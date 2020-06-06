using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace P_Market.Models
{
    public class Client
    {
        [Key]
        [Display(Name = "Codigo")]
        public int ClientKey { get; set; }

        [Display(Name = "Cliente")]
        [Required]
        [MaxLength(50, ErrorMessage = "El máximo de caracteres permitido son 50.")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres permitido son 2.")]
        public string ClientName { get; set; }

        [Display(Name = "Telefono")]
        [DataType(DataType.PhoneNumber)]
        public string ClientPhone { get; set; }

        [Display(Name = "Numero de Indentificación")]
        [MaxLength(30, ErrorMessage = "El máximo de caracteres permitido son 30.")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres permitido son 2.")]
        public string ClientIdentificationId { get; set; }

        [Display(Name = "Tipo de Identificación")]
        public int IdentifitationTypeKey { get; set; }

        [ForeignKey("IdentifitationTypeKey")]
        public IdentifitationType IdentifitationType { get; set; }
    }
}