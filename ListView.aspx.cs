using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Contact_List
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string connectionID = Request.QueryString["ContactID"];               
                string sqlQuery = "Select * FROM ContactList WHERE ContactID = @ContactID";     // Option #1: Parameterized Query

                #region
                /* Option #2: Apostrophes -> ' '
                 * string sqlStr = "Select * FROM ContactList WHERE ContactID = '" + cID + "'";
                 */
                #endregion

                DatabaseConnection dbConnection = DatabaseConnection.DbConnectInstance;
                dbConnection.BuildConnection(sqlQuery);
                dbConnection.GetSqlCommand().Parameters.AddWithValue("@ContactID", connectionID);

                var dataSet = new DataSet();
                var sqlDataAdapter = new SqlDataAdapter(dbConnection.GetSqlCommand());
                sqlDataAdapter.Fill(dataSet);

                repeaterView.DataSource = dataSet;
                repeaterView.DataBind();

                dbConnection.GetSqlConnection().Close();
            }
            else
            {
                ;
            }
        }

        protected void ShowAllContacts_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select * FROM ContactList";

            DatabaseConnection dbConnection = DatabaseConnection.DbConnectInstance;
            dbConnection.BuildConnection(sqlQuery);

            var dataSet = new DataSet();
            var sqlDataAdapter = new SqlDataAdapter(dbConnection.GetSqlCommand());
            sqlDataAdapter.Fill(dataSet);

            gridView.DataSource = dataSet;
            gridView.DataBind();

            dbConnection.GetSqlConnection().Close();
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the correct row, which the user selected by pressing the 'Choose' button in the GridView
            GridViewRow row = gridView.SelectedRow;

            Response.Redirect("ListEdit.aspx?ContactID=" + row.Cells[1].Text);
        }

        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var contact = new SaveIntoAndLoadFromDatabase();

            gridView.PageIndex = e.NewPageIndex;
            gridView.DataSource = contact.LoadDataFromDatabase();
            gridView.DataBind();
        }
    }
}