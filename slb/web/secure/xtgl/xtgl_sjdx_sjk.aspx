<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="xtgl_sjdx_sjk.aspx.vb" Inherits="Josco.JsKernal.web.xtgl_sjdx_sjk" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>���ݿ���Ϣ��ʾ��༭��</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/bgmain.gif">
		<form id="frmSJDXGL_SJK" method="post" runat="server">
			<asp:Panel ID="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="98%">
					<TR>
						<TD width="5%"></TD>
						<TD></TD>
						<TD width="5%"></TD>
					</TR>
					<TR>
						<TD class="title" vAlign="middle" align="center" colSpan="3" height="30" style="BORDER-BOTTOM: #99cccc 1px solid">���ݿ���Ϣ�鿴��༭��<asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD width="5%"></TD>
						<TD></TD>
						<TD width="5%"></TD>
					</TR>
					<TR>
						<TD width="5%"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" align="left"></TD>
									<TD class="label" align="left"></TD>
								</TR>
								<TR vAlign="middle" align="center">
									<TD class="tips" align="left" colSpan="2">������Դ���ɫ*�ŵ����ݱ������룬������ɺ�[ȷ��]���沢���ء�</TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" style="HEIGHT: 22px" align="right" height="32">���������ƣ�</TD>
									<TD class="labelNotNull" style="HEIGHT: 22px" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtFWQMC" runat="server" Height="24px" CssClass="textbox" Columns="36" Font-Names="����" Font-Size="11pt" Wrap="False"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" align="right" height="32">���ݿ����ƣ�</TD>
									<TD class="labelNotNull" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtSJKMC" runat="server" Height="24px" CssClass="textbox" Columns="36" Font-Names="����" Font-Size="11pt" Wrap="False"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" style="HEIGHT: 32px" align="right" height="32">���ݿ���������</TD>
									<TD class="labelNotNull" style="HEIGHT: 32px" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtSJKZWM" runat="server" Height="24px" CssClass="textbox" Columns="36" Font-Names="����" Font-Size="11pt" Wrap="False"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN>&nbsp;&nbsp;
									</TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" vAlign="top" align="right" height="32">˵����</TD>
									<TD class="label" align="left" height="32"><asp:textbox id="txtSJKSM" runat="server" Height="136px" CssClass="textbox" Columns="60" Font-Names="����" Font-Size="11pt" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5%"></TD>
					</TR>
					<TR vAlign="middle">
						<TD width="5%"></TD>
						<TD class="label" align="center" height="20">&nbsp;</TD>
						<TD width="5%"></TD>
					</TR>
					<TR vAlign="middle">
						<TD align="center" colSpan="3" height="30" style="BORDER-TOP: #99cccc 1px solid">
							<asp:button id="btnOK" Runat="server" Height="36" Width="94" CssClass="button"
								Font-Names="����" Font-Size="11pt" Text=" ȷ  �� "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnCancel" Runat="server" Height="36px" Width="94px" CssClass="button"
								Font-Names="����" Font-Size="11pt" Text=" ȡ  �� "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnClose" Runat="server" Height="36px" Width="94px" CssClass="button"
								Font-Names="����" Font-Size="11pt" Text=" ��  �� "></asp:button>
						</TD>
					</TR>
				</TABLE>
			</asp:Panel>
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
						<uwin:popmessage id="popMessageObject" runat="server" width="96px" height="48px" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False" Visible="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
