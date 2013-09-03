<%@ Page Language="vb" AutoEventWireup="false" Codebehind="chat_main.aspx.vb" Inherits="Josco.JsKernal.web.chat_main"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN" "http://www.w3.org/TR/html4/frameset.dtd">
<HTML>
	<HEAD>
		<TITLE>我的即时信息交流</TITLE>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<script language="javascript">
			var m_currentHeight = 0;
		</script>
	</HEAD>
	<frameset id="chatMainFrameSet" rows="*,*,230,0,0,0" framespacing="0">
		<frame src="chat_sstz.aspx" name="chatXXFrame" scrolling="no" frameborder="no" noresize>
		<frame src="chat_dhxx.aspx" name="chatDHFrame" scrolling="no" frameborder="no" noresize>
		<frame src="chat_fsxx.aspx" name="chatFSFrame" scrolling="no" frameborder="no" noresize>
		<frame src="chat_ssjk.aspx" name="chatJKFrame" scrolling="no" frameborder="no" noresize>
		<frame src="chat_quit.aspx" name="chatQTFrame" scrolling="no" frameborder="no" noresize>
		<frame src="about:blank"    name="chatYDFrame" scrolling="no" frameborder="no" noresize>
	</frameset>
</HTML>
