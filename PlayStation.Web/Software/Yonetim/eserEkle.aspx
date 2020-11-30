<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true" CodeFile="eserEkle.aspx.cs" Inherits="Yonetim_eserEkle" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">


        function SetButtonStatus(sender, target) {

            document.getElementById(target).Enabled = true;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function popitup(url) {
            newwindow = window.open(url, 'name', 'height=250,width=300');
            if (window.focus) { newwindow.focus(); }
            return false;
        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            $('#FileUpload').on('change', function (e) {
                e.preventDefault();
                var fileInput = $('#FileUpload');
                var fileData = fileInput.prop("files")[0];   // Getting the properties of file from file field
                var formData = new window.FormData();                  // Creating object of FormData class
                formData.append("file", fileData); // Appending parameter named file with properties of file_field to form_data
                $.ajax({
                    url: '/Yonetim/resimyukle.ashx',
                    data: formData,
                    processData: false,
                    contentType: false,
                    type: 'POST',
                    success: function (data) {
                        $('#hfgizli').val(data);
                        $('#yuklenen1').html("<a href='" + data + "' target='_blank'>  " + data + "</a>").show();

                    },
                    error: function (xhr, textStatus, errorThrown) {
                        alert("xhr: " + xhr + " text: " + textStatus + " error: " + errorThrown);
                    }
                });
            });
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g8">
        <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
    </div>
    <div class="g12" id="divicerik" runat="server" visible="false">
        <div id="divkaydet" runat="server" visible="false" class="alert success">
            <asp:Label ID="lbkaydedildi" runat="server"></asp:Label></div>
        <table id="TblIcerik" runat="server" class="padding">
            <tr>
                <td width="200">
                    Adı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbad" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbad"
                        Display="None" ErrorMessage="Başlık bölümü boş geçilemez" ValidationGroup="iii">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Açıklama
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="TbAciklama" runat="server" Height="70px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TbAciklama"
                        Display="None" ErrorMessage="Açıklama bölümü boş geçilemez" ValidationGroup="iii">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Detay
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <CKEditor:CKEditorControl ID="CKEditorControl1" BaseHref="~/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CKEditorControl1"
                        Display="None" ErrorMessage="Detay bölümü boş geçilemez" ValidationGroup="iii">*</asp:RequiredFieldValidator>
                </td>
            </tr>
                        <tr id="trlogo" runat="server" visible="false">
                <td width="150">
                    Resim
                </td>
                <td width="10">
                </td>
                <td width="300">
                    <asp:FileUpload ID="FileUploadImg" runat="server" />
                </td>
            </tr>
                        <tr id="trdosya" runat="server" visible="false" clientidmode="Static">
                <td width="200">
                    Dosya
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:HiddenField ID="hfgizli" runat="server" ClientIDMode="Static" />
                    <asp:FileUpload ID="FileUpload" ClientIDMode="Static" runat="server" />
                    <div id="yuklenen1" style="width: auto; display: inline-block;">
                    </div>
                </td>
            </tr>
          <%--     <tr id="trdosya" runat="server" visible="false">
                <td width="150">
                    Dosya
                </td>
                <td width="10">
                </td>
                <td width="300">
                    <asp:FileUpload ID="FileUpload" runat="server" />
                </td>
            </tr>--%>
            <tr id="trres" runat="server" visible="false">
                <td width="150">
                </td>
                <td width="10">
                </td>
                <td width="300">
                    <img id="imgsrc" width="150" border="0" runat="server" />
                    <asp:Label ID="lbres" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Title
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbtitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Description
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbdess" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Keyword
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:TextBox ID="tbkey" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Sıra No
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
                    Kategori Adı
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:Label ID="lbkat" runat="server"></asp:Label>
                    &nbsp;<a id="hrfkat" runat="server" href="#">(Değiştir)</a>
                </td>
            </tr>
            <tr>
                <td width="200">
                    Aktif
                </td>
                <td width="10">
                    :
                </td>
                <td width="600">
                    <asp:CheckBox ID="chkAktif" runat="server" Checked="True" OnCheckedChanged="chkAktif_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 235px">
                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"
                        CssClass="button blue" ValidationGroup="iii" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Düzenle" CssClass="button blue" OnClick="BtnUpdate_Click"
                        Visible="False" ValidationGroup="iii" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="iii" />
                </td>
            </tr>
        </table>
    </div>
    <div class="g4" id="divkategori" runat="server">
        <table>
            <tr>
                <td>
                    <h3>
                        Kategoriler</h3>
                </td>
                <td>
                    <input type="button" value="Geri" onclick="history.go(-1)">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="border0">
                        <tr>
                            <td align="left">
                                <div style="float: left">
                                    <asp:RadioButtonList CssClass="radio" ID="rdkat" runat="server">
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="butonlar" style="text-align: left;">
                                <asp:Button ID="BtnSec" runat="server" Text="Seç" OnClick="BtnSec_Click" />
                                <asp:Button ID="Btnileri" runat="server" Text="Alt Kategorileri" OnClick="Btnileri_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
</asp:Content>
