<%@ Page Language="vb" AutoEventWireup="false" Codebehind="qzbj_workflow_jjxx.aspx.vb" Inherits="Josco.JsKernal.web.qzbj_workflow_jjxx" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�ļ���ת����༭��</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles01.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdLZXXLocked { ; LEFT: expression(divLZXX.scrollLeft); POSITION: relative }
			TH.grdLZXXLocked { ; LEFT: expression(divLZXX.scrollLeft); POSITION: relative }
			TH.grdLZXXLocked { Z-INDEX: 99 }
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
				
				if (document.all("divLZXX") == null)
					return;


				intWidth   = document.body.clientWidth;   //�ܿ��
				intWidth  -= 24;                          //������
				intWidth  -= 2 * 4;                       //���ҿհ�
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 8;                           //������
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
				//    window.alert(strWidth + " " + strHeight);
				document.all("divLZXX").style.width  = strWidth;
				document.all("divLZXX").style.height = strHeight;
				document.all("divLZXX").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmqzbj_workflow_jjxx" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="4"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="center" colSpan="3" height="36" valign="middle">�ļ���ת����༭<asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="4"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow2">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle">������&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtLZXXSearch_FSR" runat="server" CssClass="textbox" Columns="16"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;������&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtLZXXSearch_JSR" runat="server" CssClass="textbox" Columns="16"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtLZXXSearch_BLSY" runat="server" CssClass="textbox" Columns="16"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;�������&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtLZXXSearch_WCRQMin" runat="server" CssClass="textbox" Columns="12"></asp:textbox>~<asp:textbox id="txtLZXXSearch_WCRQMax" runat="server" CssClass="textbox" Columns="12"></asp:textbox></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnLZXXSearch" Runat="server" CssClass="button" Text="��������"></asp:button><asp:button id="btnLZXXSearchFull" Runat="server" CssClass="button" Text="ȫ������"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divLZXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 980px; CLIP: rect(0px 980px 524px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 524px;">
														<asp:datagrid id="grdLZXX" runat="server" Width="2320px" Font-Size="12px" CssClass="label" Font-Names="����"
															CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
															BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
															UseAccessibleHeader="True">
															<SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkLZXX" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
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
																<asp:ButtonColumn DataTextField="�������" SortExpression="�������" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="Э��" SortExpression="Э��" HeaderText="Э��" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:TemplateColumn HeaderText="��������">
																	<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtLZXX_BLSY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="����״̬">
																	<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtLZXX_BLZT" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="ί����" SortExpression="ί����" HeaderText="ί����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�����������" SortExpression="�����������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ֽ���ļ�" SortExpression="����ֽ���ļ�" HeaderText="����ֽ���ļ�����" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���͵����ļ�" SortExpression="���͵����ļ�" HeaderText="���͵����ļ�����" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ֽ�ʸ���" SortExpression="����ֽ�ʸ���" HeaderText="����ֽ�ʸ�������" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���͵��Ӹ���" SortExpression="���͵��Ӹ���" HeaderText="���͵��Ӹ�������" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ֽ���ļ�" SortExpression="����ֽ���ļ�" HeaderText="����ֽ���ļ�����" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���յ����ļ�" SortExpression="���յ����ļ�" HeaderText="���յ����ļ�����" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����ֽ�ʸ���" SortExpression="����ֽ�ʸ���" HeaderText="����ֽ�ʸ�������" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���յ��Ӹ���" SortExpression="���յ��Ӹ���" HeaderText="���յ��Ӹ�������" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���ӱ�ʶ" SortExpression="���ӱ�ʶ" HeaderText="���ӱ�ʶ" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtLZXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD>
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXDeSelectAll" runat="server">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXSelectAll" runat="server">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXMoveFirst" runat="server">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXMovePrev" runat="server">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXMoveNext" runat="server">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXMoveLast" runat="server">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXGotoPage" runat="server">ǰ��</asp:linkbutton><asp:textbox id="txtLZXXPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZLZXXSetPageSize" runat="server">ÿҳ</asp:linkbutton><asp:textbox id="txtLZXXPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblLZXXGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
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
					<TR id="trRow4">
						<TD colSpan="3" align="center">
							<asp:Button id="btnUpdate" Runat="server" Height="36px" CssClass="button" Text=" ��    �� "></asp:Button>
							<asp:Button id="btnClose"  Runat="server" Height="36px" CssClass="button" Text=" ��    �� "></asp:Button>
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
						<input id="htxtLZXXSessionIdQuery" type="hidden" runat="server">
						<input id="htxtLZXXQuery" type="hidden" runat="server">
						<input id="htxtLZXXRows" type="hidden" runat="server">
						<input id="htxtLZXXSort" type="hidden" runat="server">
						<input id="htxtLZXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtLZXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftLZXX" type="hidden" runat="server">
						<input id="htxtDivTopLZXX" type="hidden" runat="server">
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
							function ScrollProc_divLZXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopLZXX");
								if (oText != null) oText.value = divLZXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftLZXX");
								if (oText != null) oText.value = divLZXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopLZXX");
								if (oText != null) divLZXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftLZXX");
								if (oText != null) divLZXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divLZXX.onscroll = ScrollProc_divLZXX;
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
