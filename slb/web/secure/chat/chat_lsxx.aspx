<%@ Page Language="vb" AutoEventWireup="false" Codebehind="chat_lsxx.aspx.vb" Inherits="Josco.JsKernal.web.chat_lsxx"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��ʱ������ʷ�鿴��</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<style>
			TD.grdJSXXLocked { ; LEFT: expression(divJSXX.scrollLeft); POSITION: relative }
			TH.grdJSXXLocked { ; LEFT: expression(divJSXX.scrollLeft); POSITION: relative }
			TH.grdJSXXLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script language="javascript">
			function document_onreadystatechange() 
			{
				var objUrlControl = null;
				var objControl = null;
				//auto close current window
				objControl = document.getElementById("htxtCloseWindow");
				if (objControl)
				{
					if (objControl.value == "1")
					{
						objControl = document.getElementById("htxtReturnUrl");
						if (objControl)
						{
							objUrlControl = window.opener.document.getElementById("htxtOpenUrl");
							if (objUrlControl)
							{
								objUrlControl.value = objControl.value;
								window.opener.execScript("doOpenUrl();");
							}
						}
						window.close();
					}
				}
			}
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
			return document_onreadystatechange()
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="frmCHAT_LSXX" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"><asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
						<TD align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left" height="24">
									<TD vAlign="middle" noWrap><asp:linkbutton id="lnkMLSetYYD" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/GWYBW.ICO" alt="" border="0" width="16" height="16" align="absmiddle">�����Ѷ�</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap><asp:linkbutton id="lnkMLDelete" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/delete.gif" alt="" border="0" width="16" height="16" align="absmiddle">ɾ����Ϣ</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap><asp:linkbutton id="lnkMLExport" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/export.ico" alt="" border="0" width="16" height="16" align="absmiddle">������Ϣ</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap><asp:linkbutton id="lnkMLSearch" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/FIND.GIF" alt="" border="0" width="16" height="16" align="absmiddle">ȫ�ļ���</asp:linkbutton></TD>
									<TD vAlign="middle" noWrap><asp:linkbutton id="lnkMLReturn" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/close.gif" alt="" border="0" width="16" height="16" align="absmiddle">��ȫ����</asp:linkbutton></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="3" height="30">&nbsp;&nbsp;����������ͷ�ɽ������򣬵���1��Ϊ�������У��ٵ���1��Ϊ�������У��ٵ���1�λָ���ԭʼ����</TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSXXDeSelectAll" runat="server" Font-Name="����" Font-Size="11pt">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSXXSelectAll" runat="server" Font-Name="����" Font-Size="11pt">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSXXMoveFirst" runat="server" Font-Name="����" Font-Size="11pt">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSXXMovePrev" runat="server" Font-Name="����" Font-Size="11pt">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSXXMoveNext" runat="server" Font-Name="����" Font-Size="11pt">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSXXMoveLast" runat="server" Font-Name="����" Font-Size="11pt">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left" noWrap><asp:linkbutton id="lnkCZJSXXGotoPage" runat="server" Font-Name="����" Font-Size="11pt">ǰ��</asp:linkbutton><asp:textbox id="txtJSXXPageIndex" runat="server" Font-Name="����" Font-Size="11pt" Columns="3" CssClass="textbox">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left" noWrap><asp:linkbutton id="lnkCZJSXXSetPageSize" runat="server" Font-Name="����" Font-Size="11pt">ÿҳ</asp:linkbutton><asp:textbox id="txtJSXXPageSize" runat="server" Font-Name="����" Font-Size="11pt" Columns="3" CssClass="textbox">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" align="right"><asp:label id="lblJSXXGridLocInfo" runat="server" Font-Name="����" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" noWrap>������</TD>
															<TD class="label" align="left"><asp:textbox id="txtJSXXSearch_FSR" runat="server" Font-Size="11pt" Columns="6" CssClass="textbox" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" noWrap>������</TD>
															<TD class="label" align="left"><asp:textbox id="txtJSXXSearch_JSR" runat="server" Font-Size="11pt" Columns="6" CssClass="textbox" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" noWrap>��Ϣ</TD>
															<TD class="label" align="left"><asp:textbox id="txtJSXXSearch_XX" runat="server" Font-Size="11pt" Columns="12" CssClass="textbox" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" noWrap>����ʱ��</TD>
															<TD class="label" align="left"><asp:textbox id="txtJSXXSearch_FSSJMin" runat="server" Font-Size="11pt" Columns="10" CssClass="textbox" Font-Names="����"></asp:textbox><asp:textbox id="txtJSXXSearch_FSSJMax" runat="server" Font-Size="11pt" Columns="10" CssClass="textbox" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" noWrap>����</TD>
															<TD class="label" align="left"><asp:textbox id="txtJSXXSearch_FJNR" runat="server" Font-Size="11pt" Columns="12" CssClass="textbox" Font-Names="����"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnJSXXSearch" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text="����"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divJSXX" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 800px; CLIP: rect(0px 800px 435px 0px); HEIGHT: 435px; BACKGROUND-COLOR: white">
														<asp:datagrid id="grdJSXX" runat="server" Font-Size="11pt" CssClass="label" Font-Names="����" UseAccessibleHeader="True"
															AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None"
															PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4" Width="780px">
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
																		<asp:CheckBox id="chkJSXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��ˮ��" SortExpression="��ˮ��" HeaderText="��ˮ��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ʱ��" SortExpression="����ʱ��" HeaderText="����ʱ��" CommandName="Select"
																	DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�Ѷ�״̬" SortExpression="�Ѷ�״̬" HeaderText="�Ѷ�" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ϣ" SortExpression="��Ϣ" HeaderText="��Ϣ" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:BoundColumn DataField = "����" HeaderText="����" SortExpression="����" HeaderStyle-Width="160px"></asp:BoundColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��־" SortExpression="��־" HeaderText="��־" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��ʾ" SortExpression="��ʾ" HeaderText="��ʾ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtJSXXFixed" type="hidden" value="0" runat="server"></DIV>
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
						<input id="htxtCloseWindow" type="hidden" runat="server" value="0">
						<input id="htxtReturnUrl" type="hidden" runat="server">
						<input id="htxtSessionIdJSXXQuery" type="hidden" runat="server">
						<input id="htxtJSXXQuery" type="hidden" runat="server">
						<input id="htxtJSXXRows" type="hidden" runat="server">
						<input id="htxtJSXXSort" type="hidden" runat="server">
						<input id="htxtJSXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtJSXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftJSXX" type="hidden" runat="server">
						<input id="htxtDivTopJSXX" type="hidden" runat="server">
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
							function ScrollProc_divJSXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJSXX");
								if (oText != null) oText.value = divJSXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSXX");
								if (oText != null) oText.value = divJSXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopJSXX");
								if (oText != null) divJSXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSXX");
								if (oText != null) divJSXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divJSXX.onscroll = ScrollProc_divJSXX;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<uwin:popmessage id="popMessageObject" runat="server" height="48px" width="96px" Visible="False" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
