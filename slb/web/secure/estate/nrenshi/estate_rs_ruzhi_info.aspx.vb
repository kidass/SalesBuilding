Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_ruzhi_info
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　人事录用审批单信息处理
    '     新建时，保存完成后自动更改输入接口的iWJBS和iEditMode并等待用户后续操作
    '         如果取消，则直接返回上级。
    '     编辑时，无论保存或取消均等待用户后续操作
    '
    ' 接口参数：
    '     参见接口类IEstateRsLuyongInfo描述
    '----------------------------------------------------------------

    Partial Class estate_rs_ruzhi_info
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
        Private m_cstrRelativePathToImage As String = "../../"
        '文件下载后的缓存路径
        Private m_cstrUrlBaseToFileCache As String = "/temp/filecache/"
        '标准稿件模板目录
        Private m_cstrUrlBaseToWordTemplate As String = "/template/word/"
        '应用根相对ziyuan/image/rskp的相对路径
        Private m_cstrPathRootToRskpImage As String = "ziyuan/image/rskp/"
        '应用根相对ziyuan/image/rskp的相对路径
        Private m_cstrPathRootToGrllImage As String = "ziyuan/image/grll/"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_ruzhi_sp_previlege_param"
        Private m_blnPrevilegeParams(3) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsRuZhiInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数(稿件、正文、附件、相关文件统一事务处理)
        '----------------------------------------------------------------
        Private m_objsystemFlowObjectRenshiRuZhi As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi
        Private m_objDataSet_FJ As Josco.JSOA.Common.Data.FlowData
        Private m_strSessionID_FJ As String
        Private m_objDataSet_XGWJ As Josco.JSOA.Common.Data.FlowData
        Private m_strSessionID_XGWJ As String
        Private m_objDataSet_RYXX As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_strSessionID_RYXX As String

        '----------------------------------------------------------------
        '与数据网格grdFJ相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_FJ As String = "chkFJ"
        Private Const m_cstrDataGridInDIV_FJ As String = "divFJ"
        Private m_intFixedColumns_FJ As Integer

        '----------------------------------------------------------------
        '与数据网格grdXGWJ相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_XGWJ As String = "chkXGWJ"
        Private Const m_cstrDataGridInDIV_XGWJ As String = "divXGWJ"
        Private m_intFixedColumns_XGWJ As Integer

        '----------------------------------------------------------------
        '与数据网格grdRYXX相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_RYXX As String = "chkRYXX"
        Private Const m_cstrDataGridInDIV_RYXX As String = "divRYXX"
        Private m_intFixedColumns_RYXX As Integer

        '----------------------------------------------------------------
        '模块其他参数
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_blnEditMode As Boolean
        Private m_blnSPMode As Boolean
        Private m_blnTGMode As Boolean
        Private m_strGJFileName As String  '正文内容文件名称(纯文件名)
        Private m_blnEnforeEdit As Boolean '强制编辑模式
        Private m_blnRZ As Boolean = False

        Public ReadOnly Property propEditMode() As Boolean
            Get
                propEditMode = Me.m_blnEditMode
            End Get
        End Property

        Public ReadOnly Property propSPMode() As Boolean
            Get
                propSPMode = Me.m_blnSPMode
            End Get
        End Property

        Public ReadOnly Property propTGMode() As Boolean
            Get
                propTGMode = Me.m_blnTGMode
            End Get
        End Property




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
                If Me.m_blnPrevilegeParams(1) = True Then
                    blnContinueExecute = True
                    m_blnTGMode = True
                Else
                    m_blnTGMode = False
                End If

                If Me.m_blnSPMode = True Then
                    If m_blnEditMode = True Then
                        m_blnTGMode = False
                        m_blnSPMode = False
                    End If
                Else
                    m_blnTGMode = False
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo)
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
        ' 复原模块现场信息并释放相应的资源
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.txtJLBH.Text = .txtJLBH
                    Me.txtRYDM.Text = .txtRYDM
                    Me.txtRYXM.Text = .txtRYXM
                    Me.txtRYNN.Text = .txtRYNN
                    Me.txtNFPBM.Text = .txtNFPBM
                    'Me.txtNDRZW.Text = .txtNDRZW

                    Me.rblRYLX.SelectedIndex = .rblRYLX_SelectedIndex
                    Me.txtTDBH.Text = .txtTDBH
                    Me.txtLXDH.Text = .txtLXDH
                    Me.htxtBZXL.Value = .htxtBZXL
                    Me.htxtSSDW.Value = .htxtSSDW

                    Me.txtNBDRQ.Text = .txtNBDRQ
                    Me.txtZPSM.Text = .txtZPSM
                    Me.txtXYRYS.Text = .txtXYRYS
                    Me.txtDBRYS.Text = .txtDBRYS
                    Me.rblRYXB.SelectedIndex = .rblRYXB_SelectedIndex
                    Me.ddlXL.SelectedIndex = .ddlXL_SelectedIndex
                    Me.ddlZJDM.SelectedIndex = .ddlZJDM_SelectedIndex
                    Me.ddlYDYY.SelectedIndex = .ddlYDYY_SelectedIndex

                    Me.txtSFZHM.Text = .txtSFZHM
                    Me.txtBMJL.Text = .txtBMJL
                    Me.ddlZPQD.SelectedIndex = .ddlZPQD_SelectedIndex
                    Me.ddlZPSM.SelectedIndex = .ddlZPSM_SelectedIndex
                    Me.txtWLJNFS.Text = .txtWLJNFS
                    Me.txtSPSM.Text = .txtSPSM

                    Me.ddlJJCD.SelectedIndex = .ddlJJCD_SelectedIndex
                    Me.ddlMMDJ.SelectedIndex = .ddlMMDJ_SelectedIndex
                    Me.txtJGDZ.Text = .txtJGDZ
                    Me.txtWJNF.Text = .txtWJNF
                    Me.txtWJXH.Text = .txtWJXH
                    Me.txtWJBT.Text = .txtWJBT
                    'Me.txtDBRS.Text = .txtDBRS
                    Me.txtBZXX.Text = .txtBZXX
                    Me.chkDDSZ.Checked = .chkDDSZ_Checked
                    Me.txtJBDW.Text = .txtJBDW
                    Me.txtJBRY.Text = .txtJBRY
                    Me.txtJBRQ.Text = .txtJBRQ
                    Me.txtLSH.Text = .txtLSH
                    Me.htxtWJBS.Value = .htxtWJBS
                    Me.htxtRYXM.Value = .htxtRYXM

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftContent.Value = .htxtDivLeftContent
                    Me.htxtDivTopContent.Value = .htxtDivTopContent
                    Me.htxtDivLeftQFYJ.Value = .htxtDivLeftQFYJ
                    Me.htxtDivTopQFYJ.Value = .htxtDivTopQFYJ
                    Me.htxtDivLeftFHYJ.Value = .htxtDivLeftFHYJ
                    Me.htxtDivTopFHYJ.Value = .htxtDivTopFHYJ
                    Me.htxtDivLeftHQYJ.Value = .htxtDivLeftHQYJ
                    Me.htxtDivTopHQYJ.Value = .htxtDivTopHQYJ
                    Me.htxtDivLeftSHYJ.Value = .htxtDivLeftSHYJ
                    Me.htxtDivTopSHYJ.Value = .htxtDivTopSHYJ
                    Me.htxtDivLeftFJ.Value = .htxtDivLeftFJ
                    Me.htxtDivTopFJ.Value = .htxtDivTopFJ
                    Me.htxtDivLeftXGWJ.Value = .htxtDivLeftXGWJ
                    Me.htxtDivTopXGWJ.Value = .htxtDivTopXGWJ
                    Me.htxtDivLeftRYXX.Value = .htxtDivLeftRYXX
                    Me.htxtDivTopRYXX.Value = .htxtDivTopRYXX

                    Me.htxtEditMode.Value = .htxtEditMode
                    Me.htxtEditType.Value = .htxtEditType
                    Me.htxtZWNRFileName.Value = .htxtZWNRFileName
                    Me.htxtEnforeEdit.Value = .htxtEnforeEdit

                    Me.htxtSessionIDFJ.Value = .htxtSessionIDFJ
                    Me.htxtSessionIDXGWJ.Value = .htxtSessionIDXGWJ
                    Me.htxtSessionIDRYXX.Value = .htxtSessionIDRYXX

                    Me.htxtFJSort.Value = .htxtFJSort
                    Me.htxtFJSortColumnIndex.Value = .htxtFJSortColumnIndex
                    Me.htxtFJSortType.Value = .htxtFJSortType

                    Me.htxtXGWJSort.Value = .htxtXGWJSort
                    Me.htxtXGWJSortColumnIndex.Value = .htxtXGWJSortColumnIndex
                    Me.htxtXGWJSortType.Value = .htxtXGWJSortType

                    Me.htxtRYXXSort.Value = .htxtRYXXSort
                    Me.htxtRYXXSortColumnIndex.Value = .htxtRYXXSortColumnIndex
                    Me.htxtRYXXSortType.Value = .htxtRYXXSortType

                    Me.htxtSelectMenuID.Value = .htxtSelectMenuID

                    Try
                        Me.grdFJ.SelectedIndex = .grdFJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFJ.PageSize = .grdFJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFJ.CurrentPageIndex = .grdFJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Me.m_objDataSet_FJ = .objDataSet_FJ

                    Try
                        Me.grdXGWJ.SelectedIndex = .grdXGWJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXGWJ.PageSize = .grdXGWJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXGWJ.CurrentPageIndex = .grdXGWJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Me.m_objDataSet_XGWJ = .objDataSet_XGWJ

                    Try
                        Me.grdRYXX.SelectedIndex = .grdRYXX_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRYXX.PageSize = .grdRYXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRYXX.CurrentPageIndex = .grdRYXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Me.m_objDataSet_RYXX = .objDataSet_RYXX
                End With

                '释放资源
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

        End Sub

        '----------------------------------------------------------------
        ' 保存模块现场信息并返回相应的SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim strSessionId As String = ""
            Dim strErrMsg As String

            saveModuleInformation = ""

            Try
                '创建SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then Exit Try

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsRuZhiInfo

                '保存现场信息
                With Me.m_objSaveScence
                    .txtJLBH = Me.txtJLBH.Text
                    .txtRYDM = Me.txtRYDM.Text
                    .txtRYXM = Me.txtRYXM.Text
                    .txtRYNN = Me.txtRYNN.Text
                    .txtNFPBM = Me.txtNFPBM.Text
                    '.txtNDRZW = Me.txtNDRZW.Text
                    .txtNBDRQ = Me.txtNBDRQ.Text
                    .txtZPSM = Me.txtZPSM.Text
                    .txtXYRYS = Me.txtXYRYS.Text
                    .txtDBRYS = Me.txtDBRYS.Text
                    .rblRYXB_SelectedIndex = Me.rblRYXB.SelectedIndex
                    .ddlXL_SelectedIndex = Me.ddlXL.SelectedIndex
                    .ddlZJDM_SelectedIndex = Me.ddlZJDM.SelectedIndex
                    .ddlYDYY_SelectedIndex = Me.ddlYDYY.SelectedIndex


                    .rblRYLX_SelectedIndex = Me.rblRYLX.SelectedIndex
                    .txtTDBH = Me.txtTDBH.Text
                    .txtLXDH = Me.txtLXDH.Text
                    .htxtBZXL = Me.htxtBZXL.Value
                    .htxtSSDW = Me.htxtSSDW.Value

                    .txtSFZHM = Me.txtSFZHM.Text
                    .txtBMJL = Me.txtBMJL.Text
                    .ddlZPQD_SelectedIndex = Me.ddlZPQD.SelectedIndex
                    .ddlZPSM_SelectedIndex = Me.ddlZPSM.SelectedIndex
                    .txtWLJNFS = Me.txtWLJNFS.Text
                    .txtSPSM = Me.txtSPSM.Text

                    .ddlJJCD_SelectedIndex = Me.ddlJJCD.SelectedIndex
                    .ddlMMDJ_SelectedIndex = Me.ddlMMDJ.SelectedIndex
                    .txtJGDZ = Me.txtJGDZ.Text
                    .txtWJNF = Me.txtWJNF.Text
                    .txtWJXH = Me.txtWJXH.Text
                    .txtWJBT = Me.txtWJBT.Text
                    '.txtDBRS = Me.txtDBRS.Text
                    .txtBZXX = Me.txtBZXX.Text
                    .chkDDSZ_Checked = Me.chkDDSZ.Checked
                    .txtJBDW = Me.txtJBDW.Text
                    .txtJBRY = Me.txtJBRY.Text
                    .txtJBRQ = Me.txtJBRQ.Text
                    .txtLSH = Me.txtLSH.Text
                    .htxtWJBS = Me.htxtWJBS.Value
                    .htxtRYXM = Me.htxtRYXM.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftQFYJ = Me.htxtDivLeftQFYJ.Value
                    .htxtDivTopQFYJ = Me.htxtDivTopQFYJ.Value
                    .htxtDivLeftContent = Me.htxtDivLeftContent.Value
                    .htxtDivTopContent = Me.htxtDivTopContent.Value
                    .htxtDivLeftHQYJ = Me.htxtDivLeftHQYJ.Value
                    .htxtDivTopHQYJ = Me.htxtDivTopHQYJ.Value
                    .htxtDivLeftSHYJ = Me.htxtDivLeftSHYJ.Value
                    .htxtDivTopSHYJ = Me.htxtDivTopSHYJ.Value
                    .htxtDivLeftFHYJ = Me.htxtDivLeftFHYJ.Value
                    .htxtDivTopFHYJ = Me.htxtDivTopFHYJ.Value
                    .htxtDivLeftFJ = Me.htxtDivLeftFJ.Value
                    .htxtDivTopFJ = Me.htxtDivTopFJ.Value
                    .htxtDivLeftXGWJ = Me.htxtDivLeftXGWJ.Value
                    .htxtDivTopXGWJ = Me.htxtDivTopXGWJ.Value
                    .htxtDivLeftRYXX = Me.htxtDivLeftRYXX.Value
                    .htxtDivTopRYXX = Me.htxtDivTopRYXX.Value

                    .htxtEditMode = Me.htxtEditMode.Value
                    .htxtEditType = Me.htxtEditType.Value
                    .htxtZWNRFileName = Me.htxtZWNRFileName.Value
                    .htxtEnforeEdit = Me.htxtEnforeEdit.Value

                    .htxtSessionIDFJ = Me.htxtSessionIDFJ.Value
                    .htxtSessionIDXGWJ = Me.htxtSessionIDXGWJ.Value
                    .htxtSessionIDRYXX = Me.htxtSessionIDRYXX.Value

                    .htxtFJSort = Me.htxtFJSort.Value
                    .htxtFJSortColumnIndex = Me.htxtFJSortColumnIndex.Value
                    .htxtFJSortType = Me.htxtFJSortType.Value

                    .htxtXGWJSort = Me.htxtXGWJSort.Value
                    .htxtXGWJSortColumnIndex = Me.htxtXGWJSortColumnIndex.Value
                    .htxtXGWJSortType = Me.htxtXGWJSortType.Value

                    .htxtRYXXSort = Me.htxtRYXXSort.Value
                    .htxtRYXXSortColumnIndex = Me.htxtRYXXSortColumnIndex.Value
                    .htxtRYXXSortType = Me.htxtRYXXSortType.Value

                    .htxtSelectMenuID = Me.htxtSelectMenuID.Value

                    .grdFJ_SelectedIndex = Me.grdFJ.SelectedIndex
                    .grdFJ_PageSize = Me.grdFJ.PageSize
                    .grdFJ_CurrentPageIndex = Me.grdFJ.CurrentPageIndex
                    .objDataSet_FJ = Me.m_objDataSet_FJ

                    .grdXGWJ_SelectedIndex = Me.grdXGWJ.SelectedIndex
                    .grdXGWJ_PageSize = Me.grdXGWJ.PageSize
                    .grdXGWJ_CurrentPageIndex = Me.grdXGWJ.CurrentPageIndex
                    .objDataSet_XGWJ = Me.m_objDataSet_XGWJ

                    .grdRYXX_SelectedIndex = Me.grdRYXX.SelectedIndex
                    .grdRYXX_PageSize = Me.grdRYXX.PageSize
                    .grdRYXX_CurrentPageIndex = Me.grdRYXX.CurrentPageIndex
                    .objDataSet_RYXX = Me.m_objDataSet_RYXX
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim intXZBZ As Integer = Josco.JsKernal.Common.Data.FlowData.enumFileDownloadStatus.HasDownload
            Dim intLBBS As Integer = Josco.JsKernal.Common.Data.FlowData.enumXGWJLB.FujianFile
            Dim objDataRow As System.Data.DataRow

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim strWhere As String = ""

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If


                '==========================================================================================================================================================
                Dim objIEstateRsGrllInfo As Josco.JSOA.BusinessFacade.IEstateRsGrllInfo
                Try
                    objIEstateRsGrllInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsGrllInfo)
                Catch ex As Exception
                    objIEstateRsGrllInfo = Nothing
                End Try
                If Not (objIEstateRsGrllInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsGrllInfo.SafeRelease(objIEstateRsGrllInfo)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Try
                    objIEstateRsXzTeam = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsXzTeam)
                Catch ex As Exception
                    objIEstateRsXzTeam = Nothing
                End Try
                If Not (objIEstateRsXzTeam Is Nothing) Then
                    If objIEstateRsXzTeam.oExitMode = True Then
                        Dim strZBBS As String = ""
                        Select Case objIEstateRsXzTeam.iSourceControlId.ToUpper()
                            Case "btnSelectTDBH".ToUpper()
                                If objIEstateRsXzTeam.oDataSet Is Nothing Then
                                    Me.txtTDBH.Text = ""
                                Else
                                    With objIEstateRsXzTeam.oDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH)
                                        If .Rows.Count < 1 Then
                                            Me.txtTDBH.Text = ""
                                        Else
                                            Me.txtTDBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), "")
                                        End If
                                    End With
                                End If
                          
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsXzTeam.SafeRelease(objIEstateRsXzTeam)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIDmxzJbdm As Josco.JsKernal.BusinessFacade.IDmxzJbdm
                Try
                    objIDmxzJbdm = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzJbdm)
                Catch ex As Exception
                    objIDmxzJbdm = Nothing
                End Try
                If Not (objIDmxzJbdm Is Nothing) Then
                    If objIDmxzJbdm.oExitMode = True Then
                        Select Case objIDmxzJbdm.iSourceControlId.ToUpper
                            Case "btnSelect_JLBH".ToUpper
                                Me.txtJLBH.Text = objIDmxzJbdm.oNameValue
                                Me.txtRYDM.Text = objIDmxzJbdm.oCodeValue
                                '获取其他信息
                                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RYDM + " = '" + Me.txtRYDM.Text + "'"
                                If objsystemEstateRenshiXingye.getDataSet_GRLL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiXingyeData) = True Then
                                    With objestateRenshiXingyeData.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI)
                                        If .Rows.Count > 0 Then
                                            Me.txtRYXM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XM), "")
                                            Me.rblRYXB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYXB, objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XB), ""))
                                            Me.txtRYNN.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_NN), "")
                                            Me.ddlXL.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlXL, objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZGXLMC), ""))
                                            'zengxianglin 2009-05-16
                                            Me.txtNFPBM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_NYBMMC), "")
                                            If Me.txtNFPBM.Text.Trim <> "" Then
                                                '计算组织代码
                                                Dim strZZDM As String = ""
                                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtNFPBM.Text, strZZDM) = True Then
                                                    '计算定编人数
                                                    If strZZDM <> "" Then
                                                        strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SSDW + " = '" + strZZDM + "'"
                                                        If objsystemEstateRenshiXingye.getDataSet_RYJG_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, Now, strWhere, objestateRenshiXingyeData) = True Then
                                                            With objestateRenshiXingyeData.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RENYUANJIAGOU_DW)
                                                                If .Rows.Count > 0 Then
                                                                    Me.txtXYRYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SJBZ), "")
                                                                    Me.txtDBRYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_BZRS), "")
                                                                End If
                                                            End With
                                                        End If
                                                    End If
                                                End If
                                            End If
                                            'zengxianglin 2009-05-16
                                        End If
                                    End With
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzJbdm.SafeRelease(objIDmxzJbdm)
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
                            Case "btnFPBM".ToUpper
                                Me.txtNFPBM.Text = objIDmxzZzjg.oBumenList
                                '计算组织代码
                                Dim strZZDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtNFPBM.Text, strZZDM) = True Then
                                    '计算定编人数
                                    If strZZDM <> "" Then
                                        Me.htxtSSDW.Value = strZZDM
                                        strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SSDW + " = '" + strZZDM + "'"
                                        If objsystemEstateRenshiXingye.getDataSet_RYJG_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, Now, strWhere, objestateRenshiXingyeData) = True Then
                                            With objestateRenshiXingyeData.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RENYUANJIAGOU_DW)
                                                If .Rows.Count > 0 Then
                                                    Me.txtXYRYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SJBZ), "")
                                                    Me.txtDBRYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_BZRS), "")
                                                End If
                                            End With
                                        End If
                                    End If
                                End If

                                Dim intStep As Integer = 3
                                Dim strBM As String = ""
                                Dim strInfo As String = ""
                                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                                    strBM = Me.txtNFPBM.Text.Trim
                                    If strBM = "" Then
                                        strInfo = "提示：拟分配部门不能为空！请检查！"
                                        objMessageProcess.doAlertMessage(Me.popMessageObject, strInfo)
                                    Else
                                        If strBM <> Me.txtJBDW.Text.Trim Then
                                            strInfo = "提示：拟分配部门不是" + Me.txtJBDW.Text + "！请注意！"
                                            objMessageProcess.doAlertMessage(Me.popMessageObject, strInfo)
                                        End If
                                    End If
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
                    Exit Try
                End If

                '=================================================================
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Try
                    objIDmxzZzry = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzry)
                Catch ex As Exception
                    objIDmxzZzry = Nothing
                End Try
                If Not (objIDmxzZzry Is Nothing) Then
                    '返回值处理
                    Dim objDataset As New System.Data.DataSet
                    Dim strRYMC As String
                    Dim strBMMC As String

                    Select Case objIDmxzZzry.iSourceControlId.ToUpper()
                        Case "btnSelect_ZZDM".ToUpper()
                            '处理btnSelect_ZZDM返回
                            If objIDmxzZzry.oExitMode = True Then
                                objDataset = objIDmxzZzry.oDataSet
                                If objDataset Is Nothing Then

                                Else
                                    With objDataset.Tables(0)
                                        strRYMC = objPulicParameters.getObjectValue(.Rows(0).Item(0), "")
                                        strBMMC = objPulicParameters.getObjectValue(.Rows(0).Item(3), "")
                                    End With

                                    Me.txtBMJL.Text = strRYMC

                                    'If strBMMC.Trim <> "" Then
                                    '    Me.txtNFPBM.Text = strBMMC

                                    '    Dim strZZDM As String = ""
                                    '    If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtNFPBM.Text, strZZDM) = True Then
                                    '        '计算定编人数
                                    '        If strZZDM <> "" Then
                                    '            Me.htxtSSDW.Value = strZZDM
                                    '            strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SSDW + " = '" + strZZDM + "'"
                                    '            If objsystemEstateRenshiXingye.getDataSet_RYJG_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, Now, strWhere, objestateRenshiXingyeData) = True Then
                                    '                With objestateRenshiXingyeData.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RENYUANJIAGOU_DW)
                                    '                    If .Rows.Count > 0 Then
                                    '                        Me.txtXYRYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SJBZ), "")
                                    '                        Me.txtDBRYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_BZRS), "")
                                    '                    End If
                                    '                End With
                                    '            End If
                                    '        End If
                                    '    End If
                                    'End If
                                End If

                            End If
                        Case Else
                    End Select
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIDmxzZzry.Dispose()
                    objIDmxzZzry = Nothing
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCkdbqk As Josco.JSOA.BusinessFacade.IFlowCkdbqk
                Try
                    objIFlowCkdbqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowCkdbqk)
                Catch ex As Exception
                    objIFlowCkdbqk = Nothing
                End Try
                If Not (objIFlowCkdbqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowCkdbqk.SafeRelease(objIFlowCkdbqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCkcbqk As Josco.JSOA.BusinessFacade.IFlowCkcbqk
                Try
                    objIFlowCkcbqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowCkcbqk)
                Catch ex As Exception
                    objIFlowCkcbqk = Nothing
                End Try
                If Not (objIFlowCkcbqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowCkcbqk.SafeRelease(objIFlowCkcbqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowSpyjtx As Josco.JSOA.BusinessFacade.IFlowSpyjtx
                Try
                    objIFlowSpyjtx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowSpyjtx)
                Catch ex As Exception
                    objIFlowSpyjtx = Nothing
                End Try
                If Not (objIFlowSpyjtx Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowSpyjtx.SafeRelease(objIFlowSpyjtx)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowBycl As Josco.JSOA.BusinessFacade.IFlowBycl
                Try
                    objIFlowBycl = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowBycl)
                Catch ex As Exception
                    objIFlowBycl = Nothing
                End Try
                If Not (objIFlowBycl Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowBycl.SafeRelease(objIFlowBycl)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowByqk As Josco.JSOA.BusinessFacade.IFlowByqk
                Try
                    objIFlowByqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowByqk)
                Catch ex As Exception
                    objIFlowByqk = Nothing
                End Try
                If Not (objIFlowByqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowByqk.SafeRelease(objIFlowByqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCzrz As Josco.JSOA.BusinessFacade.IFlowCzrz
                Try
                    objIFlowCzrz = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowCzrz)
                Catch ex As Exception
                    objIFlowCzrz = Nothing
                End Try
                If Not (objIFlowCzrz Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowCzrz.SafeRelease(objIFlowCzrz)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowSpyj As Josco.JSOA.BusinessFacade.IFlowSpyj
                Try
                    objIFlowSpyj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowSpyj)
                Catch ex As Exception
                    objIFlowSpyj = Nothing
                End Try
                If Not (objIFlowSpyj Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowSpyj.SafeRelease(objIFlowSpyj)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowLzqk As Josco.JSOA.BusinessFacade.IFlowLzqk
                Try
                    objIFlowLzqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowLzqk)
                Catch ex As Exception
                    objIFlowLzqk = Nothing
                End Try
                If Not (objIFlowLzqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowLzqk.SafeRelease(objIFlowLzqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowDubanjg As Josco.JSOA.BusinessFacade.IFlowDubanjg
                Try
                    objIFlowDubanjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowDubanjg)
                Catch ex As Exception
                    objIFlowDubanjg = Nothing
                End Try
                If Not (objIFlowDubanjg Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowDubanjg.SafeRelease(objIFlowDubanjg)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowDuban As Josco.JSOA.BusinessFacade.IFlowDuban
                Try
                    objIFlowDuban = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowDuban)
                Catch ex As Exception
                    objIFlowDuban = Nothing
                End Try
                If Not (objIFlowDuban Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowDuban.SafeRelease(objIFlowDuban)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCuiban As Josco.JSOA.BusinessFacade.IFlowCuiban
                Try
                    objIFlowCuiban = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowCuiban)
                Catch ex As Exception
                    objIFlowCuiban = Nothing
                End Try
                If Not (objIFlowCuiban Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowCuiban.SafeRelease(objIFlowCuiban)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowImportZS As Josco.JSOA.BusinessFacade.IFlowImportZS
                Try
                    objIFlowImportZS = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowImportZS)
                Catch ex As Exception
                    objIFlowImportZS = Nothing
                End Try
                If Not (objIFlowImportZS Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowImportZS.SafeRelease(objIFlowImportZS)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowImportQP As Josco.JSOA.BusinessFacade.IFlowImportQP
                Try
                    objIFlowImportQP = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowImportQP)
                Catch ex As Exception
                    objIFlowImportQP = Nothing
                End Try
                If Not (objIFlowImportQP Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowImportQP.SafeRelease(objIFlowImportQP)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowTuihui As Josco.JSOA.BusinessFacade.IFlowTuihui
                Try
                    objIFlowTuihui = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowTuihui)
                Catch ex As Exception
                    objIFlowTuihui = Nothing
                End Try
                If Not (objIFlowTuihui Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowTuihui.SafeRelease(objIFlowTuihui)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowShouhui As Josco.JSOA.BusinessFacade.IFlowShouhui
                Try
                    objIFlowShouhui = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowShouhui)
                Catch ex As Exception
                    objIFlowShouhui = Nothing
                End Try
                If Not (objIFlowShouhui Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowShouhui.SafeRelease(objIFlowShouhui)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowReceive As Josco.JSOA.BusinessFacade.IFlowReceive
                Try
                    objIFlowReceive = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowReceive)
                Catch ex As Exception
                    objIFlowReceive = Nothing
                End Try
                If Not (objIFlowReceive Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowReceive.SafeRelease(objIFlowReceive)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowSend As Josco.JSOA.BusinessFacade.IFlowSend
                Try
                    objIFlowSend = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowSend)
                Catch ex As Exception
                    objIFlowSend = Nothing
                End Try
                If Not (objIFlowSend Is Nothing) Then
                    Dim blnReturn As Boolean = objIFlowSend.oExitMode
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowSend.SafeRelease(objIFlowSend)
                    '！！！！返回上级！！！！
                    If blnReturn = True Then
                        '设置返回参数
                        Me.m_objInterface.oExitMode = False
                        '返回到调用模块，并附加返回参数
                        '要返回的SessionId
                        Dim strSessionId As String
                        strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        'SessionId附加到返回的Url
                        Dim strUrl As String
                        strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                        '释放模块资源
                        Me.releaseModuleParameters()
                        Me.releaseInterfaceParameters()
                        '返回
                        Response.Redirect(strUrl)
                    End If
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowXgwjfjInfo As Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
                Try
                    objIFlowXgwjfjInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo)
                Catch ex As Exception
                    objIFlowXgwjfjInfo = Nothing
                End Try
                If Not (objIFlowXgwjfjInfo Is Nothing) Then
                    If objIFlowXgwjfjInfo.oExitMode = True Then
                        Select Case objIFlowXgwjfjInfo.iEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                objDataRow = objIFlowXgwjfjInfo.iRow
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS) = objPulicParameters.getObjectValue(objIFlowXgwjfjInfo.oWJYS, 1)
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ) = objIFlowXgwjfjInfo.oWJWZ
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT) = objIFlowXgwjfjInfo.oWJSM
                                If objIFlowXgwjfjInfo.oBDWJ <> "" Then
                                    objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = objIFlowXgwjfjInfo.oBDWJ
                                    objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XZBZ) = intXZBZ.ToString()
                                End If
                            Case Else
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo.SafeRelease(objIFlowXgwjfjInfo)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowFujianInfo As Josco.JSOA.BusinessFacade.IFlowFujianInfo
                Try
                    objIFlowFujianInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowFujianInfo)
                Catch ex As Exception
                    objIFlowFujianInfo = Nothing
                End Try
                If Not (objIFlowFujianInfo Is Nothing) Then
                    If objIFlowFujianInfo.oExitMode = True Then
                        Select Case objIFlowFujianInfo.iEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                objDataRow = objIFlowFujianInfo.iRow
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS) = objPulicParameters.getObjectValue(objIFlowFujianInfo.oWJYS, 1)
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ) = objIFlowFujianInfo.oWJWZ
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM) = objIFlowFujianInfo.oWJSM
                                If objIFlowFujianInfo.oBDWJ <> "" Then
                                    objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ) = objIFlowFujianInfo.oBDWJ
                                    objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XZBZ) = intXZBZ.ToString()
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowFujianInfo.SafeRelease(objIFlowFujianInfo)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowXgwj As Josco.JSOA.BusinessFacade.IFlowXgwj
                Try
                    objIFlowXgwj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowXgwj)
                Catch ex As Exception
                    objIFlowXgwj = Nothing
                End Try
                If Not (objIFlowXgwj Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowXgwj.SafeRelease(objIFlowXgwj)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowFujian As Josco.JSOA.BusinessFacade.IFlowFujian
                Try
                    objIFlowFujian = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowFujian)
                Catch ex As Exception
                    objIFlowFujian = Nothing
                End Try
                If Not (objIFlowFujian Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowFujian.SafeRelease(objIFlowFujian)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowEditWord As Josco.JSOA.BusinessFacade.IFlowEditWord
                Try
                    objIFlowEditWord = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowEditWord)
                Catch ex As Exception
                    objIFlowEditWord = Nothing
                End Try
                If Not (objIFlowEditWord Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowEditWord.SafeRelease(objIFlowEditWord)
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放接口参数(模块无返回数据时用)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try

                '必须有接口参数
                Me.m_blnInterface = False
                If m_objInterface Is Nothing Then
                    '显示错误信息
                    strErrMsg = "本模块必须提供输入接口参数！"
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = strErrMsg
                    blnContinue = False
                    Exit Try
                End If
                Me.m_blnInterface = True

                '接口参数检查
                Select Case Me.m_objInterface.iEditMode
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                    Case Else
                        If Me.m_objInterface.iWJBS.Trim() = "" Then
                            '显示错误信息
                            strErrMsg = "本模块必须提供输入[文件标识]接口参数！"
                            Me.panelError.Visible = True
                            Me.panelMain.Visible = Not Me.panelError.Visible
                            Me.lblMessage.Text = strErrMsg
                            blnContinue = False
                            Exit Try
                        End If
                End Select

                '创建工作流对象
                Dim strWJBS As String = Me.m_objInterface.iWJBS
                If Me.getModuleData_Main(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsRuZhiInfo)
                    Catch ex As Exception
                        Me.m_objSaveScence = Nothing
                    End Try
                    If Me.m_objSaveScence Is Nothing Then
                        Me.m_blnSaveScence = False
                    Else
                        Me.m_blnSaveScence = True
                    End If

                    If Me.m_objSaveScence Is Nothing Then
                        '不是调用其他模块返回
                        Me.htxtEditType.Value = CType(Me.m_objInterface.iEditMode, Integer).ToString()
                    End If

                    '恢复现场参数后释放该资源
                    Me.restoreModuleInformation(strSessionId)

                    '处理调用模块返回后的信息并同时释放相应资源
                    If Me.getDataFromCallModule(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

                '获取其他参数
                Me.m_intFixedColumns_RYXX = objPulicParameters.getObjectValue(Me.htxtRYXXFixed.Value, 0)
                Me.m_intFixedColumns_XGWJ = objPulicParameters.getObjectValue(Me.htxtXGWJFixed.Value, 0)
                Me.m_intFixedColumns_FJ = objPulicParameters.getObjectValue(Me.htxtFJFixed.Value, 0)

                Try
                    Me.m_objenumEditType = CType(Me.htxtEditType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType)
                Catch ex As Exception
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                End Try
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Me.m_blnEditMode = True
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        Me.m_blnEditMode = True
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_blnEditMode = True
                    Case Else
                        Me.m_blnEditMode = False
                End Select
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()

                Me.m_strSessionID_RYXX = objPulicParameters.getObjectValue(Me.htxtSessionIDRYXX.Value, "")
                Me.m_strSessionID_XGWJ = objPulicParameters.getObjectValue(Me.htxtSessionIDXGWJ.Value, "")
                Me.m_strSessionID_FJ = objPulicParameters.getObjectValue(Me.htxtSessionIDFJ.Value, "")
                Me.m_strGJFileName = objPulicParameters.getObjectValue(Me.htxtZWNRFileName.Value, "")

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
        ' 释放本模块缓存的参数(模块返回时用)
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                Dim objFlowData As Josco.JsKernal.Common.Data.FlowData
                If Me.m_strSessionID_FJ <> "" Then
                    Try
                        objFlowData = CType(Session.Item(Me.m_strSessionID_FJ), Josco.JsKernal.Common.Data.FlowData)
                    Catch ex As Exception
                        objFlowData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.FlowData.SafeRelease(objFlowData)
                    Session.Remove(Me.m_strSessionID_FJ)
                End If
                If Me.m_strSessionID_XGWJ <> "" Then
                    Try
                        objFlowData = CType(Session.Item(Me.m_strSessionID_XGWJ), Josco.JsKernal.Common.Data.FlowData)
                    Catch ex As Exception
                        objFlowData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.FlowData.SafeRelease(objFlowData)
                    Session.Remove(Me.m_strSessionID_XGWJ)
                End If

                Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData
                If Me.m_strSessionID_RYXX <> "" Then
                    Try
                        objestateRenshiXingyeData = CType(Session.Item(Me.m_strSessionID_RYXX), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objestateRenshiXingyeData = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
                    Session.Remove(Me.m_strSessionID_RYXX)
                End If

            Catch ex As Exception
            End Try

        End Sub












        '----------------------------------------------------------------
        ' 根据strWJBS获取文件信息
        '     strErrMsg      ：返回错误信息
        '     strWJBS        ：文件标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_Main( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String) As Boolean

            getModuleData_Main = False

            Try
                '创建工作流对象
                Dim strType As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWCODE
                Dim strName As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWNAME
                Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                Me.m_objsystemFlowObjectRenshiRuZhi = CType(objsystemFlowObject, Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi)

                '工作流对象初始化并填充数据
                If Me.m_objsystemFlowObjectRenshiRuZhi.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, True) = False Then
                    GoTo errProc
                End If

                '计算可执行的操作
                If Me.m_objsystemFlowObjectRenshiRuZhi.getCanExecuteCommand(strErrMsg, MyBase.UserId, MyBase.UserXM, MyBase.UserBmdm) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_Main = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据strWJBS获取grdFJ要显示的附件信息
        '     strErrMsg      ：返回错误信息
        '     strWJBS        ：文件标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_FJ( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_FJ = False

            Try
                '是编辑模式时首次进入：以现场复原信息为准(暗含首次进入条件)
                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    Exit Try
                End If

                '如果是编辑模式：则从缓存中获取数据
                If Me.m_strSessionID_FJ <> "" And Me.m_blnEditMode = True Then
                    Me.m_objDataSet_FJ = CType(Session.Item(Me.m_strSessionID_FJ), Josco.JSOA.Common.Data.FlowData)
                Else
                    '备份Sort字符串
                    Dim strSort As String
                    strSort = Me.htxtFJSort.Value
                    If strSort.Length > 0 Then strSort = strSort.Trim

                    '释放资源
                    Josco.JSOA.Common.Data.FlowData.SafeRelease(Me.m_objDataSet_FJ)

                    '重新检索数据
                    If Me.m_objsystemFlowObjectRenshiRuZhi.getFujianData(strErrMsg, Me.m_objDataSet_FJ) = False Then
                        GoTo errProc
                    End If

                    '恢复Sort字符串
                    With Me.m_objDataSet_FJ.Tables(strTable)
                        .DefaultView.Sort = strSort
                    End With

                    '清除现有缓存数据
                    If Me.m_strSessionID_FJ <> "" Then
                        Dim objFlowData As Josco.JSOA.Common.Data.FlowData
                        objFlowData = CType(Session.Item(Me.m_strSessionID_FJ), Josco.JSOA.Common.Data.FlowData)
                        Josco.JSOA.Common.Data.FlowData.SafeRelease(objFlowData)
                        Session.Remove(Me.m_strSessionID_FJ)
                        Me.m_strSessionID_FJ = ""
                        Me.htxtSessionIDFJ.Value = Me.m_strSessionID_FJ
                    End If
                    If Me.m_blnEditMode = True Then
                        '如果是编辑状态，则缓存数据
                        Me.m_strSessionID_FJ = objPulicParameters.getNewGuid()
                        Session.Add(Me.m_strSessionID_FJ, Me.m_objDataSet_FJ)
                        Me.htxtSessionIDFJ.Value = Me.m_strSessionID_FJ
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_FJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据strWJBS获取grdXGWJ要显示的相关信息
        '     strErrMsg      ：返回错误信息
        '     strWJBS        ：文件标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_XGWJ( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_XGWJ = False

            Try
                '是编辑模式时首次进入：以现场复原信息为准(暗含首次进入条件)
                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    Exit Try
                End If

                '如果是编辑模式：则从缓存中获取数据
                If Me.m_strSessionID_XGWJ <> "" And Me.m_blnEditMode = True Then
                    Me.m_objDataSet_XGWJ = CType(Session.Item(Me.m_strSessionID_XGWJ), Josco.JSOA.Common.Data.FlowData)
                Else
                    '备份Sort字符串
                    Dim strSort As String
                    strSort = Me.htxtXGWJSort.Value
                    If strSort.Length > 0 Then strSort = strSort.Trim

                    '释放资源
                    Josco.JSOA.Common.Data.FlowData.SafeRelease(Me.m_objDataSet_XGWJ)

                    '重新检索数据
                    If Me.m_objsystemFlowObjectRenshiRuZhi.getXgwjData(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                        GoTo errProc
                    End If

                    '恢复Sort字符串
                    With Me.m_objDataSet_XGWJ.Tables(strTable)
                        .DefaultView.Sort = strSort
                    End With

                    '清除现有缓存数据
                    If Me.m_strSessionID_XGWJ <> "" Then
                        Dim objFlowData As Josco.JSOA.Common.Data.FlowData
                        objFlowData = CType(Session.Item(Me.m_strSessionID_XGWJ), Josco.JSOA.Common.Data.FlowData)
                        Josco.JSOA.Common.Data.FlowData.SafeRelease(objFlowData)
                        Session.Remove(Me.m_strSessionID_XGWJ)
                        Me.m_strSessionID_XGWJ = ""
                        Me.htxtSessionIDXGWJ.Value = Me.m_strSessionID_XGWJ
                    End If
                    If Me.m_blnEditMode = True Then
                        '如果是编辑状态，则缓存数据
                        Me.m_strSessionID_XGWJ = objPulicParameters.getNewGuid()
                        Session.Add(Me.m_strSessionID_XGWJ, Me.m_objDataSet_XGWJ)
                        Me.htxtSessionIDXGWJ.Value = Me.m_strSessionID_XGWJ
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_XGWJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据strWJBS获取grdRYXX要显示的相关信息
        '     strErrMsg      ：返回错误信息
        '     strWJBS        ：文件标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_RYXX( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_RYXX = False

            Try
                '是编辑模式时首次进入：以现场复原信息为准(暗含首次进入条件)
                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    Exit Try
                End If

                '如果是编辑模式：则从缓存中获取数据
                If Me.m_strSessionID_RYXX <> "" And Me.m_blnEditMode = True Then
                    Me.m_objDataSet_RYXX = CType(Session.Item(Me.m_strSessionID_RYXX), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '备份Sort字符串
                    Dim strSort As String
                    strSort = Me.htxtRYXXSort.Value
                    If strSort.Length > 0 Then strSort = strSort.Trim

                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RYXX)

                    '重新检索数据
                    Dim blnSFJB As Boolean = False
                    Select Case Me.m_objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            If Me.m_objsystemFlowObjectRenshiRuZhi.getDataSet_RYXX(strErrMsg, MyBase.UserXM, Me.m_objDataSet_RYXX) = False Then
                                GoTo errProc
                            End If
                        Case Else
                            If Me.txtJBRY.Text.Trim = MyBase.UserXM Then
                                If Me.m_objsystemFlowObjectRenshiRuZhi.getDataSet_RYXX(strErrMsg, Me.m_objDataSet_RYXX, blnSFJB) = False Then
                                    GoTo errProc
                                End If
                            Else
                                If Me.m_objsystemFlowObjectRenshiRuZhi.getDataSet_RYXX(strErrMsg, MyBase.UserXM, Me.m_objDataSet_RYXX) = False Then
                                    GoTo errProc
                                End If
                            End If
                    End Select
                    

                    '恢复Sort字符串
                    With Me.m_objDataSet_RYXX.Tables(strTable)
                        .DefaultView.Sort = strSort
                    End With

                    '清除现有缓存数据
                    If Me.m_strSessionID_RYXX <> "" Then
                        Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData
                        objestateRenshiXingyeData = CType(Session.Item(Me.m_strSessionID_RYXX), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
                        Session.Remove(Me.m_strSessionID_RYXX)
                        Me.m_strSessionID_RYXX = ""
                        Me.htxtSessionIDRYXX.Value = Me.m_strSessionID_RYXX
                    End If
                    If Me.m_blnEditMode = True Then
                        '如果是编辑状态，则缓存数据
                        Me.m_strSessionID_RYXX = objPulicParameters.getNewGuid()
                        Session.Add(Me.m_strSessionID_RYXX, Me.m_objDataSet_RYXX)
                        Me.htxtSessionIDRYXX.Value = Me.m_strSessionID_RYXX
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_RYXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function














        '----------------------------------------------------------------
        ' 显示grdFJ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_FJ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_FJ = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtFJSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtFJSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_FJ Is Nothing Then
                    Me.grdFJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_FJ.Tables(strTable)
                        Me.grdFJ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_FJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdFJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdFJ)
                    With Me.grdFJ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdFJ.DataBind()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_FJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdXGWJ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_XGWJ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_XGWJ = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtXGWJSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtXGWJSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_XGWJ Is Nothing Then
                    Me.grdXGWJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_XGWJ.Tables(strTable)
                        Me.grdXGWJ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdXGWJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdXGWJ)
                    With Me.grdXGWJ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdXGWJ.DataBind()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_XGWJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdRYXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_RYXX( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_RYXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtRYXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtRYXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_RYXX Is Nothing Then
                    Me.grdRYXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_RYXX.Tables(strTable)
                        Me.grdRYXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_RYXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdRYXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdRYXX)
                    With Me.grdRYXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdRYXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdRYXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_RYXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示编辑窗的数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：当前编辑状态
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditPanelInfo( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim objBaseFlowRenshiRuZhi As Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            showEditPanelInfo = False

            Try
                objBaseFlowRenshiRuZhi = CType(Me.m_objsystemFlowObjectRenshiRuZhi.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi)

                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    '是编辑模式时首次进入：以现场复原信息为准(暗含首次进入条件)
                Else
                    If Me.IsPostBack = False Or (Me.IsPostBack = True And Me.m_blnEditMode = False) Then
                        '首次进入或查看状态下的回发，需要重新显示数据
                        Me.ddlJJCD.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJJCD, objBaseFlowRenshiRuZhi.JJCD)
                        Me.ddlMMDJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlMMDJ, objBaseFlowRenshiRuZhi.MMDJ)
                        Me.txtJGDZ.Text = objBaseFlowRenshiRuZhi.JGDZ
                        Me.txtWJNF.Text = objBaseFlowRenshiRuZhi.WJNF
                        Me.txtWJXH.Text = objBaseFlowRenshiRuZhi.WJXH
                        Me.txtWJBT.Text = objBaseFlowRenshiRuZhi.WJBT
                        'Me.txtDBRS.Text = objBaseFlowRenshiRuZhi.DBRS.ToString
                        Me.txtBZXX.Text = objBaseFlowRenshiRuZhi.BEIZ
                        If objBaseFlowRenshiRuZhi.DDSZ = 1 Then
                            Me.chkDDSZ.Checked = True
                        Else
                            Me.chkDDSZ.Checked = False
                        End If
                        Me.txtJBDW.Text = objBaseFlowRenshiRuZhi.ZBDW
                        Me.txtJBRY.Text = objBaseFlowRenshiRuZhi.NGR
                        Me.txtJBRQ.Text = objPulicParameters.doDateToString(objBaseFlowRenshiRuZhi.NGRQ, "yyyy-MM-dd")
                        Me.txtLSH.Text = objBaseFlowRenshiRuZhi.LSH
                        Me.htxtWJBS.Value = objBaseFlowRenshiRuZhi.WJBS

                        If Me.txtNBDRQ.Text = "" Then
                            Me.txtNBDRQ.Text = Now.AddDays(1).ToString("yyyy-MM-dd")
                        End If

                        Dim intTemp_start As Integer
                        Dim intTemp_end As Integer
                        Dim strTemp As String = objBaseFlowRenshiRuZhi.WJBT
                        Dim lendf As Integer

                        intTemp_start = InStr(1, objBaseFlowRenshiRuZhi.WJBT, "(")
                        intTemp_end = InStr(1, objBaseFlowRenshiRuZhi.WJBT, ")")

                        If intTemp_start > 0 Then
                            Me.htxtRYXM.Value = Mid(strTemp, intTemp_start, intTemp_end)
                        End If

                        '新增时自动设置缺省值
                        Select Case Me.m_objenumEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                '设置初始值
                                Me.txtJGDZ.Text = MyBase.UserBmmc
                                Me.txtWJNF.Text = Year(Now).ToString()
                                Dim strWJXH As String = ""
                                If Me.m_objsystemFlowObjectRenshiRuZhi.getNewWjxh(strErrMsg, Me.txtJGDZ.Text, Me.txtWJNF.Text, strWJXH) = False Then
                                Else
                                    Me.txtWJXH.Text = strWJXH
                                End If
                                Me.txtJBDW.Text = MyBase.UserBmmc
                                Me.txtJBRY.Text = MyBase.UserXM
                                Me.txtJBRQ.Text = Now.ToString("yyyy-MM-dd")
                                Dim strLSH As String = ""
                                If Me.m_objsystemFlowObjectRenshiRuZhi.getNewLSH(strErrMsg, strLSH) = False Then
                                    Me.txtLSH.Text = ""
                                Else
                                    Me.txtLSH.Text = strLSH
                                End If

                                strLSH = Right(strLSH, 2)
                                Me.txtWJBT.Text = Now.ToString("yyyyMMdd") & strLSH & MyBase.UserBmmc & "入职申请单"

                                strLSH = ""
                                If Me.m_objsystemFlowObjectRenshiRuZhi.getNewWJBS(strErrMsg, strLSH) = False Then
                                    Me.htxtWJBS.Value = ""
                                Else
                                    Me.htxtWJBS.Value = strLSH
                                End If
                            Case Else
                        End Select
                    Else
                        '其他情况：控件值自动恢复
                    End If
                    End If

                '根据文件内容随时更新
                'Me.lblQFR.Text = objBaseFlowRenshiRuZhi.QFR

                '设置日期格式
                If Me.txtJBRQ.Text <> "" Then
                    Me.txtJBRQ.Text = System.DateTime.Parse(Me.txtJBRQ.Text).ToString("yyyy-MM-dd")
                End If

                '使能控件
                With objControlProcess
                    .doEnabledControl(Me.ddlJJCD, blnEditMode)
                    .doEnabledControl(Me.ddlMMDJ, blnEditMode)
                    .doEnabledControl(Me.txtJGDZ, blnEditMode)
                    .doEnabledControl(Me.txtWJNF, blnEditMode)
                    .doEnabledControl(Me.txtWJXH, blnEditMode)
                    .doEnabledControl(Me.txtWJBT, blnEditMode)
                    '.doEnabledControl(Me.txtDBRS, blnEditMode)
                    .doEnabledControl(Me.txtBZXX, blnEditMode)
                    .doEnabledControl(Me.chkDDSZ, blnEditMode)

                    '不让输入的内容
                    .doEnabledControl(Me.txtLSH, False)
                    .doEnabledControl(Me.txtJBDW, False)
                    .doEnabledControl(Me.txtJBRY, False)
                    .doEnabledControl(Me.txtJBRQ, False)
                End With

                '人员信息窗内容
                With objControlProcess
                    .doEnabledControl(Me.txtJLBH, blnEditMode)
                    .doEnabledControl(Me.txtRYDM, blnEditMode)
                    .doEnabledControl(Me.txtRYXM, blnEditMode)
                    .doEnabledControl(Me.txtRYNN, blnEditMode)
                    .doEnabledControl(Me.txtNFPBM, blnEditMode)
                    .doEnabledControl(Me.ddlZJDM, blnEditMode)
                    .doEnabledControl(Me.txtZPSM, blnEditMode)
                    .doEnabledControl(Me.txtXYRYS, blnEditMode)
                    .doEnabledControl(Me.txtDBRYS, blnEditMode)
                    .doEnabledControl(Me.rblRYXB, blnEditMode)
                    .doEnabledControl(Me.ddlXL, blnEditMode)

                    .doEnabledControl(Me.txtSFZHM, blnEditMode)
                    .doEnabledControl(Me.txtBMJL, blnEditMode)
                    '.doEnabledControl(Me.txtSPSM, blnEditMode)
                    .doEnabledControl(Me.txtWLJNFS, blnEditMode)
                    .doEnabledControl(Me.ddlZPQD, blnEditMode)
                    .doEnabledControl(Me.ddlYDYY, blnEditMode)
                    .doEnabledControl(Me.ddlZPSM, blnEditMode)


                    .doEnabledControl(Me.rblRYLX, blnEditMode)
                    .doEnabledControl(Me.txtTDBH, blnEditMode)
                    .doEnabledControl(Me.txtLXDH, blnEditMode)
                   


                End With
                Me.btnFPBM.Visible = blnEditMode
                Me.btnSelectTDBH.Visible = blnEditMode
                'Me.btnSelect_JLBH.Visible = blnEditMode
                Me.btnSelect_ZZDM.Visible = blnEditMode
                Me.btnRYXX_AddNew.Visible = blnEditMode
                Me.btnRYXX_Delete.Visible = blnEditMode
                Me.btnRYXX_Update.Visible = blnEditMode
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanelInfo = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        Private Function getStringCount(ByVal strSrc As String, ByVal intStart As Integer, ByVal intLenth As Integer) As String
            Dim strResult As String = String.Empty
            Dim byeTemp As Byte()

            '将字符串转化为Byte
            byeTemp = System.Text.Encoding.Default.GetBytes(strSrc.ToCharArray())

            Try
                strResult = New String(System.Text.Encoding.Default.GetChars(byeTemp, intStart, intLenth))
            Catch ex As Exception
                strResult = String.Empty
            End Try

            Return strResult
        End Function


        '----------------------------------------------------------------
        ' 使能所有的操作命令
        '     blnEnabled     ：开关
        '----------------------------------------------------------------
        Private Sub doEnabledFileCommands(ByVal blnEnabled As Boolean)

            Try
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuJJCL_FSWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuJJCL_THWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuJJCL_SHWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuJJCL_WTBL").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuFILE_BCWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuFILE_QXXG").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuFILE_SXWJ").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuSPCL_TXYJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_BDPS").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_BYBL").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_BLWB").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_ZHBL").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_JXBL").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_ZFWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_QYWJ").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuCBDB_CBWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuCBDB_DBWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuCBDB_DBJG").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuXXCY_CYYJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXCY_CKLZ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXCY_CKBY").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXCY_CKRZ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXCY_CKCB").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXCY_CKDB").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuXXDY_DYGZ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXDY_DYBJ").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuQTCL_WJBY").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuQTCL_BWTX").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuQTCL_DRQP").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuQTCL_DRZS").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuQTCL_WJBJ").Enabled = blnEnabled
                'zengxianglin 2009-05-16
                Me.mnuMain.FindItemById("mnuQTCL_RYLY").Enabled = blnEnabled
                'zengxianglin 2009-05-16
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuFHSJ").Enabled = blnEnabled
                '**********************************************************************

                '**********************************************************************
                '签署意见操作
                Me.lnkCZQSYJ_QF.Enabled = blnEnabled
                Me.lnkCZQSYJ_FH.Enabled = blnEnabled
                Me.lnkCZQSYJ_SH.Enabled = blnEnabled
                Me.lnkCZQSYJ_HQ.Enabled = blnEnabled
                '**********************************************************************
                'Me.m_blnSPMode = blnEnabled

                '文件内部操作
                'Me.lnkCZCYGJ.Enabled = blnEnabled
                'Me.lnkCZCYFJ.Enabled = blnEnabled
                'Me.lnkCZCYXGWJ.Enabled = blnEnabled
                'Me.lnkCZCYQPWJ.Enabled = blnEnabled
                'Me.lnkCZCYZSWJ.Enabled = blnEnabled

            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 使能所有的操作命令
        '     blnEnabled     ：开关
        '----------------------------------------------------------------
        Private Sub doSetVisibleCommands()

            Try


                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuJJCL_FSWJ").Visible = Me.mnuMain.FindItemById("mnuJJCL_FSWJ").Enabled
                Me.mnuMain.FindItemById("mnuJJCL_THWJ").Visible = Me.mnuMain.FindItemById("mnuJJCL_THWJ").Enabled
                Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Visible = Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Enabled
                Me.mnuMain.FindItemById("mnuJJCL_SHWJ").Visible = Me.mnuMain.FindItemById("mnuJJCL_SHWJ").Enabled
                'Me.mnuMain.FindItemById("mnuJJCL_WTBL").Visible = Me.mnuMain.FindItemById("mnuJJCL_WTBL").Enabled
                Me.mnuMain.FindItemById("mnuJJCL_WTBL").Visible = False
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuFILE_XGWJ").Visible = Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled
                Me.mnuMain.FindItemById("mnuFILE_BCWJ").Visible = Me.mnuMain.FindItemById("mnuFILE_BCWJ").Enabled
                Me.mnuMain.FindItemById("mnuFILE_QXXG").Visible = Me.mnuMain.FindItemById("mnuFILE_QXXG").Enabled
                Me.mnuMain.FindItemById("mnuFILE_SXWJ").Visible = Me.mnuMain.FindItemById("mnuFILE_SXWJ").Enabled
                '******************************************************************************************************
                'Me.mnuMain.FindItemById("mnuSPCL_TXYJ").Visible = Me.mnuMain.FindItemById("mnuSPCL_TXYJ").Enabled
                'Me.mnuMain.FindItemById("mnuSPCL_BDPS").Visible = Me.mnuMain.FindItemById("mnuSPCL_BDPS").Enabled
                'Me.mnuMain.FindItemById("mnuSPCL_BYBL").Visible = Me.mnuMain.FindItemById("mnuSPCL_BYBL").Enabled
                'Me.mnuMain.FindItemById("mnuSPCL_BLWB").Visible = Me.mnuMain.FindItemById("mnuSPCL_BLWB").Enabled
                Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Visible = Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Enabled
                'Me.mnuMain.FindItemById("mnuSPCL_ZHBL").Visible = Me.mnuMain.FindItemById("mnuSPCL_ZHBL").Enabled
                'Me.mnuMain.FindItemById("mnuSPCL_JXBL").Visible = Me.mnuMain.FindItemById("mnuSPCL_JXBL").Enabled
                'Me.mnuMain.FindItemById("mnuSPCL_ZFWJ").Visible = Me.mnuMain.FindItemById("mnuSPCL_ZFWJ").Enabled
                'Me.mnuMain.FindItemById("mnuSPCL_QYWJ").Visible = Me.mnuMain.FindItemById("mnuSPCL_QYWJ").Enabled
                ''******************************************************************************************************
                'Me.mnuMain.FindItemById("mnuCBDB_CBWJ").Visible = Me.mnuMain.FindItemById("mnuCBDB_CBWJ").Enabled
                'Me.mnuMain.FindItemById("mnuCBDB_DBWJ").Visible = Me.mnuMain.FindItemById("mnuCBDB_DBWJ").Enabled
                'Me.mnuMain.FindItemById("mnuCBDB_DBJG").Visible = Me.mnuMain.FindItemById("mnuCBDB_DBJG").Enabled
                ''******************************************************************************************************
                'Me.mnuMain.FindItemById("mnuXXCY_CYYJ").Visible = Me.mnuMain.FindItemById("mnuXXCY_CYYJ").Enabled
                'Me.mnuMain.FindItemById("mnuXXCY_CKLZ").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKLZ").Enabled
                'Me.mnuMain.FindItemById("mnuXXCY_CKBY").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKBY").Enabled
                'Me.mnuMain.FindItemById("mnuXXCY_CKRZ").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKRZ").Enabled
                'Me.mnuMain.FindItemById("mnuXXCY_CKCB").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKCB").Enabled
                'Me.mnuMain.FindItemById("mnuXXCY_CKDB").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKDB").Enabled
                ''******************************************************************************************************
                'Me.mnuMain.FindItemById("mnuXXDY_DYGZ").Visible = Me.mnuMain.FindItemById("mnuXXDY_DYGZ").Enabled
                'Me.mnuMain.FindItemById("mnuXXDY_DYBJ").Visible = Me.mnuMain.FindItemById("mnuXXDY_DYBJ").Enabled
                ''******************************************************************************************************
                'Me.mnuMain.FindItemById("mnuQTCL_WJBY").Visible = Me.mnuMain.FindItemById("mnuQTCL_WJBY").Enabled
                'Me.mnuMain.FindItemById("mnuQTCL_BWTX").Visible = Me.mnuMain.FindItemById("mnuQTCL_BWTX").Enabled
                'Me.mnuMain.FindItemById("mnuQTCL_DRQP").Visible = Me.mnuMain.FindItemById("mnuQTCL_DRQP").Enabled
                'Me.mnuMain.FindItemById("mnuQTCL_DRZS").Visible = Me.mnuMain.FindItemById("mnuQTCL_DRZS").Enabled
                'Me.mnuMain.FindItemById("mnuQTCL_WJBJ").Visible = Me.mnuMain.FindItemById("mnuQTCL_WJBJ").Enabled
                ''zengxianglin 2009-05-16
                'Me.mnuMain.FindItemById("mnuQTCL_RYLY").Visible = Me.mnuMain.FindItemById("mnuQTCL_RYLY").Enabled
                'zengxianglin 2009-05-16

                Me.mnuMain.FindItemById("mnuCBDB").Visible = False
                Me.mnuMain.FindItemById("mnuXXDY").Visible = False
                Me.mnuMain.FindItemById("mnuSPCL_TXYJ").Visible = Me.mnuMain.FindItemById("mnuSPCL_TXYJ").Enabled
                Me.mnuMain.FindItemById("mnuSPCL_BDPS").Visible = False
                Me.mnuMain.FindItemById("mnuSPCL_BLWB").Visible = False
                'Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Visible = False
                Me.mnuMain.FindItemById("mnuSPCL_ZHBL").Visible = False
                Me.mnuMain.FindItemById("mnuSPCL_JXBL").Visible = False
                Me.mnuMain.FindItemById("mnuSPCL_ZFWJ").Visible = False
                Me.mnuMain.FindItemById("mnuSPCL_QYWJ").Visible = False
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuCBDB_CBWJ").Visible = False
                Me.mnuMain.FindItemById("mnuCBDB_DBWJ").Visible = False
                Me.mnuMain.FindItemById("mnuCBDB_DBJG").Visible = False
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuXXCY_CYYJ").Visible = False
                Me.mnuMain.FindItemById("mnuXXCY_CKLZ").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKLZ").Enabled
                Me.mnuMain.FindItemById("mnuXXCY_CKBY").Visible = False
                Me.mnuMain.FindItemById("mnuXXCY_CKRZ").Visible = False
                Me.mnuMain.FindItemById("mnuXXCY_CKCB").Visible = False
                Me.mnuMain.FindItemById("mnuXXCY_CKDB").Visible = False
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuXXDY_DYGZ").Visible = False
                Me.mnuMain.FindItemById("mnuXXDY_DYBJ").Visible = False
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuQTCL_WJBY").Visible = False
                Me.mnuMain.FindItemById("mnuQTCL_BWTX").Visible = False
                Me.mnuMain.FindItemById("mnuQTCL_DRQP").Visible = False
                Me.mnuMain.FindItemById("mnuQTCL_DRZS").Visible = False
                Me.mnuMain.FindItemById("mnuQTCL_WJBJ").Visible = True
                'zengxianglin 2009-05-16
                Me.mnuMain.FindItemById("mnuQTCL_RYLY").Visible = False

                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuFHSJ").Visible = Me.mnuMain.FindItemById("mnuFHSJ").Enabled
                '******************************************************************************************************

            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 显示阅读状态下的操作
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_ReadMode(ByRef strErrMsg As String) As Boolean

            Dim objBaseFlowRenshiRuZhi As Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi
            Dim blnEditMode As Boolean = False

            showModuleData_ReadMode = False

            Try
                '人员信息窗内容

                '工作流初始化
                objBaseFlowRenshiRuZhi = CType(Me.m_objsystemFlowObjectRenshiRuZhi.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi)

                '使能命令
                doEnabledFileCommands(False)

                '逐个设置
                'Me.lnkCZCYGJ.Enabled = Not blnEditMode
                'Me.lnkCZCYGJ.Text = "查阅稿件"
                'Me.lnkCZCYFJ.Enabled = Not blnEditMode
                'Me.lnkCZCYFJ.Text = "查阅附件"
                'Me.lnkCZCYXGWJ.Enabled = Not blnEditMode
                'Me.lnkCZCYXGWJ.Text = "查阅相关文件"
                'Me.lnkCZCYQPWJ.Enabled = Not blnEditMode And (objBaseFlowRenshiRuZhi.HJWJ <> "")
                'Me.lnkCZCYZSWJ.Enabled = Not blnEditMode And (objBaseFlowRenshiRuZhi.PJYJ <> "")

                '
                '不受文件影响的命令
                '
                '刷新文件
                Me.mnuMain.FindItemById("mnuFILE_SXWJ").Enabled = Not blnEditMode
                '返回上级
                Me.mnuMain.FindItemById("mnuFHSJ").Enabled = Not blnEditMode

                '
                '必须先接收？
                '
                If Me.m_objsystemFlowObjectRenshiRuZhi.pmMustJieshou = True Then
                    '接收文件
                    Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Enabled = Not blnEditMode
                    Exit Try
                End If

                '
                '正常操作
                '
                With Me.m_objsystemFlowObjectRenshiRuZhi
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuJJCL_FSWJ").Enabled = .mlFSWJ
                    Me.mnuMain.FindItemById("mnuJJCL_THWJ").Enabled = .mlTHWJ
                    Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Enabled = .mlJSWJ
                    Me.mnuMain.FindItemById("mnuJJCL_SHWJ").Enabled = .mlSHWJ
                    Me.mnuMain.FindItemById("mnuJJCL_WTBL").Enabled = .mlFSWJ
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled = .mlXGWJ
                    Me.mnuMain.FindItemById("mnuFILE_BCWJ").Enabled = .mlBCWJ
                    Me.mnuMain.FindItemById("mnuFILE_QXXG").Enabled = .mlQXXG
                    Me.mnuMain.FindItemById("mnuFILE_SXWJ").Enabled = .mlSXWJ
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuSPCL_TXYJ").Enabled = .mlTXYJ
                    Me.mnuMain.FindItemById("mnuSPCL_BDPS").Enabled = .mlBDPS
                    Me.mnuMain.FindItemById("mnuSPCL_BYBL").Enabled = .mlBYBL
                    Me.mnuMain.FindItemById("mnuSPCL_BLWB").Enabled = .mlBLWB
                    Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Enabled = .mlWYYZ
                    If .mlWYYZ = True Then
                        If Me.m_objsystemFlowObjectRenshiRuZhi.doIReadFile(strErrMsg, MyBase.UserXM) = False Then
                            GoTo errProc
                        End If
                    End If
                    Me.mnuMain.FindItemById("mnuSPCL_ZHBL").Enabled = .mlZHBL
                    Me.mnuMain.FindItemById("mnuSPCL_JXBL").Enabled = .mlJXBL
                    Me.mnuMain.FindItemById("mnuSPCL_ZFWJ").Enabled = .mlZFWJ
                    Me.mnuMain.FindItemById("mnuSPCL_QYWJ").Enabled = .mlQYWJ
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuCBDB_CBWJ").Enabled = .mlCBWJ
                    Me.mnuMain.FindItemById("mnuCBDB_DBWJ").Enabled = .mlDBWJ
                    Me.mnuMain.FindItemById("mnuCBDB_DBJG").Enabled = .mlDBJG
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuXXCY_CYYJ").Enabled = .mlCYYJ
                    Me.mnuMain.FindItemById("mnuXXCY_CKLZ").Enabled = .mlCKLZ
                    Me.mnuMain.FindItemById("mnuXXCY_CKRZ").Enabled = .mlCKRZ
                    Me.mnuMain.FindItemById("mnuXXCY_CKBY").Enabled = .mlCKBY
                    Me.mnuMain.FindItemById("mnuXXCY_CKCB").Enabled = .mlCKCB
                    Me.mnuMain.FindItemById("mnuXXCY_CKDB").Enabled = .mlCKDB
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuXXDY_DYGZ").Enabled = .mlDYGZ
                    Me.mnuMain.FindItemById("mnuXXDY_DYBJ").Enabled = .mlDYBJ
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuQTCL_WJBY").Enabled = .mlWJBY
                    Me.mnuMain.FindItemById("mnuQTCL_BWTX").Enabled = .mlWJBY
                    Me.mnuMain.FindItemById("mnuQTCL_DRQP").Enabled = .mlDRQP
                    Me.mnuMain.FindItemById("mnuQTCL_DRZS").Enabled = .mlDRZS
                    Me.mnuMain.FindItemById("mnuQTCL_WJBJ").Enabled = True
                    'zengxianglin 2009-05-16
                    Me.mnuMain.FindItemById("mnuQTCL_RYLY").Enabled = .mlRYLY
                    'zengxianglin 2009-05-16
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuFHSJ").Enabled = .mlFHSJ
                    '********************************************************

                    '********************************************************
                    Me.lnkCZQSYJ_QF.Enabled = .pmQSYJ_QF
                    Me.lnkCZQSYJ_FH.Enabled = .pmQSYJ_FH
                    Me.lnkCZQSYJ_SH.Enabled = .pmQSYJ_SH
                    Me.lnkCZQSYJ_HQ.Enabled = .pmQSYJ_HQ
                    Me.m_blnSPMode = .pmQSYJ_SH
                    'Me.btnRYXX_AddNew.Enabled = Not m_blnSPMode
                    'Me.btnRYXX_Delete.Enabled = Not m_blnSPMode
                    Me.btnRYXX_NewJLBH.Enabled = Not m_blnSPMode
                    '********************************************************
                    Me.m_blnEnforeEdit = .pmEnforeEdit
                    Me.htxtEnforeEdit.Value = Me.m_blnEnforeEdit.ToString()
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_ReadMode = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示编辑状态下的操作
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_EditMode(ByRef strErrMsg As String) As Boolean

            Dim objBaseFlowRenshiRuZhi As Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi
            Dim blnEditMode As Boolean = True

            showModuleData_EditMode = False

            Try
                '工作流初始化
                objBaseFlowRenshiRuZhi = CType(Me.m_objsystemFlowObjectRenshiRuZhi.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi)

                '使能命令
                doEnabledFileCommands(False)

                ''逐个设置
                'Me.lnkCZCYGJ.Enabled = blnEditMode
                'Me.lnkCZCYGJ.Text = "编辑稿件"
                'Me.lnkCZCYFJ.Enabled = blnEditMode
                'Me.lnkCZCYFJ.Text = "编辑附件"
                'Me.lnkCZCYXGWJ.Enabled = blnEditMode
                'Me.lnkCZCYXGWJ.Text = "编辑相关文件"
                'Me.lnkCZCYQPWJ.Enabled = blnEditMode And (objBaseFlowRenshiRuZhi.HJWJ <> "")
                'Me.lnkCZCYZSWJ.Enabled = blnEditMode And (objBaseFlowRenshiRuZhi.PJYJ <> "")

                '文件操作
                Me.mnuMain.FindItemById("mnuFILE_BCWJ").Enabled = blnEditMode
                Me.mnuMain.FindItemById("mnuFILE_QXXG").Enabled = blnEditMode

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_EditMode = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示签署意见的信息
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：当前编辑状态
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showOpinion( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseFlowRenshiRuZhi As Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi
            Dim objOpinionData As Josco.JSOA.Common.Data.FlowData
            Dim strQSYJ As String = ""
            Dim strBJYJ As String = ""
            Dim strYJLX As String = ""

            showOpinion = False

            Try
                objBaseFlowRenshiRuZhi = CType(Me.m_objsystemFlowObjectRenshiRuZhi.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi)

                '获取可查看的意见
                If Me.m_objsystemFlowObjectRenshiRuZhi.getOpinionData(strErrMsg, MyBase.UserXM, objOpinionData) = False Then
                    GoTo errProc
                End If

                '显示区域经理意见
                strYJLX = objBaseFlowRenshiRuZhi.TASK_QFWJ
                If Me.m_objsystemFlowObjectRenshiRuZhi.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblQFYJ.Text = strQSYJ
                Me.lnkCZQSYJ_QFBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '显示部门经理意见
                strYJLX = objBaseFlowRenshiRuZhi.TASK_FHWJ
                If Me.m_objsystemFlowObjectRenshiRuZhi.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblFHYJ.Text = strQSYJ
                Me.lnkCZQSYJ_FHBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '显示中介部意见
                strYJLX = objBaseFlowRenshiRuZhi.TASK_SHWJ
                If Me.m_objsystemFlowObjectRenshiRuZhi.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblSHYJ.Text = strQSYJ
                Me.lnkCZQSYJ_SHBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '显示办公室意见
                strYJLX = objBaseFlowRenshiRuZhi.TASK_HQWJ
                If Me.m_objsystemFlowObjectRenshiRuZhi.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblHQYJ.Text = strQSYJ
                Me.lnkCZQSYJ_HQBJ.Visible = Not blnEditMode And (strBJYJ <> "")


            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOpinionData)

            showOpinion = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOpinionData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示整个模块的信息
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：当前编辑状态
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            showModuleData_Main = False

            Try
                '显示输入窗信息
                If Me.showEditPanelInfo(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If

                '显示意见信息
                If Me.showOpinion(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If

                '显示操作命令
                If blnEditMode = True Then
                    If Me.showModuleData_EditMode(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    If Me.showModuleData_ReadMode(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

                '根据命令状态隐藏命令
                Me.doSetVisibleCommands()

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
        ' 获取当前记录的最新值
        '     strErrMsg      ：返回错误信息
        '     objNewData     ：返回当前记录的最新值的NameValueCollection
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getCurrentRecordNew( _
            ByRef strErrMsg As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            objNewData = Nothing

            Try
                objNewData = New System.Collections.Specialized.NameValueCollection

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJBS, Me.htxtWJBS.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_LSH, Me.txtLSH.Text)

                If Me.chkDDSZ.Checked = True Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_DDSZ, "1")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_DDSZ, "0")
                End If

                If Me.ddlJJCD.SelectedIndex < 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JJCD, "")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JJCD, Me.ddlJJCD.SelectedItem.Text)
                End If

                If Me.ddlMMDJ.SelectedIndex < 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_MMDJ, "")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_MMDJ, Me.ddlMMDJ.SelectedItem.Text)
                End If

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JGDZ, Me.txtJGDZ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJNF, Me.txtWJNF.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJXH, Me.txtWJXH.Text)

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JBRY, Me.txtJBRY.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JBRQ, Me.txtJBRQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JBDW, Me.txtJBDW.Text)

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJBT, Me.txtWJBT.Text)
                'objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_DBRS, Me.txtDBRS.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_BZXX, Me.txtBZXX.Text)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getCurrentRecordNew = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 设置当前记录的最新值
        '     strErrMsg      ：返回错误信息
        '     objNewData     ：当前记录的最新值的NameValueCollection
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function setCurrentRecordNew( _
            ByRef strErrMsg As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            Try
                Me.htxtWJBS.Value = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJBS), "")
                Me.txtLSH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_LSH), "")
                If objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_DDSZ), 0) = 1 Then
                    Me.chkDDSZ.Checked = True
                Else
                    Me.chkDDSZ.Checked = False
                End If

                Me.ddlJJCD.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJJCD, objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JJCD), ""))
                Me.ddlMMDJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlMMDJ, objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_MMDJ), ""))

                Me.txtJGDZ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JGDZ), "")
                Me.txtWJNF.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJNF), "")
                Me.txtWJXH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJXH), "")

                Me.txtJBRY.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JBRY), "")
                Me.txtJBRQ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JBRQ), "")
                Me.txtJBDW.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_JBDW), "")

                Me.txtWJBT.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJBT), "")
                'Me.txtDBRS.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_DBRS), "")
                Me.txtBZXX.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_BZXX), "")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            setCurrentRecordNew = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 删除下载或上载到Web服务器的临时文件
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doDeleteCacheFile(ByRef strErrMsg As String) As Boolean

            doDeleteCacheFile = False

            If Me.doDeleteCacheFile_GJ(strErrMsg) = False Then
                '可以不成功，形成垃圾文件！
            End If
            If Me.m_objsystemFlowObjectRenshiRuZhi.doDeleteCacheFile_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
                '可以不成功，形成垃圾文件！
            End If
            If Me.m_objsystemFlowObjectRenshiRuZhi.doDeleteCacheFile_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                '可以不成功，形成垃圾文件！
            End If

            doDeleteCacheFile = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 删除缓存稿件文件
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doDeleteCacheFile_GJ(ByRef strErrMsg As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doDeleteCacheFile_GJ = False

            Try
                If Me.m_strGJFileName <> "" Then
                    '删除临时缓存文件
                    Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                    Dim strFilePath As String = objBaseLocalFile.doMakePath(strGJPath, Me.m_strGJFileName)
                    If objBaseLocalFile.doDeleteFile(strErrMsg, strFilePath) = False Then
                        '可以不成功，产生垃圾数据
                    End If
                End If

                '强制重新获取文件！
                Me.htxtZWNRFileName.Value = ""
                Me.m_strGJFileName = ""

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doDeleteCacheFile_GJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 初始化控件
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            initializeControls = False

            Try
                Dim strWJBS As String = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS

                '仅在第一次调用页面时执行
                If Me.IsPostBack = False Then
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    With New Josco.JsKernal.web.ControlProcess
                        .doTranslateKey(Me.ddlJJCD)
                        .doTranslateKey(Me.ddlMMDJ)
                        .doTranslateKey(Me.txtJGDZ)
                        .doTranslateKey(Me.txtWJNF)
                        .doTranslateKey(Me.txtWJXH)
                        .doTranslateKey(Me.txtWJBT)
                        '.doTranslateKey(Me.txtDBRS)
                        .doTranslateKey(Me.txtBZXX)
                        .doTranslateKey(Me.txtJBDW)
                        .doTranslateKey(Me.txtJBRY)
                        .doTranslateKey(Me.txtJBRQ)
                        .doTranslateKey(Me.txtLSH)

                        .doTranslateKey(Me.txtJLBH)
                        .doTranslateKey(Me.txtRYDM)
                        .doTranslateKey(Me.txtRYXM)
                        .doTranslateKey(Me.txtRYNN)
                        .doTranslateKey(Me.txtNFPBM)
                        .doTranslateKey(Me.ddlZJDM)
                        .doTranslateKey(Me.txtNBDRQ)
                        .doTranslateKey(Me.txtZPSM)
                        .doTranslateKey(Me.txtXYRYS)
                        .doTranslateKey(Me.txtDBRYS)
                        .doTranslateKey(Me.ddlXL)

                        .doTranslateKey(Me.txtSFZHM)
                        .doTranslateKey(Me.txtBMJL)
                        .doTranslateKey(Me.txtWLJNFS)
                        .doTranslateKey(Me.txtSPSM)
                        .doTranslateKey(Me.ddlZPQD)
                        .doTranslateKey(Me.ddlYDYY)
                        .doTranslateKey(Me.ddlZPSM)

                        .doTranslateKey(Me.txtTDBH)
                        .doTranslateKey(Me.txtLXDH)
                    End With
                End If



                If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_FJ(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_XGWJ(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_RYXX(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_RYXX(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            initializeControls = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充“秘密等级”下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillMMDJList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.MimidengjiData.TABLE_GW_B_MIMIDENGJI
            Dim objsystemMimidengji As New Josco.JsKernal.BusinessFacade.systemMimidengji
            Dim objMimidengjiData As Josco.JsKernal.Common.Data.MimidengjiData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillMMDJList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillMMDJList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemMimidengji.getMimidengjiData(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objMimidengjiData) = False Then
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
                With objMimidengjiData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.MimidengjiData.FIELD_GW_B_MIMIDENGJI_MMDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.MimidengjiData.FIELD_GW_B_MIMIDENGJI_MMDJ), "")

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

            Josco.JsKernal.BusinessFacade.systemMimidengji.SafeRelease(objsystemMimidengji)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.MimidengjiData.SafeRelease(objMimidengjiData)

            doFillMMDJList = True
            Exit Function

errProc:
            Josco.JsKernal.BusinessFacade.systemMimidengji.SafeRelease(objsystemMimidengji)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.MimidengjiData.SafeRelease(objMimidengjiData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充“紧急程度”下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillJJCDList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.JinjichengduData.TABLE_GW_B_JINJICHENGDU
            Dim objsystemJinjichengdu As New Josco.JsKernal.BusinessFacade.systemJinjichengdu
            Dim objJinjichengduData As Josco.JsKernal.Common.Data.JinjichengduData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillJJCDList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillJJCDList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemJinjichengdu.getJinjichengduData(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objJinjichengduData) = False Then
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
                With objJinjichengduData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.JinjichengduData.FIELD_GW_B_JINJICHENGDU_JJDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.JinjichengduData.FIELD_GW_B_JINJICHENGDU_JJCD), "")

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

            Josco.JsKernal.BusinessFacade.systemJinjichengdu.SafeRelease(objsystemJinjichengdu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.JinjichengduData.SafeRelease(objJinjichengduData)

            doFillJJCDList = True
            Exit Function

errProc:
            Josco.JsKernal.BusinessFacade.systemJinjichengdu.SafeRelease(objsystemJinjichengdu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.JinjichengduData.SafeRelease(objJinjichengduData)
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
                        objListItem.Text = strName
                        objListItem.Value = strName
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

            doFillXueliList = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
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

                        Select Case strCode
                            Case "010.030.045"
                            Case Else
                                objListItem = New System.Web.UI.WebControls.ListItem
                                objListItem.Text = strName.Trim
                                objListItem.Value = strCode
                                objDropDownList.Items.Add(objListItem)
                        End Select
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
                If objsystemEstateRenshiGeneral.getDataSet_BiandongYuanyin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiGeneralData) = False Then
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
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYMC), "")

                        Select Case strCode
                            Case "001.001", "001.002", "001.003"
                                objListItem = New System.Web.UI.WebControls.ListItem
                                objListItem.Text = strName.Trim
                                objListItem.Value = strCode
                                objDropDownList.Items.Add(objListItem)
                        End Select
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
        ' 填充招聘渠道下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        
        '----------------------------------------------------------------
        Private Function doFillZPQDList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            Optional ByVal strWhere As String = "") As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_ZHAOPINQUDAO
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZPQDList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillYdyyList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据              
                If objsystemEstateRenshiXingye.getZhaopinqudaoData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiXingyeData) = False Then
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
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHAOPINQUDAO_DM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHAOPINQUDAO_MC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)

            doFillZPQDList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充招聘渠道下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败

        '----------------------------------------------------------------
        Private Function doGetJLBH(ByRef strErrMsg As String) As Boolean

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
        
            doGetJLBH = False
            strErrMsg = ""

            Try

                Dim strJLBH As String = ""
                '获取数据 
                If objsystemEstateRenshiXingye.getNewRZJLBH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJLBH) = False Then
                    GoTo errProc
                Else
                    Me.txtJLBH.Text = strJLBH
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
           
            doGetJLBH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
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

                

                '填充列表框
                If Me.IsPostBack = False Then
                    If Me.doFillJJCDList(strErrMsg, Me.ddlJJCD) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillMMDJList(strErrMsg, Me.ddlMMDJ) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillXueliList(strErrMsg, Me.ddlXL) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillZjdmList(strErrMsg, Me.ddlZJDM) = False Then
                        GoTo errProc
                    End If
                    Dim strWhere As String = ""
                    strWhere = "(a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM + " like '" + Me.htxtBDYY_RYZJ.Value + "%'"
                    strWhere = strWhere + " or " + "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM + " like '" + Me.htxtBDYY_NBTZ.Value + "%')"
                    If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY, strWhere) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillZPQDList(strErrMsg, Me.ddlZPQD, "") = False Then
                        GoTo errProc
                    End If
                    'If Me.doGetJLBH(strErrMsg) = False Then
                    '    GoTo errProc
                    'End If

                End If

                '获取接口参数
                Dim blnContinue As Boolean
                If Me.getInterfaceParameters(strErrMsg, blnContinue) = False Then
                    GoTo errProc
                End If
                If blnContinue = False Then
                    Exit Try
                End If

                '控件初始化
                If Me.initializeControls(strErrMsg) = False Then
                    GoTo errProc
                End If

                '检查权限
                Dim blnDo As Boolean
                If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If

                '是否弹出接收界面
                If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                    '首次进入
                    If Me.m_blnEditMode = False Then
                        '查看模式
                        If Me.m_objInterface.iWJBS <> "" Then
                            '自动解除自己的文件封锁
                            If Me.m_objsystemFlowObjectRenshiRuZhi.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                                GoTo errProc
                            End If
                        End If
                        If Me.m_objsystemFlowObjectRenshiRuZhi.mlJSWJ = True Then
                            '自动接收文件
                            Me.htxtSelectMenuID.Value = "mnuJJCL_JSWJ"
                            If Me.doReceiveFile(strErrMsg, "lnkMenu") = False Then
                                GoTo errProc
                            End If
                        End If
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

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi.SafeRelease(Me.m_objsystemFlowObjectRenshiRuZhi)
        End Sub











        '----------------------------------------------------------------
        '网格事件处理器
        '----------------------------------------------------------------
        '实现对grdFJ网格行、列的固定
        Sub grdFJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdFJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_FJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_FJ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_FJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdFJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdFJ_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFJ.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdFJ.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        '打开附件内容查看或编辑
                        If Me.m_blnEditMode = True Then
                            '编辑模式下
                            If Me.doOpenFJ(strErrMsg, strControlId, True, False) = False Then
                                GoTo errProc
                            End If
                        Else
                            '查看模式下
                            Dim blnAutoEnter As Boolean
                            If Me.m_objsystemFlowObjectRenshiRuZhi.getCanAutoEnterEditMode( _
                                strErrMsg, _
                                MyBase.UserId, _
                                Me.m_blnEditMode, _
                                Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled, _
                                Me.m_blnEnforeEdit, _
                                blnAutoEnter) = False Then
                                GoTo errProc
                            End If
                            If Me.doOpenFJ(strErrMsg, strControlId, blnAutoEnter, blnAutoEnter) = False Then
                                GoTo errProc
                            End If
                        End If

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

        '实现对grdXGWJ网格行、列的固定
        Sub grdXGWJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdXGWJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_XGWJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_XGWJ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_XGWJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdXGWJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdXGWJ_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdXGWJ.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdXGWJ.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        '打开附件内容查看或编辑
                        If Me.m_blnEditMode = True Then
                            '编辑模式下
                            If Me.doOpenXGWJ(strErrMsg, strControlId, True, False) = False Then
                                GoTo errProc
                            End If
                        Else
                            '查看模式下
                            Dim blnAutoEnter As Boolean
                            If Me.m_objsystemFlowObjectRenshiRuZhi.getCanAutoEnterEditMode( _
                                strErrMsg, _
                                MyBase.UserId, _
                                Me.m_blnEditMode, _
                                Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled, _
                                Me.m_blnEnforeEdit, _
                                blnAutoEnter) = False Then
                                GoTo errProc
                            End If
                            If Me.doOpenXGWJ(strErrMsg, strControlId, blnAutoEnter, blnAutoEnter) = False Then
                                GoTo errProc
                            End If
                        End If

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

        '实现对grdRYXX网格行、列的固定
        Sub grdRYXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdRYXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_RYXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_RYXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_RYXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdRYXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        'zengxianglin 2009-05-21
        Private Sub grdRYXX_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdRYXX.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdRYXX.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
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
        'zengxianglin 2009-05-21














        Private Function doRefreshData(ByRef strErrMsg As String) As Boolean

            doRefreshData = False

            Try
                '创建工作流对象
                Dim strWJBS As String = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi.SafeRelease(Me.m_objsystemFlowObjectRenshiRuZhi)

                If Me.getModuleData_Main(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_FJ(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_XGWJ(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_RYXX(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_RYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '检查权限
                Dim blnDo As Boolean
                If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doRefreshData = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 直接打开附件内容进行查看或编辑
        '     strErrMsg            ：返回错误信息
        '     strControlId         ：点击该控件进入本处理
        '     blnEditMode          ：=True：编辑,False-查看
        '     blnAutoSave          ：=True：退出附件窗口时自动保存附件内容到数据库，False-不保存到数据库
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Private Function doOpenFJ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal blnEditMode As Boolean, _
            ByVal blnAutoSave As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim objIFlowFujianInfo As Josco.JSOA.BusinessFacade.IFlowFujianInfo
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim objDataRow As System.Data.DataRow

            doOpenFJ = False

            Try
                '检查
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_FJ.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdFJ.SelectedIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With
                If objDataRow Is Nothing Then
                    strErrMsg = "错误：没有选定要打开的附件！"
                    GoTo errProc
                End If

                '检查文件是否发送过？
                Dim blnHasSendOnce As Boolean
                If Me.m_objsystemFlowObjectRenshiRuZhi.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                objIFlowFujianInfo = New Josco.JSOA.BusinessFacade.IFlowFujianInfo
                With objIFlowFujianInfo
                    '一般信息
                    If blnEditMode = True Then
                        .iEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    Else
                        .iEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    End If
                    .iEnforeEdit = Me.m_blnEnforeEdit
                    .iAutoSave = blnAutoSave
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiRuZhi.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ), "")

                    .iSourceControlId = strControlId
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
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowFujianInfo)
                strUrl = ""
                strUrl += "../../flow/flow_fujian_info.aspx"
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
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doOpenFJ = True
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doRefresh(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            doRefresh = False
            strErrMsg = ""

            Try
                If Me.doRefreshData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doRefresh = True
            Exit Function

errProc:
            Exit Function

        End Function

        Private Function doCancel(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doCancel = False
            strErrMsg = ""

            Try
                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：您确定要取消录入的内容吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '返回处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Select Case Me.m_objInterface.iEditMode
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '如果是新增时则直接退回

                            '清除缓存文件
                            If Me.doDeleteCacheFile(strErrMsg) = False Then
                                '可以不成功，形成垃圾文件！
                            End If

                            '设置返回参数
                            Me.m_objInterface.oExitMode = False
                            '返回到调用模块，并附加返回参数
                            '要返回的SessionId
                            Dim strSessionId As String
                            strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                            'SessionId附加到返回的Url
                            Dim strUrl As String
                            strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                            '释放模块资源
                            Me.releaseModuleParameters()
                            Me.releaseInterfaceParameters()
                            '返回
                            Response.Redirect(strUrl)
                        Case Else
                            '解除文件编辑封锁
                            If Me.m_objsystemFlowObjectRenshiRuZhi.doLockFile(strErrMsg, "", False) = False Then
                                GoTo errProc
                            End If

                            '进入查看状态
                            Me.m_objInterface.iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                            Dim intTemp As Integer = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                            Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                            Me.htxtEditType.Value = intTemp.ToString()
                            Me.m_blnEditMode = False
                            Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()

                            '强制重新获取文件！
                            If Me.doDeleteCacheFile(strErrMsg) = False Then
                                '可以不成功，形成垃圾文件！
                            End If

                            '刷新显示
                            If Me.doRefreshData(strErrMsg) = False Then
                                GoTo errProc
                            End If
                    End Select
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doCancel = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doClose(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            doClose = False
            strErrMsg = ""

            Try
                '清除缓存文件
                If Me.doDeleteCacheFile(strErrMsg) = False Then
                    '可以不成功，形成垃圾文件！
                End If

                '设置返回参数
                Me.m_objInterface.oExitMode = False
                '返回到调用模块，并附加返回参数
                '要返回的SessionId
                Dim strSessionId As String
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                'SessionId附加到返回的Url
                Dim strUrl As String
                strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                '释放模块资源
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()
                '返回
                Response.Redirect(strUrl)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doClose = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 处理修改文件的命令
        '----------------------------------------------------------------
        Private Function doModify(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doModify = False
            strErrMsg = ""

            Try
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '文件检查
                    Dim strWJBS As String = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    If strWJBS = "" Then
                        strErrMsg = "错误：没有文件进行编辑！"
                        GoTo errProc
                    End If

                    '自动清除自己对该文件的编辑封锁
                    If Me.m_objsystemFlowObjectRenshiRuZhi.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                        GoTo errProc
                    End If

                    '封锁检查
                    Dim strBMMC As String
                    Dim strRYMC As String
                    Dim blnDo As Boolean
                    If Me.m_objsystemFlowObjectRenshiRuZhi.getFileLocked(strErrMsg, blnDo, strBMMC, strRYMC) = False Then
                        GoTo errProc
                    End If
                    If blnDo = True Then
                        strErrMsg = "错误：[" + strBMMC + "]单位的[" + strRYMC + "]人员正在编辑本文件，请稍后再进行编辑！"
                        GoTo errProc
                    End If

                    '是否定稿?
                    If Me.m_blnEnforeEdit = True Then
                        Dim strTitle As String
                        strTitle = ""
                        strTitle = strTitle + "提示：文件已经定稿，您想根据领导的意见继续修改有关内容，"
                        strTitle = strTitle + vbCr
                        strTitle = strTitle + "    可按 <是> 按钮进行强行编辑，"
                        strTitle = strTitle + vbCr
                        strTitle = strTitle + vbCr
                        strTitle = strTitle + "    但系统将把您的操作自动记录下来。"
                        strTitle = strTitle + vbCr
                        strTitle = strTitle + vbCr
                        strTitle = strTitle + "    要查看系统记录情况，请按<查看日志>！"
                        objMessageProcess.doConfirmMessage(Me.popMessageObject, strTitle, strControlId, intStep)
                        Exit Try
                    End If
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '进入编辑状态
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取应答信息
                    Dim blnOK As Boolean = True

                    '准备编辑
                    If blnOK = True Then
                        '进行编辑封锁
                        If Me.m_objsystemFlowObjectRenshiRuZhi.doLockFile(strErrMsg, MyBase.UserId, True) = False Then
                            GoTo errProc
                        End If

                        '进入编辑状态
                        Me.m_objInterface.iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Dim intTemp As Integer = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.htxtEditType.Value = intTemp.ToString()
                        Me.m_blnEditMode = True
                        Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()

                        '强制重新获取文件！
                        If Me.doDeleteCacheFile(strErrMsg) = False Then
                            '可以不成功，形成垃圾文件！
                        End If

                        '重新显示
                        If Me.doRefreshData(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doModify = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doSave(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objOldData As Josco.JSOA.Common.Workflow.BaseFlowObject
            Dim strWJBS As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objParams As New System.Collections.Specialized.ListDictionary
            Dim objOldXGWJData As Josco.JSOA.Common.Data.FlowData
            Dim objOldFJData As Josco.JSOA.Common.Data.FlowData

            doSave = False
            strErrMsg = ""

            Try
                If Me.grdRYXX.Items.Count < 1 Then
                    strErrMsg = "提示：您还没有添加任何人员，不能进行保存！如果想退出当前页面，请选择取消文件！"
                    GoTo errProc
                End If
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Me.txtWJBT.Text = Me.txtWJBT.Text + "(" + Me.htxtRYXM.Value + ")"
                End Select

                '获取记录新值
                If Me.getCurrentRecordNew(strErrMsg, objNewData) = False Then
                    GoTo errProc
                End If

                '获取记录旧值
                objOldData = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData
                objenumEditType = Me.m_objInterface.iEditMode

                '获取稿件文件
                Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                Dim strGJFile As String = Me.m_strGJFileName
                If strGJFile <> "" Then
                    strGJFile = objBaseLocalFile.doMakePath(strGJPath, strGJFile)
                End If

                '获取原附件、相关文件数据
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                    Case Else
                        If Me.m_objsystemFlowObjectRenshiRuZhi.getFujianData(strErrMsg, objOldFJData) = False Then
                            GoTo errProc
                        End If
                        If Me.m_objsystemFlowObjectRenshiRuZhi.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                            GoTo errProc
                        End If
                End Select

                '准备额外参数
                objParams.Clear()
                objParams.Add(0, Me.m_objDataSet_RYXX)

                '保存数据
                With Me.m_objsystemFlowObjectRenshiRuZhi
                    If .doSaveFileVariantParam( _
                        strErrMsg, _
                        MyBase.UserId, MyBase.UserPassword, _
                        MyBase.UserXM, _
                        .pmEnforeEdit, _
                        objNewData, objOldData, objenumEditType, _
                        strGJFile, _
                        Me.m_objDataSet_FJ, Me.m_objDataSet_XGWJ, objParams) = False Then
                        GoTo errProc
                    End If
                End With
                strWJBS = objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJBS)

                '写审计日志
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        If Me.m_objsystemFlowObjectRenshiRuZhi.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "创建了[" + strWJBS + "]文件！") = False Then
                            '忽略
                        End If
                    Case Else
                        If Me.m_objsystemFlowObjectRenshiRuZhi.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "改动了[" + strWJBS + "]文件！") = False Then
                            '忽略
                        End If
                        If Me.m_objsystemFlowObjectRenshiRuZhi.doWriteUserLog_Fujian(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_FJ, objOldFJData) = False Then
                            '忽略
                        End If
                        If Me.m_objsystemFlowObjectRenshiRuZhi.doWriteUserLog_XGWJ(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_XGWJ, objOldXGWJData) = False Then
                            '忽略
                        End If
                End Select

                '进入查看状态

                Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS = strWJBS
                Me.m_objInterface.iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                Me.m_objInterface.iWJBS = strWJBS
                Dim intTemp As Integer = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                Me.htxtEditType.Value = intTemp.ToString()
                Me.m_blnEditMode = False
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()

                '强制重新获取文件！
                If Me.doDeleteCacheFile(strErrMsg) = False Then
                    '可以不成功，形成垃圾文件！
                End If

                '刷新显示
                If Me.doRefreshData(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objParams)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)

            doSave = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objParams)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Exit Function

        End Function

        Private Sub doOpenFJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowFujian As Josco.JSOA.BusinessFacade.IFlowFujian
            Dim blnHasSendOnce As Boolean = False
            Dim strNewSessionId As String
            Dim strSessionId As String

            Try
                '文件发送过？
                If Me.m_objsystemFlowObjectRenshiRuZhi.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                objIFlowFujian = New Josco.JSOA.BusinessFacade.IFlowFujian
                With objIFlowFujian
                    '一般信息
                    If Me.m_blnEditMode = True Then
                        .iEditMode = Me.m_blnEditMode
                        .iAutoSave = False
                    Else
                        Dim blnAutoEnter As Boolean
                        If Me.m_objsystemFlowObjectRenshiRuZhi.getCanAutoEnterEditMode( _
                            strErrMsg, _
                            MyBase.UserId, _
                            Me.m_blnEditMode, _
                            Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled, _
                            Me.m_blnEnforeEdit, _
                            blnAutoEnter) = False Then
                            GoTo errProc
                        End If
                        .iEditMode = blnAutoEnter
                        .iAutoSave = blnAutoEnter
                    End If
                    .iEnforeEdit = Me.m_blnEnforeEdit
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiRuZhi.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iDataSet_FJ = Me.m_objDataSet_FJ

                    .iSourceControlId = strControlId
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
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowFujian)
                strUrl = ""
                strUrl += "../../flow/flow_fujian.aspx"
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

        '----------------------------------------------------------------
        ' 直接打开具体的相关文件的附件内容进行查看或编辑
        '     strErrMsg            ：返回错误信息
        '     strControlId         ：点击该控件进入本处理
        '     blnEditMode          ：=True：编辑,False-查看
        '     blnAutoSave          ：=True：退出附件窗口时自动保存附件内容到数据库，False-不保存到数据库
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Private Function doOpenXGWJ_FJ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal blnEditMode As Boolean, _
            ByVal blnAutoSave As Boolean) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim objIFlowXgwjfjInfo As Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim objDataRow As System.Data.DataRow

            doOpenXGWJ_FJ = False

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With
                If objDataRow Is Nothing Then
                    strErrMsg = "错误：没有选定要打开的附件！"
                    GoTo errProc
                End If

                '检查文件是否发送过？
                Dim blnHasSendOnce As Boolean
                If Me.m_objsystemFlowObjectRenshiRuZhi.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                objIFlowXgwjfjInfo = New Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
                With objIFlowXgwjfjInfo
                    '一般信息
                    If blnEditMode = True Then
                        .iEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    Else
                        .iEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    End If
                    .iEnforeEdit = Me.m_blnEnforeEdit
                    .iAutoSave = blnAutoSave
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiRuZhi.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ), "")

                    .iSourceControlId = strControlId
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
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowXgwjfjInfo)
                strUrl = ""
                strUrl += "../../flow/flow_xgwjfj_info.aspx"
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
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doOpenXGWJ_FJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 打开文件
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doOpenXGWJ_LJ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            Dim strISessionId As String = ""
            Dim strMSessionId As String = ""
            Dim strUrl As String

            doOpenXGWJ_LJ = False

            Try
                '检查当前选择
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If

                '获取文件标识和文件类型
                Dim strFlowTypeName As String
                Dim strWJBS As String
                Dim strNGR As String
                Dim intColIndex(3) As Integer
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBS)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJLX)
                intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_NGR)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdXGWJ.Items(Me.grdXGWJ.SelectedIndex), intColIndex(0))
                strFlowTypeName = objDataGridProcess.getDataGridCellValue(Me.grdXGWJ.Items(Me.grdXGWJ.SelectedIndex), intColIndex(1))
                strNGR = objDataGridProcess.getDataGridCellValue(Me.grdXGWJ.Items(Me.grdXGWJ.SelectedIndex), intColIndex(2))
                If strWJBS = "" Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If
                If strFlowTypeName = "" Then
                    strErrMsg = "错误：当前文件类型不明确！"
                    GoTo errProc
                End If

                '创建指定工作流对象
                Dim strType As String
                Dim strName As String
                strType = Josco.JsKernal.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JsKernal.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '检查文件是否能看？
                Dim blnCanRead As Boolean
                If objsystemFlowObject.canReadFile(strErrMsg, MyBase.UserXM, blnCanRead) = False Then
                    GoTo errProc
                End If
                '如果不能看，则拟稿人自动给MyBase.UserXM补阅
                If blnCanRead = False Then
                    If strNGR Is Nothing Then strNGR = ""
                    strNGR = strNGR.Trim
                    If strNGR = "" Then
                        strErrMsg = "错误：无法确定文件初始创建人！"
                        GoTo errProc
                    End If
                    If objsystemFlowObject.doSendBuyueJJD(strErrMsg, strNGR, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If
                strISessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)

                '计算Url
                If objsystemFlowObject.doFileOpen( _
                    strErrMsg, _
                    strControlId, _
                    strWJBS, _
                    strMSessionId, _
                    strISessionId, _
                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect, _
                    Request, Session, _
                    strUrl) = False Then
                    GoTo errProc
                End If
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doOpenXGWJ_LJ = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 直接打开具体的相关文件内容进行查看或编辑
        '     strErrMsg            ：返回错误信息
        '     strControlId         ：点击该控件进入本处理
        '     blnEditMode          ：=True：编辑,False-查看
        '     blnAutoSave          ：=True：退出附件窗口时自动保存附件内容到数据库，False-不保存到数据库
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Private Function doOpenXGWJ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal blnEditMode As Boolean, _
            ByVal blnAutoSave As Boolean) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim objDataRow As System.Data.DataRow

            doOpenXGWJ = False

            Try
                '检查
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前附件信息！"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With
                If objDataRow Is Nothing Then
                    strErrMsg = "错误：没有选定要打开的附件！"
                    GoTo errProc
                End If
                Dim intLB As Integer
                intLB = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS), 0)

                '分类处理
                Select Case intLB
                    Case Josco.JsKernal.Common.Data.FlowData.enumXGWJLB.FlowFile
                        '打开工作流文件
                        If Me.doOpenXGWJ_LJ(strErrMsg, strControlId) = False Then
                            GoTo errProc
                        End If
                    Case Josco.JsKernal.Common.Data.FlowData.enumXGWJLB.FujianFile
                        '打开相关文件附件
                        If Me.doOpenXGWJ_FJ(strErrMsg, strControlId, blnEditMode, blnAutoSave) = False Then
                            GoTo errProc
                        End If
                    Case Else
                        strErrMsg = "错误：无效的类型！"
                        GoTo errProc
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doOpenXGWJ = True
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Sub doOpenXGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowXgwj As Josco.JSOA.BusinessFacade.IFlowXgwj
            Dim blnHasSendOnce As Boolean = False
            Dim strNewSessionId As String
            Dim strSessionId As String

            Try
                '文件发送过？
                If Me.m_objsystemFlowObjectRenshiRuZhi.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                objIFlowXgwj = New Josco.JSOA.BusinessFacade.IFlowXgwj
                With objIFlowXgwj
                    '一般信息
                    If Me.m_blnEditMode = True Then
                        .iEditMode = Me.m_blnEditMode
                        .iAutoSave = False
                    Else
                        Dim blnAutoEnter As Boolean
                        If Me.m_objsystemFlowObjectRenshiRuZhi.getCanAutoEnterEditMode( _
                            strErrMsg, _
                            MyBase.UserId, _
                            Me.m_blnEditMode, _
                            Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled, _
                            Me.m_blnEnforeEdit, _
                            blnAutoEnter) = False Then
                            GoTo errProc
                        End If
                        .iEditMode = blnAutoEnter
                        .iAutoSave = blnAutoEnter
                    End If
                    .iEnforeEdit = Me.m_blnEnforeEdit
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiRuZhi.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iDataSet_XGWJ = Me.m_objDataSet_XGWJ

                    .iSourceControlId = strControlId
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
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowXgwj)
                strUrl = ""
                strUrl += "../../flow/flow_xgwj.aspx"
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

        '----------------------------------------------------------------
        ' 处理打开稿件的命令
        '     strControlId         ：接收回发信息的控件ID
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Private Sub doOpenGJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowEditWord As Josco.JSOA.BusinessFacade.IFlowEditWord
            Dim blnHasSendOnce As Boolean = False
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strGJFile As String = ""
            Dim strUrl As String

            Try
                '文件发送过？
                If Me.m_objsystemFlowObjectRenshiRuZhi.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
                    GoTo errProc
                End If

                '获取稿件
                Dim strMBPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToWordTemplate)
                Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                Dim strCacheFile As String = Me.m_strGJFileName
                If Me.m_objsystemFlowObjectRenshiRuZhi.getGJFile(strErrMsg, Me.m_blnEditMode, strCacheFile, strMBPath, strGJPath, strGJFile) = False Then
                    GoTo errProc
                End If
                Me.htxtZWNRFileName.Value = strCacheFile
                Me.m_strGJFileName = strCacheFile

                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                objIFlowEditWord = New Josco.JSOA.BusinessFacade.IFlowEditWord
                With objIFlowEditWord
                    '************************************************************************************************
                    If Me.m_blnEditMode = True Then
                        .iEditMode = Me.m_blnEditMode
                        .iAutoSave = False
                    Else
                        '能自动编辑？
                        Dim blnAutoEnter As Boolean
                        If Me.m_objsystemFlowObjectRenshiRuZhi.getCanAutoEnterEditMode( _
                            strErrMsg, _
                            MyBase.UserId, _
                            Me.m_blnEditMode, _
                            Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled, _
                            Me.m_blnEnforeEdit, _
                            blnAutoEnter) = False Then
                            GoTo errProc
                        End If
                        .iEditMode = blnAutoEnter
                        .iAutoSave = blnAutoEnter
                    End If
                    .iEnforeEdit = Me.m_blnEnforeEdit
                    '************************************************************************************************
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    '************************************************************************************************
                    .iGJFileSpec = strGJFile
                    .iobjDataSet_FJ = Me.m_objDataSet_FJ
                    .iobjDataSet_XGWJ = Me.m_objDataSet_XGWJ
                    .iobjNewData = Nothing
                    '************************************************************************************************
                    .iCanQSYJ = Me.m_objsystemFlowObjectRenshiRuZhi.mlTXYJ
                    If .iCanQSYJ = False Then
                        .iCanQSYJ = Me.m_objsystemFlowObjectRenshiRuZhi.mlBDPS
                        If .iCanQSYJ = False Then
                            '不能签署意见，接口缺省参数
                        Else
                            '补登领导批示
                            .iDLR = MyBase.UserXM
                            .iDLRDM = MyBase.UserId
                            .iDLRBMDM = MyBase.UserBmdm
                            .iSPR = ""
                        End If
                    Else
                        '自己签署意见
                        .iDLR = ""
                        .iDLRDM = ""
                        .iDLRBMDM = ""
                        .iSPR = MyBase.UserXM
                    End If
                    '************************************************************************************************
                    '稿件界面控制参数
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiRuZhi.swgjShowTrackRevisions And blnHasSendOnce
                    .iCanExportGJ = Me.m_objsystemFlowObjectRenshiRuZhi.swgjExportFile
                    .iCanImportGJ = Me.m_objsystemFlowObjectRenshiRuZhi.swgjImportFile
                    .iCanSelectTGWJ = Me.m_objsystemFlowObjectRenshiRuZhi.swgjSelectGJ
                    .iHasSendOnce = blnHasSendOnce

                    .iSourceControlId = strControlId
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
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowEditWord)
                strUrl = ""
                strUrl += "../../flow/flow_editword.aspx"
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

        Private Function doSendFile(ByRef strErrMsg As String, ByVal strControlId As String, ByVal blnWTFS As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doSendFile = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowSend As Josco.JSOA.BusinessFacade.IFlowSend
                Dim strUrl As String
                objIFlowSend = New Josco.JSOA.BusinessFacade.IFlowSend
                With objIFlowSend
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iBLR = MyBase.UserXM
                    .iWTFS = blnWTFS
                    .iDLR = ""

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowSend)
                strUrl = ""
                strUrl += "../../flow/flow_send.aspx"
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

            doSendFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doReceiveFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doReceiveFile = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowReceive As Josco.JSOA.BusinessFacade.IFlowReceive
                Dim strUrl As String
                objIFlowReceive = New Josco.JSOA.BusinessFacade.IFlowReceive
                With objIFlowReceive
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowReceive)
                strUrl = ""
                strUrl += "../../flow/flow_receive.aspx"
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

            doReceiveFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doShouhuiFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doShouhuiFile = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowShouhui As Josco.JSOA.BusinessFacade.IFlowShouhui
                Dim strUrl As String
                objIFlowShouhui = New Josco.JSOA.BusinessFacade.IFlowShouhui
                With objIFlowShouhui
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowShouhui)
                strUrl = ""
                strUrl += "../../flow/flow_shouhui.aspx"
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

            doShouhuiFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doTuihuiFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doTuihuiFile = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowTuihui As Josco.JSOA.BusinessFacade.IFlowTuihui
                Dim strUrl As String
                objIFlowTuihui = New Josco.JSOA.BusinessFacade.IFlowTuihui
                With objIFlowTuihui
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iCanReadFile = True

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowTuihui)
                strUrl = ""
                strUrl += "../../flow/flow_tuihui.aspx"
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

            doTuihuiFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doIReadFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            doIReadFile = False
            strErrMsg = ""

            Try
                '处理
                If Me.m_objsystemFlowObjectRenshiRuZhi.doIReadFile(strErrMsg, MyBase.UserXM) = False Then
                    GoTo errProc
                End If

                '刷新数据
                If Me.doRefreshData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '提示信息
                objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：阅读成功！")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIReadFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doIDoNotProcess(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doIDoNotProcess = False
            strErrMsg = ""

            Try
                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确信[被退回或被收回的文件]不用处理吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '处理业务
                    If Me.m_objsystemFlowObjectRenshiRuZhi.doIDoNotProcess(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    '刷新数据
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：已经将退回给我的文件、或被收回的文件成功设置为[不用处理]！")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIDoNotProcess = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doICompleteTask(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doICompleteTask = False
            strErrMsg = ""

            Try
                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定自己的事情已经[处理完毕]吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '处理业务
                    If Me.m_objsystemFlowObjectRenshiRuZhi.doICompleteTask(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    '刷新数据
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：成功设置为[处理完毕]，本文件将不再显示在您的[未办事宜]中！")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doICompleteTask = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doIStopFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doIStopFile = False
            strErrMsg = ""

            Try
                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：文件暂缓处理将导致其他人不能处理本文件,要继续吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '处理业务
                    If Me.m_objsystemFlowObjectRenshiRuZhi.doIStopFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    '刷新数据
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：文件成功设置为[暂缓处理]，将不再显示在您的[未办事宜]中，而显示在[缓办事宜]中！")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIStopFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doIContinueFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doIContinueFile = False
            strErrMsg = ""

            Try
                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：文件已经暂缓处理，您确定准备继续办理本文件吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '处理业务
                    If Me.m_objsystemFlowObjectRenshiRuZhi.doIContinueFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    '刷新数据
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：文件现在可以继续处理！")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIContinueFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doIZuofeiFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doIZuofeiFile = False
            strErrMsg = ""

            Try
                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要作废本稿件吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '处理业务
                    If Me.m_objsystemFlowObjectRenshiRuZhi.doIZuofeiFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    '刷新数据
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：已经将稿件作废，您可以删除该稿件，也可以再启用该稿件！")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIZuofeiFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doIQiyongFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doIQiyongFile = False
            strErrMsg = ""

            Try
                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要启用本稿件吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '处理业务
                    If Me.m_objsystemFlowObjectRenshiRuZhi.doIQiyongFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    '刷新数据
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：稿件已经重新启用，可以继续进行审批处理！")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIQiyongFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doCompleteFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intStep As Integer

            doCompleteFile = False
            strErrMsg = ""

            Try
                '检查并询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '检查
                    Dim strUserList As String
                    If Me.m_objsystemFlowObjectRenshiRuZhi.getUncompleteTaskRY(strErrMsg, MyBase.UserXM, strUserList) = False Then
                        GoTo errProc
                    End If
                    If strUserList <> "" Then
                        strErrMsg = "错误：[" + strUserList + "]还没有处理完毕，您暂时不能办结！"
                        GoTo errProc
                    End If

                    '询问
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：文件办结后就不允许任何改动，要继续吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '处理业务
                    If Me.m_objsystemFlowObjectRenshiRuZhi.doCompleteFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    '刷新数据
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '记录日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]对[" + Me.m_objInterface.iWJBS + "," + Me.txtWJBT.Text + "]进行了[办结处理]！")


                    If Me.doBuyueComplete(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：文件成功办结！")

                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doCompleteFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Public Function doBuyueComplete(ByRef strErrMsg As String) As Boolean
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intStep As Integer

            doBuyueComplete = False
            strErrMsg = ""

            Try
                Dim intRows As Integer
                Dim i As Integer
                Dim intIndex As Integer
                Dim strValue As String
                Dim blnC As Boolean = False

                intRows = Me.grdRYXX.Items.Count
                Dim blnComplete As Boolean = False
                For i = 0 To intRows - 1
                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPR)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)

                    If strValue.Trim <> "" Then
                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NBDRQ)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                        If strValue.Trim <> "" Then
                            blnC = True
                        End If
                    End If
                Next
