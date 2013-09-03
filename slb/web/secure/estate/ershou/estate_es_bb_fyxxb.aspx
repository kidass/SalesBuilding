<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_bb_fyxxb.aspx.vb" Inherits="Josco.JSOA.web.estate_es_bb_fyxxb" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>中介部房源信息表</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet"/>
		<style>
			TD.grdContentLocked { ; LEFT: expression(divContent.scrollLeft); POSITION: relative }
			TH.grdContentLocked { ; LEFT: expression(divContent.scrollLeft); POSITION: relative }
			TH.grdContentLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../../scripts/transkey.js"></script>
		<script language="javascript">
			function onresize_body() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";

				if (document.all("divContent") == null)
					return;
				
				dblWidth  = document.body.clientWidth;
				dblWidth  -= 18;
				strWidth   = dblWidth.toString() + "px";

				dblHeight = document.body.clientHeight;
				dblHeight -= trRow00.clientHeight;
				dblHeight -= trRow01.clientHeight;
				dblHeight -= trRow02.clientHeight;
				dblHeight -= trRow03.clientHeight;
				dblHeight -= 18;
				strHeight  = dblHeight.toString() + "px";
				
				divContent.style.width  = strWidth;
				divContent.style.height = strHeight;
				divContent.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function onreadystatechange_body() 
			{
				return onresize_body();
			}
			function onscroll_body() 
			{
				var oText;
				oText=null;
				oText=document.getElementById("htxtDivTopBody");
				if (oText != null) oText.value = document.body.scrollTop;
				oText=null;
				oText=document.getElementById("htxtDivLeftBody");
				if (oText != null) oText.value = document.body.scrollLeft;
				return;
			}
			function onscroll_divContent() 
			{
				var oText;
				oText=null;
				oText=document.getElementById("htxtDivTopContent");
				if (oText != null) oText.value = divContent.scrollTop;
				oText=null;
				oText=document.getElementById("htxtDivLeftContent");
				if (oText != null) oText.value = divContent.scrollLeft;
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
					oText=document.getElementById("htxtDivTopContent");
					if (oText != null) divContent.scrollTop = oText.value;
					oText=null;
					oText=document.getElementById("htxtDivLeftContent");
					if (oText != null) divContent.scrollLeft = oText.value;
				}
				catch (e) {}
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="onresize_body()" onreadystatechange="onreadystatechange_body()" onscroll="onscroll_body()">
		<form id="frmestate_es_bb_fyxxb" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" border="0">
					<TR id="trRow00">
						<TD width="4"></TD>
                        <TD height="30" class="title" vAlign="middle" align="center" style="BORDER-BOTTOM: #99cccc 2px solid">中介部房源信息表</TD>
                        <TD width="4"></TD>
                    </TR>					
					<tr id="trRow02">
						<TD width="4"></TD>
						<td style="BORDER-BOTTOM: #99cccc 1px solid">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
							    <tr>
								    <td class="label" nowrap>&nbsp;&nbsp;业主名称<asp:TextBox ID="txtYZMC" runat="server" CssClass="textbox" Columns="24"></asp:TextBox></td>
								    <td class="label" nowrap>&nbsp;&nbsp;联系地址<asp:TextBox ID="txtYZDZ" runat="server" CssClass="textbox" Columns="28"></asp:TextBox></td>
								    <td class="label" nowrap>&nbsp;&nbsp;确认书号<asp:TextBox ID="txtQRSH" runat="server" CssClass="textbox" Columns="16"></asp:TextBox></td>
								    <td class="label" nowrap>&nbsp;&nbsp;物业地址<asp:TextBox ID="txtFWDZ" runat="server" CssClass="textbox" Width="170px"></asp:TextBox></td>
								    <td></td>
							    </tr>
								<tr>
								    <td class="label" nowrap>&nbsp;&nbsp;业主电话<asp:TextBox ID="txtLXDH" runat="server" CssClass="textbox" Columns="24"></asp:TextBox>
								    <td class="label" nowrap>&nbsp;&nbsp;证照号码<asp:TextBox ID="txtZZHM" runat="server" CssClass="textbox" Columns="28"></asp:TextBox></td>
								    <td class="label" nowrap>&nbsp;&nbsp;合同编号<asp:TextBox ID="txtHTBH" runat="server" CssClass="textbox" Columns="16"></asp:TextBox></td>
								    <td class="label" nowrap>&nbsp;&nbsp;合同日期<asp:TextBox ID="txtHTRQMin" runat="server" CssClass="textbox" Columns="10"></asp:TextBox>-<asp:TextBox ID="txtHTRQMax" runat="server" CssClass="textbox" Columns="10"></asp:TextBox></td>
									<TD align="right">&nbsp;&nbsp;<asp:linkbutton id="lnkMLCompute" runat="server">计算数据</asp:linkbutton></TD>
								</tr>
							</table>
						</td>
						<TD width="4"></TD>
					</tr>
					<TR>
						<TD width="4"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD width="4"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divContent" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 977px; CLIP: rect(0px 977px 408px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 408px" onscroll="onscroll_divContent()">
														<asp:datagrid id="grdContent" runat="server" CssClass="label" UseAccessibleHeader="True" AllowSorting="True"
															BorderWidth="1px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="True" CellPadding="3" BorderStyle="Solid"
															GridLines="Vertical" AutoGenerateColumns="False" Width="9390px">
															<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkContent" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>

																<asp:ButtonColumn ItemStyle-Width="90px" DataTextField="交易类型" SortExpression="交易类型" HeaderText="类型" CommandName="Select">
																	<HeaderStyle Width="90px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="260px" DataTextField="业主名称" SortExpression="业主名称" HeaderText="业主名称" CommandName="OpenDocument">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="房源编号" SortExpression="房源编号" HeaderText="房源编号" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="甲方联系电话" SortExpression="甲方联系电话" HeaderText="联系电话" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="甲方联系地址" SortExpression="甲方联系地址" HeaderText="联系地址" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="220px" DataTextField="甲方证照号码" SortExpression="甲方证照号码" HeaderText="证照号码" CommandName="Select">
																	<HeaderStyle Width="220px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="甲方代理人" SortExpression="甲方代理人" HeaderText="代理人" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="甲方证件类型" SortExpression="甲方证件类型" HeaderText="证件类型" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="400px" DataTextField="房屋地址" SortExpression="房屋地址" HeaderText="房屋地址" CommandName="Select">
																	<HeaderStyle Width="400px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="房产证号" SortExpression="房产证号" HeaderText="房产证号" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="400px" DataTextField="房产证地址" SortExpression="房产证地址" HeaderText="房产证地址" CommandName="Select">
																	<HeaderStyle Width="400px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼盘" SortExpression="楼盘" HeaderText="楼盘" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼栋" SortExpression="楼栋" HeaderText="楼栋" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="单元" SortExpression="单元" HeaderText="单元" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="面积" SortExpression="面积" HeaderText="面积" CommandName="Select" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="座向" SortExpression="座向" HeaderText="座向" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼高" SortExpression="楼高" HeaderText="楼高" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼层" SortExpression="楼层" HeaderText="楼层" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼龄" SortExpression="楼龄" HeaderText="楼龄" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="间隔" SortExpression="间隔" HeaderText="间隔代码" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="间隔名称" SortExpression="间隔名称" HeaderText="户型" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="物业性质" SortExpression="物业性质" HeaderText="物业性质代码" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="物业性质名称" SortExpression="物业性质名称" HeaderText="物业性质" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="所在区域" SortExpression="所在区域" HeaderText="所在区域代码" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="所在区域名称" SortExpression="所在区域名称" HeaderText="行政区" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="建成时间" SortExpression="建成时间" HeaderText="建成时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="空间类型" SortExpression="空间类型" HeaderText="空间类型" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="房屋性质" SortExpression="房屋性质" HeaderText="房屋性质" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="装修档次" SortExpression="装修档次" HeaderText="装修档次" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="装修年限" SortExpression="装修年限" HeaderText="装修年限" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="噪音影响" SortExpression="噪音影响" HeaderText="噪音影响" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="家具设备" SortExpression="家具设备" HeaderText="家具设备" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼宇交通" SortExpression="楼宇交通" HeaderText="楼宇交通" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="房屋间隔" SortExpression="房屋间隔" HeaderText="间隔评价" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="景观类型" SortExpression="景观类型" HeaderText="景观类型" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="景观房数" SortExpression="景观房数" HeaderText="景观房数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="卧室数量" SortExpression="卧室数量" HeaderText="卧室数量" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="阳台数量" SortExpression="阳台数量" HeaderText="阳台数量" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="电梯数量" SortExpression="电梯数量" HeaderText="电梯数量" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼层户数" SortExpression="楼层户数" HeaderText="楼层户数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼盘期数" SortExpression="楼盘期数" HeaderText="楼盘期数" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主区码" SortExpression="业主区码" HeaderText="业主地区" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主区名" SortExpression="业主区名" HeaderText="业主地区补充" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主来源" SortExpression="业主来源" HeaderText="业主来源" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业源其他" SortExpression="业源其他" HeaderText="业主来源补充" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主电邮" SortExpression="业主电邮" HeaderText="业主电邮" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="售后意向" SortExpression="售后意向" HeaderText="售后意向" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="剩余物业" SortExpression="剩余物业" HeaderText="剩余物业" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易编号" SortExpression="交易编号" HeaderText="确认书号" CommandName="OpenDocument">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="合同编号" SortExpression="合同编号" HeaderText="合同编号" CommandName="OpenDocument">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="400px" DataTextField="物业地址" SortExpression="物业地址" HeaderText="房屋地址(合同)" CommandName="Select">
																	<HeaderStyle Width="400px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="交易日期" SortExpression="交易日期" HeaderText="订购日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="合同日期" SortExpression="合同日期" HeaderText="合同日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="统计日期" SortExpression="统计日期" HeaderText="统计日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																

																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易价格" SortExpression="交易价格" HeaderText="交易金额" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易面积" SortExpression="交易面积" HeaderText="交易面积" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="甲方代理费" SortExpression="甲方代理费" HeaderText="甲方代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="乙方代理费" SortExpression="乙方代理费" HeaderText="乙方代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="代理费折扣" SortExpression="代理费折扣" HeaderText="代理费折扣" CommandName="Select" DataTextFormatString="{0:#.00%}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="实收佣金" SortExpression="实收佣金" HeaderText="实收佣金" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="交易状态" SortExpression="交易状态" HeaderText="交易状态" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="合同状态" SortExpression="合同状态" HeaderText="合同状态码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="合同解除" SortExpression="合同解除" HeaderText="合同解除" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="坏账合同" SortExpression="坏账合同" HeaderText="坏账合同" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="合同状态名称" SortExpression="合同状态名称" HeaderText="合同状态" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtContentFixed" type="hidden" value="2" runat="server" NAME="htxtContentFixed"/>
													</DIV>
												</TD>
											</TR>
											<TR id="trRow03" align="center">
												<TD>
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR align="center">
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZDeSelectAll" runat="server" CssClass="label" Enabled="False">不选</asp:linkbutton>】</TD>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZSelectAll" runat="server" CssClass="label" Enabled="False">全选</asp:linkbutton>】</TD>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZMoveFirst" runat="server" CssClass="label">最前</asp:linkbutton>】</TD>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZMovePrev" runat="server" CssClass="label">前页</asp:linkbutton>】</TD>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZMoveNext" runat="server" CssClass="label">下页</asp:linkbutton>】</TD>
															<TD class="label" vAlign="baseline" align="left">【<asp:linkbutton id="lnkCZMoveLast" runat="server" CssClass="label">最后</asp:linkbutton>】</TD>
															<TD class="label" vAlign="middle" align="left">【<asp:linkbutton id="lnkCZGotoPage" runat="server" CssClass="label">前往</asp:linkbutton>】<asp:textbox id="txtPageIndex" runat="server" Columns="1" CssClass="textbox">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left">【<asp:linkbutton id="lnkCZSetPageSize" runat="server" CssClass="label">每页</asp:linkbutton>】<asp:textbox id="txtPageSize" runat="server" Columns="1" CssClass="textbox">30</asp:textbox>条</TD>
															<TD class="label" vAlign="baseline" align="right"><asp:label id="lblGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="4"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="4"></TD>
					</TR>
					<TR id="trRow01">
						<TD width="4"></TD>
						<TD style="BORDER-TOP: #99cccc 2px solid" align="center" height="32" valign="middle">
							<asp:linkbutton id="lnkMLExport"     runat="server">输出数据</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lnkMLSearchFull" runat="server">全文搜索</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:linkbutton id="lnkMLReturn"     runat="server">返回上级</asp:linkbutton>
						</TD>
						<TD width="4"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
						<input id="htxtSessionIdBuffer" type="hidden" runat="server" NAME="htxtSessionIdBuffer"/>
						<input id="htxtSessionIdQuery" type="hidden" runat="server" NAME="htxtSessionIdQuery"/>
						<input id="htxtQuery" type="hidden" runat="server" NAME="htxtQuery"/>
						<input id="htxtRows" type="hidden" runat="server" NAME="htxtRows"/>
						<input id="htxtSort" type="hidden" runat="server" NAME="htxtSort"/>
						<input id="htxtSortColumnIndex" type="hidden" runat="server" NAME="htxtSortColumnIndex"/>
						<input id="htxtSortType" type="hidden" runat="server" NAME="htxtSortType"/>
						<input id="htxtDivLeftContent" type="hidden" runat="server" NAME="htxtDivLeftContent"/>
						<input id="htxtDivTopContent" type="hidden" runat="server" NAME="htxtDivTopContent"/>
						<input id="htxtDivLeftBody" type="hidden" runat="server" NAME="htxtDivLeftBody"/>
						<input id="htxtDivTopBody" type="hidden" runat="server" NAME="htxtDivTopBody"/>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">doRestoreScrollPos();</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">onresize_body();</script>
						<uwin:popmessage id="popMessageObject" runat="server" height="48px" width="96px" Visible="False" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
