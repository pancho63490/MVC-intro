 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC.Models.ViewModels
{
    public class UserViewModel

    {
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage ="Correo muy largo", MinimumLength =1)]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display( Name ="Password")]
        public string password { get; set; }
        [Display(Name = "Confirmar Contrasena")]
        [Compare("password",ErrorMessage ="Las contrasenas no son Iguales ")]
        public string confimpassord { get; set;}

    }
    public class EditUserViewModel

    {
        public int id { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Correo muy largo", MinimumLength = 1)]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }
        [Required]
        public int Edad { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Confirmar Contrasena")]
        [Compare("password", ErrorMessage = "Las contrasenas no son Iguales ")]
        public string confimpassord { get; set; }

    }
}