<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebPengajuanSkripsi._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pengajuan Skripsi Online</title>
    <link rel="apple-touch-icon" href="https://i.imgur.com/QRAUqs9.png">
    <link rel="shortcut icon" href="https://i.imgur.com/QRAUqs9.png">

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/normalize.css@8.0.0/normalize.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/font-awesome@4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/gh/lykmapipo/themify-icons@0.1.2/css/themify-icons.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/pixeden-stroke-7-icon@1.2.3/pe-icon-7-stroke/dist/pe-icon-7-stroke.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/flag-icon-css/3.2.0/css/flag-icon.min.css">
    <link rel="stylesheet" href="Content/assets/css/cs-skin-elastic.css">
    <link rel="stylesheet" href="Content/assets/css/style.css">
    <style>
        .btn {
          background-color:#9e172e;
          color:white;
        }
            .btn:hover {
            background-color:white;
            border:1px solid #9e172e;
          color:#9e172e;
            }
        .login_input:focus {
            outline: 2px solid #9e172e !important;
            box-shadow: 0 0 10px #719ECE;
            border-radius5:50%;
        }
    </style>
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css'>
</head>
<body>

    <div class="sufee-login d-flex align-content-center flex-wrap">
        <div class="container">
            <div class="login-content">
                <div class="login-logo">
                    <a href="index.html">
                        <img class="align-content" src="http://untar.ac.id/assets/images/logo.png" alt="">
                    </a>
                </div>
                <div class="login-form">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <label>Masukkan Nim/Nid Anda</label>
                            <asp:TextBox TextMode="SingleLine" class="form-control login_input"  required autofocus runat="server" ID="t1" />
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <asp:TextBox TextMode="Password" class="form-control login_input"  required runat="server" ID="t2" />
                        </div>
                        <%--<div class="form-group">
                            <label>Role</label>
                            <asp:DropDownList runat="server" ID="d1" CssClass="form-control">
                                <asp:ListItem Value="0">Mahasiswa</asp:ListItem>
                                <asp:ListItem Value="1">Kaprodi</asp:ListItem>
                                  <asp:ListItem Value="2">Dosen</asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
                        <asp:Label ID="lblInvalidUsernamePassword" ForeColor="Red" Visible="false" runat="server">Username atau Password tidak terdaftar!</asp:Label>
                        <asp:Button OnClick="tombol_login" runat="server"  CssClass="btn btn-success btn-flat m-b-30 m-t-30" Text="Login"></asp:Button>

                    </form>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/jquery@2.2.4/dist/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.4/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-match-height@0.7.2/dist/jquery.matchHeight.min.js"></script>
    <script src="Content/assets/js/main.js"></script>
     
</body>
</html>
