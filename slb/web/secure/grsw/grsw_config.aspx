<%@ Page Language="vb" AutoEventWireup="false" Codebehind="grsw_config.aspx.vb" Inherits="Josco.JsKernal.web.grsw_config" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�������в�������</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="../../scripts/transkey.js"></script>
		<LINK href="../../styleDef01.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="frmgrsw_config" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%" height="90%">
					<TR>
						<TD width="3"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0" height="100%" width="80%">
								<TR>
									<TD class="titleLF" style="BORDER-BOTTOM: #6699cc thin solid" vAlign="middle" align="center" colSpan="3" height="36"><B>�ҵ���������һ����</B><asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="3"></TD>
									<TD vAlign="top" align="center">
										<TABLE cellSpacing="0" cellPadding="0" border="0" height="100%" width="80%">
											<TR>
												<TD width="40%"></TD>
												<TD width="40%"></TD>
											</TR>
											<TR>
												<TD class="labelLF" noWrap align="right">ϵͳ����ѡ�</TD>
												<TD align="left">
													<asp:RadioButtonList id="rblStartupOption" Runat="server" RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="2" CssClass="textboxLF">
														<asp:ListItem Value="0">�ڲ���ҳ</asp:ListItem>
														<asp:ListItem Value="1">�ҵ�����</asp:ListItem>
													</asp:RadioButtonList>
												</TD>
											</TR>
											<TR>
												<TD height="4"></TD>
												<TD height="4"></TD>
											</TR>
											<TR>
												<TD class="labelLF" noWrap align="right">״̬�����Զ�ˢ�¿��أ�</TD>
												<TD align="left">
													<asp:RadioButtonList id="rblStatusRefresh" Runat="server" RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="2" CssClass="textboxLF">
														<asp:ListItem Value="1">��</asp:ListItem>
														<asp:ListItem Value="0">�ر�</asp:ListItem>
													</asp:RadioButtonList>
												</TD>
											</TR>
											<TR>
												<TD height="4"></TD>
												<TD height="4"></TD>
											</TR>
											<TR>
												<TD class="labelLF" noWrap align="right">״̬�����Զ�ˢ�¼��(>=300��)��</TD>
												<TD align="left"><asp:TextBox id="txtStatusRefresh" Runat="server" CssClass="textboxLF" Columns="8"></asp:TextBox><input id="htxtStatusRefresh" type="hidden" runat="server" value="300"></TD>
											</TR>
											<TR>
												<TD height="4"></TD>
												<TD height="4"></TD>
											</TR>
											<TR>
												<TD class="labelLF" noWrap align="right">��ʱ����֪ͨ�����Զ�ˢ�¿��أ�</TD>
												<TD align="left">
													<asp:RadioButtonList id="rblNoticeRefresh" Runat="server" RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="2" CssClass="textboxLF">
														<asp:ListItem Value="1">��</asp:ListItem>
														<asp:ListItem Value="0">�ر�</asp:ListItem>
													</asp:RadioButtonList>
												</TD>
											</TR>
											<TR>
												<TD height="4"></TD>
												<TD height="4"></TD>
											</TR>
											<TR>
												<TD class="labelLF" noWrap align="right">��ʱ����֪ͨ�����Զ�ˢ�¼��(>=90��)��</TD>
												<TD align="left"><asp:TextBox id="txtNoticeRefresh" Runat="server" CssClass="textboxLF" Columns="8"></asp:TextBox><input id="htxtNoticeRefresh" type="hidden" runat="server" value="90"></TD>
											</TR>
											<TR>
												<TD height="4"></TD>
												<TD height="4"></TD>
											</TR>
											<TR>
												<TD class="labelLF" noWrap align="right">��ʱ�������������Զ�ˢ�£�</TD>
												<TD align="left">
													<asp:RadioButtonList id="rblChatRefresh" Runat="server" RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="2" CssClass="textboxLF">
														<asp:ListItem Value="1">��</asp:ListItem>
														<asp:ListItem Value="0">�ر�</asp:ListItem>
													</asp:RadioButtonList>
												</TD>
											</TR>
											<TR>
												<TD height="4"></TD>
												<TD height="4"></TD>
											</TR>
											<TR>
												<TD class="labelLF" noWrap align="right">��ʱ�������������Զ�ˢ�¼��(>=5��)��</TD>
												<TD align="left"><asp:TextBox id="txtChatRefresh" Runat="server" CssClass="textboxLF" Columns="8"></asp:TextBox><input id="htxtChatRefresh" type="hidden" runat="server" value="5"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="3"></TD>
								</TR>
								<TR>
									<TD colSpan="5" height="4"></TD>
								</TR>
								<TR>
									<TD class="tips" vAlign="middle" align="center" colSpan="3" height="36" style="BORDER-TOP: #6699cc thin solid">
										<asp:button id="btnSave" Runat="server" Height="30px" CssClass="button" Text=" �� �� "></asp:button>
										<asp:button id="btnCancel" Runat="server" Height="30px" CssClass="button" Text=" ȡ �� "></asp:button>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="3"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
			</asp:Panel>
			<table cellSpacing="0" cellPadding="0" align="center" border="0">
				<tr>
					<td>
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
							try {
								var Text;

								oText=null;
								oText=document.getElementById("htxtDivTopBody");
								if (oText != null) document.body.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBody");
								if (oText != null) document.body.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
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
