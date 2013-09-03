Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_cw_sssf_jz
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“实际收支结转”处理模块
    '----------------------------------------------------------------

    Partial Class estate_cw_sssf_jz
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateCwSssfJz
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateCwSssfJz
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
        '接口参数
        '----------------------------------------------------------------
        Private m_strOrgQRSH As String
        Private m_strQRSH As String

        Public ReadOnly Property propQRSH() As String
            Get
                propQRSH = Me.m_strOrgQRSH
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateCwSssfJz)
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateCwSssfJz

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftSJSZ = Me.htxtDivLeftSJSZ.Value
                    .htxtDivTopSJSZ = Me.htxtDivTopSJSZ.Value

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateCwSssfJz)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateCwSssfJz)
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
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_SJSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String) As Boolean

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
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_SJSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            searchModuleData_SJSZ = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_SJSZ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_SJSZ(strErrMsg, strQRSH, strQuery) = False Then
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
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SJSZ( _
            ByRef strErrMsg As String) As Boolean

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
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditPanelInfo( _
            ByRef strErrMsg As String) As Boolean

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strValue As String = ""

            showEditPanelInfo = False

            Try
                'If Me.IsPostBack = False And Me.m_blnSaveScence = True Then
                '    Exit Try
                'End If

                '查看状态
                If Me.grdSJSZ.Items.Count < 1 Or Me.grdSJSZ.SelectedIndex < 0 Then
                    Me.ddlSFDM.SelectedIndex = -1
                    Me.rblSFDX.SelectedIndex = -1
                    Me.rblSFBZ.SelectedIndex = -1
                    Me.txtFSJE.Text = ""
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

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                    Me.txtFSJE.Text = objPulicParameters.getObjectValue(strValue, 0.0).ToString("#,###.00")
                End If
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
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_SJSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_SJSZ = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_SJSZ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_SJSZ.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblSJSZGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdSJSZ, .Count)

                    '显示页面浏览功能
                    Me.lnkCZSJSZMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdSJSZ, .Count)
                    Me.lnkCZSJSZMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdSJSZ, .Count)
                    Me.lnkCZSJSZMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdSJSZ, .Count)
                    Me.lnkCZSJSZMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdSJSZ, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZSJSZDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZSJSZSelectAll.Enabled = blnEnabled
                    Me.lnkCZSJSZGotoPage.Enabled = blnEnabled
                    Me.lnkCZSJSZSetPageSize.Enabled = blnEnabled
                End With

                '同步显示
                If Me.showEditPanelInfo(strErrMsg) = False Then
                    GoTo errProc
                End If
                '显示备用金
                If Me.showBeiyongjin(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If

                '显示操作命令
                Me.btnOK.Visible = Me.m_blnPrevilegeParams(1) And Me.m_strQRSH <> ""
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
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SHBZ)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SFSH)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtFSJE)
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
                    If Me.m_blnSaveScence = False Then
                        If Me.searchModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                            GoTo errProc
                        End If
                    End If
                    '显示数据
                    If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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
                '同步
                If Me.showEditPanelInfo(strErrMsg) = False Then
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
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
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
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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













        Private Sub doMoveFirst_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSJSZ.PageCount - 1, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSJSZ.CurrentPageIndex + 1, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSJSZ.CurrentPageIndex - 1, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdSJSZ.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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
                If Me.searchModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objNewData As System.Collections.Specialized.NameValueCollection = Nothing
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0

            Try
                Dim strValue As String = ""
                Dim strWYBS As String = ""
                intStep = 1
                '检查
                If Me.grdSJSZ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有费用可结转！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdSJSZ.SelectedIndex
                Dim intColIndex As Integer = 0
                If Me.ddlSFDM.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定转入的费用！"
                    GoTo errProc
                End If
                If Me.rblSFBZ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定转入的收、付！"
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
                If Me.rblSFDX.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定转入的甲、乙！"
                    GoTo errProc
                End If
                If Me.txtFSJE.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定转入的金额！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtFSJE.Text) = False Then
                    strErrMsg = "错误：无效的转入金额！"
                    GoTo errProc
                End If
                Dim dblFSJE As Double = 0
                dblFSJE = objPulicParameters.getObjectValue(Me.txtFSJE.Text, 0.0)
                If dblFSJE <= 0 Then
                    strErrMsg = "错误：转入金额必须>0！"
                    GoTo errProc
                End If
                'zengxianglin 2010-12-30
                Dim strSFDX_Old As String = ""
                Dim strSFBZ_Old As String = ""
                Dim strSFDM_Old As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX)
                strSFDX_Old = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex), "")
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ)
                strSFBZ_Old = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex), "")
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM)
                strSFDM_Old = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex), "")
                'zengxianglin 2010-12-30
                Dim dblYFSJE As Double = 0
                'zengxianglin 2010-12-30
                'intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE)
                'dblYFSJE = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex), 0.0)
                If objsystemEstateCaiwu.getBalance(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, strSFDM_Old, strSFDX_Old, dblYFSJE) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2010-12-30
                If dblFSJE > dblYFSJE Then
                    strErrMsg = "错误：转入金额[" + dblFSJE.ToString("#,###.00") + "]超过[" + dblYFSJE.ToString("#,###.00") + "]！"
                    GoTo errProc
                End If
                Dim strSFDM As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM)
                strSFDM = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex), "")
                If strSFDM = Me.ddlSFDM.SelectedValue Then
                    strErrMsg = "错误：费用未发生变化！"
                    GoTo errProc
                End If
                'zengxianglin 2010-12-30
                '如果[收付对象]不变,则[收付标志]不能改变!
                If Me.rblSFDX.SelectedValue.ToUpper = strSFDX_Old.ToUpper Then
                    If Me.rblSFBZ.SelectedValue.ToUpper <> strSFBZ_Old Then
                        strErrMsg = "错误：同一客户的款项[收]、[付]不能转换，只能通过红字冲减，不能通过结转处理！"
                        GoTo errProc
                    End If
                End If
                If strSFBZ_Old = Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F Then
                    strErrMsg = "错误：只能对收款进行结转处理！"
                    GoTo errProc
                End If
                'zengxianglin 2010-12-30

                '确认
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：一旦确认将只能通过[红字]冲减，要继续吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '回答“是”
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '准备参数
                    objNewData = New System.Collections.Specialized.NameValueCollection
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS, strValue)
                    strWYBS = strValue
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH, strValue)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM, Me.ddlSFDM.SelectedValue)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC, Me.ddlSFDM.SelectedItem.Text.Split("|".ToCharArray)(1))
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE, Me.txtFSJE.Text)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX, Me.rblSFDX.SelectedValue)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ, Me.rblSFBZ.SelectedValue)

                    If Me.rblSFDX.SelectedValue.ToUpper = strSFDX_Old.ToUpper Then
                        '同一客户结转处理：费用类型改变
                        If objsystemEstateCaiwu.doJiezhuan_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData) = False Then
                            GoTo errProc
                        End If
                    Else
                        '不同客户间结转处理
                        If Me.rblSFBZ.SelectedValue.ToUpper = strSFBZ_Old.ToUpper Then
                            '[收]、[付]不变：收->收
                            If objsystemEstateCaiwu.doJiezhuan_ES_SSSF_TFX(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData) = False Then
                                GoTo errProc
                            End If
                        Else
                            '[收]、[付]改变：收->付
                            If objsystemEstateCaiwu.doJiezhuan_ES_SSSF_BTFX(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData) = False Then
                                GoTo errProc
                            End If
                        End If
                    End If

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[财务_实收实付]中对[" + strWYBS + "]执行了[结转]！")

                    '返回
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

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnSJSZSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSJSZSearch_Full.Click
            Me.doSearch_Full_SJSZ("btnSJSZSearch_Full")
        End Sub

        Private Sub btnSelect_JYBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JYBH.Click
            Me.doSelect_JYBH("btnSelect_JYBH")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace

