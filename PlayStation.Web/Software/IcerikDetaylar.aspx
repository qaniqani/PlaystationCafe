<%@ Page Title="" Language="C#" MasterPageFile="~/Content.master" AutoEventWireup="true" CodeFile="IcerikDetaylar.aspx.cs" Inherits="IcerikDetaylar" %>

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
    <asp:Literal ID="ltIcerikler" runat="server"></asp:Literal>
</asp:Content>

