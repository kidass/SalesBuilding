<%@ Page Language="vb" AutoEventWireup="false" Codebehind="xtgl_sjqx_yh.aspx.vb" Inherits="Josco.JsKernal.web.xtgl_sjqx_yh" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>应用系统数据权限管理窗(基于用户管理)</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdObjectLocked { ; LEFT: expression(divObject.scrollLeft); POSITION: relative }
			TH.grdObjectLocked { ; LEFT: expression(divObject.scrollLeft); POSITION: relative }
			TH.grdObjectLocked { Z-INDEX: 99 }
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
				
				if (document.all("divObject") == null)
					return;
				
				dblHeight = 360 + dblDeltaY + document.body.clientHeight - 570; //default state : 360px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 570 + dblDeltaX + document.body.clientWidth  - 850; //default state : 570px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divObject.style.width  = strWidth;
				divObject.style.height = strHeight;
				divObject.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				
				var objTreeView = null;
				dblHeight = 460 + dblDeltaY + document.body.clientHeight - 570; //default state : 460px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				objTreeView = document.getElementById("tvwServers");
				if (objTreeView)
					objTreeView.style.height = strHeight;
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
		<form id="frmDATAQXGLYS" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD colSpan="3" height="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD align="center" style="BORDER-BOTTOM: #99cccc 2px solid">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left" height="24">
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLRoleQX" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/users.ico" alt="open" border="0" width="16" height="16">角色授权</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLUserQX" runat="server" Font-Name="宋体" Font-Size="11pt" Enabled="False"><img src="../../images/user.ico" alt="open" border="0" width="16" height="16">用户授权</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLAccsQX" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/access.ico" alt="open" border="0" width="16" height="16">存取授权</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLGrant" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/grant.ico" alt="open" border="0" width="16" height="16">赋予权限</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLRevoke" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/revoke.ico" alt="open" border="0" width="16" height="16">回收权限</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLClose" runat="server" Font-Size="11pt" Font-Name="宋体"><img src="../../images/CLOSE.GIF" alt="返回上级" border="0" width="16" height="16">返回上级</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"></TD>
									<TD vAlign="middle" align="center" width="100"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="5" height="30">&nbsp;&nbsp;单击网格列头可进行排序，单击1次为升序排列，再单击1次为降序排列，再单击1次恢复到原始排序。<asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top" align="left" width="220" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD><IEWC:TREEVIEW id="tvwServers" runat="server" Font-Name="宋体" Font-Size="11pt" Height="460px" Width="220px" AutoPostBack="True" CssClass="label"></IEWC:TREEVIEW></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right" width="54">对象名</TD>
															<TD class="label" align="left"><asp:textbox id="txtSearchDXM" runat="server" Font-Size="11pt" CssClass="textbox" Columns="14" height="22px" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right" width="54">中文名</TD>
															<TD class="label" align="left"><asp:textbox id="txtSearchDXZWM" runat="server" Font-Size="11pt" CssClass="textbox" Columns="16" height="22px" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right" width="36">类型</TD>
															<TD class="label" align="left"><asp:textbox id="txtSearchDXLX" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnSearch" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text="搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divObject" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 570px; CLIP: rect(0px 570px 360px 0px); HEIGHT: 360px">
														<asp:datagrid id="grdObject" runat="server" Font-Size="11pt" CssClass="label" Font-Names="宋体"
															UseAccessibleHeader="True" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White"
															BorderStyle="None" CellPadding="4" AllowPaging="True" PageSize="30" BorderColor="#DEDFDE"
															BorderWidth="0px" AllowSorting="True">
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
																		<asp:CheckBox id="chkObject" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="对象名称" SortExpression="对象名称" HeaderText="对象名" CommandName="Select">
																	<HeaderStyle Width="260px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="对象中文名" SortExpression="对象中文名" HeaderText="中文名" CommandName="Select">
																	<HeaderStyle Width="280px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="对象类型" SortExpression="对象类型" HeaderText="类型" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="选择权" SortExpression="选择权" HeaderText="查看权" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="增加权" SortExpression="增加权" HeaderText="增加权" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="编辑权" SortExpression="编辑权" HeaderText="编辑权" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="删除权" SortExpression="删除权" HeaderText="删除权" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="执行权" SortExpression="执行权" HeaderText="执行权" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtObjectFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZMoveFirst" runat="server" Font-Name="宋体" Font-Size="11pt">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZMovePrev" runat="server" Font-Name="宋体" Font-Size="11pt">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZMoveNext" runat="server" Font-Name="宋体" Font-Size="11pt">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZMoveLast" runat="server" Font-Name="宋体" Font-Size="11pt">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZGotoPage" runat="server" Font-Name="宋体" Font-Size="11pt">前往</asp:linkbutton><asp:textbox id="txtPageIndex" runat="server" Font-Name="宋体" Font-Size="11pt" Height="22px" Width="40px" CssClass="textbox" Columns="2">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSetPageSize" runat="server" Font-Name="宋体" Font-Size="11pt">每页</asp:linkbutton><asp:textbox id="txtPageSize" runat="server" Font-Name="宋体" Font-Size="11pt" Height="22px" Width="40px" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" align="right" width="140"><asp:label id="lblGridLocInfo" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
											<TR>
												<TD class="label" style="BORDER-TOP: #99cccc 1px solid" align="center">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" align="center" height="20"><B>数据库对象授权选项</B></TD>
														</TR>
														<TR>
															<TD class="label" align="center" height="20">
																<asp:checkboxlist id="cblObjectQX" Runat="server" Font-Size="11pt" Width="400px" CssClass="label"
																	Font-Names="宋体" RepeatColumns="5">
																	<asp:ListItem Value="Select">查看权</asp:ListItem>
																	<asp:ListItem Value="Insert">增加权</asp:ListItem>
																	<asp:ListItem Value="Update">编辑权</asp:ListItem>
																	<asp:ListItem Value="Delete">删除权</asp:ListItem>
																	<asp:ListItem Value="Execute">执行权</asp:ListItem>
																</asp:checkboxlist></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD colSpan="5" height="5"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
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
						<input id="htxtObjectQuery" type="hidden" runat="server">
						<input id="htxtObjectRows" type="hidden" runat="server">
						<input id="htxtObjectSort" type="hidden" runat="server">
						<input id="htxtObjectSortColumnIndex" type="hidden" runat="server">
						<input id="htxtObjectSortType" type="hidden" runat="server">
						<input id="htxtDivLeftObject" type="hidden" runat="server">
						<input id="htxtDivTopObject" type="hidden" runat="server">
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
							function ScrollProc_DivObject() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopObject");
								if (oText != null) oText.value = divObject.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftObject");
								if (oText != null) oText.value = divObject.scrollLeft;
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
								oText=document.getElementById("htxtDivTopObject");
								if (oText != null) divObject.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftObject");
								if (oText != null) divObject.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divObject.onscroll = ScrollProc_DivObject;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" Visible="False" height="48px" width="96px"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
