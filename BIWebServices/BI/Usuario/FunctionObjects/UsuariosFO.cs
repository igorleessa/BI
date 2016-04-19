using BIWebServices.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIWebServices.BI.Usuario
{
    public class UsuariosFO
    {
        public static UsuariosBO LogarUsuario(string JsonChamada, ADODB.Connection cn)
        {
            var Usuario = new UsuariosBO();
            var Chamada = new UsuarioLoginWO();
            var Serializer = new SerializerFO();
            try
            {
                 Chamada = (UsuarioLoginWO)Serializer.DeserializarObjetoJson(JsonChamada, Chamada);
                if (UsuariosDA.ValidaUsuarioSenha(Chamada.Usuario, Chamada.SenhaAcesso, cn))
                {
                    Usuario = UsuariosDA.GetUsuarios(Chamada.Usuario, cn);
                }
                else
                {
                    throw new Exception("Usuário/senha inválidos.");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Usuario;
        }
    }
}