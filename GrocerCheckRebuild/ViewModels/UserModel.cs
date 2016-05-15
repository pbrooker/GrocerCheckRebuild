using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrocerCheckRebuild.ViewModels
{
    public class UserModel
    {
        [EmailAddress]
        public string UserEmail { get; set; }
    }
}