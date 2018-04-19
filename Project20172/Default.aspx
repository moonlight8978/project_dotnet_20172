<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project20172._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<nav aria-label="breadcrumb">
		<ol class="breadcrumb">
			<li class="breadcrumb-item active">Trang chủ</li>
		</ol>
	</nav>

	<div class="page-title">
		<h1>THẬT KHÔNG THỂ TIN NỔI</h1>
		<h1>Ứng dụng đọc tiểu thuyết ngôn lù hàng đầu Việt Nam</h1>
	</div>

	<div class="boxes">
		<div class="box">
			<h5>Credits</h5>

			<ul class="m-0">
				<li>
					Team Nyoro:<br />
					Lê Sĩ Bích - 20155125<br />
					Nguyễn Hữu Thắng - 20156500
				</li>
				<li>
					Design: Twitter
				</li>
			</ul>
		</div>

		<div class="box">
			<h5>Danh sách tiểu thuyết</h5>

			<a href="/admin">>>>>>>> Đi tới trang quản lý</a>

			<asp:DataList ID="NovelList" runat="server">
				<ItemTemplate>
					<asp:HyperLink NavigateUrl='<%# Eval("ID", "/novels/{0}") %>' runat="server" Text='<%# Eval("Name") %>'></asp:HyperLink>
				</ItemTemplate>
			</asp:DataList>
		</div>
	</div>
</asp:Content>
