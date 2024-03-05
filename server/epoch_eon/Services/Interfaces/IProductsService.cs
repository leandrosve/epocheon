using EpochEon.Models.DTOs;
using EpochEon.Models.DTOs.Products;
using Prueba.Models;

namespace Prueba.Services.Interfaces
{
    public interface IProductsService
    {
        public List<ProductDTO> GetAll();

        public Task<SearchResultDTO<ProductDTO>> Search(ProductSearchDTO searchDTO);

        public ProductDTO? GetById(int id);

        public ProductDTO Create(ProductCreationDTO dto);

        public ProductDTO Update(int id, ProductUpdateDTO dto);
        public void ReIndexAll();

    }
}
