Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_renyuanjiagou_add
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“入职人员”处理模块
    '
    ' 更改记录：
    '     zengxianglin 2009-05-14 更改
    '     zengxianglin 2010-01-05 更改
    '----------------------------------------------------------------

    Partial Class estate_rs_renyuanjiagou_add
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'zengxianglin 2008-10-14
        'Protected WithEvents btnViewJG As System.Web.UI.WebControls.Button
        'zengxianglin 2008-10-14



        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14


        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-11-18
        'zengxianglin 2008-11-18


        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-11-22
        'zengxianglin 2008-11-22

        'zengxianglin 2010-01-05
        'zengxianglin 2010-01-05


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
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_renyuanjiagou_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Add
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Add
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdRY相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdRY As String = "chkRY"
        Private Const m_cstrDataGridInDIV_grdRY As String = "divRY"
        Private m_intFixedColumns_grdRY As Integer
        'zengxianglin 2008-10-14
        Private m_intRows_grdRY As Integer
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_RY As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '其他参数
        '----------------------------------------------------------------
        Private m_blnEnforced_RY As Boolean











        Private Sub doGoBack(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                If strSessionId Is Nothing Then strSessionId = ""
                If strSessionId <> "" Then
                    Try
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Add)
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
            Dim objMokuaiQXData As Josco.JsKernal.Common.Data.AppManagerData = Nothing

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
                Dim strFirstParamValue As String = ""
                Dim strParamValue As String = ""
                Dim strParamName As String = ""
                Dim strFilter As String = ""
                Dim strMKMC As String = ""
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

            Dim strErrMsg As String

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftMain.Value = .htxtDivLeftMain
                    Me.htxtDivTopMain.Value = .htxtDivTopMain
                    Me.htxtDivLeftRY.Value = .htxtDivLeftRY
                    Me.htxtDivTopRY.Value = .htxtDivTopRY

                    Me.htxtSessionId_RY.Value = .htxtSessionId_RY
                    Me.htxtQuery_RY.Value = .htxtQuery_RY
                    Try
                        Me.grdRY.PageSize = .grdRY_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRY.CurrentPageIndex = .grdRY_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRY.SelectedIndex = .grdRY_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.rblRYLX.SelectedIndex = .rblRYLX_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblRYZT.SelectedIndex = .rblRYZT_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFZB.SelectedIndex = .rblSFZB_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlYDYY.SelectedIndex = .ddlYDYY_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlZJDM.SelectedIndex = .ddlZJDM_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.chkSFJZ.Checked = .chkSFJZ_Checked
                    Me.txtSXSJ.Text = .txtSXSJ
                    Me.txtSSDW.Text = .txtSSDW
                    Me.htxtSSDW.Value = .htxtSSDW
                    'zengxianglin 2008-11-18
                    Me.txtZGDW.Text = .txtZGDW
                    Me.htxtZGDW.Value = .htxtZGDW
                    'zengxianglin 2008-11-18
                    Me.txtSJLD.Text = .txtSJLD
                    Me.htxtSJLD.Value = .htxtSJLD
                    'zengxianglin 2008-10-14
                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtSSDW.Text)
                    Try
                        Me.ddlSSFZ.SelectedIndex = .ddlSSFZ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    'zengxianglin 2008-10-14

                    Me.txtSearch_RY_RYDM.Text = .txtSearch_RY_RYDM
                    Me.txtSearch_RY_ZJDM.Text = .txtSearch_RY_ZJDM
                    Me.txtSearch_RY_RYMC.Text = .txtSearch_RY_RYMC
                    Me.txtSearch_RY_DWMC.Text = .txtSearch_RY_DWMC

                    'zengxianglin 2008-10-14
                    Me.txtRYPageIndex.Text = .txtRYPageIndex
                    Me.txtRYPageSize.Text = .txtRYPageSize
                    Me.htxtRYRows.Value = .htxtRYRows
                    'zengxianglin 2008-10-14
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Add

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftRY = Me.htxtDivLeftRY.Value
                    .htxtDivTopRY = Me.htxtDivTopRY.Value

                    .htxtQuery_RY = Me.htxtQuery_RY.Value
                    .htxtSessionId_RY = Me.htxtSessionId_RY.Value
                    .grdRY_PageSize = Me.grdRY.PageSize
                    .grdRY_CurrentPageIndex = Me.grdRY.CurrentPageIndex
                    .grdRY_SelectedIndex = Me.grdRY.SelectedIndex

                    .rblRYLX_SelectedIndex = Me.rblRYLX.SelectedIndex
                    .rblRYZT_SelectedIndex = Me.rblRYZT.SelectedIndex
                    .rblSFZB_SelectedIndex = Me.rblSFZB.SelectedIndex
                    .ddlYDYY_SelectedIndex = Me.ddlYDYY.SelectedIndex
                    .ddlZJDM_SelectedIndex = Me.ddlZJDM.SelectedIndex
                    .ddlSSFZ_SelectedIndex = Me.ddlSSFZ.SelectedIndex

                    .chkSFJZ_Checked = Me.chkSFJZ.Checked
                    .txtSXSJ = Me.txtSXSJ.Text
                    .txtSSDW = Me.txtSSDW.Text
                    .htxtSSDW = Me.htxtSSDW.Value
                    'zengxianglin 2008-11-18
                    .txtZGDW = Me.txtZGDW.Text
                    .htxtZGDW = Me.htxtZGDW.Value
                    'zengxianglin 2008-11-18
                    .txtSJLD = Me.txtSJLD.Text
                    .htxtSJLD = Me.htxtSJLD.Value

                    .txtSearch_RY_RYDM = Me.txtSearch_RY_RYDM.Text
                    .txtSearch_RY_ZJDM = Me.txtSearch_RY_ZJDM.Text
                    .txtSearch_RY_RYMC = Me.txtSearch_RY_RYMC.Text
                    .txtSearch_RY_DWMC = Me.txtSearch_RY_DWMC.Text

                    'zengxianglin 2008-10-14
                    .txtRYPageIndex = Me.txtRYPageIndex.Text
                    .txtRYPageSize = Me.txtRYPageSize.Text
                    .htxtRYRows = Me.htxtRYRows.Value
                    'zengxianglin 2008-10-14
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

            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg = Nothing
                Try
                    objIDmxzZzjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzjg)
                Catch ex As Exception
                    objIDmxzZzjg = Nothing
                End Try
                If Not (objIDmxzZzjg Is Nothing) Then
                    If objIDmxzZzjg.oExitMode = True Then
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper()
                            Case "btnSelectZZDM".ToUpper()
                                Dim strZZMC As String = objIDmxzZzjg.oBumenList
                                Dim strZZDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtSSDW.Value = strZZDM
                                    Me.txtSSDW.Text = strZZMC
                                    'zengxianglin 2008-10-14
                                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, strZZMC)
                                    'zengxianglin 2008-10-14
                                End If
                                'zengxianglin 2008-11-18
                            Case "btnSelectZGDW".ToUpper()
                                Dim strZZMC As String = objIDmxzZzjg.oBumenList
                                Dim strZZDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtZGDW.Value = strZZDM
                                    Me.txtZGDW.Text = strZZMC
                                End If
                                'zengxianglin 2008-11-18
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIDmxzRyxx As Josco.JsKernal.BusinessFacade.IDmxzRyxx = Nothing
                Try
                    objIDmxzRyxx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzRyxx)
                Catch ex As Exception
                    objIDmxzRyxx = Nothing
                End Try
                If Not (objIDmxzRyxx Is Nothing) Then
                    If objIDmxzRyxx.oExitMode = True Then
                        Select Case objIDmxzRyxx.iSourceControlId.ToUpper()
                            Case "btnSelectSJLD".ToUpper()
                                Me.htxtSJLD.Value = objIDmxzRyxx.oRYDM
                                Me.txtSJLD.Text = objIDmxzRyxx.oRYZM
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzRyxx.SafeRelease(objIDmxzRyxx)
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getDataFromCallModule = True
            Exit Function
