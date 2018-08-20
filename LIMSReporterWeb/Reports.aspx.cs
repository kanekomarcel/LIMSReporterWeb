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
    public partial class Reports : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["user"];
            Label1.Visible = false;
            Label2.Visible = false;
            genericGridView.Visible = false;

            if (user == null)
            {
                Label1.Visible = true;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Label2.Visible = true;
                genericGridView.Visible = true;
                fillGrid();
            }
            
        }

        private void fillGrid()
        {
            String userLogin = ((User)Session["user"]).Login;
            String password = ((User)Session["user"]).Password;
            //String userLogin = "SYSTEM";
            //String password = "";
            List<Report> reportList = ReportDAO.getInstance().getAllReports(userLogin, password);

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(String)));
            dt.Columns.Add(new DataColumn("Name", typeof(String)));
            dt.Columns.Add(new DataColumn("Description", typeof(String)));
            dt.Columns.Add(new DataColumn("IMReport", typeof(String)));

            foreach (Report rep in reportList)
            {
                DataRow dr = null;
                dr = dt.NewRow();
                dr["ID"] = rep.Id;
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
            GridViewRow SelectedRow = genericGridView.SelectedRow;
            string id = SelectedRow.Cells[0].Text;
            Response.Redirect("~/GenerateReport.aspx?q=" + id);
        }

        protected void genericGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void genericGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(genericGridView, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
    }
}