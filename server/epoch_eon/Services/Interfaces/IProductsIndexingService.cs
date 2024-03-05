using Elastic.Transport;
using EpochEon.Models.DTOs;
using EpochEon.Models.DTOs.Products;

namespace EpochEon.Services.Interfaces
{
    public interface IProductsIndexingService
    {

        public Task Index(ProductDTO dto);
        public Task IndexMany(List<ProductDTO> dtos);
        public Task ClearAll();
        public Task<SearchResultDTO<ProductDTO>> Search(ProductSearchDTO searchDTO);
        public Task<SearchResultDTO<ProductDTO>> SearchPublished(ProductSearchDTO searchDTO);

    }
}
