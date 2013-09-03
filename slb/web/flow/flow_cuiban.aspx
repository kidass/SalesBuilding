<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_cuiban.aspx.vb" Inherits="Josco.JSOA.web.flow_cuiban"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>文件催办处理窗口</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdKCBXXLocked { ; LEFT: expression(divKCBXX.scrollLeft); POSITION: relative }
			TH.grdKCBXXLocked { ; LEFT: expression(divKCBXX.scrollLeft); POSITION: relative }
			TH.grdKCBXXLocked { Z-INDEX: 99 }
			TD.grdYCBXXLocked { ; LEFT: expression(divYCBXX.scrollLeft); POSITION: relative }
			TH.grdYCBXXLocked { ; LEFT: expression(divYCBXX.scrollLeft); POSITION: relative }
			TH.grdYCBXXLocked { Z-INDEX: 99 }
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
				
				if (document.all("divKCBXX") == null)
					return;
				
				dblHeight = 280 + (dblDeltaY + document.body.clientHeight - 570) / 2; //default state : 280px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 850;       //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divKCBXX.style.width  = strWidth;
				divKCBXX.style.height = strHeight;
				divKCBXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				dblHeight = 160 + (dblDeltaY + document.body.clientHeight - 570) / 2; //default state : 160px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 850;       //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divYCBXX.style.width  = strWidth;
				divYCBXX.style.height = strHeight;
				divYCBXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmFLOW_CUIBAN" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="3" height="26"><B>&nbsp;&nbsp;本次准备催办以下人员</B><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:Label id="lblKCBXXGridLocInfo" Runat="server"  CssClass="label-text"></asp:Label></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divKCBXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 280px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 280px">
														<asp:datagrid id="grdKCBXX" runat="server"  CssClass="labelGrid" Font-Size="13px" Font-Names="宋体"
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
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Bottom"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkKCBXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="交接序号" SortExpression="交接序号" HeaderText="交接序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="催办序号" SortExpression="催办序号" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="被催办人" SortExpression="被催办人" HeaderText="被催办人" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理子类" SortExpression="办理子类" HeaderText="办理事宜" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理状态" SortExpression="办理状态" HeaderText="办理状态" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:TemplateColumn HeaderText="催办日期">
																	<HeaderStyle HorizontalAlign="Left" Width="200px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" ></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtCBRQ" Runat="server"   CssClass="textbox-text" Width="100%"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="催办说明">
																	<HeaderStyle HorizontalAlign="Left" Width="440px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtCBSM" Runat="server" CssClass="textbox-text" Width="100%"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="催办人" SortExpression="催办人" HeaderText="催办人" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle NextPageText="下页"  PrevPageText="上页" HorizontalAlign="Right" ForeColor="White" Position="Bottom" BackColor="SkyBlue" CssClass="label-text" ></PagerStyle>
														</asp:datagrid><INPUT id="htxtKCBXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="tips" align="left" colSpan="3" height="26"><B>&nbsp;&nbsp;我已经催办的信息一览表</B><asp:Label id="lblYCBXXGridLocInfo" Runat="server"  CssClass="label-text"></asp:Label></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divYCBXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 160px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 160px">
														<asp:datagrid id="grdYCBXX" runat="server" CssClass="label" Font-Size="12px" Font-Names="宋体" AllowPaging="False"
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
																		<asp:CheckBox id="chkYCBXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="交接序号" SortExpression="交接序号" HeaderText="交接序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="催办序号" SortExpression="催办序号" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="被催办人" SortExpression="被催办人" HeaderText="被催办人" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理子类" SortExpression="办理子类" HeaderText="办理事宜" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理状态" SortExpression="办理状态" HeaderText="办理状态" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="催办日期" SortExpression="催办日期" HeaderText="催办日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="催办说明" SortExpression="催办说明" HeaderText="催办说明" CommandName="Select">
																	<HeaderStyle Width="440px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="催办人" SortExpression="催办人" HeaderText="催办人" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页"  PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtYCBXXFixed" type="hidden" value="0" runat="server">
													</DIV>
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
							<asp:Button id="btnOK" Runat="server"  CssClass="button" Text=" 确  定 " Height="30px"></asp:Button>
							<asp:Button id="btnCancel" Runat="server"  CssClass="button" Text=" 取  消 " Height="30px"></asp:Button>
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
						<input id="htxtSessionIdKCBXX" type="hidden" runat="server">
						<input id="htxtKCBXXQuery" type="hidden" runat="server">
						<input id="htxtKCBXXRows" type="hidden" runat="server">
						<input id="htxtKCBXXSort" type="hidden" runat="server">
						<input id="htxtKCBXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtKCBXXSortType" type="hidden" runat="server">
						<input id="htxtYCBXXQuery" type="hidden" runat="server">
						<input id="htxtYCBXXRows" type="hidden" runat="server">
						<input id="htxtYCBXXSort" type="hidden" runat="server">
						<input id="htxtYCBXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtYCBXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftKCBXX" type="hidden" runat="server">
						<input id="htxtDivTopKCBXX" type="hidden" runat="server">
						<input id="htxtDivLeftYCBXX" type="hidden" runat="server">
						<input id="htxtDivTopYCBXX" type="hidden" runat="server">
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
							function ScrollProc_divKCBXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopKCBXX");
								if (oText != null) oText.value = divKCBXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftKCBXX");
								if (oText != null) oText.value = divKCBXX.scrollLeft;
								return;
							}
							function ScrollProc_divYCBXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopYCBXX");
								if (oText != null) oText.value = divYCBXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftYCBXX");
								if (oText != null) oText.value = divYCBXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopKCBXX");
								if (oText != null) divKCBXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftKCBXX");
								if (oText != null) divKCBXX.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopYCBXX");
								if (oText != null) divYCBXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftYCBXX");
								if (oText != null) divYCBXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divKCBXX.onscroll = ScrollProc_divKCBXX;
								divYCBXX.onscroll = ScrollProc_divYCBXX;
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
