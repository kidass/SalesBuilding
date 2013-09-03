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

        Partial Class estate_rs_nbtz_info
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsTiaoZhengInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数(稿件、正文、附件、相关文件统一事务处理)
        '----------------------------------------------------------------
        Private m_objsystemFlowObjectRenshiTiaozheng As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiTiaozheng
        Private m_objDataSet_FJ As Josco.JSOA.Common.Data.FlowData
        Private m_strSessionID_FJ As String
        Private m_objDataSet_XGWJ As Josco.JSOA.Common.Data.FlowData
        Private m_strSessionID_XGWJ As String
        Private m_objDataSet_RYXX As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_strSessionID_RYXX As String
        Private m_objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_YTDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData

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
        Private m_blnSJJL As Boolean = True  '是否自动获取上级经理

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
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim strErrMsg As String = ""

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.txtYWYBS.Text = .txtYWYBS
                    Me.txtJLBH.Text = .txtJLBH
                    Me.txtRYDM.Text = .txtRYDM
                    Me.txtRYXM.Text = .txtRYXM

                    Me.txtYZJMC.Text = .txtYZJMC
                    Me.txtYBMMC.Text = .txtYBMMC
                    'Me.txtNDRZW.Text = .txtNDRZW
                    Me.txtYTD.Text = .txtYTD
                    Me.txtYRYZT.Text = .txtYRYZT
                    Me.txtYZBQK.Text = .txtYZBQK
                    Me.htxtYZJDM.Value = .htxtYZJDM
                    Me.htxtYBMDM.Value = .htxtYBMDM
                    Me.htxtYZGTD.Value = .htxtYZGTD
                    Me.htxtYXGTD.Value = .htxtYXGTD

                    Me.txtSSDW.Text = .txtSSDW
                    Me.htxtSSDW.Value = .htxtSSDW
                    Me.txtTDBH.Text = .txtTDBH
                    Me.htxtZGTD.Value = .htxtZGTD
                    Me.htxtXGTD.Value = .htxtXGTD

                    Me.rblRYZT.SelectedIndex = .rblRYZT_SelectedIndex
                    Me.rblSFZB.SelectedIndex = .rblSFZB_SelectedIndex
                    Me.rblSXRQ.SelectedIndex = .rblSXRQ_SelectedIndex

                    Me.txtRQ.Text = .txtRQ
                    Me.txtSFJZ.Text = .txtSFJZ
                    Me.txtRTLX.Text = .txtRTLX
                    Me.txtBZXL.Text = .txtBZXL
                    Me.txtRTLXMC.Text = .txtRTLXMC
                    Me.txtZGDWDM.Text = .txtZGDWDM
                    Me.txtZGDWMC.Text = .txtZGDWMC
                    Me.txtYSJLDMC.Text = .txtSJLD
                    Me.txtSJLDMC.Text = .txtSJLDMC
                    Me.htxtSessionId_TDZH.Value = .htxtSessionId_TDZH
                    Me.htxtSessionId_YTDZH.Value = .htxtSessionId_YTDZH

                    If Me.getModuleData_TDZH(strErrMsg) = True Then
                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, objTempDataSet, Me.lstZGTD)
                        End If
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, objTempDataSet, Me.lstXGTD)
                        End If
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                    End If

                    If Me.getModuleData_YTDZH(strErrMsg) = True Then
                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtYZGTD.Value, Me.m_objDataSet_YTDZH, objTempDataSet) = True Then
                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtYZGTD.Value, objTempDataSet, Me.lstYZGTD)
                        End If
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)

                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtYXGTD.Value, Me.m_objDataSet_YTDZH, objTempDataSet) = True Then
                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtYXGTD.Value, objTempDataSet, Me.lstYXGTD)
                        End If
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                    End If

                    Try
                        Me.lstZGTD.SelectedIndex = .lstZGTD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.lstXGTD.SelectedIndex = .lstXGTD_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.rblRYLX.SelectedIndex = .rblRYLX_SelectedIndex
                    Me.txtTDBH.Text = .txtTDBH

                    Me.htxtBZXL.Value = .htxtBZXL
                    Me.htxtSSDW.Value = .htxtSSDW

                    Me.txtNBDRQ.Text = .txtNBDRQ

                    Me.ddlZJDM.SelectedIndex = .ddlZJDM_SelectedIndex
                    Me.ddlYDYY.SelectedIndex = .ddlYDYY_SelectedIndex
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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)

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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRSTiaoZhengInfo

                '保存现场信息
                With Me.m_objSaveScence
                    .txtYWYBS = Me.txtYWYBS.Text
                    .txtJLBH = Me.txtJLBH.Text
                    .txtRYDM = Me.txtRYDM.Text
                    .txtRYXM = Me.txtRYXM.Text

                    .txtYZJMC = Me.txtYZJMC.Text
                    .txtYBMMC = Me.txtYBMMC.Text
                    'Me.txtNDRZW.Text = .txtNDRZW
                    .txtYTD = Me.txtYTD.Text
                    .txtYRYZT = Me.txtYRYZT.Text
                    .txtYZBQK = Me.txtYZBQK.Text
                    .htxtYZJDM = Me.htxtYZJDM.Value
                    .htxtYBMDM = Me.htxtYBMDM.Value
                    .htxtYZGTD = Me.htxtYZGTD.Value
                    .htxtYXGTD = Me.htxtYXGTD.Value


                    .txtSSDW = Me.txtSSDW.Text
                    .htxtSSDW = Me.htxtSSDW.Value
                    .txtTDBH = Me.txtTDBH.Text
                    .htxtZGTD = Me.htxtZGTD.Value
                    .htxtXGTD = Me.htxtXGTD.Value

                    .rblRYZT_SelectedIndex = Me.rblRYZT.SelectedIndex
                    .rblSFZB_SelectedIndex = Me.rblSFZB.SelectedIndex
                    .rblSXRQ_SelectedIndex = Me.rblSXRQ.SelectedIndex

                    .txtRQ = Me.txtRQ.Text
                    .txtSFJZ = Me.txtSFJZ.Text
                    .txtRTLX = Me.txtRTLX.Text
                    .txtBZXL = Me.txtBZXL.Text
                    .txtRTLXMC = Me.txtRTLXMC.Text
                    .txtZGDWDM = Me.txtZGDWDM.Text
                    .txtZGDWMC = Me.txtZGDWMC.Text
                    .txtSJLD = Me.txtYSJLDMC.Text
                    .txtSJLDMC = Me.txtSJLDMC.Text

                    .htxtSessionId_TDZH = Me.htxtSessionId_TDZH.Value
                    .htxtSessionId_YTDZH = Me.htxtSessionId_YTDZH.Value

                    .lstXGTD_SelectedIndex = Me.lstXGTD.SelectedIndex
                    .lstZGTD_SelectedIndex = Me.lstZGTD.SelectedIndex

                    .txtNBDRQ = Me.txtNBDRQ.Text
                    .ddlZJDM_SelectedIndex = Me.ddlZJDM.SelectedIndex
                    .ddlYDYY_SelectedIndex = Me.ddlYDYY.SelectedIndex


                    .rblRYLX_SelectedIndex = Me.rblRYLX.SelectedIndex
                    .txtTDBH = Me.txtTDBH.Text
                    .htxtBZXL = Me.htxtBZXL.Value
                    .htxtSSDW = Me.htxtSSDW.Value
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

            Dim intXZBZ As Integer = Josco.JsKernal.Common.Data.FlowData.enumFileDownloadStatus.HasDownload
            Dim intLBBS As Integer = Josco.JsKernal.Common.Data.FlowData.enumXGWJLB.FujianFile
            Dim objDataRow As System.Data.DataRow

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim strWhere As String = ""
            Dim objDataSet_RYJG As New System.Data.DataSet

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '=================================================================
                Dim objIDmxzRyjg As Josco.JSOA.BusinessFacade.IDmxzRyjg
                Try
                    objIDmxzRyjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IDmxzRyjg)
                Catch ex As Exception
                    objIDmxzRyjg = Nothing
                End Try
                If Not (objIDmxzRyjg Is Nothing) Then
                    '返回值处理
                    Select Case objIDmxzRyjg.iSourceControlId.ToUpper()
                        Case "btnSelectXM".ToUpper()
                            '处理btnSelectLBDM返回
                            If objIDmxzRyjg.oExitMode = True Then

                                objDataSet_RYJG = objIDmxzRyjg.oDataSet
                                Dim strZJDM As String = ""
                                Dim strRYZT As String = ""
                                Dim strSFZB As String = ""
                                Dim strSJLD As String = ""

                                With objDataSet_RYJG.Tables(0).DefaultView
                                    Me.txtYWYBS.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_WYBS), "")
                                    Me.txtRYDM.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM), "")
                                    Me.txtRYXM.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC), "")
                                    Me.htxtYZJDM.Value = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM), "")
                                    Me.txtYZJMC.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC), "")
                                    strZJDM = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM), "")
                                    Me.ddlZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZJDM, strZJDM)
                                    Me.htxtYBMDM.Value = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW), "")
                                    Me.txtYBMMC.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC), "")
                                    Me.htxtSSDW.Value = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW), "")
                                    Me.txtSSDW.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC), "")
                                    Me.txtYTD.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_TDBH), "")
                                    Me.txtTDBH.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_TDBH), "")
                                    Me.htxtYRYZTDM.Value = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT), "")
                                    Me.txtYRYZT.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC), "")
                                    strRYZT = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT), "")
                                    Me.rblRYZT.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYZT, strRYZT)
                                    Me.htxtYZBQKDM.Value = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB), "")
                                    If Me.htxtYZBQKDM.Value = "1" Then
                                        Me.txtYZBQK.Text = "编内人员"
                                    Else
                                        Me.txtYZBQK.Text = "编外人员"
                                    End If
                                    'Me.txtYZBQK.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZB), "")
                                    strSFZB = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB), "")
                                    Me.rblSFZB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZB, strSFZB)
                                    Me.txtSFJZ.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ), "")
                                    Me.txtRTLX.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYLX), "")
                                    Me.txtRTLXMC.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYLX), "")
                                    Me.txtBZXL.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_BZXL), "")
                                    Me.txtZGDWDM.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW), "")
                                    Me.txtZGDWMC.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC), "")
                                    'Me.txtSJLD.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD), "")
                                    'Me.txtSJLDMC.Text = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC), "")
                                    If objsystemEstateRenshiXingye.getSJLD(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtRYDM.Text.Trim(), Me.htxtSSDW.Value.Trim(), strZJDM, Me.txtTDBH.Text.Trim(), strSJLD) = False Then
                                        GoTo errProc
                                    End If
                                    Me.txtSJLDMC.Text = strSJLD
                                    Me.txtYSJLDMC.Text = strSJLD

                                    Me.htxtYZGTD.Value = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGTD), "")
                                    Me.htxtZGTD.Value = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGTD), "")
                                    Me.htxtYXGTD.Value = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_XGTD), "")
                                    Me.htxtXGTD.Value = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_XGTD), "")

                                    If Me.getModuleData_TDZH(strErrMsg) = True Then
                                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, objTempDataSet, Me.lstZGTD)
                                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtYZGTD.Value, objTempDataSet, Me.lstYZGTD)
                                        End If
                                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, objTempDataSet, Me.lstXGTD)
                                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtYXGTD.Value, objTempDataSet, Me.lstYXGTD)
                                        End If
                                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                                    End If

                                    If Me.getModuleData_YTDZH(strErrMsg) = True Then
                                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtYZGTD.Value, Me.m_objDataSet_YTDZH, objTempDataSet) = True Then
                                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtYZGTD.Value, objTempDataSet, Me.lstYZGTD)
                                        End If
                                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtYXGTD.Value, Me.m_objDataSet_YTDZH, objTempDataSet) = True Then
                                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtYXGTD.Value, objTempDataSet, Me.lstYXGTD)
                                        End If
                                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                                    End If
                                End With
                            End If
                        Case Else
                    End Select
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIDmxzRyjg.Dispose()
                    objIDmxzRyjg = Nothing
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
                            Case "btnSelectZGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '加入新团队组
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '清除上次缓存
                                        If Me.htxtZGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '显示本次列表
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstZGTD)
                                        '更新数值
                                        Me.htxtZGTD.Value = strZBBS
                                    End If
                                End If
                            Case "btnSelectXGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '加入新团队组
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '清除上次缓存
                                        If Me.htxtXGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '显示本次列表
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstXGTD)
                                        '更新数值
                                        Me.htxtXGTD.Value = strZBBS
                                    End If
                                End If


                            Case "btnAddnewZGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '加入新团队组(新选定+原来存在)
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.htxtZGTD.Value.Trim, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '清除上次缓存
                                        If Me.htxtZGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '显示本次列表
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstZGTD)
                                        '更新数值
                                        Me.htxtZGTD.Value = strZBBS
                                    End If
                                End If
                            Case "btnAddnewXGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '加入新团队组(新选定+原来存在)
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.htxtXGTD.Value.Trim, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '清除上次缓存
                                        If Me.htxtXGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '显示本次列表
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstXGTD)
                                        '更新数值
                                        Me.htxtXGTD.Value = strZBBS
                                    End If
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
                            Case "btnSelectZZDM".ToUpper
                                Dim strZZMC As String = objIDmxzZzjg.oBumenList
                                Dim strZZDM As String = ""
                                m_blnSJJL = True
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtSSDW.Value = strZZDM
                                    Me.txtSSDW.Text = strZZMC
                                    'Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, strZZMC)
                                    '强制要求团队编号失效
                                    'Me.txtTDBH.Text = ""
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
                        Case "btnSJJL".ToUpper()
                            '处理btnSelect_ZZDM返回
                            If objIDmxzZzry.oExitMode = True Then
                                objDataset = objIDmxzZzry.oDataSet
                                If objDataset Is Nothing Then

                                Else
                                    With objDataset.Tables(0)
                                        strRYMC = objPulicParameters.getObjectValue(.Rows(0).Item(0), "")
                                        strBMMC = objPulicParameters.getObjectValue(.Rows(0).Item(3), "")
                                    End With

                                    Me.txtSJLDMC.Text = strRYMC
                                    m_blnSJJL = False
                                End If
                            End If
                        Case "btnYSJJL".ToUpper()
                            '处理btnSelect_ZZDM返回
                            If objIDmxzZzry.oExitMode = True Then
                                objDataset = objIDmxzZzry.oDataSet
                                If objDataset Is Nothing Then

                                Else
                                    With objDataset.Tables(0)
                                        strRYMC = objPulicParameters.getObjectValue(.Rows(0).Item(0), "")
                                        strBMMC = objPulicParameters.getObjectValue(.Rows(0).Item(3), "")
                                    End With

                                    Me.txtYSJLDMC.Text = strRYMC
                                    m_blnSJJL = False
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
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRSTiaoZhengInfo)
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


                If Me.htxtSessionId_TDZH.Value.Trim <> "" Then
                    Dim objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_TDZH.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_TDZH.Value)
                End If

                If Me.htxtSessionId_YTDZH.Value.Trim <> "" Then
                    Dim objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_YTDZH.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_YTDZH.Value)
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
                Dim strType As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWCODE
                Dim strName As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWNAME
                Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                Me.m_objsystemFlowObjectRenshiTiaozheng = CType(objsystemFlowObject, Josco.JSOA.BusinessFacade.systemFlowObjectRenshiTiaozheng)

                '工作流对象初始化并填充数据
                If Me.m_objsystemFlowObjectRenshiTiaozheng.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, True) = False Then
                    GoTo errProc
                End If

                '计算可执行的操作
                If Me.m_objsystemFlowObjectRenshiTiaozheng.getCanExecuteCommand(strErrMsg, MyBase.UserId, MyBase.UserXM, MyBase.UserBmdm) = False Then
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
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.getFujianData(strErrMsg, Me.m_objDataSet_FJ) = False Then
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
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.getXgwjData(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI
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
                    Select Me.m_objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            If Me.m_objsystemFlowObjectRenshiTiaozheng.getDataSet_RYXX(strErrMsg, MyBase.UserXM, Me.m_objDataSet_RYXX) = False Then
                                GoTo errProc
                            End If
                        Case Else
                            If Me.txtJBRY.Text.Trim = MyBase.UserXM Then
                                If Me.m_objsystemFlowObjectRenshiTiaozheng.getDataSet_RYXX(strErrMsg, Me.m_objDataSet_RYXX, blnSFJB) = False Then
                                    GoTo errProc
                                End If
                            Else
                                If Me.m_objsystemFlowObjectRenshiTiaozheng.getDataSet_RYXX(strErrMsg, MyBase.UserXM, Me.m_objDataSet_RYXX) = False Then
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI
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
            Dim objBaseFlowRenshiTiaozheng As Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            showEditPanelInfo = False

            Try
                objBaseFlowRenshiTiaozheng = CType(Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng)

                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    '是编辑模式时首次进入：以现场复原信息为准(暗含首次进入条件)
                Else
                    If Me.IsPostBack = False Or (Me.IsPostBack = True And Me.m_blnEditMode = False) Then
                        '首次进入或查看状态下的回发，需要重新显示数据
                        Me.ddlJJCD.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJJCD, objBaseFlowRenshiTiaozheng.JJCD)
                        Me.ddlMMDJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlMMDJ, objBaseFlowRenshiTiaozheng.MMDJ)
                        Me.txtJGDZ.Text = objBaseFlowRenshiTiaozheng.JGDZ
                        Me.txtWJNF.Text = objBaseFlowRenshiTiaozheng.WJNF
                        Me.txtWJXH.Text = objBaseFlowRenshiTiaozheng.WJXH
                        Me.txtWJBT.Text = objBaseFlowRenshiTiaozheng.WJBT
                        'Me.txtDBRS.Text = objBaseFlowRenshiTiaozheng.DBRS.ToString
                        Me.txtBZXX.Text = objBaseFlowRenshiTiaozheng.BEIZ
                        If objBaseFlowRenshiTiaozheng.DDSZ = 1 Then
                            Me.chkDDSZ.Checked = True
                        Else
                            Me.chkDDSZ.Checked = False
                        End If
                        Me.txtJBDW.Text = objBaseFlowRenshiTiaozheng.ZBDW
                        Me.txtJBRY.Text = objBaseFlowRenshiTiaozheng.NGR
                        Me.txtJBRQ.Text = objPulicParameters.doDateToString(objBaseFlowRenshiTiaozheng.NGRQ, "yyyy-MM-dd")
                        Me.txtLSH.Text = objBaseFlowRenshiTiaozheng.LSH
                        Me.htxtWJBS.Value = objBaseFlowRenshiTiaozheng.WJBS

                        'Me.txtNBDRQ.Text = objPulicParameters.doDateToString(objBaseFlowRenshiTiaozheng.SXRQ, "yyyy-MM-dd")
                        If Me.txtNBDRQ.Text = "" Then
                            Me.txtNBDRQ.Text = Now.AddDays(1).ToString("yyyy-MM-dd")
                        End If

                        Dim intTemp_start As Integer
                        Dim intTemp_end As Integer
                        Dim strTemp As String = objBaseFlowRenshiTiaozheng.WJBT
                        Dim lendf As Integer

                        intTemp_start = InStr(1, objBaseFlowRenshiTiaozheng.WJBT, "(")
                        intTemp_end = InStr(1, objBaseFlowRenshiTiaozheng.WJBT, ")")

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
                                If Me.m_objsystemFlowObjectRenshiTiaozheng.getNewWjxh(strErrMsg, Me.txtJGDZ.Text, Me.txtWJNF.Text, strWJXH) = False Then
                                Else
                                    Me.txtWJXH.Text = strWJXH
                                End If
                                Me.txtJBDW.Text = MyBase.UserBmmc
                                Me.txtJBRY.Text = MyBase.UserXM
                                Me.txtJBRQ.Text = Now.ToString("yyyy-MM-dd")
                                Dim strLSH As String = ""
                                If Me.m_objsystemFlowObjectRenshiTiaozheng.getNewLSH(strErrMsg, strLSH) = False Then
                                    Me.txtLSH.Text = ""
                                Else
                                    Me.txtLSH.Text = strLSH
                                End If

                                strLSH = Right(strLSH, 2)
                                Me.txtWJBT.Text = Now.ToString("yyyyMMdd") & strLSH & MyBase.UserBmmc & "内部调整申请单"

                                strLSH = ""
                                If Me.m_objsystemFlowObjectRenshiTiaozheng.getNewWJBS(strErrMsg, strLSH) = False Then
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
                'Me.lblQFR.Text = objBaseFlowRenshiTiaozheng.QFR

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

                    .doEnabledControl(Me.txtYWYBS, blnEditMode)
                    .doEnabledControl(Me.txtJLBH, blnEditMode)
                    .doEnabledControl(Me.txtRYDM, blnEditMode)
                    .doEnabledControl(Me.txtRYXM, blnEditMode)
                    .doEnabledControl(Me.txtYZJMC, blnEditMode)
                    .doEnabledControl(Me.txtYBMMC, blnEditMode)
                    .doEnabledControl(Me.ddlZJDM, blnEditMode)
                    .doEnabledControl(Me.txtYTD, blnEditMode)
                    .doEnabledControl(Me.txtYRYZT, blnEditMode)
                    .doEnabledControl(Me.txtYZBQK, blnEditMode)
                    .doEnabledControl(Me.txtSSDW, blnEditMode)
                    .doEnabledControl(Me.txtTDBH, blnEditMode)

                    '.doEnabledControl(Me.rblRYZT, blnEditMode)
                    .doEnabledControl(Me.rblSFZB, blnEditMode)
                    .doEnabledControl(Me.rblSXRQ, blnEditMode)
                    '.doEnabledControl(Me.txtSPSM, blnEditMode)
                    .doEnabledControl(Me.ddlYDYY, blnEditMode)


                    .doEnabledControl(Me.rblRYLX, blnEditMode)
                    .doEnabledControl(Me.txtTDBH, blnEditMode)
                    .doEnabledControl(Me.txtRQ, blnEditMode)
                    .doEnabledControl(Me.txtSFJZ, blnEditMode)
                    .doEnabledControl(Me.txtRTLX, blnEditMode)
                    .doEnabledControl(Me.txtZGDWDM, blnEditMode)
                    .doEnabledControl(Me.txtBZXL, blnEditMode)
                    .doEnabledControl(Me.txtRTLXMC, blnEditMode)
                    .doEnabledControl(Me.txtZGDWMC, blnEditMode)
                    .doEnabledControl(Me.txtSJLD, blnEditMode)
                    .doEnabledControl(Me.txtSJLDMC, blnEditMode)
                    .doEnabledControl(Me.txtYSJLDMC, blnEditMode)

                End With
                'Me.btnSelect_JLBH.Visible = blnEditMode
                'Me.btnSelect_ZZDM.Visible = blnEditMode
                Me.btnSelectXM.Visible = blnEditMode
                Me.btnSelectZZDM.Visible = blnEditMode
                Me.btnSelectTDBH.Visible = blnEditMode
                Me.btnYSJJL.Visible = blnEditMode
                Me.btnSJJL.Visible = blnEditMode
                Me.btnSelectZGTD.Visible = blnEditMode
                Me.btnAddnewZGTD.Visible = blnEditMode
                Me.btnDeleteZGTD.Visible = blnEditMode
                Me.btnSelectXGTD.Visible = blnEditMode
                Me.btnAddnewXGTD.Visible = blnEditMode
                Me.btnDeleteXGTD.Visible = blnEditMode

                Me.btnRYXX_AddNew.Visible = blnEditMode
                Me.btnRYXX_Delete.Visible = blnEditMode

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
                Me.lnkCZQSYJ_HG.Enabled = blnEnabled
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
                'Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Visible = Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Enabled
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
                Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Visible = False
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

            Dim objBaseFlowRenshiTiaozheng As Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng
            Dim blnEditMode As Boolean = False

            showModuleData_ReadMode = False

            Try
                '人员信息窗内容

                '工作流初始化
                objBaseFlowRenshiTiaozheng = CType(Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng)

                '使能命令
                doEnabledFileCommands(False)

                '逐个设置
                'Me.lnkCZCYGJ.Enabled = Not blnEditMode
                'Me.lnkCZCYGJ.Text = "查阅稿件"
                'Me.lnkCZCYFJ.Enabled = Not blnEditMode
                'Me.lnkCZCYFJ.Text = "查阅附件"
                'Me.lnkCZCYXGWJ.Enabled = Not blnEditMode
                'Me.lnkCZCYXGWJ.Text = "查阅相关文件"
                'Me.lnkCZCYQPWJ.Enabled = Not blnEditMode And (objBaseFlowRenshiTiaozheng.HJWJ <> "")
                'Me.lnkCZCYZSWJ.Enabled = Not blnEditMode And (objBaseFlowRenshiTiaozheng.PJYJ <> "")

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
                If Me.m_objsystemFlowObjectRenshiTiaozheng.pmMustJieshou = True Then
                    '接收文件
                    Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Enabled = Not blnEditMode
                    Exit Try
                End If

                '
                '正常操作
                '
                With Me.m_objsystemFlowObjectRenshiTiaozheng
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
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.doIReadFile(strErrMsg, MyBase.UserXM) = False Then
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
                    Me.lnkCZQSYJ_HG.Enabled = .pmQSYJ_HG
                    Me.lnkCZQSYJ_SH.Enabled = .pmQSYJ_SH
                    Me.lnkCZQSYJ_HQ.Enabled = .pmQSYJ_HQ
                    Me.m_blnSPMode = .pmQSYJ_SH
                    'Me.btnRYXX_AddNew.Enabled = m_blnSPMode
                    'Me.btnRYXX_Delete.Enabled = m_blnSPMode
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

            Dim objBaseFlowRenshiTiaozheng As Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng
            Dim blnEditMode As Boolean = True

            showModuleData_EditMode = False

            Try
                '工作流初始化
                objBaseFlowRenshiTiaozheng = CType(Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng)

                '使能命令
                doEnabledFileCommands(False)

                ''逐个设置
                'Me.lnkCZCYGJ.Enabled = blnEditMode
                'Me.lnkCZCYGJ.Text = "编辑稿件"
                'Me.lnkCZCYFJ.Enabled = blnEditMode
                'Me.lnkCZCYFJ.Text = "编辑附件"
                'Me.lnkCZCYXGWJ.Enabled = blnEditMode
                'Me.lnkCZCYXGWJ.Text = "编辑相关文件"
                'Me.lnkCZCYQPWJ.Enabled = blnEditMode And (objBaseFlowRenshiTiaozheng.HJWJ <> "")
                'Me.lnkCZCYZSWJ.Enabled = blnEditMode And (objBaseFlowRenshiTiaozheng.PJYJ <> "")

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
            Dim objBaseFlowRenshiTiaozheng As Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng
            Dim objOpinionData As Josco.JSOA.Common.Data.FlowData
            Dim strQSYJ As String = ""
            Dim strBJYJ As String = ""
            Dim strYJLX As String = ""

            showOpinion = False

            Try
                objBaseFlowRenshiTiaozheng = CType(Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng)

                '获取可查看的意见
                If Me.m_objsystemFlowObjectRenshiTiaozheng.getOpinionData(strErrMsg, MyBase.UserXM, objOpinionData) = False Then
                    GoTo errProc
                End If

                '显示区域经理意见
                strYJLX = objBaseFlowRenshiTiaozheng.TASK_QFWJ
                If Me.m_objsystemFlowObjectRenshiTiaozheng.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblQFYJ.Text = strQSYJ
                Me.lnkCZQSYJ_QFBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '显示调入部门经理
                strYJLX = objBaseFlowRenshiTiaozheng.TASK_FHWJ
                If Me.m_objsystemFlowObjectRenshiTiaozheng.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblFHYJ.Text = strQSYJ
                Me.lnkCZQSYJ_FHBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '显示调出部门经理
                strYJLX = objBaseFlowRenshiTiaozheng.TASK_HGWJ
                If Me.m_objsystemFlowObjectRenshiTiaozheng.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblHGYJ.Text = strQSYJ
                Me.lnkCZQSYJ_HGBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '显示中介部意见
                strYJLX = objBaseFlowRenshiTiaozheng.TASK_SHWJ
                If Me.m_objsystemFlowObjectRenshiTiaozheng.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblSHYJ.Text = strQSYJ
                Me.lnkCZQSYJ_SHBJ.Visible = Not blnEditMode And (strBJYJ <> "")


                '显示办公室意见
                strYJLX = objBaseFlowRenshiTiaozheng.TASK_HQWJ
                If Me.m_objsystemFlowObjectRenshiTiaozheng.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
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

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_WJBS, Me.htxtWJBS.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_LSH, Me.txtLSH.Text)

                If Me.chkDDSZ.Checked = True Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_DDSZ, "1")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_DDSZ, "0")
                End If

                If Me.ddlJJCD.SelectedIndex < 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JJCD, "")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JJCD, Me.ddlJJCD.SelectedItem.Text)
                End If

                If Me.ddlMMDJ.SelectedIndex < 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_MMDJ, "")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_MMDJ, Me.ddlMMDJ.SelectedItem.Text)
                End If

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JGDZ, Me.txtJGDZ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_WJNF, Me.txtWJNF.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_WJXH, Me.txtWJXH.Text)

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JBRY, Me.txtJBRY.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JBRQ, Me.txtJBRQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JBDW, Me.txtJBDW.Text)

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_WJBT, Me.txtWJBT.Text)
                'objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_DBRS, Me.txtDBRS.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_BZXX, Me.txtBZXX.Text)

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
                Me.htxtWJBS.Value = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_WJBS), "")
                Me.txtLSH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_LSH), "")
                If objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_DDSZ), 0) = 1 Then
                    Me.chkDDSZ.Checked = True
                Else
                    Me.chkDDSZ.Checked = False
                End If

                Me.ddlJJCD.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJJCD, objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JJCD), ""))
                Me.ddlMMDJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlMMDJ, objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_MMDJ), ""))

                Me.txtJGDZ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JGDZ), "")
                Me.txtWJNF.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_WJNF), "")
                Me.txtWJXH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_WJXH), "")

                Me.txtJBRY.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JBRY), "")
                Me.txtJBRQ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JBRQ), "")
                Me.txtJBDW.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_JBDW), "")

                Me.txtWJBT.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_WJBT), "")
                'Me.txtDBRS.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_DBRS), "")
                Me.txtBZXX.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_BZXX), "")

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
            If Me.m_objsystemFlowObjectRenshiTiaozheng.doDeleteCacheFile_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
                '可以不成功，形成垃圾文件！
            End If
            If Me.m_objsystemFlowObjectRenshiTiaozheng.doDeleteCacheFile_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
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
                Dim strWJBS As String = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS

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


                        .doTranslateKey(Me.txtYWYBS)
                        .doTranslateKey(Me.txtJLBH)
                        .doTranslateKey(Me.txtRYDM)
                        .doTranslateKey(Me.txtRYXM)
                        .doTranslateKey(Me.ddlZJDM)
                        .doTranslateKey(Me.txtNBDRQ)

                        .doTranslateKey(Me.txtTDBH)

                        .doTranslateKey(Me.txtSSDW)
                        .doTranslateKey(Me.txtYRYZT)
                        .doTranslateKey(Me.txtYTD)
                        .doTranslateKey(Me.txtSPSM)
                        .doTranslateKey(Me.txtYBMMC)
                        .doTranslateKey(Me.ddlYDYY)

                        .doTranslateKey(Me.txtTDBH)
                        .doTranslateKey(Me.txtYZJMC)




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

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName.Trim
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

        '----------------------------------------------------------------
        ' 生成生效日期
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败

        '----------------------------------------------------------------
        Private Function doSetSXRQ(ByRef strErrMsg As String) As Boolean

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye

            doSetSXRQ = False
            strErrMsg = ""
            Dim strJBRQ As String
            Dim datJBRQ As System.DateTime
            Dim strMiddleMonth As String
            Dim datMiddleMonth As System.DateTime
            Dim strNextMonth As String
            Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
            Dim strCode As String = ""
            Dim strName As String = ""

            Try
                Me.rblSXRQ.Items.Clear()

                strJBRQ = Me.txtJBRQ.Text
                If strJBRQ.Trim <> "" Then
                    datJBRQ = CType(strJBRQ, System.DateTime)
                    strMiddleMonth = CType(Year(datJBRQ), String) + "-" + CType(Month(datJBRQ), String) + "-" + "15"
                    datMiddleMonth = CType(strMiddleMonth, System.DateTime)
                    If DateDiff(DateInterval.Day, datJBRQ, datMiddleMonth) > 0 Then

                        'strNextMonth = CType(Year(datJBRQ), String) + "-" + CType(Month(datJBRQ), String) + "-" + "01"
                        'strCode = strNextMonth
                        'strName = strNextMonth

                        'objListItem = New System.Web.UI.WebControls.ListItem
                        'objListItem.Text = strName
                        'objListItem.Value = strCode
                        'Me.rblSXRQ.Items.Add(objListItem)

                        strCode = strMiddleMonth
                        strName = strMiddleMonth

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName
                        objListItem.Value = strCode
                        Me.rblSXRQ.Items.Add(objListItem)

                        strNextMonth = CType(Year(datJBRQ.AddMonths(1)), String) + "-" + CType(Month(datJBRQ.AddMonths(1)), String) + "-" + "1"
                        strCode = strNextMonth
                        strName = strNextMonth

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName
                        objListItem.Value = strCode
                        Me.rblSXRQ.Items.Add(objListItem)
                    Else

                        'strCode = strMiddleMonth
                        'strName = strMiddleMonth

                        'objListItem = New System.Web.UI.WebControls.ListItem
                        'objListItem.Text = strName
                        'objListItem.Value = strCode
                        'Me.rblSXRQ.Items.Add(objListItem)

                        strNextMonth = CType(Year(datJBRQ.AddMonths(1)), String) + "-" + CType(Month(datJBRQ.AddMonths(1)), String) + "-" + "1"
                        strCode = strNextMonth
                        strName = strNextMonth

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName
                        objListItem.Value = strCode
                        Me.rblSXRQ.Items.Add(objListItem)

                        strNextMonth = CType(Year(datJBRQ.AddMonths(1)), String) + "-" + CType(Month(datJBRQ.AddMonths(1)), String) + "-" + "15"
                        strCode = strNextMonth
                        strName = strNextMonth

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName
                        objListItem.Value = strCode
                        Me.rblSXRQ.Items.Add(objListItem)
                    End If
                    If Me.rblSXRQ.SelectedIndex < 0 Then
                        Me.rblSXRQ.Items.Item(0).Selected = True
                    End If

                End If


            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)

            doSetSXRQ = True
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
                    If Me.doFillZjdmList(strErrMsg, Me.ddlZJDM) = False Then
                        GoTo errProc
                    End If
                    Dim strWhere As String = ""
                    'strWhere = "(a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM + " like '" + Me.htxtBDYY_RYZJ.Value + "%'"
                    'strWhere = strWhere + " or " + "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM + " like '" + Me.htxtBDYY_NBTZ.Value + "%')"
                    strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM + " like '" + Me.htxtBDYY_NBTZ.Value + "%'"
                    If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY, strWhere) = False Then
                        GoTo errProc
                    End If

                    
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

                '生成有效日期
                If Me.IsPostBack = False Then
                    If Me.doSetSXRQ(strErrMsg) = False Then
                        GoTo errProc
                    End If
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
                            If Me.m_objsystemFlowObjectRenshiTiaozheng.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                                GoTo errProc
                            End If
                        End If
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.mlJSWJ = True Then
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
            Josco.JSOA.BusinessFacade.systemFlowObjectRenshiTiaozheng.SafeRelease(Me.m_objsystemFlowObjectRenshiTiaozheng)
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
                            If Me.m_objsystemFlowObjectRenshiTiaozheng.getCanAutoEnterEditMode( _
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
                            If Me.m_objsystemFlowObjectRenshiTiaozheng.getCanAutoEnterEditMode( _
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
                Dim strWJBS As String = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
                Josco.JSOA.BusinessFacade.systemFlowObjectRenshiTiaozheng.SafeRelease(Me.m_objsystemFlowObjectRenshiTiaozheng)

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
                If Me.m_objsystemFlowObjectRenshiTiaozheng.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiTiaozheng.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                            If Me.m_objsystemFlowObjectRenshiTiaozheng.doLockFile(strErrMsg, "", False) = False Then
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
                    Dim strWJBS As String = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
                    If strWJBS = "" Then
                        strErrMsg = "错误：没有文件进行编辑！"
                        GoTo errProc
                    End If

                    '自动清除自己对该文件的编辑封锁
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                        GoTo errProc
                    End If

                    '封锁检查
                    Dim strBMMC As String
                    Dim strRYMC As String
                    Dim blnDo As Boolean
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.getFileLocked(strErrMsg, blnDo, strBMMC, strRYMC) = False Then
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
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.doLockFile(strErrMsg, MyBase.UserId, True) = False Then
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
                objOldData = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData
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
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.getFujianData(strErrMsg, objOldFJData) = False Then
                            GoTo errProc
                        End If
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                            GoTo errProc
                        End If
                End Select

                '准备额外参数
                objParams.Clear()
                objParams.Add(0, Me.m_objDataSet_RYXX)

                '保存数据
                With Me.m_objsystemFlowObjectRenshiTiaozheng
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
                strWJBS = objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENGSHENPI_WJBS)

                '写审计日志
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "创建了[" + strWJBS + "]文件！") = False Then
                            '忽略
                        End If
                    Case Else
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "改动了[" + strWJBS + "]文件！") = False Then
                            '忽略
                        End If
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.doWriteUserLog_Fujian(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_FJ, objOldFJData) = False Then
                            '忽略
                        End If
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.doWriteUserLog_XGWJ(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_XGWJ, objOldXGWJData) = False Then
                            '忽略
                        End If
                End Select

                '进入查看状态
                Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS = strWJBS
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
                If Me.m_objsystemFlowObjectRenshiTiaozheng.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.getCanAutoEnterEditMode( _
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
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiTiaozheng.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                If Me.m_objsystemFlowObjectRenshiTiaozheng.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiTiaozheng.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                If Me.m_objsystemFlowObjectRenshiTiaozheng.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.getCanAutoEnterEditMode( _
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
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiTiaozheng.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                If Me.m_objsystemFlowObjectRenshiTiaozheng.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
                    GoTo errProc
                End If

                '获取稿件
                Dim strMBPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToWordTemplate)
                Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                Dim strCacheFile As String = Me.m_strGJFileName
                If Me.m_objsystemFlowObjectRenshiTiaozheng.getGJFile(strErrMsg, Me.m_blnEditMode, strCacheFile, strMBPath, strGJPath, strGJFile) = False Then
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
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.getCanAutoEnterEditMode( _
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
                    '************************************************************************************************
                    .iGJFileSpec = strGJFile
                    .iobjDataSet_FJ = Me.m_objDataSet_FJ
                    .iobjDataSet_XGWJ = Me.m_objDataSet_XGWJ
                    .iobjNewData = Nothing
                    '************************************************************************************************
                    .iCanQSYJ = Me.m_objsystemFlowObjectRenshiTiaozheng.mlTXYJ
                    If .iCanQSYJ = False Then
                        .iCanQSYJ = Me.m_objsystemFlowObjectRenshiTiaozheng.mlBDPS
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
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiTiaozheng.swgjShowTrackRevisions And blnHasSendOnce
                    .iCanExportGJ = Me.m_objsystemFlowObjectRenshiTiaozheng.swgjExportFile
                    .iCanImportGJ = Me.m_objsystemFlowObjectRenshiTiaozheng.swgjImportFile
                    .iCanSelectTGWJ = Me.m_objsystemFlowObjectRenshiTiaozheng.swgjSelectGJ
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                strUrl += "../../flow_rs/flow_send.aspx"
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS

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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS

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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                If Me.m_objsystemFlowObjectRenshiTiaozheng.doIReadFile(strErrMsg, MyBase.UserXM) = False Then
                    GoTo errProc
                End If

                '刷新数据
                If Me.doRefreshData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '提示信息
                objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：通知消息我已经阅读了，该消息不再显示在[未办事宜]中！")

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
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.doIDoNotProcess(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.doICompleteTask(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.doIStopFile(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.doIContinueFile(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.doIZuofeiFile(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.doIQiyongFile(strErrMsg, MyBase.UserXM) = False Then
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
            Dim intStep As Integer

            doCompleteFile = False
            strErrMsg = ""

            Try
                '检查并询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '检查
                    Dim strUserList As String
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.getUncompleteTaskRY(strErrMsg, MyBase.UserXM, strUserList) = False Then
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
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.doCompleteFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    '刷新数据
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '记录日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]对[" + Me.m_objInterface.iWJBS + "," + Me.txtWJBT.Text + "]进行了[办结处理]！")


                    '提示信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：文件成功办结！")

                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doCompleteFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS

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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS

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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
                    .iSPR = MyBase.UserXM
                    .iDLR = ""
                    .iInitYjlx = strYjlx

                    blnEnabled(0) = Me.lnkCZQSYJ_SH.Enabled
                    blnEnabled(1) = Me.lnkCZQSYJ_QF.Enabled
                    blnEnabled(2) = Me.lnkCZQSYJ_FH.Enabled
                    blnEnabled(3) = Me.lnkCZQSYJ_HG.Enabled
                    blnEnabled(4) = Me.lnkCZQSYJ_HQ.Enabled
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS
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
                '    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                '    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS

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
                '    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.FlowTypeName
                '    .iWJBS = Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS

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
                    If Me.m_objsystemFlowObjectRenshiTiaozheng.doSetTaskBWTX(strErrMsg, MyBase.UserXM, True) = False Then
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
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_SH", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.TASK_SHWJ) = False Then
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
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_HQ", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.TASK_HQWJ) = False Then
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
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_QF", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.TASK_QFWJ) = False Then
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
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_FH", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.TASK_FHWJ) = False Then
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

        Private Sub lnkCZQSYJ_HG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_HG.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, " lnkCZQSYJ_HG", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.TASK_HGWJ) = False Then
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
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_SHBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.TASK_SHWJ) = False Then
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
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_HQBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.TASK_HQWJ) = False Then
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
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_FHBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.TASK_FHWJ) = False Then
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


        Private Sub lnkCZQSYJ_HGBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_HGBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_HGBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.TASK_HGWJ) = False Then
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
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_QFBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.TASK_QFWJ) = False Then
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
                Dim objBaseFlowRenshiTiaozheng As Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng
                objBaseFlowRenshiTiaozheng = CType(Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng)
                If objBaseFlowRenshiTiaozheng.HJWJ = "" Then
                    strErrMsg = "错误：还没有导入签批件的电子文件！"
                    GoTo errProc
                End If

                '签批件的电子件
                Dim strFileSpec As String = ""
                Dim strFilePath As String = ""
                Dim strFileName As String = ""
                strFilePath = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, objBaseFlowRenshiTiaozheng.HJWJ, strFileSpec, strFilePath, strFileName) = False Then
                    GoTo errProc
                End If
                Dim strUrl As String
                strUrl = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + strFileName

                '记录访问审计日志
                If Me.m_objsystemFlowObjectRenshiTiaozheng.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了文件[" + Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS + "]的[签批件的电子文件]！") = False Then
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
                Dim objBaseFlowRenshiTiaozheng As Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng
                objBaseFlowRenshiTiaozheng = CType(Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng)
                If objBaseFlowRenshiTiaozheng.PJYJ = "" Then
                    strErrMsg = "错误：还没有导入签批件的扫描件！"
                    GoTo errProc
                End If

                '签批件的扫描件
                Dim strFileSpec As String = ""
                Dim strFilePath As String = ""
                Dim strFileName As String = ""
                strFilePath = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, objBaseFlowRenshiTiaozheng.PJYJ, strFileSpec, strFilePath, strFileName) = False Then
                    GoTo errProc
                End If
                Dim strUrl As String
                strUrl = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + strFileName

                '记录访问审计日志
                If Me.m_objsystemFlowObjectRenshiTiaozheng.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了文件[" + Me.m_objsystemFlowObjectRenshiTiaozheng.FlowData.WJBS + "]的[签批件的扫描件]！") = False Then
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

        Private Sub doSelectJGDM(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '备份现场参数
                Dim strSessionId As String
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIDmxzRyjg As Josco.JSOA.BusinessFacade.IDmxzRyjg
                Dim strUrl As String
                objIDmxzRyjg = New Josco.JSOA.BusinessFacade.IDmxzRyjg
                With objIDmxzRyjg
                    .iAllowInput = True
                    .iMultiSelect = False
                    .iSelectFFFW = False
                    .iLeibieList = Me.txtRYXM.Text

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
                Dim strNewSessionId As String
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strNewSessionId = .getNewGuid()
                End With
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIDmxzRyjg)

                strUrl = ""
                strUrl += "estate_rs_jgxz.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

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

        'Private Sub btnSelect_ZZDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_ZZDM.Click
        '    Me.doSelect_ZZRY("btnSelect_ZZDM")
        'End Sub

        'Private Sub btnFPBM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFPBM.Click
        '    
        'End Sub
        Private Sub btnSelectZZDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZZDM.Click
            Me.doSelect_ZZDM("btnSelectZZDM")
        End Sub

        Private Sub btnSelectXM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectXM.Click
            Me.doSelectJGDM("btnSelectXM")
        End Sub

        Private Sub btnSelectTDBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectTDBH.Click
            Me.doSelectTDBH("btnSelectTDBH")
        End Sub

        Private Sub btnSJJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSJJL.Click
            Me.doSelect_ZZRY("btnSJJL")
        End Sub

        Private Sub btnYSJJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYSJJL.Click
            Me.doSelect_ZZRY("btnYSJJL")
        End Sub








        Private Sub doRYXX_AddNew(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strZJDM As String = ""
            Dim strRYLX As String = ""
            Dim strYZJDM As String = ""
            Try

                '检查
                If Me.txtRYDM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[人员代码]！"
                    GoTo errProc
                End If
                If Me.txtSSDW.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[新的单位]！"
                    GoTo errProc
                End If

                '判断是否是行政助理和业务人员之间互转
                strYZJDM = Me.htxtYZJDM.Value.Trim
                strZJDM = Me.ddlZJDM.SelectedValue
                If Left(strZJDM, 7) = "030.010" Or Left(strYZJDM, 7) = "030.010" Then
                    If (Left(strZJDM, 7) = "030.010" And Left(strYZJDM, 7) = "030.010") = False Then
                        strErrMsg = "错误:系统不支持行政助理和业务人员互转的调整!"
                        GoTo errProc
                    End If
                End If

                If Left(strZJDM, 7) <> "030.010" Then
                    If Me.txtSJLDMC.Text.Trim = "" Then
                        strErrMsg = "错误：没有输入[新的上级经理]！"
                        GoTo errProc
                    End If
                    If Me.txtYSJLDMC.Text.Trim = "" Then
                        strErrMsg = "错误：没有输入[原上级经理]！"
                        GoTo errProc
                    End If

                    If Me.txtTDBH.Text.Trim = "" Then
                        strErrMsg = "错误：没有输入[新的团队]！"
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

                If Me.txtNBDRQ.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtNBDRQ.Text) = False Then
                        strErrMsg = "错误：[拟报到日期]是无效的日期！"
                        GoTo errProc
                    End If
                End If

                '检验生效日期是否有效
                If Me.txtRQ.Text.Trim = "" Then
                    strErrMsg = "错误：[拟生效日期]不能为空！"
                    GoTo errProc
                Else
                    If Date.Compare(CDate(txtRQ.Text.Trim), CDate(txtJBRQ.Text.Trim)) < 0 Then
                        strErrMsg = "提示：有效日期小于经办日期"
                        GoTo errProc
                    End If
                End If
                

                '检验当前人是否已在流程中
                Dim strRydm As String = ""
                Dim strGrdRydm As String = ""
                Dim strDWDM As String
                Dim strGrdDWDM As String
                Dim intCount As Integer = 0

                Dim intRows As Integer
                Dim i As Integer
                Dim intIndex As Integer

                strRydm = Me.txtRYDM.Text.Trim
                strDWDM = Me.htxtSSDW.Value

                '1-检查调整人是否已在当前列表  
                intRows = Me.grdRYXX.Items.Count
                For i = intRows - 1 To 0 Step -1
                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYDM)
                    strGrdRydm = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWDM)
                    strGrdDWDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                    If strRydm = strGrdRydm.Trim Then
                        strErrMsg = "提示：[" + strRydm + "] 已在列表，不能重复增加!"
                        GoTo errProc
                    End If
                    If strDWDM = strGrdDWDM.Trim Then
                        intCount = intCount + 1
                    End If
                Next

                '2-检查调整人是否在流转列表（独立）
                Dim blnSJ As Boolean
                If objsystemEstateRenshiXingye.checkFlowRy(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRydm, blnSJ) = False Then
                    GoTo errProc
                End If

                If blnSJ = True Then
                    strErrMsg = "提示：[" + strRydm + "] 已在调整列表中，不能增加!"
                End If
                '3-是否检测编制（配置文件设置开关）
                '3-如果是调整部门，则检测调整部门是否还有编制
                '3-1 调整部门的剩余编制
                '3-2 当前列表中调动人数



                '加入
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_RYXX.Tables(strTable)
                    objDataRow = .NewRow()

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYXH) = .Rows.Count + 1
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WYBS) = ""
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WJBS) = Me.htxtWJBS.Value
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYDM) = Me.txtRYDM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YWYBS) = Me.txtYWYBS.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYXM) = Me.txtRYXM.Text

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZJDM) = Me.htxtYZJDM.Value
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZJMC) = Me.txtYZJMC.Text
                    If Me.ddlZJDM.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZJDM) = ""
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZJMC) = ""
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZJDM) = objPulicParameters.getObjectValue(Me.ddlZJDM.SelectedValue, "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZJMC) = Me.ddlZJDM.SelectedItem.Text
                    End If

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YDWDM) = Me.htxtYBMDM.Value
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YDWMC) = Me.txtYBMMC.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWDM) = Me.htxtSSDW.Value
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWMC) = Me.txtSSDW.Text

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YTDBH) = objPulicParameters.getObjectValue(Me.txtYTD.Text, 1)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_TDBH) = objPulicParameters.getObjectValue(Me.txtTDBH.Text, 1)

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YRYZT) = objPulicParameters.getObjectValue(Me.htxtYRYZTDM.Value, 1)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YRYZTMC) = Me.txtYRYZT.Text
                    If Me.rblRYZT.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYZT) = 1
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYZT) = objPulicParameters.getObjectValue(Me.rblRYZT.SelectedValue, 1)
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYZTMC) = Me.rblRYZT.SelectedItem.Text

                    'If Me.rblSXRQ.SelectedIndex < 0 Then
                    '    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SXRQ) = 1
                    'Else
                    '    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SXRQ) = objPulicParameters.getObjectValue(Me.rblSXRQ.SelectedValue, Now)
                    'End If

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SXRQ) = objPulicParameters.getObjectValue(Me.txtRQ.Text, Now)

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YSFZB) = objPulicParameters.getObjectValue(Me.htxtYZBQKDM.Value, 1)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZB) = Me.txtYZBQK.Text
                    If Me.rblSFZB.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFZB) = "1"
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFZB) = objPulicParameters.getObjectValue(Me.rblSFZB.SelectedValue, 1)
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZB) = Me.rblSFZB.SelectedItem.Text

                    If Me.ddlYDYY.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYDM) = ""
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYMC) = ""
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYDM) = objPulicParameters.getObjectValue(Me.ddlYDYY.SelectedValue, "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYMC) = Me.ddlYDYY.SelectedItem.Text
                    End If

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFJZ) = objPulicParameters.getObjectValue(Me.txtSFJZ.Text, 1)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYLX) = objPulicParameters.getObjectValue(Me.txtRTLX.Text, 1)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYLXMC) = Me.txtRTLXMC.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_BZXL) = Me.txtBZXL.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGDWDM) = Me.txtZGDWDM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGDWMC) = Me.txtZGDWMC.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SJLD) = Me.txtSJLD.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SJLDMC) = Me.txtSJLDMC.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YSJLDMC) = Me.txtYSJLDMC.Text

                    '团队操作
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGTD) = Me.htxtZGTD.Value
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XGTD) = Me.htxtXGTD.Value
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZGTD) = Me.htxtYZGTD.Value
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YXGTD) = Me.htxtYXGTD.Value

                    '获取缓存数据
                    If Me.getModuleData_TDZH(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    Dim incout As Integer = 0
                    'Dim i As Integer = 0
                    Dim strTDName As String = ""
                    Dim strZHBS As String = ""
                    Dim blnChange As Boolean = False

                    '新直管团队
                    strTDName = ""
                    incout = Me.lstZGTD.Items.Count
                    If incout > 0 Then
                        For i = 0 To incout - 1
                            If i = 0 Then
                                strTDName = Me.lstZGTD.Items.Item(i).Text
                            Else
                                strTDName = strTDName + "、" + Me.lstZGTD.Items.Item(i).Text
                            End If
                        Next i
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGTDMC) = strTDName
                        blnChange = True
                    Else
                        If Me.lstYZGTD.Items.Count > 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGTDMC) = ""
                            blnChange = True
                        End If

                    End If

                    '新协管团队
                    strTDName = ""
                    incout = Me.lstXGTD.Items.Count
                    If incout > 0 Then
                        For i = 0 To incout - 1
                            If i = 0 Then
                                strTDName = Me.lstXGTD.Items.Item(i).Text
                            Else
                                strTDName = strTDName + "、" + Me.lstXGTD.Items.Item(i).Text
                            End If
                        Next i
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XGTDMC) = strTDName
                        blnChange = True
                    Else
                        If Me.lstYXGTD.Items.Count > 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XGTDMC) = ""
                            blnChange = True
                        End If
                    End If

                    If blnChange = True Then
                        '保存数据
                        If objsystemEstateRenshiXingye.doSaveTDTempData(strErrMsg, MyBase.UserId, MyBase.UserPassword, 0, objDataRow, Me.m_objDataSet_TDZH) = False Then
                            GoTo errProc
                        End If
                    End If

                    '原直管团队
                    strTDName = ""
                    incout = Me.lstYZGTD.Items.Count
                    If incout > 0 Then
                        For i = 0 To incout - 1
                            If i = 0 Then
                                strTDName = Me.lstYZGTD.Items.Item(i).Text
                            Else
                                strTDName = strTDName + "、" + Me.lstYZGTD.Items.Item(i).Text
                            End If
                        Next i
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZGTDMC) = strTDName
                    End If

                    '原协管团队
                    strTDName = ""
                    incout = Me.lstYXGTD.Items.Count
                    If incout > 0 Then
                        For i = 0 To incout - 1
                            If i = 0 Then
                                strTDName = Me.lstYXGTD.Items.Item(i).Text
                            Else
                                strTDName = strTDName + "、" + Me.lstYXGTD.Items.Item(i).Text
                            End If
                        Next i
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YXGTDMC) = strTDName
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
                        If Me.htxtRYXM.Value.Trim = "" Then
                            Me.htxtRYXM.Value = "(" + Me.txtRYXM.Text.Trim + ")"
                        Else
                            Me.htxtRYXM.Value = Left(Me.htxtRYXM.Value.Trim, Len(Me.htxtRYXM.Value.Trim) - 1) + "、" + Me.txtRYXM.Text.Trim + ")"
                        End If
                        If InStr(Me.txtWJBT.Text, "(") - 1 > 0 Then
                            Me.txtWJBT.Text = Left(Me.txtWJBT.Text, InStr(Me.txtWJBT.Text, "(") - 1) + Me.htxtRYXM.Value
                        Else
                            Me.txtWJBT.Text = Me.txtWJBT.Text + Me.htxtRYXM.Value
                        End If

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


        Private Sub doRYXX_Delete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
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
                    Dim strZGZBBS As String = ""
                    Dim strXGZBBS As String = ""

                    intRows = Me.grdRYXX.Items.Count
                    intRow = Me.grdRYXX.Items.Count
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)
                            With Me.m_objDataSet_RYXX.Tables(strTable)
                                objDataRow = Nothing
                                strZGZBBS = ""
                                strZGZBBS = objPulicParameters.getObjectValue(.Rows(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGTD), "")
                                strXGZBBS = objPulicParameters.getObjectValue(.Rows(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XGTD), "")

                                If objsystemEstateRenshiXingye.doDeleteTDTempData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZGZBBS, 0) = False Then
                                    GoTo errProc
                                End If

                                If objsystemEstateRenshiXingye.doDeleteTDTempData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strXGZBBS, 0) = False Then
                                    GoTo errProc
                                End If

                                strRymc = ""
                                objDataRow = .DefaultView.Item(i).Row
                                If Not (objDataRow Is Nothing) Then
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYXM)
                                    strRymc = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    If i > 0 Then
                                        If intRow > 1 Then
                                            strRymc = "、" + strRymc
                                        Else
                                            strRymc = "(" + strRymc + ")"
                                        End If
                                    Else
                                        If intRow > 1 Then
                                            strRymc = strRymc + "、"
                                        Else
                                            strRymc = "(" + strRymc + ")"
                                        End If
                                    End If
                                    Select Case Me.m_objenumEditType
                                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                                            Me.htxtRYXM.Value = Replace(Me.htxtRYXM.Value.Trim, strRymc, "")
                                        Case Else
                                            Me.htxtRYXM.Value = Replace(Me.htxtRYXM.Value.Trim, strRymc, "")
                                            Me.txtWJBT.Text = Replace(Me.txtWJBT.Text.Trim, strRymc, "")
                                    End Select
                                    .Rows.Remove(objDataRow)
                                    intRow = intRow - 1
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
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Sub

        End Sub


        Private Sub btnRYXX_AddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYXX_AddNew.Click
            Me.doRYXX_AddNew("btnRYXX_AddNew")
        End Sub

        'Private Sub btnRYXX_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYXX_Update.Click
        '    Me.doRYXX_Update("btnRYXX_Update")
        'End Sub

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

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI
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
                    Dim blnTZ As Boolean = False

                    intRows = Me.grdRYXX.Items.Count


                    objNewData = New System.Collections.Specialized.NameValueCollection

                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPSM, Me.txtSPSM.Text)
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPR, MyBase.UserXM)
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPRQ, Now.ToString())
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPJG, "0")

                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)
                            With Me.m_objDataSet_RYXX.Tables(strTable)
                                objDataRow = Nothing
                                objDataRow = .DefaultView.Item(intPos).Row
                                If Not (objDataRow Is Nothing) Then
                                    strWYBS = objPulicParameters.getObjectValue(.Rows(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WYBS), "")
                                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WYBS, strWYBS)

                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYXM)
                                    strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPR)
                                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    If Trim(strValue) <> "" Then
                                        If strGoNext.Trim = "" Then
                                            strGoNext = strRYMC
                                            GoTo goNext
                                        Else
                                            strGoNext = strGoNext + "、" + strRYMC
                                        End If
                                    End If

                                    If objsystemEstateRenshiXingye.doSaveRyxx_BTG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtWJBS.Value, objNewData, blnTZ) = False Then
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
                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPR)
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
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.doCompleteFile(strErrMsg, MyBase.UserXM) = False Then
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI
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
            Dim strYDMC As String = ""
            Dim strGoNext As String = ""
            Dim strSPR As String = ""
            Dim strZZDM As String = ""

            Dim objNewData_Save As System.Data.DataRow = Nothing
            Dim objOldData As System.Data.DataRow = Nothing
            Dim objEnvInfo As New System.Collections.Specialized.NameValueCollection

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
                    Dim blnTZ As Boolean = False
                    Dim strRYLX As String = ""


                    intRows = Me.grdRYXX.Items.Count
                    objNewData_RY = New System.Collections.Specialized.NameValueCollection

                    'If Me.chkSFJZ.Checked = True Then
                    '    objNewData_RY.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFJZ) = "1"
                    'Else
                    '    objNewData_RY.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFJZ) = "0"
                    'End If
                    Dim intCols As Integer
                    Dim j As Integer
                    
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)
                            With Me.m_objDataSet_RYXX.Tables(strTable)
                                objDataRow = Nothing
                                objNewData_RY.Clear()
                                objEnvInfo.Clear()
                                objNewData_Save = Nothing
                                objOldData = Nothing

                                objDataRow = .DefaultView.Item(intPos).Row
                                If Not (objDataRow Is Nothing) Then

                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPSM, Me.txtSPSM.Text)
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPR, MyBase.UserXM)
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPRQ, Now.ToString())
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPJG, "1")
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_BDRQ, Me.txtNBDRQ.Text)

                                    strWYBS = objPulicParameters.getObjectValue(.Rows(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WYBS), "")
                                    objNewData_RY.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WYBS, strWYBS)

                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYDM)
                                    strYDYY = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYMC)
                                    strYDMC = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYXM)
                                    strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPR)
                                    strSPR = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    If Trim(strSPR) <> "" Then
                                        If strGoNext.Trim = "" Then
                                            strGoNext = strRYMC
                                            GoTo goNext
                                        Else
                                            strGoNext = strGoNext + "、" + strRYMC
                                        End If
                                    End If

                                    '判断是否有职级变化
                                    Dim strZJDM As String
                                    Dim strYZJDM As String
                                    Dim strSPRList As String
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZJDM)
                                    strZJDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZJDM)
                                    strYZJDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    If strZJDM.Trim <> strYZJDM.Trim Then
                                        strSPRList = Josco.JSOA.Common.Data.estateRenshiXingyeData.RS_ZHIJISP_RY
                                        If InStr(strSPRList, MyBase.UserXM) < 0 Then
                                            strErrMsg = "[" + strRYMC + "]职级发生变动，您没有权限审批？请联系管理员！"
                                            GoTo errProc
                                        End If
                                    End If

                                    '判断报到日期是否大于生效日期
                                    Dim strYWYBS As String
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYLX)
                                    strRYLX = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYDM)
                                    strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YDWDM)
                                    strZZDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YWYBS)
                                    strYWYBS = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)

                                    If strYWYBS.Trim = "" Then
                                        strErrMsg = "错误：原唯一标识已经出错，请联系管理员！"
                                        GoTo errProc
                                    End If
                                    Dim blnSJ As Boolean = False
                                    If objsystemEstateRenshiXingye.checkBDSJ(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strZZDM, strRYLX, Me.txtNBDRQ.Text, blnSJ) = False Then
                                        GoTo errProc
                                    End If

                                    If blnSJ = False Then
                                        strErrMsg = "错误：[" + strRYDM + "]无效的报到日期，请查证后再点通过！"
                                        GoTo errProc
                                    End If

                                    objOldData = .DefaultView.Item(i).Row
                                    objNewData_Save = .NewRow()
                                    '写原始数据
                                    intCols = .Columns.Count
                                    For j = 0 To intCols - 1 Step 1
                                        objNewData_Save.Item(j) = objOldData.Item(j)
                                    Next

                                    objEnvInfo.Add("BDSJ", Me.txtNBDRQ.Text)

                                    objEnvInfo.Add("BDYY", strYDYY)
                                    objEnvInfo.Add("BDYYMC", strYDMC)

                                    '保存修改架构数据
                                    If objsystemEstateRenshiXingye.doAdjust_RenyuanJiagou(strErrMsg, MyBase.UserId, MyBase.UserPassword, objEnvInfo, objOldData, objNewData_Save, Nothing, blnTZ) = False Then
                                        GoTo errProc
                                    End If

                                    '通过调整审批单
                                    If objsystemEstateRenshiXingye.doSaveRyxx_TG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtWJBS.Value, objNewData_RY, blnTZ) = False Then
                                        GoTo errProc
                                    End If

                                    '如果是换部门或者售楼部的话，在考勤里自动加入调入，调出的考勤信息
                                    Dim strNewZZDM As String
                                    intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWDM)
                                    strNewZZDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(i), intIndex)

                                    If strZZDM <> strNewZZDM Then
                                        '判断是否售楼部调出
                                        If Len(strZZDM) > 4 And Left(strZZDM, 4) = "0102" Then
                                            '加入调出考勤信息

                                        End If
                                        '判断是否调入售楼部
                                        If Len(strZZDM) > 4 And Left(strZZDM, 4) = "0102" Then
                                            '加入调入考勤信息
                                        End If
                                    End If

                                    '写配置日志
                                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_人员架构_管理架构]中调整了[" + strRYMC + "]！")

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
                        intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPR)
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
                        If Me.m_objsystemFlowObjectRenshiTiaozheng.doCompleteFile(strErrMsg, MyBase.UserXM) = False Then
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
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_BZXL)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYDM)
                intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYXM)
                intColIndex(3) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWDM)
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

        Private Sub btnSelectZGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZGTD.Click
            Me.doSelectZGTD("btnSelectZGTD")
        End Sub

        Private Sub btnSelectXGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectXGTD.Click
            Me.doSelectXGTD("btnSelectXGTD")
        End Sub


        Private Sub btnAddnewZGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddnewZGTD.Click
            Me.doAddnewZGTD("btnAddnewZGTD")
        End Sub



        Private Sub btnAddnewXGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddnewXGTD.Click
            Me.doAddnewXGTD("btnAddnewXGTD")
        End Sub



        Private Sub btnDeleteZGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteZGTD.Click
            Me.doDeleteZGTD("btnDeleteZGTD")
        End Sub



        Private Sub btnDeleteXGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteXGTD.Click
            Me.doDeleteXGTD("btnDeleteXGTD")
        End Sub

        Private Sub doSelectZGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtNBDRQ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[入职时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtNBDRQ.Text) = False Then
                    strErrMsg = "错误：无效的[入职时间][" + Me.txtNBDRQ.Text + "]！"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = True
                    .iAllowNull = True
                    .iJCSJ = Me.txtNBDRQ.Text
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

        Private Sub doSelectXGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtNBDRQ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[入职时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtNBDRQ.Text) = False Then
                    strErrMsg = "错误：无效的[入职时间][" + Me.txtNBDRQ.Text + "]！"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = True
                    .iAllowNull = True
                    .iJCSJ = Me.txtNBDRQ.Text
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


        Private Sub doAddnewZGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtNBDRQ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[入职时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtNBDRQ.Text) = False Then
                    strErrMsg = "错误：无效的[入职时间][" + Me.txtNBDRQ.Text + "]！"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = True
                    .iAllowNull = False
                    .iJCSJ = Me.txtNBDRQ.Text
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



        Private Sub doAddnewXGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtNBDRQ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[入职时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtNBDRQ.Text) = False Then
                    strErrMsg = "错误：无效的[入职时间][" + Me.txtNBDRQ.Text + "]！"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = True
                    .iAllowNull = False
                    .iJCSJ = Me.txtNBDRQ.Text
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



        Private Sub doDeleteZGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查选择
                Dim i, intCount, intSelected As Integer
                intCount = Me.lstZGTD.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    If Me.lstZGTD.Items(i).Selected = True Then
                        intSelected += 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "错误：没有选定任何团队！"
                    GoTo errProc
                End If

                '移除操作
                Dim strZBBS As String = ""
                If Me.getModuleData_TDZH(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.doDelInBuffer_TDZH(strErrMsg, Me.lstZGTD, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH, strZBBS) = False Then
                    GoTo errProc
                End If
                If Me.htxtZGTD.Value.Trim <> "" Then
                    If Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH) = False Then
                        GoTo errProc
                    End If
                End If
                If strZBBS <> "" Then
                    Me.htxtZGTD.Value = strZBBS
                End If
                If Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstZGTD) = False Then
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



        Private Sub doDeleteXGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查选择
                Dim i, intCount, intSelected As Integer
                intCount = Me.lstXGTD.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    If Me.lstXGTD.Items(i).Selected = True Then
                        intSelected += 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "错误：没有选定任何团队！"
                    GoTo errProc
                End If

                '移除操作
                Dim strZBBS As String = ""
                If Me.getModuleData_TDZH(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.doDelInBuffer_TDZH(strErrMsg, Me.lstXGTD, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH, strZBBS) = False Then
                    GoTo errProc
                End If
                If Me.htxtXGTD.Value.Trim <> "" Then
                    If Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH) = False Then
                        GoTo errProc
                    End If
                End If
                If strZBBS <> "" Then
                    Me.htxtXGTD.Value = strZBBS
                End If
                If Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstXGTD) = False Then
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

        '----------------------------------------------------------------
        ' 获取团队组合临时数据集
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_TDZH(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_TDZH = False

            Try
                '根据需要获取
                If Me.htxtSessionId_TDZH.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_TDZH = CType(Session.Item(Me.htxtSessionId_TDZH.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_TDZH)
                    '空数据
                    Me.m_objDataSet_TDZH = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_B_RS_TDZH)
                    '缓存数据
                    Me.htxtSessionId_TDZH.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_TDZH.Value, Me.m_objDataSet_TDZH)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_TDZH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取团队组合临时数据集
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_YTDZH(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_YTDZH = False

            Try
                '根据需要获取
                If Me.htxtSessionId_YTDZH.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_YTDZH = CType(Session.Item(Me.htxtSessionId_YTDZH.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_YTDZH)
                    '空数据
                    Me.m_objDataSet_YTDZH = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_B_RS_TDZH)
                    '缓存数据
                    Me.htxtSessionId_YTDZH.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_YTDZH.Value, Me.m_objDataSet_YTDZH)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_YTDZH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示strZBBS的objDataSet_Des数据到objListBox
        '     strErrMsg      ：返回错误信息
        '     strZBBS        ：组别标识
        '     objDataSet_Des ：显示数据
        '     objListBox     ：显示控件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doDisplayBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strZBBS As String, _
            ByVal objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objListBox As System.Web.UI.WebControls.ListBox) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
            Dim strOldRowFilter As String = ""
            Dim strZHBS As String = ""
            Dim strDWMC As String = ""
            Dim strTDBH As String = ""
            Dim i, intRows As Integer

            doDisplayBuffer_TDZH = False
            strErrMsg = ""

            Try
                '检查
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '清空
                objListBox.Items.Clear()

                '备份
                With objDataSet_Des.Tables(strTable)
                    strOldRowFilter = .DefaultView.RowFilter
                End With

                '搜索
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS + " = '" + strZBBS + "'"
                End With

                '主处理
                With objDataSet_Des.Tables(strTable)
                    intRows = .DefaultView.Count
                    For i = 0 To intRows - 1 Step 1
                        strZHBS = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS), "")
                        strDWMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_DWMC), "")
                        strTDBH = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), "")

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Value = strZHBS
                        objListItem.Text = strDWMC + "_" + strTDBH

                        objListBox.Items.Add(objListItem)
                    Next
                End With

                '恢复
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = strOldRowFilter
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doDisplayBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示strTDMC的strZHBS数据到objListBox
        '     strErrMsg      ：返回错误信息
        '     strZBBS        ：组别标识
        '     objDataSet_Des ：显示数据
        '     objListBox     ：显示控件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doDisplayBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strTDMC As String, _
            ByVal strZHBS As String, _
            ByVal objListBox As System.Web.UI.WebControls.ListBox) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
            Dim strOldRowFilter As String = ""

            Dim strDWMC As String = ""
            Dim strTDBH As String = ""
            Dim i, intRows As Integer

            doDisplayBuffer_TDZH = False
            strErrMsg = ""

            Try
                
                '解析接收人

                '清空
                objListBox.Items.Clear()

                Dim strArray() As String
                strTDMC = objPulicParameters.doTranslateSeperate(strTDMC)
                strArray = strTDMC.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)

                '逐个发送
                Dim intCount As Integer
                intCount = strArray.Length
                For i = 0 To intCount - 1 Step 1
                    objListItem = New System.Web.UI.WebControls.ListItem
                    objListItem.Value = strZHBS
                    objListItem.Text = strArray(i)

                    objListBox.Items.Add(objListItem)
                Next

               
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doDisplayBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 将objDataSet_Src写入objDataSet_Des中
        '     strErrMsg      ：返回错误信息
        '     objDataSet_Src ：要加入的数据
        '     objDataSet_Des ：加入到的数据
        '     strZBBS        ：新组别标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doAddInBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal objDataSet_Src As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef strZBBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim i, j, intRows, intCols As Integer
            Dim strZHBS As String = ""

            doAddInBuffer_TDZH = False
            strErrMsg = ""
            strZBBS = ""

            Try
                '检查
                '=====================================================================================================================
                If objDataSet_Src Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '主处理
                strZBBS = objPulicParameters.getNewGuid()
                With objDataSet_Src.Tables(strTable)
                    intCols = .Columns.Count
                    intRows = .Rows.Count
                    For i = 0 To intRows - 1 Step 1
                        strZHBS = objPulicParameters.getNewGuid()

                        With objDataSet_Des.Tables(strTable)
                            objDataRow = .NewRow
                        End With

                        For j = 0 To intCols - 1 Step 1
                            objDataRow.Item(j) = .Rows(i).Item(j)
                        Next
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS

                        With objDataSet_Des.Tables(strTable)
                            .Rows.Add(objDataRow)
                        End With
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doAddInBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 从objDataSet_Des删除strZBBS对应的数据
        '     strErrMsg      ：返回错误信息
        '     strZBBS        ：组别标识
        '     objDataSet_Des ：操作数据
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doDeleteBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strZBBS As String, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strOldRowFilter As String = ""
            Dim i, intRows As Integer

            doDeleteBuffer_TDZH = False
            strErrMsg = ""

            Try
                '检查
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If
                '=====================================================================================================================

                '备份
                With objDataSet_Des.Tables(strTable)
                    strOldRowFilter = .DefaultView.RowFilter
                End With

                '搜索
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS + " = '" + strZBBS + "'"
                End With

                '主处理
                With objDataSet_Des.Tables(strTable)
                    intRows = .DefaultView.Count
                    For i = intRows - 1 To 0 Step -1
                        .Rows.Remove(.DefaultView.Item(i).Row)
                    Next
                End With

                '恢复
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = strOldRowFilter
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doDeleteBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 将objDataSet_Src写入objDataSet_Des中，只加入objDataSet_Src在
        ' strZBBS_Old中不存在的团队
        '     strErrMsg      ：返回错误信息
        '     objDataSet_Src ：要加入的数据
        '     strZBBS_Old    ：原组别标识
        '     objDataSet_Des ：加入到的数据
        '     strZBBS        ：新组别标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2010-03-18 创建
        '----------------------------------------------------------------
        Private Function doAddInBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal objDataSet_Src As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal strZBBS_Old As String, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef strZBBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataSet_Old As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim i, j, intRows, intCols As Integer
            Dim strZHBS As String = ""

            doAddInBuffer_TDZH = False
            strErrMsg = ""
            strZBBS = ""

            Try
                '检查
                '=====================================================================================================================
                If objDataSet_Src Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '计算strZBBS_Old对应的团队数据[objDataSet_Old]
                If strZBBS_Old <> "" Then
                    If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZBBS_Old, objDataSet_Des, objDataSet_Old) = False Then
                        GoTo errProc
                    End If
                End If

                '新[组别标识]
                strZBBS = objPulicParameters.getNewGuid()

                '加入objDataSet_Old到objDataSet_Des
                If Not (objDataSet_Old Is Nothing) Then
                    If Not (objDataSet_Old.Tables(strTable) Is Nothing) Then
                        With objDataSet_Old.Tables(strTable)
                            intCols = .Columns.Count
                            intRows = .Rows.Count
                            For i = 0 To intRows - 1 Step 1
                                '新[组合标识]
                                strZHBS = objPulicParameters.getNewGuid()
                                '加入数据
                                With objDataSet_Des.Tables(strTable)
                                    objDataRow = .NewRow
                                End With
                                For j = 0 To intCols - 1 Step 1
                                    objDataRow.Item(j) = .Rows(i).Item(j)
                                Next
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS
                                With objDataSet_Des.Tables(strTable)
                                    .Rows.Add(objDataRow)
                                End With
                            Next
                        End With
                    End If
                End If

                '加入objDataSet_Src到objDataSet_Des
                Dim blnExisted As Boolean = False
                Dim strFilterOld As String = ""
                Dim strFilter As String = ""
                Dim strSSDW As String = ""
                Dim intTDBH As Integer = 0
                With objDataSet_Src.Tables(strTable)
                    intCols = .Columns.Count
                    intRows = .Rows.Count
                    For i = 0 To intRows - 1 Step 1
                        '新[组合标识]
                        strZHBS = objPulicParameters.getNewGuid()
                        '计算新选数据
                        strSSDW = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW), "")
                        intTDBH = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), 0)
                        '检查是否存在？
                        blnExisted = False
                        With objDataSet_Des.Tables(strTable)
                            strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS + " = '" + strZBBS + "'"
                            strFilter = strFilter + " and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW + " = '" + strSSDW + "'"
                            strFilter = strFilter + " and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH + " = " + intTDBH.ToString + ""
                            strFilterOld = .DefaultView.RowFilter
                            .DefaultView.RowFilter = strFilter
                            If .DefaultView.Count > 0 Then
                                blnExisted = True
                            End If
                            .DefaultView.RowFilter = strFilterOld
                        End With
                        '不存在，则加入！
                        If blnExisted = False Then
                            With objDataSet_Des.Tables(strTable)
                                objDataRow = .NewRow
                            End With
                            For j = 0 To intCols - 1 Step 1
                                objDataRow.Item(j) = .Rows(i).Item(j)
                            Next
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS
                            With objDataSet_Des.Tables(strTable)
                                .Rows.Add(objDataRow)
                            End With
                        End If
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)

            doAddInBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 将lstTDZH中选定的团队从strZBBS对应的数据中删除，
        ' 返回删除后的数据集objDataSet_Des及新团队组别
        '     strErrMsg      ：返回错误信息
        '     lstTDZH        ：要加入的数据
        '     strZBBS_Old    ：原组别标识
        '     objDataSet_Des ：加入到的数据
        '     strZBBS        ：新组别标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2010-03-18 创建
        '----------------------------------------------------------------
        Private Function doDelInBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal lstTDZH As System.Web.UI.WebControls.ListBox, _
            ByVal strZBBS_Old As String, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef strZBBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataSet_Old As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim i, j, intRows, intCols As Integer
            Dim strZHBS As String = ""

            doDelInBuffer_TDZH = False
            strErrMsg = ""
            strZBBS = ""

            Try
                '检查
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If lstTDZH Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '计算strZBBS_Old对应的团队数据[objDataSet_Old]
                If strZBBS_Old <> "" Then
                    If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZBBS_Old, objDataSet_Des, objDataSet_Old) = False Then
                        GoTo errProc
                    End If
                End If
                If objDataSet_Old Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Old.Tables(strTable) Is Nothing Then
                    Exit Try
                End If

                '从objDataSet_Old中删除lstTDZH选定的团队
                Dim intCount As Integer = 0
                intCount = lstTDZH.Items.Count
                For i = 0 To intCount - 1 Step 1
                    If lstTDZH.Items(i).Selected = True Then
                        strZHBS = lstTDZH.Items(i).Value
                        With objDataSet_Old.Tables(strTable)
                            .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS + " = '" + strZHBS + "'"
                            objDataRow = Nothing
                            If .DefaultView.Count > 0 Then
                                objDataRow = .DefaultView.Item(0).Row
                            End If
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                            .DefaultView.RowFilter = ""
                        End With
                    End If
                Next

                '新[组别标识]
                strZBBS = objPulicParameters.getNewGuid()

                '加入objDataSet_Old到objDataSet_Des
                If Not (objDataSet_Old Is Nothing) Then
                    If Not (objDataSet_Old.Tables(strTable) Is Nothing) Then
                        With objDataSet_Old.Tables(strTable)
                            intCols = .Columns.Count
                            intRows = .Rows.Count
                            For i = 0 To intRows - 1 Step 1
                                '新[组合标识]
                                strZHBS = objPulicParameters.getNewGuid()
                                '加入数据
                                With objDataSet_Des.Tables(strTable)
                                    objDataRow = .NewRow
                                End With
                                For j = 0 To intCols - 1 Step 1
                                    objDataRow.Item(j) = .Rows(i).Item(j)
                                Next
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS
                                With objDataSet_Des.Tables(strTable)
                                    .Rows.Add(objDataRow)
                                End With
                            Next
                        End With
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)

            doDelInBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)
            Exit Function

        End Function

        '        Public Sub txtSSDW_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSSDW.PreRender
        '            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
        '            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
        '            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
        '            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
        '            Dim strErrMsg As String = ""
        '            Dim intStep As Integer = 0
        '            Dim strNum As String = ""
        '            Dim strBirthday As String = ""
        '            Dim strSJLD As String = ""


        '            Try
        '                If m_blnSJJL = True Then
        '                    strBirthday = objPulicParameters.getObjectValue(Me.ddlZJDM.SelectedValue, "")
        '                    If Me.txtRYDM.Text.Trim() <> "" And Me.htxtSSDW.Value.Trim() <> "" And strBirthday <> "" And Me.txtTDBH.Text.Trim() <> "" Then
        '                        If objsystemEstateRenshiXingye.getSJLD(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtRYDM.Text.Trim(), Me.htxtSSDW.Value.Trim(), strBirthday, Me.txtTDBH.Text.Trim(), strSJLD) = False Then
        '                            GoTo errProc
        '                        End If
        '                        Me.txtSJLDMC.Text = strSJLD
        '                    End If
        '                End If

        '                m_blnSJJL = True
        '            Catch ex As Exception
        '                strErrMsg = ex.Message
        '                GoTo errProc
        '            End Try

        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '            Exit Sub
        'errProc:
        '            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '            Exit Sub
        '        End Sub

        '        Public Sub txtTDBH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTDBH.PreRender
        '            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
        '            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
        '            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
        '            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
        '            Dim strErrMsg As String = ""
        '            Dim intStep As Integer = 0
        '            Dim strNum As String = ""
        '            Dim strBirthday As String = ""
        '            Dim strSJLD As String = ""
        '            Dim intYear As Integer
        '            Dim intMonth As Integer

        '            Try
        '                If m_blnSJJL = True Then
        '                    strBirthday = objPulicParameters.getObjectValue(Me.ddlZJDM.SelectedValue, "")
        '                    If Me.txtRYDM.Text.Trim() <> "" And Me.htxtSSDW.Value.Trim() <> "" And strBirthday <> "" And Me.txtTDBH.Text.Trim() <> "" Then
        '                        If objsystemEstateRenshiXingye.getSJLD(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtRYDM.Text.Trim(), Me.htxtSSDW.Value.Trim(), strBirthday, Me.txtTDBH.Text.Trim(), strSJLD) = False Then
        '                            GoTo errProc
        '                        End If
        '                        Me.txtSJLDMC.Text = strSJLD
        '                    End If
        '                End If

        '                m_blnSJJL = True
        '            Catch ex As Exception
        '                strErrMsg = ex.Message
        '                GoTo errProc
        '            End Try

        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '            Exit Sub
        'errProc:
        '            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '            Exit Sub
        '        End Sub




        '        '        Public Sub txtSSDW_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSSDW.TextChanged
        '        '            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
        '        '            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
        '        '            Dim objsystemEstateRenshiXingye As Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
        '        '            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
        '        '            Dim strErrMsg As String = ""
        '        '            Dim intStep As Integer = 0
        '        '            Dim strNum As String = ""
        '        '            Dim strBirthday As String = ""
        '        '            Dim strSJLD As String
        '        '            Dim intYear As Integer
        '        '            Dim intMonth As Integer

        '        '            Try
        '        '                If Me.txtRYDM.Text.Trim() <> "" And Me.htxtSSDW.Value.Trim() <> "" And Me.ddlZJDM.SelectedValue <> "" And Me.txtTDBH.Text.Trim() <> "" Then
        '        '                    If objsystemEstateRenshiXingye.getSJLD(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtRYDM.Text.Trim(), Me.htxtSSDW.Value.Trim(), Me.ddlZJDM.SelectedValue, Me.txtTDBH.Text.Trim(), strSJLD) = False Then
        '        '                        GoTo errProc
        '        '                    End If
        '        '                    Me.txtSJLDMC.Text = strSJLD
        '        '                End If
        '        '            Catch ex As Exception
        '        '                strErrMsg = ex.Message
        '        '                GoTo errProc
        '        '            End Try

        '        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '        '            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        '        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '        '            Exit Sub
        '        'errProc:
        '        '            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
        '        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '        '            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        '        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '        '            Exit Sub
        '        '        End Sub

        '        Public Sub txtTDBH_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTDBH.TextChanged
        '            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
        '            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
        '            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
        '            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
        '            Dim strErrMsg As String = ""
        '            Dim intStep As Integer = 0
        '            Dim strNum As String = ""
        '            Dim strBirthday As String = ""
        '            Dim strSJLD As String = ""
        '            Dim intYear As Integer
        '            Dim intMonth As Integer

        '            Try

        '                strBirthday = objPulicParameters.getObjectValue(Me.ddlZJDM.SelectedValue, "")
        '                If Me.txtRYDM.Text.Trim() <> "" And Me.htxtSSDW.Value.Trim() <> "" And strBirthday <> "" And Me.txtTDBH.Text.Trim() <> "" Then
        '                    If objsystemEstateRenshiXingye.getSJLD(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtRYDM.Text.Trim(), Me.htxtSSDW.Value.Trim(), strBirthday, Me.txtTDBH.Text.Trim(), strSJLD) = False Then
        '                        GoTo errProc
        '                    End If
        '                    Me.txtSJLDMC.Text = strSJLD
        '                End If
        '            Catch ex As Exception
        '                strErrMsg = ex.Message
        '                GoTo errProc
        '            End Try

        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '            Exit Sub
        'errProc:
        '            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '            Exit Sub
        '        End Sub

       
        Private Sub grdRYXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRYXX.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try

                '同步显示编辑窗信息
                If Me.showEditRuInfo(strErrMsg, False) = False Then
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim strSPR As String

            showEditRuInfo = False

            Try
                '查看状态
                If Me.grdRYXX.Items.Count < 1 Then

                ElseIf Me.grdRYXX.SelectedIndex < 0 Then
                 
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
                    Dim blnOption As Boolean = False
                    Dim strZGTD As String
                    Dim strXGTD As String
                    Dim strSXRQ As String

                    Dim objDataRow As System.Data.DataRow = Nothing
                    With Me.m_objDataSet_RYXX.Tables(strTable).DefaultView
                        strYDYY = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYDM), "")
                        Me.ddlYDYY.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYDYY, strYDYY)
                        Me.txtRYDM.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYDM), "")
                        Me.txtRYXM.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYXM), "")
                        Me.txtYRYZT.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YRYZTMC), "")
                        Me.htxtYRYZTDM.Value = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YRYZT), "")

                        Me.htxtYZJDM.Value = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZJDM), "")
                        Me.txtYZJMC.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZJMC), "")
                        Me.htxtYBMDM.Value = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YDWDM), "")
                        Me.txtYBMMC.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YDWMC), "")
                        Me.txtYTD.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YTDBH), "")
                        Me.txtYZBQK.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZB), "")

                        strZJDM = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZJDM), "")
                        Me.ddlZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZJDM, strZJDM)
                        Me.htxtSSDW.Value = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWDM), "")
                        Me.txtSSDW.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWMC), "")
                        Me.txtTDBH.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_TDBH), "")
                        strRYZT = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYZT), "")
                        Me.rblRYZT.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYZT, strRYZT)

                        strSXRQ = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SXRQ), "")
                        'Me.rblSXRQ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSXRQ, strSXRQ)
                        Me.txtRQ.Text = strSXRQ
                        Me.txtNBDRQ.Text = strSXRQ


                        Me.txtSJLD.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SJLD), "")
                        Me.txtSJLDMC.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SJLDMC), "")
                        Me.txtYSJLDMC.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YSJLDMC), "")
                        strSFZB = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFZB), "")
                        Me.rblSFZB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZB, strSFZB)

                        Me.txtSFJZ.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFJZ), "")
                        Me.txtRTLX.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYLX), "")
                        Me.txtRTLXMC.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYLXMC), "")
                        Me.txtBZXL.Text = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_BZXL), "")

                        '团队操作
                        Me.htxtZGTD.Value = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGTD), "")
                        Me.htxtXGTD.Value = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XGTD), "")
                        Me.htxtYZGTD.Value = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZGTD), "")
                        Me.htxtYXGTD.Value = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YXGTD), "")

                        strZGTD = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGTDMC), "")
                        strXGTD = objPulicParameters.getObjectValue(.Item(intPos).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XGTDMC), "")


                        Me.doDisplayBuffer_TDZH(strErrMsg, strZGTD, Me.htxtZGTD.Value, Me.lstZGTD)
                        Me.doDisplayBuffer_TDZH(strErrMsg, strXGTD, Me.htxtXGTD.Value, Me.lstXGTD)
                       

                        If Me.getModuleData_YTDZH(strErrMsg) = True Then
                            If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtYZGTD.Value, Me.m_objDataSet_YTDZH, objTempDataSet) = True Then
                                Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtYZGTD.Value, objTempDataSet, Me.lstYZGTD)
                            End If
                            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)

                            If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtYXGTD.Value, Me.m_objDataSet_YTDZH, objTempDataSet) = True Then
                                Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtYXGTD.Value, objTempDataSet, Me.lstYXGTD)
                            End If
                            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                        End If

                    End With
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
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)

            showEditRuInfo = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)

            Exit Function

        End Function

    End Class

End Namespace
