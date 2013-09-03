<%@ Page Language="vb" AutoEventWireup="false" Codebehind="main.aspx.vb" Inherits="Josco.JsKernal.web.main"%>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<%@ Import namespace="Josco.JsKernal.Common.Utilities.PulicParameters" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>系统主界面</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="../mnuStyle01.css" type="text/css" rel="stylesheet"/>
		<LINK href="../styles01.css" type="text/css" rel="stylesheet"/>
		<script src="../scripts/transkey.js"></script>
		<script language="vb" runat="server">
			'获取Unicode的字符串转换为MBCS字符串的字节长度
			Public Function getStringLength(ByVal strValue As String) As Integer
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				getStringLength = objPulicParameters.getStringLength(strValue)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
			End Function

			'从Unicode的字符串中获取指定长度的字符串，长度按MBCS计算
			Public Function getSubString(ByVal strValue As String, ByVal intLen As Integer) As String
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				getSubString = objPulicParameters.getSubString(strValue, intLen)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
			End Function

			'获取应用根目录HTTP路径
			Public Function getApplicationPath() As String
				getApplicationPath = Request.ApplicationPath
			End Function

			'----------------------------------------------------------------
			' 隐藏没有权限的菜单
			'----------------------------------------------------------------
			Private Sub mnuMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMain.Load
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim objsystemAppManager As New Josco.JsKernal.BusinessFacade.systemAppManager
				Dim objMokuaiQXData As Josco.JsKernal.Common.Data.AppManagerData = Nothing
				Dim strErrMsg As String = ""
				Try
					'根据登录用户获取模块权限数据
					If MyBase.UserId.ToUpper() = "SA" Then
						Exit Try
					End If
					'普通用户权限
					If objsystemAppManager.getDBUserMokuaiQXData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, objMokuaiQXData) = True Then
						Dim strMKMC As String = Josco.JsKernal.Common.Data.AppManagerData.FIELD_GL_B_YINGYONGXITONG_MOKUAIQX_MKMC
						Dim blnVisible As Boolean = False
						Dim strParamValue As String = ""
						Dim strFilter As String = ""
						With objMokuaiQXData.Tables(Josco.JsKernal.Common.Data.AppManagerData.TABLE_GL_B_YINGYONGXITONG_MOKUAIQX)
							strParamValue = "应用系统-权限管理-文件转换"
							strFilter = strMKMC + " = '" + strParamValue + "'"
							.DefaultView.RowFilter = strFilter
							If .DefaultView.Count < 1 Then
								Me.mnuMain.FindItemById("mnuXTGL_5001").Visible = False
							End If
							blnVisible = blnVisible Or Me.mnuMain.FindItemById("mnuXTGL_5001").Visible
							'*******************************************************************************
							strParamValue = "应用系统-特殊处理-工作流文件处理"
							strFilter = strMKMC + " = '" + strParamValue + "'"
							.DefaultView.RowFilter = strFilter
							If .DefaultView.Count < 1 Then
								Me.mnuMain.FindItemById("mnuXTGL_5002").Visible = False
							End If
							blnVisible = blnVisible Or Me.mnuMain.FindItemById("mnuXTGL_5002").Visible
							Me.mnuMain.FindItemById("mnuXTGL_Bar4").Visible = blnVisible
							'*******************************************************************************
							'zengxianglin 2009-01-07
							strParamValue = "应用系统-系统报表-人事报表-人力资源状况调查表"
							strFilter = strMKMC + " = '" + strParamValue + "'"
							.DefaultView.RowFilter = strFilter
							If .DefaultView.Count < 1 Then
								Me.mnuMain.FindItemById("mnuRSGL_6001_0001").Enabled = False
							End If
							'zengxianglin 2009-01-07
							'*******************************************************************************
							'zengxianglin 2009-01-09
							strParamValue = "应用系统-系统报表-人事报表-越秀集团在岗人员及其他数据统计表"
							strFilter = strMKMC + " = '" + strParamValue + "'"
							.DefaultView.RowFilter = strFilter
							If .DefaultView.Count < 1 Then
								Me.mnuMain.FindItemById("mnuRSGL_6001_0004").Enabled = False
							End If
							'zengxianglin 2009-01-09
							'*******************************************************************************
							'zengxianglin 2009-05-14
							strParamValue = "应用系统-人事管理-个人履历-登记履历"
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

			'zengxianglin 2009-01-07 创建
			Private Sub doPrint_RSBB_RLZYZKDCB(ByVal strControlId As String)

				Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
				Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
				Dim strErrMsg As String = ""
				Dim intStep As Integer

				Try
					intStep = 1
					'输入统计日期
					If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
						objMessageProcess.doInputBox(Me.popMessageObject, "请输入统计截止日期(yyyy-MM-dd)：", strControlId, intStep, Now.ToString("yyyy-MM-dd"))
						Exit Try
					Else
						objMessageProcess.doResetPopMessage(Me.popMessageObject)
					End If

					'获取输入后继续处理
					intStep = 2
					If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
						'获取输入日期
						Dim strJZRQ As String = ""
						strJZRQ = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
						If strJZRQ Is Nothing Then strJZRQ = ""
						strJZRQ = strJZRQ.Trim
						If strJZRQ = "" Then
							strErrMsg = "错误：没有指定日期！"
							GoTo errProc
						End If
						If objPulicParameters.isDatetimeString(strJZRQ) = False Then
							strErrMsg = "错误：无效的日期！"
							GoTo errProc
						End If
						'检查模版文件
						Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "广州兴业_人事管理_人力资源状况调查表.xls"
						Dim strMBLOC As String = Server.MapPath(strMBURL)
						Dim blnFound As Boolean
						If objBaseLocalFile.doFileExisted(strErrMsg, strMBLOC, blnFound) = False Then
							GoTo errProc
						End If
						If blnFound = False Then
							strErrMsg = "错误：[" + strMBLOC + "]不存在！"
							GoTo errProc
						End If
						'备份模版文件到缓存目录
						Dim strTempPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
						Dim strTempFile As String
						strTempPath = Server.MapPath(strTempPath)
						If objBaseLocalFile.doCopyToTempFile(strErrMsg, strMBLOC, strTempPath, strTempFile) = False Then
							GoTo errProc
						End If
						Dim strTempSpec As String
						strTempSpec = objBaseLocalFile.doMakePath(strTempPath, strTempFile)
						'输出数据
						Dim strMacroValue As String = ""
						Dim strMacroName As String = ""
						strMacroName = "$Macro$TJRQ$"
						strMacroValue = strJZRQ
						If objsystemEstateRenshiGeneral.doPrint_RSBB_RLZYZKDCB(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJZRQ, strTempSpec, strMacroName, strMacroValue) = False Then
							GoTo errProc
						End If
						'显示Excel
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
			'zengxianglin 2009-01-07 创建

			'zengxianglin 2009-01-09 创建
			Private Sub doPrint_RSBB_YXJTZGRYJQTSJTJB(ByVal strControlId As String)

				Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
				Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
				Dim strErrMsg As String = ""
				Dim intStep As Integer

				Try
					intStep = 1
					'输入统计日期
					If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
						objMessageProcess.doInputBox(Me.popMessageObject, "请输入统计截止日期(yyyy-MM-dd)：", strControlId, intStep, Now.ToString("yyyy-MM-dd"))
						Exit Try
					Else
						objMessageProcess.doResetPopMessage(Me.popMessageObject)
					End If

					'获取输入后继续处理
					intStep = 2
					If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
						'获取输入日期
						Dim strJZRQ As String = ""
						strJZRQ = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
						If strJZRQ Is Nothing Then strJZRQ = ""
						strJZRQ = strJZRQ.Trim
						If strJZRQ = "" Then
							strErrMsg = "错误：没有指定日期！"
							GoTo errProc
						End If
						If objPulicParameters.isDatetimeString(strJZRQ) = False Then
							strErrMsg = "错误：无效的日期！"
							GoTo errProc
						End If
						'检查模版文件
						Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "广州兴业_人事管理_越秀集团在岗人员及其他数据统计表.xls"
						Dim strMBLOC As String = Server.MapPath(strMBURL)
						Dim blnFound As Boolean
						If objBaseLocalFile.doFileExisted(strErrMsg, strMBLOC, blnFound) = False Then
							GoTo errProc
						End If
						If blnFound = False Then
							strErrMsg = "错误：[" + strMBLOC + "]不存在！"
							GoTo errProc
						End If
						'备份模版文件到缓存目录
						Dim strTempPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
						Dim strTempFile As String
						strTempPath = Server.MapPath(strTempPath)
						If objBaseLocalFile.doCopyToTempFile(strErrMsg, strMBLOC, strTempPath, strTempFile) = False Then
							GoTo errProc
						End If
						Dim strTempSpec As String
						strTempSpec = objBaseLocalFile.doMakePath(strTempPath, strTempFile)
						'输出数据
						Dim strMacroValue As String = ""
						Dim strMacroName As String = ""
						strMacroName = "$Macro$TJRQ$"
						strMacroValue = strJZRQ
						If objsystemEstateRenshiGeneral.doPrint_RSBB_YXJTZGRYJQTSJTJB(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJZRQ, strTempSpec, strMacroName, strMacroValue) = False Then
							GoTo errProc
						End If
						'显示Excel
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
			'zengxianglin 2009-01-09 创建

			'zengxianglin 2009-05-14
			Private Sub doGRLL_AddNew(ByVal strControlId As String)

				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
				Dim strErrMsg As String = ""

				Try
					'准备调用接口
					Dim objIEstateRsGrllInfo As Josco.JSOA.BusinessFacade.IEstateRsGrllInfo = Nothing
					Dim strUrl As String = ""
					objIEstateRsGrllInfo = New Josco.JSOA.BusinessFacade.IEstateRsGrllInfo
					With objIEstateRsGrllInfo
						.iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
						.iRYDM = ""
						.iSourceControlId = strControlId
						.iReturnUrl = Request.Url.AbsolutePath
					End With

					'调用模块
					Dim strNewSessionId As String = ""
					strNewSessionId = objPulicParameters.getNewGuid()
					If strNewSessionId = "" Then
						strErrMsg = "错误：不能初始化调用接口！"
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
					'获取点击菜单
					Dim strMenuId As String = Me.htxtSelectMenuID.Value
					'处理菜单命令
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
		    '曾祥林 2008-04-02
		    
		    '显示待办事宜数据
		    Public Sub doDisplay_Dbsy()
		        Dim strTable As String = Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE
		        Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
		        Dim objgrswMyTaskData As Josco.JsKernal.Common.Data.grswMyTaskData = Nothing
		        Dim blnWriteNull As Boolean = False
		        Dim intMaxItemLen As Integer = 62
		        Dim intMaxItems As Integer = 7
		        
		        Try
		            '获取数据
		            objgrswMyTaskData = getDataSet_DBSY()
		            '无法获取数据
		            If objgrswMyTaskData Is Nothing Then blnWriteNull = True
		            '没有数据
		            With objgrswMyTaskData.Tables(strTable)
		                If .Rows.Count < 1 Then blnWriteNull = True
		                intMaxItems = .Rows.Count
		            End With
		            If blnWriteNull = True Then
		                Response.Write("&nbsp;")
		                Exit Try
		            End If
		            '输出数据
		            Dim intLen As Integer = 0
		            Dim strBS As String = ""
		            Dim strRQ As String = ""
		            Dim strBT As String = ""
		            Dim strLX As String = ""
		            
		            Dim i As Integer = 0
		            Response.Write("<table cellpadding='0' cellspacing='0' border='0'>" + vbCr)
		            With objgrswMyTaskData.Tables(strTable).DefaultView
		                For i = 0 To intMaxItems - 1 Step 1
		                    '没有足够数据
		                    If i >= .Count Then Exit For
		                    '获取数据
		                    strBS = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBS), "")
		                    strBT = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBT), "")
		                    strRQ = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ), "", "MM.dd")
		                    strLX = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJLX), "")
		                    
		                    intLen = getStringLength(strBT)
		                    If intLen + (strRQ.Length + 2) > intMaxItemLen Then
		                        strBT = getSubString(strBT, intMaxItemLen - (strRQ.Length + 2) - 1) + "…(" + strRQ + ")"
		                    Else
		                        strBT = strBT + "(" + strRQ + strLX + ")"
		                    End If
		                   
		                    Dim strUserId As String
		                    Dim strPassword As String
					
		                    strUserId = MyBase.UserId
		                    strPassword = MyBase.UserPassword
		                    
		                    '显示数据
		                    Response.Write("  <tr>" + vbCr)
		                    Response.Write("    <td height='18' class='label12_01'>" + vbCr)
		                    Response.Write("      &nbsp;&nbsp;·<A href='#' onClick=openWindow('./gzflow/gzsp_flow.aspx?ID=" + strUserId + "&password=" + strPassword + "&type=DBSY&wjbs=" + strBS + "') class='hrefcss12_01'>" + strBT + "</A>" + vbCr)
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
		    
		    '获取能够阅读的未办事宜数据集（按“发送日期”降序）
		    Public Function getDataSet_DBSY() As Josco.JsKernal.Common.Data.grswMyTaskData
		        Dim objsystemMyTask As New Josco.JsKernal.BusinessFacade.systemMyTask
		        Dim objDataSet As Josco.JsKernal.Common.Data.grswMyTaskData = Nothing
		        Dim strErrMsg As String = ""
		        Try
		            If objsystemMyTask.getDataSetDBSY(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserXM, objDataSet) = True Then
		                objDataSet.Tables(0).DefaultView.Sort = "发送日期 desc"
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
			//曾祥林 2008-03-29
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
			//曾祥林 2008-03-29
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
			//曾祥林 2008-04-02
			function doMenuItemClick(menuItemId) 
			{
				try 
				{
					document.all("htxtSelectMenuID").value = menuItemId;
					window.setTimeout("__doPostBack('lnkMenu', '');", 500);
				} catch (e) {}
			}
			//曾祥林 2008-04-02
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
						<td><!--曾祥林 2008-04-02 --><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMenu" Runat="server" Width="0px"></asp:LinkButton><INPUT id="htxtSelectMenuID" type="hidden" size="1" runat="server"><!--曾祥林 2008-04-02 --></td>
						<TD>
							<ComponentArt:Menu id="mnuMain" runat="server" width="100%" Orientation="Horizontal" CssClass="TopGroup"
								DefaultGroupCssClass="MenuGroup" DefaultSubGroupExpandOffsetX="-10" DefaultSubGroupExpandOffsetY="-5"
								DefaultItemLookID="DefaultItemLook" TopGroupItemSpacing="1" DefaultGroupItemSpacing="2" ImagesBaseUrl="../images/"
								EnableViewState="false" ExpandDelay="100" DefaultTarget="mainFrame">
								<ITEMS>
									<COMPONENTART:MENUITEM id="mnuXTZY" Target="mainFrame" Text="主页" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuXTZY_1001" Target="mainFrame" Text="欢迎页面" ClientSideCommand="openWindow('../areaContent.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTZY_Bar1" Target="mainFrame" LookId="BreakItem" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTZY_2001" Target="mainFrame" Text="用户信息" ClientSideCommand="openWindow('./userinfo.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTZY_2002" Target="mainFrame" Text="更改密码" ClientSideCommand="openWindow('./modifypwd.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTZY_Bar2" Target="mainFrame" LookId="BreakItem" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTZY_3001" Target="mainFrame" Text="退出系统" ClientSideCommand="closeWindow();" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuGRSW" Target="mainFrame" Text="个人工具" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuGRSW_1001" Target="mainFrame" Text="我的各类工作" ClientSideCommand="openWindow('./grsw/grsw_wdsy.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_Bar1" Target="mainFrame" LookId="BreakItem" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_2001" Target="mainFrame" Text="我的委托留言" ClientSideCommand="openWindow('./grsw/grsw_lkly.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_2002" Target="mainFrame" Text="我的常用意见" ClientSideCommand="openWindow('./grsw/grsw_cyyj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_3001" Target="mainFrame" Text="即时信息交流" ClientSideCommand="openChat();" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
		                                <COMPONENTART:MENUITEM id="mnuGRSW_5001" Target="mainFrame" Text="移交我的文件" ClientSideCommand="openWindow('./grsw/grsw_yijiao.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
		                                <COMPONENTART:MENUITEM id="mnuGRSW_5002" Target="mainFrame" Text="接收移交文件" ClientSideCommand="openWindow('./grsw/grsw_jieshou.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuGRSW_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
		                                <COMPONENTART:MENUITEM id="mnuGRSW_6001" Target="mainFrame" Text="我的个人配置" ClientSideCommand="openWindow('./grsw/grsw_config.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuHTGL" Target="mainFrame" Text="合同管理" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuHTGL_1001" Target="mainFrame" Text="买卖确认书管理"   ClientSideCommand="openWindow('./estate/ershou/estate_es_qrsmm_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_1002" Target="mainFrame" Text="租赁确认书管理"   ClientSideCommand="openWindow('./estate/ershou/estate_es_qrszl_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_1003" Target="mainFrame" Text="其他确认书管理"   ClientSideCommand="openWindow('./estate/ershou/estate_es_qrsqt_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2001" Target="mainFrame" Text="二手合同管理"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_list.aspx');"   DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2002" Target="mainFrame" Text="二手买卖合同查询" ClientSideCommand="openWindow('./estate/ershou/estate_es_hetongmm_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2003" Target="mainFrame" Text="二手租赁合同查询" ClientSideCommand="openWindow('./estate/ershou/estate_es_hetongzl_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2004" Target="mainFrame" Text="二手其他合同查询" ClientSideCommand="openWindow('./estate/ershou/estate_es_hetongqt_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2005" Target="mainFrame" Text="二手合同审核"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_sh.aspx');"     DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_2006" Target="mainFrame" Text="合同折扣审核"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_zksh.aspx');"   DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_3001" Target="mainFrame" Text="合同办案管理"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_bl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_4001" Target="mainFrame" Text="合同结算管理"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_jss_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_4002" Target="mainFrame" Text="结算书审核"       ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_jss_sh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_4003" Target="mainFrame" Text="结算书补计佣金"   ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_jss_bjyj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_5001" Target="mainFrame" Text="合同结案处理"     ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_wc.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_Bar5" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHTGL_6001" Target="mainFrame" Text="强制更改业绩分配" ClientSideCommand="openWindow('./estate/ershou/estate_es_hetong_qzbj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuCWSZ" Target="mainFrame" Text="财务收支" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuCWSZ_1001" Target="mainFrame" Text="票据发放管理" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_piaoju_fafang.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_1002" Target="mainFrame" Text="票据使用管理" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_piaoju_shiyong.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_1003" Target="mainFrame" Text="票据使用监控" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_piaoju_jiankong.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_2001" Target="mainFrame" Text="财务收支登记" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_sssf.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_2002" Target="mainFrame" Text="费用结转处理" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_sssf_jz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_2003" Target="mainFrame" Text="财务收支审核" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_sssf_sh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuCWSZ_3001" Target="mainFrame" Text="财务收支台帐" ClientSideCommand="openWindow('./estate/caiwu/estate_cw_sztz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuKQGL" Target="mainFrame" Text="考勤管理" DisabledLookId="MenuItemDisabledLook">
									    <COMPONENTART:MENUITEM id="mnuKQGL_1001" Target="mainFrame" Text="考勤记录"   ClientSideCommand="openWindow('./kqgl/kqgl_kqjl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1002" Target="mainFrame" Text="年休假管理"   ClientSideCommand="openWindow('./kqgl/kqgl_nxj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1003" Target="mainFrame" Text="月应休假管理"   ClientSideCommand="openWindow('./kqgl/kqgl_yxj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1004" Target="mainFrame" Text="补休假一览表"   ClientSideCommand="openWindow('./kqgl/kqgl_bxj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1005" Target="mainFrame" Text="请假管理"   ClientSideCommand="openWindow('./kqgl/kqgl_qjd.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1006" Target="mainFrame" Text="月应休假职级管理"   ClientSideCommand="openWindow('./kqgl/kqgl_yxj_zj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuKQGL_1007" Target="mainFrame" Text="打印记录"   ClientSideCommand="openWindow('./kqgl/kqjl_print.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM> 
									<COMPONENTART:MENUITEM id="mnuRSGL" Target="mainFrame" Text="人事管理" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuRSGL_1001" Target="mainFrame" Text="佣金计提标准" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuRSGL_1001_0001" Target="mainFrame" Text="标准序列(一)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_yongjinjitibiaozhun.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_1001_0002" Target="mainFrame" Text="标准序列(二)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_yongjinjitibiaozhun_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_1001_0003" Target="mainFrame" Text="标准序列(三)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_yongjinjitibiaozhun_x3.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_1001_0004" Target="mainFrame" Text="标准序列(四)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_yongjinjitibiaozhun_x4.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_1002" Target="mainFrame" Text="业绩考核标准" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuRSGL_1002_0001" Target="mainFrame" Text="标准序列(一)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_kaohebiaozhun.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_1002_0002" Target="mainFrame" Text="标准序列(二)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_kaohebiaozhun_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_2002_0005" Target="mainFrame" Text="流程综合管理" ClientSideCommand="openWindow('./gzflow/gzsp_flow.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_2001" Target="mainFrame" Text="二手业务人员管理架构" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_mn.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_2002" Target="mainFrame" Text="二手业务人员架构调整" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0001" Target="mainFrame" Text="人员入职" ClientSideCommand="openWindow('./estate/nrenshi/estate_rs_ruzhi.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0002" Target="mainFrame" Text="内部调整" ClientSideCommand="openWindow('./estate/nrenshi/estate_rs_nbtz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>	
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0003" Target="mainFrame" Text="离开岗位" ClientSideCommand="openWindow('./estate/nrenshi/estate_rs_lztz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>									
										    <COMPONENTART:MENUITEM id="mnuRSGL_2002_0004" Target="mainFrame" Text="实习生入职" ClientSideCommand="openWindow('./estate/nrenshi/estate_rs_shixisheng.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											
										</COMPONENTART:MENUITEM>	
										<COMPONENTART:MENUITEM id="mnuRSGL_2010" Target="mainFrame" Text="办公室专用架构调整" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0006" Target="mainFrame" Text="人员入职" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_add_mn.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0007" Target="mainFrame" Text="内部调整" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_mdfy_mn.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>	
											<COMPONENTART:MENUITEM id="mnuRSGL_2002_0008" Target="mainFrame" Text="离开岗位" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_del_mn.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>									
										</COMPONENTART:MENUITEM>									
										<COMPONENTART:MENUITEM id="mnuRSGL_2003" Target="mainFrame" Text="二手业务人员架构手动调整" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_list.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_2004" Target="mainFrame" Text="二手业务人员架构变动查询" ClientSideCommand="openWindow('./estate/renshi/estate_rs_renyuanjiagou_bdls_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_3001" Target="mainFrame" Text="入职员工管理" ClientSideCommand="openWindow('./estate/renshi/estate_rs_rskp_main.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_3002" Target="mainFrame" Text="员工培训管理" ClientSideCommand="openWindow('./estate/renshi/estate_rs_rskp_pxjl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_3003" Target="mainFrame" Text="人事变动管理" ClientSideCommand="openWindow('./estate/renshi/estate_rs_rskp_ydjl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_3004" Target="mainFrame" Text="劳动合同管理" ClientSideCommand="openWindow('./estate/renshi/estate_rs_rskp_ldht.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_4001" Target="mainFrame" Text="登记求职履历" ClientSideCommand="doMenuItemClick('mnuRSGL_4001');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_4002" Target="mainFrame" Text="求职履历管理" ClientSideCommand="openWindow('./estate/renshi/estate_rs_grll_main.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_4003" Target="mainFrame" Text="人员录用审批" ClientSideCommand="openWindow('./estate/renshi/estate_rs_luyong_main.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_5001" Target="mainFrame" Text="职员业绩考核" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuRSGL_5001_0003" Target="mainFrame" Text="正式人员考核(考核标准一)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_eszszgkh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_5001_0004" Target="mainFrame" Text="试用人员考核(考核标准一)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_essyzgkh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>	
											<COMPONENTART:MENUITEM id="mnuRSGL_5001_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_5001_0001" Target="mainFrame" Text="业务精英考核(考核标准二)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_kh_jy.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_5001_0002" Target="mainFrame" Text="业务主管考核(考核标准二)" ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_kh_gl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>	
										<COMPONENTART:MENUITEM id="mnuRSGL_Bar5" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuRSGL_6001" Target="mainFrame" Text="人事统计报表" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0001" Target="mainFrame" Text="人力资源状况调查表"               ClientSideCommand="doMenuItemClick('mnuRSGL_6001_0001');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0002" Target="mainFrame" Text="人员增减异动表"                   ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_esryzjydb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0003" Target="mainFrame" Text="人力资源信息汇总表"               ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_esrlzyxxhzb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0004" Target="mainFrame" Text="越秀集团在岗人员及其他数据统计表" ClientSideCommand="doMenuItemClick('mnuRSGL_6001_0004');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0005" Target="mainFrame" Text="在岗人员劳动合同届满期限表"       ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_esldhtjmqxb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0006" Target="mainFrame" Text="劳动局季报表"                     ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_esldjjbb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuRSGL_6001_0007" Target="mainFrame" Text="劳动局年报表"                     ClientSideCommand="openWindow('./estate/renshi/estate_rs_bb_esldjnbb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>	
									</COMPONENTART:MENUITEM>	
									<COMPONENTART:MENUITEM id="mnuBAOBIAO" Target="mainFrame" Text="统计报表" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_1001" Target="mainFrame" Text="中介部二手年度计划管理" ClientSideCommand="openWindow('./estate/ershou/estate_es_jyndjh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_2001" Target="mainFrame" Text="中介部二手代理结算情况表" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_2001_1001" Target="mainFrame" Text="各业务" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjsqkb_gyw.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_2001_1002" Target="mainFrame" Text="各分行" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjsqkb_gfh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_2001_1003" Target="mainFrame" Text="各月度" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjsqkb_gyd.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_3001" Target="mainFrame" Text="中介部二手代理情况表(各分行)" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_3001_1001" Target="mainFrame" Text="接案" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjaqkb_gfh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_3001_1002" Target="mainFrame" Text="结案" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_eswcqkb_gfh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_4001" Target="mainFrame" Text="中介部二手业务代理清单(接案)(业务|合同)" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuBAOBIAO_4001_1001" Target="mainFrame" Text="已审合同" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_ja.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuBAOBIAO_4001_1002" Target="mainFrame" Text="未审合同" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_ja_ws.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuBAOBIAO_4001_1003" Target="mainFrame" Text="各类状态" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_ja_all.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_4002" Target="mainFrame" Text="中介部二手业务代理清单(接案)(片区|分行|合同)" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
											<COMPONENTART:MENUITEM id="mnuBAOBIAO_4002_1001" Target="mainFrame" Text="已审合同" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_ja1_ys.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
											<COMPONENTART:MENUITEM id="mnuBAOBIAO_4002_1003" Target="mainFrame" Text="各类状态" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_ja1_all.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_4003" Target="mainFrame" Text="中介部二手业务代理清单" DisabledLookId="MenuItemDisabledLook" Look-RightIconUrl="../images/menu01/arrow.gif" Look-RightIconWidth="20">
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4003_1001" Target="mainFrame" Text="结案"           ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_wc.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4003_1002" Target="mainFrame" Text="已接未结案"     ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_yjwj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4003_1003" Target="mainFrame" Text="已接未结完"     ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esywdlqd_yjwjw.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										</COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4004" Target="mainFrame" Text="中介部应收未收佣金清单" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_yswsyjb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4005" Target="mainFrame" Text="中介部二手客源信息清单" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_kyxxb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									    <COMPONENTART:MENUITEM id="mnuBAOBIAO_4006" Target="mainFrame" Text="中介部二手房源信息清单" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_fyxxb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_5001" Target="mainFrame" Text="中介部二手计佣清单(私佣)"     ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjyqd_sy_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_5002" Target="mainFrame" Text="中介部二手计佣清单(公佣)"     ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjyqd_gy_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_5003" Target="mainFrame" Text="中介部二手计佣清单(公佣补发)" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esjyqd_gybf.aspx');" DisabledLookId="MenuItemDisabledLook" Visible="False"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_5004" Target="mainFrame" Text="中介部二手佣金分配表"         ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esyjfpb_x2.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_Bar5" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_6001" Target="mainFrame" Text="中介部二手代理区域情况表" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esdlqyqkb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_6002" Target="mainFrame" Text="中介部二手排行榜区域业绩" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esphbqyyj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_6003" Target="mainFrame" Text="中介部二手排行榜部门业绩" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esphbbmyj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_6004" Target="mainFrame" Text="中介部二手排行榜人员业绩" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esphbryyj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuBAOBIAO_6005" Target="mainFrame" Text="中介部二手业绩年度对比图" ClientSideCommand="openWindow('./estate/ershou/estate_es_bb_esnddb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuDMGL" Target="mainFrame" Text="数据字典" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuDMGL_1001" Target="mainFrame" Text="行政级别" ClientSideCommand="openWindow('./dmgl/ggdm_xzjb.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_1002" Target="mainFrame" Text="岗位设置" ClientSideCommand="openWindow('./dmgl/ggdm_gwsz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_2003" Target="mainFrame" Text="紧急程度" ClientSideCommand="openWindow('./gwdm/gwdm_jjcd.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_2004" Target="mainFrame" Text="秘密等级" ClientSideCommand="openWindow('./gwdm/gwdm_mmdj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_3001" Target="mainFrame" Text="职级定义" ClientSideCommand="openWindow('./estate/renshi/estate_rs_zhijidingyi.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4001" Target="mainFrame" Text="技术职称" ClientSideCommand="openWindow('./estate/renshi/estate_rs_jishuzhicheng.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4002" Target="mainFrame" Text="学历代码" ClientSideCommand="openWindow('./estate/renshi/estate_rs_xuelihuafen.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4003" Target="mainFrame" Text="学位代码" ClientSideCommand="openWindow('./estate/renshi/estate_rs_xueweihuafen.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4004" Target="mainFrame" Text="政治面貌" ClientSideCommand="openWindow('./estate/renshi/estate_rs_zhengzhimianmao.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4005" Target="mainFrame" Text="执业资格" ClientSideCommand="openWindow('./estate/renshi/estate_rs_zhiyezige.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4006" Target="mainFrame" Text="人事变动类型" ClientSideCommand="openWindow('./estate/renshi/estate_rs_biandongyuanyin.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_4007" Target="mainFrame" Text="人事上岗类型" ClientSideCommand="openWindow('./estate/renshi/estate_rs_zhigongshuxing.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5001" Target="mainFrame" Text="税费目录字典" ClientSideCommand="openWindow('./estate/common/estate_gg_shuifeimulu.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5002" Target="mainFrame" Text="物业间隔字典" ClientSideCommand="openWindow('./estate/common/estate_gg_wuyejiange.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5003" Target="mainFrame" Text="应收应付模版" ClientSideCommand="openWindow('./estate/common/estate_gg_yingshouyingfumoban.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5004" Target="mainFrame" Text="物业性质字典" ClientSideCommand="openWindow('./estate/common/estate_gg_wuyexingzhi.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5005" Target="mainFrame" Text="区域划分字典" ClientSideCommand="openWindow('./estate/common/estate_gg_quyuhuafen.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_5006" Target="mainFrame" Text="办案项目字典" ClientSideCommand="openWindow('./estate/common/estate_gg_baxm.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="MENUITEM1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuDMGL_6001" Target="mainFrame" Text="招聘渠道字典" ClientSideCommand="openWindow('./estate/nrenshi/estate_rs_zpqd.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuXTPZ" Target="mainFrame" Text="系统配置" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuXTPZ_1001" Target="mainFrame" Text="运行参数" ClientSideCommand="openWindow('./xtpz/xtpz_xtcs.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_2001" Target="mainFrame" Text="单位人员" ClientSideCommand="openWindow('./bmry/ggdm_bmry.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="MENUITEM2" Target="mainFrame" Text="单位人员2" ClientSideCommand="openWindow('./staffmanager/staff_manager.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_2002" Target="mainFrame" Text="常用范围" ClientSideCommand="openWindow('./gwdm/gwdm_cyfw.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_3001" Target="mainFrame" Text="督办控制" ClientSideCommand="openWindow('./xtpz/xtpz_dbsz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTPZ_3002" Target="mainFrame" Text="补登控制" ClientSideCommand="openWindow('./xtpz/xtpz_bdkz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuXTGL" Target="mainFrame" Text="系统管理" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuXTGL_1001" Target="mainFrame" Text="数据对象" ClientSideCommand="openWindow('./xtgl/xtgl_sjdx.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_Bar1" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_2001" Target="mainFrame" Text="用户管理" ClientSideCommand="openWindow('./xtgl/xtgl_yhgl_yh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_2002" Target="mainFrame" Text="数据授权" ClientSideCommand="openWindow('./xtgl/xtgl_sjqx_js.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_2003" Target="mainFrame" Text="模块管理" ClientSideCommand="openWindow('./xtgl/xtgl_mkgl.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_2004" Target="mainFrame" Text="模块授权" ClientSideCommand="openWindow('./xtgl/xtgl_mkqx_js.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_Bar2" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_3001" Target="mainFrame" Text="在线用户" ClientSideCommand="openWindow('./xtgl/xtgl_rzgl_zxyh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_3002" Target="mainFrame" Text="进出日志" ClientSideCommand="openWindow('./xtgl/xtgl_rzgl_jcrz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_Bar3" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_4001" Target="mainFrame" Text="用户日志" ClientSideCommand="openWindow('./xtgl/xtgl_rz_cz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_4002" Target="mainFrame" Text="访问审计" ClientSideCommand="openWindow('./xtgl/xtgl_rz_fw.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_4003" Target="mainFrame" Text="安全审计" ClientSideCommand="openWindow('./xtgl/xtgl_rz_aq.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_4004" Target="mainFrame" Text="配置审计" ClientSideCommand="openWindow('./xtgl/xtgl_rz_pz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_4005" Target="mainFrame" Text="审计日志" ClientSideCommand="openWindow('./xtgl/xtgl_rz_sj.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_Bar4" Target="mainFrame" LookId="BreakItem"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_5001" Target="mainFrame" Text="文件转换" ClientSideCommand="openWindow('./xtgl/xtgl_wjzh.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuXTGL_5002" Target="mainFrame" Text="强制编辑" ClientSideCommand="openWindow('./gzflow/gzsp_admin_bz.aspx');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuHELP" Target="mainFrame" Text="使用说明" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuHELP_1001" Target="mainFrame" Text="分行人员" ClientSideCommand="openWindow('../public/helpdoc/help_fenhang.mht');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuHELP_1002" Target="mainFrame" Text="总部人员" ClientSideCommand="openWindow('../public/helpdoc/help_zongbu.mht');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
									</COMPONENTART:MENUITEM>
									<COMPONENTART:MENUITEM id="mnuZJAZ" Target="mainFrame" Text="组件安装" DisabledLookId="MenuItemDisabledLook">
										<COMPONENTART:MENUITEM id="mnuZJAZ_1001" Target="mainFrame" Text="文档组件" Enabled="False" ClientSideCommand="openWindow('../cabs/jsoffice.exe');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuZJAZ_1002" Target="mainFrame" Text="条码组件" ClientSideCommand="openWindow('../cabs/pdf417.exe');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuZJAZ_1003" Target="mainFrame" Text="通讯组件" ClientSideCommand="openWindow('../cabs/mscomm32.exe');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuZJAZ_1004" Target="mainFrame" Text="PDF阅读器" ClientSideCommand="openWindow('../cabs/AdbeRdr708_zh_CN.exe');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
										<COMPONENTART:MENUITEM id="mnuZJAZ_1005" Target="mainFrame" Text="IE6安装包" ClientSideCommand="openWindow('../cabs/ie6.zip');" DisabledLookId="MenuItemDisabledLook"></COMPONENTART:MENUITEM>
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
									<td align="left" valign="top">待批文件…</td>
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
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();" type="button" value=" 返回 "></P></TD>
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
