<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="reklam.aspx.cs" Inherits="Yonetim_reklam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function selected() {
            var values = $("#ddlAdverType").val();
            if (values == "Ozel") {
                $("#txtAdverCode").hide();
                $("#txtAdverLink").show();
                $("#txtAdverUpload").show();
            }
            else {
                $("#txtAdverCode").show();
                $("#txtAdverLink").hide();
                $("#txtAdverUpload").hide();
            }
        }
        $(document).ready(function () {
            $("#ddlAdverType").change(function () {
                selected();
            });
        });

        window.onload = selected;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="g12">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
    </div>
    <div class="g12">
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table id="TblIcerik" runat="server" class="padding">
            <tr>
                <td width="200">
                    Reklam Adı</td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtAdverName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Reklam Tipi</td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:DropDownList ID="ddlAdverType" runat="server" Width="593px" ClientIDMode="Static">
                        <asp:ListItem Value="Ozel">Özel</asp:ListItem>
                        <asp:ListItem>Google</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Reklam Linki</td>
                <td width="10">
                    &nbsp;</td>
                <td width="600">
                    <asp:TextBox ID="txtAdverLink" runat="server" ClientIDMode="Static"></asp:TextBox>
                &nbsp;http://www.link.com</td>
            </tr>
            <tr>
                <td width="200">
                    Reklam Kodu</td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="txtAdverCode" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Reklam Yükle</td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:FileUpload ID="txtAdverUpload" runat="server" ClientIDMode="Static" />
                </td>
            </tr>
            <tr>
                <td width="200">
                    Reklam GUID</td>
                <td width="10">
                    :</td>
                <td width="600">
                    <asp:TextBox ID="txtAdverGuid" runat="server"></asp:TextBox>
                    <asp:Literal ID="ltLnk" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Aktif/ Pasif
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:CheckBox ID="cbActive" runat="server" Checked="True" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 235px">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click" CssClass="button blue" />
                </td>
            </tr>
        </table>
    </div>
    <div class="clear"></div>
</asp:Content>

