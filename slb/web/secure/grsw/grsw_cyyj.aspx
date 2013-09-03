<%@ Page Language="vb" AutoEventWireup="false" Codebehind="grsw_cyyj.aspx.vb" Inherits="Josco.JsKernal.web.grsw_cyyj" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>我的常用意见处理窗</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdCYYJLocked { ; LEFT: expression(divCYYJ.scrollLeft); POSITION: relative }
			TH.grdCYYJLocked { ; LEFT: expression(divCYYJ.scrollLeft); POSITION: relative }
			TH.grdCYYJLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				var dblDeltaY = 20;
				var dblDeltaX = 0;
				
				if (document.all("divCYYJ") == null)
					return;
				
				dblHeight = 370 + dblDeltaY + document.body.clientHeight - 570; //default state : 370px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 580 + dblDeltaX + document.body.clientWidth  - 850; //default state : 580px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divCYYJ.style.width  = strWidth;
				divCYYJ.style.height = strHeight;
				divCYYJ.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
				return window_onresize();
			}
		//-->
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
		<!--
			return document_onreadystatechange()
		//-->
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()" background="../../images/bgmain.gif">
		<form id="frmGRSW_CYYJ" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="3"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="title" align="center" colSpan="5" height="36"><B>我的常用意见一览表</B><asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="3"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR align="center">
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZCYYJDeSelectAll" runat="server" Font-Size="11pt" Font-Name="宋体">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZCYYJSelectAll" runat="server" Font-Size="11pt" Font-Name="宋体">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZCYYJMoveFirst" runat="server" Font-Size="11pt" Font-Name="宋体">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZCYYJMovePrev" runat="server" Font-Size="11pt" Font-Name="宋体">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZCYYJMoveNext" runat="server" Font-Size="11pt" Font-Name="宋体">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZCYYJMoveLast" runat="server" Font-Size="11pt" Font-Name="宋体">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" noWrap><asp:linkbutton id="lnkCZCYYJGotoPage" runat="server" Font-Size="11pt" Font-Name="宋体">前往</asp:linkbutton><asp:textbox id="txtCYYJPageIndex" runat="server" Font-Size="11pt" Font-Name="宋体" Columns="2" CssClass="textbox">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" noWrap><asp:linkbutton id="lnkCZCYYJSetPageSize" runat="server" Font-Size="11pt" Font-Name="宋体">每页</asp:linkbutton><asp:textbox id="txtCYYJPageSize" runat="server" Font-Size="11pt" Font-Name="宋体" Columns="3" CssClass="textbox">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" align="right"><asp:label id="lblCYYJGridLocInfo" runat="server" Font-Size="11pt" Font-Name="宋体" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" noWrap align="right">意见内容</TD>
															<TD class="label" align="left"><asp:textbox id="txtCYYJSearch_YJNR" runat="server" Font-Size="11pt" Columns="48" CssClass="textbox" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnCYYJQuery" Runat="server" Font-Size="11pt" Font-Name="宋体" CssClass="button" Text="搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divCYYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 580px; CLIP: rect(0px 580px 370px 0px); HEIGHT: 370px;">
														<asp:datagrid id="grdCYYJ" runat="server" Font-Size="11pt" CssClass="label" Font-Names="宋体" AllowSorting="True"
															BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="True" CellPadding="4"
															BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True">
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
																		<asp:CheckBox id="chkCYYJ" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="序号" SortExpression="序号" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="意见类型" SortExpression="意见类型" HeaderText="意见类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="意见内容" SortExpression="意见内容" HeaderText="意见内容" CommandName="Select">
																	<HeaderStyle Width="880px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtCYYJFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:Button id="btnCYYJAddNew" Runat="server" Height="30px" Font-Size="11pt" Font-Name="宋体" CssClass="button" Text=" 增加 "></asp:Button>
													<asp:Button id="btnCYYJModify" Runat="server" Height="30px" Font-Size="11pt" Font-Name="宋体" CssClass="button" Text=" 更改 "></asp:Button>
													<asp:Button id="btnCYYJDelete" Runat="server" Height="30px" Font-Size="11pt" Font-Name="宋体" CssClass="button" Text=" 删除 "></asp:Button>
													<asp:Button id="btnCYYJSearch" Runat="server" Height="30px" Font-Size="11pt" Font-Name="宋体" CssClass="button" Text=" 全文 "></asp:Button>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="3"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="title" style="" align="center" colSpan="3" height="30"><B>常用意见查看与编辑窗</B></TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="3" height="2"></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" noWrap align="left" colSpan="3">意见内容：</TD>
											</TR>
											<TR>
												<td>&nbsp;</td>
												<TD class="label" vAlign="top" align="left"><asp:textbox id="txtYJNR" Runat="server" Height="370px" Width="200px" Font-Size="11pt" Font-Name="宋体" CssClass="textbox" TextMode="MultiLine"></asp:textbox></TD>
												<td>&nbsp;</td>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="3" height="2"></TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="3" valign="middle">
													<asp:button id="btnSave" Runat="server" Height="30px" Width="96px" Font-Size="11pt" Font-Name="宋体" CssClass="button" Text="保存"></asp:button>
													<asp:button id="btnCancel" Runat="server" Height="30px" Width="96px" Font-Size="11pt" Font-Name="宋体" CssClass="button" Text="取消"></asp:button>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="3"></TD>
								</TR>
								<tr>
									<td colspan="5" height="4"></td>
								</tr>
							</TABLE>
						</TD>
						<TD width="3"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="3"></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3">
							<asp:button id="btnOK" Runat="server" Height="30px" Width="96px" Font-Size="11pt" Font-Name="宋体" CssClass="button" Text=" 选  定 "></asp:button>
							<asp:button id="btnClose" Runat="server" Height="30px" Width="96px" Font-Size="11pt" Font-Name="宋体" CssClass="button" Text=" 返  回 "></asp:button>
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
						<input id="htxtSessionIdCYYJQuery" type="hidden" runat="server">
						<input id="htxtCurrentPage" type="hidden" runat="server">
						<input id="htxtCurrentRow" type="hidden" runat="server">
						<input id="htxtEditMode" type="hidden" runat="server">
						<input id="htxtEditType" type="hidden" runat="server">
						<input id="htxtCYYJQuery" type="hidden" runat="server">
						<input id="htxtCYYJRows" type="hidden" runat="server">
						<input id="htxtCYYJSort" type="hidden" runat="server">
						<input id="htxtCYYJSortColumnIndex" type="hidden" runat="server">
						<input id="htxtCYYJSortType" type="hidden" runat="server">
						<input id="htxtDivLeftCYYJ" type="hidden" runat="server">
						<input id="htxtDivTopCYYJ" type="hidden" runat="server">
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
							function ScrollProc_divCYYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopCYYJ");
								if (oText != null) oText.value = divCYYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftCYYJ");
								if (oText != null) oText.value = divCYYJ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopCYYJ");
								if (oText != null) divCYYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftCYYJ");
								if (oText != null) divCYYJ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divCYYJ.onscroll = ScrollProc_divCYYJ;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" height="48px" width="96px" Visible="False" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
