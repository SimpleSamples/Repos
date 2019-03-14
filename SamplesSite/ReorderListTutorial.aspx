<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReorderListTutorial.aspx.cs" Inherits="SamplesSite.ReorderListTutorial" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReorderList Sample</title>
	<style>
h1 {
    text-align: center;
}
		.dragHandle {
			width: 10px;
			height: 15px;
			background-color: Blue;
			cursor: move;
			border: outset thin white;
		}

		.callbackStyle {
			border: thin blue inset;
		}

		.reorderListDemo li {
			list-style: none;
			margin: 2px;
			background-repeat: repeat-x;
		}

		.reorderCue {
			border: dashed thin black;
			width: 100%;
			height: 25px;
		}

		.itemArea {
			margin-left: 15px;
			font-family: Arial, Verdana, sans-serif;
			font-size: 1em;
			text-align: left;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
		<h1>ReorderList Sample</h1>
		<asp:ScriptManager ID="ScriptManager1" runat="server" />
	<asp:UpdatePanel ID="up1" runat="server">
		<ContentTemplate>
			<div class="reorderListDemo">
				<ajaxToolkit:ReorderList ID="ReorderList1" runat="server"
					PostBackOnReorder="true"
					ItemType="AJAX"
					SelectMethod="GetData"
					UpdateMethod="UpdateItem"
					CallbackCssStyle="callbackStyle"
					DragHandleAlignment="Left"
					ItemInsertLocation="Beginning"
					DataKeyField="id"
					SortOrderField="position"
					ClientIDMode="AutoID"
					AllowReorder="true">
					<ItemTemplate>
						<div class="itemArea">
							|
							<asp:Label ID="Label1" runat="server"
								Text='<%# Item.position %>' />
							|
							<asp:Label ID="Label2" runat="server"
								Text='<%# Item._char %>' />
							|
							<asp:Label ID="Label3" runat="server"
								Text='<%# Item.description %>' />
							|
						</div>
					</ItemTemplate>
					<EditItemTemplate>
						<div class="itemArea">
							<asp:TextBox ID="TextBox3" runat="server" Text='<%# Item._char %>' ValidationGroup="edit" />
							<asp:TextBox ID="TextBox4" runat="server" Text='<%# Item.description %>' ValidationGroup="edit" />
						</div>
					</EditItemTemplate>
					<ReorderTemplate>
						<asp:Panel ID="Panel2" runat="server" CssClass="reorderCue" />
					</ReorderTemplate>
					<DragHandleTemplate>
						<div class="dragHandle"></div>
					</DragHandleTemplate>
					<InsertItemTemplate>
						<div style="padding-left: 25px; border-bottom: thin solid transparent;">
							<asp:Panel ID="panel1" runat="server" DefaultButton="Button1">
								Char: <asp:TextBox ID="TextBox1" runat="server" Text='<%# Item._char  %>' ValidationGroup="add" />
								<br />
								Description: <asp:TextBox ID="TextBox2" runat="server" Text='<%# Item.description  %>' ValidationGroup="add" />
								<br />
								<asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Add" ValidationGroup="add" />
							</asp:Panel>
						</div>
					</InsertItemTemplate>
				</ajaxToolkit:ReorderList>
			</div>
			<asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
		</ContentTemplate>
	</asp:UpdatePanel>
    </form>
</body>
</html>
