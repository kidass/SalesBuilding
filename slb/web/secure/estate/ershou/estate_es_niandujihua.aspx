<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_niandujihua.aspx.vb" Inherits="Josco.JSOA.web.estate_es_niandujihua"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>二手代理年度计划编辑窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()"
		background="../../../images/bgmain.gif">
		<form id="estate_es_niandujihua" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD colSpan="3" height="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD style="BORDER-BOTTOM: #99cccc 2px solid" align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left" height="24">
									<TD>
										<asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
									<TD vAlign="middle" align="center" width="100">
										<asp:linkbutton id="lnkMLAddNew" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../../images/new.gif" border="0" width="16" height="16">增加计划</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100">
										<asp:linkbutton id="lnkMLUpdate" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../../images/modify.ico" border="0" width="16" height="16">更改计划</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100">
										<asp:linkbutton id="lnkMLDelete" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../../images/delete.gif" border="0" width="16" height="16">删除计划</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100">
										<asp:linkbutton id="lnkMLRefresh" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../../images/refresh.ico" border="0" width="16" height="16">刷新数据</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100">
										<asp:linkbutton id="lnkMLClose" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../../images/CLOSE.GIF" alt="返回上级" border="0" width="16" height="16">返回上级</asp:linkbutton></TD>
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
															<TD class="label" vAlign="middle" align="right">计划年度&nbsp;</TD>
															<TD class="label" align="left">
																<asp:textbox id="txtSearch_JHND" runat="server" Font-Size="11pt" Font-Names="宋体" CssClass="textbox"
																	Columns="20"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;计划类型&nbsp;</TD>
															<TD class="label" align="left">
																<asp:RadioButtonList id="rblSearch_JHLX" Runat="server" Font-Name="宋体" Font-Size="12px" CssClass="textbox"
																	RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
																	<asp:ListItem Value="1">代理费</asp:ListItem>
																	<asp:ListItem Value="2">代理宗数</asp:ListItem>
																</asp:RadioButtonList></TD>
															<TD class="label">&nbsp;&nbsp;
																<asp:button id="btnSearch" Runat="server" Width="60px" Font-Name="宋体" Font-Size="11pt" CssClass="button"
																	Text="搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divObjects" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 100%; CLIP: rect(0px 100% 330px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 330px">
														<asp:datagrid id="grdObjects" runat="server" Font-Size="11pt" Font-Names="宋体" CssClass="label"
															UseAccessibleHeader="True" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White"
															BorderStyle="None" CellPadding="4" AllowPaging="True" PageSize="30" BorderColor="#DEDFDE"
															BorderWidth="0px" AllowSorting="True">
															<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000"
																BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold"
																VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold"
																VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
																BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															
															<Columns>
																<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkObjects" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																
																<asp:ButtonColumn ItemStyle-Width="0px" DataTextField="唯一标识" Visible =False  SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>															
																
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="计划年度" SortExpression="计划年度" HeaderText="计划年度" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" DataTextField="计划类型" Visible =False  SortExpression="计划类型" HeaderText="计划类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="类型名称" SortExpression="类型名称" HeaderText="类型名称" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="580px" DataTextField="计划额度" SortExpression="计划额度" HeaderText="计划额度" CommandName="Select">
																	<HeaderStyle Width="580px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页"
																HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtOBJECTSFixed" type="hidden" value="0" name="htxtOBJECTSFixed" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR align="center">
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZMoveFirst" runat="server" Font-Name="宋体" Font-Size="11pt">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZMovePrev" runat="server" Font-Name="宋体" Font-Size="11pt">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZMoveNext" runat="server" Font-Name="宋体" Font-Size="11pt">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZMoveLast" runat="server" Font-Name="宋体" Font-Size="11pt">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZGotoPage" runat="server" Font-Name="宋体" Font-Size="11pt">前往</asp:linkbutton>
																<asp:textbox id="txtPageIndex" runat="server" Width="60px" Font-Name="宋体" Font-Size="11pt" CssClass="textbox"
																	Columns="2">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZSetPageSize" runat="server" Font-Name="宋体" Font-Size="11pt">每页</asp:linkbutton>
																<asp:textbox id="txtPageSize" runat="server" Width="60px" Font-Name="宋体" Font-Size="11pt" CssClass="textbox"
																	Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" align="right" width="200">
																<asp:label id="lblGridLocInfo" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD class="label" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid"
										align="center">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="label" align="center" height="2"></TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="20"><B>年度计划编辑窗</B></TD>
											</TR>
											<TR>
												<TD class="label" align="center">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" align="center" colSpan="2" height="2"></TD>
														</TR>
														<TR>
															<TD class="labelNotNull" align="right" width="40%">计划年度(*)：</TD>
															<TD class="label" align="left" width="60%">
																<asp:textbox id="txtJHND" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="23"></asp:textbox><SPAN class="label" style="COLOR: red">(yyyy)</SPAN></TD>
														</TR>
														<TR>
															<TD class="label" align="center" colSpan="2" height="2"></TD>
														</TR>
														<TR>
															<TD class="labelNotNull" align="right">计划类型(*)：</TD>
															<TD class="label" align="left">
																<asp:RadioButtonList id="rblJHLX" Runat="server" Font-Name="宋体" Font-Size="12px" CssClass="textbox" RepeatLayout="Flow"
																	RepeatDirection="Vertical" RepeatColumns="2">
																	<asp:ListItem Value="1">代理费</asp:ListItem>
																	<asp:ListItem Value="2">代理宗数</asp:ListItem>
																</asp:RadioButtonList></TD>
														</TR>
														<TR>
															<TD class="label" align="center" colSpan="2" height="2"></TD>
														</TR>
														<TR>
															<TD class="labelNotNull" align="right" width="40%">计划额度(*)：</TD>
															<TD class="label" align="left" width="60%">
																<asp:textbox id="txtJHED" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="23"></asp:textbox><SPAN class="label" style="COLOR: red"></SPAN></TD>
														</TR>
														<TR>
															<TD class="label" align="center" colSpan="2" height="2"></TD>
														</TR>
														<TR>
															<TD class="label" align="center" colSpan="2">
																<asp:button id="btnSave" Runat="server" Width="96px" Height="24px" Font-Name="宋体" Font-Size="11pt"
																	CssClass="button" Text="保存"></asp:button>
																<asp:button id="btnCancel" Runat="server" Width="96px" Height="24px" Font-Name="宋体" Font-Size="11pt"
																	CssClass="button" Text="取消"></asp:button></TD>
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
				<TABLE height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt"
										align="center">
										<asp:Label id="lblMessage" Runat="server"></asp:Label>
										<P>&nbsp;&nbsp;</P>
										<P>
											<asp:Button id="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></P>
									</TD>
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
						<input id="htxtCurrentPage" type="hidden" runat="server" NAME="htxtCurrentPage">
						<input id="htxtCurrentRow" type="hidden" runat="server" NAME="htxtCurrentRow"> <input id="htxtEditMode" type="hidden" runat="server" NAME="htxtEditMode">
						<input id="htxtEditType" type="hidden" runat="server" NAME="htxtEditType"> <input id="htxtQuery" type="hidden" runat="server" NAME="htxtQuery">
						<input id="htxtRows" type="hidden" runat="server" NAME="htxtRows"> <input id="htxtSort" type="hidden" runat="server" NAME="htxtSort">
						<input id="htxtSortColumnIndex" type="hidden" runat="server" NAME="htxtSortColumnIndex">
						<input id="htxtSortType" type="hidden" runat="server" NAME="htxtSortType"> <input id="htxtDivLeftObject" type="hidden" runat="server" NAME="htxtDivLeftObject">
						<input id="htxtDivTopObject" type="hidden" runat="server" NAME="htxtDivTopObject">
						<input id="htxtDivLeftBody" type="hidden" runat="server" NAME="htxtDivLeftBody">
						<input id="htxtDivTopBody" type="hidden" runat="server" NAME="htxtDivTopBody">
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
						<uwin:popmessage id="popMessageObject" runat="server" height="48px" width="96px" Visible="False"
							ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
