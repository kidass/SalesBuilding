<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_hetongzl_info.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetongzl_info" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>租赁合同查看与编辑</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdWYXXLocked { ; LEFT: expression(divWYXX.scrollLeft); POSITION: relative }
			TH.grdWYXXLocked { ; LEFT: expression(divWYXX.scrollLeft); POSITION: relative }
			TH.grdWYXXLocked { Z-INDEX: 99 }
			TD.grdYWRYLocked { ; LEFT: expression(divYWRY.scrollLeft); POSITION: relative }
			TH.grdYWRYLocked { ; LEFT: expression(divYWRY.scrollLeft); POSITION: relative }
			TH.grdYWRYLocked { Z-INDEX: 99 }
			TD.grdZLQXLocked { ; LEFT: expression(divZLQX.scrollLeft); POSITION: relative }
			TH.grdZLQXLocked { ; LEFT: expression(divZLQX.scrollLeft); POSITION: relative }
			TH.grdZLQXLocked { Z-INDEX: 99 }
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
				
				if (document.all("divMain") == null)
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
				strHeight  = intHeight.toString() + "px";

				divMain.style.width  = strWidth;
				divMain.style.height = strHeight;
				divMain.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmestate_es_hetongzl_info" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR id="trRow1">
						<TD align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
								<TR>
									<TD class="title" align="center">房地产租赁合同<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
									<TD width="20">&nbsp;</TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="right"><span class="labelAuto">合同编号：</span><asp:TextBox id="txtHTBH" runat="server" CssClass="textbox" Columns="14"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;客源编号：<asp:TextBox id="txtKYBH" runat="server" Columns="24" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">签订日期：</span><asp:TextBox id="txtHTRQ" runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;&nbsp;<span class="labelAuto">签约统计日期：</span><asp:TextBox id="txtTJRQ" runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkHTJC" runat="server"  CssClass="labelAuto" Text="合同解除"/><asp:CheckBox ID="chkHTHZ" runat="server"  CssClass="labelAuto" Text="存在坏账"/><INPUT id="htxtHTWYBS" type="hidden" size="1" runat="server"><INPUT id="htxtHTZT" type="hidden" size="1" runat="server"><INPUT id="htxtWYBS" type="hidden" size="1" runat="server"><INPUT id="htxtQRSH" type="hidden" size="1" runat="server"><INPUT id="htxtDGRQ" type="hidden" size="1" runat="server"><INPUT id="htxtHTBZ" type="hidden" size="1" runat="server"></TD>
									<TD width="20">&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<DIV id="divMain" style="BORDER-TOP: #99cccc 2px solid; OVERFLOW: auto; WIDTH: 964px; CLIP: rect(0px 964px 447px 0px); BORDER-BOTTOM: #99cccc 2px solid; HEIGHT: 447px">
								<TABLE>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;基本资料</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                 <tr>
                                                    <td align="left"><span class="labelNotNull">查册地址：</span><asp:TextBox id="txtCCDZ" runat="server" Columns="60" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">查册费：</span><asp:TextBox id="txtCCF" runat="server" Columns="14" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;佣金资料(RMB)</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr>
                                                    <td align="left"><span class="labelAuto">月租金额：</span><asp:TextBox id="txtJYYZJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">业主佣金：</span><asp:TextBox id="txtJFDLF" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">客户佣金：</span><asp:TextBox id="txtYFDLF" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelAuto">租金总额：</span><asp:TextBox id="txtJYZZJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">兴业实收：</span><asp:TextBox id="txtSSYJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">合作佣金：</span><asp:TextBox id="txtHZYJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelAuto">按揭返还：</span><asp:TextBox id="txtAJFH" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;代理折扣：<asp:TextBox id="txtDLFZK" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>% (100%表示没有折扣)</td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelAuto">坏账金额：</span><asp:TextBox id="txtHZJE" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelAuto">解除日期：</span><asp:TextBox id="txtJCRQ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelAuto">坏账日期：</span><asp:TextBox id="txtHZRQ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;物业楼宇</B></TD>
                                    </TR>
									<TR>
										<TD>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD>
														<DIV id="divWYXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 260px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 260px">
															<asp:datagrid id="grdWYXX" runat="server" Width="4160px" CssClass="label" CellPadding="4" AllowSorting="False"
																BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
																GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False" UseAccessibleHeader="True">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle ForeColor="#CC0000" VerticalAlign="Middle" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle BorderWidth="0px" ForeColor="Black" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7"></ItemStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc"></HeaderStyle>
																
																<Columns>
																	<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkWYXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	
                                                                    <asp:ButtonColumn ItemStyle-Width="700px" DataTextField="物业信息" SortExpression="物业信息" HeaderText="物业信息" CommandName="OpenDocument">
                                                                        <HeaderStyle Width="700px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
																	
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="物业编码" SortExpression="物业编码" HeaderText="物业编码" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="240px" DataTextField="房屋地址" SortExpression="房屋地址" HeaderText="房屋地址" CommandName="OpenDocument">
																		<HeaderStyle Width="240px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="房产证号" SortExpression="房产证号" HeaderText="房产证号" CommandName="OpenDocument">
																		<HeaderStyle Width="160px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="房产证地址" SortExpression="房产证地址" HeaderText="房产证地址" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="月租金" SortExpression="月租金" HeaderText="月租金" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																		<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="面积" SortExpression="面积" HeaderText="面积" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																		<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="座向" SortExpression="座向" HeaderText="朝向" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼层" SortExpression="楼层" HeaderText="楼层" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼龄" SortExpression="楼龄" HeaderText="楼龄" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="间隔" SortExpression="间隔" HeaderText="间隔码" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="间隔名称" SortExpression="间隔名称" HeaderText="户型" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="物业性质" SortExpression="物业性质" HeaderText="物业性质码" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="物业性质名称" SortExpression="物业性质名称" HeaderText="物业性质" CommandName="Select">
																		<HeaderStyle Width="140px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="所在区域" SortExpression="所在区域" HeaderText="所在区域码" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="所在区域名称" SortExpression="所在区域名称" HeaderText="所在区域" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	
                                                                    <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="房源编号" SortExpression="房源编号" HeaderText="房源编号" CommandName="Select">
                                                                        <HeaderStyle Width="160px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="楼盘" SortExpression="楼盘" HeaderText="楼盘" CommandName="Select">
                                                                        <HeaderStyle Width="160px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼栋" SortExpression="楼栋" HeaderText="楼栋" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="单元" SortExpression="单元" HeaderText="单元" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="建成时间" SortExpression="建成时间" HeaderText="建成时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="空间类型" SortExpression="空间类型" HeaderText="空间类型" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="房屋性质" SortExpression="房屋性质" HeaderText="房屋性质" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="装修档次" SortExpression="装修档次" HeaderText="装修档次" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="装修年限" SortExpression="装修年限" HeaderText="装修年限" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="噪音影响" SortExpression="噪音影响" HeaderText="噪音影响" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="家具设备" SortExpression="家具设备" HeaderText="家具设备" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼宇交通" SortExpression="楼宇交通" HeaderText="楼宇交通" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="房屋间隔" SortExpression="房屋间隔" HeaderText="房屋间隔" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="景观类型" SortExpression="景观类型" HeaderText="房屋景观" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="景观房数" SortExpression="景观房数" HeaderText="景观房数" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼高" SortExpression="楼高" HeaderText="楼高" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="卧室数量" SortExpression="卧室数量" HeaderText="卧室数量" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="阳台数量" SortExpression="阳台数量" HeaderText="阳台数量" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="false" DataTextField="花园面积" SortExpression="花园面积" HeaderText="花园面积" CommandName="Select" DataTextFormatString="{0:0.00}">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="电梯数量" SortExpression="电梯数量" HeaderText="电梯数量" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼层户数" SortExpression="楼层户数" HeaderText="楼层户数" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼盘期数" SortExpression="楼盘期数" HeaderText="楼盘期数" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
																	
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="备注信息" SortExpression="备注信息" HeaderText="备注信息" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																</Columns>
																
																<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
															</asp:datagrid><INPUT id="htxtWYXXFixed" type="hidden" value="0" runat="server">
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD align="right"><asp:Button id="btnAddNew_WYXX" Runat="server" CssClass="button" Text=" 加入新的物业 "></asp:Button><asp:Button id="btnUpdate_WYXX" Runat="server" CssClass="button" Text=" 更改物业资料 "></asp:Button><asp:Button id="btnDelete_WYXX" Runat="server" CssClass="button" Text=" 删除现有物业 "></asp:Button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;交易详情</B></TD>
                                    </TR>
									<TR>
										<TD>
                                            <TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                <tr>
                                                    <td align="left" class="labelNotNull">租期：从<asp:TextBox id="txtZLKS" runat="server" Columns="12" CssClass="textbox"></asp:TextBox>至<asp:TextBox id="txtZLJS" runat="server" Columns="12" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span style="width:96px">水、电、煤气：</span>
                                                        <asp:RadioButtonList id="rblSDMQ" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="包括">包括</asp:ListItem>
                                                            <asp:ListItem Value="不包括">不包括</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="width:84px">电话费：</span>
                                                        <asp:RadioButtonList id="rblDHF" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="包括">包括</asp:ListItem>
                                                            <asp:ListItem Value="不包括">不包括</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span style="width:96px">管理费：</span>
                                                        <asp:RadioButtonList id="rblGLF" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="包括">包括</asp:ListItem>
                                                            <asp:ListItem Value="不包括">不包括</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="width:84px">租赁发票：</span>
                                                        <asp:RadioButtonList id="rblZLFP" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="包括">包括</asp:ListItem>
                                                            <asp:ListItem Value="不包括">不包括</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">业主名称：</span><asp:TextBox id="txtJFMC" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>&nbsp;&nbsp;代理人：<asp:TextBox id="txtJFDLR" runat="server" Columns="24" CssClass="textbox"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;证件号码：</span><asp:DropDownList id="ddlJFZJLB" runat="server" CssClass="textbox" Width="100px">
                                                            <asp:ListItem Value="0">身份证</asp:ListItem>
                                                            <asp:ListItem Value="1">护照</asp:ListItem>
                                                            <asp:ListItem Value="2">营业执照</asp:ListItem>
                                                        </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox id="txtJFZZHM" Runat="server" CssClass="textbox" Columns="36"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="label">剩余物业：</span>
                                                        <asp:RadioButtonList id="rblSYWY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
                                                            <asp:ListItem Value="1套">1套</asp:ListItem>
                                                            <asp:ListItem Value="2-3套">2-3套</asp:ListItem>
                                                            <asp:ListItem Value="4套以上">4套以上</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">业主电话：</span><asp:TextBox id="txtJFLXDH" Runat="server" CssClass="textbox" Columns="48"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;地区：</span><asp:RadioButtonList ID="rblYZQC" runat="server" CssClass="textbox" RepeatColumns="2" RepeatLayout="Flow" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="大陆">大陆</asp:ListItem>
                                                            <asp:ListItem Value="其他地区或国家">其他地区或国家</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtYZQN" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">业主来源：</span>
                                                        <asp:RadioButtonList id="rblYZLY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="11">
                                                            <asp:ListItem Value="Call in">Call in</asp:ListItem>
                                                            <asp:ListItem Value="Walk in">Walk in</asp:ListItem>
                                                            <asp:ListItem Value="Cold Call">Cold Call</asp:ListItem>
                                                            <asp:ListItem Value="转介">转介</asp:ListItem>
                                                            <asp:ListItem Value="旧客">旧客</asp:ListItem>
                                                            <asp:ListItem Value="广州日报">广州日报</asp:ListItem>
                                                            <asp:ListItem Value="搜房">搜房</asp:ListItem>
                                                            <asp:ListItem Value="安居客">安居客</asp:ListItem>
                                                            <asp:ListItem Value="超经">超经</asp:ListItem>
                                                            <asp:ListItem Value="焦点">焦点</asp:ListItem>
                                                            <asp:ListItem Value="其他">其他</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtYYQT" runat="server" CssClass="textbox" Columns="20"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">业主地址：<asp:TextBox id="txtJFLXDZ" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </TR>
                                                <tr>
                                                    <td align="left">业主电邮：<asp:TextBox id="txtYZDY" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">租客名称：</span><asp:TextBox id="txtYFMC" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>&nbsp;&nbsp;代理人：<asp:TextBox id="txtYFDLR" runat="server" CssClass="textbox" Columns="24"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;证件号码：</span><asp:DropDownList id="ddlYFZJLB" runat="server" CssClass="textbox" Width="100px">
                                                            <asp:ListItem Value="0">身份证</asp:ListItem>
                                                            <asp:ListItem Value="1">护照</asp:ListItem>
                                                            <asp:ListItem Value="2">营业执照</asp:ListItem>
                                                        </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox id="txtYFZZHM" Runat="server" CssClass="textbox" Columns="36"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">租客电话：</span><asp:TextBox id="txtYFLXDH" Runat="server" CssClass="textbox" Columns="48"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;地区：</span><asp:RadioButtonList ID="rblMJQC" runat="server" CssClass="textbox" RepeatColumns="2" RepeatLayout="Flow" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="大陆">大陆</asp:ListItem>
                                                            <asp:ListItem Value="其他地区或国家">其他地区或国家</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtMJQN" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">租客来源：</span>
                                                        <asp:RadioButtonList id="rblKHLY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="11">
                                                            <asp:ListItem Value="Call in">Call in</asp:ListItem>
                                                            <asp:ListItem Value="Walk in">Walk in</asp:ListItem>
                                                            <asp:ListItem Value="Cold Call">Cold Call</asp:ListItem>
                                                            <asp:ListItem Value="转介">转介</asp:ListItem>
                                                            <asp:ListItem Value="旧客">旧客</asp:ListItem>
                                                            <asp:ListItem Value="广州日报">广州日报</asp:ListItem>
                                                            <asp:ListItem Value="搜房">搜房</asp:ListItem>
                                                            <asp:ListItem Value="安居客">安居客</asp:ListItem>
                                                            <asp:ListItem Value="超经">超经</asp:ListItem>
                                                            <asp:ListItem Value="焦点">焦点</asp:ListItem>
                                                            <asp:ListItem Value="其他">其他</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtKYQT" runat="server" CssClass="textbox" Columns="20"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">租客地址：<asp:TextBox id="txtYFLXDZ" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">租客电邮：<asp:TextBox id="txtKHDY" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </tr>
                                            </TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;租赁期限</B></TD>
									</TR>
									<TR>
										<TD>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD>
														<DIV id="divZLQX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 140px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 140px">
															<asp:datagrid id="grdZLQX" runat="server" CssClass="label" CellPadding="4" AllowSorting="False"
																BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
																GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False" UseAccessibleHeader="True">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle ForeColor="#CC0000" VerticalAlign="Middle" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle BorderWidth="0px" ForeColor="Black" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7"></ItemStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc"></HeaderStyle>
																
																<Columns>
																	<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkZLQX" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="开始日期" SortExpression="开始日期" HeaderText="开始日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																		<HeaderStyle Width="180px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="终止日期" SortExpression="终止日期" HeaderText="终止日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																		<HeaderStyle Width="180px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="月租金额" SortExpression="月租金额" HeaderText="月租金(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																		<HeaderStyle Width="180px" HorizontalAlign="Right"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="月租总额" SortExpression="月租总额" HeaderText="总额(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																		<HeaderStyle Width="180px" HorizontalAlign="Right"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="租期月数" SortExpression="租期月数" HeaderText="租期(月)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																		<HeaderStyle Width="180px" HorizontalAlign="Right"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="缴租日" SortExpression="缴租日" HeaderText="缴租日" CommandName="Select">
																		<HeaderStyle Width="120px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="缴租方式" SortExpression="缴租方式" HeaderText="缴租方式" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="缴租方式名称" SortExpression="缴租方式名称" HeaderText="计租方法" CommandName="Select">
																		<HeaderStyle Width="160px"></HeaderStyle>
																	</asp:ButtonColumn>
																</Columns>
																
																<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
															</asp:datagrid><INPUT id="htxtZLQXFixed" type="hidden" value="0" runat="server">
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD style="BORDER-RIGHT: #6699cc 1px solid; BORDER-LEFT: #6699cc 1px solid; BORDER-BOTTOM: #6699cc 1px solid"><% if propEditMode()=false then response.write("<div style='display:none'>") %>
														<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
															<TR>
																<TD class="labelNotNull" noWrap align="right">开始日期</TD>
																<TD align="left"><asp:TextBox id="txtQX_KSRQ" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox></TD>
																<TD class="labelNotNull" noWrap align="right">终止日期</TD>
																<TD align="left"><asp:TextBox id="txtQX_ZZRQ" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox></TD>
																<TD class="label" noWrap align="right">月租金</TD>
																<TD align="left"><asp:TextBox id="txtQX_YZJE" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></TD>
																<TD class="label" noWrap align="right">缴租日</TD>
																<TD align="left"><asp:TextBox id="txtQX_JZR" Runat="server" CssClass="textbox" Columns="2"></asp:TextBox></TD>
																<TD class="label" noWrap align="right">计租方法</TD>
																<TD align="left">
																	<asp:RadioButtonList id="rblQX_JZFS" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
																		<asp:ListItem Value="0">自然月</asp:ListItem>
																		<asp:ListItem Value="1">非自然月</asp:ListItem>
																	</asp:RadioButtonList>
																</TD>
																<TD class="labelAuto" noWrap align="right">总额</TD>
																<TD align="left"><asp:TextBox id="txtQX_YZZE" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></TD>
																<TD class="labelAuto" noWrap align="right">租期</TD>
																<TD class="label" align="left"><asp:TextBox id="txtQX_ZQYS" Runat="server" CssClass="textbox" Columns="2"></asp:TextBox>月</TD>
															</TR>
														</TABLE>
														<% if propEditMode()=false then response.write("</div>") %>
													</TD>
												</TR>
												<TR>
													<TD align="right"><asp:Button id="btnCompute_ZLQX" Runat="server" CssClass="button" Text="计算租金租期"></asp:Button><asp:Button id="btnAddNew_ZLQX" Runat="server" CssClass="button" Text=" 加入新的期限 "></asp:Button><asp:Button id="btnUpdate_ZLQX" Runat="server" CssClass="button" Text=" 更改当前期限 "></asp:Button><asp:Button id="btnDelete_ZLQX" Runat="server" CssClass="button" Text=" 删除选定期限 "></asp:Button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;其他资料</B></TD>
									</TR>
									<TR>
										<TD>
											<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
												<TR>
													<TD class="labelAuto" align="left">建筑面积：<asp:TextBox id="txtJYZMJ" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>平方米(以房产证面积为准)；</TD>
												</TR>
												<TR>
													<TD class="labelAuto" align="left">房屋地址：<asp:TextBox id="txtFWDZ" runat="server" Width="800px" CssClass="textbox"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD class="labelAuto" align="left">租赁保证金：<asp:TextBox id="txtZLBZJ" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>元人民币</TD>
												</TR>
												<TR>
													<TD class="label" align="left">租期月数：<asp:TextBox id="txtZQYS" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>月</TD>
												</TR>
												<TR>
													<TD class="labelNotNull" align="left">付款模式：<asp:DropDownList id="ddlFKFS" Runat="server" CssClass="textbox" Width="420px"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="label" align="left">缴租方式：<asp:RadioButtonList id="rblFZFSYD" Runat="server" CssClass="textbox" RepeatColumns="4" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="0">月缴</asp:ListItem>
															<asp:ListItem Value="1">季缴</asp:ListItem>
															<asp:ListItem Value="2">半年</asp:ListItem>
															<asp:ListItem Value="3">年缴</asp:ListItem>
														</asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;缴租日：<asp:TextBox id="txtJZR" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>
													</TD>
												</TR>
												<TR>
													<TD class="label" align="left">滞纳金比例：<asp:TextBox id="txtZNJBL" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>%月租金额</TD>
												</TR>
												<TR>
													<TD class="label" align="left">租金递增比例：<asp:TextBox id="txtNDZBL" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>%按年递增</TD>
												</TR>
												<TR>
													<TD class="label" align="left">交楼日期：<asp:TextBox id="txtJLRQ" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD class="label" align="left">交楼状况：<asp:TextBox id="txtJLZKSM" runat="server" Width="800px" TextMode="MultiLine" Rows="3"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD class="label" align="left">交易税费：<asp:RadioButtonList id="rblSFZFYD" Runat="server" CssClass="textbox" RepeatColumns="4" RepeatDirection="Vertical" RepeatLayout="Flow" AutoPostBack="False">
															<asp:ListItem Value="0">各付各税</asp:ListItem>
															<asp:ListItem Value="1">甲方包税(卖方包税)</asp:ListItem>
															<asp:ListItem Value="2">乙方包税(买方包税)</asp:ListItem>
															<asp:ListItem Value="3">其他</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
												</TR>
												<TR>
													<TD class="label" align="left">租金托管：<asp:RadioButtonList id="rblZJTGYD" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="0">不托管</asp:ListItem>
															<asp:ListItem Value="1">托管</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;备注</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <TR>
                                                    <TD align="left"><asp:TextBox id="txtBZXX" runat="server" Width="900px" Rows="8" TextMode="MultiLine"></asp:TextBox></TD>
                                                </TR>
                                            </TABLE>
                                        </td>
                                    </tr>
									<TR>
										<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;相关业务员资料</B></TD>
									</TR>
									<TR>
										<TD>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD>
														<DIV id="divYWRY" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 200px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 200px">
															<asp:datagrid id="grdYWRY" runat="server" CssClass="label" CellPadding="4" AllowSorting="False"
																BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
																GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False" UseAccessibleHeader="True">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle ForeColor="#CC0000" VerticalAlign="Middle" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle BorderWidth="0px" ForeColor="Black" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7"></ItemStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc"></HeaderStyle>
																
																<Columns>
																	<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkYWRY" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员名称" SortExpression="人员名称" HeaderText="人员名称" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="单位代码" SortExpression="单位代码" HeaderText="单位代码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="单位名称" SortExpression="单位名称" HeaderText="单位名称" CommandName="Select">
                                                                        <HeaderStyle Width="300px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="所属分组" SortExpression="所属分组" HeaderText="所属分组" CommandName="Select">
                                                                        <HeaderStyle Width="200px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="团队编号" SortExpression="团队编号" HeaderText="团队" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="人员职级" SortExpression="人员职级" HeaderText="人员职级码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="240px" DataTextField="人员职级名称" SortExpression="人员职级名称" HeaderText="职级" CommandName="Select">
                                                                        <HeaderStyle Width="240px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="分配比例" SortExpression="分配比例" HeaderText="分配比例" CommandName="Select" DataTextFormatString="{0:#.00%}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="直管标记" SortExpression="直管标记" HeaderText="直管标记" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="直管标记名称" SortExpression="直管标记名称" HeaderText="直管" CommandName="Select">
                                                                        <HeaderStyle Width="80px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="状态标志" SortExpression="状态标志" HeaderText="状态标志" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="状态标志名称" SortExpression="状态标志名称" HeaderText="状态" CommandName="Select">
                                                                        <HeaderStyle Width="80px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
																</Columns>
																
																<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
															</asp:datagrid><INPUT id="htxtYWRYFixed" type="hidden" value="0" runat="server">
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD align="right"><asp:Button id="btnAddNew_YWRY" Runat="server" CssClass="button" Text=" 加入新的业务员 "></asp:Button><asp:Button id="btnDelete_YWRY" Runat="server" CssClass="button" Text=" 删除现有业务员 "></asp:Button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
					</TR>
					<TR id="trRow2">
						<TD align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD height="4"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:button id="btnFPBL"   Runat="server" CssClass="button" Text="业绩分配" Height="36px"></asp:button>
										<asp:button id="btnSHQK"   Runat="server" CssClass="button" Text="审核情况" Height="36px"></asp:button>
                                        <asp:button id="btnAJFH"   Runat="server" CssClass="button" Text="按揭返还" Height="36px"></asp:button>
										<asp:button id="btnSJSZ"   Runat="server" CssClass="button" Text="实际收支" Height="36px"></asp:button>
										<asp:button id="btnYSYF"   Runat="server" CssClass="button" Text="计划收支" Height="36px"></asp:button>
										<asp:button id="btnSZTZ"   Runat="server" CssClass="button" Text="收支台帐" Height="36px"></asp:button>
										<asp:button id="btnJSQK"   Runat="server" CssClass="button" Text="结算情况" Height="36px"></asp:button>
										<asp:button id="btnBAQK"   Runat="server" CssClass="button" Text="办案情况" Height="36px"></asp:button>
										<asp:button id="btnHTJA"   Runat="server" CssClass="button" Text="合同结案" Height="36px"></asp:button>
                                        <asp:button id="btnJCHT"   Runat="server" CssClass="button" Text="解除合同" Height="36px"></asp:button>
                                        <asp:button id="btnBJHZ"   Runat="server" CssClass="button" Text="标记坏账" Height="36px"></asp:button>
										<asp:button id="btnOK"     Runat="server" CssClass="button" Text="确    定" Height="36px"></asp:button>
										<asp:button id="btnCancel" Runat="server" CssClass="button" Text="取    消" Height="36px"></asp:button>
										<asp:button id="btnClose"  Runat="server" CssClass="button" Text="返    回" Height="36px"></asp:button>
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
			<TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
				<TR>
					<TD>
						<INPUT id="htxtSessionId_ZLQX" type="hidden" runat="server">
						<INPUT id="htxtSessionId_WYXX" type="hidden" runat="server">
						<INPUT id="htxtSessionId_YWRY" type="hidden" runat="server">
						<INPUT id="htxtDivLeftZLQX" type="hidden" runat="server">
						<INPUT id="htxtDivTopZLQX" type="hidden" runat="server">
						<INPUT id="htxtDivLeftWYXX" type="hidden" runat="server">
						<INPUT id="htxtDivTopWYXX" type="hidden" runat="server">
						<INPUT id="htxtDivLeftYWRY" type="hidden" runat="server">
						<INPUT id="htxtDivTopYWRY" type="hidden" runat="server">
						<INPUT id="htxtDivLeftMain" type="hidden" runat="server">
						<INPUT id="htxtDivTopMain" type="hidden" runat="server">
						<INPUT id="htxtDivLeftBody" type="hidden" runat="server">
						<INPUT id="htxtDivTopBody" type="hidden" runat="server">
					</TD>
				</TR>
				<TR>
					<TD>
						<SCRIPT language="javascript">
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
							function ScrollProc_divMain() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopMain");
								if (oText != null) oText.value = divMain.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftMain");
								if (oText != null) oText.value = divMain.scrollLeft;
								return;
							}
							function ScrollProc_divWYXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopWYXX");
								if (oText != null) oText.value = divWYXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftWYXX");
								if (oText != null) oText.value = divWYXX.scrollLeft;
								return;
							}
							function ScrollProc_divYWRY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopYWRY");
								if (oText != null) oText.value = divYWRY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftYWRY");
								if (oText != null) oText.value = divYWRY.scrollLeft;
								return;
							}
							function ScrollProc_divZLQX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopZLQX");
								if (oText != null) oText.value = divZLQX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftZLQX");
								if (oText != null) oText.value = divZLQX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopMain");
								if (oText != null) divMain.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftMain");
								if (oText != null) divMain.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopWYXX");
								if (oText != null) divWYXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftWYXX");
								if (oText != null) divWYXX.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopYWRY");
								if (oText != null) divYWRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftYWRY");
								if (oText != null) divYWRY.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopZLQX");
								if (oText != null) divZLQX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftZLQX");
								if (oText != null) divZLQX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divWYXX.onscroll = ScrollProc_divWYXX;
								divYWRY.onscroll = ScrollProc_divYWRY;
								divZLQX.onscroll = ScrollProc_divZLQX;
							}
							catch (e) {}
						</SCRIPT>
					</TD>
				</TR>
				<TR>
					<TD>
						<SCRIPT language="javascript">window_onresize();</SCRIPT>
						<UWIN:POPMESSAGE id="popMessageObject" runat="server" Visible="False" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" height="48px" width="96px"></UWIN:POPMESSAGE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
