using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class BusinessLay
    {
        DataLay Data = new DataLay();
        DataProductsEntities db = new DataProductsEntities();
        public List<ProductEntity> GetProductEntities()
        {
            List<ProductEntity> List = new List<ProductEntity>();
            foreach (var item in Data.GetProducts())
            {
                ProductEntity Product = new ProductEntity()
                {
                    Id = item.Id,
                    IdType = item.IdType,
                    IdColor = item.IdColor,
                    IdBrand = item.IdBrand,
                    IdProvider = item.IdProvider,
                    IdCatalog = item.IdCatalog,
                    Title = item.Title,
                    Nombre = item.Nombre,
                    Description = item.Description,
                    Observations = item.Observations,
                    PriceDistributor = item.PriceDistributor,
                    PriceClient = item.PriceClient,
                    PriceMember = item.PriceMember,
                    IsEnabled = item.IsEnabled,
                    Keywords = item.Keywords,
                    DateUpdate = item.DateUpdate,
                    Image = item.ImagesProduct.Select(x => x.Image).ToList(),
                };

                if (item.CatTypeProduct != null)
                {
                    Product.CatTypeCode = item.CatTypeProduct.Code;
                }

                if (item.CatColors != null)
                {
                    Product.NameColor = item.CatColors.Name;
                }

                if (item.CatBrands != null)
                {
                    Product.CatBrandCode = item.CatBrands.Code;
                }

                if (item.CatProviders != null)
                {
                    Product.CatProvidersName = item.CatProviders.Name;
                }

                if (item.CatCatalogs != null)
                {
                    Product.CatCatalogsSeason = item.CatCatalogs.Season;
                }  
                    
                List.Add(Product);
            }
            return List;
        }

        public void AddProduct(Products product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Edit(Products products)
        {
            db.Entry(products).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Products Find(int? id)
        {
            return db.Products.Find(id);
        }

        public void Delete(Products products)
        {
            db.Products.Remove(products);
            db.SaveChanges();
        }

        public void AddImage(byte[] img, int id)
        {
            ImagesProduct ImagReg = new ImagesProduct()
            {
                IdImageProduct = id, //id,
                Decription = "Image",
                Image = img,
                DateUpdate = DateTime.Now + "",
                IsEnabled = "true",
            };
            db.ImagesProduct.Add(ImagReg);
            db.SaveChanges();
            //SqlException: The INSERT statement conflicted
            //        with the FOREIGN KEY constraint "FK_CatBrandsImagesProduct".
            //        The conflict occurred in database "DataProducts", table "dbo.CatBrands", 
            //    column 'IdBrand'.
        }
    }
}
