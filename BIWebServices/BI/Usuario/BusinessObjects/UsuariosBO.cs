using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIWebServices.BI.Usuario
{
    public class UsuariosBO
    {
        public string Usuario { get; set; }
        public Boolean Inativo { get; set; }
        public string TokenAcesso { get; set; }
        public string SenhaAcesso { get; set; }
    }
}