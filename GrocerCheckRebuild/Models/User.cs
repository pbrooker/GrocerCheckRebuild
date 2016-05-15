using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrocerCheckRebuild.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }


        //Navigation

        public virtual ICollection<Brand> Brands { get; set; }  

        public virtual  ICollection<Size> Sizes { get; set; }

        public virtual ICollection<Grocer> Grocers { get; set; }
    }
}