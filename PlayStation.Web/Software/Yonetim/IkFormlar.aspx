<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="IkFormlar.aspx.cs" Inherits="Yonetim_IkFormlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
        <table class="padding">
            <tr>
                <td width="150">
                    Pozisyonlar
                </td>
                <td width="10">
                    :
                </td>
                <td>
                    <asp:DropDownList ID="drppozisyonlar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpdil_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div class="g12" >
        <table class="datatable">
            <thead>
                <tr>
                    <td width="30" id="thbas">
                    </td>
                    <th width="100">
                        Başvuru Tarihi
                    </th>
                    <th width="100">
                        Ad Soyad
                    </th>
                    <th width="50">
                        E-Posta
                    </th>
                    <th width="50">
                        Telefon
                    </th>
                    <th width="80">
                        Yaş
                    </th>
                    <th width="120">
                        Bilgi
                    </th>
                    <th width="60">
                        Dosya
                    </th>
                    <th width="50">
                        Sil
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterUrun" runat="server" OnItemCommand="RepeaterUrun_ItemCommand">
                    <ItemTemplate>
                        <tr class='gradeX'>
                            <td>
                                <%#Eval("ID")%>
                            </td>
                            <td>
                                <%#Eval("TARIH_1")%>
                            </td>
                            <td>
                                <%#Eval("ADSOYAD")%>
                            </td>
                            <td>
                                <%#Eval("EPOSTA")%>
                            </td>
                            <td class="c">
                                <%#Eval("TEL")%>
                            </td>
                            <td class="c">
                                <%#Eval("DOGTARIH")%>
                            </td>
                            <td class="c">
                                <%#Eval("EGITIMBILGI")%>
                            </td>
                            <td class="c">
                                <a href="<%#"/images/IK/"+Eval("DOSYA")%>" target="_blank">Dosya</a>
                            </td>
                            <td>
                                <asp:LinkButton ID="BtnSil" Style="position: relative; top: 9px" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                    CommandArgument='<%#Eval("ID")%>' CommandName="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
