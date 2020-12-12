<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" 
    CodeBehind="detail_bimbingan.aspx.cs" 
    Inherits="WebPengajuanSkripsi.detail_bimbingan" %>

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
                        <label for="cc-payment" class="control-label mb-1">NIM</label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="t2" autofocus></asp:TextBox>
                    </div>
                      <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Nama</label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="t3" autofocus></asp:TextBox>
                    </div>
                     <div class="form-group">
                        <label for="cc-payment" class="control-label mb-1">Isi</label>
                        <asp:TextBox runat="server" CssClass="form-control" required ID="t4" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button OnClick="Unnamed_Click" runat="server"  CssClass="btn btn-lg btn-info btn-block" Text="Update"></asp:Button>
                    </div>
                    <div>
                    </div>

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
                                <asp:BoundField DataField="nama_pengirim" HeaderText="Pengirim" SortExpression="nama_pengirim"
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="nama_penerima" HeaderText="Penerima" SortExpression="nama_penerima"
                                    
                                    HeaderStyle-CssClass="" />
                                <asp:BoundField DataField="isi" HeaderText="Isi Bimbingan" SortExpression="isi"
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
