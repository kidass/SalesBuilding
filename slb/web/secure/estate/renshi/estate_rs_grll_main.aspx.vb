Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_grll_main
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　个人履历信息列表
    '
    ' QueryString参数描述： 
    '
    ' 接口参数：
    '     参见接口类IEstateRsGrllMain描述
    ' 更改记录：
    '     zengxianglin 2009-05-15 更改
    '----------------------------------------------------------------

    Partial Class estate_rs_grll_main
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
        '文件下载后的缓存路径
        Private m_cstrUrlBaseToFileCache As String = "/temp/filecache/"
        '打印模版相对于应用根的路径
        Private m_cstrExcelMBRelativePathToAppRoot As String = "/template/excel/"
        '打印文件缓存目录相对于应用根的路径
        Private m_cstrPrintCacheRelativePathToAppRoot As String = "/temp/printcache/"
        '应用根相对filecache的相对路径
        Private m_cstrPathRootToCache As String = "temp/filecache/"
        '应用根相对ziyuan/image/rskp的相对路径
        Private m_cstrPathRootToRskpImage As String = "ziyuan/image/rskp/"
        '应用根相对ziyuan/image/rskp的相对路径
        Private m_cstrPathRootToGrllImage As String = "ziyuan/image/grll/"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_grll_previlege_param"
        Private m_blnPrevilegeParams(5) As Boolean
        Private m_cstrPrevilegeParamPrefix1 As String = "estate_rs_rskp_previlege_param"
        Private m_blnPrevilegeParams1(2) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsGrllMain
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsGrllMain
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdRYLIST相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_RYLIST As String = "chkRYLIST"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_RYLIST As String = "divRYLIST"
        '网格要锁定的列数
        Private m_intFixedColumns_RYLIST As Integer

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objDataSet_RYLIST As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_strQuery_RYLIST As String '记录m_objDataSet_RYLIST搜索串
        Private m_intRows_RYLIST As Integer '记录m_objDataSet_RYLIST的DefaultView记录数


        '----------------------------------------------------------------
        '其他数据
        '----------------------------------------------------------------
        'zengxianglin 2009-05-15
        Private m_strFixQuery As String
        'zengxianglin 2009-05-15












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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsGrllMain)
                    Catch ex As Exception
                        Me.m_objInterface = Nothing
                    End Try
                Else
                    Me.m_objInterface = Nothing
                End If
                If Not (Me.m_objInterface Is Nothing) Then
                    '设置返回参数
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
                If Me.m_blnPrevilegeParams(0) = True And Me.m_blnPrevilegeParams(5) = True Then
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
        ' 获取权限参数
        '     strErrMsg          ：返回错误信息
        '     blnContinueExecute ：是否继续执行后续程序？
        ' 返回
        '     True               ：成功
        '     False              ：失败
        '----------------------------------------------------------------
        Private Function getPrevilegeParams1( _
            ByRef strErrMsg As String, _
            ByRef blnContinueExecute As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemAppManager As New Josco.JsKernal.BusinessFacade.systemAppManager
            Dim objMokuaiQXData As Josco.JsKernal.Common.Data.AppManagerData

            getPrevilegeParams1 = False
            blnContinueExecute = False

            Try
                Dim intCount As Integer
                Dim i As Integer

                '根据登录用户获取模块权限数据
                If MyBase.UserId.ToUpper() = "SA" Then
                    '管理员权限
                    intCount = Me.m_blnPrevilegeParams1.Length
                    For i = 0 To intCount - 1 Step 1
                        Me.m_blnPrevilegeParams1(i) = True
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
                    intCount = Me.m_blnPrevilegeParams1.Length
                    For i = 0 To intCount - 1 Step 1
                        '计算参数名
                        strParamName = i.ToString()
                        If strParamName.Length < 2 Then strParamName = "0" + strParamName
                        strParamName = Me.m_cstrPrevilegeParamPrefix1 + strParamName

                        '获取参数值
                        With objPulicParameters
                            strParamValue = .getObjectValue(Josco.JsKernal.Common.jsoaSecureConfiguration.ReadSetting(strParamName, ""), "")
                        End With
                        If i = 0 Then strFirstParamValue = strParamValue

                        '获取参数对应的权限
                        strFilter = strMKMC + " = '" + strParamValue + "'"
                        .DefaultView.RowFilter = strFilter
                        If .DefaultView.Count > 0 Then
                            Me.m_blnPrevilegeParams1(i) = True
                        Else
                            Me.m_blnPrevilegeParams1(i) = False
                        End If
                    Next

                End With
                blnContinueExecute = True
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemAppManager.SafeRelease(objsystemAppManager)
            Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objMokuaiQXData)

            getPrevilegeParams1 = True
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
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtRYLISTQuery.Value = .htxtRYLISTQuery
                    Me.htxtRYLISTRows.Value = .htxtRYLISTRows
                    Me.htxtRYLISTSort.Value = .htxtRYLISTSort
                    Me.htxtRYLISTSortColumnIndex.Value = .htxtRYLISTSortColumnIndex
                    Me.htxtRYLISTSortType.Value = .htxtRYLISTSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftRYLIST.Value = .htxtDivLeftRYLIST
                    Me.htxtDivTopRYLIST.Value = .htxtDivTopRYLIST

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtRYLISTPageIndex.Text = .txtRYLISTPageIndex
                    Me.txtRYLISTPageSize.Text = .txtRYLISTPageSize

                    Me.txtRYLISTSearch_MZ.Text = .txtRYLISTSearch_MZ
                    Me.txtRYLISTSearch_JGHJ.Text = .txtRYLISTSearch_JGHJ
                    Me.txtRYLISTSearch_NNMin.Text = .txtRYLISTSearch_NNMin
                    Me.txtRYLISTSearch_NNMax.Text = .txtRYLISTSearch_NNMax
                    'zengxianglin 2009-05-15
                    Me.txtRYLISTSearch_JLBH.Text = .txtRYLISTSearch_JLBH
                    Me.txtRYLISTSearch_RYXM.Text = .txtRYLISTSearch_RYXM
                    Me.txtRYLISTSearch_DJSJMin.Text = .txtRYLISTSearch_DJSJMin
                    Me.txtRYLISTSearch_DJSJMax.Text = .txtRYLISTSearch_DJSJMax
                    'zengxianglin 2009-05-15
                    Me.ddlRYLISTSearch_XB.SelectedIndex = .ddlRYLISTSearch_XB_SelectedIndex
                    Me.ddlRYLISTSearch_XL.SelectedIndex = .ddlRYLISTSearch_XL_SelectedIndex
                    Me.ddlRYLISTSearch_ZC.SelectedIndex = .ddlRYLISTSearch_ZC_SelectedIndex
                    Me.ddlRYLISTSearch_ZYZG.SelectedIndex = .ddlRYLISTSearch_ZYZG_SelectedIndex
                    Me.ddlRYLISTSearch_ZZMM.SelectedIndex = .ddlRYLISTSearch_ZZMM_SelectedIndex
                    Me.ddlRYLISTSearch_SFLY.SelectedIndex = .ddlRYLISTSearch_SFLY_SelectedIndex

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
                End With

                '释放资源
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

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
                If strSessionId = "" Then Exit Try

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsGrllMain

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtRYLISTQuery = Me.htxtRYLISTQuery.Value
                    .htxtRYLISTRows = Me.htxtRYLISTRows.Value
                    .htxtRYLISTSort = Me.htxtRYLISTSort.Value
                    .htxtRYLISTSortColumnIndex = Me.htxtRYLISTSortColumnIndex.Value
                    .htxtRYLISTSortType = Me.htxtRYLISTSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftRYLIST = Me.htxtDivLeftRYLIST.Value
                    .htxtDivTopRYLIST = Me.htxtDivTopRYLIST.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtRYLISTPageIndex = Me.txtRYLISTPageIndex.Text
                    .txtRYLISTPageSize = Me.txtRYLISTPageSize.Text

                    .txtRYLISTSearch_MZ = Me.txtRYLISTSearch_MZ.Text
                    .txtRYLISTSearch_JGHJ = Me.txtRYLISTSearch_JGHJ.Text
                    .txtRYLISTSearch_NNMin = Me.txtRYLISTSearch_NNMin.Text
                    .txtRYLISTSearch_NNMax = Me.txtRYLISTSearch_NNMax.Text
                    'zengxianglin 2009-05-15
                    .txtRYLISTSearch_JLBH = Me.txtRYLISTSearch_JLBH.Text
                    .txtRYLISTSearch_RYXM = Me.txtRYLISTSearch_RYXM.Text
                    .txtRYLISTSearch_DJSJMin = Me.txtRYLISTSearch_DJSJMin.Text
                    .txtRYLISTSearch_DJSJMax = Me.txtRYLISTSearch_DJSJMax.Text
                    'zengxianglin 2009-05-15
                    .ddlRYLISTSearch_XB_SelectedIndex = Me.ddlRYLISTSearch_XB.SelectedIndex
                    .ddlRYLISTSearch_XL_SelectedIndex = Me.ddlRYLISTSearch_XL.SelectedIndex
                    .ddlRYLISTSearch_ZC_SelectedIndex = Me.ddlRYLISTSearch_ZC.SelectedIndex
                    .ddlRYLISTSearch_ZYZG_SelectedIndex = Me.ddlRYLISTSearch_ZYZG.SelectedIndex
                    .ddlRYLISTSearch_ZZMM_SelectedIndex = Me.ddlRYLISTSearch_ZZMM.SelectedIndex
                    .ddlRYLISTSearch_SFLY_SelectedIndex = Me.ddlRYLISTSearch_SFLY.SelectedIndex

                    .grdRYLISTPageSize = Me.grdRYLIST.PageSize
                    .grdRYLISTCurrentPageIndex = Me.grdRYLIST.CurrentPageIndex
                    .grdRYLISTSelectedIndex = Me.grdRYLIST.SelectedIndex

                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateRsGrllInfo As Josco.JSOA.BusinessFacade.IEstateRsGrllInfo = Nothing
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

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
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

        End Sub

        '----------------------------------------------------------------
        ' 获取接口参数(没有接口参数则显示错误信息页面)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsGrllMain)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try

                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                End If

                'zengxianglin 2009-05-15
                '是售楼部人员？
                Dim blnIS As Boolean = False
                If objsystemCustomer.isFenghangRenyuan(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = True Then
                    '只能查看本部门登记的履历！
                    Me.m_strFixQuery = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_DJBM + " = '" + MyBase.UserBmdm + "'"
                Else
                    Me.m_strFixQuery = ""
                End If
                'zengxianglin 2009-05-15

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsGrllMain)
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

                '获取局部接口参数
                Me.m_intFixedColumns_RYLIST = objPulicParameters.getObjectValue(Me.htxtRYLISTFixed.Value, 0)
                Me.m_intRows_RYLIST = objPulicParameters.getObjectValue(Me.htxtRYLISTRows.Value, 0)
                Me.m_strQuery_RYLIST = Me.htxtRYLISTQuery.Value

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

        End Sub













        '----------------------------------------------------------------
        ' 获取grdRYLIST的搜索条件(默认表前缀a.)
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
                'zengxianglin 2009-05-15
                '按“简历编号”搜索
                Dim strJLBH As String
                strJLBH = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JLBH
                If Me.txtRYLISTSearch_JLBH.Text.Length > 0 Then Me.txtRYLISTSearch_JLBH.Text = Me.txtRYLISTSearch_JLBH.Text.Trim()
                If Me.txtRYLISTSearch_JLBH.Text <> "" Then
                    Me.txtRYLISTSearch_JLBH.Text = objPulicParameters.getNewSearchString(Me.txtRYLISTSearch_JLBH.Text)
                    If strQuery = "" Then
                        strQuery = strJLBH + " like '" + Me.txtRYLISTSearch_JLBH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJLBH + " like '" + Me.txtRYLISTSearch_JLBH.Text + "%'"
                    End If
                End If
                '按“姓名”搜索
                Dim strRYXM As String
                strRYXM = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XM
                If Me.txtRYLISTSearch_RYXM.Text.Length > 0 Then Me.txtRYLISTSearch_RYXM.Text = Me.txtRYLISTSearch_RYXM.Text.Trim()
                If Me.txtRYLISTSearch_RYXM.Text <> "" Then
                    Me.txtRYLISTSearch_RYXM.Text = objPulicParameters.getNewSearchString(Me.txtRYLISTSearch_RYXM.Text)
                    If strQuery = "" Then
                        strQuery = strRYXM + " like '" + Me.txtRYLISTSearch_RYXM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYXM + " like '" + Me.txtRYLISTSearch_RYXM.Text + "%'"
                    End If
                End If
                'zengxianglin 2009-05-15

                '按“民族”搜索
                Dim strMZ As String
                strMZ = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_MZ
                If Me.txtRYLISTSearch_MZ.Text.Length > 0 Then Me.txtRYLISTSearch_MZ.Text = Me.txtRYLISTSearch_MZ.Text.Trim()
                If Me.txtRYLISTSearch_MZ.Text <> "" Then
                    Me.txtRYLISTSearch_MZ.Text = objPulicParameters.getNewSearchString(Me.txtRYLISTSearch_MZ.Text)
                    If strQuery = "" Then
                        strQuery = strMZ + " like '" + Me.txtRYLISTSearch_MZ.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strMZ + " like '" + Me.txtRYLISTSearch_MZ.Text + "%'"
                    End If
                End If

                '按“籍贯”或“户籍”搜索
                Dim strJG As String
                Dim strHJ As String
                strJG = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JG
                strHJ = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_HJDZ
                If Me.txtRYLISTSearch_JGHJ.Text.Length > 0 Then Me.txtRYLISTSearch_JGHJ.Text = Me.txtRYLISTSearch_JGHJ.Text.Trim()
                If Me.txtRYLISTSearch_JGHJ.Text <> "" Then
                    Me.txtRYLISTSearch_JGHJ.Text = objPulicParameters.getNewSearchString(Me.txtRYLISTSearch_JGHJ.Text)
                    If strQuery = "" Then
                        strQuery = "(" + strJG + " like '" + Me.txtRYLISTSearch_JGHJ.Text + "%' or " + strHJ + " like '" + Me.txtRYLISTSearch_JGHJ.Text + "%')"
                    Else
                        strQuery = strQuery + " and " + "(" + strJG + " like '" + Me.txtRYLISTSearch_JGHJ.Text + "%' or " + strHJ + " like '" + Me.txtRYLISTSearch_JGHJ.Text + "%')"
                    End If
                End If

                '按“年龄”搜索
                Dim strNN As String
                Dim intMin As Integer
                Dim intMax As Integer
                strNN = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_NN
                If Me.txtRYLISTSearch_NNMin.Text.Length > 0 Then Me.txtRYLISTSearch_NNMin.Text = Me.txtRYLISTSearch_NNMin.Text.Trim()
                If Me.txtRYLISTSearch_NNMax.Text.Length > 0 Then Me.txtRYLISTSearch_NNMax.Text = Me.txtRYLISTSearch_NNMax.Text.Trim()
                If Me.txtRYLISTSearch_NNMin.Text <> "" And Me.txtRYLISTSearch_NNMax.Text <> "" Then
                    Try
                        intMin = CType(Me.txtRYLISTSearch_NNMin.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的年龄！"
                        GoTo errProc
                    End Try
                    Try
                        intMax = CType(Me.txtRYLISTSearch_NNMax.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的年龄！"
                        GoTo errProc
                    End Try
                    If intMin > intMax Then
                        Me.txtRYLISTSearch_NNMin.Text = intMax.ToString
                        Me.txtRYLISTSearch_NNMax.Text = intMin.ToString
                    Else
                        Me.txtRYLISTSearch_NNMin.Text = intMin.ToString
                        Me.txtRYLISTSearch_NNMax.Text = intMax.ToString
                    End If
                    If strQuery = "" Then
                        strQuery = strNN + " between " + Me.txtRYLISTSearch_NNMin.Text + " and " + Me.txtRYLISTSearch_NNMax.Text
                    Else
                        strQuery = strQuery + " and " + strNN + " between " + Me.txtRYLISTSearch_NNMin.Text + " and " + Me.txtRYLISTSearch_NNMax.Text
                    End If
                ElseIf Me.txtRYLISTSearch_NNMin.Text <> "" Then
                    Try
                        intMin = CType(Me.txtRYLISTSearch_NNMin.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的年龄！"
                        GoTo errProc
                    End Try
                    Me.txtRYLISTSearch_NNMin.Text = intMin.ToString
                    If strQuery = "" Then
                        strQuery = strNN + " >= " + Me.txtRYLISTSearch_NNMin.Text
                    Else
                        strQuery = strQuery + " and " + strNN + " >= " + Me.txtRYLISTSearch_NNMin.Text
                    End If
                ElseIf Me.txtRYLISTSearch_NNMax.Text <> "" Then
                    Try
                        intMax = CType(Me.txtRYLISTSearch_NNMax.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的年龄！"
                        GoTo errProc
                    End Try
                    Me.txtRYLISTSearch_NNMax.Text = intMax.ToString
                    If strQuery = "" Then
                        strQuery = strNN + " <= " + Me.txtRYLISTSearch_NNMax.Text
                    Else
                        strQuery = strQuery + " and " + strNN + " <= " + Me.txtRYLISTSearch_NNMax.Text
                    End If
                Else
                End If

                'zengxianglin 2009-05-15
                '按“登记时间”搜索
                Dim strDJSJ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strDJSJ = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_DJSJ
                If Me.txtRYLISTSearch_DJSJMin.Text.Length > 0 Then Me.txtRYLISTSearch_DJSJMin.Text = Me.txtRYLISTSearch_DJSJMin.Text.Trim()
                If Me.txtRYLISTSearch_DJSJMax.Text.Length > 0 Then Me.txtRYLISTSearch_DJSJMax.Text = Me.txtRYLISTSearch_DJSJMax.Text.Trim()
                If Me.txtRYLISTSearch_DJSJMin.Text <> "" And Me.txtRYLISTSearch_DJSJMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtRYLISTSearch_DJSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的[" + Me.txtRYLISTSearch_DJSJMin.Text + "]！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtRYLISTSearch_DJSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的[" + Me.txtRYLISTSearch_DJSJMax.Text + "]！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtRYLISTSearch_DJSJMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtRYLISTSearch_DJSJMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtRYLISTSearch_DJSJMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtRYLISTSearch_DJSJMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strDJSJ + " between '" + Me.txtRYLISTSearch_DJSJMin.Text + "' and '" + Me.txtRYLISTSearch_DJSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strDJSJ + " between '" + Me.txtRYLISTSearch_DJSJMin.Text + "' and '" + Me.txtRYLISTSearch_DJSJMax.Text + "'"
                    End If
                ElseIf Me.txtRYLISTSearch_DJSJMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtRYLISTSearch_DJSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的[" + Me.txtRYLISTSearch_DJSJMin.Text + "]！"
                        GoTo errProc
                    End Try
                    Me.txtRYLISTSearch_DJSJMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strDJSJ + " >= '" + Me.txtRYLISTSearch_DJSJMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strDJSJ + " >= '" + Me.txtRYLISTSearch_DJSJMin.Text + "'"
                    End If
                ElseIf Me.txtRYLISTSearch_DJSJMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtRYLISTSearch_DJSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的[" + Me.txtRYLISTSearch_DJSJMax.Text + "]！"
                        GoTo errProc
                    End Try
                    Me.txtRYLISTSearch_DJSJMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strDJSJ + " <= '" + Me.txtRYLISTSearch_DJSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strDJSJ + " <= '" + Me.txtRYLISTSearch_DJSJMax.Text + "'"
                    End If
                Else
                End If
                'zengxianglin 2009-05-15

                '按“录用”搜索
                Dim strSFLY As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_SFLY
                Select Case Me.ddlRYLISTSearch_SFLY.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFLY + " = '" + Me.ddlRYLISTSearch_SFLY.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strSFLY + " = '" + Me.ddlRYLISTSearch_SFLY.SelectedValue + "'"
                        End If
                End Select

                '按“性别”搜索
                Dim strXB As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XB
                Select Case Me.ddlRYLISTSearch_XB.SelectedIndex
                    Case 0, -1
                    Case Else
                        If strQuery = "" Then
                            strQuery = strXB + " = '" + Me.ddlRYLISTSearch_XB.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strXB + " = '" + Me.ddlRYLISTSearch_XB.SelectedValue + "'"
                        End If
                End Select

                '按“学历”搜索
                Dim strXL As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZGXL
                Select Case Me.ddlRYLISTSearch_XL.SelectedIndex
                    Case 0, -1
                    Case Else
                        If strQuery = "" Then
                            strQuery = strXL + " = '" + Me.ddlRYLISTSearch_XL.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strXL + " = '" + Me.ddlRYLISTSearch_XL.SelectedValue + "'"
                        End If
                End Select

                '按“职称”搜索
                Dim strZC As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JSZC
                Select Case Me.ddlRYLISTSearch_ZC.SelectedIndex
                    Case 0, -1
                    Case Else
                        If strQuery = "" Then
                            strQuery = strZC + " = '" + Me.ddlRYLISTSearch_ZC.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strZC + " = '" + Me.ddlRYLISTSearch_ZC.SelectedValue + "'"
                        End If
                End Select

                '按“职业资格”搜索
                Dim strZYZG As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZYZG
                Select Case Me.ddlRYLISTSearch_ZYZG.SelectedIndex
                    Case 0, -1
                    Case Else
                        If strQuery = "" Then
                            strQuery = strZYZG + " = '" + Me.ddlRYLISTSearch_ZYZG.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strZYZG + " = '" + Me.ddlRYLISTSearch_ZYZG.SelectedValue + "'"
                        End If
                End Select

                '按“政治面貌”搜索
                Dim strZZMM As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZZMM
                Select Case Me.ddlRYLISTSearch_ZZMM.SelectedIndex
                    Case 0, -1
                    Case Else
                        If strQuery = "" Then
                            strQuery = strZZMM + " = '" + Me.ddlRYLISTSearch_ZZMM.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strZZMM + " = '" + Me.ddlRYLISTSearch_ZZMM.SelectedValue + "'"
                        End If
                End Select
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
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_RYLIST( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye

            getModuleData_RYLIST = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtRYLISTSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RYLIST)

                '重新检索数据
                'zengxianglin 2009-05-15
                If Me.m_strFixQuery <> "" Then
                    If strWhere = "" Then
                        strWhere = Me.m_strFixQuery
                    Else
                        strWhere = strWhere + vbCr + " and " + Me.m_strFixQuery
                    End If
                End If
                'zengxianglin 2009-05-15
                If objsystemEstateRenshiXingye.getDataSet_GRLL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_RYLIST) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_RYLIST.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_RYLIST.Tables(strTable)
                    Me.htxtRYLISTRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_RYLIST = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)

            getModuleData_RYLIST = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdRYLIST数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_RYLIST(ByRef strErrMsg As String) As Boolean

            searchModuleData_RYLIST = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_RYLIST(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_RYLIST(strErrMsg, strQuery) = False Then
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
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_RYLIST(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_RYLIST = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = 0
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
                If Me.m_objDataSet_RYLIST Is Nothing Then
                    Me.grdRYLIST.DataSource = Nothing
                Else
                    With Me.m_objDataSet_RYLIST.Tables(strTable)
                        Me.grdRYLIST.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_RYLIST.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdRYLIST, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

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
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdRYLIST, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_RYLIST) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_RYLIST = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdRYLIST及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_RYLIST(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_RYLIST = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_RYLIST(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_RYLIST.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblRYLISTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRYLIST, .Count)

                    '显示页面浏览功能
                    Me.lnkCZRYLISTMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdRYLIST, .Count)
                    Me.lnkCZRYLISTMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdRYLIST, .Count)
                    Me.lnkCZRYLISTMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdRYLIST, .Count)
                    Me.lnkCZRYLISTMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdRYLIST, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZRYLISTDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZRYLISTSelectAll.Enabled = blnEnabled
                    Me.lnkCZRYLISTGotoPage.Enabled = blnEnabled
                    Me.lnkCZRYLISTSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_RYLIST = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示模块级的操作状态
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN(ByRef strErrMsg As String) As Boolean

            showModuleData_MAIN = False

            Try
                Me.btnAddNew.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnUpdate.Visible = Me.m_blnPrevilegeParams(1) Or Me.m_blnPrevilegeParams(4)
                Me.btnDelete.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnPrint.Visible = Me.m_blnPrevilegeParams(2)
                Me.btnAccept.Visible = Me.m_blnPrevilegeParams1(1)
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

            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                '显示Pannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                '执行键转译(不论是否是“回发”)
                objControlProcess.doTranslateKey(Me.txtRYLISTPageIndex)
                objControlProcess.doTranslateKey(Me.txtRYLISTPageSize)
                '************************************************
                objControlProcess.doTranslateKey(Me.txtRYLISTSearch_JGHJ)
                objControlProcess.doTranslateKey(Me.txtRYLISTSearch_MZ)
                objControlProcess.doTranslateKey(Me.txtRYLISTSearch_NNMin)
                objControlProcess.doTranslateKey(Me.txtRYLISTSearch_NNMax)
                'zengxianglin 2009-05-15
                objControlProcess.doTranslateKey(Me.txtRYLISTSearch_JLBH)
                objControlProcess.doTranslateKey(Me.txtRYLISTSearch_RYXM)
                objControlProcess.doTranslateKey(Me.txtRYLISTSearch_DJSJMin)
                objControlProcess.doTranslateKey(Me.txtRYLISTSearch_DJSJMax)
                'zengxianglin 2009-05-15
                '************************************************
                objControlProcess.doTranslateKey(Me.ddlRYLISTSearch_XB)
                objControlProcess.doTranslateKey(Me.ddlRYLISTSearch_XL)
                objControlProcess.doTranslateKey(Me.ddlRYLISTSearch_ZC)
                objControlProcess.doTranslateKey(Me.ddlRYLISTSearch_ZYZG)
                objControlProcess.doTranslateKey(Me.ddlRYLISTSearch_ZZMM)
                objControlProcess.doTranslateKey(Me.ddlRYLISTSearch_SFLY)

                '显示模块级操作
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '初始化
                If Me.m_blnSaveScence = False Then
                    'zengxianglin 2009-05-15
                    Me.txtRYLISTSearch_DJSJMin.Text = Now.Year.ToString + "-01-01"
                    If Me.searchModuleData_RYLIST(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2009-05-15
                Else
                    If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                        GoTo errProc
                    End If
                End If
                '显示数据
                If Me.showModuleData_RYLIST(strErrMsg) = False Then
                    GoTo errProc
                End If
            End If

            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function

errProc:
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充职称下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillJishuZhichengList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JISHUZHICHENG
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillJishuZhichengList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillJishuZhichengList]接口参数不正确！"
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
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)

            doFillJishuZhichengList = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
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
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)

            doFillZzmmList = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
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
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)

            doFillZyzgList = True
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

            '预处理
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '检查权限
            Dim blnDo As Boolean
            If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then
                GoTo normExit
            End If
            If Me.getPrevilegeParams1(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If

            '填充列表
            If Me.IsPostBack = False Then
                If Me.doFillJishuZhichengList(strErrMsg, Me.ddlRYLISTSearch_ZC) = False Then
                    GoTo errProc
                End If
                If Me.doFillXueliList(strErrMsg, Me.ddlRYLISTSearch_XL) = False Then
                    GoTo errProc
                End If
                If Me.doFillZyzgList(strErrMsg, Me.ddlRYLISTSearch_ZYZG) = False Then
                    GoTo errProc
                End If
                If Me.doFillZzmmList(strErrMsg, Me.ddlRYLISTSearch_ZZMM) = False Then
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
        '实现对grdRYLIST网格行、列的固定
        Sub grdRYLIST_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdRYLIST.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_RYLIST + ".scrollTop)")
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

        End Sub

        Private Sub grdRYLIST_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRYLIST.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblRYLISTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRYLIST, Me.m_intRows_RYLIST)
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

        Private Sub grdRYLIST_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdRYLIST.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdRYLIST.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        Me.doOpen(strControlId)
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

        Private Sub grdRYLIST_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdRYLIST.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI
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
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_RYLIST.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_RYLIST.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtRYLISTSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtRYLISTSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtRYLISTSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_RYLIST(strErrMsg) = False Then
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












        Private Sub doMoveFirst_RYLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdRYLIST.PageCount)
                Me.grdRYLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RYLIST(strErrMsg) = False Then
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

        Private Sub doMoveLast_RYLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRYLIST.PageCount - 1, Me.grdRYLIST.PageCount)
                Me.grdRYLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RYLIST(strErrMsg) = False Then
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

        Private Sub doMoveNext_RYLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRYLIST.CurrentPageIndex + 1, Me.grdRYLIST.PageCount)
                Me.grdRYLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RYLIST(strErrMsg) = False Then
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

        Private Sub doMovePrevious_RYLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRYLIST.CurrentPageIndex - 1, Me.grdRYLIST.PageCount)
                Me.grdRYLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RYLIST(strErrMsg) = False Then
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

        Private Sub doGotoPage_RYLIST(ByVal strControlId As String)

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
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdRYLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RYLIST(strErrMsg) = False Then
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

        Private Sub doSetPageSize_RYLIST(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtRYLISTPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdRYLIST.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_RYLIST(strErrMsg) = False Then
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

        Private Sub doSelectAll_RYLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRYLIST, 0, Me.m_cstrCheckBoxIdInDataGrid_RYLIST, True) = False Then
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

        Private Sub doDeSelectAll_RYLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRYLIST, 0, Me.m_cstrCheckBoxIdInDataGrid_RYLIST, False) = False Then
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

        Private Sub doSearch_RYLIST(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_RYLIST(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_RYLIST(strErrMsg) = False Then
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
            Me.doMoveFirst_RYLIST("lnkCZRYLISTMoveFirst")
        End Sub

        Private Sub lnkCZRYLISTMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTMoveLast.Click
            Me.doMoveLast_RYLIST("lnkCZRYLISTMoveLast")
        End Sub

        Private Sub lnkCZRYLISTMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTMoveNext.Click
            Me.doMoveNext_RYLIST("lnkCZRYLISTMoveNext")
        End Sub

        Private Sub lnkCZRYLISTMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTMovePrev.Click
            Me.doMovePrevious_RYLIST("lnkCZRYLISTMovePrev")
        End Sub

        Private Sub lnkCZRYLISTGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTGotoPage.Click
            Me.doGotoPage_RYLIST("lnkCZRYLISTGotoPage")
        End Sub

        Private Sub lnkCZRYLISTSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTSetPageSize.Click
            Me.doSetPageSize_RYLIST("lnkCZRYLISTSetPageSize")
        End Sub

        Private Sub lnkCZRYLISTSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTSelectAll.Click
            Me.doSelectAll_RYLIST("lnkCZRYLISTSelectAll")
        End Sub

        Private Sub lnkCZRYLISTDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYLISTDeSelectAll.Click
            Me.doDeSelectAll_RYLIST("lnkCZRYLISTDeSelectAll")
        End Sub

        Private Sub btnRYLISTSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYLISTSearch.Click
            Me.doSearch_RYLIST("btnRYLISTSearch")
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

        Private Sub doSearchFull(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI

            Try
                '获取数据
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
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
                    .iQueryTable = Me.m_objDataSet_RYLIST.Tables(strTable)
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

        Private Sub doPrint(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '获取数据集
                If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                    GoTo errProc
                End If
                If Me.m_objDataSet_RYLIST.Tables(strTable) Is Nothing Then
                    strErrMsg = "错误：还未获取数据！"
                    GoTo errProc
                End If
                With Me.m_objDataSet_RYLIST.Tables(strTable)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有数据！"
                        GoTo errProc
                    End If
                End With

                '检查模版文件
                Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "广州兴业_人事管理_求职履历管理.xls"
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
                strMacroValue = Me.txtRYLISTSearch_NNMin.Text + "," + Me.txtRYLISTSearch_NNMax.Text + "," + "兴业公司"
                If objsystemEstateRenshiXingye.doExportToExcel(strErrMsg, Me.m_objDataSet_RYLIST, strTempSpec, strMacroName, strMacroValue, "yyyy-MM-dd") = False Then
                    GoTo errProc
                End If

                '显示Excel
                Dim strTempUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strTempFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strTempUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doAddNew(ByVal strControlId As String)

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
                Dim objIEstateRsGrllInfo As Josco.JSOA.BusinessFacade.IEstateRsGrllInfo = Nothing
                Dim strUrl As String = ""
                objIEstateRsGrllInfo = New Josco.JSOA.BusinessFacade.IEstateRsGrllInfo
                With objIEstateRsGrllInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iRYDM = ""
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
                Session.Add(strNewSessionId, objIEstateRsGrllInfo)

                strUrl = ""
                strUrl += "estate_rs_grll_info.aspx"
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

        Private Sub doUpdate(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.grdRYLIST.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定人员！"
                    GoTo errProc
                End If
                Dim intColIndex As Integer = -1
                Dim strRYDM As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RYDM)
                strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                strRYDM = strRYDM.Trim
                If strRYDM = "" Then
                    strErrMsg = "错误：没有选定人员！"
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
                Dim objIEstateRsGrllInfo As Josco.JSOA.BusinessFacade.IEstateRsGrllInfo = Nothing
                Dim strUrl As String = ""
                objIEstateRsGrllInfo = New Josco.JSOA.BusinessFacade.IEstateRsGrllInfo
                With objIEstateRsGrllInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iRYDM = strRYDM
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
                Session.Add(strNewSessionId, objIEstateRsGrllInfo)

                strUrl = ""
                strUrl += "estate_rs_grll_info.aspx"
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
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpen(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.grdRYLIST.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定人员！"
                    GoTo errProc
                End If
                Dim intColIndex As Integer = -1
                Dim strRYDM As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RYDM)
                strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex)
                strRYDM = strRYDM.Trim
                If strRYDM = "" Then
                    strErrMsg = "错误：没有选定人员！"
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
                Dim objIEstateRsGrllInfo As Josco.JSOA.BusinessFacade.IEstateRsGrllInfo = Nothing
                Dim strUrl As String = ""
                objIEstateRsGrllInfo = New Josco.JSOA.BusinessFacade.IEstateRsGrllInfo
                With objIEstateRsGrllInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iRYDM = strRYDM
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
                Session.Add(strNewSessionId, objIEstateRsGrllInfo)

                strUrl = ""
                strUrl += "estate_rs_grll_info.aspx"
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
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDelete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
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
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYLIST.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYLIST) = True Then
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
                    Dim strPrefix As String = Request.ApplicationPath + "/"
                    Dim intColIndex(2) As Integer
                    Dim strWYBS As String = ""
                    Dim strRYDM As String = ""
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_WYBS)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RYDM)
                    intRows = Me.grdRYLIST.Items.Count
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYLIST.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYLIST) = True Then
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(i), intColIndex(0))
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(i), intColIndex(1))

                            '删除处理
                            If objsystemEstateRenshiXingye.doDeleteData_GRLL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS, Server, strPrefix) = False Then
                                GoTo errProc
                            End If

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_求职履历]字典中删除了[" + strRYDM + "]的资料！")
                        End If
                    Next

                    '重新获取数据
                    If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                        GoTo errProc
                    End If

                    '刷新网格显示
                    If Me.showModuleData_RYLIST(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

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
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_JLBH)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RYDM)
                intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XM)
                intColIndex(3) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYLIST, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_NYBM)
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intCount = Me.grdRYLIST.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYLIST.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYLIST) = True Then
                            strJLBH = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex(0))
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex(1))
                            strRYXM = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex(2))
                            strNYBM = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex(3))
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
                    intCount = Me.grdRYLIST.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYLIST.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYLIST) = True Then
                            strJLBH = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex(0))
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex(1))
                            strRYXM = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex(2))
                            strNYBM = objDataGridProcess.getDataGridCellValue(Me.grdRYLIST.Items(Me.grdRYLIST.SelectedIndex), intColIndex(3))

                            '录用处理
                            If objsystemEstateRenshiGeneral.doLuyong(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJLBH, Server, Request.ApplicationPath, Me.m_cstrPathRootToRskpImage) = False Then
                                GoTo errProc
                            End If
                        End If
                    Next

                    '显示
                    If Me.getModuleData_RYLIST(strErrMsg, Me.m_strQuery_RYLIST) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_RYLIST(strErrMsg) = False Then
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

        Private Sub btnRYLISTSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYLISTSearch_Full.Click
            Me.doSearchFull("btnRYLISTSearch_Full")
        End Sub

        Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpen.Click
            Me.doOpen("btnOpen")
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

        Private Sub btnAccept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccept.Click
            Me.doAccept("btnAccept")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Me.doPrint("btnPrint")
        End Sub

    End Class

End Namespace
