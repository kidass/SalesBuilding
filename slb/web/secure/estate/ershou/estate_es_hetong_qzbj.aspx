<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_hetong_qzbj.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetong_qzbj" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>合同业绩分配强制变更处理</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdHTLocked { ; LEFT: expression(divHT.scrollLeft); POSITION: relative }
		    TH.grdHTLocked { ; LEFT: expression(divHT.scrollLeft); POSITION: relative }
		    TH.grdHTLocked { Z-INDEX: 99 }
		    TD.grdJSSLocked { ; LEFT: expression(divJSS.scrollLeft); POSITION: relative }
		    TH.grdJSSLocked { ; LEFT: expression(divJSS.scrollLeft); POSITION: relative }
		    TH.grdJSSLocked { Z-INDEX: 99 }
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
				
				if (document.all("divJSS") == null)
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
				intHeight -= trRow06.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);
				divHT.style.width = strWidth;

				divJSS.style.width = strWidth;
				divJSS.style.height = strHeight;
				divJSS.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmestate_es_hetong_qzbj" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow01">
									<TD class="title" align="center" colSpan="3" height="30">合同业绩分配强制变更处理<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow02">
												<TD><% if propQRSH()<>"" then response.write("<div style='display:none'>") %>
													<TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
														<TR>
															<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;确定合同</B></TD>
														</TR>
														<TR>
															<TD align="left">
																<TABLE cellSpacing="0" cellPadding="0" border="0">
																	<TR>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;确认书号&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_QRSH" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;合同编号&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_HTBH" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;合同日期&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_HTRQMin" runat="server" CssClass="textbox" Columns="7"></asp:textbox>~<asp:textbox id="txtHTSearch_HTRQMax" runat="server" CssClass="textbox" Columns="7"></asp:textbox></TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;状态&nbsp;</TD>
																		<TD class="label" align="left">
																			<asp:DropDownList id="ddlHTSearch_HTZT" runat="server" CssClass="textbox">
																				<asp:ListItem Value=""></asp:ListItem>
                                                                                <asp:ListItem Value="&1=0">未审</asp:ListItem>
                                                                                <asp:ListItem Value="&1=1">已审</asp:ListItem>
                                                                                <asp:ListItem Value="&2=0">未结</asp:ListItem>
                                                                                <asp:ListItem Value="&2=2">已结</asp:ListItem>
																			</asp:DropDownList>
																		</TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;甲方&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_JFMC" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;乙方&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_YFMC" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;房屋地址&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_FWDZ" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
																		<TD class="label" align="right" colSpan="2">&nbsp;&nbsp;<asp:button id="btnHTSearch" Runat="server" CssClass="button" Text="快速"></asp:button><asp:button id="btnHTSearch_Full" Runat="server" CssClass="button" Text="全文"></asp:button></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<DIV id="divHT" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 240px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 240px">
																	<asp:datagrid id="grdHT" runat="server" Width="7690px" CssClass="label" CellPadding="4" AllowSorting="True"
																		BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
																		GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True" UseAccessibleHeader="True">
																		<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																		<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																		<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																		<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																		<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
																		<FooterStyle BackColor="#CCCC99"></FooterStyle>
																		
																		<Columns>
																			<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																				<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																				<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																				<ItemTemplate>
																					<asp:CheckBox id="chkHT" runat="server" AutoPostBack="False"></asp:CheckBox>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="合同唯一标识" SortExpression="合同唯一标识" HeaderText="合同唯一标识" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="交易类型" SortExpression="交易类型" HeaderText="类型" CommandName="Select">
																				<HeaderStyle Width="100px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="交易编号" SortExpression="交易编号" HeaderText="确认书号" CommandName="OpenDocument">
																				<HeaderStyle Width="120px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="合同编号" SortExpression="合同编号" HeaderText="合同编号" CommandName="OpenDocument">
																				<HeaderStyle Width="120px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="交易日期" SortExpression="交易日期" HeaderText="订购日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																				<HeaderStyle Width="140px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="合同日期" SortExpression="合同日期" HeaderText="合同日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																				<HeaderStyle Width="120px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="统计日期" SortExpression="统计日期" HeaderText="统计日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																				<HeaderStyle Width="120px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="结案日期" SortExpression="结案日期" HeaderText="结案日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																				<HeaderStyle Width="120px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="交易状态" SortExpression="交易状态" HeaderText="交易状态" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="合同状态" SortExpression="合同状态" HeaderText="合同状态码" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="合同状态名称" SortExpression="合同状态名称" HeaderText="合同状态" CommandName="Select">
																				<HeaderStyle Width="100px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主名称" SortExpression="业主名称" HeaderText="甲方" CommandName="Select">
																				<HeaderStyle Width="160px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="客户名称" SortExpression="客户名称" HeaderText="乙方" CommandName="Select">
																				<HeaderStyle Width="160px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="700px" DataTextField="物业地址" SortExpression="物业地址" HeaderText="房屋地址" CommandName="Select">
																				<HeaderStyle Width="700px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易价格" SortExpression="交易价格" HeaderText="交易金额" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																				<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易面积" SortExpression="交易面积" HeaderText="交易面积" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																				<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="甲方代理费" SortExpression="甲方代理费" HeaderText="甲方代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																				<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="乙方代理费" SortExpression="乙方代理费" HeaderText="乙方代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																				<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="代理费折扣" SortExpression="代理费折扣" HeaderText="代理费折扣" CommandName="Select" DataTextFormatString="{0:#.00%}" ItemStyle-HorizontalAlign="Right">
																				<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
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
																		
																		<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																	</asp:datagrid><INPUT id="htxtHTFixed" type="hidden" value="0" runat="server" NAME="htxtHTFixed">
																</DIV>
															</TD>
														</TR>
														<TR>
															<TD class="label">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTDeSelectAll" runat="server">不选</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTSelectAll" runat="server">全选</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveFirst" runat="server">最前</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMovePrev" runat="server">前页</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveNext" runat="server">下页</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveLast" runat="server">最后</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtHTPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTSetPageSize" runat="server">每页</asp:linkbutton><asp:textbox id="txtHTPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
																		<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblHTGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
													<% if propQRSH()="" then response.write("</div>") %>
												</TD>
											</TR>
											<TR id="trRow03">
												<TD><% if propQRSH()="" then response.write("<div style='display:none'>") %>
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;交易信息</B></TD>
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;交易编号：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" width="15%">&nbsp;<asp:Label id="lblJYBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;交易日期：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" width="15%">&nbsp;<asp:Label id="lblJYRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;甲方名称：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" width="18%">&nbsp;<asp:Label id="lblJFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;交易价格(元)：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right" width="15%">&nbsp;<asp:Label id="lblJYJG" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;甲方代理费(元)：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right" width="15%">&nbsp;<asp:Label id="lblJFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																	</TR>
																	<TR>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;合同编号：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left">&nbsp;<asp:Label id="lblHTBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;合同日期：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left">&nbsp;<asp:Label id="lblHTRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;乙方名称：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left">&nbsp;<asp:Label id="lblYFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;交易面积(㎡)：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right">&nbsp;<asp:Label id="lblJYMJ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;乙方代理费(元)：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right">&nbsp;<asp:Label id="lblYFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																	</TR>
																	<TR>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;物业地址：&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" colSpan="9">&nbsp;<asp:Label id="lblWYDZ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
													<% if propQRSH()="" then response.write("</div>") %>
												</TD>
											</TR>
											<TR id="trRow04">
												<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;合同结算情况一览表</B></TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divJSS" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 200px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 200px">
														<asp:datagrid id="grdJSS" runat="server" Width="1610px" CssClass="label" CellPadding="4" AllowSorting="False"
															BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
															GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False" UseAccessibleHeader="True">
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
																		<asp:CheckBox id="chkJSS" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="结算单位" SortExpression="结算单位" HeaderText="结算单位码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="经办人员" SortExpression="经办人员" HeaderText="经办人员码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="结算类型" SortExpression="结算类型" HeaderText="结算类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="状态标志" SortExpression="状态标志" HeaderText="状态标志" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="50px" DataTextField="状态标志名称" SortExpression="状态标志名称" HeaderText="审核" CommandName="Select">
																	<HeaderStyle Width="50px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="结算类型名称" SortExpression="结算类型名称" HeaderText="类型" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="结算书号" SortExpression="结算书号" HeaderText="结算书号" CommandName="OpenDocument">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="结算日期" SortExpression="结算日期" HeaderText="结算日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="中介费额" SortExpression="中介费额" HeaderText="中介费额(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="结算额甲" SortExpression="结算额甲" HeaderText="甲方结算(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="结算额乙" SortExpression="结算额乙" HeaderText="乙方结算(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="实收额甲" SortExpression="实收额甲" HeaderText="甲方实收(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="实收额乙" SortExpression="实收额乙" HeaderText="乙方实收(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="结算单位名称" SortExpression="结算单位名称" HeaderText="结算单位" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="经办人员名称" SortExpression="经办人员名称" HeaderText="经办人员" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="备注信息" SortExpression="备注信息" HeaderText="备注信息" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtJSSFixed" type="hidden" value="0" runat="server" NAME="htxtJSSFixed">
													</DIV>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="3"></TD>
					</TR>
					<TR id="trRow05">
						<TD width="5"></TD>
						<TD align="left">&nbsp;&nbsp;&nbsp;&nbsp;更改说明：<asp:TextBox ID="txtBZXX" Runat="server" CssClass="textbox" Width="800px">强制调整业绩分配</asp:TextBox></TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="3"></TD>
					</TR>
					<TR id="trRow06">
						<TD align="center" colSpan="3">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD height="4"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Button id="btnGGFPBL" Runat="server" CssClass="button" Text="更改分配比例" Height="36px"></asp:Button>
										<asp:Button id="btnGGJSYJ" Runat="server" CssClass="button" Text="更改结算业绩" Height="36px"></asp:Button>
										<asp:Button id="btnGGHTBZ" Runat="server" CssClass="button" Text="记录更改说明" Height="36px"></asp:Button>
										<asp:Button id="btnZDTZXD" Runat="server" CssClass="button" Text="自动调整选定" Height="36px"></asp:Button>
										<asp:Button id="btnZDTZQB" Runat="server" CssClass="button" Text="自动调整全部" Height="36px"></asp:Button>
										<asp:Button id="btnClose"  Runat="server" CssClass="button" Text="返    回"     Height="36px"></asp:Button>
									</TD>
								</TR>
							</TABLE>
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
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button id="btnGoBack" Runat="server" Text=" 返回 " Font-Size="24pt"></asp:Button></P></TD>
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
						<input id="htxtSessionIdQueryHT" type="hidden" runat="server" NAME="htxtSessionIdQueryHT">
						<input id="htxtHTQuery" type="hidden" runat="server" NAME="htxtHTQuery">
						<input id="htxtHTRows" type="hidden" runat="server" NAME="htxtHTRows">
						<input id="htxtHTSort" type="hidden" runat="server" NAME="htxtHTSort">
						<input id="htxtHTSortColumnIndex" type="hidden" runat="server" NAME="htxtHTSortColumnIndex">
						<input id="htxtHTSortType" type="hidden" runat="server" NAME="htxtHTSortType">
						<input id="htxtDivLeftJSS" type="hidden" runat="server" NAME="htxtDivLeftJSS">
						<input id="htxtDivTopJSS" type="hidden" runat="server" NAME="htxtDivTopJSS">
						<input id="htxtDivLeftHT" type="hidden" runat="server" NAME="htxtDivLeftHT">
						<input id="htxtDivTopHT" type="hidden" runat="server" NAME="htxtDivTopHT">
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
							function ScrollProc_divHT() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopHT");
								if (oText != null) oText.value = divHT.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftHT");
								if (oText != null) oText.value = divHT.scrollLeft;
								return;
							}
							function ScrollProc_divJSS() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJSS");
								if (oText != null) oText.value = divJSS.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSS");
								if (oText != null) oText.value = divJSS.scrollLeft;
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
								oText=document.getElementById("htxtDivTopHT");
								if (oText != null) divHT.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftHT");
								if (oText != null) divHT.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopJSS");
								if (oText != null) divJSS.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSS");
								if (oText != null) divJSS.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divHT.onscroll = ScrollProc_divHT;
								divJSS.onscroll = ScrollProc_divJSS;
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