goBreak:

                If blnC = True Then
                    '解析接收人
                    Dim strArray() As String
                    Dim strFSR As String = MyBase.UserXM
                    Dim strJJSM As String = "入职"
                    Dim strName As String = "杨先知"
                    Dim strJSRList As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.RS_RUZHI_RYMC
                    strArray = strJSRList.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)

                    '获取“发送序号”
                    Dim strFSXH As String
                    If Me.m_objsystemFlowObjectRenshiRuZhi.getNewFSXH(strErrMsg, strFSXH) = False Then
                        GoTo errProc
                    End If

                    '逐个发送
                    Dim intCount As Integer
                    intCount = strArray.Length
                    For i = 0 To intCount - 1 Step 1
                        If Me.m_objsystemFlowObjectRenshiRuZhi.doSendBuyueTongzhi(strErrMsg, strFSXH, strFSR, strArray(i), strJJSM) = False Then
                            GoTo errProc
                        End If
                    Next

                    '记录日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]对[" + strFSR + "]进行了文件 " + Me.txtWJBT.Text + "[补阅处理]！")
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doBuyueComplete = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function
        End Function

        Private Function doImportQPYJ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doImportQPYJ = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowImportQP As Josco.JSOA.BusinessFacade.IFlowImportQP
                Dim strUrl As String
                objIFlowImportQP = New Josco.JSOA.BusinessFacade.IFlowImportQP
                With objIFlowImportQP
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iTitle = "导入签批件的电子文件"

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowImportQP)
                strUrl = ""
                strUrl += "../../flow/flow_importqp.aspx"
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

            doImportQPYJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doImportZSWJ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doImportZSWJ = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowImportZS As Josco.JSOA.BusinessFacade.IFlowImportZS
                Dim strUrl As String
                objIFlowImportZS = New Josco.JSOA.BusinessFacade.IFlowImportZS
                With objIFlowImportZS
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iTitle = "导入签批文件的扫描件"

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowImportZS)
                strUrl = ""
                strUrl += "../../flow/flow_importzs.aspx"
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

            doImportZSWJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doCuiban(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doCuiban = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowCuiban As Josco.JSOA.BusinessFacade.IFlowCuiban
                Dim strUrl As String
                objIFlowCuiban = New Josco.JSOA.BusinessFacade.IFlowCuiban
                With objIFlowCuiban
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowCuiban)
                strUrl = ""
                strUrl += "../../flow/flow_cuiban.aspx"
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

            doCuiban = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doDuban(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doDuban = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowDuban As Josco.JSOA.BusinessFacade.IFlowDuban
                Dim strUrl As String
                objIFlowDuban = New Josco.JSOA.BusinessFacade.IFlowDuban
                With objIFlowDuban
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowDuban)
                strUrl = ""
                strUrl += "../../flow/flow_duban.aspx"
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

            doDuban = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doDubanjg(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doDubanjg = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowDubanjg As Josco.JSOA.BusinessFacade.IFlowDubanjg
                Dim strUrl As String
                objIFlowDubanjg = New Josco.JSOA.BusinessFacade.IFlowDubanjg
                With objIFlowDubanjg
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowDubanjg)
                strUrl = ""
                strUrl += "../../flow/flow_dubanjg.aspx"
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

            doDubanjg = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanLZQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanLZQK = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowLzqk As Josco.JSOA.BusinessFacade.IFlowLzqk
                Dim strUrl As String
                objIFlowLzqk = New Josco.JSOA.BusinessFacade.IFlowLzqk
                With objIFlowLzqk
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowLzqk)
                strUrl = ""
                strUrl += "../../flow/flow_lzqk.aspx"
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

            doChakanLZQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanSPYJ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanSPYJ = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowSpyj As Josco.JSOA.BusinessFacade.IFlowSpyj
                Dim strUrl As String
                objIFlowSpyj = New Josco.JSOA.BusinessFacade.IFlowSpyj
                With objIFlowSpyj
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowSpyj)
                strUrl = ""
                strUrl += "../../flow/flow_spyj.aspx"
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

            doChakanSPYJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanCZRZ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanCZRZ = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowCzrz As Josco.JSOA.BusinessFacade.IFlowCzrz
                Dim strUrl As String
                objIFlowCzrz = New Josco.JSOA.BusinessFacade.IFlowCzrz
                With objIFlowCzrz
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowCzrz)
                strUrl = ""
                strUrl += "../../flow/flow_czrz.aspx"
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

            doChakanCZRZ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanCBQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanCBQK = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowCkcbqk As Josco.JSOA.BusinessFacade.IFlowCkcbqk
                Dim strUrl As String
                objIFlowCkcbqk = New Josco.JSOA.BusinessFacade.IFlowCkcbqk
                With objIFlowCkcbqk
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowCkcbqk)
                strUrl = ""
                strUrl += "../../flow/flow_ckcbqk.aspx"
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

            doChakanCBQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanDBQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanDBQK = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowCkdbqk As Josco.JSOA.BusinessFacade.IFlowCkdbqk
                Dim strUrl As String
                objIFlowCkdbqk = New Josco.JSOA.BusinessFacade.IFlowCkdbqk
                With objIFlowCkdbqk
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowCkdbqk)
                strUrl = ""
                strUrl += "../../flow/flow_ckdbqk.aspx"
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

            doChakanDBQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanBYQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanBYQK = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowByqk As Josco.JSOA.BusinessFacade.IFlowByqk
                Dim strUrl As String
                objIFlowByqk = New Josco.JSOA.BusinessFacade.IFlowByqk
                With objIFlowByqk
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iBLR = MyBase.UserXM
                    .iYjjhList = ""

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowByqk)
                strUrl = ""
                strUrl += "../../flow/flow_byqk.aspx"
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

            doChakanBYQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doBuyue(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doBuyue = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowBycl As Josco.JSOA.BusinessFacade.IFlowBycl
                Dim strUrl As String
                objIFlowBycl = New Josco.JSOA.BusinessFacade.IFlowBycl
                With objIFlowBycl
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowBycl)
                strUrl = ""
                strUrl += "../../flow/flow_bycl.aspx"
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

            doBuyue = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doTianxieYijian( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strYjlx As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Dim blnEnabled(4) As Boolean

            doTianxieYijian = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowSpyjtx As Josco.JSOA.BusinessFacade.IFlowSpyjtx
                Dim strUrl As String
                objIFlowSpyjtx = New Josco.JSOA.BusinessFacade.IFlowSpyjtx
                With objIFlowSpyjtx
                    .iPromptInfo = "注意：要保证您的意见正确地显示在审批单对应栏目中，请确认下面选项是否选择正确。谢谢！"
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iSPR = MyBase.UserXM
                    .iDLR = ""
                    .iInitYjlx = strYjlx
                    blnEnabled(0) = Me.lnkCZQSYJ_SH.Enabled
                    blnEnabled(1) = Me.lnkCZQSYJ_QF.Enabled
                    blnEnabled(2) = Me.lnkCZQSYJ_FH.Enabled
                    blnEnabled(3) = Me.lnkCZQSYJ_HQ.Enabled
                    .iYjlxEnabled = blnEnabled

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowSpyjtx)
                strUrl = ""
                strUrl += "../../flow/flow_spyjtx.aspx"
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

            doTianxieYijian = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanBianjianyijian( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strYjlx As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanBianjianyijian = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowBjyj As Josco.JSOA.BusinessFacade.IFlowBjyj
                Dim strUrl As String
                objIFlowBjyj = New Josco.JSOA.BusinessFacade.IFlowBjyj
                With objIFlowBjyj
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iBLR = MyBase.UserXM
                    .iSPR = MyBase.UserXM
                    .iInitYjlx = strYjlx

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowBjyj)
                strUrl = ""
                strUrl += "../../flow/flow_bjyj.aspx"
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

            doChakanBianjianyijian = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doBudengYijian( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Dim blnEnabled(3) As Boolean

            doBudengYijian = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowSpyjtx As Josco.JSOA.BusinessFacade.IFlowSpyjtx
                Dim strUrl As String
                objIFlowSpyjtx = New Josco.JSOA.BusinessFacade.IFlowSpyjtx
                With objIFlowSpyjtx
                    .iPromptInfo = "注意：要保证您的意见正确地显示在审批单对应栏目中，请确认下面选项是否选择正确。谢谢！"
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS
                    .iSPR = ""
                    .iDLR = MyBase.UserXM
                    .iInitYjlx = ""
                    blnEnabled(0) = True
                    blnEnabled(1) = True
                    blnEnabled(2) = True
                    blnEnabled(3) = True
                    .iYjlxEnabled = blnEnabled

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowSpyjtx)
                strUrl = ""
                strUrl += "../../flow/flow_spyjtx.aspx"
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

            doBudengYijian = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doPrintGZ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doPrintGZ = False
            strErrMsg = ""

            Try
                ''备份现场参数
                'strMSessionId = Me.saveModuleInformation()
                'If strMSessionId = "" Then
                '    strErrMsg = "错误：不能保存现场信息！"
                '    GoTo errProc
                'End If

                ''准备调用接口
                'Dim objIEstateRsLuyongInfobpwj As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfoBpjgz
                'Dim strUrl As String
                'objIEstateRsLuyongInfobpwj = New Josco.JSOA.BusinessFacade.IEstateRsLuyongInfoBpjgz
                'With objIEstateRsLuyongInfobpwj
                '    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                '    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS

                '    .iSourceControlId = strControlId
                '    strUrl = ""
                '    strUrl += Request.Url.AbsolutePath
                '    strUrl += "?"
                '    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                '    strUrl += "="
                '    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                '    strUrl += "&"
                '    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                '    strUrl += "="
                '    strUrl += strMSessionId
                '    .iReturnUrl = strUrl
                'End With

                ''调用模块
                'strNewSessionId = objPulicParameters.getNewGuid()
                'If strNewSessionId = "" Then
                '    strErrMsg = "错误：不能初始化调用接口！"
                '    GoTo errProc
                'End If
                'Session.Add(strNewSessionId, objIEstateRsLuyongInfobpwj)
                'strUrl = ""
                'strUrl += "estate_rs_ruzhi_info_bpjgz.aspx"
                'strUrl += "?"
                'strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                'strUrl += "="
                'strUrl += strNewSessionId
                'Response.Redirect(strUrl)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doPrintGZ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doPrintBJGZ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doPrintBJGZ = False
            strErrMsg = ""

            Try
                ''备份现场参数
                'strMSessionId = Me.saveModuleInformation()
                'If strMSessionId = "" Then
                '    strErrMsg = "错误：不能保存现场信息！"
                '    GoTo errProc
                'End If

                ''准备调用接口
                'Dim objIEstateRsLuyongInfobpwj As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfoBjgz
                'Dim strUrl As String
                'objIEstateRsLuyongInfobpwj = New Josco.JSOA.BusinessFacade.IEstateRsLuyongInfoBjgz
                'With objIEstateRsLuyongInfobpwj
                '    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.FlowTypeName
                '    .iWJBS = Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS

                '    .iSourceControlId = strControlId
                '    strUrl = ""
                '    strUrl += Request.Url.AbsolutePath
                '    strUrl += "?"
                '    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                '    strUrl += "="
                '    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                '    strUrl += "&"
                '    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                '    strUrl += "="
                '    strUrl += strMSessionId
                '    .iReturnUrl = strUrl
                'End With

                ''调用模块
                'strNewSessionId = objPulicParameters.getNewGuid()
                'If strNewSessionId = "" Then
                '    strErrMsg = "错误：不能初始化调用接口！"
                '    GoTo errProc
                'End If
                'Session.Add(strNewSessionId, objIEstateRsLuyongInfobpwj)
                'strUrl = ""
                'strUrl += "estate_rs_ruzhi_info_bjgz.aspx"
                'strUrl += "?"
                'strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                'strUrl += "="
                'strUrl += strNewSessionId
                'Response.Redirect(strUrl)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doPrintBJGZ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doSetBwtx(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doSetBwtx = False
            strErrMsg = ""

            Try
                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '询问
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定要进行备忘提醒吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '继续处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '处理业务
                    If Me.m_objsystemFlowObjectRenshiRuZhi.doSetTaskBWTX(strErrMsg, MyBase.UserXM, True) = False Then
                        GoTo errProc
                    End If

                    '提示信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：系统将定期提醒您注意本文件的处理情况！")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doSetBwtx = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function










        Private Sub lnkCZQSYJ_SH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_SH.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_SH", Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.TASK_SHWJ) = False Then
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

        Private Sub lnkCZQSYJ_HQ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_HQ.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_HQ", Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.TASK_HQWJ) = False Then
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

        Private Sub lnkCZQSYJ_QF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_QF.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_QF", Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.TASK_QFWJ) = False Then
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

        Private Sub lnkCZQSYJ_FH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_FH.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_FH", Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.TASK_FHWJ) = False Then
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

       














        Private Sub lnkCZQSYJ_SHBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_SHBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_SHBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.TASK_SHWJ) = False Then
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

       

        Private Sub lnkCZQSYJ_HQBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_HQBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_HQBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.TASK_HQWJ) = False Then
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

       

        Private Sub lnkCZQSYJ_FHBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_FHBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_FHBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.TASK_FHWJ) = False Then
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

        Private Sub lnkCZQSYJ_QFBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_QFBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_QFBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.TASK_QFWJ) = False Then
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














        Private Sub doOpenPJYJ(ByVal strControlId As String)

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon

            strErrMsg = ""

            Try
                '检查
                Dim objBaseFlowRenshiRuZhi As Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi
                objBaseFlowRenshiRuZhi = CType(Me.m_objsystemFlowObjectRenshiRuZhi.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi)
                If objBaseFlowRenshiRuZhi.HJWJ = "" Then
                    strErrMsg = "错误：还没有导入签批件的电子文件！"
                    GoTo errProc
                End If

                '签批件的电子件
                Dim strFileSpec As String = ""
                Dim strFilePath As String = ""
                Dim strFileName As String = ""
                strFilePath = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, objBaseFlowRenshiRuZhi.HJWJ, strFileSpec, strFilePath, strFileName) = False Then
                    GoTo errProc
                End If
                Dim strUrl As String
                strUrl = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + strFileName

                '记录访问审计日志
                If Me.m_objsystemFlowObjectRenshiRuZhi.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了文件[" + Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS + "]的[签批件的电子文件]！") = False Then
                    '忽略
                End If

                '签批件的电子件
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpenZSWJ(ByVal strControlId As String)

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon

            strErrMsg = ""

            Try
                '检查
                Dim objBaseFlowRenshiRuZhi As Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi
                objBaseFlowRenshiRuZhi = CType(Me.m_objsystemFlowObjectRenshiRuZhi.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi)
                If objBaseFlowRenshiRuZhi.PJYJ = "" Then
                    strErrMsg = "错误：还没有导入签批件的扫描件！"
                    GoTo errProc
                End If

                '签批件的扫描件
                Dim strFileSpec As String = ""
                Dim strFilePath As String = ""
                Dim strFileName As String = ""
                strFilePath = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, objBaseFlowRenshiRuZhi.PJYJ, strFileSpec, strFilePath, strFileName) = False Then
                    GoTo errProc
                End If
                Dim strUrl As String
                strUrl = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + strFileName

                '记录访问审计日志
                If Me.m_objsystemFlowObjectRenshiRuZhi.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了文件[" + Me.m_objsystemFlowObjectRenshiRuZhi.FlowData.WJBS + "]的[签批件的扫描件]！") = False Then
                    '忽略
                End If

                '签批件的扫描件
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

       












        Private Sub doSelect_ZZRY(ByVal strControlId As String)

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
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Dim strUrl As String = ""
                objIDmxzZzry = New Josco.JsKernal.BusinessFacade.IDmxzZzry
                With objIDmxzZzry
                    .iSelectMode = False
                    .iAllowInput = True
                    .iMultiSelect = False
                    .iSelectBMMC = False
                    .iSelectFFFW = False
                    .iRenyuanList = Me.txtBMJL.Text

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
                strUrl += "../../ryxz/ryxz_zzry.aspx"
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

        Private Sub doSelectTDBH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.htxtSSDW.Value.Trim = "" Then
                    strErrMsg = "错误：没有指定[分配部门]！"
                    GoTo errProc
                End If

                Dim strTime As String = ""
                strTime = Now.ToString

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = False
                    .iAllowNull = True
                    .iJCSJ = strTime
                    .iFixQuery = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW + " = '" + Me.htxtSSDW.Value + "'"

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
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "../renshi/estate_rs_xz_team.aspx"
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

        Private Sub btnSelect_ZZDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_ZZDM.Click
            Me.doSelect_ZZRY("btnSelect_ZZDM")
        End Sub

        Private Sub btnFPBM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFPBM.Click
            Me.doSelect_ZZDM("btnFPBM")
        End Sub

        Private Sub btnSelectTDBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectTDBH.Click
            Me.doSelectTDBH("btnSelectTDBH")
        End Sub


        








        Private Sub doRYXX_AddNew(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strRYDM As String = ""
            Dim strSFZHM As String = ""
            Dim intRYZT As Integer
            Dim intSFZB As Integer
            Dim strRYXM As String
            Dim strZJDM As String = ""

            Try
                '检查
                If Me.txtRYDM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[人员代码]！"
                    GoTo errProc
                End If
                If Me.txtRYXM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[人员姓名]！"
                    GoTo errProc
                End If
                strZJDM = objPulicParameters.getObjectValue(Me.ddlZJDM.SelectedValue, "")
                If Left(strZJDM, 7) <> "030.010" Then
                    If Me.txtBMJL.Text.Trim = "" Then
                        strErrMsg = "错误：没有输入[上级经理]！"
                        GoTo errProc
                    End If
                    If Me.txtTDBH.Text.Trim = "" Then
                        strErrMsg = "错误：没有输入[团队编号]！"
                        GoTo errProc
                    Else
                        Try
                            If Integer.Parse(Me.txtTDBH.Text.Trim) < 1 Then
                                strErrMsg = "错误：输入了错误的团队编号，团队编号必须是大于0的整数！"
                                GoTo errProc
                            End If
                        Catch ex As Exception
                            strErrMsg = "错误：输入了错误的团队编号，团队编号必须是大于0的整数！"
                            GoTo errProc
                        End Try
                    End If
                End If


                If Me.txtNFPBM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[拟分配部门]！"
                    GoTo errProc
                End If
                If Me.txtSFZHM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[身份证号码]！"
                    GoTo errProc
                End If
                If Me.txtLXDH.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[联系电话]！"
                    GoTo errProc
                End If
                If Me.txtNBDRQ.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtNBDRQ.Text) = False Then
                        strErrMsg = "错误：[拟报到日期]是无效的日期！"
                        GoTo errProc
                    End If
                End If
                If Me.txtXYRYS.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtXYRYS.Text) = False Then
                        strErrMsg = "错误：[现有人员数]是无效的数值！"
                        GoTo errProc
                    End If
                End If
                If Me.txtDBRYS.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtDBRYS.Text) = False Then
                        strErrMsg = "错误：[定编人员数]是无效的数值！"
                        GoTo errProc
                    End If
                End If
                If Me.txtSFZHM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[身份证号码]！"
                    GoTo errProc
                End If

                strRYDM = Me.txtRYDM.Text.Trim
                strSFZHM = Me.txtSFZHM.Text.Trim
                strRYXM = Me.txtRYXM.Text.Trim
                Dim lenSfzhm As Integer

                If Me.chkQZTJ.Checked = False Then
                    Dim intReturn As Integer = 0
                    Dim intLXTable As Integer = 0     ' 0-入职；1-实习生
                    If objsystemEstateRenshiXingye.doCheckRydmData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strSFZHM, strRYXM, intReturn, intLXTable) = False Then
                        GoTo errProc
                    End If
                    '0-通过；1-身份证号码相同；2-ID相同；3-人员姓名相同
                    If intReturn = 0 Then

                    Else
                        If intReturn = 1 Then

                            strErrMsg = "提示:系统已经有了一个相同的身份证号码！请查证！"
                            GoTo errProc
                        Else
                            If intReturn = 2 Then
                                Me.txtRYDM.Text = strRYDM + Right(strSFZHM, 2)
                                strErrMsg = "提示:系统已经有了相同人员代码,系统自动加入身份证号码后两位！请查证！"
                                GoTo errProc
                            Else
                                lenSfzhm = Len(strSFZHM)
                                If lenSfzhm = 18 Then
                                    Me.txtRYXM.Text = strRYXM + strSFZHM.Substring(9, 2)
                                Else
                                    Me.txtRYXM.Text = strRYXM + strSFZHM.Substring(7, 2)
                                End If
                                strErrMsg = "提示:系统已经有了一个相同的人员姓名,系统自动加入出生年份！请查证！"
                                GoTo errProc
                            End If
                        End If
                    End If
                End If


                ''检查是否存在
                'Dim strOldFilter As String = ""
                'Dim strNewFilter As String = ""
                'With Me.m_objDataSet_RYXX.Tables(strTable)
                '    strOldFilter = .DefaultView.RowFilter

                '    strNewFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_JLBH + " = '" + Me.txtJLBH.Text.Trim + "'"
                '    .DefaultView.RowFilter = strNewFilter
                '    If .DefaultView.Count > 0 Then
                '        .DefaultView.RowFilter = strOldFilter
                '        strErrMsg = "错误：[" + Me.txtJLBH.Text.Trim + "]已经存在！"
                '        GoTo errProc
                '    End If

                '    .DefaultView.RowFilter = strOldFilter
                'End With

                '加入
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_RYXX.Tables(strTable)
                    objDataRow = .NewRow()

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXH) = .Rows.Count + 1
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WYBS) = ""
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WJBS) = Me.htxtWJBS.Value

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM) = Me.txtRYDM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_JLBH) = Me.txtJLBH.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM) = Me.txtRYXM.Text
                    If Me.rblRYXB.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXB) = Me.rblRYXB.SelectedValue
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXB) = "男"
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYNN) = objPulicParameters.getObjectValue(Me.txtRYNN.Text, 0)
                    If Me.ddlXL.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXL) = Me.ddlXL.SelectedValue
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXL) = ""
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NFPBM) = Me.txtNFPBM.Text

                    If Me.ddlYDYY.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYDM) = ""
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYMC) = ""
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYDM) = objPulicParameters.getObjectValue(Me.ddlYDYY.SelectedValue, "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYMC) = Me.ddlYDYY.SelectedItem.Text
                    End If

                    If Me.ddlZJDM.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZJDM) = ""
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_b_RS_RUZHISHENPI_RENYUANXINXI_ZJMC) = ""
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZJDM) = objPulicParameters.getObjectValue(Me.ddlZJDM.SelectedValue, "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_b_RS_RUZHISHENPI_RENYUANXINXI_ZJMC) = Me.ddlZJDM.SelectedItem.Text
                    End If

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NDRZW) = Me.ddlZJDM.SelectedItem.Text
                    'objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM) = Me.txtZPSM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_XYRYS) = objPulicParameters.getObjectValue(Me.txtXYRYS.Text, 0)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DBRYS) = objPulicParameters.getObjectValue(Me.txtDBRYS.Text, 0)

                    If Me.ddlZPQD.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPQD) = Me.ddlZPQD.SelectedItem.Text
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPQD) = ""
                    End If

                    If Me.ddlZPSM.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM) = Me.ddlZPSM.SelectedItem.Text
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM) = ""
                    End If

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZHM) = Me.txtSFZHM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BMJL) = Me.txtBMJL.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WLJN) = Me.txtWLJNFS.Text


                    If Me.rblRYLX.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLX) = 1
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLX) = objPulicParameters.getObjectValue(Me.rblRYLX.SelectedValue, 1)
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLXMC) = Me.rblRYLX.SelectedItem.Text

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_TDBH) = objPulicParameters.getObjectValue(Me.txtTDBH.Text, 0)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BZXL) = objPulicParameters.getObjectValue(Me.htxtBZXL.Value, 0)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_LXDH) = Me.txtLXDH.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DWDM) = Me.htxtSSDW.Value

                    If Me.rblRYZT.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT) = 1
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZTMC) = "试用人员"
                    Else
                        intRYZT = objPulicParameters.getObjectValue(Me.rblRYZT.SelectedValue, 1)
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT) = intRYZT
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZTMC) = Me.rblRYZT.SelectedItem.Text
                    End If

                    If Me.rblSFZB.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB) = "1"
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZB) = "编内人员"
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB) = objPulicParameters.getObjectValue(Me.rblSFZB.SelectedValue, 1)
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZB) = Me.rblSFZB.SelectedItem.Text
                    End If

                    .Rows.Add(objDataRow)
                End With

                Dim intTemp As Integer

                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        If Me.htxtRYXM.Value.Trim = "" Then
                            Me.htxtRYXM.Value = Me.txtRYXM.Text.Trim
                        Else
                            Me.htxtRYXM.Value = Me.htxtRYXM.Value.Trim + "、" + Me.txtRYXM.Text.Trim
                        End If
                    Case Else

                        Me.htxtRYXM.Value = Left(Me.htxtRYXM.Value.Trim, Len(Me.htxtRYXM.Value.Trim) - 1) + "、" + Me.txtRYXM.Text.Trim
                        Me.txtWJBT.Text = Left(Me.txtWJBT.Text, InStr(Me.txtWJBT.Text, "(") - 1) + Me.htxtRYXM.Value + ")"
                End Select

                '显示
                If Me.showDataGridInfo_RYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Sub

        End Sub

        Private Sub doRYXX_Update(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strSFZHM As String = ""
            Dim intRYZT As Integer
            Dim intSFZB As Integer
            Dim strRYXM As String
            Dim strRYDM As String

            Try
                '检查
                If Me.txtRYDM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[人员代码]！"
                    GoTo errProc
                End If
                If Me.txtRYXM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[人员姓名]！"
                    GoTo errProc
                End If
                If Me.txtBMJL.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[上级经理]！"
                    GoTo errProc
                End If
                If Me.txtTDBH.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[团队编号]！"
                    GoTo errProc
                Else
                    Try
                        If Integer.Parse(Me.txtTDBH.Text.Trim) < 1 Then
                            strErrMsg = "错误：输入了错误的团队编号，团队编号必须是大于0的整数！"
                            GoTo errProc
                        End If
                    Catch ex As Exception
                        strErrMsg = "错误：输入了错误的团队编号，团队编号必须是大于0的整数！"
                        GoTo errProc
                    End Try
                End If
                If Me.txtNFPBM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[拟分配部门]！"
                    GoTo errProc
                End If
                If Me.txtSFZHM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[身份证号码]！"
                    GoTo errProc
                End If
                If Me.txtLXDH.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[联系电话]！"
                    GoTo errProc
                End If
                If Me.txtNBDRQ.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtNBDRQ.Text) = False Then
                        strErrMsg = "错误：[拟报到日期]是无效的日期！"
                        GoTo errProc
                    End If
                End If
                If Me.txtXYRYS.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtXYRYS.Text) = False Then
                        strErrMsg = "错误：[现有人员数]是无效的数值！"
                        GoTo errProc
                    End If
                End If
                If Me.txtDBRYS.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtDBRYS.Text) = False Then
                        strErrMsg = "错误：[定编人员数]是无效的数值！"
                        GoTo errProc
                    End If
                End If
                If Me.txtSFZHM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[身份证号码]！"
                    GoTo errProc
                End If

                strRYDM = Me.txtRYDM.Text.Trim
                strSFZHM = Me.txtSFZHM.Text.Trim
                strRYXM = Me.txtRYXM.Text.Trim
                Dim lenSfzhm As Integer

                If Me.chkQZTJ.Checked = False Then
                    Dim intReturn As Integer = 0
                    Dim intLXTable As Integer = 0     ' 0-入职；1-实习生
                    If objsystemEstateRenshiXingye.doCheckRydmData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strSFZHM, strRYXM, intReturn, intLXTable) = False Then
                        GoTo errProc
                    End If
                    '0-通过；1-身份证号码相同；2-ID相同；3-人员姓名相同
                    If intReturn = 0 Then

                    Else
                        If intReturn = 1 Then

                            strErrMsg = "提示:系统已经有了一个相同的身份证号码！请查证！"
                            GoTo errProc
                        Else
                            If intReturn = 2 Then
                                Me.txtRYDM.Text = strRYDM + Right(strSFZHM, 2)
                                strErrMsg = "提示:系统已经有了相同人员代码,系统自动加入身份证号码后两位！请查证！"
                                GoTo errProc
                            Else
                                lenSfzhm = Len(strSFZHM)
                                If lenSfzhm = 18 Then
                                    Me.txtRYXM.Text = strRYXM + strSFZHM.Substring(9, 2)
                                Else
                                    Me.txtRYXM.Text = strRYXM + strSFZHM.Substring(7, 2)
                                End If
                                strErrMsg = "提示:系统已经有了一个相同的人员姓名,系统自动加入出生年份！请查证！"
                                GoTo errProc
                            End If
                        End If
                    End If
                End If


            
                If Me.grdRYXX.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定行！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdRYXX.SelectedIndex

                '获取记录位置
                Dim intPos As Integer = 0
                Dim intIndex As Integer
                Dim strRymc As String = ""

                intPos = objDataGridProcess.getRecordPosition(i, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)
                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM)
                strRymc = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Me.htxtRYXM.Value = Replace(Me.htxtRYXM.Value.Trim, strRymc, Me.txtRYXM.Text)
                    Case Else
                        Me.txtWJBT.Text = Replace(Me.txtWJBT.Text.Trim, strRymc, Me.txtRYXM.Text)
                End Select


                '加入
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_RYXX.Tables(strTable)
                    objDataRow = .DefaultView.Item(intPos).Row

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM) = Me.txtRYDM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_JLBH) = Me.txtJLBH.Text



                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM) = Me.txtRYXM.Text
                    If Me.rblRYXB.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXB) = Me.rblRYXB.SelectedValue
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXB) = "男"
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYNN) = objPulicParameters.getObjectValue(Me.txtRYNN.Text, 0)
                    If Me.ddlXL.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXL) = Me.ddlXL.SelectedValue
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXL) = ""
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NFPBM) = Me.txtNFPBM.Text
                 
                    If Me.ddlYDYY.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYDM) = ""
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYMC) = ""
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYDM) = objPulicParameters.getObjectValue(Me.ddlYDYY.SelectedValue, "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYMC) = Me.ddlYDYY.SelectedItem.Text
                    End If

                    If Me.ddlZJDM.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZJDM) = ""
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZJMC) = ""
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZJDM) = objPulicParameters.getObjectValue(Me.ddlZJDM.SelectedValue, "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_b_RS_RUZHISHENPI_RENYUANXINXI_ZJMC) = Me.ddlZJDM.SelectedItem.Text
                    End If

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NDRZW) = Me.ddlZJDM.SelectedItem.Text
                    'objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM) = Me.txtZPSM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_XYRYS) = objPulicParameters.getObjectValue(Me.txtXYRYS.Text, 0)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DBRYS) = objPulicParameters.getObjectValue(Me.txtDBRYS.Text, 0)

                    If Me.ddlZPQD.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPQD) = Me.ddlZPQD.SelectedItem.Text
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPQD) = ""
                    End If
                    If Me.ddlZPSM.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM) = Me.ddlZPSM.SelectedItem.Text
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM) = ""
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZHM) = Me.txtSFZHM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BMJL) = Me.txtBMJL.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WLJN) = Me.txtWLJNFS.Text


                    If Me.rblRYLX.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLX) = 1
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLX) = objPulicParameters.getObjectValue(Me.rblRYLX.SelectedValue, 1)
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLXMC) = Me.rblRYLX.SelectedItem.Text

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_TDBH) = objPulicParameters.getObjectValue(Me.txtTDBH.Text, 0)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BZXL) = objPulicParameters.getObjectValue(Me.htxtBZXL.Value, 0)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_LXDH) = Me.txtLXDH.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DWDM) = Me.htxtSSDW.Value

                    'If Me.rblRYZT.SelectedIndex < 0 Then
                    '    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT) = 1
                    'Else
                    '    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT) = objPulicParameters.getObjectValue(Me.rblRYZT.SelectedValue, 1)
                    'End If

                    'If Me.rblSFZB.SelectedIndex < 0 Then
                    '    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB) = "1"
                    'Else
                    '    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB) = objPulicParameters.getObjectValue(Me.rblSFZB.SelectedValue, 1)
                    'End If
                    If Me.rblRYZT.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT) = 1
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZTMC) = "试用人员"
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT) = objPulicParameters.getObjectValue(Me.rblRYZT.SelectedValue, 1)
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZTMC) = Me.rblRYZT.SelectedItem.Text
                    End If

                    If Me.rblSFZB.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB) = "1"
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZB) = "编内人员"
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB) = objPulicParameters.getObjectValue(Me.rblSFZB.SelectedValue, 1)
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZB) = Me.rblSFZB.SelectedItem.Text
                    End If
                End With

                '显示
                If Me.showDataGridInfo_RYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Sub

        End Sub

        Private Sub doRYXX_Delete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0

            Try
                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdRYXX.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
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
                Dim intIndex As Integer
                Dim strRymc As String = ""
                Dim intRow As Integer
               
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim objDataRow As System.Data.DataRow = Nothing
                    Dim intPos As Integer = 0
                    intRows = Me.grdRYXX.Items.Count
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)
                            With Me.m_objDataSet_RYXX.Tables(strTable)
                                objDataRow = Nothing
                                objDataRow = .DefaultView.Item(intPos).Row
                                intRow = Me.grdRYXX.Items.Count
                                strRymc = ""
                                If Not (objDataRow Is Nothing) Then
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM)
                                    strRymc = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    If intRow > 1 Then
                                        strRymc = "、" + strRymc
                                    Else
                                        strRymc = strRymc
                                    End If
                                    Select Case Me.m_objenumEditType
                                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                                            Me.htxtRYXM.Value = Replace(Me.htxtRYXM.Value.Trim, strRymc, "")
                                        Case Else
                                            Me.htxtRYXM.Value = Replace(Me.htxtRYXM.Value.Trim, strRymc, "")
                                            Me.txtWJBT.Text = Replace(Me.txtWJBT.Text.Trim, strRymc, "")
                                    End Select

                                    .Rows.Remove(objDataRow)
                                End If
                            End With
                        End If
                    Next

                    '刷新显示
                    If Me.showDataGridInfo_RYXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnRYXX_NewJLBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYXX_NewJLBH.Click

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
          
            Try

                Me.txtRYXM.Text = ""
                Me.txtSFZHM.Text = ""
                'If Me.doGetJLBH(strErrMsg) = False Then
                '    GoTo errProc
                'End If
                Me.txtJLBH.Text = ""
                Me.txtBMJL.Text = ""
                Me.txtNFPBM.Text = ""
                Me.txtZPSM.Text = ""
                Me.txtWLJNFS.Text = ""
                Me.txtXYRYS.Text = ""
                Me.txtDBRYS.Text = ""
                Me.txtTDBH.Text = ""
                Me.txtLXDH.Text = ""

                Me.btnRYXX_AddNew.Enabled = True
                Me.btnRYXX_Delete.Enabled = True
                Me.btnRYXX_Update.Enabled = True

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

        Private Sub btnRYXX_AddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYXX_AddNew.Click
            Me.doRYXX_AddNew("btnRYXX_AddNew")
        End Sub

        Private Sub btnRYXX_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYXX_Update.Click
            Me.doRYXX_Update("btnRYXX_Update")
        End Sub

        Private Sub btnRYXX_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYXX_Delete.Click
            Me.doRYXX_Delete("btnRYXX_Delete")
        End Sub

        Private Sub btnBTG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBTG.Click
            Me.doRyxx_BTG("btnBTG")
        End Sub

        Private Sub btnTG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTG.Click
            Me.doRyxx_TG("btnTG")
        End Sub

        Private Sub doRyxx_BTG(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0
            Dim intIndex As Integer = 0
            Dim intRYLX As Integer = 0
            Dim strValue As String = ""
            Dim strRYDM As String = ""
            Dim strRYMC As String = ""
            Dim strGoNext As String = ""

            Try
                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdRYXX.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要审批的人员！"
                        GoTo errProc
                    End If
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备不通过选定的[" + intSelect.ToString() + "]个人员吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim objDataRow As System.Data.DataRow = Nothing
                    Dim intPos As Integer = 0
                    Dim strWYBS As String = ""

                    intRows = Me.grdRYXX.Items.Count


                    objNewData = New System.Collections.Specialized.NameValueCollection

                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)
                            With Me.m_objDataSet_RYXX.Tables(strTable)
                                objDataRow = Nothing
                                objNewData.Clear()
                                objDataRow = .DefaultView.Item(intPos).Row
                                If Not (objDataRow Is Nothing) Then
                                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPSM, Me.txtSPSM.Text)
                                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPR, MyBase.UserXM)
                                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPRQ, Now.ToString())
                                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPJG, "0")

                                    strWYBS = objPulicParameters.getObjectValue(.Rows(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WYBS), "")
                                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WYBS, strWYBS)

                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM)
                                    strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPR)
                                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    If Trim(strValue) <> "" Then
                                        If strGoNext.Trim = "" Then
                                            strGoNext = strRYMC
                                            GoTo goNext
                                        Else
                                            strGoNext = strGoNext + "、" + strRYMC
                                        End If
                                    End If

                                    If objsystemEstateRenshiXingye.doSaveRyxx_BTG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtWJBS.Value, objNewData) = False Then
                                        GoTo errProc
                                    End If
                                End If
                            End With
