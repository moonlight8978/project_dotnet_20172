<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AdminNovels.aspx.cs" Inherits="Project20172.AdminNovels" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="NovelName" runat="server" Text="Novel name"></asp:Label>

    <div>
        <h4>New chapter</h4>
        <asp:TextBox ID="NewChapterNumber" runat="server" Width="911px"></asp:TextBox>
        <asp:TextBox ID="NewChapterContent" runat="server" Rows="5" Height="97px" Width="912px" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="CreateChapter" runat="server" Text="Create Chapter" Width="122px" OnClick="CreateChapter_Click" />
        <asp:Button ID="UpdateChapter" runat="server" Text="Update Chapter" OnClick="UpdateChapter_Click" />
    </div>

    <h4>Chapters List</h4>
    <asp:DataList ID="ChaptersList" runat="server">
        <ItemTemplate>
            <asp:Label ID="ChapterNumber" runat="server" Text='<%# Eval("Number", "Chapter {0}") %>'></asp:Label>
            <asp:LinkButton ID="EditChapter" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="EditChapter_Click">
                Edit
            </asp:LinkButton>
            <asp:LinkButton ID="DeleteChapter" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="DeleteChapter_Click">
                Delete
            </asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
