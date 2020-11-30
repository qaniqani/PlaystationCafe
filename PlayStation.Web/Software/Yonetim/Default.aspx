<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g6 widgets">
        <%-- <div class="widget" id="calendar_widget" data-icon="calendar">
            <h3 class="handle">
                Calendar</h3>
            <div>
                <div class="calendar" data-header="small">
                </div>
                <p>
                    <a class="btn" href="calendar.html">Check out the Calendar section</a>
                </p>
            </div>
        </div>--%>
        <%--  <div class="widget" id="widget_tabs">
            <h3 class="handle">
                Tabs</h3>
            <div class="tab">
                <ul>
                    <li><a href="#tabs-1">Nunc tincidunt</a></li>
                    <li><a href="#tabs-2">Proin dolor</a></li>
                    <li><a href="#tabs-3">Aenean lacinia</a></li>
                </ul>
                <div id="tabs-1">
                    <p>
                        Proin elit arcu, rutrum commodo, vehicula tempus, commodo a, risus. Curabitur nec
                        arcu. Donec sollicitudin mi sit amet mauris. Nam elementum quam ullamcorper ante.
                        Etiam aliquet massa et lorem. Mauris dapibus lacus auctor risus. Aenean tempor ullamcorper
                        leo. Vivamus sed magna quis ligula eleifend adipiscing. Duis orci. Aliquam sodales
                        tortor vitae ipsum. Aliquam nulla. Duis aliquam molestie erat. Ut et mauris vel
                        pede varius sollicitudin. Sed ut dolor nec orci tincidunt interdum. Phasellus ipsum.
                        Nunc tristique tempus lectus.
                    </p>
                </div>
                <div id="tabs-2">
                    <p>
                        Morbi tincidunt, dui sit amet facilisis feugiat, odio metus gravida ante, ut pharetra
                        massa metus id nunc. Duis scelerisque molestie turpis. Sed fringilla, massa eget
                        luctus malesuada, metus eros molestie lectus, ut tempus eros massa ut dolor. Aenean
                        aliquet fringilla sem. Suspendisse sed ligula in ligula suscipit aliquam. Praesent
                        in eros vestibulum mi adipiscing adipiscing. Morbi facilisis. Curabitur ornare consequat
                        nunc. Aenean vel metus. Ut posuere viverra nulla. Aliquam erat volutpat. Pellentesque
                        convallis. Maecenas feugiat, tellus pellentesque pretium posuere, felis lorem euismod
                        felis, eu ornare leo nisi vel felis. Mauris consectetur tortor et purus.
                    </p>
                </div>
                <div id="tabs-3">
                    <p>
                        Mauris eleifend est et turpis. Duis id erat. Suspendisse potenti. Aliquam vulputate,
                        pede vel vehicula accumsan, mi neque rutrum erat, eu congue orci lorem eget lorem.
                        Vestibulum non ante. Class aptent taciti sociosqu ad litora torquent per conubia
                        nostra, per inceptos himenaeos. Fusce sodales. Quisque eu urna vel enim commodo
                        pellentesque. Praesent eu risus hendrerit ligula tempus pretium. Curabitur lorem
                        enim, pretium nec, feugiat nec, luctus a, lacus.
                    </p>
                    <p>
                        Duis cursus. Maecenas ligula eros, blandit nec, pharetra at, semper at, magna. Nullam
                        ac lacus. Nulla facilisi. Praesent viverra justo vitae neque. Praesent blandit adipiscing
                        velit. Suspendisse potenti. Donec mattis, pede vel pharetra blandit, magna ligula
                        faucibus eros, id euismod lacus dolor eget odio. Nam scelerisque. Donec non libero
                        sed nulla mattis commodo. Ut sagittis. Donec nisi lectus, feugiat porttitor, tempor
                        ac, tempor vitae, pede. Aenean vehicula velit eu tellus interdum rutrum. Maecenas
                        commodo. Pellentesque nec elit. Fusce in lacus. Vivamus a libero vitae lectus hendrerit
                        hendrerit.
                    </p>
                </div>
            </div>
        </div>--%>
        <div class="widget number-widget" id="widget_number">
            <h3 class="handle">
                İçerik Durumları</h3>
            <div>
                <ul>
                    <asp:Literal ID="LiteralIstatistik" runat="server"></asp:Literal>
                </ul>
            </div>
        </div>
    </div>
    <div class="g6 widgets">
        <%--Grafikler --%>
        <%--<div class="widget" id="widget_charts" data-icon="graph">
			<h3 class="handle">Charts</h3>
			<div>
				<table class="chart" data-fill="true" data-tooltip-pattern="%1 %2 on the 2011-03-%3">
					<thead>
						<tr>
							<th></th>
							<th>01</th><th>02</th><th>03</th><th>04</th><th>05</th><th>06</th><th>07</th><th>08</th><th>09</th><th>10</th><th>11</th><th>12</th><th>13</th><th>14</th><th>15</th>
							<th>16</th><th>17</th><th>18</th><th>19</th><th>20</th><th>21</th><th>22</th><th>23</th><th>24</th><th>25</th><th>26</th><th>27</th><th>28</th><th>29</th><th>30</th><th>31</th>
						</tr>
					</thead>
					<tbody>
						<tr>
							<th>Total Visitors</th>
							<td>331</td><td>306</td><td>337</td><td>340</td><td>332</td><td>330</td><td>307</td><td>343</td><td>307</td><td>322</td><td>319</td><td>314</td><td>326</td><td>317</td><td>323</td><td>347</td><td>317</td><td>341</td><td>328</td><td>307</td><td>350</td><td>330</td><td>313</td><td>314</td><td>332</td><td>330</td><td>317</td><td>346</td><td>328</td><td>312</td><td>311</td>
						</tr>
						<tr>
							<th>Unique Visitors</th>
							<td>113</td><td>126</td><td>143</td><td>126</td><td>147</td><td>131</td><td>150</td><td>112</td><td>110</td><td>130</td><td>109</td><td>115</td><td>146</td><td>129</td><td>138</td><td>122</td><td>114</td><td>112</td><td>128</td><td>111</td><td>122</td><td>136</td><td>109</td><td>106</td><td>104</td><td>146</td><td>123</td><td>139</td><td>117</td><td>116</td><td>143</td>
						</tr>
					</tbody>
				</table>
				<p>
				<a class="btn" href="charts.html">Check out the Charts section</a>
				</p>
				</div>
			</div>--%>
        <%--  <div class="widget" id="widget_accordion">
				<h3 class="handle">Son Yorumlar</h3>
				<div class="accordion">
					<asp:Repeater ID="RepeaterYorum" runat="server">
                    <ItemTemplate>
                        <h4><a href="#"><%#Eval("YORUMBASLIK") %></a></h4>
					<div>
						<p>
								<%#Eval("YORUMDETAY")%>
						</p>
					</div>
                    </ItemTemplate>
                    </asp:Repeater>
			
				</div>
			</div>--%>
        <div class="widget" id="widget_accordion1">
            <h3 class="handle">
                Son Formlar</h3>
            <div class="accordion">
                <asp:Repeater ID="RepeaterForm" runat="server">
                    <ItemTemplate>
                        <h4>
                            <a href="#">
                                <%#Eval("FORMADI") + " " + Eval("FORMSOYADI")%>
                                -
                                <%# Eval("FORMYAYIN").ToString()=="1"?"Okundu":"Okunmadı"%></a></h4>
                        <div>
                            <p>
                                <%#Eval("FORMMESAJ") %> <a style="color:Red" href="formDetay.aspx?id=<%#Eval("FORMID") %>">Detaylı İncele</a>
                            </p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
