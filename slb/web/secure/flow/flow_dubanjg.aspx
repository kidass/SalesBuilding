<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_dubanjg.aspx.vb" Inherits="Josco.JSOA.web.flow_dubanjg"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>文件督办结果登记窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdBDBXXLocked { ; LEFT: expression(divBDBXX.scrollLeft); POSITION: relative }
		    TH.grdBDBXXLocked { ; LEFT: expression(divBDBXX.scrollLeft); POSITION: relative }
		    TH.grdBDBXXLocked { Z-INDEX: 99 }
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
				var dblDeltaY =-380;
				var dblDeltaX =-50;
				
				if (document.all("divBDBXX") == null)
					return;
				
				dblWidth  = 800 + document.body.clientWidth  - 850; //default state : 800px
				strWidth  = parseInt(dblWidth.toString(), 10).toString() + "px";
				strHeight = divBDBXX.style.height;
				divBDBXX.style.width  = strWidth;
				divBDBXX.style.height = strHeight;
				divBDBXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				
				var objControl = null;
				objControl = document.getElementById("textareaQBJG");
				if (objControl)
				{
					dblHeight = dblDeltaY + document.body.clientHeight; 
					strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
					dblWidth  = (dblDeltaX + document.body.clientWidth) / 2;
					strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
					objControl.style.width  = strWidth;
					objControl.style.height = strHeight;
				}

				objControl = document.getElementById("textareaBCJG");
				if (objControl)
				{
					dblHeight = dblDeltaY + document.body.clientHeight; 
					strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
					dblWidth  = (dblDeltaX + document.body.clientWidth) / 2;
					strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
					objControl.style.width  = strWidth;
					objControl.style.height = strHeight;
				}
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
		<form id="frmFLOW_DUBANJG" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD height="10"></TD>
								</TR>
								<TR>
									<TD class="tips" align="left" colSpan="3" height="26"><B>&nbsp;&nbsp;我被督办的情况一览表</B><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:Label id="lblBDBXXGridLocInfo" Runat="server" CssClass="label"></asp:Label></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divBDBXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 260px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 260px">
														<asp:datagrid id="grdBDBXX" runat="server" CssClass="labelGrid" Font-Size="13px" Font-Names="宋体"
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
																	<HeaderStyle HorizontalAlign="Center" Width="20px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Bottom" ></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkBDBXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="交接序号" SortExpression="交接序号" HeaderText="交接序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="督办序号" SortExpression="督办序号" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="督办人" SortExpression="督办人" HeaderText="督办人" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="督办日期" SortExpression="督办日期" HeaderText="督办日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="督办结果" SortExpression="督办结果" HeaderText="督办结果" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="本次结果" SortExpression="本次结果" HeaderText="本次结果" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="督办要求" SortExpression="督办要求" HeaderText="督办要求" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理子类" SortExpression="办理子类" HeaderText="办理事宜" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理状态" SortExpression="办理状态" HeaderText="办理状态" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="被督办人" SortExpression="被督办人" HeaderText="被督办人" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="Bottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtBDBXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD height="10"></TD>
											</TR>
											<TR>
												<TD class="tips"><B>已经汇报的督办结果</B></TD>
												<TD>&nbsp;</TD>
												<TD class="tips"><B>本次准备汇报的督办结果</B></TD>
											</TR>
											<TR>
												<TD colSpan="3" height="3"></TD>
											</TR>
											<TR>
												<TD><TEXTAREA id="textareaQBJG" runat="server" class="textbox" readOnly></TEXTAREA></TD>
												<TD>&nbsp;</TD>
												<TD><TEXTAREA id="textareaBCJG" runat="server" class="textbox"></TEXTAREA></TD>
											</TR>
										</TABLE>
									</TD>
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
						<TD align="center" colSpan="3">
							<asp:Button ID="btnSave" Runat="server"  CssClass="button" Text=" 暂  存 " Height="30px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnOK" Runat="server" CssClass="button" Text=" 确  定 " Height="30px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnCancel" Runat="server" CssClass="button" Text=" 取  消 " Height="30px"></asp:Button>
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
						<input id="htxtSessionIdBDBXX" type="hidden" runat="server">
						<input id="htxtBDBXXQuery" type="hidden" runat="server">
						<input id="htxtBDBXXRows" type="hidden" runat="server">
						<input id="htxtBDBXXSort" type="hidden" runat="server">
						<input id="htxtBDBXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtBDBXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftBDBXX" type="hidden" runat="server">
						<input id="htxtDivTopBDBXX" type="hidden" runat="server">
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
							function ScrollProc_divBDBXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopBDBXX");
								if (oText != null) oText.value = divBDBXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftBDBXX");
								if (oText != null) oText.value = divBDBXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopBDBXX");
								if (oText != null) divBDBXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBDBXX");
								if (oText != null) divBDBXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divBDBXX.onscroll = ScrollProc_divBDBXX;
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
