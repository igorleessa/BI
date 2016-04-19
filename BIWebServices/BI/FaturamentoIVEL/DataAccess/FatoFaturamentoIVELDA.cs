using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIWebServices.BI.FaturamentoIVEL
{
    public class FatoFaturamentoIVELDA
    {
        public static FatoFaturamentoIVELBO[] GetFaturamentoIVEL(string Operacao, Connection Cn)
        {

            var RsFaturamento = new Recordset();
            int Cont = 0;
            int CountCor = 0;
            try
            {
                RsFaturamento.Open(String.Format("SELECT Operacao, AnoMes, TradeMarketing, SUM(ValorNF)AS ValorTotal FROM dbo.FatoFaturamentoIVEL WHERE TradeMarketing = 0  and AnoMes = '2016/04' GROUP BY Operacao, AnoMes, TradeMarketing ORDER BY SUM(ValorNF) ASC", Operacao), Cn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly);
                var ArrayRetorno = new FatoFaturamentoIVELBO[RsFaturamento.RecordCount];
                while (!RsFaturamento.EOF)
                {
                    FatoFaturamentoIVELBO Faturamento = new FatoFaturamentoIVELBO();
                    Faturamento.Operacao = RsFaturamento.Fields["Operacao"].Value.ToString();
                    Faturamento.AnoMes = RsFaturamento.Fields["AnoMes"].Value.ToString();
                    Faturamento.ValorNF = decimal.Parse(RsFaturamento.Fields["ValorTotal"].Value.ToString());
                    Faturamento.CodHex = GetCor(CountCor++, ref Cn);

                    ArrayRetorno[Cont] = Faturamento;

                    Cont++;
                    RsFaturamento.MoveNext();
                }

                RsFaturamento.Close();

                return ArrayRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }





        private static string GetCor(int IdCor, ref Connection Cn)
        {
            var RsCor = new Recordset();

            try
            {
                RsCor.Open(String.Format("SELECT IdCor, CodHex from dbo.GraficoCor  where IdCor = {0}", IdCor), Cn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly);
                if (!RsCor.EOF)
                {
                    return RsCor.Fields["CodHex"].Value.ToString();
                }
                else
                {
                    //nao encontrou a cor vc faz o que?????? retorna pink! uhahuahuhuahuahuahua
                    return "#FFFFFF";

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro :" + ex.Message);
            }
        }









        //>>>>>>>>>>>>>>>>>Metodo 2<<<<<<<<<<<<<<<<< 
        //public static FatoFaturamentoIVELBO[] GetFaturamentoIVEL(string Operacao, Connection Cn)
        //{

        //    var RsFaturamento = new Recordset();
        //    int Cont = 0;
        //    int CountCor = 0;
        //    try
        //    {
        //        RsFaturamento.Open(String.Format("SELECT Operacao, AnoMes, TradeMarketing, SUM(ValorNF)AS ValorTotal FROM dbo.FatoFaturamentoIVEL WHERE TradeMarketing = 0  and AnoMes = '2016/04' GROUP BY Operacao, AnoMes, TradeMarketing ORDER BY SUM(ValorNF) ASC", Operacao), Cn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly);
        //        var ArrayRetorno = new FatoFaturamentoIVELBO[RsFaturamento.RecordCount];
        //        while (!RsFaturamento.EOF)
        //        {
        //            FatoFaturamentoIVELBO Faturamento = new FatoFaturamentoIVELBO();
        //            Faturamento.Operacao = RsFaturamento.Fields["Operacao"].Value.ToString();
        //            Faturamento.AnoMes = RsFaturamento.Fields["AnoMes"].Value.ToString();
        //            Faturamento.ValorNF = decimal.Parse(RsFaturamento.Fields["ValorTotal"].Value.ToString());
        //            Faturamento.CodHex = GetCor(CountCor++, Cn);
        //            SetCor(ref Faturamento, CountCor++, Cn);

        //            ArrayRetorno[Cont] = Faturamento;

        //            Cont++;
        //            RsFaturamento.MoveNext();
        //        }

        //        RsFaturamento.Close();

        //        return ArrayRetorno;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Erro: " + ex.Message);
        //    }
        //}





        //private static string GetCor(int IdCor, Connection Cn)
        //{
        //    var RsCor = new Recordset();

        //    try
        //    {
        //        RsCor.Open(String.Format("SELECT IdCor, CodHex from dbo.GraficoCor  where IdCor = {0}", IdCor), Cn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly);
        //        if (!RsCor.EOF)
        //        {
        //            return RsCor.Fields["CodHex"].Value.ToString();
        //        }
        //        else
        //        {
        //            //nao encontrou a cor vc faz o que?????? retorna pink! uhahuahuhuahuahuahua
        //            return "#FFFFFF";

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Erro :" + ex.Message);
        //    }
        //}



        //private static void SetCor(ref FatoFaturamentoIVELBO fat, int IdCor, Connection Cn)
        //{
        //    var RsCor = new Recordset();

        //    try
        //    {
        //        RsCor.Open(String.Format("SELECT IdCor, CodHex from dbo.GraficoCor  where IdCor = {0}", IdCor), Cn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly);
        //        if (!RsCor.EOF)
        //        {
        //            fat.CodHex = RsCor.Fields["CodHex"].Value.ToString();
        //        }
        //        else
        //        {
        //            //nao encontrou a cor vc faz o que?????? retorna pink! uhahuahuhuahuahuahua
        //            fat.CodHex = "#FFFFFF";

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Erro :" + ex.Message);
        //    }
        //}



    }
}