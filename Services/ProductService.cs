using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService : IProductService
    {
        private readonly TestDbContext _ctx;

        public ProductService(TestDbContext ctx)
        {
            _ctx = ctx;
        }
        
		public ProductList  ListProducts(int page)
		{
            int pageSize = 10;
            var totalProducts = _ctx.Products.Count();
            var products = _ctx.Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var hasNext = (page * pageSize) < totalProducts;

            return new ProductList()
            {
                HasNext = hasNext,
                TotalCount = totalProducts,
                Products = products
            };
        }

	}
}
