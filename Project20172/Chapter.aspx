<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Chapter.aspx.cs" Inherits="Project20172.Chapter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<nav aria-label="breadcrumb">
		<ol class="breadcrumb">
			<li class="breadcrumb-item"><a href="/">Trang chủ</a></li>
			<li class="breadcrumb-item">
				<asp:Label ID="ChapterFullName" runat="server" Text="Hồi Full"></asp:Label>
			</li>
		</ol>
	</nav>
	<div class="page-title">
		<h1>
			<asp:Label ID="NovelName" runat="server" Text="Tiểu thuyết"></asp:Label>
		</h1>
		(<asp:Label ID="ChapterNumber" runat="server" Text="Hồi"></asp:Label>)
	</div>

	<div class="boxes">
		<div class="box">
			Số lỗi chính tả: 
			<asp:Label ID="InvalidCount" runat="server"></asp:Label>

			<div class="mt-3">
				<asp:Button CssClass="btn btn-primary" ID="SpellCheck" runat="server" Text="Kiểm tra chính tả" OnClick="SpellCheck_Click" />
			</div>
		</div>

		<div class="box">
			<asp:Label ID="ChapterContent" runat="server" Text="Nội dung"></asp:Label>
		</div>
	</div>

	<div class="footer-nav">
		<a href="/">Trang chủ</a>
	</div>
</asp:Content>
