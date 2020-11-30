<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="AlbumResimEkle.aspx.cs" Inherits="Yonetim_AlbumResimEkle" %>
    
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12" id="divicerik" runat="server">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table class="padding">
            
            <tr id="trbelge" runat="server" visible="true">
                <td width="200">
                    Ana Logo
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:DropDownList ID="drpAlbum" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpUrun_SelectedIndexChanged">
              
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="200">
                   Başlık
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbbaslik" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tbbaslik" Display="None" ErrorMessage="Başlık boş geçilemez" 
                        ValidationGroup="aaa">*</asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr id="trlinK" runat="server" visible="false">
                <td width="200">
                    Link
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tblink" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="tblink" Display="None" ErrorMessage="Link boş geçilemez" 
                        ValidationGroup="aaa">*</asp:RequiredFieldValidator>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tbsira" Display="None" ErrorMessage="Sıra boş geçilemez" 
                        ValidationGroup="aaa">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="200">
                   Logo
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
                    Durum
                </td>
                <td width="10">
                    :
                </td>
                <td width="600" align="left">
                    <asp:CheckBox ID="chkdurum" runat="server"  Checked="True"  />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 235px">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" CssClass="button blue" OnClick="BtnKaydet_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="aaa" />
                </td>
            </tr>
        </table>
        <div class="g12">
            <h4>
               Galeri Resimleri</h4>
        </div>
        <div class="g12">
            <table class="datatable">
                <thead>
                    <tr>
                        <th width="40">
                            Id
                        </th>
                        <th width="80">
                          Başlık
                        </th>
                        <th width="100">
                        Resim
                        </th>
                        <th width="50">
                            Tarih
                        </th>
                        <th width="40">
                            Durum
                        </th>
                        <th  width="40">
                            Sil
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RepeaterResim" runat="server" OnItemCommand="RepeaterUrun_ItemCommand">
                        <ItemTemplate>
                            <tr class='gradeX'>
                                <td valign="middle">
                                    <span style="position:relative;top:-35px">   <%#Eval("RESID")%></span>
                                </td>
                                <td valign="middle">

                                <%#Eval("RESBASLIK") %>
                                  
                                </td>
                                   <td valign="middle">

                                <img src='<%#"../PhotoResize.aspx?Tur=Crop&genislik=100&yukseklik=100&src=images/Album/"+Eval("RESYOL")%>' width="100" height="100" style="position:relative;top:9px"  border="0" />
                                  
                                  
                                </td>
                                <td valign="middle">
                                  <span style="position:relative;top:-35px">   <%#Eval("RESTARIH")%></span>
                                </td>
                                <td class="c" valign="middle">
                                <span style="position:relative;top:-35px">    <%#Convert.ToBoolean( Eval("RESDURUM"))==true?"Aktif":"Pasif"%></span>
                                </td>
                                <td valign="middle">
                                    <asp:LinkButton ID="BtnSil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                        runat="server" style="position:relative;top:-26px" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                        CommandArgument='<%#Eval("RESID")%>' CommandName="Sil" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
