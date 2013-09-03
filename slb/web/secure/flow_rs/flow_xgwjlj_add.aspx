<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_xgwjlj_add.aspx.vb" Inherits="Josco.JSOA.web.flow_xgwjlj_add"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>相关链接文件添加处理窗</title>   
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdFILELocked { ; LEFT: expression(divFILE.scrollLeft); POSITION: relative }
		    TH.grdFILELocked { ; LEFT: expression(divFILE.scrollLeft); POSITION: relative }
		    TH { Z-INDEX: 10; POSITION: relative }
		    TH.grdFILELocked { Z-INDEX: 99 }
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
				
				if (document.all("divFILE") == null)
					return;
				
				dblHeight = 400 + dblDeltaY + document.body.clientHeight - 550; //default state : 400px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 850; //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divFILE.style.width  = strWidth;
				divFILE.style.height = strHeight;
				divFILE.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmFLOW_XGWJLJ_ADD" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD colSpan="3" height="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="3"><asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD vAlign="middle">年度&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtFILESearch_NDMIN" runat="server" CssClass="textbox" Columns="4"></asp:textbox>~<asp:textbox id="txtFILESearch_NDMAX" runat="server" CssClass="textbox" Columns="4"></asp:textbox></TD>
															<TD vAlign="middle">&nbsp;&nbsp;流水号&nbsp;</TD>
															<TD align="left"><asp:textbox id="txtFILESearch_LSH" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD vAlign="middle">&nbsp;&nbsp;标题&nbsp;</TD>
															<TD align="left"><asp:textbox id="txtFILESearch_WJBT" runat="server" CssClass="textbox" Columns="20"></asp:textbox></TD>
															<TD vAlign="middle">&nbsp;&nbsp;文号&nbsp;</TD>
															<TD align="left"><asp:textbox id="txtFILESearch_WJZH" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD vAlign="middle" noWrap>&nbsp;&nbsp;主送/来文/主办单位&nbsp;</TD>
															<TD align="left"><asp:textbox id="txtFILESearch_ZBDW" runat="server" CssClass="textbox" Columns="13"></asp:textbox></TD>
															<TD>&nbsp;&nbsp;<asp:button id="btnFILESearch" Runat="server" CssClass="button" Text="搜索"></asp:button><asp:button id="btnFILEFullSearch" Runat="server"  CssClass="button" Text="全文搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD  height="5"></TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divFILE" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 600px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 600px">
														<asp:datagrid id="grdFILE" runat="server" Width="1110px" CssClass="labelGrid" Font-Size="14px" Font-Names="宋体"
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                            PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
                                                            <SelectedItemStyle Font-Size="14px" Font-Names="宋体" Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="14px" Font-Names="宋体"  BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="14px" Font-Names="宋体" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="14px" Font-Names="宋体" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="14px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选">
																	<HeaderStyle HorizontalAlign="Center" Width="20px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkFILE" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="办理类型" SortExpression="办理类型" HeaderText="办理类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="文件子类" SortExpression="文件子类" HeaderText="类型" CommandName="Select">
																	<HeaderStyle Width="110px"></HeaderStyle>
																</asp:ButtonColumn>																
																<asp:ButtonColumn DataTextField="文件标题" SortExpression="文件标题" HeaderText="标题" CommandName="OpenDocument">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="主送单位" SortExpression="主送单位" HeaderText="主送/来文/主办单位" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="文件字号" SortExpression="文件字号" HeaderText="文号" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="文件年度" SortExpression="文件年度" HeaderText="年度" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理状态" SortExpression="办理状态" HeaderText="状态" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="流水号" SortExpression="流水号" HeaderText="流水号" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="紧急程度" SortExpression="紧急程度" HeaderText="紧急" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="秘密等级" SortExpression="秘密等级" HeaderText="密级" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件类型" SortExpression="文件类型" HeaderText="文件类型" CommandName="Select">
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
																<asp:ButtonColumn Visible="False" DataTextField="快速收文" SortExpression="快速收文" HeaderText="快速收文" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtFILEFixed" type="hidden" value="1" name="htxtFILEFixed" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR>
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEDeSelectAll" runat="server" CssClass="labelBlack">不选</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILESelectAll" runat="server" CssClass="labelBlack">全选</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveFirst" runat="server" CssClass="labelBlack">最前</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMovePrev" runat="server" CssClass="labelBlack">前页</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveNext" runat="server" CssClass="labelBlack">下页</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveLast" runat="server" CssClass="labelBlack">最后</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" noWrap align="left"><asp:linkbutton id="lnkCZFILEGotoPage" runat="server"  CssClass="labelBlack">前往</asp:linkbutton><asp:textbox id="txtFILEPageIndex" runat="server" Font-Size="13px" Font-Name="宋体" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
															<TD class="labelBlack" vAlign="middle" noWrap align="left"><asp:linkbutton id="lnkCZFILESetPageSize" runat="server"   CssClass="labelBlack">每页</asp:linkbutton><asp:textbox id="txtFILEPageSize" runat="server" Font-Size="13px" Font-Name="宋体" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="labelBlack" vAlign="middle" align="right"><asp:label id="lblFILEGridLocInfo" runat="server" Font-Size="14px" CssClass="labelBlack">1/10 N/15</asp:label></TD>
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
					<tr>
						<td colspan="3" height="5"></td>
					</tr>
					<TR>
						<TD colSpan="3" align="center"><asp:Button ID="btnOK" Runat="server"  CssClass="button" Text=" 添   加 " Height="30px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnOpenFile" Runat="server"  CssClass="button" Text=" 查   看 " Height="30px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancel" Runat="server"  CssClass="button" Text=" 取   消 " Height="30px"></asp:Button></TD>
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
						<input id="htxtSessionIdQuery" type="hidden" runat="server">
						<input id="htxtFILEQuery" type="hidden" runat="server">
						<input id="htxtFILERows" type="hidden" runat="server">
						<input id="htxtFILESort" type="hidden" runat="server">
						<input id="htxtFILESortColumnIndex" type="hidden" runat="server">
						<input id="htxtFILESortType" type="hidden" runat="server">
						<input id="htxtDivLeftFILE" type="hidden" runat="server">
						<input id="htxtDivTopFILE" type="hidden" runat="server">
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
							function ScrollProc_divFILE() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFILE");
								if (oText != null) oText.value = divFILE.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFILE");
								if (oText != null) oText.value = divFILE.scrollLeft;
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
								oText=document.getElementById("htxtDivTopFILE");
								if (oText != null) divFILE.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFILE");
								if (oText != null) divFILE.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divFILE.onscroll = ScrollProc_divFILE;
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