errProc:
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

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 获取接口参数
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Add)
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
                Me.m_blnEnforced_RY = False '默认不强制获取数据

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Add)
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

                Me.m_intFixedColumns_grdRY = objPulicParameters.getObjectValue(Me.htxtRYFixed.Value, 0)
                'zengxianglin 2008-10-14
                Me.m_intRows_grdRY = objPulicParameters.getObjectValue(Me.htxtRYRows.Value, 0)
                'zengxianglin 2008-10-14
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
                Dim objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                If Me.htxtSessionId_RY.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_RY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_RY.Value)
                End If
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
                '按人员代码搜索
                Dim strRYDM As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM
                If Me.txtSearch_RY_RYDM.Text.Length > 0 Then Me.txtSearch_RY_RYDM.Text = Me.txtSearch_RY_RYDM.Text.Trim()
                If Me.txtSearch_RY_RYDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strRYDM + " like '" + Me.txtSearch_RY_RYDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYDM + " like '" + Me.txtSearch_RY_RYDM.Text + "%'"
                    End If
                End If

                '按职级代码搜索
                Dim strZJDM As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM
                If Me.txtSearch_RY_ZJDM.Text.Length > 0 Then Me.txtSearch_RY_ZJDM.Text = Me.txtSearch_RY_ZJDM.Text.Trim()
                If Me.txtSearch_RY_ZJDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strZJDM + " like '" + Me.txtSearch_RY_ZJDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strZJDM + " like '" + Me.txtSearch_RY_ZJDM.Text + "%'"
                    End If
                End If

                '按人员名称搜索
                Dim strRYMC As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC
                If Me.txtSearch_RY_RYMC.Text.Length > 0 Then Me.txtSearch_RY_RYMC.Text = Me.txtSearch_RY_RYMC.Text.Trim()
                If Me.txtSearch_RY_RYMC.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strRYMC + " like '" + Me.txtSearch_RY_RYMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYMC + " like '" + Me.txtSearch_RY_RYMC.Text + "%'"
                    End If
                End If

                '按人员名称搜索
                Dim strSSDWMC As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC
                If Me.txtSearch_RY_DWMC.Text.Length > 0 Then Me.txtSearch_RY_DWMC.Text = Me.txtSearch_RY_DWMC.Text.Trim()
                If Me.txtSearch_RY_DWMC.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strSSDWMC + " like '" + Me.txtSearch_RY_DWMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strSSDWMC + " like '" + Me.txtSearch_RY_DWMC.Text + "%'"
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
        ' 获取grdRY要显示的数据(没有在现架构内的人员)
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：Rowfilter串
        '     blnEnforced    ：true-强制重新获取数据
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_RY( _
            ByRef strErrMsg As String, _
            ByRef strWhere As String, _
            ByVal blnEnforced As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_RY = False

            Try
                '强制重新获取数据
                If blnEnforced = True Then
                    If Me.htxtSessionId_RY.Value.Trim <> "" Then
                        Me.m_objDataSet_RY = CType(Session.Item(Me.htxtSessionId_RY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RY)
                        Session.Remove(Me.htxtSessionId_RY.Value)
                        Me.htxtSessionId_RY.Value = ""
                    End If
                End If

                '根据需要获取
                If Me.htxtSessionId_RY.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_RY = CType(Session.Item(Me.htxtSessionId_RY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RY)

                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_RYJG_RY_NotIn(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", Me.m_objDataSet_RY) = False Then
                        GoTo errProc
                    End If

                    '缓存数据
                    Me.htxtSessionId_RY.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_RY.Value, Me.m_objDataSet_RY)
                End If

                '设置strWhere
                With Me.m_objDataSet_RY.Tables(strTable)
                    .DefaultView.RowFilter = strWhere
                End With

                'zengxianglin 2008-10-14
                '缓存参数
                With Me.m_objDataSet_RY.Tables(strTable)
                    Me.htxtRYRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_grdRY = .DefaultView.Count
                End With
                'zengxianglin 2008-10-14
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_RY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_RY(ByRef strErrMsg As String) As Boolean

            searchModuleData_RY = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_RY(strErrMsg, strQuery, Me.m_blnEnforced_RY) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.htxtQuery_RY.Value = strQuery
                '显示人员数目
                With Me.m_objDataSet_RY.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU)
                    Me.lblRYSM.Text = .DefaultView.Count.ToString
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_RY = True
            Exit Function
errProc:
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' 显示grdRY的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_RY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_RY = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_RY Is Nothing Then
                    Me.grdRY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_RY.Tables(strTable)
                        Me.grdRY.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_RY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdRY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdRY.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdRY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_RY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' 显示grdRY相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_RY( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_RY = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_RY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_RY.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblRYGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRY, .Count)

                    '显示页面浏览功能
                    Me.lnkCZRYMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdRY, .Count)
                    Me.lnkCZRYMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdRY, .Count)
                    Me.lnkCZRYMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdRY, .Count)
                    Me.lnkCZRYMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdRY, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZRYDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZRYSelectAll.Enabled = blnEnabled
                    Me.lnkCZRYGotoPage.Enabled = blnEnabled
                    Me.lnkCZRYSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_RY = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        ' 显示整个模块信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_Main(ByRef strErrMsg As String) As Boolean

            showModuleData_Main = False

            Try

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
        ' 填充职级下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillZjdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_ZHIJIDINGYI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZjdmList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillZjdmList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                'zengxianglin 2010-01-05
                Dim strWhere As String = ""
                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_JBSZ + " > 0"
                'zengxianglin 2010-01-05
                If objsystemEstateRenshiXingye.getDataSet_ZhijiDingyi(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiXingyeData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiXingyeData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)

            doFillZjdmList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充变动原因下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改描述
        '     zengxianglin 2008-11-22 增加接口[strWhere]
        '----------------------------------------------------------------
        Private Function doFillYdyyList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            Optional ByVal strWhere As String = "") As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_BIANDONGYUANYIN
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillYdyyList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillYdyyList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                'zengxianglin 2008-11-22
                'If objsystemEstateRenshiGeneral.getDataSet_BiandongYuanyin(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                '    GoTo errProc
                'End If
                If objsystemEstateRenshiGeneral.getDataSet_BiandongYuanyin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-22

                '清空现有列表
                objDropDownList.Items.Clear()

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)

            doFillYdyyList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充服务分组下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     strZZMC        ：单位名称
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillSsfzList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal strZZMC As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIFENZU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objCustomerData As Josco.JsKernal.Common.Data.CustomerData = Nothing

            doFillSsfzList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillYdyyList]接口参数不正确！"
                    GoTo errProc
                End If
                If strZZMC Is Nothing Then strZZMC = ""
                strZZMC = strZZMC.Trim

                '清空现有列表
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")
                If strZZMC = "" Then
                    Exit Try
                End If

                '获取数据
                If objsystemCustomer.getFenzuDataByFhmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, objCustomerData) = False Then
                    GoTo errProc
                End If

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objCustomerData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIFENZU_FZMC), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIFENZU_FZMC), "")

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName
                        objListItem.Value = strName
                        objDropDownList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objCustomerData)

            doFillSsfzList = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objCustomerData)
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
                    With objControlProcess
                        .doTranslateKey(Me.txtSearch_RY_DWMC)
                        .doTranslateKey(Me.txtSearch_RY_RYDM)
                        .doTranslateKey(Me.txtSearch_RY_ZJDM)
                        .doTranslateKey(Me.txtSearch_RY_RYMC)
                        .doTranslateKey(Me.txtSSDW)
                        'zengxianglin 2008-11-18
                        .doTranslateKey(Me.txtZGDW)
                        'zengxianglin 2008-11-18
                        .doTranslateKey(Me.txtSJLD)
                        .doTranslateKey(Me.txtSXSJ)
                        .doTranslateKey(Me.ddlYDYY)
                        .doTranslateKey(Me.ddlZJDM)
                        'zengxianglin 2008-10-14
                        .doTranslateKey(Me.txtRYPageIndex)
                        .doTranslateKey(Me.txtRYPageSize)
                        'zengxianglin 2008-10-14
                    End With

                    '设初始值
                    If Me.m_blnSaveScence = False Then
                        Me.txtSXSJ.Text = Now.ToString("yyyy-MM-dd")
                        'zengxianglin 2009-02-24
                        'Me.rblRYLX.SelectedIndex = 0
                        'Me.rblRYZT.SelectedIndex = 1
                        'Me.rblSFZB.SelectedIndex = 1
                        'zengxianglin 2009-02-24
                        Me.chkSFJZ.Checked = False
                    End If

                    '显示Main
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '显示grdRY
                    If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value, Me.m_blnEnforced_RY) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_RY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    '获取缓存数据
                    If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value, False) = False Then
                        GoTo errProc
                    End If
                End If
                '显示人员数目
                With Me.m_objDataSet_RY.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU)
                    Me.lblRYSM.Text = .DefaultView.Count.ToString
                End With
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

                '检查权限(不论是否回发！)
                Dim blnDo As Boolean
                If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = False Then
                    GoTo normExit
                End If

                '填充列表
                If Me.IsPostBack = False Then
                    If Me.doFillZjdmList(strErrMsg, Me.ddlZJDM) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-22
                    'If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY) = False Then
                    '    GoTo errProc
                    'End If
                    Dim strWhere As String = ""
                    strWhere = "(a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM + " like '" + Me.htxtBDYY_RYZJ.Value + "%'"
                    strWhere = strWhere + " or " + "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM + " like '" + Me.htxtBDYY_NBTZ.Value + "%')"
                    If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY, strWhere) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-22
                End If

                '获取接口参数
                If Me.getInterfaceParameters(strErrMsg) = False Then
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
normExit:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub










        '---------------------------------------------------------------------------------------------------------------------------
        '网格事件处理器
        '---------------------------------------------------------------------------------------------------------------------------
        Sub grdRY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdRY.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdRY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdRY > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdRY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdRY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        'zengxianglin 2008-10-14
        Private Sub grdRY_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRY.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblRYGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRY, Me.m_intRows_grdRY)
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub rblRYLX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblRYLX.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Select Case Me.rblRYLX.SelectedIndex
                    Case 0
                        Me.chkSFJZ.Enabled = False
                        Me.ddlSSFZ.Enabled = True
                        Me.txtSJLD.Enabled = True
                        Me.btnSelectSJLD.Enabled = True
                        Me.btnJSFZLB.Enabled = True
                    Case Else
                        Me.chkSFJZ.Enabled = True
                        Me.ddlSSFZ.Enabled = False
                        Me.txtSJLD.Enabled = False
                        Me.btnSelectSJLD.Enabled = False
                        Me.btnJSFZLB.Enabled = False
                End Select
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-11-18
        Private Sub chkSFJZ_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSFJZ.CheckedChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.chkSFJZ.Checked = True Then
                    Me.rblSFZB.SelectedIndex = 0
                Else
                    Me.rblSFZB.SelectedIndex = 1
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
        'zengxianglin 2008-11-18










        'zengxianglin 2008-10-14
        Private Sub doMoveFirst(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value, Me.m_blnEnforced_RY) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doMoveLast(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value, Me.m_blnEnforced_RY) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.PageCount - 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doMoveNext(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value, Me.m_blnEnforced_RY) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.CurrentPageIndex + 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doMovePrevious(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value, Me.m_blnEnforced_RY) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.CurrentPageIndex - 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doGotoPage(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtRYPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value, Me.m_blnEnforced_RY) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtRYPageIndex.Text = (Me.grdRY.CurrentPageIndex + 1).ToString()
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
            intPageSize = objPulicParameters.getObjectValue(Me.txtRYPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value, Me.m_blnEnforced_RY) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdRY.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtRYPageSize.Text = (Me.grdRY.PageSize).ToString()
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY, True) = False Then
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

        Private Sub doDeSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY, False) = False Then
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

        Private Sub lnkCZRYMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveFirst.Click
            Me.doMoveFirst("lnkCZRYMoveFirst")
        End Sub

        Private Sub lnkCZRYMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveLast.Click
            Me.doMoveLast("lnkCZRYMoveLast")
        End Sub

        Private Sub lnkCZRYMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveNext.Click
            Me.doMoveNext("lnkCZRYMoveNext")
        End Sub

        Private Sub lnkCZRYMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMovePrev.Click
            Me.doMovePrevious("lnkCZRYMovePrev")
        End Sub

        Private Sub lnkCZRYGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYGotoPage.Click
            Me.doGotoPage("lnkCZRYGotoPage")
        End Sub

        Private Sub lnkCZRYSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYSetPageSize.Click
            Me.doSetPageSize("lnkCZRYSetPageSize")
        End Sub

        Private Sub lnkCZRYSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYSelectAll.Click
            Me.doSelectAll("lnkCZRYSelectAll")
        End Sub

        Private Sub lnkCZRYDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYDeSelectAll.Click
            Me.doDeSelectAll("lnkCZRYDeSelectAll")
        End Sub
        'zengxianglin 2008-10-14









        Private Sub doSelectAll_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY, True) = False Then
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

        Private Sub doDeSelectAll_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY, False) = False Then
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

        Private Sub btnSelAll_RY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_RY.Click
            Me.doSelectAll_RY("btnSelAll_RY")
        End Sub

        Private Sub btnDeSelAll_RY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_RY.Click
            Me.doDeSelectAll_RY("btnDeSelAll_RY")
        End Sub












        Private Sub doSelectZZDM(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2008-11-18
        Private Sub doSelectZGDW(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
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
                    .iAllowNull = True
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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        'zengxianglin 2008-11-18

        Private Sub doSelectSJLD(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
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
                Dim objIDmxzRyxx As Josco.JsKernal.BusinessFacade.IDmxzRyxx = Nothing
                Dim strUrl As String = ""
                objIDmxzRyxx = New Josco.JsKernal.BusinessFacade.IDmxzRyxx
                With objIDmxzRyxx
                    .iMultiSelect = False
                    'zengxianglin 2008-10-14
                    '.iAllowNull = False
                    .iAllowNull = True
                    'zengxianglin 2008-10-14
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
                Session.Add(strNewSessionId, objIDmxzRyxx)
                strUrl = ""
                strUrl += "../../dmxz/dmxz_ryxx.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnSelectZZDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZZDM.Click
            Me.doSelectZZDM("btnSelectZZDM")
        End Sub

        Private Sub btnSelectZGDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZGDW.Click
            Me.doSelectZGDW("btnSelectZGDW")
        End Sub

        Private Sub btnSelectSJLD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectSJLD.Click
            Me.doSelectSJLD("btnSelectSJLD")
        End Sub












        'zengxianglin 2008-10-14 复查
        'zengxianglin 2010-01-05 更新
        Private Sub doWriteParams(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            strErrMsg = ""

            Try
                '检查
                If Me.grdRY.Items.Count < 1 Then
                    strErrMsg = "错误：[doWriteParams]网格列表中没有数据！"
                    GoTo errProc
                End If
                If Me.grdRY.SelectedIndex < 0 Then
                    strErrMsg = "错误：[doWriteParams]网格中没有选定行！"
                    GoTo errProc
                End If
                If Me.rblRYLX.SelectedIndex < 0 Then
                    strErrMsg = "错误：[doWriteParams]没有选择[人员类型]！"
                    GoTo errProc
                End If
                If Me.rblRYZT.SelectedIndex < 0 Then
                    strErrMsg = "错误：[doWriteParams]没有选择[人员状态]！"
                    GoTo errProc
                End If
                If Me.rblSFZB.SelectedIndex < 0 Then
                    strErrMsg = "错误：[doWriteParams]没有选择[是否占编]！"
                    GoTo errProc
                End If
                If Me.ddlZJDM.SelectedIndex < 0 Then
                    strErrMsg = "错误：[doWriteParams]没有选择[人员职级]！"
                    GoTo errProc
                End If
                If Me.ddlYDYY.SelectedIndex < 0 Then
                    strErrMsg = "错误：[doWriteParams]没有选择[变动原因]！"
                    GoTo errProc
                End If
                If Me.txtSXSJ.Text.Trim = "" Then
                    strErrMsg = "错误：[doWriteParams]没有输入[生效时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtSXSJ.Text) = False Then
                    strErrMsg = "错误：[doWriteParams]输入的[生效时间]是无效的日期！"
                    GoTo errProc
                End If
                Me.txtSXSJ.Text = CType(Me.txtSXSJ.Text, System.DateTime).ToString("yyyy-MM-dd")
                'zengxianglin 2009-05-14
                Dim objBDSJ As System.DateTime = CType(Me.txtSXSJ.Text, System.DateTime)
                If objBDSJ < Now.AddDays(-100) Then
                    strErrMsg = "错误：[" + Me.txtSXSJ.Text + "]超过[100]天，这些数据不能再调整！"
                    GoTo errProc
                End If
                'zengxianglin 2009-05-14
                If Me.txtSSDW.Text.Trim = "" Or Me.htxtSSDW.Value.Trim = "" Then
                    strErrMsg = "错误：[doWriteParams]没有输入[服务单位]！"
                    GoTo errProc
                End If

                '写入
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim i As Integer = Me.grdRY.SelectedIndex
                Dim intRecPos As Integer = 0

                'zengxianglin 2008-10-14
                '检查[自己不能是自己的上级]
                Dim strRYDM As String = ""
                Dim strRYMC As String = ""
                intRecPos = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM)
                strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intRecPos)
                intRecPos = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intRecPos)
                If Me.htxtSJLD.Value.Trim <> "" Then
                    If strRYDM = Me.htxtSJLD.Value.Trim Then
                        strErrMsg = "错误：[doWriteParams][" + strRYMC + "]不能为自己的上级！"
                        GoTo errProc
                    End If
                End If
                '检查时间的有效性
                Dim intRYLX As Integer = objPulicParameters.getObjectValue(Me.rblRYLX.SelectedValue, 1)
                Dim blnValid As Boolean = False
                If objsystemEstateRenshiXingye.doValidParamsJG_Add( _
                    strErrMsg, _
                    MyBase.UserId, MyBase.UserPassword, _
                    intRYLX, strRYDM, strRYMC, Me.htxtSSDW.Value, Me.txtSXSJ.Text, blnValid) = False Then
                    GoTo errProc
                End If
                If blnValid = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-10-14

                '获取对应数据行
                intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdRY.CurrentPageIndex, Me.grdRY.PageSize)
                objDataRow = Me.m_objDataSet_RY.Tables(strTable).DefaultView.Item(intRecPos).Row

                If Me.rblRYLX.SelectedIndex < 0 Then
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYLX) = 1
                Else
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYLX) = objPulicParameters.getObjectValue(Me.rblRYLX.SelectedValue, 1)
                End If
                If Me.rblRYZT.SelectedIndex < 0 Then
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = 1
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = Josco.JSOA.Common.Data.estateRenshiXingyeData.getRenyuanZhuangtaiName(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumRenyuanZhuangtai.Shiyong)
                Else
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = objPulicParameters.getObjectValue(Me.rblRYZT.SelectedValue, 1)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = Me.rblRYZT.SelectedItem.Text
                End If
                If Me.rblSFZB.SelectedIndex < 0 Then
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = 1
                Else
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = objPulicParameters.getObjectValue(Me.rblSFZB.SelectedValue, 1)
                End If

                If Me.ddlZJDM.SelectedIndex < 0 Then
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM) = ""
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC) = ""
                Else
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM) = objPulicParameters.getObjectValue(Me.ddlZJDM.SelectedValue, "")
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC) = Me.ddlZJDM.SelectedItem.Text.Split("|".ToCharArray)(1)
                End If
                If Me.ddlYDYY.SelectedIndex < 0 Then
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY) = ""
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYYMC) = ""
                Else
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY) = objPulicParameters.getObjectValue(Me.ddlYDYY.SelectedValue, "")
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYYMC) = Me.ddlYDYY.SelectedItem.Text.Split("|".ToCharArray)(1)
                End If

                If Me.ddlSSFZ.SelectedIndex < 0 Then
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = ""
                Else
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = objPulicParameters.getObjectValue(Me.ddlSSFZ.SelectedValue, "")
                End If

                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW) = Me.htxtSSDW.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC) = Me.txtSSDW.Text
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD) = Me.htxtSJLD.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC) = Me.txtSJLD.Text
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ) = Me.txtSXSJ.Text
                'zengxianglin 2008-11-18
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW) = Me.htxtZGDW.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC) = Me.txtZGDW.Text
                'zengxianglin 2008-11-18

                'zengxianglin 2010-01-05
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_BZXL) = Me.htxtBZXL.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_TDBH) = "0"
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGTD) = ""
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_XGTD) = ""
                If Me.chkSFJZ.Enabled = False Then
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ) = "0"
                Else
                    If Me.chkSFJZ.Checked = True Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ) = "1"
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ) = "0"
                    End If
                End If
                'zengxianglin 2010-01-05

                '显示
                If Me.showModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doSearch(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If
                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doJSFZLB(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtSSDW.Text) = False Then
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

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.doSearch("btnSearch")
        End Sub

        Private Sub btnJSFZLB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSFZLB.Click
            Me.doJSFZLB("btnJSFZLB")
        End Sub

        Private Sub btnWriteParam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWriteParam.Click
            Me.doWriteParams("btnWriteParam")
        End Sub












        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 1

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

        'zengxianglin 2008-10-14 复查
        'zengxianglin 2010-01-05 更新
        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objNewData As New System.Collections.Specialized.NameValueCollection
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 1

            Dim blnValid As Boolean = False
            Dim intIndex As Integer = 0
            Dim intRYLX As Integer = 0
            Dim strValue As String = ""
            Dim strRYDM As String = ""
            Dim strRYMC As String = ""
            Dim strSSDW As String = ""
            Dim strBDSJ As String = ""
            Dim strSJLD As String = ""
            Dim strYDYY As String = ""

            Try
                '检查变动时间
                strBDSJ = Me.txtSXSJ.Text.Trim
                If strBDSJ = "" Then
                    strErrMsg = "错误：没有输入[入职时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(strBDSJ) = False Then
                    strErrMsg = "错误：[" + strBDSJ + "]是无效的日期！"
                    GoTo errProc
                End If
                Dim objBDSJ As System.DateTime = CType(strBDSJ, System.DateTime)

                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdRY.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = True Then
                            '检查时间有效性
                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                            strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM)
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYLX)
                            strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                            intRYLX = objPulicParameters.getObjectValue(strValue, 1)
                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW)
                            strSSDW = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ)
                            strBDSJ = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                            If objsystemEstateRenshiXingye.doValidParamsJG_Add(strErrMsg, MyBase.UserId, MyBase.UserPassword, intRYLX, strRYDM, strRYMC, strSSDW, strBDSJ, blnValid) = False Then
                                GoTo errProc
                            End If
                            If blnValid = False Then
                                GoTo errProc
                            End If

                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要的入职的人员！"
                        GoTo errProc
                    End If
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定所有内容填写正确吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim blnSFJZ As Boolean = False
                    '保存数据
                    intRows = Me.grdRY.Items.Count
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = True Then
                            '准备数据
                            objNewData.Clear()

                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                            strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY)
                            strYDYY = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYLX)
                            strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)

                            If strValue = "1" Then
                                '添加管理架构
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_WYBS, "")

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                strRYDM = strValue
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYDM, strValue)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYMC, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZJDM, strValue)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZJMC, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYZT, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSDW, strValue)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSDWMC, strValue)

                                'zengxianglin 2008-11-18
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZGDW, strValue)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZGDWMC, strValue)
                                'zengxianglin 2008-11-18

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSFZ, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SFZB, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                strSJLD = strValue
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SJLD, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_KSSJ, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_JSSJ, strValue)

                                'zengxianglin 2010-01-05
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_BZXL)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_BZXL, strValue)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_TDBH)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_TDBH, strValue)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGTD)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZGTD, strValue)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_XGTD)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_XGTD, strValue)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_YDYY, strYDYY)
                                'zengxianglin 2010-01-05

                                If objsystemEstateRenshiXingye.doAddNew_GuanliJiagou(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData, strYDYY, False, Nothing) = False Then
                                    GoTo errProc
                                End If

                                '写配置日志
                                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_人员架构_管理架构]中增加了[" + strRYMC + "]！")
                            Else
                                '添加助理架构
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_WYBS, "")

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_RYDM, strValue)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_RYMC, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_ZJDM, strValue)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_ZJMC, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_RYZT, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SSDW, strValue)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SSDWMC, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SFZB, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_KSSJ, strValue)

                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_JSSJ, strValue)

                                'zengxianglin 2010-01-05
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_BZXL)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_BZXL, strValue)
                                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_YDYY, strYDYY)
                                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ)
                                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intIndex)
                                If strValue = "1" Then
                                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SFJZ, "1")
                                    blnSFJZ = True
                                Else
                                    blnSFJZ = False
                                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SFJZ, "0")
                                End If
                                'zengxianglin 2010-01-05

                                If objsystemEstateRenshiXingye.doAddNew_ZhuliJiagou(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData, strYDYY, blnSFJZ) = False Then
                                    GoTo errProc
                                End If

                                '写配置日志
                                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_人员架构_助理架构]中增加了[" + strRYMC + "]！")
                            End If
                        End If
                    Next

                    '刷新显示(强制重新获取数据)
                    If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value, True) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_RY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        'zengxianglin 2008-10-14
        'Private Sub btnViewJG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewJG.Click
        '    Dim strUrl As String = "estate_rs_renyuanjiagou.aspx"
        '    Response.Redirect(strUrl)
        'End Sub
        'zengxianglin 2008-10-14

    End Class

End Namespace
