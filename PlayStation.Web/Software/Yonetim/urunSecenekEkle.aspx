<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="urunSecenekEkle.aspx.cs" Inherits="Yonetim_urunSecenekEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12" id="divicerik" runat="server">
      <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table class="padding">
            <tr>

                <td colspan="3" >
                <table class="datatable">
                        <thead>
                            <tr>
                                <th>
                                    Ürün Adı
                                </th>
                                
                          
                                <th>
                                    Kategori Ekle
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterUrun" runat="server" 
                                OnItemCommand="RepeaterUrun_ItemCommand" oninit="RepeaterUrun_Init">
                                <ItemTemplate>
                                    <tr class='gradeX'>
                                        <td valign="middle">
                                            <%#Eval("URUNADI")%>
                                        </td>
                                      
                                       
                                        <td valign="middle" align="center" width="70">
                                            <a href="urunSecenekEkle.aspx?urunid=<%#Eval("URUNID")%>">Ekle</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                  
                </td></tr>
                </table>
                 <table class="padding" id="tblsecenekler" runat="server" visible="false">
            <tr>
                <td width="150">
                    Ürün
                </td>
                <td width="10">
                    :
                </td>
                <td width="580">
                <asp:Literal ID="ltrurun" runat="server" Text="Ürün Seçilmedi"></asp:Literal>
                </td>
                
                </tr>
            <tr>
                <td width="150">
                    Seçenekler
                </td>
                <td width="10">
                    :
                </td>
                <td width="580">
                  
                        <asp:Repeater ID="RepeaterSecenekler" runat="server">
                            <ItemTemplate>
                               <div style="background:#ddd; height:30px; padding-left:10px; line-height:30px;">
                                        <b>
                                            <%#Eval("OZELLIKBASLIK")%></b>
                                    </div>
                                      
                                            <div style="border:none;" class="cre-01">
                                            <%--<asp:RadioButtonList DataSource='<%#AltSecenekGetir(Eval("OZELLIKID")) %>' RepeatColumns="4"   RepeatDirection="Horizontal" DataValueField="OZELLIkID" ID="RadioBtnList1" runat="server" DataTextField="OZELLIKBASLIK"></asp:RadioButtonList>--%>
                                            <asp:CheckBoxList DataSource='<%#AltSecenekGetir(Eval("OZELLIKID")) %>'  RepeatDirection="Vertical"  DataValueField="OZELLIkID" ID="ChkList" runat="server" DataTextField="OZELLIKBASLIK"></asp:CheckBoxList>
                                           
                                            </div>
                                          
                        
                            </ItemTemplate>
                        </asp:Repeater>
                 
                </td>
            </tr>
            <tr><td colspan="3"  style="padding-left:200px;"><asp:Button ID="BtnKaydet" 
                    Text="Seçilileri Kaydet" runat="server" CssClass="button blue" 
                    onclick="BtnKaydet_Click" /></td></tr>
        </table>
    </div>
</asp:Content>
