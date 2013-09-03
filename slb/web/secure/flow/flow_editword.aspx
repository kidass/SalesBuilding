<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_editword.aspx.vb" Inherits="Josco.JSOA.web.flow_editword"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>文档编辑器</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styleGW.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script src="flow_editword.js"></script>
		<script language="javascript">
			//*********************************************************************************************************************
			//2008-08-04 zengxianglin 全面修改
			//*********************************************************************************************************************
			var m_strMsg_SavePrompt              = "警告：是否要保存对文件的修改？<br>[&nbsp;&nbsp;是&nbsp;&nbsp;] -- 保存并退出<br>[&nbsp;&nbsp;否&nbsp;&nbsp;] -- 不保存退出<br>[取消] -- 继续编辑&nbsp;&nbsp;&nbsp;&nbsp; ";
			var m_strMsg_CancelPrompt            = "警告：要保存您录入的内容吗（是/否）？";
			var m_strMsg_FilePrintError          = "错误：文件打印过程中出错！"
			var m_strMsg_FileCanNotOpen          = "错误：文件打开过程中出错，请单击[重新打开]！"
			var m_strMsg_FileCanNotSave          = "错误：文件保存过程中出错！"
			var m_strMsg_FileNotExcel            = "错误：文件不是[Microsoft Excel]！"
			var m_strMsg_FileNotWord             = "错误：文件不是[Microsoft Word]！"
			var m_strMsg_FileNotOpen             = "错误：您还没有打开文件！";
			var m_strMsg_CanNotShowRevisions     = "错误：不能显示痕迹！";
			var m_strMsg_CanNotHideRevisions     = "错误：不能隐藏痕迹！";
			var m_strMsg_CanNotDisableRevisions  = "错误：不能关闭痕迹记录！";
			var m_strMsg_CanNotEnabledRevisions  = "错误：不能打开痕迹记录！";
			var m_strMsg_CanNotProtectDocument   = "错误：不能完成保护文档！";
			var m_strMsg_CanNotUnProtectDocument = "错误：不能取消文档保护！";
			var m_strMsg_CanNotCloseDocument     = "错误：不能关闭文档！";
			var m_strMsg_CanNotGetTempLocalFile  = "错误：不能获取Url文件的本地临时文件！";
			var m_strMsg_EditXGWJ                = "&nbsp;改相关文&nbsp;";
			var m_strMsg_ReadXGWJ                = "&nbsp;查相关文&nbsp;";
			var m_strMsg_FileNameNull            = "错误：没有指定要打开的文件！";
			var m_strMsg_EditFJ                  = "&nbsp;编辑附件&nbsp;";
			var m_strMsg_ReadFJ                  = "&nbsp;查阅附件&nbsp;";
			var m_objNewMsgWin                   = null;
			//zengxianglin 2009-03-14
			var m_intWatchTimerId = null;
			//编辑时间监测器处理脚本
			function doWatchEditTimer()
			{
				//获取监测间隔时间
				var strWatchInterval = getElementValueSafe_String("htxtWatchInterval");
				//提示信息
				var objMsgWin = null;
				var strMsg    = "";
				if (((m_blnAutoSave == true) && (m_blnEditMode == true)) == false)
				{
					strMsg = "警告：您已经连续编辑[" + strWatchInterval + "]分钟未做保存，系统正强制保存您的数据，<br>请稍候......";
					objMsgWin = window.showModelessDialog("../../info_button0.aspx",strMsg,"dialogHeight:170px;dialogWidth:320px;help:no;scroll:no;status:no");
				}
				//保存文件
				hrefSAVE_onclick();
				//关闭提示
				if (objMsgWin)
					objMsgWin.close();
				objMsgWin = null;
				objOffice.focus();
			}
			//重新启动编辑时间监测器
			function doRestartWatchEditTimer()
			{
				//开关关闭！
				var strSwitch = getElementValueSafe_String("htxtWatchSwitch");
				if (strSwitch != "1")
					return;
				//不是编辑状态，就不启动！
				if (m_blnEditMode == false)
					return;
				//关闭现有监测器
				doStopWatchEditTimer();
				//启动新的监测器
				var strWatchInterval = getElementValueSafe_String("htxtWatchInterval");
				var intWatchInterval = parseInt(strWatchInterval, 10) * 1000 * 60;
				m_intWatchTimerId = window.setInterval("doWatchEditTimer()", intWatchInterval);
			}
			//关闭现有监测器
			function doStopWatchEditTimer()
			{
				//关闭现有监测器
				if (m_intWatchTimerId)
					window.clearInterval(m_intWatchTimerId);
				m_intWatchTimerId = null;
			}
			//zengxianglin 2009-03-14
			//文件另存为...
			function hrefDCWJ_onclick() 
			{
				try {
					if (! m_blnDocumentOpened) { alert(m_strMsg_FileNotOpen); return;}
					objOffice.ShowDialog(3); //open
					var strType = document.getElementById("htxtFlowTypeName").value;
					var strWJBS = document.getElementById("htxtWJBS").value;
					window.open("./../userlog.aspx?WJBS=" + strWJBS + "&Type=" + strType + "&Czlx=导出&Czms=主文件","iexeFrame");
					for(var i=0; i<10000; i++);
				} catch(e) { alert(m_strMsg_FileCanNotSave);}
			}
			//打印文件
			function hrefDYWJ_onclick() 
			{
				try {
					if (! m_blnDocumentOpened) {alert(m_strMsg_FileNotOpen);return;}
					objOffice.ShowDialog(4); //print
					var strType = document.getElementById("htxtFlowTypeName").value;
					var strWJBS = document.getElementById("htxtWJBS").value;
					window.open("./../userlog.aspx?WJBS=" + strWJBS + "&Type=" + strType + "&Czlx=打印&Czms=主文件","iexeFrame");
					for(var i=0; i<10000; i++);
				} catch(e) {alert(m_strMsg_FilePrintError);}
			}
			//选择投稿稿件
			function hrefXZGJ_onclick() 
			{
				alert("错误：不支持本操作！");
				return;
			}
			//关闭信息提示窗
			function HideMessageWindow()
			{
				//zengxianglin 2008-08-14
				objOffice.focus();
				//zengxianglin 2008-08-14
				if (m_objNewMsgWin)
					m_objNewMsgWin.close();
				objOffice.focus();
			}
			//打开文件主操作
			function OpenDocument()
			{
				var blnRe     = false;
				//until page load complete
				if (document.readyState.toLowerCase() != "complete") {window.setTimeout("OpenDocument()", 1000);return;}
				//close current document
				try { if (objOffice.ActiveDocument) objOffice.Close();} catch (e) {}
				//initialize
				blnRe = InitializedParameters();
				//prompt wait
				var strMsg = ""
				//if (m_blnEditMode)
				//	strMsg = "提示：系统正在打开文件供您[<B>&nbsp;编&nbsp;辑&nbsp;</B>]，<br><br>请稍侯...";
				//else
				//	//2009-02-20
				//	//strMsg = "提示：系统正在打开文件供您[<B>&nbsp;查&nbsp;阅&nbsp;</B>]，<br><br>请稍侯...";
				//	if (m_blnLocked)
				//		strMsg = "提示：" & document.getElementById("htxtLocked").value & "系统已经锁定文件，您只能[<B>&nbsp;查&nbsp;阅&nbsp;</B>]，<br><br>请稍侯...";
				//	else
				//		strMsg = "提示：系统正在打开文件供您[<B>&nbsp;查&nbsp;阅&nbsp;</B>]，<br><br>请稍侯...";
				//	//2009-02-20	
				//if (m_objNewMsgWin)
				//	m_objNewMsgWin.close();
				//m_objNewMsgWin = window.showModelessDialog("../../info_button0.aspx",strMsg,"dialogHeight:170px;dialogWidth:320px;help:no;scroll:no;status:no");
				//zengxianglin 2008-08-14
				objOffice.focus();
				//zengxianglin 2008-08-14
				//open document
				
				if (blnRe == true)
					blnRe = OpenOfficeDocument();
							
				//set final command display
				if (!blnRe) 
					setCommandDisplay(blnRe);
				//if (m_objNewMsgWin)
				//	window.setTimeout("HideMessageWindow()",500);
				return blnRe;
			}
			function document_onreadystatechange()
			{
				//自动打开文件
				window.setTimeout("OpenDocument()", 1000);
				//zengxianglin 2009-03-14
				doRestartWatchEditTimer();
				//zengxianglin 2009-03-14
			}
			function document_onbeforeunload()
			{
				try	{objOffice.Close();} catch (e) {}
				//zengxianglin 2009-03-14
				doStopWatchEditTimer();
				//zengxianglin 2009-03-14
			}
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
			return document_onreadystatechange()
		</script>
		<script language="javascript" for="document" event="onbeforeunload">
			return document_onbeforeunload()
		</script>
	</HEAD>
	<BODY background="../../images/oabk.gif" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
			<tr>
				<td colspan="3">
					<form id="frmFLOW_EDITWORD" method="post" runat="server">
						<asp:panel id="panelMain" Runat="server">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="5">
										<asp:LinkButton id="lnkMLSaveAndClose" Runat="server" Width="0px"></asp:LinkButton>
										<asp:LinkButton id="lnkMLClose" Runat="server" Width="0px"></asp:LinkButton>
										<asp:LinkButton id="lnkMLSave" Runat="server" Width="0px"></asp:LinkButton>
										<asp:LinkButton id="lnkMLXgfj" Runat="server" Width="0px"></asp:LinkButton>
										<asp:LinkButton id="lnkMLXgwj" Runat="server" Width="0px"></asp:LinkButton>
										<asp:LinkButton id="lnkMLXzgj" Runat="server" Width="0px"></asp:LinkButton>
										<asp:LinkButton id="lnkMLDrwj" Runat="server" Width="0px"></asp:LinkButton>
									</TD>
									<TD align="center">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR vAlign="middle" align="left" height="24">
												<TD vAlign="middle" noWrap align="left"><SPAN id="spanOPEN" style="DISPLAY: none;">
													<A id="hrefOPEN" href="javascript:hrefOPEN_onclick()" onfocus="this.blur()">&nbsp;重新打开&nbsp;</A></SPAN><SPAN id="spanHJCK" style="DISPLAY: none;">
													<A id="hrefHJCK" href="javascript:hrefHJCK_onclick()" onfocus="this.blur()">&nbsp;显示痕迹&nbsp;</A></SPAN><SPAN id="spanHJYC" style="DISPLAY: none;">
													<A id="hrefHJYC" href="javascript:hrefHJYC_onclick()" onfocus="this.blur()">&nbsp;隐藏痕迹&nbsp;</A></SPAN><SPAN id="spanYJCK" style="DISPLAY: none;">
													<A id="hrefYJCK" href="javascript:hrefYJCK_onclick()" onfocus="this.blur()">&nbsp;显示意见&nbsp;</A></SPAN><SPAN id="spanYJYC" style="DISPLAY: none;">
													<A id="hrefYJYC" href="javascript:hrefYJYC_onclick()" onfocus="this.blur()">&nbsp;隐藏意见&nbsp;</A></SPAN><SPAN id="spanXGFJ" style="DISPLAY: none;">
													<A id="hrefXGFJ" href="javascript:hrefXGFJ_onclick()" onfocus="this.blur()">&nbsp;查阅附件&nbsp;</A></SPAN><SPAN id="spanXGWJ" style="DISPLAY: none;">
													<A id="hrefXGWJ" href="javascript:hrefXGWJ_onclick()" onfocus="this.blur()">&nbsp;查相关文&nbsp;</A></SPAN><SPAN id="spanXZGJ" style="DISPLAY: none;">
													<A id="hrefXZGJ" href="javascript:hrefXZGJ_onclick()" onfocus="this.blur()">&nbsp;选择稿件&nbsp;</A></SPAN><SPAN id="spanDRWJ" style="DISPLAY: none;">
													<A id="hrefDRWJ" href="javascript:hrefDRWJ_onclick()" onfocus="this.blur()">&nbsp;更换文件&nbsp;</A></SPAN><SPAN id="spanDCWJ" style="DISPLAY: none;">
													<A id="hrefDCWJ" href="javascript:hrefDCWJ_onclick()" onfocus="this.blur()">&nbsp;导出文件&nbsp;</A></SPAN><SPAN id="spanDYWJ" style="DISPLAY: none;">
													<A id="hrefDYWJ" href="javascript:hrefDYWJ_onclick()" onfocus="this.blur()">&nbsp;打印文件&nbsp;</A></SPAN><SPAN id="spanSAVE" style="DISPLAY: none;">
													<A id="hrefSAVE" href="javascript:hrefSAVE_onclick()" onfocus="this.blur()">&nbsp;保存文件&nbsp;</A></SPAN><SPAN id="spanQXFH" style="DISPLAY: none;">
													<A id="hrefQXFH" href="javascript:hrefQXFH_onclick()" onfocus="this.blur()">&nbsp;返&nbsp;&nbsp;&nbsp;&nbsp;回&nbsp;</A></SPAN><SPAN id="spanFHSJ" style="DISPLAY:     ;">
													<A id="hrefFHSJ" href="javascript:hrefFHSJ_onclick()" onfocus="this.blur()">&nbsp;返&nbsp;&nbsp;&nbsp;&nbsp;回&nbsp;</A></SPAN>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
							</TABLE>
						</asp:panel>
						<asp:Panel id="panelError" Runat="server">
							<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="5%"></TD>
									<TD>
										<TABLE id="tabErrInfo" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
												<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" 返回 " style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();"></p></TD>
												<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5%"></TD>
								</TR>
							</TABLE>
						</asp:Panel>
						<table cellSpacing="0" cellPadding="0" align="center" border="0" style="POSITION: absolute; HEIGHT: 0px">
							<tr>
								<td>
									<input id="htxtWatchInterval" type="hidden" runat="server">
									<input id="htxtWatchSwitch" type="hidden" runat="server">
									<input id="htxtFlowTypeName" type="hidden" runat="server">
									<input id="htxtWJBS" type="hidden" runat="server">
									<input id="htxtFileUrl" type="hidden" runat="server">
									<input id="htxtISession" type="hidden" runat="server">
									<input id="htxtCursorPos" type="hidden" runat="server">
									<input id="htxtTrackRevisions" type="hidden" runat="server">
									<input id="htxtCanSelectTGWJ" type="hidden" runat="server">
									<input id="htxtCanExportFile" type="hidden" runat="server">
									<input id="htxtCanImportFile" type="hidden" runat="server">
									<input id="htxtCanQSYJ" type="hidden" runat="server">
									<input id="htxtAutoSave" type="hidden" runat="server">
									<input id="htxtEditMode" type="hidden" runat="server">
									<input id="htxtLocked" type="hidden" runat="server">
									<input id="htxtFileSpec" type="hidden" runat="server">
									<input id="htxtProtectPassword" type="hidden" runat="server">
									<input id="htxtUserName" type="hidden" runat="server">
									<input id="htxtDivLeftBody" type="hidden" runat="server">
									<input id="htxtDivTopBody" type="hidden" runat="server">
								</td>
							</tr>
							<tr>
								<td>
									<script language="javascript">
										function ScrollProc_Body() {
											var oText;
											oText=null;
											oText=document.getElementById("htxtDivTopBody");
											if (oText != null) oText.value = document.body.scrollTop;
											oText=null;
											oText=document.getElementById("htxtDivLeftBody");
											if (oText != null) oText.value = document.body.scrollLeft;
											return;
										}
										try {
											var Text;

											oText=null;
											oText=document.getElementById("htxtDivTopBody");
											if (oText != null) document.body.scrollTop = oText.value;
											oText=null;
											oText=document.getElementById("htxtDivLeftBody");
											if (oText != null) document.body.scrollLeft = oText.value;

											document.body.onscroll = ScrollProc_Body;
										}
										catch (e) {}
									</script>
								</td>
							</tr>
							<tr>
								<td>
									<uwin:popmessage id="popMessageObject" runat="server" height="10px" width="10px" Visible="False" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
			<TR>
				<td>&nbsp;</td>
				<TD height="100%" align="center" width="100%">
					<OBJECT id="objOffice" codeBase="../../cabs/jsoffice.CAB#version=6.1.1000.55" classid="clsid:AC460182-9E5E-11d5-B7C8-B8269041DD57" height="100%" width="100%" VIEWASTEXT>
						<PARAM NAME="TitlebarColor" VALUE="52479">
						<PARAM NAME="TitlebarTextColor" VALUE="0">
						<PARAM NAME="BorderStyle" VALUE="1">
						<PARAM NAME="Titlebar" VALUE="0">
						<PARAM NAME="Toolbars" VALUE="1">
						<PARAM NAME="Menubar" VALUE="0">
					</OBJECT>
				</TD>
				<td>&nbsp;</td>
			</TR>
		</TABLE>
	</BODY>
</HTML>
