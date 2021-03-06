﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="edit_pengajuan.aspx.cs" Inherits="WebPengajuanSkripsi.edit_pengajuan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="card">
            <div class="card-body">
                <div class="card-header">
                    <h3 class="text-center">Edit Judul</h3>
                </div>
                <hr>
                <form runat="server">
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Judul</label>
                        <asp:TextBox runat="server" CssClass="form-control" required ID="t1" autofocus></asp:TextBox>
                    </div>
                 <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Berkas <span>* Harap Upload File jenis PDF atau WORD</span></label>
                        <asp:FileUpload  runat="server" CssClass="form-control" AllowMultiple="true"  ID="f1"></asp:FileUpload>
                  </div>
                    <div>
                           <asp:Label ID="error_tipe" runat="server" ForeColor="Red">Tipe File yang di upload salah</asp:Label>
                        <asp:Button OnClick="Unnamed_Click" runat="server"  CssClass="btn btn-lg btn-info btn-block" Text="Update"></asp:Button>
                    </div>
                </form>

            </div>
        </div>
    </div>
</asp:Content>
