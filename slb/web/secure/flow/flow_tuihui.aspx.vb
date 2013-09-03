Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_tuihui
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理工作流文件的退回任务
    '
    ' 接口参数：
    '     参见接口类IFlowTuihui描述
    '----------------------------------------------------------------

    Public Class flow_tuihui
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblFSRXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents lblZZTS As System.Web.UI.WebControls.Label
        Protected WithEvents grdFSRXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTuihui As System.Web.UI.WebControls.Button
        Protected WithEvents btnRefresh As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtFSRXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFSRXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFSRXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFSRXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFSRXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFSRXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftFSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopFSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden

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

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowTuihui
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowTuihui
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_FSRXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_FSRXX As String '记录m_objDataSet_FSRXX搜索串
        Private m_intRows_FSRXX As Integer '记录m_objDataSet_FSRXX的DefaultView记录数

        '----------------------------------------------------------------
        '与数据网格grdFSRXX相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_FSRXX As String = "chkFSRXX"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_FSRXX As String = "divFSRXX"
        '网格要锁定的列数
        Private m_intFixedColumns_FSRXX As Integer

        '----------------------------------------------------------------
        '模块其他参数
        '----------------------------------------------------------------
        '工作流类型名称
        Private m_strFlowTypeName As String
        '文件标识
        Private m_strWJBS As String










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
                    Me.htxtDivLeftFSRXX.Value = .htxtDivLeftFSRXX
                    Me.htxtDivTopFSRXX.Value = .htxtDivTopFSRXX

                    Me.htxtFSRXXQuery.Value = .htxtFSRXXQuery
                    Me.htxtFSRXXRows.Value = .htxtFSRXXRows
                    Me.htxtFSRXXSort.Value = .htxtFSRXXSort
                    Me.htxtFSRXXSortColumnIndex.Value = .htxtFSRXXSortColumnIndex
                    Me.htxtFSRXXSortType.Value = .htxtFSRXXSortType

                    Try
                        Me.grdFSRXX.PageSize = .grdFSRXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFSRXX.CurrentPageIndex = .grdFSRXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFSRXX.SelectedIndex = .grdFSRXX_SelectedIndex
                    Catch ex As Exception
                    End Try

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strSessionId As String = ""
            Dim strErrMsg As String

            saveModuleInformation = ""

            Try
                '创建SessionId
                strSessionId = objPulicParameters.getNewGuid()
                If strSessionId = "" Then Exit Try

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowTuihui

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftFSRXX = Me.htxtDivLeftFSRXX.Value
                    .htxtDivTopFSRXX = Me.htxtDivTopFSRXX.Value

                    .htxtFSRXXQuery = Me.htxtFSRXXQuery.Value
                    .htxtFSRXXRows = Me.htxtFSRXXRows.Value
                    .htxtFSRXXSort = Me.htxtFSRXXSort.Value
                    .htxtFSRXXSortColumnIndex = Me.htxtFSRXXSortColumnIndex.Value
                    .htxtFSRXXSortType = Me.htxtFSRXXSortType.Value

                    .grdFSRXX_PageSize = Me.grdFSRXX.PageSize
                    .grdFSRXX_CurrentPageIndex = Me.grdFSRXX.CurrentPageIndex
                    .grdFSRXX_SelectedIndex = Me.grdFSRXX.SelectedIndex

                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.IsPostBack = True Then Exit Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowTuihui)
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

                '初始化工作流
                If Me.doInitializeWorkflow(strErrMsg) = False Then
                    GoTo errProc
                End If

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowTuihui)
                    Catch ex As Exception
                        Me.m_objSaveScence = Nothing
                    End Try
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
                Me.m_intFixedColumns_FSRXX = objPulicParameters.getObjectValue(Me.htxtFSRXXFixed.Value, 0)
                Me.m_intRows_FSRXX = objPulicParameters.getObjectValue(Me.htxtFSRXXRows.Value, 0)
                Me.m_strQuery_FSRXX = Me.htxtFSRXXQuery.Value

                Me.m_strFlowTypeName = Me.m_objInterface.iFlowTypeName
                Me.m_strWJBS = Me.m_objInterface.iWJBS

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
        ' 获取接收人信息数据集
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_FSRXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANTUIHUI
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_FSRXX = False

            Try
                '释放资源
                If Not (Me.m_objDataSet_FSRXX Is Nothing) Then
                    Me.m_objDataSet_FSRXX.Dispose()
                    Me.m_objDataSet_FSRXX = Nothing
                End If

                '从数据库获取数据
                If Me.m_objsystemFlowObject.getTuihuiDataSet(strErrMsg, MyBase.UserXM, Me.m_strQuery_FSRXX, Me.m_objDataSet_FSRXX) = False Then
                    GoTo errProc
                End If

                '缓存参数
                With Me.m_objDataSet_FSRXX.Tables(strTable)
                    Me.htxtFSRXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_FSRXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_FSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdFSRXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_FSRXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANTUIHUI

            showDataGridInfo_FSRXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtFSRXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtFSRXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_FSRXX Is Nothing Then
                    Me.grdFSRXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_FSRXX.Tables(strTable)
                        Me.grdFSRXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_FSRXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdFSRXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdFSRXX)
                    With Me.grdFSRXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdFSRXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdFSRXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_FSRXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_FSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdFSRXX及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_FSRXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_FSRXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_FSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                Me.lblFSRXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdFSRXX, Me.m_intRows_FSRXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_FSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示整个模块信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_Main(ByRef strErrMsg As String) As Boolean

            showModuleData_Main = False

            Try
                '纸质文件流转提醒
                Dim blnHas As Boolean
                If Me.m_objsystemFlowObject.isReceiveZhizhi(strErrMsg, MyBase.UserXM, blnHas) = False Then
                    GoTo errProc
                End If
                If blnHas = True Then
                    Me.lblZZTS.Text = "[提示]：本文件有纸质文件送来，请注意退回！"
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_Main = True
            Exit Function

