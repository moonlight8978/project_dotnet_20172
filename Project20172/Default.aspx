<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project20172._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink NavigateUrl="/AdminNovels.aspx" runat="server">Sửa Tiểu Thuyết</asp:HyperLink>

	<h1>Thiên long bát bộ</h1>

	<h5>Tìm kiếm</h5>
	<asp:TextBox ID="FindingKeyword" runat="server"></asp:TextBox>
	<asp:Label ID="FindingResult" runat="server" Text="Label"></asp:Label>
	<asp:Button ID="Find" runat="server" Text="Find" OnClick="Find_Click" />
	<asp:DataList ID="ResultText" runat="server">
		<ItemTemplate>
			<%# Container.DataItem %>
		</ItemTemplate>
	</asp:DataList>
	<h5>Danh sách hồi</h5>

	<asp:DataList ID="ChaptersList" runat="server">
		<ItemTemplate>
			<asp:HyperLink NavigateUrl='<%# Eval("ID", "/chapters/{0}.aspx") %>' runat="server" Text='<%# Eval("Number", "Hồi {0}") %>'></asp:HyperLink>
		</ItemTemplate>
	</asp:DataList>
</asp:Content>
