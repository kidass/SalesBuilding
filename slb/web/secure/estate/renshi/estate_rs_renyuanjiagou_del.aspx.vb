Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_renyuanjiagou_del
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“人员离岗”处理模块
    '
    ' 更改记录：
    '     zengxianglin 2009-05-14 更改
    '     zengxianglin 2009-07-13 更改
    '----------------------------------------------------------------

    Partial Class estate_rs_renyuanjiagou_del
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



        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14


        'zengxianglin 2008-11-18
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-22
        'zengxianglin 2008-11-22

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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Del
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Del
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
        '与数据网格grdXJ相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdXJ As String = "chkXJ"
        Private Const m_cstrDataGridInDIV_grdXJ As String = "divXJ"
        Private m_intFixedColumns_grdXJ As Integer
        'zengxianglin 2008-10-14
        Private m_intRows_grdXJ As Integer
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_RY As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_XJ As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '其他参数
        '----------------------------------------------------------------
        Private m_blnEnforced_XJ As Boolean












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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Del)
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
                    Me.htxtDivLeftXJ.Value = .htxtDivLeftXJ
                    Me.htxtDivTopXJ.Value = .htxtDivTopXJ

                    Me.htxtSessionIdQuery_RY.Value = .htxtSessionIdQuery_RY
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

                    Me.htxtSessionId_XJ.Value = .htxtSessionId_XJ
                    Try
                        Me.grdXJ.PageSize = .grdXJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXJ.CurrentPageIndex = .grdXJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXJ.SelectedIndex = .grdXJ_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.ddlYDYY.SelectedIndex = .ddlYDYY_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblBDLX.SelectedIndex = .rblBDLX_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.txtSXSJ.Text = .txtSXSJ

                    Me.txtSJLD_XJ.Text = .txtSJLD_XJ
                    Me.htxtSJLD_XJ.Value = .htxtSJLD_XJ

                    Me.txtSearch_RY_RYDM.Text = .txtSearch_RY_RYDM
                    Me.txtSearch_RY_ZJDM.Text = .txtSearch_RY_ZJDM
                    Me.txtSearch_RY_RYMC.Text = .txtSearch_RY_RYMC
                    Me.txtSearch_RY_DWMC.Text = .txtSearch_RY_DWMC

                    'zengxianglin 2008-10-14
                    Me.txtRYPageIndex.Text = .txtRYPageIndex
                    Me.txtRYPageSize.Text = .txtRYPageSize
                    Me.htxtRYRows.Value = .htxtRYRows
                    Me.txtXJPageIndex.Text = .txtXJPageIndex
                    Me.txtXJPageSize.Text = .txtXJPageSize
                    Me.htxtXJRows.Value = .htxtXJRows
                    'zengxianglin 2008-10-14

                    'zengxianglin 2008-10-14
                    Me.txtZZDM_XJ.Text = .txtZZDM_XJ
                    Me.htxtZZDM_XJ.Value = .htxtZZDM_XJ
                    'zengxianglin 2008-11-18
                    Me.txtZGDW_XJ.Text = .txtZGDW_XJ
                    Me.htxtZGDW_XJ.Value = .htxtZGDW_XJ
                    'zengxianglin 2008-11-18
                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_XJ, Me.txtZZDM_XJ.Text)
                    Try
                        Me.ddlSSFZ_XJ.SelectedIndex = .ddlSSFZ_XJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlZJDM_XJ.SelectedIndex = .ddlZJDM_XJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlYDYY_XJ.SelectedIndex = .ddlYDYY_XJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblRYZT_XJ.SelectedIndex = .rblRYZT_XJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFZB_XJ.SelectedIndex = .rblSFZB_XJ_SelectedIndex
                    Catch ex As Exception
                    End Try
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Del

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftRY = Me.htxtDivLeftRY.Value
                    .htxtDivTopRY = Me.htxtDivTopRY.Value

                    .htxtSessionIdQuery_RY = Me.htxtSessionIdQuery_RY.Value
                    .htxtQuery_RY = Me.htxtQuery_RY.Value
                    .grdRY_PageSize = Me.grdRY.PageSize
                    .grdRY_CurrentPageIndex = Me.grdRY.CurrentPageIndex
                    .grdRY_SelectedIndex = Me.grdRY.SelectedIndex

                    .htxtSessionId_XJ = Me.htxtSessionId_XJ.Value
                    .grdXJ_PageSize = Me.grdXJ.PageSize
                    .grdXJ_CurrentPageIndex = Me.grdXJ.CurrentPageIndex
                    .grdXJ_SelectedIndex = Me.grdXJ.SelectedIndex

                    .ddlYDYY_SelectedIndex = Me.ddlYDYY.SelectedIndex
                    .rblBDLX_SelectedIndex = Me.rblBDLX.SelectedIndex
                    .txtSXSJ = Me.txtSXSJ.Text

                    .txtSJLD_XJ = Me.txtSJLD_XJ.Text
                    .htxtSJLD_XJ = Me.htxtSJLD_XJ.Value

                    .txtSearch_RY_RYDM = Me.txtSearch_RY_RYDM.Text
                    .txtSearch_RY_ZJDM = Me.txtSearch_RY_ZJDM.Text
                    .txtSearch_RY_RYMC = Me.txtSearch_RY_RYMC.Text
                    .txtSearch_RY_DWMC = Me.txtSearch_RY_DWMC.Text

                    'zengxianglin 2008-10-14
                    .txtRYPageIndex = Me.txtRYPageIndex.Text
                    .txtRYPageSize = Me.txtRYPageSize.Text
                    .htxtRYRows = Me.htxtRYRows.Value
                    .txtXJPageIndex = Me.txtXJPageIndex.Text
                    .txtXJPageSize = Me.txtXJPageSize.Text
                    .htxtXJRows = Me.htxtXJRows.Value
                    'zengxianglin 2008-10-14

                    'zengxianglin 2008-10-14
                    .txtZZDM_XJ = Me.txtZZDM_XJ.Text
                    .htxtZZDM_XJ = Me.htxtZZDM_XJ.Value
                    'zengxianglin 2008-11-18
                    .txtZGDW_XJ = Me.txtZGDW_XJ.Text
                    .htxtZGDW_XJ = Me.htxtZGDW_XJ.Value
                    'zengxianglin 2008-11-18
                    .ddlSSFZ_XJ_SelectedIndex = Me.ddlSSFZ_XJ.SelectedIndex
                    .ddlZJDM_XJ_SelectedIndex = Me.ddlZJDM_XJ.SelectedIndex
                    .ddlYDYY_XJ_SelectedIndex = Me.ddlYDYY_XJ.SelectedIndex
                    .rblRYZT_XJ_SelectedIndex = Me.rblRYZT_XJ.SelectedIndex
                    .rblSFZB_XJ_SelectedIndex = Me.rblSFZB_XJ.SelectedIndex
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                'zengxianglin 2008-10-14
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
                            Case "btnSelectZZDM_XJ".ToUpper()
                                Dim strZZMC As String = objIDmxzZzjg.oBumenList
                                Dim strZZDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtZZDM_XJ.Value = strZZDM
                                    Me.txtZZDM_XJ.Text = strZZMC
                                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_XJ, strZZMC)
                                End If

                                'zengxianglin 2008-11-18
                            Case "btnSelectZGDW_XJ".ToUpper()
                                Dim strZZMC As String = objIDmxzZzjg.oBumenList
                                Dim strZZDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtZGDW_XJ.Value = strZZDM
                                    Me.txtZGDW_XJ.Text = strZZMC
                                End If
                                'zengxianglin 2008-11-18
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
                    Exit Try
                End If
                'zengxianglin 2008-10-14

                '==========================================================================================================================================================
                Dim objIEstateRsRenyuanJiagou_Rela As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela = Nothing
                Try
                    objIEstateRsRenyuanJiagou_Rela = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela)
                Catch ex As Exception
                    objIEstateRsRenyuanJiagou_Rela = Nothing
                End Try
                If Not (objIEstateRsRenyuanJiagou_Rela Is Nothing) Then
                    If objIEstateRsRenyuanJiagou_Rela.oExitMode = True Then
                        Select Case objIEstateRsRenyuanJiagou_Rela.iSourceControlId.ToUpper()
                            Case "btnSelectSJLD_XJ".ToUpper()
                                Me.htxtSJLD_XJ.Value = objIEstateRsRenyuanJiagou_Rela.oRYDM
                                Me.txtSJLD_XJ.Text = objIEstateRsRenyuanJiagou_Rela.oRYZM
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela.SafeRelease(objIEstateRsRenyuanJiagou_Rela)
                    Exit Try
                End If

                '=================================================================
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                        Select Case objISjcxCxtj.iSourceControlId.ToUpper
                            Case "btnSearchFull_RY".ToUpper
                                Me.htxtQuery_RY.Value = objISjcxCxtj.oQueryString
                                If Me.htxtSessionIdQuery_RY.Value.Trim = "" Then
                                    Me.htxtSessionIdQuery_RY.Value = objPulicParameters.getNewGuid()
                                Else
                                    Try
                                        objQueryData = CType(Session(Me.htxtSessionIdQuery_RY.Value), Josco.JsKernal.Common.Data.QueryData)
                                    Catch ex As Exception
                                        objQueryData = Nothing
                                    End Try
                                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                                End If
                                Session.Add(Me.htxtSessionIdQuery_RY.Value, objISjcxCxtj.oDataSetTJ)
                                Me.m_blnEnforced_XJ = True
                            Case Else
                        End Select
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Del)
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
                Me.m_blnEnforced_XJ = False

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Del)
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
                Me.m_intFixedColumns_grdXJ = objPulicParameters.getObjectValue(Me.htxtXJFixed.Value, 0)

                'zengxianglin 2008-10-14
                Me.m_intRows_grdRY = objPulicParameters.getObjectValue(Me.htxtRYRows.Value, 0)
                Me.m_intRows_grdXJ = objPulicParameters.getObjectValue(Me.htxtXJRows.Value, 0)
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
                If Me.htxtSessionId_XJ.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_XJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_XJ.Value)
                End If

                Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                If Me.htxtSessionIdQuery_RY.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQuery_RY.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery_RY.Value)
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
        Private Function getQueryString_RY( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_RY = False
            strQuery = ""

            Try
                '按人员代码搜索
                Dim strRYDM As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM
                If Me.txtSearch_RY_RYDM.Text.Length > 0 Then Me.txtSearch_RY_RYDM.Text = Me.txtSearch_RY_RYDM.Text.Trim()
                If Me.txtSearch_RY_RYDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strRYDM + " like '" + Me.txtSearch_RY_RYDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYDM + " like '" + Me.txtSearch_RY_RYDM.Text + "%'"
                    End If
                End If

                '按职级代码搜索
                Dim strZJDM As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM
                If Me.txtSearch_RY_ZJDM.Text.Length > 0 Then Me.txtSearch_RY_ZJDM.Text = Me.txtSearch_RY_ZJDM.Text.Trim()
                If Me.txtSearch_RY_ZJDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strZJDM + " like '" + Me.txtSearch_RY_ZJDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strZJDM + " like '" + Me.txtSearch_RY_ZJDM.Text + "%'"
                    End If
                End If

                '按人员名称搜索
                Dim strRYMC As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC
                If Me.txtSearch_RY_RYMC.Text.Length > 0 Then Me.txtSearch_RY_RYMC.Text = Me.txtSearch_RY_RYMC.Text.Trim()
                If Me.txtSearch_RY_RYMC.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strRYMC + " like '" + Me.txtSearch_RY_RYMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYMC + " like '" + Me.txtSearch_RY_RYMC.Text + "%'"
                    End If
                End If

                '按人员名称搜索
                Dim strSSDWMC As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC
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

            getQueryString_RY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdRY要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索字符串
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_RY( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye

            getModuleData_RY = False

            Try
                '释放资源
                Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RY)

                '重新检索数据
                If objsystemEstateRenshiXingye.getDataSet_RYJG_RY_In(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_RY) = False Then
                    GoTo errProc
                End If

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

            getModuleData_RY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU

            searchModuleData_RY = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_RY(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_RY(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.htxtQuery_RY.Value = strQuery
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
        ' 获取grdXJ要显示的数据
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索字符串
        '     blnEnforced    ：True-重新获取数据 False-优先从缓存获取数据
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_XJ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnEnforced As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_XJ = False

            Try
                '计算grdRY中的当前行数据
                Dim intColIndex As Integer = 0
                Dim strSJLD As String = ""
                If Me.grdRY.Items.Count > 0 And Me.grdRY.SelectedIndex >= 0 Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM)
                    strSJLD = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                End If
                '获取指定人员的直接下级
                If strWhere = "" Then
                    strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD + " = '" + strSJLD + "'"
                Else
                    strWhere = strWhere + " and " + "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD + " = '" + strSJLD + "'"
                End If

                '释放缓存数据
                If blnEnforced = True Then
                    If Me.htxtSessionId_XJ.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_XJ = CType(Session.Item(Me.htxtSessionId_XJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Catch ex As Exception
                            Me.m_objDataSet_XJ = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_XJ)
                        Session.Remove(Me.htxtSessionId_XJ.Value)
                        Me.htxtSessionId_XJ.Value = ""
                    End If
                End If

                '获取下属数据
                If Me.htxtSessionId_XJ.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_XJ = CType(Session.Item(Me.htxtSessionId_XJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_XJ)
                    '重新检索数据
                    'zengxianglin 2008-10-14
                    If objsystemEstateRenshiXingye.getDataSet_RYJG_RY_In(strErrMsg, MyBase.UserId, MyBase.UserPassword, True, strWhere, Me.m_objDataSet_XJ) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-10-14
                    '缓存数据
                    Me.htxtSessionId_XJ.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_XJ.Value, Me.m_objDataSet_XJ)
                End If

                'zengxianglin 2008-10-14
                '缓存参数
                With Me.m_objDataSet_XJ.Tables(strTable)
                    Me.htxtXJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_grdXJ = .DefaultView.Count
                End With
                'zengxianglin 2008-10-14
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_XJ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdRY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = False Then
                '    GoTo errProc
                'End If

                '显示人员数目
                With Me.m_objDataSet_RY.Tables(strTable)
                    Me.lblRYSM_RY.Text = .DefaultView.Count.ToString
                End With

                '显示生效时间
                Dim intColIndex As Integer = 0
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ)
                If Me.grdRY.SelectedIndex >= 0 Then
                    Me.txtKSSJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                Else
                    Me.txtKSSJ.Text = ""
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
        ' 更改描述
        '     zengxianglin 2008-11-06 add Optional ByVal blnEnforced As Boolean = False
        '----------------------------------------------------------------
        Private Function showModuleData_RY( _
            ByRef strErrMsg As String, _
            Optional ByVal blnEnforced As Boolean = False) As Boolean

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

                '显示相关信息
                'zengxianglin 2008-11-06
                If blnEnforced = True Then
                    If Me.getModuleData_XJ(strErrMsg, "", True) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_XJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2008-11-06
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
        ' 显示grdXJ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_XJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_XJ = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_XJ Is Nothing Then
                    Me.grdXJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_XJ.Tables(strTable)
                        Me.grdXJ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_XJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdXJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdXJ.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdXJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXJ) = False Then
                    GoTo errProc
                End If

                '显示人员数目
                With Me.m_objDataSet_XJ.Tables(strTable)
                    Me.lblRYSM_XJ.Text = .DefaultView.Count.ToString
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_XJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' 显示grdXJ相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_XJ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_XJ = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_XJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_XJ.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblXJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdXJ, .Count)

                    '显示页面浏览功能
                    Me.lnkCZXJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdXJ, .Count)
                    Me.lnkCZXJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdXJ, .Count)
                    Me.lnkCZXJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdXJ, .Count)
                    Me.lnkCZXJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdXJ, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZXJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZXJSelectAll.Enabled = blnEnabled
                    Me.lnkCZXJGotoPage.Enabled = blnEnabled
                    Me.lnkCZXJSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_XJ = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function
        'zengxianglin 2008-10-14











        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' 将grdXJ当前行信息显示到参数表中
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditPanel_XJ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanel_XJ = False

            Try
                '清空
                Me.htxtZZDM_XJ.Value = ""
                Me.txtZZDM_XJ.Text = ""
                Me.ddlSSFZ_XJ.SelectedIndex = -1
                Me.ddlZJDM_XJ.SelectedIndex = -1
                Me.ddlYDYY_XJ.SelectedIndex = -1
                Me.rblRYZT_XJ.SelectedIndex = -1
                Me.rblSFZB_XJ.SelectedIndex = -1

                '检查
                If Me.grdXJ.SelectedIndex < 0 Then
                    Exit Try
                End If
                Dim intIndex As Integer = Me.grdXJ.SelectedIndex

                '显示
                Dim intColIndex As Integer
                Dim strValue As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW)
                Me.htxtZZDM_XJ.Value = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC)
                Me.txtZZDM_XJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_XJ, Me.txtZZDM_XJ.Text)

                'zengxianglin 2008-11-18
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW)
                Me.htxtZGDW_XJ.Value = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC)
                Me.txtZGDW_XJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                'zengxianglin 2008-11-18

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD)
                Me.htxtSJLD_XJ.Value = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC)
                Me.txtSJLD_XJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.ddlZJDM_XJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZJDM_XJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.ddlYDYY_XJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYDYY_XJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.rblRYZT_XJ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYZT_XJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.rblSFZB_XJ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZB_XJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.ddlSSFZ_XJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSSFZ_XJ, strValue, True)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_XJ = True
            Exit Function
errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
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

        'zengxianglin 2008-10-14
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
                If objsystemEstateRenshiXingye.getDataSet_ZhijiDingyi(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiXingyeData) = False Then
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' 填充分组下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     strZZMC        ：组织名称
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
        'zengxianglin 2008-10-14

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
                        .doTranslateKey(Me.txtSJLD_XJ)
                        .doTranslateKey(Me.txtSXSJ)
                        .doTranslateKey(Me.txtKSSJ)
                        .doTranslateKey(Me.ddlYDYY)

                        'zengxianglin 2008-10-14
                        .doTranslateKey(Me.txtRYPageIndex)
                        .doTranslateKey(Me.txtRYPageSize)
                        .doTranslateKey(Me.txtXJPageIndex)
                        .doTranslateKey(Me.txtXJPageSize)
                        'zengxianglin 2008-10-14

                        'zengxianglin 2008-10-14
                        .doTranslateKey(Me.txtZZDM_XJ)
                        'zengxianglin 2008-11-18
                        .doTranslateKey(Me.txtZGDW_XJ)
                        'zengxianglin 2008-11-18
                        .doTranslateKey(Me.ddlSSFZ_XJ)
                        .doTranslateKey(Me.ddlZJDM_XJ)
                        .doTranslateKey(Me.ddlYDYY_XJ)
                        'zengxianglin 2008-10-14
                    End With

                    '设初始值
                    If Me.m_blnSaveScence = False Then
                        Me.txtSXSJ.Text = Now.ToString("yyyy-MM-dd")
                        Me.rblBDLX.SelectedIndex = 0
                    End If

                    '显示Main
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '显示grdRY
                    If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-06
                    If Me.m_blnSaveScence = False Then
                        If Me.showModuleData_RY(strErrMsg, True) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.showModuleData_RY(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        '显示grdXJ
                        If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                            GoTo errProc
                        End If
                        If Me.showModuleData_XJ(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    End If
                    'zengxianglin 2008-11-06
                Else
                    '获取缓存数据
                    If Me.getModuleData_XJ(strErrMsg, "", False) = False Then
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
                    'zengxianglin 2008-11-22
                    Dim strWhere As String = ""
                    strWhere = "(a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM + " like '" + Me.htxtBDYY_RYJS.Value + "%'"
                    strWhere = strWhere + " or " + "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM + " like '" + Me.htxtBDYY_NBTZ.Value + "%')"
                    'If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY) = False Then
                    '    GoTo errProc
                    'End If
                    If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY, strWhere) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-22
                    If Me.doFillZjdmList(strErrMsg, Me.ddlZJDM_XJ) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY_XJ) = False Then
                        GoTo errProc
                    End If
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

        Sub grdXJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdXJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdXJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdXJ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdXJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdXJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdRY_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRY.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                'zengxianglin 2008-10-14
                '显示记录位置
                Me.lblRYGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRY, Me.m_intRows_grdRY)
                'zengxianglin 2008-10-14

                'zengxianglin 2009-07-13
                '显示生效时间
                Dim intColIndex As Integer = 0
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ)
                If Me.grdRY.SelectedIndex >= 0 Then
                    Me.txtKSSJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                Else
                    Me.txtKSSJ.Text = ""
                End If
                'zengxianglin 2009-07-13

                '同步显示信息
                If Me.getModuleData_XJ(strErrMsg, "", True) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        'zengxianglin 2008-10-14
        Private Sub grdXJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdXJ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblXJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdXJ, Me.m_intRows_grdXJ)

                ''同步显示信息
                'If Me.showEditPanel_XJ(strErrMsg) = False Then
                '    GoTo errProc
                'End If
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
        Private Sub doMoveFirst_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06
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

        Private Sub doMoveLast_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.PageCount - 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06
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

        Private Sub doMoveNext_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.CurrentPageIndex + 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06
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

        Private Sub doMovePrevious_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.CurrentPageIndex - 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06
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

        Private Sub doGotoPage_RY(ByVal strControlId As String)

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
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdRY.CurrentPageIndex = intPageIndex

                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06

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

        Private Sub doSetPageSize_RY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtRYPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdRY.PageSize = intPageSize

                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06

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

        Private Sub lnkCZRYMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveFirst.Click
            Me.doMoveFirst_RY("lnkCZRYMoveFirst")
        End Sub

        Private Sub lnkCZRYMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveLast.Click
            Me.doMoveLast_RY("lnkCZRYMoveLast")
        End Sub

        Private Sub lnkCZRYMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveNext.Click
            Me.doMoveNext_RY("lnkCZRYMoveNext")
        End Sub

        Private Sub lnkCZRYMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMovePrev.Click
            Me.doMovePrevious_RY("lnkCZRYMovePrev")
        End Sub

        Private Sub lnkCZRYGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYGotoPage.Click
            Me.doGotoPage_RY("lnkCZRYGotoPage")
        End Sub

        Private Sub lnkCZRYSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYSetPageSize.Click
            Me.doSetPageSize_RY("lnkCZRYSetPageSize")
        End Sub

        Private Sub lnkCZRYSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYSelectAll.Click
            Me.doSelectAll_RY("lnkCZRYSelectAll")
        End Sub

        Private Sub lnkCZRYDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYDeSelectAll.Click
            Me.doDeSelectAll_RY("lnkCZRYDeSelectAll")
        End Sub
        'zengxianglin 2008-10-14











        'zengxianglin 2008-10-14
        Private Sub doMoveFirst_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdXJ.PageCount)
                Me.grdXJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        Private Sub doMoveLast_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXJ.PageCount - 1, Me.grdXJ.PageCount)
                Me.grdXJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        Private Sub doMoveNext_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXJ.CurrentPageIndex + 1, Me.grdXJ.PageCount)
                Me.grdXJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        Private Sub doMovePrevious_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXJ.CurrentPageIndex - 1, Me.grdXJ.PageCount)
                Me.grdXJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        Private Sub doGotoPage_XJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtXJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdXJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_XJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtXJPageIndex.Text = (Me.grdXJ.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_XJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtXJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdXJ.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_XJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtXJPageSize.Text = (Me.grdXJ.PageSize).ToString()
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

        Private Sub doSelectAll_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdXJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXJ, True) = False Then
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

        Private Sub doDeSelectAll_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdXJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXJ, False) = False Then
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

        Private Sub lnkCZXJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJMoveFirst.Click
            Me.doMoveFirst_XJ("lnkCZXJMoveFirst")
        End Sub

        Private Sub lnkCZXJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJMoveLast.Click
            Me.doMoveLast_XJ("lnkCZXJMoveLast")
        End Sub

        Private Sub lnkCZXJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJMoveNext.Click
            Me.doMoveNext_XJ("lnkCZXJMoveNext")
        End Sub

        Private Sub lnkCZXJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJMovePrev.Click
            Me.doMovePrevious_XJ("lnkCZXJMovePrev")
        End Sub

        Private Sub lnkCZXJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJGotoPage.Click
            Me.doGotoPage_XJ("lnkCZXJGotoPage")
        End Sub

        Private Sub lnkCZXJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJSetPageSize.Click
            Me.doSetPageSize_XJ("lnkCZXJSetPageSize")
        End Sub

        Private Sub lnkCZXJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJSelectAll.Click
            Me.doSelectAll_XJ("lnkCZXJSelectAll")
        End Sub

        Private Sub lnkCZXJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJDeSelectAll.Click
            Me.doDeSelectAll_XJ("lnkCZXJDeSelectAll")
        End Sub
        'zengxianglin 2008-10-14

        Private Sub btnSelAll_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_XJ.Click
            Me.doSelectAll_XJ("btnSelAll_XJ")
        End Sub

        Private Sub btnDeSelAll_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_XJ.Click
            Me.doDeSelectAll_XJ("btnDeSelAll_XJ")
        End Sub











        Private Sub doSelectSJLD_XJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'zengxianglin 2008-11-18
                '检查
                If Me.txtSXSJ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[变动时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtSXSJ.Text) = False Then
                    strErrMsg = "错误：无效的[变动时间]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-18

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateRsRenyuanJiagou_Rela As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela = Nothing
                Dim strUrl As String = ""
                objIEstateRsRenyuanJiagou_Rela = New Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela
                With objIEstateRsRenyuanJiagou_Rela
                    'zengxianglin 2008-11-18
                    '.iTime = Now.ToString("yyyy-MM-dd")
                    .iTime = Me.txtSXSJ.Text
                    'zengxianglin 2008-11-18
                    'zengxianglin 2008-10-14
                    .iAllowNull = True
                    'zengxianglin 2008-10-14
                    .iMode = 1

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
                Session.Add(strNewSessionId, objIEstateRsRenyuanJiagou_Rela)
                strUrl = ""
                strUrl += "estate_rs_renyuanjiagou_rela.aspx"
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

        'zengxianglin 2008-10-14
        Private Sub doSelectZZDM_XJ(ByVal strControlId As String)

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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-11-18
        Private Sub doSelectZGDW_XJ(ByVal strControlId As String)

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

        'zengxianglin 2008-10-14
        Private Sub doJSFZLB_XJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_XJ, Me.txtZZDM_XJ.Text) = False Then
                    GoTo errProc
                End If
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub doGetSJLD_XJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.showEditPanel_XJ(strErrMsg) = False Then
                    GoTo errProc
                End If
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
        'zengxianglin 2008-10-14

        Private Sub btnSelectSJLD_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectSJLD_XJ.Click
            Me.doSelectSJLD_XJ("btnSelectSJLD_XJ")
        End Sub

        'zengxianglin 2008-10-14
        Private Sub btnSelectZZDM_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZZDM_XJ.Click
            Me.doSelectZZDM_XJ("btnSelectZZDM_XJ")
        End Sub
        'zengxianglin 2008-10-14

        'zengxianglin 2008-11-18
        Private Sub btnSelectZGDW_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZGDW_XJ.Click
            Me.doSelectZGDW_XJ("btnSelectZGDW_XJ")
        End Sub
        'zengxianglin 2008-11-18

        'zengxianglin 2008-10-14
        Private Sub btnJSFZLB_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSFZLB_XJ.Click
            Me.doJSFZLB_XJ("btnJSFZLB_XJ")
        End Sub
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub btnGetSJLD_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetSJLD_XJ.Click
            Me.doGetSJLD_XJ("btnGetSJLD_XJ")
        End Sub
        'zengxianglin 2008-10-14











        'zengxianglin 2008-10-14
        '改批量写入变为单条写入！
        'zengxianglin 2008-10-14
        Private Sub doSaveSJLD_XJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            strErrMsg = ""

            Try
                '检查
                If Me.grdXJ.Items.Count < 1 Then
                    strErrMsg = "错误：[doSaveSJLD_XJ]网格列表中没有数据！"
                    GoTo errProc
                End If
                If Me.grdXJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：[doSaveSJLD_XJ]网格列表中没有数据！"
                    GoTo errProc
                End If
                If Me.ddlZJDM_XJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定[新职级]！"
                    GoTo errProc
                End If
                If Me.ddlYDYY_XJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定[变动原因]！"
                    GoTo errProc
                End If
                If Me.rblRYZT_XJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定[正式职工]或[试用人员]！"
                    GoTo errProc
                End If
                If Me.rblSFZB_XJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定[编内人员]或[编外人员]！"
                    GoTo errProc
                End If
                If Me.htxtZZDM_XJ.Value.Trim = "" Then
                    strErrMsg = "错误：没有指定[新单位]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-10-14
                'If Me.htxtSJLD_XJ.Value.Trim = "" Then
                '    strErrMsg = "错误：没有指定[新领导]！"
                '    GoTo errProc
                'End If
                'zengxianglin 2008-10-14
                Dim strSSFZ As String = ""
                If Me.ddlSSFZ_XJ.SelectedIndex >= 0 Then
                    strSSFZ = Me.ddlSSFZ_XJ.SelectedItem.Text
                End If

                '获取对应数据行
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim i As Integer = Me.grdXJ.SelectedIndex
                Dim intRecPos As Integer = 0
                intRecPos = -1
                intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdXJ.CurrentPageIndex, Me.grdXJ.PageSize)
                objDataRow = Nothing
                objDataRow = Me.m_objDataSet_XJ.Tables(strTable).DefaultView.Item(intRecPos).Row

                '写入信息
                Dim strValue As String = ""
                Dim intValue As Integer
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD) = Me.htxtSJLD_XJ.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC) = Me.txtSJLD_XJ.Text
                'zengxianglin 2008-10-14
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW) = Me.htxtZZDM_XJ.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC) = Me.txtZZDM_XJ.Text
                'zengxianglin 2008-11-18
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW) = Me.htxtZGDW_XJ.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC) = Me.txtZGDW_XJ.Text
                'zengxianglin 2008-11-18
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM) = Me.ddlZJDM_XJ.SelectedItem.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC) = Me.ddlZJDM_XJ.SelectedItem.Text.Split("|".ToCharArray)(1)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY) = Me.ddlYDYY_XJ.SelectedItem.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYYMC) = Me.ddlYDYY_XJ.SelectedItem.Text.Split("|".ToCharArray)(1)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = strSSFZ
                intValue = objPulicParameters.getObjectValue(Me.rblRYZT_XJ.SelectedValue, 1)
                Select Case intValue
                    Case 2
                        strValue = Josco.JSOA.Common.Data.estateRenshiXingyeData.getRenyuanZhuangtaiName(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumRenyuanZhuangtai.Ruzhi)
                    Case Else
                        strValue = Josco.JSOA.Common.Data.estateRenshiXingyeData.getRenyuanZhuangtaiName(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumRenyuanZhuangtai.Shiyong)
                End Select
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = intValue
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = strValue
                intValue = objPulicParameters.getObjectValue(Me.rblSFZB_XJ.SelectedValue, 0)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = intValue
                'zengxianglin 2008-10-14

                '显示
                If Me.showModuleData_XJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doSearch_RY(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.searchModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_XJ(strErrMsg, "", True) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        Private Sub doSearchFull_RY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
                Dim strUrl As String = ""
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    .iQueryTable = Me.m_objDataSet_RY.Tables(strTable)
                    Try
                        If Me.htxtSessionIdQuery_RY.Value.Trim <> "" Then
                            .iDataSetTJ = CType(Session(Me.htxtSessionIdQuery_RY.Value), Josco.JsKernal.Common.Data.QueryData)
                        Else
                            .iDataSetTJ = Nothing
                        End If
                    Catch ex As Exception
                        .iDataSetTJ = Nothing
                    End Try
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
                Dim strNewSessionId As String = ""
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

        Private Sub btnSaveSJLD_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveSJLD_XJ.Click
            Me.doSaveSJLD_XJ("btnSaveSJLD_XJ")
        End Sub

        Private Sub btnSearch_RY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch_RY.Click
            Me.doSearch_RY("btnSearch_RY")
        End Sub

        Private Sub btnSearchFull_RY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchFull_RY.Click
            Me.doSearchFull_RY("btnSearchFull_RY")
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

        Private Sub doOK(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objEnvInfo As System.Collections.Specialized.NameValueCollection = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 1

            Try
                'zengxianglin 2009-05-14
                '检查变动时间
                Dim strBDSJ As String = ""
                strBDSJ = Me.txtSXSJ.Text.Trim
                If strBDSJ = "" Then
                    strErrMsg = "错误：没有输入[离开时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(strBDSJ) = False Then
                    strErrMsg = "错误：[" + strBDSJ + "]是无效的日期！"
                    GoTo errProc
                End If
                Dim objBDSJ As System.DateTime = CType(strBDSJ, System.DateTime)
                If objBDSJ < Now.AddDays(-100) Then
                    strErrMsg = "错误：[" + strBDSJ + "]超过[100]天，这些数据不能再调整！"
                    GoTo errProc
                End If
                'zengxianglin 2009-05-14

                intStep = 1
                '检查
                Dim intSelect As Integer = 0
                Dim intColIndex As Integer
                Dim intRows As Integer
                Dim i As Integer
                If Me.grdRY.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选择[离岗人员]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-12-06
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM)
                Dim strLGRY As String = ""
                strLGRY = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                'zengxianglin 2008-12-06
                If Me.txtSXSJ.Text.Trim = "" Then
                    strErrMsg = "错误：未输入[离岗时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtSXSJ.Text) = False Then
                    strErrMsg = "错误：无效的[离岗时间]！"
                    GoTo errProc
                End If
                Me.txtSXSJ.Text = CType(Me.txtSXSJ.Text, System.DateTime).ToString("yyyy-MM-dd")
                If Me.ddlYDYY.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选择[变动原因]！"
                    GoTo errProc
                End If
                If Me.rblBDLX.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选择[变动类型]！"
                    GoTo errProc
                End If
                If CType(Me.txtSXSJ.Text, System.DateTime) <= CType(Me.txtKSSJ.Text, System.DateTime) Then
                    strErrMsg = "错误：[离岗时间]<=[生效时间]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-10-14
                '检查[变动时间]是否与[直接下属]的[生效时间]冲突！
                '检查[上级领导]不能设为自己！
                Dim strKSSJ As String = ""
                Dim strSJLD As String = ""
                Dim strRYDM As String = ""
                Dim strRYMC As String = ""
                With Me.m_objDataSet_XJ.Tables(strTable)
                    intRows = .DefaultView.Count
                    For i = 0 To intRows - 1 Step 1
                        strKSSJ = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ), "", "yyyy-MM-dd")
                        strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM), "")
                        strSJLD = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD), "")
                        strRYMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC), "")
                        If CType(Me.txtSXSJ.Text, System.DateTime) <= CType(strKSSJ, System.DateTime) Then
                            strErrMsg = "错误：直接下属人员[" + strRYMC + "]的[生效时间]>=[变动时间]！"
                            GoTo errProc
                        End If
                        If strRYDM = strSJLD Then
                            strErrMsg = "错误：直接下属人员[" + strRYMC + "]的[上级领导]不能设为自己！"
                            GoTo errProc
                        End If
                        'zengxianglin 2008-12-06
                        Select Case Me.rblBDLX.SelectedIndex
                            Case 0, 1
                                If strSJLD = strLGRY Then
                                    strErrMsg = "错误：直接下属人员[" + strRYMC + "]的[上级领导]还没有调整！"
                                    GoTo errProc
                                End If
                        End Select
                        'zengxianglin 2008-12-06
                    Next
                End With
                'zengxianglin 2008-10-14

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定所有内容(包括下属的上级领导)填写正确吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取数据集
                    If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                        GoTo errProc
                    End If

                    '定位记录
                    With Me.grdRY
                        intColIndex = objDataGridProcess.getRecordPosition(.SelectedIndex, .CurrentPageIndex, .PageSize)
                    End With
                    Dim objMainInfo As System.Data.DataRow = Nothing
                    With Me.m_objDataSet_RY.Tables(strTable)
                        objMainInfo = .DefaultView.Item(intColIndex).Row
                    End With
                    If objMainInfo Is Nothing Then
                        strErrMsg = "错误：人员不存在！"
                        GoTo errProc
                    End If

                    '获取人员信息
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                    strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)

                    '准备接口参数
                    objEnvInfo = New System.Collections.Specialized.NameValueCollection
                    objEnvInfo.Add("BDLX", Me.rblBDLX.SelectedIndex.ToString)
                    objEnvInfo.Add("BDSJ", Me.txtSXSJ.Text)
                    objEnvInfo.Add("BDYY", Me.ddlYDYY.SelectedItem.Value)
                    objEnvInfo.Add("BDYYMC", Me.ddlYDYY.SelectedItem.Text.Split("|".ToCharArray)(1))

                    '相应处理
                    If objsystemEstateRenshiXingye.doDelete_RenyuanJiagou( _
                        strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                        objEnvInfo, objMainInfo, Me.m_objDataSet_XJ) = False Then
                        GoTo errProc
                    End If

                    '记录日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]对[" + strRYMC + "]进行了[人事调整]！")

                    '刷新显示
                    If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_RY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    '强制显示新数据
                    If Me.getModuleData_XJ(strErrMsg, "", True) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_XJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objEnvInfo)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objEnvInfo)
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
