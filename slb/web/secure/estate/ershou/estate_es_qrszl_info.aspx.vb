Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_qrszl_info
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“租赁确认书主信息”处理模块
    '
    ' 更改记录：
    '     zengxianglin 2010-01-06 更改
    '     zengxianglin 2010-12-26 更改
    '----------------------------------------------------------------

    Partial Class estate_es_qrszl_info
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

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_cw_sssf_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsQrsZlInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsQrsZlInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdWYXX相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdWYXX As String = "chkWYXX"
        Private Const m_cstrDataGridInDIV_grdWYXX As String = "divWYXX"
        Private m_intFixedColumns_grdWYXX As Integer

        '----------------------------------------------------------------
        '与数据网格grdYWRY相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdYWRY As String = "chkYWRY"
        Private Const m_cstrDataGridInDIV_grdYWRY As String = "divYWRY"
        Private m_intFixedColumns_grdYWRY As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_MAIN As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData

        '----------------------------------------------------------------
        '其他参数
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_blnEditMode As Boolean
        Private m_strQRSH As String












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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsQrsZlInfo)
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

                ''是否继续执行
                'If Me.m_blnPrevilegeParams(0) = True Then
                '    blnContinueExecute = True
                'Else
                '    Me.panelError.Visible = True
                '    Me.lblMessage.Text = "错误：您没有[" + strFirstParamValue + "]的执行权限，请与系统管理员联系，谢谢！"
                '    Me.panelMain.Visible = Not Me.panelError.Visible
                'End If
                blnContinueExecute = True
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
                    Me.htxtDivLeftWYXX.Value = .htxtDivLeftWYXX
                    Me.htxtDivTopWYXX.Value = .htxtDivTopWYXX
                    Me.htxtDivLeftYWRY.Value = .htxtDivLeftYWRY
                    Me.htxtDivTopYWRY.Value = .htxtDivTopYWRY

                    Me.htxtSessionId_WYXX.Value = .htxtSessionId_WYXX
                    Try
                        Me.grdWYXX.PageSize = .grdWYXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWYXX.CurrentPageIndex = .grdWYXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWYXX.SelectedIndex = .grdWYXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtSessionId_YWRY.Value = .htxtSessionId_YWRY
                    Try
                        Me.grdYWRY.PageSize = .grdYWRY_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYWRY.CurrentPageIndex = .grdYWRY_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYWRY.SelectedIndex = .grdYWRY_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.ddlJFZJLB.SelectedIndex = .ddlJFZJLB_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlYFZJLB.SelectedIndex = .ddlYFZJLB_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.rblFZFSYD.SelectedIndex = .rblFZFSYD_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtWYBS.Value = .htxtWYBS
                    Me.txtQRSH.Text = .txtQRSH
                    Me.txtDGRQ.Text = .txtDGRQ
                    Me.txtJYRQ.Text = .txtJYRQ
                    Me.txtJLRQ.Text = .txtJLRQ
                    Me.txtJLZK.Text = .txtJLZK
                    Me.txtZQ.Text = .txtZQ
                    Me.txtFWDZ.Text = .txtFWDZ
                    Me.txtJYYZJ.Text = .txtJYYZJ
                    Me.txtZLBZJ.Text = .txtZLBZJ
                    Me.txtJYZMJ.Text = .txtJYZMJ
                    Me.txtBZXX.Text = .txtBZXX

                    Me.txtJFDLR.Text = .txtJFDLR
                    Me.txtJFLXDH.Text = .txtJFLXDH
                    Me.txtJFLXDZ.Text = .txtJFLXDZ
                    Me.txtJFMC.Text = .txtJFMC
                    Me.txtJFZZHM.Text = .txtJFZZHM

                    Me.txtYFDLR.Text = .txtYFDLR
                    Me.txtYFLXDH.Text = .txtYFLXDH
                    Me.txtYFLXDZ.Text = .txtYFLXDZ
                    Me.txtYFMC.Text = .txtYFMC
                    Me.txtYFZZHM.Text = .txtYFZZHM

                    'zengxianglin 2010-12-28
                    Me.txtKYBH.Text = .txtKYBH
                    Me.txtCCDZ.Text = .txtCCDZ
                    Me.txtCCF.Text = .txtCCF
                    Me.txtJFDLF.Text = .txtJFDLF
                    Me.txtYFDLF.Text = .txtYFDLF
                    Me.txtSSYJ.Text = .txtSSYJ
                    Me.txtHZYJ.Text = .txtHZYJ
                    Me.txtYZQN.Text = .txtYZQN
                    Me.txtYYQT.Text = .txtYYQT
                    Me.txtYZDY.Text = .txtYZDY
                    Me.txtMJQN.Text = .txtMJQN
                    Me.txtKYQT.Text = .txtKYQT
                    Me.txtKHDY.Text = .txtKHDY
                    Me.rblYZQC.SelectedIndex = .rblYZQC_SelectedIndex
                    Me.rblYZLY.SelectedIndex = .rblYZLY_SelectedIndex
                    Me.rblSYWY.SelectedIndex = .rblSYWY_SelectedIndex
                    Me.rblMJQC.SelectedIndex = .rblMJQC_SelectedIndex
                    Me.rblKHLY.SelectedIndex = .rblKHLY_SelectedIndex
                    Me.txtZLKS.Text = .txtZLKS
                    Me.txtZLJS.Text = .txtZLJS
                    Me.rblSDMQ.SelectedIndex = .rblSDMQ_SelectedIndex
                    Me.rblDHF.SelectedIndex = .rblDHF_SelectedIndex
                    Me.rblGLF.SelectedIndex = .rblGLF_SelectedIndex
                    Me.rblZLFP.SelectedIndex = .rblZLFP_SelectedIndex
                    'zengxianglin 2010-12-28
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsQrsZlInfo

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftWYXX = Me.htxtDivLeftWYXX.Value
                    .htxtDivTopWYXX = Me.htxtDivTopWYXX.Value
                    .htxtDivLeftYWRY = Me.htxtDivLeftYWRY.Value
                    .htxtDivTopYWRY = Me.htxtDivTopYWRY.Value

                    .htxtSessionId_WYXX = Me.htxtSessionId_WYXX.Value
                    .grdWYXX_PageSize = Me.grdWYXX.PageSize
                    .grdWYXX_CurrentPageIndex = Me.grdWYXX.CurrentPageIndex
                    .grdWYXX_SelectedIndex = Me.grdWYXX.SelectedIndex

                    .htxtSessionId_YWRY = Me.htxtSessionId_YWRY.Value
                    .grdYWRY_PageSize = Me.grdYWRY.PageSize
                    .grdYWRY_CurrentPageIndex = Me.grdYWRY.CurrentPageIndex
                    .grdYWRY_SelectedIndex = Me.grdYWRY.SelectedIndex

                    .ddlJFZJLB_SelectedIndex = Me.ddlJFZJLB.SelectedIndex
                    .ddlYFZJLB_SelectedIndex = Me.ddlYFZJLB.SelectedIndex

                    .rblFZFSYD_SelectedIndex = Me.rblFZFSYD.SelectedIndex

                    .htxtWYBS = Me.htxtWYBS.Value
                    .txtQRSH = Me.txtQRSH.Text
                    .txtDGRQ = Me.txtDGRQ.Text
                    .txtFWDZ = Me.txtFWDZ.Text
                    .txtJYRQ = Me.txtJYRQ.Text
                    .txtJLRQ = Me.txtJLRQ.Text
                    .txtJLZK = Me.txtJLZK.Text
                    .txtZQ = Me.txtZQ.Text
                    .txtJYYZJ = Me.txtJYYZJ.Text
                    .txtZLBZJ = Me.txtZLBZJ.Text
                    .txtJYZMJ = Me.txtJYZMJ.Text
                    .txtBZXX = Me.txtBZXX.Text

                    .txtJFDLR = Me.txtJFDLR.Text
                    .txtJFLXDH = Me.txtJFLXDH.Text
                    .txtJFLXDZ = Me.txtJFLXDZ.Text
                    .txtJFMC = Me.txtJFMC.Text
                    .txtJFZZHM = Me.txtJFZZHM.Text

                    .txtYFDLR = Me.txtYFDLR.Text
                    .txtYFLXDH = Me.txtYFLXDH.Text
                    .txtYFLXDZ = Me.txtYFLXDZ.Text
                    .txtYFMC = Me.txtYFMC.Text
                    .txtYFZZHM = Me.txtYFZZHM.Text

                    'zengxianglin 2010-12-28
                    .txtKYBH = Me.txtKYBH.Text
                    .txtCCDZ = Me.txtCCDZ.Text
                    .txtCCF = Me.txtCCF.Text
                    .txtJFDLF = Me.txtJFDLF.Text
                    .txtYFDLF = Me.txtYFDLF.Text
                    .txtSSYJ = Me.txtSSYJ.Text
                    .txtHZYJ = Me.txtHZYJ.Text
                    .txtYZQN = Me.txtYZQN.Text
                    .txtYYQT = Me.txtYYQT.Text
                    .txtYZDY = Me.txtYZDY.Text
                    .txtMJQN = Me.txtMJQN.Text
                    .txtKYQT = Me.txtKYQT.Text
                    .txtKHDY = Me.txtKHDY.Text
                    .rblYZQC_SelectedIndex = Me.rblYZQC.SelectedIndex
                    .rblYZLY_SelectedIndex = Me.rblYZLY.SelectedIndex
                    .rblSYWY_SelectedIndex = Me.rblSYWY.SelectedIndex
                    .rblMJQC_SelectedIndex = Me.rblMJQC.SelectedIndex
                    .rblKHLY_SelectedIndex = Me.rblKHLY.SelectedIndex
                    .txtZLKS = Me.txtZLKS.Text
                    .txtZLJS = Me.txtZLJS.Text
                    .rblSDMQ_SelectedIndex = Me.rblSDMQ.SelectedIndex
                    .rblDHF_SelectedIndex = Me.rblDHF.SelectedIndex
                    .rblGLF_SelectedIndex = Me.rblGLF.SelectedIndex
                    .rblZLFP_SelectedIndex = Me.rblZLFP.SelectedIndex
                    'zengxianglin 2010-12-28
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

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objRYJGXX As System.Collections.Specialized.NameValueCollection = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateCwSssf As Josco.JSOA.BusinessFacade.IEstateCwSssf = Nothing
                Try
                    objIEstateCwSssf = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwSssf)
                Catch ex As Exception
                    objIEstateCwSssf = Nothing
                End Try
                If Not (objIEstateCwSssf Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwSssf.SafeRelease(objIEstateCwSssf)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateCwYsyf As Josco.JSOA.BusinessFacade.IEstateCwYsyf = Nothing
                Try
                    objIEstateCwYsyf = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwYsyf)
                Catch ex As Exception
                    objIEstateCwYsyf = Nothing
                End Try
                If Not (objIEstateCwYsyf Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwYsyf.SafeRelease(objIEstateCwYsyf)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsQrsZlWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye = Nothing
                Try
                    objIEstateEsQrsZlWuye = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye)
                Catch ex As Exception
                    objIEstateEsQrsZlWuye = Nothing
                End Try
                If Not (objIEstateEsQrsZlWuye Is Nothing) Then
                    If objIEstateEsQrsZlWuye.oExitMode = True Then
                        Select Case objIEstateEsQrsZlWuye.iSourceControlId.ToUpper()
                            Case "btnAddNew_WYXX".ToUpper(), "btnUpdate_WYXX".ToUpper()
                                Dim strFWDZ As String = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ)
                                Try
                                    Me.m_objDataSet_WYXX = CType(Session(Me.htxtSessionId_WYXX.Value), Josco.JSOA.Common.Data.estateErshouData)
                                Catch ex As Exception
                                    Me.m_objDataSet_WYXX = Nothing
                                End Try
                                If Not (Me.m_objDataSet_WYXX Is Nothing) Then
                                    Dim strOldFilter As String = ""
                                    Dim strNewFilter As String = ""
                                    With Me.m_objDataSet_WYXX.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_ZL)
                                        Dim objDataRow As System.Data.DataRow = Nothing
                                        Select Case objIEstateEsQrsZlWuye.iMode
                                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                                Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                                '是否存在?
                                                strOldFilter = .DefaultView.RowFilter
                                                '搜索filter
                                                strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ + " = '" + strFWDZ + "'"
                                                .DefaultView.RowFilter = strNewFilter
                                                If .DefaultView.Count < 1 Then
                                                    '不存在！
                                                    objDataRow = .NewRow()
                                                    .Rows.Add(objDataRow)
                                                End If
                                                '复原filter
                                                .DefaultView.RowFilter = strOldFilter
                                            Case Else
                                                Dim intPos As Integer = -1
                                                intPos = objDataGridProcess.getRecordPosition(objIEstateEsQrsZlWuye.iRowNo, Me.grdWYXX.CurrentPageIndex, Me.grdWYXX.PageSize)
                                                objDataRow = .DefaultView.Item(intPos).Row
                                        End Select
                                        If Not (objDataRow Is Nothing) Then
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ) = objPulicParameters.getObjectValue(objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ), 0.0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ) = objPulicParameters.getObjectValue(objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ), 0.0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC) = objPulicParameters.getObjectValue(objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC), 0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL) = objPulicParameters.getObjectValue(objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL), 0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX)
                                            'zengxianglin 2010-12-26
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY)
                                            If objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ) = "" Then
                                                objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ) = System.DBNull.Value
                                            Else
                                                objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ)
                                            End If
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX)
                                            'zengxianglin 2010-12-26

                                            '重新计算相关数据
                                            Dim dblMJ As Double = 0
                                            Dim dblJE As Double = 0
                                            If Me.getQRSInfoWyxxRela(strErrMsg, Me.m_objDataSet_WYXX, strFWDZ, dblMJ, dblJE) = True Then
                                                Me.txtFWDZ.Text = strFWDZ
                                                Me.txtJYZMJ.Text = dblMJ.ToString("#,###.00")
                                                Me.txtJYYZJ.Text = dblJE.ToString("#,###.00")
                                                Me.txtZLBZJ.Text = (dblJE * 2).ToString("#,###.00")
                                            End If
                                        End If
                                    End With
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye.SafeRelease(objIEstateEsQrsZlWuye)
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
                            Case "btnAddNew_YWRY".ToUpper()
                                Dim strRYDM As String = objIDmxzRyxx.oRYDM
                                Dim strRYMC As String = objIDmxzRyxx.oRYZM
                                Dim strZZDM As String = objIDmxzRyxx.oZZDM
                                Dim strZZMC As String = objIDmxzRyxx.oZZMC
                                Dim strZJDM As String = ""
                                Dim strZJMC As String = ""
                                'zengxianglin 2008-10-14
                                Dim strSSFZ As String = ""
                                'If objsystemEstateRenshiXingye.getRenyuanZhiji(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, Now, strZJDM, strZJMC) = False Then
                                '    '忽略
                                'End If
                                If objsystemEstateErshou.getRYJGXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, Me.txtDGRQ.Text, objRYJGXX) = True Then
                                    If Not (objRYJGXX Is Nothing) Then
                                        strZZDM = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM), "")
                                        strZZMC = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC), "")
                                        strZJDM = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ), "")
                                        strZJMC = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC), "")
                                        strSSFZ = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ), "")
                                    End If
                                End If
                                'zengxianglin 2008-10-14
                                Try
                                    Me.m_objDataSet_YWRY = CType(Session(Me.htxtSessionId_YWRY.Value), Josco.JSOA.Common.Data.estateErshouData)
                                Catch ex As Exception
                                    Me.m_objDataSet_YWRY = Nothing
                                End Try
                                If Not (Me.m_objDataSet_YWRY Is Nothing) Then
                                    Dim strOldFilter As String = ""
                                    Dim strNewFilter As String = ""
                                    Dim blnDo As Boolean = False
                                    With Me.m_objDataSet_YWRY.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL)
                                        '是否存在?
                                        strOldFilter = .DefaultView.RowFilter
                                        '搜索filter
                                        strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM + " = '" + strRYDM + "'"
                                        .DefaultView.RowFilter = strNewFilter
                                        If .DefaultView.Count < 1 Then
                                            Dim objDataRow As System.Data.DataRow = Nothing
                                            '不存在！
                                            objDataRow = .NewRow()
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM) = strRYDM
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC) = strRYMC
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM) = strZZDM
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC) = strZZMC
                                            'zengxianglin 2008-10-14
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = strSSFZ
                                            'zengxianglin 2008-10-14
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = 1.0
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ) = strZJDM
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC) = strZJMC
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJ) = -1
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ) = 1
                                            .Rows.Add(objDataRow)
                                            blnDo = True
                                        End If
                                        '复原filter
                                        .DefaultView.RowFilter = strOldFilter
                                    End With
                                    '调整分配比例
                                    If blnDo = True Then
                                        If Me.doComputeFPBL(strErrMsg) = False Then
                                            '忽略
                                        End If
                                    End If
                                End If
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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objRYJGXX)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objRYJGXX)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsQrsZlInfo)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    Me.m_strQRSH = ""
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_objenumEditType = Me.m_objInterface.iMode
                    Me.m_strQRSH = Me.m_objInterface.iQRSH
                End If
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_blnEditMode = True
                    Case Else
                        Me.m_blnEditMode = False
                End Select

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsQrsZlInfo)
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
                Me.m_intFixedColumns_grdWYXX = objPulicParameters.getObjectValue(Me.htxtWYXXFixed.Value, 0)
                Me.m_intFixedColumns_grdYWRY = objPulicParameters.getObjectValue(Me.htxtYWRYFixed.Value, 0)
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

            Dim strErrMsg As String = ""

            Try
                Dim objDataSet As Josco.JSOA.Common.Data.estateErshouData = Nothing
                If Me.htxtSessionId_WYXX.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_WYXX.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_WYXX.Value)
                    Me.htxtSessionId_WYXX.Value = ""
                End If
                If Me.htxtSessionId_YWRY.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_YWRY.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_YWRY.Value)
                    Me.htxtSessionId_YWRY.Value = ""
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub













        '----------------------------------------------------------------
        ' 重新计算各人的分配比例
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doComputeFPBL(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doComputeFPBL = False
            strErrMsg = ""

            Try
                Dim intCount As Integer = 0
                Dim dblFPBL As Double = 0
                Dim dblLeft As Double = 1
                Dim i As Integer = 0
                With Me.m_objDataSet_YWRY.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL)
                    dblFPBL = CType((1.0 / .Rows.Count).ToString("#.00"), Double)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        If i = intCount - 1 Then
                            .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = dblLeft
                        Else
                            .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = dblFPBL
                        End If
                        dblLeft = dblLeft - dblFPBL
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doComputeFPBL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据物业数据获取确认书相关数据
        '     strErrMsg      ：返回错误信息
        '     objData        ：输入的数据
        '     strFWDZ        ：合成的房屋地址
        '     dblMJ          ：总面积
        '     dblJE          ：总金额
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQRSInfoWyxxRela( _
            ByRef strErrMsg As String, _
            ByVal objData As Josco.JSOA.Common.Data.estateErshouData, _
            ByRef strFWDZ As String, _
            ByRef dblMJ As Double, _
            ByRef dblJE As Double) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_ZL
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQRSInfoWyxxRela = False
            strErrMsg = ""
            strFWDZ = ""
            dblMJ = 0
            dblJE = 0

            Try
                '检查
                If objData Is Nothing Then
                    Exit Try
                End If
                If objData.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objData.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If

                '计算
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        If strFWDZ = "" Then
                            strFWDZ = objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ), "")
                        Else
                            strFWDZ = strFWDZ + strSep + objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ), "")
                        End If

                        dblMJ += objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ), 0.0)

                        dblJE += objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ), 0.0)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQRSInfoWyxxRela = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取要显示的主数据信息
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_MAIN( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_ZL
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_MAIN = False

            Try
                '检查
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_MAIN)

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_QRS_ZL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", Me.m_objDataSet_MAIN) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdWYXX要显示的数据
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        '     strWhere       ：搜索字符串
        '     blnEditMode    ：True-编辑 False-查看
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_WYXX( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_ZL
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_WYXX = False

            Try
                '检查
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '获取数据
                If blnEditMode = True Then
                    If Me.htxtSessionId_WYXX.Value.Trim <> "" Then
                        '从缓存中获取数据
                        Me.m_objDataSet_WYXX = CType(Session.Item(Me.htxtSessionId_WYXX.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Else
                        '释放资源
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_WYXX)
                        '重新检索数据
                        If objsystemEstateErshou.getDataSet_ES_WUYE_ZL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_WYXX) = False Then
                            GoTo errProc
                        End If
                        '缓存数据
                        Me.htxtSessionId_WYXX.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_WYXX.Value, Me.m_objDataSet_WYXX)
                    End If
                Else
                    '释放缓存数据
                    If Me.htxtSessionId_WYXX.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_WYXX = CType(Session.Item(Me.htxtSessionId_WYXX.Value), Josco.JSOA.Common.Data.estateErshouData)
                        Catch ex As Exception
                            Me.m_objDataSet_WYXX = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_WYXX)
                        Session.Remove(Me.htxtSessionId_WYXX.Value)
                        Me.htxtSessionId_WYXX.Value = ""
                    End If
                    '释放资源
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_WYXX)
                    '重新检索数据
                    If objsystemEstateErshou.getDataSet_ES_WUYE_ZL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_WYXX) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_WYXX = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdYWRY要显示的数据
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        '     strWhere       ：搜索字符串
        '     blnEditMode    ：True-编辑 False-查看
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_YWRY( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_YWRY = False

            Try
                '检查
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                Dim strQuery As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ + " & 1 = 1"
                If strWhere = "" Then
                    strWhere = strQuery
                Else
                    strWhere = strWhere + " and " + strQuery
                End If

                '获取数据
                If blnEditMode = True Then
                    If Me.htxtSessionId_YWRY.Value.Trim <> "" Then
                        '从缓存中获取数据
                        Me.m_objDataSet_YWRY = CType(Session.Item(Me.htxtSessionId_YWRY.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Else
                        '释放资源
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YWRY)
                        '重新检索数据
                        If objsystemEstateErshou.getDataSet_ES_HETONG_FPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_YWRY) = False Then
                            GoTo errProc
                        End If
                        '缓存数据
                        Me.htxtSessionId_YWRY.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_YWRY.Value, Me.m_objDataSet_YWRY)
                    End If
                Else
                    '释放缓存数据
                    If Me.htxtSessionId_YWRY.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_YWRY = CType(Session.Item(Me.htxtSessionId_YWRY.Value), Josco.JSOA.Common.Data.estateErshouData)
                        Catch ex As Exception
                            Me.m_objDataSet_YWRY = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YWRY)
                        Session.Remove(Me.htxtSessionId_YWRY.Value)
                        Me.htxtSessionId_YWRY.Value = ""
                    End If
                    '释放资源
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YWRY)
                    '重新检索数据
                    If objsystemEstateErshou.getDataSet_ES_HETONG_FPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_YWRY) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_YWRY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' 显示grdWYXX的数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_WYXX( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_ZL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_WYXX = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_WYXX Is Nothing Then
                    Me.grdWYXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_WYXX.Tables(strTable)
                        Me.grdWYXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_WYXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdWYXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdWYXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdWYXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdWYXX) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_WYXX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYWRY的数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_YWRY( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_YWRY = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_YWRY Is Nothing Then
                    Me.grdYWRY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YWRY.Tables(strTable)
                        Me.grdYWRY.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_YWRY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYWRY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdYWRY.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYWRY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWRY) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_YWRY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_ZL
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            showEditPanel_MAIN = False
            strErrMsg = ""

            Try
                '显示值
                Dim strValue As String = ""
                Dim intValue As Integer = 0
                If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                    With Me.m_objDataSet_MAIN.Tables(strTable)
                        If .Rows.Count < 1 Then
                            '设置空值
                            Me.ddlJFZJLB.SelectedIndex = -1
                            Me.ddlYFZJLB.SelectedIndex = -1

                            Me.rblFZFSYD.SelectedIndex = -1

                            Me.htxtWYBS.Value = ""
                            Me.txtQRSH.Text = ""

                            Me.txtDGRQ.Text = ""
                            Me.txtFWDZ.Text = ""
                            Me.txtJYRQ.Text = ""
                            Me.txtJLRQ.Text = ""
                            Me.txtJLZK.Text = ""
                            Me.txtZQ.Text = ""
                            Me.txtJYYZJ.Text = ""
                            Me.txtZLBZJ.Text = ""
                            Me.txtJYZMJ.Text = ""
                            Me.txtBZXX.Text = ""

                            Me.txtJFDLR.Text = ""
                            Me.txtJFLXDH.Text = ""
                            Me.txtJFLXDZ.Text = ""
                            Me.txtJFMC.Text = ""
                            Me.txtJFZZHM.Text = ""

                            Me.txtYFDLR.Text = ""
                            Me.txtYFLXDH.Text = ""
                            Me.txtYFLXDZ.Text = ""
                            Me.txtYFMC.Text = ""
                            Me.txtYFZZHM.Text = ""

                            'zengxianglin 2010-12-28
                            Me.txtKYBH.Text = ""
                            Me.txtCCDZ.Text = ""
                            Me.txtCCF.Text = ""
                            Me.txtJFDLF.Text = ""
                            Me.txtYFDLF.Text = ""
                            Me.txtSSYJ.Text = ""
                            Me.txtHZYJ.Text = ""
                            Me.txtYZQN.Text = ""
                            Me.txtYYQT.Text = ""
                            Me.txtYZDY.Text = ""
                            Me.txtMJQN.Text = ""
                            Me.txtKYQT.Text = ""
                            Me.txtKHDY.Text = ""
                            Me.rblYZQC.SelectedIndex = -1
                            Me.rblYZLY.SelectedIndex = -1
                            Me.rblSYWY.SelectedIndex = -1
                            Me.rblMJQC.SelectedIndex = -1
                            Me.rblKHLY.SelectedIndex = -1
                            Me.txtZLKS.Text = ""
                            Me.txtZLJS.Text = ""
                            Me.rblSDMQ.SelectedIndex = -1
                            Me.rblDHF.SelectedIndex = -1
                            Me.rblGLF.SelectedIndex = -1
                            Me.rblZLFP.SelectedIndex = -1
                            'zengxianglin 2010-12-28
                        Else
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFZJLX), "")
                            Me.ddlJFZJLB.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJFZJLB, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFZJLX), "")
                            Me.ddlYFZJLB.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYFZJLB, strValue)

                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_FZFSYD), "")
                            Me.rblFZFSYD.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblFZFSYD, strValue)

                            Me.htxtWYBS.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_WYBS), "")
                            Me.txtQRSH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_QRSH), "")
                            Me.txtDGRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DGRQ), "", "yyyy-MM-dd")

                            Me.txtFWDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_FWDZ), "")
                            Me.txtJYYZJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYYZJ), 0.0).ToString("#,###.00")
                            Me.txtZLBZJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLBZJ), 0.0).ToString("#,###.00")
                            Me.txtJYZMJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYZMJ), 0.0).ToString("#,###.00")
                            Me.txtJYRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JHJYRQ), "", "yyyy-MM-dd")
                            Me.txtJLRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JHJLRQ), "", "yyyy-MM-dd")
                            Me.txtZQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZQYS), "")
                            Me.txtJLZK.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JLZKSM), "")
                            Me.txtBZXX.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_BZXX), "")

                            Me.txtJFDLR.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFDLR), "")
                            Me.txtJFLXDH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDH), "")
                            Me.txtJFLXDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDZ), "")
                            Me.txtJFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFMC), "")
                            Me.txtJFZZHM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFZZHM), "")

                            Me.txtYFDLR.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFDLR), "")
                            Me.txtYFLXDH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDH), "")
                            Me.txtYFLXDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDZ), "")
                            Me.txtYFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFMC), "")
                            Me.txtYFZZHM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFZZHM), "")

                            'zengxianglin 2010-12-28
                            Me.txtKYBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KYBH), "")
                            Me.txtCCDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_CCDZ), "")
                            Me.txtCCF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_CCF), 0.0).ToString("#,##0.00")
                            Me.txtJFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFDLF), 0.0).ToString("#,##0.00")
                            Me.txtYFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFDLF), 0.0).ToString("#,##0.00")
                            Me.txtSSYJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SSYJ), 0.0).ToString("#,##0.00")
                            Me.txtHZYJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_HZYJ), 0.0).ToString("#,##0.00")
                            Me.txtYZQN.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZQN), "")
                            Me.txtYYQT.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YYQT), "")
                            Me.txtYZDY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZDY), "")
                            Me.txtMJQN.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_MJQN), "")
                            Me.txtKYQT.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KYQT), "")
                            Me.txtKHDY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KHDY), "")
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZQC), "")
                            Me.rblYZQC.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYZQC, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZLY), "")
                            Me.rblYZLY.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYZLY, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SYWY), "")
                            Me.rblSYWY.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSYWY, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_MJQC), "")
                            Me.rblMJQC.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblMJQC, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KHLY), "")
                            Me.rblKHLY.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblKHLY, strValue)

                            Me.txtZLKS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLKS), "", "yyyy-MM-dd")
                            Me.txtZLJS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLJS), "", "yyyy-MM-dd")
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SDMQ), "")
                            Me.rblSDMQ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSDMQ, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DHF), "")
                            Me.rblDHF.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblDHF, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_GLF), "")
                            Me.rblGLF.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblGLF, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLFP), "")
                            Me.rblZLFP.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblZLFP, strValue)
                            'zengxianglin 2010-12-28
                        End If

                        'zengxianglin 2008-11-27
                        '设初始值
                        Select Case Me.m_objenumEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                If objsystemEstateErshou.getNewQRSH_ZL(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtQRSH.Text) = False Then
                                    GoTo errProc
                                End If
                                Me.txtDGRQ.Text = Now.ToString("yyyy-MM-dd")
                        End Select
                        'zengxianglin 2008-11-27
                    End With
                End If

                '操作控制
                objControlProcess.doEnabledControl(Me.ddlJFZJLB, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlYFZJLB, blnEditMode)

                objControlProcess.doEnabledControl(Me.rblFZFSYD, blnEditMode)
                'zengxianglin 2008-11-27
                objControlProcess.doEnabledControl(Me.txtQRSH, False)
                'zengxianglin 2008-11-27
                objControlProcess.doEnabledControl(Me.txtDGRQ, blnEditMode)

                objControlProcess.doEnabledControl(Me.txtFWDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJYYZJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZLBZJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJYZMJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJLRQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJYRQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJLZK, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBZXX, blnEditMode)

                objControlProcess.doEnabledControl(Me.txtJFDLR, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFLXDH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFLXDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFMC, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFZZHM, blnEditMode)

                objControlProcess.doEnabledControl(Me.txtYFDLR, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFLXDH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFLXDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFMC, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFZZHM, blnEditMode)

                'zengxianglin 2010-12-28
                objControlProcess.doEnabledControl(Me.txtKYBH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtCCDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtCCF, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFDLF, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFDLF, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSSYJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtHZYJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYZQN, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYYQT, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYZDY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtMJQN, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtKYQT, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtKHDY, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblYZQC, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblYZLY, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSYWY, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblMJQC, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblKHLY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZLKS, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZLJS, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSDMQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblDHF, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblGLF, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblZLFP, blnEditMode)
                'zengxianglin 2010-12-28

                Me.btnAddNew_WYXX.Visible = blnEditMode
                Me.btnAddNew_YWRY.Visible = blnEditMode
                Me.btnUpdate_WYXX.Visible = blnEditMode
                Me.btnDelete_WYXX.Visible = blnEditMode
                Me.btnDelete_YWRY.Visible = blnEditMode
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_MAIN = True
            Exit Function
