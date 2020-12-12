<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu_reporting.aspx.cs" Inherits="WebPengajuanSkripsi.Menu_reporting" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="card">
        
            <div class="card-header">
          
            </div>
            <div class="table-stats order-table ov-h">
                <form runat="server">
                    <div class="table-responsives" style="overflow: scrolls">
                        <asp:GridView ID="GridView1" AutoGenerateColumns="false" 
                            runat="server"  PageSize="20" AllowSorting="false" CssClass="table  table-striped table-bordered table-hover "
                        >
                            <HeaderStyle HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <%# (GridView1.PageSize * (GridView1.PageIndex)) + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="semester" HeaderText="Tahun Akademik" SortExpression="nama"                                 
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="jml_mhs" HeaderText="Jumlah Mahasiswa" SortExpression="fakultas"
                                    HeaderStyle-CssClass="" />
                                
                            </Columns>
                           
                        </asp:GridView>

                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
