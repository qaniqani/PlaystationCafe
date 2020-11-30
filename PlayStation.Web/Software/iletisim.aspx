<%@ Page Title="" Language="C#" MasterPageFile="~/Content.master" AutoEventWireup="true" CodeFile="iletisim.aspx.cs" Inherits="iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <header id="content-header">
        <div class="wrapper">
			<!-- Heading _____________________________________________-->
			<h1>
                <asp:Literal ID="ltBaslik" runat="server"></asp:Literal>
			</h1>
			
			<!-- Breadcrumbs _____________________________________________-->
			<p itemscope itemtype="http://data-vocabulary.org/Breadcrumb" id="breadcrumbs">
				<a href="/" rel="home" itemprop="url">
					<span itemprop="title">Anasayfa</span>
				</a>
				<span class="divider">></span>
				<asp:Literal ID="ltAltBaslik" runat="server"></asp:Literal>
			</p>
	    </div>
    </header>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <!-- Google Map  _____________________________________________-->
<div id="map">
	<div id="map-content">
		<p class="center">Harita çalışmıyor... Lütfen Javascript eklentinizi aktif ediniz!</p>
	</div>
</div><!-- END #map -->


<div class="wrapper">

	<!-- MAIN CONTENT SECTION  _____________________________________________-->
	<section id="content" class="full-width" role="main">
	
		<!-- WYSIWYG content  _____________________________________________-->
		<div class="p30">

			<h3>İletişim Bilgileri</h3>

            <p>World Elektronik &amp; Yazılım, Proje Geliştirme<br />
                M. Akif Mh. Fatih Bul. Merkez Sk. No: 4<br/>
			    Sultanbeyli, İstanbul<br/>
			    Türkiye</p>

			<p><strong class="p15"><i class="icon-phone" title="Phone"></i> &nbsp;</strong> +90 (216) 398-4499<br/>
				<strong class="p15"><i class="icon-envelope" title="Email"></i> &nbsp;</strong> info@nvisionsoft.net<br/>
				<strong class="p15"><i class="icon-desktop" title="Web"></i> &nbsp;</strong>  nvisionsoft.net</p>
			
		</div><!-- END .p25 -->
	
		<div class="p70 right">

			<h3>İletişim Formu</h3>

			<mark id="message"></mark>

				<fieldset>
					<div class="p50 input-block">
						<label for="txtUserName" accesskey="U"><strong>Adınız</strong> (zorunlu)</label>
                        <asp:TextBox ID="txtUserName" runat="server" required="required"></asp:TextBox>
					</div>
					<div class="p50 input-block right">
						<label for="txtGSMNo" accesskey="E"><strong>GSM No</strong> (zorunlu)</label>
                        <asp:TextBox ID="txtGSMNo" runat="server" required="required"></asp:TextBox>
					</div>
				</fieldset>

				<fieldset>
					<div class="input-block">
						<label for="txtSubject" accesskey="S"><strong>Başlık</strong></label>
                        <asp:TextBox ID="txtSubject" runat="server" required="required"></asp:TextBox>
					</div>

					<div class="input-block">
						<label for="commetxtDetailnts" accesskey="C"><strong>Detay</strong> (zorunlu)</label>
                        <asp:TextBox ID="txtDetail" runat="server" required="required" TextMode="MultiLine" Height="100px"></asp:TextBox>
					</div>
				</fieldset>

                <asp:Button ID="btnSubmit" runat="server" Text="Gönder" CssClass="submit" OnClick="btnSubmit_Click" />

		</div><!-- END .p75 -->

		
		<!-- END of WYSIWYG content ____________________________-->

	</section>
	<!-- END #content -->
		
</div> <!-- END .wrapper -->
    <!-- include google map -->
<script src="http://maps.google.com/maps/api/js?sensor=false"></script>
<script src="/js/jquery.gmap.min.js"></script> 
<!-- include contact form scripts -->
    <script>
        jQuery(document).ready(function () {
            // init gmap
            try {
                $('#map-content').gMap({
                    address: "İstanbul, Sultanbeyli, Mehmet Akif Mah. Merkez Sk. No: 4",
                    scrollwheel: false,
                    zoom: 12,
                    markers: [
                        {
                            address: "İstanbul, Sultanbeyli, Mehmet Akif Mah. Merkez Sk. No: 4"
                        }
                    ]
                });
            } catch (e) { }
        });
</script>

</asp:Content>

