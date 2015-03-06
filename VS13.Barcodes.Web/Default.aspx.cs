using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    //Members

    //Interface
    protected void Page_Load(object sender, EventArgs e) {
        //Page load event handler
        try {
            if (!Page.IsPostBack) {
                this.lblShipmentNumber.Text = "12345678";
                this.lblClient.Text = "Client Name";
                this.lblShipperName.Text = "Shipper Name";
                this.lblShipperAddress.Text = "100 Shipper Street";
                this.lblShipperCityStateZip.Text = "ShipperCity, NJ 000000";
                this.lblConsigneeName.Text = "Consignee Name";
                this.lblConsigneeAddress.Text = "100 Consignee Street";
                this.lblConsigneeCityStateZip.Text = "ConsigneeCity, NJ 00000";
                this.lblWeight.Text = "150Lbs";
                this.lblInsuredValue.Text = "$0";
                this.imgLabelNumber.ImageUrl = "BarcodeImage.aspx?barcode=12345678&fontsize=24";
                this.lblLabelNumber.Text = "12345678";
            }
        }
        catch (Exception ex) { reportError(ex,3); }
    }
    private void reportError(Exception ex,int logLevel) {
        //Report an exception to the user
        try {
            string msg = ex.Message;
            if (ex.InnerException != null) msg = ex.Message + "\n\n NOTE: " + ex.InnerException.Message;
            showMessageBox(msg);
        }
        catch (Exception) { }
    }
    private void showMessageBox(string message) {
        //
        message = message.Replace("'","").Replace("\n"," ").Replace("\r"," ");
        ScriptManager.RegisterStartupScript(this.lblMsg,typeof(Label),"Error","alert('" + message + "');",true);
    }
}
