<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_xz_jyxx.aspx.vb" Inherits="Josco.JSOA.web.estate_es_xz_jyxx" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>业务编号选择处理窗</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdJYXXLocked { ; LEFT: expression(divJYXX.scrollLeft); POSITION: relative }
		    TH.grdJYXXLocked { ; LEFT: expression(divJYXX.scrollLeft); POSITION: relative }
		    TH.grdJYXXLocked { Z-INDEX: 99 }
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
				
				if (document.all("divJYXX") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 24;                          //滚动条
				intWidth  -= 2 * 4;                       //左、右空白
				intWidth  -= 16;                          //调整数
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 24;                          //调整数
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
				strHeight  = intHeight.toString() + "px";
                //if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);
                
				divJYXX.style.width  = strWidth;
				divJYXX.style.height = strHeight;
				divJYXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmestate_es_xz_jyxx" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="center" colSpan="3" height="30">业务编号选择处理窗<asp:Label ID="lblSelectMode" Runat="server" CssClass="label"></asp:Label><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<tr>
								    <td height="4"></td>
								</tr>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow2">
												<TD class="label" align="left" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;确认书号&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_JYBH" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;甲方&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_YZMC" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;乙方&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_KHMC" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;地址&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_WYDZ" runat="server" CssClass="textbox" Columns="12"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;确认日期&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_JYRQMin" runat="server" CssClass="textbox" Columns="8"></asp:textbox>~<asp:textbox id="txtJYXXSearch_JYRQMax" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;合同日期&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_HTRQMin" runat="server" CssClass="textbox" Columns="8"></asp:textbox>~<asp:textbox id="txtJYXXSearch_HTRQMax" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnJYXXSearch" Runat="server" CssClass="button" Text="搜索"></asp:button><asp:button id="btnJYXXSearch_Full" Runat="server" CssClass="button" Text="全文"></asp:button></td>
														</Tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divJYXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 384px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 384px">
														<asp:datagrid id="grdJYXX" runat="server" Font-Size="12px" CssClass="label" Font-Names="宋体"
															CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
															BorderStyle="None" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
															UseAccessibleHeader="True" Width="7040px">
															<SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															
															<Columns>
																<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkJYXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="交易类型" SortExpression="交易类型" HeaderText="类型" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="交易编号" SortExpression="交易编号" HeaderText="确认书号" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="合同编号" SortExpression="合同编号" HeaderText="合同编号" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="交易日期" SortExpression="交易日期" HeaderText="确认日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="合同日期" SortExpression="合同日期" HeaderText="合同日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="交易状态" SortExpression="交易状态" HeaderText="交易状态" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="合同状态" SortExpression="合同状态" HeaderText="合同状态" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="业主名称" SortExpression="业主名称" HeaderText="业主" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="客户名称" SortExpression="客户名称" HeaderText="客户" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="700px" DataTextField="物业地址" SortExpression="物业地址" HeaderText="物业地址" CommandName="Select">
																	<HeaderStyle Width="700px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易价格" SortExpression="交易价格" HeaderText="金额" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易面积" SortExpression="交易面积" HeaderText="面积" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="甲方代理费" SortExpression="甲方代理费" HeaderText="甲方代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="乙方代理费" SortExpression="乙方代理费" HeaderText="乙方代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="代理费折扣" SortExpression="代理费折扣" HeaderText="代理费折扣" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="付款方式" SortExpression="付款方式" HeaderText="付款方式" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="客源编号" SortExpression="客源编号" HeaderText="客源编号" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="查册地址" SortExpression="查册地址" HeaderText="查册地址" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="查册费" SortExpression="查册费" HeaderText="查册费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="实收佣金" SortExpression="实收佣金" HeaderText="实收佣金" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="合作佣金" SortExpression="合作佣金" HeaderText="合作佣金" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="按揭机构" SortExpression="按揭机构" HeaderText="按揭机构" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="按揭银行" SortExpression="按揭银行" HeaderText="按揭银行" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="按揭成数" SortExpression="按揭成数" HeaderText="按揭成数" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="按揭年限" SortExpression="按揭年限" HeaderText="按揭年限" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主区码" SortExpression="业主区码" HeaderText="业主地区" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主区名" SortExpression="业主区名" HeaderText="业主地区补充" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主来源" SortExpression="业主来源" HeaderText="业主来源" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业源其他" SortExpression="业源其他" HeaderText="业主来源补充" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主电邮" SortExpression="业主电邮" HeaderText="业主电邮" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="售后意向" SortExpression="售后意向" HeaderText="售后意向" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="剩余物业" SortExpression="剩余物业" HeaderText="剩余物业" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="买家区码" SortExpression="买家区码" HeaderText="买家地区" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="买家区名" SortExpression="买家区名" HeaderText="买家地区补充" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="客户来源" SortExpression="客户来源" HeaderText="客户来源" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="客源其他" SortExpression="客源其他" HeaderText="客户来源补充" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="客户电邮" SortExpression="客户电邮" HeaderText="客户电邮" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="购买目的" SortExpression="购买目的" HeaderText="购买目的" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>

													            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="合同标志" SortExpression="合同标志" HeaderText="合同标志" CommandName="Select">
														            <HeaderStyle Width="100px"></HeaderStyle>
													            </asp:ButtonColumn>
													            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="解除日期" SortExpression="解除日期" HeaderText="解除日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
														            <HeaderStyle Width="140px"></HeaderStyle>
													            </asp:ButtonColumn>
													            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="坏账日期" SortExpression="坏账日期" HeaderText="坏账日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
														            <HeaderStyle Width="140px"></HeaderStyle>
													            </asp:ButtonColumn>
													            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="坏账金额" SortExpression="坏账金额" HeaderText="坏账金额" CommandName="Select" DataTextFormatString="{0:#,##0.00}">
														            <HeaderStyle Width="160px"></HeaderStyle>
													            </asp:ButtonColumn>
													            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="合同解除" SortExpression="合同解除" HeaderText="合同解除" CommandName="Select">
														            <HeaderStyle Width="100px"></HeaderStyle>
													            </asp:ButtonColumn>
													            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="坏账合同" SortExpression="坏账合同" HeaderText="坏账合同" CommandName="Select">
														            <HeaderStyle Width="100px"></HeaderStyle>
													            </asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="租赁开始" SortExpression="租赁开始" HeaderText="租赁开始" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="租赁结束" SortExpression="租赁结束" HeaderText="租赁结束" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="水电煤气" SortExpression="水电煤气" HeaderText="水电煤气" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="电话费" SortExpression="电话费" HeaderText="电话费" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="管理费" SortExpression="管理费" HeaderText="管理费" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="租赁发票" SortExpression="租赁发票" HeaderText="租赁发票" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtJYXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXDeSelectAll" runat="server" Font-Size="12px" Font-Name="宋体">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXSelectAll" runat="server" Font-Size="12px" Font-Name="宋体">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXMoveFirst" runat="server" Font-Size="12px" Font-Name="宋体">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXMovePrev" runat="server" Font-Size="12px" Font-Name="宋体">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXMoveNext" runat="server" Font-Size="12px" Font-Name="宋体">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXMoveLast" runat="server" Font-Size="12px" Font-Name="宋体">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXGotoPage" runat="server" Font-Size="12px" Font-Name="宋体">前往</asp:linkbutton><asp:textbox id="txtJYXXPageIndex" runat="server" Font-Size="12px" Font-Name="宋体" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXSetPageSize" runat="server" Font-Size="12px" Font-Name="宋体">每页</asp:linkbutton><asp:textbox id="txtJYXXPageSize" runat="server" Font-Size="12px" Font-Name="宋体" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblJYXXGridLocInfo" runat="server" Font-Size="12px" Font-Name="宋体" CssClass="label">1/10 N/15</asp:label></TD>
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
					<TR id="trRow4">
						<TD align="center" colSpan="3">
						    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						        <tr>
						            <td height="4"></td>
						        </tr>
						        <tr>
						            <td align="center">
							            <asp:Button id="btnOK" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 选择确认 " Height="36px"></asp:Button>
							            <asp:Button id="btnNull" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 空值确认 " Height="36px"></asp:Button>
							            <asp:Button id="btnClose" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 取    消 " Height="36px"></asp:Button>
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
						<input id="htxtSessionIdQuery" type="hidden" runat="server">
						<input id="htxtJYXXQuery" type="hidden" runat="server">
						<input id="htxtJYXXRows" type="hidden" runat="server">
						<input id="htxtJYXXSort" type="hidden" runat="server">
						<input id="htxtJYXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtJYXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftJYXX" type="hidden" runat="server">
						<input id="htxtDivTopJYXX" type="hidden" runat="server">
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
							function ScrollProc_divJYXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJYXX");
								if (oText != null) oText.value = divJYXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJYXX");
								if (oText != null) oText.value = divJYXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopJYXX");
								if (oText != null) divJYXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJYXX");
								if (oText != null) divJYXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divJYXX.onscroll = ScrollProc_divJYXX;
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
