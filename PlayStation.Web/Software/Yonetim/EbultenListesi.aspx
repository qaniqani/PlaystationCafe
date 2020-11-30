<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.master" AutoEventWireup="true"
    CodeFile="EbultenListesi.aspx.cs" Inherits="Yonetim_EbultenListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="g12">
     <div id="divhata" runat="server" visible="false" class="alert warning">
            <asp:Label ID="lbhatamesaj" runat="server"></asp:Label></div>
        <table class="datatable">
            <thead>
                <tr>
                    <th>
                        E-Posta
                    </th>
                    <th>
                        GSM
                    </th>
                    <th>
                        Tarih
                    </th>
                    <th>
                        Mail Durum
                    </th>
                    <th>
                        GSM Durum
                    </th>
                    <th>
                        Sil
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterUrun" runat="server" OnItemCommand="RepeaterUrun_ItemCommand">
                    <ItemTemplate>
                        <tr class='gradeX'>
                            <td>
                                <%#Eval("BULTENEPOSTA")%>
                            </td>
                            <td>
                                <%#Eval("BULTENGSM")%>
                            </td>
                            <td>
                                <%#Eval("BULTENTARIH")%>
                            </td>
                            <td class="c">
                    
                                              <%#Convert.ToBoolean(Eval("BULTENDURUM")) == true ? "Aktif" : "Pasif"%>
                            </td>
                            <td class="c">

                                 <%#Convert.ToBoolean(Eval("BULTENONAY")) == true ? "Aktif" : "Pasif"%>
                            </td>
                            <td>
                                <asp:LinkButton ID="BtnSil" style="position:relative;top:9px" OnClientClick=" return confirm('Silmek istediğinize eminmisiniz ?')"
                                    runat="server" Text="<img src='css/images/icons/light/cross.png' border='0' width='30'/>"
                                    CommandArgument='<%#Eval("BULTENID")%>' CommandName="Sil" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
