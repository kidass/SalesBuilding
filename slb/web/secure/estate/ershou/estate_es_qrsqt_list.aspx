<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_qrsqt_list.aspx.vb" Inherits="Josco.JSOA.web.estate_es_qrsqt_list" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>其他确认书主窗口</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdQRSLocked { ; LEFT: expression(divQRS.scrollLeft); POSITION: relative }
		    TH.grdQRSLocked { ; LEFT: expression(divQRS.scrollLeft); POSITION: relative }
		    TH.grdQRSLocked { Z-INDEX: 99 }
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
				
				if (document.all("divQRS") == null)
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
				divQRS.style.width  = strWidth;
				divQRS.style.height = strHeight;
				divQRS.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmestate_es_qrsqt_list" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="center" colSpan="3" height="30">【<%=propRYMC%>】能查看的其他业务的确认书一览表<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
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
															<TD class="label" align="left"><asp:textbox id="txtQRSSearch_QRSH" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;订购日期&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtQRSSearch_DGRQMin" runat="server" CssClass="textbox" Columns="10"></asp:textbox>~<asp:textbox id="txtQRSSearch_DGRQMax" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;订购状态&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlQRSSearch_DGZT" runat="server" CssClass="textbox"><asp:ListItem Value=""></asp:ListItem><asp:ListItem Value="&3=0">未审</asp:ListItem><asp:ListItem Value="&3=1">已审</asp:ListItem><asp:ListItem Value="&2=2">挞定</asp:ListItem></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;甲方&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtQRSSearch_JFMC" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;乙方&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtQRSSearch_YFMC" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;物业地址&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtQRSSearch_FWDZ" runat="server" CssClass="textbox" Columns="16"></asp:textbox></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnQRSSearch" Runat="server" CssClass="button" Text="快速"></asp:button><asp:button id="btnQRSSearch_Full" Runat="server" CssClass="button" Text="全文"></asp:button></td>
														</Tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divQRS" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 405px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 405px">
														<asp:datagrid id="grdQRS" runat="server" CssClass="label" Width="6230px"
															CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
															BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
															UseAccessibleHeader="True">
															<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															
															<Columns>
																<asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkQRS" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="130px" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="OpenDocument">
																	<HeaderStyle Width="130px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="订购日期" SortExpression="订购日期" HeaderText="订购日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="订购状态" SortExpression="订购状态" HeaderText="订购状态" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="60px" DataTextField="订购状态名称" SortExpression="订购状态名称" HeaderText="状态" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="甲方名称" SortExpression="甲方名称" HeaderText="甲方" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="乙方名称" SortExpression="乙方名称" HeaderText="乙方" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="700px" DataTextField="房屋地址" SortExpression="房屋地址" HeaderText="房屋地址" CommandName="Select">
																	<HeaderStyle Width="700px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易总价格" SortExpression="交易总价格" HeaderText="交易总价格" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易总面积" SortExpression="交易总面积" HeaderText="交易总面积" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="甲方代理费" SortExpression="甲方代理费" HeaderText="甲方代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="乙方代理费" SortExpression="乙方代理费" HeaderText="乙方代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="代理费折扣" SortExpression="代理费折扣" HeaderText="代理费折扣" CommandName="Select" DataTextFormatString="{0:#.00%}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="计划交易日期" SortExpression="计划交易日期" HeaderText="计划交易日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="160px" ></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="计划交楼日期" SortExpression="计划交楼日期" HeaderText="计划交楼日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="甲方联系电话" SortExpression="甲方联系电话" HeaderText="甲方联系电话" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="甲方联系地址" SortExpression="甲方联系地址" HeaderText="甲方联系地址" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="乙方联系电话" SortExpression="乙方联系电话" HeaderText="乙方联系电话" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="乙方联系地址" SortExpression="乙方联系地址" HeaderText="乙方联系地址" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="甲方证件类型" SortExpression="甲方证件类型" HeaderText="甲方证件类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="甲方证照号码" SortExpression="甲方证照号码" HeaderText="甲方证照号码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="甲方代理人" SortExpression="甲方代理人" HeaderText="甲方代理人" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="乙方证件类型" SortExpression="乙方证件类型" HeaderText="乙方证件类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="乙方证照号码" SortExpression="乙方证照号码" HeaderText="乙方证照号码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="乙方代理人" SortExpression="乙方代理人" HeaderText="乙方代理人" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="交楼日期约定" SortExpression="交楼日期约定" HeaderText="交楼日期约定" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="交楼状况约定" SortExpression="交楼状况约定" HeaderText="交楼状况约定" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="付款方式约定" SortExpression="付款方式约定" HeaderText="付款方式约定" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="税费支付约定" SortExpression="税费支付约定" HeaderText="税费支付约定" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="房款托管约定" SortExpression="房款托管约定" HeaderText="房款托管约定" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="登记人码" SortExpression="登记人码" HeaderText="登记人码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="登记人名" SortExpression="登记人名" HeaderText="登记人名" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="登记日期" SortExpression="登记日期" HeaderText="登记日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="备注信息" SortExpression="备注信息" HeaderText="备注信息" CommandName="Select">
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
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtQRSFixed" type="hidden" value="0" runat="server" NAME="htxtQRSFixed"></DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZQRSDeSelectAll" runat="server">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZQRSSelectAll" runat="server">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZQRSMoveFirst" runat="server">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZQRSMovePrev" runat="server">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZQRSMoveNext" runat="server">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZQRSMoveLast" runat="server">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZQRSGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtQRSPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZQRSSetPageSize" runat="server">每页</asp:linkbutton><asp:textbox id="txtQRSPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblQRSGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
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
						            <td height="3"></td>
						        </tr>
						        <tr>
						            <td align="center">
							            <asp:Button id="btnOpen"   Runat="server" CssClass="button" Text=" 打  开 "   Height="36px"></asp:Button>
							            <asp:Button id="btnAddNew" Runat="server" CssClass="button" Text=" 增  加 "   Height="36px"></asp:Button>
							            <asp:Button id="btnUpdate" Runat="server" CssClass="button" Text=" 修  改 "   Height="36px"></asp:Button>
							            <asp:Button id="btnDelete" Runat="server" CssClass="button" Text=" 删  除 "   Height="36px"></asp:Button>
							            <asp:Button id="btnDelWtj" Runat="server" CssClass="button" Text=" 强制删除 " Height="36px"></asp:Button>
							            <asp:Button id="btnScyj"   Runat="server" CssClass="button" Text=" 诚意金 "   Height="36px"></asp:Button>
							            <asp:Button id="btnTading" Runat="server" CssClass="button" Text=" 挞  定 "   Height="36px"></asp:Button>
							            <asp:Button id="btnPrint"  Runat="server" CssClass="button" Text=" 打  印 "   Height="36px"></asp:Button>
							            <asp:Button id="btnClose"  Runat="server" CssClass="button" Text=" 返  回 "   Height="36px"></asp:Button>
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
						<input id="htxtQRSQuery" type="hidden" runat="server" NAME="htxtQRSQuery">
						<input id="htxtQRSRows" type="hidden" runat="server" NAME="htxtQRSRows">
						<input id="htxtQRSSort" type="hidden" runat="server" NAME="htxtQRSSort">
						<input id="htxtQRSSortColumnIndex" type="hidden" runat="server" NAME="htxtQRSSortColumnIndex">
						<input id="htxtQRSSortType" type="hidden" runat="server" NAME="htxtQRSSortType">
						<input id="htxtDivLeftQRS" type="hidden" runat="server" NAME="htxtDivLeftQRS">
						<input id="htxtDivTopQRS" type="hidden" runat="server" NAME="htxtDivTopQRS">
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
							function ScrollProc_divQRS() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopQRS");
								if (oText != null) oText.value = divQRS.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftQRS");
								if (oText != null) oText.value = divQRS.scrollLeft;
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
								oText=document.getElementById("htxtDivTopQRS");
								if (oText != null) divQRS.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftQRS");
								if (oText != null) divQRS.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divQRS.onscroll = ScrollProc_divQRS;
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
