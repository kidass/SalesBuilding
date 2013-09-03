<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_yongjinjitibiaozhun_x3.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_yongjinjitibiaozhun_x3" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>佣金计提标准(三)</title>
        <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">		
		<script src="../../../scripts/transkey.js"></script>
		 <LINK href="../../../StylePerson.css" type="text/css" rel="stylesheet">			
		<style>
			TD.grdSYLocked { ; LEFT: expression(divSY.scrollLeft); POSITION: relative }
			TH.grdSYLocked { ; LEFT: expression(divSY.scrollLeft); POSITION: relative }
			TH.grdSYLocked { Z-INDEX: 99 }
			TD.grdGYZGZJLocked { ; LEFT: expression(divGYZGZJ.scrollLeft); POSITION: relative }
			TH.grdGYZGZJLocked { ; LEFT: expression(divGYZGZJ.scrollLeft); POSITION: relative }
			TH.grdGYZGZJLocked { Z-INDEX: 99 }
			TD.grdGYZGLocked { ; LEFT: expression(divGYZG.scrollLeft); POSITION: relative }
			TH.grdGYZGLocked { ; LEFT: expression(divGYZG.scrollLeft); POSITION: relative }
			TH.grdGYZGLocked { Z-INDEX: 99 }
			TD.grdGYXGLocked { ; LEFT: expression(divGYXG.scrollLeft); POSITION: relative }
			TH.grdGYXGLocked { ; LEFT: expression(divGYXG.scrollLeft); POSITION: relative }
			TH.grdGYXGLocked { Z-INDEX: 99 }
			TD.grdGYZTZJLocked { ; LEFT: expression(divGYZTZJ.scrollLeft); POSITION: relative }
			TH.grdGYZTZJLocked { ; LEFT: expression(divGYZTZJ.scrollLeft); POSITION: relative }
			TH.grdGYZTZJLocked { Z-INDEX: 99 }
			TD.grdGYZTLocked { ; LEFT: expression(divGYZT.scrollLeft); POSITION: relative }
			TH.grdGYZTLocked { ; LEFT: expression(divGYZT.scrollLeft); POSITION: relative }
			TH.grdGYZTLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
        </style>        
        <script language="javascript">
			function doSYBZ()
			{
				__doPostBack("lnkSYBZ");				
			}
			function doZGGY()
			{
				__doPostBack("lnkZGGY");				
			}
			function doXGGY()
			{
				__doPostBack("lnkXGGY");				
			}
			function doZTGY()
			{
				__doPostBack("lnkZTGY");				
			}
			function doFHSJ()
			{
				__doPostBack("lnkFHSJ");				
			}			
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				dblWidth   = document.body.clientWidth;   //总宽度
				dblWidth  -= 24;                          //滚动条
				dblWidth  -= 2 * 4;                       //左、右空白
				dblHeight  = document.body.clientHeight;  //总高度
				dblHeight -= 24;                          //调整数

				strWidth  = (dblWidth - tdCol01.clientWidth).toString() + "px";
				strHeight = (dblHeight - trRowSY01.clientHeight - trRowSY02.clientHeight - trRowSY03.clientHeight - trRowSY04.clientHeight).toString() + "px";
				divSY.style.width  = strWidth;
				divSY.style.height = strHeight;
				divSY.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				strWidth  = (dblWidth - tdCol01.clientWidth).toString() + "px";
				strHeight = (dblHeight - trRowGYXG01.clientHeight - trRowGYXG02.clientHeight - trRowGYXG03.clientHeight - trRowGYXG04.clientHeight).toString() + "px";
				divGYXG.style.width  = strWidth;
				divGYXG.style.height = strHeight;
				divGYXG.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				strWidth  = divGYZGZJ.style.width;
				strHeight = (dblHeight - trRowGYZG01.clientHeight - trRowGYZG02.clientHeight - trRowGYZG03.clientHeight - trRowGYZG04.clientHeight - trRowGYZG06.clientHeight + 4).toString() + "px";
				divGYZGZJ.style.width  = strWidth;
				divGYZGZJ.style.height = strHeight;
				divGYZGZJ.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				strWidth  = (dblWidth - tdCol01.clientWidth - tdColZG01.clientWidth - 4).toString() + "px";
				strHeight = (dblHeight - trRowGYZG01.clientHeight - trRowGYZG02.clientHeight - trRowGYZG05.clientHeight - trRowGYZG06.clientHeight).toString() + "px";
				divGYZG.style.width  = strWidth;
				divGYZG.style.height = strHeight;
				divGYZG.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				strWidth  = divGYZTZJ.style.width;
				strHeight = (dblHeight - trRowGYZT01.clientHeight - trRowGYZT02.clientHeight - trRowGYZT03.clientHeight - trRowGYZT04.clientHeight - trRowGYZT06.clientHeight + 4).toString() + "px";
				divGYZTZJ.style.width  = strWidth;
				divGYZTZJ.style.height = strHeight;
				divGYZTZJ.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				strWidth  = (dblWidth - tdCol01.clientWidth - tdColZT01.clientWidth - 4).toString() + "px";
				strHeight = (dblHeight - trRowGYZT01.clientHeight - trRowGYZT02.clientHeight - trRowGYZT05.clientHeight - trRowGYZT06.clientHeight).toString() + "px";
				divGYZT.style.width  = strWidth;
				divGYZT.style.height = strHeight;
				divGYZT.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
				return window_onresize();
			}
		
		</script>
		<script language="javascript" for="document" event="onreadystatechange">		
			return document_onreadystatechange()		
		</script>		
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmestate_rs_yongjinjitibiaozhun_x3" method="post" runat="server">
			<asp:Panel ID="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" border="0">
					<TR>
						<td>							
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<tr>
									<TD id="tdCol01" vAlign="top" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" width="200px">
										<TABLE cellSpacing="0" cellPadding="0" border="0" width="200">
											<TR>
												<TD class="labelTitle" colspan="2" align="center" valign="middle"><br>佣金计提标准<br>(三)</TD>
											</TR>
											<tr>
												<td colspan="2" height="20"></td>
											</tr>
											<TR height="30" valign="middle">
												<td style="BORDER-BOTTOM: #33cccc 1px solid" width="32">&nbsp;<%if propFunctionId = 1 then response.write("<img border='0' src='../../../images/ARWRT.GIF'>") %></td>
												<TD style="BORDER-BOTTOM: #33cccc 1px solid" class="labelInfo"><asp:LinkButton id="lnkSYBZ" Runat="server" Width="0px"></asp:LinkButton><A id="doSYBZ" href="javascript:doSYBZ()">私佣计提标准</a></TD>										
											</TR>
											<TR height="30" valign="middle">
												<td style="BORDER-BOTTOM: #33cccc 1px solid" width="32">&nbsp;<%if propFunctionId = 2 then response.write("<img border='0' src='../../../images/ARWRT.GIF'>") %></td>
												<TD style="BORDER-BOTTOM: #33cccc 1px solid" class="labelInfo"><asp:LinkButton id="lnkZGGY" Runat="server" Width="0px"></asp:LinkButton><A id="doZGGY" href="javascript:doZGGY()">营经直管公佣</a></TD>
											</TR>
											<TR height="30" valign="middle">
												<td style="BORDER-BOTTOM: #33cccc 1px solid" width="32">&nbsp;<%if propFunctionId = 3 then response.write("<img border='0' src='../../../images/ARWRT.GIF'>") %></td>
												<TD style="BORDER-BOTTOM: #33cccc 1px solid" class="labelInfo"><asp:LinkButton id="lnkXGGY" Runat="server" Width="0px"></asp:LinkButton><A id="doXGGY" href="javascript:doXGGY()">营经协管公佣</a></TD>
											</TR>
											<TR height="30" valign="middle">
												<td style="BORDER-BOTTOM: #33cccc 1px solid" width="32">&nbsp;<%if propFunctionId = 4 then response.write("<img border='0' src='../../../images/ARWRT.GIF'>") %></td>
												<TD style="BORDER-BOTTOM: #33cccc 1px solid" class="labelInfo"><asp:LinkButton id="lnkZTGY" Runat="server" Width="0px"></asp:LinkButton><A id="doZTGY" href="javascript:doZTGY()">其他职级公佣</a></TD>
											</TR>												
											<TR height="30" valign="middle">
												<td style="BORDER-BOTTOM: #33cccc 1px solid" width="32">&nbsp;</td>
												<TD style="BORDER-BOTTOM: #33cccc 1px solid" class="labelInfo"><asp:LinkButton id="lnkFHSJ" Runat="server" Width="0px"></asp:LinkButton><A id="doFHSJ" href="javascript:doFHSJ()">返回上级</a></TD>
											</TR>
											<TR>
												<td width="32">&nbsp;</td>
												<TD height="300px">&nbsp;</TD>
											</TR>
										</TABLE>
									</TD> 						
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">							
										<% 
											if propFunctionId = 1 then
												response.write("<DIV>" + vbcr)
											else
												response.write("<DIV style='display:none'>" + vbcr)
											end if
										%>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD vAlign="top">
                                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR id="trRowSY01">
																<TD class="typeTitle" align="left" background="../../../images/yj/bg_title.gif" height="30px"><img src="../../../images/yj/titleicon.gif">&nbsp;个人完成业绩的佣金计提标准(私佣标准)</TD>
															</TR>
															<TR id="trRowSY02">
																<TD class="label" align="left" height="10px"></TD>
															</TR>
                                                            <TR>
                                                                <TD>
                                                                    <DIV id="divSY" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
                                                                        <asp:datagrid id="grdSY" runat="server" Width="100%"  CssClass="labelGrid" 
																			AllowPaging="False" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
																			PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4" UseAccessibleHeader="True" BorderStyle="Solid">
																			<SelectedItemStyle Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
																			<EditItemStyle BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
																			<AlternatingItemStyle BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle CssClass="FixedHead"  Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                            <Columns>
                                                                                <asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="30px">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox id="chkSY" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
                                                                                <asp:TemplateColumn HeaderText="区间小值" ItemStyle-Width="20%" HeaderStyle-ForeColor="white">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtQJZX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="区间大值" ItemStyle-Width="20%" HeaderStyle-ForeColor="white">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtQJZD" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="最小额度" ItemStyle-Width="20%" HeaderStyle-ForeColor="white">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtEDZX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="最大额度" ItemStyle-Width="20%" HeaderStyle-ForeColor="white"> 
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtEDZD" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="计提比例" ItemStyle-Width="20%" HeaderStyle-ForeColor="white">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtJTBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                            </Columns>
                                                                            <PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                        </asp:datagrid><INPUT id="htxtSYFixed" type="hidden" value="0" runat="server" NAME="htxtSYFixed">
                                                                    </DIV>
                                                                </TD>
                                                            </TR>
                                                            <tr id="trRowSY03">
                                                                <TD align="right" valign="middle">
                                                                    <asp:Button id="btnAddNew_SY" Runat="server" Text="添加末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                                                    <asp:Button id="btnDelete_SY" Runat="server" Text="删除末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnSave_SY"   Runat="server" Text="保存私佣指标" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>																	
                                                                </TD>
                                                            </TR>
                                                            <tr id="trRowSY04">
                                                                <TD align="left">
																	<table cellpadding="0" cellspacing="0" border="0" width="100%">
																		<tr>
																			<td align="left" class="label" bgcolor="#ccff99">填写说明：</td>
																		</tr>																		
																		<tr>
																			<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(1) 第一个[区间小值]固定=0，不能改动</td>
																		</tr>																		
																		<tr>
																			<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(2) [区间大值]不能改动，系统自动设置：上行的[区间大值] = 下行的[区间小值] - 1</td>
																		</tr>
																		<tr>
																			<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(3) [区间小值]按从上到下顺序逐渐增大，至少大1</td>
																		</tr>
																		<tr>
																			<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(4) 区间范围、额度范围是个人月度结算业绩。
																		</tr>
																	</table>
																</TD>
                                                            </tr>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                            </TABLE>
										<% response.write("</DIV>" + vbcr) %>
										<% 
											if propFunctionId = 2 then
												response.write("<DIV>" + vbcr)
											else
												response.write("<DIV style='display:none'>" + vbcr)
											end if
										%>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR id="trRowGYZG01">
													<TD class="typeTitle" align="left" colspan="3" background="../../../images/yj/bg_title.gif" height="30px"><img src="../../../images/yj/titleicon.gif">&nbsp;营业经理直管团队业绩的佣金计提标准(直管公佣)</TD>
												</TR>
												<TR id="trRowGYZG02">
													<TD class="label" align="left" colspan="3" height="10px"></TD>
												</TR>
												<TR>
													<TD id="tdColZG01" align="left" valign="top">
														<TABLE cellSpacing="0" cellPadding="0" border="0">															
															<tr>
																<td valign="top">
																	<DIV id="divGYZGZJ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 260px; CLIP: rect(0px 260px 296px 0px); BORDER-BOTTOM: #aed3f0 2px inset; HEIGHT: 296px">
																		<asp:datagrid id="grdGYZGZJ" runat="server" CssClass="labelGrid" Width="100%"
																			AllowPaging="False" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
																			PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
																			<SelectedItemStyle  Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
																			<EditItemStyle   BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
																			<AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle CssClass="FixedHead"  Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" ItemStyle-Width="30px" Visible="False">
																					<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox Visible=False id="chkGYZGZJ" runat="server" AutoPostBack="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="区间最小" SortExpression="区间最小" HeaderText="区间最小" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="区间最大" SortExpression="区间最大" HeaderText="区间最大" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="最小额度" SortExpression="最小额度" HeaderText="最小额度" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="最大额度" SortExpression="最大额度" HeaderText="最大额度" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="计提比例" SortExpression="计提比例" HeaderText="计提比例" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="50%" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
																					<HeaderStyle Width="50%"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="50%" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
																					<HeaderStyle Width="50%"></HeaderStyle>
																				</asp:ButtonColumn>						                                                    
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtGYZGZJFixed" type="hidden" value="0" runat="server" NAME="htxtGYZGZJFixed">
																	</DIV>													
																</td>
															</tr>
															<TR id="trRowGYZG03">
																<td height="4">
																	<div style="display:none" >
																		<asp:Button id="btnSelAll_GYZGZJ"   Runat="server" Text="全部选定" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																		<asp:Button id="btnDeSelAll_GYZGZJ" Runat="server" Text="全部不选" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	</div> 
																</td>															
															</tr>
															<TR id="trRowGYZG04">
																<TD align="left" valign="middle">
																	<asp:Button id="btnAddNew_GYZGZJ" Runat="server" Text="加入新的职级" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnDelete_GYZGZJ" Runat="server" Text="删除选定职级" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																</TD>
															</TR>
														</TABLE>
													</TD>
													<td width="4">&nbsp;</td>
													<TD align="left" valign="top">
														<TABLE cellSpacing="0" cellPadding="0" border="0">	
															<tr>
																<td align="left" valign="top">
																	<DIV id="divGYZG" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 520px; CLIP: rect(0px 520px 296px 0px); BORDER-BOTTOM: #aed3f0 2px inset; HEIGHT: 296px">
																		<asp:datagrid id="grdGYZG" runat="server" CssClass="labelGrid" Width="100%"
																			AllowPaging="False" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
																			PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4" UseAccessibleHeader="True" BorderStyle="Solid">
																			<SelectedItemStyle  Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
																			<EditItemStyle   BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
																			<AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle CssClass="FixedHead"  Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="30px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkGYZG" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>						                                                    
																				<asp:TemplateColumn HeaderText="区间最小" ItemStyle-Width="20%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZGQJZX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="区间最大" ItemStyle-Width="20%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZGQJZD" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="最小额度" ItemStyle-Width="20%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZGZXED" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="最大额度" ItemStyle-Width="20%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZGZDED" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="计提比例" ItemStyle-Width="20%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZGJTBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtGYZGFixed" type="hidden" value="0" runat="server" NAME="htxtGYZGFixed">
																	</DIV>
																</td>
															</tr>
															<TR id="trRowGYZG05" vAlign="middle">
																<TD align="right" valign="middle">
																	<asp:Button id="btnAddNew_GYZG" Runat="server" Text="添加末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnDelete_GYZG" Runat="server" Text="删除末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnSave_GYZG"     Runat="server" Text="保存直管指标" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>																	
																</TD>
															</TR>											
														</TABLE>
													</TD>
												</TR>
												<tr id="trRowGYZG06">
													<TD align="left" colspan="3">
														<table cellpadding="0" cellspacing="0" border="0" width="100%">
															<tr>
																<td align="left" class="label" bgcolor="#ccff99">填写说明：</td>
															</tr>																		
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(1) 第一个[区间小值]固定=0，不能改动</td>
															</tr>													
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(2) 区间范围、额度范围是团队月度结算业绩。
															</tr>
														</table>
													</TD>
												</tr>												
											</TABLE>
										<% response.write("</DIV>" + vbcr) %>										
										<% 
											if propFunctionId = 3 then
												response.write("<DIV >" + vbcr)
											else
												response.write("<DIV style='display:none'>" + vbcr)
											end if
										%>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR id="trRowGYXG01">
													<TD class="typeTitle" align="left" background="../../../images/yj/bg_title.gif" height="30px"><img src="../../../images/yj/titleicon.gif">&nbsp;营业经理协管团队业绩的佣金计提标准(协管公佣)</TD>
												</TR>
												<TR id="trRowGYXG02">
													<TD class="label" align="left" height="10px"></TD>
												</TR>
												<TR>																						
													<TD align="left">
														<TABLE cellSpacing="0" cellPadding="0" border="0">	
															<tr>
																<td align="left" valign="top">
																	<DIV id="divGYXG" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 400px; CLIP: rect(0px 400px 296px 0px); BORDER-BOTTOM: #aed3f0 2px inset; HEIGHT: 296px">
																		<asp:datagrid id="grdGYXG" runat="server" CssClass="labelGrid" Width="100%"
																			AllowPaging="False" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
																			PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
																			<SelectedItemStyle  Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
																			<EditItemStyle   BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
																			<AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle CssClass="FixedHead"  Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="30px">
																					<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkGYXG" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
                                                                              	<asp:TemplateColumn HeaderText="区间最小" ItemStyle-Width="33%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="33%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtXGQJZX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>	
																				<asp:TemplateColumn HeaderText="区间最大" ItemStyle-Width="33%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="33%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtXGQJZD" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>																			
																				<asp:TemplateColumn HeaderText="计提比例" ItemStyle-Width="34%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="34%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtXGJTBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtGYXGFixed" type="hidden" value="0" runat="server" NAME="htxtGYXGFixed">
																	</DIV>															
																</td>
															</tr>
														</TABLE>
													</TD>
												</TR>	
												<TR id="trRowGYXG03" vAlign="middle">
													<TD align="left" valign="middle">
														<asp:Button id="btnAddNew_GYXG" Runat="server" Text="添加末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
														<asp:Button id="btnDelete_GYXG" Runat="server" Text="删除末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
														<asp:Button id="btnSave_GYXG"   Runat="server" Text="保存协管指标" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>																	
													</TD>
												</TR>
												<TR id="trRowGYXG04">
													<TD align="left">
														<table cellpadding="0" cellspacing="0" border="0" width="100%">
															<tr>
																<td align="left" class="label" bgcolor="#ccff99">填写说明：</td>
															</tr>
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(1) 区间范围是团队月度结算业绩与团队任务指标的比例，如35%，则录入0.35</td>
															</tr>
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(2) 计提比例不设置请填0</td>
															</tr>
														</table>
													</TD>
												</TR>
											</TABLE>
										<% response.write("</DIV>" + vbcr) %>
										<% 
											if propFunctionId = 4 then
												response.write("<DIV>" + vbcr)
											else
												response.write("<DIV style='display:none'>" + vbcr)
											end if
										%>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR id="trRowGYZT01">
													<TD class="typeTitle" align="left" colspan="3" background="../../../images/yj/bg_title.gif" height="30px"><img src="../../../images/yj/titleicon.gif">&nbsp;其他职级人员的管理佣金计提标准(直提公佣)</TD>
												</TR>
												<TR id="trRowGYZT02">
													<TD class="label" align="left" colspan="3" height="10px"></TD>
												</TR>
												<TR>
													<TD id="tdColZT01" align="left" valign="top">
														<TABLE cellSpacing="0" cellPadding="0" border="0">															
															<tr>
																<td valign="top">
																	<DIV id="divGYZTZJ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 260px; CLIP: rect(0px 260px 296px 0px); BORDER-BOTTOM: #aed3f0 2px inset; HEIGHT: 296px">
																		<asp:datagrid id="grdGYZTZJ" runat="server" CssClass="labelGrid" Width="100%"
																			AllowPaging="False" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
																			PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
																			<SelectedItemStyle  Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
																			<EditItemStyle   BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
																			<AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle CssClass="FixedHead"  Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" ItemStyle-Width="30px" Visible="False">
																					<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox Visible=False id="chkGYZTZJ" runat="server" AutoPostBack="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="区间最小" SortExpression="区间最小" HeaderText="区间最小" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="区间最大" SortExpression="区间最大" HeaderText="区间最大" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="计提比例" SortExpression="计提比例" HeaderText="计提比例" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="50%" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
																					<HeaderStyle Width="50%"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="50%" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
																					<HeaderStyle Width="50%"></HeaderStyle>
																				</asp:ButtonColumn>						                                                    
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtGYZTZJFixed" type="hidden" value="0" runat="server" NAME="htxtGYZTZJFixed">
																	</DIV>													
																</td>
															</tr>
															<TR id="trRowGYZT03">
																<td height="4">
																	<div style="display:none" >
																		<asp:Button id="btnSelAll_GYZTZJ"   Runat="server" Text="全部选定" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																		<asp:Button id="btnDeSelAll_GYZTZJ" Runat="server" Text="全部不选" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	</div> 
																</td>															
															</tr>
															<TR id="trRowGYZT04">
																<TD align="left" valign="middle">
																	<asp:Button id="btnAddNew_GYZTZJ" Runat="server" Text="加入新的职级" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnDelete_GYZTZJ" Runat="server" Text="删除选定职级" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																</TD>
															</TR>
														</TABLE>
													</TD>																							
													<td width="4">&nbsp;</td>
													<TD align="left" valign="top">
														<TABLE cellSpacing="0" cellPadding="0" border="0">	
															<tr>
																<td align="left" valign="top">
																	<DIV id="divGYZT" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 520px; CLIP: rect(0px 520px 296px 0px); BORDER-BOTTOM: #aed3f0 2px inset; HEIGHT: 296px">
																		<asp:datagrid id="grdGYZT" runat="server" CssClass="labelGrid" Width="100%"
																			AllowPaging="False" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
																			PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
																			<SelectedItemStyle  Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
																			<EditItemStyle   BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
																			<AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle CssClass="FixedHead"  Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="30px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkGYZT" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>						                                                    
																				<asp:TemplateColumn HeaderText="区间最小" ItemStyle-Width="33%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="33%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZTQJZX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="区间最大" ItemStyle-Width="33%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="33%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZTQJZD" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="计提比例" ItemStyle-Width="34%" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="34%"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZTJTBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtGYZTFixed" type="hidden" value="0" runat="server" NAME="htxtGYZTFixed">
																	</DIV>
																</td>
															</tr>
															<TR id="trRowGYZT05" vAlign="middle">
																<TD align="right" valign="middle">
																	<asp:Button id="btnAddNew_GYZT" Runat="server" Text="添加末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnDelete_GYZT" Runat="server" Text="删除末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnSave_GYZT"     Runat="server" Text="保存直提指标" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>																	
																</TD>
															</TR>											
														</TABLE>
													</TD>
												</TR>
												<tr id="trRowGYZT06">
													<TD align="left" colspan="3">
														<table cellpadding="0" cellspacing="0" border="0" width="100%">
															<tr>
																<td align="left" class="label" bgcolor="#ccff99">填写说明：</td>
															</tr>																		
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(1) 第一个[区间小值]固定=0，不能改动</td>
															</tr>													
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(2) 区间范围是团队月度人均结算业绩。
															</tr>
														</table>
													</TD>
												</tr>												
											</TABLE>
										<% response.write("</DIV>" + vbcr) %>							
									</TD>	
								</tr>														
							</table>							
						</td>						
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE id="tabErrMain" height="95%" cellSpacing="0" cellPadding="0" width="90%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
						<input id="htxtFunctionId" type="hidden" runat="server" value="1" NAME="htxtFunctionId">
						<input id="htxtSessionId_SY" type="hidden" runat="server" NAME="htxtSessionId_SY">
                        <input id="htxtSessionId_GYZGZJ" type="hidden" runat="server" NAME="htxtSessionId_GYZGZJ">
                        <input id="htxtSessionId_GYZG" type="hidden" runat="server" NAME="htxtSessionId_GYZG">
                        <input id="htxtSessionId_GYXG" type="hidden" runat="server" NAME="htxtSessionId_GYXG">
                        <input id="htxtSessionId_GYZTZJ" type="hidden" runat="server" NAME="htxtSessionId_GYZTZJ">
                        <input id="htxtSessionId_GYZT" type="hidden" runat="server" NAME="htxtSessionId_GYZT">
                        
                        <input id="htxtSYSort" type="hidden" runat="server" NAME="htxtSYSort">
						<input id="htxtSYSortColumnIndex" type="hidden" runat="server" NAME="htxtSYSortColumnIndex">
						<input id="htxtSYSortType" type="hidden" runat="server" NAME="htxtSYSortType">
						
						<input id="htxtGYZGZJSort" type="hidden" runat="server" NAME="htxtGYZGZJSort">
						<input id="htxtGYZGZJColumnIndex" type="hidden" runat="server" NAME="htxtGYZGZJColumnIndex">
						<input id="htxtGYZGZJSortType" type="hidden" runat="server" NAME="htxtGYZGZJSortType">
                        <input id="htxtGYZGSort" type="hidden" runat="server" NAME="htxtGYZGSort">
						<input id="htxtGYZGSortColumnIndex" type="hidden" runat="server" NAME="htxtGYZGSortColumnIndex">
                        <input id="htxtGYZGSortType" type="hidden" runat="server" NAME="htxtGYZGSortType">
                        
                        <input id="htxtGYXGSort" type="hidden" runat="server" NAME="htxtGYXGSort">
						<input id="htxtGYXGColumnIndex" type="hidden" runat="server" NAME="htxtGYXGColumnIndex">
						<input id="htxtGYXGSortType" type="hidden" runat="server" NAME="htxtGYXGSortType">

                        <input id="htxtGYZTSort" type="hidden" runat="server" NAME="htxtGYZTSort">
						<input id="htxtGYZTSortColumnIndex" type="hidden" runat="server" NAME="htxtGYZTSortColumnIndex">
                        <input id="htxtGYZTSortType" type="hidden" runat="server" NAME="htxtGYZTSortType">
                        <input id="htxtGYZTZJSort" type="hidden" runat="server" NAME="htxtGYZTZJSort">
						<input id="htxtGYZTZJColumnIndex" type="hidden" runat="server" NAME="htxtGYZTZJColumnIndex">
						<input id="htxtGYZTZJSortType" type="hidden" runat="server" NAME="htxtGYZTZJSortType">
						
						<input id="htxtDivLeftBody" type="hidden" runat="server" NAME="htxtDivLeftBody">
						<input id="htxtDivTopBody" type="hidden" runat="server" NAME="htxtDivTopBody">
						<input id="htxtDivLeftSY" type="hidden" runat="server" NAME="htxtDivLeftSY">
						<input id="htxtDivTopSY" type="hidden" runat="server" NAME="htxtDivTopSY">	
						<input id="htxtDivLeftGYZGZJ" type="hidden" runat="server" NAME="htxtDivLeftGYZGZJ">
						<input id="htxtDivTopGYZGZJ" type="hidden" runat="server" NAME="htxtDivTopGYZGZJ">
						<input id="htxtDivLeftGYZG" type="hidden" runat="server" NAME="htxtDivLeftGYZG">
						<input id="htxtDivTopGYZG" type="hidden" runat="server" NAME="htxtDivTopGYZG">
						<input id="htxtDivLeftGYXG" type="hidden" runat="server" NAME="htxtDivLeftGYXG">	
						<input id="htxtDivTopGYXG" type="hidden" runat="server" NAME="htxtDivTopGYXG">	
						<input id="htxtDivLeftGYZTZJ" type="hidden" runat="server" NAME="htxtDivLeftGYZTZJ">
						<input id="htxtDivTopGYZTZJ" type="hidden" runat="server" NAME="htxtDivTopGYZTZJ">
						<input id="htxtDivLeftGYZT" type="hidden" runat="server" NAME="htxtDivLeftGYZT">
						<input id="htxtDivTopGYZT" type="hidden" runat="server" NAME="htxtDivTopGYZT">
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
							function ScrollProc_divSY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSY");
								if (oText != null) oText.value = divSY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSY");
								if (oText != null) oText.value = divSY.scrollLeft;
								return;
							}							
							function ScrollProc_divGYZGZJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGYZGZJ");
								if (oText != null) oText.value = divGYZGZJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZGZJ");
								if (oText != null) oText.value = divGYZGZJ.scrollLeft;
								return;
							}
							function ScrollProc_divGYZG() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGYZG");
								if (oText != null) oText.value = divGYZG.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZG");
								if (oText != null) oText.value = divGYZG.scrollLeft;
								return;
							}
							function ScrollProc_divGYXG() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGYXG");
								if (oText != null) oText.value = divGYXG.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYXG");
								if (oText != null) oText.value = divGYXG.scrollLeft;
								return;
							}
							function ScrollProc_divGYZTZJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGYZTZJ");
								if (oText != null) oText.value = divGYZT.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZTZJ");
								if (oText != null) oText.value = divGYZT.scrollLeft;
								return;
							}
							function ScrollProc_divGYZT() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGYZT");
								if (oText != null) oText.value = divGYXG.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZT");
								if (oText != null) oText.value = divGYXG.scrollLeft;
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
								oText=document.getElementById("htxtDivTopSY");
								if (oText != null) divSY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSY");
								if (oText != null) divSY.scrollLeft = oText.value;
								
								oText=null;
								oText=document.getElementById("htxtDivTopGYZGZJ");
								if (oText != null) divGYZGZJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZGZJ");
								if (oText != null) divGYZGZJ.scrollLeft = oText.value;
								
								oText=null;
								oText=document.getElementById("htxtDivTopGYZG");
								if (oText != null) divGYZG.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZG");
								if (oText != null) divGYZG.scrollLeft = oText.value;
								
								oText=null;
								oText=document.getElementById("htxtDivTopGYXG");
								if (oText != null) divGYXG.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGXG");
								if (oText != null) divGYXG.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopGYZTZJ");
								if (oText != null) divGYZTZJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZTZJ");
								if (oText != null) divGYZTZJ.scrollLeft = oText.value;
								
								oText=null;
								oText=document.getElementById("htxtDivTopGYZT");
								if (oText != null) divGYZT.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGXGZB");
								if (oText != null) divGYZT.scrollLeft = oText.value;
								
								document.body.onscroll = ScrollProc_Body;
								divSY.onscroll = ScrollProc_divSY;
								divGYZGZJ.onscroll = ScrollProc_divGYZGZJ;
								divGYZG.onscroll = ScrollProc_divGYZG;
								divGYXG.onscroll = ScrollProc_divGYXG;
								divGYZTZJ.onscroll = ScrollProc_divGYZTZJ;
								divGYZT.onscroll = ScrollProc_divGYZT;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" width="96px" height="48px" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False" Visible="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
