<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_rskp_main.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_rskp_main" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>人员资料一览表</title>
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
				intWidth  -= 2 * 4;                       //左右空白
				intWidth  -= 24;                          //右滚动条
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 24;                          //调整数
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
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
	<body background="../../images/oabk.gif" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmestate_rs_rskp_main" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="left" colSpan="3" height="30">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;入职员工管理<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<tr>
								    <td height="4"></td>
								</tr>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow3">
												<TD class="label" align="left" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;员工号&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_RYDM" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体" Width="60px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">年龄&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_NNMin" runat="server" Font-Size="12px" CssClass="textbox" Columns="4" Font-Names="宋体"></asp:textbox>~<asp:textbox id="txtRYLISTSearch_NNMax" runat="server" Font-Size="12px" CssClass="textbox" Columns="4" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;职称&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_ZC" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;职业资格&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_ZYZG" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体" Width="180px"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;政治面貌&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_ZZMM" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;性别&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_XB" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体"><asp:ListItem Value=""> </asp:ListItem><asp:ListItem Value="男">男</asp:ListItem><asp:ListItem Value="女">女</asp:ListItem></asp:DropDownList></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnRYLISTSearch" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 快速搜索 "></asp:button></td>
															
														</Tr>
														<tr>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;姓名&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_RYXM" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体" Width="60px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;岗位&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_DRZW" runat="server" Font-Size="12px" CssClass="textbox" Width="100%" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;学历&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_XL" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体" Width="100%"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;职级&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_ZJMC" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体" Width="180px"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;籍贯/户籍&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_JGHJ" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体" Width="100%"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;民族&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_MZ" runat="server" Font-Size="12px" CssClass="textbox" Width="100%" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnRYLISTSearch_Full" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 全文检索 "></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divRYLIST" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 980px; CLIP: rect(0px 980px 389px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 389px">
														<asp:datagrid id="grdRYLIST" runat="server" Width="6100px" Font-Size="12px" CssClass="label" Font-Names="宋体"
															CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
															BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
															UseAccessibleHeader="True">
															<SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															
															<Columns>
																<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkRYLIST" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="OpenDocument">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="员工号" CommandName="OpenDocument">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="是否在职" SortExpression="是否在职" HeaderText="是否在职" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="姓名" SortExpression="姓名" HeaderText="姓名" CommandName="OpenDocument">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="60px" DataTextField="性别" SortExpression="性别" HeaderText="性别" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="出生日期" SortExpression="出生日期" HeaderText="出生年月" CommandName="Select"  DataTextFormatString="{0:yyyy-MM}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="年龄" SortExpression="年龄" HeaderText="年龄" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="政治面貌" SortExpression="政治面貌" HeaderText="政治面貌代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="政治面貌名称" SortExpression="政治面貌名称" HeaderText="政治面貌" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="最高学历" SortExpression="最高学历" HeaderText="最高学历代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="最高学历名称" SortExpression="最高学历名称" HeaderText="学历" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="学习类型" SortExpression="学习类型" HeaderText="教育类别" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="最高学位" SortExpression="最高学位" HeaderText="最高学位代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="最高学位名称" SortExpression="最高学位名称" HeaderText="学位" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="毕业院校" SortExpression="毕业院校" HeaderText="毕业院校" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="毕业专业" SortExpression="毕业专业" HeaderText="专业" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="技术职称" SortExpression="技术职称" HeaderText="技术职称代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="技术职称名称" SortExpression="技术职称名称" HeaderText="职称" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="执业资格" SortExpression="执业资格" HeaderText="执业资格代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="执业资格名称" SortExpression="执业资格名称" HeaderText="执业资格" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="籍贯" SortExpression="籍贯" HeaderText="籍贯" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="民族" SortExpression="民族" HeaderText="民族" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="参加工作时间" SortExpression="参加工作时间" HeaderText="参加工作时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="入本单位时间" SortExpression="入本单位时间" HeaderText="入本单位时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="转正时间" SortExpression="转正时间" HeaderText="转正时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="转正职位" SortExpression="转正职位" HeaderText="转正职位" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="现任职级" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="担任职务" SortExpression="担任职务" HeaderText="现任职务" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="毕业时间" SortExpression="毕业时间" HeaderText="毕业时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="职称取得时间" SortExpression="职称取得时间" HeaderText="职称取得时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="入党时间" SortExpression="入党时间" HeaderText="入党/团时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="组织关系" SortExpression="组织关系" HeaderText="组织关系" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="是否工会成员" SortExpression="是否工会成员" HeaderText="是否工会成员代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="是否工会成员名称" SortExpression="是否工会成员名称" HeaderText="是否工会成员" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="户籍地址" SortExpression="户籍地址" HeaderText="户籍" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="户口状态" SortExpression="户口状态" HeaderText="户口状态代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="户口状态名称" SortExpression="户口状态名称" HeaderText="户籍状态" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="婚姻状况" SortExpression="婚姻状况" HeaderText="婚姻状况代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="婚姻状况名称" SortExpression="婚姻状况名称" HeaderText="婚姻状况" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="生育情况" SortExpression="生育情况" HeaderText="生育情况代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="生育情况名称" SortExpression="生育情况名称" HeaderText="养育情况" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="子女数量" SortExpression="子女数量" HeaderText="子女数量" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="中介资格" SortExpression="中介资格" HeaderText="中介资格证" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="身份证号" SortExpression="身份证号" HeaderText="身份证号" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="现住地址" SortExpression="现住地址" HeaderText="现住地址" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="邮寄地址" SortExpression="邮寄地址" HeaderText="邮寄地址" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="个人服役说明" SortExpression="个人服役说明" HeaderText="本人服役情况" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="成员服役说明" SortExpression="成员服役说明" HeaderText="家庭服役情况" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="离职原因" SortExpression="离职原因" HeaderText="离职原因" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtRYLISTFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR id="trRow2">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTDeSelectAll" runat="server" Font-Size="12px" Font-Name="宋体">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTSelectAll" runat="server" Font-Size="12px" Font-Name="宋体">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTMoveFirst" runat="server" Font-Size="12px" Font-Name="宋体">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTMovePrev" runat="server" Font-Size="12px" Font-Name="宋体">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTMoveNext" runat="server" Font-Size="12px" Font-Name="宋体">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTMoveLast" runat="server" Font-Size="12px" Font-Name="宋体">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTGotoPage" runat="server" Font-Size="12px" Font-Name="宋体">前往</asp:linkbutton><asp:textbox id="txtRYLISTPageIndex" runat="server" Font-Size="12px" Font-Name="宋体" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTSetPageSize" runat="server" Font-Size="12px" Font-Name="宋体">每页</asp:linkbutton><asp:textbox id="txtRYLISTPageSize" runat="server" Font-Size="12px" Font-Name="宋体" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblRYLISTGridLocInfo" runat="server" Font-Size="12px" Font-Name="宋体" CssClass="label">1/10 N/15</asp:label></TD>
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
					<TR id="trRow4">
						<TD align="center" colSpan="3">
						    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						        <tr>
						            <td height="3"></td>
						        </tr>
						        <tr>
						            <td align="center">
							            <asp:Button id="btnOpen"   Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 打开 " Height="36px"></asp:Button>
							            <asp:Button id="btnAddNew" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 增加 " Height="36px"></asp:Button>
							            <asp:Button id="btnUpdate" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 修改 " Height="36px"></asp:Button>
							            <asp:Button id="btnDelete" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 删除 " Height="36px"></asp:Button>
							            <asp:Button id="btnPrint"  Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 打印人员资料明细表 " Height="36px"></asp:Button>
							            <asp:Button id="btnPXJL"   Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 培训情况 " Height="36px"></asp:Button>
							            <asp:Button id="btnYDJL"   Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 变动情况 " Height="36px"></asp:Button>
							            <asp:Button id="btnLDHT"   Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 劳动合同 " Height="36px"></asp:Button>
							            <asp:Button id="btnClose"  Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 返回 " Height="36px"></asp:Button>
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
