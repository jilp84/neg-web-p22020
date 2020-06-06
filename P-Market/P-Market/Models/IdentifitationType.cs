using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P_Market.Models
{
    public class IdentifitationType
    {

        [Key]
        [Display(Name = "Codigo")]
        public int IdentifitationTypeKey { get; set; }

        [Display(Name = "Tipo de Identificación")]
        [Required]
        [MaxLength(50, ErrorMessage = "El máximo de caracteres permitido son 50.")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres permitido son 2.")]
        public string IdentifitationTypeName { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}