goNext:
                        End If
                    Next


                    '刷新显示
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    intRows = Me.grdRYXX.Items.Count
                    Dim blnComplete As Boolean = False
                    For i = 0 To intRows - 1
                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPR)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                        If strValue.Trim = "" Then
                            blnComplete = False
                            GoTo goBreak
                        Else
                            blnComplete = True
                        End If
                    Next
goBreak:
                    If intRows < 1 Then
                        blnComplete = True
                    End If

                    If blnComplete = True Then
                        '处理业务
                        If Me.m_objsystemFlowObjectRenshiRuZhi.doCompleteFile(strErrMsg, MyBase.UserXM) = False Then
                            GoTo errProc
                        End If

                        '刷新显示
                        If Me.doRefreshData(strErrMsg) = False Then
                            GoTo errProc
                        End If

                        '记录日志
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]对[" + Me.m_objInterface.iWJBS + "," + Me.txtWJBT.Text + "]进行了[办结处理]！")


                        '提示信息
                        objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：文件处理已经完毕！")

                    End If

                    If strGoNext.Trim <> "" Then
                        strErrMsg = "提示：" + strGoNext + "已经审核过了，不能重复审核！"
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Sub
        End Sub

        Private Sub doRyxx_TG(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objNewData_RY As System.Collections.Specialized.NameValueCollection
            Dim objNewData_RYXX As System.Collections.Specialized.NameValueCollection
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0
            Dim intIndex As Integer = 0
            Dim intRYLX As Integer = 0
            Dim strValue As String = ""
            Dim strRYDM As String = ""
            Dim strRYMC As String = ""
            Dim strSSDW As String = ""
            Dim strBDSJ As String = ""
            Dim strSJLD As String = ""
            Dim strYDYY As String = ""
            Dim strGoNext As String = ""
            Dim strSPR As String = ""
            Dim oDataGridItem As DataGridItem
            Dim chkTG As System.Web.UI.WebControls.CheckBox

            Dim objNewData_Save As System.Data.DataRow = Nothing
            Dim objOldData As System.Data.DataRow = Nothing
            Dim objEnvInfo As New System.Collections.Specialized.NameValueCollection
            Dim m_objDataSet As New Josco.JsKernal.Common.Data.CustomerData

            Try
                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdRYXX.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要审批的人员！"
                        GoTo errProc
                    End If
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备通过选定的[" + intSelect.ToString() + "]个人员吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim objDataRow As System.Data.DataRow = Nothing
                    Dim intPos As Integer = 0
                    Dim strWYBS As String = ""
                    Dim blnSFJZ As Boolean = False

                    intRows = Me.grdRYXX.Items.Count

                    objNewData_RY = New System.Collections.Specialized.NameValueCollection
                    objNewData = New System.Collections.Specialized.NameValueCollection
                    objNewData_RYXX = New System.Collections.Specialized.NameValueCollection

                    Dim intCols As Integer
                    Dim j As Integer
                    Dim strRYLX As String = ""

                    For i = 0 To intRows - 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)
                            With Me.m_objDataSet_RYXX.Tables(strTable)
                                objDataRow = Nothing
                                objOldData = Nothing
                                objNewData_RY.Clear()
                                objNewData.Clear()
                                objNewData_RYXX.Clear()
                                objDataRow = .DefaultView.Item(i).Row
                                If Not (objDataRow Is Nothing) Then

                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPSM, Me.txtSPSM.Text)
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPR, MyBase.UserXM)
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPRQ, Now.ToString())
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPJG, "1")
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NBDRQ, Me.txtNBDRQ.Text)

                                    If Me.chkSFJZ.Checked = True Then
                                        objNewData_RY.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFJZ) = "1"
                                    Else
                                        objNewData_RY.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFJZ) = "0"
                                    End If

                                    strWYBS = objPulicParameters.getObjectValue(.Rows(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WYBS), "")
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WYBS, strWYBS)

                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM)
                                    strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYDM)
                                    strYDYY = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLX)
                                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    strRYLX = strValue
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPR)
                                    strSPR = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM)
                                    strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM, strRYDM)

                                    If Trim(strSPR) <> "" Then
                                        If strGoNext.Trim = "" Then
                                            strGoNext = strRYMC
                                            GoTo goNext
                                        Else
                                            strGoNext = strGoNext + "、" + strRYMC
                                        End If
                                    End If

                                    '添加人员
                                    Dim strMC As String = ""
                                    Dim strSFZHM As String = ""
                                    Dim strZZDM As String
                                    Dim blnuser As String = ""

                                    If objsystemCustomer.getRymcByRydm(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strMC) = False Then
                                        GoTo errProc
                                    End If


                                    objNewData_RYXX.Clear()

                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM)
                                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    strRYDM = strValue
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZHM)
                                    strSFZHM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)

                                    objNewData_RYXX.Add(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYDM, strRYDM)
                                    objNewData_RYXX.Add(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYZM, strRYMC)
                                    objNewData_RYXX.Add(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYMC, strRYMC)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DWDM)
                                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)

                                    objNewData_RYXX.Add(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_ZZDM, strValue)
                                    '自动生成人员序号
                                    Dim strRYXH As String
                                    objsystemCustomer.getNewRYXH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strValue, strRYXH)
                                    objNewData_RYXX.Add(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYXH, strRYXH)

                                    objNewData_RYXX.Add(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_SFYX, "1")
                                    objNewData_RYXX.Add(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_SFZB, "1")
                                    If strMC = "" Then
                                        '保存信息                                    
                                        If objsystemCustomer.doSaveRenyuanData(strErrMsg, MyBase.UserId, MyBase.UserPassword, Nothing, objNewData_RYXX, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, Nothing) = False Then
                                            GoTo errProc
                                        End If

                                        If objsystemEstateRenshiXingye.doSaveSFZHM(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strSFZHM, 0) = False Then
                                            GoTo errProc
                                        End If

                                        '记录审计日志
                                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]增加了[" + strRYDM + "]账户！")
                                    Else

                                        Josco.JsKernal.Common.Data.CustomerData.SafeRelease(m_objDataSet)

                                        If objsystemEstateRenshiXingye.getRenyuanData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, "1000", m_objDataSet) = False Then
                                            GoTo errProc
                                        End If

                                        With m_objDataSet.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_RENYUAN)
                                            If .Rows.Count < 1 Then
                                                strErrMsg = "错误：没有当前记录！"
                                                GoTo errProc
                                            End If
                                            objOldData = .Rows(0)
                                        End With

                                        '保存信息                                    
                                        If objsystemCustomer.doSaveRenyuanData(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objNewData_RYXX, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, Nothing) = False Then
                                            GoTo errProc
                                        End If

                                        '记录审计日志
                                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]修改了[" + strRYDM + "]账户！")
                                    End If

                                    If objsystemEstateRenshiXingye.doSaveRyxx_TG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtWJBS.Value, objNewData_RY) = False Then
                                        GoTo errProc
                                    End If


                                    objNewData.Clear()

                                    '添加管理架构
                                    If strRYLX = "1" Then
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_WYBS, "")

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        strRYDM = strValue
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYDM, strValue)
                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYMC, strValue)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZJDM)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZJDM, strValue)
                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_b_RS_RUZHISHENPI_RENYUANXINXI_ZJMC)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZJMC, strValue)


                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYZT, strValue)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DWDM)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSDW, strValue)
                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NFPBM)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSDWMC, strValue)

                                        'intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW)
                                        'strValue = ""
                                        'objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZGDW, strValue)
                                        ''intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC)
                                        'strValue = ""
                                        'objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZGDWMC, strValue)


                                        strValue = ""
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSFZ, strValue)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SFZB, strValue)

                                        'intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BMJL)
                                        'strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        strSJLD = ""
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SJLD, strSJLD)

                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_KSSJ, Me.txtNBDRQ.Text)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BZXL)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_BZXL, strValue)
                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_TDBH)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_TDBH, strValue)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_YDYY, strYDYY)

                                        If objsystemEstateRenshiXingye.doAddNew_GuanliJiagou(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData, strYDYY, False) = False Then
                                            GoTo errProc
                                        End If

                                        '写配置日志
                                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_人员架构_管理架构]中增加了[" + strRYMC + "]！")

                                    Else
                                        '添加助理架构
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_WYBS, "")

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_RYDM, strValue)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_RYMC, strValue)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZJDM)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_ZJDM, strValue)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_b_RS_RUZHISHENPI_RENYUANXINXI_ZJMC)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_ZJMC, strValue)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_RYZT, strValue)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DWDM)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SSDW, strValue)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NFPBM)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SSDWMC, strValue)

                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SFZB, strValue)

                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_KSSJ, Me.txtNBDRQ.Text)
                                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BZXL)
                                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_BZXL, strValue)
                                        strValue = objNewData_RY.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFJZ)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SFJZ, strValue)
                                        objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_YDYY, strYDYY)

                                        If strValue = "1" Then
                                            blnSFJZ = True
                                        Else
                                            blnSFJZ = False
                                        End If

                                        If objsystemEstateRenshiXingye.doAddNew_ZhuliJiagou(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData, strYDYY, blnSFJZ) = False Then
                                            GoTo errProc
                                        End If

                                        '写配置日志
                                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_人员架构_助理架构]中增加了[" + strRYMC + "]！")
                                    End If

                                    
                                End If
                            End With
