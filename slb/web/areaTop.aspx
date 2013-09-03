<%@ Page Language="vb" AutoEventWireup="false" Codebehind="areaTop.aspx.vb" Inherits="Josco.JsKernal.web.areaTop" %>
<%@ Register TagPrefix="ucc" TagName="bannertile" Src="BannerTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>系统标题窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="style.css" type="text/css" rel="stylesheet">
		<script src="scripts/showdateweek.js"></script>
		<script src="scripts/transkey.js"></script>
		<script language="javascript">
			var m_doAutoRefresh      = true;
			var m_autoRefreshTimerId = -1;
			var m_autoLoadTimerId    = -1;
			var m_dateWeekTimerId    = -1;
			var m_loginTimeTimerId   = -1;
			var m_blnFirstEnter      = true;
			//曾祥林 2008-03-29
			function openChatWindow(blnEnforced)
			{
				var objLeftFrameWindow = null;
				var objLeftFrame = null;
				var objControl = null;
				try 
				{
					//不强制显示！
					if (blnEnforced == false)
					{
						//是否需要弹出提醒窗?
						objControl=document.getElementById("mainmenu_htxtInfoCount");
						if (objControl)
						{
							if (parseInt(objControl.value, 10) > 0)
							{
								objLeftFrame = getFrame(window.parent.frames, "leftFrame"); //获取"leftFrame"帧
								if (objLeftFrame)
									objLeftFrame.window.execScript("openChat();");
							}
						}
					}
					//强制显示
					else
					{
						objLeftFrame = getFrame(window.parent.frames, "leftFrame"); //获取"leftFrame"帧
						if (objLeftFrame)
							objLeftFrame.window.execScript("openChatEnforced();");
					}
				} 
				catch (e) 
				{
					return false;
				}
				return true;
			}
			function document_onreadystatechange() 
			{
				var objHidden = null;
				var objButton = null;
				//设置全屏或正常显示模式
				objHidden = document.getElementById("mainmenu_htxtFullScreen");
				objButton = document.getElementById("btnFullScreen");
				if (objButton && objHidden)
				{
					if (objHidden.value == "0")
						objButton.value = "全屏";
					else
						objButton.value = "正常";
				}				
				//设置锁定或解锁显示模式
				objHidden = document.getElementById("mainmenu_htxtLockApp");
				objButton = document.getElementById("btnLockApp");
				if (objButton && objHidden)
				{
					if (objHidden.value == "0")
						objButton.value = "锁定";
					else
						objButton.value = "解锁";
				}
				//是否需要打开Chat窗口？				
				openChatWindow(false);
			}
			function btnFullScreen_onClick() 
			{
				var objButton = null;
				var objHidden = null;
				objHidden = document.getElementById("mainmenu_htxtFullScreen");
				objButton = document.getElementById("btnFullScreen");
				if (objHidden && objButton)
				{
					try 
					{
						if (objButton.value == "全屏") 
						{
							objHidden.value = "1";
							objButton.value = "正常"; 
							window.parent.doHideLogoWindow(); 
							window.open("fullscreen.aspx?FullScreen=1","iexeFrame");
							return;
						}
						if (objButton.value == "正常") 
						{
							objHidden.value = "0";
							objButton.value = "全屏"; 
							window.parent.doShowLogoWindow(); 
							window.open("fullscreen.aspx?FullScreen=0","iexeFrame");
							return;
						}
					}
					catch (e) {}
				}
			}
			function btnLockApp_onClick() 
			{
				var objButton = null;
				var objHidden = null;
				objHidden = document.getElementById("mainmenu_htxtLockApp");
				objButton = document.getElementById("btnLockApp");
				if (objHidden && objButton)
				{
					try 
					{
						if (objButton.value == "锁定") 
						{
							//询问
							if (window.confirm("警告：您确定已经保存了当前页面的数据吗（确定/取消）？") == false)
								return;
							//更新当前状态显示
							objHidden.value = "1";
							objButton.value = "解锁"; 
							//显示锁定界面
							window.open("./secure/applock.aspx","mainFrame");
							openChatWindow(true);
							return;
						}
						if (objButton.value == "解锁") 
						{
							//显示解锁界面
							window.open("./secure/appunlock.aspx","mainFrame");
							return;
						}
					}
					catch (e) {}
				}
			}
			function doDisplayAppUnLocked()
			{
				var objButton = null;
				var objHidden = null;
				objHidden = document.getElementById("mainmenu_htxtLockApp");
				objButton = document.getElementById("btnLockApp");
				if (objHidden && objButton)
				{
					try 
					{
						objHidden.value = "0";
						objButton.value = "锁定"; 
					}
					catch (e) {}
				}
			}
			//曾祥林 2008-03-29
			function document_onbeforeunload()
			{
				try 
				{
					if (m_autoRefreshTimerId > 0)
						window.clearTimeout(m_autoRefreshTimerId);
					m_autoRefreshTimerId = -1;
					
					if (m_autoLoadTimerId > 0)
						window.clearTimeout(m_autoLoadTimerId);
					m_autoLoadTimerId = -1;
					
					if (m_dateWeekTimerId > 0)
						window.clearTimeout(m_dateWeekTimerId);
					m_dateWeekTimerId = -1;
					
					if (m_loginTimeTimerId > 0)
						window.clearTimeout(m_loginTimeTimerId);
					m_loginTimeTimerId = -1;
				}
				catch (e) {}
			}
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
		<!--
			return document_onreadystatechange()
		//-->
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onbeforeunload="document_onbeforeunload();">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td>
					 <!--PAGE HEADER MODULE -->
					<ucc:bannertile id="mainmenu" runat="server" Enabled="true" SelectIndex="0" PathPrefix="."></ucc:bannertile>
					 <!--PAGE HEADER MODULE -->
				</td>
			</tr>
		</table>
	</body>
</HTML>
