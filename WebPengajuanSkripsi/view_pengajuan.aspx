<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="view_pengajuan.aspx.cs" 
    Inherits="WebPengajuanSkripsi.view_pengajuan" %>

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
                     <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Tahun Akademik</label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="t2" autofocus></asp:TextBox>
                    </div>
                     <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Peminatan</label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="t3" autofocus></asp:TextBox>
                    </div>
                      <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Catatan Kaprodi</label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="catatan_kaprodi" autofocus></asp:TextBox>
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
                                                        <td> <span class="name"><%# Eval("nama_file") %></span> </td>
                                                        <td><span class="counts"><asp:HyperLink ID="lnkDetails" download NavigateUrl='<%# Eval("lokasi_file") %>' runat="server">Download</asp:HyperLink></span></td>
                                                        </tr>
                                                    </ItemTemplate>  
                                                </asp:Repeater>
                                         </tbody>
                                    </table>
                                    </div>
                    <div>
                    </div>
                </form>

            </div>
        </div>
    </div>
</asp:Content>
