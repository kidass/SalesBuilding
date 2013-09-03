<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_bb_eszszgkh.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_bb_eszszgkh" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>中介部正式职工考核表</title>
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

				dblHeight = document.body.clientHeight;
				dblHeight -= trRow00.clientHeight;
				dblHeight -= trRow01.clientHeight;
				dblHeight -= trRow02.clientHeight;
				dblHeight -= 18;

				strWidth   = (dblWidth  - tdCol01.clientWidth - 4).toString() + "px";
				strHeight  = (dblHeight - trRow03.clientHeight).toString() + "px";
				divContent.style.width  = strWidth;
				divContent.style.height = strHeight;
				divContent.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				//alert(strHeight + " " + strWidth);

				var objTreeView = null;
				objTreeView = document.getElementById("tvwTJBM");
				if (objTreeView)
				{
					strHeight  = (dblHeight - trRow03.clientHeight - 2).toString() + "px";
					objTreeView.style.height = strHeight;
					//alert(strHeight);
				}
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
		<form id="frmestate_rs_bb_eszszgkh" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" border="0">
					<TR id="trRow00">
						<TD width="4"></TD>
                        <TD height="30" class="title" vAlign="middle" align="left" style="BORDER-BOTTOM: #99cccc 2px solid">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;职员业绩考核&nbsp;&gt;&gt;&gt;&gt;&nbsp;正式人员考核</TD>
                        <TD width="4"></TD>
                    </TR>					
					<tr id="trRow02">
						<TD width="4"></TD>
						<td style="BORDER-BOTTOM: #99cccc 1px solid">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<tr>
									<td class="labelNotNull">&nbsp;&nbsp;考核年度：<asp:TextBox ID="txtND" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox></td>
									<td class="labelNotNull">&nbsp;&nbsp;考核季度：<asp:DropDownList ID="ddlJD" Runat="server" CssClass="textbox">
											<asp:ListItem Value="1">一季度</asp:ListItem>
											<asp:ListItem Value="2">二季度</asp:ListItem>
											<asp:ListItem Value="3">三季度</asp:ListItem>
											<asp:ListItem Value="4">四季度</asp:ListItem>
										</asp:DropDownList>
									</td>
									<td class="labelNotNull">&nbsp;&nbsp;月截止日：<asp:TextBox ID="txtYJZR" Runat="server" CssClass="textbox" Columns="2">26</asp:TextBox></td>
									<td class="labelNotNull">&nbsp;&nbsp;考核部门：<asp:DropDownList ID="ddlZZDM" Runat="server" CssClass="textbox"></asp:DropDownList></td>
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
									<td id="tdCol01" valign="top" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid;">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td style="BORDER-BOTTOM: #99cccc 1px solid"><iewc:treeview id="tvwTJBM" runat="server" Height="443px" Width="200px" CssClass="label" AutoPostBack="false"></iewc:treeview></td>
											</tr>
											<TR align="center">
												<TD>
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR align="center" height="24" valign="middle">
															<TD class="labelBlack" align="center">【<asp:linkbutton id="lnkCZDeSelectAllTJBM" runat="server" CssClass="labelBlack" Enabled="True">不选</asp:linkbutton>】</TD>
															<TD class="labelBlack" align="center">【<asp:linkbutton id="lnkCZSelectAllTJBM" runat="server" CssClass="labelBlack" Enabled="True">全选</asp:linkbutton>】</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</table>
									</td>
									<TD width="4"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divContent" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 790px; CLIP: rect(0px 790px 445px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 445px" onscroll="onscroll_divContent()">
														<asp:datagrid id="grdContent" runat="server" CssClass="label" UseAccessibleHeader="True" AllowSorting="True"
															BorderWidth="1px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="True" CellPadding="3" BorderStyle="Solid"
															GridLines="Vertical" AutoGenerateColumns="False" Width="1440px">
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
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="人员名称" SortExpression="人员名称" HeaderText="人员" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="季末职级" SortExpression="季末职级" HeaderText="季末职级" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="考核业绩" SortExpression="考核业绩" HeaderText="考核业绩" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="平均人数" SortExpression="平均人数" HeaderText="平均人数" CommandName="Select" DataTextFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="考核指标" SortExpression="考核指标" HeaderText="考核指标" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="达到等级" SortExpression="达到等级" HeaderText="达到等级" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="320px" DataTextField="工作情况" SortExpression="工作情况" HeaderText="工作情况" CommandName="Select">
																	<HeaderStyle Width="320px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="私人业绩" SortExpression="私人业绩" HeaderText="个人业绩" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="团队业绩" SortExpression="团队业绩" HeaderText="团队业绩" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="私人平均" SortExpression="私人平均" HeaderText="个人月度平均" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="团队平均" SortExpression="团队平均" HeaderText="团队月度平均" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
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
														<TR align="center" height="24">
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
						<TD align="center" style="BORDER-TOP: #99cccc 2px solid" height="32" valign="middle">
							<asp:linkbutton id="lnkMLSearch" runat="server">搜索数据</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lnkMLExport" runat="server">输出当前</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lnkMLExpSel" runat="server">输出选定</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
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
