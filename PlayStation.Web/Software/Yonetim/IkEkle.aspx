<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="IkEkle.aspx.cs" Inherits="Yonetim_IkEkle" %>

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
                    Referans Numarası
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbreferans" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbreferans"
                        Display="None" ErrorMessage="Referans numarası boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
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
                    <asp:TextBox ID="tbdetay" runat="server" Height="80px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbdetay"
                        Display="None" ErrorMessage="Detay bölümü boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
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
