Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_cw_piaoju_fafang
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　票据发放管理
    '
    ' QueryString参数描述： 
    '
    ' 接口参数：
    '     参见接口类IEstateCwPiaojuFafang描述
    ' 更改记录：
    '     zengxianglin 2009-05-17 更改
    '----------------------------------------------------------------

    Partial Class estate_cw_piaoju_fafang
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub




        'zengxianglin 2008-11-18
        'zengxianglin 2008-11-18





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

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_cw_piaoju_previlege_param"
        Private m_blnPrevilegeParams(3) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateCwPiaojuFafang
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateCwPiaojuFafang
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdPIAOJU相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_PIAOJU As String = "chkPIAOJU"
        Private Const m_cstrDataGridInDIV_PIAOJU As String = "divPIAOJU"
        Private m_intFixedColumns_PIAOJU As Integer

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objDataSet_PIAOJU As Josco.JSOA.Common.Data.estateCaiwuData
        Private m_strQuery_PIAOJU As String
        Private m_intRows_PIAOJU As Integer











        Private Sub doGoBack(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                If strSessionId Is Nothing Then strSessionId = ""
                If strSessionId <> "" Then
                    Try
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateCwPiaojuFafang)
                    Catch ex As Exception
                        Me.m_objInterface = Nothing
                    End Try
                Else
                    Me.m_objInterface = Nothing
                End If
                If Not (Me.m_objInterface Is Nothing) Then
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

        Private Sub btnGoBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoBack.Click
            Me.doGoBack("btnGoBack")
        End Sub










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
                If Me.m_blnPrevilegeParams(0) = True And Me.m_blnPrevilegeParams(1) = True Then
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
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtPIAOJUQuery.Value = .htxtPIAOJUQuery
                    Me.htxtPIAOJURows.Value = .htxtPIAOJURows
                    Me.htxtPIAOJUSort.Value = .htxtPIAOJUSort
                    Me.htxtPIAOJUSortColumnIndex.Value = .htxtPIAOJUSortColumnIndex
                    Me.htxtPIAOJUSortType.Value = .htxtPIAOJUSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftPIAOJU.Value = .htxtDivLeftPIAOJU
                    Me.htxtDivTopPIAOJU.Value = .htxtDivTopPIAOJU

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtPIAOJUPageIndex.Text = .txtPIAOJUPageIndex
                    Me.txtPIAOJUPageSize.Text = .txtPIAOJUPageSize

                    Me.txtPIAOJUSearch_PJPH.Text = .txtPIAOJUSearch_PJPH
                    Me.txtPIAOJUSearch_FGFHMC.Text = .txtPIAOJUSearch_FGFHMC
                    Me.txtPIAOJUSearch_FFRQMin.Text = .txtPIAOJUSearch_FFRQMin
                    Me.txtPIAOJUSearch_FFRQMax.Text = .txtPIAOJUSearch_FFRQMax
                    Me.txtPIAOJUSearch_PJHM.Text = .txtPIAOJUSearch_PJHM
                    Me.ddlPIAOJUSearch_ZTBZ.SelectedIndex = .ddlPIAOJUSearch_ZTBZ_SelectedIndex
                    'zengxianglin 2008-05-17
                    Me.ddlPIAOJUSearch_HXBZ.SelectedIndex = .ddlPIAOJUSearch_HXBZ_SelectedIndex
                    'zengxianglin 2008-05-17

                    Me.txtFGFH.Text = .txtFGFH
                    Me.htxtFGFH.Value = .htxtFGFH
                    Me.txtPJQZ.Text = .txtPJQZ
                    'zengxianglin 2008-11-18
                    Me.txtFFPC.Text = .txtFFPC
                    'zengxianglin 2008-11-18
                    Me.txtKSHM.Text = .txtKSHM
                    Me.txtZZHM.Text = .txtZZHM
                    Me.ddlPJLX.SelectedIndex = .ddlPJLX_SelectedIndex

                    Try
                        Me.grdPIAOJU.PageSize = .grdPIAOJUPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdPIAOJU.CurrentPageIndex = .grdPIAOJUCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdPIAOJU.SelectedIndex = .grdPIAOJUSelectedIndex
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '创建SessionId
                strSessionId = objPulicParameters.getNewGuid()
                If strSessionId = "" Then Exit Try

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateCwPiaojuFafang

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtPIAOJUQuery = Me.htxtPIAOJUQuery.Value
                    .htxtPIAOJURows = Me.htxtPIAOJURows.Value
                    .htxtPIAOJUSort = Me.htxtPIAOJUSort.Value
                    .htxtPIAOJUSortColumnIndex = Me.htxtPIAOJUSortColumnIndex.Value
                    .htxtPIAOJUSortType = Me.htxtPIAOJUSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftPIAOJU = Me.htxtDivLeftPIAOJU.Value
                    .htxtDivTopPIAOJU = Me.htxtDivTopPIAOJU.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtPIAOJUPageIndex = Me.txtPIAOJUPageIndex.Text
                    .txtPIAOJUPageSize = Me.txtPIAOJUPageSize.Text

                    .txtPIAOJUSearch_PJPH = Me.txtPIAOJUSearch_PJPH.Text
                    .txtPIAOJUSearch_FGFHMC = Me.txtPIAOJUSearch_FGFHMC.Text
                    .txtPIAOJUSearch_PJHM = Me.txtPIAOJUSearch_PJHM.Text
                    .txtPIAOJUSearch_FFRQMin = Me.txtPIAOJUSearch_FFRQMin.Text
                    .txtPIAOJUSearch_FFRQMax = Me.txtPIAOJUSearch_FFRQMax.Text
                    .ddlPIAOJUSearch_ZTBZ_SelectedIndex = Me.ddlPIAOJUSearch_ZTBZ.SelectedIndex
                    'zengxianglin 2008-05-17
                    .ddlPIAOJUSearch_HXBZ_SelectedIndex = Me.ddlPIAOJUSearch_HXBZ.SelectedIndex
                    'zengxianglin 2008-05-17

                    .txtFGFH = Me.txtFGFH.Text
                    .htxtFGFH = Me.htxtFGFH.Value
                    .txtPJQZ = Me.txtPJQZ.Text
                    'zengxianglin 2008-11-18
                    .txtFFPC = Me.txtFFPC.Text
                    'zengxianglin 2008-11-18
                    .txtKSHM = Me.txtKSHM.Text
                    .txtZZHM = Me.txtZZHM.Text
                    .ddlPJLX_SelectedIndex = Me.ddlPJLX.SelectedIndex

                    .grdPIAOJUPageSize = Me.grdPIAOJU.PageSize
                    .grdPIAOJUCurrentPageIndex = Me.grdPIAOJU.CurrentPageIndex
                    .grdPIAOJUSelectedIndex = Me.grdPIAOJU.SelectedIndex
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
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg
                Try
                    objIDmxzZzjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzjg)
                Catch ex As Exception
                    objIDmxzZzjg = Nothing
                End Try
                If Not (objIDmxzZzjg Is Nothing) Then
                    If objIDmxzZzjg.oExitMode = True Then
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper
                            Case "btnSelect_ZZDM".ToUpper
                                Dim strZZDM As String = ""
                                Me.txtFGFH.Text = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtFGFH.Text, strZZDM) = True Then
                                    Me.htxtFGFH.Value = strZZDM
                                Else
                                    Me.htxtFGFH.Value = ""
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
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
                        Me.htxtPIAOJUQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQuery.Value.Trim = "" Then
                            Me.htxtSessionIdQuery.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.ISjcxCxtj.SafeRelease(objISjcxCxtj)
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateCwPiaojuFafang)
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
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateCwPiaojuFafang)
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
                Me.m_intFixedColumns_PIAOJU = objPulicParameters.getObjectValue(Me.htxtPIAOJUFixed.Value, 0)
                Me.m_intRows_PIAOJU = objPulicParameters.getObjectValue(Me.htxtPIAOJURows.Value, 0)
                Me.m_strQuery_PIAOJU = Me.htxtPIAOJUQuery.Value
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
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery.Value)
                End If
            Catch ex As Exception
            End Try

        End Sub













        '----------------------------------------------------------------
        ' 获取grdPIAOJU的搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_PIAOJU( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_PIAOJU = False
            strQuery = ""

            Try
                '按“票据批号”搜索
                Dim strPJPH As String
                strPJPH = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_PJPH
                If Me.txtPIAOJUSearch_PJPH.Text.Length > 0 Then Me.txtPIAOJUSearch_PJPH.Text = Me.txtPIAOJUSearch_PJPH.Text.Trim()
                If Me.txtPIAOJUSearch_PJPH.Text <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtPIAOJUSearch_PJPH.Text) = False Then
                        strErrMsg = "错误：[批号]必须是数字！"
                        GoTo errProc
                    End If
                    If strQuery = "" Then
                        strQuery = strPJPH + " = " + Me.txtPIAOJUSearch_PJPH.Text
                    Else
                        strQuery = strQuery + " and " + strPJPH + " = " + Me.txtPIAOJUSearch_PJPH.Text
                    End If
                End If

                '按“发给分行”搜索
                Dim strFGFH As String
                strFGFH = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_FGFHMC
                If Me.txtPIAOJUSearch_FGFHMC.Text.Length > 0 Then Me.txtPIAOJUSearch_FGFHMC.Text = Me.txtPIAOJUSearch_FGFHMC.Text.Trim()
                If Me.txtPIAOJUSearch_FGFHMC.Text <> "" Then
                    Me.txtPIAOJUSearch_FGFHMC.Text = objPulicParameters.getNewSearchString(Me.txtPIAOJUSearch_FGFHMC.Text)
                    If strQuery = "" Then
                        strQuery = strFGFH + " like '" + Me.txtPIAOJUSearch_FGFHMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strFGFH + " like '" + Me.txtPIAOJUSearch_FGFHMC.Text + "%'"
                    End If
                End If

                '按“发放日期”搜索
                Dim strFFRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strFFRQ = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_FFRQ
                If Me.txtPIAOJUSearch_FFRQMin.Text.Length > 0 Then Me.txtPIAOJUSearch_FFRQMin.Text = Me.txtPIAOJUSearch_FFRQMin.Text.Trim()
                If Me.txtPIAOJUSearch_FFRQMax.Text.Length > 0 Then Me.txtPIAOJUSearch_FFRQMax.Text = Me.txtPIAOJUSearch_FFRQMax.Text.Trim()
                If Me.txtPIAOJUSearch_FFRQMin.Text <> "" And Me.txtPIAOJUSearch_FFRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtPIAOJUSearch_FFRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的[发放日期]！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtPIAOJUSearch_FFRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的[发放日期]！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtPIAOJUSearch_FFRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtPIAOJUSearch_FFRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtPIAOJUSearch_FFRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtPIAOJUSearch_FFRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strFFRQ + " between '" + Me.txtPIAOJUSearch_FFRQMin.Text + "' and '" + Me.txtPIAOJUSearch_FFRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFFRQ + " between '" + Me.txtPIAOJUSearch_FFRQMin.Text + "' and '" + Me.txtPIAOJUSearch_FFRQMax.Text + "'"
                    End If
                ElseIf Me.txtPIAOJUSearch_FFRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtPIAOJUSearch_FFRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的[发放日期]！"
                        GoTo errProc
                    End Try
                    Me.txtPIAOJUSearch_FFRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strFFRQ + " >= '" + Me.txtPIAOJUSearch_FFRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFFRQ + " >= '" + Me.txtPIAOJUSearch_FFRQMin.Text + "'"
                    End If
                ElseIf Me.txtPIAOJUSearch_FFRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtPIAOJUSearch_FFRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的[发放日期]！"
                        GoTo errProc
                    End Try
                    Me.txtPIAOJUSearch_FFRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strFFRQ + " <= '" + Me.txtPIAOJUSearch_FFRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFFRQ + " <= '" + Me.txtPIAOJUSearch_FFRQMax.Text + "'"
                    End If
                Else
                End If

                '按“票据号码”搜索
                Dim strPJHM As String
                strPJHM = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_PJHM
                If Me.txtPIAOJUSearch_PJHM.Text.Length > 0 Then Me.txtPIAOJUSearch_PJHM.Text = Me.txtPIAOJUSearch_PJHM.Text.Trim()
                If Me.txtPIAOJUSearch_PJHM.Text <> "" Then
                    Me.txtPIAOJUSearch_PJHM.Text = objPulicParameters.getNewSearchString(Me.txtPIAOJUSearch_PJHM.Text)
                    If strQuery = "" Then
                        strQuery = strPJHM + " like '" + Me.txtPIAOJUSearch_PJHM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strPJHM + " like '" + Me.txtPIAOJUSearch_PJHM.Text + "%'"
                    End If
                End If

                '按“状态标志”搜索
                Dim strZTBZ As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_ZTBZ
                Select Case Me.ddlPIAOJUSearch_ZTBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strZTBZ + " = " + Me.ddlPIAOJUSearch_ZTBZ.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strZTBZ + " = " + Me.ddlPIAOJUSearch_ZTBZ.SelectedValue
                        End If
                End Select

                'zengxianglin 2009-05-17
                '按“核销标志”搜索
                Dim strHXBZ As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_HXBZ
                Select Case Me.ddlPIAOJUSearch_HXBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strHXBZ + " = " + Me.ddlPIAOJUSearch_HXBZ.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strHXBZ + " = " + Me.ddlPIAOJUSearch_HXBZ.SelectedValue
                        End If
                End Select
                'zengxianglin 2009-05-17
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_PIAOJU = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdPIAOJU要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_PIAOJU( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            getModuleData_PIAOJU = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtPIAOJUSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(Me.m_objDataSet_PIAOJU)

                '重新检索数据
                If objsystemEstateCaiwu.getDataSet_PJSY(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_PIAOJU) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_PIAOJU.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_PIAOJU.Tables(strTable)
                    Me.htxtPIAOJURows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_PIAOJU = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            getModuleData_PIAOJU = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdPIAOJU数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_PIAOJU(ByRef strErrMsg As String) As Boolean

            searchModuleData_PIAOJU = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_PIAOJU(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_PIAOJU(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_PIAOJU = strQuery
                Me.htxtPIAOJUQuery.Value = Me.m_strQuery_PIAOJU
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_PIAOJU = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdPIAOJU的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_PIAOJU(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_PIAOJU = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = 0
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtPIAOJUSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtPIAOJUSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_PIAOJU Is Nothing Then
                    Me.grdPIAOJU.DataSource = Nothing
                Else
                    With Me.m_objDataSet_PIAOJU.Tables(strTable)
                        Me.grdPIAOJU.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_PIAOJU.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdPIAOJU, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdPIAOJU)
                    With Me.grdPIAOJU.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdPIAOJU.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdPIAOJU, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_PIAOJU = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdPIAOJU及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_PIAOJU(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_PIAOJU = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_PIAOJU(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_PIAOJU.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblPIAOJUGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdPIAOJU, .Count)

                    '显示页面浏览功能
                    Me.lnkCZPIAOJUMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdPIAOJU, .Count)
                    Me.lnkCZPIAOJUMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdPIAOJU, .Count)
                    Me.lnkCZPIAOJUMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdPIAOJU, .Count)
                    Me.lnkCZPIAOJUMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdPIAOJU, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZPIAOJUDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZPIAOJUSelectAll.Enabled = blnEnabled
                    Me.lnkCZPIAOJUGotoPage.Enabled = blnEnabled
                    Me.lnkCZPIAOJUSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_PIAOJU = True
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
                Me.btnDelete.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnFafang.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnShouhui.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnHexiao.Visible = Me.m_blnPrevilegeParams(1)
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

            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                '显示Pannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                '执行键转译(不论是否是“回发”)
                objControlProcess.doTranslateKey(Me.txtPIAOJUPageIndex)
                objControlProcess.doTranslateKey(Me.txtPIAOJUPageSize)
                '************************************************
                objControlProcess.doTranslateKey(Me.txtPIAOJUSearch_FGFHMC)
                objControlProcess.doTranslateKey(Me.txtPIAOJUSearch_PJPH)
                objControlProcess.doTranslateKey(Me.txtPIAOJUSearch_FFRQMin)
                objControlProcess.doTranslateKey(Me.txtPIAOJUSearch_FFRQMax)
                objControlProcess.doTranslateKey(Me.txtPIAOJUSearch_PJHM)
                '************************************************
                objControlProcess.doTranslateKey(Me.ddlPIAOJUSearch_ZTBZ)
                'zengxianglin 2009-05-17
                objControlProcess.doTranslateKey(Me.ddlPIAOJUSearch_HXBZ)
                'zengxianglin 2009-05-17
                '************************************************
                objControlProcess.doTranslateKey(Me.ddlPJLX)
                '************************************************
                objControlProcess.doTranslateKey(Me.txtZZHM)
                objControlProcess.doTranslateKey(Me.txtPJQZ)
                'zengxianglin 2008-11-18
                objControlProcess.doTranslateKey(Me.txtFFPC)
                'zengxianglin 2008-11-18
                objControlProcess.doTranslateKey(Me.txtFGFH)
                objControlProcess.doTranslateKey(Me.txtKSHM)

                '显示模块级操作
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '设初始值
                If Me.m_blnSaveScence = False Then
                    Me.txtPIAOJUSearch_FFRQMin.Text = Now.ToString("yyyy-MM-dd")
                    Me.txtPIAOJUSearch_FFRQMax.Text = ""
                    '显示数据
                    If Me.searchModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    '显示数据
                    If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            End If

            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function
errProc:
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim strUrl As String

            Dim strUserID As String
            Dim strPassword As String
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

            '检查权限
            Dim blnDo As Boolean
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
        '实现对grdPIAOJU网格行、列的固定
        Sub grdPIAOJU_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdPIAOJU.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_PIAOJU + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_PIAOJU > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_PIAOJU - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdPIAOJU.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdPIAOJU_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPIAOJU.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblPIAOJUGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdPIAOJU, Me.m_intRows_PIAOJU)
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

        Private Sub grdPIAOJU_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdPIAOJU.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
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
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_PIAOJU.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_PIAOJU.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtPIAOJUSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtPIAOJUSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtPIAOJUSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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












        Private Sub doMoveFirst_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdPIAOJU.PageCount)
                Me.grdPIAOJU.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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

        Private Sub doMoveLast_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdPIAOJU.PageCount - 1, Me.grdPIAOJU.PageCount)
                Me.grdPIAOJU.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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

        Private Sub doMoveNext_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdPIAOJU.CurrentPageIndex + 1, Me.grdPIAOJU.PageCount)
                Me.grdPIAOJU.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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

        Private Sub doMovePrevious_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdPIAOJU.CurrentPageIndex - 1, Me.grdPIAOJU.PageCount)
                Me.grdPIAOJU.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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

        Private Sub doGotoPage_PIAOJU(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtPIAOJUPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdPIAOJU.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtPIAOJUPageIndex.Text = (Me.grdPIAOJU.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_PIAOJU(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtPIAOJUPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdPIAOJU.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtPIAOJUPageSize.Text = (Me.grdPIAOJU.PageSize).ToString()
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

        Private Sub doSelectAll_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdPIAOJU, 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU, True) = False Then
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

        Private Sub doDeSelectAll_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdPIAOJU, 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU, False) = False Then
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

        Private Sub doSearch_PIAOJU(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_PIAOJU(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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

        Private Sub lnkCZPIAOJUMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUMoveFirst.Click
            Me.doMoveFirst_PIAOJU("lnkCZPIAOJUMoveFirst")
        End Sub

        Private Sub lnkCZPIAOJUMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUMoveLast.Click
            Me.doMoveLast_PIAOJU("lnkCZPIAOJUMoveLast")
        End Sub

        Private Sub lnkCZPIAOJUMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUMoveNext.Click
            Me.doMoveNext_PIAOJU("lnkCZPIAOJUMoveNext")
        End Sub

        Private Sub lnkCZPIAOJUMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUMovePrev.Click
            Me.doMovePrevious_PIAOJU("lnkCZPIAOJUMovePrev")
        End Sub

        Private Sub lnkCZPIAOJUGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUGotoPage.Click
            Me.doGotoPage_PIAOJU("lnkCZPIAOJUGotoPage")
        End Sub

        Private Sub lnkCZPIAOJUSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUSetPageSize.Click
            Me.doSetPageSize_PIAOJU("lnkCZPIAOJUSetPageSize")
        End Sub

        Private Sub lnkCZPIAOJUSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUSelectAll.Click
            Me.doSelectAll_PIAOJU("lnkCZPIAOJUSelectAll")
        End Sub

        Private Sub lnkCZPIAOJUDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUDeSelectAll.Click
            Me.doDeSelectAll_PIAOJU("lnkCZPIAOJUDeSelectAll")
        End Sub

        Private Sub btnPIAOJUSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPIAOJUSearch.Click
            Me.doSearch_PIAOJU("btnPIAOJUSearch")
        End Sub











        Private Sub doSelect_ZZDM(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg = Nothing
                Dim strUrl As String = ""
                objIDmxzZzjg = New Josco.JsKernal.BusinessFacade.IDmxzZzjg
                With objIDmxzZzjg
                    .iAllowInput = False
                    .iMultiSelect = False
                    .iAllowNull = False
                    .iSelectFFFW = False
                    .iBumenList = ""
                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = True Then
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
                    Else
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIDmxzZzjg)
                strUrl = ""
                strUrl += "../../dmxz/dmxz_zzjg.aspx"
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

        'zengxianglin 2008-11-18
        Private Sub doJSPC(ByVal strControlId As String)

            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                If Me.htxtFGFH.Value.Trim = "" Then
                    strErrMsg = "错误：没有指定[分行]！"
                    GoTo errProc
                End If

                '计算
                Dim strPJPH As String = ""
                If objsystemEstateCaiwu.getNewPjph(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtFGFH.Value, strPJPH) = False Then
                    GoTo errProc
                End If
                Me.txtFFPC.Text = strPJPH
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
        Private Sub btnJSPC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSPC.Click
            Me.doJSPC("btnJSPC")
        End Sub
        'zengxianglin 2008-11-18

        Private Sub btnSelect_ZZDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_ZZDM.Click
            Me.doSelect_ZZDM("btnSelect_ZZDM")
        End Sub










        Private Sub doSearchFull(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '获取数据
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
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
                    .iQueryTable = Me.m_objDataSet_PIAOJU.Tables(strTable)
                    .iFixQuery = ""

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = True Then
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
                    Else
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    End If
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
                strUrl += "../../sjcx/sjcx_cxtj.aspx"
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

        Private Sub btnPIAOJUSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPIAOJUSearch_Full.Click
            Me.doSearchFull("btnPIAOJUSearch_Full")
        End Sub













        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
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

        Private Sub doDelete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
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
                intRows = Me.grdPIAOJU.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
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
                    '逐个删除
                    Dim intColIndex(2) As Integer
                    Dim strWYBS As String = ""
                    Dim strPJHM As String = ""
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYPJHM)
                    intRows = Me.grdPIAOJU.Items.Count
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(0))
                            strPJHM = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(1))

                            '删除处理
                            If objsystemEstateCaiwu.doPiaoju_Delete(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                                GoTo errProc
                            End If

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[财务_发放票据]中删除了[" + strPJHM + "]的资料！")
                        End If
                    Next

                    '重新获取数据
                    If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                        GoTo errProc
                    End If

                    '刷新网格显示
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doShouhui(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
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
                intRows = Me.grdPIAOJU.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要收回的内容(只能收回[未使用]的票据)！"
                        GoTo errProc
                    End If
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备收回选定的[" + intSelect.ToString() + "]条内容吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '逐个收回
                    Dim intColIndex(2) As Integer
                    Dim strWYBS As String = ""
                    Dim strPJHM As String = ""
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYPJHM)
                    intRows = Me.grdPIAOJU.Items.Count
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(0))
                            strPJHM = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(1))

                            '收回处理
                            If objsystemEstateCaiwu.doPiaoju_Mark(strErrMsg, _
                                MyBase.UserId, MyBase.UserPassword, _
                                strWYBS, _
                                 Josco.JSOA.Common.Data.estateCaiwuData.enumPiaojuStatus.Shouhui, _
                                 Nothing) = False Then
                                GoTo errProc
                            End If

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[财务_发放票据]中收回了[" + strPJHM + "]的资料！")
                        End If
                    Next

                    '重新获取数据
                    If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                        GoTo errProc
                    End If

                    '刷新网格显示
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doFafang(ByVal strControlId As String)

            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0

            Try
                '检查
                intStep = 1
                If Me.htxtFGFH.Value.Trim = "" Then
                    strErrMsg = "错误：没有输入[发给分行]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-18
                If Me.txtFFPC.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[批次]！"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtFFPC.Text) = False Then
                    strErrMsg = "错误：无效的[批次]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-18
                If Me.txtKSHM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[开始号码]！"
                    GoTo errProc
                End If
                If Me.txtZZHM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[结束号码]！"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtKSHM.Text) = False Then
                    strErrMsg = "错误：无效的[开始号码]！"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtZZHM.Text) = False Then
                    strErrMsg = "错误：无效的[结束号码]！"
                    GoTo errProc
                End If
                Dim strPJLX As String = ""
                If Me.ddlPJLX.SelectedIndex >= 0 Then
                    strPJLX = Me.ddlPJLX.SelectedValue
                End If
                Dim intMin As Integer = objPulicParameters.getObjectValue(Me.txtKSHM.Text, 0)
                Dim intMax As Integer = objPulicParameters.getObjectValue(Me.txtZZHM.Text, 0)

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定输入的数据吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '录用处理
                    If objsystemEstateCaiwu.doPiaoju_Fafang(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtPJQZ.Text.Trim, intMin, intMax, strPJLX, Me.htxtFGFH.Value.Trim, Me.txtFFPC.Text) = False Then
                        GoTo errProc
                    End If

                    '显示
                    Me.txtPIAOJUSearch_FFRQMin.Text = Now.ToString("yyyy-MM-dd")
                    Me.txtPIAOJUSearch_FFRQMax.Text = ""
                    Me.ddlPIAOJUSearch_ZTBZ.SelectedIndex = -1
                    Me.txtPIAOJUSearch_FGFHMC.Text = ""
                    Me.txtPIAOJUSearch_PJHM.Text = ""
                    Me.txtPIAOJUSearch_PJPH.Text = ""
                    If Me.searchModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：处理成功！")
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2009-05-17
        Private Sub doHexiao(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
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
                intRows = Me.grdPIAOJU.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要核销的票据(只能核销[已使用|已作废]的票据)！"
                        GoTo errProc
                    End If
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备核销选定的[" + intSelect.ToString() + "]张票据吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '逐个核销
                    Dim intColIndex(2) As Integer
                    Dim strWYBS As String = ""
                    Dim strPJHM As String = ""
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYPJHM)
                    intRows = Me.grdPIAOJU.Items.Count
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(0))
                            strPJHM = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(1))

                            '核销处理
                            If objsystemEstateCaiwu.doPiaoju_Hexiao(strErrMsg, _
                                MyBase.UserId, MyBase.UserPassword, _
                                strWYBS, _
                                 MyBase.UserId, _
                                 Now.ToString("yyyy-MM-dd HH:mm:ss")) = False Then
                                GoTo errProc
                            End If

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[财务_发放票据]中核销了[" + strPJHM + "]的票据！")
                        End If
                    Next

                    '重新获取数据
                    If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                        GoTo errProc
                    End If
                    '刷新网格显示
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        'zengxianglin 2009-05-17

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Me.doDelete("btnDelete")
        End Sub

        Private Sub btnFafang_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFafang.Click
            Me.doFafang("btnFafang")
        End Sub

        Private Sub btnShouhui_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShouhui.Click
            Me.doShouhui("btnShouhui")
        End Sub

        'zengxianglin 2009-05-17
        Private Sub btnHexiao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHexiao.Click
            Me.doHexiao("btnHexiao")
        End Sub
        'zengxianglin 2009-05-17

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
