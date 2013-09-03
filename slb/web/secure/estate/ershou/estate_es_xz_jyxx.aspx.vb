Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_xz_jyxx
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　选择业务编号信息
    '
    ' QueryString参数描述： 
    '
    ' 接口参数：
    '     参见接口类IEstateEsXzJyxx描述
    '----------------------------------------------------------------

    Partial Class estate_es_xz_jyxx
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

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsXzJyxx
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsXzJyxx
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdJYXX相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_JYXX As String = "chkJYXX"
        Private Const m_cstrDataGridInDIV_JYXX As String = "divJYXX"
        Private m_intFixedColumns_JYXX As Integer

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objDataSet_JYXX As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_JYXX As String
        Private m_intRows_JYXX As Integer

        '----------------------------------------------------------------
        '接口数据
        '----------------------------------------------------------------
        Private m_blnQxControl As Boolean

        '----------------------------------------------------------------
        '接口数据
        '----------------------------------------------------------------
        Private m_blnAllowNull As Boolean











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsXzJyxx)
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

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtJYXXQuery.Value = .htxtJYXXQuery
                    Me.htxtJYXXRows.Value = .htxtJYXXRows
                    Me.htxtJYXXSort.Value = .htxtJYXXSort
                    Me.htxtJYXXSortColumnIndex.Value = .htxtJYXXSortColumnIndex
                    Me.htxtJYXXSortType.Value = .htxtJYXXSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftJYXX.Value = .htxtDivLeftJYXX
                    Me.htxtDivTopJYXX.Value = .htxtDivTopJYXX

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtJYXXPageIndex.Text = .txtJYXXPageIndex
                    Me.txtJYXXPageSize.Text = .txtJYXXPageSize

                    Me.txtJYXXSearch_KHMC.Text = .txtJYXXSearch_KHMC
                    Me.txtJYXXSearch_YZMC.Text = .txtJYXXSearch_YZMC
                    Me.txtJYXXSearch_JYBH.Text = .txtJYXXSearch_JYBH
                    Me.txtJYXXSearch_WYDZ.Text = .txtJYXXSearch_WYDZ
                    Me.txtJYXXSearch_JYRQMin.Text = .txtJYXXSearch_JYRQMin
                    Me.txtJYXXSearch_JYRQMax.Text = .txtJYXXSearch_JYRQMax
                    Me.txtJYXXSearch_HTRQMin.Text = .txtJYXXSearch_HTRQMin
                    Me.txtJYXXSearch_HTRQMax.Text = .txtJYXXSearch_HTRQMax

                    Try
                        Me.grdJYXX.PageSize = .grdJYXXPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJYXX.CurrentPageIndex = .grdJYXXCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJYXX.SelectedIndex = .grdJYXXSelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsXzJyxx

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtJYXXQuery = Me.htxtJYXXQuery.Value
                    .htxtJYXXRows = Me.htxtJYXXRows.Value
                    .htxtJYXXSort = Me.htxtJYXXSort.Value
                    .htxtJYXXSortColumnIndex = Me.htxtJYXXSortColumnIndex.Value
                    .htxtJYXXSortType = Me.htxtJYXXSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftJYXX = Me.htxtDivLeftJYXX.Value
                    .htxtDivTopJYXX = Me.htxtDivTopJYXX.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtJYXXPageIndex = Me.txtJYXXPageIndex.Text
                    .txtJYXXPageSize = Me.txtJYXXPageSize.Text

                    .txtJYXXSearch_KHMC = Me.txtJYXXSearch_KHMC.Text
                    .txtJYXXSearch_YZMC = Me.txtJYXXSearch_YZMC.Text
                    .txtJYXXSearch_WYDZ = Me.txtJYXXSearch_WYDZ.Text
                    .txtJYXXSearch_JYBH = Me.txtJYXXSearch_JYBH.Text
                    .txtJYXXSearch_JYRQMin = Me.txtJYXXSearch_JYRQMin.Text
                    .txtJYXXSearch_JYRQMax = Me.txtJYXXSearch_JYRQMax.Text
                    .txtJYXXSearch_HTRQMin = Me.txtJYXXSearch_HTRQMin.Text
                    .txtJYXXSearch_HTRQMax = Me.txtJYXXSearch_HTRQMax.Text

                    .grdJYXXPageSize = Me.grdJYXX.PageSize
                    .grdJYXXCurrentPageIndex = Me.grdJYXX.CurrentPageIndex
                    .grdJYXXSelectedIndex = Me.grdJYXX.SelectedIndex

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
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                        Me.htxtJYXXQuery.Value = objISjcxCxtj.oQueryString
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsXzJyxx)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try

                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_blnAllowNull = Me.m_objInterface.iAllowNull
                End If
                If Me.m_blnInterface = False Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "错误：没有提供本模块需要的接口信息！"
                    Exit Try
                End If

                '计算是否进行查看限制
                Dim blnIS As Boolean = True
                If objsystemCustomer.isFenghangRenyuan(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, blnIS) = False Then
                    GoTo errProc
                End If
                Me.m_blnQxControl = blnIS

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsXzJyxx)
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
                Me.m_intFixedColumns_JYXX = objPulicParameters.getObjectValue(Me.htxtJYXXFixed.Value, 0)
                Me.m_intRows_JYXX = objPulicParameters.getObjectValue(Me.htxtJYXXRows.Value, 0)
                Me.m_strQuery_JYXX = Me.htxtJYXXQuery.Value

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
        ' 获取grdJYXX的搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_JYXX( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_JYXX = False
            strQuery = ""

            Try
                '按“客户名称”搜索
                Dim strKHMC As String
                strKHMC = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_KHMC
                If Me.txtJYXXSearch_KHMC.Text.Length > 0 Then Me.txtJYXXSearch_KHMC.Text = Me.txtJYXXSearch_KHMC.Text.Trim()
                If Me.txtJYXXSearch_KHMC.Text <> "" Then
                    Me.txtJYXXSearch_KHMC.Text = objPulicParameters.getNewSearchString(Me.txtJYXXSearch_KHMC.Text)
                    If strQuery = "" Then
                        strQuery = strKHMC + " like '" + Me.txtJYXXSearch_KHMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strKHMC + " like '" + Me.txtJYXXSearch_KHMC.Text + "%'"
                    End If
                End If

                '按“业主名称”搜索
                Dim strYZMC As String
                strYZMC = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YZMC
                If Me.txtJYXXSearch_YZMC.Text.Length > 0 Then Me.txtJYXXSearch_YZMC.Text = Me.txtJYXXSearch_YZMC.Text.Trim()
                If Me.txtJYXXSearch_YZMC.Text <> "" Then
                    Me.txtJYXXSearch_YZMC.Text = objPulicParameters.getNewSearchString(Me.txtJYXXSearch_YZMC.Text)
                    If strQuery = "" Then
                        strQuery = strYZMC + " like '" + Me.txtJYXXSearch_YZMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strYZMC + " like '" + Me.txtJYXXSearch_YZMC.Text + "%'"
                    End If
                End If

                '按“交易编号”搜索
                Dim strJYBH As String
                strJYBH = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH
                If Me.txtJYXXSearch_JYBH.Text.Length > 0 Then Me.txtJYXXSearch_JYBH.Text = Me.txtJYXXSearch_JYBH.Text.Trim()
                If Me.txtJYXXSearch_JYBH.Text <> "" Then
                    Me.txtJYXXSearch_JYBH.Text = objPulicParameters.getNewSearchString(Me.txtJYXXSearch_JYBH.Text)
                    If strQuery = "" Then
                        strQuery = strJYBH + " like '" + Me.txtJYXXSearch_JYBH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJYBH + " like '" + Me.txtJYXXSearch_JYBH.Text + "%'"
                    End If
                End If

                '按“物业地址”搜索
                Dim strWYDZ As String
                strWYDZ = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYDZ
                If Me.txtJYXXSearch_WYDZ.Text.Length > 0 Then Me.txtJYXXSearch_WYDZ.Text = Me.txtJYXXSearch_WYDZ.Text.Trim()
                If Me.txtJYXXSearch_WYDZ.Text <> "" Then
                    Me.txtJYXXSearch_WYDZ.Text = objPulicParameters.getNewSearchString(Me.txtJYXXSearch_WYDZ.Text)
                    If strQuery = "" Then
                        strQuery = strWYDZ + " like '" + Me.txtJYXXSearch_WYDZ.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWYDZ + " like '" + Me.txtJYXXSearch_WYDZ.Text + "%'"
                    End If
                End If

                '按“交易日期”搜索
                Dim strJYRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strJYRQ = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYRQ
                If Me.txtJYXXSearch_JYRQMin.Text.Length > 0 Then Me.txtJYXXSearch_JYRQMin.Text = Me.txtJYXXSearch_JYRQMin.Text.Trim()
                If Me.txtJYXXSearch_JYRQMax.Text.Length > 0 Then Me.txtJYXXSearch_JYRQMax.Text = Me.txtJYXXSearch_JYRQMax.Text.Trim()
                If Me.txtJYXXSearch_JYRQMin.Text <> "" And Me.txtJYXXSearch_JYRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtJYXXSearch_JYRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtJYXXSearch_JYRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtJYXXSearch_JYRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtJYXXSearch_JYRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtJYXXSearch_JYRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtJYXXSearch_JYRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strJYRQ + " between '" + Me.txtJYXXSearch_JYRQMin.Text + "' and '" + Me.txtJYXXSearch_JYRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJYRQ + " between '" + Me.txtJYXXSearch_JYRQMin.Text + "' and '" + Me.txtJYXXSearch_JYRQMax.Text + "'"
                    End If
                ElseIf Me.txtJYXXSearch_JYRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtJYXXSearch_JYRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtJYXXSearch_JYRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strJYRQ + " >= '" + Me.txtJYXXSearch_JYRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJYRQ + " >= '" + Me.txtJYXXSearch_JYRQMin.Text + "'"
                    End If
                ElseIf Me.txtJYXXSearch_JYRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtJYXXSearch_JYRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtJYXXSearch_JYRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strJYRQ + " <= '" + Me.txtJYXXSearch_JYRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJYRQ + " <= '" + Me.txtJYXXSearch_JYRQMax.Text + "'"
                    End If
                Else
                End If

                '按“合同日期”搜索
                Dim strHTRQ As String
                strHTRQ = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTRQ
                If Me.txtJYXXSearch_HTRQMin.Text.Length > 0 Then Me.txtJYXXSearch_HTRQMin.Text = Me.txtJYXXSearch_HTRQMin.Text.Trim()
                If Me.txtJYXXSearch_HTRQMax.Text.Length > 0 Then Me.txtJYXXSearch_HTRQMax.Text = Me.txtJYXXSearch_HTRQMax.Text.Trim()
                If Me.txtJYXXSearch_HTRQMin.Text <> "" And Me.txtJYXXSearch_HTRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtJYXXSearch_HTRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtJYXXSearch_HTRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtJYXXSearch_HTRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtJYXXSearch_HTRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtJYXXSearch_HTRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtJYXXSearch_HTRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strHTRQ + " between '" + Me.txtJYXXSearch_HTRQMin.Text + "' and '" + Me.txtJYXXSearch_HTRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " between '" + Me.txtJYXXSearch_HTRQMin.Text + "' and '" + Me.txtJYXXSearch_HTRQMax.Text + "'"
                    End If
                ElseIf Me.txtJYXXSearch_HTRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtJYXXSearch_HTRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtJYXXSearch_HTRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strHTRQ + " >= '" + Me.txtJYXXSearch_HTRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " >= '" + Me.txtJYXXSearch_HTRQMin.Text + "'"
                    End If
                ElseIf Me.txtJYXXSearch_HTRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtJYXXSearch_HTRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtJYXXSearch_HTRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strHTRQ + " <= '" + Me.txtJYXXSearch_HTRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " <= '" + Me.txtJYXXSearch_HTRQMax.Text + "'"
                    End If
                Else
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_JYXX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdJYXX要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_JYXX( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_JYXX = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtJYXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_JYXX)

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_JYXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_blnQxControl, Me.m_objDataSet_JYXX) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_JYXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_JYXX.Tables(strTable)
                    Me.htxtJYXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_JYXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_JYXX = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdJYXX数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_JYXX(ByRef strErrMsg As String) As Boolean

            searchModuleData_JYXX = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_JYXX(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_JYXX(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_JYXX = strQuery
                Me.htxtJYXXQuery.Value = Me.m_strQuery_JYXX

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_JYXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdJYXX的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_JYXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_JYXX = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = 0
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtJYXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtJYXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_JYXX Is Nothing Then
                    Me.grdJYXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_JYXX.Tables(strTable)
                        Me.grdJYXX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_JYXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdJYXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdJYXX)
                    With Me.grdJYXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '隐藏选定列
                Me.grdJYXX.Columns(0).Visible = False

                '绑定数据
                Me.grdJYXX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                ''恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdJYXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_JYXX) = False Then
                '    GoTo errProc
                'End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_JYXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdJYXX及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_JYXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_JYXX = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_JYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_JYXX.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblJYXXGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdJYXX, .Count)

                    '显示页面浏览功能
                    Me.lnkCZJYXXMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdJYXX, .Count)
                    Me.lnkCZJYXXMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdJYXX, .Count)
                    Me.lnkCZJYXXMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdJYXX, .Count)
                    Me.lnkCZJYXXMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdJYXX, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZJYXXDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZJYXXSelectAll.Enabled = blnEnabled
                    Me.lnkCZJYXXGotoPage.Enabled = blnEnabled
                    Me.lnkCZJYXXSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_JYXX = True
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
                Me.btnNull.Visible = Me.m_blnAllowNull

                Me.lnkCZJYXXSelectAll.Enabled = False
                Me.lnkCZJYXXDeSelectAll.Enabled = False

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

            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                '显示Pannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                '显示提示
                Me.lblSelectMode.Text = ""

                '执行键转译(不论是否是“回发”)
                objControlProcess.doTranslateKey(Me.txtJYXXPageIndex)
                objControlProcess.doTranslateKey(Me.txtJYXXPageSize)
                '************************************************
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_YZMC)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_KHMC)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_JYBH)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_WYDZ)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_JYRQMin)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_JYRQMax)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_HTRQMin)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_HTRQMax)
                '************************************************

                '显示模块级操作
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '设初始值
                If Me.m_blnSaveScence = False Then
                    Me.txtJYXXSearch_JYRQMin.Text = Now.Year.ToString + "-01-01"
                    If Me.searchModuleData_JYXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                        GoTo errProc
                    End If
                End If
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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
            Dim blnDo As Boolean

            '预处理
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
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

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_JYXX)
        End Sub












        '----------------------------------------------------------------
        '网格事件处理器
        '----------------------------------------------------------------
        '实现对grdJYXX网格行、列的固定
        Sub grdJYXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdJYXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_JYXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_JYXX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_JYXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdJYXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdJYXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdJYXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblJYXXGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdJYXX, Me.m_intRows_JYXX)
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

        Private Sub grdJYXX_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdJYXX.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
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
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_JYXX.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_JYXX.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtJYXXSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtJYXXSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtJYXXSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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












        Private Sub doMoveFirst_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdJYXX.PageCount)
                Me.grdJYXX.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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

        Private Sub doMoveLast_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJYXX.PageCount - 1, Me.grdJYXX.PageCount)
                Me.grdJYXX.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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

        Private Sub doMoveNext_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJYXX.CurrentPageIndex + 1, Me.grdJYXX.PageCount)
                Me.grdJYXX.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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

        Private Sub doMovePrevious_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJYXX.CurrentPageIndex - 1, Me.grdJYXX.PageCount)
                Me.grdJYXX.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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

        Private Sub doGotoPage_JYXX(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtJYXXPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdJYXX.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_JYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtJYXXPageIndex.Text = (Me.grdJYXX.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_JYXX(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtJYXXPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdJYXX.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_JYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtJYXXPageSize.Text = (Me.grdJYXX.PageSize).ToString()

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

        Private Sub doSelectAll_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdJYXX, 0, Me.m_cstrCheckBoxIdInDataGrid_JYXX, True) = False Then
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

        Private Sub doDeSelectAll_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdJYXX, 0, Me.m_cstrCheckBoxIdInDataGrid_JYXX, False) = False Then
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

        Private Sub doSearch_JYXX(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_JYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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

        Private Sub lnkCZJYXXMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXMoveFirst.Click
            Me.doMoveFirst_JYXX("lnkCZJYXXMoveFirst")
        End Sub

        Private Sub lnkCZJYXXMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXMoveLast.Click
            Me.doMoveLast_JYXX("lnkCZJYXXMoveLast")
        End Sub

        Private Sub lnkCZJYXXMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXMoveNext.Click
            Me.doMoveNext_JYXX("lnkCZJYXXMoveNext")
        End Sub

        Private Sub lnkCZJYXXMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXMovePrev.Click
            Me.doMovePrevious_JYXX("lnkCZJYXXMovePrev")
        End Sub

        Private Sub lnkCZJYXXGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXGotoPage.Click
            Me.doGotoPage_JYXX("lnkCZJYXXGotoPage")
        End Sub

        Private Sub lnkCZJYXXSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXSetPageSize.Click
            Me.doSetPageSize_JYXX("lnkCZJYXXSetPageSize")
        End Sub

        Private Sub lnkCZJYXXSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXSelectAll.Click
            Me.doSelectAll_JYXX("lnkCZJYXXSelectAll")
        End Sub

        Private Sub lnkCZJYXXDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXDeSelectAll.Click
            Me.doDeSelectAll_JYXX("lnkCZJYXXDeSelectAll")
        End Sub

        Private Sub btnJYXXSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJYXXSearch.Click
            Me.doSearch_JYXX("btnJYXXSearch")
        End Sub












        Private Sub doSearchFull(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI

            Try
                '获取数据
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
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
                    .iQueryTable = Me.m_objDataSet_JYXX.Tables(strTable)
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

        Private Sub btnJYXXSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJYXXSearch_Full.Click
            Me.doSearchFull("btnJYXXSearch_Full")
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                If Me.grdJYXX.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有任何交易！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdJYXX.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strValue As String = ""

                '返回参数
                If Me.m_blnInterface = True Then
                    With Me.m_objInterface
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdJYXX.Items(i), intColIndex)
                        .oJYBH = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdJYXX.Items(i), intColIndex)
                        .oHTBH = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYBS)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdJYXX.Items(i), intColIndex)
                        .oWYBS = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTWYBS)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdJYXX.Items(i), intColIndex)
                        .oHTWYBS = strValue
                    End With
                End If

                '返回处理
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    Me.m_objInterface.oExitMode = True
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

        Private Sub doNull(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '返回处理
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    Me.m_objInterface.oExitMode = True
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

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnNull_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNull.Click
            Me.doNull("btnNull")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
