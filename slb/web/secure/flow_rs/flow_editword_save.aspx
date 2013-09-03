<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_editword_save.aspx.vb" Inherits="Josco.JSOA.web.flow_editword_save" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>文件保存提示窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<base target="_self">
		<script type="text/javascript">
			function ShowSuccessInfo()
			{
				if (document.getElementById("divMessage") == null)
					return;
				if (document.readyState.toLowerCase() != "complete")
					window.setTimeout("ShowSuccessInfo()", 500);
				var obj = document.getElementById("htxtPostFlag");
				if (obj.value == "0")
				{
					obj.value = "1";
					window.setTimeout("doSaveFile()", 500);
				}
				else
					window.setTimeout("HideMessageWindow()", 500);
			}
			function HideMessageWindow()
			{
				window.close();
			}
			function doSaveFile()
			{
				__doPostBack("lnkMLSave");
			}
			function document_onreadystatechange() 
			{
				ShowSuccessInfo();
			}
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
			return document_onreadystatechange()
		</script>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" bgcolor="#ece9d8">
		<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
			<tr>
				<td>
					<form id="frmflow_editword_save" method="post" runat="server">
						<asp:panel id="panelMain" Runat="server">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td><asp:LinkButton id="lnkMLSave" Runat="server" Width="0px"></asp:LinkButton></td>
								</tr>
								<TR>
									<TD align="center" height="24"><div id="divMessage" style="FONT-SIZE: 16px">正在向服务器保存数据，请等待...</div></TD>
								</TR>
							</TABLE>
						</asp:panel>
						<asp:Panel id="panelError" Runat="server">
							<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="5%"></TD>
									<TD>
										<TABLE id="tabErrInfo" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
												<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();" type="button" value=" 返回 "></P></TD>
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
									<input id="htxtPostFlag" runat="server" type="hidden" value="0">
								</td>
							</tr>
							<tr>
								<td>
									<uwin:popmessage id="popMessageObject" runat="server" height="10px" width="10px" Visible="False" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
		</TABLE>
	</BODY>
</HTML>
