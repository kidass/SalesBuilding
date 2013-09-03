<%@ Page Language="vb" AutoEventWireup="false" Codebehind="chat_fsxx.aspx.vb" Inherits="Josco.JsKernal.web.chat_fsxx"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>对话内容发送窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<style>
			TD.grdFJLocked { ; LEFT: expression(divFJ.scrollLeft); POSITION: relative }
			TH.grdFJLocked { ; LEFT: expression(divFJ.scrollLeft); POSITION: relative }
			TH.grdFJLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script language="javascript">
			function doOpenUrl()
			{
				var objControl = null;
				objControl = window.document.getElementById("htxtOpenUrl");
				if (objControl)
					window.open(objControl.value,"_self");
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" language="javascript">
		<form id="frmCHAT_FSXX" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="title" style="BORDER-TOP: dodgerblue thin outset; BORDER-BOTTOM: dodgerblue thin outset; BACKGROUND-COLOR: lightskyblue" align="center" height="30">【<!--<%=Mybase.UserXM%>--><%=Mybase.UserZM%>】即时交流内容发送窗<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD>
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<td>&nbsp;</td>
									<TD class="label" width="55%" nowrap>准备发送的信息：</TD>
									<td>&nbsp;</td>
									<TD class="label" width="45%" nowrap>传送文件≤<%=Josco.JsKernal.Common.jsoaConfiguration.MaxRequestLength/1024%>MB</TD>
									<td>&nbsp;</td>
								</TR>
								<TR>
									<td>&nbsp;</td>
									<TD vAlign="top" width="55%" class="label">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td><TEXTAREA class="textbox" id="textareaNR" rows="6" runat="server" style="width:100%" NAME="textareaNR"></TEXTAREA></td>
											</tr>
											<tr>
												<td><INPUT class="textbox" id="fileUpload" type="file" runat="server" style="width:100%" NAME="fileUpload"></td>
											</tr>
											<tr>
												<td class="label" nowrap>准备发给：<asp:TextBox ID="txtJSR" Runat="server" CssClass="textbox" Font-Size="11pt" Font-Name="宋体" ReadOnly="True" Width="100%"></asp:TextBox></td>
											</tr>
										</table>
									</TD>
									<td>&nbsp;</td>
									<TD vAlign="top" width="45%">
										<DIV id="divFJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 100%; CLIP: rect(0px 100% 150px 0px); HEIGHT: 150px; BACKGROUND-COLOR: white">
											<asp:datagrid id="grdFJ" runat="server" UseAccessibleHeader="True" AllowPaging="False" AutoGenerateColumns="False"
												GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE"
												BorderWidth="0px" AllowSorting="False" CellPadding="4" Font-Names="宋体" CssClass="label" Font-Size="11pt">
												<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
												<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
												<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
												<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
												<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
												<FooterStyle BackColor="#CCCC99"></FooterStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="选">
														<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
														<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:CheckBox id="chkFJ" runat="server" AutoPostBack="False"></asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:ButtonColumn Visible="False" DataTextField="显示序号" SortExpression="显示序号" HeaderText="序号" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn DataTextField="说明" SortExpression="说明" HeaderText="文件名" CommandName="Select">
														<HeaderStyle Width="300px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn DataTextField="页数" SortExpression="页数" HeaderText="KB" CommandName="Select">
														<HeaderStyle Width="120px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" DataTextField="序号" SortExpression="序号" HeaderText="序号" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" DataTextField="位置" SortExpression="位置" HeaderText="位置" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" DataTextField="本地文件" SortExpression="本地文件" HeaderText="本地文件" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" DataTextField="下载标志" SortExpression="下载标志" HeaderText="下载标志" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
												</Columns>
												<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
											</asp:datagrid><INPUT id="htxtFJFixed" type="hidden" value="0" name="htxtFJFixed" runat="server"></DIV>
									</TD>
									<td>&nbsp;</td>
								</TR>
								<TR>
									<td>&nbsp;</td>
									<TD align="center" width="55%" nowrap>
										<asp:Button id="btnSend" Runat="server" CssClass="button" Font-Size="11pt" Font-Name="宋体" Text="发送"></asp:Button>
										<asp:Button id="btnSelectJSR" Runat="server" CssClass="button" Font-Size="11pt" Font-Name="宋体" Text="选人"></asp:Button>
										<asp:Button id="btnCancelReply" Runat="server" CssClass="button" Font-Size="11pt" Font-Name="宋体" Text="取消"></asp:Button>
										<asp:Button id="btnHistory" Runat="server" CssClass="button" Font-Size="11pt" Font-Name="宋体" Text="历史"></asp:Button></TD>
									<td>&nbsp;</td>
									<TD align="center" width="45%" nowrap>
										<asp:Button id="btnUpload" Runat="server" CssClass="button" Font-Size="11pt" Font-Name="宋体" Text="上传"></asp:Button>
										<asp:Button id="btnDelete" Runat="server" CssClass="button" Font-Size="11pt" Font-Name="宋体" Text="删除"></asp:Button></TD>
									<td>&nbsp;</td>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="98%">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" 返回 " style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();"></p></TD>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5%"></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<table cellSpacing="0" cellPadding="0" align="center" border="0">
				<tr>
					<td>
						<input id="htxtOpenUrl" type="hidden">
						<input id="htxtSessionIdFJ" runat="server" type="hidden">
						<input id="htxtReplyMode" runat="server" type="hidden">
						<input id="htxtLSH" runat="server" type="hidden">
						<input id="htxtFJQuery" type="hidden" runat="server">
						<input id="htxtFJRows" type="hidden" runat="server">
						<input id="htxtFJSort" type="hidden" runat="server">
						<input id="htxtFJSortColumnIndex" type="hidden" runat="server">
						<input id="htxtFJSortType" type="hidden" runat="server">
						<input id="htxtDivLeftFJ" type="hidden" runat="server">
						<input id="htxtDivTopFJ" type="hidden" runat="server">
						<input id="htxtDivLeftBody" type="hidden" runat="server">
						<input id="htxtDivTopBody" type="hidden" runat="server">
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">
							function ScrollProc_Body() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopBody");
								if (oText != null) oText.value = document.body.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftBody");
								if (oText != null) oText.value = document.body.scrollLeft;
								return;
							}
							function ScrollProc_divFJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFJ");
								if (oText != null) oText.value = divFJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFJ");
								if (oText != null) oText.value = divFJ.scrollLeft;
								return;
							}
							try {
								var Text;

								oText=null;
								oText=document.getElementById("htxtDivTopBody");
								if (oText != null) document.body.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBody");
								if (oText != null) document.body.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopFJ");
								if (oText != null) divFJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFJ");
								if (oText != null) divFJ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divFJ.onscroll = ScrollProc_divFJ;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<uwin:popmessage id="popMessageObject" runat="server" Visible="False" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" height="48px" width="96px"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
