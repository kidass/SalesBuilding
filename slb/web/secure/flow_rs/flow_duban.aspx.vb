Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_duban
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理工作流文件的督办任务
    '
    ' 接口参数：
    '     参见接口类IFlowDuban描述
    '----------------------------------------------------------------

    Public Class flow_duban
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblKDBXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdKDBXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblYDBXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdYDBXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnOK As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtKDBXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSessionIdKDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKDBXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKDBXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKDBXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKDBXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKDBXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftKDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopKDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftYDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopYDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowDuban
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowDuban
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_KDBXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_KDBXX As String '记录m_objDataSet_KDBXX搜索串
        Private m_intRows_KDBXX As Integer '记录m_objDataSet_KDBXX的DefaultView记录数
        Private m_objDataSet_YDBXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_YDBXX As String '记录m_objDataSet_YDBXX搜索串
        Private m_intRows_YDBXX As Integer '记录m_objDataSet_YDBXX的DefaultView记录数

        '----------------------------------------------------------------
        '与数据网格grdKDBXX相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrControlId_KDBXX_txtDBRQ As String = "txtDBRQ"
        Private Const m_cstrControlId_KDBXX_txtDBYQ As String = "txtDBYQ"
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_KDBXX As String = "chkKDBXX"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_KDBXX As String = "divKDBXX"
        '网格要锁定的列数
        Private m_intFixedColumns_KDBXX As Integer

        '----------------------------------------------------------------
        '与数据网格grdYDBXX相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_YDBXX As String = "chkYDBXX"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_YDBXX As String = "divYDBXX"
        '网格要锁定的列数
        Private m_intFixedColumns_YDBXX As Integer

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
                    Me.htxtDivLeftKDBXX.Value = .htxtDivLeftKDBXX
                    Me.htxtDivTopKDBXX.Value = .htxtDivTopKDBXX
                    Me.htxtDivLeftYDBXX.Value = .htxtDivLeftYDBXX
                    Me.htxtDivTopYDBXX.Value = .htxtDivTopYDBXX

                    Me.htxtKDBXXQuery.Value = .htxtKDBXXQuery
                    Me.htxtKDBXXRows.Value = .htxtKDBXXRows
                    Me.htxtKDBXXSort.Value = .htxtKDBXXSort
                    Me.htxtKDBXXSortColumnIndex.Value = .htxtKDBXXSortColumnIndex
                    Me.htxtKDBXXSortType.Value = .htxtKDBXXSortType

                    Me.htxtYDBXXQuery.Value = .htxtYDBXXQuery
                    Me.htxtYDBXXRows.Value = .htxtYDBXXRows
                    Me.htxtYDBXXSort.Value = .htxtYDBXXSort
                    Me.htxtYDBXXSortColumnIndex.Value = .htxtYDBXXSortColumnIndex
                    Me.htxtYDBXXSortType.Value = .htxtYDBXXSortType

                    Me.htxtSessionIdKDBXX.Value = .htxtSessionIdKDBXX
                    Try
                        Me.grdKDBXX.PageSize = .grdKDBXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdKDBXX.CurrentPageIndex = .grdKDBXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdKDBXX.SelectedIndex = .grdKDBXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdYDBXX.PageSize = .grdYDBXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYDBXX.CurrentPageIndex = .grdYDBXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYDBXX.SelectedIndex = .grdYDBXX_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowDuban

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftKDBXX = Me.htxtDivLeftKDBXX.Value
                    .htxtDivTopKDBXX = Me.htxtDivTopKDBXX.Value
                    .htxtDivLeftYDBXX = Me.htxtDivLeftYDBXX.Value
                    .htxtDivTopYDBXX = Me.htxtDivTopYDBXX.Value

                    .htxtKDBXXQuery = Me.htxtKDBXXQuery.Value
                    .htxtKDBXXRows = Me.htxtKDBXXRows.Value
                    .htxtKDBXXSort = Me.htxtKDBXXSort.Value
                    .htxtKDBXXSortColumnIndex = Me.htxtKDBXXSortColumnIndex.Value
                    .htxtKDBXXSortType = Me.htxtKDBXXSortType.Value

                    .htxtYDBXXQuery = Me.htxtYDBXXQuery.Value
                    .htxtYDBXXRows = Me.htxtYDBXXRows.Value
                    .htxtYDBXXSort = Me.htxtYDBXXSort.Value
                    .htxtYDBXXSortColumnIndex = Me.htxtYDBXXSortColumnIndex.Value
                    .htxtYDBXXSortType = Me.htxtYDBXXSortType.Value

                    .htxtSessionIdKDBXX = Me.htxtSessionIdKDBXX.Value
                    .grdKDBXX_PageSize = Me.grdKDBXX.PageSize
                    .grdKDBXX_CurrentPageIndex = Me.grdKDBXX.CurrentPageIndex
                    .grdKDBXX_SelectedIndex = Me.grdKDBXX.SelectedIndex

                    .grdYDBXX_PageSize = Me.grdYDBXX.PageSize
                    .grdYDBXX_CurrentPageIndex = Me.grdYDBXX.CurrentPageIndex
                    .grdYDBXX_SelectedIndex = Me.grdYDBXX.SelectedIndex

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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowDuban)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowDuban)
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
                Me.m_intFixedColumns_KDBXX = objPulicParameters.getObjectValue(Me.htxtKDBXXFixed.Value, 0)
                Me.m_intRows_KDBXX = objPulicParameters.getObjectValue(Me.htxtKDBXXRows.Value, 0)
                Me.m_strQuery_KDBXX = Me.htxtKDBXXQuery.Value

                Me.m_intFixedColumns_YDBXX = objPulicParameters.getObjectValue(Me.htxtYDBXXFixed.Value, 0)
                Me.m_intRows_YDBXX = objPulicParameters.getObjectValue(Me.htxtYDBXXRows.Value, 0)
                Me.m_strQuery_YDBXX = Me.htxtYDBXXQuery.Value

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
                If Me.htxtSessionIdKDBXX.Value.Trim <> "" Then
                    Dim objFlowData As Josco.JSOA.Common.Data.FlowData
                    Try
                        objFlowData = CType(Session(Me.htxtSessionIdKDBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        objFlowData = Nothing
                    End Try
                    If Not (objFlowData Is Nothing) Then
                        objFlowData.Dispose()
                        objFlowData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdKDBXX.Value)
                    Me.htxtSessionIdKDBXX.Value = ""
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
        ' 获取可督办信息数据集
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_KDBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_KDBXX = False

            Try
                '从缓存获取数据
                If Me.htxtSessionIdKDBXX.Value.Trim <> "" Then
                    Try
                        Me.m_objDataSet_KDBXX = CType(Session(Me.htxtSessionIdKDBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        Me.m_objDataSet_KDBXX = Nothing
                    End Try
                End If

                '创建缺省数据
                If Me.m_objDataSet_KDBXX Is Nothing Then
                    If Me.m_objsystemFlowObject.getKeDubanData(strErrMsg, Me.m_objInterface.iBLR, Me.m_objDataSet_KDBXX) = False Then
                        GoTo errProc
                    End If
                End If

                '缓存数据集
                If Me.htxtSessionIdKDBXX.Value.Trim <> "" Then
                    Session.Remove(Me.htxtSessionIdKDBXX.Value)
                Else
                    Me.htxtSessionIdKDBXX.Value = objPulicParameters.getNewGuid()
                End If
                Session.Add(Me.htxtSessionIdKDBXX.Value, Me.m_objDataSet_KDBXX)

                '缓存参数
                With Me.m_objDataSet_KDBXX.Tables(strTable)
                    Me.htxtKDBXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_KDBXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_KDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取已督办信息数据集
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_YDBXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            getModuleData_YDBXX = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtYDBXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objDataSet_YDBXX Is Nothing) Then
                    Me.m_objDataSet_YDBXX.Dispose()
                    Me.m_objDataSet_YDBXX = Nothing
                End If

                '重新检索数据
                If Me.m_objsystemFlowObject.getDubanData(strErrMsg, Me.m_objInterface.iBLR, Me.m_objDataSet_YDBXX) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_YDBXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_YDBXX.Tables(strTable)
                    Me.htxtYDBXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_YDBXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_YDBXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdKDBXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_KDBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            showDataGridInfo_KDBXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtKDBXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtKDBXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_KDBXX Is Nothing Then
                    Me.grdKDBXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_KDBXX.Tables(strTable)
                        Me.grdKDBXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_KDBXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdKDBXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdKDBXX)
                    With Me.grdKDBXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdKDBXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdKDBXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_KDBXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_KDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYDBXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_YDBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            showDataGridInfo_YDBXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtYDBXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtYDBXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_YDBXX Is Nothing Then
                    Me.grdYDBXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YDBXX.Tables(strTable)
                        Me.grdYDBXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_YDBXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYDBXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdYDBXX)
                    With Me.grdYDBXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdYDBXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYDBXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_YDBXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_YDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存grdKDBXX未绑定的数据
        '     strErrMsg      ：返回错误信息
        '     blnVerify      ：需要校验数据
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveModuleDataUnbound_KDBXX( _
            ByRef strErrMsg As String, _
            ByVal blnVerify As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveModuleDataUnbound_KDBXX = False
            strErrMsg = ""

            Try
                '保存未绑定数据
                Dim txtDBYQ As System.Web.UI.WebControls.TextBox
                Dim txtDBRQ As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdKDBXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKDBXX.CurrentPageIndex, Me.grdKDBXX.PageSize)
                    objDataRow = Me.m_objDataSet_KDBXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存[督办日期]txtDBRQ
                    txtDBRQ = CType(Me.grdKDBXX.Items(i).FindControl(Me.m_cstrControlId_KDBXX_txtDBRQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtDBRQ Is Nothing) Then
                        If txtDBRQ.Text.Trim <> "" Then
                            If objPulicParameters.isDatetimeString(txtDBRQ.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[督办日期]是无效日期！"
                                    GoTo errProc
                                Else
                                    txtDBRQ.Text = ""
                                End If
                            End If
                        End If
                        If txtDBRQ.Text = "" Then
                            txtDBRQ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBRQ) = CType(txtDBRQ.Text, System.DateTime)
                    End If

                    '保存[督办要求]txtDBYQ
                    txtDBYQ = CType(Me.grdKDBXX.Items(i).FindControl(Me.m_cstrControlId_KDBXX_txtDBYQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtDBYQ Is Nothing) Then
                        If txtDBYQ.Text = "" Then
                            txtDBYQ.Text = "请尽快办理！"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBYQ) = txtDBYQ.Text
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveModuleDataUnbound_KDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdKDBXX未绑定的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleDataUnbound_KDBXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleDataUnbound_KDBXX = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim txtDBYQ As System.Web.UI.WebControls.TextBox
                Dim txtDBRQ As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdKDBXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKDBXX.CurrentPageIndex, Me.grdKDBXX.PageSize)
                    objDataRow = Me.m_objDataSet_KDBXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充[督办日期]txtDBRQ
                    txtDBRQ = CType(Me.grdKDBXX.Items(i).FindControl(Me.m_cstrControlId_KDBXX_txtDBRQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtDBRQ Is Nothing) Then
                        objControlProcess.doTranslateKey(txtDBRQ)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBRQ), "")
                        If strValue = "" Then
                            txtDBRQ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                        Else
                            txtDBRQ.Text = Format(CType(strValue, System.DateTime), "yyyy-MM-dd HH:mm:ss")
                        End If
                    End If

                    '填充[督办要求]txtDBYQ
                    txtDBYQ = CType(Me.grdKDBXX.Items(i).FindControl(Me.m_cstrControlId_KDBXX_txtDBYQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtDBYQ Is Nothing) Then
                        objControlProcess.doTranslateKey(txtDBYQ)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBYQ), "")
                        If strValue = "" Then
                            txtDBYQ.Text = "请尽快办理！"
                        Else
                            txtDBYQ.Text = strValue
                        End If
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleDataUnbound_KDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdKDBXX及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_KDBXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_KDBXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_KDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示未绑定数据
                If Me.showModuleDataUnbound_KDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                Me.lblKDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdKDBXX, Me.m_intRows_KDBXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_KDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYDBXX及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_YDBXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_YDBXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_YDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                Me.lblYDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdYDBXX, Me.m_intRows_YDBXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_YDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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

                    '先显示grdKDBXX
                    If Me.showModuleData_KDBXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '获取数据
                    If Me.getModuleData_YDBXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_YDBXX(strErrMsg) = False Then
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
                If Me.getModuleData_KDBXX(strErrMsg) = False Then
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
        Sub grdKDBXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdKDBXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_KDBXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_KDBXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_KDBXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdKDBXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdKDBXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdKDBXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblKDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdKDBXX, Me.m_intRows_KDBXX) + ")"

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

        Private Sub grdKDBXX_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdKDBXX.PageIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '保存未绑定数据
                If Me.saveModuleDataUnbound_KDBXX(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                '修改索引
                Me.grdKDBXX.CurrentPageIndex = e.NewPageIndex

                '重新显示
                If Me.getModuleData_KDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_KDBXX(strErrMsg) = False Then
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

        Sub grdYDBXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYDBXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_YDBXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_YDBXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_YDBXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYDBXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdYDBXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdYDBXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblYDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdYDBXX, Me.m_intRows_YDBXX) + ")"
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objNewData As New System.Collections.Specialized.NameValueCollection
            Dim objDataRow As System.Data.DataRow
            Dim intStep As Integer

            Try
                '询问
                Dim strUserList As String = ""
                Dim blnSelected As Boolean
                Dim intSelected As Integer
                Dim intRecPos As Integer
                Dim intCount As Integer
                Dim strValue As String
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '保存输入数据(校验)
                    If Me.saveModuleDataUnbound_KDBXX(strErrMsg, True) = False Then
                        GoTo errProc
                    End If

                    '检查选择
                    intCount = Me.grdKDBXX.Items.Count
                    intSelected = 0
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdKDBXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_KDBXX)
                        If blnSelected = True Then
                            '计数
                            intSelected += 1
                            '获取数据记录
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKDBXX.CurrentPageIndex, Me.grdKDBXX.PageSize)
                            With Me.m_objDataSet_KDBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With
                            '获取被督办人
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_BDBR), "")
                            If strUserList = "" Then
                                strUserList = strValue
                            Else
                                strUserList = strUserList + objPulicParameters.CharSeparate + strValue
                            End If
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "错误：未选择要督办的人员！"
                        GoTo errProc
                    End If

                    '询问
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定向[" + strUserList + "]发出督办通知吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                Dim strField As String
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '逐个督办
                    intCount = Me.grdKDBXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdKDBXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_KDBXX)
                        If blnSelected = True Then
                            '获取数据记录
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKDBXX.CurrentPageIndex, Me.grdKDBXX.PageSize)
                            With Me.m_objDataSet_KDBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With
                            '准备数据
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_WJBS
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_JJXH
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), "0"))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBXH
                            objNewData.Add(strField, "") '自动创建
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBR
                            objNewData.Add(strField, Me.m_objInterface.iBLR)
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBRQ
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_BDBR
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBYQ
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBJG
                            objNewData.Add(strField, "") '缺省空
                            '发送通知
                            If Me.m_objsystemFlowObject.doSaveDuban(strErrMsg, Nothing, objNewData) = False Then
                                GoTo errProc
                            End If
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
                    Response.Redirect(strUrl)

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

    End Class

End Namespace
