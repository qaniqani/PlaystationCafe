<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="AlbumEkle.aspx.cs" Inherits="Yonetim_AlbumEkle" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
    </div>
    <div class="g8">
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
                        ControlToValidate="tbad" Display="None" ErrorMessage="Albüm adı boş geçilemez" 
                        ValidationGroup="aeae">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="trlogo" runat="server" visible="true">
                <td width="200">
                    Logo
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                     
                </td>
            </tr>
            <tr id="trres" runat="server" visible="false">
                <td width="200">
                </td>
                <td width="10">
                </td>
                <td width="300">
                    <img id="imgsrc" border="0" runat="server" />
                    <asp:Label ID="lbres" Visible="false" runat="server"></asp:Label>
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
                    <asp:TextBox ID="tbsira" runat="server">9999</asp:TextBox>
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
                  
                        <asp:CheckBox ID="chkAktif" runat="server" Checked="True" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left:235px;">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"
                        CssClass="button blue" ValidationGroup="aeae" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Düzenle" CssClass="button blue" OnClick="BtnUpdate_Click"
                        Visible="False" ValidationGroup="aeae" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="aeae" />
                </td>
            </tr>
        </table>
    </div>
    <div class="g4">
        <table class="border0">
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td class="ustbaslik">
                    <h3>
                        Albümler</h3>
                </td>
                <td>
                    <input type="button" value="Geri" onclick="history.go(-1)">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="border0" cellpadding="0" cellspacing="0">
                        <asp:Repeater ID="RepeaterAlbum" runat="server" OnItemCommand="RepaterKategori_ItemCommand">
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
                                        <%#Eval("ALBUMBASLIK")%>
                                    </td>
                                    <td width="3">
                                        |
                                    </td>
                                    <td>
                                        <a href="AlbumEkle.aspx?id=<%#Eval("ALBUMID") %>" class="list">Düzenle</a>
                                    </td>
                                    <td width="3">
                                        |
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnksil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                            CommandArgument='<%#Eval("ALBUMID") %>' CommandName="s" runat="server" Text="Sil"></asp:LinkButton>
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
