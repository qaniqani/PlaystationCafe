<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="icerikListesi.aspx.cs" Inherits="Yonetim_icerikListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
        <table class="datatable">
            <thead>
                <tr>
                    <th width="150">
                        Başlık
                    </th>
                    <th width="60">
                        Kategori
                    </th>
                    <th width="100">
                        İçerik Url
                    </th>
                    <th  width="60">
                        Tarih
                    </th>
                    <th  width="60">
                        Durum
                    </th>
                    <th  width="70ice">
                        Düzenle
                    </th>
                    <th  width="60">
                        Sil
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeatericerik" runat="server" 
                    onitemcommand="Repeatericerik_ItemCommand">
                    <ItemTemplate>
                        <tr class="gradeX">
                            <td>
                                <%#Eval("ICERIKBASLIK") %>
                            </td>
                            <td>
                                <%#kategorigetir(Convert.ToInt32(Eval("ICERIKKATID")))%>
                            </td>
                            <td>
                                <%#Eval("ICERIKURL") %>
                            </td>
                            <td class="c">
                                <%#Eval("ICERIKTARIH") %>
                            </td>
                            <td class="c">
                                      <%#Convert.ToBoolean(Eval("ICERIKDURUM")) == true ? "Aktif" : "Pasif"%>
                            </td>
                            <td class="c">
                                <a href="icerikEkle.aspx?id=<%#Eval("ICERIKID") %>"><img style="position:relative;top:7px" src='css/images/icons/light/create_write.png' border='0' width='25'/></a>
                            </td>
                            <td class="c">
                                <asp:LinkButton ID="LinkButton1" style="position:relative;top:9px" runat="server" OnClientClick="return confirm('Silmek istediğinize eminmisiniz ?')" CommandArgument='<%#Eval("ICERIKID") %>' Text="<img src='css/images/icons/light/cross.png' border='0' width='30'  />" CommandName="s"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
