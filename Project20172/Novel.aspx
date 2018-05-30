<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Novel.aspx.cs" Inherits="Project20172.Novel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<nav aria-label="breadcrumb">
		<ol class="breadcrumb">
			<li class="breadcrumb-item"><a href="/">Trang chủ</a></li>
			<li class="breadcrumb-item">
				<asp:Label ID="NovelFullName" runat="server" Text="Tiểu thuyết Full"></asp:Label>
			</li>
		</ol>
	</nav>
	<div class="page-title">
		<h1><asp:Label ID="NovelName" runat="server" Text="Label"></asp:Label></h1>
		(<asp:HyperLink ID="EditNovelLink" runat="server">Sửa</asp:HyperLink>)
	</div>

	<div class="boxes">
		<div class="box">
			<h5>Tìm kiếm</h5>
			<div class="form-group">
				<asp:TextBox CssClass="form-control" ID="FindingKeyword" runat="server"></asp:TextBox>
				<label>Từ khóa</label>
			</div>

			<%--<asp:Label ID="FindingResult" runat="server" Text="Label"></asp:Label>--%>
			<asp:Button CssClass="btn btn-primary mb-3" ID="Find" runat="server" Text="Find" OnClick="Find_Click" />

			<asp:DataList ID="ResultText" runat="server" ItemStyle-CssClass="row-result">
				<ItemTemplate>
					<%# Container.DataItem %>
				</ItemTemplate>
			</asp:DataList>
		</div>

		<div class="box">
			<h5>Danh sách hồi</h5>

			<asp:DataList ID="ChapterList" runat="server">
				<ItemTemplate>
					<asp:HyperLink NavigateUrl='<%# Eval("ID", "/chapters/{0}.aspx") %>' runat="server" Text='<%# Eval("Number", "Hồi {0}") %>'></asp:HyperLink>
				</ItemTemplate>
			</asp:DataList>
		</div>
	</div>
</asp:Content>