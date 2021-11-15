using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;

namespace Contact_List
{
    public partial class ListEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Is it the first time the page loads? -> No
            if (Page.IsPostBack == false)
            {
                // Is there an ID in the URL? -> Yes
                if (Request.QueryString["ContactID"] != null)
                {
                    #region
                    /*** BAD CODE ***
                    ContactID.Text = "Contact" + Request.QueryString["ContactID"];
                    gender.SelectedItem.Text = Request.QueryString["gender"].ToString();
                    title.Text = Request.QueryString["title"];
                    firstName.Text = Request.QueryString["firstName"];
                    lastName.Text = Request.QueryString["lastName"];
                    address.Text = Request.QueryString["address"];
                    addressComplement.Text = Request.QueryString["addressComplement"];
                    postalCode.Text = Request.QueryString["postalCode"];
                    city.Text = Request.QueryString["city"];
                    region.Text = Request.QueryString["region"];
                    country.Text = Request.QueryString["country"];
                    email.Text = Request.QueryString["email"];
                    phoneNumber.Text = Request.QueryString["phoneNumber"];
                    message.Text = Request.QueryString["message"];
                    ***/
                    #endregion

                    string connectionID = Request.QueryString["ContactID"];
                    string sqlQuery = "Select * From ContactList Where ContactID = @ContactID";

                    var dbConnection = DatabaseConnection.DbConnectInstance;
                    dbConnection.BuildConnection(sqlQuery);
                    dbConnection.GetSqlCommand().Parameters.AddWithValue("@ContactID", connectionID);

                    SqlDataReader sqlDataReader = dbConnection.GetSqlCommand().ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            ContactID.Text = sqlDataReader["ContactID"].ToString();
                            Gender.SelectedItem.Text = sqlDataReader["Gender"].ToString();
                            Title.Text = sqlDataReader["Title"].ToString();
                            FirstName.Text = sqlDataReader["FirstName"].ToString();
                            LastName.Text = sqlDataReader["LastName"].ToString();
                            Address.Text = sqlDataReader["Address"].ToString();
                            AddressComplement.Text = sqlDataReader["AddressComplement"].ToString();
                            PostalCode.Text = sqlDataReader["PostalCode"].ToString();
                            City.Text = sqlDataReader["City"].ToString();
                            Region.Text = sqlDataReader["Region"].ToString();
                            Country.Text = sqlDataReader["Country"].ToString();
                            Email.Text = sqlDataReader["Email"].ToString();
                            PhoneNumber.Text = sqlDataReader["PhoneNumber"].ToString();
                            Message.Text = sqlDataReader["Message"].ToString();
                        }
                    }

                    sqlDataReader.Close();
                    dbConnection.GetSqlConnection().Close();
                }
            }          
        }

        protected void SaveOrUpdate_Click(object sender, EventArgs e)
        {
            Guid guid;
            var gender = new EnumGender();
            Genders genders = gender.GetGender(Gender.SelectedItem.Text);
            int postalCodes = Convert.ToInt32(PostalCode.Text);

            if (Request.QueryString["ContactID"] != null)
            {
                guid = new Guid(ContactID.Text);
                DatabaseCRUD.UpdateDataInDatabase(guid, genders, Title.Text, FirstName.Text, LastName.Text, Address.Text, AddressComplement.Text,
                                                  postalCodes, City.Text, Region.Text, Country.Text, Email.Text, PhoneNumber.Text, Message.Text);

                #region
                /*** ALTERNATIVE CODE FOR UPDATING DATA IN DATABASE ***
                string connID = Request.QueryString["ContactID"];

                var strCon = ConfigurationManager.ConnectionStrings["tayfun_dbConnectionString"].ConnectionString;
                var conSql = new SqlConnection(strCon);
                conSql.Open();

                string strSql = "UPDATE ContactList SET Gender = @Gender, " +
                                                                 "Title = @Title, " +
                                                                 "FirstName = @FirstName, " +
                                                                 "LastName = @LastName, " +
                                                                 "Address = @Address, " +
                                                                 "AddressComplement = @AddressComplement, " +
                                                                 "PostalCode = @PostalCode, " +
                                                                 "City = @City, " +
                                                                 "Region = @Region, " +
                                                                 "Country = @Country, " +
                                                                 "Email = @Email, " +
                                                                 "PhoneNumber = @PhoneNumber, " +
                                                                 "Message = @Message " +
                                                    "WHERE ContactID = @ContactID";

                var cmd = new SqlCommand(strSql, conSql);

                cmd.Parameters.AddWithValue("@Gender", gender.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Title", title.Text);
                cmd.Parameters.AddWithValue("@FirstName", firstName.Text);
                cmd.Parameters.AddWithValue("@LastName", lastName.Text);
                cmd.Parameters.AddWithValue("@Address", address.Text);
                cmd.Parameters.AddWithValue("@AddressComplement", addressComplement.Text);
                cmd.Parameters.AddWithValue("@PostalCode", postalCode.Text);
                cmd.Parameters.AddWithValue("@City", city.Text);
                cmd.Parameters.AddWithValue("@Region", region.Text);
                cmd.Parameters.AddWithValue("@Country", country.Text);
                cmd.Parameters.AddWithValue("@Email", email.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber.Text);
                cmd.Parameters.AddWithValue("@Message", message.Text);
                cmd.Parameters.AddWithValue("@ContactID", connID);

                //cmd.ExecuteNonQuery();

                var dtst = new DataSet();
                var sqldtadpt = new SqlDataAdapter(cmd);
                sqldtadpt.TableMappings.Add("ContactList", "ContactList");
                sqldtadpt.Update(dtst, "ContactList");

                conSql.Close();
                ***/
                #endregion
            }
            else
            {
                guid = Guid.NewGuid();
                DatabaseCRUD.InsertDataIntoDatabase(guid, genders, Title.Text, FirstName.Text, LastName.Text, Address.Text, AddressComplement.Text,
                                                    postalCodes, City.Text, Region.Text, Country.Text, Email.Text, PhoneNumber.Text, Message.Text);
            }

            Response.Redirect("ListView.aspx?ContactID=" + guid);
        }
    }
}