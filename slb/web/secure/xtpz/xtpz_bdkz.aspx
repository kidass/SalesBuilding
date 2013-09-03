<%@ Page Language="vb" AutoEventWireup="false" Codebehind="xtpz_bdkz.aspx.vb" Inherits="Josco.JsKernal.web.xtpz_bdkz" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�����쵼��ʾ���ƴ���</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdBDKZLocked { ; LEFT: expression(divBDKZ.scrollLeft); POSITION: relative }
			TH.grdBDKZLocked { ; LEFT: expression(divBDKZ.scrollLeft); POSITION: relative }
			TH.grdBDKZLocked { Z-INDEX: 99 }
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
				var dblDeltaX = 20;
				
				if (document.all("divBDKZ") == null)
					return;
				
				dblHeight = 430 + dblDeltaY + document.body.clientHeight - 570; //default state : 430px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 520 + dblDeltaX + document.body.clientWidth  - 850; //default state : 520px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divBDKZ.style.width  = strWidth;
				divBDKZ.style.height = strHeight;
				divBDKZ.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmXTPZ_BDKZ" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="3"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="title" align="left" colSpan="3" height="24" align="center"><asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
									<TD align="right"><asp:Button id="btnClose" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text=" ��ȫ���� "></asp:Button></TD>
									<TD width="3"></TD>
								</TR>
								<TR>
									<TD width="3"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" noWrap align="right">������ְ��</TD>
															<TD class="label" align="left"><asp:textbox id="txtBDKZSearch_ZWMC" runat="server" Font-Size="11pt" CssClass="textbox" Columns="12" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" noWrap align="right">&nbsp;&nbsp;���Ƿ�Χ</TD>
															<TD class="label" align="left"><asp:textbox id="txtBDKZSearch_BDFW" runat="server" Font-Size="11pt" CssClass="textbox" Columns="16" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" noWrap align="right">&nbsp;&nbsp;����˵��</TD>
															<TD class="label" align="left"><asp:textbox id="txtBDKZSearch_BCSM" runat="server" Font-Size="11pt" CssClass="textbox" Columns="16" Font-Names="����"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnBDKZQuery" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text="����"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divBDKZ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 520px; CLIP: rect(0px 520px 430px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 430px">
														<asp:datagrid id="grdBDKZ" runat="server" Font-Size="11pt" CssClass="label" Font-Names="����" UseAccessibleHeader="True"
															AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="4"
															AllowPaging="True" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" Width="760px">
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
																		<asp:CheckBox id="chkBDKZ" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��λ����" SortExpression="��λ����" HeaderText="������ְ��" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���Ƿ�Χ" SortExpression="���Ƿ�Χ" HeaderText="���Ƿ�Χ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���Ƿ�Χ����" SortExpression="���Ƿ�Χ����" HeaderText="���Ƿ�Χ" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="ְ���б�" SortExpression="ְ���б�" HeaderText="ְ���б�" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="�������ƴ���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������������" SortExpression="������������" HeaderText="���Ƿ�Χ����˵��" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtBDKZFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR align="center">
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZBDKZDeSelectAll" runat="server" Font-Name="����" Font-Size="11pt">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZBDKZSelectAll" runat="server" Font-Name="����" Font-Size="11pt">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZBDKZMoveFirst" runat="server" Font-Name="����" Font-Size="11pt">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZBDKZMovePrev" runat="server" Font-Name="����" Font-Size="11pt">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZBDKZMoveNext" runat="server" Font-Name="����" Font-Size="11pt">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZBDKZMoveLast" runat="server" Font-Name="����" Font-Size="11pt">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" noWrap><asp:linkbutton id="lnkCZBDKZGotoPage" runat="server" Font-Name="����" Font-Size="11pt">ǰ��</asp:linkbutton><asp:textbox id="txtBDKZPageIndex" runat="server" Font-Name="����" Font-Size="11pt" CssClass="textbox" Columns="2">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" noWrap><asp:linkbutton id="lnkCZBDKZSetPageSize" runat="server" Font-Name="����" Font-Size="11pt">ÿҳ</asp:linkbutton><asp:textbox id="txtBDKZPageSize" runat="server" Font-Name="����" Font-Size="11pt" CssClass="textbox" Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" align="right"><asp:label id="lblBDKZGridLocInfo" runat="server" Font-Name="����" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:Button id="btnBDKZAddNew" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text=" �����趨 "></asp:Button>
													<asp:Button id="btnBDKZModify" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text=" �����趨 "></asp:Button>
													<asp:Button id="btnBDKZDelete" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text=" ɾ���趨 "></asp:Button>
													<asp:Button id="btnBDKZSearch" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text=" ȫ�ļ��� "></asp:Button>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="6"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="title" style="BORDER-BOTTOM: #99cccc 1px solid" align="center" height="30"><B>������Ϣ�鿴��༭��</B></TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="10"></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" align="left">������ְ��</TD>
											</TR>
											<TR>
												<TD class="label" align="left"><asp:textbox id="txtZWMC" Runat="server" Width="250px" Font-Name="����" Font-Size="11pt" CssClass="textbox"></asp:textbox><asp:LinkButton id="lnkCZSelectZW" Runat="server" CssClass="button"><img src="../../images/glist.gif" border="0" width="16" height="19" align="absmiddle"></asp:LinkButton><INPUT id="htxtZWDM" type="hidden" runat="server"></TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="10"></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" align="left">���Ƿ�Χ��</TD>
											</TR>
											<TR>
												<TD class="label" align="left" width="270">
													<asp:DropDownList id="ddlBDFW" Runat="server" Width="100%" Font-Name="����" Font-Size="11pt">
														<asp:ListItem Value="0">������</asp:ListItem>
														<asp:ListItem Value="1">���Բ�������ָ��ְ���б��еĴ������</asp:ListItem>
														<asp:ListItem Value="2">���Բ��Ǳ�����ָ��ְ���б��еĴ������</asp:ListItem>
													</asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="10"></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" align="left">�������쵼��Ӧ��ְ��</TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="10"></TD>
											</TR>
											<TR>
												<TD class="label" align="left" valign="top"><asp:TextBox id="txtZWLB" Runat="server" Width="250px" Font-Name="����" Font-Size="11pt" TextMode="MultiLine" Rows="6" Height="160px"></asp:TextBox><asp:LinkButton id="lnkCZSelectZWLIST" Runat="server" CssClass="button"><img src="../../images/glist.gif" border="0" width="16" height="19" align="top"></asp:LinkButton></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" align="left">���Ƿ�Χ����˵����</TD>
											</TR>
											<TR>
												<TD class="label" align="left">
													<asp:DropDownList id="ddlBCSM" Runat="server" Width="100%" Font-Name="����" Font-Size="11pt">
														<asp:ListItem Value="1">��һ����λ����</asp:ListItem>
														<asp:ListItem Value="2">�޶�����λ����</asp:ListItem>
														<asp:ListItem Value="3">��������λ����</asp:ListItem>
														<asp:ListItem Value="4">���ļ���λ����</asp:ListItem>
														<asp:ListItem Value="5">���弶��λ����</asp:ListItem>
														<asp:ListItem Value="6">��������λ����</asp:ListItem>
													</asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="10"></TD>
											</TR>
											<TR>
												<TD class="label" align="center">
													<asp:button id="btnSave" Runat="server" Width="96px" Height="24px" Font-Name="����" Font-Size="11pt" CssClass="button" Text="����"></asp:button>
													<asp:button id="btnCancel" Runat="server" Width="96px" Height="24px" Font-Name="����" Font-Size="11pt" CssClass="button" Text="ȡ��"></asp:button>
												</TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="3"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="3"></TD>
								</TR>
								<TR>
									<TD colSpan="3" height="3"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="3"></TD>
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
						<input id="htxtSessionIdBDKZQuery" type="hidden" runat="server">
						<input id="htxtCurrentPage" type="hidden" runat="server">
						<input id="htxtCurrentRow" type="hidden" runat="server">
						<input id="htxtEditMode" type="hidden" runat="server">
						<input id="htxtEditType" type="hidden" runat="server">
						<input id="htxtBDKZQuery" type="hidden" runat="server">
						<input id="htxtBDKZRows" type="hidden" runat="server">
						<input id="htxtBDKZSort" type="hidden" runat="server">
						<input id="htxtBDKZSortColumnIndex" type="hidden" runat="server">
						<input id="htxtBDKZSortType" type="hidden" runat="server">
						<input id="htxtDivLeftBDKZ" type="hidden" runat="server">
						<input id="htxtDivTopBDKZ" type="hidden" runat="server">
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
							function ScrollProc_divBDKZ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopBDKZ");
								if (oText != null) oText.value = divBDKZ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftBDKZ");
								if (oText != null) oText.value = divBDKZ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopBDKZ");
								if (oText != null) divBDKZ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBDKZ");
								if (oText != null) divBDKZ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divBDKZ.onscroll = ScrollProc_divBDKZ;
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
