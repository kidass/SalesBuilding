<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_lzqk.aspx.vb" Inherits="Josco.JSOA.web.flow_lzqk"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>文件流转情况显示窗</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdLZXXLocked { ; LEFT: expression(divLZXX.scrollLeft); POSITION: relative }
			TH.grdLZXXLocked { ; LEFT: expression(divLZXX.scrollLeft); POSITION: relative }
			TH.grdLZXXLocked { Z-INDEX: 99 }
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
				
				if (document.all("divLZXX") == null)
					return;
				
				dblHeight = 440 + dblDeltaY + document.body.clientHeight - 570; //default state : 440px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 850; //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divLZXX.style.width  = strWidth;
				divLZXX.style.height = strHeight;
				divLZXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmFLOW_LZQK" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="3" height="4"></TD>
								</TR>
								<TR>
									<TD width="5"><asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<TD  height="8"></TD>
											</tr>
											<TR>
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label-text" vAlign="middle">发送人&nbsp;</TD>
															<TD class="label-text" align="left"><asp:textbox id="txtLZXXSearch_FSR" runat="server"  CssClass="textbox-text" Columns="16"></asp:textbox></TD>
															<TD class="label-text" vAlign="middle">&nbsp;&nbsp;接收人&nbsp;</TD>
															<TD class="label-text" align="left"><asp:textbox id="txtLZXXSearch_JSR" runat="server"  CssClass="textbox-text" Columns="16" ></asp:textbox></TD>
															<TD class="label-text" vAlign="middle">&nbsp;&nbsp;事宜&nbsp;</TD>
															<TD class="label-text" align="left"><asp:textbox id="txtLZXXSearch_BLSY" runat="server" CssClass="textbox-text" Columns="16"></asp:textbox></TD>
															<TD class="label-text" vAlign="middle">&nbsp;&nbsp;完成日期&nbsp;</TD>
															<TD class="label-text" align="left"><asp:textbox id="txtLZXXSearch_WCRQMin" runat="server"  CssClass="textbox-text" Columns="12" ></asp:textbox>~<asp:textbox id="txtLZXXSearch_WCRQMax" runat="server"  CssClass="textbox-text" Columns="12" ></asp:textbox></TD>
															<TD class="label-text">&nbsp;&nbsp;<asp:button id="btnLZXXSearch" Runat="server"  CssClass="button" Text="快速搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divLZXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 440px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 440px;">
														<asp:datagrid id="grdLZXX" runat="server" Width="1710px" CssClass="labelGrid" Font-Size="13px" Font-Names="宋体"
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                            PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
                                                            <SelectedItemStyle Font-Size="13px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Bottom" ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="13px" Font-Names="宋体"  BackColor="#FFCC00" VerticalAlign="Bottom"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="13px" Font-Names="宋体" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Bottom" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="13px" Font-Names="宋体" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Bottom" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="13px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选">
																	<HeaderStyle HorizontalAlign="Center" Width="30px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Bottom"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkLZXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="原交接号" SortExpression="原交接号" HeaderText="原交接号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="发送序号" SortExpression="发送序号" HeaderText="发送序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="接收序号" SortExpression="接收序号" HeaderText="接收序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="交接序号" SortExpression="交接序号" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送人" SortExpression="发送人" HeaderText="发送人" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收人" SortExpression="接收人" HeaderText="接收人" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="协办" SortExpression="协办" HeaderText="协办" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理子类" SortExpression="办理子类" HeaderText="办理事宜" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理状态" SortExpression="办理状态" HeaderText="办理状态" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="委托人" SortExpression="委托人" HeaderText="委托人" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送日期" SortExpression="发送日期" HeaderText="发送日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收日期" SortExpression="接收日期" HeaderText="接收日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="完成日期" SortExpression="完成日期" HeaderText="完成日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理最后期限" SortExpression="办理最后期限" HeaderText="办理期限" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送纸质文件" SortExpression="发送纸质文件" HeaderText="发送纸质文件份数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送电子文件" SortExpression="发送电子文件" HeaderText="发送电子文件份数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送纸质附件" SortExpression="发送纸质附件" HeaderText="发送纸质附件份数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送电子附件" SortExpression="发送电子附件" HeaderText="发送电子附件份数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收纸质文件" SortExpression="接收纸质文件" HeaderText="接收纸质文件份数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收电子文件" SortExpression="接收电子文件" HeaderText="接收电子文件份数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收纸质附件" SortExpression="接收纸质附件" HeaderText="接收纸质附件份数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收电子附件" SortExpression="接收电子附件" HeaderText="接收电子附件份数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="交接标识" SortExpression="交接标识" HeaderText="交接标识" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="办理类型" SortExpression="办理类型" HeaderText="办理类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页"  PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtLZXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR>
												<TD>
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXDeSelectAll" runat="server" CssClass="labelBlack">不选</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXSelectAll" runat="server" CssClass="labelBlack">全选</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXMoveFirst" runat="server" CssClass="labelBlack">最前</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXMovePrev" runat="server" CssClass="labelBlack">前页</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXMoveNext" runat="server" CssClass="labelBlack">下页</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXMoveLast" runat="server" CssClass="labelBlack">最后</asp:linkbutton></TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXGotoPage" runat="server"  CssClass="labelBlack">前往</asp:linkbutton><asp:textbox id="txtLZXXPageIndex" runat="server"  CssClass="textbox-text" Columns="3">1</asp:textbox>页</TD>
															<TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXSetPageSize" runat="server" CssClass="labelBlack">每页</asp:linkbutton><asp:textbox id="txtLZXXPageSize" runat="server"  CssClass="textbox-text" Columns="3">30</asp:textbox>条</TD>
															<TD class="labelBlack" vAlign="middle" noWrap align="right"><asp:label id="lblLZXXGridLocInfo" runat="server" Font-Size="12px" CssClass="labelBlack">1/10 N/15</asp:label></TD>
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
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="3"></TD>
					</TR>
					<TR>
						<TD colSpan="3" align="center">
							<asp:Button id="btnCKYJ" Runat="server" Height="36px"  CssClass="button" Text=" 查看意见 "></asp:Button>
							<asp:Button id="btnSearch" Runat="server" Height="36px"  CssClass="button" Text=" 全文检索 "></asp:Button>
							<asp:Button id="btnClose" Runat="server" Height="36px"  CssClass="button" Text=" 返    回 "></asp:Button>
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
						<input id="htxtSessionIdQuery" type="hidden" runat="server">
						<input id="htxtLZXXQuery" type="hidden" runat="server">
						<input id="htxtLZXXRows" type="hidden" runat="server">
						<input id="htxtLZXXSort" type="hidden" runat="server">
						<input id="htxtLZXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtLZXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftLZXX" type="hidden" runat="server">
						<input id="htxtDivTopLZXX" type="hidden" runat="server">
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
							function ScrollProc_divLZXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopLZXX");
								if (oText != null) oText.value = divLZXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftLZXX");
								if (oText != null) oText.value = divLZXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopLZXX");
								if (oText != null) divLZXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftLZXX");
								if (oText != null) divLZXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divLZXX.onscroll = ScrollProc_divLZXX;
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
