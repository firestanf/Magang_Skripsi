<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="peminatan.aspx.cs" 
    Inherits="WebPengajuanSkripsi.peminatan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="card">
        
            <div class="card-header">
                <a href="add_peminatan.aspx" class="btn btn-primary btn-sm pull-right">Tambah Peminatan</a>
            </div>
            <div class="table-stats order-table ov-h">
                <form runat="server">
                    <div class="table-responsives" style="overflow: scrolls">
                        <asp:GridView ID="GridView1" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                            runat="server" AllowPaging="true" PageSize="20" AllowSorting="false" CssClass="table  table-striped table-bordered table-hover ">
                             <HeaderStyle HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <%# (GridView1.PageSize * (GridView1.PageIndex)) + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nama_peminatan" HeaderText="Peminatan" SortExpression="nama_peminatan"
                                    HeaderStyle-CssClass="" />
                              <asp:BoundField DataField="nama_fakultas" HeaderText="Fakultas" SortExpression="nama_fakultas"
                                    HeaderStyle-CssClass="" />
                              
                                <asp:BoundField DataField="nama_jurusan" HeaderText="Jurusan" SortExpression="nama_jurusan"
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
