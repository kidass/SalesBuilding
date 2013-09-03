Imports System.Web.Security
Imports System.Threading
Imports System.Char
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Permissions
Imports Microsoft.Win32
Imports System.Diagnostics


Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_fujian
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

    Public Class flow_fujian
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkMLAddNew As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLModify As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLSelect As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLMoveUp As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLMoveDn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLAutoXH As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLExport As System.Web.UI.WebControls.LinkButton
        '2010-05-21 LJ
        Protected WithEvents lnkMLExportAll As System.Web.UI.WebControls.LinkButton
        '2010-05-21 LJ
        Protected WithEvents lnkMLClose As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtFJPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZFJSetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtFJPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblFJGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdFJ As System.Web.UI.WebControls.DataGrid
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents htxtFJFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFJQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFJRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFJSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFJSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFJSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftFJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopFJ As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowFujian
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowFujian
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objDataSet_FJ As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_FJ As String '记录m_objDataSet_FJ搜索串
        Private m_intRows_FJ As Integer '记录m_objDataSet_FJ的DefaultView记录数

        '----------------------------------------------------------------
        '与数据网格grdFJ相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_FJ As String = "chkFJ"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_FJ As String = "divFJ"
        '网格要锁定的列数
        Private m_intFixedColumns_FJ As Integer

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
                    Me.txtFJPageIndex.Text = .txtFJPageIndex
                    Me.txtFJPageSize.Text = .txtFJPageSize

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftFJ.Value = .htxtDivLeftFJ
                    Me.htxtDivTopFJ.Value = .htxtDivTopFJ

                    Me.htxtFJQuery.Value = .htxtFJQuery
                    Me.htxtFJRows.Value = .htxtFJRows
                    Me.htxtFJSort.Value = .htxtFJSort
                    Me.htxtFJSortColumnIndex.Value = .htxtFJSortColumnIndex
                    Me.htxtFJSortType.Value = .htxtFJSortType

                    Me.m_objDataSet_FJ = .objDataSet_FJ
                    Try
                        Me.grdFJ.PageSize = .grdFJ_PageSize
                        Me.grdFJ.SelectedIndex = .grdFJ_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowFujian

                '保存现场信息
                With Me.m_objSaveScence
                    .txtFJPageIndex = Me.txtFJPageIndex.Text
                    .txtFJPageSize = Me.txtFJPageSize.Text

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftFJ = Me.htxtDivLeftFJ.Value
                    .htxtDivTopFJ = Me.htxtDivTopFJ.Value

                    .htxtFJQuery = Me.htxtFJQuery.Value
                    .htxtFJRows = Me.htxtFJRows.Value
                    .htxtFJSort = Me.htxtFJSort.Value
                    .htxtFJSortColumnIndex = Me.htxtFJSortColumnIndex.Value
                    .htxtFJSortType = Me.htxtFJSortType.Value

                    .objDataSet_FJ = Me.m_objDataSet_FJ
                    .grdFJ_PageSize = Me.grdFJ.PageSize
                    .grdFJ_SelectedIndex = Me.grdFJ.SelectedIndex
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
            Dim objDataRow As System.Data.DataRow

            Try
                If Me.IsPostBack = True Then Exit Try

                '=================================================================
                Dim objIFlowFujianInfo As Josco.JSOA.BusinessFacade.IFlowFujianInfo
                Try
                    objIFlowFujianInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowFujianInfo)
                Catch ex As Exception
                    objIFlowFujianInfo = Nothing
                End Try
                If Not (objIFlowFujianInfo Is Nothing) Then
                    If objIFlowFujianInfo.oExitMode = True Then
                        '返回参数处理
                        With Me.m_objInterface.iDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                            Select Case objIFlowFujianInfo.iEditType
                                Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                    objDataRow = .NewRow()
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH) = objPulicParameters.getObjectValue(objIFlowFujianInfo.oWJXH, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS) = objPulicParameters.getObjectValue(objIFlowFujianInfo.oWJYS, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ) = objIFlowFujianInfo.oBDWJ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ) = objIFlowFujianInfo.oWJWZ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM) = objIFlowFujianInfo.oWJSM
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XZBZ) = intXZBZ.ToString()
                                    .Rows.Add(objDataRow)
                                Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                    objDataRow = objIFlowFujianInfo.iRow
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS) = objPulicParameters.getObjectValue(objIFlowFujianInfo.oWJYS, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ) = objIFlowFujianInfo.oWJWZ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM) = objIFlowFujianInfo.oWJSM
                                    If objIFlowFujianInfo.oBDWJ <> "" Then
                                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ) = objIFlowFujianInfo.oBDWJ
                                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XZBZ) = intXZBZ.ToString()
                                    End If
                            End Select
                        End With
                    End If
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowFujianInfo.Dispose()
                    objIFlowFujianInfo = Nothing
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowFujian)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowFujian)
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
                Me.m_intFixedColumns_FJ = objPulicParameters.getObjectValue(Me.htxtFJFixed.Value, 0)
                Me.m_intRows_FJ = objPulicParameters.getObjectValue(Me.htxtFJRows.Value, 0)
                Me.m_strQuery_FJ = Me.htxtFJQuery.Value

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
        Private Function getModuleData_FJ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            getModuleData_FJ = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtFJSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '获取数据
                Me.m_objDataSet_FJ = Me.m_objInterface.iDataSet_FJ

                '恢复Sort字符串
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    .DefaultView.Sort = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH + " asc" '缺省排序，不能改变
                    .DefaultView.RowFilter = strWhere
                End With

                '缓存参数
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    Me.htxtFJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_FJ = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_FJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdFJ的搜索条件(RowFilter格式)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_FJ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_FJ = False
            strQuery = ""

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_FJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdFJ数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_FJ(ByRef strErrMsg As String) As Boolean

            searchModuleData_FJ = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_FJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_FJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_FJ = strQuery
                Me.htxtFJQuery.Value = Me.m_strQuery_FJ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_FJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdFJ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_FJ( _
            ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_FJ = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtFJSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtFJSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_FJ Is Nothing Then
                    Me.grdFJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                        Me.grdFJ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdFJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdFJ)
                    With Me.grdFJ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdFJ.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdFJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_FJ) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_FJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdFJ及其相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_FJ(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_FJ = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN).DefaultView
                    '显示网格位置信息
                    Me.lblFJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdFJ, .Count)
                    '显示页面浏览功能
                    Me.lnkCZFJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdFJ, .Count)
                    Me.lnkCZFJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdFJ, .Count)
                    Me.lnkCZFJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdFJ, .Count)
                    Me.lnkCZFJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdFJ, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZFJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZFJSelectAll.Enabled = blnEnabled
                    Me.lnkCZFJGotoPage.Enabled = blnEnabled
                    Me.lnkCZFJSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_FJ = True
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
                If Me.showModuleData_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示命令
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
                        .doTranslateKey(Me.txtFJPageIndex)
                        .doTranslateKey(Me.txtFJPageSize)
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
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
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
        '实现对grdFJ网格行、列的固定
        Sub grdFJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdFJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_FJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_FJ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_FJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdFJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub




        Private Sub grdFJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFJ.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                With New Josco.JsKernal.web.DataGridProcess
                    Me.lblFJGridLocInfo.Text = .getDataGridLocation(Me.grdFJ, Me.m_intRows_FJ)
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




        Private Sub grdFJ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdFJ.SortCommand

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
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtFJSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtFJSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtFJSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_FJ(strErrMsg) = False Then
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




        Private Sub doMoveFirst_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdFJ.PageCount)
                Me.grdFJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FJ(strErrMsg) = False Then
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

        Private Sub doMoveLast_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFJ.PageCount - 1, Me.grdFJ.PageCount)
                Me.grdFJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FJ(strErrMsg) = False Then
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

        Private Sub doMoveNext_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFJ.CurrentPageIndex + 1, Me.grdFJ.PageCount)
                Me.grdFJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FJ(strErrMsg) = False Then
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

        Private Sub doMovePrevious_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFJ.CurrentPageIndex - 1, Me.grdFJ.PageCount)
                Me.grdFJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FJ(strErrMsg) = False Then
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

        Private Sub doGotoPage_FJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtFJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdFJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtFJPageIndex.Text = (Me.grdFJ.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_FJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtFJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdFJ.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtFJPageSize.Text = (Me.grdFJ.PageSize).ToString()

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

        Private Sub doSelectAll_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdFJ, 0, Me.m_cstrCheckBoxIdInDataGrid_FJ, True) = False Then
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

        Private Sub doDeSelectAll_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdFJ, 0, Me.m_cstrCheckBoxIdInDataGrid_FJ, False) = False Then
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

        Private Sub doSearch_FJ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_FJ(strErrMsg) = False Then
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

        Private Sub lnkCZFJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJMoveFirst.Click
            Me.doMoveFirst_FJ("lnkCZFJMoveFirst")
        End Sub

        Private Sub lnkCZFJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJMoveLast.Click
            Me.doMoveLast_FJ("lnkCZFJMoveLast")
        End Sub

        Private Sub lnkCZFJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJMovePrev.Click
            Me.doMovePrevious_FJ("lnkCZFJMovePrev")
        End Sub

        Private Sub lnkCZFJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJMoveNext.Click
            Me.doMoveNext_FJ("lnkCZFJMoveNext")
        End Sub

        Private Sub lnkCZFJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJSetPageSize.Click
            Me.doSetPageSize_FJ("lnkCZFJSetPageSize")
        End Sub

        Private Sub lnkCZFJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJGotoPage.Click
            Me.doGotoPage_FJ("lnkCZFJGotoPage")
        End Sub

        Private Sub lnkCZFJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJSelectAll.Click
            Me.doSelectAll_FJ("lnkCZFJSelectAll")
        End Sub

        Private Sub lnkCZFJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJDeSelectAll.Click
            Me.doDeSelectAll_FJ("lnkCZFJDeSelectAll")
        End Sub




        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objOldFJData As Josco.JSOA.Common.Data.FlowData
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
                    If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                        GoTo errProc
                    End If
                    Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN).DefaultView.RowFilter = ""

                    '是否自动保存?
                    If Me.m_objInterface.iEditMode = True Then
                        '编辑模式下
                        If Me.m_objInterface.iAutoSave = True Then
                            '需要自动保存！
                            '创建并初始化工作流
                            strFlowTypeName = Me.m_objInterface.iFlowTypeName
                            strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                            objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)
                            If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, False) = False Then
                                GoTo errProc
                            End If
                            If blnOK = True Then
                                '获取原附件数据
                                If objsystemFlowObject.getFujianData(strErrMsg, objOldFJData) = False Then
                                    GoTo errProc
                                End If

                                '自动保存附件
                                If objsystemFlowObject.doSaveFujian(strErrMsg, Me.m_objInterface.iEnforeEdit, MyBase.UserXM, Me.m_objDataSet_FJ) = False Then
                                    GoTo errProc
                                End If

                                '写审计日志
                                If objsystemFlowObject.doWriteUserLog_Fujian(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_FJ, objOldFJData) = False Then
                                    '忽略
                                End If
                            Else
                                '解除自己对文件的编辑封锁
                                If objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                                    GoTo errProc
                                End If
                            End If
                            '删除缓存文件
                            If objsystemFlowObject.doDeleteCacheFile_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
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
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Exit Sub

        End Sub

        Private Sub doAddNewFJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowFujianInfo As Josco.JSOA.BusinessFacade.IFlowFujianInfo
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Try
                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String
                objIFlowFujianInfo = New Josco.JSOA.BusinessFacade.IFlowFujianInfo
                With objIFlowFujianInfo
                    Dim intXH As Integer
                    With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                        If .Rows.Count < 1 Then
                            intXH = 1
                        Else
                            'intXH = objPulicParameters.getObjectValue(.Rows(.Rows.Count - 1).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH), 1)
                            intXH = Me.grdFJ.Items.Count
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
                Session.Add(strNewSessionId, objIFlowFujianInfo)
                strUrl = ""
                strUrl += "flow_fujian_info.aspx"
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

        Private Sub doModifyFJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowFujianInfo As Josco.JSOA.BusinessFacade.IFlowFujianInfo
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim objDataRow As System.Data.DataRow

            Try
                '检查
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    With New Josco.JsKernal.web.DataGridProcess
                        intRow = .getRecordPosition(Me.grdFJ.SelectedIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    End With
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
                objIFlowFujianInfo = New Josco.JSOA.BusinessFacade.IFlowFujianInfo
                With objIFlowFujianInfo
                    '一般信息
                    .iEditType = JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iAutoSave = False '肯定返回到本界面后再集中保存!
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ), "")

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
                Session.Add(strNewSessionId, objIFlowFujianInfo)
                strUrl = ""
                strUrl += "flow_fujian_info.aspx"
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

        Private Sub doOpenFJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowFujianInfo As Josco.JSOA.BusinessFacade.IFlowFujianInfo

            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim objDataRow As System.Data.DataRow

            Try
                '检查
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    With New Josco.JsKernal.web.DataGridProcess
                        intRow = .getRecordPosition(Me.grdFJ.SelectedIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    End With
                    objDataRow = .DefaultView.Item(intRow).Row
                End With

                '检查文件类型
                'LJ-2008-07-29
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
                        Me.doExport(strControlId)
                        Exit Try
                End Select
                'LJ-2008-07-29

                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String
                objIFlowFujianInfo = New Josco.JSOA.BusinessFacade.IFlowFujianInfo
                With objIFlowFujianInfo
                    '一般信息
                    .iEditType = JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iAutoSave = False '肯定返回到本界面后再集中保存!
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ), "")

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
                Session.Add(strNewSessionId, objIFlowFujianInfo)
                strUrl = ""
                strUrl += "flow_fujian_info.aspx"
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
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDeleteFJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

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
                '    intCount = Me.grdFJ.Items.Count
                '    intSelected = 0
                '    For i = 0 To intCount - 1 Step 1
                '        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdFJ.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FJ)
                '        If blnSelected = True Then
                '            intSelected += 1
                '        End If
                '    Next
                '    If intSelected < 1 Then
                '        strErrMsg = "提示：请在要删除的文件前打钩,再点击删除按钮，来删除文件！"
                '        GoTo errProc
                '    End If
                'End If
                '检查
                If Me.grdFJ.SelectedIndex < 0 Then
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
                    If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                        GoTo errProc
                    End If

                    '删除
                    With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                        intRow = objDataGridProcess.getRecordPosition(Me.grdFJ.SelectedIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                        objDataRow = .DefaultView.Item(intRow).Row
                        If objsystemFlowObject.doDeleteData_FJ(strErrMsg, objDataRow) = False Then
                            GoTo errProc
                        End If
                    End With

                    '获取附件数据
                    If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                        GoTo errProc
                    End If

                    '调整序号
                    If objsystemFlowObject.doAutoAdjustXSXH_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
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
                If Me.grdFJ.Items.Count < 1 Then
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
                    If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                        GoTo errProc
                    End If

                    '调整序号
                    If objsystemFlowObject.doAutoAdjustXSXH_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
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

            Dim objSrcDataRow As System.Data.DataRow
            Dim objDesDataRow As System.Data.DataRow
            Dim intRow As Integer

            Try
                '检查
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选择要移动的文件！"
                    GoTo errProc
                End If
                Dim intSrcIndex As Integer = Me.grdFJ.SelectedIndex
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
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '处理
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    intRow = objDataGridProcess.getRecordPosition(intSrcIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objSrcDataRow = .DefaultView.Item(intRow).Row

                    intRow = objDataGridProcess.getRecordPosition(intDesIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objDesDataRow = .DefaultView.Item(intRow).Row

                    '移动
                    If objsystemFlowObject.doMoveTo_FJ(strErrMsg, objSrcDataRow, objDesDataRow) = False Then
                        GoTo errProc
                    End If

                    '更改当前索引
                    Me.grdFJ.SelectedIndex = intDesIndex
                End With

                '获取附件数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '调整序号
                If objsystemFlowObject.doAutoAdjustXSXH_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
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

            Dim objSrcDataRow As System.Data.DataRow
            Dim objDesDataRow As System.Data.DataRow
            Dim intRow As Integer

            Try
                '检查
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选择要移动的文件！"
                    GoTo errProc
                End If
                Dim intSrcIndex As Integer = Me.grdFJ.SelectedIndex
                If ((intSrcIndex >= Me.grdFJ.PageSize - 1) Or (intSrcIndex >= Me.grdFJ.Items.Count - 1)) And Me.grdFJ.AllowPaging = True Then
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
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '处理
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    intRow = objDataGridProcess.getRecordPosition(intSrcIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objSrcDataRow = .DefaultView.Item(intRow).Row

                    intRow = objDataGridProcess.getRecordPosition(intDesIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objDesDataRow = .DefaultView.Item(intRow).Row

                    '移动
                    If objsystemFlowObject.doMoveTo_FJ(strErrMsg, objSrcDataRow, objDesDataRow) = False Then
                        GoTo errProc
                    End If

                    '更改当前索引
                    Me.grdFJ.SelectedIndex = intDesIndex
                End With

                '获取附件数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '调整序号
                If objsystemFlowObject.doAutoAdjustXSXH_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
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

        Private Sub doExport(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objDataRow As System.Data.DataRow
            Dim intRowIndex As Integer
            Dim intRow As Integer
            Dim strFileName As String = ""

            Try
                '检查
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选择要导出的文件！"
                    GoTo errProc
                End If
                intRowIndex = Me.grdFJ.SelectedIndex

                '获取数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
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
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ)
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ)
                    strFTPPath = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(0))
                    strDesSpec = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(1))
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
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    intRow = objDataGridProcess.getRecordPosition(intRowIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ) = strDesSpec
                End With

                '记录访问审计日志
                If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "导出了文件[" + objsystemFlowObject.FlowData.WJBS + "]的第[" + (Me.grdFJ.SelectedIndex + 1).ToString + "]个附件！") = False Then
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

        'lj 2008-08-12
        Private Sub doExportFile(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objDataRow As System.Data.DataRow
            Dim intRowIndex As Integer
            Dim intRow As Integer

            Try
                '检查
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选择要导出的文件！"
                    GoTo errProc
                End If
                intRowIndex = Me.grdFJ.SelectedIndex


                '获取数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
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
                Dim i As Integer

                With objDataGridProcess
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ)
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ)
                    intColIndex(2) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM)
                    strFTPPath = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(0))
                    strDesSpec = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(1))
                    strFileName = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(2))
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
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    intRow = objDataGridProcess.getRecordPosition(intRowIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ) = strDesSpec
                End With

                '记录访问审计日志
                If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "导出了文件[" + objsystemFlowObject.FlowData.WJBS + "]的第[" + (Me.grdFJ.SelectedIndex + 1).ToString + "]个附件！") = False Then
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
                'Me.Response.Write(System.IO.File.OpenWrite(strFTPPath))
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

        Private Sub doCompressRAR(ByVal patch As String, ByVal rarPatch As String, ByVal rarName As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim the_rar As String
            Dim the_Reg As RegistryKey
            Dim the_Obj As Object
            Dim the_Info As String
            Dim the_StartInfo As ProcessStartInfo
            Dim the_Process As Process

            Try
                the_Reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe")
                the_Obj = the_Reg.GetValue("")
                the_rar = CStr(the_Obj)

                Dim FileString As String 'Shell指令中的字符串   
                Dim Result As Long
                FileString = the_rar + " a -EP1 " + rarName + " " + patch
                Result = Shell(FileString, vbHide)

                the_Reg.Close()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'lj 2010-05-21
        Private Sub doExportFileAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objDataRow As System.Data.DataRow
            Dim intRowIndex As Integer
            Dim intRow As Integer
            Dim intCountRow As Integer

            Try
                '检查
                If Me.grdFJ.Items.Count <= 0 Then
                    strErrMsg = "错误：您没有附件！"
                    GoTo errProc
                End If


                '获取数据
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
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
                Dim strDesSpec_0 As String
                Dim strDesSpec_1 As String = ""
                Dim strDesPath As String
                Dim strDesFile As String
                Dim strFileName As String = ""
                Dim strFileExt As String = ""
                Dim strUrl As String = ""
                Dim i As Integer = 0

                intCountRow = Me.grdFJ.Items.Count
                intRowIndex = 0
                With objDataGridProcess
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ)
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ)
                    intColIndex(2) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM)
                    strFTPPath = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(0))
                    strDesSpec = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(1))
                    strFileName = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(2))
                End With

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
                strDesSpec_0 = strDesSpec + ".rar"
                strDesSpec_1 = strDesSpec

                For i = 1 To intCountRow - 1 Step 1
                    strFTPPath = ""
                    strDesSpec = ""
                    strFileName = ""
                    strFileExt = ""
                    intRowIndex = i
                    With objDataGridProcess
                        intColIndex(0) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ)
                        intColIndex(1) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ)
                        intColIndex(2) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM)
                        strFTPPath = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(0))
                        strDesSpec = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(1))
                        strFileName = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(2))
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
                    strDesSpec_1 = strDesSpec_1 + " " + strDesSpec
                Next

                '压缩打包文件
                doCompressRAR(strDesSpec_1, strDesPath, strDesSpec_0)

                Dim strPoint As String = "."
                Dim intCount As Integer
                Dim strTemp() As String = strFileName.Split(strPoint.ToCharArray)
                'intCount = strTemp.Length
                strFileName = strTemp(0)
                strFileName = strFileName + ".rar"
                strDesSpec_0 = objBaseLocalFile.getFileName(strDesSpec_0)
                strUrl = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strDesSpec_0


                '记录访问审计日志
                If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "导出了文件[" + objsystemFlowObject.FlowData.WJBS + "]的全部附件！") = False Then
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

        Private Sub lnkMLClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub

        Private Sub lnkMLSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSelect.Click
            Me.doOpenFJ("lnkMLSelect")
        End Sub

        Private Sub lnkMLAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLAddNew.Click
            Me.doAddNewFJ("lnkMLAddNew")
        End Sub

        Private Sub lnkMLModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLModify.Click
            Me.doModifyFJ("lnkMLModify")
        End Sub

        Private Sub lnkMLDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDelete.Click
            Me.doDeleteFJ("lnkMLDelete")
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
            Me.doExportFile("lnkMLExport")
        End Sub

        Private Sub lnkMLExportAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLExportAll.Click
            Me.doExportFileAll("lnkMLExportAll")
        End Sub

        Private Sub grdFJ_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFJ.ItemCommand
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdFJ.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        Me.doOpenFJ("lnkMLSelect")


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
