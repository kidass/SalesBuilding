<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_editword.aspx.vb" Inherits="Josco.JsKernal.web.flow_editword"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�ĵ��༭��</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles01.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script src="flow_editword.js"></script>
		<script language="javascript">
			var m_strMsg_SavePrompt              = "���棺�ļ��ѷ����޸ģ�Ҫ��������/�񣩣�";
			var m_strMsg_CancelPrompt            = "���棺��ȷʵҪȡ��¼�����������/�񣩣�";
			var m_strMsg_FilePrintError          = "�����ļ���ӡ�����г���"
			var m_strMsg_FileCanNotOpen          = "�����ļ��򿪹����г����뵥��[���´�]��"
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
			var m_strMsg_EditXGWJ                = "&nbsp;�������&nbsp;";
			var m_strMsg_EditFJ                  = "&nbsp;�༭����&nbsp;";

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
					window.open("./../userlog.aspx?WJBS=" + strWJBS + "&Type=" + strType + "&Czlx=����&Czms=���ļ�","iexeFrame");
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
					window.open("./../userlog.aspx?WJBS=" + strWJBS + "&Type=" + strType + "&Czlx=��ӡ&Czms=���ļ�","iexeFrame");
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
				alert("���󣺲�֧�ֱ�������");
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
												<TD vAlign="middle" noWrap align="left"><SPAN        id="spanOPEN" style="DISPLAY: none;"><A id="hrefOPEN" href="javascript:hrefOPEN_onclick()">&nbsp;���´�&nbsp;</A></SPAN><SPAN id="spanHJCK" style="DISPLAY:     ;"><A id="hrefHJCK" href="javascript:hrefHJCK_onclick()">&nbsp;��ʾ�ۼ�&nbsp;</A></SPAN><SPAN id="spanHJYC" style="DISPLAY: none;"><A id="hrefHJYC" href="javascript:hrefHJYC_onclick()">&nbsp;���غۼ�&nbsp;</A></SPAN><SPAN id="spanYJCK" style="DISPLAY:     ;"><A id="hrefYJCK" href="javascript:hrefYJCK_onclick()">&nbsp;��ʾ���&nbsp;</A></SPAN><SPAN id="spanYJYC" style="DISPLAY: none;"><A id="hrefYJYC" href="javascript:hrefYJYC_onclick()">&nbsp;�������&nbsp;</A></SPAN><SPAN id="spanXGFJ" style="DISPLAY:     ;"><A id="hrefXGFJ" href="javascript:hrefXGFJ_onclick()">&nbsp;���ĸ���&nbsp;</A></SPAN><SPAN id="spanXGWJ" style="DISPLAY:     ;"><A id="hrefXGWJ" href="javascript:hrefXGWJ_onclick()">&nbsp;�������&nbsp;</A></SPAN><SPAN id="spanXZGJ" style="DISPLAY:     ;"><A id="hrefXZGJ" href="javascript:hrefXZGJ_onclick()">&nbsp;ѡ����&nbsp;</A></SPAN><SPAN id="spanDRWJ" style="DISPLAY:     ;"><A id="hrefDRWJ" href="javascript:hrefDRWJ_onclick()">&nbsp;�����ļ�&nbsp;</A></SPAN><SPAN id="spanDCWJ" style="DISPLAY:     ;"><A id="hrefDCWJ" href="javascript:hrefDCWJ_onclick()">&nbsp;�����ļ�&nbsp;</A></SPAN><SPAN id="spanDYWJ" style="DISPLAY:     ;"><A id="hrefDYWJ" href="javascript:hrefDYWJ_onclick()">&nbsp;��ӡ�ļ�&nbsp;</A></SPAN><SPAN id="spanSAVE" style="DISPLAY: none;"><A id="hrefSAVE" href="javascript:hrefSAVE_onclick()">&nbsp;���淵��&nbsp;</A></SPAN><SPAN id="spanQXFH" style="DISPLAY: none;"><A id="hrefQXFH" href="javascript:hrefQXFH_onclick()">&nbsp;ȡ������&nbsp;</A></SPAN><SPAN id="spanFHSJ" style="DISPLAY:     ;"><A id="hrefFHSJ" href="javascript:hrefFHSJ_onclick()">&nbsp;�����ϼ�&nbsp;</A></SPAN></TD>
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
