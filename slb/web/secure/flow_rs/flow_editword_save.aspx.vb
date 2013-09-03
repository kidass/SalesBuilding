Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_editword_save
    ' 
    ' 调用性质：
    '     仅供querystring参数调用
    '         SessionId
    '         FileName
    ' 功能描述： 
    '     当强制编辑文件时，后台保存文件及数据到服务器
    ' 接口参数：
    '----------------------------------------------------------------

    Public Class flow_editword_save
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        End Sub

        Protected WithEvents htxtPostFlag As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lnkMLSave As System.Web.UI.WebControls.LinkButton

        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage

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

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowEditWord
        Private m_blnInterface As Boolean

        Private QUERYSTRING_SESSIONID As String = "SessionId"
        Private QUERYSTRING_FILENAME As String = "FileName"

        '----------------------------------------------------------------
        '模块数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

        '----------------------------------------------------------------
        '模块其他参数
        '----------------------------------------------------------------
        Private m_strGJFileName As String
        Private m_blnEditMode As Boolean










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
                    objTemp = Session.Item(Request.QueryString(Me.QUERYSTRING_SESSIONID))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowEditWord)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                Me.m_strGJFileName = Request.QueryString(Me.QUERYSTRING_FILENAME)
                If Me.m_strGJFileName Is Nothing Then Me.m_strGJFileName = ""
                Me.m_strGJFileName = Me.m_strGJFileName.Trim

                '必须有接口参数
                Me.m_blnInterface = False
                If (m_objInterface Is Nothing) Or (Me.m_strGJFileName = "") Then
                    strErrMsg = "本模块必须提供输入接口参数！"
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = strErrMsg
                    blnContinue = False
                    Exit Try
                End If
                Me.m_blnInterface = True
                Me.m_blnEditMode = Me.m_objInterface.iEditMode

                '初始化工作流
                If Me.doInitializeWorkflowData(strErrMsg) = False Then
                    GoTo errProc
                End If
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
        ' 创建并初始化工作流对象
        '----------------------------------------------------------------
        Private Function doInitializeWorkflowData(ByRef strErrMsg As String) As Boolean

            doInitializeWorkflowData = False

            Try
                '创建工作流对象
                Dim strFlowTypeName As String = Me.m_objInterface.iFlowTypeName
                Dim strFlowType As String = ""
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                Me.m_objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '初始化工作流对象并获取工作流数据
                If Me.m_objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, True) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doInitializeWorkflowData = True
            Exit Function
errProc:
            Exit Function

        End Function

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
            Dim strUrl As String = ""

            Try
                '预处理
                If MyBase.doPagePreprocess(True, Not Me.IsPostBack) = True Then
                    Exit Sub
                End If

                '获取接口参数
                Dim blnDo As Boolean = False
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

        Private Sub lnkMLSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSave.Click
            Me.doSave("lnkMLSave")
        End Sub

    End Class

End Namespace
