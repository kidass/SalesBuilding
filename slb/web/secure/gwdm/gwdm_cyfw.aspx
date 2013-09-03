<%@ Page Language="vb" AutoEventWireup="false" Codebehind="gwdm_cyfw.aspx.vb" Inherits="Josco.JsKernal.web.gwdm_cyfw" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>常用范围编辑窗</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdFWLISTLocked { ; LEFT: expression(divFWLIST.scrollLeft); POSITION: relative }
			TH.grdFWLISTLocked { ; LEFT: expression(divFWLIST.scrollLeft); POSITION: relative }
			TH.grdFWLISTLocked { Z-INDEX: 99 }
			TD.grdFWCYLocked { ; LEFT: expression(divFWCY.scrollLeft); POSITION: relative }
			TH.grdFWCYLocked { ; LEFT: expression(divFWCY.scrollLeft); POSITION: relative }
			TH.grdFWCYLocked { Z-INDEX: 99 }
			TD.grdBMRYLocked { ; LEFT: expression(divBMRY.scrollLeft); POSITION: relative }
			TH.grdBMRYLocked { ; LEFT: expression(divBMRY.scrollLeft); POSITION: relative }
			TH.grdBMRYLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				var dblDeltaY = 40;
				var dblDeltaX = 30;
				
				if (document.all("divFWCY") == null)
					return;
				
				dblWidth  = 550 + dblDeltaX + document.body.clientWidth  - 850; //default state : 550px
				strWidth  = parseInt(dblWidth.toString(), 10).toString() + "px";
				strHeight = divFWCY.style.height;
				divFWCY.style.width  = strWidth;
				divFWCY.style.height = strHeight;
				divFWCY.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				dblWidth  = 550 + dblDeltaX + document.body.clientWidth  - 850; //default state : 550px
				strWidth  = parseInt(dblWidth.toString(), 10).toString() + "px";
				strHeight = divBMRY.style.height;
				divBMRY.style.width  = strWidth;
				divBMRY.style.height = strHeight;
				divBMRY.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
				window_onresize();
			}
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
		<!--
			return document_onreadystatechange()
		//-->
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()" background="../../images/bgmain.gif">
		<form id="frmGWDM_CYFW" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD colSpan="3" height="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD align="center" style="BORDER-BOTTOM: #99cccc 2px solid">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left" height="24">
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLFWAddNew" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/new.gif" border="0" width="16" height="16">定义范围</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLFWUpdate" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/modify.ico" border="0" width="16" height="16">范围改名</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLFWDelete" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/delete.gif" border="0" width="16" height="16">删除范围</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLRYAddNew" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/movein.ico" border="0" width="16" height="16">加入人员</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLCYDelete" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/moveout.ico" border="0" width="16" height="16">移出成员</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLCYUpdate" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/modify.ico" border="0" width="16" height="16">更改成员</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLCYMoveUp" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/arwup.ico" border="0" width="16" height="16">成员上移</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLCYMoveDn" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/arwdn.ico" border="0" width="16" height="16">成员下移</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLClose" runat="server" Font-Size="11pt" Font-Name="宋体"><img src="../../images/CLOSE.GIF" alt="返回上级" border="0" width="16" height="16">返回上级</asp:linkbutton></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="5" height="30">&nbsp;&nbsp;单击网格列头可进行排序，单击1次为升序排列，再单击1次为降序排列，再单击1次恢复到原始排序。<asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top" align="left">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR align="center">
															<TD class="label" vAlign="middle" align="left" width="40"><asp:linkbutton id="lnkCZFWLISTDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left" width="40"><asp:linkbutton id="lnkCZFWLISTSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="right" width="160"><asp:label id="lblFWLISTGridLocInfo" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="label">N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divFWLIST" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 240px; CLIP: rect(0px 240px 500px 0px); HEIGHT: 500px">
														<asp:datagrid id="grdFWLIST" runat="server" Font-Size="11pt" CssClass="label" Font-Names="宋体"
															AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30"
															BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" UseAccessibleHeader="True" CellPadding="4">
															<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选">
																	<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkFWLIST" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="范围名称" SortExpression="范围名称" HeaderText="范围名称" CommandName="Select">
																	<HeaderStyle Width="190px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="流水号" SortExpression="流水号" HeaderText="流水号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="范围标志" SortExpression="范围标志" HeaderText="范围标志" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="成员类型" SortExpression="成员类型" HeaderText="成员类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="成员名称" SortExpression="成员名称" HeaderText="成员名称" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="成员位置" SortExpression="成员位置" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="联系电话" SortExpression="联系电话" HeaderText="联系电话" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="手机号码" SortExpression="手机号码" HeaderText="移动电话" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="FTP地址" SortExpression="FTP地址" HeaderText="内部邮箱" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="邮箱地址" SortExpression="邮箱地址" HeaderText="因特网邮箱" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtFWLISTFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWCYDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWCYSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWCYMoveFirst" runat="server" Font-Name="宋体" Font-Size="11pt">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWCYMovePrev" runat="server" Font-Name="宋体" Font-Size="11pt">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWCYMoveNext" runat="server" Font-Name="宋体" Font-Size="11pt">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWCYMoveLast" runat="server" Font-Name="宋体" Font-Size="11pt">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWCYGotoPage" runat="server" Font-Name="宋体" Font-Size="11pt">前往</asp:linkbutton><asp:textbox id="txtFWCYPageIndex" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWCYSetPageSize" runat="server" Font-Name="宋体" Font-Size="11pt">每页</asp:linkbutton><asp:textbox id="txtFWCYPageSize" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" align="right" width="200"><asp:label id="lblFWCYGridLocInfo" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right" width="40">名称</TD>
															<TD class="label" align="left"><asp:textbox id="txtFWCYSearch_CYMC" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体" Columns="5"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right" width="40">序号</TD>
															<TD class="label" align="left" width="100"><asp:textbox id="txtFWCYSearch_CYWZMin" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体" Columns="2"></asp:textbox><asp:textbox id="txtFWCYSearch_CYWZMax" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体" Columns="2"></asp:textbox></TD>
															<TD class="label" vAlign="middle" width="40">类型</TD>
															<TD class="label" vAlign="top" align="left" width="150">
																<asp:RadioButtonList id="rblFWCYSearch_CYLX" Runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体"
																	RepeatColumns="3" RepeatLayout="Flow" RepeatDirection="Horizontal">
																	<asp:ListItem Value="无" Selected="True">无</asp:ListItem>
																	<asp:ListItem Value="单位">单位</asp:ListItem>
																	<asp:ListItem Value="个人">个人</asp:ListItem>
																</asp:RadioButtonList></TD>
															<TD class="label" vAlign="middle" align="right" width="40">电话</TD>
															<TD class="label" align="left"><asp:textbox id="txtFWCYSearch_LXDH" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体" Columns="4"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnFWCYSearch" Runat="server" Font-Name="宋体" Font-Size="11pt" Width="60px" CssClass="button" Text="搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divFWCY" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 550px; CLIP: rect(0px 550px 284px 0px); HEIGHT: 284px">
														<asp:datagrid id="grdFWCY" runat="server" Font-Size="11pt" Width="1110px" CssClass="label" Font-Names="宋体"
															AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30"
															BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" UseAccessibleHeader="True" CellPadding="4"
															AllowPaging="True">
															<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选">
																	<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkFWCY" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="成员位置" SortExpression="成员位置" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="成员名称" SortExpression="成员名称" HeaderText="名称" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="成员类型" SortExpression="成员类型" HeaderText="类型" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="联系电话" SortExpression="联系电话" HeaderText="联系电话" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="手机号码" SortExpression="手机号码" HeaderText="移动电话" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="FTP地址" SortExpression="FTP地址" HeaderText="内部邮箱" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="邮箱地址" SortExpression="邮箱地址" HeaderText="因特网邮箱" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="流水号" SortExpression="流水号" HeaderText="流水号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="范围名称" SortExpression="范围名称" HeaderText="范围名称" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="范围标志" SortExpression="范围标志" HeaderText="范围标志" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtFWCYFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
											<TR>
												<TD class="label" style="" align="center">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" align="center" height="2"></TD>
														</TR>
														<TR>
															<TD class="label" align="center" height="20"><B>成员信息编辑窗</B></TD>
														</TR>
														<TR>
															<TD class="label" align="center">
																<TABLE cellSpacing="0" cellPadding="0" border="0">
																	<TR>
																		<TD class="label" align="center" colSpan="2" height="2"></TD>
																	</TR>
																	<TR>
																		<TD class="labelNotNull" align="right" width="40%">成员序号：</TD>
																		<TD class="label" align="left" width="60%"><asp:textbox id="txtFWCY_CYXH" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="8"></asp:textbox><SPAN class="label" style="COLOR: red">*</SPAN></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="center" colSpan="2" height="2"></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="right">联系电话：</TD>
																		<TD class="label" align="left"><asp:textbox id="txtFWCY_LXDH" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="24"></asp:textbox></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="center" colSpan="2" height="2"></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="right">手机号码：</TD>
																		<TD class="label" align="left"><asp:textbox id="txtFWCY_SJHM" Runat="server" Font-Name="宋体" Font-Size="11pt" Height="24px" CssClass="textbox" Columns="24"></asp:textbox></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="center" colSpan="2" height="2"></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="right">内部邮箱：</TD>
																		<TD class="label" align="left"><asp:textbox id="txtFWCY_FTPDZ" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="24"></asp:textbox></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="center" colSpan="2" height="2"></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="right">因特网邮箱：</TD>
																		<TD class="label" align="left"><asp:textbox id="txtFWCY_YXDZ" Runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="24"></asp:textbox></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="center" colSpan="2" height="2"></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="center" colSpan="2">
																			<asp:button id="btnFWCY_Save" Runat="server" Font-Name="宋体" Font-Size="11pt" Height="24px" Width="96px" CssClass="button" Text="保存"></asp:button>&nbsp;&nbsp;
																			<asp:button id="btnFWCY_Cancel" Runat="server" Font-Name="宋体" Font-Size="11pt" Height="24px" Width="96px" CssClass="button" Text="取消"></asp:button></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="center" colSpan="2" height="2"></TD>
																	</TR>
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
									<TD colSpan="5" height="2"></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD class="label" vAlign="middle" align="left">现有部门一览表</TD>
									<TD width="5"></TD>
									<TD class="label" vAlign="middle" align="left">部门现有人员一览表</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top" align="left">
										<iewc:treeview id="tvwBMLIST" runat="server" Font-Name="宋体" Font-Size="11pt" Height="360px" Width="240px" CssClass="label" AutoPostBack="true"></iewc:treeview></TD>
									<TD width="5"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMoveFirst" runat="server" Font-Name="宋体" Font-Size="11pt">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMovePrev" runat="server" Font-Name="宋体" Font-Size="11pt">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMoveNext" runat="server" Font-Name="宋体" Font-Size="11pt">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMoveLast" runat="server" Font-Name="宋体" Font-Size="11pt">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYGotoPage" runat="server" Font-Name="宋体" Font-Size="11pt">前往</asp:linkbutton><asp:textbox id="txtBMRYPageIndex" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYSetPageSize" runat="server" Font-Name="宋体" Font-Size="11pt">每页</asp:linkbutton><asp:textbox id="txtBMRYPageSize" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" align="right" width="200"><asp:label id="lblBMRYGridLocInfo" runat="server" Font-Name="宋体" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle">名称</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYMC" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体" Columns="5"></asp:textbox></TD>
															<TD class="label" vAlign="middle">序号</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYXHMin" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体" Columns="2"></asp:textbox><asp:textbox id="txtBMRYSearch_RYXHMax" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体" Columns="2"></asp:textbox></TD>
															<TD class="label" vAlign="middle">级别</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYJBMC" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体" Columns="5"></asp:textbox></TD>
															<TD class="label" vAlign="middle">职务</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYDRZW" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体" Columns="5"></asp:textbox></TD>
															<TD class="label" vAlign="middle">电话</TD>
															<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYLXDH" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="宋体" Columns="4"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnBMRYSearch" Runat="server" Font-Name="宋体" Font-Size="11pt" Width="60px" CssClass="button" Text="搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divBMRY" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 550px; CLIP: rect(0px 550px 314px 0px); HEIGHT: 314px">
														<asp:datagrid id="grdBMRY" runat="server" Font-Size="11pt" Width="1990px" CssClass="label" Font-Names="宋体"
															AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30"
															BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" UseAccessibleHeader="True" CellPadding="4"
															AllowPaging="True">
															<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选">
																	<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkBMRY" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="人员名称" SortExpression="人员名称" HeaderText="名称" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="人员真名" SortExpression="人员真名" HeaderText="真名" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="是否有效" SortExpression="是否有效" HeaderText="有效" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="组织名称" SortExpression="组织名称" HeaderText="部门" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="人员序号" SortExpression="人员序号" HeaderText="序号" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="岗位列表" SortExpression="岗位列表" HeaderText="职务" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="级别名称" SortExpression="级别名称" HeaderText="级别" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="秘书名称" SortExpression="秘书名称" HeaderText="秘书" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="联系电话" SortExpression="联系电话" HeaderText="联系电话" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="手机号码" SortExpression="手机号码" HeaderText="移动电话" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="FTP地址" SortExpression="FTP地址" HeaderText="内部邮箱" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="邮箱地址" SortExpression="邮箱地址" HeaderText="因特网邮箱" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="人员代码" SortExpression="人员代码" HeaderText="标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="组织代码" SortExpression="组织代码" HeaderText="组织代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="级别代码" SortExpression="级别代码" HeaderText="级别代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="行政级别" SortExpression="行政级别" HeaderText="行政级别" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="秘书代码" SortExpression="秘书代码" HeaderText="秘书代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="自动签收" SortExpression="自动签收" HeaderText="自动签收" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="交接显示名称" SortExpression="交接显示名称" HeaderText="交接显示名称" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="可查看姓名" SortExpression="可查看姓名" HeaderText="可查看姓名" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="可直送人员" SortExpression="可直送人员" HeaderText="可直送人员" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="其他由转送" SortExpression="其他由转送" HeaderText="其他由转送" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="是否加密" SortExpression="是否加密" HeaderText="是否加密" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtBMRYFixed" type="hidden" value="0" runat="server"></DIV>
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
						<TD width="5"></TD>
						<TD style="BORDER-TOP: #99cccc 2px solid" align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left" height="24">
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLFWAddNewB" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/new.gif" border="0" width="16" height="16">定义范围</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLFWUpdateB" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/modify.ico" border="0" width="16" height="16">范围改名</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLFWDeleteB" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/delete.gif" border="0" width="16" height="16">删除范围</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLRYAddNewB" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/movein.ico" border="0" width="16" height="16">加入人员</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLCYDeleteB" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/moveout.ico" border="0" width="16" height="16">移出成员</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLCYUpdateB" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/modify.ico" border="0" width="16" height="16">更改成员</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLCYMoveUpB" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/arwup.ico" border="0" width="16" height="16">成员上移</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLCYMoveDnB" runat="server" Font-Name="宋体" Font-Size="11pt"><img src="../../images/arwdn.ico" border="0" width="16" height="16">成员下移</asp:linkbutton></TD>
									<TD vAlign="middle" align="center"><asp:linkbutton id="lnkMLCloseB" runat="server" Font-Size="11pt" Font-Name="宋体"><img src="../../images/CLOSE.GIF" alt="返回上级" border="0" width="16" height="16">返回上级</asp:linkbutton></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="98%">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" 返回 " style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();"></p></TD>
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
						<input id="htxtFWCYCurrentPage" type="hidden" runat="server">
						<input id="htxtFWCYCurrentRow" type="hidden" runat="server">
						<input id="htxtEditMode" type="hidden" runat="server">
						<input id="htxtEditType" type="hidden" runat="server">
						<input id="htxtFWLISTQuery" type="hidden" runat="server">
						<input id="htxtFWLISTRows" type="hidden" runat="server">
						<input id="htxtFWLISTSort" type="hidden" runat="server">
						<input id="htxtFWLISTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtFWLISTSortType" type="hidden" runat="server">
						<input id="htxtFWCYQuery" type="hidden" runat="server">
						<input id="htxtFWCYRows" type="hidden" runat="server">
						<input id="htxtFWCYSort" type="hidden" runat="server">
						<input id="htxtFWCYSortColumnIndex" type="hidden" runat="server">
						<input id="htxtFWCYSortType" type="hidden" runat="server">
						<input id="htxtBMRYQuery" type="hidden" runat="server">
						<input id="htxtBMRYRows" type="hidden" runat="server">
						<input id="htxtBMRYSort" type="hidden" runat="server">
						<input id="htxtBMRYSortColumnIndex" type="hidden" runat="server">
						<input id="htxtBMRYSortType" type="hidden" runat="server">
						<input id="htxtDivLeftBMRY" type="hidden" runat="server">
						<input id="htxtDivTopBMRY" type="hidden" runat="server">
						<input id="htxtDivLeftFWCY" type="hidden" runat="server">
						<input id="htxtDivTopFWCY" type="hidden" runat="server">
						<input id="htxtDivLeftFWLIST" type="hidden" runat="server">
						<input id="htxtDivTopFWLIST" type="hidden" runat="server">
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
							function ScrollProc_divFWLIST() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFWLIST");
								if (oText != null) oText.value = divFWLIST.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFWLIST");
								if (oText != null) oText.value = divFWLIST.scrollLeft;
								return;
							}
							function ScrollProc_divFWCY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFWCY");
								if (oText != null) oText.value = divFWCY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFWCY");
								if (oText != null) oText.value = divFWCY.scrollLeft;
								return;
							}
							function ScrollProc_divBMRY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopBMRY");
								if (oText != null) oText.value = divBMRY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftBMRY");
								if (oText != null) oText.value = divBMRY.scrollLeft;
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
								oText=document.getElementById("htxtDivTopFWLIST");
								if (oText != null) divFWLIST.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFWLIST");
								if (oText != null) divFWLIST.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopFWCY");
								if (oText != null) divFWCY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFWCY");
								if (oText != null) divFWCY.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopBMRY");
								if (oText != null) divBMRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBMRY");
								if (oText != null) divBMRY.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divFWLIST.onscroll = ScrollProc_divFWLIST;
								divFWCY.onscroll = ScrollProc_divFWCY;
								divBMRY.onscroll = ScrollProc_divBMRY;
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
