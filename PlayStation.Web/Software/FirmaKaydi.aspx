<%@ Page Title="" Language="C#" MasterPageFile="~/Content.master" AutoEventWireup="true" CodeFile="FirmaKaydi.aspx.cs" Inherits="FirmaKaydi" %>

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
    <div class="wrapper">

	<!-- MAIN CONTENT SECTION  _____________________________________________-->
	<section id="content" class="full-width" role="main">
	
		<!-- WYSIWYG content  _____________________________________________-->
		<div class="p30">

			<h3>Lisanslama</h3>

            <asp:Literal ID="ltIcerik" runat="server"></asp:Literal>
			
		</div><!-- END .p25 -->

        

		<div class="p70 right">
            <asp:Panel ID="pnlFirmSave" runat="server">
			    <h3>Firma Bilgileri</h3>

			    <mark id="message"></mark>

				<fieldset>
					<div class="p50 input-block">
						<label for="name" accesskey="U"><strong>Adınız Soyadınız</strong> (zorunlu)</label>
                        <asp:TextBox ID="txtName" runat="server" required="required"></asp:TextBox>
					</div>
					<div class="p50 input-block right">
						<label for="txtTCNR" accesskey="E"><strong>TC No</strong> (zorunlu)</label>
                        <asp:TextBox ID="txtTCNR" runat="server" required="required"></asp:TextBox>
					</div>
				</fieldset>

				<fieldset>
					<div class="p50 input-block right">
						<label for="txtGsmNo" accesskey="E"><strong>GSM No</strong> (zorunlu)</label>
                        <asp:TextBox ID="txtGsmNo" runat="server" required="required"></asp:TextBox>
					</div>
					<div class="p50 input-block">
						<label for="txtEmail" accesskey="U"><strong>E-Mail</strong> (zorunlu)</label>
                        <asp:TextBox ID="txtEmail" runat="server" required="required"></asp:TextBox>
					</div>
				</fieldset>

				<fieldset>
					<div class="input-block">
						<label for="txtCustomerName" accesskey="S"><strong>Firma Adı</strong> (zorunlu)</label>
                        <asp:TextBox ID="txtCustomerName" runat="server" required="required"></asp:TextBox>
					</div>
				</fieldset>

				<fieldset>
					<div class="p50 input-block">
						<label for="txtCity" accesskey="U"><strong>İl</strong> (zorunlu)</label>
                        <asp:TextBox ID="txtCity" runat="server" required="required"></asp:TextBox>
					</div>
					<div class="p50 input-block right">
						<label for="txtRegion" accesskey="E"><strong>İlçe</strong> (zorunlu)</label>
                        <asp:TextBox ID="txtRegion" runat="server" required="required"></asp:TextBox>
					</div>
				</fieldset>

				<fieldset>
					<div class="input-block">
						<label for="txtAddress" accesskey="S"><strong>Adres Detayı</strong></label>
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
					</div>
				</fieldset>

				<fieldset>
					<div class="p50 input-block">
						<label for="txtTaxOffice" accesskey="U"><strong>Vergi Dairesi</strong></label>
                        <asp:TextBox ID="txtTaxOffice" runat="server"></asp:TextBox>
					</div>
					<div class="p50 input-block right">
						<label for="txtTaxNR" accesskey="E"><strong>Vergi No</strong></label>
						<asp:TextBox ID="txtTaxNR" runat="server"></asp:TextBox>
					</div>
				</fieldset>
                <asp:Button ID="btnSubmit" runat="server" Text="İndir" CssClass="submit" OnClick="btnSubmit_Click" />

            </asp:Panel>

            <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
                <p class="notice success">
                    <strong>Kayıt Tamamlandı</strong> &nbsp;
                    <br />
                    1 Aylık demo lisansınız oluşturulmuştur.<br /> Lütfen lisans keyiniz kaydediniz.
                    <br />
                    Lisans numaranız programın açılışında istenecektir.
                    <br />
                    Lisans keyiniz e-mail adresinize gönderilmiştir.
                    <br />
                    <br />
                    Lisans Numaranız: <strong><asp:Literal ID="ltLicenceKey" runat="server"></asp:Literal></strong>
                    <br />
                    <br />
                    Programı indirmek için <a href="/download/setup.exe">tıklayınız</a>.
                </p>
            </asp:Panel>
            <asp:Panel ID="pnlError" runat="server" Visible="false">
                <p class="notice error">
                    <strong>Hata</strong> - <asp:Literal ID="ltError" runat="server"></asp:Literal>

                </p>
            </asp:Panel>

		</div><!-- END .p75 -->

		<!-- END of WYSIWYG content ____________________________-->

	</section>
	<!-- END #content -->
		
</div> <!-- END .wrapper -->
</asp:Content>

