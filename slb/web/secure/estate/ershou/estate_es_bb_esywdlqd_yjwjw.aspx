<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_bb_esywdlqd_yjwjw.aspx.vb" Inherits="Josco.JSOA.web.estate_es_bb_esywdlqd_yjwjw" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>中介部二手业务代理清单(已接未结完)(片区|分行|合同)</title>
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
		<form id="frmestate_es_bb_esywdlqd_yjwjw" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" border="0">
					<TR id="trRow00">
						<TD width="4"></TD>
                        <TD height="30" class="title" vAlign="middle" align="center" style="BORDER-BOTTOM: #99cccc 2px solid">中介部二手业务代理清单(已接未结完)-片区|分行|合同</TD>
                        <TD width="4"></TD>
                    </TR>					
					<tr id="trRow02">
						<TD width="4"></TD>
						<td style="BORDER-BOTTOM: #99cccc 1px solid">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<tr>
									<td class="labelNotNull">&nbsp;&nbsp;统计开始日期：<asp:TextBox ID="txtKSRQ" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></td>
									<td class="labelNotNull">&nbsp;&nbsp;统计截止日期：<asp:TextBox ID="txtZZRQ" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></td>
									<td class="label">&nbsp;&nbsp;统计部门：<asp:DropDownList ID="ddlZZDM" Runat="server" CssClass="textbox"></asp:DropDownList></td>
									<td class="label">&nbsp;&nbsp;显示级别：
										<asp:DropDownList ID="ddlSearch_XSJB" Runat="server" CssClass="textbox">
											<asp:ListItem Value=""></asp:ListItem>
											<asp:ListItem Value=" =  1 ">仅显示总计</asp:ListItem>
											<asp:ListItem Value=" <= 2 ">显示到片区</asp:ListItem>
											<asp:ListItem Value=" =  2 ">仅显示片区</asp:ListItem>
											<asp:ListItem Value=" <= 3 ">显示到分行</asp:ListItem>
											<asp:ListItem Value=" =  3 ">仅显示分行</asp:ListItem>
											<asp:ListItem Value=" <= 4 ">显示到合同</asp:ListItem>
											<asp:ListItem Value=" =  4 ">仅显示合同</asp:ListItem>
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
															GridLines="Vertical" AutoGenerateColumns="False" Width="3980px">
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
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="显示名称" SortExpression="显示名称" HeaderText="显示名称" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="显示级别" SortExpression="显示级别" HeaderText="显示级别" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="交易类型" SortExpression="交易类型" HeaderText="交易类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="交易排序" SortExpression="交易排序" HeaderText="交易排序" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="订购日期" SortExpression="订购日期" HeaderText="订购日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="合同日期" SortExpression="合同日期" HeaderText="合同日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="统计日期" SortExpression="统计日期" HeaderText="统计日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="结案日期" SortExpression="结案日期" HeaderText="结案日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="60px" DataTextField="合同状态" SortExpression="合同状态" HeaderText="状态" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="确认书号" SortExpression="确认书号" HeaderText="交易号" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="合同编号" SortExpression="合同编号" HeaderText="合同编号" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="业主名称" SortExpression="业主名称" HeaderText="甲方" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="客户名称" SortExpression="客户名称" HeaderText="乙方" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="240px" DataTextField="物业地址" SortExpression="物业地址" HeaderText="房屋地点" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																

																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="租期" SortExpression="租期" HeaderText="租期(月)" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="月租金" SortExpression="月租金" HeaderText="月租金" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="交易面积" SortExpression="交易面积" HeaderText="交易面积" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="交易价格" SortExpression="交易价格" HeaderText="交易价格" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="收费标准" SortExpression="收费标准" HeaderText="收费标准" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="收费比例" SortExpression="收费比例" HeaderText="收费比例" CommandName="Select" DataTextFormatString="{0:##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="实收代理费" SortExpression="实收代理费" HeaderText="实收代理费" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="总代理费" SortExpression="总代理费" HeaderText="总代理费" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="甲方代理费" SortExpression="甲方代理费" HeaderText="甲方代理费" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="乙方代理费" SortExpression="乙方代理费" HeaderText="乙方代理费" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="代理费折扣" SortExpression="代理费折扣" HeaderText="折扣(%)" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="诚意金" SortExpression="诚意金" HeaderText="诚意金" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="按揭返还" SortExpression="按揭返还" HeaderText="按揭返还" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="实收款" SortExpression="实收款" HeaderText="实收款" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="套数" SortExpression="套数" HeaderText="套数" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="宗数" SortExpression="宗数" HeaderText="宗数" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="片区名称" SortExpression="片区名称" HeaderText="片区" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="片区代码" SortExpression="片区代码" HeaderText="片区代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="经办单位名称" SortExpression="经办单位名称" HeaderText="经办单位" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="经办单位" SortExpression="经办单位" HeaderText="经办单位码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="所属分组" SortExpression="所属分组" HeaderText="所属分组" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="经办人员名称" SortExpression="经办人员名称" HeaderText="经办人员" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="经办人员" SortExpression="经办人员" HeaderText="经办人员码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="分配比例" SortExpression="分配比例" HeaderText="分配比例(%)" CommandName="Select" DataTextFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
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
