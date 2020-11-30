<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="SiteAyar.aspx.cs" Inherits="Yonetim_SiteAyar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
     <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table class="padding">
          
            
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
                  Analytics Kodu
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    <asp:TextBox ID="tbanalytics" runat="server" Height="80px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr id="trdil" runat="server" visible="false">
                <td width="150" >
                    Varsayılan Dil
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    
                       <asp:DropDownList ID="dpvarsayilan" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                 
                </td>
            </tr>
            <tr>
                <td width="150">
                    E-Posta
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                    
                    <asp:TextBox ID="Tbeposta" runat="server"></asp:TextBox>
                 
                </td>
            </tr>
             <tr>
                <td width="150">
                    Şifre
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                  
                       <asp:TextBox ID="tbsifre"  runat="server"></asp:TextBox>
                    
                </td>
            </tr>
               <tr>
                <td width="150">
                    E-Posta SMTP
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                  
                       <asp:TextBox ID="tbsmtp"  runat="server" ></asp:TextBox>
              
                </td>
            </tr>
                           <tr>
                <td width="150">
                    E-Posta SMTP Port
                </td>
                <td width="10">
                    :
                </td>
                <td width="300">
                   
                       <asp:TextBox ID="tbport"  runat="server" ></asp:TextBox>
                  
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left:315px">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"
                        CssClass="button blue" ValidationGroup="vvv" />
                   
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="vvv" />
                   
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
