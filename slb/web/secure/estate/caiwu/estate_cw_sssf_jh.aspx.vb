Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_cw_sssf_jh
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　根据“计划”进行实际收付款处理
    '----------------------------------------------------------------

    Partial Class estate_cw_sssf_jh
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateCwSssfJh
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateCwSssfJh
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdJHSZ相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_JHSZ As String = "chkJHSZ"
        Private Const m_cstrDataGridInDIV_JHSZ As String = "divJHSZ"
        Private m_intFixedColumns_JHSZ As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_JHSZ As Josco.JSOA.Common.Data.estateCaiwuData
        Private m_strQuery_JHSZ As String
        Private m_intRows_JHSZ As Integer

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------
        Private m_strFixQuery As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT + " = 1"

        '----------------------------------------------------------------
        '接口参数
        '----------------------------------------------------------------
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateCwSssfJh)
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
                    Me.htxtDivLeftJHSZ.Value = .htxtDivLeftJHSZ
                    Me.htxtDivTopJHSZ.Value = .htxtDivTopJHSZ

                    Me.htxtJHSZQuery.Value = .htxtJHSZQuery
                    Me.htxtJHSZRows.Value = .htxtJHSZRows
                    Me.htxtJHSZSort.Value = .htxtJHSZSort
                    Me.htxtJHSZSortColumnIndex.Value = .htxtJHSZSortColumnIndex
                    Me.htxtJHSZSortType.Value = .htxtJHSZSortType

                    Me.txtJHSZSearch_YSRQMax.Text = .txtJHSZSearch_YSRQMax
                    Me.txtJHSZSearch_YSRQMin.Text = .txtJHSZSearch_YSRQMin
                    Me.ddlJHSZSearch_SFDM.SelectedIndex = .ddlJHSZSearch_SFDM_SelectedIndex
                    Me.ddlJHSZSearch_SFBZ.SelectedIndex = .ddlJHSZSearch_SFBZ_SelectedIndex
                    Me.ddlJHSZSearch_SFDX.SelectedIndex = .ddlJHSZSearch_SFDX_SelectedIndex

                    Me.txtJHSZPageIndex.Text = .txtJHSZPageIndex
                    Me.txtJHSZPageSize.Text = .txtJHSZPageSize
                    Try
                        Me.grdJHSZ.PageSize = .grdJHSZPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJHSZ.CurrentPageIndex = .grdJHSZCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJHSZ.SelectedIndex = .grdJHSZSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtJHSZSessionIdQuery.Value = .htxtJHSZSessionIdQuery

                    Me.txtJHFSJE.Text = .txtJHFSJE
                    Me.txtJHPJHM.Text = .txtJHPJHM
                    Me.txtJHZYSM.Text = .txtJHZYSM
                    Me.txtJHKHMC.Text = .txtJHKHMC
                    Me.txtJHJBRY.Text = .txtJHJBRY
                    Me.txtJHJBDW.Text = .txtJHJBDW
                    Me.htxtJHJBRY.Value = .htxtJHJBRY
                    Me.htxtJHJBDW.Value = .htxtJHJBDW
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateCwSssfJh

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftJHSZ = Me.htxtDivLeftJHSZ.Value
                    .htxtDivTopJHSZ = Me.htxtDivTopJHSZ.Value

                    .htxtJHSZQuery = Me.htxtJHSZQuery.Value
                    .htxtJHSZRows = Me.htxtJHSZRows.Value
                    .htxtJHSZSort = Me.htxtJHSZSort.Value
                    .htxtJHSZSortColumnIndex = Me.htxtJHSZSortColumnIndex.Value
                    .htxtJHSZSortType = Me.htxtJHSZSortType.Value

                    .txtJHSZSearch_YSRQMax = Me.txtJHSZSearch_YSRQMax.Text
                    .txtJHSZSearch_YSRQMin = Me.txtJHSZSearch_YSRQMin.Text
                    .ddlJHSZSearch_SFDM_SelectedIndex = Me.ddlJHSZSearch_SFDM.SelectedIndex
                    .ddlJHSZSearch_SFBZ_SelectedIndex = Me.ddlJHSZSearch_SFBZ.SelectedIndex
                    .ddlJHSZSearch_SFDX_SelectedIndex = Me.ddlJHSZSearch_SFDX.SelectedIndex

                    .txtJHSZPageIndex = Me.txtJHSZPageIndex.Text
                    .txtJHSZPageSize = Me.txtJHSZPageSize.Text
                    .grdJHSZPageSize = Me.grdJHSZ.PageSize
                    .grdJHSZCurrentPageIndex = Me.grdJHSZ.CurrentPageIndex
                    .grdJHSZSelectedIndex = Me.grdJHSZ.SelectedIndex
                    .htxtJHSZSessionIdQuery = Me.htxtJHSZSessionIdQuery.Value

                    .txtJHFSJE = Me.txtJHFSJE.Text
                    .txtJHPJHM = Me.txtJHPJHM.Text
                    .txtJHZYSM = Me.txtJHZYSM.Text
                    .txtJHKHMC = Me.txtJHKHMC.Text
                    .txtJHJBRY = Me.txtJHJBRY.Text
                    .txtJHJBDW = Me.txtJHJBDW.Text
                    .htxtJHJBRY = Me.htxtJHJBRY.Value
                    .htxtJHJBDW = Me.htxtJHJBDW.Value
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
                Dim objIDmxzRyxx As Josco.JsKernal.BusinessFacade.IDmxzRyxx = Nothing
                Try
                    objIDmxzRyxx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzRyxx)
                Catch ex As Exception
                    objIDmxzRyxx = Nothing
                End Try
                If Not (objIDmxzRyxx Is Nothing) Then
                    If objIDmxzRyxx.oExitMode = True Then
                        Select Case objIDmxzRyxx.iSourceControlId.ToUpper
                            Case "btnSelect_JHJBRY".ToUpper
                                Me.htxtJHJBRY.Value = objIDmxzRyxx.oRYDM
                                Me.txtJHJBRY.Text = objIDmxzRyxx.oRYZM
                                Me.htxtJHJBDW.Value = objIDmxzRyxx.oZZDM
                                Me.txtJHJBDW.Text = objIDmxzRyxx.oZZMC
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzRyxx.SafeRelease(objIDmxzRyxx)
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
                            Case "btnSelect_JHJBDW".ToUpper
                                Me.txtJHJBDW.Text = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtJHJBDW.Text, Me.htxtJHJBDW.Value) = False Then
                                    Me.htxtJHJBDW.Value = ""
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
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
                            Case "btnJHSZSearch_Full".ToUpper()
                                Me.htxtJHSZQuery.Value = objISjcxCxtj.oQueryString
                                If Me.htxtJHSZSessionIdQuery.Value.Trim = "" Then
                                    Me.htxtJHSZSessionIdQuery.Value = objPulicParameters.getNewGuid()
                                Else
                                    Try
                                        objQueryData = CType(Session(Me.htxtJHSZSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                                    Catch ex As Exception
                                        objQueryData = Nothing
                                    End Try
                                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                                End If
                                Session.Add(Me.htxtJHSZSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
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
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateCwSssfJh)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_strQRSH = ""
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_strQRSH = Me.m_objInterface.iQRSH
                End If
                Dim blnIS As Boolean = False
                If objsystemEstateErshou.isQrshExist(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = False Then Me.m_strQRSH = ""
                If Me.m_strQRSH = "" Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "错误：没有提供本模块需要的接口！"
                    Exit Try
                End If

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateCwSssfJh)
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

                '是否处于编辑状态
                Me.m_strQuery_JHSZ = Me.htxtJHSZQuery.Value
                Me.m_intRows_JHSZ = objPulicParameters.getObjectValue(Me.htxtJHSZRows.Value, 0)
                Me.m_intFixedColumns_JHSZ = objPulicParameters.getObjectValue(Me.htxtJHSZFixed.Value, 0)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                If Me.htxtJHSZSessionIdQuery.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtJHSZSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtJHSZSessionIdQuery.Value)
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
        Private Function getQueryString_JHSZ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_JHSZ = False
            strQuery = ""

            Try
                '按“税费代码”搜索
                Dim strSFDM As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM
                Select Case Me.ddlJHSZSearch_SFDM.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFDM + " like '" + Me.ddlJHSZSearch_SFDM.SelectedValue + "%'"
                        Else
                            strQuery = strQuery + " and " + strSFDM + " like '" + Me.ddlJHSZSearch_SFDM.SelectedValue + "%'"
                        End If
                End Select

                '按“收付标志”搜索
                Dim strSFBZ As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ
                Select Case Me.ddlJHSZSearch_SFBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFBZ + " = '" + Me.ddlJHSZSearch_SFBZ.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strSFBZ + " = '" + Me.ddlJHSZSearch_SFBZ.SelectedValue + "'"
                        End If
                End Select

                '按“收付对象”搜索
                Dim strSFDX As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX
                Select Case Me.ddlJHSZSearch_SFDX.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFDX + " = '" + Me.ddlJHSZSearch_SFDX.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strSFDX + " = '" + Me.ddlJHSZSearch_SFDX.SelectedValue + "'"
                        End If
                End Select

                '按“应收日期”搜索
                Dim strYSRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strYSRQ = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ
                If Me.txtJHSZSearch_YSRQMin.Text.Length > 0 Then Me.txtJHSZSearch_YSRQMin.Text = Me.txtJHSZSearch_YSRQMin.Text.Trim()
                If Me.txtJHSZSearch_YSRQMax.Text.Length > 0 Then Me.txtJHSZSearch_YSRQMax.Text = Me.txtJHSZSearch_YSRQMax.Text.Trim()
                If Me.txtJHSZSearch_YSRQMin.Text <> "" And Me.txtJHSZSearch_YSRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtJHSZSearch_YSRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtJHSZSearch_YSRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtJHSZSearch_YSRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtJHSZSearch_YSRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtJHSZSearch_YSRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtJHSZSearch_YSRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strYSRQ + " between '" + Me.txtJHSZSearch_YSRQMin.Text + "' and '" + Me.txtJHSZSearch_YSRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strYSRQ + " between '" + Me.txtJHSZSearch_YSRQMin.Text + "' and '" + Me.txtJHSZSearch_YSRQMax.Text + "'"
                    End If
                ElseIf Me.txtJHSZSearch_YSRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtJHSZSearch_YSRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtJHSZSearch_YSRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strYSRQ + " >= '" + Me.txtJHSZSearch_YSRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strYSRQ + " >= '" + Me.txtJHSZSearch_YSRQMin.Text + "'"
                    End If
                ElseIf Me.txtJHSZSearch_YSRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtJHSZSearch_YSRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtJHSZSearch_YSRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strYSRQ + " <= '" + Me.txtJHSZSearch_YSRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strYSRQ + " <= '" + Me.txtJHSZSearch_YSRQMax.Text + "'"
                    End If
                Else
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_JHSZ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdJHSZ要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        '     strWhere       ：搜索字符串
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_JHSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            getModuleData_JHSZ = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtJHSZSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(Me.m_objDataSet_JHSZ)

                '默认条件：一般计划
                If strWhere = "" Then
                    strWhere = Me.m_strFixQuery
                Else
                    strWhere = strWhere + " and " + Me.m_strFixQuery
                End If

                '重新检索数据
                If objsystemEstateCaiwu.getDataSet_ES_YSYF(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_JHSZ) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_JHSZ.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_JHSZ.Tables(strTable)
                    Me.htxtJHSZRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_JHSZ = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            getModuleData_JHSZ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdJHSZ数据
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_JHSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            searchModuleData_JHSZ = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_JHSZ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_JHSZ(strErrMsg, strQRSH, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_JHSZ = strQuery
                Me.htxtJHSZQuery.Value = Me.m_strQuery_JHSZ
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_JHSZ = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdJHSZ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_JHSZ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_JHSZ = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtJHSZSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtJHSZSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_JHSZ Is Nothing Then
                    Me.grdJHSZ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_JHSZ.Tables(strTable)
                        Me.grdJHSZ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_JHSZ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdJHSZ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdJHSZ)
                    With Me.grdJHSZ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdJHSZ.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdJHSZ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_JHSZ) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_JHSZ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示参数窗的数据(根据网格当前行数据显示)
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditPanelInfo( _
            ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strValue As String = ""

            showEditPanelInfo = False

            Try
                '现场已经恢复
                If Me.IsPostBack = False And Me.m_blnSaveScence = True Then
                    Exit Try
                End If

                '查看状态
                If Me.grdJHSZ.Items.Count < 1 Or Me.grdJHSZ.SelectedIndex < 0 Then
                    Me.txtJHFSJE.Text = ""
                    Me.txtJHZYSM.Text = ""
                    Me.txtJHJBRY.Text = ""
                    Me.txtJHJBDW.Text = ""
                    Me.txtJHKHMC.Text = ""
                    Me.txtJHPJHM.Text = ""
                    Me.htxtJHJBRY.Value = ""
                    Me.htxtJHJBDW.Value = ""
                Else
                    Dim intColIndex As Integer = -1

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJHSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdJHSZ.Items(Me.grdJHSZ.SelectedIndex), intColIndex)
                    Me.txtJHFSJE.Text = objPulicParameters.getObjectValue(strValue, 0.0).ToString("#,###.00")

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJHSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QTMS)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdJHSZ.Items(Me.grdJHSZ.SelectedIndex), intColIndex)
                    Me.txtJHZYSM.Text = strValue

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJHSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdJHSZ.Items(Me.grdJHSZ.SelectedIndex), intColIndex)
                    Select Case strValue
                        Case Josco.JSOA.Common.Data.estateCaiwuData.SFDX_J
                            Me.txtJHKHMC.Text = Me.lblJFMC.Text
                        Case Else
                            Me.txtJHKHMC.Text = Me.lblYFMC.Text
                    End Select

                    'zengxianglin 2010-12-29
                    '设定初始值
                    Me.htxtJHJBRY.Value = MyBase.UserId
                    Me.txtJHJBRY.Text = MyBase.UserXM
                    Me.htxtJHJBDW.Value = MyBase.UserBmdm
                    Me.txtJHJBDW.Text = MyBase.UserBmmc
                    'zengxianglin 2010-12-29
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanelInfo = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示JHSZ相关的全部信息
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_JHSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_JHSZ = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_JHSZ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_JHSZ.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblJHSZGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdJHSZ, .Count)

                    '显示页面浏览功能
                    Me.lnkCZJHSZMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdJHSZ, .Count)
                    Me.lnkCZJHSZMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdJHSZ, .Count)
                    Me.lnkCZJHSZMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdJHSZ, .Count)
                    Me.lnkCZJHSZMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdJHSZ, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZJHSZDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZJHSZSelectAll.Enabled = blnEnabled
                    Me.lnkCZJHSZGotoPage.Enabled = blnEnabled
                    Me.lnkCZJHSZSetPageSize.Enabled = blnEnabled
                End With

                '显示其他
                If Me.showEditPanelInfo(strErrMsg) = False Then
                    GoTo errProc
                End If
                '显示备用金
                If Me.showBeiyongjin(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If

                Me.btnOK.Visible = Me.m_blnPrevilegeParams(1)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_JHSZ = True
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
                    objControlProcess.doTranslateKey(Me.txtJHSZPageIndex)
                    objControlProcess.doTranslateKey(Me.txtJHSZPageSize)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtJHSZSearch_YSRQMin)
                    objControlProcess.doTranslateKey(Me.txtJHSZSearch_YSRQMax)
                    objControlProcess.doTranslateKey(Me.ddlJHSZSearch_SFDM)
                    objControlProcess.doTranslateKey(Me.ddlJHSZSearch_SFBZ)
                    objControlProcess.doTranslateKey(Me.ddlJHSZSearch_SFDX)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtJHJBDW)
                    objControlProcess.doTranslateKey(Me.txtJHJBRY)
                    objControlProcess.doTranslateKey(Me.txtJHKHMC)
                    objControlProcess.doTranslateKey(Me.txtJHZYSM)
                    objControlProcess.doTranslateKey(Me.txtJHPJHM)
                    objControlProcess.doTranslateKey(Me.txtJHFSJE)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtBYJ_HT)
                    objControlProcess.doTranslateKey(Me.txtBYJ_JF)
                    objControlProcess.doTranslateKey(Me.txtBYJ_YF)

                    '显示交易数据
                    If Me.showJiaoyiInfo(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If

                    '获取数据
                    If Me.getModuleData_JHSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_JHSZ) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_JHSZ(strErrMsg, Me.m_strQRSH) = False Then
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
            Dim strErrMsg As String = ""
            Dim strUrl As String = ""

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
                If Me.doFillSfdmList(strErrMsg, Me.ddlJHSZSearch_SFDM, True) = False Then
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
        Sub grdJHSZ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdJHSZ.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_JHSZ + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns_JHSZ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_JHSZ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdJHSZ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdJHSZ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdJHSZ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblJHSZGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdJHSZ, Me.m_intRows_JHSZ)
                '同步显示数据
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

        Private Sub grdJHSZ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdJHSZ.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
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
                If Me.getModuleData_JHSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_JHSZ) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objDataSet_JHSZ.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet_JHSZ.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtJHSZSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtJHSZSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtJHSZSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_JHSZ(strErrMsg, Me.m_strQRSH) = False Then
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














        Private Sub doMoveFirst_JHSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_JHSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_JHSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdJHSZ.PageCount)
                Me.grdJHSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JHSZ(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub doMoveLast_JHSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_JHSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_JHSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJHSZ.PageCount - 1, Me.grdJHSZ.PageCount)
                Me.grdJHSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JHSZ(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub doMoveNext_JHSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_JHSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_JHSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJHSZ.CurrentPageIndex + 1, Me.grdJHSZ.PageCount)
                Me.grdJHSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JHSZ(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub doMovePrevious_JHSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_JHSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_JHSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJHSZ.CurrentPageIndex - 1, Me.grdJHSZ.PageCount)
                Me.grdJHSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JHSZ(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub doGotoPage_JHSZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtJHSZPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_JHSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_JHSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdJHSZ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JHSZ(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtJHSZPageIndex.Text = (Me.grdJHSZ.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_JHSZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtJHSZPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_JHSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_JHSZ) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdJHSZ.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_JHSZ(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtJHSZPageSize.Text = (Me.grdJHSZ.PageSize).ToString()
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

        Private Sub doSelectAll_JHSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdJHSZ, 0, Me.m_cstrCheckBoxIdInDataGrid_JHSZ, True) = False Then
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

        Private Sub doDeSelectAll_JHSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdJHSZ, 0, Me.m_cstrCheckBoxIdInDataGrid_JHSZ, False) = False Then
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

        Private Sub doSearch_JHSZ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_JHSZ(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_JHSZ(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub lnkCZJHSZMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJHSZMoveFirst.Click
            Me.doMoveFirst_JHSZ("lnkCZJHSZMoveFirst")
        End Sub

        Private Sub lnkCZJHSZMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJHSZMoveLast.Click
            Me.doMoveLast_JHSZ("lnkCZJHSZMoveLast")
        End Sub

        Private Sub lnkCZJHSZMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJHSZMoveNext.Click
            Me.doMoveNext_JHSZ("lnkCZJHSZMoveNext")
        End Sub

        Private Sub lnkCZJHSZMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJHSZMovePrev.Click
            Me.doMovePrevious_JHSZ("lnkCZJHSZMovePrev")
        End Sub

        Private Sub lnkCZJHSZGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJHSZGotoPage.Click
            Me.doGotoPage_JHSZ("lnkCZJHSZGotoPage")
        End Sub

        Private Sub lnkCZJHSZSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJHSZSetPageSize.Click
            Me.doSetPageSize_JHSZ("lnkCZJHSZSetPageSize")
        End Sub

        Private Sub lnkCZJHSZSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJHSZSelectAll.Click
            Me.doSelectAll_JHSZ("lnkCZJHSZSelectAll")
        End Sub

        Private Sub lnkCZJHSZDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJHSZDeSelectAll.Click
            Me.doDeSelectAll_JHSZ("lnkCZJHSZDeSelectAll")
        End Sub

        Private Sub btnJHSZSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJHSZSearch.Click
            Me.doSearch_JHSZ("btnJHSZSearch")
        End Sub














        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
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

        Private Sub doSearch_Full_JHSZ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
            Dim strNewSessionId As String = ""
            Dim strErrMsg As String = ""
            Dim strSessionId As String = ""

            Try
                '获取数据
                If Me.getModuleData_JHSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_JHSZ) = False Then
                    GoTo errProc
                End If

                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String = ""
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    If Me.htxtJHSZSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtJHSZSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_JHSZ.Tables(strTable)
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

        Private Sub doSelect_JHJBRY(ByVal strControlId As String)

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

        Private Sub doSelect_JHJBDW(ByVal strControlId As String)

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

        Private Sub doOK(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strErrMsg As String = ""

            Try
                intStep = 1
                '检查
                If Me.grdJHSZ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有[计划]数据！"
                    GoTo errProc
                End If
                If Me.txtJHFSJE.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[金额]！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtJHFSJE.Text) = False Then
                    strErrMsg = "错误：无效的[金额]！"
                    GoTo errProc
                End If
                If Me.txtJHPJHM.Text.Trim = "" Then
                    strErrMsg = "错误：没有输入[票据号]！"
                    GoTo errProc
                End If
                If Me.htxtJHJBRY.Value.Trim = "" Then
                    strErrMsg = "错误：没有输入[经办人员]！"
                    GoTo errProc
                End If
                If Me.htxtJHJBDW.Value.Trim = "" Then
                    strErrMsg = "错误：没有输入[经办单位]！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdJHSZ.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strWYBS As String = ""
                Dim strQRSH As String = ""
                Dim strSFBZ As String = ""
                Dim dblYSJE As Double = 0
                Dim dblSSJE As Double = 0
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJHSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdJHSZ.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJHSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdJHSZ.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJHSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ)
                strSFBZ = objDataGridProcess.getDataGridCellValue(Me.grdJHSZ.Items(i), intColIndex)
                'zengxianglin 2008-12-04
                Select Case strSFBZ
                    Case Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F
                        If Me.m_blnPrevilegeParams(3) = False Then
                            strErrMsg = "错误：您没有付款的权限！"
                            GoTo errProc
                        End If
                End Select
                'zengxianglin 2008-12-04
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJHSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE)
                dblYSJE = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdJHSZ.Items(i), intColIndex), 0.0)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJHSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SSJE)
                dblSSJE = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdJHSZ.Items(i), intColIndex), 0.0)
                If System.Math.Abs(dblSSJE - dblYSJE) < 0.001 Then
                    strErrMsg = "错误：该笔款项已经收齐！"
                    GoTo errProc
                End If
                Dim dblNewSSJE As Double = 0
                dblNewSSJE = objPulicParameters.getObjectValue(Me.txtJHFSJE.Text, 0.0)
                If (dblYSJE - dblSSJE - dblNewSSJE) < 0 Then
                    Me.txtJHFSJE.Text = (dblYSJE - dblSSJE).ToString("#,###.00")
                    strErrMsg = "错误：该笔款项的余额不足！"
                    GoTo errProc
                End If
                Dim dblBYJ_HT As Double = objPulicParameters.getObjectValue(Me.txtBYJ_HT.Text, 0.0)
                Select Case strSFBZ
                    Case Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F
                        If dblBYJ_HT < dblNewSSJE Then
                            Me.txtJHFSJE.Text = dblBYJ_HT.ToString("#,###.00")
                            strErrMsg = "错误：合同备用金不足，不能支付！"
                            GoTo errProc
                        End If
                    Case Else
                End Select

                intStep = 2
                '询问
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：一旦确认将不能删除，只能用[红字]冲减，要继续吗（是/否）？", strControlId, intStep)
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
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS, strWYBS)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH, strQRSH)
                    '***************************************************************************************************************
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE, Me.txtJHFSJE.Text)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_ZYSM, Me.txtJHZYSM.Text)
                    '***************************************************************************************************************
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_KHMC, Me.txtJHKHMC.Text)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM, Me.txtJHPJHM.Text)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRY, Me.htxtJHJBRY.Value)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDW, Me.htxtJHJBDW.Value)

                    '保存信息
                    If objsystemEstateCaiwu.doAddNew_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData) = False Then
                        GoTo errProc
                    End If

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[财务_实收实付]中增加了内容！")

                    '返回
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

        Private Sub btnJHSZSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJHSZSearch_Full.Click
            Me.doSearch_Full_JHSZ("btnJHSZSearch_Full")
        End Sub

        Private Sub btnSelect_JHJBRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JHJBRY.Click
            Me.doSelect_JHJBRY("btnSelect_JHJBRY")
        End Sub

        Private Sub btnSelect_JHJBDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JHJBDW.Click
            Me.doSelect_JHJBDW("btnSelect_JHJBDW")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace

