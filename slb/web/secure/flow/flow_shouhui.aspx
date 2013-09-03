<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_shouhui.aspx.vb" Inherits="Josco.JSOA.web.flow_shouhui"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>文件强制收回处理窗口</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdJSRXXLocked { ; LEFT: expression(divJSRXX.scrollLeft); POSITION: relative }
			TH.grdJSRXXLocked { ; LEFT: expression(divJSRXX.scrollLeft); POSITION: relative }
			TH.grdJSRXXLocked { Z-INDEX: 99 }
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
				
				if (document.all("divJSRXX") == null)
					return;
				
				dblHeight = 450 + dblDeltaY + document.body.clientHeight - 570; //default state : 450px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 850; //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divJSRXX.style.width  = strWidth;
				divJSRXX.style.height = strHeight;
				divJSRXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmFLOW_SHOUHUI" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="3" height="26"><B>&nbsp;&nbsp;我准备从以下人员中收回文件&nbsp;&nbsp;&nbsp;&nbsp;</B><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:Label id="lblJSRXXGridLocInfo" Runat="server" CssClass="labelGrid" ></asp:Label><B>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblZZTS" Runat="server" CssClass="labelNotNull" ></asp:Label></B></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divJSRXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 450px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 450px">
														<asp:datagrid id="grdJSRXX" runat="server" CssClass="labelGrid"  Font-Size="12px" Font-Names="宋体" AllowPaging="False"
                                                            AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30"
                                                            BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4" UseAccessibleHeader="True">
                                                           <SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="12px" Font-Names="宋体"  BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选">
																	<HeaderStyle HorizontalAlign="Center" Width="20px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkJSRXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="接收人" SortExpression="接收人" HeaderText="接收人" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="交办事宜" SortExpression="交办事宜" HeaderText="交办事宜" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送日期" SortExpression="发送日期" HeaderText="发送日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送纸质文件份数" SortExpression="发送纸质文件份数" HeaderText="发送纸质文件份数" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送电子文件份数" SortExpression="发送电子文件份数" HeaderText="发送电子文件份数" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送纸质附件份数" SortExpression="发送纸质附件份数" HeaderText="发送纸质附件份数" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="发送电子附件份数" SortExpression="发送电子附件份数" HeaderText="发送电子附件份数" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收日期" SortExpression="接收日期" HeaderText="接收日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收纸质文件份数" SortExpression="接收纸质文件份数" HeaderText="接收纸质文件份数" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收电子文件份数" SortExpression="接收电子文件份数" HeaderText="接收电子文件份数" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收纸质附件份数" SortExpression="接收纸质附件份数" HeaderText="接收纸质附件份数" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="接收电子附件份数" SortExpression="接收电子附件份数" HeaderText="接收电子附件份数" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="交接序号" SortExpression="交接序号" HeaderText="交接序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="发送序号" SortExpression="发送序号" HeaderText="发送序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="原交接号" SortExpression="原交接号" HeaderText="原交接号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="交接标识" SortExpression="交接标识" HeaderText="交接标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="发送人" SortExpression="发送人" HeaderText="发送人" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="协办" SortExpression="协办" HeaderText="协办" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="发送人办理事宜" SortExpression="发送人办理事宜" HeaderText="发送人办理事宜" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="发送人协办" SortExpression="发送人协办" HeaderText="发送人协办" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="Bottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtJSRXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD colSpan="5" height="3"></TD>
								</TR>
								<TR>
									<TD colSpan="5" height="3"><asp:CheckBox ID="chkSHTZ" Runat="server"  CssClass="textbox-text" Text="向被收回人发送收回文件通知"></asp:CheckBox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
					    <td colspan="3" height="3"></td>
					</TR>
					<TR>
						<TD align="center" colSpan="3">
							<asp:Button id="btnShouhui" Runat="server" CssClass="button"  Height="30px" Text=" 收  回 "></asp:Button>
							<asp:Button id="btnRefresh" Runat="server" CssClass="button"  Height="30px" Text=" 刷  新 "></asp:Button>
							<asp:Button id="btnCancel" Runat="server" CssClass="button"  Height="30px" Text=" 取  消 "></asp:Button>
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
						<input id="htxtJSRXXQuery" type="hidden" runat="server">
						<input id="htxtJSRXXRows" type="hidden" runat="server">
						<input id="htxtJSRXXSort" type="hidden" runat="server">
						<input id="htxtJSRXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtJSRXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftJSRXX" type="hidden" runat="server">
						<input id="htxtDivTopJSRXX" type="hidden" runat="server">
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
							function ScrollProc_divJSRXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJSRXX");
								if (oText != null) oText.value = divJSRXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSRXX");
								if (oText != null) oText.value = divJSRXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopJSRXX");
								if (oText != null) divJSRXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSRXX");
								if (oText != null) divJSRXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divJSRXX.onscroll = ScrollProc_divJSRXX;
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
