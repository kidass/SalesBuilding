Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_grll_info
    ' 
    ' 调用性质：
    '     可备调用，也可调用其他模块
    '
    ' 功能描述： 
    '   　“个人履历”处理模块
    ' 更改记录：
    '     zengxianglin 2009-05-15 更改
    '----------------------------------------------------------------

    Partial Class estate_rs_grll_info
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
        '应用根相对filecache的相对路径
        Private m_cstrPathRootToCache As String = "temp/filecache/"
        '应用根相对ziyuan/image/rskp的相对路径
        Private m_cstrPathRootToGrllImage As String = "ziyuan/image/grll/"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_grll_previlege_param"
        Private m_blnPrevilegeParams(5) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsGrllInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsGrllInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdXXJL相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdXXJL As String = "chkXXJL"
        Private Const m_cstrDataGridInDIV_grdXXJL As String = "divXXJL"
        Private m_intFixedColumns_grdXXJL As Integer
        Private Const m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXLX As String = "ddlXXJL_XXLX"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_KSSJ As String = "txtXXJL_KSSJ"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_JSSJ As String = "txtXXJL_JSSJ"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXYX As String = "txtXXJL_XXYX"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXZY As String = "txtXXJL_XXZY"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXJG As String = "ddlXXJL_XXJG"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_chkXXJL_XWZ As String = "chkXXJL_XWZ"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_chkXXJL_XLZ As String = "chkXXJL_XLZ"

        '----------------------------------------------------------------
        '与数据网格grdGZJL相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGZJL As String = "chkGZJL"
        Private Const m_cstrDataGridInDIV_grdGZJL As String = "divGZJL"
        Private m_intFixedColumns_grdGZJL As Integer
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_KSSJ As String = "txtGZJL_KSSJ"
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_JSSJ As String = "txtGZJL_JSSJ"
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_FWDW As String = "txtGZJL_FWDW"
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_DRZW As String = "txtGZJL_DRZW"
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_YX As String = "txtGZJL_YX"
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_LZYY As String = "txtGZJL_LZYY"
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_ZMR As String = "txtGZJL_ZMR"
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_DH As String = "txtGZJL_DH"

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_MAIN As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_XXJL As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_GZJL As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '其他参数
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_blnEditMode As Boolean
        Private m_blnCanEdit As Boolean
        Private m_strRYDM As String

        Public ReadOnly Property propTPWZ() As String
            Get
                Try
                    If Me.htxtUploadFile.Value.Trim <> "" Then
                        propTPWZ = Request.ApplicationPath + "/" + Me.htxtUploadFile.Value.Trim
                    Else
                        propTPWZ = Request.ApplicationPath + "/" + Me.htxtRYXP.Value.Trim
                    End If
                Catch ex As Exception
                    propTPWZ = ""
                End Try
            End Get
        End Property











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsGrllInfo)
                    Catch ex As Exception
                        Me.m_objInterface = Nothing
                    End Try
                Else
                    Me.m_objInterface = Nothing
                End If
                If Not (Me.m_objInterface Is Nothing) Then
                    '设置返回参数
                    Me.m_objInterface.oExitMode = False
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
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftMain.Value = .htxtDivLeftMain
                    Me.htxtDivTopMain.Value = .htxtDivTopMain
                    Me.htxtDivLeftXXJL.Value = .htxtDivLeftXXJL
                    Me.htxtDivTopXXJL.Value = .htxtDivTopXXJL
                    Me.htxtDivLeftGZJL.Value = .htxtDivLeftGZJL
                    Me.htxtDivTopGZJL.Value = .htxtDivTopGZJL

                    Me.htxtSessionId_XXJL.Value = .htxtSessionId_XXJL
                    Try
                        Me.grdXXJL.PageSize = .grdXXJL_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXXJL.CurrentPageIndex = .grdXXJL_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXXJL.SelectedIndex = .grdXXJL_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtSessionId_GZJL.Value = .htxtSessionId_GZJL
                    Try
                        Me.grdGZJL.PageSize = .grdGZJL_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGZJL.CurrentPageIndex = .grdGZJL_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGZJL.SelectedIndex = .grdGZJL_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.ddlJSZC.SelectedIndex = .ddlJSZC_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlXL.SelectedIndex = .ddlXL_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlXW.SelectedIndex = .ddlXW_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlZYZG.SelectedIndex = .ddlZYZG_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlZZMM.SelectedIndex = .ddlZZMM_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.rblHYZK.SelectedIndex = .rblHYZK_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblRYXB.SelectedIndex = .rblRYXB_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSYZK.SelectedIndex = .rblSYZK_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblXZZDS.SelectedIndex = .rblXZZDS_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.chkHYZK.Checked = .chkHYZK_Checked
                    Me.chkYZGZ.Checked = .chkYZGZ_Checked

                    Me.htxtUploadFile.Value = .htxtUploadFile
                    Me.htxtRYXP.Value = .htxtRYXP
                    Me.htxtWYBS.Value = .htxtWYBS

                    Me.txtBYSJ.Text = .txtBYSJ
                    Me.txtBYYX.Text = .txtBYYX
                    Me.txtBYZY.Text = .txtBYZY
                    Me.txtCSNY.Text = .txtCSNY
                    Me.txtHJDZ.Text = .txtHJDZ
                    Me.txtJG.Text = .txtJG
                    Me.txtMZ.Text = .txtMZ
                    Me.txtRDSJ.Text = .txtRDSJ
                    Me.txtRYDM.Text = .txtRYDM
                    Me.txtRYXM.Text = .txtRYXM
                    Me.txtXZDZ.Text = .txtXZDZ
                    Me.txtZCQDSJ.Text = .txtZCQDSJ
                    Me.txtYWM.Text = .txtYWM
                    Me.txtSJHM.Text = .txtSJHM
                    Me.txtZZDH.Text = .txtZZDH
                    Me.txtSFZH.Text = .txtSFZH

                    Me.txtJLBH.Text = .txtJLBH
                    Me.txtTBRQ.Text = .txtTBRQ
                    Me.txtYPZW.Text = .txtYPZW
                    Me.txtXJYQ.Text = .txtXJYQ
                    Me.txtSG.Text = .txtSG
                    Me.txtTZ.Text = .txtTZ
                    Me.txtGRJJ.Text = .txtGRJJ

                    'zengxianglin 2009-05-15
                    Me.txtXCYJ.Text = .txtXCYJ
                    Me.txtNYBM.Text = .txtNYBM
                    Me.txtDJSJ.Text = .txtDJSJ
                    Me.txtDJBM.Text = .txtDJBM
                    Me.txtDJRY.Text = .txtDJRY
                    Me.htxtDJRY.Value = .htxtDJRY
                    Me.htxtDJBM.Value = .htxtDJBM
                    Me.htxtNYBM.Value = .htxtNYBM
                    'zengxianglin 2009-05-15
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsGrllInfo

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftXXJL = Me.htxtDivLeftXXJL.Value
                    .htxtDivTopXXJL = Me.htxtDivTopXXJL.Value
                    .htxtDivLeftGZJL = Me.htxtDivLeftGZJL.Value
                    .htxtDivTopGZJL = Me.htxtDivTopGZJL.Value

                    .htxtSessionId_XXJL = Me.htxtSessionId_XXJL.Value
                    .grdXXJL_PageSize = Me.grdXXJL.PageSize
                    .grdXXJL_CurrentPageIndex = Me.grdXXJL.CurrentPageIndex
                    .grdXXJL_SelectedIndex = Me.grdXXJL.SelectedIndex

                    .htxtSessionId_GZJL = Me.htxtSessionId_GZJL.Value
                    .grdGZJL_PageSize = Me.grdGZJL.PageSize
                    .grdGZJL_CurrentPageIndex = Me.grdGZJL.CurrentPageIndex
                    .grdGZJL_SelectedIndex = Me.grdGZJL.SelectedIndex

                    .ddlJSZC_SelectedIndex = Me.ddlJSZC.SelectedIndex
                    .ddlXL_SelectedIndex = Me.ddlXL.SelectedIndex
                    .ddlXW_SelectedIndex = Me.ddlXW.SelectedIndex
                    .ddlZYZG_SelectedIndex = Me.ddlZYZG.SelectedIndex
                    .ddlZZMM_SelectedIndex = Me.ddlZZMM.SelectedIndex

                    .rblHYZK_SelectedIndex = Me.rblHYZK.SelectedIndex
                    .rblRYXB_SelectedIndex = Me.rblRYXB.SelectedIndex
                    .rblSYZK_SelectedIndex = Me.rblSYZK.SelectedIndex
                    .rblXZZDS_SelectedIndex = Me.rblXZZDS.SelectedIndex

                    .chkHYZK_Checked = Me.chkHYZK.Checked
                    .chkYZGZ_Checked = Me.chkYZGZ.Checked

                    .htxtUploadFile = Me.htxtUploadFile.Value
                    .htxtRYXP = Me.htxtRYXP.Value
                    .htxtWYBS = Me.htxtWYBS.Value

                    .txtBYSJ = Me.txtBYSJ.Text
                    .txtBYYX = Me.txtBYYX.Text
                    .txtBYZY = Me.txtBYZY.Text
                    .txtCSNY = Me.txtCSNY.Text
                    .txtHJDZ = Me.txtHJDZ.Text
                    .txtJG = Me.txtJG.Text
                    .txtMZ = Me.txtMZ.Text
                    .txtRDSJ = Me.txtRDSJ.Text
                    .txtRYDM = Me.txtRYDM.Text
                    .txtRYXM = Me.txtRYXM.Text
                    .txtXZDZ = Me.txtXZDZ.Text

                    .txtYWM = Me.txtYWM.Text
                    .txtSJHM = Me.txtSJHM.Text
                    .txtZZDH = Me.txtZZDH.Text
                    .txtSFZH = Me.txtSFZH.Text

                    .txtJLBH = Me.txtJLBH.Text
                    .txtTBRQ = Me.txtTBRQ.Text
                    .txtYPZW = Me.txtYPZW.Text
                    .txtXJYQ = Me.txtXJYQ.Text
                    .txtSG = Me.txtSG.Text
                    .txtTZ = Me.txtTZ.Text
                    .txtGRJJ = Me.txtGRJJ.Text

                    'zengxianglin 2009-05-15
                    .txtXCYJ = Me.txtXCYJ.Text
                    .txtNYBM = Me.txtNYBM.Text
                    .txtDJSJ = Me.txtDJSJ.Text
                    .txtDJBM = Me.txtDJBM.Text
                    .txtDJRY = Me.txtDJRY.Text
                    .htxtDJRY = Me.htxtDJRY.Value
                    .htxtDJBM = Me.htxtDJBM.Value
                    .htxtNYBM = Me.htxtNYBM.Value
                    'zengxianglin 2009-05-15
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

                'zengxianglin 2009-05-15
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
                            Case "btnSelectNYBM".ToUpper
                                Me.txtNYBM.Text = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtNYBM.Text, Me.htxtNYBM.Value) = False Then
                                    Me.htxtNYBM.Value = ""
                                    Me.txtNYBM.Text = ""
                                End If
                            Case "btnSelectDJBM".ToUpper
                                Me.txtDJBM.Text = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtDJBM.Text, Me.htxtDJBM.Value) = False Then
                                    Me.htxtDJBM.Value = ""
                                    Me.txtDJBM.Text = ""
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
                    Exit Try
                End If
                'zengxianglin 2009-05-15

                'zengxianglin 2009-05-15
                '==========================================================================================================================================================
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Try
                    objIDmxzZzry = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzry)
                Catch ex As Exception
                    objIDmxzZzry = Nothing
                End Try
                If Not (objIDmxzZzry Is Nothing) Then
                    If objIDmxzZzry.oExitMode = True Then
                        Select Case objIDmxzZzry.iSourceControlId.ToUpper
                            Case "btnSelectDJRY".ToUpper
                                Me.txtDJRY.Text = objIDmxzZzry.oRenyuanList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtDJRY.Text, Me.htxtDJRY.Value) = False Then
                                    Me.htxtDJRY.Value = ""
                                    Me.txtDJRY.Text = ""
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzry.SafeRelease(objIDmxzZzry)
                    Exit Try
                End If
                'zengxianglin 2009-05-15
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsGrllInfo)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    Me.m_strRYDM = ""
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_objenumEditType = Me.m_objInterface.iMode
                    Me.m_strRYDM = Me.m_objInterface.iRYDM
                End If
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_blnEditMode = True
                    Case Else
                        Me.m_blnEditMode = False
                End Select
                Me.m_blnCanEdit = Me.m_blnPrevilegeParams(1) Or Me.m_blnPrevilegeParams(3) Or Me.m_blnPrevilegeParams(4)

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsGrllInfo)
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
                Me.m_intFixedColumns_grdXXJL = objPulicParameters.getObjectValue(Me.htxtXXJLFixed.Value, 0)
                Me.m_intFixedColumns_grdGZJL = objPulicParameters.getObjectValue(Me.htxtGZJLFixed.Value, 0)
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
        Private Function doDeleteTempFiles(ByRef strErrMsg As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doDeleteTempFiles = False
            strErrMsg = ""

            Try
                '没有缓存
                If Me.htxtUploadFile.Value.Trim = "" Then
                    Exit Try
                End If

                '清除
                Dim strFileSpec As String = ""
                strFileSpec = Server.MapPath(Request.ApplicationPath + "/" + Me.htxtUploadFile.Value)
                If objBaseLocalFile.doDeleteFile(strErrMsg, strFileSpec) = False Then
                    GoTo errProc
                End If

                '复原
                Me.htxtUploadFile.Value = ""
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doDeleteTempFiles = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Dim strErrMsg As String = ""

            Try
                Dim objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
                If Me.htxtSessionId_XXJL.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_XXJL.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_XXJL.Value)
                    Me.htxtSessionId_XXJL.Value = ""
                End If
                If Me.htxtSessionId_GZJL.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GZJL.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GZJL.Value)
                    Me.htxtSessionId_GZJL.Value = ""
                End If

                '清除缓存文件
                If Me.doDeleteTempFiles(strErrMsg) = False Then
                    '忽略
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub









        '----------------------------------------------------------------
        ' 获取要显示的主数据信息
        '     strErrMsg      ：返回错误信息
        '     strRYDM        ：人员代码
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_MAIN( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye

            getModuleData_MAIN = False

            Try
                '检查
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_MAIN)

                '重新检索数据
                Dim strWhere As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RYDM + " = '" + strRYDM + "'"
                If objsystemEstateRenshiXingye.getDataSet_GRLL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_MAIN) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)

            getModuleData_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdXXJL要显示的数据
        '     strErrMsg      ：返回错误信息
        '     strRYDM        ：人员代码
        '     strWhere       ：搜索字符串
        '     blnEditMode    ：True-编辑 False-查看
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_XXJL( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_XUEXIJINGLI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_XXJL = False

            Try
                '检查
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取数据
                If blnEditMode = True Then
                    If Me.htxtSessionId_XXJL.Value.Trim <> "" Then
                        '从缓存中获取数据
                        Me.m_objDataSet_XXJL = CType(Session.Item(Me.htxtSessionId_XXJL.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Else
                        '释放资源
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_XXJL)
                        '重新检索数据
                        If objsystemEstateRenshiXingye.getDataSet_GRLL_XXJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_XXJL) = False Then
                            GoTo errProc
                        End If
                        '缓存数据
                        Me.htxtSessionId_XXJL.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_XXJL.Value, Me.m_objDataSet_XXJL)
                    End If
                Else
                    '释放缓存数据
                    If Me.htxtSessionId_XXJL.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_XXJL = CType(Session.Item(Me.htxtSessionId_XXJL.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Catch ex As Exception
                            Me.m_objDataSet_XXJL = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_XXJL)
                        Session.Remove(Me.htxtSessionId_XXJL.Value)
                        Me.htxtSessionId_XXJL.Value = ""
                    End If
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_XXJL)
                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_GRLL_XXJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_XXJL) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_XXJL = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdGZJL要显示的数据
        '     strErrMsg      ：返回错误信息
        '     strRYDM        ：人员代码
        '     strWhere       ：搜索字符串
        '     blnEditMode    ：True-编辑 False-查看
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_GZJL( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GONGZUOJINGLI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_GZJL = False

            Try
                '检查
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取数据
                If blnEditMode = True Then
                    If Me.htxtSessionId_GZJL.Value.Trim <> "" Then
                        '从缓存中获取数据
                        Me.m_objDataSet_GZJL = CType(Session.Item(Me.htxtSessionId_GZJL.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Else
                        '释放资源
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GZJL)
                        '重新检索数据
                        If objsystemEstateRenshiXingye.getDataSet_GRLL_GZJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_GZJL) = False Then
                            GoTo errProc
                        End If
                        '缓存数据
                        Me.htxtSessionId_GZJL.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_GZJL.Value, Me.m_objDataSet_GZJL)
                    End If
                Else
                    '释放缓存数据
                    If Me.htxtSessionId_GZJL.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_GZJL = CType(Session.Item(Me.htxtSessionId_GZJL.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Catch ex As Exception
                            Me.m_objDataSet_GZJL = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GZJL)
                        Session.Remove(Me.htxtSessionId_GZJL.Value)
                        Me.htxtSessionId_GZJL.Value = ""
                    End If
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GZJL)
                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_GRLL_GZJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_GZJL) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_GZJL = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' 显示grdXXJL的数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_XXJL( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_XUEXIJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_XXJL = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_XXJL Is Nothing Then
                    Me.grdXXJL.DataSource = Nothing
                Else
                    With Me.m_objDataSet_XXJL.Tables(strTable)
                        Me.grdXXJL.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_XXJL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdXXJL, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdXXJL.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdXXJL, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXXJL) = False Then
                    GoTo errProc
                End If

                '显示其他未绑定内容
                If Me.showDataGridUnboundInfo_XXJL(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_XXJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdGZJL的数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GZJL( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GONGZUOJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GZJL = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_GZJL Is Nothing Then
                    Me.grdGZJL.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GZJL.Tables(strTable)
                        Me.grdGZJL.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_GZJL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGZJL, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdGZJL.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGZJL, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGZJL) = False Then
                    GoTo errProc
                End If

                '显示其他未绑定数据
                If Me.showDataGridUnboundInfo_GZJL(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GZJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdXXJL中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改说明：
        '     zengxianglin 2009-01-12 修改
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_XXJL( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_XUEXIJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_XXJL = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objCheckBox As System.Web.UI.WebControls.CheckBox = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdXXJL.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdXXJL.CurrentPageIndex, Me.grdXXJL.PageSize)
                    objDataRow = Me.m_objDataSet_XXJL.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充ddlXXJL_XXLX
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXLX), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        objControlProcess.doTranslateKey(objDropDownList)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_XXLX), "")
                        If strValue = "" Then
                            objDropDownList.SelectedIndex = -1
                        Else
                            objDropDownList.SelectedIndex = objDropDownListProcess.getSelectedItem(objDropDownList, strValue)
                        End If
                        objControlProcess.doEnabledControl(objDropDownList, blnEditMode)
                    End If

                    '填充txtXXJL_KSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_KSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        'zengxianglin 2009-01-12
                        'strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_KSNY), "")
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_KSNY), "", "yyyy-MM-dd")
                        'zengxianglin 2009-01-12
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtXXJL_JSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_JSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        'zengxianglin 2009-01-12
                        'strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_ZZNY), "")
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_ZZNY), "", "yyyy-MM-dd")
                        'zengxianglin 2009-01-12
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtXXJL_XXYX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXYX), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_XXYX), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtXXJL_XXZY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXZY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_XXZY), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充ddlXXJL_XXJG
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXJG), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        objControlProcess.doTranslateKey(objDropDownList)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_XXJG), "")
                        If strValue = "" Then
                            objDropDownList.SelectedIndex = -1
                        Else
                            objDropDownList.SelectedIndex = objDropDownListProcess.getSelectedItem(objDropDownList, strValue)
                        End If
                        objControlProcess.doEnabledControl(objDropDownList, blnEditMode)
                    End If

                    '填充chkXXJL_XWZ
                    objCheckBox = Nothing
                    objCheckBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_chkXXJL_XWZ), System.Web.UI.WebControls.CheckBox)
                    If Not (objCheckBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_YXWZ), "0")
                        Select Case strValue
                            Case "1"
                                objCheckBox.Checked = True
                            Case Else
                                objCheckBox.Checked = False
                        End Select
                        objControlProcess.doEnabledControl(objCheckBox, blnEditMode)
                    End If

                    '填充chkXXJL_XLZ
                    objCheckBox = Nothing
                    objCheckBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_chkXXJL_XLZ), System.Web.UI.WebControls.CheckBox)
                    If Not (objCheckBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_YXLZ), "0")
                        Select Case strValue
                            Case "1"
                                objCheckBox.Checked = True
                            Case Else
                                objCheckBox.Checked = False
                        End Select
                        objControlProcess.doEnabledControl(objCheckBox, blnEditMode)
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_XXJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdGZJL中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_GZJL( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GONGZUOJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_GZJL = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGZJL.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGZJL.CurrentPageIndex, Me.grdGZJL.PageSize)
                    objDataRow = Me.m_objDataSet_GZJL.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充txtGZJL_KSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_KSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_KSNY), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtGZJL_JSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_JSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_ZZNY), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtGZJL_FWDW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_FWDW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_FWDW), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtGZJL_DRZW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_DRZW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_DRZW), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtGZJL_YX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_YX), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_YX), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtGZJL_LZYY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_LZYY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_LZYY), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtGZJL_ZMR
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_ZMR), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_ZMR), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtGZJL_DH
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_DH), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_DH), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_GZJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存grdXXJL中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改说明：
        '     zengxianglin 2009-01-12 修改
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_XXJL( _
            ByRef strErrMsg As String, _
            ByVal blnValid As Boolean, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_XUEXIJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_XXJL = False
            strErrMsg = ""

            Try
                '查看模式：不用保存
                If blnEditMode = False Then
                    Exit Try
                End If

                '保存未绑定数据
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objCheckBox As System.Web.UI.WebControls.CheckBox = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdXXJL.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdXXJL.CurrentPageIndex, Me.grdXXJL.PageSize)
                    objDataRow = Me.m_objDataSet_XXJL.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存ddlXXJL_XXLX
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXLX), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        If objDropDownList.SelectedIndex >= 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_XXLX) = objDropDownList.SelectedValue
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_XXLX) = ""
                        End If
                    End If

                    '保存txtXXJL_KSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_KSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        'zengxianglin 2009-01-12
                        If blnValid = True Then
                            If objTextBox.Text.Trim = "" Then
                                strErrMsg = "错误：[" + objTextBox.Text + "]是无效的日期！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(objTextBox.Text) = False Then
                                strErrMsg = "错误：[" + objTextBox.Text + "]是无效的日期！"
                                GoTo errProc
                            End If
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_KSNY) = CType(objTextBox.Text.Trim, System.DateTime)
                        Else
                            If objTextBox.Text.Trim = "" Then
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_KSNY) = System.DBNull.Value
                            ElseIf objPulicParameters.isDatetimeString(objTextBox.Text) = False Then
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_KSNY) = System.DBNull.Value
                            Else
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_KSNY) = CType(objTextBox.Text.Trim, System.DateTime)
                            End If
                        End If
                        'zengxianglin 2009-01-12
                    End If

                    '保存txtXXJL_JSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_JSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        'zengxianglin 2009-01-12
                        If blnValid = True Then
                            If objTextBox.Text.Trim = "" Then
                                strErrMsg = "错误：[" + objTextBox.Text + "]是无效的日期！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(objTextBox.Text) = False Then
                                strErrMsg = "错误：[" + objTextBox.Text + "]是无效的日期！"
                                GoTo errProc
                            End If
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_ZZNY) = CType(objTextBox.Text.Trim, System.DateTime)
                        Else
                            If objTextBox.Text.Trim = "" Then
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_ZZNY) = System.DBNull.Value
                            ElseIf objPulicParameters.isDatetimeString(objTextBox.Text) = False Then
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_ZZNY) = System.DBNull.Value
                            Else
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_ZZNY) = CType(objTextBox.Text.Trim, System.DateTime)
                            End If
                        End If
                        'zengxianglin 2009-01-12
                    End If

                    '保存txtXXJL_XXYX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXYX), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_XXYX) = objTextBox.Text.Trim
                    End If

                    '保存txtXXJL_XXZY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXZY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_XXZY) = objTextBox.Text.Trim
                    End If

                    '保存ddlXXJL_XXJG
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXJG), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        If objDropDownList.SelectedIndex >= 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_XXJG) = objDropDownList.SelectedValue
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_XXJG) = ""
                        End If
                    End If

                    '保存chkXXJL_XWZ
                    objCheckBox = Nothing
                    objCheckBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_chkXXJL_XWZ), System.Web.UI.WebControls.CheckBox)
                    If Not (objCheckBox Is Nothing) Then
                        If objCheckBox.Checked = True Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_YXWZ) = 1
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_YXWZ) = 0
                        End If
                    End If

                    '保存chkXXJL_XLZ
                    objCheckBox = Nothing
                    objCheckBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_chkXXJL_XLZ), System.Web.UI.WebControls.CheckBox)
                    If Not (objCheckBox Is Nothing) Then
                        If objCheckBox.Checked = True Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_YXLZ) = 1
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_XUEXIJINGLI_YXLZ) = 0
                        End If
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_XXJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存grdGZJL中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_GZJL( _
            ByRef strErrMsg As String, _
            ByVal blnValid As Boolean, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GONGZUOJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_GZJL = False
            strErrMsg = ""

            Try
                '查看模式：不用保存
                If blnEditMode = False Then
                    Exit Try
                End If

                '保存未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGZJL.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGZJL.CurrentPageIndex, Me.grdGZJL.PageSize)
                    objDataRow = Me.m_objDataSet_GZJL.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存txtGZJL_KSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_KSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_KSNY) = objTextBox.Text.Trim
                    End If

                    '保存txtGZJL_JSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_JSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_ZZNY) = objTextBox.Text.Trim
                    End If

                    '保存txtGZJL_FWDW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_FWDW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_FWDW) = objTextBox.Text.Trim
                    End If

                    '保存txtGZJL_DRZW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_DRZW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_DRZW) = objTextBox.Text.Trim
                    End If

                    '保存txtGZJL_YX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_YX), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        'zengxianglin 2009-01-12
                        If blnValid = True Then
                            If objTextBox.Text.Trim = "" Then
                                objTextBox.Text = "0"
                            End If
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：[" + objTextBox.Text + "]是无效的数字！"
                                GoTo errProc
                            End If
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_YX) = CType(objTextBox.Text.Trim, Double)
                        Else
                            If objTextBox.Text.Trim = "" Then
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_YX) = 0
                            ElseIf objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_YX) = 0
                            Else
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_YX) = CType(objTextBox.Text.Trim, Double)
                            End If
                        End If
                        'zengxianglin 2009-01-12
                    End If

                    '保存txtGZJL_LZYY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_LZYY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_LZYY) = objTextBox.Text.Trim
                    End If

                    '保存txtGZJL_ZMR
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_ZMR), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_ZMR) = objTextBox.Text.Trim
                    End If

                    '保存txtGZJL_DH
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_DH), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GONGZUOJINGLI_DH) = objTextBox.Text.Trim
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_GZJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示模块主信息
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditPanel_MAIN( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanel_MAIN = False
            strErrMsg = ""

            Try
                '显示值
                Dim strValue As String = ""
                Dim intValue As Integer = 0
                If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                    '首次进入+没有现场恢复
                    With Me.m_objDataSet_MAIN.Tables(strTable)
                        If .Rows.Count < 1 Then
                            '设置空值
                            Me.ddlJSZC.SelectedIndex = -1
                            Me.ddlXL.SelectedIndex = -1
                            Me.ddlXW.SelectedIndex = -1
                            Me.ddlZYZG.SelectedIndex = -1
                            Me.ddlZZMM.SelectedIndex = -1

                            Me.rblHYZK.SelectedIndex = -1
                            Me.rblRYXB.SelectedIndex = -1
                            Me.rblSYZK.SelectedIndex = -1
                            Me.rblXZZDS.SelectedIndex = -1

                            Me.chkHYZK.Checked = False
                            Me.chkYZGZ.Checked = False

                            Me.htxtUploadFile.Value = ""
                            Me.htxtRYXP.Value = ""
                            Me.htxtWYBS.Value = ""

                            Me.txtBYSJ.Text = ""
                            Me.txtBYYX.Text = ""
                            Me.txtBYZY.Text = ""
                            Me.txtCSNY.Text = ""
                            Me.txtHJDZ.Text = ""
                            Me.txtJG.Text = ""
                            Me.txtMZ.Text = ""
                            Me.txtRDSJ.Text = ""
                            Me.txtRYDM.Text = ""
                            Me.txtRYXM.Text = ""
                            Me.txtXZDZ.Text = ""
                            Me.txtZCQDSJ.Text = ""
                            Me.txtYWM.Text = ""
                            Me.txtSJHM.Text = ""
                            Me.txtZZDH.Text = ""
                            Me.txtSFZH.Text = ""

                            Me.txtJLBH.Text = ""
                            Me.txtTBRQ.Text = ""
                            Me.txtYPZW.Text = ""
                            Me.txtXJYQ.Text = ""
                            Me.txtSG.Text = ""
                            Me.txtTZ.Text = ""
                            Me.txtGRJJ.Text = ""

                            'zengxianglin 2009-05-15
                            Me.htxtNYBM.Value = ""
                            Me.txtNYBM.Text = ""
                            Me.htxtDJRY.Value = ""
                            Me.txtDJRY.Text = ""
                            Me.htxtDJBM.Value = ""
                            Me.txtDJBM.Text = ""
                            Me.txtDJSJ.Text = ""
                            Me.txtXCYJ.Text = ""
                            'zengxianglin 2009-05-15
                        Else
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JSZC), "")
                            Me.ddlJSZC.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJSZC, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZGXL), "")
                            Me.ddlXL.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlXL, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZGXW), "")
                            Me.ddlXW.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlXW, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZYZG), "")
                            Me.ddlZYZG.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZYZG, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZZMM), "")
                            Me.ddlZZMM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZZMM, strValue)

                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_SYQK), "")
                            Me.rblSYZK.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSYZK, strValue)
                            intValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_HYZK), 0)
                            Me.rblHYZK.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblHYZK, (intValue And 3).ToString)
                            Me.chkHYZK.Checked = (intValue And 4) = 4
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XB), "")
                            Me.rblRYXB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYXB, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JZDS), "")
                            Me.rblXZZDS.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblXZZDS, strValue)

                            Select Case objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_YZGZ), "")
                                Case "1"
                                    Me.chkYZGZ.Checked = True
                                Case Else
                                    Me.chkYZGZ.Checked = False
                            End Select

                            Me.htxtUploadFile.Value = ""
                            Me.htxtRYXP.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RYXP), "")
                            Me.htxtWYBS.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_WYBS), "")

                            Me.txtBYSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_BYSJ), "", "yyyy-MM-dd")
                            Me.txtBYYX.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_BYYX), "")
                            Me.txtBYZY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_BYZY), "")
                            Me.txtCSNY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_CSRQ), "", "yyyy-MM-dd")
                            Me.txtHJDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_HJDZ), "")
                            Me.txtJG.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JG), "")
                            Me.txtMZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_MZ), "")
                            Me.txtRDSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RDSJ), "", "yyyy-MM-dd")
                            Me.txtRYDM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RYDM), "")
                            Me.txtRYXM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XM), "")
                            Me.txtXZDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XZDZ), "")
                            Me.txtZCQDSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZCQDSJ), "", "yyyy-MM-dd")
                            Me.txtYWM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_YWXM), "")
                            Me.txtSJHM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_SJHM), "")
                            Me.txtZZDH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZZDH), "")
                            Me.txtSFZH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_SFZH), "")

                            Me.txtJLBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JLBH), "")
                            Me.txtTBRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_TBRQ), "", "yyyy-MM-dd")
                            Me.txtYPZW.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_YPZW), "")
                            Me.txtXJYQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XJYQ), "")
                            Me.txtSG.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_SG), "")
                            Me.txtTZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_TZ), "")
                            Me.txtGRJJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_GRJJ), "")

                            'zengxianglin 2009-05-15
                            Me.htxtNYBM.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_NYBM), "")
                            Me.txtNYBM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_NYBMMC), "")
                            Me.htxtDJRY.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_DJRY), "")
                            Me.txtDJRY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_DJRYMC), "")
                            Me.htxtDJBM.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_DJBM), "")
                            Me.txtDJBM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_DJBMMC), "")
                            Me.txtDJSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_DJSJ), "", "yyyy-MM-dd HH:mm:ss")
                            Me.txtXCYJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XCYJ), "")
                            'zengxianglin 2009-05-15
                        End If

                        '设初始值
                        Select Case Me.m_objenumEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                Me.txtTBRQ.Text = Now.ToString("yyyy-MM-dd")
                                'zengxianglin 2009-05-15
                                objsystemEstateRenshiXingye.getNewJLBH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtJLBH.Text)
                                Me.txtRYDM.Text = Me.txtJLBH.Text
                                Me.txtDJRY.Text = MyBase.UserXM
                                Me.htxtDJRY.Value = MyBase.UserId
                                Me.txtDJBM.Text = MyBase.UserBmmc
                                Me.htxtDJBM.Value = MyBase.UserBmdm
                                Me.txtDJSJ.Text = Now.ToString("yyyy-MM-dd HH:mm:ss")
                                Me.txtNYBM.Text = MyBase.UserBmmc
                                Me.htxtNYBM.Value = MyBase.UserBmdm
                                'zengxianglin 2009-05-15
                        End Select
                    End With
                End If

                '操作控制
                objControlProcess.doEnabledControl(Me.ddlJSZC, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlXL, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlXW, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlZYZG, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlZZMM, blnEditMode)

                objControlProcess.doEnabledControl(Me.rblHYZK, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblRYXB, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSYZK, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblXZZDS, blnEditMode)

                objControlProcess.doEnabledControl(Me.chkHYZK, blnEditMode)
                objControlProcess.doEnabledControl(Me.chkYZGZ, blnEditMode)

                objControlProcess.doEnabledControl(Me.txtBYSJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBYYX, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBYZY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtCSNY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtHJDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJG, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtMZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtRDSJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtRYDM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtRYXM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtXZDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZCQDSJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYWM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSJHM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZZDH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSFZH, blnEditMode)

                objControlProcess.doEnabledControl(Me.txtJLBH, False)
                objControlProcess.doEnabledControl(Me.txtTBRQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYPZW, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtXJYQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSG, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtTZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtGRJJ, blnEditMode)

                'zengxianglin 2009-05-15
                objControlProcess.doEnabledControl(Me.txtDJRY, False)
                objControlProcess.doEnabledControl(Me.txtDJBM, False)
                objControlProcess.doEnabledControl(Me.txtDJSJ, False)
                objControlProcess.doEnabledControl(Me.txtNYBM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtXCYJ, blnEditMode And Me.m_blnPrevilegeParams(4))
                Me.btnSelectDJBM.Visible = False
                Me.btnSelectDJRY.Visible = False
                Me.btnSelectNYBM.Visible = blnEditMode
                'zengxianglin 2009-05-15

                Me.btnAddNew_GZJL.Visible = blnEditMode
                Me.btnAddNew_XXJL.Visible = blnEditMode
                Me.btnDelete_GZJL.Visible = blnEditMode
                Me.btnDelete_XXJL.Visible = blnEditMode
                Me.lnkUpload.Visible = blnEditMode
                Me.filePicture.Visible = blnEditMode
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示模块其他信息
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            showModuleData_MAIN = False

            Try
                Me.btnOK.Visible = blnEditMode
                Me.btnCancel.Visible = blnEditMode
                Me.btnClose.Visible = Not blnEditMode
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
        ' 填充学历下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillXueliList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUELIHUAFEN
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillXueliList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillXueliList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemEstateRenshiGeneral.getDataSet_XueliHuafen(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLMC), "")

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
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillXueliList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充学位下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillXueweiList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEWEIHUAFEN
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillXueweiList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillXueweiList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemEstateRenshiGeneral.getDataSet_XueweiHuafen(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWMC), "")

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
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillXueweiList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充政治面貌下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillZzmmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_ZHENGZHIMIANMAO
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZzmmList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillZzmmList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemEstateRenshiGeneral.getDataSet_ZhengzhiMianmao(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMMC), "")

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
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillZzmmList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充执业资格下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillZyzgList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_ZHIYEZIGE
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZyzgList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillZyzgList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemEstateRenshiGeneral.getDataSet_ZhiyeZige(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGMC), "")

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
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillZyzgList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充技术职称下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillJszcList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JISHUZHICHENG
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillJszcList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillJszcList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemEstateRenshiGeneral.getDataSet_JishuZhicheng(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCMC), "")

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
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillJszcList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
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
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.ddlJSZC)
                    objControlProcess.doTranslateKey(Me.ddlXL)
                    objControlProcess.doTranslateKey(Me.ddlXW)
                    objControlProcess.doTranslateKey(Me.ddlZYZG)
                    objControlProcess.doTranslateKey(Me.ddlZZMM)
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.txtBYSJ)
                    objControlProcess.doTranslateKey(Me.txtBYYX)
                    objControlProcess.doTranslateKey(Me.txtBYZY)
                    objControlProcess.doTranslateKey(Me.txtCSNY)
                    objControlProcess.doTranslateKey(Me.txtHJDZ)
                    objControlProcess.doTranslateKey(Me.txtJG)
                    objControlProcess.doTranslateKey(Me.txtMZ)
                    objControlProcess.doTranslateKey(Me.txtRDSJ)
                    objControlProcess.doTranslateKey(Me.txtRYDM)
                    objControlProcess.doTranslateKey(Me.txtRYXM)
                    objControlProcess.doTranslateKey(Me.txtXZDZ)
                    objControlProcess.doTranslateKey(Me.txtZCQDSJ)
                    objControlProcess.doTranslateKey(Me.txtYWM)
                    objControlProcess.doTranslateKey(Me.txtSJHM)
                    objControlProcess.doTranslateKey(Me.txtZZDH)
                    objControlProcess.doTranslateKey(Me.txtSFZH)
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.txtJLBH)
                    objControlProcess.doTranslateKey(Me.txtTBRQ)
                    objControlProcess.doTranslateKey(Me.txtYPZW)
                    objControlProcess.doTranslateKey(Me.txtXJYQ)
                    objControlProcess.doTranslateKey(Me.txtSG)
                    objControlProcess.doTranslateKey(Me.txtTZ)
                    '====================================================================
                    'zengxianglin 2009-05-15
                    objControlProcess.doTranslateKey(Me.txtDJRY)
                    objControlProcess.doTranslateKey(Me.txtDJBM)
                    objControlProcess.doTranslateKey(Me.txtDJSJ)
                    objControlProcess.doTranslateKey(Me.txtNYBM)
                    'zengxianglin 2009-05-15

                    '显示Main
                    If Me.showModuleData_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_MAIN(strErrMsg, Me.m_strRYDM) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.getModuleData_XXJL(strErrMsg, Me.m_strRYDM, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_XXJL(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.getModuleData_GZJL(strErrMsg, Me.m_strRYDM, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_GZJL(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                Else
                    '获取缓存数据
                    If Me.getModuleData_XXJL(strErrMsg, Me.m_strRYDM, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_GZJL(strErrMsg, Me.m_strRYDM, "", Me.m_blnEditMode) = False Then
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
                    If Me.doFillJszcList(strErrMsg, Me.ddlJSZC) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillXueliList(strErrMsg, Me.ddlXL) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillXueweiList(strErrMsg, Me.ddlXW) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillZyzgList(strErrMsg, Me.ddlZYZG) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillZzmmList(strErrMsg, Me.ddlZZMM) = False Then
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
        Sub grdXXJL_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdXXJL.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdXXJL + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdXXJL > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdXXJL - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdXXJL.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGZJL_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGZJL.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGZJL + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGZJL > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdGZJL - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGZJL.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub









        Private Sub doSelectDJBM(ByVal strControlId As String)

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

        Private Sub doSelectNYBM(ByVal strControlId As String)

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

        Private Sub doSelectDJRY(ByVal strControlId As String)

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
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry = Nothing
                Dim strUrl As String = ""
                objIDmxzZzry = New Josco.JsKernal.BusinessFacade.IDmxzZzry
                With objIDmxzZzry
                    .iSelectBMMC = False
                    .iSelectFFFW = False
                    .iSelectMode = False
                    .iAllowInput = False
                    .iMultiSelect = False
                    .iAllowNull = True
                    .iRenyuanList = ""
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
                Session.Add(strNewSessionId, objIDmxzZzry)
                strUrl = ""
                strUrl += "../../dmxz/dmxz_zzry.aspx"
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

        Private Sub btnSelectDJBM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectDJBM.Click
            Me.doSelectDJBM("btnSelectDJBM")
        End Sub

        Private Sub btnSelectNYBM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectNYBM.Click
            Me.doSelectNYBM("btnSelectNYBM")
        End Sub

        Private Sub btnSelectDJRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectDJRY.Click
            Me.doSelectDJRY("btnSelectDJRY")
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
                        Me.m_objInterface.oExitMode = False
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

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    Me.m_objInterface.oExitMode = False
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

        Private Sub doDelete_XXJL(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_XUEXIJINGLI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '保存缓存数据
                If Me.saveDataGridUnboundInfo_XXJL(strErrMsg, False, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                '删除选定行
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdXXJL.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdXXJL.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdXXJL) = True Then
                        With Me.m_objDataSet_XXJL.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdXXJL.CurrentPageIndex, Me.grdXXJL.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next
                '重新显示
                If Me.showDataGridInfo_XXJL(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doDelete_GZJL(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GONGZUOJINGLI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '保存缓存数据
                If Me.saveDataGridUnboundInfo_GZJL(strErrMsg, False, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                '删除选定行
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGZJL.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdGZJL.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdGZJL) = True Then
                        With Me.m_objDataSet_GZJL.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGZJL.CurrentPageIndex, Me.grdGZJL.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next
                '重新显示
                If Me.showDataGridInfo_GZJL(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doAddNew_XXJL(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_XUEXIJINGLI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '保存缓存数据
                If Me.saveDataGridUnboundInfo_XXJL(strErrMsg, False, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                '加行
                With Me.m_objDataSet_XXJL.Tables(strTable)
                    .Rows.Add(.NewRow())
                End With
                '重新显示
                If Me.showDataGridInfo_XXJL(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doAddNew_GZJL(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GONGZUOJINGLI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '保存缓存数据
                If Me.saveDataGridUnboundInfo_GZJL(strErrMsg, False, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                '加行
                With Me.m_objDataSet_GZJL.Tables(strTable)
                    .Rows.Add(.NewRow())
                End With
                '重新显示
                If Me.showDataGridInfo_GZJL(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doUploadFile(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.filePicture.PostedFile Is Nothing Then
                    '没有上传文件
                    Exit Try
                End If
                If Me.filePicture.PostedFile.FileName Is Nothing Then
                    '没有上传文件
                    Exit Try
                End If
                If Me.filePicture.PostedFile.FileName.Trim = "" Then
                    '没有上传文件
                    Exit Try
                End If

                '清除缓存文件
                Dim strFileSpec As String = ""
                If Me.doDeleteTempFiles(strErrMsg) = False Then
                    '形成垃圾文件
                End If

                '保存上传文件到缓存目录
                Dim strHttpPath As String = ""
                Dim strFileName As String = ""
                strFileSpec = Me.filePicture.PostedFile.FileName
                If objBaseLocalFile.doCreateTempFile(strErrMsg, strFileSpec, True, strFileName) = False Then
                    GoTo errProc
                End If
                strHttpPath = Me.m_cstrPathRootToCache + strFileName
                strFileSpec = Server.MapPath(Request.ApplicationPath + "/" + strHttpPath)
                Me.filePicture.PostedFile.SaveAs(strFileSpec)
                Me.htxtUploadFile.Value = strHttpPath
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objNewData As New System.Collections.Specialized.NameValueCollection
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '保存缓存数据
                If Me.saveDataGridUnboundInfo_XXJL(strErrMsg, True, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                If Me.saveDataGridUnboundInfo_GZJL(strErrMsg, True, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                '上传文件
                Dim strBasePath As String = Me.m_cstrPathRootToGrllImage
                Dim strSrcLocFileSpec As String = ""
                Me.doUploadFile(strControlId)
                If Me.htxtUploadFile.Value.Trim <> "" Then
                    strSrcLocFileSpec = Server.MapPath(Request.ApplicationPath + "/" + Me.htxtUploadFile.Value)
                End If

                'zengxianglin 2009-05-15
                '设置默认数据
                Me.htxtDJRY.Value = MyBase.UserId
                Me.txtDJRY.Text = MyBase.UserXM
                Me.htxtDJBM.Value = MyBase.UserBmdm
                Me.txtDJBM.Text = MyBase.UserBmmc
                If Me.txtDJSJ.Text.Trim = "" Then
                    Me.txtDJSJ.Text = Now.ToString("yyyy-MM-dd HH:mm:ss")
                End If
                'zengxianglin 2009-05-15

                '准备接口数据
                objNewData.Clear()
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_WYBS, Me.htxtWYBS.Value.Trim)
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_BYSJ, Me.txtBYSJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_BYYX, Me.txtBYYX.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_BYZY, Me.txtBYZY.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_CSRQ, Me.txtCSNY.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_HJDZ, Me.txtHJDZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JG, Me.txtJG.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_MZ, Me.txtMZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RDSJ, Me.txtRDSJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RYDM, Me.txtRYDM.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XM, Me.txtRYXM.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XZDZ, Me.txtXZDZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZCQDSJ, Me.txtZCQDSJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_YWXM, Me.txtYWM.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_SJHM, Me.txtSJHM.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZZDH, Me.txtZZDH.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_SFZH, Me.txtSFZH.Text.Trim)
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JLBH, Me.txtJLBH.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_TBRQ, Me.txtTBRQ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_YPZW, Me.txtYPZW.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XJYQ, Me.txtXJYQ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_SG, Me.txtSG.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_TZ, Me.txtTZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_GRJJ, Me.txtGRJJ.Text.Trim)
                '********************************************************************************************************************
                'zengxianglin 2009-05-15
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_DJRY, Me.htxtDJRY.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_DJBM, Me.htxtDJBM.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_NYBM, Me.htxtNYBM.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_DJSJ, Me.txtDJSJ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XCYJ, Me.txtXCYJ.Text)
                'zengxianglin 2009-05-15
                '********************************************************************************************************************
                If Me.chkYZGZ.Checked = True Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_YZGZ, "1")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_YZGZ, "0")
                End If
                '********************************************************************************************************************
                Dim intValue As Integer = 0
                Select Case Me.rblHYZK.SelectedIndex
                    Case 0, 1
                        intValue = CType(Me.rblHYZK.SelectedValue, Integer)
                    Case Else
                End Select
                If Me.chkHYZK.Checked = True Then
                    intValue += 4
                End If
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_HYZK, intValue.ToString)
                '********************************************************************************************************************
                If Me.rblRYXB.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XB, Me.rblRYXB.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XB, "男")
                End If
                '********************************************************************************************************************
                If Me.rblXZZDS.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JZDS, Me.rblXZZDS.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JZDS, "")
                End If
                '********************************************************************************************************************
                If Me.ddlJSZC.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JSZC, Me.ddlJSZC.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JSZC, "")
                End If
                '********************************************************************************************************************
                If Me.ddlXL.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZGXL, Me.ddlXL.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZGXL, "")
                End If
                '********************************************************************************************************************
                If Me.ddlXW.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZGXW, Me.ddlXW.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZGXW, "")
                End If
                '********************************************************************************************************************
                If Me.ddlZYZG.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZYZG, Me.ddlZYZG.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZYZG, "")
                End If
                '********************************************************************************************************************
                If Me.ddlZZMM.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZZMM, Me.ddlZZMM.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZZMM, "")
                End If

                '保存数据
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_WYBS) = ""
                        'zengxianglin 2009-05-15
                        'objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JLBH) = ""
                        'zengxianglin 2009-05-15
                        If objsystemEstateRenshiXingye.doSaveData_GRLL(strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                            objNewData, Nothing, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                             strSrcLocFileSpec, Request.ApplicationPath, strBasePath, Server, _
                             Me.m_objDataSet_XXJL, _
                             Me.m_objDataSet_GZJL) = False Then
                            'zengxianglin 2009-05-15
                            Me.txtJLBH.Text = objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JLBH)
                            'zengxianglin 2009-05-15
                            GoTo errProc
                        End If
                    Case Else
                        '获取数据
                        If Me.getModuleData_MAIN(strErrMsg, Me.m_strRYDM) = False Then
                            GoTo errProc
                        End If
                        '保存数据
                        Dim objDataRow As System.Data.DataRow = Nothing
                        With Me.m_objDataSet_MAIN.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI)
                            If .Rows.Count < 1 Then
                                strErrMsg = "错误：要更改的数据不存在！"
                                GoTo errProc
                            End If
                            objDataRow = .Rows(0)
                            If objsystemEstateRenshiXingye.doSaveData_GRLL(strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                                objNewData, objDataRow, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, _
                                 strSrcLocFileSpec, Request.ApplicationPath, strBasePath, Server, _
                                 Me.m_objDataSet_XXJL, _
                                 Me.m_objDataSet_GZJL) = False Then
                                'zengxianglin 2009-05-15
                                Me.txtJLBH.Text = objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JLBH)
                                'zengxianglin 2009-05-15
                                GoTo errProc
                            End If
                        End With
                End Select

                '返回处理
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    Me.m_objInterface.oExitMode = False
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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub lnkUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkUpload.Click
            Me.doUploadFile("lnkUpload")
        End Sub

        Private Sub btnDelete_XXJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_XXJL.Click
            Me.doDelete_XXJL("btnDelete_XXJL")
        End Sub

        Private Sub btnDelete_GZJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GZJL.Click
            Me.doDelete_GZJL("btnDelete_GZJL")
        End Sub

        Private Sub btnAddNew_XXJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_XXJL.Click
            Me.doAddNew_XXJL("btnAddNew_XXJL")
        End Sub

        Private Sub btnAddNew_GZJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GZJL.Click
            Me.doAddNew_GZJL("btnAddNew_GZJL")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

    End Class

End Namespace
