<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Yonetim/Admin.master"
    AutoEventWireup="true" CodeFile="IletisimEkle.aspx.cs" Inherits="Yonetim_IletisimEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table>
            <tr>
                <td width="200">
                    Başlık
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbbaslik" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Adres
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbadres" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="tr2" runat="server" visible="true">
                <td width="200">
                    Telefon
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbtel" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="tr4" runat="server" visible="false">
                <td width="200">
                    Call Center
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbtel2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="tr3" runat="server" visible="true">
                <td width="200">
                    Faks
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbfaks" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="tr1" runat="server" visible="false">
                <td width="200">
                    GSM
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="Tbgsm" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    E-Posta
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbeposta" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Goole Maps
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbmaps" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="trface" runat="server" visible="true">
                <td width="200">
                    Facebook Link
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbfacebook" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="trtwitter" runat="server" visible="true">
                <td width="200">
                    Twitter Link
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbtwitter" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="googlelink" runat="server" visible="false">
                <td width="200">
                    Google Link
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbgoogle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="linkedin" runat="server" visible="true">
                <td width="200">
                    Linkedin
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tblinkedin" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr id="Tr5" runat="server" visible="true">
                <td width="200">
                   Yenibiris.com
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbyenibiris" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"
                        CssClass="button blue" ValidationGroup="vvv" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="vvv" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
