using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.TableViewModels
{
    public class UserTableViewModel

    {
        public int id { get; set; }
        public string Correo { get; set; }
        public int? edad { get; set; }
    }
}