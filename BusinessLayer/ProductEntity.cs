using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductEntity
    {
        public int? Id;
        public int? IdType;
        public int? IdColor;
        public int? IdBrand;
        public int? IdProvider;
        public int? IdCatalog;
        public string CatTypeCode;
        public string NameColor;
        public string CatBrandCode;
        public string CatProvidersName;
        public string CatCatalogsSeason;
        public string Title;
        public string Nombre;
        public string Description;
        public string Observations;
        public decimal? PriceDistributor;
        public decimal PriceClient;
        public decimal PriceMember;
        public bool IsEnabled;
        public string Keywords;
        public DateTime? DateUpdate;
        public List<byte[]> Image;
    }
}
