using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace EpochEon.Extensions
{
    public static class QueryExtensions
    {

        public static IQueryable<Product> BuildProduct(this IQueryable<Product> query)
        {
            return query.Include(x => x.Category)
                        .Include(x => x.Images)
                        .Include(x => x.Brand);
        }



    }
}
