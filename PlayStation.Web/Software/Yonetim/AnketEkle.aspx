<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="AnketEkle.aspx.cs" Inherits="Yonetim_AnketEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g8">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table class="padding">
           
            <tr>
                <td width="200">
                    Anket Soru</td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbad" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbad"
                        Display="None" ErrorMessage="Kategori adı boş geçilemez" ValidationGroup="ggg">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td width="200">
                    Aktif
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                  
                        <asp:CheckBox ID="chkAktif"  Checked="True"  runat="server" 
                            oncheckedchanged="chkAktif_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left:235px">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"
                        CssClass="button blue" ValidationGroup="ggg" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Düzenle" CssClass="button blue" OnClick="BtnUpdate_Click"
                        Visible="False" ValidationGroup="ggg" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="ggg" />
                </td>
            </tr>
        </table>
    </div>
    <div class="g4">
        <table  class="border0">
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td  class="ustbaslik">
                    <h3>
                        Anketler</h3>
                </td>
                <td>
                    <input type="button" value="Geri" onclick="history.go(-1)">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <asp:Repeater ID="RepeaterSoru" runat="server" OnItemCommand="RepaterKategori_ItemCommand">
                            <HeaderTemplate>
                                <tr>
                                    <td>
                                        <b>Soru</b>
                                    </td>
                                    <td width="3">
                                        |
                                    </td>
                                    <td>
                                        <b>Düzenle</b>
                                    </td>
                                    <td width="3">
                                        |
                                    </td>
                                    <td>
                                        <b>Sil</b>
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="solayasla">
                                        <%#Eval("ANKETSORU")%>
                                    </td>
                                    <td width="3">
                                        |
                                    </td>
                                    <td>
                                         <asp:LinkButton ID="LinkButton1"
                                            CommandArgument='<%#Eval("ANKETID") %>' CommandName="d" runat="server" Text="Düzenle"></asp:LinkButton>
                                    </td>
                                    <td width="3">
                                        |
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnksil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                            CommandArgument='<%#Eval("ANKETID") %>' CommandName="s" runat="server" Text="Sil"></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
</asp:Content>
