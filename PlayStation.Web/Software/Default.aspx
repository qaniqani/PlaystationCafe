<%@ Page Title="" Language="C#" MasterPageFile="~/Content.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Slider _____________________________________________-->
	<section id="slider">
		<a href="javascript:void(0)" class="prev1"></a>
		<a href="javascript:void(0)" class="next1"></a>
		<ul id="slides">
            <asp:Repeater ID="rptSlid" runat="server">
                <ItemTemplate>
                    <li class="slide">
				        <img src='/images/Slider/<%#Eval("SLIDERRESIM") %>' alt='<%#Eval("SLIDERBASLIK") %>' />
			        </li>
                </ItemTemplate>
            </asp:Repeater>
		</ul>
	</section>
	<!--  END #slider -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Literal ID="ltIcerik" runat="server"></asp:Literal>
</asp:Content>

