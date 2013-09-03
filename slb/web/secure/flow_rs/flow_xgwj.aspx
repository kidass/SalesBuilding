 <%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_xgwj.aspx.vb" Inherits="Josco.JSOA.web.flow_xgwj"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>文件链接信息查看与编辑主窗口</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styleGW.css" type="text/css" rel="stylesheet">
		<style>
		TD.grdXGWJLocked { ; LEFT: expression(divXGWJ.scrollLeft); POSITION: relative }
		TH.grdXGWJLocked { ; LEFT: expression(divXGWJ.scrollLeft); POSITION: relative }
		TH { Z-INDEX: 10; POSITION: relative }
		TH.grdXGWJLocked { Z-INDEX: 99 }
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
				
				if (document.all("divXGWJ") == null)
					return;
				
				dblHeight = 460 + dblDeltaY + document.body.clientHeight - 570; //default state : 460px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 850; //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divXGWJ.style.width  = strWidth;
				divXGWJ.style.height = strHeight;
				divXGWJ.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body background="../../images/oabk.gif" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmFLOW_XGWJ" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD colSpan="3" height="10"></TD>
					</TR>
					<TR>
						<TD width="5"><asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
						<TD align="center" style="BORDER-BOTTOM: #99cccc 2px solid">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left" height="24">
									<TD vAlign="middle" noWrap align="center"><asp:linkbutton id="lnkMLAddNewWJ" runat="server" CssClass="label-link"><img src="../../images/new.gif" alt="addnew" border="0" width="16" height="16" align="absmiddle">添加系统内相关文</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap align="center"><asp:linkbutton id="lnkMLAddNew" runat="server" CssClass="label-link"><img src="../../images/new.gif" alt="addnew" border="0" width="16" height="16" align="absmiddle">添加系统外文件</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap align="center"><asp:linkbutton id="lnkMLModify" runat="server" CssClass="label-link"><img src="../../images/modify.ico" alt="modify" border="0" width="16" height="16" align="absmiddle">修改系统外文件</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap align="center"><asp:linkbutton id="lnkMLDelete" runat="server" CssClass="label-link"><img src="../../images/delete.gif" alt="delete" border="0" width="16" height="16" align="absmiddle">删除</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap align="center"><asp:linkbutton id="lnkMLSelect" runat="server" CssClass="label-link"><img src="../../images/open.gif" alt="open" border="0" width="16" height="16" align="absmiddle">查看</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap align="center"><asp:linkbutton id="lnkMLMoveUp" runat="server" CssClass="label-link"><img src="../../images/arwup.ico" alt="moveup" border="0" width="16" height="16" align="absmiddle">上移</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap align="center"><asp:linkbutton id="lnkMLMoveDn" runat="server" CssClass="label-link"><img src="../../images/arwdn.ico" alt="movedown" border="0" width="16" height="16" align="absmiddle">下移</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap align="center"><asp:linkbutton id="lnkMLAutoXH" runat="server" CssClass="label-link"><img src="../../images/autoxh.gif" alt="auto_set_xh" border="0" width="16" height="16" align="absmiddle">自动调号</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap align="center"><asp:linkbutton id="lnkMLExport" runat="server" CssClass="label-link"><img src="../../images/export.ico" alt="export" border="0" width="16" height="16" align="absmiddle">导出</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap align="center"><asp:linkbutton id="lnkMLClose" runat="server" CssClass="label-link"><img src="../../images/close.gif" alt="close" border="0" width="16" height="16" align="absmiddle">返回</asp:linkbutton></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="3"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="3" height="5"></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											
											<tr>
												<td height="3"></td>
											</tr>
											<TR>
												<TD>
													<DIV id="divXGWJ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 460px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 460px">
														<asp:datagrid id="grdXGWJ" runat="server" CssClass="labelGrid" Font-Size="13px" Font-Names="宋体"
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                            PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
                                                            <SelectedItemStyle Font-Size="13px" Font-Names="宋体" Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="13px" Font-Names="宋体"  BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="13px" Font-Names="宋体" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="13px" Font-Names="宋体" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="13px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn Visible="False"  HeaderText="选">
																	<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkXGWJ" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="显示序号" SortExpression="显示序号" HeaderText="序号" CommandName="Select" >
																	<HeaderStyle Width="50px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="文件标题" SortExpression="文件标题" HeaderText="标题" CommandName="OpenDocument">
																	<HeaderStyle Width="900px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="类别标识" SortExpression="类别标识" HeaderText="类别标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="流水号" SortExpression="流水号" HeaderText="流水号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件类型" SortExpression="文件类型" HeaderText="文件类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="办理类型" SortExpression="办理类型" HeaderText="办理类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件子类" SortExpression="文件子类" HeaderText="文件子类" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="办理状态" SortExpression="办理状态" HeaderText="办理状态" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="主送单位" SortExpression="主送单位" HeaderText="主送单位" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="机关代字" SortExpression="机关代字" HeaderText="机关代字" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件年份" SortExpression="文件年份" HeaderText="文件年份" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件序号" SortExpression="文件序号" HeaderText="文件序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="主办单位" SortExpression="主办单位" HeaderText="主办单位" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="拟稿人" SortExpression="拟稿人" HeaderText="拟稿人" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="拟稿日期" SortExpression="拟稿日期" HeaderText="拟稿日期" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="主题词" SortExpression="主题词" HeaderText="主题词" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="快速收文" SortExpression="快速收文" HeaderText="快速收文" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="序号" SortExpression="序号" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="页数" SortExpression="页数" HeaderText="页数" CommandName="Select">
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
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtXGWJFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR>
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="labelBlack" vAlign="middle" align="left"><div style="display:none"><asp:linkbutton id="lnkCZXGWJDeSelectAll" runat="server" CssClass="labelBlack">不选</asp:linkbutton></div></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><div style="display:none"><asp:linkbutton id="lnkCZXGWJSelectAll" runat="server" CssClass="labelBlack">全选</asp:linkbutton></div></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZXGWJMoveFirst" runat="server" CssClass="labelBlack">最前</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZXGWJMovePrev" runat="server" CssClass="labelBlack">前页</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZXGWJMoveNext" runat="server" CssClass="labelBlack">下页</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZXGWJMoveLast" runat="server" CssClass="labelBlack">最后</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" noWrap align="right"><asp:linkbutton id="lnkCZXGWJGotoPage" runat="server" CssClass="labelBlack">前往</asp:linkbutton><asp:textbox id="txtXGWJPageIndex" runat="server"  CssClass="textbox-linkbutton" Columns="1">1</asp:textbox>页</TD>
															<TD class="labelBlack" vAlign="middle" noWrap align="right"><asp:linkbutton id="lnkCZXGWJSetPageSize" runat="server" CssClass="labelBlack">每页</asp:linkbutton><asp:textbox id="txtXGWJPageSize" runat="server"  CssClass="textbox-linkbutton" Columns="1">30</asp:textbox>条</TD>
															<TD class="labelBlack" vAlign="middle" align="right" width="200"><asp:label id="lblXGWJGridLocInfo" runat="server" CssClass="labelBlack">1/10 N/15</asp:label></TD>
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
				<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE id="tabErrInfo" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" 返回 " style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();"></p></TD>
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
						<input id="htxtXGWJQuery" type="hidden" runat="server">
						<input id="htxtXGWJRows" type="hidden" runat="server">
						<input id="htxtXGWJSort" type="hidden" runat="server">
						<input id="htxtXGWJSortColumnIndex" type="hidden" runat="server">
						<input id="htxtXGWJSortType" type="hidden" runat="server">
						<input id="htxtDivLeftXGWJ" type="hidden" runat="server">
						<input id="htxtDivTopXGWJ" type="hidden" runat="server">
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
							function ScrollProc_divXGWJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopXGWJ");
								if (oText != null) oText.value = divXGWJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftXGWJ");
								if (oText != null) oText.value = divXGWJ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopXGWJ");
								if (oText != null) divXGWJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftXGWJ");
								if (oText != null) divXGWJ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divXGWJ.onscroll = ScrollProc_divXGWJ;
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
