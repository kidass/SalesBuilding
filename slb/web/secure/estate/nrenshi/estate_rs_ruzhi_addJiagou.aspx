<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_ruzhi_addJiagou.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_ruzhi_addJiagou" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>新进人员报到登记</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdPIAOJULocked { ; LEFT: expression(divRYXX.scrollLeft); POSITION: relative }
		    TH.grdPIAOJULocked { ; LEFT: expression(divRYXX.scrollLeft); POSITION: relative }
		    TH.grdPIAOJULocked { Z-INDEX: 99 }
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
				
				if (document.all("divPIAOJU") == null)
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
				strHeight  = intHeight.toString() + "px";
                //alert(strWidth + " " + strHeight);
                
				divPIAOJU.style.width  = strWidth;
				divPIAOJU.style.height = strHeight;
				divPIAOJU.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body background="../../images/oabk.gif" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmestate_cw_piaoju_fafang" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow01">
									<TD class="title" align="center" colSpan="3" height="30">新进人员报到登记<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<tr>
								    <td height="4"></td>
								</tr>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow02">
												<TD class="label" align="left" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;拟稿日期&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtSearch_NGRQMin" runat="server" Font-Size="12px" CssClass="textbox" Columns="9" Font-Names="宋体"></asp:textbox>~<asp:textbox id="txtSearch_NGRQMax" runat="server" Font-Size="12px" CssClass="textbox" Columns="9" Font-Names="宋体"></asp:textbox></TD>
															
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;审批状态&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlPIAOJUSearch_HXBZ" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="0">未审批</asp:ListItem>
																	<asp:ListItem Value="1">已审批</asp:ListItem>
																</asp:DropDownList>
															</TD>
														</Tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divRYXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 391px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 391px">
														 <asp:datagrid id="grdRYXX" runat="server" Width="2240px" CssClass="labelGrid" 
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                            PageSize="250" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
			                                                 <SelectedItemStyle  Font-Bold="False" VerticalAlign="Middle" HorizontalAlign=Center ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle   BackColor="#FFCC00" VerticalAlign="Middle" HorizontalAlign=Center ></EditItemStyle>
                                                            <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle  BorderWidth="1px" HorizontalAlign=Center BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle   Font-Bold="True" HorizontalAlign=Center  ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" ></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99" HorizontalAlign=Center></FooterStyle>
                                                            
                                                            <Columns>
				                                                <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
					                                                <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
					                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
					                                                <ItemTemplate>
						                                                <asp:CheckBox id="chkRYXX" runat="server" AutoPostBack="False" Width="20px"></asp:CheckBox>
					                                                </ItemTemplate>
				                                                </asp:TemplateColumn>                                                                                            
                                                                <asp:ButtonColumn Text="×"  HeaderStyle-ForeColor="white" ButtonType="PushButton" CommandName="FalseOneRow" HeaderText="单" ItemStyle-Width="1"  FooterStyle-BorderWidth="1" FooterStyle-Width="1" HeaderStyle-BorderWidth="1" ></asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                                           
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员姓名" SortExpression="人员姓名" HeaderText="姓名" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="联系电话" SortExpression="联系电话" HeaderText="联系电话" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>  
                                                                 <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="身份证号码" SortExpression="身份证号码" HeaderText="身份证号码" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                                           
                                                                <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="人员性别" SortExpression="人员性别" HeaderText="性别" CommandName="Select">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="人员年龄" SortExpression="人员年龄" HeaderText="年龄" CommandName="Select">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员学历" SortExpression="人员学历" HeaderText="学历" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>        
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员类型名称" SortExpression="人员类型名称" HeaderText="入职类型" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                                    
                                                                <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="拟分配部门" SortExpression="拟分配部门" HeaderText="拟分配部门" CommandName="Select">
                                                                    <HeaderStyle Width="140px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                 <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="部门经理" SortExpression="部门经理" HeaderText="所属团队经理" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="拟担任职位" SortExpression="拟担任职位" HeaderText="拟担任职位" CommandName="Select">
                                                                    <HeaderStyle Width="160px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="团队编号" SortExpression="团队编号" HeaderText="团队编号" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="招聘说明" SortExpression="招聘说明" HeaderText="招聘说明" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="招聘渠道" SortExpression="招聘渠道" HeaderText="招聘渠道" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                 <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="网络技能" SortExpression="网络技能" HeaderText="网络技能分数" CommandName="Select">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                                            
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="现有人员" SortExpression="现有人员" HeaderText="现有人员" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="定编人数" SortExpression="定编人数" HeaderText="定编人数" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>                                                                                                
                                                                </asp:ButtonColumn>  
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="审批说明" SortExpression="审批说明" HeaderText="审批说明" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                 <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="审批日期" SortExpression="审批日期" HeaderText="审批日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                 <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="审批结果" SortExpression="审批结果" HeaderText="审批结果" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="审批人" SortExpression="审批人" HeaderText="审批人" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="拟报到日期" SortExpression="拟报到日期" HeaderText="报到日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>  
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员序号" SortExpression="人员序号" HeaderText="序号" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员类型" SortExpression="人员类型" HeaderText="入职类型" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原因代码" SortExpression="原因代码" HeaderText="原因代码" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原因名称" SortExpression="原因名称" HeaderText="原因名称" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="单位代码" SortExpression="单位代码" HeaderText="单位代码" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="标准序列" SortExpression="标准序列" HeaderText="标准序列" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="是否兼职" SortExpression="是否兼职" HeaderText="是否兼职" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="是否占编" SortExpression="是否占编" HeaderText="是否占编" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员状态" SortExpression="人员状态" HeaderText="人员状态" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                                                                                                                                  
                                                            </Columns>
                                                            
                                                            <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                        </asp:datagrid><INPUT id="htxtRYXXFixed" type="hidden" value="0" runat="server">
                                                    </DIV>
												</TD>
											</TR>
											<TR id="trRow03">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUDeSelectAll" runat="server" Font-Size="12px" Font-Name="宋体">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUSelectAll" runat="server" Font-Size="12px" Font-Name="宋体">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUMoveFirst" runat="server" Font-Size="12px" Font-Name="宋体">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUMovePrev" runat="server" Font-Size="12px" Font-Name="宋体">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUMoveNext" runat="server" Font-Size="12px" Font-Name="宋体">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUMoveLast" runat="server" Font-Size="12px" Font-Name="宋体">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUGotoPage" runat="server" Font-Size="12px" Font-Name="宋体">前往</asp:linkbutton><asp:textbox id="txtPIAOJUPageIndex" runat="server" Font-Size="12px" Font-Name="宋体" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUSetPageSize" runat="server" Font-Size="12px" Font-Name="宋体">每页</asp:linkbutton><asp:textbox id="txtPIAOJUPageSize" runat="server" Font-Size="12px" Font-Name="宋体" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblPIAOJUGridLocInfo" runat="server" Font-Size="12px" Font-Name="宋体" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<tr id="trRow04">
											    <td style="BORDER-RIGHT: #66cccc 1px solid; BORDER-TOP: #66cccc 1px solid; BORDER-LEFT: #66cccc 1px solid; BORDER-BOTTOM: #66cccc 1px solid">
											        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											            <tr>
											                <td colspan="10" align="left" bgcolor="#ccff99" height="20" valign="middle">票据发放时需指定以下信息：</td>
											            </tr>
											            <tr>
											                <TD class="labelNotNull" vAlign="middle" align="right">发给分行：</td>
											                <TD class="label" vAlign="middle" align="left"><asp:TextBox ID="txtFGFH" Runat="server" CssClass="textbox" Columns="24"></asp:TextBox><asp:Button id="btnSelect_ZZDM" Runat="server" CssClass="button" Text="…"></asp:Button><input type="hidden" id="htxtFGFH" runat="server" size="1"></td>
											                <!-- zengxianglin 2008-11-18-->
											                <TD class="labelNotNull" vAlign="middle" align="right">批次：</td>
											                <TD class="label" vAlign="middle" align="left"><asp:TextBox ID="txtFFPC" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox><asp:Button ID="btnJSPC" Runat="server" CssClass="button" Text="计算"></asp:Button></td>
											                <!-- zengxianglin 2008-11-18-->
											                <TD class="label" vAlign="middle" align="right">号码前导符：</td>
											                <TD class="label" vAlign="middle" align="left"><asp:TextBox ID="txtPJQZ" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox></td>
											                <TD class="labelNotNull" vAlign="middle" align="right">发放区间：</td>
											                <TD class="label" vAlign="middle" align="left"><asp:TextBox ID="txtKSHM" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox>~<asp:TextBox ID="txtZZHM" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox></td>
											                <TD class="label" vAlign="middle" align="right">票据类型：</td>
											                <TD class="label" vAlign="middle" align="left">
																<asp:DropDownList ID="ddlPJLX" Runat="server" CssClass="textbox">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="收据">收据</asp:ListItem>
																	<asp:ListItem Value="发票">发票</asp:ListItem>
																</asp:DropDownList>
															</td>
											            </tr>
											        </table>
											    </td>
											</tr>
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
					<TR id="trRow05">
						<TD align="center" colSpan="3">
						    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						        <tr>
						            <td height="4"></td>
						        </tr>
						        <tr>
						            <td align="center">
							            <asp:Button id="btnFafang"  Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 发放 " Height="36px"></asp:Button>
							            <asp:Button id="btnShouhui" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 收回 " Height="36px"></asp:Button>
							            <asp:Button id="btnDelete"  Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 删除 " Height="36px"></asp:Button>
							            <asp:Button id="btnHexiao"  Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 核销 " Height="36px"></asp:Button>
							            <asp:Button id="btnClose"   Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 返回 " Height="36px"></asp:Button>
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
						<input id="htxtPIAOJUQuery" type="hidden" runat="server">
						<input id="htxtPIAOJURows" type="hidden" runat="server">
						<input id="htxtPIAOJUSort" type="hidden" runat="server">
						<input id="htxtPIAOJUSortColumnIndex" type="hidden" runat="server">
						<input id="htxtPIAOJUSortType" type="hidden" runat="server">
						<input id="htxtDivLeftPIAOJU" type="hidden" runat="server">
						<input id="htxtDivTopPIAOJU" type="hidden" runat="server">
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
							function ScrollProc_divPIAOJU() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopPIAOJU");
								if (oText != null) oText.value = divPIAOJU.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftPIAOJU");
								if (oText != null) oText.value = divPIAOJU.scrollLeft;
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
								oText=document.getElementById("htxtDivTopPIAOJU");
								if (oText != null) divPIAOJU.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftPIAOJU");
								if (oText != null) divPIAOJU.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divPIAOJU.onscroll = ScrollProc_divPIAOJU;
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

