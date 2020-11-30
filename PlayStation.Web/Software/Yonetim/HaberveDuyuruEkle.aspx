<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="HaberveDuyuruEkle.aspx.cs" Inherits="Yonetim_HaberveDuyuruEkle" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12" id="divicerik" runat="server">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            Kaydedildi...</div>
        <div id="divduzen" runat="server" visible="false" class="alert success">
            Düzenlendi...</div>
        <table id="TblIcerik" runat="server" class="padding">
            <tr id="trtur" runat="server" visible="false">
                <td width="200">
                    İçerik Türü
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:DropDownList ID="drptur" runat="server" OnSelectedIndexChanged="drptur_SelectedIndexChanged">
                     <asp:ListItem Value="1">Haber</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="tr1" runat="server" visible="false">
                <td width="200">
                    Haber Turu
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:DropDownList ID="DrpHaberTur" runat="server" OnSelectedIndexChanged="drptur_SelectedIndexChanged">
                        <asp:ListItem Value="1">Alt Duyuru</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
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
                    Kısa Özet
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbozet" runat="server" Height="80px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbozet"
                        Display="None" ErrorMessage="Özet bölümü boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
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
                        Display="None" ErrorMessage="Detay bölümü boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
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
            <tr id="trmanset" runat="server" visible="false">
                <td width="200">
                    Manşet
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
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
                    <asp:CheckBox ID="chkAktif" runat="server" Checked="True" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 235px">
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
    <div class="clear">
    </div>
</asp:Content>
