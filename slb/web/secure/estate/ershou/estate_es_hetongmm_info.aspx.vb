Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_hetongmm_info
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“买卖合同主信息”处理模块
    '
    ' 更改记录：
    '     zengxianglin 2010-01-06 更改
    '     zengxianglin 2010-01-13 更改
    '     zengxianglin 2010-12-26 更改
    '----------------------------------------------------------------

    Partial Class estate_es_hetongmm_info
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
        Private m_cstrPrevilegeParamPrefix As String = "estate_es_hetong_previlege_param"
        Private m_blnPrevilegeParams(15) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsHetongMmInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo
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
        Private m_objDataSet_MAINQRS As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_MAINHT As Josco.JSOA.Common.Data.estateErshouData
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo)
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

                    '****************************************************************
                    Try
                        Me.ddlJFZJLB.SelectedIndex = .ddlJFZJLB_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlYFZJLB.SelectedIndex = .ddlYFZJLB_SelectedIndex
                    Catch ex As Exception
                    End Try
                    '****************************************************************
                    Try
                        Me.rblTGFKYD.SelectedIndex = .rblTGFKYD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblJLZKYD.SelectedIndex = .rblJLZKYD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblJLRQYD.SelectedIndex = .rblJLRQYD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFZFYD.SelectedIndex = .rblSFZFYD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    '****************************************************************
                    Me.htxtWYBS.Value = .htxtWYBS
                    Me.htxtQRSH.Value = .htxtQRSH
                    Me.htxtDGRQ.Value = .htxtDGRQ
                    Me.txtJLRQ.Text = .txtJLRQ
                    Me.txtFWDZ.Text = .txtFWDZ
                    Me.txtJYZMJ.Text = .txtJYZMJ
                    Me.txtJYZJG.Text = .txtJYZJG
                    Me.txtJFDLF.Text = .txtJFDLF
                    Me.txtYFDLF.Text = .txtYFDLF
                    Me.txtDLFZK.Text = .txtDLFZK
                    '****************************************************************
                    Me.txtJFDLR.Text = .txtJFDLR
                    Me.txtJFLXDH.Text = .txtJFLXDH
                    Me.txtJFLXDZ.Text = .txtJFLXDZ
                    Me.txtJFMC.Text = .txtJFMC
                    Me.txtJFZZHM.Text = .txtJFZZHM
                    '****************************************************************
                    Me.txtYFDLR.Text = .txtYFDLR
                    Me.txtYFLXDH.Text = .txtYFLXDH
                    Me.txtYFLXDZ.Text = .txtYFLXDZ
                    Me.txtYFMC.Text = .txtYFMC
                    Me.txtYFZZHM.Text = .txtYFZZHM

                    '****************************************************************
                    Me.htxtHTWYBS.Value = .htxtHTWYBS
                    Me.htxtHTZT.Value = .htxtHTZT
                    Me.txtHTBH.Text = .txtHTBH
                    Me.txtHTRQ.Text = .txtHTRQ
                    'zengxianglin 2008-11-22
                    Me.txtTJRQ.Text = .txtTJRQ
                    'zengxianglin 2008-11-22
                    'zengxianglin 2008-11-25
                    Me.txtAJFH.Text = .txtAJFH
                    'zengxianglin 2008-11-25
                    Me.txtBZXX.Text = .txtBZXX
                    '****************************************************************
                    Me.rblHTLX.SelectedIndex = .rblHTLX_SelectedIndex
                    Me.ddlFKFS.SelectedIndex = .ddlFKFS_SelectedIndex

                    'zengxianglin 2010-12-28
                    Me.txtKYBH.Text = .txtKYBH
                    Me.txtCCDZ.Text = .txtCCDZ
                    Me.txtCCF.Text = .txtCCF
                    Me.txtSSYJ.Text = .txtSSYJ
                    Me.txtHZYJ.Text = .txtHZYJ
                    Me.txtAJJG.Text = .txtAJJG
                    Me.txtAJYH.Text = .txtAJYH
                    Me.txtAJCS.Text = .txtAJCS
                    Me.txtAJNX.Text = .txtAJNX
                    Me.txtYZQN.Text = .txtYZQN
                    Me.txtYYQT.Text = .txtYYQT
                    Me.txtYZDY.Text = .txtYZDY
                    Me.txtMJQN.Text = .txtMJQN
                    Me.txtKYQT.Text = .txtKYQT
                    Me.txtKHDY.Text = .txtKHDY
                    Me.rblYZQC.SelectedIndex = .rblYZQC_SelectedIndex
                    Me.rblYZLY.SelectedIndex = .rblYZLY_SelectedIndex
                    Me.rblSHYX.SelectedIndex = .rblSHYX_SelectedIndex
                    Me.rblSYWY.SelectedIndex = .rblSYWY_SelectedIndex
                    Me.rblMJQC.SelectedIndex = .rblMJQC_SelectedIndex
                    Me.rblKHLY.SelectedIndex = .rblKHLY_SelectedIndex
                    Me.rblGMMD.SelectedIndex = .rblGMMD_SelectedIndex
                    Me.rblFKFSYD.SelectedIndex = .rblFKFSYD_SelectedIndex
                    Me.htxtHTBZ.Value = .htxtHTBZ
                    Me.txtJCRQ.Text = .txtJCRQ
                    Me.txtHZRQ.Text = .txtHZRQ
                    Me.txtHZJE.Text = .txtHZJE
                    Me.chkHTHZ.Checked = .chkHTHZ_Checked
                    Me.chkHTJC.Checked = .chkHTJC_Checked
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsHetongMmInfo

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

                    '****************************************************************
                    .ddlJFZJLB_SelectedIndex = Me.ddlJFZJLB.SelectedIndex
                    .ddlYFZJLB_SelectedIndex = Me.ddlYFZJLB.SelectedIndex
                    '****************************************************************
                    .rblTGFKYD_SelectedIndex = Me.rblTGFKYD.SelectedIndex
                    .rblJLZKYD_SelectedIndex = Me.rblJLZKYD.SelectedIndex
                    .rblJLRQYD_SelectedIndex = Me.rblJLRQYD.SelectedIndex
                    .rblSFZFYD_SelectedIndex = Me.rblSFZFYD.SelectedIndex
                    '****************************************************************
                    .htxtWYBS = Me.htxtWYBS.Value
                    .htxtQRSH = Me.htxtQRSH.Value
                    .htxtDGRQ = Me.htxtDGRQ.Value
                    .txtFWDZ = Me.txtFWDZ.Text
                    .txtJLRQ = Me.txtJLRQ.Text
                    .txtJYZJG = Me.txtJYZJG.Text
                    .txtJYZMJ = Me.txtJYZMJ.Text
                    .txtJFDLF = Me.txtJFDLF.Text
                    .txtYFDLF = Me.txtYFDLF.Text
                    .txtDLFZK = Me.txtDLFZK.Text
                    '****************************************************************
                    .txtJFDLR = Me.txtJFDLR.Text
                    .txtJFLXDH = Me.txtJFLXDH.Text
                    .txtJFLXDZ = Me.txtJFLXDZ.Text
                    .txtJFMC = Me.txtJFMC.Text
                    .txtJFZZHM = Me.txtJFZZHM.Text
                    '****************************************************************
                    .txtYFDLR = Me.txtYFDLR.Text
                    .txtYFLXDH = Me.txtYFLXDH.Text
                    .txtYFLXDZ = Me.txtYFLXDZ.Text
                    .txtYFMC = Me.txtYFMC.Text
                    .txtYFZZHM = Me.txtYFZZHM.Text

                    '****************************************************************
                    .htxtHTWYBS = Me.htxtHTWYBS.Value
                    .htxtHTZT = Me.htxtHTZT.Value
                    .txtHTBH = Me.txtHTBH.Text
                    .txtHTRQ = Me.txtHTRQ.Text
                    'zengxianglin 2008-11-22
                    .txtTJRQ = Me.txtTJRQ.Text
                    'zengxianglin 2008-11-22
                    'zengxianglin 2008-11-25
                    .txtAJFH = Me.txtAJFH.Text
                    'zengxianglin 2008-11-25
                    .txtBZXX = Me.txtBZXX.Text
                    '****************************************************************
                    .rblHTLX_SelectedIndex = Me.rblHTLX.SelectedIndex
                    .ddlFKFS_SelectedIndex = Me.ddlFKFS.SelectedIndex

                    'zengxianglin 2010-12-28
                    .txtKYBH = Me.txtKYBH.Text
                    .txtCCDZ = Me.txtCCDZ.Text
                    .txtCCF = Me.txtCCF.Text
                    .txtSSYJ = Me.txtSSYJ.Text
                    .txtHZYJ = Me.txtHZYJ.Text
                    .txtAJJG = Me.txtAJJG.Text
                    .txtAJYH = Me.txtAJYH.Text
                    .txtAJCS = Me.txtAJCS.Text
                    .txtAJNX = Me.txtAJNX.Text
                    .txtYZQN = Me.txtYZQN.Text
                    .txtYYQT = Me.txtYYQT.Text
                    .txtYZDY = Me.txtYZDY.Text
                    .txtMJQN = Me.txtMJQN.Text
                    .txtKYQT = Me.txtKYQT.Text
                    .txtKHDY = Me.txtKHDY.Text
                    .rblYZQC_SelectedIndex = Me.rblYZQC.SelectedIndex
                    .rblYZLY_SelectedIndex = Me.rblYZLY.SelectedIndex
                    .rblSHYX_SelectedIndex = Me.rblSHYX.SelectedIndex
                    .rblSYWY_SelectedIndex = Me.rblSYWY.SelectedIndex
                    .rblMJQC_SelectedIndex = Me.rblMJQC.SelectedIndex
                    .rblKHLY_SelectedIndex = Me.rblKHLY.SelectedIndex
                    .rblGMMD_SelectedIndex = Me.rblGMMD.SelectedIndex
                    .rblFKFSYD_SelectedIndex = Me.rblFKFSYD.SelectedIndex
                    .htxtHTBZ = Me.htxtHTBZ.Value
                    .txtJCRQ = Me.txtJCRQ.Text
                    .txtHZRQ = Me.txtHZRQ.Text
                    .txtHZJE = Me.txtHZJE.Text
                    .chkHTHZ_Checked = Me.chkHTHZ.Checked
                    .chkHTJC_Checked = Me.chkHTJC.Checked
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
                Dim objIEstateEsHetongWc As Josco.JSOA.BusinessFacade.IEstateEsHetongWc = Nothing
                Try
                    objIEstateEsHetongWc = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongWc)
                Catch ex As Exception
                    objIEstateEsHetongWc = Nothing
                End Try
                If Not (objIEstateEsHetongWc Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongWc.SafeRelease(objIEstateEsHetongWc)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongJssList As Josco.JSOA.BusinessFacade.IEstateEsHetongJssList = Nothing
                Try
                    objIEstateEsHetongJssList = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongJssList)
                Catch ex As Exception
                    objIEstateEsHetongJssList = Nothing
                End Try
                If Not (objIEstateEsHetongJssList Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongJssList.SafeRelease(objIEstateEsHetongJssList)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateCwSztz As Josco.JSOA.BusinessFacade.IEstateCwSztz = Nothing
                Try
                    objIEstateCwSztz = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwSztz)
                Catch ex As Exception
                    objIEstateCwSztz = Nothing
                End Try
                If Not (objIEstateCwSztz Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwSztz.SafeRelease(objIEstateCwSztz)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongBl As Josco.JSOA.BusinessFacade.IEstateEsHetongBl = Nothing
                Try
                    objIEstateEsHetongBl = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongBl)
                Catch ex As Exception
                    objIEstateEsHetongBl = Nothing
                End Try
                If Not (objIEstateEsHetongBl Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongBl.SafeRelease(objIEstateEsHetongBl)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongSh As Josco.JSOA.BusinessFacade.IEstateEsHetongSh = Nothing
                Try
                    objIEstateEsHetongSh = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongSh)
                Catch ex As Exception
                    objIEstateEsHetongSh = Nothing
                End Try
                If Not (objIEstateEsHetongSh Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongSh.SafeRelease(objIEstateEsHetongSh)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongFpbl As Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl = Nothing
                Try
                    objIEstateEsHetongFpbl = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl)
                Catch ex As Exception
                    objIEstateEsHetongFpbl = Nothing
                End Try
                If Not (objIEstateEsHetongFpbl Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl.SafeRelease(objIEstateEsHetongFpbl)
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
                Dim objIEstateEsQrsMmWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsMmWuye = Nothing
                Try
                    objIEstateEsQrsMmWuye = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsQrsMmWuye)
                Catch ex As Exception
                    objIEstateEsQrsMmWuye = Nothing
                End Try
                If Not (objIEstateEsQrsMmWuye Is Nothing) Then
                    If objIEstateEsQrsMmWuye.oExitMode = True Then
                        Select Case objIEstateEsQrsMmWuye.iSourceControlId.ToUpper()
                            Case "btnAddNew_WYXX".ToUpper(), "btnUpdate_WYXX".ToUpper()
                                Dim strFWDZ As String = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWDZ)
                                Try
                                    Me.m_objDataSet_WYXX = CType(Session(Me.htxtSessionId_WYXX.Value), Josco.JSOA.Common.Data.estateErshouData)
                                Catch ex As Exception
                                    Me.m_objDataSet_WYXX = Nothing
                                End Try
                                If Not (Me.m_objDataSet_WYXX Is Nothing) Then
                                    Dim strOldFilter As String = ""
                                    Dim strNewFilter As String = ""
                                    With Me.m_objDataSet_WYXX.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_MM)
                                        Dim objDataRow As System.Data.DataRow = Nothing
                                        Select Case objIEstateEsQrsMmWuye.iMode
                                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                                Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                                '是否存在?
                                                strOldFilter = .DefaultView.RowFilter
                                                '搜索filter
                                                strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWDZ + " = '" + strFWDZ + "'"
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
                                                intPos = objDataGridProcess.getRecordPosition(objIEstateEsQrsMmWuye.iRowNo, Me.grdWYXX.CurrentPageIndex, Me.grdWYXX.PageSize)
                                                objDataRow = .DefaultView.Item(intPos).Row
                                        End Select
                                        If Not (objDataRow Is Nothing) Then
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBS) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBM) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBM)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_QRSH) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_QRSH)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZH) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZH)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZDZ) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZDZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWDZ) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWDZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_MJ) = objPulicParameters.getObjectValue(objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_MJ), 0.0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JYJE) = objPulicParameters.getObjectValue(objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JYJE), 0.0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZX) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LC) = objPulicParameters.getObjectValue(objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LC), 0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LL) = objPulicParameters.getObjectValue(objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LL), 0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JG) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JG)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGMC) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGMC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZ) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZMC) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZMC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQY) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQY)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQYMC) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQYMC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_BZXX) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_BZXX)
                                            'zengxianglin 2010-12-26
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FYBH) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FYBH)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LP) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LP)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LD) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LD)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DY) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DY)
                                            If objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JCSJ) = "" Then
                                                objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JCSJ) = System.DBNull.Value
                                            Else
                                                objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JCSJ) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JCSJ)
                                            End If
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_KJLX) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_KJLX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWXZ) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWXZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXDC) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXDC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXNX) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXNX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZYYX) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZYYX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JJSB) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JJSB)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LYJT) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LYJT)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWJG) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWJG)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGLX) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGLX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGFS) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGFS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LG) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LG)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WSSL) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WSSL)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_YTSL) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_YTSL)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_HYMJ) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_HYMJ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DTSL) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DTSL)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LCHS) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LCHS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LPQS) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LPQS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXX) = objIEstateEsQrsMmWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXX)
                                            'zengxianglin 2010-12-26

                                            '重新计算相关数据
                                            Dim dblMJ As Double = 0
                                            Dim dblJE As Double = 0
                                            If Me.getQRSInfoWyxxRela(strErrMsg, Me.m_objDataSet_WYXX, strFWDZ, dblMJ, dblJE) = True Then
                                                Me.txtFWDZ.Text = strFWDZ
                                                Me.txtJYZMJ.Text = dblMJ.ToString("#,###.00")
                                                Me.txtJYZJG.Text = dblJE.ToString("#,###.00")
                                                'zengxianglin 2008-11-25
                                                'If Me.doComputeDLF(strErrMsg) = False Then
                                                '    '忽略
                                                'End If
                                                'zengxianglin 2008-11-25
                                            End If
                                        End If
                                    End With
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsQrsMmWuye.SafeRelease(objIEstateEsQrsMmWuye)
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
                                Dim intTDBH As Integer = 0
                                Dim strZJDM As String = ""
                                Dim strZJMC As String = ""
                                'zengxianglin 2008-10-14
                                Dim strSSFZ As String = ""
                                If objsystemEstateErshou.getRYJGXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, Me.txtHTRQ.Text, objRYJGXX) = True Then
                                    If Not (objRYJGXX Is Nothing) Then
                                        strZZDM = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM), "")
                                        strZZMC = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC), "")
                                        strZJDM = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ), "")
                                        strZJMC = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC), "")
                                        strSSFZ = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ), "")
                                        'zengxianglin 2010-01-13
                                        intTDBH = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH), 0)
                                        'zengxianglin 2010-01-13
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
                                            'zengxianglin 2010-01-13
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH) = intTDBH
                                            'zengxianglin 2010-01-13
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = 1.0
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ) = strZJDM
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC) = strZJMC
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ) = 1
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZMC) = Josco.JSOA.Common.Data.estateErshouData.getYejiStatusName(1)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJ) = -1
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJMC) = Josco.JSOA.Common.Data.estateErshouData.getZhiguanStatusName(-1)
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
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo)
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
                If Me.m_strQRSH = "" Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "错误：没有提供本模块必须的接口！"
                    Exit Try
                End If

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsHetongMmInfo)
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
        ' 根据当前交易额、税费方式计算各自的代理费
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doComputeDLF(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim dblJE As Double = 0.0

            doComputeDLF = False
            strErrMsg = ""

            Try
                dblJE = objPulicParameters.getObjectValue(Me.txtJYZJG.Text, 0.0)
                Select Case Me.rblSFZFYD.SelectedIndex
                    Case 0
                        Me.txtJFDLF.Text = (dblJE * 0.015).ToString("#,###.00")
                        Me.txtYFDLF.Text = (dblJE * 0.015).ToString("#,###.00")
                    Case 1
                        Me.txtJFDLF.Text = (dblJE * 0.03).ToString("#,###.00")
                        Me.txtYFDLF.Text = (dblJE * 0.0).ToString("#,###.00")
                    Case 2
                        Me.txtJFDLF.Text = (dblJE * 0.0).ToString("#,###.00")
                        Me.txtYFDLF.Text = (dblJE * 0.015).ToString("#,###.00")
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doComputeDLF = True
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_MM
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
                            strFWDZ = objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWDZ), "")
                        Else
                            strFWDZ = strFWDZ + strSep + objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWDZ), "")
                        End If

                        dblMJ += objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_MJ), 0.0)

                        dblJE += objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JYJE), 0.0)
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
        ' 获取要显示的主数据信息(确认书部分)
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_MAINQRS( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_MM
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_MAINQRS = False

            Try
                '检查
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_MAINQRS)

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_QRS_MM(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", Me.m_objDataSet_MAINQRS) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_MAINQRS = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取要显示的主数据信息(合同部分)
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_MAINHT( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_MAINHT = False

            Try
                '检查
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_MAINHT)

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", Me.m_objDataSet_MAINHT) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_MAINHT = True
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_MM
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
                        If objsystemEstateErshou.getDataSet_ES_WUYE_MM(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_WYXX) = False Then
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
                    If objsystemEstateErshou.getDataSet_ES_WUYE_MM(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_WYXX) = False Then
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_MM
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
        '     blnEnforced    ：强制重新显示
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改描述
        '     zengxianglin 2008-11-25 增加接口[blnEnforced]
        '----------------------------------------------------------------
        Private Function showEditPanel_MAIN( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            Optional ByVal blnEnforced As Boolean = False) As Boolean

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strTable As String = ""

            showEditPanel_MAIN = False
            strErrMsg = ""

            Try
                '显示值
                Dim strValue As String = ""
                Dim intValue As Integer = 0

                'zengxianglin 2008-11-25
                'If (Me.IsPostBack = False And Me.m_blnSaveScence = False) Then
                If (Me.IsPostBack = False And Me.m_blnSaveScence = False) Or blnEnforced = True Then
                    'zengxianglin 2008-11-25

                    strTable = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_MM
                    With Me.m_objDataSet_MAINQRS.Tables(strTable)
                        If .Rows.Count < 1 Then
                            '设置空值
                            Me.ddlJFZJLB.SelectedIndex = -1
                            Me.ddlYFZJLB.SelectedIndex = -1
                            '*****************************************************************************************************************
                            Me.rblTGFKYD.SelectedIndex = -1
                            Me.rblJLZKYD.SelectedIndex = -1
                            Me.rblJLRQYD.SelectedIndex = -1
                            Me.rblSFZFYD.SelectedIndex = -1
                            '*****************************************************************************************************************
                            Me.htxtWYBS.Value = ""
                            Me.htxtQRSH.Value = ""
                            Me.htxtDGRQ.Value = ""
                            Me.txtFWDZ.Text = ""
                            Me.txtJLRQ.Text = ""
                            Me.txtJYZMJ.Text = ""
                            Me.txtJYZJG.Text = ""
                            Me.txtJFDLF.Text = ""
                            Me.txtYFDLF.Text = ""
                            Me.txtDLFZK.Text = ""
                            Me.txtBZXX.Text = ""
                            '*****************************************************************************************************************
                            Me.txtJFDLR.Text = ""
                            Me.txtJFLXDH.Text = ""
                            Me.txtJFLXDZ.Text = ""
                            Me.txtJFMC.Text = ""
                            Me.txtJFZZHM.Text = ""
                            '*****************************************************************************************************************
                            Me.txtYFDLR.Text = ""
                            Me.txtYFLXDH.Text = ""
                            Me.txtYFLXDZ.Text = ""
                            Me.txtYFMC.Text = ""
                            Me.txtYFZZHM.Text = ""
                            'zengxianglin 2010-12-28
                            Me.txtKYBH.Text = ""
                            Me.txtCCDZ.Text = ""
                            Me.txtCCF.Text = ""
                            Me.txtSSYJ.Text = ""
                            Me.txtHZYJ.Text = ""
                            Me.txtAJJG.Text = ""
                            Me.txtAJYH.Text = ""
                            Me.txtAJCS.Text = ""
                            Me.txtAJNX.Text = ""
                            Me.txtYZQN.Text = ""
                            Me.txtYYQT.Text = ""
                            Me.txtYZDY.Text = ""
                            Me.txtMJQN.Text = ""
                            Me.txtKYQT.Text = ""
                            Me.txtKHDY.Text = ""
                            Me.rblYZQC.SelectedIndex = -1
                            Me.rblYZLY.SelectedIndex = -1
                            Me.rblSHYX.SelectedIndex = -1
                            Me.rblSYWY.SelectedIndex = -1
                            Me.rblMJQC.SelectedIndex = -1
                            Me.rblKHLY.SelectedIndex = -1
                            Me.rblGMMD.SelectedIndex = -1
                            Me.rblFKFSYD.SelectedIndex = -1
                            'zengxianglin 2010-12-28
                        Else
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFZJLX), "")
                            Me.ddlJFZJLB.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJFZJLB, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFZJLX), "")
                            Me.ddlYFZJLB.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYFZJLB, strValue)
                            '*****************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_FKTGYD), "")
                            Me.rblTGFKYD.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblTGFKYD, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SFZFYD), "")
                            Me.rblSFZFYD.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZFYD, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JLZKYD), "")
                            Me.rblJLZKYD.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblJLZKYD, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JLRQYD), "")
                            Me.rblJLRQYD.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblJLRQYD, strValue)
                            '*****************************************************************************************************************
                            Me.htxtWYBS.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_WYBS), "")
                            Me.htxtQRSH.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_QRSH), "")
                            Me.htxtDGRQ.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_DGRQ), "", "yyyy-MM-dd")
                            '*****************************************************************************************************************
                            Me.txtFWDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_FWDZ), "")
                            Me.txtJFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFDLF), 0.0).ToString("#,###.00")
                            Me.txtYFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFDLF), 0.0).ToString("#,###.00")
                            Me.txtDLFZK.Text = (objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_DLFZK), 0.0) * 100).ToString("#.00")
                            Me.txtJYZJG.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JYZJG), 0.0).ToString("#,###.00")
                            Me.txtJYZMJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JYZMJ), 0.0).ToString("#,###.00")
                            Me.txtJLRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JHJLRQ), "", "yyyy-MM-dd")
                            Me.txtBZXX.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_BZXX), "")
                            '*****************************************************************************************************************
                            Me.txtJFDLR.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFDLR), "")
                            Me.txtJFLXDH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFLXDH), "")
                            Me.txtJFLXDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFLXDZ), "")
                            Me.txtJFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFMC), "")
                            Me.txtJFZZHM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFZZHM), "")
                            '*****************************************************************************************************************
                            Me.txtYFDLR.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFDLR), "")
                            Me.txtYFLXDH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFLXDH), "")
                            Me.txtYFLXDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFLXDZ), "")
                            Me.txtYFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFMC), "")
                            Me.txtYFZZHM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFZZHM), "")

                            'zengxianglin 2010-12-28
                            Me.txtKYBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_KYBH), "")
                            Me.txtCCDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_CCDZ), "")
                            Me.txtCCF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_CCF), 0.0).ToString("#,##0.00")
                            Me.txtSSYJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SSYJ), 0.0).ToString("#,##0.00")
                            Me.txtHZYJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_HZYJ), 0.0).ToString("#,##0.00")
                            Me.txtAJJG.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_AJJG), "")
                            Me.txtAJYH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_AJYH), "")
                            Me.txtAJCS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_AJCS), 0.0).ToString("#,##0.00")
                            Me.txtAJNX.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_AJNX), 0.0).ToString("#,##0.00")
                            Me.txtYZQN.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YZQN), "")
                            Me.txtYYQT.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YYQT), "")
                            Me.txtYZDY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YZDY), "")
                            Me.txtMJQN.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_MJQN), "")
                            Me.txtKYQT.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_KYQT), "")
                            Me.txtKHDY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_KHDY), "")
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YZQC), "")
                            Me.rblYZQC.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYZQC, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YZLY), "")
                            Me.rblYZLY.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYZLY, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SHYX), "")
                            Me.rblSHYX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSHYX, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SYWY), "")
                            Me.rblSYWY.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSYWY, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_MJQC), "")
                            Me.rblMJQC.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblMJQC, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_KHLY), "")
                            Me.rblKHLY.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblKHLY, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_GMMD), "")
                            Me.rblGMMD.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblGMMD, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_FKFSYD), "")
                            Me.rblFKFSYD.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblFKFSYD, strValue)
                            'zengxianglin 2010-12-28
                        End If
                    End With

                    '填充合同信息
                    strTable = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG
                    With Me.m_objDataSet_MAINHT.Tables(strTable)
                        If .Rows.Count < 1 Then
                            Me.htxtHTWYBS.Value = ""
                            Me.htxtHTZT.Value = ""
                            Me.txtHTBH.Text = ""
                            Me.txtHTRQ.Text = ""
                            'zengxianglin 2008-11-22
                            Me.txtTJRQ.Text = ""
                            'zengxianglin 2008-11-22
                            'zengxianglin 2008-11-25
                            Me.txtAJFH.Text = ""
                            'zengxianglin 2008-11-25
                            Me.ddlFKFS.SelectedIndex = -1
                            'zengxianglin 2010-12-28
                            Me.htxtHTBZ.Value = ""
                            Me.txtJCRQ.Text = ""
                            Me.txtHZRQ.Text = ""
                            Me.txtHZJE.Text = ""
                            Me.chkHTHZ.Checked = False
                            Me.chkHTJC.Checked = False
                            'zengxianglin 2010-12-28
                        Else
                            Me.htxtHTWYBS.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_WYBS), "")
                            Me.htxtHTZT.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTZT), "")
                            Me.txtHTBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH), "")
                            Me.txtHTRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTRQ), "", "yyyy-MM-dd")
                            'zengxianglin 2008-11-22
                            Me.txtTJRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_TJRQ), "", "yyyy-MM-dd")
                            'zengxianglin 2008-11-22
                            'zengxianglin 2008-11-25
                            Me.txtAJFH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_AJFH), "", "#,##0.00", True)
                            'zengxianglin 2008-11-25
                            Me.txtBZXX.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BZXX), "")
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FKFS), "")
                            Me.ddlFKFS.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlFKFS, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTLX), "")
                            Me.rblHTLX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblHTLX, strValue)
                            'zengxianglin 2010-12-28
                            Me.htxtHTBZ.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBZ), "")
                            Me.txtJCRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JCRQ), "", "yyyy-MM-dd")
                            Me.txtHZRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HZRQ), "", "yyyy-MM-dd")
                            Me.txtHZJE.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HZJE), "", "#,##0.00", True)
                            intValue = objPulicParameters.getObjectValue(Me.htxtHTBZ.Value, 0)
                            If (intValue And &H1) = &H1 Then Me.chkHTJC.Checked = True
                            If (intValue And &H2) = &H2 Then Me.chkHTHZ.Checked = True
                            'zengxianglin 2010-12-28
                        End If
                    End With

                    'zengxianglin 2008-11-25
                    Select Case Me.m_objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '设置初始值
                            If objsystemEstateErshou.getNewHTBH_MM(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtHTBH.Text) = False Then
                                GoTo errProc
                            End If
                            Me.txtTJRQ.Text = Now.ToString("yyyy-MM-dd")
                            'zengxianglin 2010-12-28
                            'Me.txtJFDLF.Text = ""
                            'Me.txtYFDLF.Text = ""
                            'zengxianglin 2010-12-28
                    End Select
                    'zengxianglin 2008-11-25
                End If

                '操作控制
                '*****************************************************************************************************************
                objControlProcess.doEnabledControl(Me.ddlJFZJLB, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlYFZJLB, blnEditMode)
                '*****************************************************************************************************************
                objControlProcess.doEnabledControl(Me.rblTGFKYD, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblJLZKYD, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblJLRQYD, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSFZFYD, blnEditMode)
                '*****************************************************************************************************************
                objControlProcess.doEnabledControl(Me.txtFWDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJYZJG, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFDLF, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFDLF, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtDLFZK, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJYZMJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJLRQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBZXX, blnEditMode)
                '*****************************************************************************************************************
                objControlProcess.doEnabledControl(Me.txtJFDLR, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFLXDH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFLXDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFMC, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFZZHM, blnEditMode)
                '*****************************************************************************************************************
                objControlProcess.doEnabledControl(Me.txtYFDLR, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFLXDH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFLXDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFMC, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFZZHM, blnEditMode)
                '*****************************************************************************************************************
                'zengxianglin 2008-11-27
                objControlProcess.doEnabledControl(Me.txtHTBH, False)
                'zengxianglin 2008-11-27
                objControlProcess.doEnabledControl(Me.txtHTRQ, blnEditMode)
                'zengxianglin 2008-11-22
                objControlProcess.doEnabledControl(Me.txtTJRQ, False)
                'zengxianglin 2008-11-22
                'zengxianglin 2008-11-25
                objControlProcess.doEnabledControl(Me.txtAJFH, False)
                'zengxianglin 2008-11-25
                objControlProcess.doEnabledControl(Me.ddlFKFS, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblHTLX, blnEditMode)
                '*****************************************************************************************************************
                'zengxianglin 2010-12-28
                objControlProcess.doEnabledControl(Me.txtKYBH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtCCDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtCCF, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSSYJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtHZYJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtAJJG, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtAJYH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtAJCS, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtAJNX, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYZQN, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYYQT, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYZDY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtMJQN, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtKYQT, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtKHDY, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblYZQC, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblYZLY, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSHYX, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSYWY, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblMJQC, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblKHLY, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblGMMD, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblFKFSYD, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJCRQ, False)
                objControlProcess.doEnabledControl(Me.txtHZRQ, False)
                objControlProcess.doEnabledControl(Me.txtHZJE, False)
                objControlProcess.doEnabledControl(Me.chkHTJC, False)
                objControlProcess.doEnabledControl(Me.chkHTHZ, False)
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

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
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

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            showModuleData_MAIN = False

            Try
                Me.btnOK.Visible = blnEditMode
                Me.btnCancel.Visible = blnEditMode

                Me.btnClose.Visible = Not blnEditMode
                Me.btnFPBL.Visible = Not blnEditMode
                Me.btnSHQK.Visible = Not blnEditMode
                Me.btnSJSZ.Visible = Not blnEditMode
                Me.btnYSYF.Visible = Not blnEditMode
                Me.btnSZTZ.Visible = Not blnEditMode
                Me.btnJSQK.Visible = Not blnEditMode
                Me.btnBAQK.Visible = Not blnEditMode
                Me.btnHTJA.Visible = Not blnEditMode
                'zengxianglin 2008-11-25
                Dim blnComplete As Boolean = False
                If objsystemEstateErshou.isHetongComplete(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, blnComplete) = False Then
                End If
                Me.btnAJFH.Visible = Not blnEditMode And Me.m_blnPrevilegeParams(12) And blnComplete = False
                'zengxianglin 2008-11-25
                'zengxianglin 2010-12-30
                Me.btnJCHT.Visible = (Not blnEditMode) And (Me.m_blnPrevilegeParams(14))
                Me.btnBJHZ.Visible = (Not blnEditMode) And (Me.m_blnPrevilegeParams(15))
                'zengxianglin 2010-12-30
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            showModuleData_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充付款方式下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：添加空白条目
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillFkfsList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillFkfsList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillFkfsList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                'Dim strWhere As String = "a." + Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX + " <> 1"
                Dim strWhere As String = ""
                If objsystemEstateCommon.getDataSet_YingshouYingfuMoban(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateCommonData) = False Then
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
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC), "")

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

            doFillFkfsList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
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
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.ddlJFZJLB)
                    objControlProcess.doTranslateKey(Me.ddlYFZJLB)
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtFWDZ)
                    objControlProcess.doTranslateKey(Me.txtJYZJG)
                    objControlProcess.doTranslateKey(Me.txtJFDLF)
                    objControlProcess.doTranslateKey(Me.txtYFDLF)
                    objControlProcess.doTranslateKey(Me.txtDLFZK)
                    objControlProcess.doTranslateKey(Me.txtJYZMJ)
                    objControlProcess.doTranslateKey(Me.txtJLRQ)
                    objControlProcess.doTranslateKey(Me.txtBZXX)
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtJFDLR)
                    objControlProcess.doTranslateKey(Me.txtJFLXDH)
                    objControlProcess.doTranslateKey(Me.txtJFLXDZ)
                    objControlProcess.doTranslateKey(Me.txtJFMC)
                    objControlProcess.doTranslateKey(Me.txtJFZZHM)
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtYFDLR)
                    objControlProcess.doTranslateKey(Me.txtYFLXDH)
                    objControlProcess.doTranslateKey(Me.txtYFLXDZ)
                    objControlProcess.doTranslateKey(Me.txtYFMC)
                    objControlProcess.doTranslateKey(Me.txtYFZZHM)
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtHTBH)
                    objControlProcess.doTranslateKey(Me.txtHTRQ)
                    'zengxianglin 2008-11-22
                    objControlProcess.doTranslateKey(Me.txtTJRQ)
                    'zengxianglin 2008-11-22
                    'zengxianglin 2008-11-25
                    objControlProcess.doTranslateKey(Me.txtAJFH)
                    'zengxianglin 2008-11-25
                    objControlProcess.doTranslateKey(Me.ddlFKFS)
                    '*****************************************************************************************************************
                    'zengxianglin 2010-12-27
                    objControlProcess.doTranslateKey(Me.txtKYBH)
                    objControlProcess.doTranslateKey(Me.txtCCDZ)
                    objControlProcess.doTranslateKey(Me.txtCCF)
                    objControlProcess.doTranslateKey(Me.txtSSYJ)
                    objControlProcess.doTranslateKey(Me.txtHZYJ)
                    objControlProcess.doTranslateKey(Me.txtAJJG)
                    objControlProcess.doTranslateKey(Me.txtAJYH)
                    objControlProcess.doTranslateKey(Me.txtAJCS)
                    objControlProcess.doTranslateKey(Me.txtAJNX)
                    objControlProcess.doTranslateKey(Me.txtYZQN)
                    objControlProcess.doTranslateKey(Me.txtYYQT)
                    objControlProcess.doTranslateKey(Me.txtYZDY)
                    objControlProcess.doTranslateKey(Me.txtMJQN)
                    objControlProcess.doTranslateKey(Me.txtKYQT)
                    objControlProcess.doTranslateKey(Me.txtKHDY)
                    objControlProcess.doTranslateKey(Me.txtJCRQ)
                    objControlProcess.doTranslateKey(Me.txtHZRQ)
                    objControlProcess.doTranslateKey(Me.txtHZJE)
                    'zengxianglin 2010-12-27

                    If Me.getModuleData_MAINQRS(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_MAINHT(strErrMsg, Me.m_strQRSH) = False Then
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

                    'zengxianglin 2008-11-25
                    '设初始数据
                    'If Me.m_blnSaveScence = False Then
                    '    Select Case Me.m_objenumEditType
                    '        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                    '            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                    '            Me.txtHTRQ.Text = Now.ToString("yyyy-MM-dd")
                    '            If Me.doComputeDLF(strErrMsg) = False Then
                    '                '忽略
                    '            End If
                    '        Case Else
                    '    End Select
                    'End If
                    'zengxianglin 2008-11-25
                Else
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
            Dim blnDo As Boolean = False

            Try
                '预处理
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                'zengxianglin 2008-11-25
                '计算权限
                If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-25

                '填充列表
                If Me.IsPostBack = False Then
                    If Me.doFillFkfsList(strErrMsg, Me.ddlFKFS, False) = False Then
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_MM
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
                    Me.txtJYZJG.Text = dblJE.ToString("#,###.00")
                    'zengxianglin 2008-11-25
                    'If Me.doComputeDLF(strErrMsg) = False Then
                    '    '忽略
                    'End If
                    'zengxianglin 2008-11-25
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
                If Me.txtHTRQ.Text.Trim = "" Then
                    strErrMsg = "错误：请先输入[合同日期]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtHTRQ.Text) = False Then
                    strErrMsg = "错误：无效的[合同日期]！"
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
            Dim objNewDataQRS As New System.Collections.Specialized.NameValueCollection
            Dim objNewDataHT As New System.Collections.Specialized.NameValueCollection
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strQRSH As String = ""
            Dim strHTBH As String = ""

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
                If Me.rblHTLX.SelectedIndex < 0 Then
                    strErrMsg = "错误：必须指定合同类型！"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-25
                If Me.txtJFDLF.Text.Trim = "" Then
                    strErrMsg = "错误：必须指定[甲方代理费]！"
                    GoTo errProc
                End If
                If Me.txtYFDLF.Text.Trim = "" Then
                    strErrMsg = "错误：必须指定[乙方代理费]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-25

                Dim intValue As Integer = 0
                Dim dblValue As Double = 0
                '准备接口数据(确认书部分)
                objNewDataQRS.Clear()
                '********************************************************************************************************************
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_WYBS, Me.htxtWYBS.Value.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_QRSH, Me.htxtQRSH.Value.Trim)
                '********************************************************************************************************************
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_FWDZ, Me.txtFWDZ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JYZJG, Me.txtJYZJG.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JYZMJ, Me.txtJYZMJ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFDLF, Me.txtJFDLF.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFDLF, Me.txtYFDLF.Text.Trim)
                dblValue = objPulicParameters.getObjectValue(Me.txtDLFZK.Text, 0.0) / 100.0
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_DLFZK, dblValue.ToString("#.00"))
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JHJLRQ, Me.txtJLRQ.Text)
                '********************************************************************************************************************
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFDLR, Me.txtJFDLR.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFLXDH, Me.txtJFLXDH.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFLXDZ, Me.txtJFLXDZ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFMC, Me.txtJFMC.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFZZHM, Me.txtJFZZHM.Text.Trim)
                '********************************************************************************************************************
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFDLR, Me.txtYFDLR.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFLXDH, Me.txtYFLXDH.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFLXDZ, Me.txtYFLXDZ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFMC, Me.txtYFMC.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFZZHM, Me.txtYFZZHM.Text.Trim)
                '********************************************************************************************************************
                If Me.rblTGFKYD.SelectedIndex > 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_FKTGYD, Me.rblTGFKYD.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_FKTGYD, "0")
                End If
                '********************************************************************************************************************
                If Me.rblJLRQYD.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JLRQYD, Me.rblJLRQYD.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JLRQYD, "0")
                End If
                '********************************************************************************************************************
                If Me.rblSFZFYD.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SFZFYD, Me.rblSFZFYD.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SFZFYD, "0")
                End If
                '********************************************************************************************************************
                If Me.rblJLZKYD.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JLZKYD, Me.rblJLZKYD.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JLZKYD, "0")
                End If
                '********************************************************************************************************************
                If Me.ddlJFZJLB.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFZJLX, Me.ddlJFZJLB.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFZJLX, "0")
                End If
                '********************************************************************************************************************
                If Me.ddlYFZJLB.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFZJLX, Me.ddlYFZJLB.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFZJLX, "0")
                End If
                '********************************************************************************************************************
                'zengxianglin 2010-12-27
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_KYBH, Me.txtKYBH.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_CCDZ, Me.txtCCDZ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_CCF, Me.txtCCF.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SSYJ, Me.txtSSYJ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_HZYJ, Me.txtHZYJ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_AJJG, Me.txtAJJG.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_AJYH, Me.txtAJYH.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_AJCS, Me.txtAJCS.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_AJNX, Me.txtAJNX.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YZQN, Me.txtYZQN.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YYQT, Me.txtYYQT.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YZDY, Me.txtYZDY.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_MJQN, Me.txtMJQN.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_KYQT, Me.txtKYQT.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_KHDY, Me.txtKHDY.Text.Trim)
                If Me.rblYZQC.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YZQC, Me.rblYZQC.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YZQC, "")
                End If
                If Me.rblYZLY.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YZLY, Me.rblYZLY.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YZLY, "")
                End If
                If Me.rblSHYX.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SHYX, Me.rblSHYX.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SHYX, "")
                End If
                If Me.rblSYWY.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SYWY, Me.rblSYWY.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_SYWY, "")
                End If
                If Me.rblMJQC.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_MJQC, Me.rblMJQC.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_MJQC, "")
                End If
                If Me.rblKHLY.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_KHLY, Me.rblKHLY.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_KHLY, "")
                End If
                If Me.rblGMMD.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_GMMD, Me.rblGMMD.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_GMMD, "")
                End If
                If Me.rblFKFSYD.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_FKFSYD, Me.rblFKFSYD.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_FKFSYD, "")
                End If
                'zengxianglin 2010-12-27

                '准备接口数据(合同部分)
                objNewDataHT.Clear()
                '********************************************************************************************************************
                '本界面未处理的数据
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_DJRDM, MyBase.UserId)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_DJRMC, MyBase.UserZM)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_DJRQ, Now.ToString("yyyy-MM-dd"))
                '********************************************************************************************************************
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_WYBS, Me.htxtHTWYBS.Value.Trim)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_QRSH, Me.htxtQRSH.Value.Trim)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTZT, Me.htxtHTZT.Value.Trim)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH, Me.txtHTBH.Text.Trim)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTRQ, Me.txtHTRQ.Text.Trim)
                'zengxianglin 2008-11-22
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_TJRQ, Me.txtTJRQ.Text.Trim)
                'zengxianglin 2008-11-22
                'zengxianglin 2008-11-25
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_AJFH, Me.txtAJFH.Text.Trim)
                'zengxianglin 2008-11-25
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BZXX, Me.txtBZXX.Text.Trim)
                '********************************************************************************************************************
                If Me.rblHTLX.SelectedIndex >= 0 Then
                    objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTLX, Me.rblHTLX.SelectedValue)
                Else
                    objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTLX, "0")
                End If
                '********************************************************************************************************************
                If Me.ddlFKFS.SelectedIndex >= 0 Then
                    objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FKFS, Me.ddlFKFS.SelectedValue)
                Else
                    objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FKFS, "")
                End If

                '获取确认书数据
                If Me.getModuleData_MAINQRS(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If
                '保存数据
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        objNewDataHT(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTZT) = CType(Josco.JSOA.Common.Data.estateErshouData.enumHetongStatus.Weishen, Integer).ToString
                        'zengxianglin 2008-11-27
                        objNewDataHT(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_WYBS) = ""
                        objNewDataHT(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH) = ""
                        'zengxianglin 2008-11-27
                        If objsystemEstateErshou.doSaveData_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                            Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_MM, _
                            objNewDataHT, Nothing, _
                            objNewDataQRS, _
                            Me.m_objDataSet_MAINQRS.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_MM).Rows(0), _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Me.m_objDataSet_WYXX, Me.m_objDataSet_YWRY) = False Then
                            GoTo errProc
                        End If
                        '记录审计日志
                        strHTBH = objNewDataHT(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH)
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[二手_合同]中增加了[" + strHTBH + "]！")

                    Case Else
                        '获取数据
                        If Me.getModuleData_MAINHT(strErrMsg, Me.m_strQRSH) = False Then
                            GoTo errProc
                        End If
                        '保存数据
                        Dim objDataRow As System.Data.DataRow = Nothing
                        With Me.m_objDataSet_MAINHT.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG)
                            If .Rows.Count < 1 Then
                                strErrMsg = "错误：没有合同！"
                                GoTo errProc
                            Else
                                objDataRow = .Rows(0)
                            End If
                        End With
                        If objsystemEstateErshou.doSaveData_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                            Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_MM, _
                            objNewDataHT, objDataRow, _
                            objNewDataQRS, _
                            Me.m_objDataSet_MAINQRS.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_MM).Rows(0), _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, _
                            Me.m_objDataSet_WYXX, Me.m_objDataSet_YWRY) = False Then
                            GoTo errProc
                        End If
                        '记录审计日志
                        strHTBH = objNewDataQRS(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH)
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[二手_合同]中[修改]了[" + strHTBH + "]！")
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
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewDataQRS)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewDataHT)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewDataQRS)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewDataHT)
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
                If Me.htxtQRSH.Value.Trim = "" Then
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
                Dim objIEstateCwYsyf As Josco.JSOA.BusinessFacade.IEstateCwYsyf = Nothing
                Dim strUrl As String = ""
                objIEstateCwYsyf = New Josco.JSOA.BusinessFacade.IEstateCwYsyf
                With objIEstateCwYsyf
                    .iQRSH = Me.htxtQRSH.Value
                    .iCanModify = True
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
                If Me.htxtQRSH.Value.Trim = "" Then
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
                    .iQRSH = Me.htxtQRSH.Value
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
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBS, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBM, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_QRSH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_QRSH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_MJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_MJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JYJE)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JYJE, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JG, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LL, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQY, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQYMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQYMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_BZXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_BZXX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZDZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWDZ, strValue)

                'zengxianglin 2010-12-26
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FYBH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FYBH, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LP)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LP, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LD)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LD, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DY, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JCSJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JCSJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_KJLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_KJLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWXZ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXDC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXDC, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXNX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXNX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZYYX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZYYX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JJSB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JJSB, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LYJT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LYJT, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWJG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWJG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGFS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGFS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WSSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WSSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_YTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_YTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_HYMJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_HYMJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LCHS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LCHS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LPQS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LPQS, strValue)
                'zengxianglin 2010-12-26

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateEsQrsMmWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsMmWuye = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsMmWuye = New Josco.JSOA.BusinessFacade.IEstateEsQrsMmWuye
                With objIEstateEsQrsMmWuye
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iRowNo = Me.grdWYXX.SelectedIndex
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsQrsMmWuye)
                strUrl = ""
                strUrl += "estate_es_qrsmm_wuye.aspx"
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
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBS, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYBM, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_QRSH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_QRSH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_MJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_MJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JYJE)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JYJE, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JG, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LL, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXZMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQY, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQYMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_SZQYMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_BZXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_BZXX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FCZDZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWDZ, strValue)

                'zengxianglin 2010-12-26
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WYXX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FYBH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FYBH, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LP)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LP, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LD)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LD, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DY, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JCSJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JCSJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_KJLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_KJLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWXZ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXDC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXDC, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXNX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZXNX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZYYX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_ZYYX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JJSB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JJSB, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LYJT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LYJT, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWJG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_FWJG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGFS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_JGFS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WSSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_WSSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_YTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_YTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_HYMJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_HYMJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_DTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LCHS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LCHS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LPQS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_MM_LPQS, strValue)
                'zengxianglin 2010-12-26

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateEsQrsMmWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsMmWuye = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsMmWuye = New Josco.JSOA.BusinessFacade.IEstateEsQrsMmWuye
                With objIEstateEsQrsMmWuye
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iRowNo = Me.grdWYXX.SelectedIndex
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsQrsMmWuye)
                strUrl = ""
                strUrl += "estate_es_qrsmm_wuye.aspx"
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
                Dim objIEstateEsQrsMmWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsMmWuye = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsMmWuye = New Josco.JSOA.BusinessFacade.IEstateEsQrsMmWuye
                With objIEstateEsQrsMmWuye
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsQrsMmWuye)
                strUrl = ""
                strUrl += "estate_es_qrsmm_wuye.aspx"
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

        Private Sub doOpen_FPBL(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.htxtQRSH.Value.Trim = "" Then
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
                Dim objIEstateEsHetongFpbl As Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongFpbl = New Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl
                With objIEstateEsHetongFpbl
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsHetongFpbl)
                strUrl = ""
                strUrl += "estate_es_hetong_fpbl.aspx"
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

        Private Sub doOpen_SHQK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.htxtQRSH.Value.Trim = "" Then
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
                Dim objIEstateEsHetongSh As Josco.JSOA.BusinessFacade.IEstateEsHetongSh = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongSh = New Josco.JSOA.BusinessFacade.IEstateEsHetongSh
                With objIEstateEsHetongSh
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsHetongSh)
                strUrl = ""
                strUrl += "estate_es_hetong_sh.aspx"
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

        Private Sub doOpen_BAQK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.htxtQRSH.Value.Trim = "" Then
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
                Dim objIEstateEsHetongBl As Josco.JSOA.BusinessFacade.IEstateEsHetongBl = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongBl = New Josco.JSOA.BusinessFacade.IEstateEsHetongBl
                With objIEstateEsHetongBl
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsHetongBl)
                strUrl = ""
                strUrl += "estate_es_hetong_bl.aspx"
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

        Private Sub doOpen_SZTZ(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.htxtQRSH.Value.Trim = "" Then
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
                Dim objIEstateCwSztz As Josco.JSOA.BusinessFacade.IEstateCwSztz = Nothing
                Dim strUrl As String = ""
                objIEstateCwSztz = New Josco.JSOA.BusinessFacade.IEstateCwSztz
                With objIEstateCwSztz
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateCwSztz)
                strUrl = ""
                strUrl += "../caiwu/estate_cw_sztz.aspx"
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

        Private Sub doOpen_JSQK(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.htxtQRSH.Value.Trim = "" Then
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
                Dim objIEstateEsHetongJssList As Josco.JSOA.BusinessFacade.IEstateEsHetongJssList = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongJssList = New Josco.JSOA.BusinessFacade.IEstateEsHetongJssList
                With objIEstateEsHetongJssList
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsHetongJssList)
                strUrl = ""
                strUrl += "estate_es_hetong_jss_list.aspx"
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

        Private Sub doOpen_HTJA(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.htxtQRSH.Value.Trim = "" Then
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
                Dim objIEstateEsHetongWc As Josco.JSOA.BusinessFacade.IEstateEsHetongWc = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongWc = New Josco.JSOA.BusinessFacade.IEstateEsHetongWc
                With objIEstateEsHetongWc
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsHetongWc)
                strUrl = ""
                strUrl += "estate_es_hetong_wc.aspx"
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

        'zengxianglin 2008-11-25
        Private Sub doAJFH(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '检查
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "错误：没有[确认书]！"
                    GoTo errProc
                End If

                intStep = 1
                '输入信息
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doInputBox(Me.popMessageObject, "请输入按揭返回的金额：", strControlId, intStep)
                    Exit Try
                End If

                intStep = 2
                '处理
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取输入参数
                    Dim strAJFH As String = ""
                    Dim dblAJFH As Double = 0
                    strAJFH = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
                    '检查输入参数
                    If strAJFH = "" Then
                        strErrMsg = "错误：没有输入数字！"
                        GoTo errProc
                    End If
                    If objPulicParameters.isFloatString(strAJFH) = False Then
                        strErrMsg = "错误：[" + strAJFH + "]是无效的数字！"
                        GoTo errProc
                    End If
                    dblAJFH = objPulicParameters.getObjectValue(strAJFH, 0.0)
                    '处理
                    If objsystemEstateErshou.doUpdateData_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtQRSH.Value, dblAJFH) = False Then
                        GoTo errProc
                    End If
                    '显示
                    If Me.getModuleData_MAINQRS(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_MAINHT(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode, True) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        Private Sub btnAJFH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAJFH.Click
            Me.doAJFH("btnAJFH")
        End Sub
        'zengxianglin 2008-11-25

        'zengxianglin 2010-12-30
        Private Sub doJCHT(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '检查
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "错误：没有[确认书]！"
                    GoTo errProc
                End If
                If Me.txtJCRQ.Text.Trim <> "" Then
                    strErrMsg = "错误：合同已经解除了！"
                    GoTo errProc
                End If

                intStep = 1
                '确认信息
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：您确定要解除本合同吗（确定/取消）？", strControlId, intStep)
                    Exit Try
                End If

                intStep = 2
                '处理
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '处理
                    If objsystemEstateErshou.doMarkJiechu_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtQRSH.Value) = False Then
                        GoTo errProc
                    End If
                    '显示
                    If Me.getModuleData_MAINQRS(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_MAINHT(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode, True) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        Private Sub btnJCHT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJCHT.Click
            Me.doJCHT("btnJCHT")
        End Sub
        'zengxianglin 2010-12-30

        'zengxianglin 2010-12-30
        Private Sub doBJHZ(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '检查
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "错误：没有[确认书]！"
                    GoTo errProc
                End If
                If Me.txtHZRQ.Text.Trim <> "" Then
                    strErrMsg = "错误：合同已经标记了坏账！"
                    GoTo errProc
                End If

                intStep = 1
                '输入信息
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doInputBox(Me.popMessageObject, "请输入合同确定的坏账金额：", strControlId, intStep)
                    Exit Try
                End If

                intStep = 2
                '处理
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取输入参数
                    Dim strHZJE As String = ""
                    Dim dblHZJE As Double = 0
                    strHZJE = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
                    '检查输入参数
                    If strHZJE = "" Then
                        strErrMsg = "错误：没有输入数字！"
                        GoTo errProc
                    End If
                    If objPulicParameters.isFloatString(strHZJE) = False Then
                        strErrMsg = "错误：[" + strHZJE + "]是无效的数字！"
                        GoTo errProc
                    End If
                    dblHZJE = objPulicParameters.getObjectValue(strHZJE, 0.0)
                    '处理
                    If objsystemEstateErshou.doMarkHuaizhang_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtQRSH.Value, dblHZJE) = False Then
                        GoTo errProc
                    End If
                    '显示
                    If Me.getModuleData_MAINQRS(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_MAINHT(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode, True) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        Private Sub btnBJHZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBJHZ.Click
            Me.doBJHZ("btnBJHZ")
        End Sub
        'zengxianglin 2010-12-30

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

        Private Sub btnSZTZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSZTZ.Click
            Me.doOpen_SZTZ("btnSZTZ")
        End Sub

        Private Sub btnJSQK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSQK.Click
            Me.doOpen_JSQK("btnJSQK")
        End Sub

        Private Sub btnSJSZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSJSZ.Click
            Me.doOpen_SSSF("btnSJSZ")
        End Sub

        Private Sub btnFPBL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFPBL.Click
            Me.doOpen_FPBL("btnFPBL")
        End Sub

        Private Sub btnSHQK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSHQK.Click
            Me.doOpen_SHQK("btnSHQK")
        End Sub

        Private Sub btnBAQK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBAQK.Click
            Me.doOpen_BAQK("btnBAQK")
        End Sub

        Private Sub btnHTJA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHTJA.Click
            Me.doOpen_HTJA("btnHTJA")
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
