<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="SliderEkle.aspx.cs" Inherits="Yonetim_SliderEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12" id="divicerik" runat="server">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table class="padding">
            <tr id="trkk" runat="server" visible="false">
                <td width="200">
                    Slider Türü
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:DropDownList ID="DrpTur" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDil_SelectedIndexChanged">
                        <asp:ListItem Value="1">Ana Sayfa Slider</asp:ListItem>
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
                    <asp:TextBox ID="tbad" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbad"
                        Display="None" ErrorMessage="Başlık boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="trslogan" runat="server" visible="false">
                <td width="200">
                    Açıklama
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbaciklama" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbaciklama"
                        Display="None" ErrorMessage="Açıklama boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="idtraciklama" runat="server" visible="false">
                <td width="200">
                    Kısa Açıklama
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbozet" runat="server" Height="60px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbozet"
                        Display="None" ErrorMessage="Kısa açıklama boş geçilemez" ValidationGroup="aaa">*</asp:RequiredFieldValidator>
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
                    <asp:TextBox ID="tblink" Text="#" runat="server"></asp:TextBox>
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
            <tr id="trresim" runat="server" visible="false">
                <td width="200">
                </td>
                <td width="10">
                </td>
                <td width="600">
                    <img id="imgsrc" runat="server" border="0" width="150" />
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
                    Durum
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:CheckBox ID="chkdurum" runat="server" Checked="true" OnCheckedChanged="chkdurum_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 235px">
                    <asp:Button ID="BtnKaydet" runat="server" ValidationGroup="aaa" Text="Kaydet" CssClass="button blue"
                        OnClick="BtnKaydet_Click" />
                    <asp:Button ID="BtnUpdate" runat="server" ValidationGroup="aaa" Text="Güncelle" CssClass="button blue"
                        OnClick="BtnUpdate_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="aaa" />
                </td>
            </tr>
        </table>
    </div>
    <div class="g12">
        <h3>
            Slider</h3>
    </div>
    <div class="g12">
        <table class="datatable">
            <thead>
                <tr>
                    <th width="150">
                        Başlık
                    </th>
                    <th width="100">
                        Resim
                    </th>
                    <th width="150">
                        Link
                    </th>
                    <th width="50">
                        Durum
                    </th>
                    <th width="40">
                        Düzen
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
                                <span style="position: relative; top: -35px">
                                    <%#Eval("SLIDERBASLIK")%></span>
                            </td>
                            <td valign="middle">
                                <img src='<%#"../PhotoResize.aspx?Tur=Fix&genislik=150&yukseklik=100&src=images/Slider/"+Eval("SLIDERRESIM")%>'
                                    width="150" height="100" style="position: relative; top: 9px" border="0" />
                            </td>
                            <td valign="middle">
                                <span style="position: relative; top: -35px">
                                    <%#Eval("SLIDERLINK")%></span>
                            </td>
                            <td valign="middle">
                                <span style="position: relative; top: -35px">
                                    <%#Convert.ToBoolean(Eval("SLIDERDURUM")) == true ? "Aktif" : "Pasif"%></span>
                            </td>
                            <td valign="middle">
                                <asp:LinkButton Style="position: relative; top: -28px" ID="BtnDuzen" runat="server"
                                    Text="<img src='css/images/icons/light/create_write.png' border='0' width='30'/>"
                                    CommandArgument='<%#Eval("SLIDERID")%>' CommandName="Duzen" />
                            </td>
                            <td valign="middle">
                                <asp:LinkButton Style="position: relative; top: -26px" ID="BtnSil" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                    CommandArgument='<%#Eval("SLIDERID")%>' CommandName="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
