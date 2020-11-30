<%@ Page Language="C#" AutoEventWireup="true" CodeFile="katdegistir.aspx.cs" Inherits="Yonetim_katdegistir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Inplus CMS</title>
    <meta name="description" content="">
    <meta name="author" content="revaxarts.com">
    <!-- Google Font and style definitions -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=PT+Sans:regular,bold">
    <link rel="stylesheet" href="css/style.css">
    <!-- include the skins (change to dark if you like) -->
    <link rel="stylesheet" href="css/light/theme.css" id="themestyle">
    <!--[if lt IE 9]>
	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<link rel="stylesheet" href="css/ie.css">
	<![endif]-->
    <!-- Apple iOS and Android stuff -->
    <meta name="apple-mobile-web-app-capable" content="no">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="apple-touch-icon-precomposed" href="apple-touch-icon-precomposed.png">
    <!-- Apple iOS and Android stuff - don't remove! -->
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=no,maximum-scale=1">
    <!-- Use Google CDN for jQuery and jQuery UI -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.12/jquery-ui.min.js"></script>
    <!-- Loading JS Files this way is not recommended! Merge them but keep their order -->
    <!-- some basic functions -->
    <script src="js/functions.js"></script>
    <!-- all Third Party Plugins and Whitelabel Plugins -->
    <script src="js/plugins.js"></script>
    <script src="js/editor.js"></script>
    <script src="js/calendar.js"></script>
    <script src="js/flot.js"></script>
    <script src="js/elfinder.js"></script>
    <script src="js/datatables.js" charset="ISO-8859-1"></script>
    <script src="js/wl_Alert.js"></script>
    <script src="js/wl_Autocomplete.js"></script>
    <script src="js/wl_Breadcrumb.js"></script>
    <script src="js/wl_Calendar.js"></script>
    <script src="js/wl_Chart.js"></script>
    <script src="js/wl_Color.js"></script>
    <script src="js/wl_Date.js"></script>
    <script src="js/wl_Editor.js"></script>
    <script src="js/wl_File.js"></script>
    <script src="js/wl_Dialog.js"></script>
    <script src="js/wl_Fileexplorer.js"></script>
    <script src="js/wl_Form.js"></script>
    <script src="js/wl_Gallery.js"></script>
    <script src="js/wl_Multiselect.js"></script>
    <script src="js/wl_Number.js"></script>
    <script src="js/wl_Password.js"></script>
    <script src="js/wl_Slider.js"></script>
    <script src="js/wl_Store.js"></script>
    <script src="js/wl_Time.js"></script>
    <script src="js/wl_Valid.js"></script>
    <script src="js/wl_Widget.js"></script>
    <!-- configuration to overwrite settings -->
    <script src="js/config.js"></script>
    <!-- the script which handles all the access to plugins etc... -->
    <script src="js/script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="g12" id="divkategori" runat="server">
        <table>
            
            <tr>
                <td  colspan="2">
                    <h3>
                        Kategoriler</h3>
                </td>
                
            </tr>
            <tr>
                <td colspan="2">
                    <table class="border0">
                        <tr>
                            <td align="left">
                                <div style="text-align: left;">
                                    <asp:RadioButtonList CssClass="radio" ID="rdkat" runat="server">
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="butonlar" style="text-align: left;">
                                <asp:Button ID="BtnSec" OnClientClick="return confirm('Değiştirmek istediğinize eminmisiniz ?')" runat="server" Text="Seç" OnClick="BtnSec_Click" />
                                <asp:Button ID="Btnileri" runat="server" Text="Alt Kategori" OnClick="Btnileri_Click" />
                                <asp:Button ID="BtnGetir" runat="server" Text="Üst Kategori" 
                                    OnClick="BtnGetir_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </div>
    </form>
</body>
</html>
