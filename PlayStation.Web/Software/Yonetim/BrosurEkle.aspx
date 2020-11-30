<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="BrosurEkle.aspx.cs" Inherits="Yonetim_BrosurEkle" %>

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
                    Başlık
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbad" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbad"
                        Display="None" ErrorMessage="Başlık boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
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
                <td colspan="3" style="padding-left: 235px">
                    <asp:Button ID="BtnKaydet" runat="server" ValidationGroup="aaa" Text="Kaydet" CssClass="button blue"
                        OnClick="BtnKaydet_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="aaa" />
                </td>
            </tr>
        </table>
    </div>
    <div class="g12">
        <h3>
            Broşürler</h3>
    </div>
    <div class="g12">
        <table class="datatable">
            <thead>
                <tr>
                    <th>
                        Broşür Adı
                    </th>
                    <th>
                        Dosya Yolu
                    </th>
                    <th width="50">
                        Sil
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterUrun" runat="server" OnItemCommand="RepeaterUrun_ItemCommand">
                    <ItemTemplate>
                        <tr class='gradeX'>
                            <td valign="middle">
                                <%#Eval("DOSYAADI")%>
                            </td>
                            <td valign="middle">
                                <a href='<%#"/images/Dosya/"+Eval("DOSYAYOLU")%>' target="_blank">
                                    <%#"/images/Dosya/"+Eval("DOSYAYOLU")%></a>
                            </td>
                            <td valign="middle">
                                <asp:LinkButton ID="BtnSil" Style="position: relative; top: 9px" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                    CommandArgument='<%#Eval("DOSYAID")%>' CommandName="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
