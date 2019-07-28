using AutoMapper;
using ProductsApi.DAL.Models;
using ProductsApi.BL.Models;

namespace ProductsApi.BL.Profiles
{
    public class ProductRecordProfile : Profile
    {
        public ProductRecordProfile()
        {
            CreateMap<Product, ProductRecord>();
        }

    }
}