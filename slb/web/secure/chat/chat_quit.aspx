<%@ Page Language="vb" AutoEventWireup="false" Codebehind="chat_quit.aspx.vb" Inherits="Josco.JsKernal.web.chat_quit"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>即时交流窗口关闭监控窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../../style.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
		<!--
			function window_onbeforeunload() 
			{
			    //获取chat_fsxx中的“htxtSessionIdFJ”
			    var objFrame = getFrame(window.parent.frames, "chatFSFrame");
			    if (objFrame)
			    {
			        var objControl = objFrame.window.document.getElementById("htxtSessionIdFJ");
			        if (objControl)
			        {
				        //调用即时信息资源释放程序
				        window.open("chat_sfzy.aspx?SessioId=" + objControl.value,"chatYDFrame");
				        //等待
				        for(var i=0; i<10000; i++);
			        }
                }			        
			}
		//-->
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onbeforeunload="return window_onbeforeunload()">
		<table height="30" cellSpacing="0" cellPadding="0" width="100%" border="0" background="images/bgfoot.gif">
			<tr>
				<td align="center" style="FONT-SIZE: 11pt; COLOR: #003399; FONT-FAMILY: 'Courier New', 宋体, 新宋体">即时交流窗口准备关闭，请稍候...</td>
			</tr>
		</table>
	</body>
</HTML>
