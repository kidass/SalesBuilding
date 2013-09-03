Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_bb_esywdlqd_yjwjw
    ' 
    ' 调用性质：
    '     独立运行
    '
    ' 功能描述： 
    '   　中介部二手业务代理清单(已接未结完)(片区|分行|合同)处理模块
    ' 更改记录：
    '     zengxianglin 2009-05-21 创建
    '----------------------------------------------------------------

    Partial Class estate_es_bb_esywdlqd_yjwjw
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
        Private m_cstrPrevilegeParamPrefix As String = "estate_es_baobiao_previlege_param"
        Private m_blnPrevilegeParams(27) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsBbEsywdlqdYjwjw
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsBbEsywdlqdYjwjw
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdContent相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid As String = "chkContent"
        Private Const m_cstrDataGridInDIV As String = "divContent"
        Private m_intFixedColumns As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery As String
        Private m_intRows As Integer

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------
        Private m_strGlbmSqlList As String
        Private m_blnIsFHRY As Boolean








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
                If Me.m_blnPrevilegeParams(0) = True And Me.m_blnPrevilegeParams(23) = True Then
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

            Dim strErrMsg As String = ""

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtQuery.Value = .htxtQuery
                    Me.htxtRows.Value = .htxtRows
                    Me.htxtSort.Value = .htxtSort
                    Me.htxtSortColumnIndex.Value = .htxtSortColumnIndex
                    Me.htxtSortType.Value = .htxtSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftContent.Value = .htxtDivLeftContent
                    Me.htxtDivTopContent.Value = .htxtDivTopContent

                    Me.txtPageIndex.Text = .txtPageIndex
                    Me.txtPageSize.Text = .txtPageSize

                    Try
                        Me.ddlSearch_XSJB.SelectedIndex = .ddlSearch_XSJB_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.ddlZZDM.SelectedIndex = .ddlZZDM_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.txtKSRQ.Text = .txtKSRQ
                    Me.txtZZRQ.Text = .txtZZRQ

                    Me.htxtSessionIdBuffer.Value = .htxtSessionIdBuffer
                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Try
                        Me.grdContent.PageSize = .grdContentPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdContent.CurrentPageIndex = .grdContentCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdContent.SelectedIndex = .grdContentSelectedIndex
                    Catch ex As Exception
                    End Try
                End With

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

            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '创建SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then
                    Exit Try
                End If

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsBbEsywdlqdYjwjw

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtQuery = Me.htxtQuery.Value
                    .htxtRows = Me.htxtRows.Value
                    .htxtSort = Me.htxtSort.Value
                    .htxtSortColumnIndex = Me.htxtSortColumnIndex.Value
                    .htxtSortType = Me.htxtSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftContent = Me.htxtDivLeftContent.Value
                    .htxtDivTopContent = Me.htxtDivTopContent.Value

                    .txtPageIndex = Me.txtPageIndex.Text
                    .txtPageSize = Me.txtPageSize.Text

                    .ddlSearch_XSJB_SelectedIndex = Me.ddlSearch_XSJB.SelectedIndex

                    .ddlZZDM_SelectedIndex = Me.ddlZZDM.SelectedIndex
                    .txtKSRQ = Me.txtKSRQ.Text
                    .txtZZRQ = Me.txtZZRQ.Text

                    .htxtSessionIdBuffer = Me.htxtSessionIdBuffer.Value
                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .grdContentPageSize = Me.grdContent.PageSize
                    .grdContentCurrentPageIndex = Me.grdContent.CurrentPageIndex
                    .grdContentSelectedIndex = Me.grdContent.SelectedIndex
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)
            Catch ex As Exception
            End Try

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
        ' 获取接口参数
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String) As Boolean

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            strErrMsg = ""

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsBbEsywdlqdYjwjw)
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

                '设置默认查询限制：分行只能看本单位或下级单位的票据
                Dim blnFHBZ As Boolean = True
                Dim strList As String = ""
                If objsystemEstateRenshiXingye.getBumenSqlList(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, Now.ToString("yyyy-MM-dd"), strList, blnFHBZ) = False Then
                    GoTo errProc
                End If
                If blnFHBZ = True And strList <> "" Then
                    Me.m_blnIsFHRY = True
                    Me.m_strGlbmSqlList = strList
                Else
                    Me.m_blnIsFHRY = False
                    Me.m_strGlbmSqlList = ""
                End If
                '填充列表
                If Me.IsPostBack = False Then
                    If Me.doFillZzdmList(strErrMsg, Me.ddlZZDM) = False Then
                        GoTo errProc
                    End If
                End If

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsBbEsywdlqdYjwjw)
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
                Me.m_intFixedColumns = objPulicParameters.getObjectValue(Me.htxtContentFixed.Value, 0)
                Me.m_intRows = objPulicParameters.getObjectValue(Me.htxtRows.Value, 0)
                Me.m_strQuery = Me.htxtQuery.Value
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
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

                If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                    Dim objBufferData As Josco.JSOA.Common.Data.estateErshouData = Nothing
                    Try
                        objBufferData = CType(Session(Me.htxtSessionIdBuffer.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objBufferData = Nothing
                    End Try
                    If Not (objBufferData Is Nothing) Then
                        objBufferData.Dispose()
                        objBufferData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdBuffer.Value)
                    Me.htxtSessionIdBuffer.Value = ""
                End If
            Catch ex As Exception
            End Try

        End Sub













        '----------------------------------------------------------------
        ' 获取grdContent搜索条件(rowfilter格式)
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
                '按[显示级别]搜索
                Dim strXSJB As String = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_XSJB
                Select Case Me.ddlSearch_XSJB.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strXSJB + Me.ddlSearch_XSJB.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strXSJB + Me.ddlSearch_XSJB.SelectedValue
                        End If
                End Select
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
        ' 检查报表参数
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：有效
        '     False          ：无效
        '----------------------------------------------------------------
        Private Function doCheckParam(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doCheckParam = False
            strErrMsg = ""

            Try
                If Me.txtKSRQ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[统计开始日期]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSRQ.Text) = False Then
                    strErrMsg = "错误：无效的[统计开始日期]！"
                    GoTo errProc
                End If

                If Me.txtZZRQ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[统计截止日期]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtZZRQ.Text) = False Then
                    strErrMsg = "错误：无效的[统计截止日期]！"
                    GoTo errProc
                End If

                If Me.m_blnIsFHRY = True Then
                    If Me.ddlZZDM.SelectedIndex < 0 Then
                        strErrMsg = "错误：没有指定[统计部门]！"
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            doCheckParam = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取报表参数
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：有效
        '     False          ：无效
        '----------------------------------------------------------------
        Private Function getReportParam( _
            ByRef strErrMsg As String, _
            ByRef strKSRQ As String, _
            ByRef strZZRQ As String, _
            ByRef strBMDM As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getReportParam = False
            strKSRQ = ""
            strZZRQ = ""
            strBMDM = ""

            Try
                '检查
                If Me.doCheckParam(strErrMsg) = False Then
                    GoTo errProc
                End If

                '计算
                Dim objKSRQ As System.DateTime
                Dim objZZRQ As System.DateTime
                objKSRQ = CType(Me.txtKSRQ.Text, System.DateTime)
                objZZRQ = CType(Me.txtZZRQ.Text, System.DateTime)
                If objKSRQ > objZZRQ Then
                    strKSRQ = objZZRQ.ToString("yyyy-MM-dd")
                    strZZRQ = objKSRQ.ToString("yyyy-MM-dd")
                Else
                    strKSRQ = objKSRQ.ToString("yyyy-MM-dd")
                    strZZRQ = objZZRQ.ToString("yyyy-MM-dd")
                End If

                If Me.ddlZZDM.SelectedIndex >= 0 Then
                    strBMDM = Me.ddlZZDM.SelectedItem.Value
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getReportParam = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdContent要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索字符串
        '     blnEnfored     ：强制重新计算
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnEnfored As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_VT_ES_BB_ESYWDLQD_YJWJW
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData = False

            Try
                Dim strKSRQ As String = ""
                Dim strZZRQ As String = ""
                Dim strBMDM As String = ""

                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '清除缓存
                If blnEnfored = True Then
                    If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet = CType(Session(Me.htxtSessionIdBuffer.Value), Josco.JSOA.Common.Data.estateErshouData)
                        Catch ex As Exception
                            Me.m_objDataSet = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet)
                        Session.Remove(Me.htxtSessionIdBuffer.Value)
                        Me.htxtSessionIdBuffer.Value = ""
                    End If
                End If

                '计算数据
                If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                    '从缓存获取数据
                    Me.m_objDataSet = CType(Session(Me.htxtSessionIdBuffer.Value), Josco.JSOA.Common.Data.estateErshouData)
                Else
                    '重新获取数据
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet)

                    '首次进入
                    If Me.IsPostBack = False Then
                        '不计算数据
                        Me.m_objDataSet = New Josco.JSOA.Common.Data.estateErshouData(Josco.JSOA.Common.Data.estateErshouData.enumTableType.DC_VT_ES_BB_ESYWDLQD_YJWJW)
                    Else
                        '获取参数
                        If Me.getReportParam(strErrMsg, strKSRQ, strZZRQ, strBMDM) = False Then
                            GoTo errProc
                        End If
                        '重新检索数据
                        If objsystemEstateErshou.getDataSet_BB_ESYWDLQD_YJWJW(strErrMsg, MyBase.UserId, MyBase.UserPassword, strKSRQ, strZZRQ, strBMDM, Me.m_objDataSet) = False Then
                            GoTo errProc
                        End If
                    End If

                    '缓存数据
                    Me.htxtSessionIdBuffer.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionIdBuffer.Value, Me.m_objDataSet)
                End If

                '恢复搜索字符串
                With Me.m_objDataSet.Tables(strTable)
                    .DefaultView.RowFilter = strWhere
                End With

                '恢复Sort字符串
                With Me.m_objDataSet.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet.Tables(strTable)
                    Me.htxtRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdContent数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData( _
            ByRef strErrMsg As String) As Boolean

            searchModuleData = False

            Try
                '获取搜索字符串
                Dim strQuery As String = ""
                If Me.getQueryString(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData(strErrMsg, strQuery, False) = False Then
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
        ' 显示grdContent的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_VT_ES_BB_ESYWDLQD_YJWJW
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
                If Me.m_objDataSet Is Nothing Then
                    Me.grdContent.DataSource = Nothing
                Else
                    With Me.m_objDataSet.Tables(strTable)
                        Me.grdContent.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdContent, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdContent)
                    With Me.grdContent.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdContent.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdContent, Request, 0, Me.m_cstrCheckBoxIdInDataGrid) = False Then
                '    GoTo errProc
                'End If
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
        ' 显示grdContent相关的控制信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_VT_ES_BB_ESYWDLQD_YJWJW
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData = False

            Try
                '显示网格信息
                If Me.showDataGridInfo(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdContent, .Count)

                    '显示页面浏览功能
                    Me.lnkCZMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdContent, .Count)
                    Me.lnkCZMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdContent, .Count)
                    Me.lnkCZMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdContent, .Count)
                    Me.lnkCZMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdContent, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZSelectAll.Enabled = blnEnabled
                    Me.lnkCZGotoPage.Enabled = blnEnabled
                    Me.lnkCZSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示整个模块的信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showMainData( _
            ByRef strErrMsg As String) As Boolean

            showMainData = False

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showMainData = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充组织代码下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillZzdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objDataSet As Josco.JsKernal.Common.Data.CustomerData = Nothing

            doFillZzdmList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillZzdmList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                Dim strWhere As String = ""
                strWhere = "a." + Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SFFH + " &0x1 = 0x1" + vbCr
                If Me.m_strGlbmSqlList <> "" Then
                    strWhere = strWhere + " and " + "a." + Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZDM + " in (" + Me.m_strGlbmSqlList + ")" + vbCr
                End If
                If objsystemCustomer.getBumenData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, True, True, objDataSet) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                If Me.m_blnIsFHRY = False Then
                    objDropDownList.Items.Add("")
                End If

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objDataSet.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZMC), "")
                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strCode + "|" + strName
                        objListItem.Value = strCode
                        objDropDownList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objDataSet)

            doFillZzdmList = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objDataSet)
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
                Try
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    '=======================================================================
                    objControlProcess.doTranslateKey(Me.txtPageIndex)
                    objControlProcess.doTranslateKey(Me.txtPageSize)
                    '=======================================================================
                    objControlProcess.doTranslateKey(Me.txtKSRQ)
                    objControlProcess.doTranslateKey(Me.txtZZRQ)
                    objControlProcess.doTranslateKey(Me.ddlZZDM)
                    '=======================================================================
                    objControlProcess.doTranslateKey(Me.ddlSearch_XSJB)

                    '获取数据
                    If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                        GoTo errProc
                    End If
                    '显示数据
                    If Me.showModuleData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showMainData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
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
            Dim strErrMsg As String = ""
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
            If Me.getInterfaceParameters(strErrMsg) = False Then
                GoTo errProc
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
        Sub grdContent_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdContent.ItemDataBound

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV + ".scrollTop)")
                    Next
                Else
                    Dim strFZJB As String = ""
                    Dim intFZJB As Integer
                    intFZJB = objDataGridProcess.getDataGridColumnIndex(Me.grdContent, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_XSJB)
                    strFZJB = objDataGridProcess.getDataGridCellValue(e.Item, intFZJB)
                    Select Case strFZJB
                        Case "1"
                            e.Item.BackColor = System.Drawing.Color.FromArgb(51, 153, 102)
                        Case "2"
                            e.Item.BackColor = System.Drawing.Color.FromArgb(153, 204, 0)
                        Case "3"
                            e.Item.BackColor = System.Drawing.Color.FromArgb(255, 204, 153)
                        Case "4"
                            e.Item.BackColor = System.Drawing.Color.White
                        Case Else
                    End Select
                End If
                If Me.m_intFixedColumns > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdContent.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

        End Sub

        Private Sub grdContent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdContent.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '显示记录位置
                Me.lblGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdContent, Me.m_intRows)
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

        Private Sub grdContent_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdContent.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_VT_ES_BB_ESYWDLQD_YJWJW
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem = Nothing
                Dim strFinalCommand As String = ""
                Dim strOldCommand As String = ""
                Dim strUniqueId As String = ""
                Dim intColumnIndex As Integer

                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objDataSet.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet.Tables(strTable)
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
                If Me.showModuleData(strErrMsg) = False Then
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















        Private Sub doMoveFirst(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdContent.PageCount)
                Me.grdContent.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
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
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdContent.PageCount - 1, Me.grdContent.PageCount)
                Me.grdContent.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
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
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdContent.CurrentPageIndex + 1, Me.grdContent.PageCount)
                Me.grdContent.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
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
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdContent.CurrentPageIndex - 1, Me.grdContent.PageCount)
                Me.grdContent.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
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
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdContent.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtPageIndex.Text = (Me.grdContent.CurrentPageIndex + 1).ToString()
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
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdContent.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtPageSize.Text = (Me.grdContent.PageSize).ToString()
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdContent, 0, Me.m_cstrCheckBoxIdInDataGrid, True) = False Then
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdContent, 0, Me.m_cstrCheckBoxIdInDataGrid, False) = False Then
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














        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doSearch(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
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
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
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

        Private Sub doJsbbsj(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查参数
                If Me.doCheckParam(strErrMsg) = False Then
                    GoTo errProc
                End If

                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, True) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData(strErrMsg) = False Then
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

        Private Sub doExport(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objColors As System.Collections.Specialized.ListDictionary = Nothing
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查参数
                If Me.doCheckParam(strErrMsg) = False Then
                    GoTo errProc
                End If

                '获取数据
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '获取参数
                Dim strKSRQ As String = ""
                Dim strZZRQ As String = ""
                Dim strBMDM As String = ""
                If Me.getReportParam(strErrMsg, strKSRQ, strZZRQ, strBMDM) = False Then
                    GoTo errProc
                End If
                Dim strFName As String = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_XSJB
                objColors = New System.Collections.Specialized.ListDictionary
                objColors.Add("1", System.Drawing.Color.FromArgb(51, 153, 102))
                objColors.Add("2", System.Drawing.Color.FromArgb(153, 204, 0))
                objColors.Add("3", System.Drawing.Color.FromArgb(255, 204, 153))
                Dim objZZRQ As System.DateTime = CType(strZZRQ, System.DateTime)
                Dim strBMMC As String = ""
                If Me.ddlZZDM.SelectedIndex >= 0 Then
                    strBMMC = Me.ddlZZDM.SelectedItem.Text
                End If
                strBMMC = strBMMC.Trim
                If strBMMC <> "" Then
                    strBMMC = strBMMC.Split("|".ToCharArray)(1)
                End If
                If strBMMC = "" Then
                    strBMMC = "中介部所有部门"
                End If

                '准备Excel文件
                Dim strDesExcelPath As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile
                Dim strSrcExcelSpec As String = Request.ApplicationPath + Me.m_cstrUrlBaseToExcelMB + "广州兴业_二手报表_中介部二手业务代理清单(已接未结完).xls"
                Dim strDesExcelFile As String = ""
                Dim strDesExcelSpec As String = ""
                strDesExcelPath = Server.MapPath(strDesExcelPath)
                strSrcExcelSpec = Server.MapPath(strSrcExcelSpec)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strSrcExcelSpec, strDesExcelPath, strDesExcelFile) = False Then
                    GoTo errProc
                End If
                strDesExcelSpec = objBaseLocalFile.doMakePath(strDesExcelPath, strDesExcelFile)

                '导出文件
                Dim strMacroValue As String = ""
                Dim strMacroName As String = ""
                strMacroName = "$Macro$YYYY$,$Macro$MM$,$Macro$BMMC$,$Macro$KSRQ$,$Macro$ZZRQ$"
                strMacroValue = objZZRQ.Year.ToString + "," + objZZRQ.Month.ToString + "," + strBMMC + "," + strKSRQ + "," + strZZRQ
                If objsystemEstateErshou.doExportToExcel(strErrMsg, Me.m_objDataSet, strDesExcelSpec, strFName, objColors, strMacroName, strMacroValue, "yyyy-MM-dd") = False Then
                    GoTo errProc
                End If

                '打开临时Excel文件
                Dim strUrl As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile + strDesExcelFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objColors)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objColors)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
        End Sub

        Private Sub lnkMLSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSearch.Click
            Me.doSearch("lnkMLSearch")
        End Sub

        Private Sub lnkMLJsbbsj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLJsbbsj.Click
            Me.doJsbbsj("lnkMLJsbbsj")
        End Sub

        Private Sub lnkMLExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLExport.Click
            Me.doExport("lnkMLExport")
        End Sub

        Private Sub lnkMLReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLReturn.Click
            Me.doClose("lnkMLReturn")
        End Sub

    End Class

End Namespace
