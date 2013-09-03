<%@ Page CodeBehind="areaFoot.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="Josco.JsKernal.web.areaFoot" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>系统版权窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Style.css" type="text/css" rel="stylesheet">
		<script src="scripts/transkey.js"></script>
		<script language="javascript">
		<!--
			function window_onbeforeunload() 
			{
				//关闭监视窗口
				if (window.parent.m_objChatWindowId)
				{
					try {
						window.parent.m_objChatWindowId.close();
					} catch (e) {}
				}
				//注销用户
				window.open("./secure/logout.aspx","iexeFrame");
				//等待
				for(var i=0; i<10000; i++);
			}
		//-->
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onbeforeunload="return window_onbeforeunload()">
		<table height="30" cellSpacing="0" cellPadding="0" width="100%" border="0" background="images/bgfoot.gif">
			<tr>
				<td align="center" style="FONT-SIZE: 11pt; COLOR: #003399; FONT-FAMILY: 'Courier New', 宋体, 新宋体"><asp:Label ID="lblFootMessage" Runat="server"></asp:Label></td>
			</tr>
		</table>
	</body>
</HTML>
