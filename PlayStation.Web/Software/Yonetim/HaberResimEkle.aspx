<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="HaberResimEkle.aspx.cs" Inherits="Yonetim_HaberResimEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="g12" id="divicerik" runat="server">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table class="padding">
          
            <tr>
                <td width="200">
                    İçerik
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                        <asp:DropDownList ID="drpUrun" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpUrun_SelectedIndexChanged">
                        </asp:DropDownList>
                   
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
                  
                        <asp:TextBox ID="tbsira" Text="9999" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Resim
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:FileUpload ID="FileUploadResim" runat="server" />
                </td>
            </tr>
                <tr>
                <td width="200">
                   Temsili Foto
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                   <asp:CheckBox ID="chktemsili" runat="server"  Checked="True"  />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left:235px">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" CssClass="button blue" OnClick="BtnKaydet_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="g12"><h4>Ürün Resimleri</h4></div>
    <div class="g12">
    <table class="datatable">
                        <thead>
                            <tr>
                                <th width="30">
                                    Id
                                </th>
                                <th width="100">
                                    Dosya İsmi
                                </th>
                                <th width="50">
                                    Tarih
                                </th>
                                <th width="100">
                                    Temsili Foto
                                </th>
                                <th width="40">
                                    Sil
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterUrun" runat="server" OnItemCommand="RepeaterUrun_ItemCommand">
                                <ItemTemplate>
                                    <tr class='gradeX'>
                                        <td valign="middle">
                                       <span style="position:relative;top:-35px">       <%#Eval("RESID")%></span>
                                        </td>
                                        <td valign="middle">
                                        <img style="position:relative;top:9px" src='<%#"../PhotoResize.aspx?Tur=Fix&genislik=150&yukseklik=70&src=images/Haber/"+Eval("RESIM")%>'  border="0" />
                                 
                                        </td>
                                        <td valign="middle">
                                            <span style="position:relative;top:-35px">  <%#Eval("TARIH")%></span>
                                        </td>
                                        <td class="c" valign="middle">
                                     
                                             <span style="position:relative;top:-35px">   <%#Convert.ToBoolean(Eval("TEMSIL")) == true ? "Aktif" : "Pasif"%></span>
                                        </td>
                                        <td valign="middle">
                                            <asp:LinkButton style="position:relative;top:-26px" ID="BtnSil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                                runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                                CommandArgument='<%#Eval("RESID")%>' CommandName="Sil" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
    </div>
</asp:Content>

