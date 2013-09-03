Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_editword
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　发文信息处理
    '     新建时，保存完成后自动更改输入接口的iWJBS和iEditMode并等待用户后续操作
    '         如果取消，则直接返回上级。
    '     编辑时，无论保存或取消均等待用户后续操作
    ' 接口参数：
    '     参见接口类IMFlowEditWord描述
    '----------------------------------------------------------------

    Public Class flow_editword
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
		Protected WithEvents popMessageObject As Josco.Web.PopMessage

        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
		Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden

        Protected WithEvents htxtWatchInterval As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWatchSwitch As System.Web.UI.HtmlControls.HtmlInputHidden

        Protected WithEvents htxtUserName As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtProtectPassword As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtEditMode As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFileSpec As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtAutoSave As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCanQSYJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCanImportFile As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCanExportFile As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCanSelectTGWJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtTrackRevisions As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWJBS As System.Web.UI.HtmlControls.HtmlInputHidden
		Protected WithEvents htxtFlowTypeName As System.Web.UI.HtmlControls.HtmlInputHidden
		Protected WithEvents htxtCursorPos As System.Web.UI.HtmlControls.HtmlInputHidden
		Protected WithEvents htxtISession As System.Web.UI.HtmlControls.HtmlInputHidden

		Protected WithEvents lnkMLSaveAndClose As System.Web.UI.WebControls.LinkButton
		Protected WithEvents lnkMLClose As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLSave As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLXgfj As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLXgwj As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLXzgj As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLDrwj As System.Web.UI.WebControls.LinkButton

        '2009-02-20
        Protected WithEvents htxtLocked As System.Web.UI.HtmlControls.HtmlInputHidden
        '2009-02-20

        '注意: 以下占位符声明是 Web 窗体设计器所必需的。
        '不要删除或移动它。
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: 此方法调用是 Web 窗体设计器所必需的
            '不要使用代码编辑器修改它。
            InitializeComponent()
        End Sub

