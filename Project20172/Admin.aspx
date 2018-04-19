<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.cs" Inherits="Project20172.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<nav aria-label="breadcrumb">
		<ol class="breadcrumb">
			<li class="breadcrumb-item"><a href="/">Trang chủ</a></li>
			<li class="breadcrumb-item active">Quản lý tiểu thuyết</li>
		</ol>
	</nav>

	<div class="boxes">
		<div class="box">
			<h5>Tiểu thuyết mới / Sửa tiểu thuyết</h5>

			<div class="form-group">
				<asp:TextBox CssClass="form-control" ID="NovelName" runat="server" Width="676px"></asp:TextBox>
				<label>Tên tiểu thuyết</label>
			</div>

			<asp:LinkButton CssClass="btn btn-primary" ID="CreateNovel" runat="server" Text="Tạo tiểu thuyết" OnClick="CreateNewNovel_Click" />
			<asp:LinkButton CssClass="btn btn-primary" ID="UpdateNovel" runat="server" Text="Cập nhật tiểu thuyết" OnClick="UpdateNovel_Click" />
		</div>

		<div class="box">
			<h5>Danh sách truyện</h5>

			<asp:DataList ID="NovelsList" runat="server" DataKeyField="ID">
				<ItemTemplate>
					<asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />

					<span class="pl-3">
						<asp:HyperLink runat="server" NavigateUrl='<%# Eval("ID", "~/admin_novels/{0}") %>'>Quản lý</asp:HyperLink>
						<span class="px-3">/</span>
						<asp:LinkButton ID="EditNovel" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="EditNovel_Click" Text="Sửa tiểu thuyết" />
						<span class="px-3">/</span>
						<asp:LinkButton ID="DeleteNovel" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="DeleteNovel_Click" Text="Xóa tiểu thuyết" />
					</span>
				</ItemTemplate>
			</asp:DataList>
		</div>
	</div>
</asp:Content>
