Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_dubanjg
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理工作流文件的登记督办结果任务
    '
    ' 接口参数：
    '     参见接口类IFlowDubanjg描述
    '----------------------------------------------------------------

    Public Class flow_dubanjg
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblBDBXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdBDBXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnOK As System.Web.UI.WebControls.Button
        Protected WithEvents btnSave As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtBDBXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents textareaQBJG As System.Web.UI.HtmlControls.HtmlTextArea
        Protected WithEvents textareaBCJG As System.Web.UI.HtmlControls.HtmlTextArea
        Protected WithEvents htxtSessionIdBDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBDBXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBDBXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBDBXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBDBXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBDBXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowDubanjg
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowDubanjg
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_BDBXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_BDBXX As String '记录m_objDataSet_BDBXX搜索串
        Private m_intRows_BDBXX As Integer '记录m_objDataSet_BDBXX的DefaultView记录数

        '----------------------------------------------------------------
        '与数据网格grdBDBXX相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_BDBXX As String = "chkBDBXX"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_BDBXX As String = "divBDBXX"
        '网格要锁定的列数
        Private m_intFixedColumns_BDBXX As Integer

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
                    Me.htxtDivLeftBDBXX.Value = .htxtDivLeftBDBXX
                    Me.htxtDivTopBDBXX.Value = .htxtDivTopBDBXX

                    Me.htxtBDBXXQuery.Value = .htxtBDBXXQuery
                    Me.htxtBDBXXRows.Value = .htxtBDBXXRows
                    Me.htxtBDBXXSort.Value = .htxtBDBXXSort
                    Me.htxtBDBXXSortColumnIndex.Value = .htxtBDBXXSortColumnIndex
                    Me.htxtBDBXXSortType.Value = .htxtBDBXXSortType

                    Me.htxtSessionIdBDBXX.Value = .htxtSessionIdBDBXX
                    Try
                        Me.grdBDBXX.PageSize = .grdBDBXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBDBXX.CurrentPageIndex = .grdBDBXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBDBXX.SelectedIndex = .grdBDBXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.textareaQBJG.InnerText = .textareaQBJG
                    Me.textareaBCJG.InnerText = .textareaBCJG

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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowDubanjg

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftBDBXX = Me.htxtDivLeftBDBXX.Value
                    .htxtDivTopBDBXX = Me.htxtDivTopBDBXX.Value

                    .htxtBDBXXQuery = Me.htxtBDBXXQuery.Value
                    .htxtBDBXXRows = Me.htxtBDBXXRows.Value
                    .htxtBDBXXSort = Me.htxtBDBXXSort.Value
                    .htxtBDBXXSortColumnIndex = Me.htxtBDBXXSortColumnIndex.Value
                    .htxtBDBXXSortType = Me.htxtBDBXXSortType.Value

                    .htxtSessionIdBDBXX = Me.htxtSessionIdBDBXX.Value
                    .grdBDBXX_PageSize = Me.grdBDBXX.PageSize
                    .grdBDBXX_CurrentPageIndex = Me.grdBDBXX.CurrentPageIndex
                    .grdBDBXX_SelectedIndex = Me.grdBDBXX.SelectedIndex

                    .textareaBCJG = Me.textareaBCJG.InnerText
                    .textareaQBJG = Me.textareaQBJG.InnerText

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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowDubanjg)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowDubanjg)
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
                Me.m_intFixedColumns_BDBXX = objPulicParameters.getObjectValue(Me.htxtBDBXXFixed.Value, 0)
                Me.m_intRows_BDBXX = objPulicParameters.getObjectValue(Me.htxtBDBXXRows.Value, 0)
                Me.m_strQuery_BDBXX = Me.htxtBDBXXQuery.Value

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
                If Me.htxtSessionIdBDBXX.Value.Trim <> "" Then
                    Dim objFlowData As Josco.JSOA.Common.Data.FlowData
                    Try
                        objFlowData = CType(Session(Me.htxtSessionIdBDBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        objFlowData = Nothing
                    End Try
                    If Not (objFlowData Is Nothing) Then
                        objFlowData.Dispose()
                        objFlowData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdBDBXX.Value)
                    Me.htxtSessionIdBDBXX.Value = ""
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
        Private Function getModuleData_BDBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_BDBXX = False

            Try
                '从缓存获取数据
                If Me.htxtSessionIdBDBXX.Value.Trim <> "" Then
                    Try
                        Me.m_objDataSet_BDBXX = CType(Session(Me.htxtSessionIdBDBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        Me.m_objDataSet_BDBXX = Nothing
                    End Try
                End If

                '创建缺省数据
                If Me.m_objDataSet_BDBXX Is Nothing Then
                    If Me.m_objsystemFlowObject.getBeidubanData(strErrMsg, Me.m_objInterface.iBLR, Me.m_objDataSet_BDBXX) = False Then
                        GoTo errProc
                    End If
                End If

                '缓存数据集
                If Me.htxtSessionIdBDBXX.Value.Trim <> "" Then
                    Session.Remove(Me.htxtSessionIdBDBXX.Value)
                Else
                    Me.htxtSessionIdBDBXX.Value = objPulicParameters.getNewGuid()
                End If
                Session.Add(Me.htxtSessionIdBDBXX.Value, Me.m_objDataSet_BDBXX)

                '缓存参数
                With Me.m_objDataSet_BDBXX.Tables(strTable)
                    Me.htxtBDBXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_BDBXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_BDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdBDBXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_BDBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            showDataGridInfo_BDBXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtBDBXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtBDBXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_BDBXX Is Nothing Then
                    Me.grdBDBXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_BDBXX.Tables(strTable)
                        Me.grdBDBXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_BDBXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdBDBXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdBDBXX)
                    With Me.grdBDBXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdBDBXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdBDBXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_BDBXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_BDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Function showModuleData_Edit(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_Edit = False
            strErrMsg = ""

            Try
                '初始化
                Me.textareaQBJG.InnerText = ""

                '检查
                If Me.grdBDBXX.Items.Count < 1 Then
                    Exit Try
                End If
                If Me.grdBDBXX.SelectedIndex < 0 Then
                    Exit Try
                End If

                '显示
                Dim strQBJG As String = ""
                Dim strBCJG As String = ""
                Dim strYYJG As String = ""
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                With Me.m_objDataSet_BDBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE)
                    intRecPos = objDataGridProcess.getRecordPosition(Me.grdBDBXX.SelectedIndex, Me.grdBDBXX.CurrentPageIndex, Me.grdBDBXX.PageSize)
                    objDataRow = .DefaultView.Item(intRecPos).Row
                End With
                strYYJG = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBJG), "")
                strBCJG = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_JIAOJIE_BCJG), "")
                If strYYJG <> "" Then
                    strQBJG = strYYJG
                End If
                If strBCJG <> "" Then
                    If strQBJG <> "" Then
                        strQBJG = strQBJG + vbCr + strBCJG
                    Else
                        strQBJG = strBCJG
                    End If
                End If
                Me.textareaQBJG.InnerText = strQBJG
                Me.textareaBCJG.InnerText = strBCJG

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_Edit = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdBDBXX及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_BDBXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_BDBXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_BDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示“督办结果”
                If Me.showModuleData_Edit(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                Me.lblBDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdBDBXX, Me.m_intRows_BDBXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_BDBXX = True
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

                    '先显示grdBDBXX
                    If Me.showModuleData_BDBXX(strErrMsg) = False Then
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
                If Me.getModuleData_BDBXX(strErrMsg) = False Then
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
        Sub grdBDBXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdBDBXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_BDBXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_BDBXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_BDBXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdBDBXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdBDBXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBDBXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblBDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdBDBXX, Me.m_intRows_BDBXX) + ")"

                '同步
                If Me.showModuleData_BDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

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

        Private Sub doSave(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                If Me.textareaBCJG.InnerText.Trim = "" Then
                    strErrMsg = "错误：没有输入内容！"
                    GoTo errProc
                End If
                If Me.grdBDBXX.Items.Count < 1 Then
                    strErrMsg = "错误：您没有被督办，不用填督办结果！"
                    GoTo errProc
                End If
                If Me.grdBDBXX.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选定具体被督办的条目！"
                    GoTo errProc
                End If

                '暂存
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                With Me.m_objDataSet_BDBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE)
                    intRecPos = objDataGridProcess.getRecordPosition(Me.grdBDBXX.SelectedIndex, Me.grdBDBXX.CurrentPageIndex, Me.grdBDBXX.PageSize)
                    objDataRow = .DefaultView.Item(intRecPos).Row
                End With
                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_JIAOJIE_BCJG) = Me.textareaBCJG.InnerText.Trim + vbCr + "    " + Me.m_objInterface.iBLR + "    " + Format(Now, "yyyy-MM-dd HH:mm:ss")

                '显示
                If Me.showModuleData_BDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

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

        Private Sub doOK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objDataRow As System.Data.DataRow
            Dim intStep As Integer

            Try
                '询问
                Dim strUserList As String = ""
                Dim intRecPos As Integer
                Dim intCount As Integer
                Dim strValue As String
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '询问
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定填写的办理情况正确吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                Dim strField As String
                Dim intJJXH As Integer
                Dim intDBXH As Integer
                Dim strQBJG As String = ""
                Dim strBCJG As String = ""
                Dim strYYJG As String = ""
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '逐个保存
                    intCount = Me.grdBDBXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        '获取数据记录
                        intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdBDBXX.CurrentPageIndex, Me.grdBDBXX.PageSize)
                        With Me.m_objDataSet_BDBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE)
                            objDataRow = .DefaultView.Item(intRecPos).Row
                        End With

                        '准备数据
                        strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_JJXH
                        intJJXH = objPulicParameters.getObjectValue(objDataRow.Item(strField), 0)
                        strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBXH
                        intDBXH = objPulicParameters.getObjectValue(objDataRow.Item(strField), 0)
                        strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBJG
                        strYYJG = objPulicParameters.getObjectValue(objDataRow.Item(strField), "")
                        strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_JIAOJIE_BCJG
                        strBCJG = objPulicParameters.getObjectValue(objDataRow.Item(strField), "")
                        If strYYJG <> "" Then
                            strQBJG = strYYJG
                        End If
                        If strBCJG <> "" Then
                            If strQBJG <> "" Then
                                strQBJG = strQBJG + vbCr + strBCJG
                            Else
                                strQBJG = strBCJG
                            End If
                        End If

                        '保存
                        If Me.m_objsystemFlowObject.doSaveDuban(strErrMsg, intJJXH, intDBXH, strQBJG) = False Then
                            GoTo errProc
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
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
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

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Me.doSave("btnSave")
        End Sub

    End Class

End Namespace
