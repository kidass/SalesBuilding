<%@ Page Language="vb" AutoEventWireup="false" Codebehind="xtpz_dbsz.aspx.vb" Inherits="Josco.JsKernal.web.xtpz_dbsz" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>������ƴ���</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdDBSZLocked { ; LEFT: expression(divDBSZ.scrollLeft); POSITION: relative }
			TH.grdDBSZLocked { ; LEFT: expression(divDBSZ.scrollLeft); POSITION: relative }
			TH.grdDBSZLocked { Z-INDEX: 99 }
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
				
				if (document.all("divDBSZ") == null)
					return;
				
				dblHeight = 430 + dblDeltaY + document.body.clientHeight - 570; //default state : 430px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 550 + dblDeltaX + document.body.clientWidth  - 850; //default state : 550px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divDBSZ.style.width  = strWidth;
				divDBSZ.style.height = strHeight;
				divDBSZ.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmXTPZ_DBSZ" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="3"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="title" align="left" height="24" colspan="3"><asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
									<TD align="right"><asp:Button id="btnClose" Runat="server" Text=" ��ȫ���� " CssClass="button" Font-Size="11pt" Font-Name="����"></asp:Button></TD>
									<TD width="3"></TD>
								</TR>
								<TR>
									<TD width="3"></TD>
									<TD style="" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" noWrap align="right">������ְ��</TD>
															<TD class="label" align="left"><asp:textbox id="txtDBSZSearch_ZWMC" runat="server" CssClass="textbox" Font-Size="11pt" Columns="12" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" noWrap align="right">&nbsp;&nbsp;���췶Χ</TD>
															<TD class="label" align="left"><asp:textbox id="txtDBSZSearch_DBFW" runat="server" CssClass="textbox" Font-Size="11pt" Columns="16" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" noWrap align="right">&nbsp;&nbsp;����˵��</TD>
															<TD class="label" align="left"><asp:textbox id="txtDBSZSearch_BCSM" runat="server" CssClass="textbox" Font-Size="11pt" Columns="16" Font-Names="����"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnDBSZQuery" Runat="server" Text="����" CssClass="button" Font-Size="11pt" Font-Name="����"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divDBSZ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 550px; CLIP: rect(0px 550px 430px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 430px">
														<asp:datagrid id="grdDBSZ" runat="server" CssClass="label" Font-Size="11pt" Font-Names="����"
															AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="True"
															CellPadding="4" BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
															UseAccessibleHeader="True">
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
																		<asp:CheckBox id="chkDBSZ" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��λ����" SortExpression="��λ����" HeaderText="������ְ��" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���췶Χ" SortExpression="���췶Χ" HeaderText="���췶Χ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���췶Χ����" SortExpression="���췶Χ����" HeaderText="���췶Χ" CommandName="Select">
																	<HeaderStyle Width="480px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="�������ƴ���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������������" SortExpression="������������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtDBSZFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR align="center">
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZDBSZDeSelectAll" runat="server" Font-Size="11pt" Font-Name="����">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZDBSZSelectAll" runat="server" Font-Size="11pt" Font-Name="����">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZDBSZMoveFirst" runat="server" Font-Size="11pt" Font-Name="����">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZDBSZMovePrev" runat="server" Font-Size="11pt" Font-Name="����">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZDBSZMoveNext" runat="server" Font-Size="11pt" Font-Name="����">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle"><asp:linkbutton id="lnkCZDBSZMoveLast" runat="server" Font-Size="11pt" Font-Name="����">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" noWrap><asp:linkbutton id="lnkCZDBSZGotoPage" runat="server" Font-Size="11pt" Font-Name="����">ǰ��</asp:linkbutton><asp:textbox id="txtDBSZPageIndex" runat="server" CssClass="textbox" Font-Size="11pt" Font-Name="����" Columns="2">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" noWrap><asp:linkbutton id="lnkCZDBSZSetPageSize" runat="server" Font-Size="11pt" Font-Name="����">ÿҳ</asp:linkbutton><asp:textbox id="txtDBSZPageSize" runat="server" CssClass="textbox" Font-Size="11pt" Font-Name="����" Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" align="right"><asp:label id="lblDBSZGridLocInfo" runat="server" CssClass="label" Font-Size="11pt" Font-Name="����">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:Button id="btnDBSZAddNew" Runat="server" Text=" �����趨 " CssClass="button" Font-Size="11pt" Font-Name="����"></asp:Button>
													<asp:Button id="btnDBSZModify" Runat="server" Text=" �����趨 " CssClass="button" Font-Size="11pt" Font-Name="����"></asp:Button>
													<asp:Button id="btnDBSZDelete" Runat="server" Text=" ɾ���趨 " CssClass="button" Font-Size="11pt" Font-Name="����"></asp:Button>
													<asp:Button id="btnDBSZSearch" Runat="server" Text=" ȫ�ļ��� " CssClass="button" Font-Size="11pt" Font-Name="����"></asp:Button>
												</TD>
											</TR>
											<TR>
												<TD height="3"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="6"></TD>
									<TD style="" vAlign="top">
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
												<TD class="label" align="left"><asp:textbox id="txtZWMC" Runat="server" CssClass="textbox" Font-Size="11pt" Font-Name="����" Width="220px"></asp:textbox><asp:LinkButton id="lnkCZSelectZW" Runat="server" CssClass="button"><img src="../../images/glist.gif" border="0" width="16" height="19" align="absmiddle"></asp:LinkButton><INPUT id="htxtZWDM" type="hidden" runat="server"></TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="10"></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" align="left">���췶Χ��</TD>
											</TR>
											<TR>
												<TD class="label" align="left" width="240">
													<asp:DropDownList id="ddlDBFW" Runat="server" Font-Size="11pt" Font-Name="����" Width="100%">
														<asp:ListItem Value="0">������λ</asp:ListItem>
														<asp:ListItem Value="1">ָ���������²���</asp:ListItem>
														<asp:ListItem Value="2">�������Լ��¼�����</asp:ListItem>
													</asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="10"></TD>
											</TR>
											<TR>
												<TD class="labelNotNull" align="left">���췶Χ����˵����</TD>
											</TR>
											<TR>
												<TD class="label" align="left">
													<asp:DropDownList id="ddlBCSM" Runat="server" Font-Size="11pt" Font-Name="����" Width="100%">
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
													<asp:button id="btnSave" Runat="server" Height="24px" Width="96px" Text="����" CssClass="button" Font-Size="11pt" Font-Name="����"></asp:button>
													<asp:button id="btnCancel" Runat="server" Height="24px" Width="96px" Text="ȡ��" CssClass="button" Font-Size="11pt" Font-Name="����"></asp:button>
												</TD>
											</TR>
											<TR>
												<TD class="label" align="center" height="3"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="3"></TD>
								</TR>
								<tr>
									<td colspan="3" height="3"></td>
								</tr>
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
						<input id="htxtSessionIdDBSZQuery" type="hidden" runat="server">
						<input id="htxtCurrentPage" type="hidden" runat="server">
						<input id="htxtCurrentRow" type="hidden" runat="server">
						<input id="htxtEditMode" type="hidden" runat="server">
						<input id="htxtEditType" type="hidden" runat="server">
						<input id="htxtDBSZQuery" type="hidden" runat="server">
						<input id="htxtDBSZRows" type="hidden" runat="server">
						<input id="htxtDBSZSort" type="hidden" runat="server">
						<input id="htxtDBSZSortColumnIndex" type="hidden" runat="server">
						<input id="htxtDBSZSortType" type="hidden" runat="server">
						<input id="htxtDivLeftDBSZ" type="hidden" runat="server">
						<input id="htxtDivTopDBSZ" type="hidden" runat="server">
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
							function ScrollProc_divDBSZ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopDBSZ");
								if (oText != null) oText.value = divDBSZ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftDBSZ");
								if (oText != null) oText.value = divDBSZ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopDBSZ");
								if (oText != null) divDBSZ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftDBSZ");
								if (oText != null) divDBSZ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divDBSZ.onscroll = ScrollProc_divDBSZ;
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
