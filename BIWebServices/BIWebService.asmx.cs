using BIWebServices.BI.Usuario;
using BIWebServices.BI.FaturamentoIVEL;
using BIWebServices.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace BIWebServices
{
    /// <summary>
    /// Summary description for BIWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BIWebService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LoginUsuario(string JsonChamada)
        {
            SerializerFO Serializer = new SerializerFO();

            var SQL = new LibOrgm.SQL();
            var cn = new ADODB.Connection();

            try
            {

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                SQL.AbrirConexao(cn);

                var LoginUsuario = UsuariosFO.LogarUsuario(JsonChamada, cn);
                Context.Response.Write(Serializer.Serializador(LoginUsuario));
            }
            catch (Exception Ex)
            {

                Context.Response.Write(TratarErro(Ex));
            }
            finally
            {
                SQL.FecharConexao(cn);
            }
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void TrazerFaturamento(string JsonChamada)
        {
            SerializerFO Serializer = new SerializerFO();

            var SQL = new LibOrgm.SQL();
            var cn = new ADODB.Connection();

            try
            {

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                SQL.AbrirConexao(cn);

                var TrazerFaturamento = FatoFaturamentoIVELDA.GetFaturamentoIVEL(JsonChamada, cn);
                Context.Response.Write(Serializer.Serializador(TrazerFaturamento));
            }
            catch (Exception Ex)
            {

                Context.Response.Write(TratarErro(Ex));
            }
            finally
            {
                SQL.FecharConexao(cn);
            }
        }


        private string TratarErro(Exception Ex)
        {
            SerializerFO Serializer = new SerializerFO();
            RetornoErroWO Retorno = new RetornoErroWO();

            try
            {
                Retorno.MensagemErro = Ex.Message;
                Retorno.StackTrace = Ex.StackTrace;

                return Serializer.Serializador(Retorno);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
