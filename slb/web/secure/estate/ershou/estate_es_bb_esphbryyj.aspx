<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_bb_esphbryyj.aspx.vb" Inherits="Josco.JSOA.web.estate_es_bb_esphbryyj" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>中介部二手人员业绩排行榜</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdContentLocked { ; LEFT: expression(divContent.scrollLeft); POSITION: relative }
			TH.grdContentLocked { ; LEFT: expression(divContent.scrollLeft); POSITION: relative }
			TH.grdContentLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../../scripts/transkey.js"></script>
		<script src="../../../scripts/baseobj.js"></script>
		<script language="javascript">
			function onresize_body() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";

				if (document.all("divContent") == null)
					return;
				
				dblWidth  = document.body.clientWidth;
				dblWidth  -= 18;
				strWidth   = dblWidth.toString() + "px";

				dblHeight = document.body.clientHeight;
				dblHeight -= trRow00.clientHeight;
				dblHeight -= trRow01.clientHeight;
				dblHeight -= trRow02.clientHeight;
				dblHeight -= trRow03.clientHeight;
				dblHeight -= 18;
				strHeight  = dblHeight.toString() + "px";
				
				divContent.style.width  = strWidth;
				divContent.style.height = strHeight;
				divContent.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function onreadystatechange_body() 
			{
				return onresize_body();
			}
			function onscroll_body() 
			{
				var oText;
				oText=null;
				oText=document.getElementById("htxtDivTopBody");
				if (oText != null) oText.value = document.body.scrollTop;
				oText=null;
				oText=document.getElementById("htxtDivLeftBody");
				if (oText != null) oText.value = document.body.scrollLeft;
				return;
			}
			function onscroll_divContent() 
			{
				var oText;
				oText=null;
				oText=document.getElementById("htxtDivTopContent");
				if (oText != null) oText.value = divContent.scrollTop;
				oText=null;
				oText=document.getElementById("htxtDivLeftContent");
				if (oText != null) oText.value = divContent.scrollLeft;
				return;
			}
			function doRestoreScrollPos()
			{
				try 
				{
					var Text;

					oText=null;
					oText=document.getElementById("htxtDivTopBody");
					if (oText != null) document.body.scrollTop = oText.value;
					oText=null;
					oText=document.getElementById("htxtDivLeftBody");
					if (oText != null) document.body.scrollLeft = oText.value;

					oText=null;
					oText=document.getElementById("htxtDivTopContent");
					if (oText != null) divContent.scrollTop = oText.value;
					oText=null;
					oText=document.getElementById("htxtDivLeftContent");
					if (oText != null) divContent.scrollLeft = oText.value;
				}
				catch (e) {}
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="onresize_body()" onreadystatechange="onreadystatechange_body()" onscroll="onscroll_body()">
		<form id="frmestate_es_bb_esphbryyj" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" border="0">
					<TR id="trRow00">
						<TD width="4"></TD>
                        <TD height="30" class="title" vAlign="middle" align="center" style="BORDER-BOTTOM: #99cccc 2px solid">中介部二手人员业绩排行榜</TD>
                        <TD width="4"></TD>
                    </TR>					
					<tr id="trRow02">
						<TD width="4"></TD>
						<td style="BORDER-BOTTOM: #99cccc 1px solid">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<tr>
									<td class="labelNotNull">&nbsp;&nbsp;统计开始日期：<asp:TextBox ID="txtKSRQ" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></td>
									<td class="labelNotNull">&nbsp;&nbsp;统计截止日期：<asp:TextBox ID="txtZZRQ" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></td>
									<td class="labelNotNull">&nbsp;&nbsp;统计类型：
										<asp:DropDownList ID="ddlType" Runat="server" CssClass="textbox">
											<asp:ListItem Value="0">接案</asp:ListItem>
											<asp:ListItem Value="1">结案</asp:ListItem>
											<asp:ListItem Value="2">已接未结案</asp:ListItem>
											<asp:ListItem Value="3">结算</asp:ListItem>
										</asp:DropDownList>
									</td>
									<td class="labelNotNull">&nbsp;&nbsp;查看指标：
										<asp:DropDownList ID="ddlTJZB" Runat="server" CssClass="textbox">
											<asp:ListItem Value="0">指标-面积</asp:ListItem>
											<asp:ListItem Value="1">指标-套数</asp:ListItem>
											<asp:ListItem Value="2">指标-宗数</asp:ListItem>
											<asp:ListItem Value="3" Selected="True">指标-代理费</asp:ListItem>
											<asp:ListItem Value="4">指标-按揭返还</asp:ListItem>
											<asp:ListItem Value="5">指标-交易金额</asp:ListItem>
											<asp:ListItem Value="6">指标-实结代理费</asp:ListItem>
										</asp:DropDownList>
									</td>
									<TD vAlign="middle">&nbsp;&nbsp;<asp:linkbutton id="lnkMLJsbbsj" runat="server">计算数据</asp:linkbutton></TD>
								</tr>
							</table>
						</td>
						<TD width="4"></TD>
					</tr>
					<TR>
						<TD width="4"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD width="4"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divContent" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 977px; CLIP: rect(0px 977px 408px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 408px" onscroll="onscroll_divContent()">
														<asp:datagrid id="grdContent" runat="server" CssClass="label" UseAccessibleHeader="True" AllowSorting="True"
															BorderWidth="1px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="True" CellPadding="3" BorderStyle="Solid"
															GridLines="Vertical" AutoGenerateColumns="False" Width="100%">
															<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="0px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkContent" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="人员名称" SortExpression="人员名称" HeaderText="人员名称" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="面积" SortExpression="面积" HeaderText="面积" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="套数" SortExpression="套数" HeaderText="套数" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="宗数" SortExpression="宗数" HeaderText="宗数" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="代理费" SortExpression="代理费" HeaderText="代理费" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="按揭返还" SortExpression="按揭返还" HeaderText="按揭返还" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="交易金额" SortExpression="交易金额" HeaderText="交易金额" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="实结代理费" SortExpression="实结代理费" HeaderText="实结代理费" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtContentFixed" type="hidden" value="2" runat="server" NAME="htxtContentFixed">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow03" align="center">
												<TD>
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR align="center">
															<TD class="labelBlack" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZDeSelectAll" runat="server" CssClass="labelBlack" Enabled="False">不选</asp:linkbutton>】</TD>
															<TD class="labelBlack" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZSelectAll" runat="server" CssClass="labelBlack" Enabled="False">全选</asp:linkbutton>】</TD>
															<TD class="labelBlack" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZMoveFirst" runat="server" CssClass="labelBlack">最前</asp:linkbutton>】</TD>
															<TD class="labelBlack" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZMovePrev" runat="server" CssClass="labelBlack">前页</asp:linkbutton>】</TD>
															<TD class="labelBlack" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZMoveNext" runat="server" CssClass="labelBlack">下页</asp:linkbutton>】</TD>
															<TD class="labelBlack" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZMoveLast" runat="server" CssClass="labelBlack">最后</asp:linkbutton>】</TD>
															<TD class="labelBlack" vAlign="middle" align="left">【<asp:linkbutton id="lnkCZGotoPage" runat="server" CssClass="labelBlack">前往</asp:linkbutton>】<asp:textbox id="txtPageIndex" runat="server" Columns="1" CssClass="textbox">1</asp:textbox>页</TD>
															<TD class="labelBlack" vAlign="middle" align="left">【<asp:linkbutton id="lnkCZSetPageSize" runat="server" CssClass="labelBlack">每页</asp:linkbutton>】<asp:textbox id="txtPageSize" runat="server" Columns="1" CssClass="textbox">30</asp:textbox>条</TD>
															<TD class="labelBlack" vAlign="baseline" align="right"><asp:label id="lblGridLocInfo" runat="server" CssClass="labelBlack">1/10 N/15</asp:label></TD>
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
					<TR id="trRow01">
						<TD width="4"></TD>
						<TD style="BORDER-TOP: #99cccc 2px solid" align="center" height="32" valign="middle">
							<asp:linkbutton id="lnkMLSearch" runat="server">搜索数据</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lnkMLExport" runat="server">输出数据</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lnkMLReturn" runat="server">返回上级</asp:linkbutton>
						</TD>
						<TD width="4"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();" type="button" value=" 返回 "></P></TD>
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
						<input id="htxtSessionIdBuffer" type="hidden" runat="server" NAME="htxtSessionIdBuffer">
						<input id="htxtSessionIdQuery" type="hidden" runat="server" NAME="htxtSessionIdQuery">
						<input id="htxtQuery" type="hidden" runat="server" NAME="htxtQuery">
						<input id="htxtRows" type="hidden" runat="server" NAME="htxtRows">
						<input id="htxtSort" type="hidden" runat="server" NAME="htxtSort">
						<input id="htxtSortColumnIndex" type="hidden" runat="server" NAME="htxtSortColumnIndex">
						<input id="htxtSortType" type="hidden" runat="server" NAME="htxtSortType">
						<input id="htxtDivLeftContent" type="hidden" runat="server" NAME="htxtDivLeftContent">
						<input id="htxtDivTopContent" type="hidden" runat="server" NAME="htxtDivTopContent">
						<input id="htxtDivLeftBody" type="hidden" runat="server" NAME="htxtDivLeftBody">
						<input id="htxtDivTopBody" type="hidden" runat="server" NAME="htxtDivTopBody">
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">doRestoreScrollPos();</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">onresize_body();</script>
						<uwin:popmessage id="popMessageObject" runat="server" height="48px" width="96px" Visible="False" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
