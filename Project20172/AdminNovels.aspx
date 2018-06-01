<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AdminNovels.aspx.cs" Inherits="Project20172.AdminNovels" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<nav aria-label="breadcrumb">
		<ol class="breadcrumb">
			<li class="breadcrumb-item"><a href="/">Trang chủ</a></li>
			<li class="breadcrumb-item active">Sửa tiểu thuyết</li>
		</ol>
	</nav>

	<div class="page-title">
		<h1>
			<asp:Label ID="NovelName" runat="server" Text="Novel name"></asp:Label></h1>
	</div>

	<div class="boxes">
		<div class="box">
			<h5>Hồi mới / Sửa hồi</h5>

			<div class="form-group">
				<asp:TextBox CssClass="form-control" ID="NewChapterNumber" TextMode="Number" runat="server"></asp:TextBox>
				<label>Hồi</label>
			</div>

			<div class="form-group">
				<asp:TextBox CssClass="form-control" ID="NewChapterContent" runat="server" Rows="1" TextMode="MultiLine"></asp:TextBox>
				<label>Nội dung</label>
			</div>


			<asp:Button CssClass="btn btn-primary" ID="CreateChapter" runat="server" Text="Tạo hồi" OnClick="CreateChapter_Click" />
			<asp:Button CssClass="btn btn-primary" ID="UpdateChapter" runat="server" Text="Cập nhật hồi" OnClick="UpdateChapter_Click" />
		</div>

		<div class="box">
			<h4>Danh sách hồi</h4>
			<asp:DataList ID="ChaptersList" runat="server">
				<ItemTemplate>
					<asp:Label ID="ChapterNumber" runat="server" Text='<%# Eval("Number", "Hồi {0}") %>'></asp:Label>
					<span class="pl-3">
						<asp:LinkButton ID="EditChapter" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="EditChapter_Click" Text="Sửa hồi" />
						<span class="px-3">/</span>
						<asp:LinkButton ID="DeleteChapter" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="DeleteChapter_Click" Text="Xóa hồi" />
					</span>
				</ItemTemplate>
			</asp:DataList>
		</div>
	</div>
</asp:Content>
