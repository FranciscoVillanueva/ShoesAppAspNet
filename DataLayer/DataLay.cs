using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class DataLay
    {
        DataProductsEntities db = new DataProductsEntities();
        public List<Products> GetProducts()
        {
            var products = db.Products.Include(p => p.CatBrands)
                .Include(p => p.CatCatalogs)
                .Include(p => p.CatColors)
                .Include(p => p.CatProviders)
                .Include(p => p.CatTypeProduct)
                .Include(p => p.ImagesProduct);
            return products.ToList();
        }

        public IEnumerable<CatBrands> GetCatBrands()
        {
            return db.CatBrands;
        }

        public IEnumerable<CatCatalogs> GetCatCatalogs()
        {
            return db.CatCatalogs;
        }

        public IEnumerable<CatColors> GetCatColors()
        {
            return db.CatColors;
        }

        public IEnumerable<CatProviders> GetCatProviders()
        {
            return db.CatProviders;
        }

        public IEnumerable<CatTypeProduct> GetCatTypeProduct()
        {
            return db.CatTypeProduct;
        }
    }
}
