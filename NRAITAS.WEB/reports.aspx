<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="NRA_ITAS.reports" %>

<!DOCTYPE html>
<html lang="en" class="light">
<!-- BEGIN: Head -->
<head>
    <meta charset="utf-8">
    <link href="Asset/images/uba.png" rel="shortcut icon">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Reports - iTAS</title>
    <!-- BEGIN: CSS Assets-->
    <link rel="stylesheet" href="Asset/css/css-app.css">
    <!-- END: CSS Assets-->
    <style>
                   .main {
    background-repeat: no-repeat;
    background-attachment: fixed;
    padding-top: 1.25rem;
    background: #d42d11;
    padding-bottom: 1.25rem;
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
                <a href="rubick.left4code.html" class="intro-x flex items-center pl-5 pt-4">
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
                    <li>
                        <a href="reports.aspx" class="side-menu side-menu--active">
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
                    <div class="-intro-x breadcrumb mr-auto hidden sm:flex"><a href="rubick.left4code.html"></a> <i data-feather="chevron-right" class="breadcrumb__icon"></i><a href="rubick.left4code.html" class="breadcrumb--active"></a> </div>
                    <!-- END: Breadcrumb -->
                    <!-- BEGIN: Search -->
                    <div class="intro-x relative mr-3 sm:mr-6">
                        <div class="search hidden sm:block">
                            <%--<input type="text" class="search__input form-control border-transparent placeholder-theme-13" placeholder="Search...">--%>
                            <%--<i data-feather="search" class="search__icon dark:text-gray-300"></i>--%>
                        </div>
                        <a class="notification sm:hidden" href="rubick.left4code.html"><i data-feather="search" class="notification__icon dark:text-gray-300"></i></a>
                        <div class="search-result">
                            <div class="search-result__content">
                                <div class="search-result__content__title">Pages</div>
                                <div class="mb-5">
                                    <a href="rubick.left4code.html" class="flex items-center">
                                        <div class="w-8 h-8 bg-theme-18 text-theme-9 flex items-center justify-center rounded-full"><i class="w-4 h-4" data-feather="inbox"></i></div>
                                        <div class="ml-3">Mail Settings</div>
                                    </a>
                                    <a href="rubick.left4code.html" class="flex items-center mt-2">
                                        <div class="w-8 h-8 bg-theme-17 text-theme-11 flex items-center justify-center rounded-full"><i class="w-4 h-4" data-feather="users"></i></div>
                                        <div class="ml-3">Users &amp; Permissions</div>
                                    </a>
                                    <a href="rubick.left4code.html" class="flex items-center mt-2">
                                        <div class="w-8 h-8 bg-theme-14 text-theme-10 flex items-center justify-center rounded-full"><i class="w-4 h-4" data-feather="credit-card"></i></div>
                                        <div class="ml-3">Transactions Report</div>
                                    </a>
                                </div>
                                <div class="search-result__content__title">Users</div>
                                <div class="mb-5">
                                    <a href="rubick.left4code.html" class="flex items-center mt-2">
                                        <div class="w-8 h-8 image-fit">
                                            <img alt="" class="rounded-full" src="Asset/images/images-profile-15.jpg">
                                        </div>
                                        <div class="ml-3">Angelina Jolie</div>
                                        <div class="ml-auto w-48 truncate text-gray-600 text-xs text-right">angelinajolie@left4code.com</div>
                                    </a>
                                    <a href="rubick.left4code.html" class="flex items-center mt-2">
                                        <div class="w-8 h-8 image-fit">
                                            <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-profile-10.jpg">
                                        </div>
                                        <div class="ml-3">Al Pacino</div>
                                        <div class="ml-auto w-48 truncate text-gray-600 text-xs text-right">alpacino@left4code.com</div>
                                    </a>
                                    <a href="rubick.left4code.html" class="flex items-center mt-2">
                                        <div class="w-8 h-8 image-fit">
                                            <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-profile-14.jpg">
                                        </div>
                                        <div class="ml-3">Kate Winslet</div>
                                        <div class="ml-auto w-48 truncate text-gray-600 text-xs text-right">katewinslet@left4code.com</div>
                                    </a>
                                    <a href="rubick.left4code.html" class="flex items-center mt-2">
                                        <div class="w-8 h-8 image-fit">
                                            <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-profile-1.jpg">
                                        </div>
                                        <div class="ml-3">Robert De Niro</div>
                                        <div class="ml-auto w-48 truncate text-gray-600 text-xs text-right">robertdeniro@left4code.com</div>
                                    </a>
                                </div>
                                <div class="search-result__content__title">Products</div>
                                <a href="rubick.left4code.html" class="flex items-center mt-2">
                                    <div class="w-8 h-8 image-fit">
                                        <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-preview-4.jpg">
                                    </div>
                                    <div class="ml-3">Sony Master Series A9G</div>
                                    <div class="ml-auto w-48 truncate text-gray-600 text-xs text-right">Electronic</div>
                                </a>
                                <a href="rubick.left4code.html" class="flex items-center mt-2">
                                    <div class="w-8 h-8 image-fit">
                                        <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-preview-14.jpg">
                                    </div>
                                    <div class="ml-3">Nike Air Max 270</div>
                                    <div class="ml-auto w-48 truncate text-gray-600 text-xs text-right">Sport &amp; Outdoor</div>
                                </a>
                                <a href="rubick.left4code.html" class="flex items-center mt-2">
                                    <div class="w-8 h-8 image-fit">
                                        <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-preview-13.jpg">
                                    </div>
                                    <div class="ml-3">Samsung Q90 QLED TV</div>
                                    <div class="ml-auto w-48 truncate text-gray-600 text-xs text-right">Electronic</div>
                                </a>
                                <a href="rubick.left4code.html" class="flex items-center mt-2">
                                    <div class="w-8 h-8 image-fit">
                                        <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-preview-3.jpg">
                                    </div>
                                    <div class="ml-3">Sony Master Series A9G</div>
                                    <div class="ml-auto w-48 truncate text-gray-600 text-xs text-right">Electronic</div>
                                </a>
                            </div>
                        </div>
                    </div>
                    <!-- END: Search -->
                </div>
                <!-- END: Top Bar -->
                <div class="intro-y flex items-center mt-8">
                    <h2 class="text-lg font-medium mr-auto">UBA iTAS
                    </h2>
                </div>
                <div class="grid grid-cols-12 gap-6 mt-5">
                    <!--Tim Zonoe -->
                    <hr />
                </div>



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
                        <div style="width: 988px" class="z-50 ">Transactions trends</div>
                        <hr />
                        <script src="https://code.highcharts.com/highcharts.js"></script>



                        <div class="mt-3">
                            <label>Filter By</label>
                            <div class="flex flex-col sm:flex-row mt-2">
                                <div class="form-check mr-2">
                                    <%--  <asp:CheckBox ID="chkred" runat="server" AutoPostBack="True"
                            ="checkeds" Style="font-weight: 700" Text="Are you Sub agent ?" />--%>
                                    <asp:RadioButton Checked="true" AutoPostBack="true" OnCheckedChanged="checkeds" ID="dates" runat="server" Text="Date" GroupName="access" />
                                    <asp:RadioButton AutoPostBack="true" OnCheckedChanged="checkeds" ID="prn" CssClass="ml-3" runat="server" Text="PRN" GroupName="access" />
                                    <asp:RadioButton AutoPostBack="true" OnCheckedChanged="checkeds" ID="tin" CssClass="ml-3" runat="server" Text="TIN" GroupName="access" />
                                </div>
                            </div>
                        </div>



                        <div class="modal-content">
                            <!-- BEGIN: Modal Header -->
                            <!-- END: Modal Header -->
                            <!-- BEGIN: Modal Body -->
                            <div class="modal-body grid grid-cols-12 gap-4 gap-y-3" style="display: flex; flex-wrap: nowrap; flex-direction: row">
                                <asp:Panel runat="server" ID="search" class="col-span-12 sm:col-span-4">
                                    <label for="modal-datepicker-1" class="form-label">Enter PRN</label>
                                    <asp:TextBox Width="33em" ID="txtsearchnor" runat="server" CssClass="intro-x login__input form-control  border-gray-300 block" placeholder="Search..."></asp:TextBox>
                                </asp:Panel>

                                <div class="row" style="display: flex; flex-wrap: nowrap; justify-content: space-between; align-items: flex-end; width: 100%">
                                    <div class="col-8 " style="display: flex; flex-wrap: nowrap">
                                        <asp:Panel runat="server" ID="enterdate">
                                            <div style="display: flex; flex-wrap: nowrap; flex-direction: row">
                                                <div>
                                                    <label for="txtstart" class="form-label">From</label>
                                                    <div style="display: flex; flex-wrap: nowrap; min-width: 15em">

                                                        

                                                         <asp:DropDownList ID="txtddst" runat="server" CssClass="form-control" Style="max-width: fit-content">
                                                            <asp:ListItem Value="-1" Text="Day"></asp:ListItem>
                                                            <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                                            <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                                            <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                                            <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                                            <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                                            <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                                            <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                                            <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                                            <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                            <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                            <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                            <asp:ListItem Value="13" Text="13"></asp:ListItem>
                                                            <asp:ListItem Value="14" Text="14"></asp:ListItem>
                                                            <asp:ListItem Value="15" Text="15"></asp:ListItem>
                                                            <asp:ListItem Value="16" Text="16"></asp:ListItem>
                                                            <asp:ListItem Value="17" Text="17"></asp:ListItem>
                                                            <asp:ListItem Value="18" Text="18"></asp:ListItem>
                                                            <asp:ListItem Value="19" Text="19"></asp:ListItem>
                                                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                            <asp:ListItem Value="21" Text="21"></asp:ListItem>
                                                            <asp:ListItem Value="22" Text="22"></asp:ListItem>
                                                            <asp:ListItem Value="23" Text="23"></asp:ListItem>
                                                            <asp:ListItem Value="24" Text="24"></asp:ListItem>
                                                            <asp:ListItem Value="25" Text="25"></asp:ListItem>
                                                            <asp:ListItem Value="26" Text="26"></asp:ListItem>
                                                            <asp:ListItem Value="27" Text="27"></asp:ListItem>
                                                            <asp:ListItem Value="28" Text="28"></asp:ListItem>
                                                            <asp:ListItem Value="29" Text="29"></asp:ListItem>
                                                            <asp:ListItem Value="30" Text="30"></asp:ListItem>
                                                            <asp:ListItem Value="31" Text="31"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="txtMMst" runat="server" CssClass="form-control" Style="max-width: fit-content">
                                                            <asp:ListItem Value="-1" Text="Mon"></asp:ListItem>
                                                            <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                                            <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                                            <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                                            <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                                            <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                                            <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                                            <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                                            <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                                            <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                            <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                            <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="txtyyyyst" runat="server" CssClass="form-control" Style="max-width: fit-content">
                                                            <asp:ListItem Value="-1" Text="Year"></asp:ListItem>
                                                            <asp:ListItem Value="2021" Text="2021"></asp:ListItem>
                                                            <asp:ListItem Value="2022" Text="2022"></asp:ListItem>
                                                            <asp:ListItem Value="2023" Text="2023"></asp:ListItem>
                                                            <asp:ListItem Value="2024" Text="2024"></asp:ListItem>
                                                            <asp:ListItem Value="2025" Text="2025"></asp:ListItem>
                                                            <asp:ListItem Value="2026" Text="2026"></asp:ListItem>
                                                            <asp:ListItem Value="2027" Text="2027"></asp:ListItem>
                                                            <asp:ListItem Value="2028" Text="2028"></asp:ListItem>
                                                            <asp:ListItem Value="2029" Text="2029"></asp:ListItem>
                                                            <asp:ListItem Value="2030" Text="2030"></asp:ListItem>
                                                        </asp:DropDownList>

                                                       
                                                    </div>

                                                    <%-- <asp:TextBox runat="server" ID="txtstart" SkinID="modal-datepicker-1" class="datepicker form-control" data-single-mode="true" />--%>
                                                </div>
                                                <div class="col-span-12 sm:col-span-4">
                                                    <label for="txtend" class="form-label">To</label>
                                                    <div style="display: flex; flex-wrap: nowrap; min-width: 13em">
                                                         <asp:DropDownList ID="txtddend" runat="server" CssClass="form-control" Style="max-width: fit-content">
                                                            <asp:ListItem Value="-1" Text="Day"></asp:ListItem>
                                                            <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                                            <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                                            <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                                            <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                                            <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                                            <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                                            <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                                            <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                                            <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                            <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                            <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                            <asp:ListItem Value="13" Text="13"></asp:ListItem>
                                                            <asp:ListItem Value="14" Text="14"></asp:ListItem>
                                                            <asp:ListItem Value="15" Text="15"></asp:ListItem>
                                                            <asp:ListItem Value="16" Text="16"></asp:ListItem>
                                                            <asp:ListItem Value="17" Text="17"></asp:ListItem>
                                                            <asp:ListItem Value="18" Text="18"></asp:ListItem>
                                                            <asp:ListItem Value="19" Text="19"></asp:ListItem>
                                                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                            <asp:ListItem Value="21" Text="21"></asp:ListItem>
                                                            <asp:ListItem Value="22" Text="22"></asp:ListItem>
                                                            <asp:ListItem Value="23" Text="23"></asp:ListItem>
                                                            <asp:ListItem Value="24" Text="24"></asp:ListItem>
                                                            <asp:ListItem Value="25" Text="25"></asp:ListItem>
                                                            <asp:ListItem Value="26" Text="26"></asp:ListItem>
                                                            <asp:ListItem Value="27" Text="27"></asp:ListItem>
                                                            <asp:ListItem Value="28" Text="28"></asp:ListItem>
                                                            <asp:ListItem Value="29" Text="29"></asp:ListItem>
                                                            <asp:ListItem Value="30" Text="30"></asp:ListItem>
                                                            <asp:ListItem Value="31" Text="31"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        
                                                        <asp:DropDownList ID="txtMMend" runat="server" CssClass="form-control" Style="max-width: fit-content">
                                                            <asp:ListItem Value="-1" Text="Mon"></asp:ListItem>
                                                            <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                                            <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                                            <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                                            <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                                            <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                                            <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                                            <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                                            <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                                            <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                            <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                            <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                        </asp:DropDownList>

                                                        <asp:DropDownList ID="txtyyyend" runat="server" CssClass="form-control" Style="max-width: fit-content">
                                                            <asp:ListItem Value="-1" Text="Year"></asp:ListItem>
                                                            <asp:ListItem Value="2021" Text="2021"></asp:ListItem>
                                                            <asp:ListItem Value="2022" Text="2022"></asp:ListItem>
                                                            <asp:ListItem Value="2023" Text="2023"></asp:ListItem>
                                                            <asp:ListItem Value="2024" Text="2024"></asp:ListItem>
                                                            <asp:ListItem Value="2025" Text="2025"></asp:ListItem>
                                                            <asp:ListItem Value="2026" Text="2026"></asp:ListItem>
                                                            <asp:ListItem Value="2027" Text="2027"></asp:ListItem>
                                                            <asp:ListItem Value="2028" Text="2028"></asp:ListItem>
                                                            <asp:ListItem Value="2029" Text="2029"></asp:ListItem>
                                                            <asp:ListItem Value="2030" Text="2030"></asp:ListItem>
                                                        </asp:DropDownList>

                                                       
                                                    </div>

                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div class="modal-footer text-right mt-4">
                                            <%--<button type="button" data-dismiss="modal" class="btn btn-outline-secondary w-20 mr-1">Cancel</button>--%>
                                            <asp:Button runat="server" OnClick="btnsearcher" CommandArgument="data" CssClass="btn btn-primary w-20" Text="Search" />

                                        </div>
                                    </div>
                                    <asp:LinkButton Text="" runat="server" OnClick="btnsearcherexl" CommandArgument="excel" CssClass="col-2 mb-2">
                <asp:Image CssClass="excel" runat="server" Width="3em" Height="3em" ImageUrl="./Asset/excel.jpeg" />
                                    </asp:LinkButton>
                                </div>
                                <!-- END: Modal Footer -->
                            </div>
                        </div>
                        <!-- END: Modal Body -->



                    </div>

                    <div style="overflow-x: scroll">

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
                                         <asp:BoundField ItemStyle-Width="0%" ControlStyle-CssClass="intro-x" DataField="Log_seq" HeaderText="ID" SortExpression="Log_seq"></asp:BoundField>
                                       
                                        <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="Tin" HeaderText="Tin" SortExpression="Tin"></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="Prn" HeaderText="PRN" SortExpression="Prn"></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="DateOfPayment" HeaderText="Date Of Payment" SortExpression="DateOfPayment"></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="ReceiptNumber" HeaderText="Receipt Number" SortExpression="ReceiptNumber"></asp:BoundField>

                                        <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="TransStatus" HeaderText="Status" SortExpression="TransStatus"></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="19%" ControlStyle-CssClass="intro-x" DataField="PaymentAmount" HeaderText="Amount" SortExpression="PaymentAmount"></asp:BoundField>

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

        <!-- BEGIN: Slide Over Content -->
        <div id="header-footer-slide-over-preview" class="modal modal-slide-over" data-backdrop="static" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <%--<div class="modal-header">
                        <h2 class="font-medium text-base mr-auto">Record Details</h2>
                    </div>--%>

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

        <!-- END: Content -->

    </form>
    <!-- BEGIN: JS Assets-->
    <script src="Asset/js/markerclusterer-markerclusterer.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBG7gNHAhDzgYmq4-EHvM4bqW1DNj2UCuk&amp;libraries=places"></script>
    <script src="Asset/js/js-app.js"></script>
    <!-- END: JS Assets-->
</body>
</html>
