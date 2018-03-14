<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Chapter.aspx.cs" Inherits="Project20172.Chapter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div>
		<%= Page.RouteData.Values["ID"] %>
	</div>
	<div>
		<asp:Label ID="ChapterNumber" runat="server" Text="Hồi"></asp:Label>
		<pre><asp:Label ID="ChapterContent" runat="server" Text="Nội dung"></asp:Label></pre>
	</div>
</asp:Content>