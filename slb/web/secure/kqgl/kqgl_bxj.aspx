<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="kqgl_bxj.aspx.vb" Inherits="Josco.JSOA.web.kqgl_bxj" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>补休假查询</title>            
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="../../styles01.css" type="text/css" rel="stylesheet" />
		<link href="../../mnuStyle01.css" type="text/css" rel="stylesheet" />
		<style>
			TD.grdRSLYGLLocked { ; LEFT: expression(divRSLYGL.scrollLeft); POSITION: relative }
			TH.grdRSLYGLLocked { ; LEFT: expression(divRSLYGL.scrollLeft); POSITION: relative }
			TH.grdRSLYGLLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script language="javascript" src="../../scripts/Calendar.js" type="text/javascript"></script>
		<script language="javascript">  
		<!--
			
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divRSLYGL") == null)
					return;

				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 564;                          //滚动条
				intWidth  -= 2 * 4;                       //左、右空白
				intWidth  -= 16;                          //调整数
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 24;                          //调整数
				intHeight -= trRow0.clientHeight;
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				strHeight  = intHeight.toString() + "px";

				document.all("divRSLYGL").style.width  = strWidth;
				document.all("divRSLYGL").style.height = strHeight;
				document.all("divRSLYGL").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
				return window_onresize();
			}
		//-->
		</script>
		<script language="javascript" event="onreadystatechange" for="document">
		<!--
			return document_onreadystatechange()
		//-->
		</script>
	</HEAD>
	<body onresize="return window_onresize()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/oabk.gif">
		<form id="frmestate_rs_luyong_main" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="4">
                        <TD id="trRow0" height="30" class="title" vAlign="middle" align="left">当前位置：考勤管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;补休假管理</TD>
                        <TD width="4">
                    </TR>	
					<TR>
						<TD width="4"><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMenu" Runat="server" Width="0px"></asp:LinkButton><INPUT id="htxtSelectMenuID" type="hidden" size="1" runat="server"><INPUT id="htxtMenuParam00" type="hidden" size="1" runat="server"></TD>
						<TD style=" BORDER-TOP: #99cccc 1px solid;" vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD colSpan="3" height="4"></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top" align="left" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
											<iewc:treeview id="tvwBMLIST" runat="server" CssClass="label" Width="200px" Height="520px" Font-Size="12px" Font-Name="宋体" AutoPostBack="true"></iewc:treeview></TD>
									<TD width="3"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR id="trRow3">
														    <td align="left">月份：</td>
								                      	    <td align="left" >
								                      	        <asp:DropDownList ID="ddlNF" Runat="server" CssClass="textbox" > 
													            </asp:DropDownList>
								                      	        <asp:DropDownList ID="ddlYF" Runat="server" CssClass="textbox" >	
														            <asp:ListItem Value="1">一月</asp:ListItem>
														            <asp:ListItem Value="2">二月</asp:ListItem>
														            <asp:ListItem Value="3">三月</asp:ListItem>
														            <asp:ListItem Value="4">四月</asp:ListItem>
														            <asp:ListItem Value="5">五月</asp:ListItem>
														            <asp:ListItem Value="6">六月</asp:ListItem>
														            <asp:ListItem Value="7">七月</asp:ListItem>
														            <asp:ListItem Value="8">八月</asp:ListItem>
														            <asp:ListItem Value="9">九月</asp:ListItem>
														            <asp:ListItem Value="10">十月</asp:ListItem>
														            <asp:ListItem Value="11">十一月</asp:ListItem>
														            <asp:ListItem Value="12">十二月</asp:ListItem>
													            </asp:DropDownList>
													            <asp:textbox id="txtBM" runat="server" CssClass="textbox" Font-Size="12px" Columns="48" Font-Names="宋体" OnTextChanged="txtBM_TextChanged"></asp:textbox><input id="htxtBM" type="hidden" size="1" runat="server" name="htxtBM" />
															    <asp:Button id="btnFPBM" Runat="server" CssClass="button" Text="…"></asp:Button>
													             <asp:button id="btnSet" Runat="server" CssClass="button"  Text="生成补休"></asp:button>
								                      	     </td>			
															<td class="label" align="left"><div style="display:none">
															<asp:Button id="btnAllBM" Runat="server" CssClass="button" Text="全部"></asp:Button></div></td>
															<td align="right"><asp:Button id="btnClose" Runat="server" CssClass="button"  Text=" 返回 " ></asp:Button></td> 
														</TR> 														
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divKQJLGL" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 720px; CLIP: rect(0px 720px 480px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 480px">
														 <asp:datagrid id="grdKQJLG" runat="server" Width="720px" CssClass="labelGrid" 
                                                                AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                                PageSize="250" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
									                             <SelectedItemStyle  Font-Bold="False" VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="blue" ></SelectedItemStyle>
                                                                <EditItemStyle   BackColor="#FFCC00" VerticalAlign="Middle" HorizontalAlign="Center" ></EditItemStyle>
                                                                <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle  BorderWidth="1px" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle   Font-Bold="True" HorizontalAlign="Center"  ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" ></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center"></FooterStyle>
                                                                                        
															<Columns>
																<asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="组织名称" SortExpression="组织名称" HeaderText="部门名称" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="80px" DataTextField="人员名称" SortExpression="人员名称" HeaderText="姓名" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="yi" SortExpression="yi"  CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="yi1" SortExpression="yi1"  HeaderStyle-BackColor="Red"  CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="yi2" SortExpression="yi2" HeaderStyle-BackColor="Red"   CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="er" SortExpression="er" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="er1" SortExpression="er1"  HeaderStyle-BackColor="Red"  CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="er2" SortExpression="er2"  HeaderStyle-BackColor="Red"  CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="san" SortExpression="san" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>	
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="san1" SortExpression="san1"  HeaderStyle-BackColor="Red"  CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>	
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="san2" SortExpression="san2"   HeaderStyle-BackColor="Red"  CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>														
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="组织代码" SortExpression="组织代码" HeaderText="组织代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>															
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><input id="htxtRSLYGLFixed" type="hidden" size="1" value="0" runat="server" />
													</DIV>
												</TD>
											</TR>	
											<TR>
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR id="trRow2">
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLDeSelectAll" runat="server" Font-Name="宋体" Font-Size="12px">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLSelectAll" runat="server" Font-Name="宋体" Font-Size="12px">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMoveFirst" runat="server" Font-Name="宋体" Font-Size="12px">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMovePrev" runat="server" Font-Name="宋体" Font-Size="12px">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMoveNext" runat="server" Font-Name="宋体" Font-Size="12px">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMoveLast" runat="server" Font-Name="宋体" Font-Size="12px">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLGotoPage" runat="server" Font-Name="宋体" Font-Size="12px">前往</asp:linkbutton><asp:textbox id="txtRSLYGLPageIndex" runat="server" CssClass="textbox" Font-Name="宋体" Font-Size="12px" Columns="3">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLSetPageSize" runat="server" Font-Name="宋体" Font-Size="12px">每页</asp:linkbutton><asp:textbox id="txtRSLYGLPageSize" runat="server" CssClass="textbox" Font-Name="宋体" Font-Size="12px" Columns="3">250</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblRSLYGLGridLocInfo" runat="server" CssClass="label" Font-Name="宋体" Font-Size="12px">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>																														
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD colspan="3" height="4"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="4"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:panel id="panelError" Runat="server">
				<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE id="tabErrInfo" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></P></TD>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5%"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<table cellSpacing="0" cellPadding="0" align="center" border="0">
				<tr>
					<td>
						<input id="htxtSessionIdQuery" type="hidden" runat="server">
						<input id="htxtRSLYGLQuery" type="hidden" runat="server">
						<input id="htxtRSLYGLRows" type="hidden" runat="server">
						<input id="htxtRSLYGLSort" type="hidden" runat="server">
						<input id="htxtRSLYGLSortColumnIndex" type="hidden" runat="server">
						<input id="htxtRSLYGLSortType" type="hidden" runat="server">
						<input id="htxtDivLeftRSLYGL" type="hidden" runat="server">
						<input id="htxtDivTopRSLYGL" type="hidden" runat="server">
						<input id="htxtDivLeftBody" type="hidden" runat="server">
						<input id="htxtDivTopBody" type="hidden" runat="server">
						<input id="htxtYear" type="hidden" runat="server">
						<input id="htxtMonth" type="hidden" runat="server">
						<input id="htxtMonthMin" type="hidden" runat="server">
						<input id="htxtMonthMax" type="hidden" runat="server">
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
							function ScrollProc_divRSLYGL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRSLYGL");
								if (oText != null) oText.value = divRSLYGL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRSLYGL");
								if (oText != null) oText.value = divRSLYGL.scrollLeft;
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
								oText=document.getElementById("htxtDivTopRSLYGL");
								if (oText != null) divRSLYGL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRSLYGL");
								if (oText != null) divRSLYGL.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divRSLYGL.onscroll = ScrollProc_divRSLYGL;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" Visible="False" width="96px" height="48px"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

