<%@ Page Language="vb" AutoEventWireup="false" Codebehind="dmxz_gzgw.aspx.vb" Inherits="Josco.JsKernal.web.dmxz_gzgw"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ְ��ѡ��</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdZWLISTLocked { ; LEFT: expression(divZWLIST.scrollLeft); POSITION: relative }
			TH.grdZWLISTLocked { ; LEFT: expression(divZWLIST.scrollLeft); POSITION: relative }
			TH.grdZWLISTLocked { Z-INDEX: 99 }
			TD.grdZWSELLocked { ; LEFT: expression(divZWSEL.scrollLeft); POSITION: relative }
			TH.grdZWSELLocked { ; LEFT: expression(divZWSEL.scrollLeft); POSITION: relative }
			TH.grdZWSELLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
			function window_onresize() 
			{
				var dblHeight  = 0;
				var dblWidth   = 0;
				var strHeight  = "";
				var strWidth   = "";
				var dblDeltaY  = 20;
				
				if (document.all("divZWLIST") == null)
					return;
				
				dblHeight = 350 + dblDeltaY + document.body.clientHeight - 570; //default state : 350px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				strWidth  = divZWLIST.style.width;
				divZWLIST.style.height = strHeight;
				divZWLIST.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				dblHeight = 370 + dblDeltaY + document.body.clientHeight - 570; //default state : 370px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				strWidth  = divZWSEL.style.width;
				divZWSEL.style.height = strHeight;
				divZWSEL.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmDMXZ_GZGW" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD colSpan="3" height="3"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left" height="30">
									<TD class="label" vAlign="middle" align="center"><asp:Label id="lblTitle" Runat="server" Font-Bold="True" Font-Size="11pt" Font-Name="����">ְ��ѡ��</asp:Label><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="2"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="3" height="30">&nbsp;&nbsp;����������ͷ�ɽ������򣬵���1��Ϊ�������У��ٵ���1��Ϊ�������У��ٵ���1�λָ���ԭʼ����</TD>
								</TR>
								<TR>
									<TD class="label" align="center" colSpan="3" height="3"></TD>
								</TR>
								<tr>
								    <td valign="top" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
								        <TABLE cellSpacing="0" cellPadding="0" border="0">
								            <tr>
												<TD class="label" align="center">--- ����ְ��һ���� ---</TD>
								            </tr>
								            <tr>
												<TD class="label" align="left" height="24">&nbsp;&nbsp;��������<asp:TextBox id="txtSearchZWMC" Runat="server" Columns="16" CssClass="textbox"></asp:TextBox><asp:Button id="btnSearch" Runat="server" CssClass="button" Text=" ���� "></asp:Button></TD>
								            </tr>
								            <tr>
												<TD vAlign="top" align="left">
													<DIV id="divZWLIST" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 300px; CLIP: rect(0px 300px 350px 0px); HEIGHT: 350px;">
														<asp:datagrid id="grdZWLIST" runat="server" Font-Size="11pt" CssClass="label" BorderColor="#DEDFDE"
															BorderWidth="0px" AllowSorting="True" PageSize="30" AllowPaging="False" CellPadding="4" BorderStyle="None"
															BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
															Font-Names="����">
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<Columns>
																<asp:ButtonColumn Visible="False" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��λ����" SortExpression="��λ����" HeaderText="ְ��" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtZWLISTFixed" type="hidden" value="0" runat="server" NAME="htxtZWLISTFixed"></DIV>
												</TD>
								            </tr>
								        </table>
								    </td>
									<TD align="center" width="120" valign="middle">
										<asp:Button id="btnSelectOne" Runat="server" CssClass="button" Text=" > " Height="36px" Width="80px"></asp:Button><BR>
										<asp:Button id="btnSelectAll" Runat="server" CssClass="button" Text=" >> " Height="36px" Width="80px"></asp:Button><BR>
										<asp:Button id="btnDeleteOne" Runat="server" CssClass="button" Text=" < " Height="36px" Width="80px"></asp:Button><BR>
										<asp:Button id="btnDeleteAll" Runat="server" CssClass="button" Text=" << " Height="36px" Width="80px"></asp:Button><BR>
										<asp:Button id="btnMoveUp" Runat="server" CssClass="button" Text=" �� " Height="36px" Width="80px"></asp:Button><BR>
										<asp:Button id="btnMoveDown" Runat="server" CssClass="button" Text=" �� " Height="36px" Width="80px"></asp:Button>
									</TD>
								    <td valign="top" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
								        <TABLE cellSpacing="0" cellPadding="0" border="0">
								            <tr>
												<TD class="label" align="center">--- ��ѡ���ְ�� ---</TD>
								            </tr>
								            <tr>
								                <td height="24" class="label" align="center">--- һ���� ---</td>
								            </tr>
								            <tr>
												<TD class="label" vAlign="top" align="left">
													<DIV id="divZWSEL" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 300px; CLIP: rect(0px 300px 370px 0px); HEIGHT: 370px;">
														<asp:datagrid id="grdZWSEL" runat="server" Font-Size="11pt" CssClass="label" BorderColor="#DEDFDE"
															BorderWidth="0px" AllowSorting="True" PageSize="30" AllowPaging="True" CellPadding="4" BorderStyle="None"
															BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
															Font-Names="����">
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<Columns>
																<asp:ButtonColumn DataTextField="��λ����" SortExpression="��λ����" HeaderText="ְ��" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtZWSELFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
								            </tr>
								        </table>
								    </td>
								</tr>
								<TR>
									<TD colSpan="3" height="6"></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3">
										<asp:button id="btnOK" Runat="server" Font-Size="11pt" Font-Name="����" CssClass="button" Text=" ȷ  �� " Height="36px" Width="96px"></asp:button>
										<asp:button id="btnCancel" Runat="server" Font-Size="11pt" Font-Name="����" CssClass="button" Text=" ȡ  �� " Height="36px" Width="96px"></asp:button>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3" height="3"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
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
						<input id="htxtSessionIdZWSEL" type="hidden" runat="server">
						<input id="htxtZWSELSort" type="hidden" runat="server">
						<input id="htxtZWSELSortColumnIndex" type="hidden" runat="server">
						<input id="htxtZWSELSortType" type="hidden" runat="server">
						<input id="htxtZWLISTQuery" type="hidden" runat="server">
						<input id="htxtZWLISTSort" type="hidden" runat="server">
						<input id="htxtZWLISTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtZWLISTSortType" type="hidden" runat="server">
						<input id="htxtDivLeftZWSEL" type="hidden" runat="server">
						<input id="htxtDivTopZWSEL" type="hidden" runat="server">
						<input id="htxtDivLeftZWLIST" type="hidden" runat="server">
						<input id="htxtDivTopZWLIST" type="hidden" runat="server">
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
							function ScrollProc_divZWLIST() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopZWLIST");
								if (oText != null) oText.value = divZWLIST.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftZWLIST");
								if (oText != null) oText.value = divZWLIST.scrollLeft;
								return;
							}
							function ScrollProc_divZWSEL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopZWSEL");
								if (oText != null) oText.value = divZWSEL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftZWSEL");
								if (oText != null) oText.value = divZWSEL.scrollLeft;
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
								oText=document.getElementById("htxtDivTopZWLIST");
								if (oText != null) divZWLIST.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftZWLIST");
								if (oText != null) divZWLIST.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopZWSEL");
								if (oText != null) divZWSEL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftZWSEL");
								if (oText != null) divZWSEL.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divZWLIST.onscroll = ScrollProc_divZWLIST;
								divZWSEL.onscroll = ScrollProc_divZWSEL;
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
