<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="ReklamListesi.aspx.cs" Inherits="Yonetim_ReklamListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="g12">
        <table class="datatable">
            <thead>
                <tr>
                    <th>
                        Reklam Adı
                    </th>
                    <th>
                        Tipi
                    </th>
                    <th>
                        Hiti
                    </th>
                    <th>
                        Tıklanma
                    </th>
                    <th>
                        Guid
                    </th>
                    <th>
                        Durum
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
                                <%# Eval("REKADI") %>
                            </td>
                            <td>
                                <%# Eval("REKTIPI") %>
                            </td>
                            <td>
                                <%# string.Format("{0:n}", Eval("REKHIT")) %>
                            </td>
                            <td>
                                <%# string.Format("{0:n}", Eval("REKTIK")) %>
                            </td>
                            <td>
                                <%# Eval("REKGUID").ToString() %>
                            </td>
                            <td class="c">
                                <%# Convert.ToBoolean(Eval("REKAKTIF").ToString()) ? "Aktif" : "Pasif" %>
                            </td>
                            <td class="c">
                                <a href='reklam.aspx?id=<%# Eval("REKID") %>'><img src='css/images/icons/light/cross.png' border='0' width='30' /></a>
                            </td>
                            <td class="c">
                                <asp:LinkButton ID="lnkSil" style="position:relative;top:9px" ToolTip="Sil" runat="server" OnClientClick="return confirm('Silmek istediğinize eminmisiniz ?')" CommandArgument='<%#Eval("REKID") %>' Text="<img src='css/images/icons/light/cross.png' border='0' width='30'  />" CommandName="s"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>

