﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="add_bimbingan.aspx.cs" 
    Inherits="WebPengajuanSkripsi.add_bimbingan" %>

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
                        <asp:DropDownList runat="server" CssClass="form-control" required ID="t1" autofocus></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Judul</label>
                        <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" required ID="t2" ></asp:TextBox>
                    </div>
                    
                    <div>
                        <asp:Button OnClick="Unnamed_Click" runat="server"  CssClass="btn btn-lg btn-info btn-block" Text="Submit"></asp:Button>
                    </div>
                </form>

            </div>
        </div>
    </div>
</asp:Content>