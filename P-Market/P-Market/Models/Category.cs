using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P_Market.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Codigo")]
        public int CategoryKey { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [MaxLength(50,ErrorMessage = "El máximo de caracteres permitidos son 50")]
        public string CotegoryName { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(150, ErrorMessage = "El máximo de caracteres permitidos son 150")]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }


    }
}