<%@ Page Language="vb" AutoEventWireup="false" Codebehind="xtgl_mkgl_info.aspx.vb" Inherits="Josco.JsKernal.web.xtgl_mkgl_info" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ģ����Ϣ��ʾ��༭��</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript" id="clientEventHandlersJS">
            function document_onreadystatechange() 
            {
                try {
                    var objCtl = document.getElementById("txtMKDM");
                    objCtl.focus(); 
                }
                catch (e) {}
            }
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
            return document_onreadystatechange()
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/bgmain.gif">
		<form id="frmMKGL_INFO" method="post" runat="server">
			<asp:Panel ID="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="98%">
					<TR>
						<TD width="5%"></TD>
						<TD></TD>
						<TD width="5%"></TD>
					</TR>
					<TR>
						<TD class="title" vAlign="middle" align="center" colSpan="3" height="30" style="BORDER-BOTTOM: #99cccc 1px solid">ģ����Ϣ�鿴��༭��<asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
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
								<TR vAlign="middle" align="center" height="20">
									<TD class="label" align="left"></TD>
									<TD class="label" align="left"></TD>
								</TR>
								<TR vAlign="middle" align="center">
									<TD class="tips" align="left" colSpan="2">������Դ���ɫ*�ŵ����ݱ������룬������ɺ�[ȷ��]���沢���ء�</TD>
								</TR>
								<TR vAlign="middle" align="center" height="20">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" style="HEIGHT: 22px" align="right" height="32">ģ����룺</TD>
									<TD class="labelNotNull" style="HEIGHT: 22px" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtMKDM" runat="server" Height="24px" Wrap="False" Font-Size="11pt" Font-Names="����" Columns="36" CssClass="textbox"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN><INPUT id="htxtMKBS" type="hidden" name="htxtMKBS" runat="server"></TD>
								</TR>
								<TR vAlign="middle" align="center" height="20">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" align="right" height="32">ģ�����ƣ�</TD>
									<TD class="labelNotNull" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtMKMC" runat="server" Width="408px" Height="24px" Wrap="False" Font-Size="11pt" Font-Names="����" Columns="60" CssClass="textbox"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
								</TR>
								<TR vAlign="middle" align="center" height="20">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" style="HEIGHT: 32px" align="right" height="32">ģ�鼶��</TD>
									<TD class="labelNotNull" style="HEIGHT: 32px" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtMKJB" runat="server" Height="24px" Wrap="False" Font-Size="11pt" Font-Names="����" Columns="12" CssClass="textbox"></asp:textbox><FONT color="#ff0000">*</FONT>(ϵͳ�Զ�����)</SPAN><INPUT id="htxtMKBJDM" type="hidden" name="htxtMKBJDM" runat="server"> <INPUT id="htxtDJMKDM" type="hidden" name="htxtDJMKDM" runat="server"><INPUT id="htxtSJMKDM" type="hidden" name="htxtSJMKDM" runat="server"></TD>
								</TR>
								<TR vAlign="middle" align="center" height="20">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" vAlign="top" align="right" height="32">˵����</TD>
									<TD class="label" align="left" height="32"><asp:textbox id="txtMKSM" runat="server" Width="540px" Height="136px" Font-Size="11pt" Font-Names="����" Columns="80" CssClass="textbox" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR vAlign="middle" align="center" height="20">
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
							<asp:button id="btnOK" Runat="server" Width="94" Height="36" Font-Size="11pt" Font-Names="����"
								CssClass="button" Text=" ȷ  �� "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnCancel" Runat="server" Width="94px" Height="36px" Font-Size="11pt"
								Font-Names="����" CssClass="button" Text=" ȡ  �� "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnClose" Runat="server" Width="94px" Height="36px" Font-Size="11pt"
								Font-Names="����" CssClass="button" Text=" ��  �� "></asp:button>
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
