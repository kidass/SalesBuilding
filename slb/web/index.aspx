<%@ Page CodeBehind="index.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="Josco.JsKernal.web.index" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN" "http://www.w3.org/TR/html4/frameset.dtd">
<HTML>
	<HEAD>
		<TITLE>
			<%=System.Configuration.ConfigurationManager.AppSettings("ApplicationName") & "V" & System.Configuration.ConfigurationManager.AppSettings("ApplicationVersion")%>
		</TITLE>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<script src="scripts/transkey.js"></script>
		<script language = "javascript">
			//
			//id for chat popup window
			//
			var m_objChatWindowId = null;
			//
			//false：退出确认
			//true ：直接退出
			//
			var blnEnforced = false; 
			function doSetQuitPrompt(blnPrompt)
			{
				blnEnforced = blnPrompt;
			}
			function doHideLogoWindow()
			{
				window.mainFrameSet.rows = "0,25,*";
				window.contentFrameSet01.rows = "*,0,0";
			}
			function doShowLogoWindow()
			{
				window.mainFrameSet.rows = "80,25,*";
				window.contentFrameSet01.rows = "*,0,0";
			}
			function doHideLeftFrame()
			{
				window.contentFrameSet.cols = "0,*";
			}
			function window_onbeforeunload() 
			{
				if (blnEnforced == false)
					return "警告：您确定要退出系统吗（确定/取消）？\n    [确定]退出系统，\n    [取消]回到工作页面！";
			}
		</script>
	</HEAD>
	<frameset id="mainFrameSet" rows="80,25,*" framespacing="0" frameborder="no" onbeforeunload="return window_onbeforeunload();">
		<frame id="topFrameLogo" src="areaTopLogo.aspx" name="topFrameLogo" scrolling="no" frameborder="no" noresize>
		<frame id="topFrame" src="areaTop.aspx" name="topFrame" scrolling="no" frameborder="no" noresize>
		<frameset id="contentFrameSet" cols="0,*" framespacing="0" frameborder="no">
			<frame id="leftFrame" src="areaLeft.aspx" name="leftFrame" scrolling="auto" frameborder="no">
			<frameset id="contentFrameSet01" rows="*,0,0" framespacing="0">
				<frame id="mainFrame" src="areaContent.aspx" name="mainFrame" scrolling="auto" frameborder="no">
				<frame id="footFrame" src="areaFoot.aspx" name="footFrame" scrolling="no" frameborder="no">
				<frame id="iexeFrame" src="about:blank" name="iexeFrame" scrolling="no" frameborder="no">
			</frameset>
		</frameset>
	</frameset>
</HTML>
