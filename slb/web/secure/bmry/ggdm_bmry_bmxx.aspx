<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ggdm_bmry_bmxx.aspx.vb" Inherits="Josco.JsKernal.web.ggdm_bmry_bmxx" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��λ��Ϣ��ʾ��༭��</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/bgmain.gif">
		<form id="frmGGDM_BMRY_BMXX" method="post" runat="server">
			<asp:Panel ID="panelMain" Runat="server">
				<TABLE height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="title" style="BORDER-BOTTOM: #99cccc 1px solid" vAlign="middle" align="center" colSpan="3" height="30">��λ��Ϣ��ʾ��༭��<asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD width="5%"></TD>
						<TD vAlign="top" align="center">
							<TABLE height="100%" cellSpacing="0" cellPadding="0" border="0">
								<TR vAlign="middle" align="center">
									<TD class="tips" align="left" colSpan="2" height="30">������Դ���ɫ*�ŵ����ݱ������룬������ɺ�[ȷ��]���沢���ء�</TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" align="right">��λ���룺</TD>
									<TD class="labelNotNull" align="left"><SPAN class="labelNotNull"><asp:textbox id="txtZZDM" runat="server" Height="24px" CssClass="textbox" Columns="12" Font-Names="����" Font-Size="11pt" Wrap="False"></asp:textbox><FONT color="#ff0000">*[��ʽ��AABBCCDDEEFF]</FONT></SPAN></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" align="right">��λ���ƣ�</TD>
									<TD class="labelNotNull" align="left"><SPAN class="labelNotNull"><asp:textbox id="txtZZMC" runat="server" Height="24px" CssClass="textbox" Columns="60" Font-Names="����" Font-Size="11pt" Wrap="False"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">��λȫ�ƣ�</TD>
									<TD class="label" align="left"><asp:textbox id="txtZZBM" runat="server" Height="40px" CssClass="textbox" Columns="59" Font-Names="����" Font-Size="11pt" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">����Ƭ����</TD>
									<TD class="label" align="left"><asp:DropDownList id="ddlSZQY" runat="server" CssClass="textbox"></asp:DropDownList></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">��λ����</TD>
									<TD class="label" align="left"><asp:textbox id="txtJBMC" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="True"></asp:textbox><asp:Button id="btnSelectJBDM" Runat="server" Font-Size="11pt" Font-Name="����" Text=" �� "></asp:Button><INPUT id="htxtJBDM" type="hidden" runat="server"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">��λ���飺</TD>
									<TD class="label" align="left"><asp:textbox id="txtMSMC" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="True"></asp:textbox><asp:Button id="btnSelectMSDM" Runat="server" Font-Size="11pt" Font-Name="����" Text=" �� "></asp:Button><INPUT id="htxtMSDM" type="hidden" runat="server"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">��ϵ�绰��</TD>
									<TD class="label" align="left"><asp:textbox id="txtLXDH" runat="server" Height="24px" CssClass="textbox" Columns="60" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">�ƶ��绰��</TD>
									<TD class="label" align="left"><asp:textbox id="txtSJHM" runat="server" Height="24px" CssClass="textbox" Columns="30" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
								</TR> <!--������ 2008-05-07 2008-05-23-->
								<TR vAlign="middle">
									<TD class="label" align="right">��֯��ţ�</TD>
									<TD class="label" align="left"><asp:textbox id="txtZZXH" runat="server" Height="24px" CssClass="textbox" Columns="6" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">����������</TD>
									<TD class="label" align="left"><asp:textbox id="txtBZRS" runat="server" Height="24px" CssClass="textbox" Columns="6" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right"></TD>
									<TD class="label" align="left">
										<asp:CheckBox id="chkSFSLB" runat="server" Height="24px" CssClass="textbox" Font-Names="����" Font-Size="11pt" Text="��¥��"></asp:CheckBox>
										<asp:CheckBox id="chkSFFH" runat="server" Height="24px" CssClass="textbox" Font-Names="����" Font-Size="11pt" Text="����"></asp:CheckBox>
									</TD>
								</TR> <!--������ 2008-05-07 2008-05-23-->
								<tr>
									<TD class="label" align="right"></TD>
									<TD class="label" align="left">��д˵����������[��¥��]����ͨ��¥�������ͬʱ��[��¥��]��[����]���������ô򹳣�</td>
								</tr>
								<TR vAlign="middle">
									<TD class="label" align="right">�ڲ����䣺</TD>
									<TD class="label" align="left"><asp:textbox id="txtFTPDZ" runat="server" Height="24px" CssClass="textbox" Columns="60" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">���������䣺</TD>
									<TD class="label" align="left"><asp:textbox id="txtYXDZ" runat="server" Height="24px" CssClass="textbox" Columns="60" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">��ϵ��ַ��</TD>
									<TD class="label" align="left"><asp:textbox id="txtLXDZ" runat="server" Height="24px" CssClass="textbox" Columns="60" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">�������룺</TD>
									<TD class="label" align="left"><asp:textbox id="txtYZBM" runat="server" Height="24px" CssClass="textbox" Columns="6" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" align="right">��λ��ϵ�ˣ�</TD>
									<TD class="label" align="left"><asp:textbox id="txtLXR" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="����" Font-Size="11pt" TextMode="SingleLine" ReadOnly="True"></asp:textbox><asp:Button id="btnSelectLXR" Runat="server" Font-Size="11pt" Font-Name="����" Text=" �� "></asp:Button><INPUT id="htxtLXRDM" type="hidden" runat="server"></TD>
								</TR>
								<TR vAlign="middle" align="center">
									<TD class="label" colSpan="2" height="10"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5%"></TD>
					</TR>
					<TR vAlign="middle">
						<TD colSpan="3" height="6">
					</TD>
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
