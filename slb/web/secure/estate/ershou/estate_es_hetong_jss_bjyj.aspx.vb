Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_hetong_jss_bjyj
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“结算书补计佣金”处理模块
    '----------------------------------------------------------------

    Partial Class estate_es_hetong_jss_bjyj
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsHetongJssBjyj
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsHetongJssBjyj
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdJSS相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_JSS As String = "chkJSS"
        Private Const m_cstrDataGridInDIV_JSS As String = "divJSS"
        Private m_intFixedColumns_JSS As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_JSS As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_JSS As String
        Private m_intRows_JSS As Integer

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_strJSSH As String
        Private m_strQRSH As String

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------
        Private m_strFixQuery As String
        Private m_blnQxControl As Boolean

        Public ReadOnly Property propQRSH() As String
            Get
                propQRSH = Me.m_strQRSH
            End Get
        End Property

        Public ReadOnly Property propJSSH() As String
            Get
                propJSSH = Me.m_strJSSH
            End Get
        End Property











        Private Sub doGoBack(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                If strSessionId Is Nothing Then strSessionId = ""
                If strSessionId <> "" Then
                    Try
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsHetongJssBjyj)
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

                '是否继续执行
                If Me.m_blnPrevilegeParams(9) = True Then
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
                    Me.htxtDivLeftJSS.Value = .htxtDivLeftJSS
                    Me.htxtDivTopJSS.Value = .htxtDivTopJSS

                    Me.htxtJSSQuery.Value = .htxtJSSQuery
                    Me.htxtJSSRows.Value = .htxtJSSRows
                    Me.htxtJSSSort.Value = .htxtJSSSort
                    Me.htxtJSSSortColumnIndex.Value = .htxtJSSSortColumnIndex
                    Me.htxtJSSSortType.Value = .htxtJSSSortType

                    Me.txtJSSSearch_JSSH.Text = .txtJSSSearch_JSSH
                    Me.txtJSSSearch_QRSH.Text = .txtJSSSearch_QRSH
                    Me.txtJSSSearch_HTRQMax.Text = .txtJSSSearch_HTRQMax
                    Me.txtJSSSearch_HTRQMin.Text = .txtJSSSearch_HTRQMin
                    Me.ddlJSSSearch_HTZT.SelectedIndex = .ddlJSSSearch_HTZT_SelectedIndex

                    Me.txtJSSPageIndex.Text = .txtJSSPageIndex
                    Me.txtJSSPageSize.Text = .txtJSSPageSize

                    Try
                        Me.grdJSS.PageSize = .grdJSSPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJSS.CurrentPageIndex = .grdJSSCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJSS.SelectedIndex = .grdJSSSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdQueryJSS.Value = .htxtSessionIdQueryJSS
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsHetongJssBjyj

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftJSS = Me.htxtDivLeftJSS.Value
                    .htxtDivTopJSS = Me.htxtDivTopJSS.Value

                    .htxtJSSQuery = Me.htxtJSSQuery.Value
                    .htxtJSSRows = Me.htxtJSSRows.Value
                    .htxtJSSSort = Me.htxtJSSSort.Value
                    .htxtJSSSortColumnIndex = Me.htxtJSSSortColumnIndex.Value
                    .htxtJSSSortType = Me.htxtJSSSortType.Value

                    .txtJSSSearch_JSSH = Me.txtJSSSearch_JSSH.Text
                    .txtJSSSearch_QRSH = Me.txtJSSSearch_QRSH.Text
                    .txtJSSSearch_HTRQMax = Me.txtJSSSearch_HTRQMax.Text
                    .txtJSSSearch_HTRQMin = Me.txtJSSSearch_HTRQMin.Text
                    .ddlJSSSearch_HTZT_SelectedIndex = Me.ddlJSSSearch_HTZT.SelectedIndex

                    .txtJSSPageIndex = Me.txtJSSPageIndex.Text
                    .txtJSSPageSize = Me.txtJSSPageSize.Text

                    .grdJSSPageSize = Me.grdJSS.PageSize
                    .grdJSSCurrentPageIndex = Me.grdJSS.CurrentPageIndex
                    .grdJSSSelectedIndex = Me.grdJSS.SelectedIndex
                    .htxtSessionIdQueryJSS = Me.htxtSessionIdQueryJSS.Value
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
                Dim objIEstateEsHetongJssInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo = Nothing
                Try
                    objIEstateEsHetongJssInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo)
                Catch ex As Exception
                    objIEstateEsHetongJssInfo = Nothing
                End Try
                If Not (objIEstateEsHetongJssInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo.SafeRelease(objIEstateEsHetongJssInfo)
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
                        Me.htxtJSSQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQueryJSS.Value.Trim = "" Then
                            Me.htxtSessionIdQueryJSS.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQueryJSS.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtSessionIdQueryJSS.Value, objISjcxCxtj.oDataSetTJ)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsHetongJssBjyj)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_strQRSH = ""
                    Me.m_strJSSH = ""
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_strQRSH = Me.m_objInterface.iQRSH
                    Me.m_strJSSH = Me.m_objInterface.iJSSH
                End If

                '判断当前人员是否为分行人员
                Dim blnIS As Boolean = True
                If objsystemCustomer.isFenghangRenyuan(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = True Then
                    Me.m_blnQxControl = True '进行特殊权限控制
                Else
                    Me.m_blnQxControl = False
                End If
                Me.m_strFixQuery = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JYRQ + " is null"

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsHetongJssBjyj)
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

                Me.m_strQuery_JSS = Me.htxtJSSQuery.Value
                Me.m_intRows_JSS = objPulicParameters.getObjectValue(Me.htxtJSSRows.Value, 0)
                Me.m_intFixedColumns_JSS = objPulicParameters.getObjectValue(Me.htxtJSSFixed.Value, 0)
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
                If Me.htxtSessionIdQueryJSS.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQueryJSS.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQueryJSS.Value)
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
        Private Function getQueryString_JSS( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strTempWhere As String = ""

            getQueryString_JSS = False
            strQuery = ""

            Try
                '按“确认书号”搜索
                Dim strQRSH As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_QRSH
                If Me.txtJSSSearch_QRSH.Text.Length > 0 Then Me.txtJSSSearch_QRSH.Text = Me.txtJSSSearch_QRSH.Text.Trim()
                If Me.txtJSSSearch_QRSH.Text <> "" Then
                    Me.txtJSSSearch_QRSH.Text = objPulicParameters.getNewSearchString(Me.txtJSSSearch_QRSH.Text)
                    strTempWhere = strQRSH + " like '" + Me.txtJSSSearch_QRSH.Text + "%'"
                    If strQuery = "" Then
                        strQuery = strTempWhere
                    Else
                        strQuery = strQuery + " and " + strTempWhere
                    End If
                End If

                '按“结算书号”搜索
                Dim strJSSH As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH
                If Me.txtJSSSearch_JSSH.Text.Length > 0 Then Me.txtJSSSearch_JSSH.Text = Me.txtJSSSearch_JSSH.Text.Trim()
                If Me.txtJSSSearch_JSSH.Text <> "" Then
                    Me.txtJSSSearch_JSSH.Text = objPulicParameters.getNewSearchString(Me.txtJSSSearch_JSSH.Text)
                    strTempWhere = strJSSH + " like '" + Me.txtJSSSearch_JSSH.Text + "%'"
                    If strQuery = "" Then
                        strQuery = strTempWhere
                    Else
                        strQuery = strQuery + " and " + strTempWhere
                    End If
                End If

                '按“状态标志”搜索
                Dim strZTBZ As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZ
                Select Case Me.ddlJSSSearch_HTZT.SelectedIndex
                    Case Is > 0
                        strTempWhere = strZTBZ + Me.ddlJSSSearch_HTZT.SelectedValue
                        If strQuery = "" Then
                            strQuery = strTempWhere
                        Else
                            strQuery = strQuery + " and " + strTempWhere
                        End If
                    Case Else
                End Select

                '按“结算日期”搜索
                Dim strJSRQ As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSRQ
                If objControlProcess.getQueryStringDatetime(strErrMsg, Me.txtJSSSearch_HTRQMin, Me.txtJSSSearch_HTRQMax, strJSRQ, strTempWhere) = False Then
                    GoTo errProc
                End If
                If strQuery = "" Then
                    strQuery = strTempWhere
                Else
                    strQuery = strQuery + " and " + strTempWhere
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            getQueryString_JSS = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdJSS要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strJSSH        ：结算书号
        '     strWhere       ：搜索字符串
        '     blnControl     ：特殊权限控制
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_JSS( _
            ByRef strErrMsg As String, _
            ByVal strJSSH As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_JSS = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtJSSSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_JSS)

                '固定搜索串
                If Me.m_strFixQuery <> "" Then
                    If strWhere <> "" Then
                        strWhere = Me.m_strFixQuery
                    Else
                        strWhere = strWhere + " and " + Me.m_strFixQuery
                    End If
                End If

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_HETONG_JSS(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJSSH, strWhere, blnControl, Me.m_objDataSet_JSS) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_JSS.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_JSS.Tables(strTable)
                    Me.htxtJSSRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_JSS = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_JSS = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据grdJSS的当前行获取QRSH
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQRSH( _
            ByRef strErrMsg As String, _
            ByRef strQRSH As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getQRSH = False
            strErrMsg = ""
            strQRSH = ""

            Try
                If Me.grdJSS.SelectedIndex >= 0 Then
                    Dim i As Integer = Me.grdJSS.SelectedIndex
                    Dim intColIndex As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJSS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_QRSH)
                    strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdJSS.Items(i), intColIndex)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getQRSH = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据grdJSS的当前行获取JSSH
        '     strErrMsg      ：返回错误信息
        '     strJSSH        ：结算书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getJSSH( _
            ByRef strErrMsg As String, _
            ByRef strJSSH As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getJSSH = False
            strErrMsg = ""
            strJSSH = ""

            Try
                If Me.grdJSS.SelectedIndex >= 0 Then
                    Dim i As Integer = Me.grdJSS.SelectedIndex
                    Dim intColIndex As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJSS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH)
                    strJSSH = objDataGridProcess.getDataGridCellValue(Me.grdJSS.Items(i), intColIndex)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getJSSH = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据grdJSS的当前行获取strJSBS
        '     strErrMsg      ：返回错误信息
        '     strJSBS        ：结算标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getJSBS( _
            ByRef strErrMsg As String, _
            ByRef strJSBS As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getJSBS = False
            strErrMsg = ""
            strJSBS = ""

            Try
                If Me.grdJSS.SelectedIndex >= 0 Then
                    Dim i As Integer = Me.grdJSS.SelectedIndex
                    Dim intColIndex As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJSS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_WYBS)
                    strJSBS = objDataGridProcess.getDataGridCellValue(Me.grdJSS.Items(i), intColIndex)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getJSBS = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdJSS数据
        '     strErrMsg      ：返回错误信息
        '     strJSSH        ：结算书号
        '     blnControl     ：特殊权限控制
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_JSS( _
            ByRef strErrMsg As String, _
            ByVal strJSSH As String, _
            ByVal blnControl As Boolean) As Boolean

            searchModuleData_JSS = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_JSS(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_JSS(strErrMsg, strJSSH, strQuery, blnControl) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_JSS = strQuery
                Me.htxtJSSQuery.Value = Me.m_strQuery_JSS
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_JSS = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdJSS的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_JSS( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_JSS = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtJSSSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtJSSSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_JSS Is Nothing Then
                    Me.grdJSS.DataSource = Nothing
                Else
                    With Me.m_objDataSet_JSS.Tables(strTable)
                        Me.grdJSS.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_JSS.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdJSS, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdJSS)
                    With Me.grdJSS.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdJSS.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                ''恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdJSS, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_JSS) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_JSS = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdJSS及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_JSS( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_JSS = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_JSS(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_JSS.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblJSSGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdJSS, .Count)

                    '显示页面浏览功能
                    Me.lnkCZJSSMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdJSS, .Count)
                    Me.lnkCZJSSMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdJSS, .Count)
                    Me.lnkCZJSSMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdJSS, .Count)
                    Me.lnkCZJSSMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdJSS, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZJSSDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZJSSSelectAll.Enabled = blnEnabled
                    Me.lnkCZJSSGotoPage.Enabled = blnEnabled
                    Me.lnkCZJSSSetPageSize.Enabled = blnEnabled
                End With

                '同步显示
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.showJiaoyiInfo(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_Main(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_JSS = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
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
        ' 显示模块其他信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String) As Boolean

            showModuleData_Main = False

            Try
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                Dim strJSSH As String = ""
                If Me.getJSSH(strErrMsg, strJSSH) = False Then
                    GoTo errProc
                End If

                Me.btnBJYJ.Visible = Me.m_blnPrevilegeParams(9) And strQRSH <> "" And strJSSH <> ""
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
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtJSSPageIndex)
                    objControlProcess.doTranslateKey(Me.txtJSSPageSize)
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtJSSSearch_JSSH)
                    objControlProcess.doTranslateKey(Me.txtJSSSearch_QRSH)
                    objControlProcess.doTranslateKey(Me.txtJSSSearch_HTRQMin)
                    objControlProcess.doTranslateKey(Me.txtJSSSearch_HTRQMax)
                    objControlProcess.doTranslateKey(Me.ddlJSSSearch_HTZT)
                    '********************************************************

                    If Me.m_blnSaveScence = False Then
                        If Me.m_strJSSH = "" Then
                            Me.txtJSSSearch_HTRQMin.Text = Now.Year.ToString + "-01-01"
                            If Me.searchModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_blnQxControl) = False Then
                                GoTo errProc
                            End If
                        Else
                            If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
                                GoTo errProc
                            End If
                        End If
                    Else
                        If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
                            GoTo errProc
                        End If
                    End If
                    If Me.showModuleData_JSS(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_Main(strErrMsg) = False Then
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
            Dim blnDo As Boolean

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
        Sub grdJSS_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdJSS.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_JSS + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_JSS > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_JSS - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdJSS.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdJSS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdJSS.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblJSSGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdJSS, Me.m_intRows_JSS)

                '同步显示
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.showJiaoyiInfo(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_Main(strErrMsg) = False Then
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

        Private Sub grdJSS_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdJSS.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU
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
                If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objDataSet_JSS.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet_JSS.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtJSSSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtJSSSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtJSSSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_JSS(strErrMsg) = False Then
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

        Private Sub grdJSS_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdJSS.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdJSS.SelectedIndex = e.Item.ItemIndex

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














        Private Sub doMoveFirst(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdJSS.PageCount)
                Me.grdJSS.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JSS(strErrMsg) = False Then
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
                If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJSS.PageCount - 1, Me.grdJSS.PageCount)
                Me.grdJSS.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JSS(strErrMsg) = False Then
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
                If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJSS.CurrentPageIndex + 1, Me.grdJSS.PageCount)
                Me.grdJSS.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JSS(strErrMsg) = False Then
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
                If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJSS.CurrentPageIndex - 1, Me.grdJSS.PageCount)
                Me.grdJSS.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JSS(strErrMsg) = False Then
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
            intPageIndex = objPulicParameters.getObjectValue(Me.txtJSSPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdJSS.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JSS(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtJSSPageIndex.Text = (Me.grdJSS.CurrentPageIndex + 1).ToString()
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
            intPageSize = objPulicParameters.getObjectValue(Me.txtJSSPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdJSS.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_JSS(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtJSSPageSize.Text = (Me.grdJSS.PageSize).ToString()
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdJSS, 0, Me.m_cstrCheckBoxIdInDataGrid_JSS, True) = False Then
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdJSS, 0, Me.m_cstrCheckBoxIdInDataGrid_JSS, False) = False Then
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
                If Me.searchModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_JSS(strErrMsg) = False Then
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

        Private Sub lnkCZJSSMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJSSMoveFirst.Click
            Me.doMoveFirst("lnkCZJSSMoveFirst")
        End Sub

        Private Sub lnkCZJSSMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJSSMoveLast.Click
            Me.doMoveLast("lnkCZJSSMoveLast")
        End Sub

        Private Sub lnkCZJSSMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJSSMoveNext.Click
            Me.doMoveNext("lnkCZJSSMoveNext")
        End Sub

        Private Sub lnkCZJSSMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJSSMovePrev.Click
            Me.doMovePrevious("lnkCZJSSMovePrev")
        End Sub

        Private Sub lnkCZJSSGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJSSGotoPage.Click
            Me.doGotoPage("lnkCZJSSGotoPage")
        End Sub

        Private Sub lnkCZJSSSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJSSSetPageSize.Click
            Me.doSetPageSize("lnkCZJSSSetPageSize")
        End Sub

        Private Sub lnkCZJSSSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJSSSelectAll.Click
            Me.doSelectAll("lnkCZJSSSelectAll")
        End Sub

        Private Sub lnkCZJSSDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJSSDeSelectAll.Click
            Me.doDeSelectAll("lnkCZJSSDeSelectAll")
        End Sub

        Private Sub btnJSSSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSSSearch.Click
            Me.doSearch("btnJSSSearch")
        End Sub











        Private Sub doSearchFull(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '获取数据
                If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
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
                    If Me.htxtSessionIdQueryJSS.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQueryJSS.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_JSS.Tables(strTable)
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

        Private Sub btnJSSSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSSSearch_Full.Click
            Me.doSearchFull("btnJSSSearch_Full")
        End Sub













        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doOpen(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.grdJSS.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定[合同]！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdJSS.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim intHTZT As Integer = 0
                Dim strQRSH As String = ""
                Dim strJSSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJSS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZ)
                intHTZT = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdJSS.Items(i), intColIndex), 0)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJSS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdJSS.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJSS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH)
                strJSSH = objDataGridProcess.getDataGridCellValue(Me.grdJSS.Items(i), intColIndex)

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String = ""
                Dim objIEstateEsHetongJssInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo = Nothing
                objIEstateEsHetongJssInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo
                With objIEstateEsHetongJssInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iJSSH = strJSSH
                    .iQRSH = strQRSH
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
                Session.Add(strNewSessionId, objIEstateEsHetongJssInfo)
                strUrl = ""
                strUrl += "estate_es_hetong_jss_info.aspx"
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

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    '返回到调用模块，并附加返回参数
                    Me.m_objInterface.oExitMode = False
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

        Private Sub doBJYJ(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                intStep = 1
                '检查
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If strQRSH = "" Then
                    strErrMsg = "错误：没有选定[确认书]！"
                    GoTo errProc
                End If
                Dim strJSBS As String = ""
                If Me.getJSBS(strErrMsg, strJSBS) = False Then
                    GoTo errProc
                End If
                If strJSBS = "" Then
                    strErrMsg = "错误：没有选定[结算书]！"
                    GoTo errProc
                End If

                intStep = 2
                '输入计佣日期
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doInputBox(Me.popMessageObject, "请输入准备在哪天结佣：", strControlId, intStep, Now.ToString("yyyy-MM-dd"))
                    Exit Try
                End If

                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取输入信息
                    Dim strJYRQ As String = ""
                    strJYRQ = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
                    If strJYRQ = "" Then
                        strErrMsg = "错误：没有输入[计佣日期]！"
                        GoTo errProc
                    End If
                    If objPulicParameters.isDatetimeString(strJYRQ) = False Then
                        strErrMsg = "错误：无效的[计佣日期][" + strJYRQ + "]！"
                        GoTo errProc
                    End If

                    '事务处理
                    If objsystemEstateErshou.doUpdate_ES_HETONG_JSS_JYRQ(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJSBS, strJYRQ) = False Then
                        GoTo errProc
                    End If

                    '刷新显示
                    If Me.getModuleData_JSS(strErrMsg, Me.m_strJSSH, Me.m_strQuery_JSS, Me.m_blnQxControl) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_JSS(strErrMsg) = False Then
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

        Private Sub btnBJYJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBJYJ.Click
            Me.doBJYJ("btnBJYJ")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
