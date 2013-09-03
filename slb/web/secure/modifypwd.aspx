<%@ Page Language="vb" AutoEventWireup="false" Codebehind="modifypwd.aspx.vb" Inherits="Josco.JsKernal.web.modifypwd" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�û�������Ĵ�</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../scripts/transkey.js"></script>
		<script language="javascript" id="clientEventHandlersJS">
            function document_onreadystatechange() 
            {
                try {
                    var txtNewUserPwd = document.getElementById("txtNewUserPwd");
                    txtNewUserPwd.focus(); 
                } catch (e) {}
            }
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
            return document_onreadystatechange()
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../images/bgmain.gif">
		<form id="frmLogin" method="post" runat="server">
			<asp:panel id="panelModifyPwd" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%" height="98%">
					<TR>
						<TD vAlign="middle" align="center">
							<TABLE style="BORDER-RIGHT: #3399ff 2px outset; BORDER-TOP: #3399ff 2px outset; FONT-SIZE: 11pt; BORDER-LEFT: #3399ff 2px outset; BORDER-BOTTOM: #3399ff 2px outset; FONT-FAMILY: ����" cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left" colSpan="2" height="30"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="24">&nbsp;&nbsp;&nbsp;&nbsp;�û���ʶ��</TD>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" height="24"><INPUT id="txtUserId" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="18" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" colSpan="2" height="20"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="24">&nbsp;&nbsp;&nbsp;&nbsp;���������룺</TD>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" height="24"><INPUT id="txtNewUserPwd" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="password" size="18" runat="server">&nbsp;(����<%=Josco.JsKernal.Common.jsoaConfiguration.MinPasswordLength%>���ַ�)&nbsp;</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" colSpan="2" height="20"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="24">&nbsp;&nbsp;&nbsp;&nbsp;ȷ�������룺</TD>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" height="24"><INPUT id="txtNewUserPwdQR" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="password" size="18" runat="server">&nbsp;(����<%=Josco.JsKernal.Common.jsoaConfiguration.MinPasswordLength%>���ַ�)&nbsp;</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" colSpan="2" height="20"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" height="24">&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;֤&nbsp;�룺</TD>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" height="24" valign="middle"><INPUT id="txtValidPwd" style="FONT-SIZE: 11pt; FONT-FAMILY: ����; height:22px" type="text" size="8" name="txtValidPwd" runat="server"><asp:image ID="imgValidPwd" Runat="server" ImageUrl="../randimg.aspx" Height="22px" ImageAlign="AbsMiddle"></asp:image>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" colSpan="2" height="20"></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2" height="24">
										<INPUT id="btnModify" style="FONT-SIZE: 11pt; WIDTH: 100px; FONT-FAMILY: ����; HEIGHT: 36px" type="button" value=" ��  �� " runat="server">
										<INPUT id="btnReset" style="FONT-SIZE: 11pt; WIDTH: 100px; FONT-FAMILY: ����; HEIGHT: 36px" type="reset"  value=" ��  �� " runat="server">
										<INPUT id="btnCancel" style="FONT-SIZE: 11pt; WIDTH: 100px; FONT-FAMILY: ����; HEIGHT: 36px" type="button" value=" ��  �� " runat="server">
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" colSpan="2" height="30"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelInformation" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="98%">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 30pt; COLOR: black; LINE-HEIGHT: 48pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" ���� " style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();"></p></TD>
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
						<uwin:popmessage id="popMessageObject" runat="server" width="100px" height="60px" Visible="False" ActionType="OpenWindow" EnableViewState="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
