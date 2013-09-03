<%@ Page CodeBehind="default.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="Josco.JsKernal.web.DefaultPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>网站启动页</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
			function doStartApplication()
			{
				window.setTimeout("closeStartupWindow();",1000);
				window.open("index.aspx","_blank","fullscreen=no,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=yes,toolbar=no","");
			}
			function closeStartupWindow()
			{
				window.opener = null;              //适用于IE6
				window.open("about:blank","_top"); //适用于IE7
				window.top.close();
			}
            function document_onreadystatechange() 
            {
	            doStartApplication();
            }
		</script>
        <script language="javascript" for="document" event="onreadystatechange">
            return document_onreadystatechange()
        </script>
    </HEAD>
	<body></body>
</HTML>
