<%@ Page Language="vb" AutoEventWireup="false" Codebehind="chat_dhxx.aspx.vb" Inherits="Josco.JsKernal.web.chat_dhxx"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>即时聊天内容显示窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
		<!--
			function document_onreadystatechange() 
			{
				window_onresize();

				var objControl = null;
				objControl = document.getElementById("htxtChatContent");
				if (objControl)
					divAllChats.innerHTML = objControl.value;
			}
			function window_onresize() 
			{
				var dblHeight = 0;
				var strHeight = "";
				var dblDeltaY = titleAllChats.clientHeight + 4;
				
				if (document.all("divAllChats") == null)
					return;
				
				dblHeight = document.body.clientHeight - dblDeltaY;
				if (dblHeight < dblDeltaY) 
					dblHeight = dblDeltaY;
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				divAllChats.style.width  = "100%";
				divAllChats.style.height = strHeight;
				divAllChats.style.clip = "rect(0px 100% " + strHeight + " 0px)";
			}
		//-->
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
			return document_onreadystatechange()
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmCHAT_DHXX" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD id="titleAllChats" class="title" style="BORDER-TOP: dodgerblue thin outset; BORDER-BOTTOM: dodgerblue thin outset; BACKGROUND-COLOR: lightskyblue" align="center" height="30">【<!--<%=Mybase.UserXM%>--><%=Mybase.UserZM%>】即时交流信息显示窗<asp:LinkButton ID="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD>
							<DIV id="divAllChats" style="OVERFLOW: auto; WIDTH: 100%; CLIP: rect(0px 100% 250px 0px); HEIGHT: 250px; BACKGROUND-COLOR: white"></DIV>
						</TD>
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
						<input id="htxtChatContent" runat="server" type="hidden">
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" Visible="False" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" height="48px" width="96px"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
