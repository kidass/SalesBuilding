<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_fujian_info.aspx.vb" Inherits="Josco.JsKernal.web.flow_fujian_info" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>附件信息查看与编辑窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles01.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script src="flow_fujian_info.js"></script>
		<script language="javascript">
			var m_strMsg_SavePrompt              = "警告：文件已发生修改，要保存吗（是/否）？";
			var m_strMsg_CancelPrompt            = "警告：您确实要取消录入的内容吗（是/否）？";
			var m_strMsg_FilePrintError          = "错误：文件打印过程中出错！"
			var m_strMsg_FileCanNotOpen          = "错误：文件打开过程中出错！"
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
			//btnDCWJ_onclick: export file
			function btnDCWJ_onclick() 
			{
				try 
				{
					if (! m_blnDocumentOpened)
					{
						alert(m_strMsg_FileNotOpen);
						return;
					}
					objOffice.ShowDialog(3);
					var strWJBS = "";
					strWJBS = document.getElementById("htxtWJBS").value;
					var strWJXH = "";
					strWJXH = document.getElementById("htxtWJXH").value;
					var strType = "";
					strType = document.getElementById("htxtFlowTypeName").value;
					window.open("./../userlog.aspx?WJBS=" + strWJBS + "&Type=" + strType + "&Czlx=导出&Czms=第[" + strWJXH + "]个附件","iexeFrame");
					for(var i=0; i<10000; i++);
				}
				catch(e) 
				{
					alert(m_strMsg_FileCanNotSave);
				}
			}
			//btnDYWJ_onclick: print file 
			function btnDYWJ_onclick() 
			{
				try 
				{
					if (! m_blnDocumentOpened)
					{
						alert(m_strMsg_FileNotOpen);
						return;
					}
					objOffice.ShowDialog(4); //print
					var strWJBS = "";
					strWJBS = document.getElementById("htxtWJBS").value;
					var strWJXH = "";
					strWJXH = document.getElementById("htxtWJXH").value;
					var strType = "";
					strType = document.getElementById("htxtFlowTypeName").value;
					window.open("./../userlog.aspx?WJBS=" + strWJBS + "&Type=" + strType + "&Czlx=打印&Czms=第[" + strWJXH + "]个附件","iexeFrame");
					for(var i=0; i<10000; i++);
				}
				catch(e) 
				{
					alert(m_strMsg_FilePrintError);
				}
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
				try	
				{
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/oabk.gif">
		<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
			<TR>
				<td colspan="3">
					<form id="frmFLOW_FUJIAN_INFO" method="post" runat="server">
						<asp:Panel ID="panelMain" Runat="server">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="4"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top" align="center">
										<DIV id="divContent" style="DISPLAY:none">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR vAlign="middle" align="center">
													<TD class="tips" align="left" colSpan="4" height="30">&nbsp;&nbsp;带*的内容必须输入，完成后按[确定]保存并返回(Word和Excel文件可[下载文件]后当场查看或编辑)。<asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
												</TR>
												<TR vAlign="middle">
													<TD>&nbsp;&nbsp;</TD>
													<TD class="labelAuto" align="right" nowrap>序号：</TD>
													<TD class="labelAuto" align="left"><asp:textbox id="txtWJXH" runat="server" Wrap="False" Font-Size="12px" Font-Names="宋体" Columns="8" CssClass="textbox"></asp:textbox><FONT color="#ff0000">*</FONT></TD>
													<TD>&nbsp;&nbsp;</TD>
												</TR>
												<TR>
													<TD colSpan="4" height="2"></TD>
												</TR>
												<TR vAlign="middle">
													<TD>&nbsp;&nbsp;</TD>
													<TD class="labelNotNull" align="right" nowrap>准备上传文件(大小≤<%=Josco.JsKernal.Common.jsoaConfiguration.MaxRequestLength/1024%>MB)：</TD>
													<TD class="labelNotNull" align="left"><INPUT id="hifKHDWJ" style="FONT-SIZE: 12px; FONT-FAMILY: 宋体" type="file" size="60" runat="server" NAME="hifKHDWJ"><FONT color="#ff0000">*</FONT><INPUT id="htxtWEBLOC" type="hidden" runat="server" NAME="htxtWEBLOC"><asp:textbox id="txtWJWZ" runat="server" Font-Size="12px" Font-Names="宋体" Columns="60" CssClass="textbox" ReadOnly="True" Width="0px"></asp:textbox></TD>
													<TD>&nbsp;&nbsp;</TD>
												</TR>
												<TR>
													<TD colSpan="4" height="2"></TD>
												</TR>
												<TR vAlign="middle">
													<TD>&nbsp;&nbsp;</TD>
													<TD class="labelNotNull" align="right" nowrap>文件说明：</TD>
													<TD class="labelNotNull" align="left"><asp:textbox id="txtWJSM" runat="server" Font-Size="12px" Font-Names="宋体" Columns="60" CssClass="textbox"></asp:textbox><FONT color="#ff0000">*</FONT></TD>
													<TD>&nbsp;&nbsp;</TD>
												</TR>
												<TR>
													<TD colSpan="4" height="2"></TD>
												</TR>
												<TR vAlign="middle">
													<TD>&nbsp;&nbsp;</TD>
													<TD class="label" align="right" nowrap>文件总页数：</TD>
													<TD class="label" align="left" nowrap><asp:textbox id="txtWJYS" runat="server" Font-Size="12px" Font-Names="宋体" Columns="8" CssClass="textbox"></asp:textbox><span class="labelAuto">&nbsp;&nbsp;&nbsp;&nbsp;上传缓存文件：</span><asp:textbox id="txtWEBURL" runat="server" Font-Size="12px" Font-Names="宋体" Columns="49" CssClass="textbox" ReadOnly="True"></asp:textbox></TD>
													<TD>&nbsp;&nbsp;</TD>
												</TR>
												<TR>
													<TD colSpan="4" height="2"></TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
									<TD width="4"></TD>
								</TR>
								<TR>
									<TD width="4"><asp:LinkButton id="lnkMLClose" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMLSave" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMLXzwj" Runat="server" Width="0px"></asp:LinkButton></TD>
									<TD height="36" vAlign="center" align="center"><SPAN        id="spanNRXS" style="DISPLAY:     ;"><input id="btnNRXS" type="button" class="button" value =" 显示内容 " style="WIDTH: 80px" onclick="javascript:btnNRXS_onclick();"></span><SPAN id="spanNRYC" style="DISPLAY: none;"><input id="btnNRYC" type="button" class="button" value =" 隐藏内容 " style="WIDTH: 80px" onclick="javascript:btnNRYC_onclick();"></span><SPAN id="spanXZWJ" style="DISPLAY:     ;"><input id="btnXZWJ" type="button" class="button" value =" 下载文件 " style="WIDTH: 80px" onclick="javascript:btnXZWJ_onclick();"></span><SPAN id="spanOPEN" style="DISPLAY: none;"><input id="btnOPEN" type="button" class="button" value =" 重新打开 " style="WIDTH: 80px" onclick="javascript:btnOPEN_onclick();"></span><SPAN id="spanDCWJ" style="DISPLAY: none;"><input id="btnDCWJ" type="button" class="button" value =" 另存文件 " style="WIDTH: 80px" onclick="javascript:btnDCWJ_onclick();"></span><SPAN id="spanDYWJ" style="DISPLAY: none;"><input id="btnDYWJ" type="button" class="button" value =" 打印文件 " style="WIDTH: 80px" onclick="javascript:btnDYWJ_onclick();"></span><SPAN id="spanHJCK" style="DISPLAY: none;"><input id="btnHJCK" type="button" class="button" value =" 显示痕迹 " style="WIDTH: 80px" onclick="javascript:btnHJCK_onclick();"></span><SPAN id="spanHJYC" style="DISPLAY: none;"><input id="btnHJYC" type="button" class="button" value =" 隐藏痕迹 " style="WIDTH: 80px" onclick="javascript:btnHJYC_onclick();"></span><SPAN id="spanSAVE" style="DISPLAY: none;"><input id="btnSAVE" type="button" class="button" value =" 保存返回 " style="WIDTH: 80px" onclick="javascript:btnSAVE_onclick();"></span><SPAN id="spanQXFH" style="DISPLAY: none;"><input id="btnQXFH" type="button" class="button" value =" 取消返回 " style="WIDTH: 80px" onclick="javascript:btnQXFH_onclick();"></span><SPAN id="spanFHSJ" style="DISPLAY: none;"><input id="btnFHSJ" type="button" class="button" value =" 返回上级 " style="WIDTH: 80px" onclick="javascript:btnFHSJ_onclick();"></span></TD>
									<TD width="4"></TD>
								</TR>
							</TABLE>
						</asp:Panel>
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
							<TR>
								<td>
									<input id="htxtWJXH" type="hidden" runat="server">
									<input id="htxtFlowTypeName" type="hidden" runat="server">
									<input id="htxtWJBS" type="hidden" runat="server">
									<input id="htxtTrackRevisions" type="hidden" runat="server" value="0">
									<input id="htxtProtectPassword" type="hidden" runat="server" value="">
									<input id="htxtCanExportFile" type="hidden" runat="server" value="0">
									<input id="htxtUserName" type="hidden" runat="server" value="">
									<input id="htxtEditMode" type="hidden" runat="server" value="0">
									<input id="htxtFileSpec" type="hidden" runat="server" value="">
									<input id="htxtDivLeftBody" type="hidden" runat="server">
									<input id="htxtDivTopBody" type="hidden" runat="server">
								</TD>
							</TR>
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
									<uwin:popmessage id="popMessageObject" runat="server" width="96px" height="48px" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False" Visible="False"></uwin:popmessage>
								</TD>
							</tr>
						</table>
					</form>
				</TD>
			</TR>
			<TR>
				<td>&nbsp;</TD>
				<TD height="100%" width="100%">
					<OBJECT id="objOffice" codeBase="../../cabs/jsoffice.CAB#version=5.1.2600.2180" classid="clsid:AC460182-9E5E-11d5-B7C8-B8269041DD57" height="100%" width="100%" VIEWASTEXT>
						<PARAM NAME="TitlebarColor" VALUE="52479">
						<PARAM NAME="TitlebarTextColor" VALUE="0">
						<PARAM NAME="BorderStyle" VALUE="1">
						<PARAM NAME="Titlebar" VALUE="0">
						<PARAM NAME="Toolbars" VALUE="1">
						<PARAM NAME="Menubar" VALUE="0">
					</OBJECT>
				</TD>
				<td>&nbsp;</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
