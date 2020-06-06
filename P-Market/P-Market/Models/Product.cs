using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace P_Market.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Codigo")]
        public int ProductId { get; set; }

        [Display(Name = "Producto")]
        [Required]
        [MaxLength(50, ErrorMessage = "El máximo de caracteres permitido son 50.")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres permitido son 2.")]
        public string ProductName { get; set; }

        [Display(Name = "Precio")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Ultima Compra")]
        [Required]
        [DataType(DataType.Date, ErrorMessage = "El formato del campo debe ser una fecha.")]
        public DateTime ProductLastBuy { get; set; }

        [Display(Name = "Existencia")]
        [Required]
        public float ProductStock { get; set; }

        [Display(Name = "U. Mediad")]
        [MaxLength(20, ErrorMessage = "El máximo de caracteres permitido son 20.")]
        [MinLength(3, ErrorMessage = "El minimo de caracteres permitido son 3.")]
        public string ProductMeasure { get; set; }

        [Display(Name = "Categoría")]
        public int CategoryKey { get; set; }

        [ForeignKey("CategoryKey")]
        public Category Category { get; set; }
    }
}