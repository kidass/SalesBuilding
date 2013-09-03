<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ggdm_bmry.aspx.vb" Inherits="Josco.JsKernal.web.ggdm_bmry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��λ����Ա��Ϣ����</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdBMRYLocked { ; LEFT: expression(divBMRY.scrollLeft); POSITION: relative }
			TH.grdBMRYLocked { ; LEFT: expression(divBMRY.scrollLeft); POSITION: relative }
			TH { Z-INDEX: 10; POSITION: relative }
			TH.grdBMRYLocked { Z-INDEX: 99 }
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
				
				if (document.all("divBMRY") == null)
					return;
				
				dblHeight = 420 + dblDeltaY + document.body.clientHeight - 570; //default state : 420px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 550 + dblDeltaX + document.body.clientWidth  - 850; //default state : 550px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divBMRY.style.width  = strWidth;
				divBMRY.style.height = strHeight;
				divBMRY.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				
				var objTreeView = null;
				dblHeight = 464 + dblDeltaY + document.body.clientHeight - 570; //default state : 464px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				objTreeView = document.getElementById("tvwBMLIST");
				if (objTreeView)
					objTreeView.style.height = strHeight;
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
		<form id="frmGGDM_BMRY" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD colSpan="3" height="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD style="BORDER-BOTTOM: #99cccc 2px solid" align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left" height="24">
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLDWOpen" runat="server" Font-Name="����" Font-Size="11pt">�鿴��λ</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLDWAddNewTJ" runat="server" Font-Name="����" Font-Size="11pt">����ͬ��</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLDWAddNewXJ" runat="server" Font-Name="����" Font-Size="11pt">�����¼�</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLDWAddNewFZ" runat="server" Font-Name="����" Font-Size="11pt">�༭����</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLDWUpdate" runat="server" Font-Name="����" Font-Size="11pt">���ĵ�λ</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLDWDelete" runat="server" Font-Name="����" Font-Size="11pt">ɾ����λ</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLRYOpen" runat="server" Font-Name="����" Font-Size="11pt">�鿴��Ա</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLRYAddNew" runat="server" Font-Name="����" Font-Size="11pt">������Ա</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLRYUpdate" runat="server" Font-Name="����" Font-Size="11pt">������Ա</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLRYDelete" runat="server" Font-Name="����" Font-Size="11pt">ɾ����Ա</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLRYMoveUp" runat="server" Font-Name="����" Font-Size="11pt">��Ա����</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLRYMoveDn" runat="server" Font-Name="����" Font-Size="11pt">��Ա����</asp:linkbutton></TD>
									<TD vAlign="middle" align="center">
										<asp:linkbutton id="lnkMLClose" runat="server" Font-Name="����" Font-Size="11pt">�����ϼ�</asp:linkbutton></TD>
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
									<TD class="tips" align="left" colSpan="5" height="30">&nbsp;&nbsp;����������ͷ�ɽ������򣬵���1��Ϊ�������У��ٵ���1��Ϊ�������У��ٵ���1�λָ���ԭʼ����
										<asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid"
										vAlign="top" align="left">
										<iewc:treeview id="tvwBMLIST" runat="server" Font-Name="����" Font-Size="11pt" Height="464px" Width="240px"
											AutoPostBack="true" CssClass="label"></iewc:treeview></TD>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle">����</TD>
															<TD class="label" align="left">
																<asp:textbox id="txtBMRYSearch_RYMC" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="����"
																	Columns="12"></asp:textbox></TD> <!-- ������ 2008-05-23 -->
															<TD class="label" vAlign="middle">&nbsp;&nbsp;��Ч</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlBMRYSearch_SFYX" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="textbox">
																	<asp:ListItem Value="">δ��</asp:ListItem>
																	<asp:ListItem Value="0">��Ч</asp:ListItem>
																	<asp:ListItem Value="1">��Ч</asp:ListItem>
																</asp:DropDownList></TD> <!-- ������ 2008-05-23 -->
															<TD class="label" vAlign="middle">&nbsp;&nbsp;���</TD>
															<TD class="label" align="left">
																<asp:textbox id="txtBMRYSearch_RYXHMin" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="����"
																	Columns="2"></asp:textbox>~
																<asp:textbox id="txtBMRYSearch_RYXHMax" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="����"
																	Columns="2"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;����</TD>
															<TD class="label" align="left">
																<asp:textbox id="txtBMRYSearch_RYJBMC" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="����"
																	Columns="12"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;ְ��</TD>
															<TD class="label" align="left">
																<asp:textbox id="txtBMRYSearch_RYDRZW" runat="server" Font-Size="11pt" CssClass="textbox" Font-Names="����"
																	Columns="16"></asp:textbox></TD>
															<TD class="label">
																<asp:button id="btnBMRYSearch" Runat="server" Font-Name="����" Font-Size="11pt" Width="50px" CssClass="button"
																	Text="����"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divBMRY" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 550px; CLIP: rect(0px 550px 420px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 420px">
														<asp:datagrid id="grdBMRY" runat="server" Font-Size="11pt" Width="1730px" CssClass="label" Font-Names="����"
															UseAccessibleHeader="True" CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE"
															PageSize="30" BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
															AllowPaging="True">
															<SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000"
																BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold"
																VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold"
																VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
																BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ">
																	<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkBMRY" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��ʶ" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�Ƿ���Ч" SortExpression="�Ƿ���Ч" HeaderText="��Ч" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��֯����" SortExpression="��֯����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ա���" SortExpression="��Ա���" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��λ�б�" SortExpression="��λ�б�" HeaderText="ְ��" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��ϵ�绰" SortExpression="��ϵ�绰" HeaderText="��ϵ�绰" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�ֻ�����" SortExpression="�ֻ�����" HeaderText="�ƶ��绰" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="FTP��ַ" SortExpression="FTP��ַ" HeaderText="�ڲ�����" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�����ַ" SortExpression="�����ַ" HeaderText="����������" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��֯����" SortExpression="��֯����" HeaderText="��֯����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�Զ�ǩ��" SortExpression="�Զ�ǩ��" HeaderText="�Զ�ǩ��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="������ʾ����" SortExpression="������ʾ����" HeaderText="������ʾ����"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�ɲ鿴����" SortExpression="�ɲ鿴����" HeaderText="�ɲ鿴����"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��ֱ����Ա" SortExpression="��ֱ����Ա" HeaderText="��ֱ����Ա"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="������ת��" SortExpression="������ת��" HeaderText="������ת��"
																	CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�Ƿ����" SortExpression="�Ƿ����" HeaderText="�Ƿ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ"
																HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtBMRYFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR>
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZBMRYDeSelectAll" runat="server" Font-Name="����" Font-Size="11pt">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZBMRYSelectAll" runat="server" Font-Name="����" Font-Size="11pt">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZBMRYMoveFirst" runat="server" Font-Name="����" Font-Size="11pt">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZBMRYMovePrev" runat="server" Font-Name="����" Font-Size="11pt">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZBMRYMoveNext" runat="server" Font-Name="����" Font-Size="11pt">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZBMRYMoveLast" runat="server" Font-Name="����" Font-Size="11pt">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZBMRYGotoPage" runat="server" Font-Name="����" Font-Size="11pt">ǰ��</asp:linkbutton>
																<asp:textbox id="txtBMRYPageIndex" runat="server" Font-Name="����" Font-Size="11pt" CssClass="textbox"
																	Columns="3">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left">
																<asp:linkbutton id="lnkCZBMRYSetPageSize" runat="server" Font-Name="����" Font-Size="11pt">ÿҳ</asp:linkbutton>
																<asp:textbox id="txtBMRYPageSize" runat="server" Font-Name="����" Font-Size="11pt" CssClass="textbox"
																	Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" align="right" width="200">
																<asp:label id="lblBMRYGridLocInfo" runat="server" Font-Name="����" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
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
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt"
										align="center">
										<asp:Label id="lblMessage" Runat="server"></asp:Label>
										<P>&nbsp;&nbsp;</P>
										<P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();"
												type="button" value=" ���� "></P>
									</TD>
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
						<input id="htxtBMRYQuery" type="hidden" runat="server"> <input id="htxtBMRYRows" type="hidden" runat="server">
						<input id="htxtBMRYSort" type="hidden" runat="server"> <input id="htxtBMRYSortColumnIndex" type="hidden" runat="server">
						<input id="htxtBMRYSortType" type="hidden" runat="server"> <input id="htxtDivLeftBMRY" type="hidden" runat="server">
						<input id="htxtDivTopBMRY" type="hidden" runat="server"> <input id="htxtDivLeftBody" type="hidden" runat="server">
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
							function ScrollProc_divBMRY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopBMRY");
								if (oText != null) oText.value = divBMRY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftBMRY");
								if (oText != null) oText.value = divBMRY.scrollLeft;
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
								oText=document.getElementById("htxtDivTopBMRY");
								if (oText != null) divBMRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBMRY");
								if (oText != null) divBMRY.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divBMRY.onscroll = ScrollProc_divBMRY;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" height="48px" width="96px" Visible="False"
							ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
