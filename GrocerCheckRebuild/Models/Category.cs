using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrocerCheckRebuild.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }


        //Navigation

        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<Grocer> Grocers { get; set; }

        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<Item> Items { get; set; }


    }
}