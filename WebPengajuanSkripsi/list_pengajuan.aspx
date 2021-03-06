﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="list_pengajuan.aspx.cs"
    Inherits="WebPengajuanSkripsi.list_pengajuan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="detail_add" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="card">

            <div class="card-header">
            </div>
            <div class="table-stats order-table ov-h">
                <form runat="server">
                    <div class="table-responsives" style="overflow: scrolls">
                        <asp:GridView ID="GridView1" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                            runat="server" AllowPaging="true" PageSize="20" AllowSorting="false" CssClass="table  table-striped table-bordered table-hover "
                            OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating"
                            OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
                            <HeaderStyle HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <%# (GridView1.PageSize * (GridView1.PageIndex)) + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nim" HeaderText="NIM" SortExpression="nim"
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="nama" HeaderText="Nama" SortExpression="nama"
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="judul_skripsi" HeaderText="Judul" SortExpression="judul_skripsi"
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="tgl_submit" HeaderText="Tanggal Pengajuan" SortExpression="tgl_submit"
                                    DataFormatString="{0:dd/MM/yyyy}"
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="nama_peminatan" HeaderText="Peminatan" SortExpression="nama_peminatan"
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="nama_thn_akademik" HeaderText="Tahun Akademik" SortExpression="nama_thn_akademik"
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="status_proposal" HeaderText="Status" SortExpression="status_proposal"
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="dosen_1" HeaderText="Pembimbing 1" SortExpression="dosen_1"
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="dosen_2" HeaderText="Pembimbing 2" SortExpression="dosen_2"
                                    HeaderStyle-CssClass="" />
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-success btn-sm"
                                            CommandName="view" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id_proposal") %>'>View</asp:LinkButton>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" FirstPageText="First Page" LastPageText="Last Page"
                                PageButtonCount="5" />
                            <PagerStyle HorizontalAlign="Right" CssClass="pagination pull-right" />
                        </asp:GridView>

                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
