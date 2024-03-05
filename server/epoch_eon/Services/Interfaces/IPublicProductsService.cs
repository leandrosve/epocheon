using EpochEon.Models.DTOs;
using EpochEon.Models.DTOs.Products;
using Prueba.Models;

namespace Prueba.Services.Interfaces
{
    public interface IPublicProductsService
    {
        public Task<SearchResultDTO<ProductDTO>> Search(ProductSearchDTO searchDTO);

        public ProductDTO? GetById(int id);

    }
}
