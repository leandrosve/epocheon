using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Clients.Elasticsearch;
using EpochEon.Models.DTOs.Products;
using EpochEon.Models.DTOs;
using EpochEon.Models;
using Elastic.Transport.Extensions;

namespace EpochEon.Builders
{
    public class ProductSearchQueryBuilder
    {
        private readonly string[] _default_search_fields = ["title", "description", "specs", "category.title", "brand.title"];
        private List<Query> _terms = new List<Query>();
        private List<SortOptions> _sortOptions = new List<SortOptions>();
        public int _pageNumber  = 1;
        public int _pageSize  = 10;

        private Dictionary<string, string> _sortByFields = new Dictionary<string, string>
        {
            {"title", "title.enum" },
            {"price", "price" },
            {"createdAt", "createdAt" },
        };

        public void BrandFilter(int? brandId)
        {
            if (!brandId.HasValue) return;
            _terms.Add(new TermQuery("brand.id") { Value = ((float)brandId) });
        }

        public void CategoryFilter(int? categoryId)
        {
            if (!categoryId.HasValue) return;
            _terms.Add(new TermQuery("brand.id") { Value = ((float)categoryId) });
        }

        public void SearchTermFilter(string? searchTerm)
        {
            if (searchTerm == null) return;
            _terms.Add(new MultiMatchQuery()
            {
                Fields = _default_search_fields,
                Query = searchTerm,
            });
        }

        public void PriceFilter(PriceRangeDTO? priceRange)
        {
            if (priceRange == null) return;
            _terms.Add(new NumberRangeQuery("price")
            {
                Gte = priceRange.Min,
                Lte = priceRange.Max,
            });
        }

        public void StatusFilter(ProductStatus? status)
        {
            if (!status.HasValue) return;
            _terms.Add(new TermQuery("status.enum") { Value = status.GetStringValue() });
        }

        public void PageNumber(int pageNumber)
        {
            _pageNumber = Math.Max(0, pageNumber - 1);
        }

        public void PageSize(int pageSize)
        {
            _pageSize = pageSize;
        }

        public void Sort(SortByDTO? sortBy)
        {
            if (sortBy == null) return;
            var field = _sortByFields[sortBy.Field];
            if (field == null) return;
            var fieldSort = new FieldSort();
            fieldSort.Order = sortBy.Order.ToLower() == "asc" ? SortOrder.Asc : SortOrder.Desc;
            _sortOptions.Add(SortOptions.Field(field, fieldSort));
        }

        public SearchRequest Build()
        {
            var searchDescriptor = new SearchRequest<ProductDTO>
            {
                From = (_pageNumber * _pageSize),
                Size = _pageSize,
            };

            if (_terms.Count > 0)
            {
                searchDescriptor.Query = new BoolQuery
                {
                    Must = _terms,

                };
            }

            if (_sortOptions.Count > 0)
            {
                searchDescriptor.Sort = _sortOptions;
            }

            return searchDescriptor;
        }
    }
}
