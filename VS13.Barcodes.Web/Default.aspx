<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Barcodes</title>
    <style>
        body { font-family: Calibri, sans-serif; font-size: 10pt; color: #000000; background-color: #ffffff; text-align: left; }
        #page { position: relative; width: 700px; height: 375px; margin: auto; text-align: left; background-color: #ffffff; }
        #header { height: 75px; }
        #logo { float: left; display: inline; width: auto; margin: 0px 5px 5px 5px; }
        #title { float: right; display: inline; width: auto; margin: 20px 0px 0px 0px; padding: 0px 0px 0px 5px; color: #000000; font-family: Calibri; font-size: 16pt; font-weight: 400; text-align: right; }
        #body { position: relative; width: 700px; padding: 0px 0px 0px 0px; }
        .biglabel { padding: 0px 0px 0px 0px; font-size: 12pt; font-weight: bold; text-align: right; }
        .label { padding: 0px 0px 0px 0px; font-size: 10pt; font-weight: bold; text-align: right; }
        .clear { clear: both;  }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smPage" runat="server" EnablePartialRendering="true" ScriptMode="Auto" LoadScriptsBeforeUI="false" />
        <div id="page">
            <div id="header">
                <div id="logo">
                    <img id="imgLogo" runat="server" src="~/App_Themes/VS13/Images/barcode.gif" alt="logo" style="border: 0;" />
                    <asp:UpdatePanel runat="server" ID="pnlMsg" UpdateMode="Always"><ContentTemplate><asp:Label ID="lblMsg" runat="server" Text="" /></ContentTemplate></asp:UpdatePanel>
               </div>
                <div id="title">Barcoded Web Document</div>
            </div>
            <div class="clear"></div>
            <div id="body">
                <table style="width:700px; border:1px solid #c5c7c9">
                    <tr style="height:1px; font-size:1px"><td style="width:100px">&nbsp;</td><td style="width:250px">&nbsp;</td><td style="width:100px">&nbsp;</td><td style="width:250px">&nbsp;</td></tr>
                    <tr style="height:25px;">
                        <td class="biglabel">CLIENT:&nbsp;</td><td><asp:Label ID="lblClient" runat="server" Text="" /></td>
                        <td class="biglabel">FROM:&nbsp;</td><td><asp:Label ID="lblShipperName" runat="server" Text="" /></td>
                    </tr>
                    <tr style="height:25px;">
                        <td class="label">&nbsp;</td><td>&nbsp;</td>
                        <td class="label">&nbsp;</td><td><asp:Label ID="lblShipperAddress" runat="server" Text="" /></td>
                    </tr>
                    <tr style="height:25px;">
                        <td class="label">&nbsp;</td><td>&nbsp;</td>
                        <td class="label">&nbsp;</td><td><asp:Label ID="lblShipperCityStateZip" runat="server" Text="" /></td>
                    </tr>
                    <tr style="height:25px;"><td class="label">&nbsp;</td><td>&nbsp;</td><td class="label">&nbsp;</td><td>&nbsp;</td></tr>
                    <tr style="height:25px;">
                        <td class="label">Shipment#:&nbsp;</td><td><asp:Label ID="lblShipmentNumber" runat="server" Text="" /></td>
                        <td class="biglabel">TO:&nbsp;</td><td><asp:Label ID="lblConsigneeName" runat="server" Text="" /></td>
                    </tr>
                    <tr style="height:25px;">
                        <td class="label">Weight:&nbsp;</td><td><asp:Label ID="lblWeight" runat="server" Text="" /></td>
                        <td class="label">&nbsp;</td><td><asp:Label ID="lblConsigneeAddress" runat="server" Text="" /></td>
                    </tr>
                    <tr style="height:25px;">
                        <td class="label">Insured Value:&nbsp;</td><td><asp:Label ID="lblInsuredValue" runat="server" Text="" /></td>
                        <td class="label">&nbsp;</td><td><asp:Label ID="lblConsigneeCityStateZip" runat="server" Text="" /></td>
                    </tr>
                    <tr style="height:25px;"><td class="label">&nbsp;</td><td>&nbsp;</td><td class="label">&nbsp;</td><td>&nbsp;</td></tr>
                    <tr style="height:75px;"><td colspan="4" style="text-align:center"><asp:Image ID="imgLabelNumber" runat="server" ImageUrl="" Height="50px" /></td></tr>
                    <tr style="height:25px;"><td colspan="4" style="text-align:center; font-size:12pt"><asp:Label ID="lblLabelNumber" runat="server" Text="" /></td></tr>
                    <tr style="height:25px;"><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
