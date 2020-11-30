<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="Lisanslar.aspx.cs" Inherits="Yonetim_Lisanslar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="g12">
        <table class="datatable">
            <thead>
                <tr>
                    <th>
                        Yetkili Adı
                    </th>
                    <th>
                        Firma Adı
                    </th>
                    <th>
                        GSM No
                    </th>
                    <th>
                        Email
                    </th>
                    <th>
                        Lisans Baş. - Bit.
                    </th>
                    <th>
                        Demo
                    </th>
                    <th>
                        Durum
                    </th>
                    <th>
                        G
                    </th>
                    <th>
                        D
                    </th>
                    <th>
                        S
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeatericerik" runat="server" onitemcommand="Repeatericerik_ItemCommand">
                    <ItemTemplate>
                        <tr class="gradeX">
                            <td>
                                <%#Eval("FIRADSOYAD") %>
                            </td>
                            <td>
                                <%#Eval("FIRFIRMAADI")%>
                            </td>
                            <td>
                                <%#Eval("FIRGSMNO") %>
                            </td>
                            <td>
                                <%#Eval("FIREMAIL") %>
                            </td>
                            <td>
                                <%# string.Format("{0:dd.MM.yyyy}", Eval("FIRLISANSBASTARIH")) + " - " + string.Format("{0:dd.MM.yyyy}", Eval("FIRLISANSBITTARIH")) %>
                            </td>
                            <td>
                                <%# Convert.ToBoolean(Eval("FIRDEMOMU").ToString()) ? "Evet" : "Hayır" %>
                            </td>
                            <td class="c">
                                <%# Convert.ToBoolean(Eval("FIRAKTIF").ToString()) ? "Aktif" : "Pasif" %>
                            </td>
                            <td class="c">
                                <a href="LisansDetay.aspx?gid=<%#Eval("FIRID") %>" title="Görüntüle"><img style="position:relative;top:7px" src='css/images/icons/light/create_write.png' border='0' width='25'/></a>
                            </td>
                            <td class="c">
                                <a href="LisansDetay.aspx?did=<%#Eval("FIRID") %>" title="Düzenle"><img style="position:relative;top:7px" src='css/images/icons/light/create_write.png' border='0' width='25'/></a>
                            </td>
                            <td class="c">
                                <asp:LinkButton ID="lnkSil" style="position:relative;top:9px" ToolTip="Sil" runat="server" OnClientClick="return confirm('Silmek istediğinize eminmisiniz ?')" CommandArgument='<%#Eval("FIRID") %>' Text="<img src='css/images/icons/light/cross.png' border='0' width='30'  />" CommandName="s"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>

