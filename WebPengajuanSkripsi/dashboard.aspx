<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="WebPengajuanSkripsi.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <% 
        int tipe = Int32.Parse("" + Session["role"]);

        if (tipe != 0 && tipe != 2)
        {
    %>
    <!-- Animated -->
    <div class="col-lg-3 col-md-6">
        <div class="card">
            <div class="card-body">
                <div class="stat-widget-five">
                    <div class="stat-icon dib flat-color-1">
                        <i class="pe-7s-cash"></i>
                    </div>
                    <div class="stat-content">
                        <div class="text-left dib">
                            <div class="stat-text"><span runat="server" id="s1" class="count">23569</span></div>
                            <div class="stat-heading">Pengajuan</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-3 col-md-6">
        <div class="card">
            <div class="card-body">
                <div class="stat-widget-five">
                    <div class="stat-icon dib flat-color-2">
                        <i class="pe-7s-cart"></i>
                    </div>
                    <div class="stat-content">
                        <div class="text-left dib">
                            <div class="stat-text"><span runat="server" id="s2" class="count">3435</span></div>
                            <div class="stat-heading">Mahasiswa</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-3 col-md-6">
        <div class="card">
            <div class="card-body">
                <div class="stat-widget-five">
                    <div class="stat-icon dib flat-color-3">
                        <i class="pe-7s-browser"></i>
                    </div>
                    <div class="stat-content">
                        <div class="text-left dib">
                            <div class="stat-text"><span runat="server" id="s3" class="count">349</span></div>
                            <div class="stat-heading">Dosen</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-3 col-md-6">
        <div class="card">
            <div class="card-body">
                <div class="stat-widget-five">
                    <div class="stat-icon dib flat-color-4">
                        <i class="pe-7s-users"></i>
                    </div>
                    <div class="stat-content">
                        <div class="text-left dib">
                            <div class="stat-text"><span runat="server" id="s4" class="count">2986</span></div>
                            <div class="stat-heading">Pengguna</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.content -->
    <% }
      
        {%>


    <div class="col-lg-12 col-md-12">
        <div class="card">
            <div class="card-body">

                <form runat="server">
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">ID</label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="t1" autofocus></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Nama</label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="t2" autofocus></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Fakultas</label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="t3" autofocus></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Jurusan</label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="t4" autofocus></asp:TextBox>
                    </div>
                </form>

            </div>
        </div>
    </div>
    <%} %>
</asp:Content>
