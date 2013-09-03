<%@ Page Language="vb" AutoEventWireup="false" Codebehind="main.aspx.vb" Inherits="Josco.JsKernal.web.main"%>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<%@ Import namespace="Josco.JsKernal.Common.Utilities.PulicParameters" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ϵͳ������</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="../mnuStyle01.css" type="text/css" rel="stylesheet"/>
		<LINK href="../styles01.css" type="text/css" rel="stylesheet"/>
		<script src="../scripts/transkey.js"></script>
		<script language="vb" runat="server">
			'��ȡUnicode���ַ���ת��ΪMBCS�ַ������ֽڳ���
			Public Function getStringLength(ByVal strValue As String) As Integer
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				getStringLength = objPulicParameters.getStringLength(strValue)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
			End Function

			'��Unicode���ַ����л�ȡָ�����ȵ��ַ��������Ȱ�MBCS����
			Public Function getSubString(ByVal strValue As String, ByVal intLen As Integer) As String
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				getSubString = objPulicParameters.getSubString(strValue, intLen)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
			End Function

			'��ȡӦ�ø�Ŀ¼HTTP·��
			Public Function getApplicationPath() As String
				getApplicationPath = Request.ApplicationPath
			End Function

			'----------------------------------------------------------------
			' ����û��Ȩ�޵Ĳ˵�
			'----------------------------------------------------------------
			Private Sub mnuMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMain.Load
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim objsystemAppManager As New Josco.JsKernal.BusinessFacade.systemAppManager
				Dim objMokuaiQXData As Josco.JsKernal.Common.Data.AppManagerData = Nothing
				Dim strErrMsg As String = ""
				Try
					'���ݵ�¼�û���ȡģ��Ȩ������
					If MyBase.UserId.ToUpper() = "SA" Then
						Exit Try
					End If
					'��ͨ�û�Ȩ��
					If objsystemAppManager.getDBUserMokuaiQXData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, objMokuaiQXData) = True Then
						Dim strMKMC As String = Josco.JsKernal.Common.Data.AppManagerData.FIELD_GL_B_YINGYONGXITONG_MOKUAIQX_MKMC
						Dim blnVisible As Boolean = False
						Dim strParamValue As String = ""
						Dim strFilter As String = ""
						With objMokuaiQXData.Tables(Josco.JsKernal.Common.Data.AppManagerData.TABLE_GL_B_YINGYONGXITONG_MOKUAIQX)
							strParamValue = "Ӧ��ϵͳ-Ȩ�޹���-�ļ�ת��"
							strFilter = strMKMC + " = '" + strParamValue + "'"
							.DefaultView.RowFilter = strFilter
							If .DefaultView.Count < 1 Then
								Me.mnuMain.FindItemById("mnuXTGL_5001").Visible = False
							End If
							blnVisible = blnVisible Or Me.mnuMain.FindItemById("mnuXTGL_5001").Visible
							'*******************************************************************************
							strParamValue = "Ӧ��ϵͳ-���⴦��-�������ļ�����"
							strFilter = strMKMC + " = '" + strParamValue + "'"
							.DefaultView.RowFilter = strFilter
							If .DefaultView.Count < 1 Then
								Me.mnuMain.FindItemById("mnuXTGL_5002").Visible = False
							End If
							blnVisible = blnVisible Or Me.mnuMain.FindItemById("mnuXTGL_5002").Visible
							Me.mnuMain.FindItemById("mnuXTGL_Bar4").Visible = blnVisible
							'*******************************************************************************
							'zengxianglin 2009-01-07
							strParamValue = "Ӧ��ϵͳ-ϵͳ����-���±���-������Դ״�������"
							strFilter = strMKMC + " = '" + strParamValue + "'"
							.DefaultView.RowFilter = strFilter
							If .DefaultView.Count < 1 Then
								Me.mnuMain.FindItemById("mnuRSGL_6001_0001").Enabled = False
							End If
							'zengxianglin 2009-01-07
							'*******************************************************************************
							'zengxianglin 2009-01-09
							strParamValue = "Ӧ��ϵͳ-ϵͳ����-���±���-Խ�㼯���ڸ���Ա����������ͳ�Ʊ�"
							strFilter = strMKMC + " = '" + strParamValue + "'"
							.DefaultView.RowFilter = strFilter
							If .DefaultView.Count < 1 Then
								Me.mnuMain.FindItemById("mnuRSGL_6001_0004").Enabled = False
							End If
							'zengxianglin 2009-01-09
							'*******************************************************************************
							'zengxianglin 2009-05-14
							strParamValue = "Ӧ��ϵͳ-���¹���-��������-�Ǽ�����"
							strFilter = strMKMC + " = '" + strParamValue + "'"
							.DefaultView.RowFilter = strFilter
							If .DefaultView.Count < 1 Then
								Me.mnuMain.FindItemById("mnuRSGL_4001").Enabled = False
							End If
							'zengxianglin 2009-05-14
						End With
					End If
				Catch ex As Exception
				End Try
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
				Josco.JsKernal.BusinessFacade.systemAppManager.SafeRelease(objsystemAppManager)
				Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objMokuaiQXData)
			End Sub

			'zengxianglin 2009-01-07 ����
			Private Sub doPrint_RSBB_RLZYZKDCB(ByVal strControlId As String)

				Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
				Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
				Dim strErrMsg As String = ""
				Dim intStep As Integer

				Try
					intStep = 1
					'����ͳ������
					If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
						objMessageProcess.doInputBox(Me.popMessageObject, "������ͳ�ƽ�ֹ����(yyyy-MM-dd)��", strControlId, intStep, Now.ToString("yyyy-MM-dd"))
						Exit Try
					Else
						objMessageProcess.doResetPopMessage(Me.popMessageObject)
					End If

					'��ȡ������������
					intStep = 2
					If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
						'��ȡ��������
						Dim strJZRQ As String = ""
						strJZRQ = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
						If strJZRQ Is Nothing Then strJZRQ = ""
						strJZRQ = strJZRQ.Trim
						If strJZRQ = "" Then
							strErrMsg = "����û��ָ�����ڣ�"
							GoTo errProc
						End If
						If objPulicParameters.isDatetimeString(strJZRQ) = False Then
							strErrMsg = "������Ч�����ڣ�"
							GoTo errProc
						End If
						'���ģ���ļ�
						Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "������ҵ_���¹���_������Դ״�������.xls"
						Dim strMBLOC As String = Server.MapPath(strMBURL)
						Dim blnFound As Boolean
						If objBaseLocalFile.doFileExisted(strErrMsg, strMBLOC, blnFound) = False Then
							GoTo errProc
						End If
						If blnFound = False Then
							strErrMsg = "����[" + strMBLOC + "]�����ڣ�"
							GoTo errProc
						End If
						'����ģ���ļ�������Ŀ¼
						Dim strTempPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
						Dim strTempFile As String
						strTempPath = Server.MapPath(strTempPath)
						If objBaseLocalFile.doCopyToTempFile(strErrMsg, strMBLOC, strTempPath, strTempFile) = False Then
							GoTo errProc
						End If
						Dim strTempSpec As String
						strTempSpec = objBaseLocalFile.doMakePath(strTempPath, strTempFile)
						'�������
						Dim strMacroValue As String = ""
						Dim strMacroName As String = ""
						strMacroName = "$Macro$TJRQ$"
						strMacroValue = strJZRQ
						If objsystemEstateRenshiGeneral.doPrint_RSBB_RLZYZKDCB(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJZRQ, strTempSpec, strMacroName, strMacroValue) = False Then
							GoTo errProc
						End If
						'��ʾExcel
						Dim strTempUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strTempFile
						objMessageProcess.doOpenUrl(Me.popMessageObject, strTempUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
					End If
				Catch ex As Exception
					strErrMsg = ex.Message
					GoTo errProc
				End Try

				Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
				Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
				Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
				Exit Sub
	errProc:
				objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
				Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
				Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
				Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
				Exit Sub

			End Sub
			'zengxianglin 2009-01-07 ����

			'zengxianglin 2009-01-09 ����
			Private Sub doPrint_RSBB_YXJTZGRYJQTSJTJB(ByVal strControlId As String)

				Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
				Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
				Dim strErrMsg As String = ""
				Dim intStep As Integer

				Try
					intStep = 1
					'����ͳ������
					If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
						objMessageProcess.doInputBox(Me.popMessageObject, "������ͳ�ƽ�ֹ����(yyyy-MM-dd)��", strControlId, intStep, Now.ToString("yyyy-MM-dd"))
						Exit Try
					Else
						objMessageProcess.doResetPopMessage(Me.popMessageObject)
					End If

					'��ȡ������������
					intStep = 2
					If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
						'��ȡ��������
						Dim strJZRQ As String = ""
						strJZRQ = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
						If strJZRQ Is Nothing Then strJZRQ = ""
						strJZRQ = strJZRQ.Trim
						If strJZRQ = "" Then
							strErrMsg = "����û��ָ�����ڣ�"
							GoTo errProc
						End If
						If objPulicParameters.isDatetimeString(strJZRQ) = False Then
							strErrMsg = "������Ч�����ڣ�"
							GoTo errProc
						End If
						'���ģ���ļ�
						Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "������ҵ_���¹���_Խ�㼯���ڸ���Ա����������ͳ�Ʊ�.xls"
						Dim strMBLOC As String = Server.MapPath(strMBURL)
						Dim blnFound As Boolean
						If objBaseLocalFile.doFileExisted(strErrMsg, strMBLOC, blnFound) = False Then
							GoTo errProc
						End If
						If blnFound = False Then
							strErrMsg = "����[" + strMBLOC + "]�����ڣ�"
							GoTo errProc
						End If
						'����ģ���ļ�������Ŀ¼
						Dim strTempPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
						Dim strTempFile As String
						strTempPath = Server.MapPath(strTempPath)
						If objBaseLocalFile.doCopyToTempFile(strErrMsg, strMBLOC, strTempPath, strTempFile) = False Then
							GoTo errProc
						End If
						Dim strTempSpec As String
						strTempSpec = objBaseLocalFile.doMakePath(strTempPath, strTempFile)
						'�������
						Dim strMacroValue As String = ""
						Dim strMacroName As String = ""
						strMacroName = "$Macro$TJRQ$"
						strMacroValue = strJZRQ
						If objsystemEstateRenshiGeneral.doPrint_RSBB_YXJTZGRYJQTSJTJB(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJZRQ, strTempSpec, strMacroName, strMacroValue) = False Then
							GoTo errProc
						End If
						'��ʾExcel
						Dim strTempUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strTempFile
						objMessageProcess.doOpenUrl(Me.popMessageObject, strTempUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
					End If
				Catch ex As Exception
					strErrMsg = ex.Message
					GoTo errProc
				End Try

				Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
				Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
				Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
				Exit Sub
	errProc:
				objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
				Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
				Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
				Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
				Exit Sub

			End Sub
			'zengxianglin 2009-01-09 ����

			'zengxianglin 2009-05-14
			Private Sub doGRLL_AddNew(ByVal strControlId As String)

				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
				Dim strErrMsg As String = ""

				Try
					'׼�����ýӿ�
					Dim objIEstateRsGrllInfo As Josco.JSOA.BusinessFacade.IEstateRsGrllInfo = Nothing
					Dim strUrl As String = ""
					objIEstateRsGrllInfo = New Josco.JSOA.BusinessFacade.IEstateRsGrllInfo
					With objIEstateRsGrllInfo
						.iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
						.iRYDM = ""
						.iSourceControlId = strControlId
						.iReturnUrl = Request.Url.AbsolutePath
					End With

					'����ģ��
					Dim strNewSessionId As String = ""
					strNewSessionId = objPulicParameters.getNewGuid()
					If strNewSessionId = "" Then
						strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
						GoTo errProc
					End If
					Session.Add(strNewSessionId, objIEstateRsGrllInfo)
					strUrl = ""
					strUrl += "./estate/renshi/estate_rs_grll_info.aspx"
					strUrl += "?"
					strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
					strUrl += "="
					strUrl += strNewSessionId
					Response.Redirect(strUrl)
				Catch ex As Exception
					strErrMsg = ex.Message
					GoTo errProc
				End Try

				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
				Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
				Exit Sub
	errProc:
				objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
				Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
				Exit Sub

			End Sub
			'zengxianglin 2009-05-14

			Private Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click

				Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
				Dim strErrMsg As String

				Try
					'��ȡ����˵�
					Dim strMenuId As String = Me.htxtSelectMenuID.Value
					'����˵�����
					Select Case strMenuId.ToUpper()
						Case "mnuRSGL_6001_0001".ToUpper
							'zengxianglin 2009-01-07
							Me.doPrint_RSBB_RLZYZKDCB("lnkMenu")
							'zengxianglin 2009-01-07
						Case "mnuRSGL_6001_0004".ToUpper
							'zengxianglin 2009-01-09
							Me.doPrint_RSBB_YXJTZGRYJQTSJTJB("lnkMenu")
							'zengxianglin 2009-01-09
						Case "mnuRSGL_4001".ToUpper
							'zengxianglin 2009-05-14
							Me.doGRLL_AddNew("lnkMenu")
							'zengxianglin 2009-05-14
						Case Else
					End Select
				Catch ex As Exception
					strErrMsg = ex.Message
					GoTo errProc
				End Try

				Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
				Exit Sub
	errProc:
				objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
				Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
				Exit Sub

			End Sub
		    '������ 2008-04-02
		    
		    '��ʾ������������
		    Public Sub doDisplay_Dbsy()
		        Dim strTable As String = Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE
		        Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
		        Dim objgrswMyTaskData As Josco.JsKernal.Common.Data.grswMyTaskData = Nothing
		        Dim blnWriteNull As Boolean = False
		        Dim intMaxItemLen As Integer = 62
		        Dim intMaxItems As Integer = 7
		        
		        Try
		            '��ȡ����
		            objgrswMyTaskData = getDataSet_DBSY()
		            '�޷���ȡ����
		            If objgrswMyTaskData Is Nothing Then blnWriteNull = True
		            'û������
		            With objgrswMyTaskData.Tables(strTable)
		                If .Rows.Count < 1 Then blnWriteNull = True
		                intMaxItems = .Rows.Count
		            End With
		            If blnWriteNull = True Then
		                Response.Write("&nbsp;")
		                Exit Try
		            End If
		            '�������
		            Dim intLen As Integer = 0
		            Dim strBS As String = ""
		            Dim strRQ As String = ""
		            Dim strBT As String = ""
		            Dim strLX As String = ""
		            
		            Dim i As Integer = 0
		            Response.Write("<table cellpadding='0' cellspacing='0' border='0'>" + vbCr)
		            With objgrswMyTaskData.Tables(strTable).DefaultView
		                For i = 0 To intMaxItems - 1 Step 1
		                    'û���㹻����
		                    If i >= .Count Then Exit For
		                    '��ȡ����
		                    strBS = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBS), "")
		                    strBT = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBT), "")
		                    strRQ = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ), "", "MM.dd")
		                    strLX = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJLX), "")
		                    
		                    intLen = getStringLength(strBT)
		                    If intLen + (strRQ.Length + 2) > intMaxItemLen Then
		                        strBT = getSubString(strBT, intMaxItemLen - (strRQ.Length + 2) - 1) + "��(" + strRQ + ")"
		                    Else
		                        strBT = strBT + "(" + strRQ + strLX + ")"
		                    End If
		                   
		                    Dim strUserId As String
		                    Dim strPassword As String
					
		                    strUserId = MyBase.UserId
		                    strPassword = MyBase.UserPassword
		                    
		                    '��ʾ����
		                    Response.Write("  <tr>" + vbCr)
		                    Response.Write("    <td height='18' class='label12_01'>" + vbCr)
		                    Response.Write("      &nbsp;&nbsp;��<A href='#' onClick=openWindow('./gzflow/gzsp_flow.aspx?ID=" + strUserId + "&password=" + strPassword + "&type=DBSY&wjbs=" + strBS + "') class='hrefcss12_01'>" + strBT + "</A>" + vbCr)
		                    Response.Write("    </td>" + vbCr)
		                    Response.Write("  </tr>" + vbCr)
		                Next
		            End With
		            Response.Write("</table>" + vbCr)
		        Catch ex As Exception
		        End Try
		        Josco.JsKernal.Common.Data.grswMyTaskData.SafeRelease(objgrswMyTaskData)
		        Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
		    End Sub
		    
		    '��ȡ�ܹ��Ķ���δ���������ݼ��������������ڡ�����
		    Public Function getDataSet_DBSY() As Josco.JsKernal.Common.Data.grswMyTaskData
		        Dim objsystemMyTask As New Josco.JsKernal.BusinessFacade.systemMyTask
		        Dim objDataSet As Josco.JsKernal.Common.Data.grswMyTaskData = Nothing
		        Dim strErrMsg As String = ""
		        Try
		            If objsystemMyTask.getDataSetDBSY(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserXM, objDataSet) = True Then
		                objDataSet.Tables(0).DefaultView.Sort = "�������� desc"
		                getDataSet_DBSY = objDataSet
		            End If
		        Catch ex As Exception
		            getDataSet_DBSY = Nothing
		        End Try
		        Josco.JsKernal.BusinessFacade.systemMyTask.SafeRelease(objsystemMyTask)
		    End Function
		</script>
		<script language="javascript">
            function openWindow(url) 
            {
				try 
				{
					url = encodeURI(url);
					window.open(url,"mainFrame");
				} catch (e) {}
            }
            function closeWindow() 
            {
				try 
				{
					if (window.parent)
						window.parent.close();
				} catch (e) {}
            } 
			//������ 2008-03-29
            function openChat() 
            {
				try
				{
					var objLeftFrame = null;
					objLeftFrame = getFrame(window.parent.frames, "leftFrame");
					if (objLeftFrame)
						objLeftFrame.window.execScript("openChat();");
				} catch (e) {}
            }
			//������ 2008-03-29
			function minLeftFrame() 
			{
				try
				{
					window.parent.doHideLeftFrame(); 
				} catch (e) {}
			}
			function document_onreadystatechange() 
			{
				minLeftFrame();
			}
			//������ 2008-04-02
			function doMenuItemClick(menuItemId) 
			{
				try 
				{
					document.all("htxtSelectMenuID").value = menuItemId;
					window.setTimeout("__doPostBack('lnkMenu', '');", 500);
				} catch (e) {}
			}
			//������ 2008-04-02
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
			return document_onreadystatechange()
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../images/bgmain.gif">
		<form id="frmMAIN" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<td><!--������ 2008-04-02 --><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMenu" Runat="server" Width="0px"></asp:LinkButton><INPUT id="htxtSelectMenuID" type="hidden" size="1" runat="server"><!--������ 2008-04-02 --></td>
						<TD>
							<ComponentArt:Menu id="mnuMain" runat="server" width="100%" Orientation="Horizontal" CssClass="TopGroup"
								DefaultGroupCssClass="MenuGroup" DefaultSubGroupExpandOffsetX="-10" DefaultSubGroupExpandOffsetY="-5"
								DefaultItemLookID="DefaultItemLook" TopGroupItemSpacing="1" DefaultGroupItemSpacing="2" ImagesBaseUrl="../images/"
								EnableViewState="false" ExpandDelay="100" DefaultTarget="mainFrame">
								<ITEMS>
									<COMPONENTART:MENUITEM id="mnuXTZY" Target="mainFrame" Text="��ҳ" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuXTZY_1001" Target="mainFrame" Text="��ӭҳ��" ClientSideCommand="openWindow('../areaContent.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTZY_Bar1" Target="mainFrame" LookId="BreakItem" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTZY_2001" Target="mainFrame" Text="�û���Ϣ" ClientSideCommand="openWindow('./userinfo.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTZY_2002" Target="mainFrame" Text="��������" ClientSideCommand="openWindow('./modifypwd.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTZY_Bar2" Target="mainFrame" LookId="BreakItem" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTZY_3001" Target="mainFrame" Text="�˳�ϵͳ" ClientSideCommand="closeWindow();" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuGRSW" Target="mainFrame" Text="���˹���" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuGRSW_1001" Target="mainFrame" Text="�ҵĸ��๤��" ClientSideCommand="openWindow('./grsw/grsw_wdsy.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_Bar1" Target="mainFrame" LookId="BreakItem" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_2001" Target="mainFrame" Text="�ҵ�ί������" ClientSideCommand="openWindow('./grsw/grsw_lkly.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_2002" Target="mainFrame" Text="�ҵĳ������" ClientSideCommand="openWindow('./grsw/grsw_cyyj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_3001" Target="mainFrame" Text="��ʱ��Ϣ����" ClientSideCommand="openChat();" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
		                                <COMPONENTART:MENUITEM id="mnuGRSW_5001" Target="mainFrame" Text="�ƽ��ҵ��ļ�" ClientSideCommand="openWindow('./grsw/grsw_yijiao.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
		                                <COMPONENTART:MENUITEM id="mnuGRSW_5002" Target="mainFrame" Text="�����ƽ��ļ�" ClientSideCommand="openWindow('./grsw/grsw_jieshou.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
		                                <COMPONENTART:MENUITEM id="mnuGRSW_6001" Target="mainFrame" Text="�ҵĸ�������" ClientSideCommand="openWindow('./grsw/grsw_config.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuHTGL" Target="mainFrame" Text="��ͬ����" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuHTGL_1001" Target="mainFrame" Text="����ȷ�������"   ClientSideCommand="openWindow('./estate/ershou/estate_es_qrsmm_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_1002" Target="mainFrame" Text="����ȷ�������"   ClientSideCommand="openWindow('./estate/ershou/estate_es_qrszl_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_1003" Target="mainFrame" Text="����ȷ�������"   ClientSideCommand="openWindow('./estate/ershou/estate_es_qrsqt_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2001" Target="mainFrame" Text="���ֺ�ͬ����"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_list.aspx');"   DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2002" Target="mainFrame" Text="����������ͬ��ѯ" ClientSideCommand="openWindow('./estate/ershou/estate_es_hetongmm_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2003" Target="mainFrame" Text="�������޺�ͬ��ѯ" ClientSideCommand="openWindow('./estate/ershou/estate_es_hetongzl_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2004" Target="mainFrame" Text="����������ͬ��ѯ" ClientSideCommand="openWindow('./estate/ershou/estate_es_hetongqt_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2005" Target="mainFrame" Text="���ֺ�ͬ���"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_sh.aspx');"     DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2006" Target="mainFrame" Text="��ͬ�ۿ����"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_zksh.aspx');"   DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_3001" Target="mainFrame" Text="��ͬ�참����"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_bl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_4001" Target="mainFrame" Text="��ͬ�������"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_jss_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_4002" Target="mainFrame" Text="���������"       ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_jss_sh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_4003" Target="mainFrame" Text="�����鲹��Ӷ��"   ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_jss_bjyj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_5001" Target="mainFrame" Text="��ͬ�᰸����"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_wc.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_Bar5" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_6001" Target="mainFrame" Text="ǿ�Ƹ���ҵ������" ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_qzbj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuCWSZ" Target="mainFrame" Text="������֧" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuCWSZ_1001" Target="mainFrame" Text="Ʊ�ݷ��Ź���" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_piaoju_fafang.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_1002" Target="mainFrame" Text="Ʊ��ʹ�ù���" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_piaoju_shiyong.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_1003" Target="mainFrame" Text="Ʊ��ʹ�ü��" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_piaoju_jiankong.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_2001" Target="mainFrame" Text="������֧�Ǽ�" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_sssf.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_2002" Target="mainFrame" Text="���ý�ת����" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_sssf_jz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_2003" Target="mainFrame" Text="������֧���" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_sssf_sh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_3001" Target="mainFrame" Text="������̨֧��" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_sztz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuKQGL" Target="mainFrame" Text="���ڹ���" DisabledLookId="MenuItemDisabledLook">
									    <COMPONENTART:MENUITEM id="mnuKQGL_1001" Target="mainFrame" Text="���ڼ�¼"   ClientSideCommand="openWindow('./kqgl/kqgl_kqjl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1002" Target="mainFrame" Text="���ݼٹ���"   ClientSideCommand="openWindow('./kqgl/kqgl_nxj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1003" Target="mainFrame" Text="��Ӧ�ݼٹ���"   ClientSideCommand="openWindow('./kqgl/kqgl_yxj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1004" Target="mainFrame" Text="���ݼ�һ����"   ClientSideCommand="openWindow('./kqgl/kqgl_bxj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1005" Target="mainFrame" Text="��ٹ���"   ClientSideCommand="openWindow('./kqgl/kqgl_qjd.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1006" Target="mainFrame" Text="��Ӧ�ݼ�ְ������"   ClientSideCommand="openWindow('./kqgl/kqgl_yxj_zj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1007" Target="mainFrame" Text="��ӡ��¼"   ClientSideCommand="openWindow('./kqgl/kqjl_print.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM> 
									<COMPONENTART:MENUITEM id="mnuRSGL" Target="mainFrame" Text="���¹���" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuRSGL_1001" Target="mainFrame" Text="Ӷ������׼" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuRSGL_1001_0001" Target="mainFrame" Text="��׼����(һ)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_yongjinjitibiaozhun.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_1001_0002" Target="mainFrame" Text="��׼����(��)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_yongjinjitibiaozhun_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_1001_0003" Target="mainFrame" Text="��׼����(��)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_yongjinjitibiaozhun_x3.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_1001_0004" Target="mainFrame" Text="��׼����(��)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_yongjinjitibiaozhun_x4.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_1002" Target="mainFrame" Text="ҵ�����˱�׼" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuRSGL_1002_0001" Target="mainFrame" Text="��׼����(һ)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_kaohebiaozhun.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_1002_0002" Target="mainFrame" Text="��׼����(��)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_kaohebiaozhun_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_2002_0005" Target="mainFrame" Text="�����ۺϹ���" ClientSideCommand="openWindow('./gzflow/gzsp_flow.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_2001" Target="mainFrame" Text="����ҵ����Ա����ܹ�" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_mn.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_2002" Target="mainFrame" Text="����ҵ����Ա�ܹ�����" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0001" Target="mainFrame" Text="��Ա��ְ" ClientSideCommand="openWindow('./estate/nrenshi/estate_rs_ruzhi.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0002" Target="mainFrame" Text="�ڲ�����" ClientSideCommand="openWindow('./estate/nrenshi/estate_rs_nbtz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>	
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0003" Target="mainFrame" Text="�뿪��λ" ClientSideCommand="openWindow('./estate/nrenshi/estate_rs_lztz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>									
										    <COMPONENTART:MENUITEM id="mnuRSGL_2002_0004" Target="mainFrame" Text="ʵϰ����ְ" ClientSideCommand="openWindow('./estate/nrenshi/estate_rs_shixisheng.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											
										</COMPONENTART:MENUITEM>	
										<COMPONENTART:MENUITEM id="mnuRSGL_2010" Target="mainFrame" Text="�칫��ר�üܹ�����" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0006" Target="mainFrame" Text="��Ա��ְ" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_add_mn.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0007" Target="mainFrame" Text="�ڲ�����" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_mdfy_mn.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>	
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0008" Target="mainFrame" Text="�뿪��λ" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_del_mn.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>									
										</COMPONENTART:MENUITEM>									
										<COMPONENTART:MENUITEM id="mnuRSGL_2003" Target="mainFrame" Text="����ҵ����Ա�ܹ��ֶ�����" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_2004" Target="mainFrame" Text="����ҵ����Ա�ܹ��䶯��ѯ" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_bdls_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_3001" Target="mainFrame" Text="��ְԱ������" ClientSideCommand="openWindow('./estate/renshi/estate_rs_rskp_main.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_3002" Target="mainFrame" Text="Ա����ѵ����" ClientSideCommand="openWindow('./estate/renshi/estate_rs_rskp_pxjl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_3003" Target="mainFrame" Text="���±䶯����" ClientSideCommand="openWindow('./estate/renshi/estate_rs_rskp_ydjl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_3004" Target="mainFrame" Text="�Ͷ���ͬ����" ClientSideCommand="openWindow('./estate/renshi/estate_rs_rskp_ldht.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_4001" Target="mainFrame" Text="�Ǽ���ְ����" ClientSideCommand="doMenuItemClick('mnuRSGL_4001');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_4002" Target="mainFrame" Text="��ְ��������" ClientSideCommand="openWindow('./estate/renshi/estate_rs_grll_main.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_4003" Target="mainFrame" Text="��Ա¼������" ClientSideCommand="openWindow('./estate/renshi/estate_rs_luyong_main.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_5001" Target="mainFrame" Text="ְԱҵ������" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuRSGL_5001_0003" Target="mainFrame" Text="��ʽ��Ա����(���˱�׼һ)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_eszszgkh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_5001_0004" Target="mainFrame" Text="������Ա����(���˱�׼һ)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_essyzgkh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>	
											<COMPONENTART:MENUITEM id="mnuRSGL_5001_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_5001_0001" Target="mainFrame" Text="ҵ��Ӣ����(���˱�׼��)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_kh_jy.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_5001_0002" Target="mainFrame" Text="ҵ�����ܿ���(���˱�׼��)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_kh_gl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>	
										<COMPONENTART:MENUITEM id="mnuRSGL_Bar5" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_6001" Target="mainFrame" Text="����ͳ�Ʊ���" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0001" Target="mainFrame" Text="������Դ״�������"               ClientSideCommand="doMenuItemClick('mnuRSGL_6001_0001');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0002" Target="mainFrame" Text="��Ա�����춯��"                   ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_esryzjydb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0003" Target="mainFrame" Text="������Դ��Ϣ���ܱ�"               ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_esrlzyxxhzb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0004" Target="mainFrame" Text="Խ�㼯���ڸ���Ա����������ͳ�Ʊ�" ClientSideCommand="doMenuItemClick('mnuRSGL_6001_0004');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0005" Target="mainFrame" Text="�ڸ���Ա�Ͷ���ͬ�������ޱ�"       ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_esldhtjmqxb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0006" Target="mainFrame" Text="�Ͷ��ּ�����"                     ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_esldjjbb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0007" Target="mainFrame" Text="�Ͷ����걨��"                     ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_esldjnbb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>	
									</COMPONENTART:MENUITEM>	
									<COMPONENTART:MENUITEM id="mnuBAOBIAO" Target="mainFrame" Text="ͳ�Ʊ���" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_1001" Target="mainFrame" Text="�н鲿������ȼƻ�����" ClientSideCommand="openWindow('./estate/ershou/estate_es_jyndjh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_2001" Target="mainFrame" Text="�н鲿���ִ�����������" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_2001_1001" Target="mainFrame" Text="��ҵ��" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjsqkb_gyw.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_2001_1002" Target="mainFrame" Text="������" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjsqkb_gfh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_2001_1003" Target="mainFrame" Text="���¶�" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjsqkb_gyd.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_3001" Target="mainFrame" Text="�н鲿���ִ��������(������)" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_3001_1001" Target="mainFrame" Text="�Ӱ�" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjaqkb_gfh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_3001_1002" Target="mainFrame" Text="�᰸" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_eswcqkb_gfh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_4001" Target="mainFrame" Text="�н鲿����ҵ������嵥(�Ӱ�)(ҵ��|��ͬ)" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuBAOBIAO_4001_1001" Target="mainFrame" Text="�����ͬ" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_ja.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuBAOBIAO_4001_1002" Target="mainFrame" Text="δ���ͬ" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_ja_ws.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuBAOBIAO_4001_1003" Target="mainFrame" Text="����״̬" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_ja_all.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_4002" Target="mainFrame" Text="�н鲿����ҵ������嵥(�Ӱ�)(Ƭ��|����|��ͬ)" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuBAOBIAO_4002_1001" Target="mainFrame" Text="�����ͬ" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_ja1_ys.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuBAOBIAO_4002_1003" Target="mainFrame" Text="����״̬" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_ja1_all.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_4003" Target="mainFrame" Text="�н鲿����ҵ������嵥" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4003_1001" Target="mainFrame" Text="�᰸"           ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_wc.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4003_1002" Target="mainFrame" Text="�ѽ�δ�᰸"     ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_yjwj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4003_1003" Target="mainFrame" Text="�ѽ�δ����"     ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_yjwjw.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4004" Target="mainFrame" Text="�н鲿Ӧ��δ��Ӷ���嵥" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_yswsyjb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4005" Target="mainFrame" Text="�н鲿���ֿ�Դ��Ϣ�嵥" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_kyxxb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4006" Target="mainFrame" Text="�н鲿���ַ�Դ��Ϣ�嵥" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_fyxxb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_5001" Target="mainFrame" Text="�н鲿���ּ�Ӷ�嵥(˽Ӷ)"     ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjyqd_sy_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_5002" Target="mainFrame" Text="�н鲿���ּ�Ӷ�嵥(��Ӷ)"     ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjyqd_gy_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_5003" Target="mainFrame" Text="�н鲿���ּ�Ӷ�嵥(��Ӷ����)" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjyqd_gybf.aspx');" DisabledLookId="MenuItemDisabledLook" Visible="False"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_5004" Target="mainFrame" Text="�н鲿����Ӷ������"         ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esyjfpb_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_Bar5" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_6001" Target="mainFrame" Text="�н鲿���ִ������������" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esdlqyqkb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_6002" Target="mainFrame" Text="�н鲿�������а�����ҵ��" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esphbqyyj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_6003" Target="mainFrame" Text="�н鲿�������а���ҵ��" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esphbbmyj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_6004" Target="mainFrame" Text="�н鲿�������а���Աҵ��" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esphbryyj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_6005" Target="mainFrame" Text="�н鲿����ҵ����ȶԱ�ͼ" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esnddb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuDMGL" Target="mainFrame" Text="�����ֵ�" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuDMGL_1001" Target="mainFrame" Text="��������" ClientSideCommand="openWindow('./dmgl/ggdm_xzjb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_1002" Target="mainFrame" Text="��λ����" ClientSideCommand="openWindow('./dmgl/ggdm_gwsz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_2003" Target="mainFrame" Text="�����̶�" ClientSideCommand="openWindow('./gwdm/gwdm_jjcd.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_2004" Target="mainFrame" Text="���ܵȼ�" ClientSideCommand="openWindow('./gwdm/gwdm_mmdj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_3001" Target="mainFrame" Text="ְ������" ClientSideCommand="openWindow('./estate/renshi/estate_rs_zhijidingyi.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4001" Target="mainFrame" Text="����ְ��" ClientSideCommand="openWindow('./estate/renshi/estate_rs_jishuzhicheng.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4002" Target="mainFrame" Text="ѧ������" ClientSideCommand="openWindow('./estate/renshi/estate_rs_xuelihuafen.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4003" Target="mainFrame" Text="ѧλ����" ClientSideCommand="openWindow('./estate/renshi/estate_rs_xueweihuafen.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4004" Target="mainFrame" Text="������ò" ClientSideCommand="openWindow('./estate/renshi/estate_rs_zhengzhimianmao.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4005" Target="mainFrame" Text="ִҵ�ʸ�" ClientSideCommand="openWindow('./estate/renshi/estate_rs_zhiyezige.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4006" Target="mainFrame" Text="���±䶯����" ClientSideCommand="openWindow('./estate/renshi/estate_rs_biandongyuanyin.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4007" Target="mainFrame" Text="�����ϸ�����" ClientSideCommand="openWindow('./estate/renshi/estate_rs_zhigongshuxing.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5001" Target="mainFrame" Text="˰��Ŀ¼�ֵ�" ClientSideCommand="openWindow('./estate/common/estate_gg_shuifeimulu.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5002" Target="mainFrame" Text="��ҵ����ֵ�" ClientSideCommand="openWindow('./estate/common/estate_gg_wuyejiange.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5003" Target="mainFrame" Text="Ӧ��Ӧ��ģ��" ClientSideCommand="openWindow('./estate/common/estate_gg_yingshouyingfumoban.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5004" Target="mainFrame" Text="��ҵ�����ֵ�" ClientSideCommand="openWindow('./estate/common/estate_gg_wuyexingzhi.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5005" Target="mainFrame" Text="���򻮷��ֵ�" ClientSideCommand="openWindow('./estate/common/estate_gg_quyuhuafen.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5006" Target="mainFrame" Text="�참��Ŀ�ֵ�" ClientSideCommand="openWindow('./estate/common/estate_gg_baxm.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="MENUITEM1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_6001" Target="mainFrame" Text="��Ƹ�����ֵ�" ClientSideCommand="openWindow('./estate/nrenshi/estate_rs_zpqd.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuXTPZ" Target="mainFrame" Text="ϵͳ����" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuXTPZ_1001" Target="mainFrame" Text="���в���" ClientSideCommand="openWindow('./xtpz/xtpz_xtcs.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_2001" Target="mainFrame" Text="��λ��Ա" ClientSideCommand="openWindow('./bmry/ggdm_bmry.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="MENUITEM2" Target="mainFrame" Text="��λ��Ա2" ClientSideCommand="openWindow('./staffmanager/staff_manager.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_2002" Target="mainFrame" Text="���÷�Χ" ClientSideCommand="openWindow('./gwdm/gwdm_cyfw.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_3001" Target="mainFrame" Text="�������" ClientSideCommand="openWindow('./xtpz/xtpz_dbsz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_3002" Target="mainFrame" Text="���ǿ���" ClientSideCommand="openWindow('./xtpz/xtpz_bdkz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuXTGL" Target="mainFrame" Text="ϵͳ����" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuXTGL_1001" Target="mainFrame" Text="���ݶ���" ClientSideCommand="openWindow('./xtgl/xtgl_sjdx.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_2001" Target="mainFrame" Text="�û�����" ClientSideCommand="openWindow('./xtgl/xtgl_yhgl_yh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_2002" Target="mainFrame" Text="������Ȩ" ClientSideCommand="openWindow('./xtgl/xtgl_sjqx_js.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_2003" Target="mainFrame" Text="ģ�����" ClientSideCommand="openWindow('./xtgl/xtgl_mkgl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_2004" Target="mainFrame" Text="ģ����Ȩ" ClientSideCommand="openWindow('./xtgl/xtgl_mkqx_js.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_3001" Target="mainFrame" Text="�����û�" ClientSideCommand="openWindow('./xtgl/xtgl_rzgl_zxyh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_3002" Target="mainFrame" Text="������־" ClientSideCommand="openWindow('./xtgl/xtgl_rzgl_jcrz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_4001" Target="mainFrame" Text="�û���־" ClientSideCommand="openWindow('./xtgl/xtgl_rz_cz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_4002" Target="mainFrame" Text="�������" ClientSideCommand="openWindow('./xtgl/xtgl_rz_fw.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_4003" Target="mainFrame" Text="��ȫ���" ClientSideCommand="openWindow('./xtgl/xtgl_rz_aq.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_4004" Target="mainFrame" Text="�������" ClientSideCommand="openWindow('./xtgl/xtgl_rz_pz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_4005" Target="mainFrame" Text="�����־" ClientSideCommand="openWindow('./xtgl/xtgl_rz_sj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_5001" Target="mainFrame" Text="�ļ�ת��" ClientSideCommand="openWindow('./xtgl/xtgl_wjzh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_5002" Target="mainFrame" Text="ǿ�Ʊ༭" ClientSideCommand="openWindow('./gzflow/gzsp_admin_bz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuHELP" Target="mainFrame" Text="ʹ��˵��" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuHELP_1001" Target="mainFrame" Text="������Ա" ClientSideCommand="openWindow('../public/helpdoc/help_fenhang.mht');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHELP_1002" Target="mainFrame" Text="�ܲ���Ա" ClientSideCommand="openWindow('../public/helpdoc/help_zongbu.mht');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuZJAZ" Target="mainFrame" Text="�����װ" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuZJAZ_1001" Target="mainFrame" Text="�ĵ����" Enabled="False" ClientSideCommand="openWindow('../cabs/jsoffice.exe');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuZJAZ_1002" Target="mainFrame" Text="�������" ClientSideCommand="openWindow('../cabs/pdf417.exe');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuZJAZ_1003" Target="mainFrame" Text="ͨѶ���" ClientSideCommand="openWindow('../cabs/mscomm32.exe');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuZJAZ_1004" Target="mainFrame" Text="PDF�Ķ���" ClientSideCommand="openWindow('../cabs/AdbeRdr708_zh_CN.exe');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuZJAZ_1005" Target="mainFrame" Text="IE6��װ��" ClientSideCommand="openWindow('../cabs/ie6.zip');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
								</ITEMS>
								<ITEMLOOKS>
									<COMPONENTART:ItemLook LookID="TopItemLook" CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingLeft="15" LabelPaddingRight="15" LabelPaddingTop="4" LabelPaddingBottom="4" />
									<COMPONENTART:ItemLook LookID="DefaultItemLook" CssClass="MenuItem" HoverCssClass="MenuItemHover" ExpandedCssClass="MenuItemHover" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
									<COMPONENTART:ItemLook LookID="MenuItemDisabledLook" CssClass="MenuItemDisabled" HoverCssClass="" ExpandedCssClass="" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
									<COMPONENTART:ItemLook LookID="BreakItem" CssClass="MenuBreak" ImageHeight="2" ImageWidth="100%" ImageUrl="../images/menu01/break.gif" />
								</ITEMLOOKS>
							</ComponentArt:Menu>
						</TD>
					</TR>
					<TR>
						<TD align="center" colspan="2"><div id="strDisplay_dbsy" runat="server">
						    <table cellpadding="0" cellspacing="0" border="1">
						        <tr>									
									<td style="height:14px"></td>
								</tr>
								<tr >									
									<td align="left" valign="top">�����ļ���</td>
								</tr>
								
								<tr>
									<td valign="top" colspan="2">
										<table cellpadding="0" cellspacing="0" border="0">
											<tr>
												<td width="28"></td>
												<td width="600" align="left" valign="top">
													<% doDisplay_Dbsy() %>
												</td>
												<td width="20"></td>
											</tr>
										</table>
									</td>
								</tr>
						    </table></div>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server" Visible="False">
				<TABLE height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();" type="button" value=" ���� "></P></TD>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5%"></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<table cellSpacing="0" cellPadding="0" align="center" border="0">
				<tr>
					<td>
						<uwin:popmessage id="popMessageObject" runat="server" height="48px" width="96px" Visible="False" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
