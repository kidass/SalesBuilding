Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_bb_esyjfpb
    ' 
    ' 调用性质：
    '     独立运行
    '
    ' 功能描述： 
    '   　中介部二手佣金分配表处理模块
    ' 更改记录：
    '     zengxianglin 2009-05-19 更改
    '     zengxianglin 2009-05-21 更改
    '----------------------------------------------------------------

    Partial Class estate_es_bb_esyjfpb
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsBbEsYjfpb
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsBbEsYjfpb
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
        Private m_objDataSet As System.Data.DataSet
        Private m_strQuery As String
        Private m_intRows As Integer

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------
        Private m_strSelectedNodeIndex As String
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
                If Me.m_blnPrevilegeParams(0) = True And Me.m_blnPrevilegeParams(18) = True Then
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
                        Me.ddlZZDM.SelectedIndex = .ddlZZDM_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.txtKSRQ.Text = .txtKSRQ
                    Me.txtZZRQ.Text = .txtZZRQ
                    Me.txtLVBL.Text = .txtLVBL

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

                    'zengxianglin 2009-05-19
                    m_strSelectedNodeIndex = .tvwTJBM_SelectedNodeIndex
                    'zengxianglin 2009-05-19
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsBbEsYjfpb

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

                    .ddlZZDM_SelectedIndex = Me.ddlZZDM.SelectedIndex
                    .txtKSRQ = Me.txtKSRQ.Text
                    .txtZZRQ = Me.txtZZRQ.Text
                    .txtLVBL = Me.txtLVBL.Text

                    .htxtSessionIdBuffer = Me.htxtSessionIdBuffer.Value
                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .grdContentPageSize = Me.grdContent.PageSize
                    .grdContentCurrentPageIndex = Me.grdContent.CurrentPageIndex
                    .grdContentSelectedIndex = Me.grdContent.SelectedIndex

                    'zengxianglin 2009-05-19
                    .tvwTJBM_SelectedNodeIndex = Me.tvwTJBM.SelectedNodeIndex
                    'zengxianglin 2009-05-19
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsBbEsYjfpb)
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
                'zengxianglin 2009-05-19
                '显示部门列表
                If Me.IsPostBack = False Then
                    If Me.showTreeViewInfo_TJBM(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2009-05-19

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsBbEsYjfpb)
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

                If Me.txtLVBL.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[律师费私佣计提比例]！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtLVBL.Text) = False Then
                    strErrMsg = "错误：无效的[律师费私佣计提比例]！"
                    GoTo errProc
                End If

                If Me.m_blnIsFHRY = True Then
                    If Me.ddlZZDM.SelectedIndex < 0 Then
                        strErrMsg = "错误：必须选定[单位]！"
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
        ' 检查报表参数(多部门输出)
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：有效
        '     False          ：无效
        ' 更改记录
        '     zengxianglin 2009-05-19 创建
        '----------------------------------------------------------------
        Private Function doCheckParam01(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doCheckParam01 = False
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

                If Me.txtLVBL.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[律师费私佣计提比例]！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtLVBL.Text) = False Then
                    strErrMsg = "错误：无效的[律师费私佣计提比例]！"
                    GoTo errProc
                End If

                Dim intSelected As Integer = 0
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.tvwTJBM.Nodes.Count
                For i = 0 To intCount - 1 Step 1
                    If Me.tvwTJBM.Nodes(i).Checked = True Then
                        intSelected = intSelected + 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "错误：必须选定[统计部门]！"
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            doCheckParam01 = True
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
            ByRef strBMDM As String, _
            ByRef dblLVBL As Double) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getReportParam = False
            strKSRQ = ""
            strZZRQ = ""
            strBMDM = ""
            dblLVBL = 0

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

                dblLVBL = objPulicParameters.getObjectValue(Me.txtLVBL.Text, 0.0)
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
        ' 获取报表参数(多部门输出)
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：有效
        '     False          ：无效
        ' 更改记录
        '     zengxianglin 2009-05-19 创建
        '----------------------------------------------------------------
        Private Function getReportParam01( _
            ByRef strErrMsg As String, _
            ByRef strKSRQ As String, _
            ByRef strZZRQ As String, _
            ByRef dblLVBL As Double) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getReportParam01 = False
            strKSRQ = ""
            strZZRQ = ""
            dblLVBL = 0

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

                dblLVBL = objPulicParameters.getObjectValue(Me.txtLVBL.Text, 0.0)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getReportParam01 = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 从指定节点获取[部门代码]
        '     strErrMsg      ：返回错误信息
        '     strNodeIndex   ：节点索引
        '     strUuidXM      ：(返回)项目标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2009-05-19 创建
        '----------------------------------------------------------------
        Private Function getTreeviewNodeInfo( _
            ByRef strErrMsg As String, _
            ByVal strNodeIndex As String, _
            ByRef strBMDM As String) As Boolean

            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess

            getTreeviewNodeInfo = False
            strErrMsg = ""
            strBMDM = ""

            Try
                '检查
                If strNodeIndex Is Nothing Then strNodeIndex = ""
                strNodeIndex = strNodeIndex.Trim
                If strNodeIndex = "" Then
                    Exit Try
                End If

                '计算
                Dim objNode1 As Microsoft.Web.UI.WebControls.TreeNode = Nothing
                objNode1 = Me.tvwTJBM.GetNodeFromIndex(strNodeIndex)
                strBMDM = objTreeviewProcess.getCodeValueFromNodeId(objNode1.ID)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)

            getTreeviewNodeInfo = True
            Exit Function
