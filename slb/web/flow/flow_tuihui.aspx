<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_tuihui.aspx.vb" Inherits="Josco.JSOA.web.flow_tuihui"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�ļ��˻ش�����</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdFSRXXLocked { ; LEFT: expression(divFSRXX.scrollLeft); POSITION: relative }
			TH.grdFSRXXLocked { ; LEFT: expression(divFSRXX.scrollLeft); POSITION: relative }
			TH.grdFSRXXLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../scripts/transkey.js"></script>
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
				
				if (document.all("divFSRXX") == null)
					return;
				
				dblHeight = 470 + dblDeltaY + document.body.clientHeight - 570; //default state : 470px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 850; //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divFSRXX.style.width  = strWidth;
				divFSRXX.style.height = strHeight;
				divFSRXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmFLOW_TUIHUI" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="3" height="26"><B>&nbsp;&nbsp;�����˻ص���Ϣһ����&nbsp;&nbsp;&nbsp;&nbsp;</B><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:Label id="lblFSRXXGridLocInfo" Runat="server" CssClass="labelGrid" ></asp:Label><B>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblZZTS" Runat="server" CssClass="labelNotNull" ></asp:Label></B></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divFSRXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 470px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 470px">
														<asp:datagrid id="grdFSRXX" runat="server" CssClass="labelGrid"  Font-Size="12px" Font-Names="����" AllowPaging="False"
                                                            AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30"
                                                            BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4" UseAccessibleHeader="True">
                                                           <SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="12px" Font-Names="����"  BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ">
																	<HeaderStyle HorizontalAlign="Center" Width="20px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkFSRXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="160px" Wrap="False"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ֽ���ļ�����" SortExpression="����ֽ���ļ�����" HeaderText="����ֽ���ļ�����" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���������ļ�����" SortExpression="���������ļ�����" HeaderText="���������ļ�����" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ֽ�ʸ�������" SortExpression="����ֽ�ʸ�������" HeaderText="����ֽ�ʸ�������" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�������Ӹ�������" SortExpression="�������Ӹ�������" HeaderText="�������Ӹ�������" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ֽ���ļ�����" SortExpression="����ֽ���ļ�����" HeaderText="����ֽ���ļ�����" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���յ����ļ�����" SortExpression="���յ����ļ�����" HeaderText="���յ����ļ�����" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ֽ�ʸ�������" SortExpression="����ֽ�ʸ�������" HeaderText="����ֽ�ʸ�������" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���յ��Ӹ�������" SortExpression="���յ��Ӹ�������" HeaderText="���յ��Ӹ�������" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="ԭ���Ӻ�" SortExpression="ԭ���Ӻ�" HeaderText="ԭ���Ӻ�" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���ӱ�ʶ" SortExpression="���ӱ�ʶ" HeaderText="���ӱ�ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="Э��" SortExpression="Э��" HeaderText="Э��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�����˰�������" SortExpression="�����˰�������" HeaderText="�����˰�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="������Э��" SortExpression="������Э��" HeaderText="������Э��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="Bottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtFSRXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
										</TABLE>
									</TD>
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
							<asp:Button id="btnTuihui" Runat="server" CssClass="button"  Height="30px" Text=" ��  �� "></asp:Button>
							<asp:Button id="btnRefresh" Runat="server" CssClass="button"  Height="30px" Text=" ˢ  �� "></asp:Button>
							<asp:Button id="btnCancel" Runat="server" CssClass="button"  Height="30px" Text=" ȡ  �� "></asp:Button>
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
						<input id="htxtFSRXXQuery" type="hidden" runat="server">
						<input id="htxtFSRXXRows" type="hidden" runat="server">
						<input id="htxtFSRXXSort" type="hidden" runat="server">
						<input id="htxtFSRXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtFSRXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftFSRXX" type="hidden" runat="server">
						<input id="htxtDivTopFSRXX" type="hidden" runat="server">
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
							function ScrollProc_divFSRXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFSRXX");
								if (oText != null) oText.value = divFSRXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFSRXX");
								if (oText != null) oText.value = divFSRXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopFSRXX");
								if (oText != null) divFSRXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFSRXX");
								if (oText != null) divFSRXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divFSRXX.onscroll = ScrollProc_divFSRXX;
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
