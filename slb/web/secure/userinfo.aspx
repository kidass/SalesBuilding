<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="userinfo.aspx.vb" Inherits="Josco.JsKernal.web.userinfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�û���Ϣ��ʾ��</title>
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
                    var txtRYDM = document.getElementById("txtRYDM");
                    txtRYDM.focus(); 
                } catch (e) {}
            }
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
            return document_onreadystatechange()
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../images/bgmain.gif">
		<form id="frmLogin" method="post" runat="server">
			<asp:panel id="panelInformation" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="98%">
					<tr>
						<td align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%" height="100%">
								<TR>
									<TD width="5%"></TD>
									<td>
										<!--������ 2008-04-16-->
										<table cellpadding="0" cellspacing="0" border="0" width="100%">
											<tr>
												<TD align="center" height="30" class="title" width="80%">ʹ����Ա��Ϣһ����</TD>
												<td align="right" width="80%"><asp:Button ID="btnReturn" Runat="server" CssClass="button" Font-Name="����" Font-Size="11pt" Text=" ��  �� "></asp:Button></td>
											</tr>
										</table>
										<!--������ 2008-04-16-->
									</td>
									<TD width="5%"></TD>
								</TR>
								<TR>
									<TD width="5%"></TD>
									<TD valign="top" align="center" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
											<TR>
												<TD colSpan="2" height="10"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">��Ա���룺</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtRYDM" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="16" name="txtRYDM" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">��Ա���ƣ�</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtRYMC" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="16" name="txtRYMC" runat="server"></TD>
											</TR>
											<!--������ 2008-04-19 -->
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">��Ա������</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtRYZM" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="16" name="txtRYZM" runat="server"></TD>
											</TR>
											<!--������ 2008-04-19 -->
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">���ڵ�λ�������ƣ�</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtZZMC" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="48" name="txtZZMC" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">����ţ�</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtRYXH" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="10" name="txtRYXH" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">��������</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtJBMC" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="16" name="txtJBMC" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">�䱸���飺</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtMSMC" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="16" name="txtMSMC" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">��ϵ�绰��</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtLXDH" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="48" name="txtLXDH" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">�ƶ��绰��</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtSJHM" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="30" name="txtSJHM" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">�������䣺</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtYXDZ" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="48" name="txtYXDZ" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">��תʱ�ɿ�������������Ա��</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtKCKRY" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="48" name="txtKCKRY" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">������Աϵͳ��ʾΪ��</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtJJXSMC" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="16" name="txtJJXSMC" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">��תʱ��ֱ���͸�������Ա��</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtKZSRY" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="48" name="txtKZSRY" runat="server"></TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="right" height="26">������Աͨ����</TD>
												<TD style="FONT-SIZE: 11pt; FONT-FAMILY: ����" align="left"><INPUT id="txtQTYZS" style="FONT-SIZE: 11pt; FONT-FAMILY: ����" type="text" size="16" name="txtQTYZS" runat="server">&nbsp;ת��</TD>
											</TR>
											<TR>
												<TD colSpan="2" height="10"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5%"></TD>
								</TR>
								<TR>
									<TD width="5%"></TD>
									<TD align="center" height="30" class="title">����ְ�����һ����</TD>
									<TD width="5%"></TD>
								</TR>
								<TR>
									<TD width="5%"></TD>
									<TD align="center" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
											<TR>
												<TD colSpan="2"><asp:CheckBoxList id="chklstGW" Runat="server" RepeatDirection="Horizontal" Width="100%" RepeatLayout="Table" RepeatColumns="6" Enabled="False" CssClass="textbox"></asp:CheckBoxList></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5%"></TD>
								</TR>
							</table>
						</td>
					</tr>
				</TABLE>
			</asp:panel>
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
