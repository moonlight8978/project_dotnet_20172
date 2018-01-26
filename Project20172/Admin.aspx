<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Project20172.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Admin Area</h1>
        <div>
            <h3>New novel</h3>
            <div>
                <asp:TextBox ID="NewNovelName" runat="server" Width="676px"></asp:TextBox>
                <asp:Button ID="CreateNewNovel" runat="server" Text="Create" Width="227px" OnClick="CreateNewNovel_Click" />
            </div>
        </div>
        <asp:DataList ID="NovelsList" runat="server" DataKeyField="ID">
            <ItemTemplate>
                Name:
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                <br />
                <asp:HyperLink runat="server" NavigateUrl='<%# Eval("ID", "~/admin_novels/{0}") %>'>
                    Edit
                </asp:HyperLink>
            </ItemTemplate>
        </asp:DataList>
    </form>
</body>
</html>
