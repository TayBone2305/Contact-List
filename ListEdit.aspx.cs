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
            if (!Page.IsPostBack)
            {
                // Is there an ID in the URL? -> No
                if (Request.QueryString["ContactID"] == null)
                {
                    ;
                }
                // -> Yes
                else
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
                            contactID.Text = sqlDataReader.GetGuid(0).ToString();
                            gender.SelectedItem.Text = sqlDataReader.GetString(1);
                            title.Text = sqlDataReader.GetString(2);
                            firstName.Text = sqlDataReader.GetString(3);
                            lastName.Text = sqlDataReader.GetString(4);
                            address.Text = sqlDataReader.GetString(5);
                            addressComplement.Text = sqlDataReader.GetString(6);
                            postalCode.Text = sqlDataReader.GetInt32(7).ToString();
                            city.Text = sqlDataReader.GetString(8);
                            region.Text = sqlDataReader.GetString(9);
                            country.Text = sqlDataReader.GetString(10);
                            email.Text = sqlDataReader.GetString(11);
                            phoneNumber.Text = sqlDataReader.GetString(12);
                            message.Text = sqlDataReader.GetString(13);
                        }
                    }

                    sqlDataReader.Close();
                    dbConnection.GetSqlConnection().Close();
                }
            }
            // -> Yes
            else
            {
                ;
            }
        }

        protected void SaveOrUpdate_Click(object sender, EventArgs e)
        {
            Guid guid;
            var eGen = new EnumGender();
            Genders genders = eGen.GetGender(gender.SelectedItem.Text);
            int postalCodes = Convert.ToInt32(postalCode.Text);

            var contact = new SaveIntoAndLoadFromDatabase();

            if (Request.QueryString["ContactID"] == null)
            {
                guid = Guid.NewGuid(); 
                contact.InsertDataIntoDatabase(guid, genders, title.Text, firstName.Text, lastName.Text, address.Text, addressComplement.Text,
                                               postalCodes, city.Text, region.Text, country.Text, email.Text, phoneNumber.Text, message.Text);

            }
            else
            {
                guid = new Guid(contactID.Text);
                contact.UpdateDataInDatabase(guid, genders, title.Text, firstName.Text, lastName.Text, address.Text, addressComplement.Text,
                                             postalCodes, city.Text, region.Text, country.Text, email.Text, phoneNumber.Text, message.Text);

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

            Response.Redirect("ListView.aspx?ContactID=" + guid);
        }
    }
}