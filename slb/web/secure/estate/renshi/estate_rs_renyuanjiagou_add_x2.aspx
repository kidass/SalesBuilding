<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_renyuanjiagou_add_x2.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_renyuanjiagou_add_x2" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>入职人员处理窗(模式二)</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../../scripts/transkey.js"></script>
		<style>
			TD.grdRYLocked { ; LEFT: expression(divRY.scrollLeft); POSITION: relative }
			TH.grdRYLocked { ; LEFT: expression(divRY.scrollLeft); POSITION: relative }
			TH.grdRYLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script language="javascript">
		<!--
			function onclick_btnViewJG()
			{
				var strParams = "";
				strParams = strParams + "height=" + (screen.availHeight - 40).toString() +",";
				strParams = strParams + "width="  + (screen.availWidth  - 12).toString() +",";
				strParams = strParams + "top=0,";
				strParams = strParams + "left=0,";
				strParams = strParams + "location=no,";
				strParams = strParams + "menubar=no,";
				strParams = strParams + "toolbar=no,";
				strParams = strParams + "status=no,";
				strParams = strParams + "resizable=yes,";
				strParams = strParams + "scrollbars=yes,";
				strParams = strParams + "titlebar=yes";
				window.open("estate_rs_renyuanjiagou_bdls_x2.aspx", "_blank", strParams);
			}
			
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
		<form id="frmestate_rs_renyuanjiagou_add_x2" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="title" id="trRow1" style="BORDER-BOTTOM: #99cccc 2px solid" vAlign="middle" align="left" height="30">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;二手业务人员架构调整&nbsp;&gt;&gt;&gt;&gt;&nbsp;人员入职<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<DIV id="divMain" style="OVERFLOW: auto; WIDTH: 996px; CLIP: rect(0px 464px 996px 0px); HEIGHT: 464px">
								<TABLE cellSpacing="0" cellPadding="0" border="0">
									<TR>
										<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;在架构中还未进行设置的人员一览表 (共计<asp:Label id="lblRYSM" Runat="server" CssClass="label"></asp:Label>人)</TD>
									</TR>
									<TR>
										<TD align="center">
											<DIV id="divRY" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 940px; CLIP: rect(0px 940px 250px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 250px">
												<asp:datagrid id="grdRY" runat="server" CssClass="label" UseAccessibleHeader="True" AutoGenerateColumns="False" 
													GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="2" AllowPaging="True" 
													PageSize="10" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False" Width="1000px">
													<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
													<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
													<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
													<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
													<FooterStyle BackColor="#CCCC99"></FooterStyle>
													
													<Columns>
														<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
															<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="chkRY" runat="server" AutoPostBack="False"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
													
														<asp:ButtonColumn Visible="False" ItemStyle-Width="40px" DataTextField="人员类型" SortExpression="人员类型" HeaderText="类型" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="人员名称" SortExpression="人员名称" HeaderText="人员名称" CommandName="Select">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
															<HeaderStyle Width="120px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="所属单位名称" SortExpression="所属单位名称" HeaderText="单位名称" CommandName="Select">
															<HeaderStyle Width="170px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="60px" DataTextField="团队编号" SortExpression="团队编号" HeaderText="团队" CommandName="Select">
															<HeaderStyle Width="60px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="所属分组" SortExpression="所属分组" HeaderText="所属分组" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管单位名称" SortExpression="直管单位名称" HeaderText="直管单位" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="上级领导名称" SortExpression="上级领导名称" HeaderText="上级领导" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="变动原因名称" SortExpression="变动原因名称" HeaderText="变动原因" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="90px" DataTextField="生效时间" SortExpression="生效时间" HeaderText="生效时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
															<HeaderStyle Width="90px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="人员状态名称" SortExpression="人员状态名称" HeaderText="状态" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="是否占编" SortExpression="是否占编" HeaderText="占编" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="是否兼职" SortExpression="是否兼职" HeaderText="兼职" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员状态" SortExpression="人员状态" HeaderText="人员状态代码" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="所属单位" SortExpression="所属单位" HeaderText="所属单位" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管单位" SortExpression="直管单位" HeaderText="直管单位码" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="上级领导" SortExpression="上级领导" HeaderText="上级领导代码" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="失效时间" SortExpression="失效时间" HeaderText="失效时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="变动原因" SortExpression="变动原因" HeaderText="变动原因代码" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="标准序列" SortExpression="标准序列" HeaderText="标准序列" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管团队" SortExpression="直管团队" HeaderText="直管团队" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="协管团队" SortExpression="协管团队" HeaderText="协管团队" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
													</Columns>
													
													<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
												</asp:datagrid><INPUT id="htxtRYFixed" type="hidden" value="0" runat="server" NAME="htxtRYFixed">
											</DIV>
										</TD>
									</TR>
									<tr>
										<td class="label">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="label" vAlign="baseline" align="left">『<asp:linkbutton id="lnkCZRYDeSelectAll" runat="server">不选</asp:linkbutton>』</TD>
													<TD class="label" vAlign="baseline" align="left">『<asp:linkbutton id="lnkCZRYSelectAll" runat="server">全选</asp:linkbutton>』</TD>
													<TD class="label" vAlign="baseline" align="left">『<asp:linkbutton id="lnkCZRYMoveFirst" runat="server">最前</asp:linkbutton>』</TD>
													<TD class="label" vAlign="baseline" align="left">『<asp:linkbutton id="lnkCZRYMovePrev" runat="server">前页</asp:linkbutton>』</TD>
													<TD class="label" vAlign="baseline" align="left">『<asp:linkbutton id="lnkCZRYMoveNext" runat="server">下页</asp:linkbutton>』</TD>
													<TD class="label" vAlign="baseline" align="left">『<asp:linkbutton id="lnkCZRYMoveLast" runat="server">最后</asp:linkbutton>』</TD>
													<TD class="label" vAlign="middle" align="left">『<asp:linkbutton id="lnkCZRYGotoPage" runat="server">前往</asp:linkbutton>』<asp:textbox id="txtRYPageIndex" runat="server" CssClass="textbox_center" Columns="1">1</asp:textbox>页</TD>
													<TD class="label" vAlign="middle" align="left">『<asp:linkbutton id="lnkCZRYSetPageSize" runat="server">每页</asp:linkbutton>』<asp:textbox id="txtRYPageSize" runat="server" CssClass="textbox_center" Columns="1">10</asp:textbox>条</TD>
													<TD class="label" vAlign="baseline" noWrap align="right"><asp:label id="lblRYGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
									<TR>
										<TD height="2"></TD>
									</TR>
									<TR>
										<TD vAlign="middle" align="right">&nbsp;人员代码&nbsp;
											<asp:TextBox id="txtSearch_RY_RYDM" Runat="server" CssClass="textbox" Columns="16"></asp:TextBox>&nbsp;人员名称&nbsp;
											<asp:TextBox id="txtSearch_RY_RYMC" Runat="server" CssClass="textbox" Columns="16"></asp:TextBox>&nbsp;单位名称&nbsp;
											<asp:TextBox id="txtSearch_RY_DWMC" Runat="server" CssClass="textbox" Columns="16"></asp:TextBox>&nbsp;职级代码&nbsp;
											<asp:TextBox id="txtSearch_RY_ZJDM" Runat="server" CssClass="textbox" Columns="16"></asp:TextBox>
											<asp:Button id="btnSearch" Runat="server" CssClass="button" Text="搜索"></asp:Button>
											<div style="display:none"><asp:Button id="btnSelAll_RY" Runat="server" CssClass="button" Text="全选"></asp:Button></div>
											<div style="display:none"><asp:Button id="btnDeSelAll_RY" Runat="server" CssClass="button" Text="不选"></asp:Button></div>
										</TD>
									</TR>
									<TR>
										<TD height="2"></TD>
									</TR>
									<TR>
										<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;人员入职时需要填写的内容(如果行政助理，请注意选择[行政助理])<input id="htxtBZXL" type="hidden" runat="server" name="htxtBZXL" value="2"></TD>
									</TR>
									<TR>
										<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" align="center">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD class="labelNotNull" align="right">入职时间：</TD>
													<TD class="label" align="left" colSpan="7"><asp:TextBox id="txtSXSJ" Runat="server" CssClass="textbox" Width="350px"></asp:TextBox>&nbsp;日期格式：yyyy-MM-dd</TD>
												</TR>
												<TR>
													<TD class="labelNotNull" align="right">变动原因：</TD>
													<TD class="label" align="left" colSpan="7"><asp:DropDownList id="ddlYDYY" Runat="server" CssClass="textbox" Width="350px"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="label" align="right"></TD>
													<TD align="left">
														<asp:RadioButtonList id="rblRYLX" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table" AutoPostBack="True">
															<asp:ListItem Value="1" Selected="True">业务人员</asp:ListItem>
															<asp:ListItem Value="0">行政助理</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
													<TD class="label" align="right">&nbsp;&nbsp;&nbsp;&nbsp;</TD>
													<TD align="left">
														<asp:RadioButtonList id="rblRYZT" Runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Horizontal" RepeatLayout="Table">
															<asp:ListItem Value="1" Selected="True">试用人员</asp:ListItem>
															<asp:ListItem Value="2">正式职工</asp:ListItem>
															<asp:ListItem Value="4">实习生</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
													<TD class="label" align="right">&nbsp;&nbsp;&nbsp;&nbsp;</TD>
													<TD align="left">
														<asp:RadioButtonList id="rblSFZB" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table">
															<asp:ListItem Value="0">编外人员</asp:ListItem>
															<asp:ListItem Value="1" Selected="True">编内人员</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
													<TD class="label" align="right">&nbsp;&nbsp;&nbsp;&nbsp;</TD>
													<TD align="left"><asp:CheckBox id="chkSFJZ" Runat="server" CssClass="textbox" Text="兼职" Enabled="False" AutoPostBack="True"></asp:CheckBox></TD>
												</TR>
												<TR>
													<TD class="labelNotNull" align="right">入职职级：</TD>
													<TD align="left" colSpan="7"><asp:DropDownList id="ddlZJDM" Runat="server" CssClass="textbox" Width="350px"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="labelNotNull" align="right">服务单位：</TD>
													<TD class="label" align="left" colSpan="7"><asp:TextBox id="txtSSDW" Runat="server" CssClass="textbox" Width="350px" ReadOnly="True"></asp:TextBox><INPUT id="htxtSSDW" type="hidden" size="1" runat="server" NAME="htxtSSDW"><asp:Button id="btnSelectZZDM" Runat="server" CssClass="button" Text="…"></asp:Button></TD>
												</TR>
												<TR>
													<TD class="label" align="right">团队编号：</TD>
													<TD class="label" align="left" colSpan="7"><asp:TextBox id="txtTDBH" Runat="server" CssClass="textbox" Width="350px"></asp:TextBox><asp:Button id="btnSelectTDBH" Runat="server" CssClass="button" Text="…"></asp:Button><font style="FONT-WEIGHT: bold; COLOR: red; TEXT-DECORATION: underline">如果是业务人员，请指定占编部门所在团队</font></TD>
												</TR>
												<TR>
													<TD class="label" align="right">直管团队：</TD>
													<TD class="label" align="left" colSpan="7"><asp:ListBox ID="lstZGTD" Runat="server" CssClass="textbox" Rows="4" SelectionMode="Single" Width="350px"></asp:ListBox><asp:Button id="btnSelectZGTD" Runat="server" CssClass="button" Text="…"></asp:Button><input type="hidden" id="htxtZGTD" runat="server" name="htxtZGTD"><font style="FONT-WEIGHT: bold; COLOR: red; TEXT-DECORATION: underline">如果是业务经理以上人员，根据实际填写本项内容</font></TD>
												</TR>
												<TR height="148">
													<TD class="label" align="right">协管团队：</TD>
													<TD class="label" align="left" colSpan="7"><asp:ListBox ID="lstXGTD" Runat="server" CssClass="textbox" Rows="8" SelectionMode="Single" Width="350px"></asp:ListBox><asp:Button id="btnSelectXGTD" Runat="server" CssClass="button" Text="…"></asp:Button><input type="hidden" id="htxtXGTD" runat="server" name="htxtXGTD"><font style="FONT-WEIGHT: bold; COLOR: red; TEXT-DECORATION: underline">如果是业务经理以上人员，根据实际填写本项内容</font></TD>
												</TR>
												<TR>
													<TD class="label" align="right"><span style="display:none">服务分组：</span></TD>
													<TD class="label" align="left" colSpan="7"><span style="display:none"><asp:DropDownList id="ddlSSFZ" runat="server" CssClass="textbox" Width="350px"></asp:DropDownList><asp:Button ID="btnJSFZLB" Runat="server" CssClass="button" Text="…"></asp:Button><font style="FONT-WEIGHT: bold; COLOR: red; TEXT-DECORATION: underline">如果是业务人员，根据实际填写本项内容</font></span></TD>
												</TR>
												<TR>
													<TD class="label" align="right"><span style="display:none">直管单位：</span></TD>
													<TD class="label" align="left" colSpan="7"><span style="display:none"><asp:TextBox id="txtZGDW" Runat="server" CssClass="textbox" Width="350px" ReadOnly="True"></asp:TextBox><INPUT id="htxtZGDW" type="hidden" size="1" runat="server" NAME="htxtZGDW"><asp:Button id="btnSelectZGDW" Runat="server" CssClass="button" Text="…"></asp:Button><font style="FONT-WEIGHT: bold; COLOR: red; TEXT-DECORATION: underline">如果是业务经理以上的人员，根据实际填写本项内容</font></span></TD>
												</TR>
												<TR>
													<TD class="label" align="right"><span style="display:none">规谁领导：</span></TD>
													<TD class="label" align="left" colSpan="7"><span style="display:none"><asp:TextBox id="txtSJLD" Runat="server" CssClass="textbox" Width="350px" ReadOnly="True"></asp:TextBox><INPUT id="htxtSJLD" type="hidden" size="1" runat="server" NAME="htxtSJLD"><asp:Button id="btnSelectSJLD" Runat="server" CssClass="button" Text="…"></asp:Button><font style="FONT-WEIGHT: bold; COLOR: red; TEXT-DECORATION: underline">如果是业务人员，请别忘记填写本项内容</font></span></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
					</TR>
					<TR>
						<TD height="2"></TD>
					</TR>
					<TR id="trRow2">
						<TD style="BORDER-TOP: #99cccc 2px solid" vAlign="middle" align="center" height="36">
							<asp:Button id="btnWriteParam" Runat="server" CssClass="button" Text ="写入当前人员" Height="32px"></asp:Button>
							<input      id="btnViewJG"     type="button"  class   ="button" value="查看人员架构" style="HEIGHT: 32px" onclick="onclick_btnViewJG()">
							<asp:Button id="btnOK"         Runat="server" CssClass="button" Text ="确        定" Height="32px"></asp:Button>
							<asp:Button id="btnCancel"     Runat="server" CssClass="button" Text ="取        消" Height="32px"></asp:Button>
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
						<input id="htxtSessionId_TDZH" type="hidden" runat="server" NAME="htxtSessionId_TDZH">
						<input id="htxtBDYY_RYZJ" type="hidden" runat="server" NAME="htxtBDYY_RYZJ" value="001">
						<input id="htxtBDYY_NBTZ" type="hidden" runat="server" NAME="htxtBDYY_NBTZ" value="003">
						<input id="htxtRYRows" type="hidden" runat="server" NAME="htxtRYRows">
						<input id="htxtQuery_RY" type="hidden" runat="server" NAME="htxtQuery_RY">
						<input id="htxtSessionId_RY" type="hidden" runat="server" NAME="htxtSessionId_RY">
						<input id="htxtDivLeftRY" type="hidden" runat="server" NAME="htxtDivLeftRY">
						<input id="htxtDivTopRY" type="hidden" runat="server" NAME="htxtDivTopRY">
						<input id="htxtDivLeftMain" type="hidden" runat="server" NAME="htxtDivLeftMain">
						<input id="htxtDivTopMain" type="hidden" runat="server" NAME="htxtDivTopMain">
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
							function ScrollProc_divRY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRY");
								if (oText != null) oText.value = divRY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRY");
								if (oText != null) oText.value = divRY.scrollLeft;
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
								oText=document.getElementById("htxtDivTopRY");
								if (oText != null) divRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRY");
								if (oText != null) divRY.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divRY.onscroll = ScrollProc_divRY;
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
