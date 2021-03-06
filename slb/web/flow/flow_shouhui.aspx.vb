Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_shouhui
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理工作流文件的强制收回任务
    '
    ' 接口参数：
    '     参见接口类IFlowShouhui描述
    '----------------------------------------------------------------

    Public Class flow_shouhui
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblJSRXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents lblZZTS As System.Web.UI.WebControls.Label
        Protected WithEvents grdJSRXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents chkSHTZ As System.Web.UI.WebControls.CheckBox
        Protected WithEvents btnShouhui As System.Web.UI.WebControls.Button
        Protected WithEvents btnRefresh As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtJSRXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftJSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopJSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowShouhui
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowShouhui
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_JSRXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_JSRXX As String '记录m_objDataSet_JSRXX搜索串
        Private m_intRows_JSRXX As Integer '记录m_objDataSet_JSRXX的DefaultView记录数

        '----------------------------------------------------------------
        '与数据网格grdJSRXX相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_JSRXX As String = "chkJSRXX"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_JSRXX As String = "divJSRXX"
        '网格要锁定的列数
        Private m_intFixedColumns_JSRXX As Integer

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
                    Me.htxtDivLeftJSRXX.Value = .htxtDivLeftJSRXX
                    Me.htxtDivTopJSRXX.Value = .htxtDivTopJSRXX

                    Me.htxtJSRXXQuery.Value = .htxtJSRXXQuery
                    Me.htxtJSRXXRows.Value = .htxtJSRXXRows
                    Me.htxtJSRXXSort.Value = .htxtJSRXXSort
                    Me.htxtJSRXXSortColumnIndex.Value = .htxtJSRXXSortColumnIndex
                    Me.htxtJSRXXSortType.Value = .htxtJSRXXSortType

                    Me.chkSHTZ.Checked = .chkSHTZ_Selected

                    Try
                        Me.grdJSRXX.PageSize = .grdJSRXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJSRXX.CurrentPageIndex = .grdJSRXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJSRXX.SelectedIndex = .grdJSRXX_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowShouhui

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftJSRXX = Me.htxtDivLeftJSRXX.Value
                    .htxtDivTopJSRXX = Me.htxtDivTopJSRXX.Value

                    .htxtJSRXXQuery = Me.htxtJSRXXQuery.Value
                    .htxtJSRXXRows = Me.htxtJSRXXRows.Value
                    .htxtJSRXXSort = Me.htxtJSRXXSort.Value
                    .htxtJSRXXSortColumnIndex = Me.htxtJSRXXSortColumnIndex.Value
                    .htxtJSRXXSortType = Me.htxtJSRXXSortType.Value

                    .chkSHTZ_Selected = Me.chkSHTZ.Checked

                    .grdJSRXX_PageSize = Me.grdJSRXX.PageSize
                    .grdJSRXX_CurrentPageIndex = Me.grdJSRXX.CurrentPageIndex
                    .grdJSRXX_SelectedIndex = Me.grdJSRXX.SelectedIndex

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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowShouhui)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowShouhui)
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
                Me.m_intFixedColumns_JSRXX = objPulicParameters.getObjectValue(Me.htxtJSRXXFixed.Value, 0)
                Me.m_intRows_JSRXX = objPulicParameters.getObjectValue(Me.htxtJSRXXRows.Value, 0)
                Me.m_strQuery_JSRXX = Me.htxtJSRXXQuery.Value

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
        Private Function getModuleData_JSRXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANSHOUHUI
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_JSRXX = False

            Try
                '释放资源
                If Not (Me.m_objDataSet_JSRXX Is Nothing) Then
                    Me.m_objDataSet_JSRXX.Dispose()
                    Me.m_objDataSet_JSRXX = Nothing
                End If

                If m_strQuery_JSRXX = "" Then
                    m_strQuery_JSRXX = ""

                End If

                '从数据库获取数据
                If Me.m_objsystemFlowObject.getShouhuiDataSet(strErrMsg, MyBase.UserXM, Me.m_strQuery_JSRXX, Me.m_objDataSet_JSRXX) = False Then
                    GoTo errProc
                End If

                '缓存参数
                With Me.m_objDataSet_JSRXX.Tables(strTable)
                    Me.htxtJSRXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_JSRXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_JSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdJSRXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_JSRXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANSHOUHUI

            showDataGridInfo_JSRXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtJSRXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtJSRXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_JSRXX Is Nothing Then
                    Me.grdJSRXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_JSRXX.Tables(strTable)
                        Me.grdJSRXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_JSRXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdJSRXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdJSRXX)
                    With Me.grdJSRXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdJSRXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdJSRXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_JSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdJSRXX及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_JSRXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_JSRXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                Me.lblJSRXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdJSRXX, Me.m_intRows_JSRXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_JSRXX = True
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
                If Me.m_objsystemFlowObject.isSendZhizhi(strErrMsg, MyBase.UserXM, blnHas) = False Then
                    GoTo errProc
                End If
                If blnHas = True Then
                    Me.lblZZTS.Text = "[提示]：本文件您有送出纸质文件，请注意收回！"
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

                    '先显示grdJSRXX
                    If Me.showModuleData_JSRXX(strErrMsg) = False Then
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
                If Me.getModuleData_JSRXX(strErrMsg) = False Then
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
        Sub grdJSRXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdJSRXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_JSRXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_JSRXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_JSRXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdJSRXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdJSRXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdJSRXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblJSRXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdJSRXX, Me.m_intRows_JSRXX) + ")"

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

        Private Sub grdJSRXX_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdJSRXX.PageIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '修改索引
                Me.grdJSRXX.CurrentPageIndex = e.NewPageIndex

                '重新显示
                If Me.getModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_JSRXX(strErrMsg) = False Then
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
                If Me.showModuleData_Main(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_JSRXX(strErrMsg) = False Then
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

        Private Sub doShouhui(ByVal strControlId As String)

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
                    intCount = Me.grdJSRXX.Items.Count
                    intSelected = 0
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdJSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX)
                        If blnSelected = True Then
                            intSelected += 1

                            '************************************************************************************************************************************************
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJSRXX.CurrentPageIndex, Me.grdJSRXX.PageSize)
                            With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANSHOUHUI)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_JSR), "")
                            If Me.m_objsystemFlowObject.isEditFile(strErrMsg, strValue, blnSelected) = False Then
                                GoTo errProc
                            End If
                            If blnSelected = True Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的文件[" + strValue + "]正在编辑文件，不能收回！"
                                GoTo errProc
                            End If
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "错误：未选择要收回的文件！"
                        GoTo errProc
                    End If

                    '提示信息
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要收回选定的[" + intSelected.ToString + "]个文件吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '收回处理
                Dim strFSXH As String = ""
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取本批次的发送序号
                    If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                        GoTo errProc
                    End If

                    '逐个收回文件
                    intCount = Me.grdJSRXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdJSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX)
                        If blnSelected = True Then
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJSRXX.CurrentPageIndex, Me.grdJSRXX.PageSize)
                            With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANSHOUHUI)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With

                            '准备更新数据(退回用)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_WJBS, Me.m_objInterface.iWJBS)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJBS, "")            '收回时自动填写
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT, "")            '收回时自动填写
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_JSR), "")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSR, strValue)       '发收回通知用
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_FSR), "")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSR, strValue)       '发收回通知用
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_JJXH), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJXH, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_YJJH), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_YJJH, strValue)
                            '************************************************************************************************************************************************
                            strValue = Format(Now, "yyyy-MM-dd HH:mm:ss")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSRQ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_WCRQ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_FSWJZZFS), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSZZWJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSZZWJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_FSWJDZFS), "1")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSDZWJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSDZWJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_FSFJZZFS), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSZZFJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSZZFJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_FSFJDZFS), "1")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSDZFJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSDZFJ, strValue)
                            '************************************************************************************************************************************************

                            '收回当前文件
                            If Me.m_objsystemFlowObject.doShouhuiFile(strErrMsg, strFSXH, objValues, Me.chkSHTZ.Checked, objHasSendNoticeRY) = False Then
                                GoTo errProc
                            End If

                            '清除缓冲区
                            objValues.Clear()
                        End If
                    Next

                    '刷新数据
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '是否全部退回？
                    With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANSHOUHUI)
                        If .Rows.Count < 1 Then
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
                        Else
                            '继续处理
                        End If
                    End With
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

        Private Sub btnShouhui_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShouhui.Click
            Me.doShouhui("btnShouhui")
        End Sub

    End Class

End Namespace
