<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="UyeListesi.aspx.cs" Inherits="Yonetim_UyeListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
        <table class="datatable">
            <thead>
                <tr>
                    <th>
                        Ad Soyad
                    </th>
                    <th>
                        Tel
                    </th>
                    <th>
                        GSM
                    </th>
                     <th>
                        E-Mail
                    </th>
                    <th>
                        Tarih
                    </th>
                    <th>
                        Aktivasyon
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
                                <%#Eval("UYEAD")%>
                                <%#Eval("UYESOYAD")%>
                            </td>
                            <td>
                                <%#Eval("UYETEL")%>
                            </td>
                            <td>
                                <%#Eval("UYEGSM")%>
                            </td>
                            <td class="c">
                                <%#Eval("UYEMAIL")%>
                            </td>
                            <td class="c">
                                <%#Eval("UYETARIH")%>
                            </td>
                            <td class="c">
                          
                                <%#Convert.ToBoolean(Eval("UYEAKTIVASYONDURUM")) == true ? "Aktif" : "Pasif"%>
                            </td>
                            <td class="c">
                                
                                <%#Convert.ToBoolean(Eval("UYEDURUM")) == true ? "Aktif" : "Pasif"%>
                            </td>
                            <td class="c">
                                <a href="UyeGuncelle.aspx?id=<%#Eval("UYEID")%>">
                                    <img src="css/images/icons/light/create_write.png" style="position:relative;top:7px" border="0" width="25"></a>
                            </td>
                            <td>
                                <asp:LinkButton ID="BtnSil" style="position:relative;top:9px" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                    CommandArgument='<%#Eval("UYEID")%>' CommandName="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
