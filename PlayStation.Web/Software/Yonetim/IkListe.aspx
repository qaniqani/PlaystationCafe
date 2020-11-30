<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="IkListe.aspx.cs" Inherits="Yonetim_IkListe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <div class="g12">
        <table class="datatable">
            <thead>
                <tr>
                    <th width="100">
                        Başlık
                    </th>
                    <th width="50">
                       Referans
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
                                <%#Eval("BASLIK")%>
                            </td>
                            <td>
                                <%#Eval("KOD")%>
                            </td>
                           
                            <td class="c">
                                <%#Eval("TARIH")%>
                            </td>
                            <td class="c">
                                <%#Convert.ToBoolean(Eval("DURUM")) == true ? "Aktif" : "Pasif"%>
                            </td>
                            <td class="c">
                                <a href="IkEkle.aspx?id=<%#Eval("ID")%>">
                                    <img src="css/images/icons/light/create_write.png" border="0" width="25" style="position: relative;
                                        top: 7px"></a>
                            </td>
                            <td>
                                <asp:LinkButton ID="BtnSil" Style="position: relative; top: 9px" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                    CommandArgument='<%#Eval("ID")%>' CommandName="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>

