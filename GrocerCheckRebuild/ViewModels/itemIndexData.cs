using GrocerCheckRebuild.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrocerCheckRebuild.ViewModels
{
    public class ItemIndexData
    {

        public IEnumerable<Item>  Items { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Brand> Brands { get; set; }

        public IEnumerable<Size> Sizes { get; set; }

        public IEnumerable<Grocer> Grocers { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }

}