Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_bycl
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理工作流文件的文件补阅任务
    '
    ' 接口参数：
    '     参见接口类IFlowBycl描述
    '----------------------------------------------------------------

    Public Class flow_bycl
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblWSCXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdWSCXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnSendRequest As System.Web.UI.WebControls.Button
        Protected WithEvents btnShouRequest As System.Web.UI.WebControls.Button
        Protected WithEvents btnSendTongzhi As System.Web.UI.WebControls.Button
        Protected WithEvents lblSGWXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdSGWXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnPizhun As System.Web.UI.WebControls.Button
        Protected WithEvents btnJujue As System.Web.UI.WebControls.Button
        Protected WithEvents btnZhuanfa As System.Web.UI.WebControls.Button
        Protected WithEvents btnHasRead As System.Web.UI.WebControls.Button
        Protected WithEvents btnRefresh As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtWSCXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtValueB As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtValueA As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWSCXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWSCXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWSCXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWSCXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWSCXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftWSCXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopWSCXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftSGWXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopSGWXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowBycl
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowBycl
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_WSCXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_WSCXX As String '记录m_objDataSet_WSCXX搜索串
        Private m_intRows_WSCXX As Integer '记录m_objDataSet_WSCXX的DefaultView记录数
        Private m_objDataSet_SGWXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_SGWXX As String '记录m_objDataSet_SGWXX搜索串
        Private m_intRows_SGWXX As Integer '记录m_objDataSet_SGWXX的DefaultView记录数

        '----------------------------------------------------------------
        '与数据网格grdWSCXX相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_WSCXX As String = "chkWSCXX"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_WSCXX As String = "divWSCXX"
        '网格要锁定的列数
        Private m_intFixedColumns_WSCXX As Integer

        '----------------------------------------------------------------
        '与数据网格grdSGWXX相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_SGWXX As String = "chkSGWXX"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_SGWXX As String = "divSGWXX"
        '网格要锁定的列数
        Private m_intFixedColumns_SGWXX As Integer

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
                    Me.htxtValueA.Value = .htxtValueA
                    Me.htxtValueB.Value = .htxtValueB

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftWSCXX.Value = .htxtDivLeftWSCXX
                    Me.htxtDivTopWSCXX.Value = .htxtDivTopWSCXX
                    Me.htxtDivLeftSGWXX.Value = .htxtDivLeftSGWXX
                    Me.htxtDivTopSGWXX.Value = .htxtDivTopSGWXX

                    Me.htxtWSCXXQuery.Value = .htxtWSCXXQuery
                    Me.htxtWSCXXRows.Value = .htxtWSCXXRows
                    Me.htxtWSCXXSort.Value = .htxtWSCXXSort
                    Me.htxtWSCXXSortColumnIndex.Value = .htxtWSCXXSortColumnIndex
                    Me.htxtWSCXXSortType.Value = .htxtWSCXXSortType

                    Me.htxtSGWXXQuery.Value = .htxtSGWXXQuery
                    Me.htxtSGWXXRows.Value = .htxtSGWXXRows
                    Me.htxtSGWXXSort.Value = .htxtSGWXXSort
                    Me.htxtSGWXXSortColumnIndex.Value = .htxtSGWXXSortColumnIndex
                    Me.htxtSGWXXSortType.Value = .htxtSGWXXSortType

                    Try
                        Me.grdWSCXX.PageSize = .grdWSCXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWSCXX.CurrentPageIndex = .grdWSCXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWSCXX.SelectedIndex = .grdWSCXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdSGWXX.PageSize = .grdSGWXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSGWXX.CurrentPageIndex = .grdSGWXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSGWXX.SelectedIndex = .grdSGWXX_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowBycl

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtValueA = Me.htxtValueA.Value
                    .htxtValueB = Me.htxtValueB.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftWSCXX = Me.htxtDivLeftWSCXX.Value
                    .htxtDivTopWSCXX = Me.htxtDivTopWSCXX.Value
                    .htxtDivLeftSGWXX = Me.htxtDivLeftSGWXX.Value
                    .htxtDivTopSGWXX = Me.htxtDivTopSGWXX.Value

                    .htxtWSCXXQuery = Me.htxtWSCXXQuery.Value
                    .htxtWSCXXRows = Me.htxtWSCXXRows.Value
                    .htxtWSCXXSort = Me.htxtWSCXXSort.Value
                    .htxtWSCXXSortColumnIndex = Me.htxtWSCXXSortColumnIndex.Value
                    .htxtWSCXXSortType = Me.htxtWSCXXSortType.Value

                    .htxtSGWXXQuery = Me.htxtSGWXXQuery.Value
                    .htxtSGWXXRows = Me.htxtSGWXXRows.Value
                    .htxtSGWXXSort = Me.htxtSGWXXSort.Value
                    .htxtSGWXXSortColumnIndex = Me.htxtSGWXXSortColumnIndex.Value
                    .htxtSGWXXSortType = Me.htxtSGWXXSortType.Value

                    .grdWSCXX_PageSize = Me.grdWSCXX.PageSize
                    .grdWSCXX_CurrentPageIndex = Me.grdWSCXX.CurrentPageIndex
                    .grdWSCXX_SelectedIndex = Me.grdWSCXX.SelectedIndex

                    .grdSGWXX_PageSize = Me.grdSGWXX.PageSize
                    .grdSGWXX_CurrentPageIndex = Me.grdSGWXX.CurrentPageIndex
                    .grdSGWXX_SelectedIndex = Me.grdSGWXX.SelectedIndex

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
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Try
                If Me.IsPostBack = True Then Exit Try

                '=========================================================================================================================================================
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Try
                    objIDmxzZzry = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzry)
                Catch ex As Exception
                    objIDmxzZzry = Nothing
                End Try
                If Not (objIDmxzZzry Is Nothing) Then
                    '获取信息
                    Dim strSourceControl As String = objIDmxzZzry.iSourceControlId.ToUpper
                    Dim blnExitMode As Boolean = objIDmxzZzry.oExitMode
                    Dim strList As String = objIDmxzZzry.oRenyuanList
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIDmxzZzry.Dispose()
                    objIDmxzZzry = Nothing
                    If blnExitMode = True Then
                        Dim intJJXH As Integer
                        Select Case strSourceControl
                            Case "btnSendRequest".ToUpper
                                If Me.doSendBuyueRequest(strErrMsg, Me.m_objInterface.iBLR, strList) = False Then
                                    GoTo errProc
                                End If
                                objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：您已经向[" + strList + "]发出文件补阅请求！")
                            Case "btnSendTongzhi".ToUpper
                                If Me.doSendBuyueTongzhi(strErrMsg, Me.m_objInterface.iBLR, strList, Me.htxtValueA.Value) = False Then
                                    GoTo errProc
                                End If
                                Me.htxtValueA.Value = ""
                                objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：您已经向[" + strList + "]发出文件补阅通知！")
                            Case "btnZhuanfa".ToUpper
                                intJJXH = objPulicParameters.getObjectValue(Me.htxtValueA.Value, 0)
                                If Me.doZhuanfaBuyueRequest(strErrMsg, intJJXH, strList) = False Then
                                    GoTo errProc
                                End If
                                Me.htxtValueA.Value = ""
                                objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：您已经向[" + strList + "]转发了文件补阅请求！")
                            Case Else
                        End Select
                    End If
                    Exit Try
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowBycl)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowBycl)
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
                Me.m_intFixedColumns_WSCXX = objPulicParameters.getObjectValue(Me.htxtWSCXXFixed.Value, 0)
                Me.m_intRows_WSCXX = objPulicParameters.getObjectValue(Me.htxtWSCXXRows.Value, 0)
                Me.m_strQuery_WSCXX = Me.htxtWSCXXQuery.Value

                Me.m_intFixedColumns_SGWXX = objPulicParameters.getObjectValue(Me.htxtSGWXXFixed.Value, 0)
                Me.m_intRows_SGWXX = objPulicParameters.getObjectValue(Me.htxtSGWXXRows.Value, 0)
                Me.m_strQuery_SGWXX = Me.htxtSGWXXQuery.Value

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
        ' 获取“我送出”的补阅信息数据集
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件(a.)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_WSCXX( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            getModuleData_WSCXX = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtWSCXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objDataSet_WSCXX Is Nothing) Then
                    Me.m_objDataSet_WSCXX.Dispose()
                    Me.m_objDataSet_WSCXX = Nothing
                End If

                '重新检索数据
                If Me.m_objsystemFlowObject.getBuyueSendData(strErrMsg, Me.m_objInterface.iBLR, strWhere, Me.m_objDataSet_WSCXX) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_WSCXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_WSCXX.Tables(strTable)
                    Me.htxtWSCXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_WSCXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_WSCXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取“我收到”的补阅信息数据集
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件(a.)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_SGWXX( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            getModuleData_SGWXX = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtSGWXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objDataSet_SGWXX Is Nothing) Then
                    Me.m_objDataSet_SGWXX.Dispose()
                    Me.m_objDataSet_SGWXX = Nothing
                End If

                '重新检索数据
                If Me.m_objsystemFlowObject.getBuyueRecvData(strErrMsg, Me.m_objInterface.iBLR, strWhere, Me.m_objDataSet_SGWXX) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_SGWXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_SGWXX.Tables(strTable)
                    Me.htxtSGWXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_SGWXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_SGWXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdWSCXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_WSCXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            showDataGridInfo_WSCXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtWSCXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtWSCXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_WSCXX Is Nothing Then
                    Me.grdWSCXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_WSCXX.Tables(strTable)
                        Me.grdWSCXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_WSCXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdWSCXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdWSCXX)
                    With Me.grdWSCXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdWSCXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdWSCXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_WSCXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_WSCXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSGWXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SGWXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            showDataGridInfo_SGWXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtSGWXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtSGWXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_SGWXX Is Nothing Then
                    Me.grdSGWXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SGWXX.Tables(strTable)
                        Me.grdSGWXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_SGWXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSGWXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdSGWXX)
                    With Me.grdSGWXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdSGWXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSGWXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_SGWXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SGWXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdWSCXX及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_WSCXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_WSCXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_WSCXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                Me.lblWSCXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdWSCXX, Me.m_intRows_WSCXX) + ")"

                '有“我送出”
                Dim strOldFilter As String
                Dim strFilter As String
                With Me.m_objDataSet_WSCXX.Tables(strTable)
                    If .Rows.Count > 0 Then
                        Me.btnShouRequest.Enabled = True
                    Else
                        Me.btnShouRequest.Enabled = False
                    End If
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_WSCXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据当前行显示操作信息(grdSGWXX)
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showCommand_SGWXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showCommand_SGWXX = False
            strErrMsg = ""

            Try
                '有“送给我”
                Dim intColIndex As Integer
                Dim strBLZL As String = ""
                Dim strBLZT As String = ""
                If Me.grdSGWXX.Items.Count > 0 Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(Me.grdSGWXX.SelectedIndex), intColIndex)
                    If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = True Then
                        Me.btnPizhun.Enabled = False
                        Me.btnJujue.Enabled = False
                        Me.btnZhuanfa.Enabled = False
                        Me.btnHasRead.Enabled = False
                    Else
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZL)
                        strBLZL = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(Me.grdSGWXX.SelectedIndex), intColIndex)
                        Select Case strBLZL
                            Case Josco.JSOA.Common.Workflow.BaseFlowObject.TASK_BYQQ
                                Me.btnPizhun.Enabled = True
                                Me.btnJujue.Enabled = True
                                Me.btnZhuanfa.Enabled = True
                                Me.btnHasRead.Enabled = False
                            Case Else
                                Me.btnPizhun.Enabled = False
                                Me.btnJujue.Enabled = False
                                Me.btnZhuanfa.Enabled = False
                                Me.btnHasRead.Enabled = True
                        End Select
                    End If
                Else
                    Me.btnPizhun.Enabled = False
                    Me.btnJujue.Enabled = False
                    Me.btnZhuanfa.Enabled = False
                    Me.btnHasRead.Enabled = False
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showCommand_SGWXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSGWXX及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_SGWXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_SGWXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_SGWXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                Me.lblSGWXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdSGWXX, Me.m_intRows_SGWXX) + ")"

                '显示操作信息
                If Me.showCommand_SGWXX(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_SGWXX = True
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
                '一般能做
                Me.btnSendRequest.Enabled = True
                Me.btnSendTongzhi.Enabled = True

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

                    '显示grdWSCXX
                    If Me.getModuleData_WSCXX(strErrMsg, Me.m_strQuery_WSCXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_WSCXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '获取数据
                    If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SGWXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '显示Main
                    If Me.showModuleData_Main(strErrMsg) = False Then
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
        Sub grdWSCXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdWSCXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_WSCXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_WSCXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_WSCXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdWSCXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdWSCXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdWSCXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblWSCXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdWSCXX, Me.m_intRows_WSCXX) + ")"

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

        Private Sub grdWSCXX_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdWSCXX.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String
                Dim strOldCommand As String
                Dim strUniqueId As String
                Dim intColumnIndex As Integer

                '获取数据
                If Me.getModuleData_WSCXX(strErrMsg, Me.m_strQuery_WSCXX) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_WSCXX.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_WSCXX.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtWSCXXSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtWSCXXSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtWSCXXSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_WSCXX(strErrMsg) = False Then
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

        Sub grdSGWXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSGWXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_SGWXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_SGWXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_SGWXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSGWXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdSGWXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSGWXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblSGWXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdSGWXX, Me.m_intRows_SGWXX) + ")"

                '同步操作
                If Me.showCommand_SGWXX(strErrMsg) = False Then
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

        Private Sub grdSGWXX_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdSGWXX.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String
                Dim strOldCommand As String
                Dim strUniqueId As String
                Dim intColumnIndex As Integer

                '获取数据
                If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_SGWXX.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_SGWXX.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtSGWXXSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtSGWXXSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtSGWXXSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_SGWXX(strErrMsg) = False Then
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

        '----------------------------------------------------------------
        ' strFSR向strJSRList发送补阅请求
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strFSR               ：发送人
        '     strJSRList           ：接收人列表
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Private Function doSendBuyueRequest( _
            ByRef strErrMsg As String, _
            ByVal strFSR As String, _
            ByVal strJSRList As String) As Boolean

            doSendBuyueRequest = False
            strErrMsg = ""

            Try
                '检查
                If strFSR Is Nothing Then strFSR = ""
                strFSR = strFSR.Trim
                If strFSR = "" Then
                    strErrMsg = "错误：未指定发送人！"
                    GoTo errProc
                End If
                If strJSRList Is Nothing Then strJSRList = ""
                strJSRList = strJSRList.Trim
                If strJSRList = "" Then
                    strErrMsg = "错误：未指定接收人！"
                    GoTo errProc
                End If

                '解析接收人
                Dim strArray() As String
                strArray = strJSRList.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)

                '获取“发送序号”
                Dim strFSXH As String
                If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                    GoTo errProc
                End If

                '逐个发送
                Dim intCount As Integer
                Dim i As Integer
                intCount = strArray.Length
                For i = 0 To intCount - 1 Step 1
                    If Me.m_objsystemFlowObject.doSendBuyueRequest(strErrMsg, strFSXH, strFSR, strArray(i), "") = False Then
                        GoTo errProc
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doSendBuyueRequest = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Sub doSendBuyueRequest(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '计算可以进行补阅的人员列表SQL
                Dim strXZSQL As String
                If Me.m_objsystemFlowObject.getAllJsrSql(strErrMsg, Me.m_objInterface.iBLR, strXZSQL) = False Then
                    GoTo errProc
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Dim strUrl As String
                objIDmxzZzry = New Josco.JsKernal.BusinessFacade.IDmxzZzry
                With objIDmxzZzry
                    .iSendRestrict = False
                    .iSelectMode = False
                    .iAllowInput = False
                    .iAllowNull = False
                    .iMultiSelect = True
                    .iSelectBMMC = False
                    .iSelectFFFW = False
                    .iRenyuanList = ""
                    .iRestrictRenyuanList = True
                    .iRestrictRenyuanListSQL = strXZSQL

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
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIDmxzZzry)
                strUrl = ""
                strUrl += "../dmxz/dmxz_zzry.aspx"
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

        Private Sub doShouBuyueRequest(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '检查选择
                Dim intColIndex As Integer
                Dim strBLZT As String
                Dim intSelect As Integer
                Dim intRows As Integer
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intRows = Me.grdWSCXX.Items.Count
                    intSelect = 0
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdWSCXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_WSCXX) = True Then
                            strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intColIndex)
                            If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                                intSelect += 1
                            End If
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：没有选择您发出或您转发的请求，或选择的都已经办完！"
                        GoTo errProc
                    End If
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要收回选定的[" + intSelect.ToString + "]个请求吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '询问
                Dim strUserList As String = ""
                Dim intIndex(3) As Integer
                Dim strValue(3) As String
                Dim intJJXH As Integer
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JSR)
                    intIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                    intRows = Me.grdWSCXX.Items.Count
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdWSCXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_WSCXX) = True Then
                            strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(0))
                            If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                                strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(1))
                                strValue(2) = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(2))
                                intJJXH = objPulicParameters.getObjectValue(strValue(2), 0)
                                If Me.m_objsystemFlowObject.doShouhuiBuyueRequest(strErrMsg, intJJXH) = False Then
                                    GoTo errProc
                                End If
                                If strUserList = "" Then
                                    strUserList = strValue(1)
                                Else
                                    strUserList = strUserList + objPulicParameters.CharSeparate + strValue(1)
                                End If
                            End If
                        End If
                    Next

                    '显示
                    If Me.getModuleData_WSCXX(strErrMsg, Me.m_strQuery_WSCXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_WSCXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：已经收回了送给[" + strUserList + "]的补阅请求！")
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

        '2010-04-09 LJ
        Private Sub doShouBuyueTongzhi(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '检查选择
                Dim intColIndex As Integer
                Dim strBLZT As String
                Dim intSelect As Integer
                Dim intRows As Integer
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intRows = Me.grdWSCXX.Items.Count
                    intSelect = 0
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdWSCXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_WSCXX) = True Then
                            strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intColIndex)
                            If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                                intSelect += 1
                            End If
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：没有选择您发出或您转发的请求，或选择的都已经办完！"
                        GoTo errProc
                    End If
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要收回选定的[" + intSelect.ToString + "]个请求吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '询问
                Dim strUserList As String = ""
                Dim intIndex(3) As Integer
                Dim strValue(3) As String
                Dim intJJXH As Integer
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JSR)
                    intIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                    intRows = Me.grdWSCXX.Items.Count
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdWSCXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_WSCXX) = True Then
                            strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(0))
                            If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                                strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(1))
                                strValue(2) = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(2))
                                intJJXH = objPulicParameters.getObjectValue(strValue(2), 0)
                                If Me.m_objsystemFlowObject.doShouhuiBuyueTongzhi(strErrMsg, intJJXH) = False Then
                                    GoTo errProc
                                End If
                                If strUserList = "" Then
                                    strUserList = strValue(1)
                                Else
                                    strUserList = strUserList + objPulicParameters.CharSeparate + strValue(1)
                                End If
                            End If
                        End If
                    Next

                    '显示
                    If Me.getModuleData_WSCXX(strErrMsg, Me.m_strQuery_WSCXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_WSCXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：已经收回了送给[" + strUserList + "]的补阅请求！")
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

        '----------------------------------------------------------------
        ' strFSR向strJSRList发送补阅同志
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strFSR               ：发送人
        '     strJSRList           ：接收人列表
        '     strJJSM              ：批注
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Private Function doSendBuyueTongzhi( _
            ByRef strErrMsg As String, _
            ByVal strFSR As String, _
            ByVal strJSRList As String, _
            ByVal strJJSM As String) As Boolean

            doSendBuyueTongzhi = False
            strErrMsg = ""

            Try
                '检查
                If strFSR Is Nothing Then strFSR = ""
                strFSR = strFSR.Trim
                If strFSR = "" Then
                    strErrMsg = "错误：未指定发送人！"
                    GoTo errProc
                End If
                If strJSRList Is Nothing Then strJSRList = ""
                strJSRList = strJSRList.Trim
                If strJSRList = "" Then
                    strErrMsg = "错误：未指定接收人！"
                    GoTo errProc
                End If
                If strJJSM Is Nothing Then strJJSM = ""
                strJJSM = strJJSM.Trim

                '解析接收人
                Dim strArray() As String
                strArray = strJSRList.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)

                '获取“发送序号”
                Dim strFSXH As String
                If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                    GoTo errProc
                End If

                '逐个发送
                Dim intCount As Integer
                Dim i As Integer
                intCount = strArray.Length
                For i = 0 To intCount - 1 Step 1
                    If Me.m_objsystemFlowObject.doSendBuyueTongzhi(strErrMsg, strFSXH, strFSR, strArray(i), strJJSM) = False Then
                        GoTo errProc
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doSendBuyueTongzhi = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Sub doSendBuyueTongzhi(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '输入批注内容
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    'LJ 2008-07-3
                    objMessageProcess.doInputBox(Me.popMessageObject, "请输入批注内容", strControlId, intStep, " ")
                    'LJ 2008-07-3
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '获取输入值
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '批注内容
                    Me.htxtValueA.Value = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)

                    '备份现场参数
                    strMSessionId = Me.saveModuleInformation()
                    If strMSessionId = "" Then
                        strErrMsg = "错误：不能保存现场信息！"
                        GoTo errProc
                    End If

                    '准备调用接口
                    Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                    Dim strUrl As String
                    objIDmxzZzry = New Josco.JsKernal.BusinessFacade.IDmxzZzry
                    With objIDmxzZzry
                        .iSelectMode = False
                        .iAllowInput = False
                        .iAllowNull = False
                        .iMultiSelect = True
                        .iSelectBMMC = False
                        .iSelectFFFW = False

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
                        strUrl += strMSessionId
                        .iReturnUrl = strUrl
                    End With

                    '调用模块
                    strNewSessionId = objPulicParameters.getNewGuid()
                    If strNewSessionId = "" Then
                        strErrMsg = "错误：不能初始化调用接口！"
                        GoTo errProc
                    End If
                    Session.Add(strNewSessionId, objIDmxzZzry)
                    strUrl = ""
                    strUrl += "../dmxz/dmxz_zzry.aspx"
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += strNewSessionId
                    Response.Redirect(strUrl)
                End If

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

        Private Sub doPizhunBuyueRequest(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '检查选择
                Dim intColIndex As Integer
                Dim strBLZT As String
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.grdSGWXX.Items.Count < 1 Then
                        strErrMsg = "错误：您没有接收任何请求！"
                        GoTo errProc
                    End If
                    If Me.grdSGWXX.SelectedIndex < 0 Then
                        strErrMsg = "错误：您没有接收任何请求！"
                        GoTo errProc
                    End If
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    i = Me.grdSGWXX.SelectedIndex
                    strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intColIndex)
                    If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = True Then
                        strErrMsg = "错误：当前请求已处理完毕，不用再处理！"
                        GoTo errProc
                    End If
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要同意当前请求吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '询问
                Dim strUserList As String = ""
                Dim intIndex(3) As Integer
                Dim strValue(3) As String
                Dim strFSXH As String
                Dim intJJXH As Integer
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                        GoTo errProc
                    End If
                    intIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JSR)
                    intIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                    i = Me.grdSGWXX.SelectedIndex
                    strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(0))
                    If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                        strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(1))
                        strValue(2) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(2))
                        intJJXH = objPulicParameters.getObjectValue(strValue(2), 0)
                        If Me.m_objsystemFlowObject.doPizhunBuyueRequest(strErrMsg, intJJXH, strFSXH) = False Then
                            GoTo errProc
                        End If
                        strUserList = strValue(1)
                    End If

                    '显示
                    If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SGWXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：您批准了当前文件补阅请求，并向[" + strUserList + "]发出了通知消息！")
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

        Private Sub doJujueBuyueRequest(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '检查选择
                Dim intColIndex As Integer
                Dim strBLZT As String
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.grdSGWXX.Items.Count < 1 Then
                        strErrMsg = "错误：您没有接收任何请求！"
                        GoTo errProc
                    End If
                    If Me.grdSGWXX.SelectedIndex < 0 Then
                        strErrMsg = "错误：您没有接收任何请求！"
                        GoTo errProc
                    End If
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    i = Me.grdSGWXX.SelectedIndex
                    strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intColIndex)
                    If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = True Then
                        strErrMsg = "错误：当前请求已处理完毕，不用再处理！"
                        GoTo errProc
                    End If
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要拒绝当前请求吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '询问
                Dim strUserList As String = ""
                Dim intIndex(3) As Integer
                Dim strValue(3) As String
                Dim strFSXH As String
                Dim intJJXH As Integer
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                        GoTo errProc
                    End If
                    intIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JSR)
                    intIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                    i = Me.grdSGWXX.SelectedIndex
                    strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(0))
                    If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                        strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(1))
                        strValue(2) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(2))
                        intJJXH = objPulicParameters.getObjectValue(strValue(2), 0)
                        If Me.m_objsystemFlowObject.doJujueBuyueRequest(strErrMsg, intJJXH, strFSXH) = False Then
                            GoTo errProc
                        End If
                        strUserList = strValue(1)
                    End If

                    '刷新显示
                    If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SGWXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：您拒绝了当前文件补阅请求，并向[" + strUserList + "]发出了通知消息！")
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

        '----------------------------------------------------------------
        ' intJJXH的接收人向strZFJSR转发补阅请求
        '     strErrMsg            ：如果错误，则返回错误信息
        '     intJJXH              ：当前交接号
        '     strZFJSR             ：转发接收人列表
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Private Function doZhuanfaBuyueRequest( _
            ByRef strErrMsg As String, _
            ByVal intJJXH As Integer, _
            ByVal strZFJSR As String) As Boolean

            doZhuanfaBuyueRequest = False
            strErrMsg = ""

            Try
                '检查
                If strZFJSR Is Nothing Then strZFJSR = ""
                strZFJSR = strZFJSR.Trim
                If strZFJSR = "" Then
                    strErrMsg = "错误：未指定转发接收人！"
                    GoTo errProc
                End If

                '获取“发送序号”
                Dim strFSXH As String
                If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                    GoTo errProc
                End If

                '逐个发送
                If Me.m_objsystemFlowObject.doZhuanfaBuyueRequest(strErrMsg, intJJXH, strFSXH, strZFJSR) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doZhuanfaBuyueRequest = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Sub doZhuanfaBuyueRequest(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '检查选择
                Dim intColIndex(3) As Integer
                Dim strValue(3) As String
                Dim i As Integer
                If Me.grdSGWXX.Items.Count < 1 Then
                    strErrMsg = "错误：您没有接收任何请求！"
                    GoTo errProc
                End If
                If Me.grdSGWXX.SelectedIndex < 0 Then
                    strErrMsg = "错误：您没有接收任何请求！"
                    GoTo errProc
                End If
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                i = Me.grdSGWXX.SelectedIndex
                strValue(0) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intColIndex(0))
                If Me.m_objsystemFlowObject.isTaskComplete(strValue(0)) = True Then
                    strErrMsg = "错误：请求已经处理完毕，不用再处理！"
                    GoTo errProc
                End If
                strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intColIndex(1))
                strValue(2) = strValue(1)
                Me.htxtValueA.Value = strValue(2)

                '计算可以进行补阅的人员列表SQL
                Dim strXZSQL As String
                If Me.m_objsystemFlowObject.getAllJsrSql(strErrMsg, Me.m_objInterface.iBLR, strXZSQL) = False Then
                    GoTo errProc
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Dim strUrl As String
                objIDmxzZzry = New Josco.JsKernal.BusinessFacade.IDmxzZzry
                With objIDmxzZzry
                    .iSendRestrict = False
                    .iSelectMode = False
                    .iAllowInput = False
                    .iAllowNull = False
                    .iMultiSelect = True
                    .iSelectBMMC = False
                    .iSelectFFFW = False
                    .iRenyuanList = ""
                    .iRestrictRenyuanList = True
                    .iRestrictRenyuanListSQL = strXZSQL

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
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIDmxzZzry)
                strUrl = ""
                strUrl += "../dmxz/dmxz_zzry.aspx"
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
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Me.htxtValueA.Value = ""
            Exit Sub

        End Sub

        Private Sub doReadBuyueTongzhi(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '检查选择
                Dim intColIndex As Integer
                Dim strBLZT As String
                Dim i As Integer
                If Me.grdSGWXX.Items.Count < 1 Then
                    strErrMsg = "错误：您没有接收任何通知！"
                    GoTo errProc
                End If
                If Me.grdSGWXX.SelectedIndex < 0 Then
                    strErrMsg = "错误：您没有接收任何通知！"
                    GoTo errProc
                End If
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                i = Me.grdSGWXX.SelectedIndex
                strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intColIndex)
                If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = True Then
                    strErrMsg = "错误：当前通知已处理完毕，不用再处理！"
                    GoTo errProc
                End If

                '询问
                Dim intIndex(3) As Integer
                Dim strValue(3) As String
                Dim intJJXH As Integer
                intIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                intIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                i = Me.grdSGWXX.SelectedIndex
                strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(0))
                If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                    strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(1))
                    intJJXH = objPulicParameters.getObjectValue(strValue(1), 0)
                    If Me.m_objsystemFlowObject.doReadBuyueTongzhi(strErrMsg, intJJXH) = False Then
                        GoTo errProc
                    End If
                End If

                '显示
                If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_SGWXX(strErrMsg) = False Then
                    GoTo errProc
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

        Private Sub doRefresh(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.getModuleData_WSCXX(strErrMsg, Me.m_strQuery_WSCXX) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_WSCXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_SGWXX(strErrMsg) = False Then
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

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnSendRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendRequest.Click
            Me.doSendBuyueRequest("btnSendRequest")
        End Sub

        Private Sub btnShouRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShouRequest.Click
            '2010-04-09 LJ
            'Me.doShouBuyueRequest("btnShouRequest")
            Me.doShouBuyueTongzhi("btnShouRequest")
            '2010-04-09 LJ
        End Sub

        Private Sub btnSendTongzhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendTongzhi.Click
            Me.doSendBuyueTongzhi("btnSendTongzhi")
        End Sub

        Private Sub btnPizhun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPizhun.Click
            Me.doPizhunBuyueRequest("btnPizhun")
        End Sub

        Private Sub btnJujue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJujue.Click
            Me.doJujueBuyueRequest("btnJujue")
        End Sub

        Private Sub btnZhuanfa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnZhuanfa.Click
            Me.doZhuanfaBuyueRequest("btnZhuanfa")
        End Sub

        Private Sub btnHasRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHasRead.Click
            Me.doReadBuyueTongzhi("btnHasRead")
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Me.doRefresh("btnRefresh")
        End Sub

    End Class

End Namespace
