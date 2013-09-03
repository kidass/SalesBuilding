<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_zhigongshuxing.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_zhigongshuxing" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>人事上岗类型编辑窗</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdObjectsLocked { ; LEFT: expression(divObjects.scrollLeft); POSITION: relative }
			TH.grdObjectsLocked { ; LEFT: expression(divObjects.scrollLeft); POSITION: relative }
			TH { Z-INDEX: 10; POSITION: relative }
			TH.grdObjectsLocked { Z-INDEX: 99 }
		</style>
		<script src="../../../scripts/transkey.js"></script>
		<script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var strHeight = "";
				var dblDeltaY = 30;
				
				if (document.all("divObjects") == null)
					return;
				
				dblHeight = 330 + dblDeltaY + document.body.clientHeight - 570; //default state : 330px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				divObjects.style.width  = "100%";
				divObjects.style.height = strHeight;
				divObjects.style.clip = "rect(0px 100% " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()" background="../../../images/bgmain.gif">
		<form id="frmestate_rs_zhigongshuxing" method="post" runat="server">
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
								    <td><asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></td>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLAddNew" runat="server" Font-Size="11pt" Font-Name="宋体"><img src="../../../images/new.gif" border="0" width="16" height="16">增加代码</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLUpdate" runat="server" Font-Size="11pt" Font-Name="宋体"><img src="../../../images/modify.ico" border="0" width="16" height="16">更改代码</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLDelete" runat="server" Font-Size="11pt" Font-Name="宋体"><img src="../../../images/delete.gif" border="0" width="16" height="16">删除代码</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLRefresh" runat="server" Font-Size="11pt" Font-Name="宋体"><img src="../../../images/refresh.ico" border="0" width="16" height="16">刷新数据</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLClose" runat="server" Font-Size="11pt" Font-Name="宋体"><img src="../../../images/CLOSE.GIF" alt="返回上级" border="0" width="16" height="16">返回上级</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"></TD>
									<TD vAlign="middle" align="center" width="100"></TD>
									<TD vAlign="middle" align="center" width="100"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="6"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">代码&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtSearch_SXDM" runat="server" Font-Size="11pt" Columns="20" CssClass="textbox" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;名称&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtSearch_SXMC" runat="server" Font-Size="11pt" Columns="48" CssClass="textbox" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnSearch" Runat="server" Font-Size="11pt" Font-Name="宋体" Width="60px" CssClass="button" Text="搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divObjects" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 100%; CLIP: rect(0px 100% 330px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 330px">
														<asp:datagrid id="grdObjects" runat="server" Font-Size="11pt" CssClass="label" Font-Names="宋体"
															AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="True"
															CellPadding="4" BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
															UseAccessibleHeader="True">
															<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															
															<Columns>
																<asp:TemplateColumn HeaderText="选" ItemStyle-Width="30px">
																	<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkObjects" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="属性代码" SortExpression="属性代码" HeaderText="代码" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="780px" DataTextField="属性名称" SortExpression="属性名称" HeaderText="名称" CommandName="Select">
																	<HeaderStyle Width="780px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtOBJECTSFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR align="center">
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZDeSelectAll" runat="server" Font-Size="11pt" Font-Name="宋体">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSelectAll" runat="server" Font-Size="11pt" Font-Name="宋体">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZMoveFirst" runat="server" Font-Size="11pt" Font-Name="宋体">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZMovePrev" runat="server" Font-Size="11pt" Font-Name="宋体">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZMoveNext" runat="server" Font-Size="11pt" Font-Name="宋体">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZMoveLast" runat="server" Font-Size="11pt" Font-Name="宋体">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZGotoPage" runat="server" Font-Size="11pt" Font-Name="宋体">前往</asp:linkbutton><asp:textbox id="txtPageIndex" runat="server" Font-Size="11pt" Font-Name="宋体" Width="60px" Columns="2" CssClass="textbox">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSetPageSize" runat="server" Font-Size="11pt" Font-Name="宋体">每页</asp:linkbutton><asp:textbox id="txtPageSize" runat="server" Font-Size="11pt" Font-Name="宋体" Width="60px" Columns="3" CssClass="textbox">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" align="right" width="200"><asp:label id="lblGridLocInfo" runat="server" Font-Size="11pt" Font-Name="宋体" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
										</TABLE>
									</td>
									<TD width="5"></TD>
								</tr>
								<TR>
								    <TD width="5"></TD>
									<TD class="label" align="center" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="label" align="center" height="2"></TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="20"><B>人事上岗类型编辑窗</B></TD>
											</TR>
											<TR>
												<TD class="label" align="center">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" align="center" colSpan="2" height="2"></TD>
														</TR>
														<TR>
															<TD class="labelNotNull" align="right" width="40%">代码(*)：</TD>
															<TD class="label" align="left" width="60%"><asp:textbox id="txtSXDM" Runat="server" Font-Size="11pt" Font-Name="宋体" Columns="23" CssClass="textbox"></asp:textbox><SPAN class="label" style="COLOR: red">(nnn.nnn.nnn.nnn)</SPAN></TD>
														</TR>
														<TR>
															<TD class="label" align="center" colSpan="2" height="2"></TD>
														</TR>
														<TR>
															<TD class="labelNotNull" align="right">名称(*)：</TD>
															<TD class="label" align="left"><asp:textbox id="txtSXMC" Runat="server" Font-Size="11pt" Font-Name="宋体" Columns="48" CssClass="textbox"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="label" align="center" colSpan="2" height="2"></TD>
														</TR>
														<TR>
															<TD class="label" align="center" colSpan="2">
																<asp:button id="btnSave" Runat="server" Font-Size="11pt" Font-Name="宋体" Height="24px" Width="96px" CssClass="button" Text="保存"></asp:button>
																<asp:button id="btnCancel" Runat="server" Font-Size="11pt" Font-Name="宋体" Height="24px" Width="96px" CssClass="button" Text="取消"></asp:button>
															</TD>
														</TR>
														<TR>
															<TD class="label" align="center" colSpan="2" height="2"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD colSpan="3" height="5"></TD>
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
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></p></TD>
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
						<input id="htxtCurrentPage" type="hidden" runat="server">
						<input id="htxtCurrentRow" type="hidden" runat="server">
						<input id="htxtEditMode" type="hidden" runat="server">
						<input id="htxtEditType" type="hidden" runat="server">
						<input id="htxtQuery" type="hidden" runat="server">
						<input id="htxtRows" type="hidden" runat="server">
						<input id="htxtSort" type="hidden" runat="server">
						<input id="htxtSortColumnIndex" type="hidden" runat="server">
						<input id="htxtSortType" type="hidden" runat="server">
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
								if (oText != null) oText.value = divObjects.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftObject");
								if (oText != null) oText.value = divObjects.scrollLeft;
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
								if (oText != null) divObjects.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftObject");
								if (oText != null) divObjects.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divObjects.onscroll = ScrollProc_DivObject;
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
