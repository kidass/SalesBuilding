Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_bb_kh_jy
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　业务精英考核表
    '
    ' 接口参数：
    '     参见接口类IEstateRsBbKhJy描述
    '
    ' 更改记录
    '     zengxianglin 2010-01-14 创建
    '     zengxianglin 2010-05-06 更改
    '----------------------------------------------------------------

    Partial Class estate_rs_bb_kh_jy
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
        Private m_cstrRelativePathToImage As String = "../../../"
        'Url根到Excel模板目录路径
        Private m_cstrUrlBaseToExcelMB As String = "/template/excel/"
        'Url根到缓存文件目录路径
        Private m_cstrUrlBaseToDownloadFile As String = "/temp/downloadfile/"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_baobiao_previlege_param"
        Private m_blnPrevilegeParams(11) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsBbKhJy
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsBbKhJy
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdTJSJ相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_TJSJ As String = "chkTJSJ"
        Private Const m_cstrDataGridInDIV_TJSJ As String = "divTJSJ"
        Private m_intFixedColumns_TJSJ As Integer

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objDataSet_TJSJ As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_strQuery_TJSJ As String
        Private m_intRows_TJSJ As Integer
        Private m_intColIndex_TJSJ(2) As Integer









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
                If Me.m_blnPrevilegeParams(0) = True And Me.m_blnPrevilegeParams(10) = True Then
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
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtTJSJSessionId.Value = .htxtTJSJSessionId
                    Me.htxtTJSJQuery.Value = .htxtTJSJQuery
                    Me.htxtTJSJRows.Value = .htxtTJSJRows
                    Me.htxtTJSJSort.Value = .htxtTJSJSort
                    Me.htxtTJSJSortColumnIndex.Value = .htxtTJSJSortColumnIndex
                    Me.htxtTJSJSortType.Value = .htxtTJSJSortType
                    Me.htxtDivLeftTJSJ.Value = .htxtDivLeftTJSJ
                    Me.htxtDivTopTJSJ.Value = .htxtDivTopTJSJ

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody

                    Me.txtTJSJPageIndex.Text = .txtTJSJPageIndex
                    Me.txtTJSJPageSize.Text = .txtTJSJPageSize

                    Try
                        Me.ddlTJSJSearch_XSJB.SelectedIndex = .ddlTJSJSearch_XSJB_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.txtTJND.Text = .txtTJND
                    Me.txtYJZR.Text = .txtYJZR
                    Try
                        Me.ddlTJJD.SelectedIndex = .ddlTJJD_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.txtJDKS.Text = .txtJDKS
                    Me.txtJDJS.Text = .txtJDJS

                    Try
                        Me.grdTJSJ.PageSize = .grdTJSJPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdTJSJ.CurrentPageIndex = .grdTJSJCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdTJSJ.SelectedIndex = .grdTJSJSelectedIndex
                    Catch ex As Exception
                    End Try
                End With

                '释放资源
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 保存模块现场信息并返回相应的SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '创建SessionId
                strSessionId = objPulicParameters.getNewGuid()
                If strSessionId = "" Then
                    Exit Try
                End If

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsBbKhJy

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtTJSJSessionId = Me.htxtTJSJSessionId.Value
                    .htxtTJSJQuery = Me.htxtTJSJQuery.Value
                    .htxtTJSJRows = Me.htxtTJSJRows.Value
                    .htxtTJSJSort = Me.htxtTJSJSort.Value
                    .htxtTJSJSortColumnIndex = Me.htxtTJSJSortColumnIndex.Value
                    .htxtTJSJSortType = Me.htxtTJSJSortType.Value
                    .htxtDivLeftTJSJ = Me.htxtDivLeftTJSJ.Value
                    .htxtDivTopTJSJ = Me.htxtDivTopTJSJ.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value

                    .txtTJSJPageIndex = Me.txtTJSJPageIndex.Text
                    .txtTJSJPageSize = Me.txtTJSJPageSize.Text

                    .ddlTJSJSearch_XSJB_SelectedIndex = Me.ddlTJSJSearch_XSJB.SelectedIndex

                    .txtTJND = Me.txtTJND.Text
                    .txtYJZR = Me.txtYJZR.Text
                    .ddlTJJD_SelectedIndex = Me.ddlTJJD.SelectedIndex

                    .txtJDKS = Me.txtJDKS.Text
                    .txtJDJS = Me.txtJDJS.Text

                    .grdTJSJPageSize = Me.grdTJSJ.PageSize
                    .grdTJSJCurrentPageIndex = Me.grdTJSJ.CurrentPageIndex
                    .grdTJSJSelectedIndex = Me.grdTJSJ.SelectedIndex
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)
            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            saveModuleInformation = strSessionId
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.IsPostBack = True Then
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
                    If Me.m_objInterface.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
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
        ' 获取接口参数(没有接口参数则显示错误信息页面)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsBbKhJy)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    '没有有接口参数
                    Me.m_blnInterface = False
                Else
                    '有接口参数
                    Me.m_blnInterface = True
                End If

                '计算列索引
                Me.m_intColIndex_TJSJ(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdTJSJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_X2_KHJG_JY_XSJB)

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsBbKhJy)
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
                Me.m_intFixedColumns_TJSJ = objPulicParameters.getObjectValue(Me.htxtTJSJFixed.Value, 0)
                Me.m_intRows_TJSJ = objPulicParameters.getObjectValue(Me.htxtTJSJRows.Value, 0)
                Me.m_strQuery_TJSJ = Me.htxtTJSJQuery.Value
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                If Me.htxtTJSJSessionId.Value.Trim <> "" Then
                    Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                    Try
                        objTempDataSet = CType(Session(Me.htxtTJSJSessionId.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objTempDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                    Session.Remove(Me.htxtTJSJSessionId.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub










        '----------------------------------------------------------------
        ' 获取grdTJSJ的搜索条件(RowFilter格式)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_TJSJ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_TJSJ = False
            strQuery = ""

            Try
                '按“显示级别”搜索
                Dim strXSJB As String = ""
                strXSJB = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_X2_KHJG_JY_XSJB
                Select Case Me.ddlTJSJSearch_XSJB.SelectedIndex
                    Case Is >= 1
                        If strQuery = "" Then
                            strQuery = strXSJB + Me.ddlTJSJSearch_XSJB.SelectedItem.Value
                        Else
                            strQuery = strQuery + vbCr + " and " + strXSJB + Me.ddlTJSJSearch_XSJB.SelectedItem.Value
                        End If
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_TJSJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 计算报表参数
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getReportParams( _
            ByRef strErrMsg As String, _
            ByRef intTJND As Integer, _
            ByRef intTJJD As Integer, _
            ByRef intYJZR As Integer) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getReportParams = False
            strErrMsg = ""

            Try
                If Me.txtTJND.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[年度]！"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtTJND.Text) = False Then
                    strErrMsg = "错误：无效的[" + Me.txtTJND.Text + "]！"
                    GoTo errProc
                End If
                intTJND = objPulicParameters.getObjectValue(Me.txtTJND.Text, 0)
                If intTJND <= 0 Then
                    strErrMsg = "错误：无效的[" + Me.txtTJND.Text + "]！"
                    GoTo errProc
                End If

                If Me.ddlTJJD.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定[季度]！"
                    GoTo errProc
                End If
                intTJJD = Me.ddlTJJD.SelectedIndex + 1

                If Me.txtYJZR.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[月截止日]！"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtYJZR.Text) = False Then
                    strErrMsg = "错误：无效的[" + Me.txtYJZR.Text + "]！"
                    GoTo errProc
                End If
                intYJZR = objPulicParameters.getObjectValue(Me.txtYJZR.Text, 0)
                If intYJZR <= 0 Then
                    strErrMsg = "错误：无效的[" + Me.txtYJZR.Text + "]！"
                    GoTo errProc
                End If
                If intYJZR > 28 Then
                    strErrMsg = "错误：无效的[" + Me.txtYJZR.Text + "]！"
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getReportParams = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 计算报表参数
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getReportParams( _
            ByRef strErrMsg As String, _
            ByRef strJDKS As String, _
            ByRef strJDJS As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getReportParams = False
            strErrMsg = ""
            strJDKS = ""
            strJDJS = ""

            Try
                If Me.txtJDKS.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[考核季度开始日期]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtJDKS.Text) = False Then
                    strErrMsg = "错误：无效的[" + Me.txtJDKS.Text + "]！"
                    GoTo errProc
                End If
                strJDKS = objPulicParameters.getObjectValue(Me.txtJDKS.Text, "", "yyyy-MM-dd")

                If Me.txtJDJS.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[考核季度结束日期]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtJDJS.Text) = False Then
                    strErrMsg = "错误：无效的[" + Me.txtJDJS.Text + "]！"
                    GoTo errProc
                End If
                strJDJS = objPulicParameters.getObjectValue(Me.txtJDJS.Text, "", "yyyy-MM-dd")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getReportParams = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdTJSJ要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        '     blnEnforced    ：强制重新计算
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_TJSJ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnEnforced As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_VT_RS_X2_KHJG_JY
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_TJSJ = False

            Try
                Dim strJDKS As String = ""
                Dim strJDJS As String = ""
                Dim intTJND As Integer
                Dim intTJJD As Integer
                Dim intYJZR As Integer

                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtTJSJSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '检索数据
                If blnEnforced = True Then
                    '释放资源
                    If Me.htxtTJSJSessionId.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_TJSJ = CType(Session(Me.htxtTJSJSessionId.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Catch ex As Exception
                            Me.m_objDataSet_TJSJ = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_TJSJ)
                    Else
                        Me.htxtTJSJSessionId.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtTJSJSessionId.Value, Nothing)
                    End If
                    '其他计算
                    If Me.getReportParams(strErrMsg, strJDKS, strJDJS) = False Then
                        GoTo errProc
                    End If
                    If objsystemEstateRenshiXingye.getDataSet_TJBB_X2_KHJG_JY(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJDKS, strJDJS, "", Me.m_objDataSet_TJSJ) = False Then
                        GoTo errProc
                    End If
                    Session(Me.htxtTJSJSessionId.Value) = Me.m_objDataSet_TJSJ
                Else
                    If Me.htxtTJSJSessionId.Value.Trim = "" Then
                        '初始数据
                        Me.m_objDataSet_TJSJ = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_VT_RS_X2_KHJG_JY)
                        '缓存数据
                        Me.htxtTJSJSessionId.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtTJSJSessionId.Value, Me.m_objDataSet_TJSJ)
                    Else
                        '缓存获取数据
                        Try
                            Me.m_objDataSet_TJSJ = CType(Session(Me.htxtTJSJSessionId.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Catch ex As Exception
                            Me.m_objDataSet_TJSJ = Nothing
                        End Try
                    End If
                End If

                '恢复RowFilter
                With Me.m_objDataSet_TJSJ.Tables(strTable)
                    .DefaultView.RowFilter = strWhere
                End With

                '恢复Sort字符串
                With Me.m_objDataSet_TJSJ.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_TJSJ.Tables(strTable)
                    Me.htxtTJSJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_TJSJ = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_TJSJ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdTJSJ数据
        '     strErrMsg      ：返回错误信息
        '     blnEnforced    ：强制重新计算
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_TJSJ( _
            ByRef strErrMsg As String, _
            ByVal blnEnforced As Boolean) As Boolean

            searchModuleData_TJSJ = False

            Try
                '获取搜索字符串
                Dim strQuery As String = ""
                If Me.getQueryString_TJSJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_TJSJ(strErrMsg, strQuery, blnEnforced) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_TJSJ = strQuery
                Me.htxtTJSJQuery.Value = Me.m_strQuery_TJSJ
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_TJSJ = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Function doRefresh_TJSJ(ByRef strErrMsg As String, ByVal blnEnforced As Boolean) As Boolean

            doRefresh_TJSJ = False
            strErrMsg = ""

            Try
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, blnEnforced) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doRefresh_TJSJ = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdTJSJ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_TJSJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_VT_RS_X2_KHJG_JY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_TJSJ = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtTJSJSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtTJSJSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_TJSJ Is Nothing Then
                    Me.grdTJSJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_TJSJ.Tables(strTable)
                        Me.grdTJSJ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_TJSJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdTJSJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdTJSJ)
                    With Me.grdTJSJ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdTJSJ.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdTJSJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_TJSJ) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_TJSJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdTJSJ及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_TJSJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_VT_RS_X2_KHJG_JY
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_TJSJ = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_TJSJ.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblTJSJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdTJSJ, .Count)

                    '显示页面浏览功能
                    Me.lnkCZTJSJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdTJSJ, .Count)
                    Me.lnkCZTJSJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdTJSJ, .Count)
                    Me.lnkCZTJSJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdTJSJ, .Count)
                    Me.lnkCZTJSJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdTJSJ, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZTJSJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZTJSJSelectAll.Enabled = blnEnabled
                    Me.lnkCZTJSJGotoPage.Enabled = blnEnabled
                    Me.lnkCZTJSJSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_TJSJ = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 控制界面上其他的显示元素
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

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            Try
                '仅在第一次调用页面时执行
                If Me.IsPostBack = False Then
                    '显示Pannel
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.txtTJSJPageIndex)
                    objControlProcess.doTranslateKey(Me.txtTJSJPageSize)
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.ddlTJSJSearch_XSJB)
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.txtTJND)
                    objControlProcess.doTranslateKey(Me.txtYJZR)
                    objControlProcess.doTranslateKey(Me.ddlTJJD)
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.txtJDKS)
                    objControlProcess.doTranslateKey(Me.txtJDJS)
                    '====================================================================

                    '显示其他元素
                    If Me.showModuleData_MAIN(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '初始化
                    If Me.m_blnSaveScence = False Then
                        Me.txtTJND.Text = Now.Year.ToString
                        Select Case Now.Month
                            Case 1, 2, 3
                                Me.ddlTJJD.SelectedIndex = 0
                            Case 4, 5, 6
                                Me.ddlTJJD.SelectedIndex = 1
                            Case 7, 8, 9
                                Me.ddlTJJD.SelectedIndex = 2
                            Case Else
                                Me.ddlTJJD.SelectedIndex = 3
                        End Select
                    End If
                    If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_TJSJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strUrl As String = ""
            Dim blnDo As Boolean

            '预处理
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '检查权限(不论是否回发！)
            If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then
                GoTo normExit
            End If

            '获取接口参数
            If Me.getInterfaceParameters(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then
                GoTo normExit
            End If

            '控件初始化
            If Me.initializeControls(strErrMsg) = False Then
                GoTo errProc
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
        Sub grdTJSJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdTJSJ.ItemDataBound

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_TJSJ + ".scrollTop)")
                    Next
                Else
                    If Me.htxtTJSJColor.Value = "1" Then
                        '根据数据调整显示
                        Dim intColIndex(2) As Integer
                        Dim strValue(2) As String
                        Dim intValue(2) As Integer
                        intColIndex(0) = Me.m_intColIndex_TJSJ(0)
                        strValue(0) = objDataGridProcess.getDataGridCellValue(e.Item, intColIndex(0))
                        intValue(0) = objPulicParameters.getObjectValue(strValue(0), 0)
                        Select Case intValue(0)
                            Case 1
                                e.Item.BackColor = System.Drawing.Color.FromArgb(255, 102, 51)
                            Case 2
                                e.Item.BackColor = System.Drawing.Color.FromArgb(255, 153, 51)
                            Case 3
                                e.Item.BackColor = System.Drawing.Color.FromArgb(204, 255, 255)
                            Case Else
                                e.Item.BackColor = System.Drawing.Color.White
                        End Select
                    End If
                End If
                If Me.m_intFixedColumns_TJSJ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_TJSJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdTJSJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub grdTJSJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTJSJ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblTJSJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdTJSJ, Me.m_intRows_TJSJ)
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

        Private Sub grdTJSJ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdTJSJ.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_VT_RS_X2_KHJG_JY
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
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_TJSJ.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_TJSJ.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtTJSJSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtTJSJSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtTJSJSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
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










        Private Sub doMoveFirst_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '获取数据
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdTJSJ.PageCount)
                Me.grdTJSJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
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

        Private Sub doMoveLast_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '获取数据
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdTJSJ.PageCount - 1, Me.grdTJSJ.PageCount)
                Me.grdTJSJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
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

        Private Sub doMoveNext_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '获取数据
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdTJSJ.CurrentPageIndex + 1, Me.grdTJSJ.PageCount)
                Me.grdTJSJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
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

        Private Sub doMovePrevious_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '获取数据
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdTJSJ.CurrentPageIndex - 1, Me.grdTJSJ.PageCount)
                Me.grdTJSJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
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

        Private Sub doGotoPage_TJSJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtTJSJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdTJSJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtTJSJPageIndex.Text = (Me.grdTJSJ.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_TJSJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtTJSJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdTJSJ.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtTJSJPageSize.Text = (Me.grdTJSJ.PageSize).ToString()
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

        Private Sub doSelectAll_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdTJSJ, 0, Me.m_cstrCheckBoxIdInDataGrid_TJSJ, True) = False Then
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

        Private Sub doDeSelectAll_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdTJSJ, 0, Me.m_cstrCheckBoxIdInDataGrid_TJSJ, False) = False Then
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

        Private Sub lnkCZTJSJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJMoveFirst.Click
            Me.doMoveFirst_TJSJ("lnkCZTJSJMoveFirst")
        End Sub

        Private Sub lnkCZTJSJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJMoveLast.Click
            Me.doMoveLast_TJSJ("lnkCZTJSJMoveLast")
        End Sub

        Private Sub lnkCZTJSJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJMoveNext.Click
            Me.doMoveNext_TJSJ("lnkCZTJSJMoveNext")
        End Sub

        Private Sub lnkCZTJSJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJMovePrev.Click
            Me.doMovePrevious_TJSJ("lnkCZTJSJMovePrev")
        End Sub

        Private Sub lnkCZTJSJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJGotoPage.Click
            Me.doGotoPage_TJSJ("lnkCZTJSJGotoPage")
        End Sub

        Private Sub lnkCZTJSJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJSetPageSize.Click
            Me.doSetPageSize_TJSJ("lnkCZTJSJSetPageSize")
        End Sub

        Private Sub lnkCZTJSJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJSelectAll.Click
            Me.doSelectAll_TJSJ("lnkCZTJSJSelectAll")
        End Sub

        Private Sub lnkCZTJSJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJDeSelectAll.Click
            Me.doDeSelectAll_TJSJ("lnkCZTJSJDeSelectAll")
        End Sub











        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
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

        Private Sub doCompute(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '计算参数
                Dim strJDKS As String = ""
                Dim strJDJS As String = ""
                Dim intTJND As Integer
                Dim intTJJD As Integer
                Dim intYJZR As Integer
                If Me.getReportParams(strErrMsg, strJDKS, strJDJS) = False Then
                    GoTo errProc
                End If

                '计算数据
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, True) = False Then
                    GoTo errProc
                End If

                '显示数据
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objColors As System.Collections.Specialized.ListDictionary = Nothing
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strJDKS As String = ""
                Dim strJDJS As String = ""
                If Me.getReportParams(strErrMsg, strJDKS, strJDJS) = False Then
                    GoTo errProc
                End If
                '获取数据
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '准备Excel文件
                Dim strDesExcelPath As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile
                Dim strSrcExcelSpec As String = Request.ApplicationPath + Me.m_cstrUrlBaseToExcelMB + "广州兴业_人事管理_业务精英考核表.xls"
                Dim strDesExcelFile As String = ""
                Dim strDesExcelSpec As String = ""
                strDesExcelPath = Server.MapPath(strDesExcelPath)
                strSrcExcelSpec = Server.MapPath(strSrcExcelSpec)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strSrcExcelSpec, strDesExcelPath, strDesExcelFile) = False Then
                    GoTo errProc
                End If
                strDesExcelSpec = objBaseLocalFile.doMakePath(strDesExcelPath, strDesExcelFile)

                '导出文件
                Dim strFName As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_X2_KHJG_JY_XSJB
                Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                Dim strMacroValue As String = ""
                Dim strMacroName As String = ""
                Dim objZZRQ As System.DateTime = CType(strJDJS, System.DateTime)
                Dim intTJJD As Integer
                Select Case objZZRQ.Month
                    Case 1, 2, 3
                        intTJJD = 1
                    Case 4, 5, 6
                        intTJJD = 2
                    Case 7, 8, 9
                        intTJJD = 3
                    Case Else
                        intTJJD = 4
                End Select
                strMacroName = "TJND"
                strMacroValue = objZZRQ.Year.ToString
                strMacroName = strMacroName + strSep + "TJJD"
                strMacroValue = strMacroValue + strSep + intTJJD.ToString
                objColors = New System.Collections.Specialized.ListDictionary
                objColors.Add("1", System.Drawing.Color.FromArgb(255, 102, 51))
                objColors.Add("2", System.Drawing.Color.FromArgb(255, 153, 51))
                objColors.Add("3", System.Drawing.Color.FromArgb(204, 255, 255))
                If objsystemEstateRenshiXingye.doExportToExcel(strErrMsg, Me.m_objDataSet_TJSJ, strDesExcelSpec, strFName, objColors, strMacroName, strMacroValue, "yyyy-MM-dd") = False Then
                    GoTo errProc
                End If

                '打开临时Excel文件
                Dim strUrl As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile + strDesExcelFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doSearch_TJSJ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_TJSJ(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
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

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnCompute_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompute.Click
            Me.doCompute("btnCompute")
        End Sub

        Private Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
            Me.doSearch_TJSJ("btnDisplay")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

    End Class

End Namespace