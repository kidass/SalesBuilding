﻿
Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：ggdm_khlx
    ' 
    ' 调用性质：
    '     独立运行
    '
    ' 功能描述： 
    '   　“地产_B_人事_考勤类型”代码处理模块

    Partial Class kqgl_kqlx
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub








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
        Private m_cstrPrevilegeParamPrefix As String = "ggdm_zpqd_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JsKernal.BusinessFacade.IGgdmGwsz
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdObjects相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid As String = "chkObjects"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV As String = "divObjects"
        '网格要锁定的列数
        Private m_intFixedColumns As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData
        Private m_strQuery As String '记录m_objkaoqinguanliData的搜索串
        Private m_intRows As Integer '记录m_objkaoqinguanliData的DefaultView记录数

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------
        '详细编辑模式
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        '是否为编辑状态
        Private m_blnEditMode As Boolean
        '进入编辑模式前记录的页位置
        Private m_intCurrentPageIndex As Integer
        '进入编辑模式前记录的行位置
        Private m_intCurrentSelectIndex As Integer







        '----------------------------------------------------------------
        ' 获取权限参数
        '     strErrMsg          ：返回错误信息
        '     blnContinueExecute ：是否继续执行后续程序？
        ' 返回
        '     True               ：成功
        '     False              ：失败
        '----------------------------------------------------------------
        Private Function getPrevilegeParams( _
            ByRef strErrMsg As String, _
            ByRef blnContinueExecute As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemAppManager As New Josco.JsKernal.BusinessFacade.systemAppManager
            Dim objMokuaiQXData As Josco.JsKernal.Common.Data.AppManagerData

            getPrevilegeParams = False
            blnContinueExecute = False

            Try
                Dim intCount As Integer
                Dim i As Integer

                '根据登录用户获取模块权限数据
                If MyBase.UserId.ToUpper() = "SA" Then
                    '管理员权限
                    intCount = Me.m_blnPrevilegeParams.Length
                    For i = 0 To intCount - 1 Step 1
                        Me.m_blnPrevilegeParams(i) = True
                    Next
                    blnContinueExecute = True
                    Exit Try
                Else
                    '普通用户权限
                    If objsystemAppManager.getDBUserMokuaiQXData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, objMokuaiQXData) = False Then
                        GoTo errProc
                    End If
                End If

                '检查权限
                Dim strFirstParamValue As String
                Dim strParamValue As String
                Dim strParamName As String
                Dim strMKMC As String
                Dim strFilter As String
                strMKMC = Josco.JsKernal.Common.Data.AppManagerData.FIELD_GL_B_YINGYONGXITONG_MOKUAIQX_MKMC
                With objMokuaiQXData.Tables(Josco.JsKernal.Common.Data.AppManagerData.TABLE_GL_B_YINGYONGXITONG_MOKUAIQX)
                    intCount = Me.m_blnPrevilegeParams.Length
                    For i = 0 To intCount - 1 Step 1
                        '计算参数名
                        strParamName = i.ToString()
                        If strParamName.Length < 2 Then strParamName = "0" + strParamName
                        strParamName = Me.m_cstrPrevilegeParamPrefix + strParamName

                        '获取参数值
                        With objPulicParameters
                            strParamValue = .getObjectValue(Josco.JsKernal.Common.jsoaSecureConfiguration.ReadSetting(strParamName, ""), "")
                        End With
                        If i = 0 Then strFirstParamValue = strParamValue

                        '获取参数对应的权限
                        strFilter = strMKMC + " = '" + strParamValue + "'"
                        .DefaultView.RowFilter = strFilter
                        If .DefaultView.Count > 0 Then
                            Me.m_blnPrevilegeParams(i) = True
                        Else
                            Me.m_blnPrevilegeParams(i) = False
                        End If
                    Next

                End With

                '是否继续执行
                If Me.m_blnPrevilegeParams(0) = True Then
                    blnContinueExecute = True
                Else
                    Me.panelError.Visible = True
                    Me.lblMessage.Text = "错误：您没有[" + strFirstParamValue + "]的执行权限，请与系统管理员联系，谢谢！"
                    Me.panelMain.Visible = Not Me.panelError.Visible
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemAppManager.SafeRelease(objsystemAppManager)
            Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objMokuaiQXData)

            getPrevilegeParams = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemAppManager.SafeRelease(objsystemAppManager)
            Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objMokuaiQXData)
            Exit Function

        End Function







        '----------------------------------------------------------------
        ' 复原模块现场信息并释放相应的资源
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try

            Catch ex As Exception

            End Try

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 保存模块现场信息并返回相应的SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Try

            Catch ex As Exception

            End Try

            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getDataFromCallModule = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放接口参数
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
                If Not (Me.m_objInterface Is Nothing) Then
                    If Me.m_objInterface.iInterfaceType = Josco.JSOA.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                        Me.m_objInterface.Dispose()
                        Me.m_objInterface = Nothing
                    End If
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 获取接口参数
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            strErrMsg = ""

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JsKernal.BusinessFacade.IGgdmGwsz)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                End If

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")

                    '恢复现场参数后释放该资源
                    Me.restoreModuleInformation(strSessionId)

                    '处理调用模块返回后的信息并同时释放相应资源
                    If Me.getDataFromCallModule(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

                With objPulicParameters
                    '是否处于编辑状态
                    Me.m_blnEditMode = .getObjectValue(Me.htxtEditMode.Value, False)

                    '进入编辑模式前记录的页位置
                    Me.m_intCurrentPageIndex = .getObjectValue(Me.htxtCurrentPage.Value, 0)

                    '进入编辑模式前记录的行位置
                    Me.m_intCurrentSelectIndex = .getObjectValue(Me.htxtCurrentRow.Value, -1)

                    '当前编辑模式
                    Dim intEditType As Integer
                    intEditType = .getObjectValue(Me.htxtEditType.Value, 0)
                    Try
                        Me.m_objenumEditType = CType(intEditType, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType)
                    Catch ex As Exception
                        Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    End Try

                    'm_objkaoqinguanliData的搜索串
                    Me.m_strQuery = Me.htxtQuery.Value

                    '记录m_objkaoqinguanliData的DefaultView记录数
                    Me.m_intRows = .getObjectValue(Me.htxtRows.Value, 0)

                    Me.m_intFixedColumns = .getObjectValue(Me.htxtOBJECTSFixed.Value, 0)
                End With

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

            Catch ex As Exception

            End Try

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 获取模块搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString = False
            strQuery = ""

            Try
                '按代码搜索
                Dim strKHLXDM As String = "a." + Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_DM
                If Me.txtSearch_KHLXDM.Text.Length > 0 Then Me.txtSearch_KHLXDM.Text = Me.txtSearch_KHLXDM.Text.Trim()
                If Me.txtSearch_KHLXDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strKHLXDM + " like '" + Me.txtSearch_KHLXDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strKHLXDM + " like '" + Me.txtSearch_KHLXDM.Text + "%'"
                    End If
                End If

                '按名称搜索
                Dim strKHLXMC As String = "a." + Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_MC
                If Me.txtSearch_KHLXMC.Text.Length > 0 Then Me.txtSearch_KHLXMC.Text = Me.txtSearch_KHLXMC.Text.Trim()
                If Me.txtSearch_KHLXMC.Text <> "" Then
                    Me.txtSearch_KHLXMC.Text = objPulicParameters.getNewSearchString(Me.txtSearch_KHLXMC.Text)
                    If strQuery = "" Then
                        strQuery = strKHLXMC + " like '" + Me.txtSearch_KHLXMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strKHLXMC + " like '" + Me.txtSearch_KHLXMC.Text + "%'"
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取模块要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索字符串
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_B_KQ_KAOQINLEXING
            getModuleData = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objkaoqinguanliData Is Nothing) Then
                    Me.m_objkaoqinguanliData.Dispose()
                    Me.m_objkaoqinguanliData = Nothing
                End If

                '重新检索数据
                With New Josco.JSOA.BusinessFacade.systemKaoqinguanli
                    If .getKaoqingleixingData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objkaoqinguanliData) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复Sort字符串
                With Me.m_objkaoqinguanliData.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                If blnEditMode = False Then '查看模式
                    With Me.m_objkaoqinguanliData.Tables(strTable)
                        .DefaultView.AllowNew = False
                    End With
                Else '编辑模式
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            '增加1条空记录
                            With Me.m_objkaoqinguanliData.Tables(strTable)
                                .DefaultView.AllowNew = True
                                .DefaultView.AddNew()
                            End With

                        Case Else
                            With Me.m_objkaoqinguanliData.Tables(strTable)
                                .DefaultView.AllowNew = False
                            End With
                    End Select
                End If

                '缓存参数
                With Me.m_objkaoqinguanliData.Tables(strTable)
                    Me.htxtRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            searchModuleData = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData(strErrMsg, strQuery, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery = strQuery
                Me.htxtQuery.Value = Me.m_strQuery

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示DataGrid的数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_B_KQ_KAOQINLEXING
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objkaoqinguanliData Is Nothing Then
                    Me.grdObjects.DataSource = Nothing
                Else
                    With Me.m_objkaoqinguanliData.Tables(strTable)
                        Me.grdObjects.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objkaoqinguanliData.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdObjects, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '如果是编辑模式
                If blnEditMode = True Then
                    '移动到最后记录
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            With Me.m_objkaoqinguanliData.Tables(strTable)
                                Dim intPageIndex As Integer
                                Dim intSelectIndex As Integer
                                If objDataGridProcess.doMoveToRecord(Me.grdObjects.AllowPaging, Me.grdObjects.PageSize, .DefaultView.Count - 1, intPageIndex, intSelectIndex) = False Then
                                    strErrMsg = "错误：无法移动到最后！"
                                    GoTo errProc
                                End If
                                Try
                                    Me.grdObjects.CurrentPageIndex = intPageIndex
                                    Me.grdObjects.SelectedIndex = intSelectIndex
                                Catch ex As Exception
                                End Try
                            End With

                        Case Else
                    End Select
                End If

                '允许列排序？
                Me.grdObjects.AllowSorting = Not blnEditMode

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdObjects)
                    With Me.grdObjects.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdObjects.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdObjects, Request, 0, Me.m_cstrCheckBoxIdInDataGrid) = False Then
                    GoTo errProc
                End If

                '如果是编辑模式
                If blnEditMode = True Then
                    '使能网格
                    If objDataGridProcess.doEnabledDataGrid(strErrMsg, Me.grdObjects, Not blnEditMode) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示编辑窗的数据(根据网格当前行数据显示)
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：当前编辑状态
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditPanelInfo( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showEditPanelInfo = False

            Try
                If blnEditMode = False Then
                    '查看状态
                    If Me.grdObjects.Items.Count < 1 Then
                        Me.txtKHLXDM.Text = ""
                        Me.txtKHLXMC.Text = ""
                        Me.txtKHLXJC.Text = ""
                    ElseIf Me.grdObjects.SelectedIndex < 0 Then
                        Me.txtKHLXDM.Text = ""
                        Me.txtKHLXMC.Text = ""
                        Me.txtKHLXJC.Text = ""
                    Else
                        Dim intColIndex(3) As Integer
                        intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_DM)
                        intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_MC)
                        intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_JC)
                        Me.txtKHLXDM.Text = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(0))
                        Me.txtKHLXMC.Text = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(1))
                        Me.txtKHLXJC.Text = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(2))
                    End If
                Else
                    '编辑状态
                    '自动恢复数据
                End If

                '使能控件
                With New Josco.JsKernal.web.ControlProcess
                    .doEnabledControl(Me.txtKHLXDM, blnEditMode)
                    .doEnabledControl(Me.txtKHLXMC, blnEditMode)
                    .doEnabledControl(Me.txtKHLXJC, blnEditMode)
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showEditPanelInfo = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示整个模块的信息
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_B_KQ_KAOQINLEXING
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData = False

            Try
                '显示网格信息
                If Me.showDataGridInfo(strErrMsg, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objkaoqinguanliData.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdObjects, .Count)
                    '显示页面浏览功能
                    Me.lnkCZMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdObjects, .Count) And (Not blnEditMode)
                    Me.lnkCZMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdObjects, .Count) And (Not blnEditMode)
                    Me.lnkCZMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdObjects, .Count) And (Not blnEditMode)
                    Me.lnkCZMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdObjects, .Count) And (Not blnEditMode)
                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZDeSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZGotoPage.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZSetPageSize.Enabled = blnEnabled And (Not blnEditMode)
                    With objControlProcess
                        .doEnabledControl(Me.txtPageSize, Not blnEditMode)
                        .doEnabledControl(Me.txtPageIndex, Not blnEditMode)
                    End With

                    With objControlProcess
                        .doEnabledControl(Me.txtSearch_KHLXDM, Not blnEditMode)
                        .doEnabledControl(Me.txtSearch_KHLXMC, Not blnEditMode)
                    End With
                    Me.btnSearch.Enabled = Not blnEditMode
                End With

                '显示输入窗信息
                If Me.showEditPanelInfo(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If

                '显示操作命令
                Me.lnkMLAddNew.Enabled = (Not blnEditMode And Me.m_blnPrevilegeParams(1))
                Me.lnkMLUpdate.Enabled = (Not blnEditMode And Me.m_blnPrevilegeParams(2))
                Me.lnkMLDelete.Enabled = (Not blnEditMode And Me.m_blnPrevilegeParams(3))
                Me.lnkMLRefresh.Enabled = (Not blnEditMode And Me.m_blnPrevilegeParams(4))
                Me.lnkMLClose.Enabled = (Not blnEditMode)
                Me.btnSave.Enabled = blnEditMode
                Me.btnCancel.Enabled = blnEditMode

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 初始化控件
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            initializeControls = False

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                Try
                    '设置初始显示的静态信息

                    '根据接口参数设置不受数据影响的操作的状态

                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    With New Josco.JsKernal.web.ControlProcess
                        .doTranslateKey(Me.txtPageIndex)
                        .doTranslateKey(Me.txtPageSize)
                        .doTranslateKey(Me.txtSearch_KHLXDM)
                        .doTranslateKey(Me.txtSearch_KHLXMC)
                        .doTranslateKey(Me.txtKHLXDM)
                        .doTranslateKey(Me.txtKHLXMC)
                        .doTranslateKey(Me.txtKHLXJC)
                    End With

                    '获取数据
                    If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                    '显示数据
                    If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            End If

            initializeControls = True
            Exit Function

errProc:
            Exit Function

        End Function


        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim strUrl As String

            Dim strUserID As String = ""
            Dim strPassword As String = ""
            Dim strNewPassword As String
            Dim intStep As Integer

            Dim objsystemCustomer As Josco.JsKernal.BusinessFacade.systemCustomer = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objCustomerData As Josco.JsKernal.Common.Data.CustomerData = Nothing

            strUserID = CStr(Request.QueryString("ID"))
            strPassword = CStr(Request.QueryString("password"))


            If strUserID <> "" Then
                strPassword = CStr(Request.QueryString("password"))

                '验证
                objsystemCustomer = New Josco.JsKernal.BusinessFacade.systemCustomer
                If objsystemCustomer.doVerifyUserPassword(strErrMsg, strUserID, strPassword, strNewPassword) = False Then
                    GoTo errProc
                End If

                '获取用户信息`
                If objsystemCustomer.getRenyuanData(strErrMsg, strUserID, strPassword, "0011", objCustomerData) = False Then
                    GoTo errProc
                End If

                '记录凭证
                System.Web.Security.FormsAuthentication.SetAuthCookie("*", False)

                '缓存用户信息
                MyBase.Customer = objCustomerData
                MyBase.UserId = strUserID
                MyBase.UserOrgPassword = strPassword
                MyBase.UserPassword = strNewPassword
                MyBase.UserEnterTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                MyBase.LastScanTime_Chat = ""
                MyBase.LastScanTime_Notice = ""

                '检查密码长度
                If MyBase.doCheckPassword() = True Then
                    Exit Sub
                End If
            End If

            '预处理
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '检查权限(不论是否回发！)
            Dim blnDo As Boolean
            If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then
                GoTo normExit
            End If

            '获取接口参数
            If Me.getInterfaceParameters(strErrMsg) = False Then
                GoTo errProc
            End If

            '控件初始化
            If Me.initializeControls(strErrMsg) = False Then
                GoTo errProc
            End If

            '记录访问日志
            If Me.IsPostBack = False Then
                If Me.m_blnSaveScence = False Then
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]访问了[客户类型]字典！")
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


        '----------------------------------------------------------------
        '网格事件处理器
        '----------------------------------------------------------------
        '实现对网格行、列的固定
        Sub grdObjects_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdObjects.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdObjects.ID + "Locked"
                    Next
                End If

            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdObjects_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdObjects.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                With New Josco.JsKernal.web.DataGridProcess
                    Me.lblGridLocInfo.Text = .getDataGridLocation(Me.grdObjects, Me.m_intRows)
                End With

                '同步显示编辑窗信息
                If Me.showEditPanelInfo(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub grdObjects_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdObjects.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_B_KQ_KAOQINLEXING
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
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objkaoqinguanliData.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objkaoqinguanliData.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMoveFirst(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdObjects.PageCount)
                Me.grdObjects.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMoveLast(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdObjects.PageCount - 1, Me.grdObjects.PageCount)
                Me.grdObjects.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMoveNext(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdObjects.CurrentPageIndex + 1, Me.grdObjects.PageCount)
                Me.grdObjects.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMovePrevious(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdObjects.CurrentPageIndex - 1, Me.grdObjects.PageCount)
                Me.grdObjects.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doGotoPage(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdObjects.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtPageIndex.Text = (Me.grdObjects.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdObjects.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtPageSize.Text = (Me.grdObjects.PageSize).ToString()

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

        Private Sub doSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdObjects, 0, Me.m_cstrCheckBoxIdInDataGrid, True) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doDeSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdObjects, 0, Me.m_cstrCheckBoxIdInDataGrid, False) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doSearch(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub lnkCZMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZMoveFirst.Click
            Me.doMoveFirst("lnkCZMoveFirst")
        End Sub

        Private Sub lnkCZMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZMoveLast.Click
            Me.doMoveLast("lnkCZMoveLast")
        End Sub

        Private Sub lnkCZMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZMoveNext.Click
            Me.doMoveNext("lnkCZMoveNext")
        End Sub

        Private Sub lnkCZMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZMovePrev.Click
            Me.doMovePrevious("lnkCZMovePrev")
        End Sub

        Private Sub lnkCZGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZGotoPage.Click
            Me.doGotoPage("lnkCZGotoPage")
        End Sub

        Private Sub lnkCZSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSetPageSize.Click
            Me.doSetPageSize("lnkCZSetPageSize")
        End Sub

        Private Sub lnkCZSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSelectAll.Click
            Me.doSelectAll("lnkCZSelectAll")
        End Sub

        Private Sub lnkCZDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZDeSelectAll.Click
            Me.doDeSelectAll("lnkCZDeSelectAll")
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.doSearch("btnSearch")
        End Sub








        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doAddNew(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '设置编辑模式
                Me.m_blnEditMode = True
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                Me.m_intCurrentPageIndex = Me.grdObjects.CurrentPageIndex
                Me.m_intCurrentSelectIndex = Me.grdObjects.SelectedIndex

                '保存相关信息
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()
                Me.htxtCurrentPage.Value = Me.m_intCurrentPageIndex.ToString()
                Me.htxtCurrentRow.Value = Me.m_intCurrentSelectIndex.ToString()

                '进入编辑状态
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '显示信息
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doUpdate(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '设置编辑模式
                Me.m_blnEditMode = True
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                Me.m_intCurrentPageIndex = Me.grdObjects.CurrentPageIndex
                Me.m_intCurrentSelectIndex = Me.grdObjects.SelectedIndex

                '保存相关信息
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()
                Me.htxtCurrentPage.Value = Me.m_intCurrentPageIndex.ToString()
                Me.htxtCurrentRow.Value = Me.m_intCurrentSelectIndex.ToString()

                '进入编辑状态
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '显示信息
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doSave(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '获取新信息
                Dim objNewData As New System.Collections.Specialized.NameValueCollection
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_DM, Me.txtKHLXDM.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_MC, Me.txtKHLXMC.Text)

                '获取旧信息
                Dim objOldData As System.Data.DataRow
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        objOldData = Nothing
                    Case Else
                        '获取数据
                        If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                            GoTo errProc
                        End If

                        Dim intPos As Integer
                        With New Josco.JsKernal.web.DataGridProcess
                            intPos = .getRecordPosition(Me.grdObjects.SelectedIndex, Me.grdObjects.CurrentPageIndex, Me.grdObjects.PageSize)
                        End With
                        With Me.m_objkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_B_KQ_KAOQINLEXING)
                            objOldData = .DefaultView.Item(intPos).Row
                        End With
                End Select

                '保存信息
                With New Josco.JSOA.BusinessFacade.systemKaoqinguanli
                    If .doSaveKaoqingleixingData(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objNewData, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                End With

                '记录审计日志
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[客户类型]字典中增加了[" + Me.txtKHLXMC.Text + "]！")
                    Case Else
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]修改了[客户类型]字典！")
                End Select

                '最终设置编辑模式
                Me.m_blnEditMode = False
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect

                '保存相关信息
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()

                '设置记录位置
                '保存成功，停留在当前位置

                '重新获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '显示信息
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
            Dim intStep As Integer

            Try
                '提示信息
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备取消吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '取消编辑
                    Me.m_blnEditMode = False
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect

                    '保存相关信息
                    Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                    Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()

                    '恢复到编辑前的记录位置
                    Try
                        Me.grdObjects.CurrentPageIndex = Me.m_intCurrentPageIndex
                        Me.grdObjects.SelectedIndex = Me.m_intCurrentSelectIndex
                    Catch ex As Exception
                    End Try

                    '进入非编辑状态
                    If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    '显示信息
                    If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
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

        Private Sub doDelete(ByVal strControlId As String)

            Dim objsystemKaoqinguanli As New Josco.JSOA.BusinessFacade.systemKaoqinguanli
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdObjects.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdObjects.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要删除的内容！"
                        GoTo errProc
                    End If
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备删除选定的[" + intSelect.ToString() + "]条内容吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取数据
                    If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    '逐个删除
                    Dim objOldData As System.Data.DataRow
                    Dim intColIndex As Integer
                    Dim strKHLXMC As String
                    Dim intPos As Integer
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_MC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdObjects.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid) = True Then
                            strKHLXMC = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(i), intColIndex)

                            '获取要删除的数据
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdObjects.CurrentPageIndex, Me.grdObjects.PageSize)
                            objOldData = Nothing
                            With Me.m_objkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_B_KQ_KAOQINLEXING)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            '删除处理
                            If objsystemKaoqinguanli.doDeleteKaoqingleixingData(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData) = False Then
                                GoTo errProc
                            End If

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[客户类型]字典中删除了[" + strKHLXMC + "]！")
                        End If
                    Next

                    '重新获取数据
                    If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    '刷新网格显示
                    If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)
            Exit Sub

        End Sub

        Private Sub doRefresh(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '设置返回参数

                    '返回到调用模块，并附加返回参数
                    '要返回的SessionId
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    'SessionId附加到返回的Url
                    strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                Else
                    strUrl = Josco.JsKernal.Common.jsoaConfiguration.GeneralReturnUrl
                End If

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

        Private Sub lnkMLRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLRefresh.Click
            Me.doRefresh("lnkMLRefresh")
        End Sub

        Private Sub lnkMLAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLAddNew.Click
            Me.doAddNew("lnkMLAddNew")
        End Sub

        Private Sub lnkMLUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLUpdate.Click
            Me.doUpdate("lnkMLUpdate")
        End Sub

        Private Sub lnkMLDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDelete.Click
            Me.doDelete("lnkMLDelete")
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Me.doSave("btnSave")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub lnkMLClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub

    End Class
End Namespace