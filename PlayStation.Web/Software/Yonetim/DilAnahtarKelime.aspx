<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="DilAnahtarKelime.aspx.cs" Inherits="Yonetim_DilAnahtarKelime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 46px;
        }
        .style2
        {
            text-align: center;
            height: 46px;
        }
    </style>
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
                Key Başlığı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
               <asp:TextBox ID="TbAd" runat="server"></asp:TextBox>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TbAd" Display="None" ErrorMessage="Başlık boş geçilemez" 
                        ValidationGroup="aeae">*</asp:RequiredFieldValidator>
               
                </td>
            </tr>
       
               <tr>
                <td width="200">
                 Durum
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                  <div style="float:left"><asp:CheckBox ID="chkaktif" runat="server"  Checked="True"  /></div>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                     <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" 
                            CssClass="button blue" onclick="BtnKaydet_Click1" />
                        <asp:Button ID="BtnDuzen" runat="server" Text="Düzenle" 
                         CssClass="button blue" onclick="BtnDuzen_Click" />
                    
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="aeae" />
                </td>
            </tr>
             <tr><td colspan="3" align="left">Dil Anahtarları</td></tr>
           
            <tr><td colspan="3">
           
                 <table class="datatable">
            <thead>
                <tr>
                    <th>
                        Dil Key
                    </th>
                    <th>
                       Durum
                    </th>
                 
                    <th>
                        Düzenle
                    </th>
                    <th>
                       Aktif/Pasif
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterUrun" runat="server" OnItemCommand="RepeaterUrun_ItemCommand">
                    <ItemTemplate>
                        <tr class='gradeX'>
                            <td valign="middle">
                                <%#Eval("KEYNAME")%>
                            </td>
                            <td valign="middle">
                

                              <%#Convert.ToBoolean(Eval("DURUM")) == true ? "Aktif" : "Pasif"%>
                            </td>
                            <td class="c" valign="middle">
                                <asp:LinkButton ID="BtnDuzen" style="position:relative;top:7px" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/create_write.png' border='0' width='30'/>"  CommandArgument='<%#Eval("KEYID")%>'
                                    CommandName="Duzen" /> 
                            </td>
                           
                            <td valign="middle">
                                <asp:LinkButton ID="BtnSil" style="position:relative;top:9px" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"  CommandArgument='<%#Eval("KEYID")%>'
                                    CommandName="Sil" />
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

