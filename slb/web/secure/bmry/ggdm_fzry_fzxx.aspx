<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ggdm_fzry_fzxx.aspx.vb" Inherits="Josco.JsKernal.web.ggdm_fzry_fzxx"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��λ������Ϣ�༭����ʾ��</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/bgmain.gif">
		<form id="frmGGDM_FZRY_FZXX" method="post" runat="server">
			<asp:Panel ID="panelMain" Runat="server">
				<TABLE height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="title" style="BORDER-BOTTOM: #99cccc 1px solid" vAlign="middle" align="center" colSpan="3" height="30">��λ������Ϣ��ʾ��༭��<asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD width="5%"></TD>
						<TD vAlign="top" align="center">
							<TABLE height="70%" cellSpacing="0" cellPadding="0" border="0">
								<TR vAlign="middle" align="center">
									<TD class="tips" align="left" colSpan="2" height="30">������Դ���ɫ*�ŵ����ݱ������룬������ɺ�[ȷ��]���沢���ء�</TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">��λ���ƣ�</TD>
									<TD class="label" align="left"><asp:textbox id="txtZZMC" runat="server" Height="24px" CssClass="textbox" Columns="60" Font-Names="����" Font-Size="11pt" Wrap="False" Enabled="False"></asp:textbox><INPUT id="htxtZZDM" type="hidden" name="htxtZZDM" runat="server"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" align="right">�������ƣ�</TD>
									<TD class="labelNotNull" align="left"><SPAN class="labelNotNull"><asp:textbox id="txtFZMC" runat="server" Height="24px" CssClass="textbox" Columns="60" Font-Names="����" Font-Size="11pt"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
								</TR>
								<TR vAlign="middle" align="center">
									<TD class="label" colSpan="2" height="10"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5%"></TD>
					</TR>
					<TR vAlign="middle">
						<TD colSpan="3" height="6"></TD>
					</tr>
					<TR vAlign="middle">
						<TD style="BORDER-TOP: #99cccc 1px solid" align="center" colSpan="3">
							<asp:button id="btnOK" Runat="server" Width="94" Height="36" CssClass="button" Font-Names="����" Font-Size="11pt" Text=" ȷ  �� "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnCancel" Runat="server" Width="94px" Height="36px" CssClass="button" Font-Names="����" Font-Size="11pt" Text=" ȡ  �� "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnClose" Runat="server" Width="94px" Height="36px" CssClass="button" Font-Names="����" Font-Size="11pt" Text=" ��  �� "></asp:button>
						</TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();" type="button" value=" ���� "></P></TD>
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
						<uwin:popmessage id="popMessageObject" runat="server" width="96px" height="48px" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False" Visible="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
