using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thermo.SM.LIMSML.Helper.High;
using Thermo.SM.LIMSML.Helper.Low;
using System.IO;
using System.Xml.Serialization;
//using ANP_LIMS.SampleManagerWebService;
using log4net;
using LIMSReporterWeb.source.entity;
using System.Data;
using System.Text;
using System.Diagnostics;
//using ANP_LIMS.source.dao;
using System.Globalization;
using LIMSReporterWeb.SampleManagerWebServices;

namespace LIMSReporterWeb.source.services
{
    public class SampleManagerWeb
    {
        private readonly ILog log = LogManager.GetLogger(typeof(SampleManagerWeb).Name);

        //private readonly String smURL = Properties.Settings.Default.samplemanager_url;

        public List<Report> ListAllReports(String user, String password)
        {
            List<Report> reportsList = new List<Report>();

            try
            {
                RichDocument document = new RichDocument();
                document.SetResponseType(ResponseType.Data);

                document.AddUserLogin(user, password);
                document.EncryptAuthentication = false;
                //document.AddHeader("USER", "SYSTEM");
                //document.AddHeader("PASSWORD", "");

                Entity entity = document.AddEntity("INFOMAKER_LINK");
                Thermo.SM.LIMSML.Helper.Low.Action action = entity.AddAction("BROWSE");

                action.AddParameter("CRITERIA", "INFOMAKER_LINKS");
                action.AddParameter("FIELD", "IDENTITY");
                //action.AddParameter("ALL_VERSIONS", "FALSE");

                Limsml response = callService(document.Xml);

                if (response != null)
                {
                    if (response.NumberOfErrors() > 0)
                    {
                        for (int i = 0; i < response.Errors.Count; i++)
                        {
                            log.Error(response.GetError(i).ToString());
                        }
                        //throw new ReportGeneratorException();
                    }
                    else
                    {
                        //success
                        if (response.GetData("").Tables.Count == 0) throw new Exception("Unexpected return");

                        int rows = response.GetData("").Tables[0].Rows.Count;

                        for (int i = 0; i < rows; i++)
                        {
                            //ReportParameter parameter = new ReportParameter();
                            Report rep = new Report();
                            rep.Id = response.GetData("").Tables[0].Rows[i][0].ToString();
                            rep.Name = response.GetData("").Tables[0].Rows[i][6].ToString();
                            rep.Description = response.GetData("").Tables[0].Rows[i][7].ToString();
                            rep.Library = response.GetData("").Tables[0].Rows[i][8].ToString();
                            rep.IM_Report = response.GetData("").Tables[0].Rows[i][9].ToString();
                            reportsList.Add(rep);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("Erro ao processar o Web Service", e);

            }
        

            return reportsList;
           
        }

        public User LoginSMUSer(String user, String password)
        {
            User loggedUser = new User();
            try
            {
                RichDocument document = new RichDocument();

                document.SetResponseType(ResponseType.Data);

                document.AddUserLogin(user, password);
                document.EncryptAuthentication = false;
                //document.AddHeader("USER", "SYSTEM");
                //document.AddHeader("PASSWORD", "");

                Entity entity = document.AddEntity("USER");
                Thermo.SM.LIMSML.Helper.Low.Action action = entity.AddAction("LOGIN");

                Limsml response = callService(document.Xml);

                if (response != null)
                {
                    if (response.NumberOfErrors() > 0)
                    {
                        for (int i = 0; i < response.Errors.Count; i++)
                        {
                            log.Error(response.GetError(i).ToString());
                        }
                        //throw new ReportGeneratorException();
                    }
                    else
                    {
                        //success
                        if (response.GetData("").Tables.Count == 0) throw new Exception("Unexpected return");

                        loggedUser.Login = user;
                        loggedUser.Password = password;

                    }
                }
            }
            catch (Exception e)
            {
                log.Error("Erro ao processar o Web Service", e);

            }
            return loggedUser; 
        }

        //private static RichDocument createLIMSMLDocument(String user, String password)
        //{
        //    RichDocument document = new RichDocument();
        //    document.AddHeader("USER", user);
        //    document.AddHeader("PASSWORD", password);
 
        //    return document;
        //}

        private Limsml callService(string requestXml)
        {
            return callService(requestXml, true);
        }

        private Limsml callService(string requestXml, bool logResponse)
        {
            Document response = null;
            string responseXml;

            try
            {
                LIMSWebServiceClient service = new LIMSWebServiceClient();
                
                //service. = HttpParseException; ;
                //service.Timeout = Properties.Settings.Default.wcf_timeout * 60 * 1000;
                log.Debug("Calling WebService: " + requestXml);
                responseXml = service.Process(requestXml);
                if (logResponse)
                {
                    log.Debug("Response: " + responseXml);
                }
                service.Close();
                service = null;
            }
            catch (Exception e)
            {
                log.Error("Error processing Web Service: ", e);
                responseXml = e.ToString();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Document));

                StringReader reader = new StringReader(responseXml);
                response = (Document)serializer.Deserialize(reader);
            }
            catch (Exception e)
            {
                log.Error("Error parsing XML", e);
                response = new Document();
                response.AddError(e.Message);
            }

            return response;
        }


        #region relatorio
        //public List<ReportParameter> getReportParameters(User user, String reportName)
        //{
        //    RichDocument limsml = createLIMSMLDocument(user);
        //    limsml.SetResponseType(ResponseType.Data);

        //    Entity entity = limsml.AddEntity("INFOMAKER_REPORT");
        //    Thermo.SM.LIMSML.Helper.Low.Action action = entity.AddAction("GET_PARAMETERS");
        //    action.AddParameter("REPORT_ID", reportName);

        //    Limsml response = callService(limsml.Xml);
        //    if (response != null && response.NumberOfErrors() > 0)
        //    {
        //        for (int i = 0; i < response.Errors.Count; i++)
        //        {
        //            log.Error(response.GetError(i).ToString());
        //        }
        //        //throw new ReportGeneratorException();
        //    }

        //    List<ReportParameter> parameterList = new List<ReportParameter>();

        //    try
        //    {
        //        if (response.GetData("").Tables.Count == 0) throw new Exception("Retorno nao esperado");
        //        int rows = response.GetData("").Tables[0].Rows.Count;

        //        for (int i = 0; i < rows; i++)
        //        {
        //            ReportParameter parameter = new ReportParameter();

        //            /*
        //             *  0 - Identificador
        //             *  1 - Descricao
        //             *  2 - Tipo do parametro
        //             *  8 - Obrigatorio
        //             * 10 - Valor default
        //             * 13 - Nome da tabela
        //             * 14 - Coluna da tabela para retornar
        //             * 15 - Lista da phrase
        //             * Ignoro o valor default, por nao fazer muito sentido na parte web
        //             */
        //            parameter.Argument = response.GetData("").Tables[0].Rows[i][0].ToString();
        //            parameter.LabelText = response.GetData("").Tables[0].Rows[i][1].ToString();
        //            parameter.Type = response.GetData("").Tables[0].Rows[i][2].ToString();
        //            parameter.Mandatory = "True".Equals(response.GetData("").Tables[0].Rows[i][8].ToString()) ? true : false;
        //            parameter.TableName = response.GetData("").Tables[0].Rows[i][13].ToString();
        //            parameter.TableColumn = response.GetData("").Tables[0].Rows[i][14].ToString();
        //            if ("TEXT".Equals(parameter.Type))
        //            {
        //                if (!String.IsNullOrEmpty(parameter.TableName))
        //                {
        //                    parameter.Type = "TABLE";
        //                }
        //            }
        //            else if ("SELECTION".Equals(parameter.Type))
        //            {
        //                String[] selectionList = response.GetData("").Tables[0].Rows[i][15].ToString().Split(';');
        //                parameter.PhraseList = new List<Phrase>();
        //                int phraseIndex = 0;
        //                // removo um da contagem pois o wcf retorna um ; a mais
        //                while (phraseIndex < selectionList.Count() - 1)
        //                {
        //                    Phrase phrase = new Phrase();
        //                    phrase.Id = selectionList[phraseIndex];
        //                    phrase.Text = selectionList[phraseIndex + 1];
        //                    parameter.PhraseList.Add(phrase);
        //                    phraseIndex = phraseIndex + 2;
        //                }
        //            }
        //            parameterList.Add(parameter);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        log.Error(e);
        //        //throw new ReportGeneratorException();
        //    }

        //    return parameterList;
        //}

        //public String generateReport(User user, String reportFileName, String reportName, Dictionary<ReportParameter, String> parameters)
        //{
        //    RichDocument limsml = createLIMSMLDocument(user);
        //    limsml.SetResponseType(ResponseType.Data);

        //    Entity entity = limsml.AddEntity("INFOMAKER_REPORT");
        //    Thermo.SM.LIMSML.Helper.Low.Action action = entity.AddAction("GENERATE");
        //    action.AddParameter("REPORT_ID", reportName);

        //    string id_relatorio_gerado = user.Institution.GroupId.ToString() + "_" + DateTime.Now.Day.ToString().PadLeft(2, '0') +
        //                DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString().PadLeft(2, '0')
        //                + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');

        //    if (parameters != null)
        //    {
        //        foreach (ReportParameter parameter in parameters.Keys)
        //        {
        //            if (parameter.Argument.Equals("READ_ONLY"))
        //            {
        //                entity.AddField(parameter.Argument, id_relatorio_gerado, Direction.In);
        //            }
        //            else entity.AddField(parameter.Argument, parameters[parameter], Direction.In);
        //        }
        //    }

        //    Limsml response = callService(limsml.Xml, true);

        //    if (response != null && response.NumberOfErrors() > 0)
        //    {
        //        for (int i = 0; i < response.Errors.Count; i++)
        //        {
        //            log.Error(response.Errors[i].Summary);
        //        }
        //        //throw new ReportGeneratorException();
        //    }

        //    MemoryStream stream = response.GetFile(String.Empty);
        //    BinaryReader reader = new BinaryReader(stream);
        //    File.WriteAllBytes(reportFileName, reader.ReadBytes((int)stream.Length));

        //    Process.Start(reportFileName);


        //    return reportFileName;
        //}
        #endregion

    }
}