<%--        <div class="widget" id="widget_accordionn">
            <h3 class="handle">
                Son Yorumlar</h3>
            <div class="accordion">
                <asp:Repeater ID="RepeaterYorum" runat="server">
                    <ItemTemplate>
                        <h4>
                            <a href="#">
                                <%#Eval("YORUMBASLIK")%>
                                -
                                <%# Eval("YORUMDURUM").ToString() == "0" ? "Yeni Yorum" : Eval("YORUMDURUM").ToString() == "1" ? "Onaylı Yorum" :"Onaysız Yorum"%></a></h4>
                        <div>
                            <p>
                                <%#Eval("YORUMDETAY")%> <a style="color:Red" href="YorumListesi.aspx">Detaylı incele</a>
                            </p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>--%>
        <%-- <div class="widget" id="widget_breadcrumb">
            <h3 class="handle">
                Breadcrumb</h3>
            <div>
                <ul class="breadcrumb" data-numbers="true">
                    <li><a href="#">Ready</a></li>
                    <li><a href="#">Set</a></li>
                    <li><a href="#">GO!</a></li>
                </ul>
                <p>
                    <a class="btn" href="breadcrumb.html">Check out the Breadcrumb section</a>
                </p>
            </div>
        </div>--%>
        <%--<div class="widget" id="widget_ajax" data-load="widget-content.php" data-reload="10"
            data-remove-content="false">
            <h3 class="handle">
                AJAX Widget with autoreload</h3>
            <div>
                This content get replaced
            </div>
        </div>--%>
        <%--<div class="widget" id="widget_info">
            <h3 class="handle">
                Do What you like!</h3>
            <div>
                <h3>
                    Widgets can contain everything</h3>
                <p>
                    Widgets are flexible, dragg-, sort-, and collapseable content boxes. Fill them with
                    some html!
                </p>
                <p>
                    <a class="btn" href="widgets.html">Check out the Widget section</a>
                </p>
            </div>
        </div>--%>
    </div>
    <div style="clear: both">
    </div>
</asp:Content>
