<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Approval.aspx.cs" Inherits="NRA_ITAS.Approval" %>

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
        r<asp:ScriptManager runat="server">
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
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

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
                    <a href="Home.aspx" class="menu">
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
                    <a href="Approval.aspx" class="menu menu--active">
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
                <a href="rubick.left4code.html" class="intro-x flex items-center pl-5 pt-4">
                    <img alt="" class="w-72" src="Asset/images/accessbank.png">
                    <!--<i data-feather="box" class="side-menu__icon"></i>-->
                    <%--<span class="hidden xl:block text-white text-lg ml-3">AccessBank <span class="font-medium">iTAS</span> </span>--%>
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
                <%--<asp:Panel ID="Panel2" runat="server" Visible="true">--%>
                 <li>
                    <a href="Approval.aspx" class="side-menu side-menu--active">
                        <div class="side-menu__icon"><i data-feather="user-check"></i></div>
                        <div class="side-menu__title">Approval</div>
                    </a>
                </li>
                <%--</asp:Panel>--%>
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
            <!-- BEGIN:  -->
            <!-- BEGIN: Content -->
            <div class="content">
                <!-- BEGIN: Top Bar -->
                    <!-- BEGIN: Breadcrumb -->
                      <h2> Pending Transactions</h2>
                    <div class="-intro-x breadcrumb mr-auto  sm:flex"><a href="rubick.left4code.html"></a><i data-feather="chevron-right" class="breadcrumb__icon"></i><a href="rubick.left4code.html" class="breadcrumb--active"></a></div>
    
                    <!-- END: Breadcrumb -->
                    <!-- BEGIN: Search -->                <div class="top-bar">

                        <%--<asp:LinkButton Text="yesyyy" ID="" runat="server" />--%>
   Content
       

                    <div class="intro-x relative  mr-3 sm:mr-6">

                      
                    </div>
                </div>
                <!-- END: Top Bar -->
                <div class="intro-y flex items-center mt-8">

                    <%--start--%>
                    <div class="col-span-12 ">
                        <div class="grid grid-cols-12 gap-6">
                            <!-- BEGIN: General Report -->
                            <div class="col-span-12 mt-8">
                                <div class="intro-y flex items-center h-10">
                                    <h2 class="text-lg font-medium truncate mr-5"> 
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
                                      <%--  <div class="text-center h-10" style="display: flex; flex-wrap: nowrap">
                                            <asp:TextBox runat="server" ID="txtsearch" CssClass=" form-control sm:w-56 box mr-1" runat="server" />
                                            <asp:LinkButton runat="server" OnClick="search" OnClientClick="searchs(this)" CssClass="btn btn-primary  ">Search <span id="spin" ><i data-loading-icon="three-dots" data-color="white" class="w-4 h-4 ml-2"></i></span> </asp:LinkButton>
                                        </div>--%>
                                    </div>
                                    <div class="sm:ml-auto mt-3 sm:mt-0 relative text-gray-700 dark:text-gray-300">
                                        <%-- <a href="javascript:;" data-toggle="modal" data-target="#header-footer-slide-over-preview" class="btn btn-primary w-40 mr-2 mb-2">
                                            <i data-feather="plus" class="w-4 h-4 mr-2"></i>New Payment
                                        </a>--%>
                                        <div class="text-center">
        

                                        </div>
 

                                        <style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 300px;
        height: 140px;
    }
</style>
                                        <%--  <div class="text-center">
                                            <a href="javascript:;" data-toggle="modal" data-target="#static-backdrop-modal-preview" class="btn btn-primary">New Payment</a>
                                        </div>--%>
                                    </div>
                                </div>

                                <div class="intro-y box p-5 mt-12 sm:mt-5" style="overflow-x:scroll">
                                    <div class="flex flex-col xl:flex-row xl:items-center">
                                    </div>
                                    <div style="width: 988px;" class="z-50 "></div>
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
                                                    OnSelectedIndexChanged="sel">

                                                    <%--OnRowDataBound="RowDataBound"--%>
                                                    <%--                                             OnSelectedIndexChanged="GridView1_SelectedIndexChanged"--%>
                                                    <Columns>
                                                        <%--<asp:BoundField ItemStyle-Width="15%" ControlStyle-CssClass="intro-x" DataField="fname" HeaderText="Full Name" SortExpression="fname"></asp:BoundField>--%>
                                                         <asp:BoundField ItemStyle-Width="15.8%" ControlStyle-CssClass="intro-x" DataField="Log_seq" HeaderText="ID" SortExpression="Log_seq"></asp:BoundField>
                                                       <%----%>
                                                        <asp:BoundField ItemStyle-Width="15%" ControlStyle-CssClass="intro-x" DataField="Tin" HeaderText="TIN" SortExpression="Tin"></asp:BoundField>
                                                         <asp:BoundField ItemStyle-Width="15%" ControlStyle-CssClass="intro-x" DataField="Prn" HeaderText="PRN" SortExpression="Prn"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="15%" ControlStyle-CssClass="intro-x" DataField="TaxType" HeaderText="Tax Type" SortExpression="TaxType"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="15%" ControlStyle-CssClass="intro-x" DataField="TaxPayerName" HeaderText="NAME" SortExpression="TaxPayerName"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="15%" ControlStyle-CssClass="intro-x" DataField="PaymentAmount" HeaderText="AMOUNT" SortExpression="PaymentAmount"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="15%" ControlStyle-CssClass="intro-x" DataField="Initiator" HeaderText="INITIATOR" SortExpression="Initiator"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="15%" ControlStyle-CssClass="intro-x" DataField="Trans_Date" HeaderText="DATE" SortExpression="Trans_Date"></asp:BoundField>
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
                            <div class="modal-footer w-full absolute bottom-0">
                                <%--<asp:Button runat="server" Text="Cancel" OnClick="refresh" CssClass="btn btn-outline-secondary w-20 mr-1"></asp:Button>--%>
                                
                                     
                                <asp:LinkButton OnClick="Reciptss" runat="server" CssClass="btn btn-outline-secondary w-24 p-1 ml-1">
                                           Back
                                </asp:LinkButton>
                                 
                                <asp:LinkButton ID="btnApprove" OnClick="btnPaytax_Click" runat="server" CssClass="btn btn-primary w-24 p-1  ">
                                      Approve
                                </asp:LinkButton>
                                 
                                <asp:LinkButton ID="btnReject" OnClick="btnReject_Click" runat="server" CssClass="btn btn-danger w-24 p-1 ">
                                      Reject
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

            <!-- BEGIN: Modal Toggle -->
            <!-- END: Modal Toggle -->
           
            </div>
    </form>
    <!-- BEGIN: JS Assets-->
    <script type="text/javascript">
        function DisablePayTax() {
            document.getElementById("<%= btnApprove.ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisablePayTax;

    </script>
    <script src="Asset/js/markerclusterer-markerclusterer.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBG7gNHAhDzgYmq4-EHvM4bqW1DNj2UCuk&amp;libraries=places"></script>
    <script src="Asset/js/js-app.js"></script>
    <!-- END: JS Assets-->
    <script runat="server">
        protected void ServerButton_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "key", "launchModal();", true);
        }
    </script>
    <script>
        function searchs() {
            var s = document.getElementById("spin")
            s.style.display = 'block'
            //.style.color = clr;
        }

        function searchs() {
        }
        document.body.addEventListener('load', function (mEvent) {

            var s = document.getElementById("showModal")
            s.click();
        }, true);
    </script>
</body>
</html>