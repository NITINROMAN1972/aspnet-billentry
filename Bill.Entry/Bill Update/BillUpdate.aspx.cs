﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Security;
using System.Data.SqlTypes;

public partial class Bill_Update_BillUpdate : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Search_BillRefNo_DD();

            Bind_Search_Vendor_DD();
            Bind_Search_Unit_DD();
            Bind_Search_ImpstCardNo_DD();

            Session["TotalBillAmount"] = "";
        }

        // alert pop-up with only message
        //string message = $"Datatable : {}";
        //string script = $"alert('{message}');";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "messageScript", script, true);
    }

    private void alert(string mssg)
    {
        // alert pop - up with only message
        string message = mssg;
        string script = $"alert('{message}');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "messageScript", script, true);
    }


    //=========================={ Sweet Alert JS }==========================

    private void getSweetAlertSuccessOnly()
    {
        string title = "Saved!";
        string message = "Record saved successfully!";
        string icon = "success";
        string confirmButtonText = "OK";

        string sweetAlertScript =
            $@"<script>
                Swal.fire({{ 
                    title: '{title}', 
                    text: '{message}', 
                    icon: '{icon}', 
                    confirmButtonText: '{confirmButtonText}' 
                }});
            </script>";
        ClientScript.RegisterStartupScript(this.GetType(), "sweetAlert", sweetAlertScript, false);
    }

    // sweet alert - success redirect
    private void getSweetAlertSuccessRedirect(string redirectUrl)
    {
        string title = "Saved!";
        string message = "Record saved successfully!";
        string icon = "success";
        string confirmButtonText = "OK";
        string allowOutsideClick = "false";

        string sweetAlertScript =
            $@"<script>
                Swal.fire({{ 
                    title: '{title}', 
                    text: '{message}', 
                    icon: '{icon}', 
                    confirmButtonText: '{confirmButtonText}',
                    allowOutsideClick: {allowOutsideClick}
                }}).then((result) => {{
                    if (result.isConfirmed) {{
                        window.location.href = '{redirectUrl}';
                    }}
                }});
            </script>";
        ClientScript.RegisterStartupScript(this.GetType(), "sweetAlert", sweetAlertScript, false);
    }

    // sweet alert - success redirect block
    private void getSweetAlertSuccessRedirectMandatory(string titles, string mssg, string redirectUrl)
    {
        string title = titles;
        string message = mssg;
        string icon = "success";
        string confirmButtonText = "OK";
        string allowOutsideClick = "false"; // Prevent closing on outside click

        string sweetAlertScript =
        $@"<script>
            Swal.fire({{ 
                title: '{title}', 
                text: '{message}', 
                icon: '{icon}', 
                confirmButtonText: '{confirmButtonText}', 
                allowOutsideClick: {allowOutsideClick}
            }}).then((result) => {{
                if (result.isConfirmed) {{
                    window.location.href = '{redirectUrl}';
                }}
            }});
        </script>";
        ClientScript.RegisterStartupScript(this.GetType(), "sweetAlert", sweetAlertScript, false);
    }

    // sweet alert - question only
    private void getSweetAlertQuestionOnly(string titl, string mssg)
    {
        string title = titl;
        string message = mssg;
        string icon = "question";
        string confirmButtonText = "OK";

        string sweetAlertScript =
            $@"<script>
                Swal.fire({{ 
                    title: '{title}', 
                    text: '{message}', 
                    icon: '{icon}', 
                    confirmButtonText: '{confirmButtonText}' 
                }});
            </script>";
        ClientScript.RegisterStartupScript(this.GetType(), "sweetAlert", sweetAlertScript, false);
    }

    // sweet alert - error only block
    private void getSweetAlertErrorMandatory(string titles, string mssg)
    {
        string title = titles;
        string message = mssg;
        string icon = "error";
        string confirmButtonText = "OK";
        string allowOutsideClick = "false"; // Prevent closing on outside click

        string sweetAlertScript =
        $@"<script>
            Swal.fire({{ 
                title: '{title}', 
                text: '{message}', 
                icon: '{icon}', 
                confirmButtonText: '{confirmButtonText}', 
                allowOutsideClick: {allowOutsideClick}
            }});
        </script>";
        ClientScript.RegisterStartupScript(this.GetType(), "sweetAlert", sweetAlertScript, false);
    }



    //=========================={ Binding Search Dropdowns }==========================

    private void Bind_Search_BillRefNo_DD()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Bills1751 order by RefNo desc";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddScBillRefNo.DataSource = dt;
            ddScBillRefNo.DataTextField = "RefNo";
            ddScBillRefNo.DataValueField = "RefNo";
            ddScBillRefNo.DataBind();
            ddScBillRefNo.Items.Insert(0, new ListItem("------ Select Bill Ref No ------", "0"));
        }
    }

    private void Bind_Search_Vendor_DD()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from ContestantMaster751";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddScVendor.DataSource = dt;
            ddScVendor.DataTextField = "vName";
            ddScVendor.DataValueField = "RefID";
            ddScVendor.DataBind();
            ddScVendor.Items.Insert(0, new ListItem("------ Select Vendor ------", "0"));
        }
    }

    private void Bind_Search_Unit_DD()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Units751";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddScUnit.DataSource = dt;
            ddScUnit.DataTextField = "unitName";
            ddScUnit.DataValueField = "unitCode";
            ddScUnit.DataBind();
            ddScUnit.Items.Insert(0, new ListItem("------ Select Unit / Office ------", "0"));
        }
    }

    private void Bind_Search_ImpstCardNo_DD()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from ImprestCard751";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddScImpstCardNo.DataSource = dt;
            ddScImpstCardNo.DataTextField = "icNumber";
            ddScImpstCardNo.DataValueField = "RefID";
            ddScImpstCardNo.DataBind();
            ddScImpstCardNo.Items.Insert(0, new ListItem("------ Select Imprest Card No ------", "0"));
        }
    }

    // event not needed here
    protected void Search_BillNo_DD_Event(object sender, EventArgs e)
    {
        string billNo = ddScBillRefNo.SelectedValue;
    }
    protected void Search_Vendor_DD_Event(object sender, EventArgs e)
    {
        string vendor = ddScVendor.SelectedValue;
    }
    protected void Search_Unit_DD_Event(object sender, EventArgs e)
    {
        string unitOffice = ddScUnit.SelectedValue;
    }
    protected void Search_ImprestCardNo_DD_Event(object sender, EventArgs e)
    {
        string imprestCardNo = ddScImpstCardNo.SelectedValue;
    }



    //=========================={ Fetch Datatable }==========================
    protected void gridSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //binding GridView to PageIndex object
        gridSearch.PageIndex = e.NewPageIndex;

        DataTable pagination = (DataTable)Session["PaginationDataSource"];

        gridSearch.DataSource = pagination;
        gridSearch.DataBind();
    }

    private DataTable GetBillDT(string billRefNo)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Bills1751 where RefNo = @RefNo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@RefNo", billRefNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    private DataTable GetVendorDT(string vendorRefID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from ContestantMaster751 where RefID = @RefID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@RefID", vendorRefID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    private DataTable GetUnitDT(string unitCode)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Units751 where unitCode = @unitCode";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@unitCode", unitCode);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    private DataTable GetImprestCardDT(string imprestCardRefID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from ImprestCard751 where RefID = @RefID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@RefID", imprestCardRefID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    private DataTable getAccountHeadExisting(string billRefNo)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from BillTaxHead751 where BillRefNo = @BillRefNo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@BillRefNo", billRefNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    private DataTable getAccountHead()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from AcHeads751 as ach INNER JOIN AcHeadGroups751 as acg ON ach.AcHGName = acg.AHGCode where acg.AHGCode = 'DT001'";
            SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@BillRefNo", billRefNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }



    //=========================={ Search Dropdown }==========================
    protected void btnNewBill_Click(object sender, EventArgs e)
    {
        Response.Redirect("../BillEntry.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGridView();
    }

    private void BindGridView()
    {
        searchGridDiv.Visible = true;

        // dropdown values
        string billRefNo = ddScBillRefNo.SelectedValue; // bill erf no

        string vendorRefID = ddScVendor.SelectedValue;
        string unitRefID = ddScUnit.SelectedValue;
        string imprestCardRefID = ddScImpstCardNo.SelectedValue;

        // date - from & to date
        //DateTime fromDate = DateTime.Parse(ScFromDate.Text);
        //DateTime toDate = DateTime.Parse(ScToDate.Text);

        DateTime fromDate;
        DateTime toDate;

        if (!DateTime.TryParse(ScFromDate.Text, out fromDate)) { fromDate = SqlDateTime.MinValue.Value; }
        if (!DateTime.TryParse(ScToDate.Text, out toDate)) { toDate = SqlDateTime.MaxValue.Value; }


        // DTs
        DataTable billDT = GetBillDT(billRefNo);

        DataTable vendorDT = GetVendorDT(vendorRefID);
        DataTable unitDT = GetUnitDT(unitRefID);
        DataTable imprestCardDT = GetImprestCardDT(imprestCardRefID);

        // dt values
        string billRefNumber = (billDT.Rows.Count > 0) ? billDT.Rows[0]["RefNo"].ToString() : string.Empty;

        string vendorName = (vendorDT.Rows.Count > 0) ? vendorDT.Rows[0]["vName"].ToString() : string.Empty;
        string unitName = (unitDT.Rows.Count > 0) ? unitDT.Rows[0]["unitCode"].ToString() : string.Empty;
        string imprestCardNo = (imprestCardDT.Rows.Count > 0) ? imprestCardDT.Rows[0]["icNumber"].ToString() : string.Empty;

        DataTable searchResultDT = SearchRecords(billRefNumber, fromDate, toDate, vendorName, unitName, imprestCardNo);

        // binding the search grid
        gridSearch.DataSource = searchResultDT;
        gridSearch.DataBind();

        //Required for jQuery DataTables to work.
        gridSearch.UseAccessibleHeader = true;
        gridSearch.HeaderRow.TableSection = TableRowSection.TableHeader;
        //gridSearch.FooterRow.TableSection = TableRowSection.TableHeader;

        Session["PaginationDataSource"] = searchResultDT;
    }

    public DataTable SearchRecords(string billRefNumber, DateTime fromDate, DateTime toDate, string vendorName, string unitName, string imprestCardNo)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql = $@"SELECT bill.*, unit.unitName 
                            FROM Bills1751 as bill inner join Units751 as unit
                            on bill.Unit = unit.unitCode 
                            WHERE 1=1";

            if (!string.IsNullOrEmpty(billRefNumber))
            {
                sql += " AND RefNo = @RefNo";
            }

            if (fromDate != null)
            {
                sql += " AND BillDate >= @FromDate";
            }

            if (toDate != null)
            {
                sql += " AND BillDate <= @ToDate";
            }


            if (!string.IsNullOrEmpty(vendorName))
            {
                sql += " AND Vendor = @Vendor";
            }

            if (!string.IsNullOrEmpty(unitName))
            {
                sql += " AND Unit = @Unit";
            }

            if (!string.IsNullOrEmpty(imprestCardNo))
            {
                sql += " AND CardNo = @CardNo";
            }

            sql += " ORDER BY RefNo DESC";




            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (!string.IsNullOrEmpty(billRefNumber))
                {
                    command.Parameters.AddWithValue("@RefNo", billRefNumber);
                }

                if (fromDate != null)
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                }

                if (toDate != null)
                {
                    command.Parameters.AddWithValue("@ToDate", toDate);
                }



                if (!string.IsNullOrEmpty(vendorName))
                {
                    command.Parameters.AddWithValue("@Vendor", vendorName);
                }

                if (!string.IsNullOrEmpty(unitName))
                {
                    command.Parameters.AddWithValue("@Unit", unitName);
                }

                if (!string.IsNullOrEmpty(imprestCardNo))
                {
                    command.Parameters.AddWithValue("@CardNo", imprestCardNo);
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }




    //=========================={ Update - Fill Bill & Item Details }==========================
    protected void gridSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkView")
        {
            int rowId = Convert.ToInt32(e.CommandArgument);
            Session["RowID"] = rowId;

            searchGridDiv.Visible = false;
            divTopSearch.Visible = false;
            UpdateDiv.Visible = true;

            Bind_Item_Dropdown();
            Bind_UOM_Dropdown();

            FillBillDetails(rowId);

            FillItemDetails(rowId);

            // filling item tax head gridview
            FillTaxHead();
        }
    }

    private void Bind_Item_Dropdown()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Estimate751";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddItem.DataSource = dt;
            ddItem.DataTextField = "ItmName";
            ddItem.DataValueField = "ItmCode";
            ddItem.DataBind();
            ddItem.Items.Insert(0, new ListItem("------Select Item------", "0"));
        }
    }

    private void Bind_UOM_Dropdown()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from UOMs751";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddUOM.DataSource = dt;
            ddUOM.DataTextField = "umName";
            ddUOM.DataValueField = "umName";
            ddUOM.DataBind();
            ddUOM.Items.Insert(0, new ListItem("------Select UOM------", "0"));
        }
    }

    private void FillBillDetails(int billRefNo)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = $@"Select bill.* , imp.icFirstName, unit.unitName 
                            From Bills1751 bill 
                            Inner Join ImprestCard751 imp ON bill.CardNo = imp.icNumber 
                            Inner Join Units751 unit ON bill.Unit = unit.unitCode 
                            Where RefNo = @RefNo";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@RefNo", billRefNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            Session["HeaderDataTable"] = dt;


            txtRefNo.Text = dt.Rows[0]["RefNo"].ToString();
            txtBillNo.Text = dt.Rows[0]["VouNo"].ToString();
            txtBillAmount.Text = dt.Rows[0]["BillAmt"].ToString();
            Session["TotalBillAmount"] = txtBillAmount.Text;

            //txtTotalDeduct.Text = dt.Rows[0]["TotalDeduct"].ToString();
            //txtTotalAdd.Text = dt.Rows[0]["txtTotalAdd"].ToString();
            //txtNetAmnt.Text = dt.Rows[0]["txtNetAmnt"].ToString();

            DateTime billDate = DateTime.Parse(dt.Rows[0]["BillDate"].ToString());
            dateBillDate.Text = billDate.ToString("yyyy-MM-dd");



            ddVendor.DataSource = dt;
            ddVendor.DataTextField = "Vendor";
            ddVendor.DataValueField = "Vendor";
            ddVendor.DataBind();
            ddVendor.Items.Insert(0, new ListItem("------Select Vendor------", "0"));

            if (ddVendor.SelectedIndex < 2) ddVendor.SelectedIndex = 1;


            ddUnitOffice.DataSource = dt;
            ddUnitOffice.DataTextField = "unitName";
            ddUnitOffice.DataValueField = "Unit";
            ddUnitOffice.DataBind();
            ddUnitOffice.Items.Insert(0, new ListItem("------Select Unit------", "0"));

            if (ddUnitOffice.SelectedIndex < 2) ddUnitOffice.SelectedIndex = 1;


            ddImprestCardNo.DataSource = dt;
            ddImprestCardNo.DataTextField = "CardNo";
            ddImprestCardNo.DataValueField = "CardNo";
            ddImprestCardNo.DataBind();
            ddImprestCardNo.Items.Insert(0, new ListItem("------Select Imprest Card No------", "0"));

            if (ddImprestCardNo.SelectedIndex < 2) ddImprestCardNo.SelectedIndex = 1;


            ddImprestCardHolder.DataSource = dt;
            ddImprestCardHolder.DataTextField = "icFirstName";
            ddImprestCardHolder.DataValueField = "CardHld";
            ddImprestCardHolder.DataBind();
            ddImprestCardHolder.Items.Insert(0, new ListItem("------Select Imprest Card Holder------", "0"));

            if (ddImprestCardHolder.SelectedIndex < 2) ddImprestCardHolder.SelectedIndex = 1;


            ddAlloctHead.DataSource = dt;
            ddAlloctHead.DataTextField = "AlcnNo";
            ddAlloctHead.DataValueField = "AlcnNo";
            ddAlloctHead.DataBind();
            ddAlloctHead.Items.Insert(0, new ListItem("------Select Allocate Head------", "0"));

            if (ddAlloctHead.SelectedIndex < 2) ddAlloctHead.SelectedIndex = 1;
        }
    }

    private void FillItemDetails(int billRefNo)
    {
        itemDiv.Visible = true;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Bills2751 where RefNo = @RefNo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@RefNo", billRefNo.ToString());
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            itemGrid.DataSource = dt;
            itemGrid.DataBind();

            //Required for jQuery DataTables to work.
            itemGrid.UseAccessibleHeader = true;
            itemGrid.HeaderRow.TableSection = TableRowSection.TableHeader;

            ViewState["BillDetailsVS"] = dt;
            Session["BillDetails"] = dt;
        }
    }




    //=========================={ GridView RowDeleting }==========================
    protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gridView = (GridView)sender;

        // item gridview
        if (gridView.ID == "itemGrid")
        {
            int rowIndex = e.RowIndex;

            DataTable dt = ViewState["BillDetailsVS"] as DataTable;

            if (dt != null && dt.Rows.Count > rowIndex)
            {
                dt.Rows.RemoveAt(rowIndex);

                ViewState["BillDetailsVS"] = dt;
                Session["BillDetails"] = dt;

                itemGrid.DataSource = dt;
                itemGrid.DataBind();

                // re-calculating total amount n assigning back to textbox
                double? totalBillAmount = dt.AsEnumerable().Sum(row => row["Amount"] is DBNull ? (double?)null : Convert.ToDouble(row["Amount"])) ?? 0.0;
                txtBillAmount.Text = totalBillAmount.HasValue ? totalBillAmount.Value.ToString("N2") : "0.00";

                Session["TotalBillAmount"] = Convert.ToDouble(txtBillAmount.Text);

                // re-calculating taxs
                FillTaxHead();
            }
        }
    }






    //=========================={ Item Save Button Click Event }==========================
    protected void btnItemInsert_Click(object sender, EventArgs e)
    {
        // inserting bill details
        insertBillDetails();

        // filling item tax head gridview
        FillTaxHead();
    }

    private void insertBillDetails()
    {
        Session["BillHeaderRefNo"] = txtRefNo.Text.ToString();
        string refNo = Session["BillHeaderRefNo"].ToString();

        string item = ddItem.SelectedValue;
        string uom = ddUOM.SelectedValue;
        double price = Convert.ToDouble(txtPrice.Text.ToString());
        double qty = Convert.ToDouble(txtQty.Text.ToString());
        double amount = (price * qty);

        if (price >= 0.00 && qty >= 0)
        {
            DataTable dt = ViewState["BillDetailsVS"] as DataTable ?? createBillDatatable();

            AddRowToBillDetailsDataTable(dt, refNo, item, uom, price, qty, amount);

            if (dt.Rows.Count > 0)
            {
                itemDiv.Visible = true;

                itemGrid.DataSource = dt;
                itemGrid.DataBind();

                ViewState["BillDetailsVS"] = dt;
                Session["BillDetails"] = dt;

                // Identify the index of the "TOTAL BILL" row
                int lastRowIndex = dt.Rows.Count - 1;

                double totalBillAmount = Convert.ToDouble(txtBillAmount.Text);

                totalBillAmount = totalBillAmount + amount;
                Session["TotalBillAmount"] = totalBillAmount;

                txtBillAmount.Text = totalBillAmount.ToString("N2");

                // clearing input fields
                ddItem.SelectedIndex = 0;
                ddUOM.SelectedIndex = 0;
                txtPrice.Text = string.Empty;
                txtQty.Text = string.Empty;
            }
        }
        else
        {
            string title = "Negative Values";
            string message = "please add positive values";
            getSweetAlertErrorMandatory(title, message);
        }
    }

    private double? ConvertToNullableDouble(object value)
    {
        return value == DBNull.Value ? (double?)null : Convert.ToDouble(value);
    }

    private DataTable createBillDatatable()
    {
        DataTable dt = new DataTable();

        // reference no
        DataColumn RefNo = new DataColumn("RefNo", typeof(string));
        dt.Columns.Add(RefNo);

        // item
        DataColumn Item = new DataColumn("Item", typeof(string));
        dt.Columns.Add(Item);

        // uom
        DataColumn UOM = new DataColumn("UOM", typeof(string));
        dt.Columns.Add(UOM);

        // price
        DataColumn Price = new DataColumn("Price", typeof(double));
        dt.Columns.Add(Price);

        // quantity
        DataColumn Qty = new DataColumn("Qty", typeof(double));
        dt.Columns.Add(Qty);

        // amount
        DataColumn Amount = new DataColumn("Amount", typeof(double));
        dt.Columns.Add(Amount);

        return dt;
    }

    private void AddRowToBillDetailsDataTable(DataTable dt, string refNo, string item, string uom, double price, double qty, double amount)
    {
        // Create a new row
        DataRow row = dt.NewRow();

        // Set values for the new row
        row["RefNo"] = refNo;
        row["Item"] = item;
        row["UOM"] = uom;
        row["Price"] = price;
        row["Qty"] = qty;
        row["Amount"] = amount;

        // Add the new row to the DataTable
        dt.Rows.Add(row);
    }




    //=========================={ Tax Head }==========================
    protected void GridTax_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            // Set the row in edit mode
            e.Row.RowState = e.Row.RowState ^ DataControlRowState.Edit;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string billRefno = txtRefNo.Text.ToString();

            // fetching acount head or taxes
            DataTable accountHeadExistingDT = getAccountHeadExisting(billRefno);
            DataTable accountHeadNewDT = getAccountHead();

            if (accountHeadExistingDT.Rows.Count > 0)
            {
                //=================================={ Add/Less column }========================================
                DropDownList ddlAddLess = (DropDownList)e.Row.FindControl("AddLess");

                if (ddlAddLess != null)
                {
                    string addLessValue = accountHeadExistingDT.Rows[e.Row.RowIndex]["AddLess"].ToString();
                    ddlAddLess.SelectedValue = addLessValue;
                }

                //=================================={ Percentage/Amount column }========================================
                DropDownList ddlPerOrAmnt = (DropDownList)e.Row.FindControl("PerOrAmnt");

                if (ddlPerOrAmnt != null)
                {
                    string perOrAmntValue = accountHeadExistingDT.Rows[e.Row.RowIndex]["PerOrAmnt"].ToString();
                    ddlPerOrAmnt.SelectedValue = perOrAmntValue;
                }
            }
            else
            {
                //=================================={ Add/Less column }========================================
                DropDownList ddlAddLess = (DropDownList)e.Row.FindControl("AddLess");

                if (ddlAddLess != null)
                {
                    string addLessValue = accountHeadNewDT.Rows[e.Row.RowIndex]["AddLess"].ToString();
                    ddlAddLess.SelectedValue = addLessValue;
                }

                //=================================={ Percentage/Amount column }========================================
                DropDownList ddlPerOrAmnt = (DropDownList)e.Row.FindControl("PerOrAmnt");

                if (ddlPerOrAmnt != null)
                {
                    string perOrAmntValue = accountHeadNewDT.Rows[e.Row.RowIndex]["PerOrAmnt"].ToString();
                    ddlPerOrAmnt.SelectedValue = perOrAmntValue;
                }
            }
        }
    }

    protected void ddTaxOrNot_SelectedIndexChanged(object sender, EventArgs e)
    {
        string taxOrNot = ddTaxOrNot.SelectedValue;

        if (ddTaxOrNot.SelectedValue == "Yes")
        {
            divTaxHead.Visible = true;
        }
        else
        {
            divTaxHead.Visible = false;
        }
    }

    private void FillTaxHead()
    {
        string billRefno = txtRefNo.Text.ToString();

        // total bill amount
        double totalBillAmount = Convert.ToDouble(Session["TotalBillAmount"]);

        // fetching acount head or taxes
        DataTable accountHeadExistingDT = getAccountHeadExisting(billRefno);
        DataTable accountHeadNewDT = getAccountHead();

        // Header Datatable
        DataTable headerDataTable = (DataTable)Session["HeaderDataTable"];

        if (headerDataTable.Rows[0]["TaxApplied"].ToString() == "Yes")
        {
            ddTaxOrNot.SelectedValue = "Yes";
            divTaxHead.Visible = true;

            // checking if the column exists inside the datatable, to remove them and copying data to new one
            if (accountHeadExistingDT.Columns.Contains("AccountHead"))
            {
                DataColumn achg = new DataColumn("AcHGName", typeof(string));
                DataColumn achcode = new DataColumn("AcHCode", typeof(string));

                accountHeadExistingDT.Columns.Add(achg);
                accountHeadExistingDT.Columns.Add(achcode);

                foreach (DataRow row in accountHeadExistingDT.Rows)
                {
                    row["AcHGName"] = row["AccountHead"];
                    row["AcHCode"] = row["DeductHeadCode"];
                }

                accountHeadExistingDT.Columns.Remove("AccountHead");
                accountHeadExistingDT.Columns.Remove("DeductHeadCode");
            }

            Session["AccountHeadDT"] = accountHeadExistingDT;

            // fill tax heads
            autoFilltaxHeads(accountHeadExistingDT, totalBillAmount);
        }
        else
        {
            Session["AccountHeadDT"] = accountHeadNewDT;

            // fill tax heads
            autoFilltaxHeads(accountHeadNewDT, totalBillAmount);
        }
    }

    private void autoFilltaxHeads(DataTable accountHeadDT, double bscAmnt)
    {
        double basicAmount = bscAmnt;
        double totalDeduction = 0.00;
        double totalAddition = 0.00;
        double netAmount = 0.00;

        // checking if the column exists inside tghe datable
        if (accountHeadDT.Columns.Contains("DeductionHead"))
        {
            DataColumn newColumn = new DataColumn("AcHName", typeof(string));

            accountHeadDT.Columns.Add(newColumn);

            foreach (DataRow row in accountHeadDT.Rows)
            {
                row["AcHName"] = row["DeductionHead"];
            }

            accountHeadDT.Columns.Remove("DeductionHead");
        }

        foreach (DataRow row in accountHeadDT.Rows)
        {
            double percentage = Convert.ToDouble(row["FactorInPer"]);

            double factorInPer = (basicAmount * percentage) / 100;

            if (row["AddLess"].ToString() == "Add")
            {
                totalAddition = totalAddition + factorInPer;
            }
            else
            {
                totalDeduction = totalDeduction + factorInPer;
            }

            row["TaxAmount"] = factorInPer;
        }

        GridTax.DataSource = accountHeadDT;
        GridTax.DataBind();

        // filling total deduction
        txtTotalDeduct.Text = Math.Abs(totalDeduction).ToString("N2");

        // filling total addition
        txtTotalAdd.Text = totalAddition.ToString("N2");

        // Net Amount after tax deductions or addition
        netAmount = (basicAmount + totalAddition) - Math.Abs(totalDeduction);
        txtNetAmnt.Text = netAmount.ToString("N2");
    }

    protected void btnReCalTax_Click(object sender, EventArgs e)
    {
        // Account Head DataTable
        DataTable dt = (DataTable)Session["AccountHeadDT"];

        // Perform calculations or other logic based on the updated values
        double totalBill = Convert.ToDouble(txtBillAmount.Text);
        double totalDeduction = 0.00;
        double totalAddition = 0.00;
        double netAmount = 0.00;

        foreach (GridViewRow row in GridTax.Rows)
        {
            // Accessing the updated dropdown values from the grid
            string updatedAddLessValue = ((DropDownList)row.FindControl("AddLess")).SelectedValue;
            string updatedPerOrAmntValue = ((DropDownList)row.FindControl("PerOrAmnt")).SelectedValue;

            int rowIndex = row.RowIndex;

            // reading parameters from gridview
            TextBox AcHNameStr = row.FindControl("AcHName") as TextBox;
            TextBox FactorInPercentage = row.FindControl("FactorInPer") as TextBox;
            DropDownList perOrAmntDropDown = row.FindControl("PerOrAmnt") as DropDownList;
            DropDownList AddLessDropown = row.FindControl("AddLess") as DropDownList;
            TextBox TaxAccountHeadAmount = row.FindControl("TaxAmount") as TextBox;

            string AcHName = (AcHNameStr.Text).ToString();
            double factorInPer = Convert.ToDouble(FactorInPercentage.Text);
            string perOrAmnt = perOrAmntDropDown.SelectedValue;
            string addLess = AddLessDropown.SelectedValue;
            double taxAmount = Convert.ToDouble(TaxAccountHeadAmount.Text);

            if (perOrAmnt == "Amount")
            {
                taxAmount = factorInPer;

                // setting tax head amount
                TaxAccountHeadAmount.Text = Math.Abs(taxAmount).ToString("N2");

                if (addLess == "Add")
                {
                    totalAddition = totalAddition + taxAmount;
                }
                else
                {
                    totalDeduction = totalDeduction + taxAmount;
                }
            }
            else
            {
                // tax amount (based on add or less)
                taxAmount = (totalBill * factorInPer) / 100;

                // setting tax head amount
                TaxAccountHeadAmount.Text = Math.Abs(taxAmount).ToString("N2");

                if (addLess == "Add")
                {
                    totalAddition = totalAddition + taxAmount;
                }
                else
                {
                    totalDeduction = totalDeduction + taxAmount;
                }
            }
        }

        // setting total deduction
        txtTotalDeduct.Text = Math.Abs(totalDeduction).ToString("N2");

        // setting total addition
        txtTotalAdd.Text = totalAddition.ToString("N2");

        // Net Amount after tax deductions or addition
        netAmount = (totalBill + totalAddition) - Math.Abs(totalDeduction);
        txtNetAmnt.Text = netAmount.ToString("N2");
    }




    //=========================={ Submit Button Click Event }==========================
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BillUpdate.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if(itemGrid.Rows.Count > 0)
        {
            string billRefno = txtRefNo.Text.ToString();

            // updating bill head
            UpdateBillHeader();

            // updating item details
            UpdateBillItemDetails();

            // inserting bill tax heads
            string taxOrNot = ddTaxOrNot.SelectedValue;

            if (taxOrNot == "Yes")
            {
                UpdateBillTaxHeads();
            }

            getSweetAlertSuccessRedirectMandatory("Bill Updated Successfully", $"The Bill With Reference No: {billRefno}, Updated Successfully", "BillUpdate.aspx");
        }
        else
        {
            getSweetAlertErrorMandatory("No Items Found!", "Please Add Minimum 1 Service/Cell To Proceed");
        }
    }

    private void UpdateBillHeader()
    {
        string billRefno = txtRefNo.Text.ToString();

        DataTable BillHeaderDT = (DataTable)Session["HeaderDataTable"];

        //double totalBillAmount = Convert.ToDouble(Session["TotalBillAmount"]);
        double totalBillAmount = Convert.ToDouble(txtBillAmount.Text);


        // total add, deduct and net amount
        string isTaxApplied = ddTaxOrNot.Text.ToString();

        double totalDeduction = Convert.ToDouble(txtTotalDeduct.Text);
        double totalAddition = Convert.ToDouble(txtTotalAdd.Text);
        double netBillAmount = 0.00;

        if (isTaxApplied == "Yes") netBillAmount = Convert.ToDouble(txtNetAmnt.Text);
        else netBillAmount = totalBillAmount; // normal bill amount same as total bill amount



        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = $@"UPDATE Bills1751 SET BillAmt=@BillAmt, TaxApplied=@TaxApplied, TotalDeduct=@TotalDeduct, TotalAdd=@TotalAdd, NetAmount=@NetAmount WHERE RefNo=@RefNo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@BillAmt", totalBillAmount);
            cmd.Parameters.AddWithValue("@TaxApplied", isTaxApplied);
            cmd.Parameters.AddWithValue("@TotalDeduct", totalDeduction);
            cmd.Parameters.AddWithValue("@TotalAdd", totalAddition);
            cmd.Parameters.AddWithValue("@NetAmount", netBillAmount);
            cmd.Parameters.AddWithValue("@RefNo", billRefno);
            cmd.ExecuteNonQuery();

            //SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //ad.Fill(dt);

            con.Close();
        }
    }





    private void UpdateBillItemDetails()
    {
        string billRefno = txtRefNo.Text.ToString();

        DataTable itemsDT = (DataTable)Session["BillDetails"]; // Bills2 details

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            foreach (GridViewRow row in itemGrid.Rows)
            {
                int rowIndex = row.RowIndex;

                // Item, UOM, Price, Qty, Amount
                string item = itemsDT.Rows[rowIndex]["Item"].ToString();
                string uom = itemsDT.Rows[rowIndex]["UOM"].ToString();
                double price = Convert.ToDouble(itemsDT.Rows[rowIndex]["Price"]);
                double qty = Convert.ToDouble(itemsDT.Rows[rowIndex]["Qty"]);
                double amount = Convert.ToDouble(itemsDT.Rows[rowIndex]["Amount"]);

                // item ref no to update
                string itemRefID = itemsDT.Rows[rowIndex]["RefIDItem"].ToString();


                // checking for existing items
                //bool isItemExists = IsItemExists(itemRefID);

                //if (isItemExists) // update
                if (itemRefID != "") // update
                {
                    string sql = $@"UPDATE Bills2751 SET
                                    Item=@Item, UOM=@UOM, Price=@Price, Qty=@Qty, Amount=@Amount
                                    WHERE RefIDItem=@RefIDItem";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Item", item);
                    cmd.Parameters.AddWithValue("@UOM", uom);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Qty", qty);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@RefIDItem", itemRefID);
                    cmd.ExecuteNonQuery();
                }
                else // insert
                {
                    // getting new ref id for item
                    string itemRefNo = GetItemRefID().ToString();

                    string sql = $@"INSERT INTO Bills2751
                                    (RefNo, RefIDItem, Item, UOM, Price, Qty, Amount) 
                                    VALUES 
                                    (@RefNo, @RefIDItem, @Item, @UOM, @Price, @Qty, @Amount)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@RefNo", billRefno);
                    cmd.Parameters.AddWithValue("@RefIDItem", itemRefNo);
                    cmd.Parameters.AddWithValue("@Item", item);
                    cmd.Parameters.AddWithValue("@UOM", uom);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Qty", qty);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.ExecuteNonQuery();
                }
            }

            con.Close();
        }

    }

    private bool IsItemExists(string itemRefID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "SELECT * FROM Bills2751 WHERE RefIDItem=@RefIDItem";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@RefIDItem", itemRefID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0) return true;
            else return false;
        }
    }

    private int GetItemRefID()
    {
        string nextRefID = "10001";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "SELECT ISNULL(MAX(CAST(RefIDItem AS INT)), 10000) + 1 AS NextRefID FROM Bills2751";
            SqlCommand cmd = new SqlCommand(sql, con);

            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value) { nextRefID = result.ToString(); }
            return Convert.ToInt32(nextRefID);
        }
    }




    private void UpdateBillTaxHeads()
    {
        string BillRefno = txtRefNo.Text.ToString(); // bill ref no

        // Account Head DataTable
        DataTable dt = (DataTable)Session["AccountHeadDT"];

        if (dt != null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // checking for tax heads for the bill ref no
                bool isBillHasTaxHead = CheckTaxHeadForBillRefNo(BillRefno);

                foreach (GridViewRow row in GridTax.Rows)
                {
                    // to get the current row index
                    int rowIndex = row.RowIndex;


                    // getting account head from dt
                    string AccountHeadGroup = dt.Rows[rowIndex]["AcHGName"].ToString();

                    // getting deduction head code from dt
                    string DeductHeadCode = dt.Rows[rowIndex]["AcHCode"].ToString();



                    // parameters of textbox
                    TextBox DeductionHeadStr = row.FindControl("AcHName") as TextBox;
                    string DeductionHead = (DeductionHeadStr.Text).ToString();

                    TextBox FactorInPercentage = row.FindControl("FactorInPer") as TextBox;
                    double FactorInPer = Convert.ToDouble(FactorInPercentage.Text);

                    TextBox TaxAccountHeadAmount = row.FindControl("TaxAmount") as TextBox;
                    double TaxAmount = Convert.ToDouble(TaxAccountHeadAmount.Text);

                    // parameters of dropdown list
                    DropDownList perOrAmntDropDown = row.FindControl("PerOrAmnt") as DropDownList;
                    string PerOrAmnt = perOrAmntDropDown.SelectedValue;

                    DropDownList AddLessDropown = row.FindControl("AddLess") as DropDownList;
                    string AddLess = AddLessDropown.SelectedValue;

                    // if bill has existing tax head or not ?

                    if (isBillHasTaxHead) // update
                    {
                        string billTaxRefID = dt.Rows[rowIndex]["RefID"].ToString(); // existing

                        string sql = $@"UPDATE BillTaxHead751 SET
                                    FactorInPer=@FactorInPer, PerOrAmnt=@PerOrAmnt, AddLess=@AddLess, TaxAmount=@TaxAmount
                                    WHERE RefID=@RefID";

                        SqlCommand cmd = new SqlCommand(sql, con);
                        //cmd.Parameters.AddWithValue("@BillRefNo", BillRefno);
                        //cmd.Parameters.AddWithValue("@AccountHead", AccountHeadGroup);
                        //cmd.Parameters.AddWithValue("@DeductionHead", DeductionHead);
                        //cmd.Parameters.AddWithValue("@DeductHeadCode", DeductHeadCode);
                        cmd.Parameters.AddWithValue("@FactorInPer", FactorInPer);
                        cmd.Parameters.AddWithValue("@PerOrAmnt", PerOrAmnt);
                        cmd.Parameters.AddWithValue("@AddLess", AddLess);
                        cmd.Parameters.AddWithValue("@TaxAmount", TaxAmount);
                        cmd.Parameters.AddWithValue("@RefID", billTaxRefID);
                        cmd.ExecuteNonQuery();
                    }
                    else // insert
                    {
                        // getting new bill tax ref IDs
                        int billTaxRefID_New = getBillTaxRefID();

                        alert($"entered into else condition");

                        string sql = $@"INSERT INTO BillTaxHead751 
                                        (RefID, BillRefNo, AccountHead, DeductionHead, DeductHeadCode, FactorInPer, PerOrAmnt, AddLess, TaxAmount) 
                                        VALUES 
                                        (@RefID, @BillRefNo, @AccountHead, @DeductionHead, @DeductHeadCode, @FactorInPer, @PerOrAmnt, @AddLess, @TaxAmount)";

                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@RefID", billTaxRefID_New);
                        cmd.Parameters.AddWithValue("@BillRefNo", BillRefno);
                        cmd.Parameters.AddWithValue("@AccountHead", AccountHeadGroup);
                        cmd.Parameters.AddWithValue("@DeductionHead", DeductionHead);
                        cmd.Parameters.AddWithValue("@DeductHeadCode", DeductHeadCode);
                        cmd.Parameters.AddWithValue("@FactorInPer", FactorInPer);
                        cmd.Parameters.AddWithValue("@PerOrAmnt", PerOrAmnt);
                        cmd.Parameters.AddWithValue("@AddLess", AddLess);
                        cmd.Parameters.AddWithValue("@TaxAmount", TaxAmount);
                        cmd.ExecuteNonQuery();
                    }
                }

                con.Close();
            }
        }
    }

    private int getBillTaxRefID()
    {
        string nextRefID = "10001";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "SELECT ISNULL(MAX(CAST(RefID AS INT)), 10000) + 1 AS NextRefID FROM BillTaxHead751";
            SqlCommand cmd = new SqlCommand(sql, con);

            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value) { nextRefID = result.ToString(); }

            return Convert.ToInt32(nextRefID);
        }
    }

    private bool CheckTaxHeadForBillRefNo(string billRefno)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "SELECT * FROM BillTaxHead751 WHERE BillRefNo=@BillRefNo";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@BillRefNo", billRefno);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0) return true;
            else return false;
        }
    }


}