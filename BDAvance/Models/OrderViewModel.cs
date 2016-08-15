using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDAvance.Models
{
    public class OrderViewModel
    {
            [Required]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Customer Id contains numbers only")]
            [Display(Name = "Customer Id")]
            public int CustomerIdCheck { get; set; }

            [Required]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Customer Id contains numbers only")]
            [Display(Name = "Customer Id")]
            public int CustomerId { get; set; }
   
            [Required]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Abricot contains numbers only")]
            [Display(Name = "Abricot")]
            public int Abricot { get; set; }

            [Required]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Banane contains numbers only")]
            [Display(Name = "Banane")]
            public int Banane { get; set; }

            [Required]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Cerise contains numbers only")]
            [Display(Name = "Cerise")]
            public int Cerise { get; set; }

            [Required]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Fraise contains numbers only")]
            [Display(Name = "Fraise")]
            public int Fraise { get; set; }

            [Required]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Kiwi contains numbers only")]
            [Display(Name = "Kiwi")]
            public int Kiwi { get; set; }

            [Required]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Framboise contains numbers only")]
            [Display(Name = "Framboise")]
            public int Framboise { get; set; }

            [Required]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Groseille contains numbers only")]
            [Display(Name = "Groseille")]
            public int Groseille { get; set; }

            [Required]
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Prune contains numbers only")]
            [Display(Name = "Prune")]
            public int Prune { get; set; }

    }
}

