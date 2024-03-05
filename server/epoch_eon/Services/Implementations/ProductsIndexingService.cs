
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;
using Elastic.Transport.Extensions;
using EpochEon.Builders;
using EpochEon.Models;
using EpochEon.Models.DTOs;
using EpochEon.Models.DTOs.Products;
using EpochEon.Services.Interfaces;
using System.Text;

namespace EpochEon.Services.Implementations
{
    public class ProductsIndexingService : IProductsIndexingService
    {

        private readonly ILogger<ProductsIndexingService> _logger;
        private IConfiguration _configuration;
        private ElasticsearchClient _client;

        private readonly string[] _default_search_fields = ["title", "description", "specs", "category.title", "brand.title"];

        public ProductsIndexingService(IConfiguration configuration, ILogger<ProductsIndexingService> logger)
        {
            _logger = logger;
            _configuration = configuration;
            var key = _configuration.GetValue<string>("ElasticSearchSettings:Key");
            var uri = _configuration.GetValue<string>("ElasticSearchSettings:Uri");
            if (uri == null) throw new ArgumentNullException("elastic_uri_missing");
            if (key == null) throw new ArgumentNullException("elastic_key_missing");
            var connectionSettings = new ElasticsearchClientSettings();
            connectionSettings.IncludeServerStackTraceOnError();
            connectionSettings.EnableDebugMode();
            connectionSettings.Authentication(new ApiKey(key));
            connectionSettings.DefaultIndex("search-products");
            _client = new ElasticsearchClient(connectionSettings);
        }

        public async Task Index(ProductDTO dto)
        {
            await _client.IndexAsync(dto);
        }


        public async Task<SearchResultDTO<ProductDTO>> Search(ProductSearchDTO searchDTO)
        {
            return await Search(searchDTO, null);
        }

        public async Task<SearchResultDTO<ProductDTO>> SearchPublished(ProductSearchDTO searchDTO)
        {
            return await Search(searchDTO, ProductStatus.PUBLISHED);
        }

        public async Task<SearchResultDTO<ProductDTO>> Search(ProductSearchDTO searchDTO, ProductStatus? status)
        {
            var builder = new ProductSearchQueryBuilder();

            builder.BrandFilter(searchDTO.BrandId);
            builder.SearchTermFilter(searchDTO.SearchTerm);
            builder.PageNumber(searchDTO.PageNumber);
            builder.PageSize(searchDTO.PageSize);
            builder.PriceFilter(searchDTO.Price);
            builder.Sort(searchDTO.Sort);
            builder.CategoryFilter(searchDTO.CategoryId);
            builder.StatusFilter(status);

            var request = builder.Build();

            var res = await _client.SearchAsync<ProductDTO>(request);

            PrettyLogResponse(res);
            var totalResults = Convert.ToInt32(res.HitsMetadata?.Total?.Value ?? 0);
            return new SearchResultDTO<ProductDTO>
            {
                PageNumber = builder._pageNumber,
                PageSize = builder._pageSize,
                TotalResults = totalResults,
                Results = res.Documents.ToList()
            };
        }


        private void PrettyLogResponse(SearchResponse<ProductDTO> res)
        {
            var raw = Encoding.UTF8.GetString(res.ApiCallDetails.RequestBodyInBytes);
            raw.Replace("\r\n", "");
            raw.Replace("\\", "");
            _logger.LogInformation(raw);
        }

        public async Task IndexMany(List<ProductDTO> dtos)
        {
            await _client.IndexManyAsync(dtos);
        }

        public async Task ClearAll()
        {
            var deleteQuery = new DeleteByQueryRequestDescriptor<ProductDTO>("search-products");
            deleteQuery.Query(q => q.MatchAll());
            await _client.DeleteByQueryAsync(deleteQuery);
        }
    }
}
