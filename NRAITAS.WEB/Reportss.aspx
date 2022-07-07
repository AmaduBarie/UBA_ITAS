<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportss.aspx.cs" Inherits="NRA_ITAS.Reportss" %>

<!DOCTYPE html>

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
                                
                                <div class="row" style="display:flex;flex-wrap:nowrap;justify-content:space-between;align-items:flex-end;width:100%">
                                <div class="col-8 " style="display:flex;flex-wrap:nowrap">
                                <asp:Panel runat="server" ID="enterdate">
                                    <div style="display: flex; flex-wrap: nowrap; flex-direction: row">
                                        <div>
                                            <label for="txtstart" class="form-label">From</label>
                                            <div style="display: flex; flex-wrap: nowrap; min-width: 15em">

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
                                            </div>

                                            <%-- <asp:TextBox runat="server" ID="txtstart" SkinID="modal-datepicker-1" class="datepicker form-control" data-single-mode="true" />--%>
                                        </div>
                                        <div class="col-span-12 sm:col-span-4">
                                            <label for="txtend" class="form-label">To</label>
                                            <div style="display: flex; flex-wrap: nowrap; min-width: 13em">

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
                                            </div>

                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="modal-footer text-right mt-4">
                                    <%--<button type="button" data-dismiss="modal" class="btn btn-outline-secondary w-20 mr-1">Cancel</button>--%>
                                    <asp:Button runat="server" OnClick="btnsearcher" CommandArgument="data" CssClass="btn btn-primary w-20" Text="Search" />

                                </div>
                                </div>
                                    <asp:LinkButton Text="" runat="server" OnClick="btnsearcherexl" CommandArgument="excel"  CssClass="col-2 mb-2">
                <asp:Image CssClass="excel" runat="server" Width="3em" Height="3em" ImageUrl="./Asset/excel.jpeg" />
                    </asp:LinkButton>
                                </div>
                                <!-- END: Modal Footer -->
                            </div>
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
         



        
        <!-- BEGIN: Slide Over Content -->
        <div id="header-footer-slide-over-preview" class="modal modal-slide-over" data-backdrop="static" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="font-medium text-base mr-auto">Record Details</h2>
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
