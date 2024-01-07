using AdventureWorks.Controllers;
using AdventureWorks.EfModels;
using AdventureWorks.Interface;
using AdventureWorks.ViewModels;

namespace AdventureWorks.Repositories
{
    public class ProductCategoryRepository : IRepository<ProductCategoryVM>
    {
        private readonly AdventureWorksContext _db;

        public ProductCategoryRepository(ILogger<HomeController> logger
                                , AdventureWorksContext db)
        {
            _db = db;
        }

        public ProductCategoryVM Get(int id)
        {
            ProductCategoryVM productCategory = GetAll().FirstOrDefault(pc => pc.ProductID == id);

            return productCategory;
        }

        public List<ProductCategoryVM> GetAll()
        {
            List<ProductCategoryVM> productCategories = _db.Products.Join(_db.ProductCategories,
                               p => p.ProductCategoryId,
                               c => c.ProductCategoryId,
                               (p, c) => new ProductCategoryVM
                               {
                                   ProductID = (int)p.ProductId,
                                   ProductName = p.Name,
                                   ProductNumber = p.ProductNumber,
                                   Color = p.Color,
                                   CategoryName = c.Name,
                               }).ToList();
          ;

            return productCategories;
        }
    }
}

