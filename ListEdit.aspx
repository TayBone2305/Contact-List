<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListEdit.aspx.cs" Inherits="Contact_List.ListEdit" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <style>
            .auto-style2 {
                height: 1000px;
                width: 666px;
            }
        </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="auto-style2">
            <asp:Label ID="ContactID" runat="server" Text=""> 
            </asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="Gender" runat="server" Height="20px" Width="206px" AppendDataBoundItems="False" AutoPostBack="True" CausesValidation="True">
                <asp:ListItem Enabled="true" Selected="True" Hidden="True" Value="0" Text="Please Select Gender"></asp:ListItem>
                <asp:ListItem Text="Male"></asp:ListItem>
                <asp:ListItem Text="Female"></asp:ListItem>
                <asp:ListItem Text="Other"></asp:ListItem>
            </asp:DropDownList> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:RequiredFieldValidator id="GenderValidator" runat="server"
                ControlToValidate="Gender"
                ErrorMessage="Gender is a required field!"
                SetFocusOnError="true"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
             </asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Textbox ID="Title" runat="server" placeholder="Title" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            <br />
            <br />
            <br />
            <asp:Textbox ID="FirstName" runat="server" placeholder="First Name" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Textbox ID="LastName" runat="server" placeholder="Last Name" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            <br />
            <asp:RequiredFieldValidator id="FirstNameValidator" runat="server"
                ControlToValidate="FirstName"
                ErrorMessage="First Name is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
            </asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator id="LastNameValidator" runat="server"
                ControlToValidate="LastName"
                ErrorMessage="Last Name is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
            </asp:RequiredFieldValidator> 
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />     
            <asp:Textbox ID="Address" runat="server" placeholder="Address" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Textbox ID="AddressComplement" runat="server" placeholder="Address Complement" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            <br />
            <asp:RequiredFieldValidator id="AddressValidator" runat="server"
                ControlToValidate="Address"
                ErrorMessage="Address is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
            </asp:RequiredFieldValidator>
            <br /><br />
            <asp:Textbox ID="PostalCode" runat="server" placeholder="Postal Code" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Textbox ID="City" runat="server" placeholder="City" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            <br />
            <asp:RequiredFieldValidator id="PostalCodeValidator" runat="server"
                ControlToValidate="PostalCode"
                ErrorMessage="Postal Code is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
            </asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator id="CitydValidator" runat="server"
                ControlToValidate="City"
                ErrorMessage="City is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
            </asp:RequiredFieldValidator>
            <br /><br />
            <asp:Textbox ID="Region" runat="server" placeholder="Region" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Textbox ID="Country" runat="server" placeholder="Country" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator id="CountryValidator" runat="server"
                ControlToValidate="Country"
                ErrorMessage="Country is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small"> </asp:RequiredFieldValidator>
            <br /><br />
            <asp:Textbox ID="Email" runat="server" placeholder="Email" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Textbox ID="PhoneNumber" runat="server" placeholder="Phone Number" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox>
            <br />
            <asp:RequiredFieldValidator id="EmailValidator" runat="server"
                ControlToValidate="Email"
                ErrorMessage="Email is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small"> </asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator id="PhoneNumberValidator" runat="server"
                ControlToValidate="PhoneNumber"
                ErrorMessage="Phone Number is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small"> </asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br /><br />
            <asp:Textbox ID="Message" runat="server" placeholder="Write your optional message here..." BorderStyle="Solid" BorderWidth="1px" Height="150px" Width="471px" Font-Size="1em" Font-Names="Times New Roman" TextMode="MultiLine"></asp:Textbox> 
            <br /><br />
            <asp:Button ID="Save" runat="server" Text="Save/Update" Height="30px" Width="125px" OnClick="SaveOrUpdate_Click"/> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        </div>
    </form>
</body>
</html>
