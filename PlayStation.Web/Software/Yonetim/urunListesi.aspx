<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="urunListesi.aspx.cs" Inherits="Yonetim_urunListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
        <table class="datatable">
            <thead>
                <tr>
                    <th>
                        Başlık
                    </th>
                    <th>
                        Kategori
                    </th>
                    <th>
                        Ürün Url
                    </th>
                    <th>
                        Tarih
                    </th>
                    <th>
                        Durum
                    </th>
                    <th>
                        Düzenle
                    </th>
                    <th>
                        Sil
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterUrun" runat="server" OnItemCommand="RepeaterUrun_ItemCommand">
                    <ItemTemplate>
                        <tr class='gradeX'>
                            <td>
                                <%#Eval("URUNADI")%>
                            </td>
                            <td>
                                <%#kategorigetir(Convert.ToInt32(Eval("KATID")) )%>
                            </td>
                            <td>
                                <%#Eval("URUNURL")%>
                            </td>
                            <td class="c">
                                <%#Eval("TARIH") %>
                            </td>
                            <td class="c">
                                
                                <%#Convert.ToBoolean(Eval("URUNDURUM")) == true ? "Aktif" : "Pasif"%>
                            </td>
                            <td class="c">
                                <a href="urunEkle.aspx?id=<%#Eval("URUNID")%>">
                                    <img src="css/images/icons/light/create_write.png" style="position:relative;top:7px" border="0" width="25"></a>
                            </td>
                            <td>
                                <asp:LinkButton ID="BtnSil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>" style="position:relative;top:9px"  CommandArgument='<%#Eval("URUNID")%>'
                                    CommandName="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