goNext:
                        End If
                    Next


                    '刷新显示
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    intRows = Me.grdRYXX.Items.Count
                    Dim blnComplete As Boolean = False
                    For i = 0 To intRows - 1
                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPR)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                        If strValue.Trim = "" Then
                            blnComplete = False
                            GoTo goBreak
                        Else
                            blnComplete = True
                        End If
                    Next
goBreak:
                    If intRows < 1 Then
                        blnComplete = True
                    End If

                    If blnComplete = True Then
                        '处理业务
                        If Me.m_objsystemFlowObjectRenshiRuZhi.doCompleteFile(strErrMsg, MyBase.UserXM) = False Then
                            GoTo errProc
                        End If

                        '刷新显示
                        If Me.doRefreshData(strErrMsg) = False Then
                            GoTo errProc
                        End If

                        '记录日志
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]对[" + Me.m_objInterface.iWJBS + "," + Me.txtWJBT.Text + "]进行了[办结处理]！")


                        If Me.doBuyueComplete(strErrMsg) = False Then
                            GoTo errProc
                        End If

                        '提示信息
                        objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：文件处理已经完毕！")

                    End If

                    If strGoNext.Trim <> "" Then
                        strErrMsg = "提示：" + strGoNext + "已经审核过了，不能重复审核！"
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Sub
        End Sub

        Private Function gerJGXX(ByRef strErrmsg As String, ByRef objNewdata As System.Collections.Specialized.NameValueCollection) As Boolean
            '准备数据
            

        End Function







        'zengxianglin 2009-05-16
        Private Sub doAccept(ByVal strControlId As String)

            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0

            Try
                intStep = 1
                '检查
                Dim intSelected As Integer = 0
                Dim intColIndex(3) As Integer
                Dim intCount As Integer
                Dim i As Integer
                Dim strJLBH As String = ""
                Dim strRYDM As String = ""
                Dim strRYXM As String = ""
                Dim strNYBM As String = ""
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_JLBH)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM)
                intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM)
                intColIndex(3) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NFPBM)
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intCount = Me.grdRYXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            strJLBH = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(0))
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(1))
                            strRYXM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(2))
                            strNYBM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(3))
                            If strRYDM = "" Or strRYXM = "" Or strNYBM = "" Then
                                strErrMsg = "错误：[简历编号]=[" + strJLBH + "]的[人员代码]、[姓名]、[拟用单位]有空值！"
                                GoTo errProc
                            End If
                            intSelected = intSelected + 1
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "错误：没有打钩要录用的人员！"
                        GoTo errProc
                    End If
                End If

                intStep = 2
                '询问
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：确实准备录用选定的[" + intSelected.ToString + "]个人员吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '逐个处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intCount = Me.grdRYXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            strJLBH = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(0))
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(1))
                            strRYXM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(2))
                            strNYBM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(3))

                            '录用处理
                            If objsystemEstateRenshiGeneral.doLuyong(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJLBH, Server, Request.ApplicationPath, Me.m_cstrPathRootToRskpImage) = False Then
                                GoTo errProc
                            End If
                        End If
                    Next

                    '刷新数据
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '提示成功
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：处理成功！")
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub







        Private Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strMenuId As String = Me.htxtSelectMenuID.Value
                Select Case strMenuId.ToUpper()
                    Case "mnuFILE_SXWJ".ToUpper()
                        If Me.doRefresh(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuFILE_QXXG".ToUpper()
                        If Me.doCancel(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuFILE_BCWJ".ToUpper()
                        If Me.doSave(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuFILE_XGWJ".ToUpper()
                        If Me.doModify(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuJJCL_FSWJ".ToUpper()
                        If Me.doSendFile(strErrMsg, "lnkMenu", False) = False Then
                            GoTo errProc
                        End If
                    Case "mnuJJCL_WTBL".ToUpper()
                        If Me.doSendFile(strErrMsg, "lnkMenu", True) = False Then
                            GoTo errProc
                        End If
                    Case "mnuJJCL_SHWJ".ToUpper()
                        If Me.doShouhuiFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuJJCL_JSWJ".ToUpper()
                        If Me.doReceiveFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuJJCL_THWJ".ToUpper()
                        If Me.doTuihuiFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuSPCL_TXYJ".ToUpper()
                        If Me.doTianxieYijian(strErrMsg, "lnkMenu", "") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_BDPS".ToUpper()
                        If Me.doBudengYijian(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_BYBL".ToUpper()
                        If Me.doIDoNotProcess(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_BLWB".ToUpper()
                        If Me.doICompleteTask(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_WYYZ".ToUpper()
                        If Me.doIReadFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_ZHBL".ToUpper()
                        If Me.doIStopFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_JXBL".ToUpper()
                        If Me.doIContinueFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_ZFWJ".ToUpper()
                        If Me.doIZuofeiFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_QYWJ".ToUpper()
                        If Me.doIQiyongFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuCBDB_CBWJ".ToUpper()
                        If Me.doCuiban(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuCBDB_DBWJ".ToUpper()
                        If Me.doDuban(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuCBDB_DBJG".ToUpper()
                        If Me.doDubanjg(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuXXCY_CYYJ".ToUpper()
                        If Me.doChakanSPYJ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXCY_CKLZ".ToUpper()
                        If Me.doChakanLZQK(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXCY_CKBY".ToUpper()
                        If Me.doChakanBYQK(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXCY_CKRZ".ToUpper()
                        If Me.doChakanCZRZ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXCY_CKCB".ToUpper()
                        If Me.doChakanCBQK(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXCY_CKDB".ToUpper()
                        If Me.doChakanDBQK(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuXXDY_DYGZ".ToUpper()
                        If Me.doPrintGZ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXDY_DYBJ".ToUpper()
                        If Me.doPrintBJGZ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuQTCL_WJBY".ToUpper()
                        If Me.doBuyue(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuQTCL_BWTX".ToUpper()
                        If Me.doSetBwtx(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuQTCL_DRQP".ToUpper()
                        If Me.doImportQPYJ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuQTCL_DRZS".ToUpper()
                        If Me.doImportZSWJ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuQTCL_WJBJ".ToUpper()
                        If Me.doCompleteFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuQTCL_RYLY".ToUpper()
                        Me.doAccept("lnkMenu")

                    Case "mnuFHSJ".ToUpper()
                        If Me.doClose(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case Else
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

      





        Public Sub txtSFZHM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSFZHM.TextChanged

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0
            Dim strNum As String = ""
            Dim strBirthday As String = ""
            Dim strSex As String
            Dim intYear As Integer
            Dim intMonth As Integer

            Try
                strNum = Me.txtSFZHM.Text.Trim
                If strNum = "" Then
                    strErrMsg = "提示：身份证号码不能为空！请检查！"
                    GoTo errProc
                Else
                    Dim len As Integer
                    len = strNum.Length
                    If len = 15 Or len = 18 Then
                        If len = 15 Then
                            strSex = strNum.Substring(len - 1, 1)
                            If CDbl(strSex) Mod 2 > 0 Then
                                Me.rblRYXB.SelectedIndex = 0
                            Else
                                Me.rblRYXB.SelectedIndex = 1
                            End If
                            strBirthday = strNum.Substring(8, 2)
                            intYear = Now.Year
                            intMonth = Now.Month

                            If (intMonth > CInt(strBirthday)) Then
                                Me.txtRYNN.Text = CStr(intYear - (19 + CInt(strNum.Substring(6, 2))))
                            Else
                                Me.txtRYNN.Text = CStr(intYear - (19 + CInt(strNum.Substring(6, 2))) - 1)
                            End If
                        Else
                            strSex = strNum.Substring(len - 2, 1)
                            If CDbl(strSex) Mod 2 > 0 Then
                                Me.rblRYXB.SelectedIndex = 0
                            Else
                                Me.rblRYXB.SelectedIndex = 1
                            End If
                            strBirthday = strNum.Substring(10, 2)
                            intYear = Now.Year
                            intMonth = Now.Month

                            If (intMonth > CInt(strBirthday)) Then
                                Me.txtRYNN.Text = CStr(intYear - (CInt(strNum.Substring(6, 4))))
                            Else
                                Me.txtRYNN.Text = CStr(intYear - (CInt(strNum.Substring(6, 4))) - 1)
                            End If
                        End If
                    Else
                        strErrMsg = "提示：身份证号码只能为15或者18位！请检查！"
                        GoTo errProc
                    End If
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

        Private Sub grdRYXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRYXX.SelectedIndexChanged
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try

                '同步显示编辑窗信息
                If Me.showEditRuInfo(strErrMsg, Me.m_blnEditMode) = False Then
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

        '----------------------------------------------------------------
        ' 显示编辑窗的数据(根据网格当前行数据显示)
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：当前编辑状态
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditRuInfo( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim strSPR As String

            showEditRuInfo = False

            Try
                '查看状态
                If Me.grdRYXX.Items.Count < 1 Then
                    Me.txtRYXM.Text = ""
                    Me.txtSFZHM.Text = ""
                    Me.txtJLBH.Text = ""
                    Me.txtBMJL.Text = ""
                    Me.txtNFPBM.Text = ""
                    Me.txtZPSM.Text = ""
                    Me.txtWLJNFS.Text = ""
                    Me.txtXYRYS.Text = ""
                    Me.txtDBRYS.Text = ""
                    Me.txtTDBH.Text = ""
                    Me.txtLXDH.Text = ""
                ElseIf Me.grdRYXX.SelectedIndex < 0 Then
                    Me.txtRYXM.Text = ""
                    Me.txtSFZHM.Text = ""
                    Me.txtJLBH.Text = ""
                    Me.txtBMJL.Text = ""
                    Me.txtNFPBM.Text = ""
                    Me.txtZPSM.Text = ""
                    Me.txtWLJNFS.Text = ""
                    Me.txtXYRYS.Text = ""
                    Me.txtDBRYS.Text = ""
                    Me.txtTDBH.Text = ""
                    Me.txtLXDH.Text = ""
                Else
                    Dim i As Integer = Me.grdRYXX.SelectedIndex

                    '获取记录位置
                    Dim intPos As Integer = 0
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)
                    Dim strXB As String
                    Dim strLX As String
                    Dim strYDYY As String
                    Dim strZJDM As String
                    Dim strZPQD As String
                    Dim strRYLX As String
                    Dim strRYZT As String
                    Dim strSFZB As String


                    Dim objDataRow As System.Data.DataRow = Nothing
                    With Me.m_objDataSet_RYXX.Tables(strTable).DefaultView
                        Me.txtRYDM.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM), "")

                        Me.txtJLBH.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_JLBH), "")
                        Me.txtRYXM.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM), "")
                        strXB = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXB), "")
                        Me.rblRYXB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYXB, strXB)

                        Me.txtRYNN.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYNN), "")
                        strLX = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXL), "")
                        Me.ddlXL.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlXL, strLX)

                        Me.txtNFPBM.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NFPBM), "")
                        strYDYY = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYDM), "")
                        Me.ddlYDYY.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYDYY, strYDYY)
                        strZJDM = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZJDM), "")
                        Me.ddlZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZJDM, strZJDM)
                        strZPQD = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPQD), "")
                        Me.ddlZPQD.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZPQD, strZPQD)
                        'Me.ddlZPQD.SelectedItem.Text = strZPQD

                        'Me.ddlZPQD.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZPQD, strZPQD)
                        'Me.ddlZPSM.SelectedItem.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM), "")
                        strZPQD = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM), "")
                        Me.ddlZPSM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZPSM, strZPQD)

                        'Me.txtZPSM.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM), "")
                        Me.txtXYRYS.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_XYRYS), "")
                        Me.txtDBRYS.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DBRYS), "")
                        Me.txtSFZHM.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZHM), "")
                        Me.txtBMJL.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BMJL), "")
                        Me.txtWLJNFS.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WLJN), "")
                        Me.txtTDBH.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_TDBH), "")
                        strRYLX = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLX), "")
                        Me.rblRYLX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYLX, strRYLX)

                        Me.htxtBZXL.Value = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BZXL), "")
                        Me.txtLXDH.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_LXDH), "")
                        Me.htxtSSDW.Value = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DWDM), "")
                        strRYZT = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT), "")
                        Me.rblRYZT.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYZT, strRYZT)
                        strSFZB = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB), "")
                        Me.rblSFZB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZB, strSFZB)

                        strSPR = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPR), "")

                    End With
                End If


                '使能控件
                With New Josco.JsKernal.web.ControlProcess
                    .doEnabledControl(Me.txtRYXM, blnEditMode)
                    .doEnabledControl(Me.txtSFZHM, blnEditMode)
                    .doEnabledControl(Me.txtJLBH, blnEditMode)
                    .doEnabledControl(Me.txtBMJL, blnEditMode)

                    .doEnabledControl(Me.txtNFPBM, blnEditMode)
                    .doEnabledControl(Me.txtZPSM, blnEditMode)
                    .doEnabledControl(Me.txtWLJNFS, blnEditMode)
                    .doEnabledControl(Me.txtXYRYS, blnEditMode)

                    .doEnabledControl(Me.txtDBRYS, blnEditMode)
                    .doEnabledControl(Me.txtTDBH, blnEditMode)
                    .doEnabledControl(Me.txtLXDH, blnEditMode)
                End With

                If Trim(strSPR) <> "" Then
                    Me.btnRYXX_AddNew.Enabled = False
                    Me.btnRYXX_Delete.Enabled = False
                    Me.btnRYXX_Update.Enabled = False
                    Me.btnRYXX_NewJLBH.Enabled = False
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)


            showEditRuInfo = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            Exit Function

        End Function

    

    End Class

End Namespace
