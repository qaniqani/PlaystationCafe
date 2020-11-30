<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="UyeGuncelle.aspx.cs" Inherits="Yonetim_UyeGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="g12" id="divicerik" runat="server">
     <div id="divhata" runat="server" visible="false" class="alert warning"><asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
<div id="divkaydet" runat="server" visible="false" class="alert success">Kaydedildi...</div>
<div id="divduzen" runat="server" visible="false" class="alert success">Düzenlendi...</div>
        <table id="TblIcerik" runat="server" class="padding">
            <tr>
                <td width="200">
                  Adı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                 <asp:TextBox ID="TbAd" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TbAd" Display="None" 
                        ErrorMessage="Adı boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td width="200">
                 Soyadı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                   <asp:TextBox ID="TbSoyad" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TbSoyad" Display="None" 
                        ErrorMessage="Soyadı boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
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
                    <asp:TextBox ID="TbGsm" runat="server"  ></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td width="200">
                    E-Posta
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                 <asp:TextBox ID="TbEposta" runat="server"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TbEposta"  Display="None" 
                        ErrorMessage="EPosta bölümü geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="200">
                   Parola
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="TbParola" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TbParola"  Display="None" 
                        ErrorMessage="Parola bölümü geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="200">
                   Aktivasyon Durumu
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                <div style="float:left">
                   <asp:CheckBox ID="chkaktivasyondurum" runat="server" /></div>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Üyelik Durumu
                </td>
                <td width="10">
                    :
                </td>
                <td width="600"><div style="float:left">
                    <asp:CheckBox ID="chkdurum" runat="server" /></div>
                </td>
            </tr>
            <tr>
                <td width="200">
                   Adres
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="TbAdres" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td colspan="3" style="padding-left:235px">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"
                        CssClass="button blue" ValidationGroup="aaa" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Düzenle" CssClass="button blue" OnClick="BtnUpdate_Click"
                        Visible="False" ValidationGroup="aaa" />
           
            
            
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True"  ShowSummary="False" ValidationGroup="aaa" />
           
            
            
                </td>
            </tr>
        
        </table>
       
    </div>
    
    <div class="clear">
    </div>
</asp:Content>

