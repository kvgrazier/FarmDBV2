using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace FarmDBV2.WebForms
{
    public partial class ProfitAndLoss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProfitAndLossReportViewer.ProcessingMode = ProcessingMode.Local;
                ProfitAndLossReportViewer.LocalReport.ReportPath = Server.MapPath("ProfitAndLossReportViewer.rdlc");
                ProfitAndLossDataSetTableAdapters.tvfProfitLossTableAdapter ta = new ProfitAndLossDataSetTableAdapters.tvfProfitLossTableAdapter();
                DataTable dt = new DataTable();
                dt = ta.GetData(Request.QueryString["firstDay"], Request.QueryString["lastDay"], Convert.ToInt32(Request.QueryString["PersonID"]));
                ReportDataSource datasource = new
                    ReportDataSource("ProfitAndLossDataSet", dt);
                ProfitAndLossReportViewer.LocalReport.DataSources.Clear();
                ProfitAndLossReportViewer.LocalReport.DataSources.Add(datasource);
            }
        }
    }
}