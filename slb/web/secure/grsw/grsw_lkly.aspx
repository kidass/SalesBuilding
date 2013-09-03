<%@ Page Language="vb" AutoEventWireup="false" Codebehind="grsw_lkly.aspx.vb" Inherits="Josco.JsKernal.web.grsw_lkly" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>我的委托留言处理窗</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdWWTLocked { ; LEFT: expression(divWWT.scrollLeft); POSITION: relative }
			TH.grdWWTLocked { ; LEFT: expression(divWWT.scrollLeft); POSITION: relative }
			TH.grdWWTLocked { Z-INDEX: 99 }
			TD.grdWSTLocked { ; LEFT: expression(divWST.scrollLeft); POSITION: relative }
			TH.grdWSTLocked { ; LEFT: expression(divWST.scrollLeft); POSITION: relative }
			TH.grdWSTLocked { Z-INDEX: 99 }
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
				
				if (document.all("divWST") == null)
					return;
				
				dblHeight = 120 + dblDeltaY + document.body.clientHeight - 570; //default state : 120px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 850; //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divWST.style.width  = strWidth;
				divWST.style.height = strHeight;
				divWST.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				
				strHeight = divWWT.style.height;
				strWidth  = (document.body.clientWidth - tdCol1.clientWidth - 48).toString() + "px";
				divWWT.style.width = strWidth;
				divWWT.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmGRSW_LKLY" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="3"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="title" align="left" colSpan="3" height="24">&nbsp;&nbsp;<B>我的留言一览表</B><asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
									<td align="right"><asp:Button ID="btnClose" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text=" 安全返回 "></asp:Button></td>
									<TD width="3"></TD>
								</TR>
								<TR>
									<TD width="3"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR align="center">
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWWTDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWWTSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWWTMoveFirst" runat="server" Font-Name="宋体" Font-Size="11pt">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWWTMovePrev" runat="server" Font-Name="宋体" Font-Size="11pt">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWWTMoveNext" runat="server" Font-Name="宋体" Font-Size="11pt">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWWTMoveLast" runat="server" Font-Name="宋体" Font-Size="11pt">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" noWrap><asp:linkbutton id="lnkCZWWTGotoPage" runat="server" Font-Name="宋体" Font-Size="11pt">前往</asp:linkbutton><asp:textbox id="txtWWTPageIndex" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="2">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" noWrap><asp:linkbutton id="lnkCZWWTSetPageSize" runat="server" Font-Name="宋体" Font-Size="11pt">每页</asp:linkbutton><asp:textbox id="txtWWTPageSize" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" align="right"><asp:label id="lblWWTGridLocInfo" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right" nowrap>受托人</TD>
															<TD class="label" align="left"><asp:textbox id="txtWWTSearch_STR" runat="server" Font-Size="11pt" CssClass="textbox" Columns="8" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right" nowrap>委托日期</TD>
															<TD class="label" align="left"><asp:textbox id="txtWWTSearch_WTRQMin" runat="server" Font-Size="11pt" CssClass="textbox" Columns="10" Font-Names="宋体"></asp:textbox><asp:textbox id="txtWWTSearch_WTRQMax" runat="server" Font-Size="11pt" CssClass="textbox" Columns="10" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right" nowrap>留言内容</TD>
															<TD class="label" align="left"><asp:textbox id="txtWWTSearch_LYNR" runat="server" Font-Size="11pt" CssClass="textbox" Columns="8" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnWWTQuery" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text="搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divWWT" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 550px; CLIP: rect(0px 550px 200px 0px); HEIGHT: 200px">
														<asp:datagrid id="grdWWT" runat="server" Font-Size="11pt" CssClass="label" Font-Names="宋体" UseAccessibleHeader="True"
															AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="4"
															AllowPaging="True" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True">
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
																		<asp:CheckBox id="chkWWT" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="标识" SortExpression="标识" HeaderText="标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="留言人" SortExpression="留言人" HeaderText="留言人" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="委托代理人" SortExpression="委托代理人" HeaderText="受托人" CommandName="Select">
																	<HeaderStyle Width="90px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="留言日期" SortExpression="留言日期" HeaderText="留言日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="生效日期" SortExpression="生效日期" HeaderText="生效日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="失效日期" SortExpression="失效日期" HeaderText="失效日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="留言内容" SortExpression="留言内容" HeaderText="留言内容" CommandName="Select">
																	<HeaderStyle Width="550px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtWWTFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<tr>
												<td height="3"></td>
											</tr>
											<TR>
												<TD align="center">
													<asp:Button id="btnWWTAddNew" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text=" 新的留言 "></asp:Button>
													<asp:Button id="btnWWTModify" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text=" 更改留言 "></asp:Button>
													<asp:Button id="btnWWTDelete" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text=" 删除留言 "></asp:Button>
													<asp:Button id="btnWWTSearch" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text=" 全文检索 "></asp:Button>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="3"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top" id="tdCol1">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="title" style="" align="center" colSpan="2" height="30"><B>留言信息查看与编辑窗</B></TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="2" height="2"></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" noWrap align="right" width="40%">委托人：</TD>
												<TD class="label" align="left" width="60%"><asp:textbox id="txtWTR" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="8"></asp:textbox><SPAN class="label" style="COLOR: red">*</SPAN></TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="2" height="2"></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" noWrap align="right" width="40%">留言日期：</TD>
												<TD class="label" align="left" width="60%"><asp:textbox id="txtLYRQ" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="18"></asp:textbox><SPAN class="label" style="COLOR: red">*</SPAN></TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="2" height="2"></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" noWrap align="right">生效日期：</TD>
												<TD class="label" align="left"><asp:textbox id="txtSXRQ" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="18"></asp:textbox><SPAN class="label" style="COLOR: red">*</SPAN></TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="2" height="2"></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" noWrap align="right">失效日期：</TD>
												<TD class="label" align="left"><asp:textbox id="txtZFRQ" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="18"></asp:textbox><SPAN class="label" style="COLOR: red">*</SPAN></TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="2" height="2"></TD>
											</TR>
											<TR>
												<TD class="label" noWrap align="right">受托人：</TD>
												<TD class="label" align="left"><asp:textbox id="txtSTR" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="8"></asp:textbox><asp:LinkButton id="lnkCZSelectRY" Runat="server" CssClass="button"><img src="../../images/glist.gif" border="0" width="16" height="19" align="absmiddle"></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="2" height="2"></TD>
											</TR>
											<TR>
												<TD class="label" noWrap align="right">留言内容：</TD>
												<TD class="label" align="left"><TEXTAREA class="textbox" id="textareaLYNR" rows="5" cols="16" runat="server"></TEXTAREA></TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="2" height="2"></TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="2">
													<asp:button id="btnSave" Runat="server" Width="96px" Height="24px" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text="保存"></asp:button>
													<asp:button id="btnCancel" Runat="server" Width="96px" Height="24px" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text="取消"></asp:button>
												</TD>
											</TR>
											<TR>
												<TD class="label" align="center" colSpan="2" height="2"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="3"></TD>
								</TR>
								<TR>
									<TD class="title" align="left" colSpan="5" height="24">&nbsp;&nbsp;<B>别人给我的留言一览表</B></TD>
								</TR>
								<TR>
									<TD width="3"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" colSpan="3">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR align="center">
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWSTDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWSTSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWSTMoveFirst" runat="server" Font-Name="宋体" Font-Size="11pt">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWSTMovePrev" runat="server" Font-Name="宋体" Font-Size="11pt">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWSTMoveNext" runat="server" Font-Name="宋体" Font-Size="11pt">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZWSTMoveLast" runat="server" Font-Name="宋体" Font-Size="11pt">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" noWrap><asp:linkbutton id="lnkCZWSTGotoPage" runat="server" Font-Name="宋体" Font-Size="11pt">前往</asp:linkbutton><asp:textbox id="txtWSTPageIndex" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="2">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" noWrap><asp:linkbutton id="lnkCZWSTSetPageSize" runat="server" Font-Name="宋体" Font-Size="11pt">每页</asp:linkbutton><asp:textbox id="txtWSTPageSize" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" align="right"><asp:label id="lblWSTGridLocInfo" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right" nowrap>委托人</TD>
															<TD class="label" align="left"><asp:textbox id="txtWSTSearch_WTR" runat="server" Font-Size="11pt" CssClass="textbox" Columns="8" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right" nowrap>交托日期</TD>
															<TD class="label" align="left"><asp:textbox id="txtWSTSearch_WTRQMin" runat="server" Font-Size="11pt" CssClass="textbox" Columns="10" Font-Names="宋体"></asp:textbox><asp:textbox id="txtWSTSearch_WTRQMax" runat="server" Font-Size="11pt" CssClass="textbox" Columns="10" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right" nowrap>留言内容</TD>
															<TD class="label" align="left"><asp:textbox id="txtWSTSearch_LYNR" runat="server" Font-Size="11pt" CssClass="textbox" Columns="8" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnWSTQuery" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text="搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divWST" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 800px; CLIP: rect(0px 800px 120px 0px); HEIGHT: 120px">
														<asp:datagrid id="grdWST" runat="server" Font-Size="11pt" CssClass="label" Font-Names="宋体" UseAccessibleHeader="True"
															AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="4"
															AllowPaging="True" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True">
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
																		<asp:CheckBox id="chkWST" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="标识" SortExpression="标识" HeaderText="标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="留言人" SortExpression="留言人" HeaderText="委托人" CommandName="Select">
																	<HeaderStyle Width="90px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="委托代理人" SortExpression="委托代理人" HeaderText="受托人" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="留言日期" SortExpression="留言日期" HeaderText="留言日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="生效日期" SortExpression="生效日期" HeaderText="生效日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="失效日期" SortExpression="失效日期" HeaderText="失效日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="留言内容" SortExpression="留言内容" HeaderText="留言内容" CommandName="Select">
																	<HeaderStyle Width="610px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtWSTFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<tr>
												<td height="3"></td>
											</tr>
											<TR>
												<TD align="center">
													<asp:Button id="btnWSTAccept" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text=" 接受委托 "></asp:Button>
													<asp:Button id="btnWSTReject" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text=" 拒绝委托 "></asp:Button>
													<asp:Button id="btnWSTSearch" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="button" Text=" 全文检索 "></asp:Button>
												</TD>
											</TR>
											<tr>
												<td height="3"></td>
											</tr>
										</TABLE>
									</TD>
									<TD width="3"></TD>
								</TR>
								<TR>
									<TD colSpan="5" height="4"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="3"></TD>
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
						<input id="htxtSessionIdWSTQuery" type="hidden" runat="server">
						<input id="htxtSessionIdWWTQuery" type="hidden" runat="server">
						<input id="htxtCurrentPage" type="hidden" runat="server">
						<input id="htxtCurrentRow" type="hidden" runat="server">
						<input id="htxtEditMode" type="hidden" runat="server">
						<input id="htxtEditType" type="hidden" runat="server">
						<input id="htxtWSTQuery" type="hidden" runat="server">
						<input id="htxtWSTRows" type="hidden" runat="server">
						<input id="htxtWSTSort" type="hidden" runat="server">
						<input id="htxtWSTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtWSTSortType" type="hidden" runat="server">
						<input id="htxtWWTQuery" type="hidden" runat="server">
						<input id="htxtWWTRows" type="hidden" runat="server">
						<input id="htxtWWTSort" type="hidden" runat="server">
						<input id="htxtWWTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtWWTSortType" type="hidden" runat="server">
						<input id="htxtDivLeftWST" type="hidden" runat="server">
						<input id="htxtDivTopWST" type="hidden" runat="server">
						<input id="htxtDivLeftWWT" type="hidden" runat="server">
						<input id="htxtDivTopWWT" type="hidden" runat="server">
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
							function ScrollProc_divWWT() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopWWT");
								if (oText != null) oText.value = divWWT.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftWWT");
								if (oText != null) oText.value = divWWT.scrollLeft;
								return;
							}
							function ScrollProc_divWST() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopWST");
								if (oText != null) oText.value = divWST.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftWST");
								if (oText != null) oText.value = divWST.scrollLeft;
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
								oText=document.getElementById("htxtDivTopWWT");
								if (oText != null) divWWT.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftWWT");
								if (oText != null) divWWT.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopWST");
								if (oText != null) divWST.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftWST");
								if (oText != null) divWST.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divWWT.onscroll = ScrollProc_divWWT;
								divWST.onscroll = ScrollProc_divWST;
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
