<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_rskp_ldht.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_rskp_ldht" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>人员劳动合同签订情况查看与编辑窗</title>
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
				intWidth  -= 24;                          //滚动条
				intWidth  -= 2 * 4;                       //左、右空白
				intWidth  -= 16;                          //调整数
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 24;                          //调整数
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
				intHeight -= trRow5.clientHeight;
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
		<form id="frmestate_rs_rskp_ldht" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="left" colSpan="3" height="30">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;劳动合同管理【<%=propRYMC%>】<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<tr>
								    <td height="4"></td>
								</tr>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow2">
												<TD class="label" align="left" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">人员&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_RYDM" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体" Columns="6"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;签订时间&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_HTSJMin" runat="server" Font-Size="12px" CssClass="textbox" Columns="10" Font-Names="宋体"></asp:textbox>~<asp:textbox id="txtRYLISTSearch_HTSJMax" runat="server" Font-Size="12px" CssClass="textbox" Columns="10" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;合同类型&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlRYLISTSearch_HTLX" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="0">固定期限合同</asp:ListItem>
																	<asp:ListItem Value="1">无固定期合同</asp:ListItem>
																	<asp:ListItem Value="2">临时合同</asp:ListItem>
																</asp:DropDownList>
															</TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;续约情况&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlRYLISTSearch_SFXY" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="宋体">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="0">新签合同</asp:ListItem>
																	<asp:ListItem Value="1">合同续约</asp:ListItem>
																</asp:DropDownList>
															</TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnRYLISTSearch" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text="快速"></asp:button><asp:button id="btnRYLISTSearch_Full" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text="全文"></asp:button></td>
														</Tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divRYLIST" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 367px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 367px">
														<asp:datagrid id="grdRYLIST" runat="server" Font-Size="12px" CssClass="label" Font-Names="宋体"
															CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
															BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
															UseAccessibleHeader="True" Width="100%">
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
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="员工号" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="人员真名" SortExpression="人员真名" HeaderText="姓名" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="开始时间" SortExpression="开始时间" HeaderText="合同开始" CommandName="Select"  DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="结束时间" SortExpression="结束时间" HeaderText="合同结束" CommandName="Select"  DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="试用开始" SortExpression="试用开始" HeaderText="试用开始" CommandName="Select"  DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="试用结束" SortExpression="试用结束" HeaderText="试用结束" CommandName="Select"  DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="合同类型" SortExpression="合同类型" HeaderText="合同类型码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="合同类型名称" SortExpression="合同类型名称" HeaderText="合同类型" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="是否续约" SortExpression="是否续约" HeaderText="是否续约码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="是否续约名称" SortExpression="是否续约名称" HeaderText="续约情况" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="合同文件" SortExpression="合同文件" HeaderText="合同文件码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="合同文件名称" SortExpression="合同文件名称" HeaderText="有电子文件" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtRYLISTFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
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
					                        <TR id="trRow4">
						                        <TD class="label" align="center" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
							                        <TABLE cellSpacing="0" cellPadding="0" border="0">
								                        <TR>
									                        <TD class="label" align="center">
										                        <TABLE cellSpacing="0" cellPadding="0" border="0">
											                        <TR>
											                            <td class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;员工姓名</td>
												                        <TD class="label" align="left"><asp:textbox id="txtRYMC" Runat="server" Font-Size="12px" Font-Name="宋体" Columns="22" CssClass="textbox"></asp:textbox><asp:Button ID="btnSelect_RYDM" Runat="server" CssClass="button" Text="…"></asp:Button><input type="hidden" id="htxtWYBS" runat="server" size="1"><input type="hidden" id="htxtRYDM" runat="server" size="1"></TD>
											                            <td class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;合同期限</td>
												                        <TD class="label" align="left"><asp:textbox id="txtKSSJ" Runat="server" Font-Size="12px" Font-Name="宋体" Columns="10" CssClass="textbox"></asp:textbox>~<asp:textbox id="txtJSSJ" Runat="server" Font-Size="12px" Font-Name="宋体" Columns="10" CssClass="textbox"></asp:textbox></td>
											                            <td class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;合同类型</td>
												                        <TD class="label" align="left">
																			<asp:RadioButtonList id="rblHTLX" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow" AutoPostBack="True">
																				<asp:ListItem Value="0">固定期限合同</asp:ListItem>
																				<asp:ListItem Value="1">无固定期合同</asp:ListItem>
																				<asp:ListItem Value="2">临时合同</asp:ListItem>
																			</asp:RadioButtonList>
																		</td>
												                        <td><asp:button id="btnSave" Runat="server" Font-Size="12px" Font-Name="宋体" Height="24px" Width="96px" CssClass="button" Text="保存"></asp:button></td>
											                        </TR>
											                        <tr>
																		<td class="label" align="right" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;试用类型</td>
																		<td class="label" align="left">
																			<asp:DropDownList ID="ddlSYLX" Runat="server" CssClass="textbox" AutoPostBack="True" Width="100%">
																				<asp:ListItem Value="">无试用期</asp:ListItem>
																				<asp:ListItem Value="3">三个月试用期</asp:ListItem>
																				<asp:ListItem Value="6">六个月试用期</asp:ListItem>
																			</asp:DropDownList>
																		</td>
																		<td class="label" align="right">&nbsp;&nbsp;&nbsp;&nbsp;试用期限</td>
																		<TD class="label" align="left"><asp:textbox id="txtSYKS" Runat="server" Font-Size="12px" Font-Name="宋体" Columns="10" CssClass="textbox"></asp:textbox>~<asp:textbox id="txtSYJS" Runat="server" Font-Size="12px" Font-Name="宋体" Columns="10" CssClass="textbox"></asp:textbox></td>
											                            <td class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;是否续约</td>
												                        <TD class="label" align="left">
																			<asp:RadioButtonList id="rblSFXY" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
																				<asp:ListItem Value="0">新签合同&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
																				<asp:ListItem Value="1">合同续约&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
																			</asp:RadioButtonList>
																		</td>
												                        <td>&nbsp;</td>
											                        </tr>
											                        <TR>
											                            <td class="label" align="right">&nbsp;&nbsp;&nbsp;&nbsp;合同文件</td>
											                            <td class="label" align="left" colspan="3"><input type="file" id="fileUpload" runat="server" style="FONT-SIZE: 12px; WIDTH: 100%"></td>
											                            <td class="label" align="left" colspan="2"><input type="hidden" id="htxtUploadFile" runat="server" size="1" NAME="htxtUploadFile"><input type="hidden" id="htxtHTWJ" runat="server" size="1" NAME="htxtHTWJ"><asp:LinkButton ID="lnkUpload" Runat="server" CssClass="button" Font-Size="12px">上传文件</asp:LinkButton></td>
												                        <TD><asp:button id="btnCancel" Runat="server" Font-Size="12px" Font-Name="宋体" Height="24px" Width="96px" CssClass="button" Text="取消"></asp:button></TD>
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
									<TD colSpan="5" height="3"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="3"></TD>
					</TR>
					<TR id="trRow5">
						<TD align="center" colSpan="3">
						    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						        <tr>
						            <td height="3"></td>
						        </tr>
						        <tr>
						            <td align="center">
							            <asp:Button id="btnAddNew" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 增    加 " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnUpdate" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 修    改 " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnDelete" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 删    除 " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnPrint" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 打    印 " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnHTWJ" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 查看文件 " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnClose" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 返    回 " Height="36px"></asp:Button>
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
						<input id="htxtCurrentPage" type="hidden" runat="server">
						<input id="htxtCurrentRow" type="hidden" runat="server">
						<input id="htxtEditMode" type="hidden" runat="server">
						<input id="htxtEditType" type="hidden" runat="server">
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
