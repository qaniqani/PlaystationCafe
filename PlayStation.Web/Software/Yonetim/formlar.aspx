<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="formlar.aspx.cs" Inherits="Yonetim_formlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div class="g12">
            <table class="padding">
                <tr>
                    <td width="150">
                        Formu Durumu
                    </td>
                    <td width="10">
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="drpdil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpdil_SelectedIndexChanged">
                            <asp:ListItem Value="0">Okunmadı</asp:ListItem>
                            <asp:ListItem Value="1">Okundu</asp:ListItem>
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
                            Ad Soyad
                        </th>
                        <th width="100">
                            Tel
                        </th>
                        <th width="150">
                            Konu
                        </th>
                        <th width="40">
                            Tarih
                        </th>
                        <th width="60">
                            Detay
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
                                    <%#Eval("FORMADI")+" "+Eval("FORMSOYADI")%>
                                </td>
                                <td>
                                    <%#Eval("FORMTEL")%>
                                </td>
                                <td>
                                    <%#Eval("FORMKONU")%>
                                </td>
                                <td class="c">
                                    <%#Eval("FORMTARIH")%>
                                </td>
                                <td class="c">
                                    <a href="formDetay.aspx?id=<%#Eval("FORMID")%>">
                                        <img src="css/images/icons/light/create_write.png" style="position: relative; top: 7px"
                                            border="0" width="25"></a>
                                </td>
                                <td>
                                    <asp:LinkButton Style="position: relative; top: 9px" ID="BtnSil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                        runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                        CommandArgument='<%#Eval("FORMID")%>' CommandName="Sil" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
