<%@ Page Language="vb" AutoEventWireup="false" Codebehind="xtgl_sjdx_fwq.aspx.vb" Inherits="Josco.JsKernal.web.xtgl_sjdx_fwq" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>服务器信息显示或编辑窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/bgmain.gif">
		<form id="frmSJDXGL_FWQ" method="post" runat="server">
			<asp:Panel ID="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="98%">
					<TR>
						<TD width="5%"></TD>
						<TD></TD>
						<TD width="5%"></TD>
					</TR>
					<TR>
						<TD class="title" vAlign="middle" align="center" colSpan="3" height="30" style="BORDER-BOTTOM: #99cccc 1px solid">服务器信息查看与编辑窗<asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
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
									<TD class="tips" align="left" colSpan="2">输入框旁带红色*号的内容必须输入，输入完成后按[确定]保存并返回。</TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" style="HEIGHT: 22px" align="right" height="32">服务器名称：</TD>
									<TD class="labelNotNull" style="HEIGHT: 22px" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtFWQMC" runat="server" Height="24px" Wrap="False" Font-Size="11pt" Font-Names="宋体" Columns="36" CssClass="textbox"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" align="right" height="32">服务器类型：</TD>
									<TD class="labelNotNull" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtFWQLX" runat="server" Height="24px" Wrap="False" Font-Size="11pt" Font-Names="宋体" Columns="36" CssClass="textbox"></asp:textbox>(系统给定)<FONT color="#ff0000">*</FONT></SPAN></TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" style="HEIGHT: 32px" align="right" height="32">连接提供者：</TD>
									<TD class="labelNotNull" style="HEIGHT: 32px" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtFWQTGZ" runat="server" Height="24px" Wrap="False" Font-Size="11pt" Font-Names="宋体" Columns="36" CssClass="textbox"></asp:textbox>(系统给定)<FONT color="#ff0000">*</FONT></SPAN>&nbsp;&nbsp;
									</TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" style="HEIGHT: 32px" align="right" height="32">数据库名称：</TD>
									<TD class="labelNotNull" style="HEIGHT: 32px" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtSJKMC" runat="server" Height="24px" Wrap="False" Font-Size="11pt" Font-Names="宋体" Columns="36" CssClass="textbox"></asp:textbox>(系统给定)<FONT color="#ff0000">*</FONT></SPAN>&nbsp;&nbsp;
									</TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" style="HEIGHT: 22px" align="right" height="32">用户标识：</TD>
									<TD class="labelNotNull" style="HEIGHT: 22px" align="left" height="32"><SPAN class="labelNotNull"><asp:textbox id="txtUserId" runat="server" Height="24px" Wrap="False" Font-Size="11pt" Font-Names="宋体" Columns="16" CssClass="textbox"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="labelNotNull" style="HEIGHT: 22px" align="right" height="32">用户密码：</TD>
									<TD class="labelNotNull" style="HEIGHT: 22px" align="left" height="32"><INPUT class="textbox" id="txtUserPwd" style="FONT-SIZE: 11pt; FONT-FAMILY: 宋体"  type="password" size="36" runat="server"></TD>
								</TR>
								<TR vAlign="middle" align="center" height="10">
									<TD class="label" colSpan="2"></TD>
								</TR>
								<TR vAlign="middle">
									<TD class="label" vAlign="top" align="right" height="32">说明：</TD>
									<TD class="label" align="left" height="32"><asp:textbox id="txtFWQSM" runat="server" Height="136px" Font-Size="11pt" Font-Names="宋体" Columns="60" CssClass="textbox" TextMode="MultiLine"></asp:textbox></TD>
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
							<asp:button id="btnOK" Runat="server" Width="94" Height="36" Font-Size="11pt" Font-Names="宋体"
								CssClass="button" Text=" 确  定 "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnCancel" Runat="server" Width="94px" Height="36px" Font-Size="11pt"
								Font-Names="宋体" CssClass="button" Text=" 取  消 "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnClose" Runat="server" Width="94px" Height="36px" Font-Size="11pt"
								Font-Names="宋体" CssClass="button" Text=" 返  回 "></asp:button>
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
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" 返回 " style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();"></p></TD>
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
