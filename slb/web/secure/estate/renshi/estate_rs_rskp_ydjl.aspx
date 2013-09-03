<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_rskp_ydjl.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_rskp_ydjl" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>人员人事变动情况查看与编辑窗</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdRYLISTLocked { ; LEFT: expression(divRYLIST.scrollLeft); POSITION: relative }
		    TH.grdRYLISTLocked { ; LEFT: expression(divRYLIST.scrollLeft); POSITION: relative }
		    TH.grdRYLISTLocked { Z-INDEX: 99 }
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
				
				if (document.all("divRYLIST") == null)
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
				intHeight -= trRow5.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);

				divRYLIST.style.width  = strWidth;
				divRYLIST.style.height = strHeight;
				divRYLIST.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body background="../../images/oabk.gif" bottomMargin="0" leftMargin="0" topMargin="0"
		rightMargin="0" onresize="return window_onresize()">
		<form id="frmestate_rs_rskp_ydjl" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="left" colSpan="3" height="30">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;人事变动管理【<%=propRYMC%>】<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD height="4"></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow2">
												<TD class="label" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid"
													align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">人员&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_RYDM" runat="server" Columns="4" Font-Names="宋体" CssClass="textbox" Font-Size="12px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;时间&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_YDSJMin" runat="server" Columns="8" Font-Names="宋体" CssClass="textbox" Font-Size="12px"></asp:textbox>~<asp:textbox id="txtRYLISTSearch_YDSJMax" runat="server" Columns="8" Font-Names="宋体" CssClass="textbox" Font-Size="12px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;现单位&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_RZDW" runat="server" Columns="6" Font-Names="宋体" CssClass="textbox" Font-Size="12px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;原单位&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_YRDW" runat="server" Columns="6" Font-Names="宋体" CssClass="textbox" Font-Size="12px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;在岗&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlRYLISTSearch_GWSX" runat="server" Font-Names="宋体" CssClass="textbox" Font-Size="12px">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="0">离岗</asp:ListItem>
																	<asp:ListItem Value="1">在岗</asp:ListItem>
																</asp:DropDownList>
															</TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;类型&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_YDYY" runat="server" Font-Names="宋体" CssClass="textbox" Font-Size="12px"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;职工类别&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_ZGSX" runat="server" Font-Names="宋体" CssClass="textbox" Font-Size="12px"></asp:DropDownList></TD>
															<TD class="label">&nbsp;<asp:button id="btnRYLISTSearch" Runat="server" CssClass="button" Text="快速"></asp:button><asp:button id="btnRYLISTSearch_Full" Runat="server" CssClass="button" Text="全文"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divRYLIST" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 326px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 326px">
														<asp:datagrid id="grdRYLIST" runat="server" Width="2960px" Font-Names="宋体" CssClass="label" Font-Size="12px"
															UseAccessibleHeader="True" AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical"
															BackColor="White" BorderStyle="None" PageSize="12" BorderColor="#DEDFDE" BorderWidth="0px"
															AllowSorting="True" CellPadding="2">
															<SelectedItemStyle Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															
															<Columns>
																<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkRYLIST" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="员工号" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="人员真名" SortExpression="人员真名" HeaderText="姓名" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="开始时间" SortExpression="开始时间" HeaderText="开始时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="终止时间" SortExpression="终止时间" HeaderText="终止时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="变动原因" SortExpression="变动原因" HeaderText="变动原因码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="变动原因名称" SortExpression="变动原因名称" HeaderText="变动类型" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="任职单位" SortExpression="任职单位" HeaderText="任职单位码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="任职单位名称" SortExpression="任职单位名称" HeaderText="现任单位" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原任单位" SortExpression="原任单位" HeaderText="原任单位码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="原任单位名称" SortExpression="原任单位名称" HeaderText="原任单位" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="任职级别" SortExpression="任职级别" HeaderText="现任级别" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="原任级别" SortExpression="原任级别" HeaderText="原任级别" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="岗位属性" SortExpression="岗位属性" HeaderText="岗位属性码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="岗位属性名称" SortExpression="岗位属性名称" HeaderText="现在/离岗" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原岗属性" SortExpression="原岗属性" HeaderText="原岗属性码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原岗属性名称" SortExpression="原岗属性名称" HeaderText="原在/离岗" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职工属性" SortExpression="职工属性" HeaderText="职工属性码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="职工属性名称" SortExpression="职工属性名称" HeaderText="现职工类别" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原职属性" SortExpression="原职属性" HeaderText="原职属性码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原职属性名称" SortExpression="原职属性名称" HeaderText="原职工类别" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="本次占编" SortExpression="本次占编" HeaderText="本次占编" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="上次占编" SortExpression="上次占编" HeaderText="上次占编" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="现属团队" SortExpression="现属团队" HeaderText="现属团队" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原属团队" SortExpression="原属团队" HeaderText="原属团队" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="所属分组" SortExpression="所属分组" HeaderText="现属分组" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原属分组" SortExpression="原属分组" HeaderText="原属分组" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="级别标志" SortExpression="级别标志" HeaderText="级别标志码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="级别标志名称" SortExpression="级别标志名称" HeaderText="级别说明" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="分管工作" SortExpression="分管工作" HeaderText="分管工作" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="备注信息" SortExpression="备注信息" HeaderText="备注" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="360px" DataTextField="关联标识" SortExpression="关联标识" HeaderText="关联标识" CommandName="Select">
																	<HeaderStyle Width="360px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="下页" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtRYLISTFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTDeSelectAll" runat="server">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTSelectAll" runat="server">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTMoveFirst" runat="server">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTMovePrev" runat="server">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTMoveNext" runat="server">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTMoveLast" runat="server">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtRYLISTPageIndex" runat="server" Columns="3" CssClass="textbox">1</asp:textbox>页</TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTSetPageSize" runat="server">每页</asp:linkbutton><asp:textbox id="txtRYLISTPageSize" runat="server" Columns="3" CssClass="textbox">12</asp:textbox>条</TD>
															<TD class="label" vAlign="baseline" noWrap align="right"><asp:label id="lblRYLISTGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR id="trRow4">
												<TD class="label" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" width="100%">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" width="100%">
																<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
																	<TR>
																		<TD class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;员工名称</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtRYMC" Runat="server" Width="264px" CssClass="textbox"></asp:textbox><asp:Button id="btnSelect_RYDM" Runat="server" CssClass="button" Text="…"></asp:Button><INPUT id="htxtWYBS" type="hidden" size="1" runat="server"><INPUT id="htxtRYDM" type="hidden" size="1" runat="server"><INPUT id="htxtGLBS" type="hidden" size="1" runat="server"></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;现任单位</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtRZDW" Runat="server" Width="190px" CssClass="textbox"></asp:textbox><asp:Button id="btnSelect_RZDW" Runat="server" CssClass="button" Text="…"></asp:Button><INPUT id="htxtRZDW" type="hidden" size="1" runat="server"></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;原任单位</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtYRDW" Runat="server" Width="190px" CssClass="textbox"></asp:textbox><asp:Button id="btnSelect_YRDW" Runat="server" CssClass="button" Text="…"></asp:Button><INPUT id="htxtYRDW" type="hidden" size="1" runat="server" NAME="htxtYRDW"></TD>
																		<TD><asp:button id="btnSave" Runat="server" Width="48px" CssClass="button" Text="保存" Height="24px"></asp:button></TD>
																	</TR>
																	<TR>
																		<TD class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;变动开始</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtKSSJ" Runat="server" Width="264px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;现任级别</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtRZJB" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;原任级别</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtYRJB" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;变动结束</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtJSSJ" Runat="server" Width="264px" CssClass="textbox"></asp:textbox></td>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;现职类别</TD>
																		<TD class="label" align="left" nowrap><asp:DropDownList id="ddlZGSX" Runat="server" Width="190px" CssClass="textbox"></asp:DropDownList></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;原职类别</TD>
																		<TD class="label" align="left" nowrap><asp:DropDownList id="ddlYZSX" Runat="server" Width="190px" CssClass="textbox"></asp:DropDownList></TD>
																		<TD></TD>
																	</TR>
																	<tr>
																		<TD class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;变动类型</TD>
																		<TD class="label" align="left" nowrap><asp:DropDownList id="ddlYDYY" Runat="server" Width="264px" CssClass="textbox"></asp:DropDownList></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;现属分组</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtSSFZ" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;原属分组</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtYSFZ" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<td></td>
																		<td></td>
																		<td></td>
																	</tr>
																	<TR>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;级别类型</TD>
																		<TD class="label" align="left" nowrap>
																			<asp:RadioButtonList id="rblJBBZ" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
																				<asp:ListItem Value="0">非管理人员</asp:ListItem>
																				<asp:ListItem Value="1">中层管理人员</asp:ListItem>
																				<asp:ListItem Value="2">高层管理人员</asp:ListItem>
																			</asp:RadioButtonList>
																		</TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;现在离岗</TD>
																		<TD class="label" align="left" nowrap>
																			<asp:RadioButtonList id="rblGWSX" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
																				<asp:ListItem Value="0">离岗</asp:ListItem>
																				<asp:ListItem Value="1">在岗</asp:ListItem>
																			</asp:RadioButtonList>
																		</TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;原在离岗</TD>
																		<TD class="label" align="left" nowrap>
																			<asp:RadioButtonList id="rblYGSX" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
																				<asp:ListItem Value="0">离岗</asp:ListItem>
																				<asp:ListItem Value="1">在岗</asp:ListItem>
																			</asp:RadioButtonList>
																		</TD>
																		<TD></TD>
																	</TR>
																	<tr>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;分管工作</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtFGGZ" Runat="server" Width="264px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;现在占编</TD>
																		<TD class="label" align="left" nowrap>
																			<asp:RadioButtonList id="rblBCZB" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
																				<asp:ListItem Value="0">不占</asp:ListItem>
																				<asp:ListItem Value="1">占编</asp:ListItem>
																			</asp:RadioButtonList>
																		</TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;原先占编</TD>
																		<TD class="label" align="left" nowrap>
																			<asp:RadioButtonList id="rblSCZB" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
																				<asp:ListItem Value="0">不占</asp:ListItem>
																				<asp:ListItem Value="1">占编</asp:ListItem>
																			</asp:RadioButtonList>
																		</TD>
																	</tr>
																	<tr>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;备注信息</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtBZXX" Runat="server" Width="264px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;现属团队</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtXSTD" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;原属团队</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtYSTD" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<td><asp:button id="btnCancel" Runat="server" Width="48px" CssClass="button" Text="取消" Height="24px"></asp:button></td>
																	</tr>
																</TABLE>
															</TD>
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
					<TR id="trRow5">
						<TD align="center" colSpan="3">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD height="3"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Button id="btnAddNew" Runat="server" CssClass="button" Text=" 增    加 " Height="36px"></asp:Button>&nbsp;&nbsp;
										<asp:Button id="btnUpdate" Runat="server" CssClass="button" Text=" 修    改 " Height="36px"></asp:Button>&nbsp;&nbsp;
										<asp:Button id="btnDelete" Runat="server" CssClass="button" Text=" 删    除 " Height="36px"></asp:Button>&nbsp;&nbsp;
										<asp:Button id="btnPrint"  Runat="server" CssClass="button" Text=" 打    印 " Height="36px"></asp:Button>&nbsp;&nbsp;
										<asp:Button id="btnClose"  Runat="server" CssClass="button" Text=" 返    回 " Height="36px"></asp:Button>
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
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button id="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></P></TD>
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
						<input id="htxtCurrentPage" type="hidden" runat="server">
						<input id="htxtCurrentRow" type="hidden" runat="server">
						<input id="htxtEditMode" type="hidden" runat="server">
						<input id="htxtEditType" type="hidden" runat="server">
						<input id="htxtSessionIdQuery" type="hidden" runat="server">
						<input id="htxtRYLISTQuery" type="hidden" runat="server">
						<input id="htxtRYLISTRows" type="hidden" runat="server">
						<input id="htxtRYLISTSort" type="hidden" runat="server">
						<input id="htxtRYLISTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtRYLISTSortType" type="hidden" runat="server">
						<input id="htxtDivLeftRYLIST" type="hidden" runat="server">
						<input id="htxtDivTopRYLIST" type="hidden" runat="server">
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
							function ScrollProc_divRYLIST() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRYLIST");
								if (oText != null) oText.value = divRYLIST.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRYLIST");
								if (oText != null) oText.value = divRYLIST.scrollLeft;
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
								oText=document.getElementById("htxtDivTopRYLIST");
								if (oText != null) divRYLIST.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRYLIST");
								if (oText != null) divRYLIST.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divRYLIST.onscroll = ScrollProc_divRYLIST;
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
