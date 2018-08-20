<%@ Page Title="SampleManager Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="LIMSReporterWeb.Reports"  EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Reports Generation</h3>

    <asp:Label id="Label1" runat="server">You are not logged in. Click the Logon link to sign in. </asp:Label>
    <asp:Label id="Label2" runat="server">Select a report from the list below: </asp:Label>
    

    <asp:GridView ID="genericGridView" runat="server" AutoGenerateColumns="False" 
            Width="100%" AllowPaging="False" ShowHeaderWhenEmpty="False" OnRowCommand="genericGridView_RowCommand" 
            OnRowDataBound="genericGridView_RowDataBound" OnSelectedIndexChanged="genericGridView_SelectedIndexChanged">
            <AlternatingRowStyle CssClass="table-cell-variacao" />
            <Columns>
                <%--<asp:CommandField ButtonType="Image" SelectImageUrl="~/imgs/doc_page.png"
                    SelectText="Selecionar"
                    ShowCancelButton="False" ShowDeleteButton="False" ShowEditButton="False" 
                    ShowSelectButton="True">
                </asp:CommandField>--%>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="IMReport" HeaderText="Report" />

                <%--<asp:TemplateField HeaderText="Student Name">
                    <ItemTemplate>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Age">
                    <ItemTemplate>
                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Address">
                    <ItemTemplate>
                        <asp:TextBox ID="txtAddress" runat="server" 

                           Height="55px" TextMode="MultiLine"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <asp:RadioButtonList ID="RBLGender" 

                                   runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <HeaderStyle CssClass="cabecalho" />
            <RowStyle CssClass="table-cell" />
        </asp:GridView>
    

</asp:Content>
