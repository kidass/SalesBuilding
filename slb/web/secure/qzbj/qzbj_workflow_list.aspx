<%@ Page Language="vb" AutoEventWireup="false" Codebehind="qzbj_workflow_list.aspx.vb" Inherits="Josco.JsKernal.web.qzbj_workflow_list" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�������ļ�ǿ�Ʊ༭</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles01.css" type="text/css" rel="stylesheet">
		<link href="../../mnuStyle01.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdWFLISTLocked { ; LEFT: expression(divWFLIST.scrollLeft); POSITION: relative }
			TH.grdWFLISTLocked { ; LEFT: expression(divWFLIST.scrollLeft); POSITION: relative }
			TH.grdWFLISTLocked { Z-INDEX: 99 }
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
				
				if (document.all("divWFLIST") == null)
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
				document.all("divWFLIST").style.width  = strWidth;
				document.all("divWFLIST").style.height = strHeight;
				document.all("divWFLIST").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
				return window_onresize();
			}
		//-->
		</script>
		<script language="javascript" event="onreadystatechange" for="document">
		<!--
			return document_onreadystatechange()
		//-->
		</script>
	</HEAD>
	<body onresize="return window_onresize()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="frmqzbj_workflow_list" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR id="trRow1">
						<TD width="4"><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
						<td class="title" align="center" valign="middle" height="36">�������ļ����⴦��</td>
						<TD width="4"></td>
					</TR>
					<TR>
						<TD width="4"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow2">
												<TD align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle">��ˮ��&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtWFLISTSearch_LSH" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;����&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlWFLISTSearch_WJLX" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle">&nbsp;����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtWFLISTSearch_WJBT" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;�ĺ�&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtWFLISTSearch_WJZH" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;���쵥λ&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtWFLISTSearch_ZBDW" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;�ļ�����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtWFLISTSearch_WJRQMin" runat="server" CssClass="textbox" Columns="8"></asp:textbox>~<asp:textbox id="txtWFLISTSearch_WJRQMax" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label">&nbsp;<asp:button id="btnWFLISTSearch" Runat="server" CssClass="button" Text="��������"></asp:button><asp:button id="btnWFLISTSearchFull" Runat="server" CssClass="button" Text="ȫ������"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divWFLIST" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 980px; CLIP: rect(0px 980px 524px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 524px">
														<asp:datagrid id="grdWFLIST" runat="server" Width="1800px" CssClass="label" Font-Size="12px" Font-Names="����"
															UseAccessibleHeader="True" AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical"
															BackColor="White" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px"
															AllowSorting="True" CellPadding="4">
															<SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWFLIST" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�ļ���ʶ" SortExpression="�ļ���ʶ" HeaderText="�ļ���ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�ļ�����" SortExpression="�ļ�����" HeaderText="�ļ�����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�ļ�����" SortExpression="�ļ�����" HeaderText="�ļ�����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��ˮ��" SortExpression="��ˮ��" HeaderText="��ˮ��" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�ļ����" SortExpression="�ļ����" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�ļ�����" SortExpression="�ļ�����" HeaderText="����" CommandName="OpenDocument">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�ļ��ֺ�" SortExpression="�ļ��ֺ�" HeaderText="�ĺ�" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���͵�λ" SortExpression="���͵�λ" HeaderText="����/���ĵ�λ" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�����̶�" SortExpression="�����̶�" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���ܵȼ�" SortExpression="���ܵȼ�" HeaderText="�ܼ�" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�����" SortExpression="�����" HeaderText="�����" CommandName="Select">
																	<HeaderStyle Width="260px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="���쵥λ" SortExpression="���쵥λ" HeaderText="���쵥λ" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�����" SortExpression="�����" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="����״̬" SortExpression="����״̬" HeaderText="����״̬" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���ش���" SortExpression="���ش���" HeaderText="���ش���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�ļ����" SortExpression="�ļ����" HeaderText="�ļ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�ļ����" SortExpression="�ļ����" HeaderText="�ļ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtWFLISTFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD>
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWFLISTDeSelectAll" runat="server">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWFLISTSelectAll" runat="server">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWFLISTMoveFirst" runat="server">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWFLISTMovePrev" runat="server">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWFLISTMoveNext" runat="server">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWFLISTMoveLast" runat="server">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWFLISTGotoPage" runat="server">ǰ��</asp:linkbutton><asp:textbox id="txtWFLISTPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWFLISTSetPageSize" runat="server">ÿҳ</asp:linkbutton><asp:textbox id="txtWFLISTPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblWFLISTGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="4"></TD>
					</TR>
					<tr id="trRow4">
						<TD width="4"></TD>
					    <td align="center">
					        <asp:Button ID="btnXGWJ"   Runat="server" CssClass="button" Text="�޸���ϸ����" Height="36px"></asp:Button>
					        <asp:Button ID="btnJJQK"   Runat="server" CssClass="button" Text="�ļ��������" Height="36px"></asp:Button>
					        <asp:Button ID="btnSPQK"   Runat="server" CssClass="button" Text="�ļ��������" Height="36px"></asp:Button>
					        <asp:Button ID="btnDelete" Runat="server" CssClass="button" Text="ɾ  �� �� ��" Height="36px"></asp:Button>
					        <asp:Button ID="btnClose"  Runat="server" CssClass="button" Text="��        ��" Height="36px"></asp:Button>
					    </td>
						<TD width="4"></TD>
					</tr>
				</TABLE>
			</asp:panel>
			<asp:panel id="panelError" Runat="server">
				<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE id="tabErrInfo" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();" type="button" value=" ���� "></P></TD>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5%"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<table cellSpacing="0" cellPadding="0" align="center" border="0">
				<tr>
					<td>
						<input id="htxtWFLISTSessionIdQuery" type="hidden" runat="server">
						<input id="htxtWFLISTQuery" type="hidden" runat="server">
						<input id="htxtWFLISTRows" type="hidden" runat="server">
						<input id="htxtWFLISTSort" type="hidden" runat="server">
						<input id="htxtWFLISTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtWFLISTSortType" type="hidden" runat="server">
						<input id="htxtDivLeftWFLIST" type="hidden" runat="server">
						<input id="htxtDivTopWFLIST" type="hidden" runat="server">
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
							function ScrollProc_divWFLIST() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopWFLIST");
								if (oText != null) oText.value = divWFLIST.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftWFLIST");
								if (oText != null) oText.value = divWFLIST.scrollLeft;
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
								oText=document.getElementById("htxtDivTopWFLIST");
								if (oText != null) divWFLIST.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftWFLIST");
								if (oText != null) divWFLIST.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divWFLIST.onscroll = ScrollProc_divWFLIST;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" Visible="False" width="96px" height="48px"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
