<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="KategoriEkle.aspx.cs" Inherits="Yonetim_KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g8">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table cellpadding="0" cellspacing="0" class="padding">
            <tr>
                <td width="150">
                    Adı
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbad" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbad"
                        Display="None" ErrorMessage="Kategori adı boş geçilemez" ValidationGroup="ggg">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="trozet" runat="server" visible="false">
                <td width="150">
                    Özet
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="TbOzet" runat="server" Height="80px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr id="trlogo" runat="server" visible="false">
                <td width="150">
                    Resim
                </td>
                <td width="10">
                </td>
                <td width="300">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr id="trres" runat="server" visible="false">
                <td width="150">
                </td>
                <td width="10">
                </td>
                <td width="300">
                    <img id="imgsrc" width="150" border="0" runat="server" />
                    <asp:Label ID="lbres" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150">
                    Title
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbtitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150">
                    Description
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbdess" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150">
                    Keyword
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbkey" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150">
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
                <td width="150">
                    Kategori Adı
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:Label ID="lbkat" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="150">
                    Aktif
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:CheckBox ID="chkAktif" runat="server" Checked="true" />
                </td>
            </tr>
            <tr runat="server" visible="false">
                <td width="150">
                    Kategori Türü
                </td>
                <td width="10">
                </td>
                <td width="300">
                    <asp:DropDownList ID="drpKattur" runat="server">
                        <asp:ListItem Text="Icerik" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Anasayfa" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Normal" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 216px;">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"
                        CssClass="button blue" ValidationGroup="ggg" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Düzenle" CssClass="button blue" OnClick="BtnUpdate_Click"
                        Visible="False" ValidationGroup="ggg" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="ggg" Width="150px" />
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
                        Kategoriler</h3>
                </td>
                <td>
                    <input type="button" value="Geri" onclick="history.go(-1)" style="width: 80px;">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="border0" cellpadding="0" cellspacing="0">
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
                                        <a href="KategoriEkle.aspx?id=<%#Eval("KATID") %>" class="list">
                                            <%#Eval("KATADI") %></a>
                                    </td>
                                    <td width="3">
                                        |
                                    </td>
                                    <td>
                                        <a href="KategoriEkle.aspx?id=<%#Eval("KATUSTID") %>&duzen=<%#Eval("KATID") %>" class="list">
                                            Düzenle</a>
                                    </td>
                                    <td width="3">
                                        |
                                    </td>
                                    <td>
                                        <asp:LinkButton Visible='<%#Eval("KATDEGIS").ToString() == "1" ? true : false %>'
                                            ID="lnksil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                            CommandArgument='<%#Eval("KATID") %>' CommandName="s" runat="server" Text="Sil"></asp:LinkButton>
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