#End Region

        '----------------------------------------------------------------
        '模块私用参数
        '----------------------------------------------------------------
        Private m_cstrRelativePathToImage As String = "../../"            '本模块相对image的相对路径
        Private m_cstrUrlBaseToFileCache As String = "/temp/filecache/"   '本模块对应文件的下载路径

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowEditWord
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowEditWord
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

        '----------------------------------------------------------------
        '模块其他参数
        '----------------------------------------------------------------
        Private m_strGJFileName As String      '文件名称：全Url地址
        Private m_blnEditMode As Boolean       '编辑模式










        '----------------------------------------------------------------
        ' 复原模块现场信息并释放相应的资源
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtEditMode.Value = .htxtEditMode
                    '2009-02-20
                    Me.htxtLocked.Value = .htxtLocked
                    '2009-02-20
                    Me.htxtFileSpec.Value = .htxtFileSpec
                    Me.htxtAutoSave.Value = .htxtAutoSave
                    Me.htxtCanQSYJ.Value = .htxtCanQSYJ
                    Me.htxtCanImportFile.Value = .htxtCanImportFile
                    Me.htxtCanExportFile.Value = .htxtCanExportFile
                    Me.htxtCanSelectTGWJ.Value = .htxtCanSelectTGWJ
                    Me.htxtCursorPos.Value = .htxtCursorPos
                    Me.htxtProtectPassword.Value = .htxtProtectPassword
                    Me.htxtUserName.Value = .htxtUserName
                    Me.htxtTrackRevisions.Value = .htxtTrackRevisions
                End With

                '释放资源
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 保存模块现场信息并返回相应的SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strSessionId As String = ""
            Dim strErrMsg As String

            saveModuleInformation = ""

            Try
                '创建SessionId
                strSessionId = objPulicParameters.getNewGuid()
                If strSessionId = "" Then Exit Try

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowEditWord

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtEditMode = Me.htxtEditMode.Value
                    '2009-02-20
                    .htxtLocked = Me.htxtLocked.Value
                    '2009-02-20
                    .htxtFileSpec = Me.htxtFileSpec.Value
                    .htxtAutoSave = Me.htxtAutoSave.Value
                    .htxtCanQSYJ = Me.htxtCanQSYJ.Value
                    .htxtCanImportFile = Me.htxtCanImportFile.Value
                    .htxtCanExportFile = Me.htxtCanExportFile.Value
                    .htxtCanSelectTGWJ = Me.htxtCanSelectTGWJ.Value
                    .htxtCursorPos = Me.htxtCursorPos.Value
                    .htxtProtectPassword = Me.htxtProtectPassword.Value
                    .htxtUserName = Me.htxtUserName.Value
                    .htxtTrackRevisions = Me.htxtTrackRevisions.Value
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            saveModuleInformation = strSessionId
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Try
                If Me.IsPostBack = True Then Exit Try

                '=================================================================
                Dim objIFlowXgwj As Josco.JSOA.BusinessFacade.IFlowXgwj
                Try
                    objIFlowXgwj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowXgwj)
                Catch ex As Exception
                    objIFlowXgwj = Nothing
                End Try
                If Not (objIFlowXgwj Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowXgwj.Dispose()
                    objIFlowXgwj = Nothing
                    Exit Try
                End If

                '=================================================================
                Dim objIFlowFujian As Josco.JSOA.BusinessFacade.IFlowFujian
                Try
                    objIFlowFujian = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowFujian)
                Catch ex As Exception
                    objIFlowFujian = Nothing
                End Try
                If Not (objIFlowFujian Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowFujian.Dispose()
                    objIFlowFujian = Nothing
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getDataFromCallModule = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放接口参数(模块无返回数据时用)
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
                If Not (Me.m_objInterface Is Nothing) Then
                    If Me.m_objInterface.iInterfaceType = Josco.JSOA.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                        Me.m_objInterface.Dispose()
                        Me.m_objInterface = Nothing
                    End If
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 获取接口参数(没有接口参数则显示错误信息页面)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowEditWord)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try

                '必须有接口参数
                Me.m_blnInterface = False
                If m_objInterface Is Nothing Then
                    '显示错误信息
                    strErrMsg = "本模块必须提供输入接口参数！"
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = strErrMsg
                    blnContinue = False
                    Exit Try
                End If
                Me.m_blnInterface = True
                Me.htxtISession.Value = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)

                '初始化工作流
                If Me.doInitializeWorkflowData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowEditWord)
                    Catch ex As Exception
                        Me.m_objSaveScence = Nothing
                    End Try
                    If Me.m_objSaveScence Is Nothing Then
                        Me.m_blnSaveScence = False
                    Else
                        Me.m_blnSaveScence = True
                    End If

                    If Me.m_blnSaveScence = False Then
                        '从接口获取参数
                        Me.htxtFileSpec.Value = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + Me.m_objInterface.iGJFileSpec
                        Me.htxtProtectPassword.Value = Josco.JsKernal.Common.Utilities.PulicParameters.FileProtectPassword
                        Me.htxtUserName.Value = MyBase.UserXM

                        If Me.m_objInterface.iEditMode = True Then
                            Me.htxtEditMode.Value = "1"
                        Else
                            Me.htxtEditMode.Value = "0"
                        End If

                        '痕迹处理？
                        If Me.m_objInterface.iTrackRevisions = True And Me.m_objInterface.iHasSendOnce = True Then
                            Me.htxtTrackRevisions.Value = "1"
                        Else
                            Me.htxtTrackRevisions.Value = "0"
                        End If

                        '自动保存？
                        If Me.m_objInterface.iAutoSave = True Then
                            Me.htxtAutoSave.Value = "1"
                        Else
                            Me.htxtAutoSave.Value = "0"
                        End If

                        '显示意见？
                        If Me.m_objInterface.iCanQSYJ = True Then
                            Me.htxtCanQSYJ.Value = "1"
                        Else
                            Me.htxtCanQSYJ.Value = "0"
                        End If

                        '导入文件？
                        If Me.m_objInterface.iCanImportGJ = True Then
                            Me.htxtCanImportFile.Value = "1"
                        Else
                            Me.htxtCanImportFile.Value = "0"
                        End If

                        '导出文件？
                        If Me.m_objInterface.iCanExportGJ = True Then
                            Me.htxtCanExportFile.Value = "1"
                        Else
                            Me.htxtCanExportFile.Value = "0"
                        End If

                        '选择投稿文件？
                        If Me.m_objInterface.iCanSelectTGWJ = True Then
                            Me.htxtCanSelectTGWJ.Value = "1"
                        Else
                            Me.htxtCanSelectTGWJ.Value = "0"
                        End If
                    Else
                        '恢复现场参数后释放该资源
                        Me.restoreModuleInformation(strSessionId)
                    End If

                    '处理调用模块返回后的信息并同时释放相应资源
                    If Me.getDataFromCallModule(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

                '设置模块其他参数
                If Me.htxtEditMode.Value = "1" Then
                    Me.m_blnEditMode = True
                Else
                    Me.m_blnEditMode = False
                End If
                Me.m_strGJFileName = objPulicParameters.getObjectValue(Me.htxtFileSpec.Value, "")
                Me.htxtFlowTypeName.Value = Me.m_objInterface.iFlowTypeName
                Me.htxtWJBS.Value = Me.m_objInterface.iWJBS
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getInterfaceParameters = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数(模块返回时用)
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 创建并初始化工作流对象
        '----------------------------------------------------------------
        Private Function doInitializeWorkflowData(ByRef strErrMsg As String) As Boolean

            doInitializeWorkflowData = False
            Dim blnlocked As Boolean = False

            Try
                '创建工作流对象
                Dim strFlowTypeName As String = Me.m_objInterface.iFlowTypeName
                Dim strFlowType As String
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                Me.m_objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '初始化工作流对象并获取工作流数据
                If Me.m_objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, True) = False Then
                    GoTo errProc
                End If

                '2009-02-20
                Dim strBMMC As String = ""
                Dim strRYMC As String = ""
                If Me.m_objsystemFlowObject.getFileLocked(strErrMsg, blnlocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If

                '是否有人在编辑？
                If blnlocked = True Then
                    Me.htxtLocked.Value = "[" + strBMMC + "]单位的[" + strRYMC + "]人员正在编辑本文件！"
                Else
                    Me.htxtLocked.Value = ""
                End If
                '2009-02-20
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doInitializeWorkflowData = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 初始化控件
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            initializeControls = False

            Try
              

                '仅在第一次调用页面时执行
                If Me.IsPostBack = False Then
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '设置文件已经阅读
                    If Me.m_blnSaveScence = False Then
                        If Me.m_objsystemFlowObject.doSetHasReadFile(strErrMsg, MyBase.UserXM) = False Then
                            GoTo errProc
                        End If
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            initializeControls = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strUrl As String

            Try
                '预处理
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                '获取接口参数
                Dim blnDo As Boolean
                If Me.getInterfaceParameters(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = False Then
                    Exit Try
                End If

                '控件初始化
                If Me.initializeControls(strErrMsg) = False Then
                    GoTo errProc
                End If

                '记录访问审计日志
                If Me.IsPostBack = False Then
                    If Me.m_blnSaveScence = False Then
                        If Me.m_objsystemFlowObject.FlowData.WJBS <> "" Then
                            If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了文件[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]的[主文件]！") = False Then
                                '忽略
                            End If
                        End If
                    End If
                End If
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

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(Me.m_objsystemFlowObject)
        End Sub








        '----------------------------------------------------------------
        ' 删除缓存文件
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doDeleteCacheFile(ByRef strErrMsg As String) As Boolean

            doDeleteCacheFile = False

            Try
                '删除缓存文件
                If Me.doDeleteCacheFile_GJ(strErrMsg) = False Then
                    '可以不成功，产生垃圾文件
                End If
                If Me.m_objsystemFlowObject.doDeleteCacheFile_FJ(strErrMsg, Me.m_objInterface.iobjDataSet_FJ) = False Then
                    '可以不成功，产生垃圾文件
                End If
                If Me.m_objsystemFlowObject.doDeleteCacheFile_XGWJ(strErrMsg, Me.m_objInterface.iobjDataSet_XGWJ) = False Then
                    '可以不成功，产生垃圾文件
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doDeleteCacheFile = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 删除缓存稿件文件
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doDeleteCacheFile_GJ(ByRef strErrMsg As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doDeleteCacheFile_GJ = False

            Try
                If Me.m_strGJFileName <> "" Then
                    '删除临时缓存文件
                    Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                    Dim strGJFileSpec As String = ""
                    strGJFileSpec = objBaseLocalFile.getFileName(Me.m_strGJFileName)
                    strGJFileSpec = objBaseLocalFile.doMakePath(strGJPath, strGJFileSpec)
                    If objBaseLocalFile.doDeleteFile(strErrMsg, strGJFileSpec) = False Then
                        '可以不成功，产生垃圾数据
                    End If
                End If

                '强制重新获取文件！
                Me.htxtFileSpec.Value = ""
                Me.m_strGJFileName = ""

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doDeleteCacheFile_GJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '自动保存模式下清除文件缓存
                If Me.m_objInterface.iEditMode = True Then
                    If Me.m_objInterface.iAutoSave = True Then
                        '清除自己的编辑封锁
                        If Me.m_objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                            GoTo errProc
                        End If
                        '清除临时文件
                        If Me.doDeleteCacheFile(strErrMsg) = False Then
                            '可以删除不成功，形成垃圾文件！
                        End If
                    End If
                End If

                '设置返回参数
                Me.m_objInterface.oExitMode = False
                '返回到调用模块，并附加返回参数
                '要返回的SessionId
                Dim strSessionId As String = ""
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                'SessionId附加到返回的Url
                Dim strUrl As String = ""
                strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                '释放模块资源
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()
                '返回
                Response.Redirect(strUrl)
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

        '=================================================================================
        '更改记录
        'zengxianglin 2008-07-04 自动保存时保存文件但不退出文件编辑
        '=================================================================================
        Private Sub doSave(ByVal strControlId As String)

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '是否自动保存?
                If Me.m_objInterface.iEditMode = True Then      '编辑模式
                    If Me.m_objInterface.iAutoSave = True Then     '自动保存
                        '转换Url到Web本地路径！
                        Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                        Dim strGJFileSpec As String = ""
                        strGJFileSpec = objBaseLocalFile.getFileName(Me.m_strGJFileName)
                        strGJFileSpec = objBaseLocalFile.doMakePath(strGJPath, strGJFileSpec)

                        '需要自动保存
                        '同时保存稿件、附件、相关文件、签批意见等数据
                        If Me.m_objsystemFlowObject.doSaveFileZDBCVariantParam(strErrMsg, _
                            MyBase.UserId, MyBase.UserPassword, _
                            strGJFileSpec, _
                            Me.m_objInterface.iobjDataSet_FJ, _
                            Me.m_objInterface.iobjDataSet_XGWJ, _
                            MyBase.UserXM, _
                            Me.m_objInterface.iEnforeEdit, _
                            Nothing) = False Then
                            GoTo errProc
                        End If

                        '2009-03-18 zengxianglin
                        '重新锁定编辑
                        If Me.m_objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, True) = False Then
                            GoTo errProc
                        End If
                        '2009-03-18 zengxianglin
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpenFJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objIFlowFujian As Josco.JSOA.BusinessFacade.IFlowFujian = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim blnHasSendOnce As Boolean = False
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '文件发送过？
                blnHasSendOnce = Me.m_objInterface.iHasSendOnce

                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String = ""
                objIFlowFujian = New Josco.JSOA.BusinessFacade.IFlowFujian
                With objIFlowFujian
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iFlowTypeName = Me.m_objInterface.iFlowTypeName
                    .iDataSet_FJ = Me.m_objInterface.iobjDataSet_FJ
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iEditMode = Me.m_objInterface.iEditMode
                    .iWJBS = Me.m_objInterface.iWJBS
                    .iAutoSave = False

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strSessionId
                    .iReturnUrl = strUrl
                End With
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowFujian)

                strUrl = ""
                strUrl += "flow_fujian.aspx"
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

        Private Sub doOpenXGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objIFlowXgwj As Josco.JSOA.BusinessFacade.IFlowXgwj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim blnHasSendOnce As Boolean = False
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '文件发送过？
                blnHasSendOnce = Me.m_objInterface.iHasSendOnce

                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String = ""
                objIFlowXgwj = New Josco.JSOA.BusinessFacade.IFlowXgwj
                With objIFlowXgwj
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iDataSet_XGWJ = Me.m_objInterface.iobjDataSet_XGWJ
                    .iFlowTypeName = Me.m_objInterface.iFlowTypeName
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iEditMode = Me.m_objInterface.iEditMode
                    .iWJBS = Me.m_objInterface.iWJBS
                    .iAutoSave = False

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strSessionId
                    .iReturnUrl = strUrl
                End With
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowXgwj)

                strUrl = ""
                strUrl += "flow_xgwj.aspx"
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

        '=================================================================================
        '更改记录
        'zengxianglin 2008-07-04 增加本处理
        '=================================================================================
        Private Sub doSaveAndClose(ByVal strControlId As String)

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim blnExitMode As Boolean = True
            Dim strErrMsg As String = ""

            Try
                '是否自动保存?
                If Me.m_objInterface.iEditMode = True Then      '编辑模式
                    If Me.m_objInterface.iAutoSave = True Then     '自动保存
                        '转换Url到Web本地路径！
                        Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                        Dim strGJFileSpec As String = ""
                        strGJFileSpec = objBaseLocalFile.getFileName(Me.m_strGJFileName)
                        strGJFileSpec = objBaseLocalFile.doMakePath(strGJPath, strGJFileSpec)

                        '需要自动保存
                        '同时保存稿件、附件、相关文件、签批意见等数据
                        If Me.m_objsystemFlowObject.doSaveFileZDBCVariantParam(strErrMsg, _
                         MyBase.UserId, MyBase.UserPassword, _
                         strGJFileSpec, _
                         Me.m_objInterface.iobjDataSet_FJ, _
                         Me.m_objInterface.iobjDataSet_XGWJ, _
                         MyBase.UserXM, _
                         Me.m_objInterface.iEnforeEdit, _
                         Nothing) = False Then
                            GoTo errProc
                        End If

                        '清除临时文件
                        If Me.doDeleteCacheFile(strErrMsg) = False Then
                            '可以删除不成功，形成垃圾文件！
                        End If

                        '阻止继续处理
                        blnExitMode = False
                    End If
                End If

                '设置返回参数
                Me.m_objInterface.oExitMode = blnExitMode
                '返回到调用模块，并附加返回参数
                '要返回的SessionId
                Dim strSessionId As String = ""
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                'SessionId附加到返回的Url
                Dim strUrl As String = ""
                strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                '释放模块资源
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()
                '返回
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub lnkMLClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub

        Private Sub lnkMLSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSave.Click
            Me.doSave("lnkMLSave")
        End Sub

        Private Sub lnkMLSaveAndClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSaveAndClose.Click
            Me.doSaveAndClose("lnkMLSaveAndClose")
        End Sub

        Private Sub lnkMLXgfj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLXgfj.Click
            Me.doOpenFJ("lnkMLXgfj")
        End Sub

        Private Sub lnkMLXgwj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLXgwj.Click
            Me.doOpenXGWJ("lnkMLXgwj")
        End Sub

    End Class

End Namespace
