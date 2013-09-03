Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_xz_htxx
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“合同选择”处理模块
    '----------------------------------------------------------------

    Partial Class estate_es_xz_htxx
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'zengxianglin 2008-11-18
        'zengxianglin 2008-11-18







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

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsXzHtxx
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsXzHtxx
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdHT相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_HT As String = "chkHT"
        Private Const m_cstrDataGridInDIV_HT As String = "divHT"
        Private m_intFixedColumns_HT As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_HT As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_HT As String
        Private m_intRows_HT As Integer

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_blnAllowNull As Boolean

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------
        Private m_blnQxControl As Boolean











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsXzHtxx)
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
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftHT.Value = .htxtDivLeftHT
                    Me.htxtDivTopHT.Value = .htxtDivTopHT

                    Me.htxtHTQuery.Value = .htxtHTQuery
                    Me.htxtHTRows.Value = .htxtHTRows
                    Me.htxtHTSort.Value = .htxtHTSort
                    Me.htxtHTSortColumnIndex.Value = .htxtHTSortColumnIndex
                    Me.htxtHTSortType.Value = .htxtHTSortType

                    Me.txtHTSearch_HTBH.Text = .txtHTSearch_HTBH
                    Me.txtHTSearch_QRSH.Text = .txtHTSearch_QRSH
                    Me.txtHTSearch_JFMC.Text = .txtHTSearch_JFMC
                    Me.txtHTSearch_YFMC.Text = .txtHTSearch_YFMC
                    Me.txtHTSearch_FWDZ.Text = .txtHTSearch_FWDZ
                    Me.txtHTSearch_HTRQMax.Text = .txtHTSearch_HTRQMax
                    Me.txtHTSearch_HTRQMin.Text = .txtHTSearch_HTRQMin
                    Me.ddlHTSearch_HTZT.SelectedIndex = .ddlHTSearch_HTZT_SelectedIndex
                    'zengxianglin 2008-11-18
                    Me.ddlHTSearch_TSTJ.SelectedIndex = .ddlHTSearch_TSTJ_SelectedIndex
                    'zengxianglin 2008-11-18

                    Me.txtHTPageIndex.Text = .txtHTPageIndex
                    Me.txtHTPageSize.Text = .txtHTPageSize

                    Try
                        Me.grdHT.PageSize = .grdHTPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdHT.CurrentPageIndex = .grdHTCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdHT.SelectedIndex = .grdHTSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdQueryHT.Value = .htxtSessionIdQueryHT
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsXzHtxx

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftHT = Me.htxtDivLeftHT.Value
                    .htxtDivTopHT = Me.htxtDivTopHT.Value

                    .htxtHTQuery = Me.htxtHTQuery.Value
                    .htxtHTRows = Me.htxtHTRows.Value
                    .htxtHTSort = Me.htxtHTSort.Value
                    .htxtHTSortColumnIndex = Me.htxtHTSortColumnIndex.Value
                    .htxtHTSortType = Me.htxtHTSortType.Value

                    .txtHTSearch_HTBH = Me.txtHTSearch_HTBH.Text
                    .txtHTSearch_QRSH = Me.txtHTSearch_QRSH.Text
                    .txtHTSearch_JFMC = Me.txtHTSearch_JFMC.Text
                    .txtHTSearch_YFMC = Me.txtHTSearch_YFMC.Text
                    .txtHTSearch_FWDZ = Me.txtHTSearch_FWDZ.Text
                    .txtHTSearch_HTRQMax = Me.txtHTSearch_HTRQMax.Text
                    .txtHTSearch_HTRQMin = Me.txtHTSearch_HTRQMin.Text
                    .ddlHTSearch_HTZT_SelectedIndex = Me.ddlHTSearch_HTZT.SelectedIndex
                    'zengxianglin 2008-11-18
                    .ddlHTSearch_TSTJ_SelectedIndex = Me.ddlHTSearch_TSTJ.SelectedIndex
                    'zengxianglin 2008-11-18

                    .txtHTPageIndex = Me.txtHTPageIndex.Text
                    .txtHTPageSize = Me.txtHTPageSize.Text

                    .grdHTPageSize = Me.grdHT.PageSize
                    .grdHTCurrentPageIndex = Me.grdHT.CurrentPageIndex
                    .grdHTSelectedIndex = Me.grdHT.SelectedIndex
                    .htxtSessionIdQueryHT = Me.htxtSessionIdQueryHT.Value
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

            getDataFromCallModule = False

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
                        Me.htxtHTQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQueryHT.Value.Trim = "" Then
                            Me.htxtSessionIdQueryHT.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQueryHT.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtSessionIdQueryHT.Value, objISjcxCxtj.oDataSetTJ)
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

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 获取接口参数
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
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsXzHtxx)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_blnAllowNull = True
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_blnAllowNull = Me.m_objInterface.iAllowNull
                End If
                If Me.m_blnInterface = False Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "错误：没有提供本模块需要的接口！"
                    Exit Try
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

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsXzHtxx)
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

                Me.m_strQuery_HT = Me.htxtHTQuery.Value
                Me.m_intRows_HT = objPulicParameters.getObjectValue(Me.htxtHTRows.Value, 0)
                Me.m_intFixedColumns_HT = objPulicParameters.getObjectValue(Me.htxtHTFixed.Value, 0)
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
                If Me.htxtSessionIdQueryHT.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQueryHT.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQueryHT.Value)
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
        Private Function getQueryString_HT( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_HT = False
            strQuery = ""

            Try
                '按“确认书号”搜索
                Dim strQRSH As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH
                If Me.txtHTSearch_QRSH.Text.Length > 0 Then Me.txtHTSearch_QRSH.Text = Me.txtHTSearch_QRSH.Text.Trim()
                If Me.txtHTSearch_QRSH.Text <> "" Then
                    Me.txtHTSearch_QRSH.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_QRSH.Text)
                    If strQuery = "" Then
                        strQuery = strQRSH + " like '" + Me.txtHTSearch_QRSH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strQRSH + " like '" + Me.txtHTSearch_QRSH.Text + "%'"
                    End If
                End If

                '按“合同编号”搜索
                Dim strHTBH As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH
                If Me.txtHTSearch_HTBH.Text.Length > 0 Then Me.txtHTSearch_HTBH.Text = Me.txtHTSearch_HTBH.Text.Trim()
                If Me.txtHTSearch_HTBH.Text <> "" Then
                    Me.txtHTSearch_HTBH.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_HTBH.Text)
                    If strQuery = "" Then
                        strQuery = strHTBH + " like '" + Me.txtHTSearch_HTBH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strHTBH + " like '" + Me.txtHTSearch_HTBH.Text + "%'"
                    End If
                End If

                '按“甲方名称”搜索
                Dim strJFMC As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YZMC
                If Me.txtHTSearch_JFMC.Text.Length > 0 Then Me.txtHTSearch_JFMC.Text = Me.txtHTSearch_JFMC.Text.Trim()
                If Me.txtHTSearch_JFMC.Text <> "" Then
                    Me.txtHTSearch_JFMC.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_JFMC.Text)
                    If strQuery = "" Then
                        strQuery = strJFMC + " like '" + Me.txtHTSearch_JFMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJFMC + " like '" + Me.txtHTSearch_JFMC.Text + "%'"
                    End If
                End If

                '按“乙方名称”搜索
                Dim strYFMC As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_KHMC
                If Me.txtHTSearch_YFMC.Text.Length > 0 Then Me.txtHTSearch_YFMC.Text = Me.txtHTSearch_YFMC.Text.Trim()
                If Me.txtHTSearch_YFMC.Text <> "" Then
                    Me.txtHTSearch_YFMC.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_YFMC.Text)
                    If strQuery = "" Then
                        strQuery = strYFMC + " like '" + Me.txtHTSearch_YFMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strYFMC + " like '" + Me.txtHTSearch_YFMC.Text + "%'"
                    End If
                End If

                '按“房屋地址”搜索
                Dim strFWDZ As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYDZ
                If Me.txtHTSearch_FWDZ.Text.Length > 0 Then Me.txtHTSearch_FWDZ.Text = Me.txtHTSearch_FWDZ.Text.Trim()
                If Me.txtHTSearch_FWDZ.Text <> "" Then
                    Me.txtHTSearch_FWDZ.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_FWDZ.Text)
                    If strQuery = "" Then
                        strQuery = strFWDZ + " like '" + Me.txtHTSearch_FWDZ.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strFWDZ + " like '" + Me.txtHTSearch_FWDZ.Text + "%'"
                    End If
                End If

                '按“合同状态”搜索
                Dim strHTZT As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTZT
                Select Case Me.ddlHTSearch_HTZT.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strHTZT + Me.ddlHTSearch_HTZT.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strHTZT + Me.ddlHTSearch_HTZT.SelectedValue
                        End If
                    Case Else
                End Select

                'zengxianglin 2008-11-18
                '按“特殊条件”搜索
                Dim strJYBH As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH
                Dim strNow As String = Now.ToString("yyyy-MM-dd")
                Select Case Me.ddlHTSearch_TSTJ.SelectedIndex
                    Case 1
                        If strQuery = "" Then
                            strQuery = "dbo.uf_estate_es_hasKbtx(" + strJYBH + ",'" + strNow + "') = 1"
                        Else
                            strQuery = strQuery + " and " + "dbo.uf_estate_es_hasKbtx(" + strJYBH + ",'" + strNow + "') = 1"
                        End If
                    Case 2
                        If strQuery = "" Then
                            strQuery = "dbo.uf_estate_es_hasBwtx(" + strJYBH + ",'" + strNow + "') = 1"
                        Else
                            strQuery = strQuery + " and " + "dbo.uf_estate_es_hasKbtx(" + strJYBH + ",'" + strNow + "') = 1"
                        End If
                    Case Else
                End Select
                'zengxianglin 2008-11-18

                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime

                '按“合同日期”搜索
                Dim strHTRQ As String
                strHTRQ = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTRQ
                If Me.txtHTSearch_HTRQMin.Text.Length > 0 Then Me.txtHTSearch_HTRQMin.Text = Me.txtHTSearch_HTRQMin.Text.Trim()
                If Me.txtHTSearch_HTRQMax.Text.Length > 0 Then Me.txtHTSearch_HTRQMax.Text = Me.txtHTSearch_HTRQMax.Text.Trim()
                If Me.txtHTSearch_HTRQMin.Text <> "" And Me.txtHTSearch_HTRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtHTSearch_HTRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtHTSearch_HTRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtHTSearch_HTRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtHTSearch_HTRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtHTSearch_HTRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtHTSearch_HTRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strHTRQ + " between '" + Me.txtHTSearch_HTRQMin.Text + "' and '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " between '" + Me.txtHTSearch_HTRQMin.Text + "' and '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    End If
                ElseIf Me.txtHTSearch_HTRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtHTSearch_HTRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtHTSearch_HTRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strHTRQ + " >= '" + Me.txtHTSearch_HTRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " >= '" + Me.txtHTSearch_HTRQMin.Text + "'"
                    End If
                ElseIf Me.txtHTSearch_HTRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtHTSearch_HTRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtHTSearch_HTRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strHTRQ + " <= '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " <= '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_HT = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdHT要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索字符串
        '     blnControl     ：特殊权限控制
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_HT( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_HT = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtHTSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_HT)

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_JYXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", strWhere, blnControl, Me.m_objDataSet_HT) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_HT.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_HT.Tables(strTable)
                    Me.htxtHTRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_HT = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_HT = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdHT数据
        '     strErrMsg      ：返回错误信息
        '     blnControl     ：特殊权限控制
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_HT( _
            ByRef strErrMsg As String, _
            ByVal blnControl As Boolean) As Boolean

            searchModuleData_HT = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_HT(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_HT(strErrMsg, strQuery, blnControl) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_HT = strQuery
                Me.htxtHTQuery.Value = Me.m_strQuery_HT

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_HT = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdHT的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_HT( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_HT = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtHTSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtHTSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_HT Is Nothing Then
                    Me.grdHT.DataSource = Nothing
                Else
                    With Me.m_objDataSet_HT.Tables(strTable)
                        Me.grdHT.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_HT.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdHT, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdHT)
                    With Me.grdHT.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdHT.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                ''恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdHT, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_HT) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_HT = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdHT及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_HT( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_HT = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_HT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_HT.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblHTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdHT, .Count)

                    '显示页面浏览功能
                    Me.lnkCZHTMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdHT, .Count)
                    Me.lnkCZHTMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdHT, .Count)
                    Me.lnkCZHTMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdHT, .Count)
                    Me.lnkCZHTMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdHT, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZHTDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZHTSelectAll.Enabled = blnEnabled
                    Me.lnkCZHTGotoPage.Enabled = blnEnabled
                    Me.lnkCZHTSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_HT = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
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

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            showModuleData_Main = False

            Try
                Me.btnNull.Visible = Me.m_blnAllowNull
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            showModuleData_Main = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
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
                    objControlProcess.doTranslateKey(Me.txtHTPageIndex)
                    objControlProcess.doTranslateKey(Me.txtHTPageSize)
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtHTSearch_HTBH)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_QRSH)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_JFMC)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_YFMC)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_FWDZ)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_HTRQMin)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_HTRQMax)
                    objControlProcess.doTranslateKey(Me.ddlHTSearch_HTZT)
                    'zengxianglin 2008-11-18
                    objControlProcess.doTranslateKey(Me.ddlHTSearch_TSTJ)
                    'zengxianglin 2008-11-18
                    '********************************************************

                    If Me.m_blnSaveScence = False Then
                        Me.txtHTSearch_HTRQMin.Text = Now.Year.ToString + "-01-01"
                        If Me.searchModuleData_HT(strErrMsg, Me.m_blnQxControl) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.getModuleData_HT(strErrMsg, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                            GoTo errProc
                        End If
                    End If
                    If Me.showModuleData_HT(strErrMsg) = False Then
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
            Dim strErrMsg As String
            Dim strUrl As String

            '预处理
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '获取接口参数
            Dim blnDo As Boolean
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
        '实现对网格行、列的固定
        Sub grdHT_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdHT.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_HT + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns_HT > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_HT - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdHT.ID + "Locked"
                    Next
                End If

            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdHT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdHT.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblHTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdHT, Me.m_intRows_HT)
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

        Private Sub grdHT_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdHT.SortCommand

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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objDataSet_HT.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet_HT.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtHTSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtHTSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtHTSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_HT(strErrMsg) = False Then
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdHT.PageCount - 1, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdHT.CurrentPageIndex + 1, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdHT.CurrentPageIndex - 1, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
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
            intPageIndex = objPulicParameters.getObjectValue(Me.txtHTPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_HT(strErrMsg, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdHT.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtHTPageIndex.Text = (Me.grdHT.CurrentPageIndex + 1).ToString()

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
            intPageSize = objPulicParameters.getObjectValue(Me.txtHTPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_HT(strErrMsg, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdHT.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtHTPageSize.Text = (Me.grdHT.PageSize).ToString()

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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdHT, 0, Me.m_cstrCheckBoxIdInDataGrid_HT, True) = False Then
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdHT, 0, Me.m_cstrCheckBoxIdInDataGrid_HT, False) = False Then
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
                If Me.searchModuleData_HT(strErrMsg, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
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

        Private Sub lnkCZHTMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMoveFirst.Click
            Me.doMoveFirst("lnkCZHTMoveFirst")
        End Sub

        Private Sub lnkCZHTMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMoveLast.Click
            Me.doMoveLast("lnkCZHTMoveLast")
        End Sub

        Private Sub lnkCZHTMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMoveNext.Click
            Me.doMoveNext("lnkCZHTMoveNext")
        End Sub

        Private Sub lnkCZHTMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMovePrev.Click
            Me.doMovePrevious("lnkCZHTMovePrev")
        End Sub

        Private Sub lnkCZHTGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTGotoPage.Click
            Me.doGotoPage("lnkCZHTGotoPage")
        End Sub

        Private Sub lnkCZHTSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTSetPageSize.Click
            Me.doSetPageSize("lnkCZHTSetPageSize")
        End Sub

        Private Sub lnkCZHTSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTSelectAll.Click
            Me.doSelectAll("lnkCZHTSelectAll")
        End Sub

        Private Sub lnkCZHTDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTDeSelectAll.Click
            Me.doDeSelectAll("lnkCZHTDeSelectAll")
        End Sub

        Private Sub btnHTSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHTSearch.Click
            Me.doSearch("btnHTSearch")
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
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
                    If Me.htxtSessionIdQueryHT.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQueryHT.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_HT.Tables(strTable)
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

        Private Sub btnHTSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHTSearch_Full.Click
            Me.doSearchFull("btnHTSearch_Full")
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

        Private Sub doNull(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    '返回到调用模块，并附加返回参数
                    Me.m_objInterface.oExitMode = True
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

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                If Me.grdHT.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdHT.SelectedIndex
                Dim intColIndex As Integer = 0

                '准备返回参数
                If Me.m_blnInterface = True Then
                    With Me.m_objInterface
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH)
                        .oJYBH = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH)
                        .oHTBH = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYBS)
                        .oWYBS = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTWYBS)
                        .oHTWYBS = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                    End With
                End If

                '返回
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    '返回到调用模块，并附加返回参数
                    Me.m_objInterface.oExitMode = True
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

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnNull_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNull.Click
            Me.doNull("btnNull")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
