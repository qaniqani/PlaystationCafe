<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="KullaniciBelirle.aspx.cs" Inherits="KullaniciBelirle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="g12">
   <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <table class="datatable">
            <thead>
                <tr>
                    <th>
                        Ad Soyad
                    </th>
                    <th>
                      Kullanıcı
                    </th>
                    <th>
                    Durum
                    </th>
                  
                    <th>
                        Tarih
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
                                <%#Eval("ADMINADI")%>
                             
                            </td>
                            <td>
                                <%#Eval("ADMINKULLANICI")%>
                            </td>
                            <td>
                                <%# ((bool)Eval("DURUM") == true ? "Aktif":"Pasif")%>
                            </td>
                            <td class="c">
                                <%#Eval("TARIH")%>
                            </td>
                           
                            <td class="c">
                                <a href="KullaniciEkle.aspx?id=<%#Eval("ADMINID")%>">
                                    <img src="css/images/icons/light/create_write.png"  border="0" width="25" class="resimhizala resimhizala2"></a>
                            </td>
                            <td>
                                <asp:LinkButton ID="BtnSil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30' class='resimhizala'/>"
                                    CommandArgument='<%#Eval("ADMINID")%>' CommandName="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>

