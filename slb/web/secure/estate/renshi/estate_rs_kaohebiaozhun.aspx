<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_kaohebiaozhun.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_kaohebiaozhun" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>人事考核标准(一)</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../../scripts/transkey.js"></script>
		<style>
			TD.grdXLLocked { ; LEFT: expression(divXL.scrollLeft); POSITION: relative }
			TH.grdXLLocked { ; LEFT: expression(divXL.scrollLeft); POSITION: relative }
			TH.grdXLLocked { Z-INDEX: 99 }
			TD.grdDWFH01Locked { ; LEFT: expression(divDWFH01.scrollLeft); POSITION: relative }
			TH.grdDWFH01Locked { ; LEFT: expression(divDWFH01.scrollLeft); POSITION: relative }
			TH.grdDWFH01Locked { Z-INDEX: 99 }
			TD.grdDWFH02Locked { ; LEFT: expression(divDWFH02.scrollLeft); POSITION: relative }
			TH.grdDWFH02Locked { ; LEFT: expression(divDWFH02.scrollLeft); POSITION: relative }
			TH.grdDWFH02Locked { Z-INDEX: 99 }
			TD.grdDWFH03Locked { ; LEFT: expression(divDWFH03.scrollLeft); POSITION: relative }
			TH.grdDWFH03Locked { ; LEFT: expression(divDWFH03.scrollLeft); POSITION: relative }
			TH.grdDWFH03Locked { Z-INDEX: 99 }
			TD.grdDWGLC01Locked { ; LEFT: expression(divDWGLC01.scrollLeft); POSITION: relative }
			TH.grdDWGLC01Locked { ; LEFT: expression(divDWGLC01.scrollLeft); POSITION: relative }
			TH.grdDWGLC01Locked { Z-INDEX: 99 }
			TD.grdDWGLC02Locked { ; LEFT: expression(divDWGLC02.scrollLeft); POSITION: relative }
			TH.grdDWGLC02Locked { ; LEFT: expression(divDWGLC02.scrollLeft); POSITION: relative }
			TH.grdDWGLC02Locked { Z-INDEX: 99 }
			TD.grdDWGLC03Locked { ; LEFT: expression(divDWGLC03.scrollLeft); POSITION: relative }
			TH.grdDWGLC03Locked { ; LEFT: expression(divDWGLC03.scrollLeft); POSITION: relative }
			TH.grdDWGLC03Locked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
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
				intWidth  -= 16;                          //滚动条
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 16;                          //滚动条
				intHeight -= 30;                          //trRow1.clientHeight;
				intHeight -= 36;                          //trRow2.clientHeight;
				strHeight  = intHeight.toString() + "px";
				
				document.all("divMain").style.width  = strWidth;
				document.all("divMain").style.height = strHeight;
				document.all("divMain").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../../images/bgmain.gif" onresize="javascript:window_onresize()">
		<form id="frmestate_rs_kaohebiaozhun" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="title" id="trRow1" style="BORDER-BOTTOM: #99cccc 2px solid" vAlign="middle" align="left" height="30">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;业绩考核标准(一)<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<DIV id="divMain" style="OVERFLOW: auto; WIDTH: 996px; CLIP: rect(0px 464px 996px 0px); HEIGHT: 464px">
								<TABLE cellSpacing="0" cellPadding="0" border="0">
									<TR>
										<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;指标序列一览表</TD>
									</TR>
									<TR>
										<TD align="center">
											<DIV id="divXL" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
												<asp:datagrid id="grdXL" runat="server" Width="950px" Font-Names="宋体" AllowSorting="False" BorderWidth="0px"
													BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4" BorderStyle="None"
													BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
													CssClass="label" Font-Size="11pt">
													<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
													<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
													<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
													<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
													<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
													<FooterStyle BackColor="#CCCC99"></FooterStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
															<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="chkXL" runat="server" AutoPostBack="False"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														
														<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
															<HeaderStyle Width="120px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
															<HeaderStyle Width="200px"></HeaderStyle>
														</asp:ButtonColumn>
														
														<asp:TemplateColumn HeaderText="序列一" ItemStyle-Width="200px">
															<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:TextBox ID="txtZBNR01" Runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="序列二" ItemStyle-Width="200px">
															<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:TextBox ID="txtZBNR02" Runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="序列三" ItemStyle-Width="200px">
															<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:TextBox ID="txtZBNR03" Runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													
													<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
												</asp:datagrid><INPUT id="htxtXLFixed" type="hidden" value="0" runat="server">
											</DIV>
										</TD>
									</TR>
									<TR>
										<TD height="4"></TD>
									</TR>
									<TR>
										<TD vAlign="middle" align="right">
											<asp:Button id="btnSelAll_XL" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全部选定"></asp:Button>
											<asp:Button id="btnDeSelAll_XL" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全部不选"></asp:Button>
											<asp:Button id="btnAddNew_XL" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="加入新的职级"></asp:Button>
											<asp:Button id="btnDelete_XL" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="删除选定职级"></asp:Button>
										</TD>
									</TR>
									<TR>
										<TD align="left">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="label" align="left" bgColor="#ccff99">填写说明：</TD>
												</TR>
												<TR>
													<TD class="label" align="left">&nbsp;&nbsp;&nbsp;&nbsp;(1) 资深物业顾问指标 = dbo.uf_estate_rs_getZhibiaoMethod01('020.010.010',x.适用单位) ('020.010.010'为资深物业顾问职级代码)</TD>
												</TR>
												<TR>
													<TD class="label" align="left">&nbsp;&nbsp;&nbsp;&nbsp;(2) 中级物业顾问指标 = dbo.uf_estate_rs_getZhibiaoMethod01('020.010.030',x.适用单位) ('020.010.030'为中级物业顾问职级代码)</TD>
												</TR>
												<TR>
													<TD class="label" align="left">&nbsp;&nbsp;&nbsp;&nbsp;(3) 管理团队平均人数 = @inner_pzrs</TD>
												</TR>
												<TR>
													<TD class="label" align="left">&nbsp;&nbsp;&nbsp;&nbsp;(4) 公式中可使用常数(如 0.8)、括弧()、加+、减-、乘*、除/</TD>
												</TR>
												<TR>
													<TD class="label" align="left">&nbsp;&nbsp;&nbsp;&nbsp;(5) 请确保公式录入正确！！！</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;执行分行一览表</TD>
									</TR>
									<TR>
										<TD align="center">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD width="320">&nbsp;</TD>
													<TD vAlign="top">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD vAlign="top">
																	<DIV id="divDWFH01" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
																		<asp:datagrid id="grdDWFH01" runat="server" Width="200px" Font-Names="宋体" AllowSorting="False"
																			BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4"
																			BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
																			CssClass="label" Font-Size="11pt">
																			<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																			<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																			<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																					<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkDWFH01" runat="server" AutoPostBack="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="适用单位" SortExpression="适用单位" HeaderText="适用单位" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="适用单位名称" SortExpression="适用单位名称" HeaderText="单位名称" CommandName="Select">
																					<HeaderStyle Width="170px"></HeaderStyle>
																				</asp:ButtonColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtDWFH01Fixed" type="hidden" value="0" runat="server">
																	</DIV>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
															<TR>
																<TD vAlign="middle" align="right">
																	<asp:Button id="btnSelAll_DWFH01" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全选"></asp:Button>
																	<asp:Button id="btnDeSelAll_DWFH01" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="不选"></asp:Button>
																	<asp:Button id="btnAddNew_DWFH01" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="加入"></asp:Button>
																	<asp:Button id="btnDelete_DWFH01" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="删除"></asp:Button>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
														</TABLE>
													</TD>
													<TD width="8">&nbsp;</TD>
													<TD vAlign="top">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD>
																	<DIV id="divDWFH02" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
																		<asp:datagrid id="grdDWFH02" runat="server" Width="200px" Font-Names="宋体" AllowSorting="False"
																			BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4"
																			BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
																			CssClass="label" Font-Size="11pt">
																			<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																			<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																			<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																					<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkDWFH02" runat="server" AutoPostBack="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="适用单位" SortExpression="适用单位" HeaderText="适用单位" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="适用单位名称" SortExpression="适用单位名称" HeaderText="单位名称" CommandName="Select">
																					<HeaderStyle Width="170px"></HeaderStyle>
																				</asp:ButtonColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtDWFH02Fixed" type="hidden" value="0" runat="server">
																	</DIV>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
															<TR>
																<TD vAlign="middle" align="right">
																	<asp:Button id="btnSelAll_DWFH02" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全选"></asp:Button>
																	<asp:Button id="btnDeSelAll_DWFH02" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="不选"></asp:Button>
																	<asp:Button id="btnAddNew_DWFH02" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="加入"></asp:Button>
																	<asp:Button id="btnDelete_DWFH02" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="删除"></asp:Button>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
														</TABLE>
													</TD>
													<TD width="8">&nbsp;</TD>
													<TD vAlign="top">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD>
																	<DIV id="divDWFH03" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
																		<asp:datagrid id="grdDWFH03" runat="server" Width="200px" Font-Names="宋体" AllowSorting="False"
																			BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4"
																			BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
																			CssClass="label" Font-Size="11pt">
																			<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																			<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																			<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																					<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkDWFH03" runat="server" AutoPostBack="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="适用单位" SortExpression="适用单位" HeaderText="适用单位" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="适用单位名称" SortExpression="适用单位名称" HeaderText="单位名称" CommandName="Select">
																					<HeaderStyle Width="170px"></HeaderStyle>
																				</asp:ButtonColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtDWFH03Fixed" type="hidden" value="0" runat="server">
																	</DIV>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
															<TR>
																<TD vAlign="middle" align="right">
																	<asp:Button id="btnSelAll_DWFH03" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全选"></asp:Button>
																	<asp:Button id="btnDeSelAll_DWFH03" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="不选"></asp:Button>
																	<asp:Button id="btnAddNew_DWFH03" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="加入"></asp:Button>
																	<asp:Button id="btnDelete_DWFH03" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="删除"></asp:Button>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD height="4"></TD>
									</TR>
									<TR>
										<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;执行管理处一览表</TD>
									</TR>
									<TR>
										<TD align="center">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD width="320">&nbsp;</TD>
													<TD vAlign="top">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD vAlign="top">
																	<DIV id="divDWGLC01" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
																		<asp:datagrid id="grdDWGLC01" runat="server" Width="200px" Font-Names="宋体" AllowSorting="False"
																			BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4"
																			BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
																			CssClass="label" Font-Size="11pt">
																			<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																			<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																			<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																					<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkDWGLC01" runat="server" AutoPostBack="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="适用单位" SortExpression="适用单位" HeaderText="适用单位" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="适用单位名称" SortExpression="适用单位名称" HeaderText="单位名称" CommandName="Select">
																					<HeaderStyle Width="170px"></HeaderStyle>
																				</asp:ButtonColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtDWGLC01Fixed" type="hidden" value="0" runat="server">
																	</DIV>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
															<TR>
																<TD vAlign="middle" align="right">
																	<asp:Button id="btnSelAll_DWGLC01" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全选"></asp:Button>
																	<asp:Button id="btnDeSelAll_DWGLC01" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="不选"></asp:Button>
																	<asp:Button id="btnAddNew_DWGLC01" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="加入"></asp:Button>
																	<asp:Button id="btnDelete_DWGLC01" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="删除"></asp:Button>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
														</TABLE>
													</TD>
													<TD width="8">&nbsp;</TD>
													<TD vAlign="top">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD>
																	<DIV id="divDWGLC02" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
																		<asp:datagrid id="grdDWGLC02" runat="server" Width="200px" Font-Names="宋体" AllowSorting="False"
																			BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4"
																			BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
																			CssClass="label" Font-Size="11pt">
																			<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																			<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																			<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																					<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkDWGLC02" runat="server" AutoPostBack="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="适用单位" SortExpression="适用单位" HeaderText="适用单位" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="适用单位名称" SortExpression="适用单位名称" HeaderText="单位名称" CommandName="Select">
																					<HeaderStyle Width="170px"></HeaderStyle>
																				</asp:ButtonColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtDWGLC02Fixed" type="hidden" value="0" runat="server">
																	</DIV>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
															<TR>
																<TD vAlign="middle" align="right">
																	<asp:Button id="btnSelAll_DWGLC02" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全选"></asp:Button>
																	<asp:Button id="btnDeSelAll_DWGLC02" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="不选"></asp:Button>
																	<asp:Button id="btnAddNew_DWGLC02" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="加入"></asp:Button>
																	<asp:Button id="btnDelete_DWGLC02" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="删除"></asp:Button>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
														</TABLE>
													</TD>
													<TD width="8">&nbsp;</TD>
													<TD vAlign="top">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD>
																	<DIV id="divDWGLC03" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
																		<asp:datagrid id="grdDWGLC03" runat="server" Width="200px" Font-Names="宋体" AllowSorting="False"
																			BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4"
																			BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
																			CssClass="label" Font-Size="11pt">
																			<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																			<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																			<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																			<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																			<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																			<FooterStyle BackColor="#CCCC99"></FooterStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																					<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																					<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkDWGLC03" runat="server" AutoPostBack="False"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="适用单位" SortExpression="适用单位" HeaderText="适用单位" CommandName="Select">
																					<HeaderStyle Width="0px"></HeaderStyle>
																				</asp:ButtonColumn>
																				<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="适用单位名称" SortExpression="适用单位名称" HeaderText="单位名称" CommandName="Select">
																					<HeaderStyle Width="170px"></HeaderStyle>
																				</asp:ButtonColumn>
																			</Columns>
																			<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																		</asp:datagrid><INPUT id="htxtDWGLC03Fixed" type="hidden" value="0" runat="server">
																	</DIV>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
															<TR>
																<TD vAlign="middle" align="right">
																	<asp:Button id="btnSelAll_DWGLC03" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全选"></asp:Button>
																	<asp:Button id="btnDeSelAll_DWGLC03" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="不选"></asp:Button>
																	<asp:Button id="btnAddNew_DWGLC03" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="加入"></asp:Button>
																	<asp:Button id="btnDelete_DWGLC03" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="删除"></asp:Button>
																</TD>
															</TR>
															<TR>
																<TD height="4"></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD align="left">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="label" align="left" bgColor="#ccff99">填写说明：</TD>
												</TR>
												<TR>
													<TD class="label" align="left">&nbsp;&nbsp;&nbsp;&nbsp;(1) 一个单位只能指定在分行或管理处列表中的其中一个</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
					</TR>
					<TR id="trRow2">
						<TD style="BORDER-TOP: #99cccc 2px solid" vAlign="middle" align="center" height="36">
							<asp:Button id="btnOK" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text=" 保  存 "></asp:Button>
							<asp:Button id="btnCancel" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text=" 取  消 "></asp:Button>
							<asp:Button id="btnClose" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text=" 返  回 "></asp:Button>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button id="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></P></TD>
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
						<input id="htxtSessionId_XL" type="hidden" runat="server">
						<input id="htxtSessionId_DWFH01" type="hidden" runat="server">
						<input id="htxtSessionId_DWFH02" type="hidden" runat="server">
						<input id="htxtSessionId_DWFH03" type="hidden" runat="server">
						<input id="htxtSessionId_DWGLC01" type="hidden" runat="server">
						<input id="htxtSessionId_DWGLC02" type="hidden" runat="server">
						<input id="htxtSessionId_DWGLC03" type="hidden" runat="server">
						<input id="htxtDivLeftMain" type="hidden" runat="server">
						<input id="htxtDivTopMain" type="hidden" runat="server">
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

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
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
