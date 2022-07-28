using AutoMapper;
using Skinet.API.Dtos;
using Skinet.Core.Entities;

namespace Skinet.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
