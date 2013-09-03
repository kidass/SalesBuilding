<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_xgwjfj_info.aspx.vb" Inherits="Josco.JSOA.web.flow_xgwjfj_info" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>������Ϣ�鿴��༭��</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script src="flow_xgwjfj_info.js"></script>
		<script language="javascript">
			//*********************************************************************************************************************
			//2008-08-04 zengxianglin ȫ���޸�
			//*********************************************************************************************************************
			var m_strMsg_SavePrompt              = "���棺�Ƿ�Ҫ������ļ����޸ģ�<br>[&nbsp;&nbsp;��&nbsp;&nbsp;] -- ���沢�˳�<br>[&nbsp;&nbsp;��&nbsp;&nbsp;] -- �������˳�<br>[ȡ��] -- �����༭&nbsp;&nbsp;&nbsp;&nbsp; ";
			var m_strMsg_CancelPrompt            = "���棺��ȷʵҪȡ��¼�����������/�񣩣�";
			var m_strMsg_FilePrintError          = "�����ļ���ӡ�����г���"
			var m_strMsg_FileCanNotOpen          = "�����ļ��򿪹����г���"
			var m_strMsg_FileCanNotSave          = "�����ļ���������г���"
			var m_strMsg_FileNotExcel            = "�����ļ�����[Microsoft Excel]��"
			var m_strMsg_FileNotWord             = "�����ļ�����[Microsoft Word]��"
			var m_strMsg_FileNotOpen             = "��������û�д��ļ���";
			var m_strMsg_CanNotShowRevisions     = "���󣺲�����ʾ�ۼ���";
			var m_strMsg_CanNotHideRevisions     = "���󣺲������غۼ���";
			var m_strMsg_CanNotDisableRevisions  = "���󣺲��ܹرպۼ���¼��";
			var m_strMsg_CanNotEnabledRevisions  = "���󣺲��ܴ򿪺ۼ���¼��";
			var m_strMsg_CanNotProtectDocument   = "���󣺲�����ɱ����ĵ���";
			var m_strMsg_CanNotUnProtectDocument = "���󣺲���ȡ���ĵ�������";
			var m_strMsg_CanNotCloseDocument     = "���󣺲��ܹر��ĵ���";
			var m_strMsg_CanNotGetTempLocalFile  = "���󣺲��ܻ�ȡUrl�ļ��ı�����ʱ�ļ���";
			var m_strMsg_FileNameNull            = "����û��ָ��Ҫ�򿪵��ļ���";
			var m_objNewMsgWin                   = null;
			//zengxianglin 2009-03-14
			var m_intWatchTimerId = null;
			//�༭ʱ����������ű�
			function doWatchEditTimer()
			{
				//��ȡ�����ʱ��
				var strWatchInterval = getElementValueSafe_String("htxtWatchInterval");
				//��ʾ��Ϣ
				var objMsgWin = null;
				var strMsg    = "";
				//if (((m_blnAutoSave == true) && (m_blnEditMode == true)) == false)
				//{
					strMsg = "���棺���Ѿ������༭[" + strWatchInterval + "]����δ�����棬ϵͳ��ǿ�Ʊ����������ݣ�<br>���Ժ�......";
					objMsgWin = window.showModelessDialog("../../info_button0.aspx",strMsg,"dialogHeight:170px;dialogWidth:320px;help:no;scroll:no;status:no");
				//}
				//�����ļ�
				//hrefSAVE_onclick();
				SaveOfficeDocument();
				//�ر���ʾ
				if (objMsgWin)
					objMsgWin.close();
				objMsgWin = null;
				objOffice.focus();
			}
			//���������༭ʱ������
			function doRestartWatchEditTimer()
			{
				//���عرգ�
				var strSwitch = getElementValueSafe_String("htxtWatchSwitch");
				if (strSwitch != "1")
					return;
				//���Ǳ༭״̬���Ͳ�������
				if (m_blnEditMode == false)
					return;
				//�ر����м����
				doStopWatchEditTimer();
				//�����µļ����
				var strWatchInterval = getElementValueSafe_String("htxtWatchInterval");
				var intWatchInterval = parseInt(strWatchInterval, 10) * 1000 * 60;
				m_intWatchTimerId = window.setInterval("doWatchEditTimer()", intWatchInterval);
			}
			//�ر����м����
			function doStopWatchEditTimer()
			{
				//�ر����м����
				if (m_intWatchTimerId)
					window.clearInterval(m_intWatchTimerId);
				m_intWatchTimerId = null;
			}
			//zengxianglin 2009-03-14
			//get filename
			function hifKHDWJ_onpropertychange() 
			{
				try {
					var strFilePath = document.getElementById("hifKHDWJ").value;
					if (strFilePath == "")
						return
					var objArray = strFilePath.split("\\");
					var strFileName = objArray[objArray.length-1];
					objArray = null;
					objArray = strFileName.split(".");
					if (objArray.length < 1)
						document.getElementById("txtWJSM").value = strFileName;
					else
						document.getElementById("txtWJSM").value = objArray[0];
				}
				catch(e) {}
			}
			//export file
			function btnDCWJ_onclick() 
			{
				try {
					if (! m_blnDocumentOpened) {alert(m_strMsg_FileNotOpen);return;}
					objOffice.ShowDialog(3);
					var strWJBS = document.getElementById("htxtWJBS").value;
					var strWJXH = document.getElementById("htxtWJXH").value;
					var strType = document.getElementById("htxtFlowTypeName").value;
					window.open("./../userlog.aspx?WJBS=" + strWJBS + "&Type=" + strType + "&Czlx=����&Czms=��[" + strWJXH + "]������ļ�","iexeFrame");
					for(var i=0; i<10000; i++);
				} catch(e) {alert(m_strMsg_FileCanNotSave);}
			}
			//print file 
			function btnDYWJ_onclick() 
			{
				try {
					if (! m_blnDocumentOpened) {alert(m_strMsg_FileNotOpen);return;}
					objOffice.ShowDialog(4); //print
					window.open("./../userlog.aspx?WJBS=" + strWJBS + "&Type=" + strType + "&Czlx=��ӡ&Czms=��[" + strWJXH + "]������ļ�","iexeFrame");
				} catch(e) {alert(m_strMsg_FilePrintError);}
			}
			//hide prompt message window
			function HideMessageWindow()
			{
				//zengxianglin 2008-08-14
				objOffice.focus();
				//zengxianglin 2008-08-14
				if (m_objNewMsgWin)
					m_objNewMsgWin.close();
				objOffice.focus();
			}
			//���ļ�������
			function OpenDocument()
			{
				var blnRe     = false;
				//until page load complete
				if (document.readyState.toLowerCase() != "complete") {window.setTimeout("OpenDocument()", 1000);return;}
				//close current document
				try { if (objOffice.ActiveDocument) objOffice.Close();} catch (e) {}
				//initialize
				blnRe = InitializedParameters();
				//valid file type
				switch (m_strFileType)
				{
					case "doc":
					case "xls":
						//prompt wait
						var strMsg = ""
						//if (m_blnEditMode)
						//	strMsg = "��ʾ��ϵͳ���ڴ��ļ�����[<B>&nbsp;��&nbsp;��&nbsp;</B>]��<br><br>���Ժ�...";
						//else
						//	strMsg = "��ʾ��ϵͳ���ڴ��ļ�����[<B>&nbsp;��&nbsp;��&nbsp;</B>]��<br><br>���Ժ�...";
						//if (m_objNewMsgWin)
						//	m_objNewMsgWin.close();
						//m_objNewMsgWin = window.showModelessDialog("../../info_button0.aspx",strMsg,"dialogHeight:170px;dialogWidth:320px;help:no;scroll:no;status:no");
						//zengxianglin 2008-08-14
						objOffice.focus();
						//zengxianglin 2008-08-14
						break;
					default:
						setCommandDisplay(true);
						return true;
				}
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
				//�Զ����ļ�
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/oabk.gif">
		<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
			<TR>
				<td colspan="3">
					<form id="frmFLOW_XGWJFJ_INFO" method="post" runat="server">
						<asp:Panel ID="panelMain" Runat="server">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="4"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top" align="center">
										<DIV id="divContent" style="DISPLAY:none">
											<TABLE cellSpacing="0" cellPadding="0" border="0">												
												<TR vAlign="middle" align="center">
													<TD class="tips" align="left" colSpan="4"><asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
												</TR>
												<TR vAlign="middle">
													<TD>&nbsp;&nbsp;</TD>
													<TD class="labelAuto" align="right" nowrap>��ţ�</TD>
													<TD class="labelAuto" align="left"><asp:textbox id="txtWJXH" runat="server" Wrap="False"  Columns="8" CssClass="textbox-text"></asp:textbox><FONT color="#ff0000">*</FONT></TD>
													<TD>&nbsp;&nbsp;</TD>
												</TR>
												<TR>
													<TD colSpan="4" height="2"></TD>
												</TR>
												<TR vAlign="middle">
													<TD>&nbsp;&nbsp;</TD>
													<TD class="label-text" align="right" nowrap>ѡ���ļ���</TD>
													<TD class="labelNotNull" align="left"><INPUT id="hifKHDWJ"  type="file" size="60" runat="server" NAME="hifKHDWJ" language="javascript" onpropertychange="return hifKHDWJ_onpropertychange()"><FONT color="#ff0000"></FONT><INPUT id="htxtWEBLOC" type="hidden" runat="server" NAME="htxtWEBLOC"><asp:textbox id="txtWJWZ" runat="server"  Columns="60" CssClass="textbox-text" ReadOnly="True" Width="0px"></asp:textbox>(��С��<%=Josco.JsKernal.Common.jsoaConfiguration.MaxRequestLength/1024%>MB)��</TD>
													<TD>&nbsp;&nbsp;</TD>
												</TR>
												<TR>
													<TD colSpan="4" height="2"></TD>
												</TR>
												<TR vAlign="middle">
													<TD>&nbsp;&nbsp;</TD>
													<TD class="labelNotNull" align="right" nowrap>�ļ�˵����</TD>
													<TD class="labelNotNull" align="left"><asp:textbox id="txtWJSM" runat="server"  Columns="60" CssClass="textbox-text"></asp:textbox><FONT color="#ff0000">*</FONT></TD>
													<TD>&nbsp;&nbsp;</TD>
												</TR>
												<TR>
													<TD colSpan="4" height="2"></TD>
												</TR>
												<TR vAlign="middle">
													<TD>&nbsp;&nbsp;</TD>
													<TD class="label-text" align="right" nowrap>�ļ���ҳ����</TD>
													<TD class="label-text" align="left" nowrap><asp:textbox id="txtWJYS" runat="server"  Columns="8" CssClass="textbox-text"></asp:textbox><span class="labelAuto" style="DISPLAY: none;">&nbsp;&nbsp;&nbsp;&nbsp;�ϴ������ļ���<asp:textbox id="txtWEBURL" runat="server"  Columns="49" CssClass="textbox" ReadOnly="True"></asp:textbox></span></TD>
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
									<TD height="36" vAlign="center" align="center">
										       <SPAN id="spanNRXS" style="DISPLAY: none;">
										<input id="btnNRXS" type="button" class="button" value ="չ    ��" style="WIDTH: 80px" onclick="javascript:btnNRXS_onclick();">
										</span><SPAN id="spanNRYC" style="DISPLAY: none;">
										<input id="btnNRYC" type="button" class="button" value ="��    ��" style="WIDTH: 80px" onclick="javascript:btnNRYC_onclick();">
										</span><SPAN id="spanXZWJ" style="DISPLAY: none;">
										<input id="btnXZWJ" type="button" class="button" value ="����ļ�" style="WIDTH: 80px" onclick="javascript:btnXZWJ_onclick();">
										</span><SPAN id="spanOPEN" style="DISPLAY: none;">
										<input id="btnOPEN" type="button" class="button" value ="���´�" style="WIDTH: 80px" onclick="javascript:btnOPEN_onclick();">
										</span><SPAN id="spanDCWJ" style="DISPLAY: none;">
										<input id="btnDCWJ" type="button" class="button" value ="����ļ�" style="WIDTH: 80px" onclick="javascript:btnDCWJ_onclick();">
										</span><SPAN id="spanDYWJ" style="DISPLAY: none;">
										<input id="btnDYWJ" type="button" class="button" value ="��ӡ�ļ�" style="WIDTH: 80px" onclick="javascript:btnDYWJ_onclick();">
										</span><SPAN id="spanHJCK" style="DISPLAY: none;">
										<input id="btnHJCK" type="button" class="button" value ="��ʾ�ۼ�" style="WIDTH: 80px" onclick="javascript:btnHJCK_onclick();">
										</span><SPAN id="spanHJYC" style="DISPLAY: none;">
										<input id="btnHJYC" type="button" class="button" value ="���غۼ�" style="WIDTH: 80px" onclick="javascript:btnHJYC_onclick();">
										</span><SPAN id="spanSAVE" style="DISPLAY: none;">
										<input id="btnSAVE" type="button" class="button" value ="���淵��" style="WIDTH: 80px" onclick="javascript:btnSAVE_onclick();">
										</span><SPAN id="spanQXFH" style="DISPLAY: none;">
										<input id="btnQXFH" type="button" class="button" value ="ȡ������" style="WIDTH: 80px" onclick="javascript:btnQXFH_onclick();">
										</span><SPAN id="spanFHSJ" style="DISPLAY:     ;">
										<input id="btnFHSJ" type="button" class="button" value ="��    ��" style="WIDTH: 80px" onclick="javascript:btnFHSJ_onclick();">
										</span>
									</TD>
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
												<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" ���� " style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();"></p></TD>
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
									<input id="htxtWatchInterval" type="hidden" runat="server">
									<input id="htxtWatchSwitch" type="hidden" runat="server">
									<input id="htxtWJXH" type="hidden" runat="server">
									<input id="htxtFlowTypeName" type="hidden" runat="server">
									<input id="htxtWJBS" type="hidden" runat="server">
									<input id="htxtTrackRevisions" type="hidden" runat="server" value="0">
									<input id="htxtProtectPassword" type="hidden" runat="server" value="">
									<input id="htxtCanExportFile" type="hidden" runat="server" value="0">
									<input id="htxtUserName" type="hidden" runat="server" value="">
									<input id="htxtEditMode" type="hidden" runat="server" value="0">
									<input id="htxtEditType" type="hidden" runat="server" value="0">
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
				<TD height="100%" width="100%"><div id="divOffice">
					<OBJECT id="objOffice" codeBase="../../cabs/jsoffice.CAB#version=6.1.1000.55" classid="clsid:AC460182-9E5E-11d5-B7C8-B8269041DD57" height="100%" width="100%" VIEWASTEXT>
						<PARAM NAME="TitlebarColor" VALUE="52479">
						<PARAM NAME="TitlebarTextColor" VALUE="0">
						<PARAM NAME="BorderStyle" VALUE="1">
						<PARAM NAME="Titlebar" VALUE="0">
						<PARAM NAME="Toolbars" VALUE="1">
						<PARAM NAME="Menubar" VALUE="0">
					</OBJECT></div>
				</TD>
				<td>&nbsp;</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
