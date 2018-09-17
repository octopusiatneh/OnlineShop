using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Data.Infrastructure;
using OnlineShop.Model.Models;

namespace OnlineShop.Data.Repository
{
    public interface IProductRepository
    {

    }
    public class ProductRepository:RepositoryBase<Product>,IProductCategoryRepository
    {
        public ProductRepository(IDbFactory dbFactory)
            :base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            throw new NotImplementedException();
        }
    }
}
