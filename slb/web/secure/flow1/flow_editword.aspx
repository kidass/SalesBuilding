<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_editword.aspx.vb" Inherits="Josco.JsKernal.web.flow_editword"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>文档编辑器</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles01.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script src="flow_editword.js"></script>
		<script language="javascript">
			var m_strMsg_SavePrompt              = "警告：文件已发生修改，要保存吗（是/否）？";
			var m_strMsg_CancelPrompt            = "警告：您确实要取消录入的内容吗（是/否）？";
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
			var m_strMsg_EditFJ                  = "&nbsp;编辑附件&nbsp;";

			//hrefDCWJ_onclick: save as another file 
			function hrefDCWJ_onclick() 
			{
				try 
				{
					if (! m_blnDocumentOpened)
					{
						alert(m_strMsg_FileNotOpen);
						return;
					}
					objOffice.ShowDialog(3); //open
					var objIexeFrame = null;
					var strWJBS = "";
					strWJBS = document.getElementById("htxtWJBS").value;
					var strType = "";
					strType = document.getElementById("htxtFlowTypeName").value;
					window.open("./../userlog.aspx?WJBS=" + strWJBS + "&Type=" + strType + "&Czlx=导出&Czms=主文件","iexeFrame");
					for(var i=0; i<10000; i++);
				}
				catch(e) 
				{
					alert(m_strMsg_FileCanNotSave);
				}
			}
			//hrefDYWJ_onclick: print file 
			function hrefDYWJ_onclick() 
			{
				try 
				{
					if (! m_blnDocumentOpened)
					{
						alert(m_strMsg_FileNotOpen);
						return;
					}
					objOffice.ShowDialog(4); //print
					var objIexeFrame = null;
					var strWJBS = "";
					strWJBS = document.getElementById("htxtWJBS").value;
					var strType = "";
					strType = document.getElementById("htxtFlowTypeName").value;
					window.open("./../userlog.aspx?WJBS=" + strWJBS + "&Type=" + strType + "&Czlx=打印&Czms=主文件","iexeFrame");
					for(var i=0; i<10000; i++);
				}
				catch(e) 
				{
					alert(m_strMsg_FilePrintError);
				}
			}
			//hrefXZGJ_onclick: open selecting tougao window
			function hrefXZGJ_onclick() 
			{
				alert("错误：不支持本操作！");
				return;
			}
			function OpenDocument()
			{
				//close current document
				try {
					if (objOffice.ActiveDocument)
						objOffice.Close();
				} catch (e) {}
				
				//initialize
				if (InitializedParameters() == false)
					return false;
				
				//open office document
				if (OpenOfficeDocument() == false)
				{
					spanOPEN.style.display = "";
					return false;
				}
				else
				{
					spanOPEN.style.display = "none";
					return true;
				}
			}
			function document_onreadystatechange()
			{
				window.setTimeout("OpenDocument()", 500);
			}
			function document_onbeforeunload()
			{
				try	{
					objOffice.Close();
				} catch (e) {}
			}
		</script>
		<script language="javascript" for="objOffice" event="BeforeDocumentSaved">
			return objOffice_BeforeDocumentSaved()
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
												<TD vAlign="middle" noWrap align="left"><SPAN        id="spanOPEN" style="DISPLAY: none;"><A id="hrefOPEN" href="javascript:hrefOPEN_onclick()">&nbsp;重新打开&nbsp;</A></SPAN><SPAN id="spanHJCK" style="DISPLAY:     ;"><A id="hrefHJCK" href="javascript:hrefHJCK_onclick()">&nbsp;显示痕迹&nbsp;</A></SPAN><SPAN id="spanHJYC" style="DISPLAY: none;"><A id="hrefHJYC" href="javascript:hrefHJYC_onclick()">&nbsp;隐藏痕迹&nbsp;</A></SPAN><SPAN id="spanYJCK" style="DISPLAY:     ;"><A id="hrefYJCK" href="javascript:hrefYJCK_onclick()">&nbsp;显示意见&nbsp;</A></SPAN><SPAN id="spanYJYC" style="DISPLAY: none;"><A id="hrefYJYC" href="javascript:hrefYJYC_onclick()">&nbsp;隐藏意见&nbsp;</A></SPAN><SPAN id="spanXGFJ" style="DISPLAY:     ;"><A id="hrefXGFJ" href="javascript:hrefXGFJ_onclick()">&nbsp;查阅附件&nbsp;</A></SPAN><SPAN id="spanXGWJ" style="DISPLAY:     ;"><A id="hrefXGWJ" href="javascript:hrefXGWJ_onclick()">&nbsp;查相关文&nbsp;</A></SPAN><SPAN id="spanXZGJ" style="DISPLAY:     ;"><A id="hrefXZGJ" href="javascript:hrefXZGJ_onclick()">&nbsp;选择稿件&nbsp;</A></SPAN><SPAN id="spanDRWJ" style="DISPLAY:     ;"><A id="hrefDRWJ" href="javascript:hrefDRWJ_onclick()">&nbsp;更换文件&nbsp;</A></SPAN><SPAN id="spanDCWJ" style="DISPLAY:     ;"><A id="hrefDCWJ" href="javascript:hrefDCWJ_onclick()">&nbsp;导出文件&nbsp;</A></SPAN><SPAN id="spanDYWJ" style="DISPLAY:     ;"><A id="hrefDYWJ" href="javascript:hrefDYWJ_onclick()">&nbsp;打印文件&nbsp;</A></SPAN><SPAN id="spanSAVE" style="DISPLAY: none;"><A id="hrefSAVE" href="javascript:hrefSAVE_onclick()">&nbsp;保存返回&nbsp;</A></SPAN><SPAN id="spanQXFH" style="DISPLAY: none;"><A id="hrefQXFH" href="javascript:hrefQXFH_onclick()">&nbsp;取消返回&nbsp;</A></SPAN><SPAN id="spanFHSJ" style="DISPLAY:     ;"><A id="hrefFHSJ" href="javascript:hrefFHSJ_onclick()">&nbsp;返回上级&nbsp;</A></SPAN></TD>
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
					<OBJECT id="objOffice" codeBase="../../cabs/jsoffice.CAB#version=5.1.2600.2180" classid="clsid:AC460182-9E5E-11d5-B7C8-B8269041DD57" height="100%" width="100%" VIEWASTEXT>
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
