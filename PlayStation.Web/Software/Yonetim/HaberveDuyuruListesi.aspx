<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="HaberveDuyuruListesi.aspx.cs" Inherits="Yonetim_HaberveDuyuruListesi" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
        <table class="padding">
            
            <tr>
                <td>
                    İçerik Türü
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:DropDownList ID="drpTur" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpTur_SelectedIndexChanged">
                        <asp:ListItem Value="1">Haber</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div class="g12">
        <table class="datatable">
            <thead>
                <tr>
                    <th width="100">
                        Başlık
                    </th>
                    <th width="50">
                        Tür
                    </th>
                    <th width="100">
                        Url
                    </th>
                    <th width="50">
                        Tarih
                    </th>
                    <th width="60">
                        Durum
                    </th>
                    <th width="60">
                        Düzenle
                    </th>
                    <th width="50">
                        Sil
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterUrun" runat="server" OnItemCommand="RepeaterUrun_ItemCommand">
                    <ItemTemplate>
                        <tr class='gradeX'>
                            <td>
                                <%#Eval("HABERBASLIK")%>
                            </td>
                            <td>
                                <%#Eval("HABERTUR")=="1"?"Haber":"Haber"%>
                            </td>
                            <td>
                                <%#Eval("HABERURL")%>
                            </td>
                            <td class="c">
                                <%#Eval("HABERTARIH")%>
                            </td>
                            <td class="c">
                                <%#Convert.ToBoolean(Eval("HABERDURUM")) == true ? "Aktif" : "Pasif"%>
                            </td>
                            <td class="c">
                                <a href="HaberveDuyuruEkle.aspx?id=<%#Eval("HABERID")%>">
                                    <img src="css/images/icons/light/create_write.png" border="0" width="25" style="position: relative;
                                        top: 7px"></a>
                            </td>
                            <td>
                                <asp:LinkButton ID="BtnSil" Style="position: relative; top: 9px" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                    CommandArgument='<%#Eval("HABERID")%>' CommandName="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
