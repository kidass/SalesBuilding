<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_jyndjh.aspx.vb" Inherits="Josco.JSOA.web.estate_es_jyndjh" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>年度计划管理</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdNDJHLocked { ; LEFT: expression(divNDJH.scrollLeft); POSITION: relative }
		    TH.grdNDJHLocked { ; LEFT: expression(divNDJH.scrollLeft); POSITION: relative }
		    TH.grdNDJHLocked { Z-INDEX: 99 }
		    TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../../scripts/transkey.js"></script>
		<script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divNDJH") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 24;                          //滚动条
				intWidth  -= 2 * 4;                       //左、右空白
				intWidth  -= 16;                          //调整数
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 24;                          //调整数
				intHeight -= trRow01.clientHeight;
				intHeight -= trRow02.clientHeight;
				intHeight -= trRow03.clientHeight;
				intHeight -= trRow04.clientHeight;
				intHeight -= trRow05.clientHeight;
				strHeight  = intHeight.toString() + "px";

				divNDJH.style.width  = strWidth;
				divNDJH.style.height = strHeight;
				divNDJH.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmestate_es_jyndjh" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<tr id="trRow01">
									<TD width="5"></TD>
									<td align="left" class="title" bgcolor="#ccff99">&gt;&gt;&gt;&gt;已经制订的年度计划一览表</td>
									<TD width="5"></TD>
								</tr>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow02">
												<TD class="label" align="left" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">&nbsp;计划类型&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlNDJHSearch_JHLX" runat="server" CssClass="textbox">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="二手.买卖">买卖</asp:ListItem>
																	<asp:ListItem Value="二手.租赁">租赁</asp:ListItem>
																	<asp:ListItem Value="二手.其他">其他</asp:ListItem>
																</asp:DropDownList>
															</TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;计划年度&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtNDJHSearch_JHNDMin" runat="server" CssClass="textbox" Columns="4"></asp:textbox>~<asp:textbox id="txtNDJHSearch_JHNDMax" runat="server" CssClass="textbox" Columns="4"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;计划代理费&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtNDJHSearch_JHDLFMin" runat="server" CssClass="textbox" Columns="10"></asp:textbox>~<asp:textbox id="txtNDJHSearch_JHDLFMax" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD class="label" align="right"><asp:button id="btnNDJHSearch" Runat="server" CssClass="button" Text="快速"></asp:button><asp:button id="btnNDJHSearch_Full" Runat="server" CssClass="button" Text="全文"></asp:button></td>
														</tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divNDJH" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 382px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 382px">
														<asp:datagrid id="grdNDJH" runat="server" CssClass="label" BorderColor="#DEDFDE" BorderStyle="None" AutoGenerateColumns="False" 
															CellPadding="2" AllowSorting="True" BorderWidth="1px" PageSize="30" BackColor="White" 
															GridLines="Both" AllowPaging="True" UseAccessibleHeader="True" Width="100%">
															<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="0px">
																	<HeaderStyle HorizontalAlign="Center" Width="0px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkNDJH" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="计划年度" SortExpression="计划年度" HeaderText="计划年度" CommandName="Select">
																	<HeaderStyle Width="90px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="计划类型" SortExpression="计划类型" HeaderText="计划类型" CommandName="Select">
																	<HeaderStyle Width="90px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="130px" DataTextField="计划代理费" SortExpression="计划代理费" HeaderText="计划代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="130px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="130px" DataTextField="计划合同额" SortExpression="计划合同额" HeaderText="计划合同额" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="130px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="130px" DataTextField="计划宗数" SortExpression="计划宗数" HeaderText="计划宗数" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="130px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="130px" DataTextField="计划套数" SortExpression="计划套数" HeaderText="计划套数" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="130px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="130px" DataTextField="计划面积" SortExpression="计划面积" HeaderText="计划面积" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="130px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtNDJHFixed" type="hidden" value="0" runat="server" NAME="htxtNDJHFixed">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow03">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZNDJHDeSelectAll" runat="server">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZNDJHSelectAll" runat="server">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZNDJHMoveFirst" runat="server">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZNDJHMovePrev" runat="server">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZNDJHMoveNext" runat="server">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZNDJHMoveLast" runat="server">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZNDJHGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtNDJHPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZNDJHSetPageSize" runat="server">每页</asp:linkbutton><asp:textbox id="txtNDJHPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="baseline" noWrap align="right"><asp:label id="lblNDJHGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<tr id="trRow04">
									<TD width="5"></TD>
									<td align="left" class="title" bgcolor="#ccff99">&gt;&gt;&gt;&gt;编辑计划时请指定计划年度：<asp:TextBox ID="txtJHND" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></td>
									<TD width="5"></TD>
								</tr>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR id="trRow05">
						<TD align="center" colSpan="3">
						    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						        <tr>
						            <td align="center">
							            <asp:Button id="btnOpen"   Runat="server" CssClass="button" Text=" 查看计划 " Height="36px"></asp:Button>
							            <asp:Button id="btnAddNew" Runat="server" CssClass="button" Text=" 制订计划 " Height="36px"></asp:Button>
							            <asp:Button id="btnUpdate" Runat="server" CssClass="button" Text=" 修改计划 " Height="36px"></asp:Button>
							            <asp:Button id="btnDelete" Runat="server" CssClass="button" Text=" 删除计划 " Height="36px"></asp:Button>
							            <asp:Button id="btnClose"  Runat="server" CssClass="button" Text=" 返    回 " Height="36px"></asp:Button>
						            </td>
						        </tr>
						    </table>
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
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></p></TD>
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
						<input id="htxtSessionIdQuery" type="hidden" runat="server" NAME="htxtSessionIdQuery">
						<input id="htxtNDJHQuery" type="hidden" runat="server" NAME="htxtNDJHQuery">
						<input id="htxtNDJHRows" type="hidden" runat="server" NAME="htxtNDJHRows">
						<input id="htxtNDJHSort" type="hidden" runat="server" NAME="htxtNDJHSort">
						<input id="htxtNDJHSortColumnIndex" type="hidden" runat="server" NAME="htxtNDJHSortColumnIndex">
						<input id="htxtNDJHSortType" type="hidden" runat="server" NAME="htxtNDJHSortType">
						<input id="htxtDivLeftNDJH" type="hidden" runat="server" NAME="htxtDivLeftNDJH">
						<input id="htxtDivTopNDJH" type="hidden" runat="server" NAME="htxtDivTopNDJH">
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
							function ScrollProc_divNDJH() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopNDJH");
								if (oText != null) oText.value = divNDJH.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftNDJH");
								if (oText != null) oText.value = divNDJH.scrollLeft;
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
								oText=document.getElementById("htxtDivTopNDJH");
								if (oText != null) divNDJH.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftNDJH");
								if (oText != null) divNDJH.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divNDJH.onscroll = ScrollProc_divNDJH;
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
