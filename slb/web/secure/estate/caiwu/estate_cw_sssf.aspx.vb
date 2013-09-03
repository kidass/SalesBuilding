Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_cw_sssf
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　一般“实际收付款”处理模块
    '
    ' 更改记录：
    '     zengxianglin 2010-05-06 更改
    '----------------------------------------------------------------

    Partial Class estate_cw_sssf
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
        '打印模版相对于应用根的路径
        Private m_cstrExcelMBRelativePathToAppRoot As String = "/template/excel/"
        '打印文件缓存目录相对于应用根的路径
        Private m_cstrPrintCacheRelativePathToAppRoot As String = "/temp/printcache/"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_cw_sssf_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateCwSssf
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateCwSssf
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdSJSZ相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_SJSZ As String = "chkSJSZ"
        Private Const m_cstrDataGridInDIV_SJSZ As String = "divSJSZ"
        Private m_intFixedColumns_SJSZ As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_SJSZ As Josco.JSOA.Common.Data.estateCaiwuData
        Private m_strQuery_SJSZ As String
        Private m_intRows_SJSZ As Integer

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_intCurrentSelectIndex As Integer
        Private m_intCurrentPageIndex As Integer
        Private m_blnEditMode As Boolean

        '----------------------------------------------------------------
        '接口参数
        '----------------------------------------------------------------
        Private m_strOrgQRSH As String
        Private m_strQRSH As String

        Public ReadOnly Property propQRSH() As String
            Get
                propQRSH = Me.m_strOrgQRSH
            End Get
        End Property

        Public ReadOnly Property propEditMode() As Boolean
            Get
                propEditMode = Me.m_blnEditMode
            End Get
        End Property

        Public ReadOnly Property propUniQRSH() As String
            Get
                If Me.m_strOrgQRSH <> "" Then
                    propUniQRSH = Me.m_strOrgQRSH
                Else
                    propUniQRSH = Me.txtJYBH.Text
                End If
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateCwSssf)
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
                    Me.htxtDivLeftSJSZ.Value = .htxtDivLeftSJSZ
                    Me.htxtDivTopSJSZ.Value = .htxtDivTopSJSZ

                    Me.htxtCurrentPage.Value = .htxtCurrentPage
                    Me.htxtCurrentRow.Value = .htxtCurrentRow
                    Me.htxtEditMode.Value = .htxtEditMode
                    Me.htxtEditType.Value = .htxtEditType

                    Me.htxtSJSZQuery.Value = .htxtSJSZQuery
                    Me.htxtSJSZRows.Value = .htxtSJSZRows
                    Me.htxtSJSZSort.Value = .htxtSJSZSort
                    Me.htxtSJSZSortColumnIndex.Value = .htxtSJSZSortColumnIndex
                    Me.htxtSJSZSortType.Value = .htxtSJSZSortType

                    Me.txtSJSZSearch_PJHM.Text = .txtSJSZSearch_PJHM
                    Me.txtSJSZSearch_FSRQMax.Text = .txtSJSZSearch_FSRQMax
                    Me.txtSJSZSearch_FSRQMin.Text = .txtSJSZSearch_FSRQMin
                    Me.ddlSJSZSearch_SFDM.SelectedIndex = .ddlSJSZSearch_SFDM_SelectedIndex
                    Me.ddlSJSZSearch_SFBZ.SelectedIndex = .ddlSJSZSearch_SFBZ_SelectedIndex
                    Me.ddlSJSZSearch_SFDX.SelectedIndex = .ddlSJSZSearch_SFDX_SelectedIndex
                    Me.ddlSJSZSearch_SHBZ.SelectedIndex = .ddlSJSZSearch_SHBZ_SelectedIndex
                    Me.ddlSJSZSearch_SFSH.SelectedIndex = .ddlSJSZSearch_SFSH_SelectedIndex

                    Me.txtSJSZPageIndex.Text = .txtSJSZPageIndex
                    Me.txtSJSZPageSize.Text = .txtSJSZPageSize
                    Try
                        Me.grdSJSZ.PageSize = .grdSJSZPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSJSZ.CurrentPageIndex = .grdSJSZCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSJSZ.SelectedIndex = .grdSJSZSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSJSZSessionIdQuery.Value = .htxtSJSZSessionIdQuery

                    Me.ddlSFDM.SelectedIndex = .ddlSFDM_SelectedIndex
                    Me.rblSFBZ.SelectedIndex = .rblSFBZ_SelectedIndex
                    Me.rblSFDX.SelectedIndex = .rblSFDX_SelectedIndex
                    Me.txtFSJE.Text = .txtFSJE
                    Me.txtFSRQ.Text = .txtFSRQ
                    Me.htxtWYBS.Value = .htxtWYBS
                    Me.htxtQRSH.Value = .htxtQRSH
                    Me.htxtJHBS.Value = .htxtJHBS
                    Me.htxtCWSH.Value = .htxtCWSH
                    Me.htxtSHRQ.Value = .htxtSHRQ

                    Me.txtZYSM.Text = .txtZYSM
                    Me.txtKHMC.Text = .txtKHMC
                    Me.txtPJHM.Text = .txtPJHM
                    Me.txtJBRY.Text = .txtJBRY
                    Me.txtJBDW.Text = .txtJBDW
                    Me.htxtJBRY.Value = .htxtJBRY
                    Me.htxtJBDW.Value = .htxtJBDW

                    Me.txtJYBH.Text = .txtJYBH
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateCwSssf

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftSJSZ = Me.htxtDivLeftSJSZ.Value
                    .htxtDivTopSJSZ = Me.htxtDivTopSJSZ.Value

                    .htxtCurrentPage = Me.htxtCurrentPage.Value
                    .htxtCurrentRow = Me.htxtCurrentRow.Value
                    .htxtEditMode = Me.htxtEditMode.Value
                    .htxtEditType = Me.htxtEditType.Value

                    .htxtSJSZQuery = Me.htxtSJSZQuery.Value
                    .htxtSJSZRows = Me.htxtSJSZRows.Value
                    .htxtSJSZSort = Me.htxtSJSZSort.Value
                    .htxtSJSZSortColumnIndex = Me.htxtSJSZSortColumnIndex.Value
                    .htxtSJSZSortType = Me.htxtSJSZSortType.Value

                    .txtSJSZSearch_PJHM = Me.txtSJSZSearch_PJHM.Text
                    .txtSJSZSearch_FSRQMax = Me.txtSJSZSearch_FSRQMax.Text
                    .txtSJSZSearch_FSRQMin = Me.txtSJSZSearch_FSRQMin.Text
                    .ddlSJSZSearch_SFDM_SelectedIndex = Me.ddlSJSZSearch_SFDM.SelectedIndex
                    .ddlSJSZSearch_SFBZ_SelectedIndex = Me.ddlSJSZSearch_SFBZ.SelectedIndex
                    .ddlSJSZSearch_SFDX_SelectedIndex = Me.ddlSJSZSearch_SFDX.SelectedIndex
                    .ddlSJSZSearch_SHBZ_SelectedIndex = Me.ddlSJSZSearch_SHBZ.SelectedIndex
                    .ddlSJSZSearch_SFSH_SelectedIndex = Me.ddlSJSZSearch_SFSH.SelectedIndex

                    .txtSJSZPageIndex = Me.txtSJSZPageIndex.Text
                    .txtSJSZPageSize = Me.txtSJSZPageSize.Text
                    .grdSJSZPageSize = Me.grdSJSZ.PageSize
                    .grdSJSZCurrentPageIndex = Me.grdSJSZ.CurrentPageIndex
                    .grdSJSZSelectedIndex = Me.grdSJSZ.SelectedIndex
                    .htxtSJSZSessionIdQuery = Me.htxtSJSZSessionIdQuery.Value

                    .ddlSFDM_SelectedIndex = Me.ddlSFDM.SelectedIndex
                    .rblSFBZ_SelectedIndex = Me.rblSFBZ.SelectedIndex
                    .rblSFDX_SelectedIndex = Me.rblSFDX.SelectedIndex
                    .txtFSJE = Me.txtFSJE.Text
                    .txtFSRQ = Me.txtFSRQ.Text
                    .htxtWYBS = Me.htxtWYBS.Value
                    .htxtQRSH = Me.htxtQRSH.Value
                    .htxtJHBS = Me.htxtJHBS.Value
                    .htxtCWSH = Me.htxtCWSH.Value
                    .htxtSHRQ = Me.htxtSHRQ.Value

                    .txtZYSM = Me.txtZYSM.Text
                    .txtKHMC = Me.txtKHMC.Text
                    .txtPJHM = Me.txtPJHM.Text
                    .txtJBRY = Me.txtJBRY.Text
                    .txtJBDW = Me.txtJBDW.Text
                    .htxtJBRY = Me.htxtJBRY.Value
                    .htxtJBDW = Me.htxtJBDW.Value

                    .txtJYBH = Me.txtJYBH.Text
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

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                'zengxianglin 2008-11-18
                '==========================================================================================================================================================
                Dim objIEstateCwXzPiaoju As Josco.JSOA.BusinessFacade.IEstateCwXzPiaoju = Nothing
                Try
                    objIEstateCwXzPiaoju = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwXzPiaoju)
                Catch ex As Exception
                    objIEstateCwXzPiaoju = Nothing
                End Try
                If Not (objIEstateCwXzPiaoju Is Nothing) Then
                    If objIEstateCwXzPiaoju.oExitMode = True Then
                        Select Case objIEstateCwXzPiaoju.iSourceControlId.ToUpper
                            Case "btnSelect_PJHM".ToUpper
                                '填充信息
                                Dim strWYBS As String = objIEstateCwXzPiaoju.oWYBS
                                Dim strWhere As String = ""
                                Dim strValue As String = ""
                                Dim strJYBH As String = ""
                                Dim strSFDX As String = ""
                                If strWYBS = "" Then
                                    Me.txtPJHM.Text = ""
                                Else
                                    Dim objTempDataSet As Josco.JSOA.Common.Data.estateCaiwuData = Nothing
                                    strWhere = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS + " = '" + strWYBS + "'"
                                    If objsystemEstateCaiwu.getDataSet_PJSY(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objTempDataSet) = False Then
                                        Me.txtPJHM.Text = ""
                                    Else
                                        If objTempDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG) Is Nothing Then
                                            Me.txtPJHM.Text = ""
                                        Else
                                            If objTempDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG).Rows.Count < 1 Then
                                                Me.txtPJHM.Text = ""
                                            Else
                                                With objTempDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG).Rows(0)
                                                    Me.txtPJHM.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_PJHM), "")
                                                    Me.txtFSRQ.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_KPRQ), "", "yyyy-MM-dd")
                                                    Me.txtFSJE.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_KPJE), "", "#,##0.00", True)
                                                    Me.txtJBRY.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_JBRYMC), "")
                                                    Me.htxtJBRY.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_JBRY), "")
                                                    Me.txtZYSM.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_ZYSM), "")
                                                    strValue = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_SFDM), "")
                                                    Me.ddlSFDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSFDM, strValue)
                                                    strValue = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_SFDX), "")
                                                    Me.rblSFDX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFDX, strValue)
                                                    strJYBH = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_JYBH), "")
                                                    strSFDX = strValue
                                                    If objsystemEstateErshou.getKHMC(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJYBH, strSFDX, strValue) = False Then
                                                    Else
                                                        Me.txtKHMC.Text = strValue
                                                    End If
                                                    strValue = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_SFBZ), "")
                                                    Me.rblSFBZ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFBZ, strValue)
                                                    If Me.htxtJBRY.Value.Trim <> "" Then
                                                        Me.htxtJBDW.Value = ""
                                                        Me.txtJBDW.Text = ""
                                                        If objsystemCustomer.getZzmcByRymc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtJBRY.Text, strValue) = False Then
                                                        Else
                                                            Me.txtJBDW.Text = strValue
                                                            If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtJBDW.Text, strValue) = True Then
                                                                Me.htxtJBDW.Value = strValue
                                                            End If
                                                        End If
                                                    Else
                                                        Me.htxtJBDW.Value = ""
                                                        Me.txtJBDW.Text = ""
                                                    End If
                                                End With
                                            End If
                                        End If
                                    End If
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwXzPiaoju.SafeRelease(objIEstateCwXzPiaoju)
                    Exit Try
                End If
                'zengxianglin 2008-11-18

                '==========================================================================================================================================================
                Dim objIEstateCwSssfJz As Josco.JSOA.BusinessFacade.IEstateCwSssfJz = Nothing
                Try
                    objIEstateCwSssfJz = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwSssfJz)
                Catch ex As Exception
                    objIEstateCwSssfJz = Nothing
                End Try
                If Not (objIEstateCwSssfJz Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwSssfJz.SafeRelease(objIEstateCwSssfJz)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateCwSssfJh As Josco.JSOA.BusinessFacade.IEstateCwSssfJh = Nothing
                Try
                    objIEstateCwSssfJh = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwSssfJh)
                Catch ex As Exception
                    objIEstateCwSssfJh = Nothing
                End Try
                If Not (objIEstateCwSssfJh Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwSssfJh.SafeRelease(objIEstateCwSssfJh)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsXzJyxx As Josco.JSOA.BusinessFacade.IEstateEsXzJyxx = Nothing
                Try
                    objIEstateEsXzJyxx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsXzJyxx)
                Catch ex As Exception
                    objIEstateEsXzJyxx = Nothing
                End Try
                If Not (objIEstateEsXzJyxx Is Nothing) Then
                    If objIEstateEsXzJyxx.oExitMode = True Then
                        Select Case objIEstateEsXzJyxx.iSourceControlId.ToUpper
                            Case "btnSelect_JYBH".ToUpper
                                Me.txtJYBH.Text = objIEstateEsXzJyxx.oJYBH
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsXzJyxx.SafeRelease(objIEstateEsXzJyxx)
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
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper
                            Case "btnSelect_JBDW".ToUpper
                                Me.txtJBDW.Text = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtJBDW.Text, Me.htxtJBDW.Value) = False Then
                                    Me.htxtJBDW.Value = ""
                                End If
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
                        Select Case objIDmxzRyxx.iSourceControlId.ToUpper
                            Case "btnSelect_JBRY".ToUpper
                                Me.htxtJBRY.Value = objIDmxzRyxx.oRYDM
                                Me.txtJBRY.Text = objIDmxzRyxx.oRYZM
                                Me.htxtJBDW.Value = objIDmxzRyxx.oZZDM
                                Me.txtJBDW.Text = objIDmxzRyxx.oZZMC
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzRyxx.SafeRelease(objIDmxzRyxx)
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
                        Select Case objISjcxCxtj.iSourceControlId.ToUpper
                            Case "btnSJSZSearch_Full".ToUpper()
                                Me.htxtSJSZQuery.Value = objISjcxCxtj.oQueryString
                                If Me.htxtSJSZSessionIdQuery.Value.Trim = "" Then
                                    Me.htxtSJSZSessionIdQuery.Value = objPulicParameters.getNewGuid()
                                Else
                                    Try
                                        objQueryData = CType(Session(Me.htxtSJSZSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                                    Catch ex As Exception
                                        objQueryData = Nothing
                                    End Try
                                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                                End If
                                Session.Add(Me.htxtSJSZSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
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

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
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
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateCwSssf)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_strOrgQRSH = ""
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_strOrgQRSH = Me.m_objInterface.iQRSH
                End If
                If Me.m_strOrgQRSH <> "" Then
                    Dim blnIS As Boolean = False
                    If objsystemEstateErshou.isQrshExist(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strOrgQRSH, blnIS) = False Then
                        GoTo errProc
                    End If
                    If blnIS = False Then
                        Me.m_strOrgQRSH = ""
                    End If
                End If

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateCwSssf)
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

                '接口+输入合并
                If Me.m_strOrgQRSH <> "" Then
                    Me.m_strQRSH = Me.m_strOrgQRSH
                Else
                    Me.m_strQRSH = Me.txtJYBH.Text
                End If

                '是否处于编辑状态
                Me.m_blnEditMode = objPulicParameters.getObjectValue(Me.htxtEditMode.Value, False)
                '进入编辑模式前记录的页位置
                Me.m_intCurrentPageIndex = objPulicParameters.getObjectValue(Me.htxtCurrentPage.Value, 0)
                '进入编辑模式前记录的行位置
                Me.m_intCurrentSelectIndex = objPulicParameters.getObjectValue(Me.htxtCurrentRow.Value, -1)
                '当前编辑模式
                Dim intEditType As Integer
                intEditType = objPulicParameters.getObjectValue(Me.htxtEditType.Value, 0)
                Try
                    Me.m_objenumEditType = CType(intEditType, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType)
                Catch ex As Exception
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                End Try

                Me.m_strQuery_SJSZ = Me.htxtSJSZQuery.Value
                Me.m_intRows_SJSZ = objPulicParameters.getObjectValue(Me.htxtSJSZRows.Value, 0)
                Me.m_intFixedColumns_SJSZ = objPulicParameters.getObjectValue(Me.htxtSJSZFixed.Value, 0)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getInterfaceParameters = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                If Me.htxtSJSZSessionIdQuery.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtSJSZSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSJSZSessionIdQuery.Value)
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
        Private Function getQueryString_SJSZ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_SJSZ = False
            strQuery = ""

            Try
                '按“票据号码”搜索
                Dim strPJHM As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM
                If Me.txtSJSZSearch_PJHM.Text.Length > 0 Then Me.txtSJSZSearch_PJHM.Text = Me.txtSJSZSearch_PJHM.Text.Trim()
                If Me.txtSJSZSearch_PJHM.Text <> "" Then
                    Me.txtSJSZSearch_PJHM.Text = objPulicParameters.getNewSearchString(Me.txtSJSZSearch_PJHM.Text)
                    If strQuery = "" Then
                        strQuery = strPJHM + " like '" + Me.txtSJSZSearch_PJHM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strPJHM + " like '" + Me.txtSJSZSearch_PJHM.Text + "%'"
                    End If
                End If

                '按“审过”搜索
                Dim strSHBZ As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC
                Select Case Me.ddlSJSZSearch_SHBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSHBZ + " = '" + Me.ddlSJSZSearch_SHBZ.SelectedItem.Text + "'"
                        Else
                            strQuery = strQuery + " and " + strSHBZ + " = '" + Me.ddlSJSZSearch_SHBZ.SelectedItem.Text + "'"
                        End If
                End Select

                '按“有效”搜索
                Dim strSFSH As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH
                Select Case Me.ddlSJSZSearch_SFSH.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFSH + " = '" + Me.ddlSJSZSearch_SFSH.SelectedItem.Text + "'"
                        Else
                            strQuery = strQuery + " and " + strSFSH + " = '" + Me.ddlSJSZSearch_SFSH.SelectedItem.Text + "'"
                        End If
                End Select

                '按“税费代码”搜索
                Dim strSFDM As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM
                Select Case Me.ddlSJSZSearch_SFDM.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFDM + " like '" + Me.ddlSJSZSearch_SFDM.SelectedValue + "%'"
                        Else
                            strQuery = strQuery + " and " + strSFDM + " like '" + Me.ddlSJSZSearch_SFDM.SelectedValue + "%'"
                        End If
                End Select

                '按“收付标志”搜索
                Dim strSFBZ As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ
                Select Case Me.ddlSJSZSearch_SFBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFBZ + " = '" + Me.ddlSJSZSearch_SFBZ.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strSFBZ + " = '" + Me.ddlSJSZSearch_SFBZ.SelectedValue + "'"
                        End If
                End Select

                '按“收付对象”搜索
                Dim strSFDX As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX
                Select Case Me.ddlSJSZSearch_SFDX.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFDX + " = '" + Me.ddlSJSZSearch_SFDX.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strSFDX + " = '" + Me.ddlSJSZSearch_SFDX.SelectedValue + "'"
                        End If
                End Select

                '按“发生日期”搜索
                Dim strFSRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strFSRQ = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ
                If Me.txtSJSZSearch_FSRQMin.Text.Length > 0 Then Me.txtSJSZSearch_FSRQMin.Text = Me.txtSJSZSearch_FSRQMin.Text.Trim()
                If Me.txtSJSZSearch_FSRQMax.Text.Length > 0 Then Me.txtSJSZSearch_FSRQMax.Text = Me.txtSJSZSearch_FSRQMax.Text.Trim()
                If Me.txtSJSZSearch_FSRQMin.Text <> "" And Me.txtSJSZSearch_FSRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSJSZSearch_FSRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtSJSZSearch_FSRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtSJSZSearch_FSRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtSJSZSearch_FSRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtSJSZSearch_FSRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtSJSZSearch_FSRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strFSRQ + " between '" + Me.txtSJSZSearch_FSRQMin.Text + "' and '" + Me.txtSJSZSearch_FSRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFSRQ + " between '" + Me.txtSJSZSearch_FSRQMin.Text + "' and '" + Me.txtSJSZSearch_FSRQMax.Text + "'"
                    End If
                ElseIf Me.txtSJSZSearch_FSRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSJSZSearch_FSRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtSJSZSearch_FSRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strFSRQ + " >= '" + Me.txtSJSZSearch_FSRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFSRQ + " >= '" + Me.txtSJSZSearch_FSRQMin.Text + "'"
                    End If
                ElseIf Me.txtSJSZSearch_FSRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtSJSZSearch_FSRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtSJSZSearch_FSRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strFSRQ + " <= '" + Me.txtSJSZSearch_FSRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFSRQ + " <= '" + Me.txtSJSZSearch_FSRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_SJSZ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdSJSZ要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        '     strWhere       ：搜索字符串
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_SJSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            getModuleData_SJSZ = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtSJSZSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(Me.m_objDataSet_SJSZ)

                '重新检索数据
                If objsystemEstateCaiwu.getDataSet_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_SJSZ) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                If blnEditMode = False Then '查看模式
                    With Me.m_objDataSet_SJSZ.Tables(strTable)
                        .DefaultView.AllowNew = False
                    End With
                Else '编辑模式
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            '增加1条空记录
                            With Me.m_objDataSet_SJSZ.Tables(strTable)
                                .DefaultView.AllowNew = True
                                .DefaultView.AddNew()
                            End With
                        Case Else
                            With Me.m_objDataSet_SJSZ.Tables(strTable)
                                .DefaultView.AllowNew = False
                            End With
                    End Select
                End If

                '缓存参数
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    Me.htxtSJSZRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_SJSZ = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            getModuleData_SJSZ = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdSJSZ数据
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_SJSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            searchModuleData_SJSZ = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_SJSZ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_SJSZ(strErrMsg, strQRSH, strQuery, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_SJSZ = strQuery
                Me.htxtSJSZQuery.Value = Me.m_strQuery_SJSZ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_SJSZ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSJSZ的数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SJSZ( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_SJSZ = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtSJSZSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtSJSZSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_SJSZ Is Nothing Then
                    Me.grdSJSZ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SJSZ.Tables(strTable)
                        Me.grdSJSZ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSJSZ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '如果是编辑模式
                If blnEditMode = True Then
                    '移动到最后记录
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            With Me.m_objDataSet_SJSZ.Tables(strTable)
                                Dim intPageIndex As Integer
                                Dim intSelectIndex As Integer
                                If objDataGridProcess.doMoveToRecord(Me.grdSJSZ.AllowPaging, Me.grdSJSZ.PageSize, .DefaultView.Count - 1, intPageIndex, intSelectIndex) = False Then
                                    strErrMsg = "错误：无法移动到最后！"
                                    GoTo errProc
                                End If
                                Try
                                    Me.grdSJSZ.CurrentPageIndex = intPageIndex
                                    Me.grdSJSZ.SelectedIndex = intSelectIndex
                                Catch ex As Exception
                                End Try
                            End With
                        Case Else
                    End Select
                End If

                '允许列排序？
                Me.grdSJSZ.AllowSorting = Not blnEditMode

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdSJSZ)
                    With Me.grdSJSZ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdSJSZ.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSJSZ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_SJSZ) = False Then
                    GoTo errProc
                End If

                '如果是编辑模式
                If blnEditMode = True Then
                    '使能网格
                    If objDataGridProcess.doEnabledDataGrid(strErrMsg, Me.grdSJSZ, Not blnEditMode) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SJSZ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示编辑窗的数据(根据网格当前行数据显示)
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        '     blnEditMode    ：当前编辑状态
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditPanelInfo( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strValue As String = ""

            showEditPanelInfo = False

            Try
                If blnEditMode = False Then
                    '查看状态
                    If Me.grdSJSZ.Items.Count < 1 Or Me.grdSJSZ.SelectedIndex < 0 Then
                        Me.ddlSFDM.SelectedIndex = -1
                        Me.rblSFDX.SelectedIndex = -1
                        Me.rblSFBZ.SelectedIndex = -1
                        Me.htxtWYBS.Value = ""
                        Me.htxtQRSH.Value = ""
                        Me.htxtJHBS.Value = ""
                        Me.htxtCWSH.Value = ""
                        Me.htxtSHRQ.Value = ""
                        Me.txtFSJE.Text = ""
                        Me.txtFSRQ.Text = ""
                        Me.txtZYSM.Text = ""
                        Me.txtJBRY.Text = ""
                        Me.txtJBDW.Text = ""
                        Me.txtKHMC.Text = ""
                        Me.txtPJHM.Text = ""
                        Me.htxtJBRY.Value = ""
                        Me.htxtJBDW.Value = ""
                    Else
                        Dim intColIndex As Integer = -1

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.ddlSFDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSFDM, strValue)

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.rblSFDX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFDX, strValue)

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.rblSFBZ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFBZ, strValue)

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.htxtWYBS.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.htxtQRSH.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JHBS)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.htxtJHBS.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSH)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.htxtCWSH.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.htxtSHRQ.Value = objPulicParameters.getObjectValue(strValue, "", "yyyy-MM-dd")

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.txtFSJE.Text = objPulicParameters.getObjectValue(strValue, 0.0).ToString("#,###.00")

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.txtFSRQ.Text = objPulicParameters.getObjectValue(strValue, "", "yyyy-MM-dd")

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_ZYSM)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.txtZYSM.Text = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRY)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.htxtJBRY.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRYMC)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.txtJBRY.Text = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDW)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.htxtJBDW.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDWMC)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.txtJBDW.Text = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_KHMC)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.txtKHMC.Text = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                        Me.txtPJHM.Text = strValue
                    End If
                Else
                    '编辑状态
                    '自动恢复数据
                End If

                '使能控件
                objControlProcess.doEnabledControl(Me.ddlSFDM, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSFBZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSFDX, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZYSM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtFSJE, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtFSRQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtKHMC, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtPJHM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJBRY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJBDW, blnEditMode)

                Me.btnSelect_JBRY.Visible = blnEditMode
                Me.btnSelect_JBDW.Visible = blnEditMode
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanelInfo = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示SJSZ相关的全部信息
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_SJSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_SJSZ = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_SJSZ(strErrMsg, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_SJSZ.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblSJSZGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdSJSZ, .Count)

                    '显示页面浏览功能
                    Me.lnkCZSJSZMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdSJSZ, .Count) And (Not blnEditMode)
                    Me.lnkCZSJSZMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdSJSZ, .Count) And (Not blnEditMode)
                    Me.lnkCZSJSZMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdSJSZ, .Count) And (Not blnEditMode)
                    Me.lnkCZSJSZMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdSJSZ, .Count) And (Not blnEditMode)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZSJSZDeSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZSJSZSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZSJSZGotoPage.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZSJSZSetPageSize.Enabled = blnEnabled And (Not blnEditMode)
                End With

                objControlProcess.doEnabledControl(Me.txtSJSZPageSize, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSJSZPageIndex, Not blnEditMode)

                objControlProcess.doEnabledControl(Me.txtSJSZSearch_PJHM, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSJSZSearch_FSRQMax, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSJSZSearch_FSRQMin, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlSJSZSearch_SFDM, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlSJSZSearch_SFBZ, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlSJSZSearch_SFDX, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlSJSZSearch_SFSH, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlSJSZSearch_SHBZ, Not blnEditMode)
                Me.btnSJSZSearch.Enabled = Not blnEditMode
                Me.btnSJSZSearch_Full.Enabled = Not blnEditMode

                '显示输入窗信息
                If Me.showEditPanelInfo(strErrMsg, strQRSH, blnEditMode) = False Then
                    GoTo errProc
                End If
                '显示备用金
                If Me.showBeiyongjin(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If

                '显示操作命令
                Me.btnAddNew.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1) And Me.m_strQRSH <> ""
                Me.btnAddJH.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1) And Me.m_strQRSH <> ""
                Me.btnJiezhuan.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1) And Me.m_strQRSH <> ""
                Me.btnDelete.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1) And Me.m_strQRSH <> ""
                Me.btnPrint.Visible = (Not blnEditMode) And Me.m_strQRSH <> ""
                Me.btnClose.Enabled = (Not blnEditMode)
                Me.btnSelect_JYBH.Visible = Not blnEditMode

                Me.btnSave.Visible = blnEditMode
                Me.btnCancel.Visible = blnEditMode

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_SJSZ = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充税费下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：添加空白条目
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillSfdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_SHUIFEIMULU
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillSfdmList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillSfdmList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemEstateCommon.getDataSet_ShuifeiMulu(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateCommonData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                If blnAddBlank = True Then
                    objDropDownList.Items.Add("")
                End If

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateCommonData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillSfdmList = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示备用金信息
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showBeiyongjin( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            showBeiyongjin = False
            strErrMsg = ""

            Try
                '计算备用金
                Dim dblValue() As Double = {0.0, 0.0}
                If strQRSH = "" Then
                    Me.txtBYJ_JF.Text = ""
                    Me.txtBYJ_YF.Text = ""
                    Me.txtBYJ_HT.Text = ""
                Else
                    If objsystemEstateCaiwu.getHetongBeiyongjin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, dblValue(0), dblValue(1)) = False Then
                        GoTo errProc
                    End If
                    Me.txtBYJ_JF.Text = dblValue(0).ToString("#,###.00")
                    Me.txtBYJ_YF.Text = dblValue(1).ToString("#,###.00")
                    Me.txtBYJ_HT.Text = (dblValue(0) + dblValue(1)).ToString("#,###.00")
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            showBeiyongjin = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示合同信息
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showJiaoyiInfo( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objestateErshouData As Josco.JSOA.Common.Data.estateErshouData

            showJiaoyiInfo = False
            strErrMsg = ""

            Try
                '获取信息
                If objsystemEstateErshou.getDataSet_ES_JYXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", objestateErshouData) = False Then
                    GoTo errProc
                End If

                '初始化信息
                Me.lblJYBH.Text = ""
                Me.lblJYRQ.Text = ""
                Me.lblJFMC.Text = ""
                Me.lblJYJG.Text = ""
                Me.lblHTBH.Text = ""
                Me.lblHTRQ.Text = ""
                Me.lblYFMC.Text = ""
                Me.lblJYMJ.Text = ""
                Me.lblWYDZ.Text = ""
                Me.lblJFDLF.Text = ""
                Me.lblYFDLF.Text = ""

                '显示信息
                With objestateErshouData.Tables(strTable)
                    If .Rows.Count < 1 Then
                        Exit Try
                    End If
                    Me.lblJYBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH), "")
                    Me.lblJYRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYRQ), "", "yyyy-MM-dd")
                    Me.lblJFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YZMC), "")
                    Me.lblJYJG.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYJG), 0.0).ToString("#,###.00")
                    Me.lblHTBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH), "")
                    Me.lblHTRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTRQ), "", "yyyy-MM-dd")
                    Me.lblYFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_KHMC), "")
                    Me.lblJYMJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYMJ), 0.0).ToString("#,###.00")
                    Me.lblWYDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYDZ), "")
                    Me.lblJFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JFDLF), 0.0).ToString("#,###.00")
                    Me.lblYFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YFDLF), 0.0).ToString("#,###.00")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objestateErshouData)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            showJiaoyiInfo = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objestateErshouData)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
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
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtSJSZPageIndex)
                    objControlProcess.doTranslateKey(Me.txtSJSZPageSize)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtSJSZSearch_PJHM)
                    objControlProcess.doTranslateKey(Me.txtSJSZSearch_FSRQMin)
                    objControlProcess.doTranslateKey(Me.txtSJSZSearch_FSRQMax)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SFDM)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SFBZ)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SFDX)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SFSH)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SHBZ)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtJBDW)
                    objControlProcess.doTranslateKey(Me.txtJBRY)
                    objControlProcess.doTranslateKey(Me.txtKHMC)
                    objControlProcess.doTranslateKey(Me.txtPJHM)
                    objControlProcess.doTranslateKey(Me.txtZYSM)
                    objControlProcess.doTranslateKey(Me.txtFSJE)
                    objControlProcess.doTranslateKey(Me.txtFSRQ)
                    objControlProcess.doTranslateKey(Me.ddlSFDM)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtJYBH)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtBYJ_JF)
                    objControlProcess.doTranslateKey(Me.txtBYJ_YF)
                    objControlProcess.doTranslateKey(Me.txtBYJ_HT)

                    '显示交易数据
                    If Me.showJiaoyiInfo(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If

                    '获取数据
                    If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                    '显示数据
                    If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
            Dim strErrMsg As String
            Dim strUrl As String

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
                If Me.doFillSfdmList(strErrMsg, Me.ddlSFDM, False) = False Then
                    GoTo errProc
                End If
                If Me.doFillSfdmList(strErrMsg, Me.ddlSJSZSearch_SFDM, True) = False Then
                    GoTo errProc
                End If
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
        Sub grdSJSZ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSJSZ.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_SJSZ + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns_SJSZ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_SJSZ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSJSZ.ID + "Locked"
                    Next
                End If

            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdSJSZ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSJSZ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblSJSZGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdSJSZ, Me.m_intRows_SJSZ)
                '同步显示编辑窗信息
                If Me.showEditPanelInfo(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
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

        Private Sub grdSJSZ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdSJSZ.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
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
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtSJSZSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtSJSZSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtSJSZSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub rblSFDX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblSFDX.SelectedIndexChanged
            Try
                Select Case Me.rblSFDX.SelectedIndex
                    Case 0
                        Me.txtKHMC.Text = Me.lblJFMC.Text
                    Case Else
                        Me.txtKHMC.Text = Me.lblYFMC.Text
                End Select
            Catch ex As Exception
            End Try
        End Sub














        Private Sub doMoveFirst_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMoveLast_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSJSZ.PageCount - 1, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMoveNext_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSJSZ.CurrentPageIndex + 1, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMovePrevious_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSJSZ.CurrentPageIndex - 1, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doGotoPage_SJSZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtSJSZPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtSJSZPageIndex.Text = (Me.grdSJSZ.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_SJSZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtSJSZPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdSJSZ.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtSJSZPageSize.Text = (Me.grdSJSZ.PageSize).ToString()

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

        Private Sub doSelectAll_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdSJSZ, 0, Me.m_cstrCheckBoxIdInDataGrid_SJSZ, True) = False Then
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

        Private Sub doDeSelectAll_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdSJSZ, 0, Me.m_cstrCheckBoxIdInDataGrid_SJSZ, False) = False Then
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

        Private Sub doSearch_SJSZ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub lnkCZSJSZMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZMoveFirst.Click
            Me.doMoveFirst_SJSZ("lnkCZSJSZMoveFirst")
        End Sub

        Private Sub lnkCZSJSZMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZMoveLast.Click
            Me.doMoveLast_SJSZ("lnkCZSJSZMoveLast")
        End Sub

        Private Sub lnkCZSJSZMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZMoveNext.Click
            Me.doMoveNext_SJSZ("lnkCZSJSZMoveNext")
        End Sub

        Private Sub lnkCZSJSZMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZMovePrev.Click
            Me.doMovePrevious_SJSZ("lnkCZSJSZMovePrev")
        End Sub

        Private Sub lnkCZSJSZGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZGotoPage.Click
            Me.doGotoPage_SJSZ("lnkCZSJSZGotoPage")
        End Sub

        Private Sub lnkCZSJSZSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZSetPageSize.Click
            Me.doSetPageSize_SJSZ("lnkCZSJSZSetPageSize")
        End Sub

        Private Sub lnkCZSJSZSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZSelectAll.Click
            Me.doSelectAll_SJSZ("lnkCZSJSZSelectAll")
        End Sub

        Private Sub lnkCZSJSZDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZDeSelectAll.Click
            Me.doDeSelectAll_SJSZ("lnkCZSJSZDeSelectAll")
        End Sub

        Private Sub btnSJSZSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSJSZSearch.Click
            Me.doSearch_SJSZ("btnSJSZSearch")
        End Sub











        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doAddNew(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                If Me.m_strQRSH = "" Then
                    strErrMsg = "错误：没有指定[确认书号]！"
                    GoTo errProc
                End If

                '设置编辑模式
                Me.m_blnEditMode = True
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                Me.m_intCurrentPageIndex = Me.grdSJSZ.CurrentPageIndex
                Me.m_intCurrentSelectIndex = Me.grdSJSZ.SelectedIndex

                '保存相关信息
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()
                Me.htxtCurrentPage.Value = Me.m_intCurrentPageIndex.ToString()
                Me.htxtCurrentRow.Value = Me.m_intCurrentSelectIndex.ToString()

                '进入编辑状态
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设初始值
                Me.rblSFBZ.SelectedIndex = 0
                Me.rblSFDX.SelectedIndex = 1
                Me.txtFSRQ.Text = Now.ToString("yyyy-MM-dd")
                'zengxianglin 2010-12-29
                Me.htxtJBRY.Value = MyBase.UserId
                Me.txtJBRY.Text = MyBase.UserXM
                Me.htxtJBDW.Value = MyBase.UserBmdm
                Me.txtJBDW.Text = MyBase.UserBmmc
                'zengxianglin 2010-12-29
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strErrMsg As String

            Try
                intStep = 1
                '检查
                If Me.rblSFDX.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选择[对象]"
                    GoTo errProc
                End If
                If Me.rblSFBZ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选择[收付]"
                    GoTo errProc
                End If
                'zengxianglin 2008-12-04
                Dim strSFBZ As String = Me.rblSFBZ.SelectedItem.Value
                Select Case strSFBZ
                    Case Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F
                        If Me.m_blnPrevilegeParams(3) = False Then
                            strErrMsg = "错误：您没有付款的权限！"
                            GoTo errProc
                        End If
                End Select
                'zengxianglin 2008-12-04
                If Me.txtFSJE.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[金额]"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtFSJE.Text) = False Then
                    strErrMsg = "错误：无效的[金额]"
                    GoTo errProc
                End If
                Dim dblJE1 As Double = objPulicParameters.getObjectValue(Me.txtFSJE.Text, 0.0)
                Dim dblJE2 As Double = objPulicParameters.getObjectValue(Me.txtBYJ_HT.Text, 0.0)
                'zengxianglin 2010-05-06
                'Select Case Me.rblSFBZ.SelectedValue
                '    Case Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F
                '        If dblJE1 > dblJE2 Then
                '            strErrMsg = "错误：[" + dblJE1.ToString("#.00") + "]超过合同备用金[" + dblJE2.ToString("#.000") + "]，不能支付！"
                '            GoTo errProc
                '        End If
                '    Case Else
                'End Select
                'zengxianglin 2010-05-06

                intStep = 2
                '询问
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：一旦保存将不能删除，只能用[红字]冲减，要继续吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '回答“是”后继续处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取新信息
                    Dim objNewData As New System.Collections.Specialized.NameValueCollection
                    '***************************************************************************************************************
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS, Me.htxtWYBS.Value)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH, Me.htxtQRSH.Value)
                    '***************************************************************************************************************
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JHBS, Me.htxtJHBS.Value)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSH, Me.htxtCWSH.Value)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ, Me.htxtSHRQ.Value)
                    '***************************************************************************************************************
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ, Me.txtFSRQ.Text)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE, Me.txtFSJE.Text)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_ZYSM, Me.txtZYSM.Text)
                    '***************************************************************************************************************
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_KHMC, Me.txtKHMC.Text)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM, Me.txtPJHM.Text)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRY, Me.htxtJBRY.Value)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDW, Me.htxtJBDW.Value)

                    '***************************************************************************************************************
                    If Me.ddlSFDM.SelectedIndex >= 0 Then
                        objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM, Me.ddlSFDM.SelectedValue)
                    Else
                        objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM, "")
                    End If

                    '***************************************************************************************************************
                    If Me.rblSFDX.SelectedIndex >= 0 Then
                        objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX, Me.rblSFDX.SelectedValue)
                    Else
                        objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX, "")
                    End If

                    '***************************************************************************************************************
                    If Me.rblSFBZ.SelectedIndex >= 0 Then
                        objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ, Me.rblSFBZ.SelectedValue)
                    Else
                        objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ, "")
                    End If

                    '获取旧信息
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intPos As Integer = 0
                    Select Case Me.m_objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            objOldData = Nothing
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH) = Me.m_strQRSH
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS) = ""
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JHBS) = ""
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSH) = ""
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ) = ""
                        Case Else
                            '获取数据
                            If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                                GoTo errProc
                            End If
                            intPos = objDataGridProcess.getRecordPosition(Me.grdSJSZ.SelectedIndex, Me.grdSJSZ.CurrentPageIndex, Me.grdSJSZ.PageSize)
                            With Me.m_objDataSet_SJSZ.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With
                    End Select

                    '保存信息
                    If objsystemEstateCaiwu.doSaveData_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objNewData, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    '记录审计日志
                    Select Case Me.m_objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[财务_实收实付]中增加了内容！")
                        Case Else
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]更改了[财务_实收实付]中的内容！")
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
                    If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
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
                        Me.grdSJSZ.CurrentPageIndex = Me.m_intCurrentPageIndex
                        Me.grdSJSZ.SelectedIndex = Me.m_intCurrentSelectIndex
                    Catch ex As Exception
                    End Try

                    '进入非编辑状态
                    If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
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

        Private Sub doSearch_Full_SJSZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU

            Try
                '获取数据
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                    If Me.htxtSJSZSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSJSZSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_SJSZ.Tables(strTable)
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

        Private Sub doOpen_SSSF_JH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.m_strQRSH = "" Then
                    strErrMsg = "错误：没有指定[确认书号]！"
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
                Dim objIEstateCwSssfJh As Josco.JSOA.BusinessFacade.IEstateCwSssfJh = Nothing
                Dim strUrl As String = ""
                objIEstateCwSssfJh = New Josco.JSOA.BusinessFacade.IEstateCwSssfJh
                With objIEstateCwSssfJh
                    .iQRSH = Me.m_strQRSH
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
                Session.Add(strNewSessionId, objIEstateCwSssfJh)

                strUrl = ""
                strUrl += "estate_cw_sssf_jh.aspx"
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

        Private Sub doOpen_SSSF_JZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.m_strQRSH = "" Then
                    strErrMsg = "错误：没有指定[确认书号]！"
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
                Dim objIEstateCwSssfJz As Josco.JSOA.BusinessFacade.IEstateCwSssfJz = Nothing
                Dim strUrl As String = ""
                objIEstateCwSssfJz = New Josco.JSOA.BusinessFacade.IEstateCwSssfJz
                With objIEstateCwSssfJz
                    .iQRSH = Me.m_strQRSH
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
                Session.Add(strNewSessionId, objIEstateCwSssfJz)

                strUrl = ""
                strUrl += "estate_cw_sssf_jz.aspx"
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

        Private Sub doSelect_JBRY(ByVal strControlId As String)

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
                    .iAllowNull = False
                    .iMultiSelect = False
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doSelect_JBDW(ByVal strControlId As String)

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
                    .iAllowNull = False
                    .iMultiSelect = False
                    .iAllowInput = False
                    .iBumenList = ""
                    .iSelectFFFW = False
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

        Private Sub doSelect_JYBH(ByVal strControlId As String)

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
                Dim objIEstateEsXzJyxx As Josco.JSOA.BusinessFacade.IEstateEsXzJyxx = Nothing
                Dim strUrl As String = ""
                objIEstateEsXzJyxx = New Josco.JSOA.BusinessFacade.IEstateEsXzJyxx
                With objIEstateEsXzJyxx
                    .iAllowNull = False
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
                Session.Add(strNewSessionId, objIEstateEsXzJyxx)
                strUrl = ""
                strUrl += "../ershou/estate_es_xz_jyxx.aspx"
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

        Private Sub doDelete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '检查选择
                If Me.grdSJSZ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有内容！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdSJSZ.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strWYBS As String = ""
                Dim strQRSH As String = ""
                Dim strSHBZ As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ)
                strSHBZ = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex)
                If strSHBZ = "1" Then
                    strErrMsg = "错误：已做审核，不能删除！"
                    GoTo errProc
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备删除当前款项吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '删除处理
                    If objsystemEstateCaiwu.doDeleteData_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                        GoTo errProc
                    End If

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[财务_实际收支]中[删除]了[" + strWYBS + "]！")

                    '重新获取数据
                    If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    '刷新网格显示
                    If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doPrint(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '获取数据集
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If
                If Me.m_objDataSet_SJSZ.Tables(strTable) Is Nothing Then
                    strErrMsg = "错误：还未获取数据！"
                    GoTo errProc
                End If
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有数据！"
                        GoTo errProc
                    End If
                End With

                '检查模版文件
                Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "广州兴业_财务收支_财务收支登记.xls"
                Dim strMBLOC As String = Server.MapPath(strMBURL)
                Dim blnFound As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strMBLOC, blnFound) = False Then
                    GoTo errProc
                End If
                If blnFound = False Then
                    strErrMsg = "错误：[" + strMBLOC + "]不存在！"
                    GoTo errProc
                End If

                '备份模版文件到缓存目录
                Dim strTempPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
                Dim strTempFile As String
                strTempPath = Server.MapPath(strTempPath)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strMBLOC, strTempPath, strTempFile) = False Then
                    GoTo errProc
                End If
                Dim strTempSpec As String
                strTempSpec = objBaseLocalFile.doMakePath(strTempPath, strTempFile)

                '输出数据
                Dim strMacroValue As String = ""
                Dim strMacroName As String = ""
                strMacroName = "$Macro$QCRQ$,$Macro$QMRQ$,$Macro$GSMC$"
                strMacroValue = Me.txtSJSZSearch_FSRQMin.Text + "," + Me.txtSJSZSearch_FSRQMax.Text + "," + "兴业公司"
                If objsystemEstateCaiwu.doExportToExcel(strErrMsg, Me.m_objDataSet_SJSZ, strTempSpec, strMacroName, strMacroValue) = False Then
                    GoTo errProc
                End If

                '显示Excel
                Dim strTempUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strTempFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strTempUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2008-11-18
        Private Sub doSelect_PJHM(ByVal strControlId As String)

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
                Dim objIEstateCwXzPiaoju As Josco.JSOA.BusinessFacade.IEstateCwXzPiaoju = Nothing
                Dim strUrl As String = ""
                objIEstateCwXzPiaoju = New Josco.JSOA.BusinessFacade.IEstateCwXzPiaoju
                With objIEstateCwXzPiaoju
                    'zengxianglin 2008-11-22
                    .iYkpz = Josco.JSOA.BusinessFacade.IEstateCwXzPiaoju.enumYKPZ.Wkpz
                    'zengxianglin 2008-11-22
                    .iYWBH = Me.propUniQRSH
                    .iAllowNull = False
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
                Session.Add(strNewSessionId, objIEstateCwXzPiaoju)
                strUrl = ""
                strUrl += "estate_cw_xz_piaoju.aspx"
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

        Private Sub btnSJSZSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSJSZSearch_Full.Click
            Me.doSearch_Full_SJSZ("btnSJSZSearch_Full")
        End Sub

        Private Sub btnSelect_JBRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JBRY.Click
            Me.doSelect_JBRY("btnSelect_JBRY")
        End Sub

        Private Sub btnSelect_JBDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JBDW.Click
            Me.doSelect_JBDW("btnSelect_JBDW")
        End Sub

        Private Sub btnSelect_JYBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JYBH.Click
            Me.doSelect_JYBH("btnSelect_JYBH")
        End Sub

        'zengxianglin 2008-11-18
        Private Sub btnSelect_PJHM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_PJHM.Click
            Me.doSelect_PJHM("btnSelect_PJHM")
        End Sub
        'zengxianglin 2008-11-18

        Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            Me.doAddNew("btnAddNew")
        End Sub

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Me.doDelete("btnDelete")
        End Sub

        Private Sub btnAddJH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddJH.Click
            Me.doOpen_SSSF_JH("btnAddJH")
        End Sub

        Private Sub btnJiezhuan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJiezhuan.Click
            Me.doOpen_SSSF_JZ("btnJiezhuan")
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Me.doSave("btnSave")
        End Sub

        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Me.doPrint("btnPrint")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace

