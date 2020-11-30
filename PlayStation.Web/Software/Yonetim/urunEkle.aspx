<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="urunEkle.aspx.cs" Inherits="Yonetim_urunEkle" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g8">
        <div id="divhata" runat="server" visible="true" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
    </div>
    <div class="g12" id="divicerik" runat="server" visible="false">
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            Kaydedildi...</div>
        <div id="divduzen" runat="server" visible="false" class="alert success">
            Düzenlendi...</div>
        <table id="TblIcerik" class="padding" runat="server">
            <tr>
                <td width="200">
                    Adı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbad" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbad"
                        Display="None" ErrorMessage="Başlık bölümü boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Özet
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbolcu" runat="server" Height="100px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Detay
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server"></CKEditor:CKEditorControl>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CKEditorControl1"
                        Display="Dynamic" ErrorMessage="Detay bölümü boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="idcat" runat="server" visible="false">
                <td width="150">
                    Cat
                </td>
                <td width="10">
                </td>
                <td width="300">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                     <asp:Literal ID="ltrcat" runat="server" Visible="false"></asp:Literal>
                </td>
            </tr>
            <tr  id="idbrosur" runat="server" visible="false">
                <td width="150">
                    Broşür
                </td>
                <td width="10">
                </td>
                <td width="300">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:Literal ID="ltrbrosur" runat="server" Visible="false"></asp:Literal>
                </td>
            </tr>
            <tr id="tranmaboyut" runat="server" visible="false">
                <td width="200">
                    Anma Boyutu
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbanma" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Title
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbtitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Description
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbdess" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Keyword
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbkey" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Sıra No
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbsira" Text="9999" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Kategori Adı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
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
                <td width="600">
                    <asp:CheckBox ID="chkAktif" runat="server" Checked="true" />
                </td>
            </tr>
            <tr id="vitrin" runat="server" visible="false">
                <td width="200">
                    Anasayfa Vitrin
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:CheckBox ID="chkAnasayfa" runat="server" Checked="true" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 230px;">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"
                        CssClass="button blue" ValidationGroup="aaa" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Düzenle" CssClass="button blue" OnClick="BtnUpdate_Click"
                        Visible="False" ValidationGroup="aaa" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="aaa" />
                </td>
            </tr>
        </table>
    </div>
    <div class="g4" id="divkategori" runat="server">
        <table>
            <tr>
                <td>
                    <h3>
                    Kategoriler</h1>
                </td>
                <td>
                    <input type="button" value="Geri" onclick="history.go(-1)">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <%-- <asp:Repeater ID="RepaterKategori" runat="server" 
            onitemcommand="RepaterKategori_ItemCommand">
    <HeaderTemplate>
    <tr><td></td><td><b>Başlık</b></td><td width="3">|</td><td><b>Seç</b></td></tr>
    </HeaderTemplate>
    <ItemTemplate>
  <tr><td><asp:RadioButton runat="server" GroupName="aa" ValidationGroup="ee" /> </td><td><a href="icerikEkle.aspx?katid=<%#Eval("KATID") %>" class="list" ><%#Eval("KATADI") %></a></td><td width="3">|</td><td><a href="icerikEkle.aspx?katid=<%#Eval("KATID") %>" class="list" >Seç</a></td>
  </tr>
    </ItemTemplate>
    </asp:Repeater>--%>
                        <tr>
                            <td align="left">
                                <asp:RadioButtonList CssClass="radio" ID="rdkat" runat="server">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="BtnSec" runat="server" Text="Seç" OnClick="BtnSec_Click" />
                                <asp:Button ID="Btnileri" runat="server" Text="Alt Kategorileri" OnClick="Btnileri_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
</asp:Content>
