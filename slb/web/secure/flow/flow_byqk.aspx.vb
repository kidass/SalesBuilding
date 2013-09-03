Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_byqk
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理查看补阅情况任务
    '
    ' 接口参数：
    '     参见接口类IFlowByqk描述
    '----------------------------------------------------------------

    Public Class flow_byqk
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtBYQKPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZBYQKSetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtBYQKPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblBYQKGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents txtBYQKSearch_FSR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBYQKSearch_JSR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBYQKSearch_BLSY As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBYQKSearch_WCRQMin As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBYQKSearch_WCRQMax As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnBYQKSearch As System.Web.UI.WebControls.Button
        Protected WithEvents grdBYQK As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtBYQKFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBYQKQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBYQKRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBYQKSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBYQKSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBYQKSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBYQK As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBYQK As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSessionIdQuery As System.Web.UI.HtmlControls.HtmlInputHidden

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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowByqk
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowByqk
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdBYQK相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_BYQK As String = "chkBYQK"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_BYQK As String = "divBYQK"
        '网格要锁定的列数
        Private m_intFixedColumns_BYQK As Integer

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_BYQK As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_BYQK As String '记录m_objDataSet_BYQK搜索串
        Private m_intRows_BYQK As Integer '记录m_objDataSet_BYQK的DefaultView记录数









        '----------------------------------------------------------------
        ' 复原模块现场信息并释放相应的资源
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtBYQKQuery.Value = .htxtBYQKQuery
                    Me.htxtBYQKRows.Value = .htxtBYQKRows
                    Me.htxtBYQKSort.Value = .htxtBYQKSort
                    Me.htxtBYQKSortColumnIndex.Value = .htxtBYQKSortColumnIndex
                    Me.htxtBYQKSortType.Value = .htxtBYQKSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftBYQK.Value = .htxtDivLeftBYQK
                    Me.htxtDivTopBYQK.Value = .htxtDivTopBYQK

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtBYQKPageIndex.Text = .txtBYQKPageIndex
                    Me.txtBYQKPageSize.Text = .txtBYQKPageSize

                    Me.txtBYQKSearch_FSR.Text = .txtBYQKSearch_FSR
                    Me.txtBYQKSearch_JSR.Text = .txtBYQKSearch_JSR
                    Me.txtBYQKSearch_BLSY.Text = .txtBYQKSearch_BLSY
                    Me.txtBYQKSearch_WCRQMin.Text = .txtBYQKSearch_WCRQMin
                    Me.txtBYQKSearch_WCRQMax.Text = .txtBYQKSearch_WCRQMax

                    Try
                        Me.grdBYQK.PageSize = .grdBYQKPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBYQK.CurrentPageIndex = .grdBYQKCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBYQK.SelectedIndex = .grdBYQKSelectedIndex
                    Catch ex As Exception
                    End Try
                End With

                '释放资源
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 保存模块现场信息并返回相应的SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess

            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '创建SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then Exit Try

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowByqk

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtBYQKQuery = Me.htxtBYQKQuery.Value
                    .htxtBYQKRows = Me.htxtBYQKRows.Value
                    .htxtBYQKSort = Me.htxtBYQKSort.Value
                    .htxtBYQKSortColumnIndex = Me.htxtBYQKSortColumnIndex.Value
                    .htxtBYQKSortType = Me.htxtBYQKSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftBYQK = Me.htxtDivLeftBYQK.Value
                    .htxtDivTopBYQK = Me.htxtDivTopBYQK.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtBYQKPageIndex = Me.txtBYQKPageIndex.Text
                    .txtBYQKPageSize = Me.txtBYQKPageSize.Text

                    .txtBYQKSearch_FSR = Me.txtBYQKSearch_FSR.Text
                    .txtBYQKSearch_JSR = Me.txtBYQKSearch_JSR.Text
                    .txtBYQKSearch_BLSY = Me.txtBYQKSearch_BLSY.Text
                    .txtBYQKSearch_WCRQMin = Me.txtBYQKSearch_WCRQMin.Text
                    .txtBYQKSearch_WCRQMax = Me.txtBYQKSearch_WCRQMax.Text

                    .grdBYQKPageSize = Me.grdBYQK.PageSize
                    .grdBYQKCurrentPageIndex = Me.grdBYQK.CurrentPageIndex
                    .grdBYQKSelectedIndex = Me.grdBYQK.SelectedIndex
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.IsPostBack = True Then Exit Try

                '==========================================================================================================================================================
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                        Me.htxtBYQKQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQuery.Value.Trim = "" Then
                            Me.htxtSessionIdQuery.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            If Not (objQueryData Is Nothing) Then
                                objQueryData.Dispose()
                                objQueryData = Nothing
                            End If
                        End If
                        Session.Add(Me.htxtSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
                    End If
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objISjcxCxtj.Dispose()
                    objISjcxCxtj = Nothing
                    Exit Try
                End If

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
        ' 释放接口参数
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
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowByqk)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowByqk)
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

                '获取局部接口参数
                Me.m_intFixedColumns_BYQK = objPulicParameters.getObjectValue(Me.htxtBYQKFixed.Value, 0)
                Me.m_intRows_BYQK = objPulicParameters.getObjectValue(Me.htxtBYQKRows.Value, 0)
                Me.m_strQuery_BYQK = Me.htxtBYQKQuery.Value

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
        ' 释放本模块缓存的参数
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    If Not (objQueryData Is Nothing) Then
                        objQueryData.Dispose()
                        objQueryData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdQuery.Value)
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
        ' 获取grdBYQK的搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_BYQK( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess

            getQueryString_BYQK = False
            strQuery = ""

            Try
                '按“发送人”搜索
                Dim strFSR As String
                strFSR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_FSR
                If Me.txtBYQKSearch_FSR.Text.Length > 0 Then Me.txtBYQKSearch_FSR.Text = Me.txtBYQKSearch_FSR.Text.Trim()
                If Me.txtBYQKSearch_FSR.Text <> "" Then
                    Me.txtBYQKSearch_FSR.Text = objPulicParameters.getNewSearchString(Me.txtBYQKSearch_FSR.Text)
                    If strQuery = "" Then
                        strQuery = strFSR + " like '" + Me.txtBYQKSearch_FSR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strFSR + " like '" + Me.txtBYQKSearch_FSR.Text + "%'"
                    End If
                End If

                '按“接收人”搜索
                Dim strJSR As String
                strJSR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JSR
                If Me.txtBYQKSearch_JSR.Text.Length > 0 Then Me.txtBYQKSearch_JSR.Text = Me.txtBYQKSearch_JSR.Text.Trim()
                If Me.txtBYQKSearch_JSR.Text <> "" Then
                    Me.txtBYQKSearch_JSR.Text = objPulicParameters.getNewSearchString(Me.txtBYQKSearch_JSR.Text)
                    If strQuery = "" Then
                        strQuery = strJSR + " like '" + Me.txtBYQKSearch_JSR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJSR + " like '" + Me.txtBYQKSearch_JSR.Text + "%'"
                    End If
                End If

                '按“办理事宜”搜索
                Dim strBLSY As String
                strBLSY = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZL
                If Me.txtBYQKSearch_BLSY.Text.Length > 0 Then Me.txtBYQKSearch_BLSY.Text = Me.txtBYQKSearch_BLSY.Text.Trim()
                If Me.txtBYQKSearch_BLSY.Text <> "" Then
                    Me.txtBYQKSearch_BLSY.Text = objPulicParameters.getNewSearchString(Me.txtBYQKSearch_BLSY.Text)
                    If strQuery = "" Then
                        strQuery = strBLSY + " like '" + Me.txtBYQKSearch_BLSY.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strBLSY + " like '" + Me.txtBYQKSearch_BLSY.Text + "%'"
                    End If
                End If

                '按“完成日期”搜索
                Dim strWCRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strWCRQ = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_WCRQ
                If Me.txtBYQKSearch_WCRQMin.Text.Length > 0 Then Me.txtBYQKSearch_WCRQMin.Text = Me.txtBYQKSearch_WCRQMin.Text.Trim()
                If Me.txtBYQKSearch_WCRQMax.Text.Length > 0 Then Me.txtBYQKSearch_WCRQMax.Text = Me.txtBYQKSearch_WCRQMax.Text.Trim()
                If Me.txtBYQKSearch_WCRQMin.Text <> "" And Me.txtBYQKSearch_WCRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtBYQKSearch_WCRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtBYQKSearch_WCRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtBYQKSearch_WCRQMin.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                        Me.txtBYQKSearch_WCRQMax.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    Else
                        Me.txtBYQKSearch_WCRQMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                        Me.txtBYQKSearch_WCRQMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    End If
                    If strQuery = "" Then
                        strQuery = strWCRQ + " between '" + Me.txtBYQKSearch_WCRQMin.Text + "' and '" + Me.txtBYQKSearch_WCRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " between '" + Me.txtBYQKSearch_WCRQMin.Text + "' and '" + Me.txtBYQKSearch_WCRQMax.Text + "'"
                    End If
                ElseIf Me.txtBYQKSearch_WCRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtBYQKSearch_WCRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    Me.txtBYQKSearch_WCRQMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strWCRQ + " >= '" + Me.txtBYQKSearch_WCRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " >= '" + Me.txtBYQKSearch_WCRQMin.Text + "'"
                    End If
                ElseIf Me.txtBYQKSearch_WCRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtBYQKSearch_WCRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    Me.txtBYQKSearch_WCRQMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strWCRQ + " <= '" + Me.txtBYQKSearch_WCRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " <= '" + Me.txtBYQKSearch_WCRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_BYQK = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdBYQK要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_BYQK( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            getModuleData_BYQK = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtBYQKSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objDataSet_BYQK Is Nothing) Then
                    Me.m_objDataSet_BYQK.Dispose()
                    Me.m_objDataSet_BYQK = Nothing
                End If

                '重新检索数据
                If Me.m_objsystemFlowObject.getBuyueData(strErrMsg, Me.m_objInterface.iYjjhList, strWhere, Me.m_objDataSet_BYQK) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_BYQK.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_BYQK.Tables(strTable)
                    Me.htxtBYQKRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_BYQK = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_BYQK = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdBYQK数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_BYQK(ByRef strErrMsg As String) As Boolean

            searchModuleData_BYQK = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_BYQK(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_BYQK(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_BYQK = strQuery
                Me.htxtBYQKQuery.Value = Me.m_strQuery_BYQK

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_BYQK = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdBYQK的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_BYQK(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_BYQK = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtBYQKSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtBYQKSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_BYQK Is Nothing Then
                    Me.grdBYQK.DataSource = Nothing
                Else
                    With Me.m_objDataSet_BYQK.Tables(strTable)
                        Me.grdBYQK.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_BYQK.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdBYQK, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdBYQK)
                    With Me.grdBYQK.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdBYQK.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdBYQK, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_BYQK) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_BYQK = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdBYQK及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_BYQK(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_BYQK = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_BYQK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_BYQK.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblBYQKGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdBYQK, .Count)

                    '显示页面浏览功能
                    Me.lnkCZBYQKMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdBYQK, .Count)
                    Me.lnkCZBYQKMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdBYQK, .Count)
                    Me.lnkCZBYQKMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdBYQK, .Count)
                    Me.lnkCZBYQKMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdBYQK, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZBYQKDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZBYQKSelectAll.Enabled = blnEnabled
                    Me.lnkCZBYQKGotoPage.Enabled = blnEnabled
                    Me.lnkCZBYQKSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_BYQK = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示模块级的操作状态
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN(ByRef strErrMsg As String) As Boolean

            showModuleData_MAIN = False

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_MAIN = True
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

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                '显示Pannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                '执行键转译(不论是否是“回发”)
                Try
                    objControlProcess.doTranslateKey(Me.txtBYQKPageIndex)
                    objControlProcess.doTranslateKey(Me.txtBYQKPageSize)
                    objControlProcess.doTranslateKey(Me.txtBYQKSearch_FSR)
                    objControlProcess.doTranslateKey(Me.txtBYQKSearch_JSR)
                    objControlProcess.doTranslateKey(Me.txtBYQKSearch_BLSY)
                    objControlProcess.doTranslateKey(Me.txtBYQKSearch_WCRQMin)
                    objControlProcess.doTranslateKey(Me.txtBYQKSearch_WCRQMax)
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '显示模块级操作
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示数据
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_BYQK(strErrMsg) = False Then
                    GoTo errProc
                End If
            End If

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

            '预处理
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '获取接口参数
            Dim blnDo As Boolean
            If Me.getInterfaceParameters(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then GoTo normExit

            '控件初始化
            If Me.initializeControls(strErrMsg) = False Then
                GoTo errProc
            End If

            '记录访问审计日志
            If Me.IsPostBack = False Then
                If Me.m_blnSaveScence = False Then
                    If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了文件[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]的[文件补阅情况]！") = False Then
                        '忽略
                    End If
                End If
            End If
normExit:
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
        '网格事件处理器
        '----------------------------------------------------------------
        '实现对grdBYQK网格行、列的固定
        Sub grdBYQK_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdBYQK.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_BYQK + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_BYQK > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_BYQK - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdBYQK.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdBYQK_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBYQK.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblBYQKGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdBYQK, Me.m_intRows_BYQK)
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

        Private Sub grdBYQK_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdBYQK.SortCommand

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
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_BYQK.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_BYQK.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtBYQKSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtBYQKSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtBYQKSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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




        Private Sub doMoveFirst_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdBYQK.PageCount)
                Me.grdBYQK.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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

        Private Sub doMoveLast_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBYQK.PageCount - 1, Me.grdBYQK.PageCount)
                Me.grdBYQK.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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

        Private Sub doMoveNext_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBYQK.CurrentPageIndex + 1, Me.grdBYQK.PageCount)
                Me.grdBYQK.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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

        Private Sub doMovePrevious_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBYQK.CurrentPageIndex - 1, Me.grdBYQK.PageCount)
                Me.grdBYQK.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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

        Private Sub doGotoPage_BYQK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtBYQKPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdBYQK.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_BYQK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtBYQKPageIndex.Text = (Me.grdBYQK.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_BYQK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtBYQKPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdBYQK.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_BYQK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtBYQKPageSize.Text = (Me.grdBYQK.PageSize).ToString()

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

        Private Sub doSelectAll_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdBYQK, 0, Me.m_cstrCheckBoxIdInDataGrid_BYQK, True) = False Then
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

        Private Sub doDeSelectAll_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdBYQK, 0, Me.m_cstrCheckBoxIdInDataGrid_BYQK, False) = False Then
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

        Private Sub doSearch_BYQK(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_BYQK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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

        Private Sub lnkCZBYQKMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKMoveFirst.Click
            Me.doMoveFirst_BYQK("lnkCZBYQKMoveFirst")
        End Sub

        Private Sub lnkCZBYQKMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKMoveLast.Click
            Me.doMoveLast_BYQK("lnkCZBYQKMoveLast")
        End Sub

        Private Sub lnkCZBYQKMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKMoveNext.Click
            Me.doMoveNext_BYQK("lnkCZBYQKMoveNext")
        End Sub

        Private Sub lnkCZBYQKMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKMovePrev.Click
            Me.doMovePrevious_BYQK("lnkCZBYQKMovePrev")
        End Sub

        Private Sub lnkCZBYQKGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKGotoPage.Click
            Me.doGotoPage_BYQK("lnkCZBYQKGotoPage")
        End Sub

        Private Sub lnkCZBYQKSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKSetPageSize.Click
            Me.doSetPageSize_BYQK("lnkCZBYQKSetPageSize")
        End Sub

        Private Sub lnkCZBYQKSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKSelectAll.Click
            Me.doSelectAll_BYQK("lnkCZBYQKSelectAll")
        End Sub

        Private Sub lnkCZBYQKDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKDeSelectAll.Click
            Me.doDeSelectAll_BYQK("lnkCZBYQKDeSelectAll")
        End Sub

        Private Sub btnBYQKSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBYQKSearch.Click
            Me.doSearch_BYQK("btnBYQKSearch")
        End Sub



        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doClose(ByVal strControlId As String)

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

        Private Sub doSearchFull(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            Try
                '获取数据
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_BYQK.Tables(strTable)
                    .iFixQuery = ""

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

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objISjcxCxtj)
                strUrl = ""
                strUrl += "../sjcx/sjcx_cxtj.aspx"
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

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.doSearchFull("btnSearch")
        End Sub

    End Class

End Namespace
