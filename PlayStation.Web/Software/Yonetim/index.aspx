<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Yönetim Paneli | Giriş</title>
    <meta name="description" content="">
    <meta name="author" content="revaxarts.com">
    <!-- Apple iOS and Android stuff -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <link rel="apple-touch-icon-precomposed" href="img/icon.png">
    <link rel="apple-touch-startup-image" href="img/startup.png">
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=no,maximum-scale=1">
    <!-- Google Font and style definitions -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=PT+Sans:regular,bold">
    <link rel="stylesheet" href="css/style.css">
    <!-- include the skins (change to dark if you like) -->
    <link rel="stylesheet" href="css/light/theme.css" id="themestyle">
    <!--[if lt IE 9]>
	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<link rel="stylesheet" href="css/ie.css">
	<![endif]-->
    <!-- Use Google CDN for jQuery and jQuery UI -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.12/jquery-ui.min.js"></script>
    <!-- Loading JS Files this way is not recommended! Merge them but keep their order -->
    <!-- some basic functions -->
    <script src="js/functions.js"></script>
    <!-- all Third Party Plugins -->
    <script src="js/plugins.js"></script>
    <!-- Whitelabel Plugins -->
    <script src="js/wl_Alert.js"></script>
    <script src="js/wl_Dialog.js"></script>
    <script src="js/wl_Form.js"></script>
    <!-- configuration to overwrite settings -->
    <script src="js/config.js"></script>
    <!-- the script which handles all the access to plugins etc... -->
    <%--<script src="js/login.js"></script>--%>
</head>
<body id="login">
     <div id="divhata" runat="server" visible="true" class="alert warning"><asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
    <header>
			<div id="logo">
				<a href="index.aspx">whitelabel</a>
			</div>
		</header>
    <section id="content">
        <form id="form1" runat="server">
			<fieldset>
				<section><label for="username">Kullanıcı Adı</label>
					<div><input type="text" runat="server" id="username" name="username" autofocus></div>
				</section>
				<section><label for="password">Şifre</label>
					<div><input type="password" runat="server" id="password" name="password"></div>
					
				</section>
                <section runat="server" visible="false"><label for="password">Giriş Dili</label>
					<div><asp:DropDownList CssClass="selector" style="width: 278px;height: 26px;color: gray;font-size: 14px;margin-left: 5px;" ID="drpdil" runat="server">
                    <asp:ListItem Text="Türkçe" Value="1"></asp:ListItem>
                    <asp:ListItem Text="English" Value="2"></asp:ListItem>
                    </asp:DropDownList></div>
					
				</section>
				<section>
					<div style="padding-left:17px; margin-top:8px;">
          <asp:Button ID="btnGiris" runat="server" CssClass="fr submit" Text="Giriş" 
                            onclick="btnGiris_Click" />
                    </div>
				</section>
			</fieldset>
		</form>
		</section>
    <footer>NVisionSoft Yönetim Paneli</footer>
</body>
</html>
