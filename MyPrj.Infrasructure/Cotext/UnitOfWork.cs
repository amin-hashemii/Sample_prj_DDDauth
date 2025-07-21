using MediatR;
using MyPrj.Domain.Common;
using MyPrj.Domain.Interface;
using MyPrj.Domain.Models;
using MyPrj.Domain.Repository;
using MyPrj.Infrasructure.Event;
using MyPrj.Infrasructure.Repository;

namespace MyPrj.Infrasructure.Cotext;

public class UnitOfWork:IunitOfWork
{
    
    private readonly ApplicationDbContext _context;
    private readonly IDomainEventDispatcher _domainEventDispatcher;
    private readonly IMediator _mediator;

    public UnitOfWork(ApplicationDbContext context, IDomainEventDispatcher domainEventDispatcher, IMediator mediator)
    {
        _context = context;
        _domainEventDispatcher = domainEventDispatcher;
        _mediator = mediator;
        GenericRepository = new GenericRepository<User >(_context);
        ProductRepository = new GenericRepository<product>(_context);
    }


    public IGenericRepository<User> GenericRepository { get; }
    public IGenericRepository<product> ProductRepository { get; }

    public async Task<int> SaveChangesAsync()
    {
        var domainEntities = _context.ChangeTracker
            .Entries<IHasDomainEvents>()
            .Where(x => x.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        var result = await _context.SaveChangesAsync();

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }

        domainEntities.ForEach(e => e.Entity.ClearDomainEvents());

        return result;
    }
}