errProc:
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

                    '显示Main
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '先显示grdFSRXX
                    If Me.showModuleData_FSRXX(strErrMsg) = False Then
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

                '获取附件数据
                If Me.getModuleData_FSRXX(strErrMsg) = False Then
                    GoTo errProc
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




        '---------------------------------------------------------------------------------------------------------------------------
        '网格事件处理器
        '---------------------------------------------------------------------------------------------------------------------------
        Sub grdFSRXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdFSRXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_FSRXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_FSRXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_FSRXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdFSRXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdFSRXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFSRXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblFSRXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdFSRXX, Me.m_intRows_FSRXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub grdFSRXX_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdFSRXX.PageIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '修改索引
                Me.grdFSRXX.CurrentPageIndex = e.NewPageIndex

                '重新显示
                If Me.getModuleData_FSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_FSRXX(strErrMsg) = False Then
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





        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
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
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
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

        Private Function doRefreshData(ByRef strErrMsg As String) As Boolean

            doRefreshData = False
            strErrMsg = ""

            Try
                '显示数据
                If Me.showModuleData_Main(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_FSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_FSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doRefreshData = True
            Exit Function

errProc:
            Exit Function

        End Function

        Private Sub doRefresh(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doRefreshData(strErrMsg) = False Then
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

        Private Sub doTuihui(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim objHasSendNoticeRY As System.Collections.Specialized.NameValueCollection
            Dim objValues As New System.Collections.Specialized.NameValueCollection
            Dim objDataRow As System.Data.DataRow

            Try
                Dim blnSelected As Boolean
                Dim intSelected As Integer
                Dim intRecPos As Integer
                Dim intCount As Integer
                Dim strValue As String
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '检查选择
                    intCount = Me.grdFSRXX.Items.Count
                    intSelected = 0
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdFSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FSRXX)
                        If blnSelected = True Then
                            intSelected += 1

                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdFSRXX.CurrentPageIndex, Me.grdFSRXX.PageSize)
                            With Me.m_objDataSet_FSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANTUIHUI)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With

                            '获取“交接标识”
                            'strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_JJBS), "")
                            'If Me.m_objsystemFlowObject.isTaskTuihui(strValue) = True Then
                            '    '退回的
                            '    strErrMsg = "错误：第[" + (i + 1).ToString + "]行为退回文件，不能直接退回！"
                            '    GoTo errProc
                            'End If
                            'If Me.m_objsystemFlowObject.isTaskShouhui(strValue) = True Then
                            '    '收回的
                            '    strErrMsg = "错误：第[" + (i + 1).ToString + "]行为收回文件，不能直接退回！"
                            '    GoTo errProc
                            'End If
                            'If Me.m_objsystemFlowObject.isTaskHuifu(strValue) = True Then
                            '    '回复
                            '    strErrMsg = "错误：第[" + (i + 1).ToString + "]行为回复，不能直接退回！"
                            '    GoTo errProc
                            'End If
                            If Me.m_objsystemFlowObject.isTaskTongzhi(strValue) = True Then
                                '通知
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行为通知，不能直接退回！"
                                GoTo errProc
                            End If
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "错误：未选择要退回的文件！"
                        GoTo errProc
                    End If

                    '提示信息
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要退回选定的[" + intSelected.ToString + "]个文件吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '退回处理
                Dim strYBLSY As String = ""
                Dim strFSXH As String = ""
                Dim strYXB As String = ""
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取本批次的发送序号
                    If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                        GoTo errProc
                    End If

                    '逐个退回文件
                    intCount = Me.grdFSRXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdFSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FSRXX)
                        If blnSelected = True Then
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdFSRXX.CurrentPageIndex, Me.grdFSRXX.PageSize)
                            With Me.m_objDataSet_FSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANTUIHUI)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With

                            '准备更新数据(退回用)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_WJBS, Me.m_objInterface.iWJBS)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJBS, "")            '退回时自动填写
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT, "")            '退回时自动填写
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSR, MyBase.UserXM)  '发退回处理单用
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSR), "")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSR, strValue)       '发退回处理单用
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_JJXH), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJXH, strValue)
                            '************************************************************************************************************************************************
                            strValue = Format(Now, "yyyy-MM-dd HH:mm:ss")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSRQ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_WCRQ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSWJZZFS), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSZZWJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSZZWJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSWJDZFS), "1")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSDZWJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSDZWJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSFJZZFS), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSZZFJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSZZFJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSFJDZFS), "1")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSDZFJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSDZFJ, strValue)
                            '************************************************************************************************************************************************

                            '获取发送人自己的办理事宜
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSRBLSY), "")
                            If Me.m_objsystemFlowObject.doTranslateTask(strErrMsg, strValue, strYBLSY) = False Then
                                GoTo errProc
                            End If
                            strYXB = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSRXB), "")

                            '退回当前文件
                            If Me.m_objsystemFlowObject.doTuihuiFile(strErrMsg, strYBLSY, strYXB, strFSXH, objValues, Me.m_objInterface.iCanReadFile, objHasSendNoticeRY) = False Then
                                GoTo errProc
                            End If

                            '清除缓冲区
                            objValues.Clear()
                        End If
                    Next

                    '返回上级
                    '设置返回参数
                    Me.m_objInterface.oExitMode = True
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
                    If strUrl <> "" Then
                        Response.Redirect(strUrl)
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objHasSendNoticeRY)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objValues)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objHasSendNoticeRY)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objValues)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Me.doRefresh("btnRefresh")
        End Sub

        Private Sub btnTuihui_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTuihui.Click
            Me.doTuihui("btnTuihui")
        End Sub

    End Class

End Namespace
