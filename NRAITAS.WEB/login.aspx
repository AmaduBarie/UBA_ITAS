<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="NRA_ITAS.login" %>

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="NRA_ITAS.login" %>--%>

<!DOCTYPE html>
<html lang="en" class="light">
<!-- BEGIN: Head -->
<head runat="server">
    <meta charset="utf-8">
    <link href="Asset/auth/images/logo.svg" rel="shortcut icon">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Login - AccessBank</title>
    <!-- BEGIN: CSS Assets-->
    <link rel="stylesheet" href="Asset/auth/css/css-app.css">
    <!-- END: CSS Assets-->
     <style>
        .btn-primary, .dark .btn-primary {
    --tw-border-opacity: 1;
    border-color: #ffff !important;
}

.btn-primary {
    --tw-bg-opacity: 1;
    background-color: #d42d11 !important;
    --tw-text-opacity: 1;
    color: rgba(255, 255, 255, var(--tw-text-opacity));
}

.primary {
    color: #d42d11 !important;
    
}
    </style>
</head>
<!-- END: Head -->
<body class="login">
    <form id="form1" runat="server">
        <div class="container sm:px-10">
            <div class="block xl:grid grid-cols-2 gap-4">
                <!-- BEGIN: Login Info -->
                <div class="hidden xl:flex flex-col min-h-screen">
                    <a href="rubick.left4code.html" class="-intro-x flex items-center pt-5">
                        <img alt="" class="w-72" src="Asset/auth/images/uba.png">
                        <%--<span class="text-white text-lg ml-3"> Access<span class="font-medium">Bank</span> </span>--%>
                    </a>
                    <div class="my-auto">
                        <img alt="" class="-intro-x w-1/2 -mt-16" src="images/images-illustration.svg">
                        <div class="-intro-x text-white font-medium text-4xl leading-tight mt-10">
                            NRA - ITAS
                                <br>
                            Sign in to process customer's tax.
                        </div>
                       </div>
                </div>
                <!-- END: Login Info -->
                <!-- BEGIN: Login Form -->
                <div class="h-screen xl:h-auto flex py-5 xl:py-0 my-10 xl:my-0">
                    <div class="my-auto mx-auto xl:ml-20 bg-white dark:bg-dark-1 xl:bg-transparent px-5 sm:px-8 py-8 xl:p-0 rounded-md shadow-md xl:shadow-none w-full sm:w-3/4 lg:w-2/4 xl:w-auto">
                        <h2 class="primary intro-x font-bold text-2xl xl:text-3xl text-center xl:text-left">Sign In
                        </h2>
                        <div class="primary intro-x mt-2 text-gray-500 xl:hidden text-center">Sign in</div>
                        <div class="intro-x mt-8">
                            <asp:TextBox ID="txtUserName" CssClass="intro-x login__input form-control py-3 px-4 border-gray-300 block" runat="server" placeholder="User Name"></asp:TextBox>
                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="intro-x login__input form-control py-3 px-4 border-gray-300 block mt-4" runat="server" placeholder="Password"></asp:TextBox>
                        </div>
                        <div class="intro-x mt-5 xl:mt-8 text-center xl:text-left">
                            <%--<button class="btn btn-primary block py-3 px-4 w-full xl:w-32 xl:mr-3 align-top"></button>--%>
                            <asp:Button ID="btnLogin" CssClass="btn btn-primary block py-3 px-4 w-full xl:w-32 xl:mr-3 align-top" Text="Login" runat="server" OnClick="btnLogin_Click" />
                        </div>
                        <div class="intro-x mt-10 xl:mt-24 text-gray-700 dark:text-gray-600 text-center xl:text-left">
                            ALERT! ALERT!! ALERT!!!
                                <br>
                            <a class="text-theme-1 dark:text-theme-10" href="rubick.left4code.html">This computer system is the property of United Bank of Africa. It is for authorized use only. By using this system, all users acknowledge notice of, and agree to comply with, the Bank's Use of Information Technology Policy</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="Asset/auth/js/js-app.js"></script>
</body>
</html>