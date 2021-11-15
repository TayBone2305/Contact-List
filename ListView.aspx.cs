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
    public partial class ListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                string connectionID = Request.QueryString["ContactID"];               
                string sqlQuery = "Select * FROM ContactList WHERE ContactID = @ContactID";     // Option #1: Parameterized Query

                #region
                /* Option #2: Apostrophes -> ' '
                 * string sqlStr = "Select * FROM ContactList WHERE ContactID = '" + cID + "'";
                 */
                #endregion

                var dbConnection = DatabaseConnection.DbConnectInstance;
                dbConnection.BuildConnection(sqlQuery);
                dbConnection.GetSqlCommand().Parameters.AddWithValue("@ContactID", connectionID);

                RepeaterView.DataSource = dbConnection.CreateDataSetAndAdapter();
                RepeaterView.DataBind();

                dbConnection.GetSqlConnection().Close();
            }
        }

        protected void ShowAllContacts_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select * FROM ContactList";

            var dbConnection = DatabaseConnection.DbConnectInstance;
            dbConnection.BuildConnection(sqlQuery);

            GridView.DataSource = dbConnection.CreateDataSetAndAdapter();
            GridView.DataBind();

            dbConnection.GetSqlConnection().Close();
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the correct row, which the user selected by pressing the 'Choose' button in the GridView
            GridViewRow row = GridView.SelectedRow;

            Response.Redirect("ListEdit.aspx?ContactID=" + row.Cells[1].Text);
        }

        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView.PageIndex = e.NewPageIndex;
            GridView.DataSource = DatabaseCRUD.LoadDataFromDatabase();
            GridView.DataBind();
        }
    }
}