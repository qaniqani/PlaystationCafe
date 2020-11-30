<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="formDetay.aspx.cs" Inherits="Yonetim_formDetay" %>

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
            <tr runat="server" visible="false">
                <td width="200">
                    Firma
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbfirma" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Ad Soyadı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="TbAdSoyad" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" visible="false">
                <td width="200">
                    Telefon
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="TbTel" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    GSM
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="TbGsm" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" visible="false">
                <td width="200">
                    E-Posta
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="TbEposta" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" visible="false">
                <td width="200">
                    Adres
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbadres" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" visible="false">
                <td width="200">
                    Şehir
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbsehir" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" visible="false">
                <td width="200">
                    Kişi Tür
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbkisitur" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" visible="false">
                <td width="200">
                    Posta Kodu
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbpostakodu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Konu
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbkonu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Mesaj
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbmesaj" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Ip Adres
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbipadres" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Tarih
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbtarih" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
</asp:Content>
