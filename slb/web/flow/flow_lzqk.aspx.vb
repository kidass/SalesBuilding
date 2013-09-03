Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_lzqk
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理查看流转情况任务
    '
    ' 接口参数：
    '     参见接口类IFlowLzqk描述
    '----------------------------------------------------------------

    Public Class flow_lzqk
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtLZXXPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZLZXXSetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtLZXXPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblLZXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents txtLZXXSearch_FSR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLZXXSearch_JSR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLZXXSearch_BLSY As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLZXXSearch_WCRQMin As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLZXXSearch_WCRQMax As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnLZXXSearch As System.Web.UI.WebControls.Button
        Protected WithEvents grdLZXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnCKYJ As System.Web.UI.WebControls.Button
        Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtLZXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLZXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLZXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLZXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLZXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLZXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftLZXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopLZXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowLzqk
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowLzqk
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdLZXX相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_LZXX As String = "chkLZXX"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_LZXX As String = "divLZXX"
        '网格要锁定的列数
        Private m_intFixedColumns_LZXX As Integer

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_LZXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_LZXX As String '记录m_objDataSet_LZXX搜索串
        Private m_intRows_LZXX As Integer '记录m_objDataSet_LZXX的DefaultView记录数












        '----------------------------------------------------------------
        ' 复原模块现场信息并释放相应的资源
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtLZXXQuery.Value = .htxtLZXXQuery
                    Me.htxtLZXXRows.Value = .htxtLZXXRows
                    Me.htxtLZXXSort.Value = .htxtLZXXSort
                    Me.htxtLZXXSortColumnIndex.Value = .htxtLZXXSortColumnIndex
                    Me.htxtLZXXSortType.Value = .htxtLZXXSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftLZXX.Value = .htxtDivLeftLZXX
                    Me.htxtDivTopLZXX.Value = .htxtDivTopLZXX

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtLZXXPageIndex.Text = .txtLZXXPageIndex
                    Me.txtLZXXPageSize.Text = .txtLZXXPageSize

                    Me.txtLZXXSearch_FSR.Text = .txtLZXXSearch_FSR
                    Me.txtLZXXSearch_JSR.Text = .txtLZXXSearch_JSR
                    Me.txtLZXXSearch_BLSY.Text = .txtLZXXSearch_BLSY
                    Me.txtLZXXSearch_WCRQMin.Text = .txtLZXXSearch_WCRQMin
                    Me.txtLZXXSearch_WCRQMax.Text = .txtLZXXSearch_WCRQMax

                    Try
                        Me.grdLZXX.PageSize = .grdLZXXPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdLZXX.CurrentPageIndex = .grdLZXXCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdLZXX.SelectedIndex = .grdLZXXSelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowLzqk

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtLZXXQuery = Me.htxtLZXXQuery.Value
                    .htxtLZXXRows = Me.htxtLZXXRows.Value
                    .htxtLZXXSort = Me.htxtLZXXSort.Value
                    .htxtLZXXSortColumnIndex = Me.htxtLZXXSortColumnIndex.Value
                    .htxtLZXXSortType = Me.htxtLZXXSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftLZXX = Me.htxtDivLeftLZXX.Value
                    .htxtDivTopLZXX = Me.htxtDivTopLZXX.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtLZXXPageIndex = Me.txtLZXXPageIndex.Text
                    .txtLZXXPageSize = Me.txtLZXXPageSize.Text

                    .txtLZXXSearch_FSR = Me.txtLZXXSearch_FSR.Text
                    .txtLZXXSearch_JSR = Me.txtLZXXSearch_JSR.Text
                    .txtLZXXSearch_BLSY = Me.txtLZXXSearch_BLSY.Text
                    .txtLZXXSearch_WCRQMin = Me.txtLZXXSearch_WCRQMin.Text
                    .txtLZXXSearch_WCRQMax = Me.txtLZXXSearch_WCRQMax.Text

                    .grdLZXXPageSize = Me.grdLZXX.PageSize
                    .grdLZXXCurrentPageIndex = Me.grdLZXX.CurrentPageIndex
                    .grdLZXXSelectedIndex = Me.grdLZXX.SelectedIndex
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
                Dim objIFlowSpyj As Josco.JSOA.BusinessFacade.IFlowSpyj
                Try
                    objIFlowSpyj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowSpyj)
                Catch ex As Exception
                    objIFlowSpyj = Nothing
                End Try
                If Not (objIFlowSpyj Is Nothing) Then
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowSpyj.Dispose()
                    objIFlowSpyj = Nothing
                    Exit Try
                End If

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
                        Me.htxtLZXXQuery.Value = objISjcxCxtj.oQueryString
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowLzqk)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowLzqk)
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
                Me.m_intFixedColumns_LZXX = objPulicParameters.getObjectValue(Me.htxtLZXXFixed.Value, 0)
                Me.m_intRows_LZXX = objPulicParameters.getObjectValue(Me.htxtLZXXRows.Value, 0)
                Me.m_strQuery_LZXX = Me.htxtLZXXQuery.Value

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
        ' 获取grdLZXX的搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_LZXX( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess

            getQueryString_LZXX = False
            strQuery = ""

            Try
                '按“发送人”搜索
                Dim strFSR As String
                strFSR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSR
                If Me.txtLZXXSearch_FSR.Text.Length > 0 Then Me.txtLZXXSearch_FSR.Text = Me.txtLZXXSearch_FSR.Text.Trim()
                If Me.txtLZXXSearch_FSR.Text <> "" Then
                    Me.txtLZXXSearch_FSR.Text = objPulicParameters.getNewSearchString(Me.txtLZXXSearch_FSR.Text)
                    If strQuery = "" Then
                        strQuery = strFSR + " like '" + Me.txtLZXXSearch_FSR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strFSR + " like '" + Me.txtLZXXSearch_FSR.Text + "%'"
                    End If
                End If

                '按“接收人”搜索
                Dim strJSR As String
                strJSR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSR
                If Me.txtLZXXSearch_JSR.Text.Length > 0 Then Me.txtLZXXSearch_JSR.Text = Me.txtLZXXSearch_JSR.Text.Trim()
                If Me.txtLZXXSearch_JSR.Text <> "" Then
                    Me.txtLZXXSearch_JSR.Text = objPulicParameters.getNewSearchString(Me.txtLZXXSearch_JSR.Text)
                    If strQuery = "" Then
                        strQuery = strJSR + " like '" + Me.txtLZXXSearch_JSR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJSR + " like '" + Me.txtLZXXSearch_JSR.Text + "%'"
                    End If
                End If

                '按“办理事宜”搜索
                Dim strBLSY As String
                strBLSY = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZL
                If Me.txtLZXXSearch_BLSY.Text.Length > 0 Then Me.txtLZXXSearch_BLSY.Text = Me.txtLZXXSearch_BLSY.Text.Trim()
                If Me.txtLZXXSearch_BLSY.Text <> "" Then
                    Me.txtLZXXSearch_BLSY.Text = objPulicParameters.getNewSearchString(Me.txtLZXXSearch_BLSY.Text)
                    If strQuery = "" Then
                        strQuery = strBLSY + " like '" + Me.txtLZXXSearch_BLSY.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strBLSY + " like '" + Me.txtLZXXSearch_BLSY.Text + "%'"
                    End If
                End If

                '按“完成日期”搜索
                Dim strWCRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strWCRQ = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_WCRQ
                If Me.txtLZXXSearch_WCRQMin.Text.Length > 0 Then Me.txtLZXXSearch_WCRQMin.Text = Me.txtLZXXSearch_WCRQMin.Text.Trim()
                If Me.txtLZXXSearch_WCRQMax.Text.Length > 0 Then Me.txtLZXXSearch_WCRQMax.Text = Me.txtLZXXSearch_WCRQMax.Text.Trim()
                If Me.txtLZXXSearch_WCRQMin.Text <> "" And Me.txtLZXXSearch_WCRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtLZXXSearch_WCRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtLZXXSearch_WCRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtLZXXSearch_WCRQMin.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                        Me.txtLZXXSearch_WCRQMax.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    Else
                        Me.txtLZXXSearch_WCRQMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                        Me.txtLZXXSearch_WCRQMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    End If
                    If strQuery = "" Then
                        strQuery = strWCRQ + " between '" + Me.txtLZXXSearch_WCRQMin.Text + "' and '" + Me.txtLZXXSearch_WCRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " between '" + Me.txtLZXXSearch_WCRQMin.Text + "' and '" + Me.txtLZXXSearch_WCRQMax.Text + "'"
                    End If
                ElseIf Me.txtLZXXSearch_WCRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtLZXXSearch_WCRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    Me.txtLZXXSearch_WCRQMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strWCRQ + " >= '" + Me.txtLZXXSearch_WCRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " >= '" + Me.txtLZXXSearch_WCRQMin.Text + "'"
                    End If
                ElseIf Me.txtLZXXSearch_WCRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtLZXXSearch_WCRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    Me.txtLZXXSearch_WCRQMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strWCRQ + " <= '" + Me.txtLZXXSearch_WCRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " <= '" + Me.txtLZXXSearch_WCRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_LZXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdLZXX要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_LZXX( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

            getModuleData_LZXX = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtLZXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objDataSet_LZXX Is Nothing) Then
                    Me.m_objDataSet_LZXX.Dispose()
                    Me.m_objDataSet_LZXX = Nothing
                End If

                '重新检索数据
                If Me.m_objsystemFlowObject.getLZQKDataSet(strErrMsg, Me.m_objInterface.iBLR, strWhere, Me.m_objDataSet_LZXX) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_LZXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_LZXX.Tables(strTable)
                    Me.htxtLZXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_LZXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_LZXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdLZXX数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_LZXX(ByRef strErrMsg As String) As Boolean

            searchModuleData_LZXX = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_LZXX(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_LZXX(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_LZXX = strQuery
                Me.htxtLZXXQuery.Value = Me.m_strQuery_LZXX

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_LZXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdLZXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_LZXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_LZXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtLZXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtLZXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_LZXX Is Nothing Then
                    Me.grdLZXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_LZXX.Tables(strTable)
                        Me.grdLZXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_LZXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdLZXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdLZXX)
                    With Me.grdLZXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdLZXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdLZXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_LZXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_LZXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdLZXX及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_LZXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_LZXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_LZXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_LZXX.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblLZXXGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdLZXX, .Count)

                    '显示页面浏览功能
                    Me.lnkCZLZXXMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdLZXX, .Count)
                    Me.lnkCZLZXXMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdLZXX, .Count)
                    Me.lnkCZLZXXMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdLZXX, .Count)
                    Me.lnkCZLZXXMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdLZXX, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZLZXXDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZLZXXSelectAll.Enabled = blnEnabled
                    Me.lnkCZLZXXGotoPage.Enabled = blnEnabled
                    Me.lnkCZLZXXSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_LZXX = True
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
                    objControlProcess.doTranslateKey(Me.txtLZXXPageIndex)
                    objControlProcess.doTranslateKey(Me.txtLZXXPageSize)
                    objControlProcess.doTranslateKey(Me.txtLZXXSearch_FSR)
                    objControlProcess.doTranslateKey(Me.txtLZXXSearch_JSR)
                    objControlProcess.doTranslateKey(Me.txtLZXXSearch_BLSY)
                    objControlProcess.doTranslateKey(Me.txtLZXXSearch_WCRQMin)
                    objControlProcess.doTranslateKey(Me.txtLZXXSearch_WCRQMax)
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '显示模块级操作
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示数据
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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
                    If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了文件[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]的[文件流转情况]！") = False Then
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
        '实现对grdLZXX网格行、列的固定
        Sub grdLZXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdLZXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_LZXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_LZXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_LZXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdLZXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdLZXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdLZXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblLZXXGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdLZXX, Me.m_intRows_LZXX)
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

        Private Sub grdLZXX_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdLZXX.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

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
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_LZXX.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_LZXX.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtLZXXSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtLZXXSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtLZXXSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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




        Private Sub doMoveFirst_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdLZXX.PageCount)
                Me.grdLZXX.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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

        Private Sub doMoveLast_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdLZXX.PageCount - 1, Me.grdLZXX.PageCount)
                Me.grdLZXX.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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

        Private Sub doMoveNext_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdLZXX.CurrentPageIndex + 1, Me.grdLZXX.PageCount)
                Me.grdLZXX.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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

        Private Sub doMovePrevious_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdLZXX.CurrentPageIndex - 1, Me.grdLZXX.PageCount)
                Me.grdLZXX.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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

        Private Sub doGotoPage_LZXX(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtLZXXPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdLZXX.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_LZXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtLZXXPageIndex.Text = (Me.grdLZXX.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_LZXX(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtLZXXPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdLZXX.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_LZXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtLZXXPageSize.Text = (Me.grdLZXX.PageSize).ToString()

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

        Private Sub doSelectAll_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdLZXX, 0, Me.m_cstrCheckBoxIdInDataGrid_LZXX, True) = False Then
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

        Private Sub doDeSelectAll_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdLZXX, 0, Me.m_cstrCheckBoxIdInDataGrid_LZXX, False) = False Then
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

        Private Sub doSearch_LZXX(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_LZXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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

        Private Sub lnkCZLZXXMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXMoveFirst.Click
            Me.doMoveFirst_LZXX("lnkCZLZXXMoveFirst")
        End Sub

        Private Sub lnkCZLZXXMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXMoveLast.Click
            Me.doMoveLast_LZXX("lnkCZLZXXMoveLast")
        End Sub

        Private Sub lnkCZLZXXMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXMoveNext.Click
            Me.doMoveNext_LZXX("lnkCZLZXXMoveNext")
        End Sub

        Private Sub lnkCZLZXXMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXMovePrev.Click
            Me.doMovePrevious_LZXX("lnkCZLZXXMovePrev")
        End Sub

        Private Sub lnkCZLZXXGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXGotoPage.Click
            Me.doGotoPage_LZXX("lnkCZLZXXGotoPage")
        End Sub

        Private Sub lnkCZLZXXSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXSetPageSize.Click
            Me.doSetPageSize_LZXX("lnkCZLZXXSetPageSize")
        End Sub

        Private Sub lnkCZLZXXSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXSelectAll.Click
            Me.doSelectAll_LZXX("lnkCZLZXXSelectAll")
        End Sub

        Private Sub lnkCZLZXXDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXDeSelectAll.Click
            Me.doDeSelectAll_LZXX("lnkCZLZXXDeSelectAll")
        End Sub

        Private Sub btnLZXXSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLZXXSearch.Click
            Me.doSearch_LZXX("btnLZXXSearch")
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

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

            Try
                '获取数据
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
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
                    .iQueryTable = Me.m_objDataSet_LZXX.Tables(strTable)
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

        Private Sub doChakanSPYJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Try
                '获取接收人
                Dim intColIndex As Integer = 0
                Dim strJSR As String = ""
                If Me.grdLZXX.Items.Count > 0 Then
                    If Me.grdLZXX.SelectedIndex >= 0 Then
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdLZXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSR)
                        strJSR = objDataGridProcess.getDataGridCellValue(Me.grdLZXX.Items(Me.grdLZXX.SelectedIndex), intColIndex)
                    End If
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowSpyj As Josco.JSOA.BusinessFacade.IFlowSpyj
                Dim strUrl As String
                objIFlowSpyj = New Josco.JSOA.BusinessFacade.IFlowSpyj
                With objIFlowSpyj
                    .iFlowTypeName = Me.m_objInterface.iFlowTypeName
                    .iWJBS = Me.m_objInterface.iWJBS
                    .iBLR = Me.m_objInterface.iBLR
                    .iSPR = strJSR

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
                Session.Add(strNewSessionId, objIFlowSpyj)
                strUrl = ""
                strUrl += "flow_spyj.aspx"
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
            Exit Sub

        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.doSearchFull("btnSearch")
        End Sub

        Private Sub btnCKYJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCKYJ.Click
            Me.doChakanSPYJ("btnCKYJ")
        End Sub

    End Class

End Namespace
