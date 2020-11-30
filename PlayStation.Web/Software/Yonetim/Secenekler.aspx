<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="Secenekler.aspx.cs" Inherits="Yonetim_Secenekler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                    Başlık
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbad" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tbad" Display="None" 
                        ErrorMessage="Seçenek başlığı boş geçilemez" ValidationGroup="uuu">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Sıra No
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox Text="9999" ID="tbsira" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Seçenek Adı
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                  
                        <asp:Label ID="lbkat" runat="server" Text="Label"></asp:Label>
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
                    
                        <asp:CheckBox ID="chkAktif" runat="server" Checked="true" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left:235px">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"
                        CssClass="button blue" ValidationGroup="uuu" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Düzenle" CssClass="button blue" OnClick="BtnUpdate_Click"
                        Visible="False" ValidationGroup="uuu" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="uuu" />
                </td>
            </tr>
        </table>
    </div>
    <div class="g4">
        <table class="border0">
           
            <tr>
                <td class="ustbaslik">
                    <h3>
                        Seçenekler</h3>
                </td>
                <td>
                    <input type="button" value="Geri" onclick="history.go(-1)">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <asp:Repeater ID="RepaterKategori" runat="server" OnItemCommand="RepaterKategori_ItemCommand">
                            <HeaderTemplate>
                                <tr>
                                    <td>
                                        <b>Başlık</b>
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
                                        <a href="Secenekler.aspx?id=<%#Eval("OZELLIKUSTID").ToString() != "0" ? Eval("OZELLIKUSTID") : Eval("OZELLIKID")%>"
                                            class="list">
                                            <%#Eval("OZELLIKBASLIK")%></a>
                                    </td>
                                    <td width="3">
                                        |
                                    </td>
                                    <td>
                                        <a href="Secenekler.aspx?id=<%#Eval("OZELLIKUSTID") %>&duzen=<%#Eval("OZELLIKID") %>"
                                            class="list">Düzenle</a>
                                    </td>
                                    <td width="3">
                                        |
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnksil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                            CommandArgument='<%#Eval("OZELLIKID") %>' CommandName="s" runat="server" Text="Sil"></asp:LinkButton>
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
