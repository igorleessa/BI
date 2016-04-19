using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADODB;
using LibOrgm;
using BIWebServices.CORE;

namespace BIWebServices.BI.Usuario
{
    public class UsuariosDA
    {

        public static UsuariosBO GetUsuarios(string Usuario, ADODB.Connection Cn)
        {
            var Usuarios = new UsuariosBO();
            var RsUsuarios = new Recordset();

            try
            {
                RsUsuarios.Open(String.Format("SELECT * FROM dbo.Usuarios WHERE Usuario = '" + Usuario + "'"), Cn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly);
                if (!RsUsuarios.EOF)
                {
                    Usuarios.Usuario = RsUsuarios.Fields["Usuario"].Value.ToString();
                    Usuarios.SenhaAcesso = RsUsuarios.Fields["SenhaAcesso"].Value.ToString();
                    Usuarios.TokenAcesso = RsUsuarios.Fields["TokenAcesso"].Value.ToString();
                    return Usuarios;
                }
                else
                {
                    return new UsuariosBO();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static UsuariosBO UpdateUsuario(UsuariosBO Usuario, ADODB.Connection cn)
        {
            var RsUsuarios = new ADODB.Recordset();
            var LibORGM = new SQL();
            var Serializer = new SerializerFO();
            try
            {
                RsUsuarios.Open(String.Format("SELECT * FROM dbo.Usuarios WHERE Usuario = '{0}'", Usuario.Usuario), cn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic);
                if (RsUsuarios.EOF)
                {
                    RsUsuarios.AddNew();
                    RsUsuarios.Fields["Usuario"].Value = Usuario.Usuario;
                    RsUsuarios.Fields["SenhaAcesso"].Value = Usuario.SenhaAcesso;
                    RsUsuarios.Fields["TokenAcesso"].Value = CriptografiaFO.EncriptarMD5(Usuario.TokenAcesso);
                }
                RsUsuarios.Fields["Inativo"].Value = Usuario.Inativo;


                RsUsuarios.Update();
                RsUsuarios.Close();

                Usuario = UsuariosDA.GetUsuarios(Usuario.Usuario, cn);
            }
            catch (Exception)
            {

                throw;
            }

            return Usuario;
        }



         public static bool ValidaUsuarioSenha(string UsuarioID, string SenhaAcesso, ADODB.Connection cn){
            var RsUsuarios = new ADODB.Recordset();
            try
            {
                RsUsuarios.Open(String.Format("SELECT Usuario FROM Usuarios WHERE Usuario='{0}' AND SenhaAcesso='{1}'", UsuarioID, SenhaAcesso), cn, CursorTypeEnum.adOpenForwardOnly, LockTypeEnum.adLockReadOnly);
                if (!RsUsuarios.EOF)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

         
    }
}