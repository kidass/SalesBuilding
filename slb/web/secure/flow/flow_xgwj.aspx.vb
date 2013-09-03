Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_xgwj
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理文件相关链接的增加、修改、删除、查看、导出等操作
    '
    ' 接口参数：
    '     参见接口类IFlowXgwj描述
    '----------------------------------------------------------------

    Public Class flow_xgwj
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkMLAddNewWJ As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLAddNew As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLModify As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLSelect As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLMoveUp As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLMoveDn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLAutoXH As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLExport As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLClose As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtXGWJPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZXGWJSetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtXGWJPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblXGWJGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdXGWJ As System.Web.UI.WebControls.DataGrid
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents htxtXGWJFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtXGWJQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtXGWJRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtXGWJSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtXGWJSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtXGWJSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftXGWJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopXGWJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden
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
        '本模块相对image的相对路径
        Private m_cstrRelativePathToImage As String = "../../"
        '文件下载后的缓存路径
        Private m_cstrUrlBaseToFileCache As String = "/temp/filecache/"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowXgwj
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowXgwj
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objDataSet_XGWJ As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_XGWJ As String '记录m_objDataSet_XGWJ搜索串
        Private m_intRows_XGWJ As Integer '记录m_objDataSet_XGWJ的DefaultView记录数

        '----------------------------------------------------------------
        '与数据网格grdXGWJ相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_XGWJ As String = "chkXGWJ"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_XGWJ As String = "divXGWJ"
        '网格要锁定的列数
        Private m_intFixedColumns_XGWJ As Integer

        '----------------------------------------------------------------
        '模块其他参数
        '----------------------------------------------------------------
        '工作流类型名称
        Private m_strFlowTypeName As String
        '编辑模式
        Private m_blnEditMode As Boolean
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
                    '*********************************************************************
                    Me.txtXGWJPageIndex.Text = .txtXGWJPageIndex
                    Me.txtXGWJPageSize.Text = .txtXGWJPageSize
                    '*********************************************************************
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftXGWJ.Value = .htxtDivLeftXGWJ
                    Me.htxtDivTopXGWJ.Value = .htxtDivTopXGWJ
                    '*********************************************************************
                    Me.htxtXGWJQuery.Value = .htxtXGWJQuery
                    Me.htxtXGWJRows.Value = .htxtXGWJRows
                    Me.htxtXGWJSort.Value = .htxtXGWJSort
                    Me.htxtXGWJSortColumnIndex.Value = .htxtXGWJSortColumnIndex
                    Me.htxtXGWJSortType.Value = .htxtXGWJSortType
                    '*********************************************************************
                    Me.m_objDataSet_XGWJ = .objDataSet_XGWJ
                    '*********************************************************************
                    Try
                        Me.grdXGWJ.PageSize = .grdXGWJ_PageSize
                        Me.grdXGWJ.SelectedIndex = .grdXGWJ_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowXgwj

                '保存现场信息
                With Me.m_objSaveScence
                    '*********************************************************************
                    .txtXGWJPageIndex = Me.txtXGWJPageIndex.Text
                    .txtXGWJPageSize = Me.txtXGWJPageSize.Text
                    '*********************************************************************
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftXGWJ = Me.htxtDivLeftXGWJ.Value
                    .htxtDivTopXGWJ = Me.htxtDivTopXGWJ.Value
                    '*********************************************************************
                    .htxtXGWJQuery = Me.htxtXGWJQuery.Value
                    .htxtXGWJRows = Me.htxtXGWJRows.Value
                    .htxtXGWJSort = Me.htxtXGWJSort.Value
                    .htxtXGWJSortColumnIndex = Me.htxtXGWJSortColumnIndex.Value
                    .htxtXGWJSortType = Me.htxtXGWJSortType.Value
                    '*********************************************************************
                    .objDataSet_XGWJ = Me.m_objDataSet_XGWJ
                    '*********************************************************************
                    .grdXGWJ_PageSize = Me.grdXGWJ.PageSize
                    .grdXGWJ_SelectedIndex = Me.grdXGWJ.SelectedIndex
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

            Dim intXZBZ As Integer = Josco.JSOA.Common.Data.FlowData.enumFileDownloadStatus.HasDownload
            Dim intLBBS As Integer = Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FujianFile
            Dim objDataRow As System.Data.DataRow

            Try
                If Me.IsPostBack = True Then Exit Try

                '=================================================================
                Dim objIFlowXgwjljAdd As Josco.JSOA.BusinessFacade.IFlowXgwjljAdd
                Try
                    objIFlowXgwjljAdd = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowXgwjljAdd)
                Catch ex As Exception
                    objIFlowXgwjljAdd = Nothing
                End Try
                If Not (objIFlowXgwjljAdd Is Nothing) Then
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowXgwjljAdd.Dispose()
                    objIFlowXgwjljAdd = Nothing
                    Exit Try
                End If

                '=================================================================
                Dim objIFlowXgwjfjInfo As Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
                Try
                    objIFlowXgwjfjInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo)
                Catch ex As Exception
                    objIFlowXgwjfjInfo = Nothing
                End Try
                If Not (objIFlowXgwjfjInfo Is Nothing) Then
                    If objIFlowXgwjfjInfo.oExitMode = True Then
                        '返回参数处理
                        With Me.m_objInterface.iDataSet_XGWJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN)
                            Select Case objIFlowXgwjfjInfo.iEditType
                                Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                    objDataRow = .NewRow()
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH) = objPulicParameters.getObjectValue(objIFlowXgwjfjInfo.oWJXH, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS) = objPulicParameters.getObjectValue(objIFlowXgwjfjInfo.oWJYS, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = objIFlowXgwjfjInfo.oBDWJ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ) = objIFlowXgwjfjInfo.oWJWZ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT) = objIFlowXgwjfjInfo.oWJSM
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XZBZ) = intXZBZ.ToString()
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS) = intLBBS.ToString()
                                    .Rows.Add(objDataRow)
                                Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                    objDataRow = objIFlowXgwjfjInfo.iRow
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS) = objPulicParameters.getObjectValue(objIFlowXgwjfjInfo.oWJYS, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ) = objIFlowXgwjfjInfo.oWJWZ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT) = objIFlowXgwjfjInfo.oWJSM
                                    If objIFlowXgwjfjInfo.oBDWJ <> "" Then
                                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = objIFlowXgwjfjInfo.oBDWJ
                                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XZBZ) = intXZBZ.ToString()
                                    End If
                            End Select
                        End With
                    End If
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowXgwjfjInfo.Dispose()
                    objIFlowXgwjfjInfo = Nothing
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowXgwj)
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

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowXgwj)
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
                Me.m_intFixedColumns_XGWJ = objPulicParameters.getObjectValue(Me.htxtXGWJFixed.Value, 0)
                Me.m_intRows_XGWJ = objPulicParameters.getObjectValue(Me.htxtXGWJRows.Value, 0)
                Me.m_strQuery_XGWJ = Me.htxtXGWJQuery.Value

                Me.m_strFlowTypeName = Me.m_objInterface.iFlowTypeName
                Me.m_blnEditMode = Me.m_objInterface.iEditMode
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
        ' 获取附件信息数据集
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_XGWJ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            getModuleData_XGWJ = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtXGWJSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '获取数据
                Me.m_objDataSet_XGWJ = Me.m_objInterface.iDataSet_XGWJ

                '恢复Sort字符串
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    .DefaultView.Sort = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH + " asc" '缺省排序，不能改变
                    .DefaultView.RowFilter = strWhere
                End With

                '缓存参数
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    Me.htxtXGWJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_XGWJ = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_XGWJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdXGWJ的搜索条件(RowFilter格式)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_XGWJ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_XGWJ = False
            strQuery = ""

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_XGWJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdXGWJ数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_XGWJ(ByRef strErrMsg As String) As Boolean

            searchModuleData_XGWJ = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_XGWJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_XGWJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_XGWJ = strQuery
                Me.htxtXGWJQuery.Value = Me.m_strQuery_XGWJ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_XGWJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdXGWJ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_XGWJ( _
            ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            showDataGridInfo_XGWJ = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtXGWJSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtXGWJSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_XGWJ Is Nothing Then
                    Me.grdXGWJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_XGWJ.Tables(strTable)
                        Me.grdXGWJ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdXGWJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdXGWJ)
                    With Me.grdXGWJ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdXGWJ.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                'LJ 2008-07-30
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdXGWJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_XGWJ) = False Then
                '    GoTo errProc
                'End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_XGWJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdXGWJ及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_XGWJ(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            showModuleData_XGWJ = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_XGWJ.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblXGWJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdXGWJ, .Count)

                    '显示页面浏览功能
                    Me.lnkCZXGWJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdXGWJ, .Count)
                    Me.lnkCZXGWJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdXGWJ, .Count)
                    Me.lnkCZXGWJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdXGWJ, .Count)
                    Me.lnkCZXGWJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdXGWJ, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZXGWJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZXGWJSelectAll.Enabled = blnEnabled
                    Me.lnkCZXGWJGotoPage.Enabled = blnEnabled
                    Me.lnkCZXGWJSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_XGWJ = True
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
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            showModuleData_Main = False

            Try
                '显示网格
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示命令
                Me.lnkMLAddNewWJ.Enabled = blnEditMode
                Me.lnkMLAddNew.Enabled = blnEditMode
                Me.lnkMLModify.Enabled = blnEditMode
                Me.lnkMLDelete.Enabled = blnEditMode
                Me.lnkMLMoveUp.Enabled = blnEditMode
                Me.lnkMLMoveDn.Enabled = blnEditMode
                Me.lnkMLAutoXH.Enabled = blnEditMode

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

            initializeControls = False

            Try
                '仅在第一次调用页面时执行
                If Me.IsPostBack = False Then
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    With New Josco.JsKernal.web.ControlProcess
                        '***********************************************
                        .doTranslateKey(Me.txtXGWJPageIndex)
                        .doTranslateKey(Me.txtXGWJPageSize)
                        '***********************************************
                    End With

                    If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
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
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
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



        '----------------------------------------------------------------
        '网格事件处理器
        '----------------------------------------------------------------
        '实现对grdXGWJ网格行、列的固定
        Sub grdXGWJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdXGWJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_XGWJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_XGWJ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_XGWJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdXGWJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub




        Private Sub grdXGWJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdXGWJ.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                With New Josco.JsKernal.web.DataGridProcess
                    Me.lblXGWJGridLocInfo.Text = .getDataGridLocation(Me.grdXGWJ, Me.m_intRows_XGWJ)
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




        Private Sub grdXGWJ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdXGWJ.SortCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String
                Dim strOldCommand As String
                Dim strUniqueId As String
                Dim intColumnIndex As Integer

                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_XGWJ.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_XGWJ.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtXGWJSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtXGWJSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtXGWJSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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




        Private Sub doMoveFirst_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdXGWJ.PageCount)
                Me.grdXGWJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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

        Private Sub doMoveLast_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXGWJ.PageCount - 1, Me.grdXGWJ.PageCount)
                Me.grdXGWJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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

        Private Sub doMoveNext_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXGWJ.CurrentPageIndex + 1, Me.grdXGWJ.PageCount)
                Me.grdXGWJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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

        Private Sub doMovePrevious_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXGWJ.CurrentPageIndex - 1, Me.grdXGWJ.PageCount)
                Me.grdXGWJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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

        Private Sub doGotoPage_XGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtXGWJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdXGWJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtXGWJPageIndex.Text = (Me.grdXGWJ.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_XGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtXGWJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdXGWJ.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtXGWJPageSize.Text = (Me.grdXGWJ.PageSize).ToString()

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

        Private Sub doSelectAll_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdXGWJ, 0, Me.m_cstrCheckBoxIdInDataGrid_XGWJ, True) = False Then
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

        Private Sub doDeSelectAll_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdXGWJ, 0, Me.m_cstrCheckBoxIdInDataGrid_XGWJ, False) = False Then
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

        Private Sub doSearch_XGWJ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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

        Private Sub lnkCZXGWJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJMoveFirst.Click
            Me.doMoveFirst_XGWJ("lnkCZXGWJMoveFirst")
        End Sub

        Private Sub lnkCZXGWJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJMoveLast.Click
            Me.doMoveLast_XGWJ("lnkCZXGWJMoveLast")
        End Sub

        Private Sub lnkCZXGWJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJMovePrev.Click
            Me.doMovePrevious_XGWJ("lnkCZXGWJMovePrev")
        End Sub

        Private Sub lnkCZXGWJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJMoveNext.Click
            Me.doMoveNext_XGWJ("lnkCZXGWJMoveNext")
        End Sub

        Private Sub lnkCZXGWJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJSetPageSize.Click
            Me.doSetPageSize_XGWJ("lnkCZXGWJSetPageSize")
        End Sub

        Private Sub lnkCZXGWJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJGotoPage.Click
            Me.doGotoPage_XGWJ("lnkCZXGWJGotoPage")
        End Sub

        Private Sub lnkCZXGWJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJSelectAll.Click
            Me.doSelectAll_XGWJ("lnkCZXGWJSelectAll")
        End Sub

        Private Sub lnkCZXGWJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJDeSelectAll.Click
            Me.doDeSelectAll_XGWJ("lnkCZXGWJDeSelectAll")
        End Sub




        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objOldXGWJData As Josco.JSOA.Common.Data.FlowData
            Dim blnOK As Boolean = False
            Dim strFlowTypeName As String
            Dim strFlowType As String

            Try
                '询问是否保存
                intStep = 1
                If Me.m_objInterface.iEditMode = True Then
                    If Me.m_objInterface.iAutoSave = True Then
                        If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                            objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：您确定要保存当前窗口录入的内容吗（是/否）？", strControlId, intStep, True)
                            Exit Try
                        Else
                            objMessageProcess.doResetPopMessage(Me.popMessageObject)
                        End If
                    End If
                End If

                '继续处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取应答信息
                    blnOK = objMessageProcess.getConfirmBoxValue(Request, Me.popMessageObject.UniqueID)

                    '清除过滤参数
                    If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                        GoTo errProc
                    End If
                    Me.m_objDataSet_XGWJ.Tables(strTable).DefaultView.RowFilter = ""

                    '是否自动保存?
                    If Me.m_objInterface.iEditMode = True Then
                        '编辑模式下
                        If Me.m_objInterface.iAutoSave = True Then
                            '创建并初始化工作流
                            strFlowTypeName = Me.m_objInterface.iFlowTypeName
                            strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                            objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)
                            If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, False) = False Then
                                GoTo errProc
                            End If
                            '需要自动保存！
                            If blnOK = True Then
                                '获取原相关文件数据
                                If objsystemFlowObject.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                                    GoTo errProc
                                End If
                                '自动保存附件
                                If objsystemFlowObject.doSaveXgwj(strErrMsg, Me.m_objInterface.iEnforeEdit, MyBase.UserXM, Me.m_objDataSet_XGWJ) = False Then
                                    GoTo errProc
                                End If
                                '写审计日志
                                If objsystemFlowObject.doWriteUserLog_XGWJ(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_XGWJ, objOldXGWJData) = False Then
                                    '忽略
                                End If
                            Else
                                '解除编辑封锁
                                If objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                                    GoTo errProc
                                End If
                            End If
                            '删除缓存文件
                            If objsystemFlowObject.doDeleteCacheFile_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                                '可以不成功，形成垃圾文件
                            End If
                        End If
                    End If

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

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Exit Sub

        End Sub

        Private Sub doAddNewXGWJ_FJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowXgwjfjInfo As Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            Try
                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String
                objIFlowXgwjfjInfo = New Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
                With objIFlowXgwjfjInfo
                    Dim intXH As Integer
                    With Me.m_objDataSet_XGWJ.Tables(strTable)
                        If .Rows.Count < 1 Then
                            intXH = 1
                        Else
                            'intXH = objPulicParameters.getObjectValue(.Rows(.Rows.Count - 1).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH), 1)
                            intXH = Me.grdXGWJ.Items.Count
                            intXH = intXH + 1
                        End If
                    End With

                    '一般信息
                    .iEditType = JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iAutoSave = False '肯定返回到本界面后再集中保存!
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS
                    .iRow = Nothing
                    .iWJXH = intXH.ToString()
                    .iWJWZ = ""
                    .iWJSM = ""
                    .iWJYS = "1"

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
                Session.Add(strNewSessionId, objIFlowXgwjfjInfo)
                strUrl = ""
                strUrl += "flow_xgwjfj_info.aspx"
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

        Private Sub doAddNewXGWJ_LJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowXgwjljAdd As Josco.JSOA.BusinessFacade.IFlowXgwjljAdd
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            Try
                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String
                objIFlowXgwjljAdd = New Josco.JSOA.BusinessFacade.IFlowXgwjljAdd
                With objIFlowXgwjljAdd
                    .iDataSet_XGWJ = Me.m_objDataSet_XGWJ
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS

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
                Session.Add(strNewSessionId, objIFlowXgwjljAdd)
                strUrl = ""
                strUrl += "flow_xgwjlj_add.aspx"
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

        Private Sub doModifyXGWJ_FJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowXgwjfjInfo As Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With

                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String
                objIFlowXgwjfjInfo = New Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
                With objIFlowXgwjfjInfo
                    '一般信息
                    .iEditType = JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iAutoSave = False '肯定返回到本界面后再集中保存!
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ), "")

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
                Session.Add(strNewSessionId, objIFlowXgwjfjInfo)
                strUrl = ""
                strUrl += "flow_xgwjfj_info.aspx"
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

        Private Sub doModifyXGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With
                Dim intLB As Integer
                intLB = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS), 0)

                '根据类处理
                Select Case intLB
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FlowFile
                        '不能修改，只能查看
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FujianFile
                        '修改相关文件附件
                        Me.doModifyXGWJ_FJ(strControlId)
                    Case Else
                        strErrMsg = "错误：不支持的类型！"
                        GoTo errProc
                End Select

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

        Private Sub doOpenXGWJ_FJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowXgwjfjInfo As Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With

                '检查文件类型
                'LJ-2008-07-30
                Dim strFileExt As String = ""
                Dim strBDWJ As String = ""
                Dim strWJWZ As String = ""
                strBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ), "")
                strWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ), "")
                If strBDWJ = "" Then
                    If strWJWZ = "" Then
                        strErrMsg = "错误：没有对应的电子文件！"
                        GoTo errProc
                    End If
                    strFileExt = objBaseLocalFile.getExtension(strWJWZ)
                Else
                    strFileExt = objBaseLocalFile.getExtension(strBDWJ)
                End If
                Select Case strFileExt.ToUpper
                    Case ".DOC", ".RTF", ".XLS"
                        '调用嵌入处理
                    Case Else
                        '调用下载处理
                        Me.doExport_FJ(strControlId)
                        Exit Try
                End Select
                'LJ-2008-07-30

                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String
                objIFlowXgwjfjInfo = New Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
                With objIFlowXgwjfjInfo
                    '一般信息
                    .iEditType = JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iAutoSave = False '肯定返回到本界面后再集中保存!
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ), "")

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
                Session.Add(strNewSessionId, objIFlowXgwjfjInfo)
                strUrl = ""
                strUrl += "flow_xgwjfj_info.aspx"
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
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 打开文件
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doOpenXGWJ_LJ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim strISessionId As String = ""
            Dim strMSessionId As String = ""
            Dim strUrl As String

            doOpenXGWJ_LJ = False

            Try
                '检查当前选择
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If

                '获取文件标识和文件类型
                Dim strFlowTypeName As String
                Dim strWJBS As String
                Dim strNGR As String
                Dim intColIndex(3) As Integer
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBS)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJLX)
                intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_NGR)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdXGWJ.Items(Me.grdXGWJ.SelectedIndex), intColIndex(0))
                strFlowTypeName = objDataGridProcess.getDataGridCellValue(Me.grdXGWJ.Items(Me.grdXGWJ.SelectedIndex), intColIndex(1))
                strNGR = objDataGridProcess.getDataGridCellValue(Me.grdXGWJ.Items(Me.grdXGWJ.SelectedIndex), intColIndex(2))
                If strWJBS = "" Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If
                If strFlowTypeName = "" Then
                    strErrMsg = "错误：当前文件类型不明确！"
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

                '检查文件是否能看？
                Dim blnCanRead As Boolean
                If objsystemFlowObject.canReadFile(strErrMsg, MyBase.UserXM, blnCanRead) = False Then
                    GoTo errProc
                End If
                '如果不能看，则拟稿人自动给MyBase.UserXM补阅
                If blnCanRead = False Then
                    If strNGR Is Nothing Then strNGR = ""
                    strNGR = strNGR.Trim
                    If strNGR = "" Then
                        strErrMsg = "错误：无法确定文件初始创建人！"
                        GoTo errProc
                    End If
                    If objsystemFlowObject.doSendBuyueJJD(strErrMsg, strNGR, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If
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

            doOpenXGWJ_LJ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Sub doOpenXGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With
                Dim intLB As Integer
                intLB = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS), 0)

                '根据类别处理
                Select Case intLB
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FlowFile
                        '打开工作流文件
                        If Me.doOpenXGWJ_LJ(strErrMsg, strControlId) = False Then
                            GoTo errProc
                        End If
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FujianFile
                        '打开相关文件附件
                        Me.doOpenXGWJ_FJ(strControlId)
                    Case Else
                        strErrMsg = "错误：不支持的类型！"
                        GoTo errProc
                End Select

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

        Private Sub doDeleteXGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow
            Dim intStep As Integer
            Dim intRow As Integer

            Try
                '检查选择
                'Dim blnSelected As Boolean
                'Dim intSelected As Integer
                'Dim intCount As Integer
                'Dim i As Integer
                'intStep = 1
                'If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                '    intCount = Me.grdXGWJ.Items.Count
                '    intSelected = 0
                '    For i = 0 To intCount - 1 Step 1
                '        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdXGWJ.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_XGWJ)
                '        If blnSelected = True Then
                '            intSelected += 1
                '        End If
                '    Next
                '    If intSelected < 1 Then
                '        strErrMsg = "提示：请在要删除的文件前打钩,再点击删除按钮，来删除文件！"
                '        GoTo errProc
                '    End If
                'End If
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If

                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要删除文件吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '删除处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '创建工作流对象
                    Dim strFlowTypeName As String
                    Dim strFlowType As String
                    strFlowTypeName = Me.m_strFlowTypeName
                    strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                    objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                    '获取数据
                    If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                        GoTo errProc
                    End If

                    '删除                 
                    With Me.m_objDataSet_XGWJ.Tables(strTable)
                        intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                        objDataRow = .DefaultView.Item(intRow).Row
                        If objsystemFlowObject.doDeleteData_XGWJ(strErrMsg, objDataRow) = False Then
                            GoTo errProc
                        End If
                    End With


                    '获取附件数据
                    If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                        GoTo errProc
                    End If

                    '调整序号
                    If objsystemFlowObject.doAutoAdjustXSXH_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                        GoTo errProc
                    End If

                    '刷新显示
                    If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    '显示成功信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：成功删除！")
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doAutoSetXH(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim objDataRow As System.Data.DataRow
            Dim intStep As Integer
            Dim intRow As Integer

            Try
                '检查
                If Me.grdXGWJ.Items.Count < 1 Then
                    strErrMsg = "错误：没有文件！"
                    GoTo errProc
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要由系统自动给定序号吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '创建工作流对象
                    Dim strFlowTypeName As String
                    Dim strFlowType As String
                    strFlowTypeName = Me.m_strFlowTypeName
                    strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                    objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                    '获取附件数据
                    If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                        GoTo errProc
                    End If

                    '调整序号
                    If objsystemFlowObject.doAutoAdjustXSXH_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                        GoTo errProc
                    End If

                    '刷新显示
                    If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    '显示成功信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：成功设置序号！")
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doMoveUp(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objSrcDataRow As System.Data.DataRow
            Dim objDesDataRow As System.Data.DataRow
            Dim intRow As Integer

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选择要移动的文件！"
                    GoTo errProc
                End If
                Dim intSrcIndex As Integer = Me.grdXGWJ.SelectedIndex
                If intSrcIndex <= 0 Then
                    strErrMsg = "错误：已经是最上面！"
                    GoTo errProc
                End If
                Dim intDesIndex As Integer = intSrcIndex - 1

                '创建工作流对象
                Dim strFlowTypeName As String
                Dim strFlowType As String
                strFlowTypeName = Me.m_strFlowTypeName
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '处理
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(intSrcIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objSrcDataRow = .DefaultView.Item(intRow).Row

                    intRow = objDataGridProcess.getRecordPosition(intDesIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDesDataRow = .DefaultView.Item(intRow).Row

                    '移动
                    If objsystemFlowObject.doMoveTo_XGWJ(strErrMsg, objSrcDataRow, objDesDataRow) = False Then
                        GoTo errProc
                    End If

                    '更改当前索引
                    Me.grdXGWJ.SelectedIndex = intDesIndex
                End With

                '获取附件数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '调整序号
                If objsystemFlowObject.doAutoAdjustXSXH_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                    GoTo errProc
                End If

                '刷新显示
                If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doMoveDown(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objSrcDataRow As System.Data.DataRow
            Dim objDesDataRow As System.Data.DataRow
            Dim intRow As Integer

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选择要移动的文件！"
                    GoTo errProc
                End If
                Dim intSrcIndex As Integer = Me.grdXGWJ.SelectedIndex
                If ((intSrcIndex >= Me.grdXGWJ.PageSize - 1) Or (intSrcIndex >= Me.grdXGWJ.Items.Count - 1)) And Me.grdXGWJ.AllowPaging = True Then
                    strErrMsg = "错误：已经是最下面！"
                    GoTo errProc
                End If
                Dim intDesIndex As Integer = intSrcIndex + 1

                '创建工作流对象
                Dim strFlowTypeName As String
                Dim strFlowType As String
                strFlowTypeName = Me.m_strFlowTypeName
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '处理
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(intSrcIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objSrcDataRow = .DefaultView.Item(intRow).Row

                    intRow = objDataGridProcess.getRecordPosition(intDesIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDesDataRow = .DefaultView.Item(intRow).Row

                    '移动
                    If objsystemFlowObject.doMoveTo_XGWJ(strErrMsg, objSrcDataRow, objDesDataRow) = False Then
                        GoTo errProc
                    End If

                    '更改当前索引
                    Me.grdXGWJ.SelectedIndex = intDesIndex
                End With

                '获取附件数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '调整序号
                If objsystemFlowObject.doAutoAdjustXSXH_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                    GoTo errProc
                End If

                '刷新显示
                If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doExport_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objDataRow As System.Data.DataRow
            Dim intRowIndex As Integer
            Dim intRow As Integer

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选择要导出的文件！"
                    GoTo errProc
                End If
                intRowIndex = Me.grdXGWJ.SelectedIndex

                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '初始化工作流
                Dim strName As String = Me.m_objInterface.iFlowTypeName
                Dim strType As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strName)
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, False) = False Then
                    GoTo errProc
                End If

                '获取信息
                Dim intColIndex(2) As Integer
                Dim strFTPPath As String
                Dim strDesSpec As String
                Dim strDesPath As String
                Dim strDesFile As String
                Dim strUrl As String
                With objDataGridProcess
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ)
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ)
                    strFTPPath = .getDataGridCellValue(Me.grdXGWJ.Items(intRowIndex), intColIndex(0))
                    strDesSpec = .getDataGridCellValue(Me.grdXGWJ.Items(intRowIndex), intColIndex(1))
                End With
                If strFTPPath = "" And strDesSpec = "" Then
                    strErrMsg = "错误：该文件没有电子文件！"
                    GoTo errProc
                End If

                '下载文件
                If strDesSpec <> "" Then
                    '如果直接有本地文件，则直接将WEB本地文件下载到客户端
                    strDesFile = objBaseLocalFile.getFileName(strDesSpec)
                Else
                    '从FTP服务器下载
                    strDesPath = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache
                    strDesPath = Server.MapPath(strDesPath)
                    If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, strFTPPath, strDesSpec, strDesPath, strDesFile) = False Then
                        GoTo errProc
                    End If
                    strDesSpec = objBaseLocalFile.doMakePath(strDesPath, strDesFile)
                End If
                strUrl = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strDesFile

                '记录缓存文件
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(intRowIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = strDesSpec
                End With

                '记录访问审计日志
                If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "导出了文件[" + objsystemFlowObject.FlowData.WJBS + "]的第[" + (Me.grdXGWJ.SelectedIndex + 1).ToString + "]个相关文件！") = False Then
                    '忽略
                End If

                '下载到客户端
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doExportFile_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objDataRow As System.Data.DataRow
            Dim intRowIndex As Integer
            Dim intRow As Integer

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选择要导出的文件！"
                    GoTo errProc
                End If
                intRowIndex = Me.grdXGWJ.SelectedIndex

                '获取数据
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '初始化工作流
                Dim strName As String = Me.m_objInterface.iFlowTypeName
                Dim strType As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strName)
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, False) = False Then
                    GoTo errProc
                End If

                '获取信息
                Dim intColIndex(3) As Integer
                Dim strFTPPath As String
                Dim strDesSpec As String
                Dim strDesPath As String
                Dim strDesFile As String
                Dim strFileName As String = ""
                Dim strFileExt As String = ""
                Dim strUrl As String
                With objDataGridProcess
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ)
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ)
                    intColIndex(2) = .getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT)
                    strFTPPath = .getDataGridCellValue(Me.grdXGWJ.Items(intRowIndex), intColIndex(0))
                    strDesSpec = .getDataGridCellValue(Me.grdXGWJ.Items(intRowIndex), intColIndex(1))
                    strFileName = .getDataGridCellValue(Me.grdXGWJ.Items(intRowIndex), intColIndex(2))
                End With
                'LJ 2008-08-12
                If strDesSpec = "" Then
                    If strFTPPath = "" Then
                        strErrMsg = "错误：没有对应的电子文件！"
                        GoTo errProc
                    End If
                    strFileExt = objBaseLocalFile.getExtension(strFTPPath)
                Else
                    strFileExt = objBaseLocalFile.getExtension(strDesSpec)
                End If
                strFileName = strFileName + strFileExt
                '下载文件
                If strDesSpec <> "" Then
                    '如果直接有本地文件，则直接将WEB本地文件下载到客户端
                    strDesFile = objBaseLocalFile.getFileName(strDesSpec)
                Else
                    '从FTP服务器下载
                    strDesPath = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache
                    strDesPath = Server.MapPath(strDesPath)
                    If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, strFTPPath, strDesSpec, strDesPath, strDesFile) = False Then
                        GoTo errProc
                    End If
                    strDesSpec = objBaseLocalFile.doMakePath(strDesPath, strDesFile)
                End If
                strUrl = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strDesFile

                '记录缓存文件
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(intRowIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = strDesSpec
                End With

                '记录访问审计日志
                If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "导出了文件[" + objsystemFlowObject.FlowData.WJBS + "]的第[" + (Me.grdXGWJ.SelectedIndex + 1).ToString + "]个相关文件！") = False Then
                    '忽略
                End If

                Me.Response.ClearHeaders()
                Me.Response.Clear()
                Me.Response.Expires = 0
                Me.Response.Buffer = True
                Me.Response.AddHeader("Accept-Language", "zh-tw")
                '文件名称 
                Me.Response.AddHeader("content-disposition", "attachment;filename=" + Chr(34) + System.Web.HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8) + Chr(34))
                Me.Response.ContentType = "Application/octet-stream"
                '文件内容 
                Me.Response.WriteFile(strUrl)
                Me.Response.End()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doExport(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With
                Dim intLB As Integer
                intLB = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS), 0)

                '根据类处理
                Select Case intLB
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FlowFile
                        '导出默认工作流文件
                        objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：导出[链接]文件有关内容请打开链接文件后选择要导出的内容！")
                        Exit Try
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FujianFile
                        '导出相关文件附件
                        Me.doExportFile_FJ(strControlId)
                    Case Else
                        strErrMsg = "错误：不支持的类型！"
                        GoTo errProc
                End Select

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

        Private Sub lnkMLClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub

        Private Sub lnkMLSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSelect.Click
            Me.doOpenXGWJ("lnkMLSelect")
        End Sub

        Private Sub lnkMLAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLAddNew.Click
            Me.doAddNewXGWJ_FJ("lnkMLAddNew")
        End Sub

        Private Sub lnkMLAddNewWJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLAddNewWJ.Click
            Me.doAddNewXGWJ_LJ("lnkMLAddNewWJ")
        End Sub

        Private Sub lnkMLModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLModify.Click
            Me.doModifyXGWJ("lnkMLModify")
        End Sub

        Private Sub lnkMLDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDelete.Click
            Me.doDeleteXGWJ("lnkMLDelete")
        End Sub

        Private Sub lnkMLAutoXH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLAutoXH.Click
            Me.doAutoSetXH("lnkMLAutoXH")
        End Sub

        Private Sub lnkMLMoveUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLMoveUp.Click
            Me.doMoveUp("lnkMLMoveUp")
        End Sub

        Private Sub lnkMLMoveDn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLMoveDn.Click
            Me.doMoveDown("lnkMLMoveDn")
        End Sub

        Private Sub lnkMLExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLExport.Click
            Me.doExport("lnkMLExport")
        End Sub

        Private Sub grdXGWJ_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdXGWJ.ItemCommand
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdXGWJ.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        Me.doOpenXGWJ("lnkMLSelect")



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
    End Class

End Namespace
