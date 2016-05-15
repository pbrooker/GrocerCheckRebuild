using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrocerCheckRebuild.Models
{
    public class Brand
    {

        public int BrandID { get; set; }
        public string BrandName { get; set; }


        //navigation

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Grocer> Grocers { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}