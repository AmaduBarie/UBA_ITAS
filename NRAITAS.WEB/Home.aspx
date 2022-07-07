<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NRA_ITAS.Home" %>

<!DOCTYPE html>

<html lang="en" class="light">
<!-- BEGIN: Head -->
<head>
    <meta charset="utf-8">
    <link href="Asset/images/uba.png" rel="shortcut icon">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Home - iTAS</title>
    <!-- BEGIN: CSS Assets-->
    <link rel="stylesheet" href="Asset/css/css-app.css">
    <!-- END: CSS Assets-->
    <style>

.highcharts-credits{

display:none;

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
                <a href="Home.aspx" class="flex mr-auto">
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
                <asp:Panel ID="pnlTeller" runat="server" Visible="false">
                    <li>
                    <a href="transactions.aspx" class="menu">
                        <div class="menu__icon"><i data-feather="sidebar"></i></div>
                        <div class="menu__title">Transactions</div>
                    </a>
                </li>
                </asp:Panel>
                <asp:Panel ID="pnlAudit" runat="server" Visible="false">
                 <li>
                    <a href="Admins.aspx" class="menu">
                        <div class="menu__icon"><i data-feather="user-check"></i></div>
                        <div class="menu__title">Admin</div>
                    </a>
                </li>
                </asp:Panel>
                 <asp:Panel ID="pnlApproval" runat="server" Visible="false">
                 <li>
                    <a href="Approval.aspx" class="menu">
                        <div class="menu__icon"><i data-feather="user-check"></i></div>
                        <div class="menu__title">Approval</div>
                    </a>
                </li>
                </asp:Panel>
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
                        <a href="Home.aspx" class="side-menu side-menu--active">
                            <div class="side-menu__icon"><i data-feather="home"></i></div>
                            <div class="side-menu__title">Home</div>
                        </a>
                    </li>
                     <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <li>
                    <a href="transactions.aspx" class="side-menu">
                        <div class="side-menu__icon"><i data-feather="sidebar"></i></div>
                        <div class="side-menu__title">Transactions</div>
                    </a>
                </li>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" Visible="false">
                 <li>
                    <a href="Admins.aspx" class="side-menu">
                        <div class="side-menu__icon"><i data-feather="user-check"></i></div>
                        <div class="side-menu__title">Admin</div>
                    </a>
                </li>
                </asp:Panel>
                 <asp:Panel ID="Panel3" runat="server" Visible="false">
                 <li>
                    <a href="Approval.aspx" class="side-menu">
                        <div class="side-menu__icon"><i data-feather="user-check"></i></div>
                        <div class="side-menu__title">Approval</div>
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
                        <a href="help.aspx" class="side-menu">
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
            <div class="content">
                <!-- BEGIN: Top Bar -->
                <div class="top-bar">
                    <!-- BEGIN: Breadcrumb -->
                    <div class="-intro-x breadcrumb mr-auto  sm:flex"><a href="rubick.left4code.html"></a><i data-feather="chevron-right" class="breadcrumb__icon"></i><a href="rubick.left4code.html" class="breadcrumb--active"></a></div>
                    <!-- END: Breadcrumb -->
                    <!-- BEGIN: Search -->
                    <div class="intro-x relative  mr-3 sm:mr-6">

                        <div class="search-result">
                          <!--OK-->
                        </div>
                    </div>
                </div>
                <!-- END: Top Bar -->
                <div class="intro-y flex items-center mt-8">

                    <%--start--%>
                    <div class="col-span-12 w-100 " style="width:100%">
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
                                <div class="grid grid-cols-12 gap-6 mt-5">
                                    <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                                        <div class="report-box zoom-in">
                                            <div class="box p-5">
                                                <div class="flex">
                                                    <i data-feather="thumbs-up" class="w-8 h-6 text-gray-500"></i>
                                                    <div class="ml-auto">
                                                        <div class="report-box__indicator bg-theme-9 tooltip cursor-pointer">
                                                           <%=sucp.ToString()%>%
                                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevron-up w-4 h-4 ml-0.5">
                                                                <polyline points="18 15 12 9 6 15"></polyline></svg>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="text-3xl font-medium leading-8 mt-6"> <%=suc.ToString() %></div>
                                                <div class="text-base text-gray-600 mt-1">Successful Transactions</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                                        <div class="report-box zoom-in">
                                            <div class="box p-5">
                                                <div class="flex">
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-credit-card report-box__icon text-theme-11">
                                                        <rect x="1" y="4" width="22" height="16" rx="2" ry="2"></rect><line x1="1" y1="10" x2="23" y2="10"></line></svg>
                                                    <div class="ml-auto">
                                                        <div class="report-box__indicator bg-theme-6 tooltip cursor-pointer">
                                                            <%=faip%>%
                                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevron-down w-4 h-4 ml-0.5">
                                                                <polyline points="6 9 12 15 18 9"></polyline></svg>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="text-3xl font-medium leading-8 mt-6"><%=fai%></div>
                                                <div class="text-base text-gray-600 mt-1">Failed Transactions</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                                        <div class="report-box zoom-in">
                                            <div class="box p-5">
                                                <div class="flex">
                                                   <%-- <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-monitor report-box__icon text-theme-12">
                                                        <rect x="2" y="3" width="20" height="14" rx="2" ry="2"></rect><line x1="8" y1="21" x2="16" y2="21"></line><line x1="12" y1="17" x2="12" y2="21"></line></svg>
                                                   --%>
                                                    
                                                     <%--<i data-feather="" class="w-8 h-6 text-gray-500">Le</i>--%>
                                                    <span class="w-12 h-10 text-gray-500">LE</span>
                                                     
                                                    <div class="ml-auto">
                                                        <div class="report-box__indicator bg-theme-9 tooltip cursor-pointer">
                                                           <%=casp%>%
                                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevron-up w-4 h-4 ml-0.5">
                                                                <polyline points="18 15 12 9 6 15"></polyline></svg>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="text-3xl font-medium leading-8 mt-6"><%=cas%></div>
                                                <div class="text-base text-gray-600 mt-1">Cash Transactions</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                                        <div class="report-box zoom-in">
                                            <div class="box p-5">
                                                <div class="flex">
                                                   <%-- <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-user report-box__icon text-theme-9">
                                                        --%<%--><path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"></path><circle cx="12" cy="7" r="4"></circle></svg>--%>
                                                    <i data-feather="clipboard" class="w-8 h-6 text-gray-500"></i>
                                                    <div class="ml-auto">
                                                        <div class="report-box__indicator bg-theme-9 tooltip cursor-pointer">
                                                           <%=chep%>%
                                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevron-up w-4 h-4 ml-0.5">
                                                                <polyline points="18 15 12 9 6 15"></polyline></svg>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="text-3xl font-medium leading-8 mt-6"><%=che%></div>
                                                <div class="text-base text-gray-600 mt-1">Cheque Transactions</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- END: General Report -->
                            <!-- BEGIN: Sales Report -->
                            <div class="col-span-12 ">
                               <%-- <div class="intro-y block sm:flex items-center h-10">
                                    <div class="search  sm:block">
                                        <div class="text-center h-12">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-calendar w-4 h-4 z-10 absolute my-auto inset-y-0 ml-3 left-0">
                                                <rect x="3" y="4" width="18" height="18" rx="2" ry="2"></rect><line x1="16" y1="2" x2="16" y2="6"></line><line x1="8" y1="2" x2="8" y2="6"></line><line x1="3" y1="10" x2="21" y2="10"></line></svg>
                                            <input type="text" class="datepicker form-control sm:w-56 box pl-10">
                                        </div>
                                    </div>
                                    <div class="sm:ml-auto mt-3 sm:mt-0 relative text-gray-700 dark:text-gray-300">
 

                                        <div class="text-center">
                                            <a href="javascript:;" data-toggle="modal" data-target="#static-backdrop-modal-preview" class="btn btn-primary">New Payment</a>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="intro-y box p-5 mt-12 sm:mt-5">
                                    <div class="flex flex-col xl:flex-row xl:items-center">
                                    </div>
                                    <div style="width: 988px" class="z-50 ">Transactions trends showing for the entire bank system</div>
                                    <hr />
                                    <script src="https://code.highcharts.com/highcharts.js"></script>

                                    <figure class="highcharts-figure">
                                        <div id="container"></div>
                                        <%--  <p class="highcharts-description">
                                            Chart showing browser market shares. Clicking on individual columns
                                            brings up more detailed data. This chart makes use of the drilldown
                                            feature in Highcharts to easily switch between datasets.
                                        </p>--%>
                                    </figure>
                                     <div style="width: 988px" class="z-50 ">Your top few transactions</div>
                                    <hr />
                                    <div style="overflow-x: scroll">
                                        <%--start table--%>
                                        <%--<div class="grid grid-cols-12 gap-6 mt-5">--%>

                                        <asp:GridView HeaderStyle-BackColor="#f0f5f8" CssClass="table table-report -mt-2" runat="server" AutoGenerateColumns="False" ID="nratranss">
                                            <Columns>
                                                <asp:BoundField ControlStyle-CssClass="intro-x" DataField="Tin" HeaderText="Tin" SortExpression="Tin"></asp:BoundField>
                                                <asp:BoundField ControlStyle-CssClass="intro-x" DataField="DateOfPayment" HeaderText="Date Of Payment" SortExpression="DateOfPayment"></asp:BoundField>
                                                <asp:BoundField ControlStyle-CssClass="intro-x" DataField="ReceiptNumber" HeaderText="Receipt Number" SortExpression="ReceiptNumber"></asp:BoundField>
                                                <asp:BoundField ControlStyle-CssClass="intro-x" DataField="Prn" HeaderText="PRN" SortExpression="Prn"></asp:BoundField>
                                                <asp:BoundField ControlStyle-CssClass="intro-x" DataField="TransStatus" HeaderText="Status" SortExpression="TransStatus"></asp:BoundField>
                                                <asp:BoundField ControlStyle-CssClass="intro-x" DataField="PaymentAmount" HeaderText="Amount" SortExpression="PaymentAmount"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                        <%--<asp:SqlDataSource runat="server" ID="nratrans" ConnectionString='<%$ ConnectionStrings:ITAS_DBConnectionString %>' SelectCommand="top100" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
                                    </div>
                                    <!-- END: Data List -->
                                    <!-- BEGIN: Pagination -->
                                    <div class="intro-y col-span-12 flex flex-wrap sm:flex-row sm:flex-nowrap items-center">
                                        <ul class="pagination">
                                            <li>
                                                <a class="pagination__link" href="">
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevrons-left w-4 h-4">
                                                        <polyline points="11 17 6 12 11 7"></polyline><polyline points="18 17 13 12 18 7"></polyline></svg>
                                                </a>
                                            </li>
                                            <li>
                                                <a class="pagination__link" href="">
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevron-left w-4 h-4">
                                                        <polyline points="15 18 9 12 15 6"></polyline></svg>
                                                </a>
                                            </li>
                                            <li><a class="pagination__link" href="">...</a> </li>
                                            <li><a class="pagination__link" href="">1</a> </li>
                                            <li><a class="pagination__link pagination__link--active" href="">2</a> </li>
                                            <li><a class="pagination__link" href="">3</a> </li>
                                            <li><a class="pagination__link" href="">...</a> </li>
                                            <li>
                                                <a class="pagination__link" href="">
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevron-right w-4 h-4">
                                                        <polyline points="9 18 15 12 9 6"></polyline></svg>
                                                </a>
                                            </li>
                                            <li>
                                                <a class="pagination__link" href="">
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-chevrons-right w-4 h-4">
                                                        <polyline points="13 17 18 12 13 7"></polyline><polyline points="6 17 11 12 6 7"></polyline></svg>
                                                </a>
                                            </li>
                                        </ul>
                                        <select class="w-20 form-select box mt-3 sm:mt-0">
                                            <option>10</option>
                                            <option>25</option>
                                            <option>35</option>
                                            <option>50</option>
                                        </select>
                                    </div>
                                    <!-- END: Pagination -->
                                </div>
                                <%--end of table--%>
                            </div>
                        </div>
                    </div>

                    <!-- END: Weekly Top Products -->
                </div>
            </div>
            <%--end--%>
        </div>
        <div class="grid grid-cols-12 gap-6 mt-5 w-100">
            <!--Tim Zonoe -->
            <!-- BEGIN: Slide Over Toggle -->

            <!-- END: Slide Over Toggle -->
            <!-- BEGIN: Slide Over Content -->
            <div id="header-footer-slide-over-preview" class="modal modal-slide-over" data-backdrop="static" tabindex="-1" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <a data-dismiss="modal" href="javascript:;"><i data-feather="x" class="w-8 h-8 text-gray-500"></i></a>
                        <!-- BEGIN: Slide Over Header -->
                        <div class="modal-header">
                            <h2 class="font-medium text-base mr-auto">NRA ITAS Payment</h2>
                            <button class="btn btn-outline-secondary hidden sm:flex"><i data-feather="file" class="w-4 h-4 mr-2"></i>Download Docs </button>
                            <div class="dropdown sm:hidden">
                                <a class="dropdown-toggle w-5 h-5 block" href="javascript:;" aria-expanded="false"><i data-feather="more-horizontal" class="w-5 h-5 text-gray-600 dark:text-gray-600"></i></a>
                                <div class="dropdown-menu w-40">
                                    <div class="dropdown-menu__content box dark:bg-dark-1 p-2"><a href="javascript:;" class="flex items-center p-2 transition duration-300 ease-in-out bg-white dark:bg-dark-1 hover:bg-gray-200 dark:hover:bg-dark-2 rounded-md"><i data-feather="file" class="w-4 h-4 mr-2"></i>Download Docs </a></div>
                                </div>
                            </div>
                        </div>
                        <!-- END: Slide Over Header -->

                        <!-- BEGIN: Slide Over Body -->
                        <div class="modal-body">
                            <div>
                                <label for="modal-form-1" class="form-label">Name</label>
                                <input id="modal-form-1" type="text" class="form-control" placeholder="Enter full name">
                            </div>
                            <div class="mt-3">
                                <label for="modal-form-2" class="form-label">PRN Number</label>
                                <input id="modal-form-2" type="text" class="form-control" placeholder="Enter PRN Number">
                            </div>
                            <div class="mt-3">
                                <label for="modal-form-3" class="form-label">TIN Number</label>
                                <input id="modal-form-3" type="text" class="form-control" placeholder="Enter TIN Number">
                            </div>
                            <div class="mt-3">
                                <label for="modal-form-4" class="form-label">Amount</label>
                                <input id="modal-form-4" type="text" class="form-control" placeholder="">
                            </div>
                            <div class="mt-3">
                                <label for="modal-form-5" class="form-label">Document Reference</label>
                                <input id="modal-form-5" type="text" class="form-control" placeholder="">
                            </div>
                            <div class="mt-3">
                                <label for="modal-form-3" class="form-label">TAX Type</label>
                                <input id="modal-form-6" type="text" class="form-control" placeholder="">
                            </div>
                            <div class="mt-3">
                                <label for="modal-form-4" class="form-label">Document Type</label>
                                <input id="modal-form-7" type="text" class="form-control" placeholder="">
                            </div>
                            <div class="mt-3">
                                <label for="modal-form-5" class="form-label">TAX Period</label>
                                <input id="modal-form-8" type="text" class="form-control" placeholder="">
                            </div>
                            <%--<div class="mt-3">
               <label for="modal-form-6" class="form-label">Size</label>
               <select id="modal-form-6" class="form-select">
                  <option>10</option>
                  <option>25</option>
                  <option>35</option>
                  <option>50</option>
               </select>
            </div>--%>
                        </div>
                        <!-- END: Slide Over Body -->
                        <!-- BEGIN: Slide Over Footer -->
                        <div class="modal-footer text-right w-full absolute bottom-0">
                            <button type="button" data-dismiss="modal" class="btn btn-outline-secondary w-20 mr-1">Cancel</button>
                            <button type="button" class="btn btn-primary w-20">Next<i data-feather="arrow-right" class="w-4 h-4 mr-2"></i></button>
                        </div>
                        <!-- END: Slide Over Footer -->
                    </div>
                </div>
            </div>
            <hr />
        </div>
        <%--<footer>
                    <p>&copy; <%: DateTime.Now.Year %> - My ASP.NET Application</p>
                </footer>--%>
        <%--  </div>

            <!-- END: Content -->
        </div>--%>

        <!-- END: Modal Toggle -->
        <!-- BEGIN: Modal Content -->
        <div id="static-backdrop-modal-preview" class="modal" data-backdrop="static" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-body px-8 py-5">
                        <h4>Payment Details</h4>
                        <hr /> 
                       <%-- <div class="input-group  mb-3 mt-2">
                            <div   class="input-group-text">Name</div>
                            <input type="text" class="form-control" placeholder="" aria-label="Email" aria-describedby="input-group-email">
                        </div> --%>



                        <div class="grid grid-cols-12 gap-5 mt-3">

                             <div class="input-group    col-span-6 ">
                                <div   class="input-group-text">Name</div>
                                <input type="text" class="form-control col-span-6" placeholder="" aria-label="default input inline 1">
                            </div>

                              <select class="form-control col-span-4" aria-label=".form-select-lg example">
                                <option>Payment Type</option>
                                <option>Cash</option>
                                <option>Cheque</option>
                            </select>
                          <%--  </div>

                                  <div class="grid grid-cols-12 gap-5">--%>
                            <div class="input-group    col-span-6 ">
                                <div   class="input-group-text">PRN</div>
                                <input type="text" class="form-control col-span-6" placeholder="" aria-label="default input inline 1">
                            </div>

                              <div class="input-group    col-span-6 ">
                                <div   class="input-group-text">TIN</div>
                                <input type="text" class="form-control col-span-6" placeholder="" aria-label="default input inline 1">
                            </div>

                            <div class="col-span-12" style="width:100%">
                           <%--  <asp:GridView HeaderStyle-BackColor="#f0f5f8" CssClass="table table-report input-group" Width="100%" runat="server" AutoGenerateColumns="False" ID="nratrans">
                                            <Columns>
                                                <asp:BoundField ControlStyle-CssClass="intro-x" DataField="Tin" HeaderText="Doc Ref." SortExpression="Tin"></asp:BoundField>
                                                <asp:BoundField ControlStyle-CssClass="intro-x" DataField="DateOfPayment" HeaderText="Tax Type" SortExpression="DateOfPayment"></asp:BoundField>
                                                <asp:BoundField ControlStyle-CssClass="intro-x" DataField="ReceiptNumber" HeaderText="Doc Type" SortExpression="ReceiptNumber"></asp:BoundField>
                                                <asp:BoundField ControlStyle-CssClass="intro-x" DataField="Prn" HeaderText="Tax Period" SortExpression="Prn"></asp:BoundField>
                                                 <asp:BoundField ControlStyle-CssClass="intro-x"  DataFormatString = "{0:N2}" DataField="PaymentAmount" HeaderText="Amount" SortExpression="PaymentAmount"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>--%>
                                </div>

                           <%--  <div class="input-group    col-span-6 ">
                                <div   class="input-group-text">Amount</div>
                                <input type="text" class="form-control col-span-6" placeholder="" aria-label="default input inline 1">
                            </div>--%>

                              
                            

                  
                           <%--  <div class="input-group    col-span-6 ">
                                <div   class="input-group-text" style="white-space: nowrap">Document Ref</div>
                                <input type="text" class="form-control col-span-6" placeholder="" aria-label="default input inline 1">
                            </div>

                                 <div class="input-group    col-span-6 ">
                                <div   class="input-group-text" style="white-space: nowrap">Document Type</div>
                                <input type="text" class="form-control col-span-6" placeholder="" aria-label="default input inline 1">
                            </div>

                              <div class="input-group    col-span-6 ">
                                <div   class="input-group-text" style="white-space: nowrap">Tax Period</div>
                                <input type="text" class="form-control col-span-6" placeholder="" aria-label="default input inline 1">
                            </div>

                               <div class="input-group    col-span-6 ">
                                <div   class="input-group-text" style="white-space: nowrap">Tax Type</div>
                                <input type="text" class="form-control col-span-6" placeholder="" aria-label="default input inline 1">
                            </div>--%>

                                  <div  class="col-span-2" ></div>
                            <button data-dismiss="modal" class="btn btn-outline-danger  col-span-4   ">Cancel</button>

                            <button class="btn btn-primary  col-span-4 ">Pay</button> 
                                <div  class="col-span-2" ></div>
                        </div>

                        <div class="mt-2">
                          
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- BEGIN: JS Assets-->
    <script src="Asset/js/markerclusterer-markerclusterer.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBG7gNHAhDzgYmq4-EHvM4bqW1DNj2UCuk&amp;libraries=places"></script>
    <script src="Asset/js/js-app.js"></script>
    <!-- END: JS Assets-->
    <script src="https://code.highcharts.com/modules/data.js"></script>
    <script src="https://code.highcharts.com/modules/drilldown.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script src="https://code.highcharts.com/modules/export-data.js"></script>
    <script src="https://code.highcharts.com/modules/accessibility.js"></script>

    <script>
        // Create the chart
        Highcharts.chart('container', {
            chart: {
                type: 'column'
            },
            title: {
                text: ''
            },
            subtitle: {
                text: ''
            },
            accessibility: {
                announceNewData: {
                    enabled: true
                }
            },
            xAxis: {
                type: 'category'
            },
            yAxis: {
                title: {
                    text: 'Count of request per month'
                }

            },
            legend: {
                enabled: true
            },
            plotOptions: {
                series: {
                    borderWidth: 0,
                    dataLabels: {
                        enabled: true,
                        //format: '{point.y:.1f}%'
                    }
                },
                column: {

                    borderRadius: 3

                }
            },

            tooltip: {
                headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y}</b>  <br />'
            },

            series: [
                {
                    name: "",
                    colorByPoint: false,
                    data: [
                         <%=Session["series"].ToString()%>
                        //{ name:'2020',y:160,drilldown:'2020'},{ name:'2019',y:34,drilldown:'2019'},
                    ]
                }
            ],
            drilldown: {
                series: [
                  <%=Session["drilldown"].ToString()%>
                    //{name:'2020',id:'2020',data:[['Aug 2020', 16],['Jul 2020', 30],['Jun 2020', 22],['May 2020', 19],['Apr 2020', 22],['Mar 2020', 20],['Feb 2020', 17],['Jan 2020', 13],]},{name:'2019',id:'2019',data:[['Nov 2019', 9],['Oct 2019', 2],['Sep 2019', 1],['Jul 2019', 3],['Jun 2019', 2],['May 2019', 3],['Mar 2019', 4],]},{name:'2020',id:'2020',data:[['Aug 2020', 16],['Jul 2020', 30],['Jun 2020', 22],['May 2020', 19],['Apr 2020', 22],['Mar 2020', 20],['Feb 2020', 17],['Jan 2020', 13],]},{name:'2019',id:'2019',data:[['Nov 2019', 9],['Oct 2019', 2],['Sep 2019', 1],['Jul 2019', 3],['Jun 2019', 2],['May 2019', 3],['Mar 2019', 4],"
                ]
            }
        });
    </script>
</body>
</html>