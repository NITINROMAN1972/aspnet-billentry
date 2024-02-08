<%@ Page Language="C#" UnobtrusiveValidationMode="None" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="BillEntry.aspx.cs" Inherits="Bill_Entry_BillEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Entry</title>

    <%--<!--Bootstrap CSS-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <!--jQuery-->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha384-KyZXEAg3QhqLMpG8r+J2Wk5vqXn3Fm/z2N1r8f6VZJ4T3Hdvh4kXG1j4fZ6IsU2f5" crossorigin="anonymous"></script>

    <!--AJAX JS-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <!--Bootstrap JS-->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

    <!--Using JavaScript library such as Select2-->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/js/select2.min.js"></script>--%>

    <!-- SweetAlert2 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.10.3/dist/sweetalert2.min.css" rel="stylesheet" />
    <!-- SweetAlert2 JS -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.10.3/dist/sweetalert2.all.min.js"></script>



    <!-- CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap1.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-icons.min.css" rel="stylesheet" />
    <link href="../css/eye-fill.svg" rel="stylesheet" />

    <!-- Popper.js -->
    <script src="../js/popper.min.js"></script>
    <script src="../js/popper1.min.js"></script>

    <!-- jQuery -->
    <script src="../js/jquery-3.6.0.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-3.3.1.slim.min.js"></script>

    <!-- Bootstrap JS -->
    <script src="../js/bootstrap.bundle.min.js"></script>
    <script src="../js/bootstrap1.min.js"></script>

    <!-- Select2 library CSS and JS -->
    <link href="../select2/select2.min.css" rel="stylesheet" />
    <script src="../select2/select2.min.js"></script>






    <script src="bill-entry.js"></script>
    <link rel="stylesheet" href="bill-entry.css" />
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <!-- Heading -->
        <div class="col-md-11 mx-auto mt-1">
            <div class="fw-normal fs-5 fw-medium text-body-secondary">
                <asp:Literal Text="Bill Entry" runat="server"></asp:Literal>
            </div>
        </div>


        <!-- UI -->
        <div class="card col-md-11 mx-auto mt-2 py-2 shadow-sm rounded-3">
            <div class="card-body">

                <!-- Bill details -->

                <!-- 1st row -->
                <div class="row mb-2">
                    <div class="col-md-6 align-self-end">
                        <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                            <asp:Literal ID="Literal10" Text="Bill Number" runat="server">Bill Number<em style="color: red">*</em></asp:Literal>
                            <div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtBillNo" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="" runat="server" ErrorMessage="(Please select bill no)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <asp:TextBox runat="server" ID="txtBillNo" type="text" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                    </div>
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

                <!-- 2nd row -->
                <div class="row mb-2">
                    <div class="col-md-6 align-self-end">
                        <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                            <asp:Literal ID="Literal1" Text="" runat="server">Vendor<em style="color: red">*</em></asp:Literal>
                            <div>
                                <asp:RequiredFieldValidator ID="rr1" ControlToValidate="ddVendor" ValidationGroup="finalSubmit" CssClass="invalid-feedback" InitialValue="0" runat="server" ErrorMessage="(Please select vendor)" SetFocusOnError="True" Display="Dynamic" ToolTip="Required"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <asp:DropDownList ID="ddVendor" runat="server" AutoPostBack="false" class="form-control is-invalid" CssClass=""></asp:DropDownList>
                    </div>
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

                <!-- 5th row -->
                <div class="align-self-end">
                    <div class="mb-1 text-body-tertiary fw-semibold fs-6">
                        <asp:Literal ID="Literal6" Text="" runat="server">Reference No</asp:Literal>
                    </div>
                    <asp:TextBox runat="server" ID="txtRefNo" type="text" Enabled="false" CssClass="form-control border border-secondary-subtle bg-light rounded-1 fs-6 fw-light py-1"></asp:TextBox>
                </div>



            </div>
        </div>





        <!-- Below Panel UI -->
        <div class="card col-md-11 mx-auto mt-5 rounded-3">
            <div class="card-body">

                <!-- Heading -->
                <div class="fw-normal fs-5 fw-medium border-bottom pb-2 text-body-secondary">
                    <asp:Literal Text="Item Details" runat="server"></asp:Literal>
                </div>

                <!-- Item Insert -->
                <div class="card border-0 mt-3 rounded-3">
                    <div class="card-body">


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
                                    <asp:Button ID="btnItemInsert" runat="server" Text="Insert" OnClick="btnItemInsert_Click" ValidationGroup="ItemSave" CssClass="btn btn-success text-white shadow mb-5 col-md-7 button-position" />
                                </div>
                            </div>
                        </div>

                        <!-- Item GridView -->
                        <div id="itemDiv" runat="server" visible="false" class="mt-3">
                            <asp:GridView ShowHeaderWhenEmpty="true" ID="itemGrid" runat="server" AutoGenerateColumns="false"
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
                                </Columns>
                            </asp:GridView>

                            <hr class="border border-secondary-subtle" />

                            <!-- Total Bill -->
                            <div class="row mb-3">
                                <div class="col-md-9 align-self-end"></div>
                                <div class="col-md-3 align-self-end">
                                    <asp:Literal ID="Literal13" Text="" runat="server">Total Bill Amount</asp:Literal>
                                    <div class="input-group">
                                        <span class="input-group-text fs-5 fw-semibold">₹</span>
                                        <asp:TextBox runat="server" ID="txtBillAmount" CssClass="form-control fw-lighter border border-2" ReadOnly="true" placeholder="Total Bill Amount"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <!-- DD Apply Tax Or Not -->
                            <div class="row mb-3">
                                <div class="col-md-8"></div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddTaxOrNot" runat="server" OnSelectedIndexChanged="ddTaxOrNot_SelectedIndexChanged" AutoPostBack="true" CssClass="col-md-12 text-center fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2">
                                        <asp:ListItem Text="No Tax Head" Value="NoTax"></asp:ListItem>
                                        <asp:ListItem Text="Apply Tax Head" Value="Tax"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div id="divTaxHead" runat="server" visible="false">
                                <!-- Tax Grid -->
                                <asp:GridView ShowHeaderWhenEmpty="true" ID="GridTax" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridTax_RowDataBound" CssClass="table text-center">
                                    <HeaderStyle CssClass="align-middle table-secondary fw-light" />
                                    <Columns>

                                        <asp:TemplateField HeaderText="Deduction Head" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-4 align-middle text-start fw-light">
                                            <ItemTemplate>
                                                <asp:TextBox ID="AcHName" runat="server" Enabled="false" CssClass="col-md-9 fw-light bg-white border-0 py-1 px-2" Text='<%# Bind("AcHName") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Factor in %" ItemStyle-Font-Size="15px" ItemStyle-CssClass="col-md-2 align-middle">
                                            <ItemTemplate>
                                                <asp:TextBox ID="FactorInPer" runat="server" Enabled="true" CssClass="col-md-9 fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2" type="number" Text='<%# Bind("FactorInPer") %>'></asp:TextBox>
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
                                                <asp:TextBox ID="TaxAmount" runat="server" Enabled="true" ReadOnly="true" CssClass="col-md-9 fw-light border border-secondary-subtle shadow-sm rounded-1 py-1 px-2" type="number" Text='<%# Bind("TaxAmount") %>'></asp:TextBox>
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
                                <div class="mb-2">
                                    <div class="row mb-3">
                                        <div class="col-md-9 align-self-end">
                                            <!--  -->
                                        </div>
                                        <div class="col-md-3 align-self-end">
                                            <asp:Literal ID="Literal14" Text="Total Deductions :" runat="server"></asp:Literal>
                                            <div class="input-group text-end">
                                                <span class="input-group-text fs-5 fw-light">₹</span>
                                                <asp:TextBox runat="server" ID="txtTotalDeduct" CssClass="form-control fw-lighter border border-2" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mb-3">
                                        <div class="col-md-9 align-self-end">
                                            <!--  -->
                                        </div>
                                        <div class="col-md-3 align-self-end">
                                            <asp:Literal ID="Literal15" Text="Total Additions :" runat="server"></asp:Literal>
                                            <div class="input-group text-end">
                                                <span class="input-group-text fs-5 fw-light">₹</span>
                                                <asp:TextBox runat="server" ID="txtTotalAdd" CssClass="form-control fw-lighter border border-2" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mb-3">
                                        <div class="col-md-9 align-self-end">
                                            <!--  -->
                                        </div>
                                        <div class="col-md-3 align-self-end">
                                            <asp:Literal ID="Literal16" Text="Net Amount :" runat="server"></asp:Literal>
                                            <div class="input-group text-end">
                                                <span class="input-group-text fs-5 fw-light">₹</span>
                                                <asp:TextBox runat="server" ID="txtNetAmnt" CssClass="form-control fw-lighter border border-2" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>


                    <!-- Heading -->
                    <div class="border-top border-bottom border-secondary-subtle py-2 mt-4">
                        <div class="fw-normal fs-5 fw-medium text-body-secondary">
                            <asp:Literal Text="Document Upload" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <!-- Documents upload -->
                    <div class="row">
                        <div class="col-md-6">
                            <div class="mt-4 input-group has-validation">
                                <asp:FileUpload ID="fileDoc" runat="server" CssClass="form-control" aria-describedby="inputGroupPrepend" />
                                <asp:Button ID="btnDocUpload" OnClick="btnDocUpload_Click" runat="server" Text="Upload" AutoPost="true" CssClass="btn btn-custom btn-outline-secondary" />
                            </div>
                            <h6 class="pt-3 fw-lighter fs-6 text-secondary-subtle">User can upload multiple documents using upload button !</h6>
                        </div>
                        <div class="col-md-6"></div>
                    </div>


                    <!-- Document Grid -->
                    <div id="docGrid" class="mt-5" runat="server" visible="false">
                        <asp:GridView ShowHeaderWhenEmpty="true" ID="GridDocument" EnableViewState="true" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-bordered border border-light-subtle text-start mt-3 grid-custom">
                            <HeaderStyle CssClass="align-middle fw-light fs-6" />
                            <Columns>
                                <asp:TemplateField ControlStyle-CssClass="col-md-1" HeaderText="Sr.No">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="id" runat="server" Value="id" />
                                        <span>
                                            <%#Container.DataItemIndex + 1%>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="DocName" HeaderText="File Name" ReadOnly="true" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light" />

                                <asp:TemplateField HeaderText="View Document" ItemStyle-Font-Size="15px" ItemStyle-CssClass="align-middle text-start fw-light">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="DocPath" runat="server" Text="View Uploaded Document" NavigateUrl='<%# Eval("DocPath") %>' Target="_blank" CssClass="text-decoration-none"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>


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
