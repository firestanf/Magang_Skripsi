<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="mahasiswa.aspx.cs" Inherits="WebPengajuanSkripsi.mahasiswa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                <asp:BoundField DataField="alamat" HeaderText="Alamat" SortExpression="alamat"
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="telp" HeaderText="Telp" SortExpression="telp"
                                    HeaderStyle-CssClass="" />
                                
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
