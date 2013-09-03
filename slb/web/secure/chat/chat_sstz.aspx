<%@ Page Language="vb" AutoEventWireup="false" Codebehind="chat_sstz.aspx.vb" Inherits="Josco.JsKernal.web.chat_sstz"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>通知消息显示窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
		<!--
			//曾祥林 2008-03-29
            function openWindow(url) 
            {
				var objAppLocked = null;
				objAppLocked = document.getElementById("htxtAppLocked");
				var intAppLocked;
				try 
				{
					if (objAppLocked)
						intAppLocked = parseInt(objAppLocked.value, 10);
					else
						intAppLocked = 0;
				}
				catch (e)
				{
					intAppLocked = 0;
				}
				if (intAppLocked != 0)
				{
					alert("提示：系统已经被锁定，请解除锁定后再来执行，谢谢！");
					return;
				}
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
						window.open(url, "mainFrame");
				}
				else
					window.open(url, "mainFrame");
            }
			//曾祥林 2008-03-29
			function document_onreadystatechange() 
			{
				window_onresize();
				
				var objControl = null;
				objControl = document.getElementById("htxtNoticeContent");
				if (objControl)
					divAllNotices.innerHTML = objControl.value;
			}
			function window_onresize() 
			{
				var dblHeight = 0;
				var strHeight = "";
				var dblDeltaY = titleAllNotices.clientHeight + 4;
				
				if (document.all("divAllNotices") == null)
					return;
				
				dblHeight = document.body.clientHeight - dblDeltaY;
				if (dblHeight < dblDeltaY) 
					dblHeight = dblDeltaY;
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				divAllNotices.style.width  = "100%";
				divAllNotices.style.height = strHeight;
				divAllNotices.style.clip = "rect(0px 100% " + strHeight + " 0px)";
			}
		//-->
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
			return document_onreadystatechange()
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmCHAT_SSTZ" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="title" id="titleAllNotices" style="BORDER-BOTTOM: dodgerblue thin outset; BACKGROUND-COLOR: lightskyblue" align="center" height="30">【<!--<%=Mybase.UserXM%>--><%=Mybase.UserZM%>】系统通知消息显示窗<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD>
							<DIV id="divAllNotices" style="OVERFLOW: auto; WIDTH: 100%; CLIP: rect(0px 160px 100% 0px); HEIGHT: 160px; BACKGROUND-COLOR: white"></DIV>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();" type="button" value=" 返回 "></P></TD>
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
						<input id="htxtNoticeContent" runat="server" type="hidden">
						<!--曾祥林 2008-03-29 -->
						<input id="htxtAppLocked" runat="server" type="hidden" size="1">
						<!--曾祥林 2008-03-29 -->
					</td>
				</tr>
				<tr>
					<td><script language="javascript">window_onresize();</script><uwin:popmessage id="popMessageObject" runat="server" Visible="False" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" height="48px" width="96px"></uwin:popmessage></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