errProc:
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
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

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim intTable As Integer = 0

            getModuleData = False

            Try
                Dim strKSRQ As String = ""
                Dim strZZRQ As String = ""
                Dim strBMDM As String = ""
                Dim dblLVBL As Double

                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '清除缓存
                If blnEnfored = True Then
                    If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet = CType(Session(Me.htxtSessionIdBuffer.Value), System.Data.DataSet)
                        Catch ex As Exception
                            Me.m_objDataSet = Nothing
                        End Try
                        Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(Me.m_objDataSet)
                        Session.Remove(Me.htxtSessionIdBuffer.Value)
                        Me.htxtSessionIdBuffer.Value = ""
                    End If
                End If

                '计算数据
                If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                    '从缓存获取数据
                    Me.m_objDataSet = CType(Session(Me.htxtSessionIdBuffer.Value), System.Data.DataSet)
                Else
                    '重新获取数据
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(Me.m_objDataSet)

                    '首次进入
                    If Me.IsPostBack = False Then
                        '不计算数据
                        Me.m_objDataSet = New Josco.JSOA.Common.Data.estateErshouData(Josco.JSOA.Common.Data.estateErshouData.enumTableType.DC_VT_ES_BB_YJFPB)
                    Else
                        '获取参数
                        If Me.getReportParam(strErrMsg, strKSRQ, strZZRQ, strBMDM, dblLVBL) = False Then
                            GoTo errProc
                        End If
                        '重新检索数据
                        If objsystemEstateErshou.getDataSet_BB_ESYJFPB(strErrMsg, MyBase.UserId, MyBase.UserPassword, strKSRQ, strZZRQ, strBMDM, dblLVBL, Me.m_objDataSet) = False Then
                            GoTo errProc
                        End If
                    End If

                    '缓存数据
                    Me.htxtSessionIdBuffer.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionIdBuffer.Value, Me.m_objDataSet)
                End If

                '恢复搜索字符串
                With Me.m_objDataSet.Tables(intTable)
                    .DefaultView.RowFilter = strWhere
                End With

                '恢复Sort字符串
                With Me.m_objDataSet.Tables(intTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet.Tables(intTable)
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
        ' 获取报表要输出的数据(多部门统计)
        '     strErrMsg      ：返回错误信息
        '     strBMDM        ：部门代码
        '     strWhere       ：搜索字符串
        '     objDataSet     ：统计数据集(返回)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2009-05-19 创建
        '----------------------------------------------------------------
        Private Function getModuleData01( _
            ByRef strErrMsg As String, _
            ByVal strBMDM As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As System.Data.DataSet) As Boolean

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim intTable As Integer = 0

            getModuleData01 = False

            Try
                Dim strKSRQ As String = ""
                Dim strZZRQ As String = ""
                Dim dblLVBL As Double

                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '获取参数
                If Me.getReportParam01(strErrMsg, strKSRQ, strZZRQ, dblLVBL) = False Then
                    GoTo errProc
                End If
                '重新检索数据
                If objsystemEstateErshou.getDataSet_BB_ESYJFPB(strErrMsg, MyBase.UserId, MyBase.UserPassword, strKSRQ, strZZRQ, strBMDM, dblLVBL, objDataSet) = False Then
                    GoTo errProc
                End If

                '恢复搜索字符串
                With objDataSet.Tables(intTable)
                    .DefaultView.RowFilter = strWhere
                End With

                '恢复Sort字符串
                With objDataSet.Tables(intTable)
                    .DefaultView.Sort = strSort
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData01 = True
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intTable As Integer = 0

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
                    With Me.m_objDataSet.Tables(intTable)
                        Me.grdContent.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet.Tables(intTable)
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

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intTable As Integer = 0

            showModuleData = False

            Try
                '显示网格信息
                If Me.showDataGridInfo(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet.Tables(intTable).DefaultView
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
        ' 显示tvwTJBM的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2009-05-19 创建
        '----------------------------------------------------------------
        Private Function showTreeViewInfo_TJBM(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objDataSet As Josco.JsKernal.Common.Data.CustomerData = Nothing
            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess

            showTreeViewInfo_TJBM = False
            strErrMsg = ""

            Try
                '备份当前项
                Dim strSelectedIndex As String = ""
                strSelectedIndex = Me.tvwTJBM.SelectedNodeIndex

                '清空数据
                Me.tvwTJBM.Nodes.Clear()

                '获取数据
                Dim strWhere As String = ""
                strWhere = "a." + Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SFFH + " &0x1 = 0x1" + vbCr
                If Me.m_strGlbmSqlList <> "" Then
                    strWhere = strWhere + " and " + "a." + Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZDM + " in (" + Me.m_strGlbmSqlList + ")" + vbCr
                End If
                If objsystemCustomer.getBumenData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, True, True, objDataSet) = False Then
                    GoTo errProc
                End If

                '显示数据
                Dim objNode1 As Microsoft.Web.UI.WebControls.TreeNode = Nothing
                Dim strBMDM As String = ""
                Dim strBMMC As String = ""
                Dim i As Integer
                With objDataSet.Tables(strTable)
                    For i = 0 To .Rows.Count - 1 Step 1
                        '计算新节点信息
                        strBMDM = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZDM), "")
                        strBMMC = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZMC), "")
                        '创建节点
                        objNode1 = New Microsoft.Web.UI.WebControls.TreeNode
                        '添加节点
                        objNode1.Text = strBMMC
                        Me.tvwTJBM.Nodes.Add(objNode1)
                        '设置ID及其他
                        objNode1.ID = objTreeviewProcess.getNodeId("A", objNode1.GetNodeIndex(), strBMDM)
                        objNode1.Expandable = Microsoft.Web.UI.WebControls.ExpandableValue.Auto
                        objNode1.CheckBox = True
                    Next
                End With

                '尝试恢复当前节点
                If strSelectedIndex <> "" Then
                    objNode1 = Me.tvwTJBM.GetNodeFromIndex(strSelectedIndex)
                    If Not (objNode1 Is Nothing) Then
                        Me.tvwTJBM.SelectedNodeIndex = objNode1.GetNodeIndex()
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objDataSet)

            showTreeViewInfo_TJBM = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
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
                    objControlProcess.doTranslateKey(Me.txtLVBL)
                    objControlProcess.doTranslateKey(Me.ddlZZDM)
                    '=======================================================================

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
                    intFZJB = objDataGridProcess.getDataGridColumnIndex(Me.grdContent, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_VT_ES_BB_YJFPB_XSJB)
                    strFZJB = objDataGridProcess.getDataGridCellValue(e.Item, intFZJB)
                    Select Case strFZJB
                        Case "1"
                            e.Item.BackColor = System.Drawing.Color.FromArgb(51, 153, 102)
                        Case "2"
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

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intTable As Integer = 0

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
                With Me.m_objDataSet.Tables(intTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet.Tables(intTable)
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










        'zengxianglin 2009-05-21
        Private Sub doSelectAllTJBM(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.tvwTJBM.Nodes.Count
                For i = 0 To intCount - 1 Step 1
                    Me.tvwTJBM.Nodes(i).Checked = True
                Next
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
        'zengxianglin 2009-05-21

        'zengxianglin 2009-05-21
        Private Sub doDeSelectAllTJBM(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.tvwTJBM.Nodes.Count
                For i = 0 To intCount - 1 Step 1
                    Me.tvwTJBM.Nodes(i).Checked = False
                Next
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
        'zengxianglin 2009-05-21

        'zengxianglin 2009-05-21
        Private Sub lnkCZSelectAllTJBM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSelectAllTJBM.Click
            Me.doSelectAllTJBM("lnkCZSelectAllTJBM")
        End Sub
        'zengxianglin 2009-05-21

        'zengxianglin 2009-05-21
        Private Sub lnkCZDeSelectAllTJBM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZDeSelectAllTJBM.Click
            Me.doDeSelectAllTJBM("lnkCZDeSelectAllTJBM")
        End Sub
        'zengxianglin 2009-05-21










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
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objColors As System.Collections.Specialized.ListDictionary = Nothing
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataTable As System.Data.DataTable = Nothing
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
                If Me.m_objDataSet.Tables.Count < 3 Then
                    strErrMsg = "错误：还没有计算数据！"
                    GoTo errProc
                End If

                '获取参数
                Dim strKSRQ As String = ""
                Dim strZZRQ As String = ""
                Dim strBMDM As String = ""
                Dim dblLVBL As Double
                If Me.getReportParam(strErrMsg, strKSRQ, strZZRQ, strBMDM, dblLVBL) = False Then
                    GoTo errProc
                End If
                Dim objZZRQ As System.DateTime = CType(strZZRQ, System.DateTime)
                Dim strBMMC As String = ""
                If Me.ddlZZDM.SelectedIndex >= 0 Then
                    strBMMC = Me.ddlZZDM.SelectedItem.Text
                    If strBMMC <> "" Then
                        strBMMC = strBMMC.Split("|".ToCharArray)(1)
                    End If
                End If
                If strBMMC = "" Then strBMMC = "所有"
                Dim strFName As String = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_VT_ES_BB_YJFPB_XSJB
                objColors = New System.Collections.Specialized.ListDictionary
                objColors.Add("1", System.Drawing.Color.FromArgb(51, 153, 102))

                '准备Excel文件
                Dim strDesExcelPath As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile
                Dim strSrcExcelSpec As String = Request.ApplicationPath + Me.m_cstrUrlBaseToExcelMB + "广州兴业_二手报表_中介部二手佣金分配表.xls"
                Dim strDesExcelFile As String = ""
                Dim strDesExcelSpec As String = ""
                strDesExcelPath = Server.MapPath(strDesExcelPath)
                strSrcExcelSpec = Server.MapPath(strSrcExcelSpec)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strSrcExcelSpec, strDesExcelPath, strDesExcelFile) = False Then
                    GoTo errProc
                End If
                strDesExcelSpec = objBaseLocalFile.doMakePath(strDesExcelPath, strDesExcelFile)

                '导出文件
                Dim intQJ As Integer = Me.m_objDataSet.Tables(1).Rows.Count
                Dim strBL(intQJ) As String
                Dim strQJ(intQJ) As String
                Dim strMin As String = ""
                Dim strMax As String = ""
                Dim i As Integer
                With Me.m_objDataSet.Tables(1)
                    For i = 0 To intQJ - 1 Step 1
                        strBL(i) = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                        strMin = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_QJZX), "", "##0", True)
                        strMax = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_QJZD), "", "##0", True)
                        Select Case i
                            Case 0
                                strQJ(i) = strMax + "以内"
                            Case intQJ - 1
                                strQJ(i) = strMin + "以上"
                            Case Else
                                strQJ(i) = strMin + "-" + strMax
                        End Select
                    Next
                End With

                Dim strMacroValue As String
                Dim strMacroName As String
                strMacroName = "KSRQ"
                strMacroValue = strKSRQ
                strMacroName = strMacroName + "," + "ZZRQ"
                strMacroValue = strMacroValue + "," + strZZRQ
                strMacroName = strMacroName + "," + "BMMC"
                strMacroValue = strMacroValue + "," + strBMMC
                For i = 0 To intQJ - 1 Step 1
                    strMacroName = strMacroName + "," + "SYBL" + Right("00" + (i + 1).ToString, 3)
                    strMacroValue = strMacroValue + "," + strBL(i)
                    strMacroName = strMacroName + "," + "SYQJ" + Right("00" + (i + 1).ToString, 3)
                    strMacroValue = strMacroValue + "," + strQJ(i)
                Next
                Dim strFilter As String = ""
                With Me.m_objDataSet.Tables(2)
                    strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZGBJ + " = 1"
                    strFilter = strFilter + " and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_YYJL.Value + ")"
                    .DefaultView.RowFilter = strFilter
                    If .DefaultView.Count > 0 Then
                        strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                        strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                    Else
                        strMin = "0.00%"
                        strMax = "0.00%"
                    End If
                End With
                strMacroName = strMacroName + "," + "YYJLZGJT"
                strMacroValue = strMacroValue + "," + strMin
                strMacroName = strMacroName + "," + "YYJLZGBL"
                strMacroValue = strMacroValue + "," + strMax

                With Me.m_objDataSet.Tables(2)
                    strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZGBJ + " = 0"
                    strFilter = strFilter + " and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_YYJL.Value + ")"
                    .DefaultView.RowFilter = strFilter
                    If .DefaultView.Count > 0 Then
                        strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                        strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                    Else
                        strMin = "0.00%"
                        strMax = "0.00%"
                    End If
                End With
                strMacroName = strMacroName + "," + "YYJLXGJT"
                strMacroValue = strMacroValue + "," + strMin
                strMacroName = strMacroName + "," + "YYJLXGBL"
                strMacroValue = strMacroValue + "," + strMax

                With Me.m_objDataSet.Tables(2)
                    strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_QYJL.Value + ")"
                    .DefaultView.RowFilter = strFilter
                    If .DefaultView.Count > 0 Then
                        strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                        strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                    Else
                        strMin = "0.00%"
                        strMax = "0.00%"
                    End If
                End With
                strMacroName = strMacroName + "," + "QYJLJT"
                strMacroValue = strMacroValue + "," + strMin
                strMacroName = strMacroName + "," + "QYJLBL"
                strMacroValue = strMacroValue + "," + strMax

                With Me.m_objDataSet.Tables(2)
                    strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_QYZJ.Value + ")"
                    .DefaultView.RowFilter = strFilter
                    If .DefaultView.Count > 0 Then
                        strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                        strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                    Else
                        strMin = "0.00%"
                        strMax = "0.00%"
                    End If
                End With
                strMacroName = strMacroName + "," + "QYZJJT"
                strMacroValue = strMacroValue + "," + strMin
                strMacroName = strMacroName + "," + "QYZJBL"
                strMacroValue = strMacroValue + "," + strMax

                With Me.m_objDataSet.Tables(2)
                    strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_YWJL.Value + ")"
                    .DefaultView.RowFilter = strFilter
                    If .DefaultView.Count > 0 Then
                        strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                        strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                    Else
                        strMin = "0.00%"
                        strMax = "0.00%"
                    End If
                End With
                strMacroName = strMacroName + "," + "YWJLJT"
                strMacroValue = strMacroValue + "," + strMin
                strMacroName = strMacroName + "," + "YWJLBL"
                strMacroValue = strMacroValue + "," + strMax

                With Me.m_objDataSet.Tables(2)
                    strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_XZZL.Value + ")"
                    .DefaultView.RowFilter = strFilter
                    If .DefaultView.Count > 0 Then
                        strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                        strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                    Else
                        strMin = "0.00%"
                        strMax = "0.00%"
                    End If
                End With
                strMacroName = strMacroName + "," + "XZZLJT"
                strMacroValue = strMacroValue + "," + strMin
                strMacroName = strMacroName + "," + "XZZLBL"
                strMacroValue = strMacroValue + "," + strMax

                '输出数据
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
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objColors)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objColors)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
        End Sub

        'zengxianglin 2009-05-19 创建
        Private Sub doExportSelect(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objColors As System.Collections.Specialized.ListDictionary = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strErrMsg As String = ""

            Try
                '检查参数
                If Me.doCheckParam01(strErrMsg) = False Then
                    GoTo errProc
                End If

                '获取参数
                Dim strKSRQ As String = ""
                Dim strZZRQ As String = ""
                Dim dblLVBL As Double
                If Me.getReportParam01(strErrMsg, strKSRQ, strZZRQ, dblLVBL) = False Then
                    GoTo errProc
                End If
                Dim objZZRQ As System.DateTime = CType(strZZRQ, System.DateTime)
                Dim strFName As String = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_VT_ES_BB_YJFPB_XSJB
                objColors = New System.Collections.Specialized.ListDictionary
                objColors.Add("1", System.Drawing.Color.FromArgb(51, 153, 102))

                '准备最终的Excel文件
                Dim strDesExcelPath As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile
                Dim strSrcExcelSpec As String = Request.ApplicationPath + Me.m_cstrUrlBaseToExcelMB + "空白文件.xls"
                Dim strDesExcelFile As String = ""
                Dim strDesExcelSpec As String = ""
                strDesExcelPath = Server.MapPath(strDesExcelPath)
                strSrcExcelSpec = Server.MapPath(strSrcExcelSpec)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strSrcExcelSpec, strDesExcelPath, strDesExcelFile) = False Then
                    GoTo errProc
                End If
                Dim strFinalFile As String = ""
                Dim strFinalSpec As String = ""
                strFinalFile = strDesExcelFile
                strFinalSpec = objBaseLocalFile.doMakePath(strDesExcelPath, strDesExcelFile)

                '逐个获取统计部门
                Dim strMacroName As String = ""
                Dim strMacroValue As String = ""
                Dim strBMDM As String = ""
                Dim strBMMC As String = ""
                Dim intCount As Integer
                Dim i As Integer
                strSrcExcelSpec = Request.ApplicationPath + Me.m_cstrUrlBaseToExcelMB + "广州兴业_二手报表_中介部二手佣金分配表.xls"
                strSrcExcelSpec = Server.MapPath(strSrcExcelSpec)
                strDesExcelPath = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile
                strDesExcelPath = Server.MapPath(strDesExcelPath)
                strDesExcelFile = ""
                intCount = Me.tvwTJBM.Nodes.Count
                For i = 0 To intCount - 1 Step 1
                    If Me.tvwTJBM.Nodes(i).Checked = True Then
                        '获取统计部门
                        If Me.getTreeviewNodeInfo(strErrMsg, Me.tvwTJBM.Nodes(i).GetNodeIndex, strBMDM) = False Then
                            GoTo errProc
                        End If
                        strBMMC = Me.tvwTJBM.Nodes(i).Text

                        '获取数据
                        If Me.getModuleData01(strErrMsg, strBMDM, Me.m_strQuery, objDataSet) = False Then
                            GoTo errProc
                        End If
                        If objDataSet.Tables.Count < 3 Then
                            strErrMsg = "错误：计算数据不成功！"
                            GoTo errProc
                        End If

                        '创建临时文件
                        If strDesExcelFile = "" Then
                            If objBaseLocalFile.doCopyToTempFile(strErrMsg, strSrcExcelSpec, strDesExcelPath, strDesExcelFile) = False Then
                                GoTo errProc
                            End If
                            strDesExcelSpec = objBaseLocalFile.doMakePath(strDesExcelPath, strDesExcelFile)
                        Else
                            If objBaseLocalFile.doCopyFile(strErrMsg, strSrcExcelSpec, strDesExcelSpec, True) = False Then
                                GoTo errProc
                            End If
                        End If

                        '表头参数
                        Dim intQJ As Integer = objDataSet.Tables(1).Rows.Count
                        Dim strBL(intQJ) As String
                        Dim strQJ(intQJ) As String
                        Dim strMin As String = ""
                        Dim strMax As String = ""
                        Dim j As Integer
                        '==============================================================================================================================================================================
                        With objDataSet.Tables(1)
                            For j = 0 To intQJ - 1 Step 1
                                strBL(j) = objPulicParameters.getObjectValue(.Rows(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                                strMin = objPulicParameters.getObjectValue(.Rows(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_QJZX), "", "##0", True)
                                strMax = objPulicParameters.getObjectValue(.Rows(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_QJZD), "", "##0", True)
                                Select Case j
                                    Case 0
                                        strQJ(j) = strMax + "以内"
                                    Case intQJ - 1
                                        strQJ(j) = strMin + "以上"
                                    Case Else
                                        strQJ(j) = strMin + "-" + strMax
                                End Select
                            Next
                        End With
                        strMacroName = "KSRQ"
                        strMacroValue = strKSRQ
                        strMacroName = strMacroName + "," + "ZZRQ"
                        strMacroValue = strMacroValue + "," + strZZRQ
                        strMacroName = strMacroName + "," + "BMMC"
                        strMacroValue = strMacroValue + "," + strBMMC
                        '==============================================================================================================================================================================
                        For j = 0 To intQJ - 1 Step 1
                            strMacroName = strMacroName + "," + "SYBL" + Right("00" + (j + 1).ToString, 3)
                            strMacroValue = strMacroValue + "," + strBL(j)
                            strMacroName = strMacroName + "," + "SYQJ" + Right("00" + (j + 1).ToString, 3)
                            strMacroValue = strMacroValue + "," + strQJ(j)
                        Next
                        Dim strFilter As String = ""
                        With objDataSet.Tables(2)
                            strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZGBJ + " = 1"
                            strFilter = strFilter + " and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_YYJL.Value + ")"
                            .DefaultView.RowFilter = strFilter
                            If .DefaultView.Count > 0 Then
                                strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                                strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                            Else
                                strMin = "0.00%"
                                strMax = "0.00%"
                            End If
                        End With
                        strMacroName = strMacroName + "," + "YYJLZGJT"
                        strMacroValue = strMacroValue + "," + strMin
                        strMacroName = strMacroName + "," + "YYJLZGBL"
                        strMacroValue = strMacroValue + "," + strMax
                        '==============================================================================================================================================================================
                        With objDataSet.Tables(2)
                            strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZGBJ + " = 0"
                            strFilter = strFilter + " and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_YYJL.Value + ")"
                            .DefaultView.RowFilter = strFilter
                            If .DefaultView.Count > 0 Then
                                strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                                strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                            Else
                                strMin = "0.00%"
                                strMax = "0.00%"
                            End If
                        End With
                        strMacroName = strMacroName + "," + "YYJLXGJT"
                        strMacroValue = strMacroValue + "," + strMin
                        strMacroName = strMacroName + "," + "YYJLXGBL"
                        strMacroValue = strMacroValue + "," + strMax
                        '==============================================================================================================================================================================
                        With objDataSet.Tables(2)
                            strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_QYJL.Value + ")"
                            .DefaultView.RowFilter = strFilter
                            If .DefaultView.Count > 0 Then
                                strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                                strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                            Else
                                strMin = "0.00%"
                                strMax = "0.00%"
                            End If
                        End With
                        strMacroName = strMacroName + "," + "QYJLJT"
                        strMacroValue = strMacroValue + "," + strMin
                        strMacroName = strMacroName + "," + "QYJLBL"
                        strMacroValue = strMacroValue + "," + strMax
                        '==============================================================================================================================================================================
                        With objDataSet.Tables(2)
                            strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_QYZJ.Value + ")"
                            .DefaultView.RowFilter = strFilter
                            If .DefaultView.Count > 0 Then
                                strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                                strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                            Else
                                strMin = "0.00%"
                                strMax = "0.00%"
                            End If
                        End With
                        strMacroName = strMacroName + "," + "QYZJJT"
                        strMacroValue = strMacroValue + "," + strMin
                        strMacroName = strMacroName + "," + "QYZJBL"
                        strMacroValue = strMacroValue + "," + strMax
                        '==============================================================================================================================================================================
                        With objDataSet.Tables(2)
                            strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_YWJL.Value + ")"
                            .DefaultView.RowFilter = strFilter
                            If .DefaultView.Count > 0 Then
                                strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                                strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                            Else
                                strMin = "0.00%"
                                strMax = "0.00%"
                            End If
                        End With
                        strMacroName = strMacroName + "," + "YWJLJT"
                        strMacroValue = strMacroValue + "," + strMin
                        strMacroName = strMacroName + "," + "YWJLBL"
                        strMacroValue = strMacroValue + "," + strMax
                        '==============================================================================================================================================================================
                        With objDataSet.Tables(2)
                            strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM + " in (" + Me.htxtZJDM_XZZL.Value + ")"
                            .DefaultView.RowFilter = strFilter
                            If .DefaultView.Count > 0 Then
                                strMin = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT), "", "##0.00%", True)
                                strMax = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT), "", "##0.00%", True)
                            Else
                                strMin = "0.00%"
                                strMax = "0.00%"
                            End If
                        End With
                        strMacroName = strMacroName + "," + "XZZLJT"
                        strMacroValue = strMacroValue + "," + strMin
                        strMacroName = strMacroName + "," + "XZZLBL"
                        strMacroValue = strMacroValue + "," + strMax

                        '输出数据
                        If objsystemEstateErshou.doExportToExcel(strErrMsg, objDataSet, strDesExcelSpec, strFName, objColors, strMacroName, strMacroValue, "yyyy-MM-dd") = False Then
                            GoTo errProc
                        End If
                        Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                        '写入统一的输出文件
                        If objsystemEstateErshou.doExcelAddCopy(strErrMsg, strDesExcelSpec, "数据", strFinalSpec, strBMMC) = False Then
                            GoTo errProc
                        End If
                    End If
                Next

                '删除临时文件
                If strDesExcelSpec <> "" Then
                    If objBaseLocalFile.doDeleteFile(strErrMsg, strDesExcelSpec) = False Then
                        '忽略
                    End If
                End If

                '删除[Sheet1]
                If strFinalSpec <> "" Then
                    If objsystemEstateErshou.doExcelSheetDelete(strErrMsg, strFinalSpec, "Sheet1") = False Then
                        '忽略
                    End If
                End If

                '打开临时Excel文件
                Dim strUrl As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile + strFinalFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objColors)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
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

        'zengxianglin 2009-05-19
        Private Sub lnkMLExpSel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLExpSel.Click
            Me.doExportSelect("lnkMLExpSel")
        End Sub
        'zengxianglin 2009-05-19

        Private Sub lnkMLReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLReturn.Click
            Me.doClose("lnkMLReturn")
        End Sub

    End Class

End Namespace
