using AutoMapper;
using MyPrj.Application.Products.Command;
using MyPrj.Application.ViewModel;
using MyPrj.Domain.Models;

namespace MyPrj.Application.MappingProfile;

public class ProductMappingProfile: Profile
{
    public ProductMappingProfile()
    {
        CreateMap<product, ProductResponse>().ReverseMap();
        CreateMap<AddProductCommand, product>().ReverseMap();
    }
}