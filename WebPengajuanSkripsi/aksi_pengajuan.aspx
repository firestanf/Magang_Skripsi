<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="aksi_pengajuan.aspx.cs"
    Inherits="WebPengajuanSkripsi.aksi_pengajuan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-12">
        <div class="card">
            <div class="card-body">
                <div class="card-header">
                    <h3 class="text-center">Pengajuan</h3>
                </div>
                <hr>
                <form runat="server">
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Judul</label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="t1" autofocus></asp:TextBox>
                    </div>
                    <div class="table-stats order-table ov-h">
                        <table class="table ">
                            <thead>
                                <tr>
                                    <th>Nama File</th>
                                    <th>Opsi</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RptDownload" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><span class="name"><%# Eval("nama_file") %></span> </td>
                                             <td><span class="counts"><asp:HyperLink download ID="lnkDetails" NavigateUrl='<%# Eval("lokasi_file") %>' runat="server">Download</asp:HyperLink></span></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                    <div class="row">

                        <div class="form-group col-lg-6">
                            <label for="cc-payment" class="control-label mb-1">nama Mahasiswa</label>
                            <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="nama_mhs" autofocus></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="cc-payment" class="control-label mb-1">NIM Mahasiswa</label>
                            <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="nim_mhs" autofocus></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="cc-payment" class="control-label mb-1">Ipk Mahasiswa</label>
                            <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="ipk_mhs" autofocus></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="cc-payment" class="control-label mb-1">Alamat Mahasiswa</label>
                            <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="alamat" autofocus></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="cc-payment" class="control-label mb-1">Telp Mahasiswa</label>
                            <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="telp" autofocus></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="cc-payment" class="control-label mb-1">Jurusan</label>
                            <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="jurusan" autofocus></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <label for="cc-payment" class="control-label mb-1">Fakultas</label>
                            <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="fakultas" autofocus></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Catatan Kaprodi</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="catatan_kaprodi" autofocus></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Status</label>
                        <asp:DropDownList runat="server" ID="d1" CssClass="form-control">
                            <asp:ListItem Value="Pending" Text="Pending"></asp:ListItem>
                            <asp:ListItem Value="Disetujui" Text="Disetujui"></asp:ListItem>
                            <asp:ListItem Value="Ditolak" Text="Ditolak"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Pembimbing 1</label>
                        <asp:DropDownList runat="server" ID="d2" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Pembimbing 2</label>
                        <asp:DropDownList runat="server" ID="d3" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="show_error" ForeColor="Red" Visible="false" runat="server">Mohon pilih Dosen Pembimbing</asp:Label>
                    <div>
                        <asp:Button OnClick="Unnamed_Click" runat="server" CssClass="btn btn-lg btn-info btn-block" Text="Proses"></asp:Button>
                    </div>

                  
                </form>

            </div>
        </div>
    </div>
</asp:Content>
