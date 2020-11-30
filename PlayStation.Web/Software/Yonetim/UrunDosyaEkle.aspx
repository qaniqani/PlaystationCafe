<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="UrunDosyaEkle.aspx.cs" Inherits="Yonetim_UrunDosyaEkle" %>

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
                <td width="200">
                    Ürün
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
                    Başlık
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbbaslik" runat="server"></asp:TextBox>
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
                <td colspan="3" style="padding-left: 235px;">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" CssClass="button blue" OnClick="BtnKaydet_Click" />
                </td>
            </tr>
        </table>
        <div class="g12">
            <h4>
               Autocad Dosyaları</h4>
        </div>
        <div class="g12">
            <table class="datatable">
                <thead>
                    <tr>
                      <th>
                            Başlık
                        </th>
                        <th>
                            Dosya
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
                               <td valign="middle">
                                    <%#Eval("BASLIK")%>
                                </td>
                                <td valign="middle">
                                    <%#Eval("DOSYA")%>
                                </td>
                                <td valign="middle">
                                    <span>
                                        <%#Eval("TARIH")%></span>
                                </td>
                                <td valign="middle">
                                    <asp:LinkButton Style="position: relative; top: 9px" ID="BtnSil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                        runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                        CommandArgument='<%#Eval("DOSID")%>' CommandName="Sil" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
