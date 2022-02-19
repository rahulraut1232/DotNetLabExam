using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCExamMain.Models
{
    public class Products
    {
        [Key]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }
        
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Enter Product Name")]
        [Display(Name = "Product Name")]
        [StringLength(10,ErrorMessage ="Given {0} Value Shoud not exceed {1} characters. ")]
        public string ProductName { get; set; }

        [Range(2000,60000,ErrorMessage ="Please enter value between 2000-60000")]
        [MaxLength(6),MinLength(4)]
        [Display(Name ="Rate")]
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(10, ErrorMessage = "Given {0} Value Shoud not exceed {1} characters. ")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Category")]
        [StringLength(10, ErrorMessage = "Given {0} Value Shoud not exceed {1} characters. ")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}