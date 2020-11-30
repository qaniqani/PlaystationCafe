<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="YorumListesi.aspx.cs" Inherits="Yonetim_YorumListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
       
                    <div class="g12">
                      <table class="padding">
                            
                            
                            <tr><td style="width:150px">Ziyaretçi Defteri Türü</td><td  style="width:10px">:</td><td  style="width:580px">   <asp:DropDownList ID="drpYorumTur" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpYorumTur_SelectedIndexChanged">
                                <asp:ListItem Value="0">Yeni Yorumlar</asp:ListItem>
                                <asp:ListItem Value="1">Onaylı Yorumlar</asp:ListItem>
                                <asp:ListItem Value="2">Onaysız Yorumlar</asp:ListItem>
                            </asp:DropDownList></td></tr>
                                                        <tr><td colspan="3" >
                                                        
                                                           <asp:Button ID="BtnOnayla" runat="server" CssClass="button blue" 
                            Text="Onayla" onclick="BtnOnayla_Click" />
                                                            <asp:Button
                            Visible="false" ID="BtnOnayKaldir" runat="server" CssClass="button blue" 
                            Text="Pasif Et" onclick="BtnOnayKaldir_Click" />
                                                        </td></tr>
                            
                            </table>
                             
                     
                          
                     
                        
                                    
                    </div>
               
                         <div class="g12">
                         
                         <table class="datatable">
                        <thead>
                            <tr>
                                <th>
                                    Seç
                                </th>
                                <th>
                                    Başlık
                                </th>
                                 <th>
                                    İçerik
                                </th>
                                <th>
                                    Yorum
                                </th>
                                <th>
                                    Url
                                </th>
                                  <th>
                                   E-Mail
                                </th>
                                <th>
                                    Tarih
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
                                        <td width="50">
                                            <asp:CheckBox ToolTip='<%#Eval("YORUMID")%>' ID="chksec" runat="server" />
                                        </td>
                                        <td width="60">
                                            <%#Eval("YORUMBASLIK")%>
                                        </td>
                                          <td width="50">
                                            <%#IcerikGetir(Eval("YORUMICERIKID"))%>
                                        </td>
                                        <td width="150">
                                            <%#Eval("YORUMDETAY")%>
                                        </td>
                                        <td width="70">
                                            <%#Eval("YORUMURL")%>
                                        </td>
                                               <td class="c" width="50">
                                            <%#Eval("YORUMEMAIL")%>
                                        </td>
                                        <td class="c" width="50">
                                            <%#Eval("YORUMTARIH")%>
                                        </td>
                                        <td width="40">
                                            <asp:LinkButton style="position:relative;top:9px" ID="BtnSil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                                runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                                CommandArgument='<%#Eval("YORUMID")%>' CommandName="Sil" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                         </div>   
                       
    
    </div>
</asp:Content>
