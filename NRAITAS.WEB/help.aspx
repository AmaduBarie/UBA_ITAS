<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="help.aspx.cs" Inherits="NRA_ITAS.help" %>

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
                    <a href="transactions.aspx" class="side-menu side-menu--active">
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
                        <a href="reports.aspx" class="side-menu">
                            <div class="side-menu__icon"><i data-feather="file-text"></i></div>
                            <div class="side-menu__title">Reports</div>
                        </a>
                    </li>
                    <li>
                        <a href="help.aspx" class="side-menu side-menu--active">
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
                    <div class="-intro-x breadcrumb mr-auto hidden sm:flex"><a href="rubick.left4code.html">Application</a> <i data-feather="chevron-right" class="breadcrumb__icon"></i><a href="rubick.left4code.html" class="breadcrumb--active">Dashboard</a> </div>
                    <!-- END: Breadcrumb -->
                    <!-- BEGIN: Search -->
                    <div class="intro-x relative mr-3 sm:mr-6">
                        <div class="search hidden sm:block">
                            <input type="text" class="search__input form-control border-transparent placeholder-theme-13" placeholder="Search...">
                            <i data-feather="search" class="search__icon dark:text-gray-300"></i>
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
                                            <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-profile-15.jpg">
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
                    <!-- BEGIN: Notifications -->
                    <%-- <div class="intro-x dropdown mr-auto sm:mr-6">
                        <div class="dropdown-toggle notification notification--bullet cursor-pointer" role="button" aria-expanded="false"> <i data-feather="bell" class="notification__icon dark:text-gray-300"></i> </div>
                        <div class="notification-content pt-2 dropdown-menu">
                            <div class="notification-content__box dropdown-menu__content box dark:bg-dark-6">
                                <div class="notification-content__title">Notifications</div>
                                <div class="cursor-pointer relative flex items-center ">
                                    <div class="w-12 h-12 flex-none image-fit mr-1">
                                        <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-profile-15.jpg">
                                        <div class="w-3 h-3 bg-theme-9 absolute right-0 bottom-0 rounded-full border-2 border-white"></div>
                                    </div>
                                    <div class="ml-2 overflow-hidden">
                                        <div class="flex items-center">
                                            <a href="javascript:;.html" class="font-medium truncate mr-5">Angelina Jolie</a>
                                            <div class="text-xs text-gray-500 ml-auto whitespace-nowrap">05:09 AM</div>
                                        </div>
                                        <div class="w-full truncate text-gray-600 mt-0.5">Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 20</div>
                                    </div>
                                </div>
                                <div class="cursor-pointer relative flex items-center mt-5">
                                    <div class="w-12 h-12 flex-none image-fit mr-1">
                                        <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-profile-10.jpg">
                                        <div class="w-3 h-3 bg-theme-9 absolute right-0 bottom-0 rounded-full border-2 border-white"></div>
                                    </div>
                                    <div class="ml-2 overflow-hidden">
                                        <div class="flex items-center">
                                            <a href="javascript:;.html" class="font-medium truncate mr-5">Al Pacino</a>
                                            <div class="text-xs text-gray-500 ml-auto whitespace-nowrap">05:09 AM</div>
                                        </div>
                                        <div class="w-full truncate text-gray-600 mt-0.5">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomi</div>
                                    </div>
                                </div>
                                <div class="cursor-pointer relative flex items-center mt-5">
                                    <div class="w-12 h-12 flex-none image-fit mr-1">
                                        <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-profile-14.jpg">
                                        <div class="w-3 h-3 bg-theme-9 absolute right-0 bottom-0 rounded-full border-2 border-white"></div>
                                    </div>
                                    <div class="ml-2 overflow-hidden">
                                        <div class="flex items-center">
                                            <a href="javascript:;.html" class="font-medium truncate mr-5">Kate Winslet</a>
                                            <div class="text-xs text-gray-500 ml-auto whitespace-nowrap">05:09 AM</div>
                                        </div>
                                        <div class="w-full truncate text-gray-600 mt-0.5">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500</div>
                                    </div>
                                </div>
                                <div class="cursor-pointer relative flex items-center mt-5">
                                    <div class="w-12 h-12 flex-none image-fit mr-1">
                                        <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-profile-1.jpg">
                                        <div class="w-3 h-3 bg-theme-9 absolute right-0 bottom-0 rounded-full border-2 border-white"></div>
                                    </div>
                                    <div class="ml-2 overflow-hidden">
                                        <div class="flex items-center">
                                            <a href="javascript:;.html" class="font-medium truncate mr-5">Robert De Niro</a>
                                            <div class="text-xs text-gray-500 ml-auto whitespace-nowrap">01:10 PM</div>
                                        </div>
                                        <div class="w-full truncate text-gray-600 mt-0.5">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomi</div>
                                    </div>
                                </div>
                                <div class="cursor-pointer relative flex items-center mt-5">
                                    <div class="w-12 h-12 flex-none image-fit mr-1">
                                        <img alt="Rubick Tailwind HTML Admin Template" class="rounded-full" src="images/images-profile-2.jpg">
                                        <div class="w-3 h-3 bg-theme-9 absolute right-0 bottom-0 rounded-full border-2 border-white"></div>
                                    </div>
                                    <div class="ml-2 overflow-hidden">
                                        <div class="flex items-center">
                                            <a href="javascript:;.html" class="font-medium truncate mr-5">Al Pacino</a>
                                            <div class="text-xs text-gray-500 ml-auto whitespace-nowrap">06:05 AM</div>
                                        </div>
                                        <div class="w-full truncate text-gray-600 mt-0.5">Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 20</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <!-- END: Notifications -->
                    <!-- BEGIN: Account Menu -->
                    <%-- <div class="intro-x dropdown w-8 h-8">
                        <div class="dropdown-toggle w-8 h-8 rounded-full overflow-hidden shadow-lg image-fit zoom-in" role="button" aria-expanded="false">
                            <img alt="Rubick Tailwind HTML Admin Template" src="images/images-profile-13.jpg">
                        </div>
                        <div class="dropdown-menu w-56">
                            <div class="dropdown-menu__content box tzbg dark:bg-dark-6">
                                <div class="p-4 border-b border-theme-27 dark:border-dark-3">
                                    <div class="font-medium">Angelina Jolie</div>
                                    <div class="text-xs text-theme-28 mt-0.5 dark:text-gray-600">Frontend Engineer</div>
                                </div>
                                <div class="p-2">
                                    <a href="rubick.left4code.html" class="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 dark:hover:bg-dark-3 rounded-md"> <i data-feather="user" class="w-4 h-4 mr-2"></i> Profile </a>
                                    <a href="rubick.left4code.html" class="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 dark:hover:bg-dark-3 rounded-md"> <i data-feather="edit" class="w-4 h-4 mr-2"></i> Add Account </a>
                                    <a href="rubick.left4code.html" class="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 dark:hover:bg-dark-3 rounded-md"> <i data-feather="lock" class="w-4 h-4 mr-2"></i> Reset Password </a>
                                    <a href="rubick.left4code.html" class="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 dark:hover:bg-dark-3 rounded-md"> <i data-feather="help-circle" class="w-4 h-4 mr-2"></i> Help </a>
                                </div>
                                <div class="p-2 border-t border-theme-27 dark:border-dark-3">
                                    <a href="rubick.left4code.html" class="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 dark:hover:bg-dark-3 rounded-md"> <i data-feather="toggle-right" class="w-4 h-4 mr-2"></i> Logout </a>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <!-- END: Account Menu -->
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
                <%--<footer>
                    <p>&copy; <%: DateTime.Now.Year %> - My ASP.NET Application</p>
                </footer>--%>
            </div>

            <!-- END: Content -->
        </div>
    </form>
    <!-- BEGIN: JS Assets-->
    <script src="Asset/js/markerclusterer-markerclusterer.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBG7gNHAhDzgYmq4-EHvM4bqW1DNj2UCuk&amp;libraries=places"></script>
    <script src="Asset/js/js-app.js"></script>
    <!-- END: JS Assets-->
</body>
</html>