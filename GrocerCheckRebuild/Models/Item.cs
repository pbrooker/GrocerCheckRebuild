using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrocerCheckRebuild.Models
{
    public class Item
    {
        public int ItemID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [StringLength(65)]
        public string Name { get; set; }

        public string StandardID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Display(Name ="weight/volume/quantity")]
        public int SizeMeasure { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Price per 100 units")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public Nullable<decimal> CalculatedPrice
        {
            get { return (Price/SizeMeasure)*100; }
            private set { }
        }

        public int SizeID { get; set; }
        public int BrandID { get; set; }

        public int CategoryID { get; set; }
        public int GrocerID { get; set; }
        public int SizeTypeID { get; set; }

        //Navigation

        public virtual Size Size { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Grocer Grocer { get; set; }
        public virtual SizeType SizeType { get; set; }


    }
}