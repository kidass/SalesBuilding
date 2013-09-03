<%@ Page Language="vb" AutoEventWireup="false" Codebehind="xtgl_yhgl_yh.aspx.vb" Inherits="Josco.JsKernal.web.xtgl_yhgl_yh" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>用户管理窗</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdBMRYLocked { ; LEFT: expression(divBMRY.scrollLeft); POSITION: relative }
			TH.grdBMRYLocked { ; LEFT: expression(divBMRY.scrollLeft); POSITION: relative }
			TH { Z-INDEX: 10; POSITION: relative }
			TH.grdBMRYLocked { Z-INDEX: 99 }
		</style>
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				var dblDeltaY = 20;
				var dblDeltaX = 20;
				
				if (document.all("divBMRY") == null)
					return;
				
				dblHeight = 420 + dblDeltaY + document.body.clientHeight - 570; //default state : 420px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 780 + dblDeltaX + document.body.clientWidth  - 850; //default state : 780px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divBMRY.style.width  = strWidth;
				divBMRY.style.height = strHeight;
				divBMRY.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
				window_onresize();
			}
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
		<!--
			return document_onreadystatechange()
		//-->
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()" background="../../images/bgmain.gif">
		<form id="frmYHGLYH" method="post" runat="server">
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
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLRoleGL" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/users.ico" alt="role" border="0" width="16" height="16">角色管理</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLUserGL" runat="server" Font-Name="宋体" Font-Size="11pt" Enabled="False"><img src="../../images/user.ico" alt="user" border="0" width="16" height="16">用户管理</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLApplyId" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/new.gif" alt="addnew" border="0" width="16" height="16">申请标识</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLRevokeId" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/delete.gif" alt="delete" border="0" width="16" height="16">删除标识</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLModifyPwd" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/modify.ico" alt="movein" border="0" width="16" height="16">更改密码</asp:linkbutton></TD>
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
									<TD class="tips" align="left" colSpan="3" height="30">&nbsp;&nbsp;单击网格列头可进行排序，单击1次为升序排列，再单击1次为降序排列，再单击1次恢复到原始排序。<asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle">标识</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYDM" runat="server" Font-Size="11pt" Columns="6" CssClass="textbox" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;名称</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYMC" runat="server" Font-Size="11pt" Columns="6" CssClass="textbox" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;申请</TD>
															<TD class="label" align="left">
																<asp:RadioButtonList id="rblApply" Runat="server" CssClass="label" RepeatLayout="Flow" RepeatColumns="3"
																	RepeatDirection="Horizontal">
																	<asp:ListItem Value="无" Selected="True">无</asp:ListItem>
																	<asp:ListItem Value="√">√</asp:ListItem>
																	<asp:ListItem Value="×">×</asp:ListItem>
																</asp:RadioButtonList>
															</TD>
															<TD class="label" vAlign="middle">&nbsp;部门</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_ZZMC" runat="server" Font-Size="11pt" Columns="7" CssClass="textbox" Font-Names="宋体"></asp:textbox></TD>
	                                                        <!-- 曾祥林 2008-05-23 -->
	                                                        <TD class="label" vAlign="middle">&nbsp;有效</TD>
	                                                        <TD class="label" align="left"><asp:DropDownList ID="ddlBMRYSearch_SFYX" Runat="server" Font-Size="11pt" CssClass="textbox" Font-Name="宋体"><asp:ListItem Value="">未设</asp:ListItem><asp:ListItem Value="0">无效</asp:ListItem><asp:ListItem Value="1">有效</asp:ListItem></asp:DropDownList></TD>
	                                                        <!-- 曾祥林 2008-05-23 -->
															<TD class="label" vAlign="middle">&nbsp;序号</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYXHMin" runat="server" Font-Size="11pt" Columns="2" CssClass="textbox" Font-Names="宋体"></asp:textbox>~<asp:textbox id="txtBMRYSearch_RYXHMax" runat="server" Font-Size="11pt" Columns="2" CssClass="textbox" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;级别</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYJBMC" runat="server" Font-Size="11pt" Columns="5" CssClass="textbox" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;职务</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYDRZW" runat="server" Font-Size="11pt" Columns="7" CssClass="textbox" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label">&nbsp;<asp:button id="btnBMRYSearch" Runat="server" Font-Name="宋体" Font-Size="11pt" Width="50px" CssClass="button" Text="搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divBMRY" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 780px; CLIP: rect(0px 780px 420px 0px); HEIGHT: 420px">
														<asp:datagrid id="grdBMRY" runat="server" Font-Size="11pt" Width="1690px" CssClass="label" Font-Names="宋体"
															UseAccessibleHeader="True" AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical"
															BackColor="White" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px"
															AllowSorting="True" CellPadding="4">
															<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选">
																	<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkBMRY" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="是否申请" SortExpression="是否申请" HeaderText="申请?" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="人员代码" SortExpression="人员代码" HeaderText="标识" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="人员名称" SortExpression="人员名称" HeaderText="名称" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="人员真名" SortExpression="人员真名" HeaderText="真名" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="是否有效" SortExpression="是否有效" HeaderText="有效" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="组织名称" SortExpression="组织名称" HeaderText="部门" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="人员序号" SortExpression="人员序号" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="岗位列表" SortExpression="岗位列表" HeaderText="职务" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="级别名称" SortExpression="级别名称" HeaderText="级别" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="秘书名称" SortExpression="秘书名称" HeaderText="秘书" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="联系电话" SortExpression="联系电话" HeaderText="联系电话" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="手机号码" SortExpression="手机号码" HeaderText="移动电话" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="FTP地址" SortExpression="FTP地址" HeaderText="内部邮箱" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="邮箱地址" SortExpression="邮箱地址" HeaderText="因特网邮箱" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="组织代码" SortExpression="组织代码" HeaderText="组织代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="级别代码" SortExpression="级别代码" HeaderText="级别代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="行政级别" SortExpression="行政级别" HeaderText="行政级别" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="秘书代码" SortExpression="秘书代码" HeaderText="秘书代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="自动签收" SortExpression="自动签收" HeaderText="自动签收" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="交接显示名称" SortExpression="交接显示名称" HeaderText="交接显示名称" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="可查看姓名" SortExpression="可查看姓名" HeaderText="可查看姓名" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="可直送人员" SortExpression="可直送人员" HeaderText="可直送人员" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="其他由转送" SortExpression="其他由转送" HeaderText="其他由转送" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="是否加密" SortExpression="是否加密" HeaderText="是否加密" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtBMRYFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR>
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMoveFirst" runat="server" Font-Name="宋体" Font-Size="11pt">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMovePrev" runat="server" Font-Name="宋体" Font-Size="11pt">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMoveNext" runat="server" Font-Name="宋体" Font-Size="11pt">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMoveLast" runat="server" Font-Name="宋体" Font-Size="11pt">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYGotoPage" runat="server" Font-Name="宋体" Font-Size="11pt">前往</asp:linkbutton><asp:textbox id="txtBMRYPageIndex" runat="server" Font-Name="宋体" Font-Size="11pt" Columns="3" CssClass="textbox">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYSetPageSize" runat="server" Font-Name="宋体" Font-Size="11pt">每页</asp:linkbutton><asp:textbox id="txtBMRYPageSize" runat="server" Font-Name="宋体" Font-Size="11pt" Columns="3" CssClass="textbox">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" align="right" width="200"><asp:label id="lblBMRYGridLocInfo" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD colSpan="5" height="3"></TD>
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
						<input id="htxtBMRYQuery" type="hidden" runat="server">
						<input id="htxtBMRYRows" type="hidden" runat="server">
						<input id="htxtBMRYSort" type="hidden" runat="server">
						<input id="htxtBMRYSortColumnIndex" type="hidden" runat="server">
						<input id="htxtBMRYSortType" type="hidden" runat="server">
						<input id="htxtDivLeftBMRY" type="hidden" runat="server">
						<input id="htxtDivTopBMRY" type="hidden" runat="server">
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
							function ScrollProc_divBMRY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopBMRY");
								if (oText != null) oText.value = divBMRY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftBMRY");
								if (oText != null) oText.value = divBMRY.scrollLeft;
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
								oText=document.getElementById("htxtDivTopBMRY");
								if (oText != null) divBMRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBMRY");
								if (oText != null) divBMRY.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divBMRY.onscroll = ScrollProc_divBMRY;
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
