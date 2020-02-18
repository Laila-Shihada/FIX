<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewCustomer.aspx.cs" Inherits="AspNetUsingC.AddNewCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="NewSS.css" />
    <title>Add New Customer</title>
    <style type="text/css">
        .auto-style1 {
            width: 949px;
            height: 319px;
            margin-bottom: 0px;
        }
        .auto-style3 {
            width: 219px;
        }
        .auto-style6 {
            width: 104px;
        }
        .auto-style7 {
            width: 206px;
        }
        .auto-style9 {
            width: 104px;
            height: 119px;
        }
        .auto-style10 {
            width: 206px;
            height: 119px;
        }
        .auto-style11 {
            width: 219px;
            height: 119px;
        }
        .auto-style12 {
            background: burlywood;
            color: black;
            text-align: center;
            font: bold 12px,verdana;
        }
        .auto-style14 {
            width: 104px;
            height: 30px;
        }
        .auto-style15 {
            width: 206px;
            height: 30px;
        }
        .auto-style16 {
            width: 219px;
            height: 30px;
        }
        .auto-style18 {
            height: 20px;
            
        }
        .auto-style22 {
            width: 104px;
            height: 20px;
        }
        .auto-style23 {
            width: 206px;
            height: 20px;
        }
        .auto-style24 {
            width: 219px;
            height: 20px;
        }
        .auto-style25 {
            width: 245px;
            height: 20px;
        }
    </style>
</head>
<body style="left: 104px; top: 30px; width: 1037px; height: 539px">
    <h1>ADD NEW CUSTOMER</h1>
     <!--------------------------------------------------
   
    <button onclick="Alert.render('You look very pretty today.')">Custom Alert</button>
    <button onclick="Alert.render('And you also smell very nice.')">Custom Alert 2</button>-->
         <!--This code to create an over dialog box -->
    
    <form id="form1" runat="server">
        <div id="dialogoverlay"></div>
    <div id="dialogbox">
        <div>
            <div id="dialogboxhead"></div>
            <div id="dialogboxbody"></div>
            <div id="dialogboxfoot"></div>
        </div>
    </div> 
        <div>
            <asp:HiddenField ID ="Result" runat="server" value="1"/>
            <asp:HiddenField ID ="ID" runat="server" />
            <asp:Label ID="ErrorMessage" runat="server" Font-Size="Small" ForeColor="Red" Text="Error Message" Visible="False"></asp:Label>
            <table class="auto-style1" >
                
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LFirstName" runat="server" Text="First Name: "></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="FirstName" runat="server"  CssClass="txtBox" MaxLength="20" TabIndex="1"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="LLastName" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td class="auto-style3" colspan="2">
                        <asp:TextBox ID="LastName" runat="server"  CssClass="txtBox" MaxLength="20" TabIndex="2"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Label ID="LEmail" runat="server" Text="Email Adress :"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:TextBox ID="EmailAdress" runat="server" CssClass="txtBox" MaxLength="30" TabIndex="3" TextMode="Email"></asp:TextBox>
                    </td>
                    <td class="auto-style15">
                        <asp:Label ID="LPhoneNum" runat="server" Text="Cell Phone No:"></asp:Label>
                    </td>
                    <td class="auto-style16" colspan="2">
                        <asp:TextBox ID="PhoneNo" runat="server" CssClass="txtBox" MaxLength="10" TabIndex="4" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="LAdress" runat="server" Text="Adress"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="Adress" runat="server" Height="91px" TabIndex="5" TextMode="MultiLine" Width="234px"></asp:TextBox>
                    </td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style11" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LPromotions" runat="server" Text="Promotions"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="Promotion" runat="server" CssClass="txtBox" TabIndex="6"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="Label7" runat="server" Text="Date And Time :"></asp:Label>
                    </td>
                    <td class="auto-style3" colspan="2">
                        <asp:Label ID="dateTime" runat="server" BorderStyle="Groove" Width="225px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style3" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style3" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style24"></td>
                    <td class="auto-style22"></td>
                    <td class="auto-style23"></td>
                    <td class="auto-style24" colspan="2"></td>
                </tr>
                <tr>
                    <td class="auto-style24">
                        <asp:Button ID="Save_Button" runat="server" CssClass="auto-style12" OnClick="Save_Button_Click" TabIndex="7" Text="Save New Information" Width="182px" style="height: 22px" />
                    </td>
                    <td colspan="2" class="auto-style18"  >
                        <asp:Button ID="AddAnotherCustomer" runat="server" CssClass="auto-style12" OnClick="AddAnotherCustomer_Click" TabIndex="8" Text="Add Another New Customer" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    <td class="auto-style25">
                        <asp:Button ID="Cancel" runat="server" CssClass="auto-style12" TabIndex="9" Text="Cancel"   OnClientClick="Confirm()" OnClick="Cancel_Click" />
                        </td>
                    <td class="auto-style18">
                        <asp:Button ID="BackToMenu" runat="server"  Text="Back To Menu" CssClass="auto-style12" OnClientClick="Confirm()" OnClick="BackToMenu_Click" TabIndex="10" />
                    </td>
                </tr>
               
            </table>
        </div>
    </form>
    <script src="main.js"></script>
</body>
</html>
