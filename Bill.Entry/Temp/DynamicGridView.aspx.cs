using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Temp_DynamicGridView : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtResp = GetResponsibilitiesData();
            DynamicGridView(dtResp);
        }
    }

    private DataTable GetResponsibilitiesData()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Bills2751 where RefNo = @RefNo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@RefNo", "10214");
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    protected void DynamicGridView(DataTable dtResp)
    {
        if (dtResp.Rows.Count > 0)
        {
            // turning OFF column auto generation
            GridDyanmic.AutoGenerateColumns = true;

            // assigning data source to GridView
            GridDyanmic.DataSource = dtResp;
            GridDyanmic.DataBind();

            // Clear existing columns
            GridDyanmic.Columns.Clear();

            // Dynamically creating BoundFields or Columns using from the data source
            foreach (DataColumn col in dtResp.Columns)
            {
                BoundField boundField = new BoundField();
                boundField.DataField = col.ColumnName;
                boundField.HeaderText = col.ColumnName;
                GridDyanmic.Columns.Add(boundField);
            }

            // turning ON column auto generation
            GridDyanmic.AutoGenerateColumns = false;
        }
    }
}