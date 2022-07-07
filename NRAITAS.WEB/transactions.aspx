<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="transactions.aspx.cs" Inherits="NRA_ITAS.transactions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="nra" %>
<!DOCTYPE html>
<html lang="en" class="light">
<!-- BEGIN: Head -->
<head>
    <meta charset="utf-8">
    <link href="Asset/images/uba.png" rel="shortcut icon">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Transactions - iTAS</title>
    <!-- BEGIN: CSS Assets-->
    <link rel="stylesheet" href="Asset/css/css-app.css">
    <!-- END: CSS Assets-->
    <style>
        #spin {
            display: none;
        }
    </style>
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            font-family: Arial;
        }

        .modal_acb {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

            .center img {
                height: 128px;
                width: 128px;
            }
    </style>
</head>
<!-- END: Head -->
<body class="main">
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <!-- BEGIN: Mobile Menu -->
        <div class="mobile-menu md:hidden">
            <div class="mobile-menu-bar">
                <a href="rubick.left4code.html" class="flex mr-auto">
                    <img alt="" class="w-6" src="Asset/images/uba.png">
                </a>
                <a href="javascript:;.html" id="mobile-menu-toggler"><i data-feather="bar-chart-2" class="w-8 h-8 text-white transform -rotate-90"></i></a>
            </div>
            <ul class="border-t border-theme-29 py-5 hidden">
                <li>
                    <a href="Home.aspx" class="menu menu--active">
                        <div class="menu__icon"><i data-feather="home"></i></div>
                        <div class="menu__title">Home</div>
                    </a>
                </li>
                <li>
                    <a href="transactions.aspx" class="menu">
                        <div class="menu__icon"><i data-feather="sidebar"></i></div>
                        <div class="menu__title">Transactions</div>
                    </a>
                </li>
                <li>
                    <a href="reports.aspx" class="menu">
                        <div class="menu__icon"><i data-feather="file-text"></i></div>
                        <div class="menu__title">Reports</div>
                    </a>
                </li>
                <li>
                    <a href="help.aspx" class="menu">
                        <div class="menu__icon"><i data-feather="help-circle"></i></div>
                        <div class="menu__title">Help</div>
                    </a>
                </li>
                <li>
                    <a href="login.aspx" class="menu">
                        <div class="menu__icon"><i data-feather="toggle-right"></i></div>
                        <div class="menu__title">Logout</div>
                    </a>
                </li>
            </ul>
        </div>
        <!-- END: Mobile Menu -->
        <div class="flex">
            <!-- BEGIN: Side Menu -->
            <nav class="side-nav">
                <a href="Home.aspx" class="intro-x flex items-center pl-5 pt-4">
                    <img alt="" class="w-72" src="Asset/images/uba.png">
                    <!--<i data-feather="box" class="side-menu__icon"></i>-->
                    <!--<span class="hidden xl:block text-white text-lg ml-3">AccessBank <span class="font-medium">iTAS</span> </span>-->
                </a>
                <div class="side-nav__devider my-6"></div>
                <ul>
                    <li>
                        <a href="Home.aspx" class="side-menu">
                            <div class="side-menu__icon"><i data-feather="home"></i></div>
                            <div class="side-menu__title">Home</div>
                        </a>
                    </li>
                    <%-- <asp:Panel ID="Panel1" runat="server" Visible="true">--%>
                    <li>
                        <a href="transactions.aspx" class="side-menu side-menu--active">
                            <div class="side-menu__icon"><i data-feather="sidebar"></i></div>
                            <div class="side-menu__title">Transactions</div>
                        </a>
                    </li>
                    <%--</asp:Panel>--%>
                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <li>
                            <a href="Admins.aspx" class="side-menu">
                                <div class="side-menu__icon"><i data-feather="user-check"></i></div>
                                <div class="side-menu__title">Admin</div>
                            </a>
                        </li>
                    </asp:Panel>
                    <li>
                        <a href="reports.aspx" class="side-menu">
                            <div class="side-menu__icon"><i data-feather="file-text"></i></div>
                            <div class="side-menu__title">Reports</div>
                        </a>
                    </li>
                    <li>
                        <a href="#" class="side-menu">
                            <div class="side-menu__icon"><i data-feather="help-circle"></i></div>
                            <div class="side-menu__title">Help</div>
                        </a>
                    </li>
                    <li>
                        <a href="login.aspx" class="side-menu">
                            <div class="side-menu__icon"><i data-feather="toggle-right"></i></div>
                            <div class="side-menu__title">Logout</div>
                        </a>
                    </li>
                </ul>
            </nav>
            <!-- END: Side Menu -->
            <!-- BEGIN: Content -->
            <!-- BEGIN: Content -->
            <div class="content">
                <!-- BEGIN: Top Bar -->
                <div class="top-bar">
                    <!-- BEGIN: Breadcrumb -->
                    <div class="-intro-x breadcrumb mr-auto  sm:flex"><a href="rubick.left4code.html"></a><i data-feather="chevron-right" class="breadcrumb__icon"></i><a href="rubick.left4code.html" class="breadcrumb--active"></a></div>
                    <!-- END: Breadcrumb -->
                    <!-- BEGIN: Search -->
                    <div class="intro-x relative  mr-3 sm:mr-6">
                    </div>
                </div>
                <!-- END: Top Bar -->
                <div class="intro-y flex items-center mt-8">

                    <%--start--%>
                    <div class="col-span-12 w-100" style="width:100%">
                        <%--<div class="grid grid-cols-12 gap-6">--%>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upPanel">
                            <ProgressTemplate>
                                <div class="modal_acb">
                                    <div class="center">
                                        <img alt="" src="loader.gif" />
                                    </div>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel ID="upPanel" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                        <div class="intro-y box p-5 mt-12 sm:mt-5">
                            
                            <div class="grid grid-cols-12 gap-5 mt-3">
                                <div class="input-group col-span-4">
                                            <div class="input-group-text">PRN</div>
                                            <asp:TextBox ID="txtPRN" CssClass="form-control col-span-6" runat="server" placeholder="" aria-label="default input inline 1"></asp:TextBox>
                                        </div>

                                        <div class="input-group col-span-4">
                                            <div class="input-group-text">TIN</div>
                                            <asp:TextBox ID="txtTIN" CssClass="form-control col-span-6" runat="server" placeholder="" aria-label="default input inline 1"></asp:TextBox>
                                        </div>
                                        <asp:DropDownList ID="drpPaymentType" runat="server" CssClass="form-control col-span-4">
                                            <asp:ListItem Value="-1" Text="Select Payment" Selected="True" />
                                            <asp:ListItem Value="CASH" Text="Cash" />
                                            <asp:ListItem Value="Cheque" Text="Cheque" />
                                        </asp:DropDownList>
                                       <div class="input-group col-span-6 ">
                                            <div class="input-group-text">Name</div>
                                            <asp:TextBox ID="txtName" CssClass="form-control col-span-6" runat="server" placeholder="" aria-label="default input inline 1"></asp:TextBox>
                                        </div>

                                        <div class="input-group col-span-4 ">

                                            <div class="input-group-text">Ac/No</div>
                                            <asp:TextBox ID="txtAccttoDebit" CssClass="form-control col-span-6" runat="server" placeholder="" aria-label="default input inline 1"></asp:TextBox>
                                        </div>

                                        <div class="col-span-2 w-full">
                                            <asp:LinkButton ID="btnValidate" CssClass="btn btn-primary col-span-12" runat="server" OnClick="btnValidate_Click">Fetch Data</asp:LinkButton>
                                        </div>
                                        <div class="col-span-12" style="width: 100%">

                                            <asp:Panel ID="pnlNRADATA" runat="server" Visible="false">
                                                <asp:GridView ID="gvPaymentDet" HeaderStyle-BackColor="#f0f5f8" CssClass="table table-report input-group" Width="100%" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:BoundField ControlStyle-CssClass="intro-x" DataField="documentReference" HeaderText="Doc Ref."></asp:BoundField>
                                                        <asp:BoundField ControlStyle-CssClass="intro-x" DataField="taxType" HeaderText="Tax Type"></asp:BoundField>
                                                        <asp:BoundField ControlStyle-CssClass="intro-x" DataField="documentType" HeaderText="Doc Type"></asp:BoundField>
                                                        <asp:BoundField ControlStyle-CssClass="intro-x" DataField="taxPeriod" HeaderText="Tax Period"></asp:BoundField>
                                                        <asp:BoundField ControlStyle-CssClass="intro-x" DataFormatString="{0:N2}" DataField="allottedAmount" HeaderText="Amount" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                            <hr style="width: 100%" />
                                        </div>
                                       <%--<div class="col-span-2">

                                      </div>
                                        <div class="col-span-8">--%>
                                        <asp:LinkButton ID="btnReset" CssClass="btn btn-outline-danger btn-block" OnClick="btnReset_Click" runat="server">Reset</asp:LinkButton>
                                          
                                        <asp:LinkButton ID="btnPaytax" CssClass="btn btn-primary btn-block" OnClick="btnPaytax_Click" runat="server">Submit</asp:LinkButton>
                                    <%-- </div>--%>
                                   <%-- <div class="col-span-2">--%>
                                       <%-- <asp:LinkButton ID="btnReceipt" CssClass="btn btn-success col-span-3" runat="server" Text="Print Receipt" OnClick="btnReceipt_Click"></asp:LinkButton>--%>
                                   <%-- </div>--%>
                                   
                            
                                   </div>
                                     
                         </div>
                                     </ContentTemplate>
                            </asp:UpdatePanel>
                        <%-- </div>--%>
                        <div class="col-span-12 ">
                            <div class="grid grid-cols-12 gap-6">
                                <!-- BEGIN: General Report -->
                                <div class="col-span-12 mt-8">
                                    <div class="intro-y flex items-center h-10">
                                        <h2 class="text-lg font-medium truncate mr-5">General Report
                                        </h2>
                                        <%-- <a href="" class="ml-auto flex items-center text-theme-1 dark:text-theme-10">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-refresh-ccw w-4 h-4 mr-3">
                                            <polyline points="1 4 1 10 7 10"></polyline><polyline points="23 20 23 14 17 14"></polyline><path d="M20.49 9A9 9 0 0 0 5.64 5.64L1 10m22 4l-4.64 4.36A9 9 0 0 1 3.51 15"></path></svg>
                                        Reload Data </a>--%>
                                    </div>
                                </div>
                                <!-- END: General Report -->
                                <!-- BEGIN: Sales Report -->
                                <div class="col-span-12 ">
                                    <div class="intro-y block sm:flex items-center h-10">
                                        <div class="search  sm:block">
                                            <div class="text-center h-12">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-calendar w-4 h-4 z-10 absolute my-auto inset-y-0 ml-3 left-0">
                                                    <rect x="3" y="4" width="18" height="18" rx="2" ry="2"></rect><line x1="16" y1="2" x2="16" y2="6"></line><line x1="8" y1="2" x2="8" y2="6"></line><line x1="3" y1="10" x2="21" y2="10"></line></svg>
                                                <%--<a runat="server" ID="txtsearch"  >--%>
                                                <asp:TextBox runat="server" ID="txtsearch" class="datepicker form-control sm:w-56 box pl-10" runat="server" />
                                                <asp:LinkButton runat="server" OnClick="search" OnClientClick="searchs(this)" class="btn btn-primary ">Search <span id="spin" ><i data-loading-icon="three-dots" data-color="white" class="w-4 h-4 ml-2"></i></span> </asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="sm:ml-auto mt-3 sm:mt-0 relative text-gray-700 dark:text-gray-300">
                                            <%-- <a href="javascript:;" data-toggle="modal" data-target="#header-footer-slide-over-preview" class="btn btn-primary w-40 mr-2 mb-2">
                                            <i data-feather="plus" class="w-4 h-4 mr-2"></i>New Payment
                                        </a>--%>

                                            <%--  <div class="text-center">
                                            <a href="javascript:;" data-toggle="modal" data-target="#static-backdrop-modal-preview" class="btn btn-primary">New Payment</a>
                                        </div>--%>
                                        </div>
                                    </div>

                                    <div class="intro-y box p-5 mt-12 sm:mt-5">
                                        <div class="flex flex-col xl:flex-row xl:items-center">
                                        </div>
                                        <div style="width: 988px" class="z-50 "></div>
                                        <hr />
                                        <script src="https://code.highcharts.com/highcharts.js"></script>

                                        <div>
                                            <%--start table--%>
                                            <%--<div class="grid grid-cols-12 gap-6 mt-5">--%>

                                            <%--<a id="showModal" href="javascript:;" data-toggle="modal" data-target="#header-footer-slide-over-preview">--%>

                                            <%--<a id="showModal" style="overflow-y:scroll;background-color:blueviolet"  data-toggle="modal" data-target="#header-footer-slide-over-preview"  >--%>

                                            <asp:UpdatePanel ID="tb_UpdatePanel"
                                                runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView AllowPaging="true" PageSize="100"
                                                        OnPageIndexChanging="grdData_PageIndexChanging"
                                                        ID="gv_trans" HeaderStyle-BackColor="#f0f5f8"
                                                        CssClass="table table-report -mt-2" runat="server"
                                                        AutoGenerateColumns="False"
                                                        OnRowDataBound="RowDataBound"
                                                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

                                                        <%--OnRowDataBound="RowDataBound"--%>
                                                        <%--                                             OnSelectedIndexChanged="GridView1_SelectedIndexChanged"--%>
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="DateOfPayment" HeaderText="Date Of Payment" SortExpression="DateOfPayment"></asp:BoundField>
                                                            <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="ReceiptNumber" HeaderText="Receipt Number" SortExpression="ReceiptNumber"></asp:BoundField>
                                                            <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="Prn" HeaderText="PRN" SortExpression="Prn"></asp:BoundField>
                                                            <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="TransStatus" HeaderText="Status" SortExpression="TransStatus"></asp:BoundField>
                                                            <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="PaymentAmount" HeaderText="Amount" SortExpression="PaymentAmount"></asp:BoundField>
                                                            <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="Tin" HeaderText="Tin" SortExpression="Tin"></asp:BoundField>

                                                            <asp:TemplateField ItemStyle-Width="5%" HeaderText="Details" SortExpression="Details">

                                                                <ItemTemplate>

                                                                    <asp:LinkButton runat="server" ID="showModal" data-toggle="modal" data-target="#header-footer-slide-over-preview">
                                                     <i data-feather="align-justify" class="w-8 h-8 text-gray-500"></i></asp:LinkButton>

                                                                    <%--Text='<% Bind("FirstName") %>'></asp:Label>--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Black"></SelectedRowStyle>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <!-- END: Data List -->
                                    </div>
                                </div>
                            </div>
                            <!-- END: Weekly Top Products -->
                        </div>
                    </div>

                    <asp:Panel ID="plTransDetailView" runat="server" Height="24em" CssClass="card-body vv">
                        <asp:DetailsView ID="dvTransDetails" CssClass="table table-striped table-bordered table-hover h-75" runat="server" AutoGenerateRows="true">
                            <Fields>
                            </Fields>
                        </asp:DetailsView>
                    </asp:Panel>

                    <!-- END: Slide Over Toggle -->
                    <!-- BEGIN: Slide Over Content -->
                    <div id="header-footer-slide-over-preview" class="modal modal-slide-over" data-backdrop="static" tabindex="-1" aria-hidden="true">
                        <div class="modal-dialog">
                           <div class="modal-content">
                                <%--<a data-dismiss="modal" href="javascript:;"><i data-feather="x" class="w-8 h-8 text-gray-500"></i></a>--%>
                                <!-- BEGIN: Slide Over Header -->
                                <div class="modal-header">
                                    <h2 class="font-medium text-base mr-auto">Record Details</h2>

                                    <asp:LinkButton OnClick="Recipts" runat="server" class="btn btn-outline-secondary w-24 p-1">
                                       <i data-feather="print" class="w-4 h-4 mr-2"></i> Print Receipt
                                    </asp:LinkButton>

                                    <%-- <div class="dropdown sm:hidden"><a class="dropdown-toggle w-5 h-5 block" href="javascript:;" aria-expanded="false"><i data-feather="more-horizontal" class="w-5 h-5 text-gray-600 dark:text-gray-600"></i></a>
                                <div class="dropdown-menu w-40">
                                    <div class="dropdown-menu__content box dark:bg-dark-1 p-2"><a href="javascript:;" class="flex items-center p-2 transition duration-300 ease-in-out bg-white dark:bg-dark-1 hover:bg-gray-200 dark:hover:bg-dark-2 rounded-md"><i data-feather="file" class="w-4 h-4 mr-2"></i>Download Docs </a></div>
                                </div>
                            </div>--%>
                                </div>
                                <!-- END: Slide Over Header -->
                                <!-- BEGIN: Slide Over Body -->
                                <div class="modal-body">
                                    <asp:UpdatePanel ID="UpdatePanel"
                                        runat="server">
                                        <ContentTemplate>
                                            <asp:DetailsView ID="DetailsView" CssClass="table table-striped table-bordered table-hover h-75" runat="server" AutoGenerateRows="true">
                                                <Fields>
                                                </Fields>
                                            </asp:DetailsView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <!-- END: Slide Over Body -->
                                <!-- BEGIN: Slide Over Footer -->
                                <div class="modal-footer text-right w-full absolute bottom-0">
                                    <%--<asp:Button runat="server" Text="Cancel" OnClick="refresh" CssClass="btn btn-outline-secondary w-20 mr-1"></asp:Button>--%>

                                    <asp:LinkButton OnClick="Reciptss" runat="server" class="btn btn-outline-secondary w-24 p-1">
                                           Cancel
                                    </asp:LinkButton>
                                    <%--<button type="button" data-dismiss="modal" class="btn btn-outline-secondary w-20 mr-1">Cancel</button>--%>
                                    <%--<button type="button" class="btn btn-primary w-20">Send</button>--%>
                                </div>
                                <!-- END: Slide Over Footer -->
                           </div>
                        </div>
                    </div>
                    <!-- END: Slide Over Content -->
                </div>
               
                <!-- END: Weekly Top Products -->
            </div>
        </div>
        <%--end--%>

        <%--  <asp:Panel ID="plTransDetailView" runat="server" Height="24em" CssClass="card-body vv">
                        <asp:DetailsView ID="dvTransDetails" CssClass="table table-striped table-bordered table-hover h-75" runat="server" AutoGenerateRows="true">
                            <Fields>
                            </Fields>
                        </asp:DetailsView>
                    </asp:Panel>--%>

        <!-- END: Content -->
        </div>
        </div>
    </form>
    <!-- BEGIN: JS Assets-->
    <script src="Asset/js/markerclusterer-markerclusterer.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBG7gNHAhDzgYmq4-EHvM4bqW1DNj2UCuk&amp;libraries=places"></script>
    <script src="Asset/js/js-app.js"></script>
    <!-- END: JS Assets-->

    <script>
        function searchs() {
            var s = document.getElementById("spin")
            s.style.display = 'block'
            //.style.color = clr;
        }
    </script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>
</body>
</html>