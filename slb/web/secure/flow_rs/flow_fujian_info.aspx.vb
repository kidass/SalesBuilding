Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_fujian_info
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也不调用其他模块
    '
    ' 功能描述： 
    '   　处理文件附件信息的查看与编辑操作
    '
    ' 接口参数：
    '     参见接口类IFlowFujianInfo描述
    '----------------------------------------------------------------

    Public Class flow_fujian_info
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtWJXH As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWJWZ As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWJSM As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWJYS As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWEBURL As System.Web.UI.WebControls.TextBox
        Protected WithEvents hifKHDWJ As System.Web.UI.HtmlControls.HtmlInputFile
        Protected WithEvents htxtWEBLOC As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWJBS As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWJXH As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFlowTypeName As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden

        Protected WithEvents htxtProtectPassword As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtTrackRevisions As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCanExportFile As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtUserName As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtEditMode As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtEditType As System.Web.UI.HtmlControls.HtmlInputHidden

        Protected WithEvents htxtFileSpec As System.Web.UI.HtmlControls.HtmlInputHidden

        Protected WithEvents lnkMLClose As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLSave As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLXzwj As System.Web.UI.WebControls.LinkButton

        Protected WithEvents htxtWatchInterval As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWatchSwitch As System.Web.UI.HtmlControls.HtmlInputHidden

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
        '本模块相对image的相对路径
        Private m_cstrRelativePathToImage As String = "../../"
        '文件下载后的缓存路径
        Private m_cstrUrlBaseToFileCache As String = "/temp/filecache/"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowFujianInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowFujianInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

        '----------------------------------------------------------------
        '模块其他参数
        '----------------------------------------------------------------
        Private m_objEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType   '编辑类型
        Private m_strFlowTypeName As String                                                 '工作流类型名称
        Private m_blnEditMode As Boolean                                                    '编辑模式
        Private m_strWJBS As String                                                         '文件标识









        '----------------------------------------------------------------
        ' 复原模块现场信息并释放相应的资源
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.txtWJXH.Text = .txtWJXH
                    Me.txtWJSM.Text = .txtWJSM
                    Me.txtWJYS.Text = .txtWJYS
                    Me.txtWJWZ.Text = .txtWJWZ
                    Me.txtWEBURL.Text = .txtWEBURL

                    Me.htxtWEBLOC.Value = .htxtWEBLOC

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                End With

                '释放资源
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

        End Sub

        '----------------------------------------------------------------
        ' 保存模块现场信息并返回相应的SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim strSessionId As String = ""
            Dim strErrMsg As String

            saveModuleInformation = ""

            Try
                '创建SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then Exit Try

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowFujianInfo

                '保存现场信息
                With Me.m_objSaveScence
                    .txtWJXH = Me.txtWJXH.Text
                    .txtWJSM = Me.txtWJSM.Text
                    .txtWJYS = Me.txtWJYS.Text
                    .txtWJWZ = Me.txtWJWZ.Text
                    .txtWEBURL = Me.txtWEBURL.Text

                    .htxtWEBLOC = Me.htxtWEBLOC.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule( _
            ByRef strErrMsg As String) As Boolean

            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            Try
                If Me.IsPostBack = True Then Exit Try

                '=================================================================

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
                        '释放Session
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                        '释放对象
                        Me.m_objInterface.Dispose()
                        Me.m_objInterface = Nothing
                    End If
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 初始化工作流对象
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doInitializeWorkflow(ByRef strErrMsg As String) As Boolean

            doInitializeWorkflow = False
            strErrMsg = ""

            Try
                '不用初始化
                If Not (Me.m_objsystemFlowObject Is Nothing) Then
                    Exit Try
                End If

                '创建工作流对象
                Dim strFlowTypeName As String = Me.m_objInterface.iFlowTypeName
                Dim strFlowType As String
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                Me.m_objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '初始化工作流并填充数据
                Dim strWJBS As String = Me.m_objInterface.iWJBS
                If Me.m_objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, True) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doInitializeWorkflow = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取接口参数(没有接口参数则显示错误信息页面)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String, ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowFujianInfo)
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

                '工作流初始化
                If Me.doInitializeWorkflow(strErrMsg) = False Then
                    GoTo errProc
                End If

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    '获取现场恢复参数
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowFujianInfo)
                    Catch ex As Exception
                        Me.m_objSaveScence = Nothing
                    End Try
                    '标记是否从现场恢复数据
                    If Me.m_objSaveScence Is Nothing Then
                        Me.m_blnSaveScence = False
                    Else
                        Me.m_blnSaveScence = True
                    End If

                    '恢复现场参数后释放该资源
                    Me.restoreModuleInformation(strSessionId)

                    '处理调用模块返回后的信息并同时释放相应资源
                    If Me.getDataFromCallModule(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

                '设置模块其他参数
                Me.m_objEditType = Me.m_objInterface.iEditType
                Select Case Me.m_objEditType
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Me.m_blnEditMode = True
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        Me.m_blnEditMode = True
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_blnEditMode = True
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eDelete
                        Me.m_blnEditMode = False
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                        Me.m_blnEditMode = False
                End Select
                Me.m_strFlowTypeName = Me.m_objInterface.iFlowTypeName
                Me.m_strWJBS = Me.m_objInterface.iWJBS
                Me.htxtFlowTypeName.Value = Me.m_objInterface.iFlowTypeName
                Me.htxtWJBS.Value = Me.m_objInterface.iWJBS
                Me.htxtWJXH.Value = Me.m_objInterface.iWJXH

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
        ' 清除缓存文件
        '----------------------------------------------------------------
        Private Sub doDeleteTempFiles()

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim strErrMsg As String

            Try
                '本次操作形成的缓存文件
                Dim strOldFile As String = Me.m_objInterface.iBDWJ.Trim.ToUpper
                Dim strNewFile As String = Me.htxtWEBLOC.Value.Trim.ToUpper
                If strNewFile <> "" Then
                    If strNewFile <> strOldFile Then
                        If objBaseLocalFile.doDeleteFile(strErrMsg, Me.htxtWEBLOC.Value) = False Then
                            '形成垃圾文件
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

        End Sub

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数(模块返回时用)
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 获取当前显示文件的扩展名
        '----------------------------------------------------------------
        Private Function getDisplayFileExtension() As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            getDisplayFileExtension = ""

            Try
                '根据文件类型显示Office控件
                Dim strFile As String = ""
                If Me.htxtWEBLOC.Value.Trim <> "" Then
                    strFile = Me.htxtWEBLOC.Value.Trim
                End If
                If strFile = "" Then
                    If Me.txtWJWZ.Text.Trim <> "" Then
                        strFile = Me.txtWJWZ.Text.Trim
                    End If
                End If

                '获取文件类型
                Dim strFileExt As String = ""
                If strFile <> "" Then
                    strFileExt = objBaseLocalFile.getExtension(strFile)
                    strFileExt = strFileExt.ToUpper
                End If

                getDisplayFileExtension = strFileExt

            Catch ex As Exception
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示整个模块信息
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑状态
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_Main = False

            Try
                '显示数据
                Me.txtWJXH.Text = Me.m_objInterface.iWJXH
                Me.txtWJSM.Text = Me.m_objInterface.iWJSM
                Me.txtWJYS.Text = Me.m_objInterface.iWJYS
                Me.txtWJWZ.Text = Me.m_objInterface.iWJWZ

                '获取临时文件的WEB本地路径
                Me.htxtWEBLOC.Value = Me.m_objInterface.iBDWJ

                '获取临时文件的WEB虚拟路径
                Dim strFile As String = ""
                If Me.m_objInterface.iBDWJ <> "" Then
                    strFile = Me.m_objInterface.iBDWJ
                    strFile = objBaseLocalFile.getFileName(strFile)
                    strFile = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strFile
                End If
                Me.txtWEBURL.Text = strFile

                Select Case Me.m_objInterface.iEditType
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                         JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        objControlProcess.doEnabledControl(Me.txtWJXH, False)
                        objControlProcess.doEnabledControl(Me.txtWJWZ, False)
                        objControlProcess.doEnabledControl(Me.txtWJSM, True)
                        objControlProcess.doEnabledControl(Me.txtWJYS, True)
                        objControlProcess.doEnabledControl(Me.hifKHDWJ, True)
                        objControlProcess.doEnabledControl(Me.txtWEBURL, False)
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        objControlProcess.doEnabledControl(Me.txtWJXH, False)
                        objControlProcess.doEnabledControl(Me.txtWJWZ, False)
                        objControlProcess.doEnabledControl(Me.txtWJSM, True)
                        objControlProcess.doEnabledControl(Me.txtWJYS, True)
                        objControlProcess.doEnabledControl(Me.hifKHDWJ, True)
                        objControlProcess.doEnabledControl(Me.txtWEBURL, False)
                    Case Else
                        objControlProcess.doEnabledControl(Me.txtWJXH, False)
                        objControlProcess.doEnabledControl(Me.txtWJWZ, False)
                        objControlProcess.doEnabledControl(Me.txtWJSM, False)
                        objControlProcess.doEnabledControl(Me.txtWJYS, False)
                        objControlProcess.doEnabledControl(Me.hifKHDWJ, False)
                        objControlProcess.doEnabledControl(Me.txtWEBURL, False)
                End Select

                '获取要显示文件
                Dim strFileExt As String = Me.getDisplayFileExtension()
                Select Case strFileExt.ToUpper
                    Case ".DOC", ".XLS"
                        If Me.getDisplayFile(strErrMsg, True, strFile) = False Then
                            GoTo errProc
                        End If
                    Case Else
                        If Me.getDisplayFile(strErrMsg, False, strFile) = False Then
                            GoTo errProc
                        End If
                End Select
                If Me.doSetOfficeParameters(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_Main = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 初始化控件
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            Try
                

                '仅在第一次调用页面时执行
                If Me.IsPostBack = False Then
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    With objControlProcess
                        .doTranslateKey(Me.txtWJXH)
                        .doTranslateKey(Me.txtWJWZ)
                        .doTranslateKey(Me.txtWEBURL)
                        .doTranslateKey(Me.txtWJSM)
                        .doTranslateKey(Me.txtWJYS)
                        .doTranslateKey(Me.hifKHDWJ)
                    End With

                    If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function

errProc:
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim strUrl As String

            Try
                '预处理
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                '获取接口参数
                Dim blnContinue As Boolean
                If Me.getInterfaceParameters(strErrMsg, blnContinue) = False Then
                    GoTo errProc
                End If
                If blnContinue = False Then
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
                            If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了文件[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]的第[" + Me.m_objInterface.iWJXH + "]个附件内容！") = False Then
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

        Private Sub Page_Unload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(Me.m_objsystemFlowObject)

        End Sub



        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '清除自己的编辑封锁
                Select Case Me.m_objInterface.iEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        If Me.m_objInterface.iAutoSave = True Then
                            If Me.m_objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                                GoTo errProc
                            End If
                        End If
                End Select

                '清除临时文件
                doDeleteTempFiles()

                '设置返回参数
                Me.m_objInterface.oExitMode = False
                '返回到调用模块，并附加返回参数
                '要返回的SessionId
                Dim strSessionId As String
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                'SessionId附加到返回的Url
                Dim strUrl As String
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

        '----------------------------------------------------------------
        ' 从控件中获取当前数据信息
        '     strErrMsg      ：返回错误信息
        '     objNewData     ：返回新数据的字符串集合
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getNewData( _
            ByRef strErrMsg As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            getNewData = False
            objNewData = Nothing
            strErrMsg = ""

            Try
                '创建集合
                objNewData = New System.Collections.Specialized.NameValueCollection

                '获取数据
                objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJXH, Me.txtWJXH.Text)
                objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM, Me.txtWJSM.Text)
                objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS, Me.txtWJYS.Text)
                objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ, Me.htxtWEBLOC.Value)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getNewData = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Exit Function
        End Function

        '----------------------------------------------------------------
        ' 将集合中值设置到控件
        '     strErrMsg      ：返回错误信息
        '     objNewData     ：新数据的字符串集合
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function setNewData( _
            ByRef strErrMsg As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            setNewData = False
            strErrMsg = ""

            Try
                '检查
                If objNewData Is Nothing Then
                    Exit Try
                End If

                '设置数据
                With objPulicParameters
                    Me.txtWJXH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJXH), "")
                    Me.txtWJSM.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM), "")
                    Me.txtWJYS.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            setNewData = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function
        End Function

        '----------------------------------------------------------------
        ' 如果有文件上传，则缓存在WEB服务器本地的文件缓存目录中
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doUploadFile(ByRef strErrMsg As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doUploadFile = False

            Try
                '如果有文件上传，则缓存在WEB服务器本地的文件缓存目录中
                Dim strFilePath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                Dim strFileSpec As String = ""
                Dim strFileName As String = ""
                Dim strOldFile As String = ""
                If Not (Me.hifKHDWJ.PostedFile Is Nothing) Then
                    If Me.hifKHDWJ.PostedFile.FileName <> "" Then
                        '获取新文件路径
                        If objBaseLocalFile.doCreateTempFile(strErrMsg, Me.hifKHDWJ.PostedFile.FileName, True, strFileName) = False Then
                            GoTo errProc
                        End If
                        If strFileName = "" Then
                            strErrMsg = "错误：无法获取临时文件！"
                            GoTo errProc
                        End If
                        strFileSpec = objBaseLocalFile.doMakePath(strFilePath, strFileName)
                        '删除本屏幕操作形成的临时文件
                        Me.doDeleteTempFiles()
                        '重新上载文件
                        Me.hifKHDWJ.PostedFile.SaveAs(strFileSpec)
                        '保存WEB本地文件路径
                        Me.htxtWEBLOC.Value = strFileSpec
                        '保存WEB虚拟文件路径
                        Me.txtWEBURL.Text = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strFileName
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doUploadFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        Private Sub doSave(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objNewData As System.Collections.Specialized.NameValueCollection

            Try
                '准备校验的数据
                If Me.getNewData(strErrMsg, objNewData) = False Then
                    GoTo errProc
                End If
                '校验要保存的数据
                If Me.m_objsystemFlowObject.doVerifyFujian(strErrMsg, objNewData) = False Then
                    GoTo errProc
                End If
                '校验后的数据重新设置
                If Me.setNewData(strErrMsg, objNewData) = False Then
                    GoTo errProc
                End If

                '如果有文件上传，则缓存在WEB服务器本地的文件缓存目录中
                If Me.doUploadFile(strErrMsg) = False Then
                    GoTo errProc
                End If

                '是否需要自动保存？
                '自动保存只会发生在Update模式下
                Dim blnReturnSet As Boolean = True
                Select Case Me.m_objInterface.iEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        If Me.m_objInterface.iAutoSave = True Then
                            '需要保存当前附件到数据库
                            If Me.m_objsystemFlowObject.doSaveFujian(strErrMsg, Me.m_objInterface.iEnforeEdit, MyBase.UserXM, objNewData) = False Then
                                GoTo errProc
                            End If
                            '记录访问审计日志
                            If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "更改了文件[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]的第[" + Me.txtWJXH.Text + "]个附件！") = False Then
                                '忽略
                            End If
                            '删除缓存文件
                            If Me.htxtWEBLOC.Value.Trim <> "" Then
                                If objBaseLocalFile.doDeleteFile(strErrMsg, Me.htxtWEBLOC.Value) = False Then
                                    '形成垃圾文件
                                End If
                                Me.htxtWEBLOC.Value = ""
                            End If
                            '设置返回参数
                            blnReturnSet = False
                            Me.m_objInterface.oExitMode = False
                        End If
                    Case Else
                End Select
                If blnReturnSet = True Then
                    '设置返回参数
                    Me.m_objInterface.oExitMode = True
                    Me.m_objInterface.oWJXH = Me.txtWJXH.Text.Trim
                    Me.m_objInterface.oWJSM = Me.txtWJSM.Text.Trim
                    Me.m_objInterface.oWJYS = Me.txtWJYS.Text.Trim
                    Me.m_objInterface.oBDWJ = Me.htxtWEBLOC.Value.Trim
                    Me.m_objInterface.oWJWZ = Me.m_objInterface.iWJWZ
                End If

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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 获取当前要显示的文件名
        '     strErrMsg      ：返回错误信息
        '     blnDownload    ：=true没有缓存文件就下载
        '     strFileName    ：返回要显示的文件名
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getDisplayFile( _
            ByRef strErrMsg As String, _
            ByVal blnDownload As Boolean, _
            ByRef strFileName As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon

            getDisplayFile = False
            strFileName = ""

            Try
                '获取信息
                Dim strFTPPath As String
                Dim strDesSpec As String
                Dim strDesPath As String
                Dim strDesFile As String
                Dim strUrl As String
                strFTPPath = Me.txtWJWZ.Text.Trim
                strDesSpec = Me.htxtWEBLOC.Value.Trim

                '下载文件
                If strDesSpec <> "" Then
                    '如果直接有本地文件，则直接将WEB本地文件下载到客户端
                    strDesFile = objBaseLocalFile.getFileName(strDesSpec)
                Else
                    '从FTP服务器下载
                    If blnDownload = True Then
                        strDesPath = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache
                        strDesPath = Server.MapPath(strDesPath)
                        If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, strFTPPath, strDesSpec, strDesPath, strDesFile) = False Then
                            GoTo errProc
                        End If
                        strDesSpec = objBaseLocalFile.doMakePath(strDesPath, strDesFile)
                    Else
                        'LJ 2008-07-24
                        If strFTPPath <> "" Then
                            strDesPath = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache
                            strDesPath = Server.MapPath(strDesPath)
                            If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, strFTPPath, strDesSpec, strDesPath, strDesFile) = False Then
                                GoTo errProc
                            End If
                            strDesSpec = objBaseLocalFile.doMakePath(strDesPath, strDesFile)
                        Else
                            strDesFile = ""
                            strDesSpec = ""
                        End If
                    End If
                End If

                '记录缓存文件
                If strDesFile <> "" Then
                    strUrl = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strDesFile
                    Me.htxtWEBLOC.Value = strDesSpec
                    Me.txtWEBURL.Text = strUrl
                End If

                '返回
                strFileName = strDesFile

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)

            getDisplayFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据显示文件设置Office控件的参数
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doSetOfficeParameters(ByRef strErrMsg As String) As Boolean

            doSetOfficeParameters = False
            strErrMsg = ""

            Try
                '获取临时文件类型
                Dim strFileExt As String = Me.getDisplayFileExtension()
                Dim strDesFile As String = ""

                '根据类型设置参数
                Select Case strFileExt
                    Case ".DOC", ".XLS"
                        '获取要显示的文件
                        If Me.getDisplayFile(strErrMsg, False, strDesFile) = False Then
                            GoTo errProc
                        End If
                        If strDesFile <> "" Then
                            Me.htxtProtectPassword.Value = Josco.JsKernal.Common.Utilities.PulicParameters.FileProtectPassword
                            Me.htxtFileSpec.Value = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + strDesFile
                            Me.htxtUserName.Value = MyBase.UserXM
                            If Me.m_objInterface.iTrackRevisions = True Then
                                Me.htxtTrackRevisions.Value = "1"
                            Else
                                Me.htxtTrackRevisions.Value = "0"
                            End If
                            Me.htxtCanExportFile.Value = "1"
                            If Me.m_blnEditMode = True Then
                                Me.htxtEditMode.Value = "1"
                            Else
                                Me.htxtEditMode.Value = "0"
                            End If
                            Select Case Me.m_objEditType
                                Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                    Me.htxtEditType.Value = "1"
                                Case Else
                                    Me.htxtEditType.Value = "0"
                            End Select
                        Else
                            Me.htxtProtectPassword.Value = ""
                            Me.htxtFileSpec.Value = ""
                            Me.htxtUserName.Value = ""
                            Me.htxtTrackRevisions.Value = "0"
                            Me.htxtCanExportFile.Value = "0"
                            If Me.m_blnEditMode = True Then
                                Me.htxtEditMode.Value = "1"
                            Else
                                Me.htxtEditMode.Value = "0"
                            End If
                            Select Case Me.m_objEditType
                                Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                    Me.htxtEditType.Value = "1"
                                Case Else
                                    Me.htxtEditType.Value = "0"
                            End Select
                        End If

                    Case Else
                        Me.htxtProtectPassword.Value = ""
                        Me.htxtFileSpec.Value = ""
                        Me.htxtUserName.Value = ""
                        Me.htxtTrackRevisions.Value = "0"
                        Me.htxtCanExportFile.Value = "0"
                        If Me.m_blnEditMode = True Then
                            Me.htxtEditMode.Value = "1"
                        Else
                            Me.htxtEditMode.Value = "0"
                        End If
                        Select Case Me.m_objEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                   Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                                   Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                Me.htxtEditType.Value = "1"
                            Case Else
                                Me.htxtEditType.Value = "0"
                        End Select
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doSetOfficeParameters = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Sub doDownloadFile(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon

            Try
                '初始化工作流
                Dim strName As String = Me.m_objInterface.iFlowTypeName
                Dim strType As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strName)
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, False) = False Then
                    GoTo errProc
                End If

                '如果有文件上载！
                If Me.doUploadFile(strErrMsg) = False Then
                    GoTo errProc
                End If

                '获取显示文件
                Dim strDesFile As String = ""
                If Me.getDisplayFile(strErrMsg, True, strDesFile) = False Then
                    GoTo errProc
                End If

                '根据文件类型显示
                If Me.doSetOfficeParameters(strErrMsg) = False Then
                    GoTo errProc
                End If
                Dim strFileExt As String = Me.getDisplayFileExtension()
                Dim strUrl As String = ""
                Select Case strFileExt
                    Case ".DOC", ".XLS"
                    Case Else
                        '记录访问审计日志
                        If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "下载了文件[" + objsystemFlowObject.FlowData.WJBS + "]的第[" + Me.txtWJXH.Text + "]个附件！") = False Then
                            '忽略
                        End If

                        strUrl = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strDesFile
                        objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub lnkMLXzwj_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLXzwj.Click
            Me.doDownloadFile("lnkMLXzwj")
        End Sub

        Private Sub lnkMLClose_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub

        Private Sub lnkMLSave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSave.Click
            Me.doSave("lnkMLSave")
        End Sub

    End Class

End Namespace
