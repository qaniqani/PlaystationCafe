<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="SorularListesi.aspx.cs" Inherits="Yonetim_SorularListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
       
                    <div class="g12">
                      <table class="padding">
                            
                            
                            <tr><td style="width:150px;">Soru Türü</td><td style="width:10px;">:</td><td style="width:580px;">   <asp:DropDownList ID="drpYorumTur" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpYorumTur_SelectedIndexChanged">
                                <asp:ListItem Value="0">Yeni Sorular</asp:ListItem>
                                <asp:ListItem Value="1">Onaylı Sorular</asp:ListItem>
                                <asp:ListItem Value="2">Onaysız Sorular</asp:ListItem>
                            </asp:DropDownList></td></tr>
                                                        <tr><td colspan="3">
                                                        
                                                    <asp:Button ID="BtnDuzenle" runat="server" CssClass="button blue" 
                            Text="Düzenle" onclick="BtnDuzenle_Click"/>       
                                                            <asp:Button ID="BtnOnayla" runat="server" CssClass="button blue" 
                            Text="Cevaplandı Olarak İşaretle" onclick="BtnOnayla_Click" />
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
                                <th  width="30">
                                    Seç
                                </th>
                                   <th  width="200">
                                    Cevap
                                </th>
                                <th  width="70">
                                    Başlık
                                </th>
                                <th  width="200">
                                    Yorum
                                </th>
                               
                                <th  width="100">
                               E-Posta
                                </th>
                                
                                <th  width="50">
                                    Tarih
                                </th>
                                <th  width="50">
                                    Sil
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterUrun" runat="server" OnItemCommand="RepeaterUrun_ItemCommand">
                                <ItemTemplate>
                                    <tr class='gradeX'>
                                        <td style="vertical-align:middle;">
                                            <asp:CheckBox ToolTip='<%#Eval("YORUMID")%>' ID="chksec" runat="server" />
                                        </td>
                                        <td style="vertical-align:middle;">
                                           <asp:TextBox id="tbyorum" Text='<%#Eval("YORUMCEVAP")%>' runat="server" Width="180" TextMode="MultiLine" Height="100"></asp:TextBox>
                                        </td>
                                        <td style="vertical-align:top;line-height:20px;">
                                            <%#Eval("YORUMBASLIK")%>
                                        </td>
                                        <td style="vertical-align:top;line-height:20px;">
                                            <%#Eval("YORUMDETAY")%>
                                        </td>
                                       
                                            <td class="c" style="vertical-align:top;line-height:20px;">
                                            <%#Eval("YORUMEMAIL")%>
                                        </td>
                                        <td class="c" style="vertical-align:top;line-height:20px;">
                                            <%#Eval("YORUMTARIH")%>
                                        </td>
                                        <td style="vertical-align:top;">
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
