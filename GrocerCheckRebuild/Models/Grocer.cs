using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrocerCheckRebuild.Models
{
    public class Grocer
    {
        public int GrocerID { get; set; }

        public string GrocerName { get; set; }


        //navigation

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Size> Sizes { get; set; }

        public virtual ICollection<Item> Items { get; set; }



    }
}