<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_bb_kh_gl.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_bb_kh_gl"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>业务主管考核表</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<script src="../../../scripts/transkey.js"></script>
		<style>
			TD.grdTJSJLocked { ; LEFT: expression(divTJSJ.scrollLeft); POSITION: relative }
			TH.grdTJSJLocked { ; LEFT: expression(divTJSJ.scrollLeft); POSITION: relative }
			TH.grdTJSJLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script language="javascript">
			function window_onresize() 
			{
				var intHeight = 0;
				var intWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divTJSJ") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 2 * 4;                       //左、右空白
				intWidth  -= 20;                          //中空白
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= trRow01.clientHeight;
				intHeight -= trRow04.clientHeight;
				intHeight -= 20;                          //调整数

				strHeight = (intHeight - trRow02.clientHeight - trRow03.clientHeight).toString() + "px";
				strWidth  = (intWidth).toString() + "px";
				divTJSJ.style.width  = strWidth;
				divTJSJ.style.height = strHeight;
				divTJSJ.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				//alert(strHeight + "|" + strWidth);
			}
			function document_onreadystatechange() 
			{
				return window_onresize();
			}
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
			function ScrollProc_divTJSJ() {
				var oText;
				oText=null;
				oText=document.getElementById("htxtDivTopTJSJ");
				if (oText != null) oText.value = divTJSJ.scrollTop;
				oText=null;
				oText=document.getElementById("htxtDivLeftTJSJ");
				if (oText != null) oText.value = divTJSJ.scrollLeft;
				return;
			}
			function doRestoreScrollPos()
			{
				try 
				{
					var Text;
					oText=null;
					oText=document.getElementById("htxtDivTopBody");
					if (oText != null) document.body.scrollTop = oText.value;
					oText=null;
					oText=document.getElementById("htxtDivLeftBody");
					if (oText != null) document.body.scrollLeft = oText.value;
					oText=null;
					oText=document.getElementById("htxtDivTopTJSJ");
					if (oText != null) divTJSJ.scrollTop = oText.value;
					oText=null;
					oText=document.getElementById("htxtDivLeftTJSJ");
					if (oText != null) divTJSJ.scrollLeft = oText.value;
					document.body.onscroll = ScrollProc_Body;
					divTJSJ.onscroll = ScrollProc_divTJSJ;
				}
				catch (e) {}
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()" onreadystatechange="document_onreadystatechange()" >
		<form id="frmestate_rs_bb_kh_gl" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR id="trRow01">
						<TD width="4"><asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
						<TD align="left" class="title" height="30" style="BORDER-BOTTOM: #0099cc 2px solid">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;职员业绩考核&nbsp;&gt;&gt;&gt;&gt;&nbsp;业务主管考核</TD>
						<TD width="4"></TD>
					</TR>
					<tr>
						<td colspan="3" height="2"></td>
					</tr>
					<TR>
						<TD width="4"></TD>
						<TD vAlign="top" align="left">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow02">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="labelNotNull" vAlign="middle" align="right"><div style="display:none">&nbsp;考核年度</div></TD>
															<TD class="label" align="left"><div style="display:none"><asp:textbox id="txtTJND" runat="server" CssClass="textbox" Columns="4"></asp:textbox></div></TD>
															<TD class="labelNotNull" vAlign="middle" align="right"><div style="display:none">&nbsp;考核季度</div></TD>
															<TD class="label" align="left">
																<div style="display:none">
																<asp:DropDownList ID="ddlTJJD" Runat="server" CssClass="textbox" Width="120px">
																	<asp:ListItem Value="1">一季度</asp:ListItem>
																	<asp:ListItem Value="2">二季度</asp:ListItem>
																	<asp:ListItem Value="3">三季度</asp:ListItem>
																	<asp:ListItem Value="4">四季度</asp:ListItem>
																</asp:DropDownList>
																</div>
															</td>
															<TD class="labelNotNull" vAlign="middle" align="right"><div style="display:none">&nbsp;月截止日</div></TD>
															<TD class="label" align="left"><div style="display:none"><asp:textbox id="txtYJZR" runat="server" CssClass="textbox" Columns="4">26</asp:textbox></div></TD>
															<TD class="labelNotNull" vAlign="middle" align="right">&nbsp;考核季度开始日期</TD>
															<TD class="label" align="left"><asp:textbox id="txtJDKS" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD class="labelNotNull" vAlign="middle" align="right">&nbsp;考核季度结束日期</TD>
															<TD class="label" align="left"><asp:textbox id="txtJDJS" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD class="label" nowrap>&nbsp;<asp:button id="btnCompute" Runat="server" CssClass="button" Text=" 计算报表数据 "></asp:button></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList ID="ddlTJSJSearch_XSJB" Runat="server" CssClass="textbox" Width="300px">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value=" =  1">仅显示人员季度汇总</asp:ListItem>
																	<asp:ListItem Value=" =  2">仅显示人员月度汇总</asp:ListItem>
																	<asp:ListItem Value=" <= 2">显示到人员月度汇总</asp:ListItem>
																	<asp:ListItem Value=" =  3">仅显示人员月度团队汇总</asp:ListItem>
																	<asp:ListItem Value=" <= 3">显示到人员月度团队汇总</asp:ListItem>
																	<asp:ListItem Value=" =  4">仅显示人员月度团队结算明细</asp:ListItem>
																	<asp:ListItem Value=" <= 4">显示到人员月度团队结算明细</asp:ListItem>
																</asp:DropDownList>
															</td>
															<TD class="label" nowrap>&nbsp;<asp:button id="btnDisplay" Runat="server" CssClass="button" Text=" 显示指定级别 "></asp:button></TD>
														</tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divTJSJ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 967px; CLIP: rect(0px 967px 410px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 410px">
														<asp:datagrid id="grdTJSJ" runat="server" CssClass="label" UseAccessibleHeader="True" CellPadding="3" BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="1px" BackColor="White" AutoGenerateColumns="False" 
															GridLines="Both" PageSize="30" AllowSorting="True" AllowPaging="True" Width="3690px" >
															<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#006699" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选" ItemStyle-Width="0px" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="0px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkTJSJ" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>

																<asp:ButtonColumn ItemStyle-Width="190px" DataTextField="显示名称" SortExpression="显示名称" HeaderText="项目" CommandName="Select">
																	<HeaderStyle Width="190px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="显示级别" SortExpression="显示级别" HeaderText="显示级别" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="考核年度" SortExpression="考核年度" HeaderText="年度" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="考核季度" SortExpression="考核季度" HeaderText="季度" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="开始日期" SortExpression="开始日期" HeaderText="开始日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="终止日期" SortExpression="终止日期" HeaderText="终止日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="测编日期" SortExpression="测编日期" HeaderText="测编日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员名称" SortExpression="人员名称" HeaderText="人员名称" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="考核月度" SortExpression="考核月度" HeaderText="月度" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员职级" SortExpression="人员职级" HeaderText="人员职级" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="试用人员" SortExpression="试用人员" HeaderText="试用" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="考核业绩" SortExpression="考核业绩" HeaderText="考核业绩个人" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="110px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="团队业绩" SortExpression="团队业绩" HeaderText="考核业绩团队" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="110px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="团队类型" SortExpression="团队类型" HeaderText="团队类型代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="团队类型名称" SortExpression="团队类型名称" HeaderText="团队类型" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="团队人数" SortExpression="团队人数" HeaderText="规模" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="月度指标" SortExpression="月度指标" HeaderText="考核指标" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="110px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="月度达标" SortExpression="月度达标" HeaderText="达标" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="代理费额" SortExpression="代理费额" HeaderText="结算代理费" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="110px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="律师费额" SortExpression="律师费额" HeaderText="结算律师费" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="110px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="直管标记" SortExpression="直管标记" HeaderText="直管" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="单位代码" SortExpression="单位代码" HeaderText="单位代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="单位名称" SortExpression="单位名称" HeaderText="单位名称" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="单位序号" SortExpression="单位序号" HeaderText="单位序号" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="团队编号" SortExpression="团队编号" HeaderText="团队" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="认购标识" SortExpression="认购标识" HeaderText="认购标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="合同标识" SortExpression="合同标识" HeaderText="合同标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="合同编号" SortExpression="合同编号" HeaderText="合同编号" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="结算书号" SortExpression="结算书号" HeaderText="结算书号" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="订购日期" SortExpression="订购日期" HeaderText="订购日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="合同日期" SortExpression="合同日期" HeaderText="合同日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="结算日期" SortExpression="结算日期" HeaderText="结算日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="计佣日期" SortExpression="计佣日期" HeaderText="计佣日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="结案日期" SortExpression="结案日期" HeaderText="结案日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="统计日期" SortExpression="统计日期" HeaderText="签约统计" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="业主名称" SortExpression="业主名称" HeaderText="业主" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="客户名称" SortExpression="客户名称" HeaderText="客户" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="240px" DataTextField="物业地址" SortExpression="物业地址" HeaderText="物业地址" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="交易价格" SortExpression="交易价格" HeaderText="交易额" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="交易面积" SortExpression="交易面积" HeaderText="交易面积" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="交易月租金" SortExpression="交易月租金" HeaderText="月租金" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="甲方代理费" SortExpression="甲方代理费" HeaderText="甲方代理费" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="乙方代理费" SortExpression="乙方代理费" HeaderText="乙方代理费" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="总代理费" SortExpression="总代理费" HeaderText="总代理费" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="代理费折扣" SortExpression="代理费折扣" HeaderText="代理折扣(%)" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:##0.00%}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="总律师费" SortExpression="总律师费" HeaderText="总律师费" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="分配比例" SortExpression="分配比例" HeaderText="分配比例(%)" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:##0.00%}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="状态标志" SortExpression="状态标志" HeaderText="业绩类型" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="所属分组" SortExpression="所属分组" HeaderText="所属分组" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="合同类型" SortExpression="合同类型" HeaderText="合同类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtTJSJFixed" type="hidden" size="0" value="2" runat="server" NAME="htxtTJSJFixed"><INPUT id="htxtTJSJColor" type="hidden" size="0" value="1" name="htxtTJSJColor" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow03">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZTJSJDeSelectAll" runat="server" CssClass="label">不选</asp:linkbutton>】</TD>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZTJSJSelectAll" runat="server" CssClass="label">全选</asp:linkbutton>】</TD>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZTJSJMoveFirst" runat="server" CssClass="label">最前</asp:linkbutton>】</TD>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZTJSJMovePrev" runat="server" CssClass="label">前页</asp:linkbutton>】</TD>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZTJSJMoveNext" runat="server" CssClass="label">下页</asp:linkbutton>】</TD>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZTJSJMoveLast" runat="server" CssClass="label">最后</asp:linkbutton>】</TD>
															<TD class="label" vAlign="middle" align="left">【<asp:linkbutton id="lnkCZTJSJGotoPage" runat="server" CssClass="label">前往</asp:linkbutton>】<asp:textbox id="txtTJSJPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left">【<asp:linkbutton id="lnkCZTJSJSetPageSize" runat="server" CssClass="label">每页</asp:linkbutton>】<asp:textbox id="txtTJSJPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="baseline" align="right"><asp:label id="lblTJSJGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="4"></TD>
					</TR>
					<tr>
						<TD width="4"></TD>
						<TD height="2"></TD>
						<TD width="4"></TD>
					</tr>
					<tr id="trRow04">
						<TD width="4"></TD>
						<td align="center" style="BORDER-TOP: #3399cc 2px solid" height="36">
							<asp:Button ID="btnOK"     Runat="server" CssClass="button" Text=" 输出报表 " Height="32px"></asp:Button>
							<asp:Button ID="btnClose"  Runat="server" CssClass="button" Text=" 返回上级 " Height="32px"></asp:Button>
						</td>
						<TD width="4"></TD>
					</tr>
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
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();" type="button" value=" 返回 "></P></TD>
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
						<input id="htxtTJSJSessionId" type="hidden" runat="server" NAME="htxtTJSJSessionId">
						<input id="htxtTJSJQuery" type="hidden" runat="server" NAME="htxtTJSJQuery">
						<input id="htxtTJSJRows" type="hidden" runat="server" NAME="htxtTJSJRows">
						<input id="htxtTJSJSort" type="hidden" runat="server" NAME="htxtTJSJSort">
						<input id="htxtTJSJSortColumnIndex" type="hidden" runat="server" NAME="htxtTJSJSortColumnIndex">
						<input id="htxtTJSJSortType" type="hidden" runat="server" NAME="htxtTJSJSortType">
						<input id="htxtDivLeftTJSJ" type="hidden" runat="server" NAME="htxtDivLeftTJSJ">
						<input id="htxtDivTopTJSJ" type="hidden" runat="server" NAME="htxtDivTopTJSJ">
						<input id="htxtDivLeftBody" type="hidden" runat="server" NAME="htxtDivLeftBody">
						<input id="htxtDivTopBody" type="hidden" runat="server" NAME="htxtDivTopBody">
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">doRestoreScrollPos();</script>
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
