using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using LIMSReporterWeb.source.entity;
using System.Text;
using System.Data;
using LIMSReporterWeb.source.services;

namespace LIMSReporterWeb.source.dao
{
    public class ReportDAO
    {
        private readonly ILog log = LogManager.GetLogger(typeof(ReportDAO).Name);

        #region singleton
        private static ReportDAO instance;

        private ReportDAO() { }

        public static ReportDAO getInstance()
        {
            if (instance == null) instance = new ReportDAO();
            return instance;
        }
        #endregion

        public List<Report> getAllReports(String user, String password)
        {
            List<Report> reports = new List<Report>();
            SampleManagerWeb smw = new SampleManagerWeb();
            reports = smw.ListAllReports(user, password);

            return reports;
        }

        //public DataTable executeGenericQuery(String query)
        //{
        //    DataTable tableResult = new DataTable();

        //    try
        //    {
        //        OracleConnectionProvider conn = OracleConnectionProvider.getInstance();
        //        DataSet queryResult = conn.executeSelect(query);

        //        if (queryResult != null && queryResult.Tables != null && queryResult.Tables.Count > 0)
        //        {
        //            tableResult = queryResult.Tables[0];
        //        }
        //        queryResult.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        log.Error("Erro ao executar a query.", e);
        //    }

        //    return tableResult;
        //}

        //public DataTable getSamplesReport(Dictionary<ReportParameter, String> parameters, string reportID)
        //{
        //    if (reportID.Equals("ANP_RELATORIO_FINANCEIRO_FISC"))
        //    {
        //        int i = 0;
        //        List<String> rep = new List<string>();
        //        rep.Add(":ID_Contrato");
        //        rep.Add(":Data_ini");
        //        rep.Add(":Data_fim");
        //        rep.Add(":UF1");
        //        rep.Add(":UF2");
        //        //LUA 26102017
        //        rep.Add(":UF3");
        //        //LUA 26102017
        //        rep.Add(":Apenas_Fiscal");
        //        rep.Add(":Paga");
        //        rep.Add(":READ_ONLY");



        //        DataTable tableResult = new DataTable();
        //        StringBuilder query = new StringBuilder();
        //        query.Append(Properties.Settings.Default.query_amostras_financeiro.Replace("menor=", "<=").Replace("maior=", ">="));
        //        foreach (ReportParameter p in parameters.Keys)
        //        {
        //            query.Replace(rep[i], "'" + parameters[p] + "'");
        //            i++;
        //        }
        //        try
        //        {
        //            OracleConnectionProvider conn = OracleConnectionProvider.getInstance();
        //            DataSet queryResult = conn.executeSelect(query.ToString());

        //            if (queryResult != null && queryResult.Tables != null && queryResult.Tables.Count > 0)
        //            {
        //                tableResult = queryResult.Tables[0];
        //            }
        //            queryResult.Dispose();
        //        }
        //        catch (Exception e)
        //        {
        //            log.Error("Erro ao executar a query.", e);
        //        }

        //        return tableResult;
        //    }
        //    else
        //    {
        //        int i = 0;
        //        List<String> rep = new List<string>();
        //        rep.Add(":ID_Contrato");
        //        rep.Add(":Data_ini");
        //        rep.Add(":Data_fim");
        //        rep.Add(":UF1");
        //        rep.Add(":UF2");
        //        //LUA 26102017
        //        rep.Add(":UF3");
        //        //LUA 26102017
        //        rep.Add(":Paga");
        //        rep.Add(":READ_ONLY");

        //        DataTable tableResult = new DataTable();
        //        StringBuilder query = new StringBuilder();
        //        query.Append(Properties.Settings.Default.query_amostras_financeiro_monitoramento.Replace("menor=", "<=").Replace("maior=", ">="));
        //        foreach (ReportParameter p in parameters.Keys)
        //        {
        //            query.Replace(rep[i], "'" + parameters[p] + "'");
        //            i++;
        //        }
        //        try
        //        {
        //            OracleConnectionProvider conn = OracleConnectionProvider.getInstance();
        //            DataSet queryResult = conn.executeSelect(query.ToString());

        //            if (queryResult != null && queryResult.Tables != null && queryResult.Tables.Count > 0)
        //            {
        //                tableResult = queryResult.Tables[0];
        //            }
        //            queryResult.Dispose();
        //        }
        //        catch (Exception e)
        //        {
        //            log.Error("Erro ao executar a query.", e);
        //        }

        //        return tableResult;
        //    }
        //}

    }
}