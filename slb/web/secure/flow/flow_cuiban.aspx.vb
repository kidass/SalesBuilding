Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_cuiban
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理工作流文件的催办任务
    '
    ' 接口参数：
    '     参见接口类IFlowCuiban描述
    '----------------------------------------------------------------

    Public Class flow_cuiban
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblKCBXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdKCBXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblYCBXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdYCBXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnOK As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtKCBXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSessionIdKCBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKCBXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKCBXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKCBXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKCBXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKCBXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftKCBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopKCBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftYCBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopYCBXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowCuiban
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowCuiban
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_KCBXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_KCBXX As String '记录m_objDataSet_KCBXX搜索串
        Private m_intRows_KCBXX As Integer '记录m_objDataSet_KCBXX的DefaultView记录数
        Private m_objDataSet_YCBXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_YCBXX As String '记录m_objDataSet_YCBXX搜索串
        Private m_intRows_YCBXX As Integer '记录m_objDataSet_YCBXX的DefaultView记录数

        '----------------------------------------------------------------
        '与数据网格grdKCBXX相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrControlId_KCBXX_txtCBRQ As String = "txtCBRQ"
        Private Const m_cstrControlId_KCBXX_txtCBSM As String = "txtCBSM"
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_KCBXX As String = "chkKCBXX"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_KCBXX As String = "divKCBXX"
        '网格要锁定的列数
        Private m_intFixedColumns_KCBXX As Integer

        '----------------------------------------------------------------
        '与数据网格grdYCBXX相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_YCBXX As String = "chkYCBXX"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_YCBXX As String = "divYCBXX"
        '网格要锁定的列数
        Private m_intFixedColumns_YCBXX As Integer

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
                    Me.htxtDivLeftKCBXX.Value = .htxtDivLeftKCBXX
                    Me.htxtDivTopKCBXX.Value = .htxtDivTopKCBXX
                    Me.htxtDivLeftYCBXX.Value = .htxtDivLeftYCBXX
                    Me.htxtDivTopYCBXX.Value = .htxtDivTopYCBXX

                    Me.htxtKCBXXQuery.Value = .htxtKCBXXQuery
                    Me.htxtKCBXXRows.Value = .htxtKCBXXRows
                    Me.htxtKCBXXSort.Value = .htxtKCBXXSort
                    Me.htxtKCBXXSortColumnIndex.Value = .htxtKCBXXSortColumnIndex
                    Me.htxtKCBXXSortType.Value = .htxtKCBXXSortType

                    Me.htxtYCBXXQuery.Value = .htxtYCBXXQuery
                    Me.htxtYCBXXRows.Value = .htxtYCBXXRows
                    Me.htxtYCBXXSort.Value = .htxtYCBXXSort
                    Me.htxtYCBXXSortColumnIndex.Value = .htxtYCBXXSortColumnIndex
                    Me.htxtYCBXXSortType.Value = .htxtYCBXXSortType

                    Me.htxtSessionIdKCBXX.Value = .htxtSessionIdKCBXX
                    Try
                        Me.grdKCBXX.PageSize = .grdKCBXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdKCBXX.CurrentPageIndex = .grdKCBXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdKCBXX.SelectedIndex = .grdKCBXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdYCBXX.PageSize = .grdYCBXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYCBXX.CurrentPageIndex = .grdYCBXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYCBXX.SelectedIndex = .grdYCBXX_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowCuiban

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftKCBXX = Me.htxtDivLeftKCBXX.Value
                    .htxtDivTopKCBXX = Me.htxtDivTopKCBXX.Value
                    .htxtDivLeftYCBXX = Me.htxtDivLeftYCBXX.Value
                    .htxtDivTopYCBXX = Me.htxtDivTopYCBXX.Value

                    .htxtKCBXXQuery = Me.htxtKCBXXQuery.Value
                    .htxtKCBXXRows = Me.htxtKCBXXRows.Value
                    .htxtKCBXXSort = Me.htxtKCBXXSort.Value
                    .htxtKCBXXSortColumnIndex = Me.htxtKCBXXSortColumnIndex.Value
                    .htxtKCBXXSortType = Me.htxtKCBXXSortType.Value

                    .htxtYCBXXQuery = Me.htxtYCBXXQuery.Value
                    .htxtYCBXXRows = Me.htxtYCBXXRows.Value
                    .htxtYCBXXSort = Me.htxtYCBXXSort.Value
                    .htxtYCBXXSortColumnIndex = Me.htxtYCBXXSortColumnIndex.Value
                    .htxtYCBXXSortType = Me.htxtYCBXXSortType.Value

                    .htxtSessionIdKCBXX = Me.htxtSessionIdKCBXX.Value
                    .grdKCBXX_PageSize = Me.grdKCBXX.PageSize
                    .grdKCBXX_CurrentPageIndex = Me.grdKCBXX.CurrentPageIndex
                    .grdKCBXX_SelectedIndex = Me.grdKCBXX.SelectedIndex

                    .grdYCBXX_PageSize = Me.grdYCBXX.PageSize
                    .grdYCBXX_CurrentPageIndex = Me.grdYCBXX.CurrentPageIndex
                    .grdYCBXX_SelectedIndex = Me.grdYCBXX.SelectedIndex

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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowCuiban)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowCuiban)
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
                Me.m_intFixedColumns_KCBXX = objPulicParameters.getObjectValue(Me.htxtKCBXXFixed.Value, 0)
                Me.m_intRows_KCBXX = objPulicParameters.getObjectValue(Me.htxtKCBXXRows.Value, 0)
                Me.m_strQuery_KCBXX = Me.htxtKCBXXQuery.Value

                Me.m_intFixedColumns_YCBXX = objPulicParameters.getObjectValue(Me.htxtYCBXXFixed.Value, 0)
                Me.m_intRows_YCBXX = objPulicParameters.getObjectValue(Me.htxtYCBXXRows.Value, 0)
                Me.m_strQuery_YCBXX = Me.htxtYCBXXQuery.Value

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
                If Me.htxtSessionIdKCBXX.Value.Trim <> "" Then
                    Dim objFlowData As Josco.JSOA.Common.Data.FlowData
                    Try
                        objFlowData = CType(Session(Me.htxtSessionIdKCBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        objFlowData = Nothing
                    End Try
                    If Not (objFlowData Is Nothing) Then
                        objFlowData.Dispose()
                        objFlowData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdKCBXX.Value)
                    Me.htxtSessionIdKCBXX.Value = ""
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
        ' 获取可催办信息数据集
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_KCBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_KCBXX = False

            Try
                '从缓存获取数据
                If Me.htxtSessionIdKCBXX.Value.Trim <> "" Then
                    Try
                        Me.m_objDataSet_KCBXX = CType(Session(Me.htxtSessionIdKCBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        Me.m_objDataSet_KCBXX = Nothing
                    End Try
                End If

                '创建缺省数据
                If Me.m_objDataSet_KCBXX Is Nothing Then
                    If Me.m_objsystemFlowObject.getKeCuibanData(strErrMsg, Me.m_objInterface.iBLR, Me.m_objDataSet_KCBXX) = False Then
                        GoTo errProc
                    End If
                End If

                '缓存数据集
                If Me.htxtSessionIdKCBXX.Value.Trim <> "" Then
                    Session.Remove(Me.htxtSessionIdKCBXX.Value)
                Else
                    Me.htxtSessionIdKCBXX.Value = objPulicParameters.getNewGuid()
                End If
                Session.Add(Me.htxtSessionIdKCBXX.Value, Me.m_objDataSet_KCBXX)

                '缓存参数
                With Me.m_objDataSet_KCBXX.Tables(strTable)
                    Me.htxtKCBXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_KCBXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_KCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取已催办信息数据集
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_YCBXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE

            getModuleData_YCBXX = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtYCBXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objDataSet_YCBXX Is Nothing) Then
                    Me.m_objDataSet_YCBXX.Dispose()
                    Me.m_objDataSet_YCBXX = Nothing
                End If

                '重新检索数据
                If Me.m_objsystemFlowObject.getCuibanData(strErrMsg, Me.m_objInterface.iBLR, Me.m_objDataSet_YCBXX) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_YCBXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_YCBXX.Tables(strTable)
                    Me.htxtYCBXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_YCBXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_YCBXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdKCBXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_KCBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE

            showDataGridInfo_KCBXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtKCBXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtKCBXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_KCBXX Is Nothing Then
                    Me.grdKCBXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_KCBXX.Tables(strTable)
                        Me.grdKCBXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_KCBXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdKCBXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdKCBXX)
                    With Me.grdKCBXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdKCBXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdKCBXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_KCBXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_KCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYCBXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_YCBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE

            showDataGridInfo_YCBXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtYCBXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtYCBXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_YCBXX Is Nothing Then
                    Me.grdYCBXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YCBXX.Tables(strTable)
                        Me.grdYCBXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_YCBXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYCBXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdYCBXX)
                    With Me.grdYCBXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdYCBXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYCBXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_YCBXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_YCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存grdKCBXX未绑定的数据
        '     strErrMsg      ：返回错误信息
        '     blnVerify      ：需要校验数据
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveModuleDataUnbound_KCBXX( _
            ByRef strErrMsg As String, _
            ByVal blnVerify As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveModuleDataUnbound_KCBXX = False
            strErrMsg = ""

            Try
                '保存未绑定数据
                Dim txtCBSM As System.Web.UI.WebControls.TextBox
                Dim txtCBRQ As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdKCBXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKCBXX.CurrentPageIndex, Me.grdKCBXX.PageSize)
                    objDataRow = Me.m_objDataSet_KCBXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存[催办日期]txtCBRQ
                    txtCBRQ = CType(Me.grdKCBXX.Items(i).FindControl(Me.m_cstrControlId_KCBXX_txtCBRQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtCBRQ Is Nothing) Then
                        If txtCBRQ.Text.Trim <> "" Then
                            If objPulicParameters.isDatetimeString(txtCBRQ.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[催办日期]是无效日期！"
                                    GoTo errProc
                                Else
                                    txtCBRQ.Text = ""
                                End If
                            End If
                        End If
                        If txtCBRQ.Text = "" Then
                            txtCBRQ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBRQ) = CType(txtCBRQ.Text, System.DateTime)
                    End If

                    '保存[催办说明]txtCBSM
                    txtCBSM = CType(Me.grdKCBXX.Items(i).FindControl(Me.m_cstrControlId_KCBXX_txtCBSM), System.Web.UI.WebControls.TextBox)
                    If Not (txtCBSM Is Nothing) Then
                        If txtCBSM.Text = "" Then
                            txtCBSM.Text = "请尽快办理！"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBSM) = txtCBSM.Text
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveModuleDataUnbound_KCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdKCBXX未绑定的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleDataUnbound_KCBXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleDataUnbound_KCBXX = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim txtCBSM As System.Web.UI.WebControls.TextBox
                Dim txtCBRQ As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdKCBXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKCBXX.CurrentPageIndex, Me.grdKCBXX.PageSize)
                    objDataRow = Me.m_objDataSet_KCBXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充[催办日期]txtCBRQ
                    txtCBRQ = CType(Me.grdKCBXX.Items(i).FindControl(Me.m_cstrControlId_KCBXX_txtCBRQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtCBRQ Is Nothing) Then
                        objControlProcess.doTranslateKey(txtCBRQ)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBRQ), "")
                        If strValue = "" Then
                            txtCBRQ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                        Else
                            txtCBRQ.Text = Format(CType(strValue, System.DateTime), "yyyy-MM-dd HH:mm:ss")
                        End If
                    End If

                    '填充[催办说明]txtCBSM
                    txtCBSM = CType(Me.grdKCBXX.Items(i).FindControl(Me.m_cstrControlId_KCBXX_txtCBSM), System.Web.UI.WebControls.TextBox)
                    If Not (txtCBSM Is Nothing) Then
                        objControlProcess.doTranslateKey(txtCBSM)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBSM), "")
                        If strValue = "" Then
                            txtCBSM.Text = "请尽快办理！"
                        Else
                            txtCBSM.Text = strValue
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

            showModuleDataUnbound_KCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdKCBXX及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_KCBXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_KCBXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_KCBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示未绑定数据
                If Me.showModuleDataUnbound_KCBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                Me.lblKCBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdKCBXX, Me.m_intRows_KCBXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_KCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYCBXX及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_YCBXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_YCBXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_YCBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                Me.lblYCBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdYCBXX, Me.m_intRows_YCBXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_YCBXX = True
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

                    '先显示grdKCBXX
                    If Me.showModuleData_KCBXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '获取数据
                    If Me.getModuleData_YCBXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_YCBXX(strErrMsg) = False Then
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
                If Me.getModuleData_KCBXX(strErrMsg) = False Then
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
        Sub grdKCBXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdKCBXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_KCBXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_KCBXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_KCBXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdKCBXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdKCBXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdKCBXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblKCBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdKCBXX, Me.m_intRows_KCBXX) + ")"

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

        Private Sub grdKCBXX_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdKCBXX.PageIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '保存未绑定数据
                If Me.saveModuleDataUnbound_KCBXX(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                '修改索引
                Me.grdKCBXX.CurrentPageIndex = e.NewPageIndex

                '重新显示
                If Me.getModuleData_KCBXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_KCBXX(strErrMsg) = False Then
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

        Sub grdYCBXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYCBXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_YCBXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_YCBXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_YCBXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYCBXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdYCBXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdYCBXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblYCBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdYCBXX, Me.m_intRows_YCBXX) + ")"
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
                    If Me.saveModuleDataUnbound_KCBXX(strErrMsg, True) = False Then
                        GoTo errProc
                    End If

                    '检查选择
                    intCount = Me.grdKCBXX.Items.Count
                    intSelected = 0
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdKCBXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_KCBXX)
                        If blnSelected = True Then
                            '计数
                            intSelected += 1
                            '获取数据记录
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKCBXX.CurrentPageIndex, Me.grdKCBXX.PageSize)
                            With Me.m_objDataSet_KCBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With
                            '获取被催办人
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_BCBR), "")
                            If strUserList = "" Then
                                strUserList = strValue
                            Else
                                strUserList = strUserList + objPulicParameters.CharSeparate + strValue
                            End If
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "错误：未选择要催办的人员！"
                        GoTo errProc
                    End If

                    '询问
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定向[" + strUserList + "]发出催办通知吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                Dim strField As String
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '逐个催办
                    intCount = Me.grdKCBXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdKCBXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_KCBXX)
                        If blnSelected = True Then
                            '获取数据记录
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKCBXX.CurrentPageIndex, Me.grdKCBXX.PageSize)
                            With Me.m_objDataSet_KCBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With
                            '准备数据
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_WJBS
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_JJXH
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), "0"))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBXH
                            objNewData.Add(strField, "") '自动创建
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBR
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBRQ
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_BCBR
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBSM
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            '发送通知
                            If Me.m_objsystemFlowObject.doSaveCuiban(strErrMsg, Nothing, objNewData) = False Then
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
