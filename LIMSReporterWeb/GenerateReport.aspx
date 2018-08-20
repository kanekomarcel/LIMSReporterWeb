<%@ Page Title="SampleManager Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerateReport.aspx.cs" Inherits="LIMSReporterWeb.GenerateReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Reports Generation - <%: Request["q"] %></h3>

    <asp:Label id="Label1" runat="server">Enter the values for the report parameters below </asp:Label>
<%--    <p></p>
    <asp:Label id="Label2" runat="server">Enter the values for the report parameters below. </asp:Label>--%>

    <asp:GridView ID="genericGridView" runat="server" AutoGenerateColumns="False" 
            Width="100%" AllowPaging="False" ShowHeaderWhenEmpty="False"  >
            <AlternatingRowStyle CssClass="table-cell-variacao" />
            <Columns>
                <%--<asp:CommandField ButtonType="Image" SelectImageUrl="~/imgs/doc_page.png"
                    SelectText="Selecionar"
                    ShowCancelButton="False" ShowDeleteButton="False" ShowEditButton="False" 
                    ShowSelectButton="True">
                </asp:CommandField>--%>
                <asp:BoundField DataField="Parameter" HeaderText="Parameter" />
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
