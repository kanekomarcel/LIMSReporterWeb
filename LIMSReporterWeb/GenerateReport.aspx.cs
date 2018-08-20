using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LIMSReporterWeb.source.dao;
using LIMSReporterWeb.source.entity;

namespace LIMSReporterWeb
{
    public partial class GenerateReport : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["user"];
            //Label1.Visible = false;
            //Label2.Visible = false;
            //genericGridView.Visible = false;
            if (user == null)
            {
                //Label1.Visible = true;
                Response.Redirect("~/Reports.aspx");
            }
            else
            {
                //Label2.Visible = true;
                fillGrid();
            }
            
        }

        private void fillGrid()
        {
            //String userLogin = ((User)Session["user"]).Login;
            //String password = ((User)Session["user"]).Password;
            String userLogin = "SYSTEM";
            String password = "";
            List<Report> reportList = ReportDAO.getInstance().getAllReports(userLogin, password);

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Name", typeof(String)));
            dt.Columns.Add(new DataColumn("Description", typeof(String)));
            dt.Columns.Add(new DataColumn("IMReport", typeof(String)));

            foreach (Report rep in reportList)
            {
                DataRow dr = null;
                dr = dt.NewRow();
                dr["Name"] = rep.Name;
                dr["Description"] = rep.Description;
                dr["IMReport"] = rep.IM_Report;
                dt.Rows.Add(dr);
            }

            ViewState["CurrentTable"] = dt;

            genericGridView.DataSource = dt;
            genericGridView.DataBind();
        }

        protected void genericGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}