<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="SloganEkle.aspx.cs" Inherits="Yonetim_SloganEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="g12" id="divicerik" runat="server">
   <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table class="padding" >
           
          
            <tr>
                <td width="200">
                  Baslık
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                        <asp:TextBox ID="tbbaslik" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Başlık bölümü boş geçilemez" ValidationGroup="aa" 
                            ControlToValidate="tbbaslik" Display="None">*</asp:RequiredFieldValidator>
                </td>
            </tr>
              <tr>
                <td width="200">
                  Link
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                        <asp:TextBox ID="tblink" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="Link bölümü boş geçilemez" ValidationGroup="aa" 
                            ControlToValidate="tblink" Display="None">*</asp:RequiredFieldValidator>
                </td>
            </tr>
                        <tr>
                <td width="200">
                  Sıra
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                       <asp:TextBox Text="9999" ID="tbsira" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ControlToValidate="tbsira" Display="None" ErrorMessage="Sıra boş geçilemez" 
                           ValidationGroup="aa">*</asp:RequiredFieldValidator>
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
                   <asp:CheckBox ID="chkdurum" runat="server" />
                </td>
            </tr>

            <tr>
                <td colspan="3" style="padding-left:235px;">
                 <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" CssClass="button blue" 
                        onclick="BtnKaydet_Click" ValidationGroup="aa" />
                        <asp:Button ID="BtnUpdate" runat="server" Text="Düzenle" 
                        CssClass="button blue" onclick="BtnUpdate_Click"/>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="aa" />
                </td>
            </tr>
             
             
             
             
             
 
   
        </table>
        <div class="g12"><h4>Linkler</h4></div>

        <div class="g12">  <table class="datatable">
            <thead>
                <tr>
               
                    <th>
                       Başlık
                    </th>
                    <th>
                        Tarih
                    </th>
                    <th>
                        Durum
                    </th>
                    <th>
                        Düzenle
                    </th>
                    <th>
                        Sil
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterUrun" runat="server" OnItemCommand="RepeaterUrun_ItemCommand">
                    <ItemTemplate>
                        <tr class='gradeX'>
                            
                            <td valign="middle">
                               <%#Eval("SLOGANTEXT")%>
                            </td>
                            <td valign="middle">
                               <span>   <%#Eval("SLOGANTARIH")%></span>
                            </td>
                            <td valign="middle">
                               <span> 
                                 <%#Convert.ToBoolean(Eval("SLOGANDURUM")) == true ? "Aktif" : "Pasif"%>
                               </span>
                            </td>
                            <td valign="middle">
                             <a href="SloganEkle.aspx?Sln=<%#Eval("SLOGANID")%>">
                                    <img src="css/images/icons/light/create_write.png" border="0" width="25" style="position:relative;top:7px" /></a>
                            </td>
                            <td valign="middle">
                                <asp:LinkButton style="position:relative;top:9px" ID="BtnSil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"  CommandArgument='<%#Eval("SLOGANID")%>'
                                    CommandName="Sil" />
                            </td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table></div>
      
    </div>
</asp:Content>

