<%@ Page Language="vb" AutoEventWireup="false" Codebehind="chat_quit.aspx.vb" Inherits="Josco.JsKernal.web.chat_quit"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��ʱ�������ڹرռ�ش�</title>
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
			    //��ȡchat_fsxx�еġ�htxtSessionIdFJ��
			    var objFrame = getFrame(window.parent.frames, "chatFSFrame");
			    if (objFrame)
			    {
			        var objControl = objFrame.window.document.getElementById("htxtSessionIdFJ");
			        if (objControl)
			        {
				        //���ü�ʱ��Ϣ��Դ�ͷų���
				        window.open("chat_sfzy.aspx?SessioId=" + objControl.value,"chatYDFrame");
				        //�ȴ�
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
				<td align="center" style="FONT-SIZE: 11pt; COLOR: #003399; FONT-FAMILY: 'Courier New', ����, ������">��ʱ��������׼���رգ����Ժ�...</td>
			</tr>
		</table>
	</body>
</HTML>
