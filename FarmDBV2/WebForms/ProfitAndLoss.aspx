<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfitAndLoss.aspx.cs" Inherits="FarmDBV2.WebForms.ProfitAndLoss" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profit and Loss Report</title>
</head>
<body>
        <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>   
  <rsweb:ReportViewer ID="ProfitAndLossReportViewer" runat="server" AsyncRendering="false" 
      Width="100%" Height="900px" BackColor="#FFFBF7"></rsweb:ReportViewer>
    </form>
</body>
</html>