errProc:
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
                Me.btnSJSZ.Visible = Not blnEditMode
                Me.btnYSYF.Visible = Not blnEditMode
                'zengxianglin 2010-12-30
                Me.btnSHCY.Visible = (Not blnEditMode) And (Me.m_blnPrevilegeParams(2))
                'zengxianglin 2010-12-30
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

            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            Try
                '仅在第一次调用页面时执行
                If Me.IsPostBack = False Then
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    objControlProcess.doTranslateKey(Me.ddlJFZJLB)
                    objControlProcess.doTranslateKey(Me.ddlYFZJLB)

                    objControlProcess.doTranslateKey(Me.txtQRSH)
                    objControlProcess.doTranslateKey(Me.txtDGRQ)
                    objControlProcess.doTranslateKey(Me.txtFWDZ)
                    objControlProcess.doTranslateKey(Me.txtJYYZJ)
                    objControlProcess.doTranslateKey(Me.txtZLBZJ)
                    objControlProcess.doTranslateKey(Me.txtJYZMJ)
                    objControlProcess.doTranslateKey(Me.txtZQ)
                    objControlProcess.doTranslateKey(Me.txtJYRQ)
                    objControlProcess.doTranslateKey(Me.txtJLRQ)
                    objControlProcess.doTranslateKey(Me.txtJLZK)
                    objControlProcess.doTranslateKey(Me.txtBZXX)

                    objControlProcess.doTranslateKey(Me.txtJFDLR)
                    objControlProcess.doTranslateKey(Me.txtJFLXDH)
                    objControlProcess.doTranslateKey(Me.txtJFLXDZ)
                    objControlProcess.doTranslateKey(Me.txtJFMC)
                    objControlProcess.doTranslateKey(Me.txtJFZZHM)

                    objControlProcess.doTranslateKey(Me.txtYFDLR)
                    objControlProcess.doTranslateKey(Me.txtYFLXDH)
                    objControlProcess.doTranslateKey(Me.txtYFLXDZ)
                    objControlProcess.doTranslateKey(Me.txtYFMC)
                    objControlProcess.doTranslateKey(Me.txtYFZZHM)

                    'zengxianglin 2010-12-27
                    objControlProcess.doTranslateKey(Me.txtKYBH)
                    objControlProcess.doTranslateKey(Me.txtCCDZ)
                    objControlProcess.doTranslateKey(Me.txtCCF)
                    objControlProcess.doTranslateKey(Me.txtJFDLF)
                    objControlProcess.doTranslateKey(Me.txtYFDLF)
                    objControlProcess.doTranslateKey(Me.txtSSYJ)
                    objControlProcess.doTranslateKey(Me.txtHZYJ)
                    objControlProcess.doTranslateKey(Me.txtYZQN)
                    objControlProcess.doTranslateKey(Me.txtYYQT)
                    objControlProcess.doTranslateKey(Me.txtYZDY)
                    objControlProcess.doTranslateKey(Me.txtMJQN)
                    objControlProcess.doTranslateKey(Me.txtKYQT)
                    objControlProcess.doTranslateKey(Me.txtKHDY)
                    objControlProcess.doTranslateKey(Me.txtZLKS)
                    objControlProcess.doTranslateKey(Me.txtZLJS)
                    'zengxianglin 2010-12-27

                    If Me.getModuleData_MAIN(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.getModuleData_WYXX(strErrMsg, Me.m_strQRSH, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_WYXX(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.getModuleData_YWRY(strErrMsg, Me.m_strQRSH, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_YWRY(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.showModuleData_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                Else
                    '获取缓存数据
                    If Me.getModuleData_WYXX(strErrMsg, Me.m_strQRSH, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_YWRY(strErrMsg, Me.m_strQRSH, "", Me.m_blnEditMode) = False Then
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
            Dim strErrMsg As String = ""
            Dim strUrl As String = ""
            Dim blnDo As Boolean

            Try
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
        Sub grdWYXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdWYXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdWYXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdWYXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdWYXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdWYXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdYWRY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYWRY.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdYWRY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdYWRY > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdYWRY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYWRY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdWYXX_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdWYXX.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdWYXX.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        Me.doOpen_WYXX(strControlId)
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

        Private Sub doDelete_WYXX(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_ZL
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '删除选定行
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdWYXX.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdWYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdWYXX) = True Then
                        With Me.m_objDataSet_WYXX.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdWYXX.CurrentPageIndex, Me.grdWYXX.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next

                '重新显示
                If Me.showDataGridInfo_WYXX(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                '重新计算相关数据
                Dim strFWDZ As String = ""
                Dim dblMJ As Double = 0
                Dim dblJE As Double = 0
                If Me.getQRSInfoWyxxRela(strErrMsg, Me.m_objDataSet_WYXX, strFWDZ, dblMJ, dblJE) = True Then
                    Me.txtFWDZ.Text = strFWDZ
                    Me.txtJYZMJ.Text = dblMJ.ToString("#,###.00")
                    Me.txtJYYZJ.Text = dblJE.ToString("#,###.00")
                    Me.txtZLBZJ.Text = (dblJE * 2).ToString("#,###.00")
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

        Private Sub doDelete_YWRY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '删除选定行
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdYWRY.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdYWRY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWRY) = True Then
                        With Me.m_objDataSet_YWRY.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdYWRY.CurrentPageIndex, Me.grdYWRY.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next

                '调整分配比例
                If Me.doComputeFPBL(strErrMsg) = False Then
                    '忽略
                End If

                '重新显示
                If Me.showDataGridInfo_YWRY(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doAddNew_YWRY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'zengxianglin 2008-10-14
                If Me.txtDGRQ.Text.Trim = "" Then
                    strErrMsg = "错误：请先输入[订购日期]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtDGRQ.Text) = False Then
                    strErrMsg = "错误：无效的[订购日期]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-10-14

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

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objNewData As New System.Collections.Specialized.NameValueCollection
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strQRSH As String = ""

            Try
                '检查
                If Me.grdWYXX.Items.Count < 1 Then
                    strErrMsg = "错误：必须至少指定一个物业！"
                    GoTo errProc
                End If
                If Me.grdYWRY.Items.Count < 1 Then
                    strErrMsg = "错误：必须至少指定一个业务员！"
                    GoTo errProc
                End If
                'zengxianglin 2010-12-28
                If Me.txtZLKS.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtZLKS.Text) = False Then
                        strErrMsg = "错误：无效的租赁开始时间[" + Me.txtZLKS.Text + "]！"
                        GoTo errProc
                    End If
                End If
                If Me.txtZLJS.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtZLJS.Text) = False Then
                        strErrMsg = "错误：无效的租赁结束时间[" + Me.txtZLJS.Text + "]！"
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2010-12-28

                '准备接口数据
                objNewData.Clear()
                '********************************************************************************************************************
                '本界面不处理的内容
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DJRDM, MyBase.UserId)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DJRMC, MyBase.UserZM)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DJRQ, Now.ToString("yyyy-MM-dd"))
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_WYBS, Me.htxtWYBS.Value.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_QRSH, Me.txtQRSH.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DGRQ, Me.txtDGRQ.Text.Trim)
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_FWDZ, Me.txtFWDZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYYZJ, Me.txtJYYZJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLBZJ, Me.txtZLBZJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYZMJ, Me.txtJYZMJ.Text.Trim)
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZQYS, Me.txtZQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JHJYRQ, Me.txtJYRQ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JHJLRQ, Me.txtJLRQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JLZKSM, Me.txtJLZK.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_BZXX, Me.txtBZXX.Text.Trim)
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFDLR, Me.txtJFDLR.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDH, Me.txtJFLXDH.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDZ, Me.txtJFLXDZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFMC, Me.txtJFMC.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFZZHM, Me.txtJFZZHM.Text.Trim)
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFDLR, Me.txtYFDLR.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDH, Me.txtYFLXDH.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDZ, Me.txtYFLXDZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFMC, Me.txtYFMC.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFZZHM, Me.txtYFZZHM.Text.Trim)
                '********************************************************************************************************************
                Dim intValue As Integer = 0
                If Me.rblFZFSYD.SelectedIndex > 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_FZFSYD, Me.rblFZFSYD.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_FZFSYD, "0")
                End If
                '********************************************************************************************************************
                If Me.ddlJFZJLB.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFZJLX, Me.ddlJFZJLB.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFZJLX, "0")
                End If
                '********************************************************************************************************************
                If Me.ddlYFZJLB.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFZJLX, Me.ddlYFZJLB.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFZJLX, "0")
                End If

                'zengxianglin 2010-12-27
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KYBH, Me.txtKYBH.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_CCDZ, Me.txtCCDZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_CCF, Me.txtCCF.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFDLF, Me.txtJFDLF.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFDLF, Me.txtYFDLF.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SSYJ, Me.txtSSYJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_HZYJ, Me.txtHZYJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZQN, Me.txtYZQN.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YYQT, Me.txtYYQT.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZDY, Me.txtYZDY.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_MJQN, Me.txtMJQN.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KYQT, Me.txtKYQT.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KHDY, Me.txtKHDY.Text.Trim)
                If Me.rblYZQC.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZQC, Me.rblYZQC.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZQC, "")
                End If
                If Me.rblYZLY.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZLY, Me.rblYZLY.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZLY, "")
                End If
                If Me.rblSYWY.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SYWY, Me.rblSYWY.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SYWY, "")
                End If
                If Me.rblMJQC.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_MJQC, Me.rblMJQC.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_MJQC, "")
                End If
                If Me.rblKHLY.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KHLY, Me.rblKHLY.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KHLY, "")
                End If
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLKS, Me.txtZLKS.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLJS, Me.txtZLJS.Text.Trim)
                If Me.rblSDMQ.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SDMQ, Me.rblSDMQ.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SDMQ, "")
                End If
                If Me.rblDHF.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DHF, Me.rblDHF.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DHF, "")
                End If
                If Me.rblGLF.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_GLF, Me.rblGLF.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_GLF, "")
                End If
                If Me.rblZLFP.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLFP, Me.rblZLFP.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLFP, "")
                End If
                If Me.txtZQ.Text.Trim = "" Then
                    If Me.txtZLKS.Text.Trim <> "" And Me.txtZLJS.Text.Trim <> "" Then
                        Me.txtZQ.Text = (System.Math.Abs(Microsoft.VisualBasic.DateDiff(Microsoft.VisualBasic.DateInterval.Month, CType(Me.txtZLKS.Text, System.DateTime), CType(Me.txtZLJS.Text, System.DateTime))) + 1).ToString
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZQYS) = Me.txtZQ.Text
                    End If
                End If
                'zengxianglin 2010-12-27

                '保存数据
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DGZT) = CType(Josco.JSOA.Common.Data.estateErshouData.enumQuerenshuStatus.Yishen, Integer).ToString
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_WYBS) = ""
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_QRSH) = ""
                        If objsystemEstateErshou.doSaveData_ES_QRS_ZL( _
                            strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                            objNewData, _
                            Nothing, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Me.m_objDataSet_WYXX, _
                            Me.m_objDataSet_YWRY) = False Then
                            GoTo errProc
                        End If
                        '记录审计日志
                        strQRSH = objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_QRSH)
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[二手_租赁确认书]中增加了[" + strQRSH + "]！")

                    Case Else
                        '获取数据
                        If Me.getModuleData_MAIN(strErrMsg, Me.m_strQRSH) = False Then
                            GoTo errProc
                        End If
                        '保存数据
                        Dim objDataRow As System.Data.DataRow = Nothing
                        With Me.m_objDataSet_MAIN.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_ZL)
                            If .Rows.Count < 1 Then
                                strErrMsg = "错误：没有确认书！"
                                GoTo errProc
                            Else
                                objDataRow = .Rows(0)
                            End If
                        End With
                        If objsystemEstateErshou.doSaveData_ES_QRS_ZL( _
                            strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                            objNewData, _
                            objDataRow, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, _
                            Me.m_objDataSet_WYXX, _
                            Me.m_objDataSet_YWRY) = False Then
                            GoTo errProc
                        End If
                        '记录审计日志
                        strQRSH = objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_QRSH)
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[二手_租赁确认书]中[修改]了[" + strQRSH + "]！")
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

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpen_YSYF(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtQRSH.Text.Trim = "" Then
                    strErrMsg = "错误：没有选定[确认书]！"
                    GoTo errProc
                End If
                Dim blnIS As Boolean = False
                If objsystemEstateErshou.isQianHetong(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtQRSH.Text, blnIS) = False Then
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
                Dim objIEstateCwYsyf As Josco.JSOA.BusinessFacade.IEstateCwYsyf = Nothing
                Dim strUrl As String = ""
                objIEstateCwYsyf = New Josco.JSOA.BusinessFacade.IEstateCwYsyf
                With objIEstateCwYsyf
                    .iQRSH = Me.txtQRSH.Text
                    .iCanModify = Not blnIS
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
                Session.Add(strNewSessionId, objIEstateCwYsyf)
                strUrl = ""
                strUrl += "../caiwu/estate_cw_ysyf.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpen_SSSF(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtQRSH.Text.Trim = "" Then
                    strErrMsg = "错误：没有选定[确认书]！"
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
                Dim objIEstateCwSssf As Josco.JSOA.BusinessFacade.IEstateCwSssf = Nothing
                Dim strUrl As String = ""
                objIEstateCwSssf = New Josco.JSOA.BusinessFacade.IEstateCwSssf
                With objIEstateCwSssf
                    .iQRSH = Me.txtQRSH.Text
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
                Session.Add(strNewSessionId, objIEstateCwSssf)
                strUrl = ""
                strUrl += "../caiwu/estate_cw_sssf.aspx"
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

        Private Sub doOpen_WYXX(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objValues As New System.Collections.Specialized.NameValueCollection
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.grdWYXX.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有物业数据"
                    GoTo errProc
                End If

                '准备接口
                Dim i As Integer = Me.grdWYXX.SelectedIndex
                Dim intColIndex As Integer = -1
                Dim strValue As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ, strValue)

                'zengxianglin 2010-12-26
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS, strValue)
                'zengxianglin 2010-12-26

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateEsQrsZlWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsZlWuye = New Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye
                With objIEstateEsQrsZlWuye
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iRowNo = Me.grdWYXX.SelectedIndex
                    .iQRSH = Me.txtQRSH.Text
                    .iValues = objValues
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
                Session.Add(strNewSessionId, objIEstateEsQrsZlWuye)
                strUrl = ""
                strUrl += "estate_es_qrszl_wuye.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objValues)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doUpdate_WYXX(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objValues As New System.Collections.Specialized.NameValueCollection
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.grdWYXX.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有物业数据"
                    GoTo errProc
                End If

                '准备接口
                Dim i As Integer = Me.grdWYXX.SelectedIndex
                Dim intColIndex As Integer = -1
                Dim strValue As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ, strValue)

                'zengxianglin 2010-12-26
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS, strValue)
                'zengxianglin 2010-12-26

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateEsQrsZlWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsZlWuye = New Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye
                With objIEstateEsQrsZlWuye
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iRowNo = Me.grdWYXX.SelectedIndex
                    .iQRSH = Me.txtQRSH.Text
                    .iValues = objValues
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
                Session.Add(strNewSessionId, objIEstateEsQrsZlWuye)
                strUrl = ""
                strUrl += "estate_es_qrszl_wuye.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objValues)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doAddNew_WYXX(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objValues As New System.Collections.Specialized.NameValueCollection
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
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
                Dim objIEstateEsQrsZlWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsZlWuye = New Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye
                With objIEstateEsQrsZlWuye
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iQRSH = Me.txtQRSH.Text
                    .iValues = Nothing
                    .iRowNo = -1
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
                Session.Add(strNewSessionId, objIEstateEsQrsZlWuye)
                strUrl = ""
                strUrl += "estate_es_qrszl_wuye.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objValues)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2010-12-30 创建
        Private Sub doOpen_CWSH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtQRSH.Text.Trim = "" Then
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
                Dim objIEstateCwSssfSh As Josco.JSOA.BusinessFacade.IEstateCwSssfSh = Nothing
                Dim strUrl As String = ""
                objIEstateCwSssfSh = New Josco.JSOA.BusinessFacade.IEstateCwSssfSh
                With objIEstateCwSssfSh
                    .iQRSH = Me.txtQRSH.Text
                    .iSFDM = Me.htxtCYJXZ.Value
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
                Session.Add(strNewSessionId, objIEstateCwSssfSh)
                strUrl = ""
                strUrl += "../caiwu/estate_cw_sssf_sh.aspx"
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

        Private Sub btnDelete_WYXX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_WYXX.Click
            Me.doDelete_WYXX("btnDelete_WYXX")
        End Sub

        Private Sub btnDelete_YWRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_YWRY.Click
            Me.doDelete_YWRY("btnDelete_YWRY")
        End Sub

        Private Sub btnAddNew_WYXX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_WYXX.Click
            Me.doAddNew_WYXX("btnAddNew_WYXX")
        End Sub

        Private Sub btnAddNew_YWRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_YWRY.Click
            Me.doAddNew_YWRY("btnAddNew_YWRY")
        End Sub

        Private Sub btnUpdate_WYXX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate_WYXX.Click
            Me.doUpdate_WYXX("btnUpdate_WYXX")
        End Sub

        Private Sub btnYSYF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYSYF.Click
            Me.doOpen_YSYF("btnYSYF")
        End Sub

        Private Sub btnSJSZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSJSZ.Click
            Me.doOpen_SSSF("btnSJSZ")
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

        Private Sub btnSHCY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSHCY.Click
            Me.doOpen_CWSH("btnSHCY")
        End Sub

    End Class

End Namespace
