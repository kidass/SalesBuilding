<%@ Page Language="vb" AutoEventWireup="false" Codebehind="chat_ssjk.aspx.vb" Inherits="Josco.JsKernal.web.chat_ssjk"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>实时监控后台数据窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
			//曾祥林 2008-03-29
            function openWindow(url) 
            {
				if (window.parent)
				{
					var objwin = window.parent.opener;
					if (objwin)
					{
						if (objwin.closed)
							window.open(url, "mainFrame");
						else
							objwin.execScript("openWindow('" + url + "')");
					} 
					else
					{
						window.open(url, "mainFrame");
					}
				}
				else
				{
					window.open(url, "mainFrame");
				}
            }
			//曾祥林 2008-03-29
			function doAutoRefresh()
			{
				//set timeout for "doAutoRefresh": 60 seconds
				//next autorefresh
				window.setTimeout("doAutoRefresh()", 60000); 
				//refresh page
				document.location.reload(true);
			}
			function document_onreadystatechange() 
			{
				var objChatDHFrame = null;
				var objChatXXFrame = null;
				var objDesControl = null;
				var objControl = null;
				var blnFocus = false;
				
				//next autorefresh
				window.setTimeout("doAutoRefresh()", 60000); 
				//display new-arrived notices
				objControl = document.getElementById("htxtAppendNoticeContent");	
				if (objControl)
				{
					if (objControl.value != "")
					{
						objChatXXFrame = getFrame(window.parent.frames, "chatXXFrame");
						if (objChatXXFrame)
						{
							objDesControl = objChatXXFrame.window.document.getElementById("divAllNotices");
							if (objDesControl)
							{
								objDesControl.innerHTML += objControl.value;
								blnFocus = true;
							}
						}
					}
				}
				//display new-arrived chat
				objControl = document.getElementById("htxtAppendChatContent");	
				if (objControl)
				{
					if (objControl.value != "")
					{
						objChatDHFrame = getFrame(window.parent.frames, "chatDHFrame");
						if (objChatDHFrame)
						{
							objDesControl = objChatDHFrame.window.document.getElementById("divAllChats");
							if (objDesControl)
							{
								objDesControl.innerHTML += objControl.value;
								blnFocus = true;
							}
						}
					}
				}
				//set focus
				if (blnFocus)
					window.parent.focus();
			}
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
			return document_onreadystatechange()
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="frmCHAT_SSJK" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD><asp:LinkButton ID="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
					</TR>
				</TABLE>
			</asp:panel>
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
						<input id="htxtNoticeInterval" runat="server" type="hidden" value="900"><!-- notice check interval = 900 seconds -->
						<input id="htxtChatInterval" runat="server" type="hidden" value="10"><!-- chat check interval = 10 seconds -->
						<input id="htxtAppendNoticeContent" runat="server" type="hidden">
						<input id="htxtAppendChatContent" runat="server" type="hidden">
					</td>
				</tr>
				<tr>
					<td>
						<uwin:popmessage id="popMessageObject" runat="server" Visible="False" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" height="48px" width="96px"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
