<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_bycl.aspx.vb" Inherits="Josco.JSOA.web.flow_bycl"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�ļ����Ĵ�����</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<style>
		    TD.grdWSCXXLocked { ; LEFT: expression(divWSCXX.scrollLeft); POSITION: relative }
		    TH.grdWSCXXLocked { ; LEFT: expression(divWSCXX.scrollLeft); POSITION: relative }
		    TH.grdWSCXXLocked { Z-INDEX: 99 }
		    TD.grdSGWXXLocked { ; LEFT: expression(divSGWXX.scrollLeft); POSITION: relative }
		    TH.grdSGWXXLocked { ; LEFT: expression(divSGWXX.scrollLeft); POSITION: relative }
		    TH.grdSGWXXLocked { Z-INDEX: 99 }
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
				var dblDeltaY = 20;
				var dblDeltaX = 0;
				
				if (document.all("divWSCXX") == null)
					return;
				
				dblHeight = 220 + (dblDeltaY + document.body.clientHeight - 570) / 2; //default state : 220px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 700 + dblDeltaX + document.body.clientWidth  - 850;       //default state : 700px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divWSCXX.style.width  = strWidth;
				divWSCXX.style.height = strHeight;
				divWSCXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				dblHeight = 220 + (dblDeltaY + document.body.clientHeight - 570) / 2; //default state : 220px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 700 + dblDeltaX + document.body.clientWidth  - 850;       //default state : 700px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divSGWXX.style.width  = strWidth;
				divSGWXX.style.height = strHeight;
				divSGWXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmFLOW_BYCL" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<tr>
									<TD height="5"></TD>
								</tr>
								<TR>
									<TD class="tips" align="left" colSpan="3" height="26"><B>&nbsp;&nbsp;���ͳ���ת�͵��ļ���������/���������е��ļ����Ĳ���</B><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:Label id="lblWSCXXGridLocInfo" Runat="server"  CssClass="labelGrid"></asp:Label></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divWSCXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 700px; CLIP: rect(0px 700px 220px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 220px">
														<asp:datagrid id="grdWSCXX" runat="server" Width="1540px"  CssClass="labelGrid" Font-Size="13px" Font-Names="����"
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                            PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
                                                            <SelectedItemStyle Font-Size="13px" Font-Names="����" Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="13px" Font-Names="����"  BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="13px" Font-Names="����" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="13px" Font-Names="����" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="13px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderStyle-Font-Size="13px" HeaderText="ѡ">
																	<HeaderStyle HorizontalAlign="Center" Width="20px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWSCXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����״̬" SortExpression="����״̬" HeaderText="״̬" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����˵��" SortExpression="����˵��" HeaderText="��������ע" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���ӱ�ע" SortExpression="���ӱ�ע" HeaderText="��ע" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="ί����" SortExpression="ί����" HeaderText="ת����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�����������" SortExpression="�����������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���ӱ�ʶ" SortExpression="���ӱ�ʶ" HeaderText="���ӱ�ʶ" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�ļ���ʶ" SortExpression="�ļ���ʶ" HeaderText="�ļ���ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="ԭ���Ӻ�" SortExpression="ԭ���Ӻ�" HeaderText="ԭ���Ӻ�" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="����ֽ���ļ�" SortExpression="����ֽ���ļ�" HeaderText="����ֽ���ļ�����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���͵����ļ�" SortExpression="���͵����ļ�" HeaderText="���͵����ļ�����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="����ֽ�ʸ���" SortExpression="����ֽ�ʸ���" HeaderText="����ֽ�ʸ�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���͵��Ӹ���" SortExpression="���͵��Ӹ���" HeaderText="���͵��Ӹ�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="����ֽ���ļ�" SortExpression="����ֽ���ļ�" HeaderText="����ֽ���ļ�����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���յ����ļ�" SortExpression="���յ����ļ�" HeaderText="���յ����ļ�����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="����ֽ�ʸ���" SortExpression="����ֽ�ʸ���" HeaderText="����ֽ�ʸ�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���յ��Ӹ���" SortExpression="���յ��Ӹ���" HeaderText="���յ��Ӹ�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="Э��" SortExpression="Э��" HeaderText="Э��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="Bottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtWSCXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
												<td valign="top">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<tr>
															<td height="10"></td>
														</tr>
														<tr>
															<td><asp:Button id="btnSendTongzhi" Runat="server"  CssClass="button" Text="��������" Height="30px"></asp:Button></td>
														</tr>
														<tr>
															<td height="10"></td>
														</tr>
														<tr>
															<td><div style="display:none"><asp:Button id="btnSendRequest" Runat="server"  CssClass="button" Text="��������" Height="30px"></asp:Button></div></td>
														</tr>
														<tr>
															<td height="10"></td>
														</tr>
														<tr>
															<td><asp:Button id="btnShouRequest" Runat="server"  CssClass="button" Text=" ��  �� " Height="30px"></asp:Button></td>
														</tr>
														
														
													</table>
												</td>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<tr>
									<TD height="3"></TD>
								</tr>
								<TR>
									<TD class="tips" align="left" colSpan="3" height="26"><B>&nbsp;&nbsp;�͸��ҵ��ļ���������</B><asp:Label id="lblSGWXXGridLocInfo" Runat="server"  CssClass="labelGrid"></asp:Label></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divSGWXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 700px; CLIP: rect(0px 700px 220px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 220px">
														<asp:datagrid id="grdSGWXX" runat="server" Width="1480px" CssClass="labelGrid" Font-Size="13px" Font-Names="����"
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                            PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
                                                            <SelectedItemStyle Font-Size="13px" Font-Names="����" Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="13px" Font-Names="����"  BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="13px" Font-Names="����" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="13px" Font-Names="����" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="13px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderStyle-Font-Size="13px" HeaderText="ѡ">
																	<HeaderStyle HorizontalAlign="Center" Width="20px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkSGWXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����״̬" SortExpression="����״̬" HeaderText="״̬" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����˵��" SortExpression="����˵��" HeaderText="��������ע" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���ӱ�ע" SortExpression="���ӱ�ע" HeaderText="��ע" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="ί����" SortExpression="ί����" HeaderText="ת����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select"
																	DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select"
																	DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�����������" SortExpression="�����������" HeaderText="��������" CommandName="Select"
																	DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select"
																	DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���ӱ�ʶ" SortExpression="���ӱ�ʶ" HeaderText="���ӱ�ʶ" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�ļ���ʶ" SortExpression="�ļ���ʶ" HeaderText="�ļ���ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="ԭ���Ӻ�" SortExpression="ԭ���Ӻ�" HeaderText="ԭ���Ӻ�" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="����ֽ���ļ�" SortExpression="����ֽ���ļ�" HeaderText="����ֽ���ļ�����"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���͵����ļ�" SortExpression="���͵����ļ�" HeaderText="���͵����ļ�����"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="����ֽ�ʸ���" SortExpression="����ֽ�ʸ���" HeaderText="����ֽ�ʸ�������"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���͵��Ӹ���" SortExpression="���͵��Ӹ���" HeaderText="���͵��Ӹ�������"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="����ֽ���ļ�" SortExpression="����ֽ���ļ�" HeaderText="����ֽ���ļ�����"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���յ����ļ�" SortExpression="���յ����ļ�" HeaderText="���յ����ļ�����"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="����ֽ�ʸ���" SortExpression="����ֽ�ʸ���" HeaderText="����ֽ�ʸ�������"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���յ��Ӹ���" SortExpression="���յ��Ӹ���" HeaderText="���յ��Ӹ�������"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="Э��" SortExpression="Э��" HeaderText="Э��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtSGWXXFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
												<td valign="top">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<tr>
															<td height="10"></td>
														</tr>
														<tr>
															<td><asp:Button id="btnPizhun" Runat="server"  CssClass="button" Text=" ͬ  �� " Height="30px"></asp:Button></td>
														</tr>
														<tr>
															<td height="10"></td>
														</tr>
														<tr>
															<td><asp:Button id="btnJujue" Runat="server"  CssClass="button" Text=" ��  �� " Height="30px"></asp:Button></td>
														</tr>
														<tr>
															<td height="10"></td>
														</tr>
														<tr>
															<td><asp:Button id="btnZhuanfa" Runat="server"  CssClass="button" Text=" ת  �� " Height="30px"></asp:Button></td>
														</tr>
														<tr>
															<td height="10"></td>
														</tr>
														<tr>
															<td><asp:Button id="btnHasRead" Runat="server"  CssClass="button" Text="���ѿ���" Height="30px"></asp:Button></td>
														</tr>
													</table>
												</td>
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
					<TR>
						<TD align="center" colSpan="3">
							<asp:Button id="btnRefresh" Runat="server"  CssClass="button" Text=" ˢ  �� " Height="30px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnCancel" Runat="server"  CssClass="button" Text=" ��  �� " Height="30px"></asp:Button>
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
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" ���� " style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();"></p></TD>
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
						<input id="htxtValueB" type="hidden" runat="server"><!--�����ʱ����-->
						<input id="htxtValueA" type="hidden" runat="server"><!--�����ʱ����-->
						<input id="htxtWSCXXQuery" type="hidden" runat="server">
						<input id="htxtWSCXXRows" type="hidden" runat="server">
						<input id="htxtWSCXXSort" type="hidden" runat="server">
						<input id="htxtWSCXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtWSCXXSortType" type="hidden" runat="server">
						<input id="htxtSGWXXQuery" type="hidden" runat="server">
						<input id="htxtSGWXXRows" type="hidden" runat="server">
						<input id="htxtSGWXXSort" type="hidden" runat="server">
						<input id="htxtSGWXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtSGWXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftWSCXX" type="hidden" runat="server">
						<input id="htxtDivTopWSCXX" type="hidden" runat="server">
						<input id="htxtDivLeftSGWXX" type="hidden" runat="server">
						<input id="htxtDivTopSGWXX" type="hidden" runat="server">
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
							function ScrollProc_divWSCXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopWSCXX");
								if (oText != null) oText.value = divWSCXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftWSCXX");
								if (oText != null) oText.value = divWSCXX.scrollLeft;
								return;
							}
							function ScrollProc_divSGWXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSGWXX");
								if (oText != null) oText.value = divSGWXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSGWXX");
								if (oText != null) oText.value = divSGWXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopWSCXX");
								if (oText != null) divWSCXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftWSCXX");
								if (oText != null) divWSCXX.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopSGWXX");
								if (oText != null) divSGWXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSGWXX");
								if (oText != null) divSGWXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divWSCXX.onscroll = ScrollProc_divWSCXX;
								divSGWXX.onscroll = ScrollProc_divSGWXX;
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
