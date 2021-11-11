<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="Contact_List.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="repeaterView" runat="server">
            <ItemTemplate>  
                <div>  
                    <table>  
                        <tr>  
                            <th>Contact <%#Eval("ContactID")%></th>  
                        </tr>  
                        <tr>  
                            <td>Gender</td>  
                            <td><%#Eval("Gender")%></td>  
                        </tr>  
                        <tr>  
                            <td>Title</td>  
                            <td><%#Eval("Title")%></td>  
                        </tr>  
                        <tr>  
                            <td>First Name</td>  
                            <td><%#Eval("FirstName")%></td>  
                        </tr>  
                        <tr>  
                            <td>Last Name</td>  
                            <td><%#Eval("LastName")%></td>  
                        </tr>  
                        <tr>  
                            <td>Address</td>  
                            <td><%#Eval("Address")%></td>  
                        </tr>
                        <tr>  
                            <td>Address Complement</td>  
                            <td><%#Eval("AddressComplement")%></td>  
                        </tr>  
                        <tr>  
                            <td>Postal Code</td>  
                            <td><%#Eval("PostalCode")%></td>  
                        </tr>  
                        <tr>  
                            <td>City</td>  
                            <td><%#Eval("City")%></td>  
                        </tr>  
                        <tr>  
                            <td>Region</td>  
                            <td><%#Eval("Region")%></td>  
                        </tr>  
                        <tr>  
                            <td>Country</td>  
                            <td><%#Eval("Country")%></td>  
                        </tr>  
                        <tr>  
                            <td>Email</td>  
                            <td><%#Eval("Email")%></td>  
                        </tr>  
                        <tr>  
                            <td>Phone Number</td>  
                            <td><%#Eval("PhoneNumber")%></td>  
                        </tr>  
                        <tr>  
                            <td>Message</td>  
                            <td><%#Eval("Message")%></td>  
                        </tr>  
                    </table>
                    <br />
                </div>  
            </ItemTemplate>  
            </asp:Repeater>
            <br />
        </div>
        <div>
            <asp:TextBox ID="search" runat="server" Height="25px" Width="150px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="contactsButton" runat="server" Height="30px" Text="Show All Contacts" Width="120px" OnClick="ShowAllContacts_Click" />
            <br />
            <br />
            <asp:GridView ID="gridView" runat="server" OnSelectedIndexChanged="GridView_SelectedIndexChanged" OnPageIndexChanging="GridView_PageIndexChanging" AllowPaging="True">
                <Columns>
                    <asp:CommandField SelectText="Choose" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
