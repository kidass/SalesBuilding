Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_xgwjlj_add
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理文件附件的增加、修改、删除、查看、导出等操作
    '
    ' 接口参数：
    '     参见接口类IFlowFujian描述
    '----------------------------------------------------------------

    Public Class flow_xgwjlj_add
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILESelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtFILEPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZFILESetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtFILEPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblFILEGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents txtFILESearch_NDMIN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFILESearch_NDMAX As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFILESearch_LSH As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFILESearch_WJBT As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFILESearch_WJZH As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFILESearch_ZBDW As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnFILEFullSearch As System.Web.UI.WebControls.Button
        Protected WithEvents btnFILESearch As System.Web.UI.WebControls.Button
        Protected WithEvents grdFILE As System.Web.UI.WebControls.DataGrid
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtFILEFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFILEQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFILERows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFILESort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFILESortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFILESortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftFILE As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopFILE As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents btnOK As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents btnOpenFile As System.Web.UI.WebControls.Button
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowXgwjljAdd
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowXgwjljAdd
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_FILE As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_FILE As String '记录m_objDataSet_FILE搜索串
        Private m_intRows_FILE As Integer '记录m_objDataSet_FILE的DefaultView记录数

        '----------------------------------------------------------------
        '与数据网格grdFILE相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_FILE As String = "chkFILE"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_FILE As String = "divFILE"
        '网格要锁定的列数
        Private m_intFixedColumns_FILE As Integer

        '----------------------------------------------------------------
        '模块其他参数
        '----------------------------------------------------------------









        '----------------------------------------------------------------
        ' 复原模块现场信息并释放相应的资源
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    '*********************************************************************
                    Me.txtFILEPageIndex.Text = .txtFILEPageIndex
                    Me.txtFILEPageSize.Text = .txtFILEPageSize
                    '*********************************************************************
                    Me.txtFILESearch_NDMIN.Text = .txtFILESearch_NDMIN
                    Me.txtFILESearch_NDMAX.Text = .txtFILESearch_NDMAX
                    Me.txtFILESearch_LSH.Text = .txtFILESearch_LSH
                    Me.txtFILESearch_WJBT.Text = .txtFILESearch_WJBT
                    Me.txtFILESearch_WJZH.Text = .txtFILESearch_WJZH
                    Me.txtFILESearch_ZBDW.Text = .txtFILESearch_ZBDW
                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery
                    '*********************************************************************
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftFILE.Value = .htxtDivLeftFILE
                    Me.htxtDivTopFILE.Value = .htxtDivTopFILE
                    '*********************************************************************
                    Me.htxtFILEQuery.Value = .htxtFILEQuery
                    Me.htxtFILERows.Value = .htxtFILERows
                    Me.htxtFILESort.Value = .htxtFILESort
                    Me.htxtFILESortColumnIndex.Value = .htxtFILESortColumnIndex
                    Me.htxtFILESortType.Value = .htxtFILESortType
                    '*********************************************************************
                    Try
                        Me.grdFILE.PageSize = .grdFILE_PageSize
                        Me.grdFILE.SelectedIndex = .grdFILE_SelectedIndex
                        Me.grdFILE.CurrentPageIndex = .grdFILE_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    '*********************************************************************
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowXgwjljAdd

                '保存现场信息
                With Me.m_objSaveScence
                    '*********************************************************************
                    .txtFILEPageIndex = Me.txtFILEPageIndex.Text
                    .txtFILEPageSize = Me.txtFILEPageSize.Text
                    '*********************************************************************
                    .txtFILESearch_NDMIN = Me.txtFILESearch_NDMIN.Text
                    .txtFILESearch_NDMAX = Me.txtFILESearch_NDMAX.Text
                    .txtFILESearch_LSH = Me.txtFILESearch_LSH.Text
                    .txtFILESearch_WJBT = Me.txtFILESearch_WJBT.Text
                    .txtFILESearch_WJZH = Me.txtFILESearch_WJZH.Text
                    .txtFILESearch_ZBDW = Me.txtFILESearch_ZBDW.Text
                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value
                    '*********************************************************************
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftFILE = Me.htxtDivLeftFILE.Value
                    .htxtDivTopFILE = Me.htxtDivTopFILE.Value
                    '*********************************************************************
                    .htxtFILEQuery = Me.htxtFILEQuery.Value
                    .htxtFILERows = Me.htxtFILERows.Value
                    .htxtFILESort = Me.htxtFILESort.Value
                    .htxtFILESortColumnIndex = Me.htxtFILESortColumnIndex.Value
                    .htxtFILESortType = Me.htxtFILESortType.Value
                    '*********************************************************************
                    .grdFILE_PageSize = Me.grdFILE.PageSize
                    .grdFILE_SelectedIndex = Me.grdFILE.SelectedIndex
                    .grdFILE_CurrentPageIndex = Me.grdFILE.CurrentPageIndex
                    '*********************************************************************
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.IsPostBack = True Then Exit Try

                '=================================================================
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                        Me.htxtFILEQuery.Value = objISjcxCxtj.oQueryString
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowXgwjljAdd)
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

                '初始化工作流对象
                If Me.doInitializeWorkflow(strErrMsg) = False Then
                    GoTo errProc
                End If

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowXgwjljAdd)
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
                Me.m_intFixedColumns_FILE = objPulicParameters.getObjectValue(Me.htxtFILEFixed.Value, 0)
                Me.m_intRows_FILE = objPulicParameters.getObjectValue(Me.htxtFILERows.Value, 0)
                Me.m_strQuery_FILE = Me.htxtFILEQuery.Value

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
                    Me.htxtSessionIdQuery.Value = ""
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

                '初始化工作流
                Dim strWJBS As String = Me.m_objInterface.iWJBS
                If Me.m_objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
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
        ' 获取附件信息数据集
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_FILE( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            getModuleData_FILE = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtFILESort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '获取数据
                If Not (Me.m_objDataSet_FILE Is Nothing) Then
                    Me.m_objDataSet_FILE.Dispose()
                    Me.m_objDataSet_FILE = Nothing
                End If
                If Me.m_objsystemFlowObject.getWorkflowFileData(strErrMsg, MyBase.UserXM, strWhere, Me.m_objDataSet_FILE) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_FILE.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_FILE.Tables(strTable)
                    Me.htxtFILERows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_FILE = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_FILE = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdFILE的搜索条件(RowFilter格式)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_FILE( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_FILE = False
            strQuery = ""

            Try
                '按年度搜索
                Dim strFWJND As String
                Dim intMin As Integer
                Dim intMax As Integer
                strFWJND = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJND
                If Me.txtFILESearch_NDMIN.Text.Length > 0 Then Me.txtFILESearch_NDMIN.Text = Me.txtFILESearch_NDMIN.Text.Trim()
                If Me.txtFILESearch_NDMAX.Text.Length > 0 Then Me.txtFILESearch_NDMAX.Text = Me.txtFILESearch_NDMAX.Text.Trim()
                If Me.txtFILESearch_NDMIN.Text <> "" And Me.txtFILESearch_NDMAX.Text <> "" Then
                    Try
                        intMin = CType(Me.txtFILESearch_NDMIN.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "错误：[" + Me.txtFILESearch_NDMIN.Text + "]不是有效数字！"
                        GoTo errProc
                    End Try
                    Try
                        intMax = CType(Me.txtFILESearch_NDMAX.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "错误：[" + Me.txtFILESearch_NDMAX.Text + "]不是有效数字！"
                        GoTo errProc
                    End Try
                    If intMin > intMax Then
                        Me.txtFILESearch_NDMIN.Text = intMax.ToString
                        Me.txtFILESearch_NDMAX.Text = intMin.ToString
                    Else
                        Me.txtFILESearch_NDMIN.Text = intMin.ToString
                        Me.txtFILESearch_NDMAX.Text = intMax.ToString
                    End If
                    If strQuery = "" Then
                        strQuery = strFWJND + " between " + Me.txtFILESearch_NDMIN.Text + " and " + Me.txtFILESearch_NDMAX.Text
                    Else
                        strQuery = strQuery + " and " + strFWJND + " between " + Me.txtFILESearch_NDMIN.Text + " and " + Me.txtFILESearch_NDMAX.Text
                    End If
                ElseIf Me.txtFILESearch_NDMIN.Text <> "" Then
                    Try
                        intMin = CType(Me.txtFILESearch_NDMIN.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "错误：[" + Me.txtFILESearch_NDMIN.Text + "]不是有效数字！"
                        GoTo errProc
                    End Try
                    Me.txtFILESearch_NDMIN.Text = intMin.ToString
                    If strQuery = "" Then
                        strQuery = strFWJND + " >= " + Me.txtFILESearch_NDMIN.Text
                    Else
                        strQuery = strQuery + " and " + strFWJND + " >= " + Me.txtFILESearch_NDMIN.Text
                    End If
                ElseIf Me.txtFILESearch_NDMAX.Text <> "" Then
                    Try
                        intMax = CType(Me.txtFILESearch_NDMAX.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "错误：[" + Me.txtFILESearch_NDMAX.Text + "]不是有效数字！"
                        GoTo errProc
                    End Try
                    Me.txtFILESearch_NDMAX.Text = intMax.ToString
                    If strQuery = "" Then
                        strQuery = strFWJND + " <= " + Me.txtFILESearch_NDMAX.Text
                    Else
                        strQuery = strQuery + " and " + strFWJND + " <= " + Me.txtFILESearch_NDMAX.Text
                    End If
                Else
                End If

                '按流水号搜索
                Dim strLSH As String
                strLSH = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_LSH
                If Me.txtFILESearch_LSH.Text.Length > 0 Then Me.txtFILESearch_LSH.Text = Me.txtFILESearch_LSH.Text.Trim()
                If Me.txtFILESearch_LSH.Text <> "" Then
                    'Me.txtFILESearch_LSH.Text = objPulicParameters.getNewSearchString(Me.txtFILESearch_LSH.Text)
                    If strQuery = "" Then
                        strQuery = strLSH + " like '" + Me.txtFILESearch_LSH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strLSH + " like '" + Me.txtFILESearch_LSH.Text + "%'"
                    End If
                End If

                '按文件标题搜索
                Dim strWJBT As String
                strWJBT = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBT
                If Me.txtFILESearch_WJBT.Text.Length > 0 Then Me.txtFILESearch_WJBT.Text = Me.txtFILESearch_WJBT.Text.Trim()
                If Me.txtFILESearch_WJBT.Text <> "" Then
                    Me.txtFILESearch_WJBT.Text = objPulicParameters.getNewSearchString(Me.txtFILESearch_WJBT.Text)
                    If strQuery = "" Then
                        strQuery = strWJBT + " like '" + Me.txtFILESearch_WJBT.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWJBT + " like '" + Me.txtFILESearch_WJBT.Text + "%'"
                    End If
                End If

                '按文件字号搜索
                Dim strWJZH As String
                strWJZH = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJZH
                If Me.txtFILESearch_WJZH.Text.Length > 0 Then Me.txtFILESearch_WJZH.Text = Me.txtFILESearch_WJZH.Text.Trim()
                If Me.txtFILESearch_WJZH.Text <> "" Then
                    'Me.txtFILESearch_WJZH.Text = objPulicParameters.getNewSearchString(Me.txtFILESearch_WJZH.Text)
                    If strQuery = "" Then
                        strQuery = strWJZH + " like '" + Me.txtFILESearch_WJZH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWJZH + " like '" + Me.txtFILESearch_WJZH.Text + "%'"
                    End If
                End If

                '按主办单位搜索
                Dim strZBDW As String
                strZBDW = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_ZSDW
                If Me.txtFILESearch_ZBDW.Text.Length > 0 Then Me.txtFILESearch_ZBDW.Text = Me.txtFILESearch_ZBDW.Text.Trim()
                If Me.txtFILESearch_ZBDW.Text <> "" Then
                    'Me.txtFILESearch_ZBDW.Text = objPulicParameters.getNewSearchString(Me.txtFILESearch_ZBDW.Text)
                    If strQuery = "" Then
                        strQuery = strZBDW + " like '" + Me.txtFILESearch_ZBDW.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strZBDW + " like '" + Me.txtFILESearch_ZBDW.Text + "%'"
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_FILE = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdFILE数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_FILE(ByRef strErrMsg As String) As Boolean

            searchModuleData_FILE = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_FILE(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_FILE(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_FILE = strQuery
                Me.htxtFILEQuery.Value = Me.m_strQuery_FILE

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_FILE = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdFILE的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_FILE( _
            ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            showDataGridInfo_FILE = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtFILESortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtFILESortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_FILE Is Nothing Then
                    Me.grdFILE.DataSource = Nothing
                Else
                    With Me.m_objDataSet_FILE.Tables(strTable)
                        Me.grdFILE.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_FILE.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdFILE, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdFILE)
                    With Me.grdFILE.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdFILE.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdFILE, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_FILE) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_FILE = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdFILE及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_FILE(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            showModuleData_FILE = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_FILE.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblFILEGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdFILE, .Count)

                    '显示页面浏览功能
                    Me.lnkCZFILEMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdFILE, .Count)
                    Me.lnkCZFILEMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdFILE, .Count)
                    Me.lnkCZFILEMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdFILE, .Count)
                    Me.lnkCZFILEMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdFILE, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZFILEDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZFILESelectAll.Enabled = blnEnabled
                    Me.lnkCZFILEGotoPage.Enabled = blnEnabled
                    Me.lnkCZFILESetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_FILE = True
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
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String) As Boolean

            showModuleData_Main = False

            Try
                '显示网格
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示命令

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

                    '执行键转译(不论是否是“回发”)
                    '****************************************************************
                    objControlProcess.doTranslateKey(Me.txtFILEPageIndex)
                    objControlProcess.doTranslateKey(Me.txtFILEPageSize)
                    '****************************************************************
                    objControlProcess.doTranslateKey(Me.txtFILESearch_NDMIN)
                    objControlProcess.doTranslateKey(Me.txtFILESearch_NDMAX)
                    objControlProcess.doTranslateKey(Me.txtFILESearch_LSH)
                    objControlProcess.doTranslateKey(Me.txtFILESearch_WJBT)
                    objControlProcess.doTranslateKey(Me.txtFILESearch_WJZH)
                    objControlProcess.doTranslateKey(Me.txtFILESearch_ZBDW)
                    '****************************************************************

                    '显示数据
                    If Me.m_blnSaveScence = False Then
                        '缺省最近2年文件
                        Me.txtFILESearch_NDMIN.Text = (Year(Now) - 1).ToString
                        Me.txtFILESearch_NDMAX.Text = Year(Now).ToString
                        If Me.searchModuleData_FILE(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                            GoTo errProc
                        End If
                    End If
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




        '----------------------------------------------------------------
        '网格事件处理器
        '----------------------------------------------------------------
        '实现对grdFILE网格行、列的固定
        Sub grdFILE_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdFILE.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_FILE + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_FILE > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_FILE - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdFILE.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 打开文件
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doOpenFile( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim strISessionId As String = ""
            Dim strMSessionId As String = ""
            Dim strUrl As String

            doOpenFile = False

            Try
                '检查当前选择
                If Me.grdFILE.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If

                '获取文件标识和文件类型
                Dim strFlowTypeName As String
                Dim strWJBS As String
                Dim intColIndex(2) As Integer
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBS)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJLX)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(Me.grdFILE.SelectedIndex), intColIndex(0))
                strFlowTypeName = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(Me.grdFILE.SelectedIndex), intColIndex(1))
                If strWJBS = "" Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If
                If strFlowTypeName = "" Then
                    strErrMsg = "错误：当前文件类型不明确！"
                    GoTo errProc
                End If
                If strWJBS.ToUpper = Me.m_objInterface.iWJBS Then
                    strErrMsg = "错误：不能打开文件本身！"
                    GoTo errProc
                End If

                '创建指定工作流对象
                Dim strType As String
                Dim strName As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If
                strISessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)

                '计算Url
                If objsystemFlowObject.doFileOpen( _
                    strErrMsg, _
                    strControlId, _
                    strWJBS, _
                    strMSessionId, _
                    strISessionId, _
                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect, _
                    Request, Session, _
                    strUrl) = False Then
                    GoTo errProc
                End If
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doOpenFile = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Sub grdFILE_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFILE.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdFILE.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        If Me.doOpenFile(strErrMsg, strControlId) = False Then
                            GoTo errProc
                        End If
                    Case Else
                End Select

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

        Private Sub grdFILE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFILE.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                With New Josco.JsKernal.web.DataGridProcess
                    Me.lblFILEGridLocInfo.Text = .getDataGridLocation(Me.grdFILE, Me.m_intRows_FILE)
                End With
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

        Private Sub grdFILE_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdFILE.SortCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String
                Dim strOldCommand As String
                Dim strUniqueId As String
                Dim intColumnIndex As Integer

                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_FILE.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_FILE.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtFILESortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtFILESortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtFILESort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_FILE(strErrMsg) = False Then
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




        Private Sub doMoveFirst_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
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

        Private Sub doMoveLast_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFILE.PageCount - 1, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
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

        Private Sub doMoveNext_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFILE.CurrentPageIndex + 1, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
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

        Private Sub doMovePrevious_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFILE.CurrentPageIndex - 1, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
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

        Private Sub doGotoPage_FILE(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtFILEPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdFILE.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtFILEPageIndex.Text = (Me.grdFILE.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_FILE(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtFILEPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdFILE.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtFILEPageSize.Text = (Me.grdFILE.PageSize).ToString()

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

        Private Sub doSelectAll_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdFILE, 0, Me.m_cstrCheckBoxIdInDataGrid_FILE, True) = False Then
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

        Private Sub doDeSelectAll_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdFILE, 0, Me.m_cstrCheckBoxIdInDataGrid_FILE, False) = False Then
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

        Private Sub doSearch_FILE(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
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

        Private Sub doSearchFull_FILE(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
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
                    .iQueryTable = Me.m_objDataSet_FILE.Tables(strTable)
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

        Private Sub lnkCZFILEMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMoveFirst.Click
            Me.doMoveFirst_FILE("lnkCZFILEMoveFirst")
        End Sub

        Private Sub lnkCZFILEMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMoveLast.Click
            Me.doMoveLast_FILE("lnkCZFILEMoveLast")
        End Sub

        Private Sub lnkCZFILEMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMovePrev.Click
            Me.doMovePrevious_FILE("lnkCZFILEMovePrev")
        End Sub

        Private Sub lnkCZFILEMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMoveNext.Click
            Me.doMoveNext_FILE("lnkCZFILEMoveNext")
        End Sub

        Private Sub lnkCZFILESetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILESetPageSize.Click
            Me.doSetPageSize_FILE("lnkCZFILESetPageSize")
        End Sub

        Private Sub lnkCZFILEGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEGotoPage.Click
            Me.doGotoPage_FILE("lnkCZFILEGotoPage")
        End Sub

        Private Sub lnkCZFILESelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILESelectAll.Click
            Me.doSelectAll_FILE("lnkCZFILESelectAll")
        End Sub

        Private Sub lnkCZFILEDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEDeSelectAll.Click
            Me.doDeSelectAll_FILE("lnkCZFILEDeSelectAll")
        End Sub

        Private Sub btnFILESearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFILESearch.Click
            Me.doSearch_FILE("btnFILESearch")
        End Sub

        Private Sub btnFILEFullSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFILEFullSearch.Click
            Me.doSearchFull_FILE("btnFILEFullSearch")
        End Sub




        Private Sub doOK(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Try
                '检查是否选择了？
                Dim blnSelected As Boolean
                Dim intSelected As Integer
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdFILE.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE)
                    If blnSelected = True Then
                        intSelected += 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "错误：未选择要加入到链接中的文件！"
                    GoTo errProc
                End If

                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '加入到链接中
                Dim intLJBS As Integer = Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FlowFile
                Dim objSrcDataRow As System.Data.DataRow
                Dim objDataRow As System.Data.DataRow
                Dim strNewFilter As String
                Dim strOldFilter As String
                Dim intMaxXSXH As Integer
                Dim strNewWJBS As String
                Dim strOldWJBS As String
                Dim intColIndex As Integer
                Dim intRecPos As Integer
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBS)
                intCount = Me.grdFILE.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE)
                    If blnSelected = True Then
                        '获取要加入的文件标识
                        strNewWJBS = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex)
                        If strNewWJBS.ToUpper <> Me.m_objInterface.iWJBS.ToUpper Then
                            '判断是否存在
                            With Me.m_objInterface.iDataSet_XGWJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN)
                                '备份原过滤条件
                                strOldFilter = .DefaultView.RowFilter

                                '搜索
                                strNewFilter = ""
                                strNewFilter = strNewFilter + "     " + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBS + "='" + strNewWJBS + "'"
                                strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS + "= " + intLJBS.ToString
                                .DefaultView.RowFilter = strNewFilter
                                If .DefaultView.Count > 0 Then
                                    blnSelected = True
                                Else
                                    blnSelected = False
                                End If

                                '恢复过滤条件
                                .DefaultView.RowFilter = strOldFilter
                            End With
                        Else
                            blnSelected = True '自己不能加入！
                        End If

                        '加入到链接中
                        With Me.m_objInterface.iDataSet_XGWJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN)
                            If blnSelected = False Then
                                intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdFILE.CurrentPageIndex, Me.grdFILE.PageSize)
                                With Me.m_objDataSet_FILE.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW).DefaultView
                                    objSrcDataRow = .Item(intRecPos).Row
                                End With

                                If .DefaultView.Count < 1 Then
                                    intMaxXSXH = 0
                                Else
                                    intMaxXSXH = objPulicParameters.getObjectValue(.DefaultView.Item(.DefaultView.Count - 1).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH), 0)
                                End If

                                objDataRow = .NewRow

                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS) = intLJBS
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH) = intMaxXSXH + 1
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJXH) = 0
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS) = 0
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ) = ""
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = ""
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XZBZ) = 0
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBS) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBS)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LSH) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_LSH)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJLX) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJLX)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BLLX) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_BLLX)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJZL) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJZL)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BLZT) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_BLZT)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBT)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_ZSDW) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_ZSDW)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_JGDZ) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_JGDZ)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJNF) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJNF)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJXH) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJXH)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJND) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJND)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_ZBDW) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_ZBDW)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_ZTC) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_ZTC)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_NGR) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_NGR)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_NGRQ) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_NGRQ)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_KSSW) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_KSSW)

                                .Rows.Add(objDataRow)
                            End If
                        End With
                    End If
                Next

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

        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
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

        Private Sub doOpenFile(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doOpenFile(strErrMsg, strControlId) = False Then
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

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnOpenFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpenFile.Click
            Me.doOpenFile("btnOpenFile")
        End Sub

    End Class

End Namespace
