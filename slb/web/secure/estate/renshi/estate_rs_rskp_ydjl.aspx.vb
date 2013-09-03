Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_rskp_ydjl
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“人员变动记录”处理模块
    '
    ' 更改记录：
    '     zengxianglin 2010-01-06 更改
    '----------------------------------------------------------------

    Partial Class estate_rs_rskp_ydjl
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub




        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14





        'zengxianglin 2010-01-06
        'zengxianglin 2010-01-06

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
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_rskp_previlege_param"
        Private m_blnPrevilegeParams(2) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsRskpYdjl
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsRskpYdjl
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdRYLIST相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid As String = "chkRYLIST"
        Private Const m_cstrDataGridInDIV As String = "divRYLIST"
        Private m_intFixedColumns_RYLIST As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_YDJL As Josco.JSOA.Common.Data.estateRenshiGeneralData
        Private m_strQuery_RYLIST As String
        Private m_intRows_RYLIST As Integer

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_blnEditMode As Boolean
        Private m_intCurrentPageIndex As Integer
        Private m_intCurrentSelectIndex As Integer
        Private m_strRYDM As String
        Private m_strRYMC As String

        Public ReadOnly Property propRYDM() As String
            Get
                If Me.m_strRYDM Is Nothing Then Me.m_strRYDM = ""
                If Me.m_strRYDM = "" Then
                    propRYDM = "全体人员"
                Else
                    propRYDM = Me.m_strRYDM
                End If
            End Get
        End Property

        Public ReadOnly Property propRYMC() As String
            Get
                If Me.m_strRYMC Is Nothing Then Me.m_strRYMC = ""
                If Me.m_strRYMC = "" Then
                    propRYMC = "全体人员"
                Else
                    propRYMC = Me.m_strRYMC
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsRskpYdjl)
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
                    Me.htxtDivLeftRYLIST.Value = .htxtDivLeftRYLIST
                    Me.htxtDivTopRYLIST.Value = .htxtDivTopRYLIST

                    Me.htxtCurrentPage.Value = .htxtCurrentPage
                    Me.htxtCurrentRow.Value = .htxtCurrentRow
                    Me.htxtEditMode.Value = .htxtEditMode
                    Me.htxtEditType.Value = .htxtEditType

                    Me.htxtRYLISTQuery.Value = .htxtRYLISTQuery
                    Me.htxtRYLISTRows.Value = .htxtRYLISTRows
                    Me.htxtRYLISTSort.Value = .htxtRYLISTSort
                    Me.htxtRYLISTSortColumnIndex.Value = .htxtRYLISTSortColumnIndex
                    Me.htxtRYLISTSortType.Value = .htxtRYLISTSortType

                    'zengxianglin 2008-10-14
                    Me.txtSSFZ.Text = .txtSSFZ
                    Me.txtYSFZ.Text = .txtYSFZ
                    'zengxianglin 2008-10-14
                    Me.htxtWYBS.Value = .htxtWYBS
                    Me.htxtRYDM.Value = .htxtRYDM
                    Me.htxtGLBS.Value = .htxtGLBS
                    Me.htxtRZDW.Value = .htxtRZDW
                    Me.htxtYRDW.Value = .htxtYRDW
                    Me.txtRYMC.Text = .txtRYMC
                    Me.txtKSSJ.Text = .txtKSSJ
                    Me.txtJSSJ.Text = .txtJSSJ
                    Me.txtRZDW.Text = .txtRZDW
                    Me.txtRZJB.Text = .txtRZJB
                    Me.txtYRDW.Text = .txtYRDW
                    Me.txtYRJB.Text = .txtYRJB
                    Me.txtFGGZ.Text = .txtFGGZ
                    Me.txtBZXX.Text = .txtBZXX
                    Me.rblGWSX.SelectedIndex = .rblGWSX_SelectedIndex
                    Me.rblJBBZ.SelectedIndex = .rblJBBZ_SelectedIndex
                    Me.ddlYDYY.SelectedIndex = .ddlYDYY_SelectedIndex
                    Me.ddlZGSX.SelectedIndex = .ddlZGSX_SelectedIndex

                    Me.txtRYLISTSearch_RYDM.Text = .txtRYLISTSearch_RYDM
                    Me.txtRYLISTSearch_YDSJMax.Text = .txtRYLISTSearch_YDSJMax
                    Me.txtRYLISTSearch_YDSJMin.Text = .txtRYLISTSearch_YDSJMin
                    Me.txtRYLISTSearch_RZDW.Text = .txtRYLISTSearch_RZDW
                    Me.txtRYLISTSearch_YRDW.Text = .txtRYLISTSearch_YRDW
                    Me.ddlRYLISTSearch_GWSX.SelectedIndex = .ddlRYLISTSearch_GWSX_SelectedIndex
                    Me.ddlRYLISTSearch_YDYY.SelectedIndex = .ddlRYLISTSearch_YDYY_SelectedIndex
                    Me.ddlRYLISTSearch_ZGSX.SelectedIndex = .ddlRYLISTSearch_ZGSX_SelectedIndex

                    Me.txtRYLISTPageIndex.Text = .txtRYLISTPageIndex
                    Me.txtRYLISTPageSize.Text = .txtRYLISTPageSize

                    Try
                        Me.grdRYLIST.PageSize = .grdRYLISTPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRYLIST.CurrentPageIndex = .grdRYLISTCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRYLIST.SelectedIndex = .grdRYLISTSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    'zengxianglin 2010-01-06
                    Me.rblYGSX.SelectedIndex = .rblYGSX_SelectedIndex
                    Me.rblBCZB.SelectedIndex = .rblBCZB_SelectedIndex
                    Me.rblSCZB.SelectedIndex = .rblSCZB_SelectedIndex
                    Me.ddlYZSX.SelectedIndex = .ddlYZSX_SelectedIndex
                    Me.txtXSTD.Text = .txtXSTD
                    Me.txtYSTD.Text = .txtYSTD
                    'zengxianglin 2010-01-06
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsRskpYdjl

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftRYLIST = Me.htxtDivLeftRYLIST.Value
                    .htxtDivTopRYLIST = Me.htxtDivTopRYLIST.Value

                    .htxtCurrentPage = Me.htxtCurrentPage.Value
                    .htxtCurrentRow = Me.htxtCurrentRow.Value
                    .htxtEditMode = Me.htxtEditMode.Value
                    .htxtEditType = Me.htxtEditType.Value

                    .htxtRYLISTQuery = Me.htxtRYLISTQuery.Value
                    .htxtRYLISTRows = Me.htxtRYLISTRows.Value
                    .htxtRYLISTSort = Me.htxtRYLISTSort.Value
                    .htxtRYLISTSortColumnIndex = Me.htxtRYLISTSortColumnIndex.Value
                    .htxtRYLISTSortType = Me.htxtRYLISTSortType.Value

                    'zengxianglin 2008-10-14
                    .txtSSFZ = Me.txtSSFZ.Text
                    .txtYSFZ = Me.txtYSFZ.Text
                    'zengxianglin 2008-10-14
                    .htxtWYBS = Me.htxtWYBS.Value
                    .htxtRYDM = Me.htxtRYDM.Value
                    .htxtGLBS = Me.htxtGLBS.Value
                    .htxtRZDW = Me.htxtRZDW.Value
                    .htxtYRDW = Me.htxtYRDW.Value
                    .txtRYMC = Me.txtRYMC.Text
                    .txtKSSJ = Me.txtKSSJ.Text
                    .txtJSSJ = Me.txtJSSJ.Text
                    .txtRZDW = Me.txtRZDW.Text
                    .txtRZJB = Me.txtRZJB.Text
                    .txtYRDW = Me.txtYRDW.Text
                    .txtYRJB = Me.txtYRJB.Text
                    .txtFGGZ = Me.txtFGGZ.Text
                    .txtBZXX = Me.txtBZXX.Text
                    .rblGWSX_SelectedIndex = Me.rblGWSX.SelectedIndex
                    .rblJBBZ_SelectedIndex = Me.rblJBBZ.SelectedIndex
                    .ddlYDYY_SelectedIndex = Me.ddlYDYY.SelectedIndex
                    .ddlZGSX_SelectedIndex = Me.ddlZGSX.SelectedIndex

                    .txtRYLISTSearch_RYDM = Me.txtRYLISTSearch_RYDM.Text
                    .txtRYLISTSearch_YDSJMax = Me.txtRYLISTSearch_YDSJMax.Text
                    .txtRYLISTSearch_YDSJMin = Me.txtRYLISTSearch_YDSJMin.Text
                    .txtRYLISTSearch_RZDW = Me.txtRYLISTSearch_RZDW.Text
                    .txtRYLISTSearch_YRDW = Me.txtRYLISTSearch_YRDW.Text
                    .ddlRYLISTSearch_GWSX_SelectedIndex = Me.ddlRYLISTSearch_GWSX.SelectedIndex
                    .ddlRYLISTSearch_YDYY_SelectedIndex = Me.ddlRYLISTSearch_YDYY.SelectedIndex
                    .ddlRYLISTSearch_YDYY_SelectedIndex = Me.ddlRYLISTSearch_ZGSX.SelectedIndex

                    .txtRYLISTPageIndex = Me.txtRYLISTPageIndex.Text
                    .txtRYLISTPageSize = Me.txtRYLISTPageSize.Text

                    .grdRYLISTPageSize = Me.grdRYLIST.PageSize
                    .grdRYLISTCurrentPageIndex = Me.grdRYLIST.CurrentPageIndex
                    .grdRYLISTSelectedIndex = Me.grdRYLIST.SelectedIndex
                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    'zengxianglin 2010-01-06
                    .rblYGSX_SelectedIndex = Me.rblYGSX.SelectedIndex
                    .rblBCZB_SelectedIndex = Me.rblBCZB.SelectedIndex
                    .rblSCZB_SelectedIndex = Me.rblSCZB.SelectedIndex
                    .ddlYZSX_SelectedIndex = Me.ddlYZSX.SelectedIndex
                    .txtXSTD = Me.txtXSTD.Text
                    .txtYSTD = Me.txtYSTD.Text
                    'zengxianglin 2010-01-06
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
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg = Nothing
                Try
                    objIDmxzZzjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzjg)
                Catch ex As Exception
                    objIDmxzZzjg = Nothing
                End Try
                If Not (objIDmxzZzjg Is Nothing) Then
                    If objIDmxzZzjg.oExitMode = True Then
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper()
                            Case "btnSelect_RZDW".ToUpper()
                                Dim strMC As String = objIDmxzZzjg.oBumenList
                                Dim strDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strMC, strDM) = True Then
                                    Me.htxtRZDW.Value = strDM
                                    Me.txtRZDW.Text = strMC
                                End If
                            Case "btnSelect_YRDW".ToUpper()
                                Dim strMC As String = objIDmxzZzjg.oBumenList
                                Dim strDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strMC, strDM) = True Then
                                    Me.htxtYRDW.Value = strDM
                                    Me.txtYRDW.Text = strMC
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
                        Select Case objIDmxzRyxx.iSourceControlId.ToUpper()
                            Case "btnSelect_RYDM".ToUpper()
                                Me.htxtRYDM.Value = objIDmxzRyxx.oRYDM
                                Me.txtRYMC.Text = objIDmxzRyxx.oRYZM
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
                        Me.htxtRYLISTQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQuery.Value.Trim = "" Then
                            Me.htxtSessionIdQuery.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
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
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getInterfaceParameters = False

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsRskpYdjl)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_strRYDM = ""
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_strRYDM = Me.m_objInterface.iRYDM
                End If
                If Me.m_strRYDM = "" Then
                    Me.m_strRYMC = ""
                Else
                    If objsystemCustomer.getRyzmByRydm(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strRYDM, Me.m_strRYMC) = False Then
                        GoTo errProc
                    End If
                End If

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsRskpYdjl)
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

                Me.m_strQuery_RYLIST = Me.htxtRYLISTQuery.Value
                Me.m_intRows_RYLIST = objPulicParameters.getObjectValue(Me.htxtRYLISTRows.Value, 0)
                Me.m_intFixedColumns_RYLIST = objPulicParameters.getObjectValue(Me.htxtRYLISTFixed.Value, 0)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery.Value)
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
        Private Function getQueryString_RYLIST( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_RYLIST = False
            strQuery = ""

            Try
                '按“员工号”搜索
                Dim strRYDM As String = "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYDM
                If Me.txtRYLISTSearch_RYDM.Text.Length > 0 Then Me.txtRYLISTSearch_RYDM.Text = Me.txtRYLISTSearch_RYDM.Text.Trim()
                If Me.txtRYLISTSearch_RYDM.Text <> "" Then
                    Me.txtRYLISTSearch_RYDM.Text = objPulicParameters.getNewSearchString(Me.txtRYLISTSearch_RYDM.Text.Trim())
                    If strQuery = "" Then
                        strQuery = strRYDM + " like '" + Me.txtRYLISTSearch_RYDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYDM + " like '" + Me.txtRYLISTSearch_RYDM.Text + "%'"
                    End If
                End If

                '按“任职单位”搜索
                Dim strRZDW As String = "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDWMC
                If Me.txtRYLISTSearch_RZDW.Text.Length > 0 Then Me.txtRYLISTSearch_RZDW.Text = Me.txtRYLISTSearch_RZDW.Text.Trim()
                If Me.txtRYLISTSearch_RZDW.Text <> "" Then
                    Me.txtRYLISTSearch_RZDW.Text = objPulicParameters.getNewSearchString(Me.txtRYLISTSearch_RZDW.Text)
                    If strQuery = "" Then
                        strQuery = strRZDW + " like '" + Me.txtRYLISTSearch_RZDW.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRZDW + " like '" + Me.txtRYLISTSearch_RZDW.Text + "%'"
                    End If
                End If

                '按“原任单位”搜索
                Dim strYRDW As String = "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRDWMC
                If Me.txtRYLISTSearch_YRDW.Text.Length > 0 Then Me.txtRYLISTSearch_YRDW.Text = Me.txtRYLISTSearch_YRDW.Text.Trim()
                If Me.txtRYLISTSearch_YRDW.Text <> "" Then
                    Me.txtRYLISTSearch_YRDW.Text = objPulicParameters.getNewSearchString(Me.txtRYLISTSearch_YRDW.Text)
                    If strQuery = "" Then
                        strQuery = strYRDW + " like '" + Me.txtRYLISTSearch_YRDW.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strYRDW + " like '" + Me.txtRYLISTSearch_YRDW.Text + "%'"
                    End If
                End If

                'zengxianglin 2008-10-14
                '按“变动类型”搜索
                Dim strYDYY As String = "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYY
                If Me.ddlRYLISTSearch_YDYY.SelectedIndex > 0 Then
                    If strQuery = "" Then
                        strQuery = strYDYY + " like '" + Me.ddlRYLISTSearch_YDYY.SelectedValue + "%'"
                    Else
                        strQuery = strQuery + " and " + strYDYY + " like '" + Me.ddlRYLISTSearch_YDYY.SelectedValue + "%'"
                    End If
                End If
                'zengxianglin 2008-10-14

                '按“岗位属性”搜索
                Dim strGWSX As String = "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSX
                Select Case Me.ddlRYLISTSearch_GWSX.SelectedIndex
                    Case 1, 2
                        If strQuery = "" Then
                            strQuery = strGWSX + " = " + Me.ddlRYLISTSearch_GWSX.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strGWSX + " = " + Me.ddlRYLISTSearch_GWSX.SelectedValue
                        End If
                    Case Else
                End Select

                '按“职工类别”搜索
                Dim strZGSX As String = "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZGSX
                Select Case Me.ddlRYLISTSearch_ZGSX.SelectedIndex
                    Case 1, 2
                        If strQuery = "" Then
                            strQuery = strZGSX + " = " + Me.ddlRYLISTSearch_ZGSX.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strZGSX + " = " + Me.ddlRYLISTSearch_ZGSX.SelectedValue
                        End If
                    Case Else
                End Select

                '按“开始时间”搜索
                Dim strKSSJ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strKSSJ = "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_KSSJ
                If Me.txtRYLISTSearch_YDSJMin.Text.Length > 0 Then Me.txtRYLISTSearch_YDSJMin.Text = Me.txtRYLISTSearch_YDSJMin.Text.Trim()
                If Me.txtRYLISTSearch_YDSJMax.Text.Length > 0 Then Me.txtRYLISTSearch_YDSJMax.Text = Me.txtRYLISTSearch_YDSJMax.Text.Trim()
                If Me.txtRYLISTSearch_YDSJMin.Text <> "" And Me.txtRYLISTSearch_YDSJMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtRYLISTSearch_YDSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtRYLISTSearch_YDSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtRYLISTSearch_YDSJMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtRYLISTSearch_YDSJMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtRYLISTSearch_YDSJMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtRYLISTSearch_YDSJMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strKSSJ + " between '" + Me.txtRYLISTSearch_YDSJMin.Text + "' and '" + Me.txtRYLISTSearch_YDSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strKSSJ + " between '" + Me.txtRYLISTSearch_YDSJMin.Text + "' and '" + Me.txtRYLISTSearch_YDSJMax.Text + "'"
                    End If
                ElseIf Me.txtRYLISTSearch_YDSJMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtRYLISTSearch_YDSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtRYLISTSearch_YDSJMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strKSSJ + " >= '" + Me.txtRYLISTSearch_YDSJMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strKSSJ + " >= '" + Me.txtRYLISTSearch_YDSJMin.Text + "'"
                    End If
                ElseIf Me.txtRYLISTSearch_YDSJMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtRYLISTSearch_YDSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtRYLISTSearch_YDSJMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strKSSJ + " <= '" + Me.txtRYLISTSearch_YDSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strKSSJ + " <= '" + Me.txtRYLISTSearch_YDSJMax.Text + "'"
                    End If
                Else
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_RYLIST = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdRYLIST要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strRYDM        ：人员代码
        '     strWhere       ：搜索字符串
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_RYLIST( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIYIDONG
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral

            getModuleData_RYLIST = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtRYLISTSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_YDJL)

                '重新检索数据
                If objsystemEstateRenshiGeneral.getDataSet_RSKP_YDJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_YDJL) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_YDJL.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                If blnEditMode = False Then '查看模式
                    With Me.m_objDataSet_YDJL.Tables(strTable)
                        .DefaultView.AllowNew = False
                    End With
                Else '编辑模式
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            '增加1条空记录
                            With Me.m_objDataSet_YDJL.Tables(strTable)
                                .DefaultView.AllowNew = True
                                .DefaultView.AddNew()
                            End With
                        Case Else
                            With Me.m_objDataSet_YDJL.Tables(strTable)
                                .DefaultView.AllowNew = False
                            End With
                    End Select
                End If

                '缓存参数
                With Me.m_objDataSet_YDJL.Tables(strTable)
                    Me.htxtRYLISTRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_RYLIST = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)

            getModuleData_RYLIST = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdRYLIST数据
        '     strErrMsg      ：返回错误信息
        '     strRYDM        ：人员代码
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_RYLIST( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            searchModuleData_RYLIST = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_RYLIST(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_RYLIST(strErrMsg, strRYDM, strQuery, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_RYLIST = strQuery
                Me.htxtRYLISTQuery.Value = Me.m_strQuery_RYLIST
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_RYLIST = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdRYLIST的数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIYIDONG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtRYLISTSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtRYLISTSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_YDJL Is Nothing Then
                    Me.grdRYLIST.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YDJL.Tables(strTable)
                        Me.grdRYLIST.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_YDJL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdRYLIST, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '如果是编辑模式
                If blnEditMode = True Then
                    '移动到最后记录
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            With Me.m_objDataSet_YDJL.Tables(strTable)
                                Dim intPageIndex As Integer
                                Dim intSelectIndex As Integer
                                If objDataGridProcess.doMoveToRecord(Me.grdRYLIST.AllowPaging, Me.grdRYLIST.PageSize, .DefaultView.Count - 1, intPageIndex, intSelectIndex) = False Then
                                    strErrMsg = "错误：无法移动到最后！"
                                    GoTo errProc
                                End If
                                Try
                                    Me.grdRYLIST.CurrentPageIndex = intPageIndex
                                    Me.grdRYLIST.SelectedIndex = intSelectIndex
                                Catch ex As Exception
                                End Try
                            End With
                        Case Else
                    End Select
                End If

                '允许列排序？
                Me.grdRYLIST.AllowSorting = Not blnEditMode

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdRYLIST)
                    With Me.grdRYLIST.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdRYLIST.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdRYLIST, Request, 0, Me.m_cstrCheckBoxIdInDataGrid) = False Then
                    GoTo errProc
                End If

                '如果是编辑模式
                If blnEditMode = True Then
                    '使能网格
                    If objDataGridProcess.doEnabledDataGrid(strErrMsg, Me.grdRYLIST, Not blnEditMode) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示编辑窗的数据(根据网格当前行数据显示)
        '     strErrMsg      ：返回错误信息
        '     strRYDM        ：人员代码
        '     blnEditMode    ：当前编辑状态
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditPanelInfo( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String, _
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
                    If Me.grdRYLIST.Items.Count < 1 Or Me.grdRYLIST.SelectedIndex < 0 Then
                        '*********************************************************************************************************************
                        Me.htxtWYBS.Value = ""
                        Me.htxtRYDM.Value = ""
                        Me.htxtGLBS.Value = ""
                        Me.htxtRZDW.Value = ""
                        Me.htxtYRDW.Value = ""
                        '*********************************************************************************************************************
                        Me.txtRYMC.Text = ""
                        Me.txtKSSJ.Text = ""
                        Me.txtJSSJ.Text = ""
                        Me.txtRZDW.Text = ""
                        Me.txtRZJB.Text = ""
                        Me.txtYRDW.Text = ""
                        Me.txtYRJB.Text = ""
                        Me.txtFGGZ.Text = ""
                        Me.txtBZXX.Text = ""
                        'zengxianglin 2008-10-14
                        Me.txtSSFZ.Text = ""
                        Me.txtYSFZ.Text = ""
                        'zengxianglin 2008-10-14
                        '*********************************************************************************************************************
                        Me.rblGWSX.SelectedIndex = 1
                        Me.rblJBBZ.SelectedIndex = 1
                        '*********************************************************************************************************************
                        Me.ddlYDYY.SelectedIndex = 1
                        Me.ddlZGSX.SelectedIndex = 1
                        '*********************************************************************************************************************
                        'zengxianglin 2010-01-06
                        Me.rblYGSX.SelectedIndex = 1
                        Me.rblBCZB.SelectedIndex = 0
                        Me.rblSCZB.SelectedIndex = 0
                        Me.ddlYZSX.SelectedIndex = 1
                        Me.txtXSTD.Text = ""
                        Me.txtYSTD.Text = ""
                        'zengxianglin 2010-01-06
                        '*********************************************************************************************************************
                    Else
                        Dim intColIndex As Integer = -1
                        '*********************************************************************************************************************
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_WYBS)
                        Me.htxtWYBS.Value = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYDM)
                        Me.htxtRYDM.Value = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GLBS)
                        Me.htxtGLBS.Value = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDW)
                        Me.htxtRZDW.Value = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRDW)
                        Me.htxtYRDW.Value = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        '*********************************************************************************************************************
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYMC)
                        Me.txtRYMC.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDWMC)
                        Me.txtRZDW.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZJB)
                        Me.txtRZJB.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRDWMC)
                        Me.txtYRDW.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRJB)
                        Me.txtYRJB.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_FGGZ)
                        Me.txtFGGZ.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BZXX)
                        Me.txtBZXX.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        'zengxianglin 2008-10-14
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SSFZ)
                        Me.txtSSFZ.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YSFZ)
                        Me.txtYSFZ.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        'zengxianglin 2008-10-14
                        '*********************************************************************************************************************
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_KSSJ)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        Me.txtKSSJ.Text = objPulicParameters.getObjectValue(strValue, "", "yyyy-MM-dd HH:mm:ss")
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZZSJ)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        Me.txtJSSJ.Text = objPulicParameters.getObjectValue(strValue, "", "yyyy-MM-dd HH:mm:ss")
                        '*********************************************************************************************************************
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSX)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        Me.rblGWSX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblGWSX, strValue)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZ)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        Me.rblJBBZ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblJBBZ, strValue)
                        '*********************************************************************************************************************
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYY)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        Me.ddlYDYY.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYDYY, strValue)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZGSX)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        Me.ddlZGSX.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZGSX, strValue)
                        '*********************************************************************************************************************
                        'zengxianglin 2010-01-06
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSX)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        Me.rblYGSX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYGSX, strValue)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BCZB)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        Me.rblBCZB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblBCZB, strValue)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SCZB)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        Me.rblSCZB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSCZB, strValue)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSX)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        Me.ddlYZSX.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYZSX, strValue)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_XSTD)
                        Me.txtXSTD.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YSTD)
                        Me.txtYSTD.Text = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                        'zengxianglin 2010-01-06
                        '*********************************************************************************************************************
                    End If
                Else
                    '编辑状态
                    '自动恢复数据
                End If
                If Me.m_strRYDM <> "" Then
                    Me.htxtRYDM.Value = Me.m_strRYDM
                    Me.txtRYMC.Text = Me.m_strRYMC
                End If

                '使能控件
                If Me.m_strRYDM <> "" Then
                    objControlProcess.doEnabledControl(Me.txtRYMC, False)
                    Me.btnSelect_RYDM.Visible = False
                Else
                    objControlProcess.doEnabledControl(Me.txtRYMC, False)
                    Me.btnSelect_RYDM.Visible = blnEditMode
                End If
                objControlProcess.doEnabledControl(Me.txtKSSJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJSSJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtRZDW, False)
                Me.btnSelect_RZDW.Visible = blnEditMode
                objControlProcess.doEnabledControl(Me.txtRZJB, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYRDW, False)
                Me.btnSelect_YRDW.Visible = blnEditMode
                objControlProcess.doEnabledControl(Me.txtYRJB, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtFGGZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBZXX, blnEditMode)
                'zengxianglin 2008-10-14
                objControlProcess.doEnabledControl(Me.txtSSFZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYSFZ, blnEditMode)
                'zengxianglin 2008-10-14
                '*********************************************************************************************************************
                objControlProcess.doEnabledControl(Me.rblGWSX, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblJBBZ, blnEditMode)
                '*********************************************************************************************************************
                objControlProcess.doEnabledControl(Me.ddlYDYY, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlZGSX, blnEditMode)
                '*********************************************************************************************************************
                'zengxianglin 2010-01-06
                objControlProcess.doEnabledControl(Me.ddlYZSX, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblYGSX, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblBCZB, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSCZB, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtXSTD, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYSTD, blnEditMode)
                'zengxianglin 2010-01-06
                '*********************************************************************************************************************
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
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示整个模块的信息
        '     strErrMsg      ：返回错误信息
        '     strRYDM        ：人员代码
        '     blnEditMode    ：当前编辑状态
        '     objenumEditType：详细操作模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIYIDONG
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData = False

            Try
                '显示网格信息
                If Me.showDataGridInfo(strErrMsg, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_YDJL.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblRYLISTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRYLIST, .Count)

                    '显示页面浏览功能
                    Me.lnkCZRYLISTMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdRYLIST, .Count) And (Not blnEditMode)
                    Me.lnkCZRYLISTMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdRYLIST, .Count) And (Not blnEditMode)
                    Me.lnkCZRYLISTMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdRYLIST, .Count) And (Not blnEditMode)
                    Me.lnkCZRYLISTMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdRYLIST, .Count) And (Not blnEditMode)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZRYLISTDeSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZRYLISTSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZRYLISTGotoPage.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZRYLISTSetPageSize.Enabled = blnEnabled And (Not blnEditMode)

                    objControlProcess.doEnabledControl(Me.txtRYLISTPageSize, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.txtRYLISTPageIndex, Not blnEditMode)

                    objControlProcess.doEnabledControl(Me.txtRYLISTSearch_RYDM, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.txtRYLISTSearch_YDSJMax, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.txtRYLISTSearch_YDSJMin, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.txtRYLISTSearch_RZDW, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.txtRYLISTSearch_YRDW, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.ddlRYLISTSearch_GWSX, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.ddlRYLISTSearch_YDYY, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.ddlRYLISTSearch_ZGSX, Not blnEditMode)

                    Me.btnRYLISTSearch.Enabled = Not blnEditMode
                    Me.btnRYLISTSearch_Full.Enabled = Not blnEditMode
                End With

                '显示输入窗信息
                If Me.showEditPanelInfo(strErrMsg, strRYDM, blnEditMode) = False Then
                    GoTo errProc
                End If

                '显示操作命令
                Me.btnAddNew.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1)
                Me.btnUpdate.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1)
                Me.btnDelete.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1)
                Me.btnPrint.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(2)
                Me.btnClose.Enabled = (Not blnEditMode)
                Me.btnSave.Visible = blnEditMode
                Me.btnCancel.Visible = blnEditMode
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充变动原因下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：True-加空条目
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillYdyyList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

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
                If objsystemEstateRenshiGeneral.getDataSet_BiandongYuanyin(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
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
        ' 填充职工类别下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：True-加空条目
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillZgsxList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_ZHIGONGSHUXING
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZgsxList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillZgsxList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemEstateRenshiGeneral.getDataSet_ZhigongShuxing(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
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
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXMC), "")

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

            doFillZgsxList = True
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

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                Try
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    '*********************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtRYLISTPageIndex)
                    objControlProcess.doTranslateKey(Me.txtRYLISTPageSize)
                    '*********************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtRYLISTSearch_RYDM)
                    objControlProcess.doTranslateKey(Me.txtRYLISTSearch_YDSJMin)
                    objControlProcess.doTranslateKey(Me.txtRYLISTSearch_YDSJMax)
                    objControlProcess.doTranslateKey(Me.txtRYLISTSearch_RZDW)
                    objControlProcess.doTranslateKey(Me.txtRYLISTSearch_YRDW)
                    objControlProcess.doTranslateKey(Me.ddlRYLISTSearch_GWSX)
                    objControlProcess.doTranslateKey(Me.ddlRYLISTSearch_YDYY)
                    objControlProcess.doTranslateKey(Me.ddlRYLISTSearch_ZGSX)
                    '*********************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtRYMC)
                    objControlProcess.doTranslateKey(Me.txtKSSJ)
                    objControlProcess.doTranslateKey(Me.txtJSSJ)
                    objControlProcess.doTranslateKey(Me.txtRZDW)
                    objControlProcess.doTranslateKey(Me.txtRZJB)
                    objControlProcess.doTranslateKey(Me.txtYRDW)
                    objControlProcess.doTranslateKey(Me.txtYRJB)
                    objControlProcess.doTranslateKey(Me.txtFGGZ)
                    objControlProcess.doTranslateKey(Me.txtBZXX)
                    'zengxianglin 2008-10-14
                    objControlProcess.doTranslateKey(Me.txtSSFZ)
                    objControlProcess.doTranslateKey(Me.txtYSFZ)
                    'zengxianglin 2008-10-14
                    '*********************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.ddlYDYY)
                    objControlProcess.doTranslateKey(Me.ddlZGSX)
                    '*********************************************************************************************************************
                    'zengxianglin 2010-01-06
                    objControlProcess.doTranslateKey(Me.ddlYZSX)
                    objControlProcess.doTranslateKey(Me.txtXSTD)
                    objControlProcess.doTranslateKey(Me.txtYSTD)
                    'zengxianglin 2010-01-06
                    '*********************************************************************************************************************

                    '获取数据
                    If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                    '显示数据
                    If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                If Me.doFillYdyyList(strErrMsg, Me.ddlRYLISTSearch_YDYY, True) = False Then
                    GoTo errProc
                End If
                If Me.doFillZgsxList(strErrMsg, Me.ddlRYLISTSearch_ZGSX, True) = False Then
                    GoTo errProc
                End If
                If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY, False) = False Then
                    GoTo errProc
                End If
                If Me.doFillZgsxList(strErrMsg, Me.ddlZGSX, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2010-01-06
                If Me.doFillZgsxList(strErrMsg, Me.ddlYZSX, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2010-01-06
            End If

            '获取接口参数
            If Me.getInterfaceParameters(strErrMsg) = False Then
                GoTo errProc
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
        '实现对网格行、列的固定
        Sub grdRYLIST_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdRYLIST.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns_RYLIST > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_RYLIST - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdRYLIST.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdRYLIST_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRYLIST.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblRYLISTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRYLIST, Me.m_intRows_RYLIST)
                '同步显示编辑窗信息
                If Me.showEditPanelInfo(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode) = False Then
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

        Private Sub grdRYLIST_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdRYLIST.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIYIDONG
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
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objDataSet_YDJL.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet_YDJL.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtRYLISTSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtRYLISTSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtRYLISTSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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













        Private Sub doMoveFirst(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdRYLIST.PageCount)
                Me.grdRYLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMoveLast(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRYLIST.PageCount - 1, Me.grdRYLIST.PageCount)
                Me.grdRYLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMoveNext(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRYLIST.CurrentPageIndex + 1, Me.grdRYLIST.PageCount)
                Me.grdRYLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMovePrevious(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRYLIST.CurrentPageIndex - 1, Me.grdRYLIST.PageCount)
                Me.grdRYLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doGotoPage(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtRYLISTPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdRYLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtRYLISTPageIndex.Text = (Me.grdRYLIST.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtRYLISTPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdRYLIST.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtRYLISTPageSize.Text = (Me.grdRYLIST.PageSize).ToString()

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

        Private Sub doSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRYLIST, 0, Me.m_cstrCheckBoxIdInDataGrid, True) = False Then
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

        Private Sub doDeSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRYLIST, 0, Me.m_cstrCheckBoxIdInDataGrid, False) = False Then
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

        Private Sub doSearch(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub lnkCZRYLISTMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTMoveFirst.Click
            Me.doMoveFirst("lnkCZRYLISTMoveFirst")
        End Sub

        Private Sub lnkCZRYLISTMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTMoveLast.Click
            Me.doMoveLast("lnkCZRYLISTMoveLast")
        End Sub

        Private Sub lnkCZRYLISTMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTMoveNext.Click
            Me.doMoveNext("lnkCZRYLISTMoveNext")
        End Sub

        Private Sub lnkCZRYLISTMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTMovePrev.Click
            Me.doMovePrevious("lnkCZRYLISTMovePrev")
        End Sub

        Private Sub lnkCZRYLISTGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTGotoPage.Click
            Me.doGotoPage("lnkCZRYLISTGotoPage")
        End Sub

        Private Sub lnkCZRYLISTSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTSetPageSize.Click
            Me.doSetPageSize("lnkCZRYLISTSetPageSize")
        End Sub

        Private Sub lnkCZRYLISTSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTSelectAll.Click
            Me.doSelectAll("lnkCZRYLISTSelectAll")
        End Sub

        Private Sub lnkCZRYLISTDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTDeSelectAll.Click
            Me.doDeSelectAll("lnkCZRYLISTDeSelectAll")
        End Sub

        Private Sub btnRYLISTSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYLISTSearch.Click
            Me.doSearch("btnRYLISTSearch")
        End Sub











        Private Sub doSelect_RYDM(ByVal strControlId As String)

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
                    .iMultiSelect = False
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

        Private Sub doSelect_RZDW(ByVal strControlId As String)

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

        Private Sub doSelect_YRDW(ByVal strControlId As String)

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

        Private Sub btnSelect_RYDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_RYDM.Click
            Me.doSelect_RYDM("btnSelect_RYDM")
        End Sub

        Private Sub btnSelect_RZDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_RZDW.Click
            Me.doSelect_RZDW("btnSelect_RZDW")
        End Sub

        Private Sub btnSelect_YRDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_YRDW.Click
            Me.doSelect_YRDW("btnSelect_YRDW")
        End Sub











        Private Sub doSearchFull(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIYIDONG

            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                    If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_YDJL.Tables(strTable)
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

        Private Sub btnRYLISTSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYLISTSearch_Full.Click
            Me.doSearchFull("btnRYLISTSearch_Full")
        End Sub













        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doAddNew(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '设置编辑模式
                Me.m_blnEditMode = True
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                Me.m_intCurrentPageIndex = Me.grdRYLIST.CurrentPageIndex
                Me.m_intCurrentSelectIndex = Me.grdRYLIST.SelectedIndex

                '保存相关信息
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()
                Me.htxtCurrentPage.Value = Me.m_intCurrentPageIndex.ToString()
                Me.htxtCurrentRow.Value = Me.m_intCurrentSelectIndex.ToString()

                '进入编辑状态
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '显示信息
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doUpdate(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                If Me.grdRYLIST.Items.Count < 1 Then
                    strErrMsg = "错误：没有内容可修改！"
                    GoTo errProc
                End If

                '设置编辑模式
                Me.m_blnEditMode = True
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                Me.m_intCurrentPageIndex = Me.grdRYLIST.CurrentPageIndex
                Me.m_intCurrentSelectIndex = Me.grdRYLIST.SelectedIndex

                '保存相关信息
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()
                Me.htxtCurrentPage.Value = Me.m_intCurrentPageIndex.ToString()
                Me.htxtCurrentRow.Value = Me.m_intCurrentSelectIndex.ToString()

                '进入编辑状态
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '显示信息
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doSave(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIYIDONG
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '获取新信息
                Dim objNewData As New System.Collections.Specialized.NameValueCollection
                '***************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_WYBS, Me.htxtWYBS.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYDM, Me.htxtRYDM.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GLBS, Me.htxtGLBS.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDW, Me.htxtRZDW.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRDW, Me.htxtYRDW.Value)
                '***************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_KSSJ, Me.txtKSSJ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZZSJ, Me.txtJSSJ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZJB, Me.txtRZJB.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRJB, Me.txtYRJB.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_FGGZ, Me.txtFGGZ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BZXX, Me.txtBZXX.Text)
                'zengxianglin 2008-10-14
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SSFZ, Me.txtSSFZ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YSFZ, Me.txtYSFZ.Text)
                'zengxianglin 2008-10-14
                '***************************************************************************************************************
                If Me.rblGWSX.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSX, Me.rblGWSX.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSX, "1")
                End If
                If Me.rblJBBZ.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZ, Me.rblJBBZ.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZ, "1")
                End If
                '***************************************************************************************************************
                If Me.ddlYDYY.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYY, Me.ddlYDYY.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYY, "")
                End If
                If Me.ddlZGSX.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZGSX, Me.ddlZGSX.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZGSX, "")
                End If
                '***************************************************************************************************************
                'zengxianglin 2010-01-06
                If Me.rblYGSX.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSX, Me.rblYGSX.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSX, "0")
                End If
                If Me.rblBCZB.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BCZB, Me.rblBCZB.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BCZB, "0")
                End If
                If Me.rblSCZB.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SCZB, Me.rblSCZB.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SCZB, "0")
                End If
                If Me.ddlYZSX.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSX, Me.ddlYZSX.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSX, "")
                End If
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_XSTD, Me.txtXSTD.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YSTD, Me.txtYSTD.Text)
                'zengxianglin 2010-01-06
                '***************************************************************************************************************

                '获取旧信息
                Dim objOldData As System.Data.DataRow = Nothing
                Dim intPos As Integer = 0
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        objOldData = Nothing
                        objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_WYBS) = ""
                    Case Else
                        '获取数据
                        If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                            GoTo errProc
                        End If
                        intPos = objDataGridProcess.getRecordPosition(Me.grdRYLIST.SelectedIndex, Me.grdRYLIST.CurrentPageIndex, Me.grdRYLIST.PageSize)
                        With Me.m_objDataSet_YDJL.Tables(strTable)
                            objOldData = .DefaultView.Item(intPos).Row
                        End With
                End Select

                '保存信息
                If objsystemEstateRenshiGeneral.doSaveData_RSKP_YDJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objNewData, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '记录审计日志
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_人事卡片]中增加了[变动记录]！")
                    Case Else
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]更改了[人事_人事卡片]中的[变动记录]！")
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
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '显示信息
                If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
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
                        Me.grdRYLIST.CurrentPageIndex = Me.m_intCurrentPageIndex
                        Me.grdRYLIST.SelectedIndex = Me.m_intCurrentSelectIndex
                    Catch ex As Exception
                    End Try

                    '进入非编辑状态
                    If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    '显示信息
                    If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doDelete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIYIDONG
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdRYLIST.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYLIST.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid) = True Then
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
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '逐个删除
                    Dim intColIndex As Integer = 0
                    Dim strWYBS As String = ""
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_WYBS)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYLIST.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid) = True Then
                            '获取信息
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(i), intColIndex)

                            '删除处理
                            If objsystemEstateRenshiGeneral.doDeleteData_RSKP_YDJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                                GoTo errProc
                            End If

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_人事卡片]的[变动记录]中删除了[" + strWYBS + "]！")
                        End If
                    Next

                    '重新获取数据
                    If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    '刷新网格显示
                    If Me.showModuleData(strErrMsg, Me.m_strRYDM, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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

        Private Sub doPrint(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIYIDONG
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strRYDM, Me.m_strQuery_RYLIST, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If
                If Me.m_objDataSet_YDJL.Tables(strTable) Is Nothing Then
                    strErrMsg = "错误：还未获取数据！"
                    GoTo errProc
                End If
                With Me.m_objDataSet_YDJL.Tables(strTable)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有数据！"
                        GoTo errProc
                    End If
                End With

                '准备Excel文件
                Dim strDesExcelPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
                Dim strSrcExcelSpec As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "广州兴业_人事管理_人事变动管理.xls"
                Dim strDesExcelFile As String = ""
                Dim strDesExcelSpec As String = ""
                strDesExcelPath = Server.MapPath(strDesExcelPath)
                strSrcExcelSpec = Server.MapPath(strSrcExcelSpec)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strSrcExcelSpec, strDesExcelPath, strDesExcelFile) = False Then
                    GoTo errProc
                End If
                strDesExcelSpec = objBaseLocalFile.doMakePath(strDesExcelPath, strDesExcelFile)

                '导出文件
                Dim strMacroValue As String = ""
                Dim strMacroName As String = ""
                strMacroName = "$Macro$QCRQ$,$Macro$QMRQ$,$Macro$GSMC$"
                strMacroValue = Me.txtRYLISTSearch_YDSJMin.Text + "," + Me.txtRYLISTSearch_YDSJMax.Text + "," + "兴业公司"
                If objsystemEstateRenshiGeneral.doExportToExcel(strErrMsg, Me.m_objDataSet_YDJL, strDesExcelSpec, strMacroName, strMacroValue) = False Then
                    GoTo errProc
                End If

                '打开临时Excel文件
                Dim strUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strDesExcelFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
        End Sub

        Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            Me.doAddNew("btnAddNew")
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Me.doUpdate("btnUpdate")
        End Sub

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Me.doDelete("btnDelete")
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

