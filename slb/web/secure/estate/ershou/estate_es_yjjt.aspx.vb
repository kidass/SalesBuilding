Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_yjjt
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“查看佣金计提情况”处理模块
    '----------------------------------------------------------------

    Partial Class estate_es_yjjt
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
        '本模块相对image的相对路径
        Private m_cstrRelativePathToImage As String = "../../../"
        '打印模版相对于应用根的路径
        Private m_cstrExcelMBRelativePathToAppRoot As String = "/template/excel/"
        '打印文件缓存目录相对于应用根的路径
        Private m_cstrPrintCacheRelativePathToAppRoot As String = "/temp/printcache/"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsYjjt
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsYjjt
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdYJ相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_YJ As String = "chkYJ"
        Private Const m_cstrDataGridInDIV_YJ As String = "divYJ"
        Private m_intFixedColumns_YJ As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_YJ As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_YJ As String
        Private m_intRows_YJ As Integer

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_strRYDM_I As String
        Private m_intYJBZ_I As Integer

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsYjjt)
                    Catch ex As Exception
                        Me.m_objInterface = Nothing
                    End Try
                Else
                    Me.m_objInterface = Nothing
                End If
                If Not (Me.m_objInterface Is Nothing) Then
                    Me.m_objInterface.oExitMode = False
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
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
                    Me.htxtDivLeftYJ.Value = .htxtDivLeftYJ
                    Me.htxtDivTopYJ.Value = .htxtDivTopYJ

                    Me.htxtYJQuery.Value = .htxtYJQuery
                    Me.htxtYJRows.Value = .htxtYJRows
                    Me.htxtYJSort.Value = .htxtYJSort
                    Me.htxtYJSortColumnIndex.Value = .htxtYJSortColumnIndex
                    Me.htxtYJSortType.Value = .htxtYJSortType

                    Me.txtYJSearch_RYMC.Text = .txtYJSearch_RYMC
                    Me.txtYJSearch_RYDM.Text = .txtYJSearch_RYDM
                    Me.txtYJSearch_JYNYMax.Text = .txtYJSearch_JYNYMax
                    Me.txtYJSearch_JYNYMin.Text = .txtYJSearch_JYNYMin
                    Me.txtYJSearch_JANYMax.Text = .txtYJSearch_JANYMax
                    Me.txtYJSearch_JANYMin.Text = .txtYJSearch_JANYMin

                    Me.txtYJPageIndex.Text = .txtYJPageIndex
                    Me.txtYJPageSize.Text = .txtYJPageSize

                    Try
                        Me.grdYJ.PageSize = .grdYJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYJ.CurrentPageIndex = .grdYJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYJ.SelectedIndex = .grdYJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdQueryYJ.Value = .htxtSessionIdQueryYJ
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsYjjt

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftYJ = Me.htxtDivLeftYJ.Value
                    .htxtDivTopYJ = Me.htxtDivTopYJ.Value

                    .htxtYJQuery = Me.htxtYJQuery.Value
                    .htxtYJRows = Me.htxtYJRows.Value
                    .htxtYJSort = Me.htxtYJSort.Value
                    .htxtYJSortColumnIndex = Me.htxtYJSortColumnIndex.Value
                    .htxtYJSortType = Me.htxtYJSortType.Value

                    .txtYJSearch_RYDM = Me.txtYJSearch_RYDM.Text
                    .txtYJSearch_RYMC = Me.txtYJSearch_RYMC.Text
                    .txtYJSearch_JYNYMax = Me.txtYJSearch_JYNYMax.Text
                    .txtYJSearch_JYNYMin = Me.txtYJSearch_JYNYMin.Text
                    .txtYJSearch_JANYMax = Me.txtYJSearch_JANYMax.Text
                    .txtYJSearch_JANYMin = Me.txtYJSearch_JANYMin.Text

                    .txtYJPageIndex = Me.txtYJPageIndex.Text
                    .txtYJPageSize = Me.txtYJPageSize.Text

                    .grdYJ_PageSize = Me.grdYJ.PageSize
                    .grdYJ_CurrentPageIndex = Me.grdYJ.CurrentPageIndex
                    .grdYJ_SelectedIndex = Me.grdYJ.SelectedIndex
                    .htxtSessionIdQueryYJ = Me.htxtSessionIdQueryYJ.Value
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
                Dim objISelectColumns As Josco.JsKernal.BusinessFacade.ISelectColumns = Nothing
                Try
                    objISelectColumns = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISelectColumns)
                Catch ex As Exception
                    objISelectColumns = Nothing
                End Try
                If Not (objISelectColumns Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.ISelectColumns.SafeRelease(objISelectColumns)
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
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                        Me.htxtYJQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQueryYJ.Value.Trim = "" Then
                            Me.htxtSessionIdQueryYJ.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQueryYJ.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtSessionIdQueryYJ.Value, objISjcxCxtj.oDataSetTJ)
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
        Private Function getInterfaceParameters(ByRef strErrMsg As String, ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getInterfaceParameters = False

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsYjjt)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "错误：没有提供本模块必须的接口！"
                    Exit Try
                End If
                Me.m_strRYDM_I = Me.m_objInterface.iRYDM
                Me.m_intYJBZ_I = Me.m_objInterface.iYJBZ
                Me.m_blnInterface = True
                blnContinue = True

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String = ""
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsYjjt)
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

                Me.m_strQuery_YJ = Me.htxtYJQuery.Value
                Me.m_intRows_YJ = objPulicParameters.getObjectValue(Me.htxtYJRows.Value, 0)
                Me.m_intFixedColumns_YJ = objPulicParameters.getObjectValue(Me.htxtYJFixed.Value, 0)
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
                If Me.htxtSessionIdQueryYJ.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQueryYJ.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQueryYJ.Value)
                End If
            Catch ex As Exception
            End Try

        End Sub














        '----------------------------------------------------------------
        ' 获取模块搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_YJ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strTempWhere As String = ""

            getQueryString_YJ = False
            strQuery = ""

            Try
                '按“人员代码”搜索
                Dim strRYDM As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_YJJT_JBRY
                If Me.txtYJSearch_RYDM.Text.Trim <> "" Then
                    Me.txtYJSearch_RYDM.Text = objPulicParameters.getNewSearchString(Me.txtYJSearch_RYDM.Text)
                    strTempWhere = strRYDM + " like '" + Me.txtYJSearch_RYDM.Text + "%'"
                    If strTempWhere <> "" Then
                        If strQuery = "" Then
                            strQuery = strTempWhere
                        Else
                            strQuery = strQuery + vbCr + " and " + strTempWhere
                        End If
                    End If
                End If

                '按“人员名称”搜索
                Dim strRYMC As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_YJJT_JBRYMC
                If Me.txtYJSearch_RYMC.Text.Trim <> "" Then
                    Me.txtYJSearch_RYMC.Text = objPulicParameters.getNewSearchString(Me.txtYJSearch_RYMC.Text)
                    strTempWhere = strRYMC + " like '" + Me.txtYJSearch_RYMC.Text + "%'"
                    If strTempWhere <> "" Then
                        If strQuery = "" Then
                            strQuery = strTempWhere
                        Else
                            strQuery = strQuery + vbCr + " and " + strTempWhere
                        End If
                    End If
                End If

                '按“计佣年月”搜索
                Dim strJYNY As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_YJJT_JYNY
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtYJSearch_JYNYMin, Me.txtYJSearch_JYNYMax, strJYNY, strTempWhere) = False Then
                    GoTo errProc
                End If
                If strTempWhere <> "" Then
                    If strQuery = "" Then
                        strQuery = strTempWhere
                    Else
                        strQuery = strQuery + vbCr + " and " + strTempWhere
                    End If
                End If

                '按“计佣年月”搜索
                Dim strJANY As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_YJJT_JANY
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtYJSearch_JANYMin, Me.txtYJSearch_JANYMax, strJANY, strTempWhere) = False Then
                    GoTo errProc
                End If
                If strTempWhere <> "" Then
                    If strQuery = "" Then
                        strQuery = strTempWhere
                    Else
                        strQuery = strQuery + vbCr + " and " + strTempWhere
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            getQueryString_YJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdYJ要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索字符串
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_YJ(ByRef strErrMsg As String, ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_YJJT
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_YJ = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtYJSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YJ)

                '固定查询串
                Dim strTempWhere As String = ""
                'If Me.m_strRYDM_I <> "" Then
                '    strTempWhere = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_YJJT_JBRY + " = '" + Me.m_strRYDM_I + "'"
                'End If
                If strTempWhere = "" Then
                    strTempWhere = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_YJJT_YJBJ + " = " + Me.m_intYJBZ_I.ToString
                Else
                    strTempWhere = strTempWhere + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_YJJT_YJBJ + " = " + Me.m_intYJBZ_I.ToString
                End If
                If strWhere = "" Then
                    strWhere = strTempWhere
                Else
                    strWhere = strWhere + vbCr + " and " + strTempWhere
                End If

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_YJJT(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_YJ) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_YJ.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_YJ.Tables(strTable)
                    Me.htxtYJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_YJ = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_YJ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdYJ数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_YJ(ByRef strErrMsg As String) As Boolean

            searchModuleData_YJ = False

            Try
                '获取搜索字符串
                Dim strQuery As String = ""
                If Me.getQueryString_YJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_YJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_YJ = strQuery
                Me.htxtYJQuery.Value = Me.m_strQuery_YJ
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_YJ = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYJ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_YJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_YJJT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_YJ = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtYJSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtYJSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_YJ Is Nothing Then
                    Me.grdYJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YJ.Tables(strTable)
                        Me.grdYJ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_YJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdYJ)
                    With Me.grdYJ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdYJ.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                ''恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_YJ) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_YJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYJ及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_YJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_YJJT
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_YJ = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_YJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_YJ.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblYJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdYJ, .Count)

                    '显示页面浏览功能
                    Me.lnkCZYJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdYJ, .Count)
                    Me.lnkCZYJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdYJ, .Count)
                    Me.lnkCZYJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdYJ, .Count)
                    Me.lnkCZYJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdYJ, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZYJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZYJSelectAll.Enabled = blnEnabled
                    Me.lnkCZYJGotoPage.Enabled = blnEnabled
                    Me.lnkCZYJSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_YJ = True
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
        Private Function showModuleData_Main(ByRef strErrMsg As String) As Boolean

            showModuleData_Main = False

            Try

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
                    objControlProcess.doTranslateKey(Me.txtYJPageIndex)
                    objControlProcess.doTranslateKey(Me.txtYJPageSize)
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtYJSearch_JYNYMax)
                    objControlProcess.doTranslateKey(Me.txtYJSearch_JYNYMin)
                    objControlProcess.doTranslateKey(Me.txtYJSearch_JANYMin)
                    objControlProcess.doTranslateKey(Me.txtYJSearch_JANYMax)
                    '********************************************************

                    If Me.m_blnSaveScence = False Then
                        Me.txtYJSearch_JYNYMin.Text = (Now.Year * 100 + 1).ToString
                        Me.txtYJSearch_JYNYMax.Text = (Now.Year * 100 + 12).ToString
                        If Not (Me.m_objInterface Is Nothing) Then
                            Me.txtYJSearch_RYDM.Text = Me.m_objInterface.iRYDM
                        End If
                        If Me.searchModuleData_YJ(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.getModuleData_YJ(strErrMsg, Me.m_strQuery_YJ) = False Then
                            GoTo errProc
                        End If
                    End If
                    If Me.showModuleData_YJ(strErrMsg) = False Then
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
        '实现对网格行、列的固定
        Sub grdYJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYJ.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_YJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_YJ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_YJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdYJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdYJ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblYJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdYJ, Me.m_intRows_YJ)

                '同步显示
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

        Private Sub grdYJ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdYJ.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_YJJT
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
                If Me.getModuleData_YJ(strErrMsg, Me.m_strQuery_YJ) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objDataSet_YJ.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet_YJ.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtYJSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtYJSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtYJSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_YJ(strErrMsg) = False Then
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
                If Me.getModuleData_YJ(strErrMsg, Me.m_strQuery_YJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdYJ.PageCount)
                Me.grdYJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_YJ(strErrMsg) = False Then
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
                If Me.getModuleData_YJ(strErrMsg, Me.m_strQuery_YJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdYJ.PageCount - 1, Me.grdYJ.PageCount)
                Me.grdYJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_YJ(strErrMsg) = False Then
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
                If Me.getModuleData_YJ(strErrMsg, Me.m_strQuery_YJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdYJ.CurrentPageIndex + 1, Me.grdYJ.PageCount)
                Me.grdYJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_YJ(strErrMsg) = False Then
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
                If Me.getModuleData_YJ(strErrMsg, Me.m_strQuery_YJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdYJ.CurrentPageIndex - 1, Me.grdYJ.PageCount)
                Me.grdYJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_YJ(strErrMsg) = False Then
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
            intPageIndex = objPulicParameters.getObjectValue(Me.txtYJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_YJ(strErrMsg, Me.m_strQuery_YJ) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdYJ.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_YJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtYJPageIndex.Text = (Me.grdYJ.CurrentPageIndex + 1).ToString()

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
            intPageSize = objPulicParameters.getObjectValue(Me.txtYJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_YJ(strErrMsg, Me.m_strQuery_YJ) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdYJ.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_YJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtYJPageSize.Text = (Me.grdYJ.PageSize).ToString()
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdYJ, 0, Me.m_cstrCheckBoxIdInDataGrid_YJ, True) = False Then
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdYJ, 0, Me.m_cstrCheckBoxIdInDataGrid_YJ, False) = False Then
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
                If Me.searchModuleData_YJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_YJ(strErrMsg) = False Then
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

        Private Sub lnkCZYJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYJMoveFirst.Click
            Me.doMoveFirst("lnkCZYJMoveFirst")
        End Sub

        Private Sub lnkCZYJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYJMoveLast.Click
            Me.doMoveLast("lnkCZYJMoveLast")
        End Sub

        Private Sub lnkCZYJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYJMoveNext.Click
            Me.doMoveNext("lnkCZYJMoveNext")
        End Sub

        Private Sub lnkCZYJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYJMovePrev.Click
            Me.doMovePrevious("lnkCZYJMovePrev")
        End Sub

        Private Sub lnkCZYJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYJGotoPage.Click
            Me.doGotoPage("lnkCZYJGotoPage")
        End Sub

        Private Sub lnkCZYJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYJSetPageSize.Click
            Me.doSetPageSize("lnkCZYJSetPageSize")
        End Sub

        Private Sub lnkCZYJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYJSelectAll.Click
            Me.doSelectAll("lnkCZYJSelectAll")
        End Sub

        Private Sub lnkCZYJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYJDeSelectAll.Click
            Me.doDeSelectAll("lnkCZYJDeSelectAll")
        End Sub

        Private Sub btnYJSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYJSearch.Click
            Me.doSearch("btnYJSearch")
        End Sub











        Private Sub doSearchFull(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_YJJT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '获取数据
                If Me.getModuleData_YJ(strErrMsg, Me.m_strQuery_YJ) = False Then
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
                    If Me.htxtSessionIdQueryYJ.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQueryYJ.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_YJ.Tables(strTable)
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

        Private Sub btnYJSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYJSearch_Full.Click
            Me.doSearchFull("btnYJSearch_Full")
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
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
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

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '获取打印数据
                If Me.getModuleData_YJ(strErrMsg, Me.m_strQuery_YJ) = False Then
                    GoTo errProc
                End If
                If Me.m_objDataSet_YJ.Tables.Count < 1 Then
                    strErrMsg = "错误：还未获取数据！"
                    GoTo errProc
                End If
                With Me.m_objDataSet_YJ.Tables(0)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有数据！"
                        GoTo errProc
                    End If
                End With

                '准备Excel文件
                Dim strSrcExcelSpec As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "广州兴业_二手报表_中介部二手佣金计提情况.xls"

                '调用打印模块
                Dim strNewSessionId As String = ""
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If
                '准备调用接口
                Dim objISelectColumns As Josco.JsKernal.BusinessFacade.ISelectColumns = Nothing
                objISelectColumns = New Josco.JsKernal.BusinessFacade.ISelectColumns
                With objISelectColumns
                    .iDataSet = Me.m_objDataSet_YJ
                    .iTableNo = 0
                    .iExcelMBFileUrl = strSrcExcelSpec
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
                Session.Add(strNewSessionId, objISelectColumns)
                strUrl = ""
                strUrl += "../../selectcolumns.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
        End Sub

        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Me.doPrint("btnPrint")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
