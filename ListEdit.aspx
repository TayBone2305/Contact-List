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
    <form id="form1" runat="server">
        <div class="auto-style2">
            <asp:Label ID="contactID" runat="server" Text=""> 
            </asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="gender" runat="server" Height="20px" Width="206px">
                <asp:ListItem Value="" disabled selected hidden>Please Select Gender</asp:ListItem>
                <asp:ListItem Value="Male"></asp:ListItem>
                <asp:ListItem Value="Female"></asp:ListItem>
                <asp:ListItem Value="Other"></asp:ListItem>
            </asp:DropDownList> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:RequiredFieldValidator id="genderValidator" runat="server"
                ControlToValidate="firstName"
                ErrorMessage="Gender is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
             </asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Textbox ID="title" runat="server" placeholder="Title" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            <br />
            <br />
            <br />
            <asp:Textbox ID="firstName" runat="server" placeholder="First Name" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Textbox ID="lastName" runat="server" placeholder="Last Name" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            <br />
            <asp:RequiredFieldValidator id="firstNameValidator" runat="server"
                ControlToValidate="firstName"
                ErrorMessage="First Name is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
            </asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator id="lastNameValidator" runat="server"
                ControlToValidate="lastName"
                ErrorMessage="Last Name is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
            </asp:RequiredFieldValidator> 
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />     
            <asp:Textbox ID="address" runat="server" placeholder="Address" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Textbox ID="addressComplement" runat="server" placeholder="Address Complement" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            <br />
            <asp:RequiredFieldValidator id="addressValidator" runat="server"
                ControlToValidate="address"
                ErrorMessage="Address is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
            </asp:RequiredFieldValidator>
            <br /><br />
            <asp:Textbox ID="postalCode" runat="server" placeholder="Postal Code" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Textbox ID="city" runat="server" placeholder="City" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            <br />
            <asp:RequiredFieldValidator id="postalCodeValidator" runat="server"
                ControlToValidate="postalCode"
                ErrorMessage="Postal Code is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
            </asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator id="citydValidator" runat="server"
                ControlToValidate="city"
                ErrorMessage="City is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small">
            </asp:RequiredFieldValidator>
            <br /><br />
            <asp:Textbox ID="region" runat="server" placeholder="Region" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Textbox ID="country" runat="server" placeholder="Country" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator id="countryValidator" runat="server"
                ControlToValidate="country"
                ErrorMessage="Country is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small"> </asp:RequiredFieldValidator>
            <br /><br />
            <asp:Textbox ID="email" runat="server" placeholder="Email" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Textbox ID="phoneNumber" runat="server" placeholder="Phone Number" BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="200px" Font-Size="1em" Font-Names="Times New Roman"></asp:Textbox>
            <br />
            <asp:RequiredFieldValidator id="emailValidator" runat="server"
                ControlToValidate="email"
                ErrorMessage="Email is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small"> </asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator id="phoneNumberValidator" runat="server"
                ControlToValidate="phoneNumber"
                ErrorMessage="Phone Number is a required field!"
                ForeColor="Red" Height="20px" Width="204px" Font-Size="Small"> </asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br /><br />
            <asp:Textbox ID="message" runat="server" placeholder="Write your optional message here..." BorderStyle="Solid" BorderWidth="1px" Height="150px" Width="471px" Font-Size="1em" Font-Names="Times New Roman" TextMode="MultiLine"></asp:Textbox> 
            <br /><br />
            <asp:Button ID="save" runat="server" Text="Save/Update" Height="30px" Width="125px" OnClick="SaveOrUpdate_Click"/> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        </div>
    </form>
</body>
</html>
