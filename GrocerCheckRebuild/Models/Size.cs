using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrocerCheckRebuild.Models
{
    public class Size
    {
        public int SizeID { get; set; }
        public string SizeDescription { get; set; }

        //navigation

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Grocer> Grocers { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}