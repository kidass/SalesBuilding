<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_yongjinjitibiaozhun_x2.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_yongjinjitibiaozhun_X2" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>佣金计提标准(二)</title>
        <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">		
		<script src="../../../scripts/transkey.js"></script>
		 <LINK href="../../../StylePerson.css" type="text/css" rel="stylesheet">			
		<style>
			TD.grdSYZBLocked { ; LEFT: expression(divSYZB.scrollLeft); POSITION: relative }
			TH.grdSYZBLocked { ; LEFT: expression(divSYZB.scrollLeft); POSITION: relative }
			TH.grdSYZBLocked { Z-INDEX: 99 }
			TD.grdGYZGLocked { ; LEFT: expression(divGYZG.scrollLeft); POSITION: relative }
			TH.grdGYZGLocked { ; LEFT: expression(divGYZG.scrollLeft); POSITION: relative }
			TH.grdGYZGLocked { Z-INDEX: 99 }
			TD.grdGYZGZBLocked { ; LEFT: expression(divGYZGZB.scrollLeft); POSITION: relative }
			TH.grdGYZGZBLocked { ; LEFT: expression(divGYZGZB.scrollLeft); POSITION: relative }
			TH.grdGYZGZBLocked { Z-INDEX: 99 }
			TD.grdGYXGZBLocked { ; LEFT: expression(divGYXGZB.scrollLeft); POSITION: relative }
			TH.grdGYXGZBLocked { ; LEFT: expression(divGYXGZB.scrollLeft); POSITION: relative }
			TH.grdGYXGZBLocked { Z-INDEX: 99 }
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
				var dblDeltaY = 40;
				var dblDeltaX = 0;
				var proEdit = 0 ;
				
				dblHeight = 450 + dblDeltaY + document.body.clientHeight - 900; //default state : 450px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 1050; //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				
				contentRight1.style.width  = strWidth;
				contentRight1.style.height = strHeight;
				contentRight1.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";				
			
				contentRight2.style.width  = strWidth;
				contentRight2.style.height = strHeight;
				contentRight2.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				
				contentRight3.style.width  = strWidth;
				contentRight3.style.height = strHeight;
				contentRight3.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				
				contentRight4.style.width  = strWidth;
				contentRight4.style.height = strHeight;
				contentRight4.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmestate_rs_yongjinjitibiaozhun_x2" method="post" runat="server">
			<asp:Panel ID="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" border="0">
					<TR>
						<TD height="8px"></TD>
					</TR>
					<TR>
						<td>							
							<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
								<tr>
									<TD vAlign="top" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" width="200px">
										<DIV id="contentLeft">
											<TABLE cellSpacing="0" cellPadding="5" width="100%" height="100%" border="0">
												<TR>
													<TD class="labelTitle" colspan="2" align="center" valign="middle">佣金计提标准<br>(二)</TD>
												</TR>
												<tr>
													<td colspan="2" height="20"></td>
												</tr>
												<TR height="30" valign="middle">
													<td style="BORDER-BOTTOM: #33cccc 1px solid" width="16">&nbsp;<%if propFunctionId = 1 then response.write("<img border='0' src='../../../images/ARWRT.GIF'>") %></td>
													<TD style="BORDER-BOTTOM: #33cccc 1px solid" class="labelInfo"><asp:LinkButton id="lnkSYBZ" Runat="server" Width="0px"></asp:LinkButton><A id="doSYBZ" href="javascript:doSYBZ()">私佣计提标准</a></TD>										
												</TR>
												<TR height="30" valign="middle">
													<td style="BORDER-BOTTOM: #33cccc 1px solid" width="16">&nbsp;<%if propFunctionId = 2 then response.write("<img border='0' src='../../../images/ARWRT.GIF'>") %></td>
													<TD style="BORDER-BOTTOM: #33cccc 1px solid" class="labelInfo"><asp:LinkButton id="lnkZGGY" Runat="server" Width="0px"></asp:LinkButton><A id="doZGGY" href="javascript:doZGGY()">营经直管公佣</a></TD>
												</TR>
												<TR height="30" valign="middle">
													<td style="BORDER-BOTTOM: #33cccc 1px solid" width="16">&nbsp;<%if propFunctionId = 3 then response.write("<img border='0' src='../../../images/ARWRT.GIF'>") %></td>
													<TD style="BORDER-BOTTOM: #33cccc 1px solid" class="labelInfo"><asp:LinkButton id="lnkXGGY" Runat="server" Width="0px"></asp:LinkButton><A id="doXGGY" href="javascript:doXGGY()">营经协管公佣</a></TD>
												</TR>
												<TR height="30" valign="middle">
													<td style="BORDER-BOTTOM: #33cccc 1px solid" width="16">&nbsp;<%if propFunctionId = 4 then response.write("<img border='0' src='../../../images/ARWRT.GIF'>") %></td>
													<TD style="BORDER-BOTTOM: #33cccc 1px solid" class="labelInfo"><asp:LinkButton id="lnkZTGY" Runat="server" Width="0px"></asp:LinkButton><A id="doZTGY" href="javascript:doZTGY()">其他职级公佣</a></TD>
												</TR>												
												<TR height="30" valign="middle">
													<td style="BORDER-BOTTOM: #33cccc 1px solid" width="16">&nbsp;</td>
													<TD style="BORDER-BOTTOM: #33cccc 1px solid" class="labelInfo"><asp:LinkButton id="lnkFHSJ" Runat="server" Width="0px"></asp:LinkButton><A id="doFHSJ" href="javascript:doFHSJ()">返回上级</a></TD>
												</TR>
												<TR>
													<td width="16">&nbsp;</td>
													<TD height="300px">&nbsp;</TD>
												</TR>
											</TABLE>
										</DIV>
									</TD> 						
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">							
										<% 
											if propFunctionId = 1 then
												response.write("<DIV id='contentRight1'>" + vbcr)
											else
												response.write("<DIV id='contentRight1' style='display:none'>" + vbcr)
											end if
										%>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD vAlign="top">
                                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD class="typeTitle" align="left" background="../../../images/yj/bg_title.gif" height="30px"><img src="../../../images/yj/titleicon.gif">&nbsp;个人完成业绩的佣金计提标准(私佣标准)</TD>
															</TR>
															<TR>
																<TD class="label" align="left" height="10px"></TD>
															</TR>
                                                            <TR>
                                                                <TD>
                                                                    <DIV id="divSYZB" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
                                                                        <asp:datagrid id="grdSYZB" runat="server" Width="600px" CssClass="labelGrid" 
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
                                                                                        <asp:CheckBox id="chkSYZB" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="区间小值" ItemStyle-Width="120px" HeaderStyle-ForeColor="white">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtQJZX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="区间大值" ItemStyle-Width="120px" HeaderStyle-ForeColor="white">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtQJZD" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="最小额度" ItemStyle-Width="120px" HeaderStyle-ForeColor="white">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtEDZX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="最大额度" ItemStyle-Width="120px" HeaderStyle-ForeColor="white"> 
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtEDZD" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="计提比例" ItemStyle-Width="120px" HeaderStyle-ForeColor="white">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtJTBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                            </Columns>
                                                                            <PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                        </asp:datagrid><INPUT id="htxtSYZBFixed" type="hidden" value="0" runat="server" NAME="htxtSYZBFixed">
                                                                    </DIV>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td height="4"></td>
                                                            </tr>
                                                            <TR>
                                                                <TD align="right" valign="middle">
                                                                    <asp:Button id="btnAddNew_SYZB" Runat="server" Text="添加末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                                                    <asp:Button id="btnDelete_SYZB" Runat="server" Text="删除末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnSave_SYZB"   Runat="server" Text="保        存" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>																	
                                                                </TD>
                                                            </TR>
                                                            <tr>
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
																			<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(4) 区间的值是佣金的基数范围，额度区间是计算计提比例的范围。
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
												response.write("<DIV id='contentRight2' style='display:'>" + vbcr)
											else
												response.write("<DIV id='contentRight2' style='display:none'>" + vbcr)
											end if
										%>
											<TABLE cellSpacing="1" cellPadding="5" width="100%" border="0">
												<TR>
													<TD class="typeTitle" colspan="2" align="left" background="../../../images/yj/bg_title.gif" height="30px"><img src="../../../images/yj/titleicon.gif">&nbsp;营业经理直管团队业绩的佣金计提标准(直管公佣)</TD>
												</TR>
												<TR>
													<TD class="label" colspan="2" align="left" height="10px"></TD>
												</TR>
												<TR>
													<TD align="left" valign="top">
														<TABLE  cellSpacing="0" cellPadding="0" border="0">															
															<tr>
																<td valign="top">
																	<DIV id="divGYZG" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 260px; CLIP: rect(0px 260px 296px 0px); BORDER-BOTTOM: #aed3f0 2px inset; HEIGHT: 296px">
																		<asp:datagrid id="grdGYZG" runat="server" CssClass="labelGrid" Width="250px"
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
																						<asp:CheckBox Visible=False  id="chkGYZG" runat="server" AutoPostBack="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
																					<HeaderStyle Width="120px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="130px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
																					<HeaderStyle Width="130px"></HeaderStyle>
																				</asp:ButtonColumn>						                                                    
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtGYZGFixed" type="hidden" value="0" runat="server">
																	</DIV>													
																</td>
															</tr>
															<tr>
																<td height="4">
																	<div style="display:none" >
																		<asp:Button id="btnSelAll_GYZG"   Runat="server" Text="全部选定" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																		<asp:Button id="btnDeSelAll_GYZG" Runat="server" Text="全部不选" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	</div> 
																</td>															
															</tr>
															<TR>
																<TD align="left" valign="middle">
																	<asp:Button id="btnAddNew_GYZG" Runat="server" Text="加入职级" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnDelete_GYZG" Runat="server" Text="删除职级" Font-Size="14px" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																</TD>
															</TR>
														</TABLE>
													</TD>																							
													<TD align="left" valign="top">
														<TABLE  cellSpacing="0" cellPadding="0" border="0">	
															<tr>
																<td align="left" valign="top">
																	<DIV id="divGYZGZB" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 520px; CLIP: rect(0px 520px 296px 0px); BORDER-BOTTOM: #aed3f0 2px inset; HEIGHT: 296px">
																		<asp:datagrid id="grdGYZGZB" runat="server" CssClass="labelGrid" Width="510px"
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
																						<asp:CheckBox id="chkGYZGZB" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			<asp:TemplateColumn HeaderText="区间最小" ItemStyle-Width="90px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZGQJZX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="区间最大" ItemStyle-Width="90px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZGQJZD" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="最小任务比例" ItemStyle-Width="110px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZGZXRWBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="最大任务比例" ItemStyle-Width="110px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZGZDRWBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="计提比例" ItemStyle-Width="90px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZGJTBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtGYZGZBFixed" type="hidden" value="0" runat="server" >
																	</DIV>															
																</td>
															</tr>
															<tr>
																<td height="4px"></td>
															</tr> 
															<TR vAlign="middle">
																<TD align="right" valign="middle">
																	<asp:Button id="btnAddNew_GYZGZB" Runat="server" Text="添加末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnDelete_GYZGZB" Runat="server" Text="删除末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
																	<asp:Button id="btnSave_GYZG"     Runat="server" Text="保        存" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>																	
																</TD>
															</TR>											
														</TABLE>
													</TD>
												</TR>
												<tr>
													<TD align="left" colspan="2">
														<table cellpadding="0" cellspacing="0" border="0" width="100%">
															<tr>
																<td align="left" class="label" bgcolor="#ccff99">填写说明：</td>
															</tr>																		
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(1) 第一个[区间小值]固定=0，不能改动</td>
															</tr>													
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(2)  区间的值是佣金的基数范围，任务比例区间是计算计提比例的范围。
															</tr>
														</table>
													</TD>
												</tr>												
											</TABLE>
										<% response.write("</DIV>" + vbcr) %>										
										<% 
											if propFunctionId = 3 then
												response.write("<DIV id='contentRight3' style='display:'>" + vbcr)
											else
												response.write("<DIV id='contentRight3' style='display:none'>" + vbcr)
											end if
										%>
											<TABLE cellSpacing="1" cellPadding="5" width="100%" border="0">
												<TR>
													<TD class="typeTitle" align="left" background="../../../images/yj/bg_title.gif" height="30px"><img src="../../../images/yj/titleicon.gif">&nbsp;营业经理协管团队业绩的佣金计提标准(协管公佣)</TD>
												</TR>
												<TR>
													<TD class="label" align="left" height="10px"></TD>
												</TR>
												<TR>																						
													<TD align="left">
														<TABLE cellSpacing="0" cellPadding="0" border="0">	
															<tr>
																<td align="left" valign="top">
																	<DIV id="divGYXGZB" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 400px; CLIP: rect(0px 400px 296px 0px); BORDER-BOTTOM: #aed3f0 2px inset; HEIGHT: 296px">
																		<asp:datagrid id="grdGYXGZB"  runat="server" CssClass="labelGrid" 
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
																						<asp:CheckBox id="chkGYXGZB" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="区间最小" ItemStyle-Width="120px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtXGQJZX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>	
																				<asp:TemplateColumn HeaderText="区间最大" ItemStyle-Width="120px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtXGQJZD" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>																			
																				<asp:TemplateColumn HeaderText="计提比例" ItemStyle-Width="120px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtXGJTBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtGYXGZBFixed" type="hidden" value="0" runat="server" >
																	</DIV>															
																</td>
															</tr>
														</TABLE>
													</TD>
												</TR>	
												<TR vAlign="middle">
													<TD align="left" valign="middle">
														<asp:Button id="btnAddNew_GYXGZB" Runat="server" Text="添加末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
														<asp:Button id="btnDelete_GYXGZB" Runat="server" Text="删除末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
														<asp:Button id="btnSave_GYXG"     Runat="server" Text="保        存" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>																	
													</TD>
												</TR>
												<TR>
													<TD align="left">
														<table cellpadding="0" cellspacing="0" border="0" width="100%">
															<tr>
																<td align="left" class="label" bgcolor="#ccff99">填写说明：</td>
															</tr>
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(1) 区间填写的是完成任务比例范围，如35%，则录入0.35</td>
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
												response.write("<DIV id='contentRight4' style='display:'>" + vbcr)
											else
												response.write("<DIV id='contentRight4' style='display:none'>" + vbcr)
											end if
										%>
											<TABLE cellSpacing="1" cellPadding="5" width="100%" border="0">
												<TR>
													<TD class="typeTitle" align="left" background="../../../images/yj/bg_title.gif" height="30px"><img src="../../../images/yj/titleicon.gif">&nbsp;其他职级人员的公佣计提标准</TD>
												</TR>
												<TR>
													<TD class="label" align="left" height="10px"></TD>
												</TR>
												<TR>
													<TD align="left">
														<TABLE cellSpacing="0" cellPadding="0" border="0">	
															<tr>
																<td valign="top">
																	<DIV id="divGYZT" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 570px; CLIP: rect(0px 570px 320px 0px); BORDER-BOTTOM: #aed3f0 2px inset; HEIGHT:320px">
																		<asp:datagrid id="grdGYZT" runat="server" CssClass="labelGrid" 
																			AllowPaging="False" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
																			PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
																			<SelectedItemStyle  Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
																			<EditItemStyle   BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
																			<AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle CssClass="FixedHead"  Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" ItemStyle-Width="30px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkGYZTZB" runat="server" AutoPostBack="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
																					<HeaderStyle Width="160px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="240px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
																					<HeaderStyle Width="240px"></HeaderStyle>
																				</asp:ButtonColumn>						                                                    
																				<asp:TemplateColumn HeaderText="计提比例" ItemStyle-Width="120px" HeaderStyle-ForeColor="white">
																					<HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:TextBox ID="txtZTJTBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtGYZTFixed" type="hidden" value="0" runat="server">
																	</DIV>																
																</td>
															</tr>
														</TABLE>
													</TD>												
												</TR>	
												<TR>
													<TD align="left" valign="middle">
														<asp:Button id="btnSelAll_GYZT"   Runat="server" Text="全部选定" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
														<asp:Button id="btnDeSelAll_GYZT" Runat="server" Text="全部不选" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
														<asp:Button id="btnAddNew_GYZT"   Runat="server" Text="加入职级" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
														<asp:Button id="btnDelete_GYZT"   Runat="server" Text="删除职级" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
														<asp:Button id="btnSave_GYZT"     Runat="server" Text="保    存" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>																	
													</TD>
												</TR>
												<TR>
													<TD align="left">
														<table cellpadding="0" cellspacing="0" border="0" width="100%">
															<tr>
																<td align="left" class="label" bgcolor="#ccff99">填写说明：</td>
															</tr>
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(1) 计提比例录入百分数的实际值，如35%，则录入0.35</td>
															</tr>
															<tr>
																<td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(2) 比例不设置请填0</td>
															</tr>
														</table>
													</TD>
												</TR>
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
						<input id="htxtFunctionId" type="hidden" runat="server" value="1">
						<input id="htxtSessionId_SY" type="hidden" runat="server">
                        <input id="htxtSessionId_GYZG" type="hidden" runat="server">
                        <input id="htxtSessionId_GYZGZB" type="hidden" runat="server">
                        <input id="htxtSessionId_GYXG" type="hidden" runat="server" >
                        <input id="htxtSessionId_GYXGZB" type="hidden" runat="server">
                        <input id="htxtSessionId_GYZT" type="hidden" runat="server" >
                        
                        <input id="htxtSYSort" type="hidden" runat="server">
						<input id="htxtSYSortColumnIndex" type="hidden" runat="server">
						<input id="htxtSYSortType" type="hidden" runat="server">
						
						<input id="htxtGYZGSort" type="hidden" runat="server">
						<input id="htxtGYZGColumnIndex" type="hidden" runat="server">
						<input id="htxtGYZGSortType" type="hidden" runat="server">
						<input id="htxtGYZGZBSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtGYZGZBSortType" type="hidden" runat="server" >
                        <input id="htxtGYZGZBSort" type="hidden" runat="server">
                        
                        <input id="htxtGYXGSort" type="hidden" runat="server">
						<input id="htxtGYXGColumnIndex" type="hidden" runat="server">
						<input id="htxtGYXGSortType" type="hidden" runat="server" >
						<input id="htxtGYXGZBSortColumnIndex" type="hidden" runat="server" >
                        <input id="htxtGYXGZBSortType" type="hidden" runat="server">
                        <input id="htxtGYXGZBSort" type="hidden" runat="server">
                        
                        <input id="htxtGYZTSort" type="hidden" runat="server">
						<input id="htxtGYZTColumnIndex" type="hidden" runat="server">
						<input id="htxtGYZTSortType" type="hidden" runat="server">
						
						<input id="htxtDivLeftBody" type="hidden" runat="server" >
						<input id="htxtDivTopBody" type="hidden" runat="server" >
						<input id="htxtDivLeftSY" type="hidden" runat="server" >
						<input id="htxtDivTopSY" type="hidden" runat="server" >	
						<input id="htxtDivLeftGYZG" type="hidden" runat="server">
						<input id="htxtDivTopGYZG" type="hidden" runat="server">
						<input id="htxtDivLeftGYZGZB" type="hidden" runat="server" >
						<input id="htxtDivTopGYZGZB" type="hidden" runat="server" >
						<input id="htxtDivLeftGYXG" type="hidden" runat="server">	
						<input id="htxtDivTopGYXG" type="hidden" runat="server" >	
						<input id="htxtDivLeftGYXGZB" type="hidden" runat="server">
						<input id="htxtDivTopGYXGZB" type="hidden" runat="server">
						<input id="htxtDivLeftGYZT" type="hidden" runat="server">
						<input id="htxtDivTopGYZT" type="hidden" runat="server">							
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
							function ScrollProc_divSYZB() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSY");
								if (oText != null) oText.value = divSYZB.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSY");
								if (oText != null) oText.value = divSYZB.scrollLeft;
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
							function ScrollProc_divGYZGZB() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGYZGZB");
								if (oText != null) oText.value = divGYZGZB.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZGZB");
								if (oText != null) oText.value = divGYZGZB.scrollLeft;
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
							function ScrollProc_divGYXGZB() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGYXGZB");
								if (oText != null) oText.value = divGYXGZB.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYXGZB");
								if (oText != null) oText.value = divGYXGZB.scrollLeft;
								return;
							}
							function ScrollProc_divGYZT() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGYZT");
								if (oText != null) oText.value = divGYZT.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZT");
								if (oText != null) oText.value = divGYZT.scrollLeft;
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
								if (oText != null) divSYZB.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSY");
								if (oText != null) divSYZB.scrollLeft = oText.value;
								
								oText=null;
								oText=document.getElementById("htxtDivTopGYZG");
								if (oText != null) divGYZG.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZG");
								if (oText != null) divGYZG.scrollLeft = oText.value;
								
								oText=null;
								oText=document.getElementById("htxtDivTopGYZGZB");
								if (oText != null) divGYZGZB.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZGZB");
								if (oText != null) divGYZGZB.scrollLeft = oText.value;
								
								oText=null;
								oText=document.getElementById("htxtDivTopGYXG");
								if (oText != null) divGYXG.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGXG");
								if (oText != null) divGYXG.scrollLeft = oText.value;
								
								oText=null;
								oText=document.getElementById("htxtDivTopGYXGZB");
								if (oText != null) divGYXGZB.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGXGZB");
								if (oText != null) divGYXGZB.scrollLeft = oText.value;
								
								oText=null;
								oText=document.getElementById("htxtDivTopGYZT");
								if (oText != null) divGYZT.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYZT");
								if (oText != null) divGYZT.scrollLeft = oText.value;
								
								document.body.onscroll = ScrollProc_Body;
								divSYZB.onscroll = ScrollProc_divSYZB;
								divGYZG.onscroll = ScrollProc_divGYZG;
								divGYZGZB.onscroll = ScrollProc_divGYZGZB;
								divGYXGZB.onscroll = ScrollProc_divGYXGZB;
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


