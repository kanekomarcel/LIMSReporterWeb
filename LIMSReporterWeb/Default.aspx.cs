using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LIMSReporterWeb.source.services;
using LIMSReporterWeb.source.entity;

namespace LIMSReporterWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user.Login = "SYSTEM";
            user.Password = "";
            Session.Add("user", user);
            //List<Report> reports = new List<Report>();
            //SampleManagerWeb smw = new SampleManagerWeb();
            //reports = smw.ListAllReports("SYSTEM", "");
        }
    }
}