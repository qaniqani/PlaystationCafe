<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="DilTitleEkle.aspx.cs" Inherits="Yonetim_DilTitleEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="g12" id="divicerik" runat="server">
   <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table >
           
        
               <tr>
                <td width="200">
                 Dil
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                  <div style="float:left"><asp:DropDownList ID="drpdil" runat="server" 
                          onselectedindexchanged="drpdil_SelectedIndexChanged"></asp:DropDownList></div>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                     <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" 
                            CssClass="button blue" onclick="BtnKaydet_Click1" />
                    
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="aeae" />
                </td>
            </tr>
             <tr><td colspan="3" align="left">Dil Anahtarları</td></tr>
           
            <tr><td colspan="3">
           
                 <table >
            <thead>
                <tr>
                    <th>
                        Dil Key
                    </th>
                    <th>
                       Başlık
                    </th>
                 
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterUrun" runat="server">
                    <ItemTemplate>
                        <tr >
                            <td valign="middle">
                                <%#Eval("KEYNAME")%>
                            </td>
                            <td valign="middle">
                  
                  <asp:TextBox ID="tbdeneme" runat="server" ToolTip='<%#Eval("KEYID") %>' Text='<%#KeyGetir(Eval("KEYID")) %>'></asp:TextBox>
                            </td>
                           
                          
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
            
          
            
            </td></tr>
   
        </table>
      
    </div>
</asp:Content>

