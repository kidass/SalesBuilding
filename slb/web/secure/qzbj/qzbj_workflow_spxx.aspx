<%@ Page Language="vb" AutoEventWireup="false" Codebehind="qzbj_workflow_spxx.aspx.vb" Inherits="Josco.JsKernal.web.qzbj_workflow_spxx" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>领导签批意见编辑窗</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles01.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdSPYJLocked { ; LEFT: expression(divSPYJ.scrollLeft); POSITION: relative }
			TH.grdSPYJLocked { ; LEFT: expression(divSPYJ.scrollLeft); POSITION: relative }
			TH.grdSPYJLocked { Z-INDEX: 99 }
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
				
				if (document.all("divSPYJ") == null)
					return;


				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 24;                          //滚动条
				intWidth  -= 2 * 4;                       //左、右空白
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 8;                           //调整数
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
				//    window.alert(strWidth + " " + strHeight);
				document.all("divSPYJ").style.width  = strWidth;
				document.all("divSPYJ").style.height = strHeight;
				document.all("divSPYJ").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmqzbj_workflow_spxx" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="4"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="center" colSpan="3" height="36" valign="middle">文件流转情况编辑<asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="4"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow2">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle">领导&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtSPYJSearch_JSR" runat="server" Columns="16" CssClass="textbox"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;代理&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtSPYJSearch_DLR" runat="server" Columns="16" CssClass="textbox"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;事宜&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtSPYJSearch_BLSY" runat="server" Columns="16" CssClass="textbox"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;签批日期&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtSPYJSearch_QPRQMin" runat="server" Columns="12" CssClass="textbox"></asp:textbox>~<asp:textbox id="txtSPYJSearch_QPRQMax" runat="server" Columns="12" CssClass="textbox"></asp:textbox></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnSPYJSearch" Runat="server" CssClass="button" Text="快速搜索"></asp:button><asp:Button id="btnSPYJSearchFull" Runat="server" CssClass="button" Text="全文检索"></asp:Button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divSPYJ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 980px; CLIP: rect(0px 980px 524px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 524px;">
														<asp:datagrid id="grdSPYJ" runat="server" Width="1700px" Font-Size="12px" CssClass="label" Font-Names="宋体"
															UseAccessibleHeader="True" AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical"
															BackColor="White" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px"
															AllowSorting="True" CellPadding="4">
															<SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkSPYJ" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="办理类型" SortExpression="办理类型" HeaderText="办理类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="交接序号" SortExpression="交接序号" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="显示序号" SortExpression="显示序号" HeaderText="排序" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理人" SortExpression="办理人" HeaderText="领导" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="办理子类" SortExpression="办理子类" HeaderText="办理事宜" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:TemplateColumn HeaderText="签批意见">
																	<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtSPYJ_BLYJ" Runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="便笺意见">
																	<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtSPYJ_BJNR" Runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="办理日期" SortExpression="办理日期" HeaderText="签批日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="代理人" SortExpression="代理人" HeaderText="代理人" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="代理日期" SortExpression="代理日期" HeaderText="代理填写日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:TemplateColumn HeaderText="办理结果">
																	<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtSPYJ_BLJG" Runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="填写日期" SortExpression="填写日期" HeaderText="结果填写日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="是否批准" SortExpression="是否批准" HeaderText="是否批准" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:TemplateColumn HeaderText="限制查看人员">
																	<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtSPYJ_XZYDRY" Runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtSPYJFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD>
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSPYJDeSelectAll" runat="server">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSPYJSelectAll" runat="server">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSPYJMoveFirst" runat="server">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSPYJMovePrev" runat="server">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSPYJMoveNext" runat="server">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSPYJMoveLast" runat="server">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSPYJGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtSPYJPageIndex" runat="server" Columns="3" CssClass="textbox">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSPYJSetPageSize" runat="server">每页</asp:linkbutton><asp:textbox id="txtSPYJPageSize" runat="server" Columns="3" CssClass="textbox">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblSPYJGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="4"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="4"></TD>
					</TR>
					<TR id="trRow4">
						<TD align="center" colSpan="3">
							<asp:Button id="btnUpdate" Runat="server" Height="36px" CssClass="button" Text=" 修    改 "></asp:Button>
							<asp:Button id="btnDelete" Runat="server" Height="36px" CssClass="button" Text=" 删    除 "></asp:Button>
							<asp:Button id="btnClose"  Runat="server" Height="36px" CssClass="button" Text=" 返    回 "></asp:Button>
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
						<input id="htxtSPYJSessionIdQuery" type="hidden" runat="server">
						<input id="htxtSPYJQuery" type="hidden" runat="server">
						<input id="htxtSPYJRows" type="hidden" runat="server">
						<input id="htxtSPYJSort" type="hidden" runat="server">
						<input id="htxtSPYJSortColumnIndex" type="hidden" runat="server">
						<input id="htxtSPYJSortType" type="hidden" runat="server">
						<input id="htxtDivLeftSPYJ" type="hidden" runat="server">
						<input id="htxtDivTopSPYJ" type="hidden" runat="server">
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
							function ScrollProc_divSPYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSPYJ");
								if (oText != null) oText.value = divSPYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSPYJ");
								if (oText != null) oText.value = divSPYJ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopSPYJ");
								if (oText != null) divSPYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSPYJ");
								if (oText != null) divSPYJ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divSPYJ.onscroll = ScrollProc_divSPYJ;
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
