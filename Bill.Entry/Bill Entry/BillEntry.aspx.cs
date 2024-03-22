using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bill_Entry_BillEntry : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dateBillDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Bind_Vendor_Dropdown();
            Bind_UnitOffice_Dropdown();
            Bind_ImprestCardNo_Dropdown();
            Bind_AllocationHead_Dropdown();

            Bind_Item_Dropdown();
            Bind_UOM_Dropdown();

            //Session["TotalBillAmount"] = "";
        }
    }




    //=========================={ Fetching Reference Nos }==========================

    private void alert(string mssg)
    {
        // alert pop-up with only message
        string message = mssg;
        string script = $"alert('{message}');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "messageScript", script, true);
    }

    private int GetRefID()
    {
        string nextRefID = "1000001";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "SELECT ISNULL(MAX(CAST(RefNo AS INT)), 1000000) + 1 AS NextRefID FROM Bills1751";
            SqlCommand cmd = new SqlCommand(sql, con);

            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value) { nextRefID = result.ToString(); }

            con.Close();
            return Convert.ToInt32(nextRefID);
        }
    }


    private string GetNewVendorReferenceNo()
    {
        string nextRefNo = "1000001";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "SELECT ISNULL(MAX(CAST(RefID AS INT)), 1000000) + 1 AS NextRefNo FROM ContestantMaster751";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0) return dt.Rows[0]["NextRefNo"].ToString();
            else return nextRefNo;
        }
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

    // info
    private void getSweetAlertInfo(string titles, string mssg)
    {
        string title = titles;
        string message = mssg;
        string icon = "info";
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




    //=========================={ Add New Vendor }==========================
    protected void AddVendor_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        bool isChecked = checkBox.Checked;

        if (isChecked)
        {
            AddVendorDiv.Visible = true;
        }
        else
        {
            AddVendorDiv.Visible = false;
        }
    }

    protected void BtnAddVendor_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            string newVendorName = NewVendorText.Text.ToString();
            string vendorRefNo_New = GetNewVendorReferenceNo();


            string sql = "insert into ContestantMaster751 (vName, RefID) values (@vName, @RefID)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@vName", newVendorName);
            cmd.Parameters.AddWithValue("@RefID", vendorRefNo_New);
            int k = cmd.ExecuteNonQuery();

            //SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //ad.Fill(dt);
            //con.Close();

            // binding newly entered vendor to dropdown again
            if(k > 0)
            {
                BindNewVendorToDropdown(newVendorName);
            }
        }
    }

    private void BindNewVendorToDropdown(string newVendorName)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select RefID, vName from ContestantMaster751 order by RefID desc";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                // clearing existing selections
                ddVendor.ClearSelection();

                ddVendor.DataSource = dt;
                ddVendor.DataTextField = "vName";
                ddVendor.DataValueField = "vName";
                ddVendor.DataBind();
                ddVendor.Items.Insert(0, new ListItem("------Select Vendor------", "0"));

                // Selecting the top record
                if (dt.Rows[0]["vName"] != null)
                {
                    ddVendor.SelectedValue = dt.Rows[0]["vName"].ToString();
                }

                getSweetAlertInfo("New Vendor Added!", "Please Select The New Vendor Frop Drop Down");

                AddVendor.Checked = false;
                AddVendorDiv.Visible = false;
                NewVendorText.Text = string.Empty;
            }
        }
    }




    //=========================={ Dropdown Bind }==========================

    private void Bind_Vendor_Dropdown()
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

            ddVendor.DataSource = dt;
            ddVendor.DataTextField = "vName";
            ddVendor.DataValueField = "vName";
            ddVendor.DataBind();
            ddVendor.Items.Insert(0, new ListItem("------Select Vendor------", "0"));
        }
    }

    private void Bind_UnitOffice_Dropdown()
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

            ddUnitOffice.DataSource = dt;
            ddUnitOffice.DataTextField = "unitName";
            ddUnitOffice.DataValueField = "unitCode";
            ddUnitOffice.DataBind();
            ddUnitOffice.Items.Insert(0, new ListItem("------Select Unit / Office------", "0"));
        }
    }

    private void Bind_ImprestCardNo_Dropdown()
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

            ddImprestCardNo.DataSource = dt;
            ddImprestCardNo.DataTextField = "icNumber";
            ddImprestCardNo.DataValueField = "icNumber";
            ddImprestCardNo.DataBind();
            ddImprestCardNo.Items.Insert(0, new ListItem("------Select Imprest Card No.------", "0"));
        }
    }

    private void Bind_ImprestCardHolder_Dropdown(string imprestCardNo)
    {
        DataTable icDT = getImpCardDT(imprestCardNo);

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from ImprestCard751 where icNumber = @icNumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@icNumber", icDT.Rows[0]["icNumber"].ToString());
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddImprestCardHolder.DataSource = dt;
            ddImprestCardHolder.DataTextField = "icFirstName";
            ddImprestCardHolder.DataValueField = "icNumber";
            ddImprestCardHolder.DataBind();
            ddImprestCardHolder.Items.Insert(0, new ListItem("------Select Imprest Card Holder------", "0"));
        }
    }

    private void Bind_AllocationHead_Dropdown()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from Allocationhead751";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            ddAlloctHead.DataSource = dt;
            ddAlloctHead.DataTextField = "AllocatNo";
            ddAlloctHead.DataValueField = "AllocatNo";
            ddAlloctHead.DataBind();
            ddAlloctHead.Items.Insert(0, new ListItem("------Select Allocate No.------", "0"));
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




    //=========================={ Drop Down Event }==========================
    protected void ddImprestCardNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string imprestCardNo = ddImprestCardNo.SelectedValue;

        if (ddImprestCardNo.SelectedValue != "0")
        {
            Bind_ImprestCardHolder_Dropdown(imprestCardNo);
        }
        else
        {

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
            }
        }
    }


    //=========================={ Fetching DataTable }==========================

    private DataTable getImpCardDT(string imprestCardNo)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select * from ImprestCard751 where icNumber = @icNumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@icNumber", imprestCardNo);
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
            //cmd.Parameters.AddWithValue("@icNumber", imprestCardNo);
            cmd.ExecuteNonQuery();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
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
        string item = ddItem.SelectedValue;
        string uom = ddUOM.SelectedValue;
        double price = Convert.ToDouble(txtPrice.Text.ToString());
        double qty = Convert.ToDouble(txtQty.Text.ToString());
        double amount = (price * qty);

        if (price >= 0.00 && qty >= 0)
        {
            DataTable dt = ViewState["BillDetailsVS"] as DataTable ?? createBillDatatable();

            AddRowToBillDetailsDataTable(dt, item, uom, price, qty, amount);

            ViewState["BillDetailsVS"] = dt;
            Session["BillDetails"] = dt;

            if (dt.Rows.Count > 0)
            {
                itemDiv.Visible = true;

                itemGrid.DataSource = dt;
                itemGrid.DataBind();


                double? totalBillAmount = dt.AsEnumerable().Sum(row => row["Amount"] is DBNull ? (double?)null : Convert.ToDouble(row["Amount"])) ?? 0.0;








                //double totalBillAmount = 0.00;

                //if (Session["TotalBillAmount"].ToString() != "")
                //{
                //    totalBillAmount = Convert.ToDouble(txtBillAmount.Text);
                //}

                //totalBillAmount = totalBillAmount + amount;


                Session["TotalBillAmount"] = totalBillAmount;

                txtBillAmount.Text = totalBillAmount.HasValue ? totalBillAmount.Value.ToString("N2") : "0.00";

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

    private void AddRowToBillDetailsDataTable(DataTable dt, string item, string uom, double price, double qty, double amount)
    {
        // Create a new row
        DataRow row = dt.NewRow();

        // Set values for the new row
        //row["RefNo"] = refNo;
        row["Item"] = item;
        row["UOM"] = uom;
        row["Price"] = price;
        row["Qty"] = qty;
        row["Amount"] = amount;

        // Add the new row to the DataTable
        dt.Rows.Add(row);
    }



    //=========================={ Tax Head }==========================

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

    protected void GridTax_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            // Set the row in edit mode
            e.Row.RowState = e.Row.RowState ^ DataControlRowState.Edit;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // fetching acount head or taxes
            DataTable accountHeadDT = getAccountHead();

            //=================================={ Add/Less column }========================================
            DropDownList ddlAddLess = (DropDownList)e.Row.FindControl("AddLess");

            if (ddlAddLess != null)
            {
                string addLessValue = accountHeadDT.Rows[e.Row.RowIndex]["AddLess"].ToString();
                ddlAddLess.SelectedValue = addLessValue;
            }

            //=================================={ Percentage/Amount column }========================================
            DropDownList ddlPerOrAmnt = (DropDownList)e.Row.FindControl("PerOrAmnt");

            if (ddlPerOrAmnt != null)
            {
                string perOrAmntValue = accountHeadDT.Rows[e.Row.RowIndex]["PerOrAmnt"].ToString();
                ddlPerOrAmnt.SelectedValue = perOrAmntValue;
            }
        }
    }

    private void FillTaxHead()
    {
        // fetching acount head or taxes
        DataTable accountHeadDT = getAccountHead();
        Session["AccountHeadDT"] = accountHeadDT;

        // total bill amount
        double totalBillAmount = Convert.ToDouble(Session["TotalBillAmount"]);

        // fill tax heads
        autoFilltaxHeads(accountHeadDT, totalBillAmount);
    }

    private void autoFilltaxHeads(DataTable accountHeadDT, double bscAmnt)
    {
        double basicAmount = bscAmnt;
        double totalDeduction = 0.00;
        double totalAddition = 0.00;
        double netAmount = 0.00;

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
        Response.Redirect("BillEntryUpdate/BillUpdate.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (itemGrid.Rows.Count > 0)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string billReferenceNo = GetRefID().ToString();
                    Session["BillHeaderRefNo"] = billReferenceNo;

                    // insert header
                    insertBillHeader(billReferenceNo, con, transaction);

                    // inserting item details
                    insertItemDetails(billReferenceNo, con, transaction);

                    // inserting bill tax heads
                    string taxOrNot = ddTaxOrNot.SelectedValue;

                    if (taxOrNot == "Yes")
                    {
                        insertBillTaxHeads(billReferenceNo, con, transaction);
                    }

                    InsertWorkFlowBillEntery(billReferenceNo, con, transaction);

                    if (transaction != null) transaction.Commit();

                    // success notification
                    getSweetAlertSuccessRedirectMandatory("Bill Saved!", $"The Bill Reference Number: {billReferenceNo} Saved Successfully", "BillEntryUpdate/BillUpdate.aspx");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                finally
                {
                    con.Close();
                    transaction.Dispose();
                }
            }
        }
        else
        {
            getSweetAlertErrorMandatory("No Item Added!", "Kindly Add Minimum 1 Item To Proceed Further");
        }
    }



    private void insertBillHeader(string billReferenceNo, SqlConnection con, SqlTransaction transaction)
    {
        string userID = Session["UserId"].ToString();

        string refno = billReferenceNo;
        string billNo = txtBillNo.Text.ToString();
        DateTime billDate = DateTime.Parse(dateBillDate.Text);
        string vendor = ddVendor.SelectedValue;
        string unitOffice = ddUnitOffice.SelectedValue;
        string impCardNo = ddImprestCardNo.SelectedValue;
        string impCardHolder = ddImprestCardHolder.SelectedValue;
        string allocateHead = ddAlloctHead.SelectedValue;

        double totalBillAmount = Convert.ToDouble(Session["TotalBillAmount"]);

        string isTaxApplied = ddTaxOrNot.SelectedValue; // tax applied Yes or No

        double totalDeduction = Convert.ToDouble(txtTotalDeduct.Text);
        double totalAddition = Convert.ToDouble(txtTotalAdd.Text);
        double netBillAmount = 0.00;

        if (isTaxApplied == "Yes")
        {
            netBillAmount = Convert.ToDouble(txtNetAmnt.Text);
        }
        else
        {
            netBillAmount = totalBillAmount; // normal bill amount same
        }

        string sql = $@"INSERT INTO Bills1751 
                        (RefNo, VouNo, BillDate, Vendor, Unit, CardNo, CardHld, AlcnNo, BillAmt, TaxApplied, TotalDeduct, TotalAdd, NetAmount, SaveBy) 
                        VALUES 
                        (@RefNo, @VouNo, @BillDate, @Vendor, @Unit, @CardNo, @CardHld, @AlcnNo, @BillAmt, @TaxApplied, @TotalDeduct, @TotalAdd, @NetAmount, @SaveBy)";

        SqlCommand cmd = new SqlCommand(sql, con, transaction);
        cmd.Parameters.AddWithValue("@RefNo", refno);
        cmd.Parameters.AddWithValue("@VouNo", billNo);
        cmd.Parameters.AddWithValue("@BillDate", billDate);
        cmd.Parameters.AddWithValue("@Vendor", vendor);
        cmd.Parameters.AddWithValue("@Unit", unitOffice);
        cmd.Parameters.AddWithValue("@CardNo", impCardNo);
        cmd.Parameters.AddWithValue("@CardHld", impCardHolder);
        cmd.Parameters.AddWithValue("@AlcnNo", allocateHead);
        cmd.Parameters.AddWithValue("@BillAmt", totalBillAmount);
        cmd.Parameters.AddWithValue("@TaxApplied", isTaxApplied);
        cmd.Parameters.AddWithValue("@TotalDeduct", totalDeduction);
        cmd.Parameters.AddWithValue("@TotalAdd", totalAddition);
        cmd.Parameters.AddWithValue("@NetAmount", netBillAmount);
        cmd.Parameters.AddWithValue("@SaveBy", userID);
        cmd.ExecuteNonQuery();

        //SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //ad.Fill(dt);
    }

    private void insertItemDetails(string billReferenceNo, SqlConnection con, SqlTransaction transaction)
    {
        string userID = Session["UserId"].ToString();

        DataTable itemsDT = (DataTable)Session["BillDetails"];

        // bill header ref no
        string billRefno = billReferenceNo;

        foreach (GridViewRow row in itemGrid.Rows)
        {
            int rowIndex = row.RowIndex;

            // individual item ref no
            string itemRefNo = GetItemRefID(con, transaction);

            // Item, UOM, Price, Qty, Amount
            string item = itemsDT.Rows[rowIndex]["Item"].ToString();
            string uom = itemsDT.Rows[rowIndex]["UOM"].ToString();

            double price = Convert.IsDBNull(itemsDT.Rows[rowIndex]["Price"]) ? 0.00 : Convert.ToDouble(itemsDT.Rows[rowIndex]["Price"]);
            double qty = Convert.IsDBNull(itemsDT.Rows[rowIndex]["Qty"]) ? 0.00 : Convert.ToDouble(itemsDT.Rows[rowIndex]["Qty"]);
            double amount = Convert.IsDBNull(itemsDT.Rows[rowIndex]["Amount"]) ? 0.00 : Convert.ToDouble(itemsDT.Rows[rowIndex]["Amount"]);

            // inserting bill item details
            string sql = $@"INSERT INTO Bills2751 
                            (RefNo, RefIDItem, Item, UOM, Price, Qty, Amount, SaveBy) 
                            VALUES 
                            (@RefNo, @RefIDItem, @Item, @UOM, @Price, @Qty, @Amount, @SaveBy)";

            SqlCommand cmd = new SqlCommand(sql, con, transaction);
            cmd.Parameters.AddWithValue("@RefNo", billRefno);
            cmd.Parameters.AddWithValue("@RefIDItem", itemRefNo);
            cmd.Parameters.AddWithValue("@Item", item);
            cmd.Parameters.AddWithValue("@UOM", uom);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Qty", qty);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.Parameters.AddWithValue("@SaveBy", userID);
            cmd.ExecuteNonQuery();

            //SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //ad.Fill(dt);
        }
    }

    private void insertBillTaxHeads(string billReferenceNo, SqlConnection con, SqlTransaction transaction)
    {
        string userID = Session["UserId"].ToString();

        string BillRefno = billReferenceNo;

        // Account Head DataTable
        DataTable dt = (DataTable)Session["AccountHeadDT"];

        if (dt != null)
        {
            foreach (GridViewRow row in GridTax.Rows)
            {
                // to get the current row index
                int rowIndex = row.RowIndex;

                // getting new bill tax ref IDs
                string billTaxRefID = getBillTaxRefID(con, transaction);



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


                // inserting into BILL Tax
                string sql = $@"INSERT INTO BillTaxHead751 
                                (RefID, BillRefNo, AccountHead, DeductionHead, DeductHeadCode, FactorInPer, PerOrAmnt, AddLess, TaxAmount, SaveBy) 
                                VALUES 
                                (@RefID, @BillRefNo, @AccountHead, @DeductionHead, @DeductHeadCode, @FactorInPer, @PerOrAmnt, @AddLess, @TaxAmount, @SaveBy)";

                SqlCommand cmd = new SqlCommand(sql, con, transaction);
                cmd.Parameters.AddWithValue("@RefID", billTaxRefID);
                cmd.Parameters.AddWithValue("@BillRefNo", BillRefno);
                cmd.Parameters.AddWithValue("@AccountHead", AccountHeadGroup);
                cmd.Parameters.AddWithValue("@DeductionHead", DeductionHead);
                cmd.Parameters.AddWithValue("@DeductHeadCode", DeductHeadCode);
                cmd.Parameters.AddWithValue("@FactorInPer", FactorInPer);
                cmd.Parameters.AddWithValue("@PerOrAmnt", PerOrAmnt);
                cmd.Parameters.AddWithValue("@AddLess", AddLess);
                cmd.Parameters.AddWithValue("@TaxAmount", TaxAmount);
                cmd.Parameters.AddWithValue("@SaveBy", userID);
                cmd.ExecuteNonQuery();

                //SqlDataAdapter ad = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);
            }
        }
    }

    private string getBillTaxRefID(SqlConnection con, SqlTransaction transaction)
    {
        string nextRefNo = "10001";

        string sql = "SELECT ISNULL(MAX(CAST(RefID AS INT)), 10000) + 1 AS NextRefNo FROM BillTaxHead751";
        SqlCommand cmd = new SqlCommand(sql, con, transaction);

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);

        if (dt.Rows.Count > 0) return dt.Rows[0]["NextRefNo"].ToString();
        else return nextRefNo;
    }

    private string GetItemRefID(SqlConnection con, SqlTransaction transaction)
    {
        string nextRefNo = "10001";

        string sql = "SELECT ISNULL(MAX(CAST(RefIDItem AS INT)), 10000) + 1 AS NextRefNo FROM Bills2751";
        SqlCommand cmd = new SqlCommand(sql, con, transaction);

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);

        if (dt.Rows.Count > 0) return dt.Rows[0]["NextRefNo"].ToString();
        else return nextRefNo;
    }




    //========================{ WorkFlow Bill Entry }==================================

    private void InsertWorkFlowBillEntery(string billReferenceNo, SqlConnection con, SqlTransaction transaction)
    {
        string userID = Session["UserId"].ToString();

        // fetching the current logged-in user role
        string userRole = Session["UserRole"].ToString(); // eg: Tech, system, applicant etc.

        // getting next desk from WorkFlow2 table
        DataTable workFlow2DT = GetNextDeskWorlFlow(con, transaction);

        // next desk code
        string desk2 = workFlow2DT.Rows[0]["w2Desk1"].ToString();

        string sql = $@"INSERT INTO WorkFlow751 
                        (DocType, DocNo, Status, Reason, Desk1, Desk2, Remarks, SaveBy) 
                        VALUES 
                        (@DocType, @DocNo, @Status, @Reason, @Desk1, @Desk2, @Remarks, @SaveBy)";
        SqlCommand cmd = new SqlCommand(sql, con, transaction);
        cmd.Parameters.AddWithValue("@DocType", "Bills1");
        cmd.Parameters.AddWithValue("@DocNo", billReferenceNo);
        cmd.Parameters.AddWithValue("@Status", "New");
        cmd.Parameters.AddWithValue("@Reason", "For Review");
        cmd.Parameters.AddWithValue("@Desk1", userRole);
        cmd.Parameters.AddWithValue("@Desk2", desk2);
        cmd.Parameters.AddWithValue("@Remarks", "System Genereted");
        cmd.Parameters.AddWithValue("@SaveBy", userID);
        cmd.ExecuteNonQuery();

        //SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //ad.Fill(dt);
    }

    private DataTable GetNextDeskWorlFlow(SqlConnection con, SqlTransaction transaction)
    {
        string sql = $@"SELECT * FROM WorkFlow2751 WHERE w2Name = 'WFBills1' ORDER BY w2Order ASC";
        SqlCommand cmd = new SqlCommand(sql, con, transaction);
        //cmd.Parameters.AddWithValue("@BillAmt", totalBillAmount);
        //cmd.ExecuteNonQuery();

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);

        return dt;
    }


}