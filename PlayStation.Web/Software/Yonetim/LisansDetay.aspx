<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="LisansDetay.aspx.cs" Inherits="Yonetim_LisansDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="g12">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
    </div>
    <div class="g12">
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table id="TblIcerik" runat="server" class="padding">
            <tr>
                <td width="200">
                    Yetkili Ad Soyad
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtNameSurname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    TC No
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtTCNr" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    E-Mail
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    GSM No
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtGSM" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Firma Adı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    İl
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    İlçe
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Adres Detayı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtAddressDetail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Vergi Dairesi
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtTaxOffice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Vergi No
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtTaxNR" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Lisans Key
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtLicenceKey" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Kullanıcı Sayısı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtUserCount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Lisans Baş. Tarihi
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtLicenceStartDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Lisans Bit. Tarihi
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtLicenceEndDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Lisans Güncelleme Sıklığı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtUpdateDayCount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Anakart Seri No
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtBoardSerialNR" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    CPU Seri No
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtCPUSerialNR" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    HDD Seri No
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtHDDSerialNR" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Kayıt Tarihi
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtSaveDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Demo mu?
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:CheckBox ID="cbDemo" runat="server"/>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Aktif/ Pasif
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:CheckBox ID="cbActive" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 235px">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"
                        CssClass="button blue" ValidationGroup="iii" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Düzenle" CssClass="button blue" OnClick="BtnUpdate_Click"
                        Visible="False" ValidationGroup="iii" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="iii" />
                </td>
            </tr>
        </table>
    </div>
    <div class="clear"></div>
</asp:Content>

