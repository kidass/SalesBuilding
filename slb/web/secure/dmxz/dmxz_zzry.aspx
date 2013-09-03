<%@ Page Language="vb" AutoEventWireup="false" Codebehind="dmxz_zzry.aspx.vb" Inherits="Josco.JsKernal.web.dmxz_zzry" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>人员选择窗</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdBMRYLocked { ; LEFT: expression(divBMRY.scrollLeft); POSITION: relative }
			TH.grdBMRYLocked { ; LEFT: expression(divBMRY.scrollLeft); POSITION: relative }
			TH.grdBMRYLocked { Z-INDEX: 99 }
			TD.grdFWLISTLocked { ; LEFT: expression(divFWLIST.scrollLeft); POSITION: relative }
			TH.grdFWLISTLocked { ; LEFT: expression(divFWLIST.scrollLeft); POSITION: relative }
			TH.grdFWLISTLocked { Z-INDEX: 99 }
			TD.grdJCLXRLocked { ; LEFT: expression(divJCLXR.scrollLeft); POSITION: relative }
			TH.grdJCLXRLocked { ; LEFT: expression(divJCLXR.scrollLeft); POSITION: relative }
			TH.grdJCLXRLocked { Z-INDEX: 99 }
			TD.grdSELRYLocked { ; LEFT: expression(divSELRY.scrollLeft); POSITION: relative }
			TH.grdSELRYLocked { ; LEFT: expression(divSELRY.scrollLeft); POSITION: relative }
			TH.grdSELRYLocked { Z-INDEX: 99 }
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
				var dblDeltaY = 20;
				
				if (document.all("divMAIN") == null)
					return;

				dblHeight = 470 + dblDeltaY + document.body.clientHeight - 570; //default state : 470px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = document.body.clientWidth - 32;
				strWidth  = parseInt(dblWidth.toString(), 10).toString() + "px";
				divMAIN.style.width  = strWidth;
				divMAIN.style.height = strHeight;
				divMAIN.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				
				dblWidth  = divMAIN.clientWidth - 236 - 16;
				strWidth  = parseInt(dblWidth.toString(), 10).toString() + "px";
				strHeight = divBMRY.style.height;
				divBMRY.style.width  = strWidth;
				divBMRY.style.height = strHeight;
				divBMRY.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				strHeight = divSELRY.style.height;
				divSELRY.style.width  = strWidth;
				divSELRY.style.height = strHeight;
				divSELRY.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
				var objUrlControl = null;
				var objControl = null;
				//auto close current window
				objControl = document.getElementById("htxtCloseWindow");
				if (objControl)
				{
					if (objControl.value == "1")
					{
						objControl = document.getElementById("htxtReturnUrl");
						if (objControl)
						{
							objUrlControl = window.opener.document.getElementById("htxtOpenUrl");
							if (objUrlControl)
							{
								objUrlControl.value = objControl.value;
								window.opener.execScript("doOpenUrl();");
							}
						}
						window.close();
						return;
					}
				}
				window_onresize();
			}
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
		<!--
			return document_onreadystatechange()
		//-->
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmDMXZ_ZZRY" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" border="0" align="center">
					<TR>
						<TD width="3"></TD>
						<TD align="center" style="BORDER-BOTTOM: #99cccc 1px solid">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left">
									<TD class="label" vAlign="middle" align="center" height="24"><B>人员选择窗<asp:Label id="lblTitle" Runat="server" CssClass="label"></asp:Label></B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="3"></TD>
					</TR>
					<TR>
						<TD width="3"></TD>
						<TD id="tdMAIN" vAlign="top" align="center">
							<div id="divMAIN" style="OVERFLOW: auto; WIDTH: 820px; CLIP: rect(0px 820px 470px 0px); HEIGHT: 470px">
								<TABLE cellSpacing="0" cellPadding="0" border="0">
									<TR>
										<TD class="tips" align="left" colSpan="5" height="30">&nbsp;&nbsp;单击网格列头可进行排序，单击1次为升序排列，再单击1次为降序排列，再单击1次恢复到原始排序。<asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
									</TR>
									<TR>
										<TD width="3"></TD>
										<TD id="tdCol1" vAlign="top" align="left" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
											<iewc:treeview id="tvwBMLIST" runat="server" CssClass="label" Height="268px" Width="236px" AutoPostBack="true" Font-Name="宋体" Font-Size="11pt"></iewc:treeview></TD>
										<TD width="3"></TD>
										<TD vAlign="top" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD class="label">
														<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
															<TR>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMoveFirst" runat="server" Font-Name="宋体" Font-Size="11pt">最前</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMovePrev" runat="server" Font-Name="宋体" Font-Size="11pt">前页</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMoveNext" runat="server" Font-Name="宋体" Font-Size="11pt">下页</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYMoveLast" runat="server" Font-Name="宋体" Font-Size="11pt">最后</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYGotoPage" runat="server" Font-Name="宋体" Font-Size="11pt">前往</asp:linkbutton><asp:textbox id="txtBMRYPageIndex" runat="server" CssClass="textbox" Font-Name="宋体" Font-Size="11pt" Columns="3">1</asp:textbox>页</TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBMRYSetPageSize" runat="server" Font-Name="宋体" Font-Size="11pt">每页</asp:linkbutton><asp:textbox id="txtBMRYPageSize" runat="server" CssClass="textbox" Font-Name="宋体" Font-Size="11pt" Columns="3">30</asp:textbox>条</TD>
																<TD class="label" vAlign="middle" align="right" width="200"><asp:label id="lblBMRYGridLocInfo" runat="server" CssClass="label" Font-Name="宋体" Font-Size="11pt">1/10 N/15</asp:label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="label" align="left">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD class="label" vAlign="middle">名称</TD>
																<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYMC" runat="server" CssClass="textbox" Font-Size="11pt" Columns="4" Font-Names="宋体"></asp:textbox></TD>
	                                                            <!-- 曾祥林 2008-05-23 -->
	                                                            <TD class="label" vAlign="middle">&nbsp;有效</TD>
	                                                            <TD class="label" align="left"><asp:DropDownList ID="ddlBMRYSearch_SFYX" Runat="server" Font-Size="11pt" CssClass="textbox" Font-Name="宋体"><asp:ListItem Value="">未设</asp:ListItem><asp:ListItem Value="0">无效</asp:ListItem><asp:ListItem Value="1">有效</asp:ListItem></asp:DropDownList></TD>
	                                                            <!-- 曾祥林 2008-05-23 -->
																<TD class="label" vAlign="middle">&nbsp;序号</TD>
																<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYXHMin" runat="server" CssClass="textbox" Font-Size="11pt" Columns="2" Font-Names="宋体"></asp:textbox>~<asp:textbox id="txtBMRYSearch_RYXHMax" runat="server" CssClass="textbox" Font-Size="11pt" Columns="2" Font-Names="宋体"></asp:textbox></TD>
																<TD class="label" vAlign="middle">&nbsp;级别</TD>
																<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYJBMC" runat="server" CssClass="textbox" Font-Size="11pt" Columns="4" Font-Names="宋体"></asp:textbox></TD>
																<TD class="label" vAlign="middle">&nbsp;职务</TD>
																<TD class="label" align="left"><asp:textbox id="txtBMRYSearch_RYDRZW" runat="server" CssClass="textbox" Font-Size="11pt" Columns="4" Font-Names="宋体"></asp:textbox></TD>
																<TD class="label">&nbsp;<asp:button id="btnBMRYSearch" Runat="server" CssClass="button" Font-Name="宋体" Font-Size="11pt" Text="搜索"></asp:button><asp:button id="btnBMRYAdd" Runat="server" CssClass="button" Font-Name="宋体" Font-Size="11pt" Text="选定加入"></asp:button><asp:button id="btnBMRYAddLxr" Runat="server" CssClass="button" Font-Name="宋体" Font-Size="11pt" Text="加到联系人"></asp:button></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD>
														<DIV id="divBMRY" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 586px; CLIP: rect(0px 586px 220px 0px); HEIGHT: 220px;">
															<asp:datagrid id="grdBMRY" runat="server" CssClass="label" Width="1540px" Font-Size="11pt" Font-Names="宋体"
																UseAccessibleHeader="True" CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE"
																PageSize="30" BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
																AllowPaging="True">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="多">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkBMRY" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:ButtonColumn Text="↓" ButtonType="PushButton" CommandName="AddOneRow" HeaderText="单"></asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="人员名称" SortExpression="人员名称" HeaderText="名称" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
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
																		<HeaderStyle Width="60px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="岗位列表" SortExpression="岗位列表" HeaderText="职务" CommandName="Select">
																		<HeaderStyle Width="180px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="级别名称" SortExpression="级别名称" HeaderText="级别" CommandName="Select">
																		<HeaderStyle Width="80px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="秘书名称" SortExpression="秘书名称" HeaderText="秘书" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="联系电话" SortExpression="联系电话" HeaderText="联系电话" CommandName="Select">
																		<HeaderStyle Width="120px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="手机号码" SortExpression="手机号码" HeaderText="移动电话" CommandName="Select">
																		<HeaderStyle Width="120px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="FTP地址" SortExpression="FTP地址" HeaderText="内部邮箱" CommandName="Select">
																		<HeaderStyle Width="160px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="邮箱地址" SortExpression="邮箱地址" HeaderText="因特网邮箱" CommandName="Select">
																		<HeaderStyle Width="160px"></HeaderStyle>
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
															</asp:datagrid><INPUT id="htxtBMRYFixed" type="hidden" value="0" runat="server">
														</DIV>
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD width="3"></TD>
									</TR>
									<TR>
										<TD width="3"></TD>
										<TD class="label" vAlign="middle" align="left" height="24">现有范围一览表</TD>
										<TD width="3"></TD>
										<TD class="label" vAlign="middle" align="left" height="24">已选择的范围/单位/个人信息一览表</TD>
										<TD width="3"></TD>
									</TR>
									<TR>
										<TD width="3"></TD>
										<TD vAlign="top" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD class="label">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD class="label" vAlign="middle" align="left" width="60"><asp:linkbutton id="lnkCZFWLISTDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left" width="60"><asp:linkbutton id="lnkCZFWLISTSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="right" width="180"><asp:label id="lblFWLISTGridLocInfo" runat="server" CssClass="label" Font-Name="宋体" Font-Size="11pt">N/15</asp:label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="label" align="left">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD class="label" vAlign="middle" align="left" nowrap>名称</TD>
																<TD class="label" align="left"><asp:textbox id="txtFWLISTSearch_FWMC" runat="server" CssClass="textbox" Font-Size="11pt" Columns="7" Font-Names="宋体"></asp:textbox></TD>
																<TD class="label"><asp:button id="btnFWLISTSearch" Runat="server" CssClass="button" Height="22px" Font-Name="宋体" Font-Size="11pt" Text="搜索"></asp:button><asp:button id="btnFWLISTAdd" Runat="server" CssClass="button" Height="22px" Font-Name="宋体" Font-Size="11pt" Text="选定加入"></asp:button></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD>
														<DIV id="divFWLIST" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 236px; CLIP: rect(0px 236px 180px 0px); HEIGHT: 180px;">
															<asp:datagrid id="grdFWLIST" runat="server" CssClass="label" Font-Size="11pt" Font-Names="宋体"
																UseAccessibleHeader="True" CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE"
																PageSize="30" BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="多">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkFWLIST" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:ButtonColumn Text="↓" ButtonType="PushButton" CommandName="AddOneRow" HeaderText="单"></asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="范围名称" SortExpression="范围名称" HeaderText="范围名称" CommandName="Select">
																		<HeaderStyle Width="100%"></HeaderStyle>
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
												<TR>
													<TD class="label" align="left" height="30" style="BORDER-TOP: #99cccc 1px solid">我的经常联系人一览表</TD>
												</TR>
												<TR>
													<TD class="label" style="BORDER-TOP: #99cccc 1px solid">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD class="label" vAlign="middle" align="left" width="60"><asp:linkbutton id="lnkCZJCLXRDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left" width="60"><asp:linkbutton id="lnkCZJCLXRSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="right" width="180"><asp:label id="lblJCLXRGridLocInfo" runat="server" CssClass="label" Font-Name="宋体" Font-Size="11pt">N/15</asp:label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="label" align="left">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD class="label" vAlign="middle" align="left" nowrap>名称</TD>
																<TD class="label" align="left"><asp:textbox id="txtJCLXRSearch_RYMC" runat="server" CssClass="textbox" Font-Size="11pt" Columns="7" Font-Names="宋体"></asp:textbox></TD>
																<TD class="label"><asp:button id="btnJCLXRSearch" Runat="server" CssClass="button" Height="22px" Font-Name="宋体" Font-Size="11pt" Text="搜索"></asp:button><asp:button id="btnJCLXRAdd" Runat="server" CssClass="button" Height="22px" Font-Name="宋体" Font-Size="11pt" Text="选定加入"></asp:button></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD>
														<DIV id="divJCLXR" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 236px; CLIP: rect(0px 236px 200px 0px); HEIGHT: 200px;">
															<asp:datagrid id="grdJCLXR" runat="server" CssClass="label" Font-Size="11pt" Font-Names="宋体" UseAccessibleHeader="True"
																CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
																BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" width="1380px">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="多">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkJCLXR" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:ButtonColumn Text="↓" ButtonType="PushButton" CommandName="AddOneRow" HeaderText="单"></asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="人员名称" SortExpression="人员名称" HeaderText="名称" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="组织名称" SortExpression="组织名称" HeaderText="部门" CommandName="Select">
																		<HeaderStyle Width="240px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="人员序号" SortExpression="人员序号" HeaderText="序号" CommandName="Select">
																		<HeaderStyle Width="60px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="岗位列表" SortExpression="岗位列表" HeaderText="职务" CommandName="Select">
																		<HeaderStyle Width="180px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="级别名称" SortExpression="级别名称" HeaderText="级别" CommandName="Select">
																		<HeaderStyle Width="80px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="秘书名称" SortExpression="秘书名称" HeaderText="秘书" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="联系电话" SortExpression="联系电话" HeaderText="联系电话" CommandName="Select">
																		<HeaderStyle Width="120px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="手机号码" SortExpression="手机号码" HeaderText="移动电话" CommandName="Select">
																		<HeaderStyle Width="120px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="FTP地址" SortExpression="FTP地址" HeaderText="内部邮箱" CommandName="Select">
																		<HeaderStyle Width="160px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="邮箱地址" SortExpression="邮箱地址" HeaderText="因特网邮箱" CommandName="Select">
																		<HeaderStyle Width="160px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="联系人代码" SortExpression="联系人代码" HeaderText="标识" CommandName="Select">
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
															</asp:datagrid><INPUT id="htxtJCLXRFixed" type="hidden" value="0" runat="server">
														</DIV>
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD width="3"></TD>
										<TD vAlign="top" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD class="label">
														<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
															<TR>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELRYDeSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">不选</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELRYSelectAll" runat="server" Font-Name="宋体" Font-Size="11pt">全选</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELRYMoveFirst" runat="server" Font-Name="宋体" Font-Size="11pt">最前</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELRYMovePrev" runat="server" Font-Name="宋体" Font-Size="11pt">前页</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELRYMoveNext" runat="server" Font-Name="宋体" Font-Size="11pt">下页</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELRYMoveLast" runat="server" Font-Name="宋体" Font-Size="11pt">最后</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELRYGotoPage" runat="server" Font-Name="宋体" Font-Size="11pt">前往</asp:linkbutton><asp:textbox id="txtSELRYPageIndex" runat="server" CssClass="textbox" Font-Name="宋体" Font-Size="11pt" Columns="3">1</asp:textbox>页</TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELRYSetPageSize" runat="server" Font-Name="宋体" Font-Size="11pt">每页</asp:linkbutton><asp:textbox id="txtSELRYPageSize" runat="server" CssClass="textbox" Font-Name="宋体" Font-Size="11pt" Columns="3">30</asp:textbox>条</TD>
																<TD class="label" vAlign="middle" align="right" width="200"><asp:label id="lblSELRYGridLocInfo" runat="server" CssClass="label" Font-Name="宋体" Font-Size="11pt">1/10 N/15</asp:label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="label">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD class="label" align="left">
																	<TABLE cellSpacing="0" cellPadding="0" border="0">
																		<TR>
																			<TD class="label" vAlign="middle" align="left">范围/单位/人员名称</TD>
																			<TD class="label" align="left"><asp:textbox id="txtSELRYSearch_XZMC" runat="server" CssClass="textbox" Font-Size="11pt" Columns="27" Font-Names="宋体"></asp:textbox></TD>
																			<TD class="label"><asp:button id="btnSELRYSearch" Runat="server" CssClass="button" Height="22px" Font-Name="宋体" Font-Size="11pt" Text="搜索"></asp:button><asp:button id="btnSELRYDelete" Runat="server" CssClass="button" Height="22px" Font-Name="宋体" Font-Size="11pt" Text="选定移出"></asp:button></TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD>
														<DIV id="divSELRY" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 586px; CLIP: rect(0px 586px 415px 0px); HEIGHT: 415px; BACKGROUND-COLOR: white">
															<asp:datagrid id="grdSELRY" runat="server" CssClass="label" Width="1990px" Font-Size="11pt" Font-Names="宋体"
																UseAccessibleHeader="True" CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE"
																PageSize="30" BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
																AllowPaging="True">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="多">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkSELRY" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:ButtonColumn Text="↑" ButtonType="PushButton" CommandName="DeleteOneRow" HeaderText="单"></asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="名称" SortExpression="名称" HeaderText="单位或范围或人员名称" CommandName="Select">
																		<HeaderStyle Width="240px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="类型" SortExpression="类型" HeaderText="类型" CommandName="Select">
																		<HeaderStyle Width="60px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="序号" SortExpression="序号" HeaderText="序号" CommandName="Select">
																		<HeaderStyle Width="60px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="部门" SortExpression="部门" HeaderText="部门" CommandName="Select">
																		<HeaderStyle Width="200px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="职务" SortExpression="职务" HeaderText="职务" CommandName="Select">
																		<HeaderStyle Width="200px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="级别" SortExpression="级别" HeaderText="级别" CommandName="Select">
																		<HeaderStyle Width="200px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="秘书" SortExpression="秘书" HeaderText="秘书" CommandName="Select">
																		<HeaderStyle Width="200px"></HeaderStyle>
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
																</Columns>
																<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
															</asp:datagrid><INPUT id="htxtSELRYFixed" type="hidden" value="0" runat="server"></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="label">&nbsp;输入新的<asp:RadioButtonList id="rblXZLX" Runat="server" Font-Name="宋体" Font-Size="11pt" RepeatLayout="Flow"
															RepeatDirection="Horizontal" RepeatColumns="3">
															<asp:ListItem>范围</asp:ListItem>
															<asp:ListItem>单位</asp:ListItem>
															<asp:ListItem Selected="True">个人</asp:ListItem>
														</asp:RadioButtonList><asp:TextBox id="txtNewRYMC" Runat="server" Height="22px" Font-Name="宋体" Font-Size="11pt" Columns="20"></asp:TextBox><asp:Button id="btnAddNew" Runat="server" Height="22px" Width="60px" Font-Name="宋体" Font-Size="11pt" Text="加入"></asp:Button>
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD width="3"></TD>
									</TR>
									<TR>
										<TD colSpan="5" height="3"></TD>
									</TR>
								</TABLE>
							</div>
						</TD>
						<TD width="3"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="3"></TD>
					</TR>
					<TR>
						<TD align="center" colspan="3" style="BORDER-TOP: #99cccc 1px solid">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							    <tr>
							        <td height="3"></td>
							    </tr>
								<TR vAlign="middle" align="left">
									<TD class="label" vAlign="middle" align="center" height="36"><asp:Button id="btnOK" Runat="server" Height="32px" Font-Name="宋体" Font-Size="11pt" Text=" 确  定 "></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button id="btnCancel" Runat="server" Height="32px" Font-Name="宋体" Font-Size="11pt" Text=" 取  消 "></asp:Button></TD>
								</TR>
							</TABLE>
						</TD>
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
						<input id="htxtCloseWindow" type="hidden" runat="server" value="0">
						<input id="htxtReturnUrl" type="hidden" runat="server">
						<input id="htxtSessionIdSELRY" type="hidden" runat="server">
						<input id="htxtSELRYSort" type="hidden" runat="server">
						<input id="htxtSELRYSortColumnIndex" type="hidden" runat="server">
						<input id="htxtSELRYSortType" type="hidden" runat="server">
						<input id="htxtJCLXRQuery" type="hidden" runat="server">
						<input id="htxtJCLXRRows" type="hidden" runat="server">
						<input id="htxtJCLXRSort" type="hidden" runat="server">
						<input id="htxtJCLXRSortColumnIndex" type="hidden" runat="server">
						<input id="htxtJCLXRSortType" type="hidden" runat="server">
						<input id="htxtFWLISTQuery" type="hidden" runat="server">
						<input id="htxtFWLISTRows" type="hidden" runat="server">
						<input id="htxtFWLISTSort" type="hidden" runat="server">
						<input id="htxtFWLISTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtFWLISTSortType" type="hidden" runat="server">
						<input id="htxtBMRYQuery" type="hidden" runat="server">
						<input id="htxtBMRYRows" type="hidden" runat="server">
						<input id="htxtBMRYSort" type="hidden" runat="server">
						<input id="htxtBMRYSortColumnIndex" type="hidden" runat="server">
						<input id="htxtBMRYSortType" type="hidden" runat="server">
						<input id="htxtDivLeftSELRY" type="hidden" runat="server">
						<input id="htxtDivTopSELRY" type="hidden" runat="server">
						<input id="htxtDivLeftJCLXR" type="hidden" runat="server">
						<input id="htxtDivTopJCLXR" type="hidden" runat="server">
						<input id="htxtDivLeftFWLIST" type="hidden" runat="server">
						<input id="htxtDivTopFWLIST" type="hidden" runat="server">
						<input id="htxtDivLeftBMRY" type="hidden" runat="server">
						<input id="htxtDivTopBMRY" type="hidden" runat="server">
						<input id="htxtDivLeftMAIN" type="hidden" runat="server">
						<input id="htxtDivTopMAIN" type="hidden" runat="server">
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
							function ScrollProc_divMAIN() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopMAIN");
								if (oText != null) oText.value = divMAIN.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftMAIN");
								if (oText != null) oText.value = divMAIN.scrollLeft;
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
							function ScrollProc_divJCLXR() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJCLXR");
								if (oText != null) oText.value = divJCLXR.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJCLXR");
								if (oText != null) oText.value = divJCLXR.scrollLeft;
								return;
							}
							function ScrollProc_divSELRY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSELRY");
								if (oText != null) oText.value = divSELRY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSELRY");
								if (oText != null) oText.value = divSELRY.scrollLeft;
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
								oText=document.getElementById("htxtDivTopMAIN");
								if (oText != null) divMAIN.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftMAIN");
								if (oText != null) divMAIN.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopBMRY");
								if (oText != null) divBMRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBMRY");
								if (oText != null) divBMRY.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopFWLIST");
								if (oText != null) divFWLIST.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFWLIST");
								if (oText != null) divFWLIST.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopJCLXR");
								if (oText != null) divJCLXR.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJCLXR");
								if (oText != null) divJCLXR.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopSELRY");
								if (oText != null) divSELRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSELRY");
								if (oText != null) divSELRY.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMAIN.onscroll = ScrollProc_divMAIN;
								divBMRY.onscroll = ScrollProc_divBMRY;
								divFWLIST.onscroll = ScrollProc_divFWLIST;
								divJCLXR.onscroll = ScrollProc_divJCLXR;
								divSELRY.onscroll = ScrollProc_divSELRY;
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
