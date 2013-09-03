﻿Imports System.Web.Security

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
    Partial Public Class kqgl_qjd_info
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
        Private m_objsystemFlowObjectKqglQJD As Josco.JSOA.BusinessFacade.systemFlowObjectKqglQJD
        Private m_objDataSet_FJ As Josco.JSOA.Common.Data.FlowData
        Private m_strSessionID_FJ As String
        Private m_objDataSet_XGWJ As Josco.JSOA.Common.Data.FlowData
        Private m_strSessionID_XGWJ As String
        Private m_objDataSet_RYXX As Josco.JSOA.Common.Data.kaoqinguanliData
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
                    Me.txtZW.Text = .txtJLBH
                    Me.htxtRYDM.Value = .txtRYDM
                    Me.txtRYXM.Text = .txtRYXM
                    Me.txtYY.Text = .txtRYNN
                    Me.txtDD.Text = .txtNFPBM
                    'Me.txtNDRZW.Text = .txtNDRZW


                    Me.txtLXDH.Text = .txtLXDH
                    Me.htxtBZXL.Value = .htxtBZXL
                    Me.htxtSSDW.Value = .htxtSSDW

                    'Me.txtSQRQ.Text = .txtNBDRQ
                    Me.txtStartSQRQ.Text = .txtZPSM
                    Me.txtEndSQRQ.Text = .txtXYRYS
                    'Me.txtDBRYS.Text = .txtDBRYS
                    Me.ddlJQ.SelectedIndex = .ddlXL_SelectedIndex
                  
                    Me.txtTS.Text = .txtSFZHM
                    Me.txtJQTS.Text = .txtBMJL
                    Me.txtWTGZ.Text = .txtSPSM

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
                    Me.m_objDataSet_RYXX = .objDataSet_KQXX
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
                    .txtJLBH = Me.txtZW.Text
                    .txtRYDM = htxtRYDM.Value
                    .txtRYXM = Me.txtRYXM.Text
                    .txtRYNN = Me.txtYY.Text
                    .txtNFPBM = Me.txtDD.Text
                    '.txtNDRZW = Me.txtNDRZW.Text
                    '.txtNBDRQ = Me.txtSQRQ.Text
                    .txtZPSM = Me.txtStartSQRQ.Text
                    .txtXYRYS = Me.txtEndSQRQ.Text
                    '.txtDBRYS = Me.txtDBRYS.Text
                    .ddlXL_SelectedIndex = Me.ddlJQ.SelectedIndex
                    .txtLXDH = Me.txtLXDH.Text
                    .htxtBZXL = Me.htxtBZXL.Value
                    .htxtSSDW = Me.htxtSSDW.Value

                    .txtSFZHM = Me.txtTS.Text
                    .txtBMJL = Me.txtJQTS.Text
                    .txtSPSM = Me.txtWTGZ.Text

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
                    .objDataSet_KQXX = Me.m_objDataSet_RYXX
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
            Dim objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
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
                             
                            Case Else

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
                                Me.txtSSDW.Text = objIDmxzZzjg.oBumenList

                                Dim strZZDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtSSDW.Text, strZZDM) = True Then

                                    If strZZDM <> "" Then
                                        Me.htxtSSDW.Value = strZZDM

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
                    Dim strRYDM As String = ""
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

                                    Me.txtRYXM.Text = strRYMC
                                    Me.txtSSDW.Text = strBMMC
                                    If objsystemCustomer.getRydmByRymc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYMC, strRYDM) = True Then
                                        If strRYDM <> "" Then
                                            Me.htxtRYDM.Value = strRYDM
                                        End If
                                    End If
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
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objkaoqinguanliData)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objkaoqinguanliData)
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

                Dim objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData
                If Me.m_strSessionID_RYXX <> "" Then
                    Try
                        objkaoqinguanliData = CType(Session.Item(Me.m_strSessionID_RYXX), Josco.JSOA.Common.Data.kaoqinguanliData)
                    Catch ex As Exception
                        objkaoqinguanliData = Nothing
                    End Try
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objkaoqinguanliData)
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
                Dim strType As String = Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.FLOWCODE
                Dim strName As String = Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.FLOWNAME
                Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                Me.m_objsystemFlowObjectKqglQJD = CType(objsystemFlowObject, Josco.JSOA.BusinessFacade.systemFlowObjectKqglQJD)

                '工作流对象初始化并填充数据
                If Me.m_objsystemFlowObjectKqglQJD.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, True) = False Then
                    GoTo errProc
                End If

                '计算可执行的操作
                If Me.m_objsystemFlowObjectKqglQJD.getCanExecuteCommand(strErrMsg, MyBase.UserId, MyBase.UserXM, MyBase.UserBmdm) = False Then
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
                    If Me.m_objsystemFlowObjectKqglQJD.getFujianData(strErrMsg, Me.m_objDataSet_FJ) = False Then
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
                    If Me.m_objsystemFlowObjectKqglQJD.getXgwjData(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
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

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIASHENQINGDAN_JIAQI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_RYXX = False

            Try
                '是编辑模式时首次进入：以现场复原信息为准(暗含首次进入条件)
                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    Exit Try
                End If

                '如果是编辑模式：则从缓存中获取数据
                If Me.m_strSessionID_RYXX <> "" And Me.m_blnEditMode = True Then
                    Me.m_objDataSet_RYXX = CType(Session.Item(Me.m_strSessionID_RYXX), Josco.JSOA.Common.Data.kaoqinguanliData)
                Else
                    '备份Sort字符串
                    Dim strSort As String = ""
                    strSort = Me.htxtRYXXSort.Value
                    If strSort.Length > 0 Then strSort = strSort.Trim

                    '释放资源
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(Me.m_objDataSet_RYXX)

                    '重新检索数据
                    Dim blnSFJB As Boolean = False
                    Select Case Me.m_objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            If Me.m_objsystemFlowObjectKqglQJD.getDataSet_JQXX(strErrMsg, Me.m_objDataSet_RYXX, blnSFJB) = False Then
                                GoTo errProc
                            End If
                        Case Else
                            If Me.txtJBRY.Text.Trim = MyBase.UserXM Then
                                If Me.m_objsystemFlowObjectKqglQJD.getDataSet_JQXX(strErrMsg, Me.m_objDataSet_RYXX, blnSFJB) = False Then
                                    GoTo errProc
                                End If
                            Else
                                If Me.m_objsystemFlowObjectKqglQJD.getDataSet_JQXX(strErrMsg, Me.m_objDataSet_RYXX) = False Then
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
                        Dim objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData
                        objkaoqinguanliData = CType(Session.Item(Me.m_strSessionID_RYXX), Josco.JSOA.Common.Data.kaoqinguanliData)
                        Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objkaoqinguanliData)
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

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIASHENQINGDAN_JIAQI
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
            Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            showEditPanelInfo = False

            Try
                objBaseFlowKqglQJD = CType(Me.m_objsystemFlowObjectKqglQJD.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)

                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    '是编辑模式时首次进入：以现场复原信息为准(暗含首次进入条件)
                Else
                    If Me.IsPostBack = False Or (Me.IsPostBack = True And Me.m_blnEditMode = False) Then
                        '首次进入或查看状态下的回发，需要重新显示数据
                        Me.ddlJJCD.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJJCD, objBaseFlowKqglQJD.JJCD)
                        Me.ddlMMDJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlMMDJ, objBaseFlowKqglQJD.MMDJ)
                        Me.txtJGDZ.Text = objBaseFlowKqglQJD.JGDZ
                        Me.txtWJNF.Text = objBaseFlowKqglQJD.WJNF
                        Me.txtWJXH.Text = objBaseFlowKqglQJD.WJXH
                        Me.txtWJBT.Text = objBaseFlowKqglQJD.WJBT
                        'Me.txtDBRS.Text = objBaseFlowKqglQJD.DBRS.ToString
                        Me.txtBZXX.Text = objBaseFlowKqglQJD.BEIZ
                        If objBaseFlowKqglQJD.DDSZ = 1 Then
                            Me.chkDDSZ.Checked = True
                        Else
                            Me.chkDDSZ.Checked = False
                        End If
                        Me.txtJBDW.Text = objBaseFlowKqglQJD.ZBDW
                        Me.txtJBRY.Text = objBaseFlowKqglQJD.NGR
                        Me.txtJBRQ.Text = objPulicParameters.doDateToString(objBaseFlowKqglQJD.NGRQ, "yyyy-MM-dd")
                        Me.txtBZXX.Text = objBaseFlowKqglQJD.BEIZ
                        Me.txtLSH.Text = objBaseFlowKqglQJD.LSH
                        Me.htxtWJBS.Value = objBaseFlowKqglQJD.WJBS
                        Me.txtRYXM.Text = objBaseFlowKqglQJD.SQR
                        Me.htxtRYDM.Value = objBaseFlowKqglQJD.SQRDM
                        Me.txtSSDW.Text = objBaseFlowKqglQJD.ZZMC
                        Me.htxtSSDW.Value = objBaseFlowKqglQJD.ZZdm
                        Me.txtZW.Text = objBaseFlowKqglQJD.ZW
                        Me.txtYY.Text = objBaseFlowKqglQJD.YY
                        Me.txtDD.Text = objBaseFlowKqglQJD.DD
                        Me.txtLXDH.Text = objBaseFlowKqglQJD.LXDH
                        Me.txtStartSQRQ.Text = objPulicParameters.doDateToString(objBaseFlowKqglQJD.KSRQ, "yyyy-MM-dd")
                        Me.txtEndSQRQ.Text = objPulicParameters.doDateToString(objBaseFlowKqglQJD.JSRQ, "yyyy-MM-dd")
                        Me.txtTS.Text = CType(objBaseFlowKqglQJD.TS, String)
                        Me.txtWTGZ.Text = objBaseFlowKqglQJD.WTGZ

                        Dim intTemp_start As Integer
                        Dim intTemp_end As Integer
                        Dim strTemp As String = objBaseFlowKqglQJD.WJBT
                        Dim lendf As Integer

                        intTemp_start = InStr(1, objBaseFlowKqglQJD.WJBT, "(")
                        intTemp_end = InStr(1, objBaseFlowKqglQJD.WJBT, ")")

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
                                If Me.m_objsystemFlowObjectKqglQJD.getNewWjxh(strErrMsg, Me.txtJGDZ.Text, Me.txtWJNF.Text, strWJXH) = False Then
                                Else
                                    Me.txtWJXH.Text = strWJXH
                                End If
                                Me.txtJBDW.Text = MyBase.UserBmmc
                                Me.txtJBRY.Text = MyBase.UserXM
                                Me.txtJBRQ.Text = Now.ToString("yyyy-MM-dd")
                                Dim strLSH As String = ""
                                If Me.m_objsystemFlowObjectKqglQJD.getNewLSH(strErrMsg, strLSH) = False Then
                                    Me.txtLSH.Text = ""
                                Else
                                    Me.txtLSH.Text = strLSH
                                End If

                                strLSH = Right(strLSH, 2)
                                Me.txtWJBT.Text = Now.ToString("yyyyMMdd") & strLSH & MyBase.UserBmmc & "入职申请单"

                                strLSH = ""
                                If Me.m_objsystemFlowObjectKqglQJD.getNewWJBS(strErrMsg, strLSH) = False Then
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
                'Me.lblQFR.Text = objBaseFlowKqglQJD.QFR

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
                    .doEnabledControl(Me.txtRYXM, blnEditMode)
                    .doEnabledControl(Me.txtSSDW, blnEditMode)
                    .doEnabledControl(Me.txtZW, blnEditMode)
                    .doEnabledControl(Me.txtYY, blnEditMode)
                    .doEnabledControl(Me.txtDD, blnEditMode)
                    .doEnabledControl(Me.txtLXDH, blnEditMode)
                    .doEnabledControl(Me.txtStartSQRQ, blnEditMode)
                    .doEnabledControl(Me.txtEndSQRQ, blnEditMode)
                    .doEnabledControl(Me.txtTS, blnEditMode)

                    .doEnabledControl(Me.txtWTGZ, blnEditMode)
                    .doEnabledControl(Me.ddlJQ, blnEditMode)
                    .doEnabledControl(Me.txtJQTS, blnEditMode)
                End With
               
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
                Me.lnkCZQSYJ_FGLD.Enabled = blnEnabled
                Me.lnkCZQSYJ_ZJL.Enabled = blnEnabled
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

            Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
            Dim blnEditMode As Boolean = False

            showModuleData_ReadMode = False

            Try
                '人员信息窗内容

                '工作流初始化
                objBaseFlowKqglQJD = CType(Me.m_objsystemFlowObjectKqglQJD.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)

                '使能命令
                doEnabledFileCommands(False)

                '逐个设置
                'Me.lnkCZCYGJ.Enabled = Not blnEditMode
                'Me.lnkCZCYGJ.Text = "查阅稿件"
                'Me.lnkCZCYFJ.Enabled = Not blnEditMode
                'Me.lnkCZCYFJ.Text = "查阅附件"
                'Me.lnkCZCYXGWJ.Enabled = Not blnEditMode
                'Me.lnkCZCYXGWJ.Text = "查阅相关文件"
                'Me.lnkCZCYQPWJ.Enabled = Not blnEditMode And (objBaseFlowKqglQJD.HJWJ <> "")
                'Me.lnkCZCYZSWJ.Enabled = Not blnEditMode And (objBaseFlowKqglQJD.PJYJ <> "")

                '
                '不受文件影响的命令
                '
                '刷新文件
                Me.mnuMain.FindItemById("mnuFILE_SXWJ").Enabled = Not blnEditMode
                '返回上级
                Me.mnuMain.FindItemById("mnuFHSJ").Enabled = Not blnEditMode
                Me.btnSelect_ZZDM.Visible = blnEditMode
                Me.btnFPBM.Visible = blnEditMode

                '
                '必须先接收？
                '
                If Me.m_objsystemFlowObjectKqglQJD.pmMustJieshou = True Then
                    '接收文件
                    Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Enabled = Not blnEditMode
                    Exit Try
                End If

                '
                '正常操作
                '
                With Me.m_objsystemFlowObjectKqglQJD
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
                    Me.mnuMain.FindItemById("mnuQTCL_WJBJ").Enabled = .mlWJBJ
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
                    Me.lnkCZQSYJ_FGLD.Enabled = .pmQSYJ_FGLD
                    Me.lnkCZQSYJ_ZJL.Enabled = .pmQSYJ_ZJL
                    Me.m_blnSPMode = .pmQSYJ_SH
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

            Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
            Dim blnEditMode As Boolean = True

            showModuleData_EditMode = False

            Try
                '工作流初始化
                objBaseFlowKqglQJD = CType(Me.m_objsystemFlowObjectKqglQJD.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)

                '使能命令
                doEnabledFileCommands(False)

                ''逐个设置
                'Me.lnkCZCYGJ.Enabled = blnEditMode
                'Me.lnkCZCYGJ.Text = "编辑稿件"
                'Me.lnkCZCYFJ.Enabled = blnEditMode
                'Me.lnkCZCYFJ.Text = "编辑附件"
                'Me.lnkCZCYXGWJ.Enabled = blnEditMode
                'Me.lnkCZCYXGWJ.Text = "编辑相关文件"
                'Me.lnkCZCYQPWJ.Enabled = blnEditMode And (objBaseFlowKqglQJD.HJWJ <> "")
                'Me.lnkCZCYZSWJ.Enabled = blnEditMode And (objBaseFlowKqglQJD.PJYJ <> "")

                '文件操作
                Me.mnuMain.FindItemById("mnuFILE_BCWJ").Enabled = blnEditMode
                Me.mnuMain.FindItemById("mnuFILE_QXXG").Enabled = blnEditMode
                Me.btnSelect_ZZDM.Visible = blnEditMode
                Me.btnFPBM.Visible = blnEditMode

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
            Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
            Dim objOpinionData As Josco.JSOA.Common.Data.FlowData
            Dim strQSYJ As String = ""
            Dim strBJYJ As String = ""
            Dim strYJLX As String = ""

            showOpinion = False

            Try
                objBaseFlowKqglQJD = CType(Me.m_objsystemFlowObjectKqglQJD.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)

                '获取可查看的意见
                If Me.m_objsystemFlowObjectKqglQJD.getOpinionData(strErrMsg, MyBase.UserXM, objOpinionData) = False Then
                    GoTo errProc
                End If


                '显示售楼部/分行经理意见
                strYJLX = objBaseFlowKqglQJD.TASK_FHWJ
                If Me.m_objsystemFlowObjectKqglQJD.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblFHYJ.Text = strQSYJ
                Me.lnkCZQSYJ_FHBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '显示项目经理/区域经理/总监意见
                strYJLX = objBaseFlowKqglQJD.TASK_QFWJ
                If Me.m_objsystemFlowObjectKqglQJD.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblQFYJ.Text = strQSYJ
                Me.lnkCZQSYJ_QFBJ.Visible = Not blnEditMode And (strBJYJ <> "")


                '显示部门经理意见
                strYJLX = objBaseFlowKqglQJD.TASK_SHWJ
                If Me.m_objsystemFlowObjectKqglQJD.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblSHYJ.Text = strQSYJ
                Me.lnkCZQSYJ_SHBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '显示办公室意见
                strYJLX = objBaseFlowKqglQJD.TASK_HQWJ
                If Me.m_objsystemFlowObjectKqglQJD.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblHQYJ.Text = strQSYJ
                Me.lnkCZQSYJ_HQBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '显示分管领导意见
                strYJLX = objBaseFlowKqglQJD.TASK_FGLD
                If Me.m_objsystemFlowObjectKqglQJD.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblFGLDYJ.Text = strQSYJ
                Me.lnkCZQSYJ_FGLDBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '显示总经理审批
                strYJLX = objBaseFlowKqglQJD.TASK_ZJL
                If Me.m_objsystemFlowObjectKqglQJD.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblZJLYJ.Text = strQSYJ
                Me.lnkCZQSYJ_ZJLBJ.Visible = Not blnEditMode And (strBJYJ <> "")

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

                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBS, Me.htxtWJBS.Value)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_LSH, Me.txtLSH.Text)

                If Me.chkDDSZ.Checked = True Then
                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DDSZ, "1")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DDSZ, "0")
                End If

                If Me.ddlJJCD.SelectedIndex < 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JJCD, "")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JJCD, Me.ddlJJCD.SelectedItem.Text)
                End If

                If Me.ddlMMDJ.SelectedIndex < 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_MMDJ, "")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_MMDJ, Me.ddlMMDJ.SelectedItem.Text)
                End If

                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JGDZ, Me.txtJGDZ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJNF, Me.txtWJNF.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJXH, Me.txtWJXH.Text)

                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBRY, Me.txtJBRY.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBRQ, Me.txtJBRQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBDW, Me.txtJBDW.Text)

                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBT, Me.txtWJBT.Text)

                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_SQR, Me.txtRYXM.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_SQRDM, Me.htxtRYDM.Value)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_ZZMC, Me.txtSSDW.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_ZZDM, Me.htxtSSDW.Value)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_ZW, Me.txtZW.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_YY, Me.txtYY.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DD, Me.txtDD.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_KSRQ, Me.txtStartSQRQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JSRQ, Me.txtEndSQRQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_TS, Me.txtTS.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WTGZ, Me.txtWTGZ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_LXDH, Me.txtLXDH.Text)
                objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_BZXX, Me.txtBZXX.Text)
               
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
                Me.htxtWJBS.Value = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBS), "")
                Me.txtLSH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_LSH), "")
                If objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DDSZ), 0) = 1 Then
                    Me.chkDDSZ.Checked = True
                Else
                    Me.chkDDSZ.Checked = False
                End If

                Me.ddlJJCD.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJJCD, objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JJCD), ""))
                Me.ddlMMDJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlMMDJ, objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_MMDJ), ""))

                Me.txtJGDZ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JGDZ), "")
                Me.txtWJNF.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJNF), "")
                Me.txtWJXH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJXH), "")

                Me.txtJBRY.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBRY), "")
                Me.txtJBRQ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBRQ), "")
                Me.txtJBDW.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBDW), "")

                Me.txtWJBT.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBT), "")
                'Me.txtDBRS.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DBRS), "")
                Me.txtRYXM.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_SQR), "")
                Me.htxtRYDM.Value = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_SQRDM), "")
                Me.txtSSDW.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_ZZMC), "")
                Me.htxtSSDW.Value = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_ZZDM), "")
                Me.txtZW.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_ZW), "")
                Me.txtYY.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_YY), "")
                Me.txtDD.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DD), "")
                Me.txtStartSQRQ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_KSRQ), "")
                Me.txtEndSQRQ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JSRQ), "")
                Me.txtTS.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_TS), "")
                Me.txtWTGZ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WTGZ), "")
                Me.txtLXDH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_LXDH), "")
                Me.txtBZXX.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_BZXX), "")

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
            If Me.m_objsystemFlowObjectKqglQJD.doDeleteCacheFile_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
                '可以不成功，形成垃圾文件！
            End If
            If Me.m_objsystemFlowObjectKqglQJD.doDeleteCacheFile_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
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
                Dim strWJBS As String = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS

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

                      
                        .doTranslateKey(Me.txtRYXM)
                        .doTranslateKey(Me.txtSSDW)
                        .doTranslateKey(Me.txtZW)
                        .doTranslateKey(Me.txtYY)
                        .doTranslateKey(Me.txtDD)
                        .doTranslateKey(Me.txtStartSQRQ)
                        .doTranslateKey(Me.txtEndSQRQ)
                        .doTranslateKey(Me.txtTS)
                        .doTranslateKey(Me.txtWTGZ)

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

        

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim strUrl As String

            Try
                '预处理
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If


                If Me.IsPostBack = False Then
                    If Me.doFillKQLXList(strErrMsg, Me.ddlJQ) = False Then
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
                            If Me.m_objsystemFlowObjectKqglQJD.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                                GoTo errProc
                            End If
                        End If
                        If Me.m_objsystemFlowObjectKqglQJD.mlJSWJ = True Then
                            '自动接收文件
                            Me.htxtSelectMenuID.Value = "mnuJJCL_JSWJ"
                            If Me.doReceiveFile(strErrMsg, "lnkMenu") = False Then
                                GoTo errProc
                            End If
                        End If
                    End If
                End If

                Me.grdRYXX.ShowHeader = False
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
            Josco.JSOA.BusinessFacade.systemFlowObjectKqglQJD.SafeRelease(Me.m_objsystemFlowObjectKqglQJD)
        End Sub

        '----------------------------------------------------------------
        ' 填充“考勤类型”下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillKQLXList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_B_KQ_KAOQINLEXING
            Dim objsystemKaoqinguanli As New Josco.JSOA.BusinessFacade.systemKaoqinguanli
            Dim objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillKQLXList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillMMDJList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemKaoqinguanli.getKaoqingleixingData(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objkaoqinguanliData) = False Then
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
                With objkaoqinguanliData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_DM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_MC), "")
                        If strName = "" Then
                            strName = "外出"
                        End If
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

            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objkaoqinguanliData)

            doFillKQLXList = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objkaoqinguanliData)
            Exit Function

        End Function









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
                            If Me.m_objsystemFlowObjectKqglQJD.getCanAutoEnterEditMode( _
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
                            If Me.m_objsystemFlowObjectKqglQJD.getCanAutoEnterEditMode( _
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
                Dim strWJBS As String = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
                Josco.JSOA.BusinessFacade.systemFlowObjectKqglQJD.SafeRelease(Me.m_objsystemFlowObjectKqglQJD)

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
                If Me.m_objsystemFlowObjectKqglQJD.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                    .iTrackRevisions = Me.m_objsystemFlowObjectKqglQJD.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                            If Me.m_objsystemFlowObjectKqglQJD.doLockFile(strErrMsg, "", False) = False Then
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
                    Dim strWJBS As String = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
                    If strWJBS = "" Then
                        strErrMsg = "错误：没有文件进行编辑！"
                        GoTo errProc
                    End If

                    '自动清除自己对该文件的编辑封锁
                    If Me.m_objsystemFlowObjectKqglQJD.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                        GoTo errProc
                    End If

                    '封锁检查
                    Dim strBMMC As String
                    Dim strRYMC As String
                    Dim blnDo As Boolean
                    If Me.m_objsystemFlowObjectKqglQJD.getFileLocked(strErrMsg, blnDo, strBMMC, strRYMC) = False Then
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
                        If Me.m_objsystemFlowObjectKqglQJD.doLockFile(strErrMsg, MyBase.UserId, True) = False Then
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
                    strErrMsg = "提示：您还没有添加任何休假信息，不能进行保存！如果想退出当前页面，请选择取消文件！"
                    GoTo errProc
                End If
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Me.txtWJBT.Text = Me.txtWJBT.Text + "(" + Me.txtRYXM.Text + ")"
                End Select

                '获取记录新值
                If Me.getCurrentRecordNew(strErrMsg, objNewData) = False Then
                    GoTo errProc
                End If

                '获取记录旧值
                objOldData = Me.m_objsystemFlowObjectKqglQJD.FlowData
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
                        If Me.m_objsystemFlowObjectKqglQJD.getFujianData(strErrMsg, objOldFJData) = False Then
                            GoTo errProc
                        End If
                        If Me.m_objsystemFlowObjectKqglQJD.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                            GoTo errProc
                        End If
                End Select

                '准备额外参数
                objParams.Clear()
                objParams.Add(0, Me.m_objDataSet_RYXX)

                '保存数据
                With Me.m_objsystemFlowObjectKqglQJD
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
                strWJBS = objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBS)

                '写审计日志
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        If Me.m_objsystemFlowObjectKqglQJD.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "创建了[" + strWJBS + "]文件！") = False Then
                            '忽略
                        End If
                    Case Else
                        If Me.m_objsystemFlowObjectKqglQJD.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "改动了[" + strWJBS + "]文件！") = False Then
                            '忽略
                        End If
                        If Me.m_objsystemFlowObjectKqglQJD.doWriteUserLog_Fujian(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_FJ, objOldFJData) = False Then
                            '忽略
                        End If
                        If Me.m_objsystemFlowObjectKqglQJD.doWriteUserLog_XGWJ(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_XGWJ, objOldXGWJData) = False Then
                            '忽略
                        End If
                End Select

                '进入查看状态

                Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS = strWJBS
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
                If Me.m_objsystemFlowObjectKqglQJD.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                        If Me.m_objsystemFlowObjectKqglQJD.getCanAutoEnterEditMode( _
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
                    .iTrackRevisions = Me.m_objsystemFlowObjectKqglQJD.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                If Me.m_objsystemFlowObjectKqglQJD.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                    .iTrackRevisions = Me.m_objsystemFlowObjectKqglQJD.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                If Me.m_objsystemFlowObjectKqglQJD.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                        If Me.m_objsystemFlowObjectKqglQJD.getCanAutoEnterEditMode( _
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
                    .iTrackRevisions = Me.m_objsystemFlowObjectKqglQJD.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                strUrl += "../flow/flow_xgwj.aspx"
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
                If Me.m_objsystemFlowObjectKqglQJD.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
                    GoTo errProc
                End If

                '获取稿件
                Dim strMBPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToWordTemplate)
                Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                Dim strCacheFile As String = Me.m_strGJFileName
                If Me.m_objsystemFlowObjectKqglQJD.getGJFile(strErrMsg, Me.m_blnEditMode, strCacheFile, strMBPath, strGJPath, strGJFile) = False Then
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
                        If Me.m_objsystemFlowObjectKqglQJD.getCanAutoEnterEditMode( _
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
                    '************************************************************************************************
                    .iGJFileSpec = strGJFile
                    .iobjDataSet_FJ = Me.m_objDataSet_FJ
                    .iobjDataSet_XGWJ = Me.m_objDataSet_XGWJ
                    .iobjNewData = Nothing
                    '************************************************************************************************
                    .iCanQSYJ = Me.m_objsystemFlowObjectKqglQJD.mlTXYJ
                    If .iCanQSYJ = False Then
                        .iCanQSYJ = Me.m_objsystemFlowObjectKqglQJD.mlBDPS
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
                    .iTrackRevisions = Me.m_objsystemFlowObjectKqglQJD.swgjShowTrackRevisions And blnHasSendOnce
                    .iCanExportGJ = Me.m_objsystemFlowObjectKqglQJD.swgjExportFile
                    .iCanImportGJ = Me.m_objsystemFlowObjectKqglQJD.swgjImportFile
                    .iCanSelectTGWJ = Me.m_objsystemFlowObjectKqglQJD.swgjSelectGJ
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
                strUrl += "../flow/flow_editword.aspx"
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                strUrl += "../flow/flow_send.aspx"
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS

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
                strUrl += "../flow/flow_receive.aspx"
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS

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
                strUrl += "../flow/flow_shouhui.aspx"
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                strUrl += "../flow/flow_tuihui.aspx"
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
                If Me.m_objsystemFlowObjectKqglQJD.doIReadFile(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectKqglQJD.doIDoNotProcess(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectKqglQJD.doICompleteTask(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectKqglQJD.doIStopFile(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectKqglQJD.doIContinueFile(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectKqglQJD.doIZuofeiFile(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectKqglQJD.doIQiyongFile(strErrMsg, MyBase.UserXM) = False Then
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
                    If Me.m_objsystemFlowObjectKqglQJD.getUncompleteTaskRY(strErrMsg, MyBase.UserXM, strUserList) = False Then
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
                    If Me.m_objsystemFlowObjectKqglQJD.doCompleteFile(strErrMsg, MyBase.UserXM) = False Then
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS

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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS

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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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

            Dim blnEnabled(6) As Boolean

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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
                    .iSPR = MyBase.UserXM
                    .iDLR = ""
                    .iInitYjlx = strYjlx
                    blnEnabled(0) = Me.lnkCZQSYJ_FH.Enabled
                    blnEnabled(1) = Me.lnkCZQSYJ_QF.Enabled
                    blnEnabled(2) = Me.lnkCZQSYJ_SH.Enabled
                    blnEnabled(3) = Me.lnkCZQSYJ_HQ.Enabled
                    blnEnabled(4) = Me.lnkCZQSYJ_FGLD.Enabled
                    blnEnabled(5) = Me.lnkCZQSYJ_ZJL.Enabled
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS
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
                '    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                '    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS

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
                '    .iFlowTypeName = Me.m_objsystemFlowObjectKqglQJD.FlowData.FlowTypeName
                '    .iWJBS = Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS

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
                    If Me.m_objsystemFlowObjectKqglQJD.doSetTaskBWTX(strErrMsg, MyBase.UserXM, True) = False Then
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
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_SH", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_SHWJ) = False Then
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

        Private Sub lnkCZQSYJ_FGLD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_FGLD.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_FGLD", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_FGLD) = False Then
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

        Private Sub lnkCZQSYJ_ZJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_ZJL.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_ZJL", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_ZJL) = False Then
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
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_HQ", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_HQWJ) = False Then
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
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_QF", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_QFWJ) = False Then
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
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_FH", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_FHWJ) = False Then
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
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_SHBJ", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_SHWJ) = False Then
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



        Private Sub lnkCZQSYJ_FGLDBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_FGLDBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_FGLDBJ", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_FGLD) = False Then
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


        Private Sub lnkCZQSYJ_ZJLBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_ZJLBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_ZJLBJ", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_ZJL) = False Then
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
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_HQBJ", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_HQWJ) = False Then
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
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_FHBJ", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_FHWJ) = False Then
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
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_QFBJ", Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_QFWJ) = False Then
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
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.m_objsystemFlowObjectKqglQJD.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                If objBaseFlowKqglQJD.HJWJ = "" Then
                    strErrMsg = "错误：还没有导入签批件的电子文件！"
                    GoTo errProc
                End If

                '签批件的电子件
                Dim strFileSpec As String = ""
                Dim strFilePath As String = ""
                Dim strFileName As String = ""
                strFilePath = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, objBaseFlowKqglQJD.HJWJ, strFileSpec, strFilePath, strFileName) = False Then
                    GoTo errProc
                End If
                Dim strUrl As String
                strUrl = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + strFileName

                '记录访问审计日志
                If Me.m_objsystemFlowObjectKqglQJD.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了文件[" + Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS + "]的[签批件的电子文件]！") = False Then
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
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.m_objsystemFlowObjectKqglQJD.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                If objBaseFlowKqglQJD.PJYJ = "" Then
                    strErrMsg = "错误：还没有导入签批件的扫描件！"
                    GoTo errProc
                End If

                '签批件的扫描件
                Dim strFileSpec As String = ""
                Dim strFilePath As String = ""
                Dim strFileName As String = ""
                strFilePath = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, objBaseFlowKqglQJD.PJYJ, strFileSpec, strFilePath, strFileName) = False Then
                    GoTo errProc
                End If
                Dim strUrl As String
                strUrl = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + strFileName

                '记录访问审计日志
                If Me.m_objsystemFlowObjectKqglQJD.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了文件[" + Me.m_objsystemFlowObjectKqglQJD.FlowData.WJBS + "]的[签批件的扫描件]！") = False Then
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











        Private Sub doJQ_AddNew(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIASHENQINGDAN_JIAQI
             Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try

                '检查
                If Me.txtJQTS.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[休假天数]！"
                    GoTo errProc
                End If
              

                '加入
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_RYXX.Tables(strTable)
                    objDataRow = .NewRow()

                    objDataRow.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_XH) = .Rows.Count + 1
                    objDataRow.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_WYBS) = ""
                    objDataRow.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_WJBS) = Me.htxtWJBS.Value
                    objDataRow.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_TS) = Me.txtJQTS.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_XSTS) = Me.txtJQTS.Text + "天"
                    If Me.ddlJQ.SelectedIndex < 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_JQDM) = ""
                        objDataRow.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_JQMC) = ""
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_JQDM) = objPulicParameters.getObjectValue(Me.ddlJQ.SelectedValue, "")
                        objDataRow.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_JQMC) = Me.ddlJQ.SelectedItem.Text
                    End If

                    .Rows.Add(objDataRow)
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
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
           
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            
            Exit Sub

        End Sub

        Private Sub doJQ_Delete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIASHENQINGDAN_JIAQI
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
                If Me.grdRYXX.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选择要删除的内容！"
                End If
                

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实要删除内容吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim objDataRow As System.Data.DataRow
                    Dim intPos As Integer
                    Dim strField As String = Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_XH
                    Dim intCount As Integer
                  
                    intPos = objDataGridProcess.getRecordPosition(Me.grdRYXX.SelectedIndex, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)

                    With Me.m_objDataSet_RYXX.Tables(strTable)
                        objDataRow = Nothing
                        objDataRow = .DefaultView.Item(intPos).Row
                        If Not (objDataRow Is Nothing) Then
                            .Rows.Remove(objDataRow)
                        End If

                        '调整序号
                        intCount = .DefaultView.Count
                        For i = 0 To intCount - 1
                            .DefaultView.Item(i).Item(strField) = i + 1
                        Next
                    End With


                    

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
                    .iRenyuanList = Me.txtRYXM.Text

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
                strUrl += "../ryxz/ryxz_zzry.aspx"
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
                strUrl += "../dmxz/dmxz_zzjg.aspx"
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







    

        Private Sub btnJQ_AddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJQ_AddNew.Click
            Me.doJQ_AddNew("btnJQ_AddNew")
        End Sub

        Private Sub btnJQ_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJQ_Delete.Click
            Me.doJQ_Delete("btnJQ_Delete")
        End Sub

        'Public Sub txtStartSQRQ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartSQRQ.TextChanged
        '    If txtStartSQRQ.Text.Trim <> "" Then
        '        Me.txtEndSQRQ_TextChanged(sender, e)
        '    End If
        'End Sub

        'Public Sub txtEndSQRQ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEndSQRQ.TextChanged

        'End Sub

        Public Sub lnkRq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRq.Click
            Me.doComputeRq()
        End Sub

        Public Sub doComputeRq()
            Dim dateStart As System.DateTime
            Dim dateEnd As System.DateTime
            Dim intTs As Integer

            If Me.txtStartSQRQ.Text.Trim <> "" Then
                If Me.txtEndSQRQ.Text.Trim <> "" Then
                    dateStart = CType(Me.txtStartSQRQ.Text.Trim, System.DateTime)
                    dateEnd = CType(Me.txtEndSQRQ.Text.Trim, System.DateTime)

                    Me.txtTS.Text = CType(DateDiff(DateInterval.Day, dateStart, dateEnd) + 1, String)
                End If
            End If
        End Sub
    End Class
End Namespace