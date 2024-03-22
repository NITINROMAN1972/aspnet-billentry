<%@ Page Language="C#" UnobtrusiveValidationMode="None" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="BillEntry.aspx.cs" Inherits="Bill_Entry_BillEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Entry</title>

    <!-- Boottrap CSS -->
    <link href="../assests/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assests/css/bootstrap1.min.css" rel="stylesheet" />

    <!-- Bootstrap JS -->
    <script src="../assests/js/bootstrap.bundle.min.js"></script>
    <script src="../assests/js/bootstrap1.min.js"></script>

    <!-- Popper.js -->
    <script src="../assests/js/popper.min.js"></script>
    <script src="../assests/js/popper1.min.js"></script>

    <!-- jQuery -->
    <script src="../assests/js/jquery-3.6.0.min.js"></script>
    <script src="../assests/js/jquery.min.js"></script>
    <script src="../assests/js/jquery-3.3.1.slim.min.js"></script>

    <!-- Select2 library CSS and JS -->
    <link href="../assests/select2/select2.min.css" rel="stylesheet" />
    <script src="../assests/select2/select2.min.js"></script>

    <!-- Sweet Alert CSS and JS -->
    <link href="../assests/sweertalert/sweetalert2.min.css" rel="stylesheet" />
    <script src="../assests/sweertalert/sweetalert2.all.min.js"></script>

    <script src="bill-entry.js"></script>
    <link rel="stylesheet" href="bill-entry.css" />
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <!-- Heading -->
        <div class="col-md-11 mx-auto fw-normal fs-3 fw-medium ps-0 pb-2 text-body-secondary mb-3">
            <asp:Literal Text="Bill Entry" runat="server"></asp:Literal>
        </div>


        <!-- Header UI Starts -->
        <div class="card col-md-11 mx-auto mt-1 py-2 shadow-sm rounded-3">
            <div class="card-body">

                <!-- Update Panel Starts -->
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <!-- Heading -->
                        <div class="fw-normal fs-5 fw-medium text-body-secondary border-bottom pb-2 mb-4">
                            <asp:Literal Text="Bill Details" runat="server"></asp:Literal>
                        </div>

                        <!-- Bill details -->

                        <!-- 1st row -->
                        <div class="row mb-2">

                            <!-- Bill Number -->
                            <div class="col-md-6 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal10" Text="Bill Number" runat="server">Bill Number<em style="color: red">*</em></asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtBillNo" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(Please select bill no)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:TextBox runat="server" ID="txtBillNo" type="text" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                            </div>

                            <!-- Bill Date -->
                            <div class="col-md-6 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal12" Text="Bill Date" runat="server">Bill Date<em style="color: red">*</em></asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="dateBillDate" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(Please select the date)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:TextBox runat="server" ID="dateBillDate" type="date" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Mid Row >> Add Vendor -->
                        <div class="row mb-2 ms-1">

                            <!-- Add Vendor -->
                            <div class="col-md-2 align-self-end px-0 mt-4">
                                <div class="input-group text-end">
                                    <span class="input-group-text fs-6 px-3 py-2 fw-light">Add Vendor</span>
                                    <div class="border border-dark-subtle rounded-end-3 text-center px-4 py-auto" style="display: flex; align-items: center;">
                                        <asp:CheckBox ID="AddVendor" runat="server" AutoPostBack="true" OnCheckedChanged="AddVendor_CheckedChanged" />
                                    </div>
                                </div>
                            </div>

                            <div id="AddVendorDiv" runat="server" visible="false" class="row col-md-10 align-self-end px-0 mt-4 border accordion-body border-primary-subtle py-3 rounded-3 shadow-sm">
                                <!-- New Vendor textbox -->
                                <div class="col-md-10 align-self-end">
                                    <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                        <asp:Literal ID="Literal13" Text="" runat="server">Add New Vendor Name<em style="color: red">*</em></asp:Literal>
                                    </div>
                                    <asp:TextBox runat="server" ID="NewVendorText" type="text" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                                </div>

                                <!-- New Vendor Add Button -->
                                <div class="col-md-2 align-self-end text-end">
                                    <div class="pb-0 mb-0">
                                        <asp:Button ID="BtnAddVendor" runat="server" Text="Add +" OnClick="BtnAddVendor_Click" CssClass="btn btn-success text-white shadow mb-5 col-md-7 button-position" />
                                    </div>
                                </div>
                            </div>

                        </div>

                        <!-- 2nd row -->
                        <div class="row mb-2">

                            <!-- Vendor -->
                            <div class="col-md-6 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal1" Text="" runat="server">Vendor<em style="color: red">*</em></asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="rr1" ControlToValidate="ddVendor" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(Please select vendor)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:DropDownList ID="ddVendor" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                            </div>

                            <!-- Unit / Office -->
                            <div class="col-md-6 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal2" Text="" runat="server">Unit / Office<em style="color: red">*</em></asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="rr2" ControlToValidate="ddUnitOffice" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(Please select unit / office)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:DropDownList ID="ddUnitOffice" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                            </div>
                        </div>

                        <!-- 3rd row -->
                        <div class="row mb-2">

                            <!-- Imperest Card Number -->
                            <div class="col-md-4 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal3" Text="" runat="server">Imperest Card Number<em style="color: red">*</em></asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="rr3" ControlToValidate="ddImprestCardNo" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(Please select imprest card no)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddImprestCardNo" OnSelectedIndexChanged="ddImprestCardNo_SelectedIndexChanged" runat="server" AutoPostBack="true" class="form-control is-invalid" CssClass="" ClientIDMode="Static"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <!-- Imperest Card Holder -->
                            <div class="col-md-4 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal4" Text="" runat="server">Imperest Card Holder<em style="color: red">*</em></asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="rr4" ControlToValidate="ddImprestCardHolder" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(Please select imprest card holder)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddImprestCardHolder" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass="" ClientIDMode="Static"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <!-- Allocate Head -->
                            <div class="col-md-4 align-self-end">
                                <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                    <asp:Literal ID="Literal5" Text="" runat="server">Allocate Head<em style="color: red">*</em></asp:Literal>
                                    <div>
                                        <asp:RequiredFieldValidator ID="rr5" ControlToValidate="ddAlloctHead" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(Please select allocate head)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:DropDownList ID="ddAlloctHead" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                            </div>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
                <!-- Update Panel Ends -->


            </div>
        </div>
        <!-- Header UI Ends -->




        <!-- Below Panel UI -->
        <div class="card col-md-11 mx-auto mt-5 rounded-3">
            <div class="card-body">

                <!-- Heading -->
                <div class="fw-normal fs-5 fw-medium border-bottom pb-2 text-body-secondary">
                    <asp:Literal Text="Item Details" runat="server"></asp:Literal>
                </div>

                <!-- Item Insert -->
                <div class="card border-0 mt-3 rounded-3">
                    <div class="">

                        <!-- Update Panel Starts -->
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>


                                <div class="row mb-2">
                                    <div class="col-md-3 align-self-end">
                                        <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                            <asp:Literal ID="Literal7" Text="" runat="server">Item<em style="color: red">*</em></asp:Literal>
                                            <div>
                                                <asp:RequiredFieldValidator ID="rr6" ControlToValidate="ddItem" ValidationGroup="ItemSave" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(Please select item)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <asp:DropDownList ID="ddItem" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3 align-self-end">
                                        <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                            <asp:Literal ID="Literal8" Text="" runat="server">UOM<em style="color: red">*</em></asp:Literal>
                                            <div>
                                                <asp:RequiredFieldValidator ID="rr7" ControlToValidate="ddUOM" ValidationGroup="ItemSave" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(Please select uom)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <asp:DropDownList ID="ddUOM" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 align-self-end">
                                        <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                            <asp:Literal ID="Literal9" Text="Bill Number" runat="server">Price</asp:Literal>
                                            <div>
                                                <asp:RequiredFieldValidator ID="rr8" ControlToValidate="txtPrice" ValidationGroup="ItemSave" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(Please insert the price)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <asp:TextBox runat="server" ID="txtPrice" type="text" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 align-self-end">
                                        <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                                            <asp:Literal ID="Literal11" Text="" runat="server">Quantity</asp:Literal>
                                            <div>
                                                <asp:RequiredFieldValidator ID="rr9" ControlToValidate="txtQty" ValidationGroup="ItemSave" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(Please insert the quantity)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <asp:TextBox runat="server" ID="txtQty" type="number" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 align-self-end text-end">
                                        <div class="pb-0 mb-0">
                                            <asp:Button ID="btnItemInsert" runat="server" Text="Add +" OnClick="btnItemInsert_Click" ValidationGroup="ItemSave" CssClass="btn btn-success text-white shadow mb-5 col-md-7 button-position" />
                                        </div>
                                    </div>
                                </div>

                                <!-- Item GridView -->
                                <div id="itemDiv" runat="server" visible="false" class="mt-3">
                                    <asp:GridView ShowHeaderWhenEmpty="true" ID="itemGrid" runat="server" AutoGenerateColumns="false" OnRowDeleting="Grid_RowDeleting"
                                        CssClass="table table-bordered  border border-1 border-dark-subtle text-center grid-custom mb-3">
                                        <HeaderStyle CssClass="align-middle" />
                                        <Columns>
                                            <asp:TemplateField ControlStyle-CssClass="col-md-1" HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="id" runat="server" Value="id" />
                                                    <span>
                                                        <%#Container.DataItemIndex + 1%>
                                                    </span>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="col-md-1" />
                                                <ItemStyle Font-Size="15px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Item" HeaderText="Item" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />
                                            <asp:BoundField DataField="UOM" HeaderText="UOM" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />
                                            <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />
                                            <asp:BoundField DataField="Qty" HeaderText="Qty" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />

                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>'>
                                                <asp:Image runat="server" ImageUrl="~/portal/assests/img/modern-cross-fill.svg" AlternateText="Edit" style="width: 28px; height: 28px;"/>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>

                                    <hr class="border border-secondary-subtle" />

                                    <!-- Total Bill & Tax Visibility Dropdown -->
                                    <div class="row px-0 mb-3">

                                        <!-- DD Apply Tax Or Not -->
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddTaxOrNot" runat="server" OnSelectedIndexChanged="ddTaxOrNot_SelectedIndexChanged" AutoPostBack="true" CssClass="col-md-12 text-center fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2">
                                                <asp:ListItem Text="No Tax Head" Value="No"></asp:ListItem>
                                                <asp:ListItem Text="Apply Tax Head" Value="Yes"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-md-3"></div>
                                        <div class="col-md-3"></div>

                                        <!-- Total Bill -->
                                        <div class="col-md-3 align-self-end text-end">
                                            <asp:Literal ID="Literal6" Text="" runat="server">Total Bill Amount</asp:Literal>
                                            <div class="input-group">
                                                <span class="input-group-text fs-5 fw-semibold">₹</span>
                                                <asp:TextBox runat="server" ID="txtBillAmount" CssClass="form-control fw-lighter border border-2" ReadOnly="true" placeholder="Total Bill Amount"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <!-- Tax Grid Starts -->
                                    <div id="divTaxHead" runat="server" visible="false">

                                        <asp:GridView ShowHeaderWhenEmpty="true" ID="GridTax" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridTax_RowDataBound" CssClass="table text-center">
                                            <HeaderStyle CssClass="align-middle table-secondary fw-light" />
                                            <Columns>

                                                <asp:TemplateField HeaderText="Account Head" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-4 align-middle text-start fw-light">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="AcHName" Text='<%# Bind("AcHName") %>' runat="server" Enabled="false" CssClass="col-md-9 fw-light bg-white border-0 py-1 px-2"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Factor in %" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-2 align-middle">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="FactorInPer" Text='<%# Bind("FactorInPer") %>' type="number" step="0.01" title="Enter a number two decimals" runat="server" Enabled="true" CssClass="col-md-9 fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="% / Amount" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-2 align-middle">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="PerOrAmnt" runat="server" CssClass="col-md-6 text-center fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2">
                                                            <asp:ListItem Text="%" Value="Percentage"></asp:ListItem>
                                                            <asp:ListItem Text="₹" Value="Amount"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Add / Less" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-2 align-middle">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="AddLess" runat="server" CssClass="col-md-6 text-center fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2">
                                                            <asp:ListItem Text="+" Value="Add"></asp:ListItem>
                                                            <asp:ListItem Text="-" Value="Less"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Amount" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-3 align-middle">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TaxAmount" Text='<%# Bind("TaxAmount") %>' type="number" step="0.01" runat="server" Enabled="true" ReadOnly="true" CssClass="col-md-9 fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>

                                        <!-- Re-Calculate Tax -->

                                        <div class="mt-3 mb-3">
                                            <div class="text-end">
                                                <asp:Button ID="btnReCalTax" runat="server" Text="Re-Calculate" OnClick="btnReCalTax_Click" CssClass="btn btn-custom text-white mb-3" />
                                            </div>
                                        </div>


                                        <!-- Net Deduction, Addition & Total Bill Amounts -->
                                        <div class="row mb-3">
                                            <!-- Total Deduction -->
                                            <div class="col-md-3 align-self-end">
                                                <asp:Literal ID="Literal14" Text="Total Deductions :" runat="server"></asp:Literal>
                                                <div class="input-group text-end">
                                                    <span class="input-group-text fs-5 fw-light">₹</span>
                                                    <asp:TextBox runat="server" ID="txtTotalDeduct" CssClass="form-control fw-lighter border border-2" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>

                                            <!-- Total Addition -->
                                            <div class="col-md-3 align-self-end">
                                                <asp:Literal ID="Literal15" Text="Total Additions :" runat="server"></asp:Literal>
                                                <div class="input-group text-end">
                                                    <span class="input-group-text fs-5 fw-light">₹</span>
                                                    <asp:TextBox runat="server" ID="txtTotalAdd" CssClass="form-control fw-lighter border border-2" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-md-3"></div>

                                            <!-- Net Amount -->
                                            <div class="col-md-3 align-self-end text-end">
                                                <asp:Literal ID="Literal16" Text="Net Amount :" runat="server"></asp:Literal>
                                                <div class="input-group text-end">
                                                    <span class="input-group-text fs-5 fw-light">₹</span>
                                                    <asp:TextBox runat="server" ID="txtNetAmnt" CssClass="form-control fw-lighter border border-2" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <!-- Tax Grid Ends -->


                                </div>

                                </div>

                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                        <!-- Update Panel Ends -->


                        <!-- Submit Button -->
                        <div class="">
                            <div class="row mt-5 mb-2">
                                <div class="col-md-6 text-start">
                                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-custom text-white shadow mb-5" />
                                </div>
                                <div class="col-md-6 text-end">
                                    <asp:Button ID="btnSubmit" Enabled="true" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="finalSubmit" CssClass="btn btn-custom text-white shadow mb-5" />
                                </div>
                            </div>
                        </div>


                    </div>




                </div>
            </div>
    </form>
</body>
</html>
