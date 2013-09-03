
Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：qzbj_workflow_list
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身调用其他模块
    '
    ' 功能描述： 
    '   　工作流文件强制编辑处理模块
    '
    ' 接口参数：
    '     参见接口类IQzbjWorkFlowList描述
    '----------------------------------------------------------------

    Public Class gzsp_admin_bz
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

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "qzbj_workflow_previlege_param"
        Private m_blnPrevilegeParams(2) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JsKernal.BusinessFacade.IMQzbjWorkFlowList
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JsKernal.BusinessFacade.IQzbjWorkFlowList
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdWFLIST相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_WFLIST As String = "chkWFLIST"
        Private Const m_cstrDataGridInDIV_WFLIST As String = "divWFLIST"
        Private m_intFixedColumns_WFLIST As Integer

        Private Const m_cstrControlIdInDataGrid_LZXX_txtWJXX_BLZT As String = "txtWJXX_BLZT"
        Private Const m_cstrControlIdInDataGrid_LZXX_txtWJXX_QFR As String = "txtWJXX_QFR"
        Private Const m_cstrControlIdInDataGrid_LZXX_txtWJXX_QFRQ As String = "txtWJXX_QFRQ"

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objDataSet_WFLIST As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_WFLIST As String
        Private m_intRows_WFLIST As Integer













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
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtWFLISTQuery.Value = .htxtWFLISTQuery
                    Me.htxtWFLISTRows.Value = .htxtWFLISTRows
                    Me.htxtWFLISTSort.Value = .htxtWFLISTSort
                    Me.htxtWFLISTSortColumnIndex.Value = .htxtWFLISTSortColumnIndex
                    Me.htxtWFLISTSortType.Value = .htxtWFLISTSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftWFLIST.Value = .htxtDivLeftWFLIST
                    Me.htxtDivTopWFLIST.Value = .htxtDivTopWFLIST

                    Me.htxtWFLISTSessionIdQuery.Value = .htxtWFLISTSessionIdQuery

                    Me.txtWFLISTPageIndex.Text = .txtWFLISTPageIndex
                    Me.txtWFLISTPageSize.Text = .txtWFLISTPageSize

                    Me.txtWFLISTSearch_WJBT.Text = .txtWFLISTSearch_WJBT
                    Me.txtWFLISTSearch_LSH.Text = .txtWFLISTSearch_LSH
                    Me.txtWFLISTSearch_WJZH.Text = .txtWFLISTSearch_WJZH
                    Me.txtWFLISTSearch_ZBDW.Text = .txtWFLISTSearch_ZBDW
                    Me.txtWFLISTSearch_WJRQMin.Text = .txtWFLISTSearch_WJRQMin
                    Me.txtWFLISTSearch_WJRQMax.Text = .txtWFLISTSearch_WJRQMax
                    Me.ddlWFLISTSearch_WJLX.SelectedIndex = .ddlWFLISTSearch_WJLX_SelectedIndex

                    Try
                        Me.grdWFLIST.PageSize = .grdWFLISTPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWFLIST.CurrentPageIndex = .grdWFLISTCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWFLIST.SelectedIndex = .grdWFLISTSelectedIndex
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
                If strSessionId = "" Then
                    Exit Try
                End If

                '创建对象
                Me.m_objSaveScence = New Josco.JsKernal.BusinessFacade.IMQzbjWorkFlowList

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtWFLISTQuery = Me.htxtWFLISTQuery.Value
                    .htxtWFLISTRows = Me.htxtWFLISTRows.Value
                    .htxtWFLISTSort = Me.htxtWFLISTSort.Value
                    .htxtWFLISTSortColumnIndex = Me.htxtWFLISTSortColumnIndex.Value
                    .htxtWFLISTSortType = Me.htxtWFLISTSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftWFLIST = Me.htxtDivLeftWFLIST.Value
                    .htxtDivTopWFLIST = Me.htxtDivTopWFLIST.Value

                    .htxtWFLISTSessionIdQuery = Me.htxtWFLISTSessionIdQuery.Value

                    .txtWFLISTPageIndex = Me.txtWFLISTPageIndex.Text
                    .txtWFLISTPageSize = Me.txtWFLISTPageSize.Text

                    .txtWFLISTSearch_WJBT = Me.txtWFLISTSearch_WJBT.Text
                    .txtWFLISTSearch_LSH = Me.txtWFLISTSearch_LSH.Text
                    .txtWFLISTSearch_WJZH = Me.txtWFLISTSearch_WJZH.Text
                    .txtWFLISTSearch_ZBDW = Me.txtWFLISTSearch_ZBDW.Text
                    .txtWFLISTSearch_WJRQMin = Me.txtWFLISTSearch_WJRQMin.Text
                    .txtWFLISTSearch_WJRQMax = Me.txtWFLISTSearch_WJRQMax.Text
                    .ddlWFLISTSearch_WJLX_SelectedIndex = Me.ddlWFLISTSearch_WJLX.SelectedIndex

                    .grdWFLISTPageSize = Me.grdWFLIST.PageSize
                    .grdWFLISTCurrentPageIndex = Me.grdWFLIST.CurrentPageIndex
                    .grdWFLISTSelectedIndex = Me.grdWFLIST.SelectedIndex
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


                '==================================================================================================================================
                Dim objIEstateRsLuyongInfo As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo = Nothing
                Try
                    objIEstateRsLuyongInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo)
                Catch ex As Exception
                    objIEstateRsLuyongInfo = Nothing
                End Try
                If Not (objIEstateRsLuyongInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo.SafeRelease(objIEstateRsLuyongInfo)
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
                        Me.htxtWFLISTQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtWFLISTSessionIdQuery.Value.Trim = "" Then
                            Me.htxtWFLISTSessionIdQuery.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtWFLISTSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtWFLISTSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
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
                    If Me.m_objInterface.iInterfaceType = Josco.JSOA.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                        Me.m_objInterface.Dispose()
                        Me.m_objInterface = Nothing
                    End If
                End If
            Catch ex As Exception
            End Try

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
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JsKernal.BusinessFacade.IQzbjWorkFlowList)
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

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JsKernal.BusinessFacade.IMQzbjWorkFlowList)
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
                Me.m_intFixedColumns_WFLIST = objPulicParameters.getObjectValue(Me.htxtWFLISTFixed.Value, 0)
                Me.m_intRows_WFLIST = objPulicParameters.getObjectValue(Me.htxtWFLISTRows.Value, 0)
                Me.m_strQuery_WFLIST = Me.htxtWFLISTQuery.Value
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

            Try
                Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                If Me.htxtWFLISTSessionIdQuery.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtWFLISTSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtWFLISTSessionIdQuery.Value)
                End If
            Catch ex As Exception
            End Try

        End Sub














        '----------------------------------------------------------------
        ' 获取grdWFLIST的搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_WFLIST( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_WFLIST = False
            strQuery = ""

            Try
                '按“文件标题”搜索
                Dim strWJBT As String
                strWJBT = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBT
                If Me.txtWFLISTSearch_WJBT.Text.Length > 0 Then Me.txtWFLISTSearch_WJBT.Text = Me.txtWFLISTSearch_WJBT.Text.Trim()
                If Me.txtWFLISTSearch_WJBT.Text <> "" Then
                    Me.txtWFLISTSearch_WJBT.Text = objPulicParameters.getNewSearchString(Me.txtWFLISTSearch_WJBT.Text)
                    If strQuery = "" Then
                        strQuery = strWJBT + " like '" + Me.txtWFLISTSearch_WJBT.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWJBT + " like '" + Me.txtWFLISTSearch_WJBT.Text + "%'"
                    End If
                End If

                '按“流水号”搜索
                Dim strLSH As String
                strLSH = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_LSH
                If Me.txtWFLISTSearch_LSH.Text.Length > 0 Then Me.txtWFLISTSearch_LSH.Text = Me.txtWFLISTSearch_LSH.Text.Trim()
                If Me.txtWFLISTSearch_LSH.Text <> "" Then
                    Me.txtWFLISTSearch_LSH.Text = objPulicParameters.getNewSearchString(Me.txtWFLISTSearch_LSH.Text)
                    If strQuery = "" Then
                        strQuery = strLSH + " like '" + Me.txtWFLISTSearch_LSH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strLSH + " like '" + Me.txtWFLISTSearch_LSH.Text + "%'"
                    End If
                End If

                '按“文件字号”搜索
                Dim strWJZH As String
                strWJZH = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJZH
                If Me.txtWFLISTSearch_WJZH.Text.Length > 0 Then Me.txtWFLISTSearch_WJZH.Text = Me.txtWFLISTSearch_WJZH.Text.Trim()
                If Me.txtWFLISTSearch_WJZH.Text <> "" Then
                    Me.txtWFLISTSearch_WJZH.Text = objPulicParameters.getNewSearchString(Me.txtWFLISTSearch_WJZH.Text)
                    If strQuery = "" Then
                        strQuery = strWJZH + " like '" + Me.txtWFLISTSearch_WJZH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWJZH + " like '" + Me.txtWFLISTSearch_WJZH.Text + "%'"
                    End If
                End If

                '按“主办单位”搜索
                Dim strZBDW As String
                strZBDW = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_ZBDW
                If Me.txtWFLISTSearch_ZBDW.Text.Length > 0 Then Me.txtWFLISTSearch_ZBDW.Text = Me.txtWFLISTSearch_ZBDW.Text.Trim()
                If Me.txtWFLISTSearch_ZBDW.Text <> "" Then
                    Me.txtWFLISTSearch_ZBDW.Text = objPulicParameters.getNewSearchString(Me.txtWFLISTSearch_ZBDW.Text)
                    If strQuery = "" Then
                        strQuery = strZBDW + " like '" + Me.txtWFLISTSearch_ZBDW.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strZBDW + " like '" + Me.txtWFLISTSearch_ZBDW.Text + "%'"
                    End If
                End If

                '按“文件类型”搜索
                Dim strWJLX As String
                strWJLX = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJLX
                Select Case Me.ddlWFLISTSearch_WJLX.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strWJLX + " = '" + Me.ddlWFLISTSearch_WJLX.SelectedItem.Text + "'"
                        Else
                            strQuery = strQuery + " and " + strWJLX + " = '" + Me.ddlWFLISTSearch_WJLX.SelectedItem.Text + "'"
                        End If
                End Select

                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime

                '按“拟稿日期”搜索
                Dim strNGRQ As String
                strNGRQ = "convert(varchar(10),a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_NGRQ + ",120)"
                If Me.txtWFLISTSearch_WJRQMin.Text.Length > 0 Then Me.txtWFLISTSearch_WJRQMin.Text = Me.txtWFLISTSearch_WJRQMin.Text.Trim()
                If Me.txtWFLISTSearch_WJRQMax.Text.Length > 0 Then Me.txtWFLISTSearch_WJRQMax.Text = Me.txtWFLISTSearch_WJRQMax.Text.Trim()
                If Me.txtWFLISTSearch_WJRQMin.Text <> "" And Me.txtWFLISTSearch_WJRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtWFLISTSearch_WJRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtWFLISTSearch_WJRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtWFLISTSearch_WJRQMin.Text = Format(dateMax, "yyyy-MM-dd")
                        Me.txtWFLISTSearch_WJRQMax.Text = Format(dateMin, "yyyy-MM-dd")
                    Else
                        Me.txtWFLISTSearch_WJRQMin.Text = Format(dateMin, "yyyy-MM-dd")
                        Me.txtWFLISTSearch_WJRQMax.Text = Format(dateMax, "yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strNGRQ + " between '" + Me.txtWFLISTSearch_WJRQMin.Text + "' and '" + Me.txtWFLISTSearch_WJRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strNGRQ + " between '" + Me.txtWFLISTSearch_WJRQMin.Text + "' and '" + Me.txtWFLISTSearch_WJRQMax.Text + "'"
                    End If
                ElseIf Me.txtWFLISTSearch_WJRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtWFLISTSearch_WJRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    Me.txtWFLISTSearch_WJRQMin.Text = Format(dateMin, "yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strNGRQ + " >= '" + Me.txtWFLISTSearch_WJRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strNGRQ + " >= '" + Me.txtWFLISTSearch_WJRQMin.Text + "'"
                    End If
                ElseIf Me.txtWFLISTSearch_WJRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtWFLISTSearch_WJRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的日期！"
                        GoTo errProc
                    End Try
                    Me.txtWFLISTSearch_WJRQMax.Text = Format(dateMax, "yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strNGRQ + " <= '" + Me.txtWFLISTSearch_WJRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strNGRQ + " <= '" + Me.txtWFLISTSearch_WJRQMax.Text + "'"
                    End If
                Else
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_WFLIST = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdWFLIST要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_WFLIST( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW
            Dim objsystemEditWorkFlow As New Josco.JSOA.BusinessFacade.systemEditWorkFlow

            getModuleData_WFLIST = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtWFLISTSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.FlowData.SafeRelease(Me.m_objDataSet_WFLIST)

                '重新检索数据
                If objsystemEditWorkFlow.getDataSet_WFS(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_WFLIST) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_WFLIST.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_WFLIST.Tables(strTable)
                    Me.htxtWFLISTRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_WFLIST = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEditWorkFlow.SafeRelease(objsystemEditWorkFlow)

            getModuleData_WFLIST = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEditWorkFlow.SafeRelease(objsystemEditWorkFlow)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdWFLIST数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_WFLIST(ByRef strErrMsg As String) As Boolean

            searchModuleData_WFLIST = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_WFLIST(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_WFLIST(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_WFLIST = strQuery
                Me.htxtWFLISTQuery.Value = Me.m_strQuery_WFLIST
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_WFLIST = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdWFLIST的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_WFLIST(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_WFLIST = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtWFLISTSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtWFLISTSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_WFLIST Is Nothing Then
                    Me.grdWFLIST.DataSource = Nothing
                Else
                    With Me.m_objDataSet_WFLIST.Tables(strTable)
                        Me.grdWFLIST.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_WFLIST.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdWFLIST, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdWFLIST)
                    With Me.grdWFLIST.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdWFLIST.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdWFLIST, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_WFLIST) = False Then
                '    GoTo errProc
                'End If

                '显示未绑定数据
                If Me.showDataGridUnboundInfo_WJXX(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_WFLIST = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdWFLIST中的非绑定数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_WJXX( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_WJXX = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0

                intCount = Me.grdWFLIST.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdWFLIST.CurrentPageIndex, Me.grdWFLIST.PageSize)
                    objDataRow = Me.m_objDataSet_WFLIST.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充txtWJXX_BLZT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdWFLIST.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_LZXX_txtWJXX_BLZT), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_BLZT), "")
                        objTextBox.Text = strValue
                    End If

                    '填充txtWJXX_QFR
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdWFLIST.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_LZXX_txtWJXX_QFR), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_QFR), "")
                        objTextBox.Text = strValue
                    End If

                    '填充txtWJXX_QFRQ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdWFLIST.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_LZXX_txtWJXX_QFRQ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_QFRQ), "")
                        objTextBox.Text = strValue
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_WJXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdWFLIST中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnCheck       ：检查输入信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_WJXX( _
            ByRef strErrMsg As String, _
            Optional ByVal blnCheck As Boolean = False) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_WJXX = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdWFLIST.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdWFLIST.CurrentPageIndex, Me.grdWFLIST.PageSize)
                    objDataRow = Me.m_objDataSet_WFLIST.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充txtWJXX_BLZT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdWFLIST.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_LZXX_txtWJXX_BLZT), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            '不检查
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_BLZT) = objPulicParameters.getObjectValue(objTextBox.Text, "")
                    End If

                    '填充txtWJXX_QFR
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdWFLIST.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_LZXX_txtWJXX_QFR), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            '不检查
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_QFR) = objPulicParameters.getObjectValue(objTextBox.Text, "")
                    End If

                    '填充txtWJXX_QFRQ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdWFLIST.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_LZXX_txtWJXX_QFRQ), System.Web.UI.WebControls.TextBox)
                    If objTextBox.Text <> "" Then
                        If Not (objTextBox Is Nothing) Then
                            If blnCheck = True Then
                                '不检查
                            End If
                            objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_QFRQ) = objPulicParameters.getObjectValue(objTextBox.Text, "", "yyyy-MM-dd HH:mm:ss")
                        End If
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_WJXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdWFLIST及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_WFLIST(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_WFLIST = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_WFLIST(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_WFLIST.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblWFLISTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdWFLIST, .Count)

                    '显示页面浏览功能
                    Me.lnkCZWFLISTMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdWFLIST, .Count)
                    Me.lnkCZWFLISTMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdWFLIST, .Count)
                    Me.lnkCZWFLISTMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdWFLIST, .Count)
                    Me.lnkCZWFLISTMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdWFLIST, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZWFLISTDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZWFLISTSelectAll.Enabled = blnEnabled
                    Me.lnkCZWFLISTGotoPage.Enabled = blnEnabled
                    Me.lnkCZWFLISTSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_WFLIST = True
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
                Me.btnJJQK.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnSPQK.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnXGWJ.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnDelete.Visible = Me.m_blnPrevilegeParams(1)
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
        ' 填充工作流类型列表
        '----------------------------------------------------------------
        Private Function doFillWorkflowType( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim objList As System.Collections.Specialized.NameValueCollection = Nothing

            doFillWorkflowType = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    Exit Try
                End If

                '清空
                objDropDownList.Items.Clear()

                '加空
                If blnAddBlank = True Then
                    objDropDownList.Items.Add(" ")
                End If

                '加列表
                objList = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowTypeCollection()
                If objList Is Nothing Then
                    Exit Try
                End If
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim intCount As Integer = objList.Count
                Dim i As Integer = 0
                For i = 0 To intCount - 1 Step 1
                    objListItem = New System.Web.UI.WebControls.ListItem
                    objListItem.Value = objList.Item(i)
                    objListItem.Text = objList.Item(i)
                    objDropDownList.Items.Add(objListItem)
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doFillWorkflowType = True
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

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                '显示Pannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                '执行键转译(不论是否是“回发”)
                objControlProcess.doTranslateKey(Me.txtWFLISTPageIndex)
                objControlProcess.doTranslateKey(Me.txtWFLISTPageSize)
                '*************************************************************
                objControlProcess.doTranslateKey(Me.txtWFLISTSearch_WJBT)
                objControlProcess.doTranslateKey(Me.txtWFLISTSearch_LSH)
                objControlProcess.doTranslateKey(Me.txtWFLISTSearch_WJZH)
                objControlProcess.doTranslateKey(Me.txtWFLISTSearch_ZBDW)
                objControlProcess.doTranslateKey(Me.txtWFLISTSearch_WJRQMin)
                objControlProcess.doTranslateKey(Me.txtWFLISTSearch_WJRQMax)
                objControlProcess.doTranslateKey(Me.ddlWFLISTSearch_WJLX)

                '显示模块级操作
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示数据
                If Me.m_blnSaveScence = False Then
                    Me.txtWFLISTSearch_WJRQMin.Text = Now.Year.ToString + "-01-01"
                    Me.txtWFLISTSearch_WJRQMax.Text = Now.Year.ToString + "-12-31"
                    If Me.searchModuleData_WFLIST(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                        GoTo errProc
                    End If
                End If
                If Me.showModuleData_WFLIST(strErrMsg) = False Then
                    GoTo errProc
                End If
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

            Dim strUserID As String = ""
            Dim strPassword As String = ""
            Dim strNewPassword As String
            Dim intStep As Integer

            Dim objsystemCustomer As Josco.JsKernal.BusinessFacade.systemCustomer = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objCustomerData As Josco.JsKernal.Common.Data.CustomerData = Nothing

            Try
                strUserID = CStr(Request.QueryString("ID"))
                strPassword = CStr(Request.QueryString("password"))

                If strUserID <> "" Then
                    strPassword = CStr(Request.QueryString("password"))

                    '验证
                    objsystemCustomer = New Josco.JsKernal.BusinessFacade.systemCustomer
                    If objsystemCustomer.doVerifyUserPassword(strErrMsg, strUserID, strPassword, strNewPassword) = False Then
                        GoTo errProc
                    End If

                    '获取用户信息`
                    If objsystemCustomer.getRenyuanData(strErrMsg, strUserID, strPassword, "0011", objCustomerData) = False Then
                        GoTo errProc
                    End If

                    '记录凭证
                    System.Web.Security.FormsAuthentication.SetAuthCookie("*", False)

                    '缓存用户信息
                    MyBase.Customer = objCustomerData
                    MyBase.UserId = strUserID
                    MyBase.UserOrgPassword = strPassword
                    MyBase.UserPassword = strNewPassword
                    MyBase.UserEnterTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                    MyBase.LastScanTime_Chat = ""
                    MyBase.LastScanTime_Notice = ""

                    '检查密码长度
                    If MyBase.doCheckPassword() = True Then
                        Exit Sub
                    End If
                End If

                '预处理
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                '初始化工作流
                Dim m_objsystemFlowObjectRenshiRuZhi As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi
                If Me.doInitializeWorkflow(strErrMsg, "", False, m_objsystemFlowObjectRenshiRuZhi) = False Then
                    GoTo errProc
                End If


                '检查权限
                Dim blnDo As Boolean = False
                If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = False Then
                    GoTo normExit
                End If

                '初始化列表
                If Me.IsPostBack = False Then
                    If Me.doFillWorkflowType(strErrMsg, Me.ddlWFLISTSearch_WJLX, True) = False Then
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



        '----------------------------------------------------------------
        ' 初始化工作流对象
        '     strErrMsg                       ：返回错误信息
        '     strWJBS                         ：文件标识
        '     blnFill                         ：填充数据
        '     objsystemFlowObjectRenshiRuZhi ：工作流对象
        ' 返回
        '     True                            ：成功
        '     False                           ：失败
        '----------------------------------------------------------------
        Private Function doInitializeWorkflow( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String, _
            ByVal blnFill As Boolean, _
            ByRef objsystemFlowObjectRenshiRuZhi As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi) As Boolean

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject = Nothing

            doInitializeWorkflow = False
            strErrMsg = ""

            Try
                '释放现有资源
                Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi.SafeRelease(objsystemFlowObjectRenshiRuZhi)

                '创建工作流对象
                Dim strType As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWCODE
                Dim strName As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWNAME
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi.Create(strType, strName)

                '初始化工作流
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, blnFill) = False Then
                    GoTo errProc
                End If

                '返回
                objsystemFlowObjectRenshiRuZhi = CType(objsystemFlowObject, Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doInitializeWorkflow = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Josco.JSOA.Common.Data.FlowData.SafeRelease(Me.m_objDataSet_WFLIST)
        End Sub













        '----------------------------------------------------------------
        '网格事件处理器
        '----------------------------------------------------------------
        '实现对grdWFLIST网格行、列的固定
        Sub grdWFLIST_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdWFLIST.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_WFLIST + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_WFLIST > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_WFLIST - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdWFLIST.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdWFLIST_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdWFLIST.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '定位
                Me.grdWFLIST.SelectedIndex = e.Item.ItemIndex

                '处理
                Dim strControlId As String
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        If Me.doOpenFile(strErrMsg, strControlId) = False Then
                            GoTo errProc
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

        Private Sub grdWFLIST_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdWFLIST.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblWFLISTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdWFLIST, Me.m_intRows_WFLIST)
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

        Private Sub grdWFLIST_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdWFLIST.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW
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
                If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_WFLIST.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_WFLIST.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtWFLISTSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtWFLISTSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtWFLISTSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_WFLIST(strErrMsg) = False Then
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












        Private Sub doMoveFirst_WFLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdWFLIST.PageCount)
                Me.grdWFLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_WFLIST(strErrMsg) = False Then
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

        Private Sub doMoveLast_WFLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdWFLIST.PageCount - 1, Me.grdWFLIST.PageCount)
                Me.grdWFLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_WFLIST(strErrMsg) = False Then
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

        Private Sub doMoveNext_WFLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdWFLIST.CurrentPageIndex + 1, Me.grdWFLIST.PageCount)
                Me.grdWFLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_WFLIST(strErrMsg) = False Then
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

        Private Sub doMovePrevious_WFLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdWFLIST.CurrentPageIndex - 1, Me.grdWFLIST.PageCount)
                Me.grdWFLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_WFLIST(strErrMsg) = False Then
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

        Private Sub doGotoPage_WFLIST(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtWFLISTPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdWFLIST.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_WFLIST(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtWFLISTPageIndex.Text = (Me.grdWFLIST.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_WFLIST(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtWFLISTPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdWFLIST.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_WFLIST(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtWFLISTPageSize.Text = (Me.grdWFLIST.PageSize).ToString()

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

        Private Sub doSelectAll_WFLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdWFLIST, 0, Me.m_cstrCheckBoxIdInDataGrid_WFLIST, True) = False Then
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

        Private Sub doDeSelectAll_WFLIST(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdWFLIST, 0, Me.m_cstrCheckBoxIdInDataGrid_WFLIST, False) = False Then
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

        Private Sub doSearch_WFLIST(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_WFLIST(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_WFLIST(strErrMsg) = False Then
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

        Private Sub lnkCZWFLISTMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZWFLISTMoveFirst.Click
            Me.doMoveFirst_WFLIST("lnkCZWFLISTMoveFirst")
        End Sub

        Private Sub lnkCZWFLISTMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZWFLISTMoveLast.Click
            Me.doMoveLast_WFLIST("lnkCZWFLISTMoveLast")
        End Sub

        Private Sub lnkCZWFLISTMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZWFLISTMoveNext.Click
            Me.doMoveNext_WFLIST("lnkCZWFLISTMoveNext")
        End Sub

        Private Sub lnkCZWFLISTMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZWFLISTMovePrev.Click
            Me.doMovePrevious_WFLIST("lnkCZWFLISTMovePrev")
        End Sub

        Private Sub lnkCZWFLISTGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZWFLISTGotoPage.Click
            Me.doGotoPage_WFLIST("lnkCZWFLISTGotoPage")
        End Sub

        Private Sub lnkCZWFLISTSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZWFLISTSetPageSize.Click
            Me.doSetPageSize_WFLIST("lnkCZWFLISTSetPageSize")
        End Sub

        Private Sub lnkCZWFLISTSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZWFLISTSelectAll.Click
            Me.doSelectAll_WFLIST("lnkCZWFLISTSelectAll")
        End Sub

        Private Sub lnkCZWFLISTDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZWFLISTDeSelectAll.Click
            Me.doDeSelectAll_WFLIST("lnkCZWFLISTDeSelectAll")
        End Sub

        Private Sub btnWFLISTSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWFLISTSearch.Click
            Me.doSearch_WFLIST("btnWFLISTSearch")
        End Sub













        Private Sub doSearchFull_WFLIST(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            Try
                '获取数据
                If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                    GoTo errProc
                End If
                If Me.saveDataGridUnboundInfo_WJXX(strErrMsg, False) = False Then
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
                    If Me.htxtWFLISTSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtWFLISTSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_WFLIST.Tables(strTable)
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
                strUrl += "../sjcx/sjcx_cxtj.aspx"
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

        Private Sub btnWFLISTSearchFull_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWFLISTSearchFull.Click
            Me.doSearchFull_WFLIST("btnWFLISTSearchFull")
        End Sub














        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Function doCreateWorkflow( _
            ByRef strErrMsg As String, _
            ByRef objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            doCreateWorkflow = False
            objsystemFlowObject = Nothing
            strErrMsg = ""

            Try
                '检查当前选择
                If Me.grdWFLIST.Items.Count < 1 Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If
                If Me.grdWFLIST.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If

                '获取文件标识和文件类型
                Dim intColIndex() As Integer = {0, 0, 0}
                Dim strFlowTypeName As String = ""
                Dim strWJBS As String = ""
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdWFLIST, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBS)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdWFLIST, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJLX)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdWFLIST.Items(Me.grdWFLIST.SelectedIndex), intColIndex(0))
                strFlowTypeName = objDataGridProcess.getDataGridCellValue(Me.grdWFLIST.Items(Me.grdWFLIST.SelectedIndex), intColIndex(1))
                If strWJBS = "" Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If
                If strFlowTypeName = "" Then
                    strErrMsg = "错误：当前文件类型不明确！"
                    GoTo errProc
                End If

                '创建指定工作流对象
                Dim blnDo As Boolean = False
                Dim strType As String = ""
                Dim strName As String = ""
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, True) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doCreateWorkflow = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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
        Private Function doOpenFile( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim strMSessionId As String = ""
            Dim strISessionId As String = ""
            Dim strUrl As String = ""

            doOpenFile = False

            Try
                '创建工作流
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '计算Url
                If Me.m_blnInterface = True Then
                    strISessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
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
                Else
                    If objsystemFlowObject.doFileOpen( _
                        strErrMsg, _
                        strControlId, _
                        strWJBS, _
                        strMSessionId, _
                        "", _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect, _
                        Request, Session, _
                        strUrl) = False Then
                        GoTo errProc
                    End If
                End If
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doOpenFile = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 修改文件
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doUpdateFile( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim strMSessionId As String = ""
            Dim strISessionId As String = ""
            Dim strUrl As String = ""

            doUpdateFile = False

            Try
                '创建工作流
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '计算Url
                If Me.m_blnInterface = True Then
                    strISessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    If objsystemFlowObject.doFileOpen( _
                        strErrMsg, _
                        strControlId, _
                        strWJBS, _
                        strMSessionId, _
                        strISessionId, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, _
                        Request, Session, _
                        strUrl) = False Then
                        GoTo errProc
                    End If
                Else
                    If objsystemFlowObject.doFileOpen( _
                        strErrMsg, _
                        strControlId, _
                        strWJBS, _
                        strMSessionId, _
                        "", _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, _
                        Request, Session, _
                        strUrl) = False Then
                        GoTo errProc
                    End If
                End If
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doUpdateFile = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 删除文件
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doDeleteFile( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doDeleteFile = False

            Try
                '创建工作流
                If Me.grdWFLIST.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定文件！"
                    GoTo errProc
                End If
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS
                Dim i As Integer = Me.grdWFLIST.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strWJBT As String = ""
                Dim strLSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWFLIST, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_LSH)
                strLSH = objDataGridProcess.getDataGridCellValue(Me.grdWFLIST.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWFLIST, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBT)
                strWJBT = objDataGridProcess.getDataGridCellValue(Me.grdWFLIST.Items(i), intColIndex)

                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：一旦删除将无法撤销，确定要删除[流水号=" + strLSH + "]和[标题=" + strWJBT + "]吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '执行删除操作
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '执行操作
                    If objsystemFlowObject.doDeleteFile(strErrMsg, MyBase.UserId, MyBase.UserPassword) = False Then
                        GoTo errProc
                    End If

                    '刷新显示
                    If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_WFLIST(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doDeleteFile = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 返回上级
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doClose( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strUrl As String = ""

            doClose = False

            Try
                '返回到调用模块，并附加返回参数
                If Me.m_blnInterface = True Then
                    '返回值
                    Me.m_objInterface.oExitMode = False
                    '获取ISessionId
                    Dim strSessionId As String
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

            doClose = True
            Exit Function

errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Sub doOpen_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Try
                '获取接收人
                If Me.grdWFLIST.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有文件！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdWFLIST.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strTypeName As String = ""
                Dim strWJBS As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWFLIST, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJLX)
                strTypeName = objDataGridProcess.getDataGridCellValue(Me.grdWFLIST.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWFLIST, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBS)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdWFLIST.Items(i), intColIndex)
                Dim strType As String = ""
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strTypeName)
                If strType = "" Then
                    strErrMsg = "错误：不支持[" + strTypeName + "]工作流！！"
                    GoTo errProc
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIQzbjWorkFlowJjxx As Josco.JsKernal.BusinessFacade.IQzbjWorkFlowJjxx
                Dim strUrl As String
                objIQzbjWorkFlowJjxx = New Josco.JsKernal.BusinessFacade.IQzbjWorkFlowJjxx
                With objIQzbjWorkFlowJjxx
                    .iFlowTypeName = strTypeName
                    .iBLR = MyBase.UserXM
                    .iWJBS = strWJBS
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
                        strUrl += strMSessionId
                    Else
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIQzbjWorkFlowJjxx)
                strUrl = ""
                strUrl += "gzsp_admin_jjxx.aspx"
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

        Private Sub doOpen_SPXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Try
                '获取接收人
                If Me.grdWFLIST.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有文件！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdWFLIST.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strTypeName As String = ""
                Dim strWJBS As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWFLIST, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJLX)
                strTypeName = objDataGridProcess.getDataGridCellValue(Me.grdWFLIST.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWFLIST, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBS)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdWFLIST.Items(i), intColIndex)
                Dim strType As String = ""
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strTypeName)
                If strType = "" Then
                    strErrMsg = "错误：不支持[" + strTypeName + "]工作流！！"
                    GoTo errProc
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIQzbjWorkFlowSpxx As Josco.JsKernal.BusinessFacade.IQzbjWorkFlowSpxx
                Dim strUrl As String
                objIQzbjWorkFlowSpxx = New Josco.JsKernal.BusinessFacade.IQzbjWorkFlowSpxx
                With objIQzbjWorkFlowSpxx
                    .iFlowTypeName = strTypeName
                    .iBLR = MyBase.UserXM
                    .iWJBS = strWJBS
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
                        strUrl += strMSessionId
                    Else
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIQzbjWorkFlowSpxx)
                strUrl = ""
                strUrl += "gzsp_admin_spxx.aspx"
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

        Private Sub btnXGWJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXGWJ.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Try
                If Me.doUpdateFile(strErrMsg, "btnXGWJ") = False Then
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

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Try
                If Me.doDeleteFile(strErrMsg, "btnDelete") = False Then
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

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Try
                If Me.doClose(strErrMsg, "btnClose") = False Then
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0

            Try
                intStep = 1
                '检查
                If Me.grdWFLIST.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有记录！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdWFLIST.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strLSH As String = ""
                Dim strWJLX As String = ""

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWFLIST, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_LSH)
                strLSH = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdWFLIST.Items(i), intColIndex), "")

                intColIndex = 0
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWFLIST, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJLX)
                strWJLX = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdWFLIST.Items(i), intColIndex), "")

                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If

                intStep = 2
                '询问
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：您确定要修改[流水号=" + strLSH + "]的" + strWJLX + "内容吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '回答“是”
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    ''获取数据集
                    If Me.getModuleData_WFLIST(strErrMsg, Me.m_strQuery_WFLIST) = False Then
                        GoTo errProc
                    End If
                    If Me.saveDataGridUnboundInfo_WJXX(strErrMsg, True) = False Then
                        GoTo errProc
                    End If

                    '定位记录
                    Dim intPos As Integer = 0
                    With Me.grdWFLIST
                        intPos = objDataGridProcess.getRecordPosition(.SelectedIndex, .CurrentPageIndex, .PageSize)
                    End With
                    Dim objDataRow As System.Data.DataRow = Nothing
                    Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW
                    With Me.m_objDataSet_WFLIST.Tables(strTable)
                        objDataRow = .DefaultView.Item(intPos).Row
                    End With
                    If objDataRow Is Nothing Then
                        strErrMsg = "错误：没有记录！"
                        GoTo errProc
                    End If

                    '保存
                    objNewData = New System.Collections.Specialized.NameValueCollection
                    With objDataRow
                        objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_BLZT, objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_BLZT), ""))
                        objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_QFR, objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_QFR), ""))
                        objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_QFRQ, objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_QFRQ), "", "yyyy-MM-dd HH:mm:ss"))
                    End With
                    If objsystemFlowObject.doUpdateWJXX(strErrMsg, objNewData) = False Then
                        GoTo errProc
                    End If

                    '提示
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：修改成功！")
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnJJQK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJJQK.Click
            Me.doOpen_LZXX("btnJJQK")
        End Sub

        Private Sub btnSPQK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSPQK.Click
            Me.doOpen_SPXX("btnSPQK")
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Me.doUpdate("btnUpdate")
        End Sub
    End Class

End Namespace
