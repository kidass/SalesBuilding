<%@ Page Language="vb" AutoEventWireup="false" Codebehind="login.aspx.vb" Inherits="Josco.JsKernal.web.login" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ϵͳ��¼��</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../scripts/transkey.js"></script>
		<script src="../scripts/libcookie.js"></script>
		<script language="javascript">
		<!--
            function document_onreadystatechange() 
            {
				//����¼���Դ���
				try {
				    var intMaxTry = 0;
					var intTry = 0;
					intMaxTry = parseInt(document.getElementById("htxtMaxTryCount").value, 10);
					intTry = parseInt(document.getElementById("htxtTryCount").value, 10);
					if (intTry >= intMaxTry)
					{
						//�����û�
						var objIexeFrame = null;
						var strUserId = "";
						strUserId = document.getElementById("txtUserId").value;
						objIexeFrame = getFrame(window.parent.frames, "iexeFrame"); //��ȡ"iexeFrame"֡
						if (objIexeFrame)
						{
							objIexeFrame.window.open("./../lockuser.aspx?UserId=" + strUserId,"iexeFrame");
							for(var i=0; i<10000; i++);
						}

						//��ʾ
						var strLockTime = "";
						strLockTime = document.getElementById("htxtLockTime").value;
						alert("��ʾ�����Ѿ�������" + intMaxTry.toString() +"�Σ����ѱ�������[" + strLockTime + "]���Ӻ�ϵͳ�Զ���������[ȷ��]�˳���");
						window.parent.doSetQuitPrompt(true);
						window.parent.close();
						return;
					}
					window.parent.doSetQuitPrompt(false);
					//����¼���Դ���
				} catch (e) {}
				
				if (window.navigator.cookieEnabled == true)
					if (document.all("txtUserId").value == "")
						document.all("txtUserId").value = getCookie("JoscoJsoaUsername");
				if (document.all("txtUserId").value == "")
				{
					document.all("txtUserId").focus();
					return;
				}
				document.all("txtUserPwd").focus();
            }
            function btnLogin_onClick()
            {
				if (window.navigator.cookieEnabled == true)
					if (document.all("txtUserId").value != "")
						setDefaultCookie("JoscoJsoaUsername", document.all("txtUserId").value);
				__doPostBack("lnkLogin","");
            }
		//-->
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
		<!--
            return document_onreadystatechange()
		//-->
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../images/bgmain.gif">
		<form id="frmLogin" method="post" runat="server" language="javascript">
			<asp:panel id="panelLogin" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%" height="98%" >
					<TR>
						<TD vAlign="middle" align="center" width="100%">
							<TABLE style="BORDER-RIGHT: #3399ff 2px outset; BORDER-TOP: #FFFFFF 2px outset; FONT-SIZE: 11pt; FILTER: progid: DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#99CCFF', EndColorStr='#99CCFF'); BORDER-LEFT: #ffffff 2px outset; BORDER-BOTTOM: #3399ff 2px outset; FONT-FAMILY: ����" cellSpacing="0" cellPadding="0" border="0" background="../images/passbk.jpg">
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left" colSpan="2" height="30"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" height="24">&nbsp;&nbsp;&nbsp;&nbsp;�û���ʶ��<asp:LinkButton ID="lnkLogin" Runat="server" Width="0px"></asp:LinkButton></TD>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" height="24"><INPUT id="txtUserId" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="18" name="txtUserId" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" colSpan="2" height="20"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" height="24">&nbsp;&nbsp;&nbsp;&nbsp;�û����룺</TD>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" height="24"><INPUT id="txtUserPwd" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="password" size="18" name="txtUserPwd" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;</TD>
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
									<TD align="center" colSpan="2" height="24"><INPUT id="btnLogin" style="FONT-SIZE: 11pt; WIDTH: 100px; FONT-FAMILY: ����; HEIGHT: 36px" type="button" value=" ��  ¼ " name="btnLogin" onclick="javascript:btnLogin_onClick();">&nbsp;&nbsp;&nbsp;&nbsp;<INPUT style="FONT-SIZE: 11pt; WIDTH: 100px; FONT-FAMILY: ����; HEIGHT: 36px" type="reset" value=" ��  �� "></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" colSpan="2" height="30"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<table cellSpacing="0" cellPadding="0" align="center" border="0">
				<tr>
					<td>
						<input id="htxtTryCount" runat="server" type="hidden" value="0">
						<input id="htxtMaxTryCount" runat="server" type="hidden">
						<input id="htxtLockTime" runat="server" type="hidden">
					</td>
					<td>
						<uwin:popmessage id="popMessageObject" runat="server" width="100px" height="60px" Visible="False" ActionType="OpenWindow" EnableViewState="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
