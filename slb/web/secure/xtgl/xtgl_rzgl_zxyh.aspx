<%@ Page Language="vb" AutoEventWireup="false" Codebehind="xtgl_rzgl_zxyh.aspx.vb" Inherits="Josco.JsKernal.web.xtgl_rzgl_zxyh"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ϵͳ�����û�</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdZXYHLocked { ; LEFT: expression(divZXYH.scrollLeft); POSITION: relative }
			TH.grdZXYHLocked { ; LEFT: expression(divZXYH.scrollLeft); POSITION: relative }
			TH.grdZXYHLocked { Z-INDEX: 99 }
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
				
				if (document.all("divZXYH") == null)
					return;
				
				dblHeight = 420 + dblDeltaY + document.body.clientHeight - 570; //default state : 420px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 850; //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divZXYH.style.width  = strWidth;
				divZXYH.style.height = strHeight;
				divZXYH.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()" background="../../images/bgmain.gif">
		<form id="frmXTGL_RZGL_ZXYH" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="title" align="center" colSpan="3" height="30">ϵͳ�����û�һ����<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle">�û���ʶ</TD>
															<TD class="label" align="left"><asp:textbox id="txtZXYHSearch_YHBS" runat="server" Font-Size="11pt" Columns="16" CssClass="textbox" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle">�û�����</TD>
															<TD class="label" align="left"><asp:textbox id="txtZXYHSearch_YHMC" runat="server" Font-Size="11pt" Columns="16" CssClass="textbox" Font-Names="����"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnZXYHSearch" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text="��������"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divZXYH" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 800px; CLIP: rect(0px 800px 420px 0px); HEIGHT: 420px">
														<asp:datagrid id="grdZXYH" runat="server" Font-Size="11pt" CssClass="label" Font-Names="����" UseAccessibleHeader="True"
															AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None"
															PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4">
															<SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkZXYH" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="�û���ʶ" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����������" SortExpression="����������" HeaderText="�û�����" CommandName="Select">
																	<HeaderStyle Width="360px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ʱ��" SortExpression="����ʱ��" HeaderText="����ʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ʱ��" SortExpression="����ʱ��" HeaderText="����ʱ��" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtZXYHFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR>
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZZXYHDeSelectAll" runat="server" Font-Name="����" Font-Size="11pt">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZZXYHSelectAll" runat="server" Font-Name="����" Font-Size="11pt">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZZXYHMoveFirst" runat="server" Font-Name="����" Font-Size="11pt">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZZXYHMovePrev" runat="server" Font-Name="����" Font-Size="11pt">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZZXYHMoveNext" runat="server" Font-Name="����" Font-Size="11pt">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZZXYHMoveLast" runat="server" Font-Name="����" Font-Size="11pt">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZZXYHGotoPage" runat="server" Font-Name="����" Font-Size="11pt">ǰ��</asp:linkbutton><asp:textbox id="txtZXYHPageIndex" runat="server" Font-Name="����" Font-Size="11pt" Columns="3" CssClass="textbox">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZZXYHSetPageSize" runat="server" Font-Name="����" Font-Size="11pt">ÿҳ</asp:linkbutton><asp:textbox id="txtZXYHPageSize" runat="server" Font-Name="����" Font-Size="11pt" Columns="3" CssClass="textbox">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblZXYHGridLocInfo" runat="server" Font-Name="����" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
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
					<TR>
						<TD align="center" colSpan="3"><asp:Button id="btnSearch" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text=" ȫ�ļ��� " Height="36px"></asp:Button>&nbsp;&nbsp;<asp:Button id="btnPrint" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text=" ��    ӡ " Height="36px"></asp:Button>&nbsp;&nbsp;<asp:Button id="btnClose" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text=" ��    �� " Height="36px"></asp:Button></TD>
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
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" ���� " style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();"></p></TD>
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
						<input id="htxtZXYHQuery" type="hidden" runat="server">
						<input id="htxtZXYHRows" type="hidden" runat="server">
						<input id="htxtZXYHSort" type="hidden" runat="server">
						<input id="htxtZXYHSortColumnIndex" type="hidden" runat="server">
						<input id="htxtZXYHSortType" type="hidden" runat="server">
						<input id="htxtDivLeftZXYH" type="hidden" runat="server">
						<input id="htxtDivTopZXYH" type="hidden" runat="server">
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
							function ScrollProc_divZXYH() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopZXYH");
								if (oText != null) oText.value = divZXYH.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftZXYH");
								if (oText != null) oText.value = divZXYH.scrollLeft;
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
								oText=document.getElementById("htxtDivTopZXYH");
								if (oText != null) divZXYH.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftZXYH");
								if (oText != null) divZXYH.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divZXYH.onscroll = ScrollProc_divZXYH;
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
