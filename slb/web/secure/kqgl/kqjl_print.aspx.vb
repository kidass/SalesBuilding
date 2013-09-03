Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：kqgl_kqjl
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身调用其他模块
    '
    ' 功能描述： 
    '   　考勤记录主模块
    '
    ' 接口参数：
    '     参见接口类IKqglkqjl描述
    '----------------------------------------------------------------
    Partial Public Class kqjl_print
        Inherits Josco.JsKernal.web.PageBase


        '----------------------------------------------------------------
        '模块私用参数
        '----------------------------------------------------------------
        '本模块相对image的相对路径
        Private m_cstrRelativePathToImage As String = "../../"
        '文件下载后的缓存路径
        Private m_cstrUrlBaseToFileCache As String = "/temp/filecache/"
        '打印模版相对于应用根的路径
        Private m_cstrExcelMBRelativePathToAppRoot As String = "/template/excel/"
        '打印文件缓存目录相对于应用根的路径
        Private m_cstrPrintCacheRelativePathToAppRoot As String = "/temp/printcache/"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_kqgl_kqjl_previlege_param"
        Private m_blnPrevilegeParams(2) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMKqglkqjl
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IKqglkqjl
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdKQJLG相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_RSLYGL As String = "chkKQJLG"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_RSLYGL As String = "divKQJLGL"
        '网格要锁定的列数
        Private m_intFixedColumns_RSLYGL As Integer

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objDataSet_RSLYGL As Josco.JSOA.Common.Data.kaoqinguanliData
        Private m_objDataSet_List As Josco.JSOA.Common.Data.kaoqinguanliData
        Private m_strQuery_RSLYGL As String '记录m_objDataSet_RSLYGL搜索串
        Private m_intRows_RSLYGL As Integer '记录m_objDataSet_RSLYGL的DefaultView记录数

        '----------------------------------------------------------------
        '其他数据
        '----------------------------------------------------------------













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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IKqglkqjl)
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
                blnContinueExecute = True
                If Me.m_blnPrevilegeParams(1) = True Then
                    Me.btnFPBM.Visible = True
                Else
                    Me.btnFPBM.Visible = False
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
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtRSLYGLQuery.Value = .htxtRSLYGLQuery
                    Me.htxtRSLYGLRows.Value = .htxtRSLYGLRows
                    Me.htxtRSLYGLSort.Value = .htxtRSLYGLSort
                    Me.htxtRSLYGLSortColumnIndex.Value = .htxtRSLYGLSortColumnIndex
                    Me.htxtRSLYGLSortType.Value = .htxtRSLYGLSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftRSLYGL.Value = .htxtDivLeftRSLYGL
                    Me.htxtDivTopRSLYGL.Value = .htxtDivTopRSLYGL

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtDay.Text = .txtDay
                    Me.chkSW.Checked = .blnSw
                    Me.chkXW.Checked = .blnXW
                    Me.chkWC.Checked = .blnWC
                    Me.txtWC.Text = .txtWC
                    Me.htxtBM.Value = .txtGZSJ
                    Me.rblkqlx.SelectedIndex = .rblkqlxSelectedIndex
                    Me.ddlNF.SelectedIndex = .ddlNF_SelectedIndex
                    Me.ddlYF.SelectedIndex = .ddlYF_SelectedIndex

                    Try
                        Me.grdKQJLG.PageSize = .grdRSLYGLPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdKQJLG.CurrentPageIndex = .grdRSLYGLCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdKQJLG.SelectedIndex = .grdRSLYGLSelectedIndex
                    Catch ex As Exception
                    End Try

                End With

                '释放资源
                Session.Remove(strSessionId)
                Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMKqglkqjl

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtRSLYGLQuery = Me.htxtRSLYGLQuery.Value
                    .htxtRSLYGLRows = Me.htxtRSLYGLRows.Value
                    .htxtRSLYGLSort = Me.htxtRSLYGLSort.Value
                    .htxtRSLYGLSortColumnIndex = Me.htxtRSLYGLSortColumnIndex.Value
                    .htxtRSLYGLSortType = Me.htxtRSLYGLSortType.Value

                    .txtDay = Me.txtDay.Text
                    .blnSw = Me.chkSW.Checked
                    .blnXW = Me.chkXW.Checked
                    .blnWC = Me.chkWC.Checked
                    .txtWC = Me.txtWC.Text
                    .txtGZSJ = Me.htxtBM.Value
                    .rblkqlxSelectedIndex = Me.rblkqlx.SelectedIndex

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftRSLYGL = Me.htxtDivLeftRSLYGL.Value
                    .htxtDivTopRSLYGL = Me.htxtDivTopRSLYGL.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .grdRSLYGLPageSize = Me.grdKQJLG.PageSize
                    .grdRSLYGLCurrentPageIndex = Me.grdKQJLG.CurrentPageIndex
                    .grdRSLYGLSelectedIndex = Me.grdKQJLG.SelectedIndex
                    .ddlNF_SelectedIndex = Me.ddlNF.SelectedIndex
                    .ddlYF_SelectedIndex = Me.ddlYF.SelectedIndex

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
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
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
                                Me.txtBM.Text = objIDmxzZzjg.oBumenList
                                '计算组织代码
                                Dim strZZDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtBM.Text, strZZDM) = True Then
                                    '计算定编人数
                                    If strZZDM <> "" Then
                                        Me.htxtBM.Value = strZZDM
                                    End If
                                End If
                            Case "btnSelect_DRDW".ToUpper
                                Me.txtDR.Text = Replace(objIDmxzZzjg.oBumenList, "分行", "")

                            Case "btnSelect_DCDW".ToUpper
                                Me.txtDC.Text = Replace(objIDmxzZzjg.oBumenList, "分行", "")

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
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                        Me.htxtRSLYGLQuery.Value = objISjcxCxtj.oQueryString
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IKqglkqjl)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMKqglkqjl)
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
                Me.m_intFixedColumns_RSLYGL = objPulicParameters.getObjectValue(Me.htxtRSLYGLFixed.Value, 0)
                Me.m_intRows_RSLYGL = objPulicParameters.getObjectValue(Me.htxtRSLYGLRows.Value, 0)
                Me.m_strQuery_RSLYGL = Me.htxtRSLYGLQuery.Value

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
                If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
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
        ' 获取grdKQJLG的搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_RSLYGL( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strTemp As String

            getQueryString_RSLYGL = False
            strQuery = ""

            Try
                '按“标题”搜索
                Dim strWJBT As String
                strTemp = ""
                strWJBT = "a." + Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_ZZDM
                'If Me.htxtBM.Value.Length > 0 Then Me.htxtBM.Value = Me.htxtBM.Value.Trim()
                'If Me.htxtBM.Value <> "" Then
                '    strTemp = objPulicParameters.getNewSearchString(Me.htxtBM.Value)
                '    If strQuery = "" Then
                '        strQuery = strWJBT + " like '" + strTemp + "%'"
                '    Else
                '        strQuery = strQuery + " and " + strWJBT + " like '" + strTemp + "%'"
                '    End If
                'End If


            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_RSLYGL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdKQJLG要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_RSLYGL( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_KAOQINJILU
            Dim m_objsystemKaoqinguanli As New Josco.JSOA.BusinessFacade.systemKaoqinguanli

            getModuleData_RSLYGL = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtRSLYGLSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(Me.m_objDataSet_RSLYGL)

                '重新检索数据
                Dim strNF As String = ""
                Dim strYF As String = ""
                Dim strZZDM As String = ""
                strNF = Me.ddlNF.SelectedValue
                strYF = Me.ddlYF.SelectedValue
                strZZDM = Me.htxtBM.Value.Trim
                If m_objsystemKaoqinguanli.getDataSetKqjl_Main(strErrMsg, MyBase.UserId, MyBase.UserPassword, strNF, strYF, strZZDM, m_objDataSet_RSLYGL) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_RSLYGL.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_RSLYGL.Tables(strTable)
                    Me.htxtRSLYGLRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_RSLYGL = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(m_objsystemKaoqinguanli)

            getModuleData_RSLYGL = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(m_objsystemKaoqinguanli)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdKQJLG数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_RSLYGL(ByRef strErrMsg As String) As Boolean

            searchModuleData_RSLYGL = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_RSLYGL(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_RSLYGL(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_RSLYGL = strQuery
                Me.htxtRSLYGLQuery.Value = Me.m_strQuery_RSLYGL

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_RSLYGL = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdKQJLG的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_RSLYGL(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_KAOQINJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_RSLYGL = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtRSLYGLSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtRSLYGLSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_RSLYGL Is Nothing Then
                    Me.grdKQJLG.DataSource = Nothing
                Else
                    With Me.m_objDataSet_RSLYGL.Tables(strTable)
                        Me.grdKQJLG.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_RSLYGL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdKQJLG, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdKQJLG)
                    With Me.grdKQJLG.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdKQJLG.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdKQJLG, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL) = False Then
                    GoTo errProc
                End If
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdKQJLG.Items.Count

                For i = 1 To intCount - 1 Step 2
                    If spanRow(Me.grdKQJLG, i, i + 1) = False Then
                        GoTo errProc
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_RSLYGL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdKQJLG及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_RSLYGL(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_KAOQINJILU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_RSLYGL = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_RSLYGL.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblRSLYGLGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdKQJLG, .Count)

                    '显示页面浏览功能
                    Me.lnkCZRSLYGLMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdKQJLG, .Count)
                    Me.lnkCZRSLYGLMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdKQJLG, .Count)
                    Me.lnkCZRSLYGLMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdKQJLG, .Count)
                    Me.lnkCZRSLYGLMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdKQJLG, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZRSLYGLDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZRSLYGLSelectAll.Enabled = blnEnabled
                    Me.lnkCZRSLYGLGotoPage.Enabled = blnEnabled
                    Me.lnkCZRSLYGLSetPageSize.Enabled = blnEnabled

                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_RSLYGL = True
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
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            initializeControls = False

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                '显示Pannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                '执行键转译(不论是否是“回发”)
                objControlProcess.doTranslateKey(Me.txtBM)


                '显示模块级操作
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示数据
                Dim strTemp As String
                Dim intTemp As Integer

                strTemp = ""
                If Me.m_blnSaveScence = False Then
                    Me.txtBM.Text = MyBase.UserBmmc
                    Me.htxtBM.Value = MyBase.UserBmdm
                    Me.ddlNF.SelectedIndex = 1

                    Me.htxtYear.Value = Year(Now).ToString
                    intTemp = Month(Now)
                    If intTemp < 10 Then
                        strTemp = "0" + intTemp.ToString
                    Else
                        strTemp = intTemp.ToString
                    End If
                    Me.htxtMonth.Value = strTemp
                    Me.htxtMonthMin.Value = Now.AddDays(1 - Now.Day).ToString
                    Me.htxtMonthMax.Value = Now.AddDays(1 - Now.Day).AddMonths(1).AddDays(-1).ToString
                    Me.ddlYF.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYF, Month(Now).ToString)


                    If Me.searchModuleData_RSLYGL(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                        GoTo errProc
                    End If
                End If

                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If
            End If

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            initializeControls = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If Me.IsPostBack = False Then
                If Me.doFillYEARList(strErrMsg, Me.ddlNF) = False Then
                    GoTo errProc
                End If
                If Me.doFillKQLXList(strErrMsg, Me.rblkqlx) = False Then
                    GoTo errProc
                End If
            End If

            '检查权限
            Dim blnDo As Boolean
            If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                GoTo errProc
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

            '记录操作审计日志
            If Me.IsPostBack = False Then
                If Me.m_blnSaveScence = False Then
                    With New Josco.JsKernal.BusinessFacade.systemCustomer
                        .doWriteYonghuCaozuoRizhi(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "访问了考勤记录！")
                    End With
                End If
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
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(Me.m_objDataSet_RSLYGL)
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
                objDropDownList.Items.Add("")

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
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_JC), "")
                        If strName = "" Then
                            GoTo GNEXT
                        End If
                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName
                        objListItem.Value = strName
                        objDropDownList.Items.Add(objListItem)
GNEXT:
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
        ' 填充“考勤类型”下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillKQLXList( _
            ByRef strErrMsg As String, _
            ByVal objRadioButtonList As System.Web.UI.WebControls.RadioButtonList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_B_KQ_KAOQINLEXING
            Dim objsystemKaoqinguanli As New Josco.JSOA.BusinessFacade.systemKaoqinguanli
            Dim objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillKQLXList = False
            strErrMsg = ""

            Try
                '检查
                If objRadioButtonList Is Nothing Then
                    strErrMsg = "错误：[doFillMMDJList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemKaoqinguanli.getKaoqingleixingData(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objkaoqinguanliData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objRadioButtonList.Items.Clear()

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
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_JC), "")
                        If strName = "" Then
                            GoTo GNEXT
                        End If
                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName
                        objListItem.Value = strCode
                        objRadioButtonList.Items.Add(objListItem)
GNEXT:
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
        ' 填充“秘密等级”下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillYEARList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillYEARList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillMMDJList]接口参数不正确！"
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim objYEAR As DateTime
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                Dim strYEAR As String
                Dim strYearLast As String

                strYEAR = Now.Year.ToString
                objYEAR = Now.AddYears(-1)
                strYearLast = objYEAR.Year.ToString

                objListItem = New System.Web.UI.WebControls.ListItem
                objListItem.Text = strYEAR
                objListItem.Value = strYEAR
                objDropDownList.Items.Add(objListItem)

                objListItem = New System.Web.UI.WebControls.ListItem
                objListItem.Text = strYearLast
                objListItem.Value = strYearLast
                objDropDownList.Items.Add(objListItem)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillYEARList = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Sub grdKQJLG_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdKQJLG.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdKQJLG.SelectedIndex = e.Item.ItemIndex

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











        '----------------------------------------------------------------
        '网格事件处理器
        '----------------------------------------------------------------
        '实现对grdKQJLG网格行、列的固定
        Sub grdKQJLG_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdKQJLG.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_RSLYGL + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_RSLYGL > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_RSLYGL - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdKQJLG.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub



        Private Sub grdKQJLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdKQJLG.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblRSLYGLGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdKQJLG, Me.m_intRows_RSLYGL)
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

        Private Sub grdKQJLG_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdKQJLG.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_KAOQINJILU
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
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_RSLYGL.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_RSLYGL.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtRSLYGLSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtRSLYGLSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtRSLYGLSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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












        Private Sub doMoveFirst_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdKQJLG.PageCount)
                Me.grdKQJLG.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub doMoveLast_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdKQJLG.PageCount - 1, Me.grdKQJLG.PageCount)
                Me.grdKQJLG.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub doMoveNext_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdKQJLG.CurrentPageIndex + 1, Me.grdKQJLG.PageCount)
                Me.grdKQJLG.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub doMovePrevious_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdKQJLG.CurrentPageIndex - 1, Me.grdKQJLG.PageCount)
                Me.grdKQJLG.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub doGotoPage_RSLYGL(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtRSLYGLPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdKQJLG.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtRSLYGLPageIndex.Text = (Me.grdKQJLG.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_RSLYGL(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtRSLYGLPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdKQJLG.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtRSLYGLPageSize.Text = (Me.grdKQJLG.PageSize).ToString()

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

        Private Sub doSelectAll_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdKQJLG, 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL, True) = False Then
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

        Private Sub doDeSelectAll_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdKQJLG, 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL, False) = False Then
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

        Private Sub doSearch_RSLYGL(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub lnkCZRSLYGLMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLMoveFirst.Click
            Me.doMoveFirst_RSLYGL("lnkCZRSLYGLMoveFirst")
        End Sub

        Private Sub lnkCZRSLYGLMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLMoveLast.Click
            Me.doMoveLast_RSLYGL("lnkCZRSLYGLMoveLast")
        End Sub

        Private Sub lnkCZRSLYGLMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLMoveNext.Click
            Me.doMoveNext_RSLYGL("lnkCZRSLYGLMoveNext")
        End Sub

        Private Sub lnkCZRSLYGLMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLMovePrev.Click
            Me.doMovePrevious_RSLYGL("lnkCZRSLYGLMovePrev")
        End Sub

        Private Sub lnkCZRSLYGLGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLGotoPage.Click
            Me.doGotoPage_RSLYGL("lnkCZRSLYGLGotoPage")
        End Sub

        Private Sub lnkCZRSLYGLSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLSetPageSize.Click
            Me.doSetPageSize_RSLYGL("lnkCZRSLYGLSetPageSize")
        End Sub

        Private Sub lnkCZRSLYGLSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLSelectAll.Click
            Me.doSelectAll_RSLYGL("lnkCZRSLYGLSelectAll")
        End Sub

        Private Sub lnkCZRSLYGLDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLDeSelectAll.Click
            Me.doDeSelectAll_RSLYGL("lnkCZRSLYGLDeSelectAll")
        End Sub












        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Function doRefresh(ByRef strErrMsg As String) As Boolean

            doRefresh = False

            Try
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub doPrint(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_KAOQINJILU
            'Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_GONGZIBIAO
            Dim objsystemKaoqinguanli As New Josco.JSOA.BusinessFacade.systemKaoqinguanli
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDateSet As Josco.JSOA.Common.Data.kaoqinguanliData
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim strWYBS As String = ""
            Dim strWhere As String
            Dim objDateSet_temp As New System.Data.DataSet
            Dim objsysCommon As Josco.JsKernal.BusinessFacade.systemCommon
            Dim strSQL As String


            Try
                'If objsystemEstateRenshiXingye.getPrintRyxxData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserXM, strWhere, objDateSet) = False Then
                '      GoTo errProc
                '  End If

                'strSQL = ""
                'strSQL = strSQL + " "
                'strSQL = strSQL + " select 人员代码,组织代码,类型,组织名称,人员名称,身份证号,是否离职 from"
                'strSQL = strSQL + " ("
                'strSQL = strSQL + " select 人员代码,a.组织代码,组织名称,人员名称,身份证号,是否离职=是否有效,类型=1 from gzcjxyDB.dbo.公共_B_人员 a left join gzcjxyDB.dbo.公共_B_组织机构 b on a.组织代码=b.组织代码 where b.组织代码 like '0102%' and b.组织代码<>'0102'"
                'strSQL = strSQL + " union"
                'strSQL = strSQL + " select 人员代码,a.组织代码,组织名称,人员名称,身份证号,是否离职=是否有效,类型=2 from gzcjxyDB_sy.dbo.公共_B_人员 a left join gzcjxyDB_sy.dbo.公共_B_组织机构 b on a.组织代码=b.组织代码 where b.组织代码 like '0102%' and b.组织代码<>'0102'"
                'strSQL = strSQL + " union"
                'strSQL = strSQL + " select 人员代码,a.组织代码,组织名称,人员名称,身份证号,是否离职=是否有效,类型=3 from gzcjxyDB_slb.dbo.公共_B_人员 a left join gzcjxyDB_slb.dbo.公共_B_组织机构 b on a.组织代码=b.组织代码 where b.组织代码 like '0102%' and b.组织代码<>'0102'"
                'strSQL = strSQL + " union "
                'strSQL = strSQL + " select 人员代码,a.组织代码,组织名称,人员名称,身份证号,是否离职=是否有效,类型=4 from gzcjxyDB_zb.dbo.公共_B_人员 a left join gzcjxyDB_zb.dbo.公共_B_组织机构 b on a.组织代码=b.组织代码"
                'strSQL = strSQL + " )a order by 类型,组织代码,是否离职,人员代码"

                'If objsysCommon.getDataSetBySQL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strSQL, objDateSet_temp) = False Then
                '    GoTo errProc
                'End If

                Dim strNF As String = ""
                Dim strYF As String = ""
                Dim strZZDM As String = ""
                strNF = Me.ddlNF.SelectedValue
                strYF = Me.ddlYF.SelectedValue
                strZZDM = Me.htxtBM.Value.Trim

                If strControlId = "btnPrintAll" Then
                    If objsystemKaoqinguanli.getDataSetKqjl_Print(strErrMsg, MyBase.UserId, MyBase.UserPassword, strNF, strYF, strZZDM, m_objDataSet_RSLYGL, "") = False Then
                        GoTo errProc
                    End If
                Else
                    If objsystemKaoqinguanli.getDataSetKqjl_Print(strErrMsg, MyBase.UserId, MyBase.UserPassword, strNF, strYF, strZZDM, m_objDataSet_RSLYGL) = False Then
                        GoTo errProc
                    End If
                End If

                If m_objDataSet_RSLYGL.Tables(strTable) Is Nothing Then
                    strErrMsg = "错误：获取数据时出错！"
                    GoTo errProc
                End If
                With m_objDataSet_RSLYGL.Tables(strTable)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有要输出的数据！"
                        GoTo errProc
                    End If
                End With


                '检查模版文件
                Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "考勤表interval.xls"
                'Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "人员名单表.xls"

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
                If objsystemKaoqinguanli.doExportToExcel(strErrMsg, m_objDataSet_RSLYGL, strTempSpec) = False Then
                    GoTo errProc
                End If
                'If objsystemKaoqinguanli.doExportToExcel(strErrMsg, objDateSet_temp, strTempSpec) = False Then
                '    GoTo errProc
                'End If

                '显示Excel
                Dim strTempUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strTempFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strTempUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)

            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doPrintWages(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_GONGZIBIAO
            Dim objsystemKaoqinguanli As New Josco.JSOA.BusinessFacade.systemKaoqinguanli
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDateSet As Josco.JSOA.Common.Data.kaoqinguanliData
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim strWYBS As String = ""
            Dim strWhere As String

            Try
                'If objsystemEstateRenshiXingye.getPrintRyxxData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserXM, strWhere, objDateSet) = False Then
                '      GoTo errProc
                '  End If

                Dim strNF As String = ""
                Dim strYF As String = ""
                Dim strZZDM As String = ""
                strNF = Me.ddlNF.SelectedValue
                strYF = Me.ddlYF.SelectedValue
                strZZDM = Me.htxtBM.Value.Trim


                If objsystemKaoqinguanli.getDataSetKqjl_Print(strErrMsg, MyBase.UserId, MyBase.UserPassword, strNF, strYF, strZZDM, m_objDataSet_RSLYGL, 0) = False Then
                    GoTo errProc
                End If


                If m_objDataSet_RSLYGL.Tables(strTable) Is Nothing Then
                    strErrMsg = "错误：获取数据时出错！"
                    GoTo errProc
                End If
                With m_objDataSet_RSLYGL.Tables(strTable)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有要输出的数据！"
                        GoTo errProc
                    End If
                End With


                '检查模版文件
                Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "工资表1.xls"

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
                If objsystemKaoqinguanli.doExportToExcel(strErrMsg, m_objDataSet_RSLYGL, strTempSpec) = False Then
                    GoTo errProc
                End If

                '显示Excel
                Dim strTempUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strTempFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strTempUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)

            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub


        '----------------------------------------------------------------
        ' 返回上级
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doClose(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strUrl As String

            doClose = False

            Try
                '返回到调用模块，并附加返回参数
                Dim strSessionId As String
                If Me.m_blnInterface = True Then
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


        '----------------------------------------------------------------
        ' 返回上级
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doAdd(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objsystemKaoqinguanli As New Josco.JSOA.BusinessFacade.systemKaoqinguanli
            Dim intStep As Integer

            Dim strCheck As String
            Dim intSW As Integer = 0
            Dim intXW As Integer = 0
            Dim rblLX As String
            Dim strWC As String
            Dim intSJLX As Integer


            doAdd = False

            Try
                Dim strRQ As String = ""
                Dim strKQRQ() As String
                Dim intCount_RQ As Integer

                If Me.chkSW.Checked = False And Me.chkXW.Checked = False Then
                    strErrMsg = "提示:您还没有选择任何一个考勤时段！请查证！"
                    GoTo errProc
                End If

                If Me.rblkqlx.SelectedIndex >= 0 And (Me.chkWC.Checked = True Or Me.chkCD.Checked = True Or Me.chkDR.Checked = True Or Me.chkDC.Checked = True) Then
                    strErrMsg = "提示:您不能同时选择考勤类型和其他！请查证！"
                    GoTo errProc
                End If

                If Me.chkWC.Checked = True And Me.txtWC.Text.Trim = "" Then
                    strErrMsg = "提示:您选择了外出，却没有填写目的地！请查证！"
                    GoTo errProc
                End If

                If Me.chkCD.Checked = True And Me.txtCD.Text.Trim = "" Then
                    strErrMsg = "提示:您选择了迟到，却没有填写迟到时间！请查证！"
                    GoTo errProc
                End If

                If Me.chkDR.Checked = True And Me.txtDR.Text.Trim = "" Then
                    strErrMsg = "提示:您选择了调入，却没有填写调出分行！请查证！"
                    GoTo errProc
                End If

                If Me.chkDC.Checked = True And Me.txtDC.Text.Trim = "" Then
                    strErrMsg = "提示:您选择了调出，却没有填写调入分行！请查证！"
                    GoTo errProc
                End If

                strRQ = Me.txtDay.Text.Trim
                strKQRQ = strRQ.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray())
                intCount_RQ = strKQRQ.Length

                If intCount_RQ < 1 Then
                    strErrMsg = "提示:您没有选择日期！请查证！"
                    GoTo errProc
                End If

                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdKQJLG.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdKQJLG.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要考勤的人员！"
                        GoTo errProc
                    End If
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备更新选定的[" + intSelect.ToString() + "]个人员的考勤吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim intPos As Integer
                    Dim intIndex As Integer
                    Dim strRYMC As String
                    Dim strJLDM As String = ""
                    Dim strKQJL As String = ""
                    Dim strZZDM As String = Me.htxtBM.Value
                    Dim strRYDM As String = ""

                    Dim j As Integer
                    Dim k As Integer


                    objNewData = New System.Collections.Specialized.NameValueCollection

                    '获取考勤时段，1-上午，2-下午
                    If Me.chkSW.Checked = True And Me.chkXW.Checked = True Then
                        intSJLX = 3
                    Else
                        If Me.chkSW.Checked = True Then
                            intSJLX = 1
                        Else
                            If Me.chkXW.Checked = True Then
                                intSJLX = 2
                            End If
                        End If
                    End If

                    '获取考勤类型
                    If Me.chkWC.Checked = False And Me.chkCD.Checked = False And Me.chkDR.Checked = False And Me.chkDC.Checked = False Then
                        strJLDM = Me.rblkqlx.SelectedValue
                        strKQJL = Me.rblkqlx.SelectedItem.Text
                    Else
                        If Me.chkWC.Checked = True Then
                            strJLDM = Josco.JSOA.Common.Data.kaoqinguanliData.strWCDM
                            strKQJL = Me.txtWC.Text.Trim
                        End If

                        If Me.chkCD.Checked = True Then
                            strJLDM = Josco.JSOA.Common.Data.kaoqinguanliData.strCD
                            strKQJL = "迟" + Me.txtCD.Text.Trim + "分"
                        End If

                        If Me.chkDC.Checked = True Then
                            strJLDM = Josco.JSOA.Common.Data.kaoqinguanliData.strDC
                            strKQJL = "调去" + Me.txtDC.Text.Trim
                        End If

                        If Me.chkDR.Checked = True Then
                            strJLDM = Josco.JSOA.Common.Data.kaoqinguanliData.strDR
                            strKQJL = Me.txtDR.Text.Trim + "调入"
                        End If
                    End If




                    '检查所有选择人员是否可以进行更新
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdKQJLG.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL) = True Then
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdKQJLG.CurrentPageIndex, Me.grdKQJLG.PageSize)
                            objNewData.Clear()
                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdKQJLG, Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_VT_KAOQINJILU_RYDM)
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdKQJLG.Items(i), intIndex)

                            '判断


                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdKQJLG, Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_VT_KAOQINJILU_RYMC)
                            strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdKQJLG.Items(i), intIndex)


                            'intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdKQJLG, Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_VT_KAOQINJILU_ZZDM)
                            'strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdKQJLG.Items(i), intIndex)

                            '检查人员的休假情况
                            If strJLDM <> Josco.JSOA.Common.Data.kaoqinguanliData.strWCDM Then
                                '检查休息日
                                If strJLDM = Josco.JSOA.Common.Data.kaoqinguanliData.strXXR Then
                                    ''当月已打休息日天数
                                    'Dim dblKaoqinDay As Double
                                    'Dim dblVacationDay As Double
                                    'Dim strDate As String = ""
                                    'Dim dblDay As Double

                                    'If objsystemKaoqinguanli.getMonthKaoqin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strJLDM, strKQRQ(0), dblKaoqinDay) = False Then
                                    '    GoTo errProc
                                    'End If

                                    ''当月应休假天数
                                    'If objsystemKaoqinguanli.getMonthVacation(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strZZDM, strKQRQ(0), dblVacationDay) = False Then
                                    '    GoTo errProc
                                    'End If

                                    ''考勤更新天数
                                    'If intSJLX = 3 Then
                                    '    dblDay = CType(intCount_RQ, Double)
                                    'Else
                                    '    dblDay = CType(intCount_RQ / 2, Double)
                                    'End If

                                    ''计算是否可以继续
                                    'If dblKaoqinDay + dblDay - dblVacationDay > 0 Then
                                    '    strErrMsg = "提示:[" + strRYMC + "]要更新的休息天数已超过本月应休天数！请查证！"
                                    '    GoTo errProc
                                    'End If

                                    'strRYDM,intCount,intSJLX
                                End If

                                '检查补休
                                If strJLDM = Josco.JSOA.Common.Data.kaoqinguanliData.strBX Then
                                    '检查应休假是否用完
                                    '当月已打休息日天数
                                    'Dim dblKaoqinDay As Double
                                    'Dim dblVacationDay As Double
                                    'Dim strDate As String = ""
                                    'Dim dblDay As Double

                                    'If objsystemKaoqinguanli.getMonthKaoqin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, Josco.JSOA.Common.Data.kaoqinguanliData.strXXR, strKQRQ(0), dblKaoqinDay) = False Then
                                    '    GoTo errProc
                                    'End If

                                    ''当月应休假天数
                                    'If objsystemKaoqinguanli.getMonthVacation(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strZZDM, strKQRQ(0), dblVacationDay) = False Then
                                    '    GoTo errProc
                                    'End If

                                    ''计算是否可以继续
                                    'If dblVacationDay - dblKaoqinDay > 0 Then
                                    '    strErrMsg = "提示:[" + strRYMC + "]本月的应休天数,未休完！用完应休天数才能使用补休！请查证！"
                                    '    GoTo errProc
                                    'End If

                                    '是否还有补休

                                End If

                                '检查年休假
                                If strJLDM = Josco.JSOA.Common.Data.kaoqinguanliData.strNXJ Then
                                    '检查年休假
                                End If
                            End If

                            '检查报到、调动、离职日期
                            If strKQJL = "离职" Then
                                If intCount_RQ > 1 Then
                                    strErrMsg = "提示：离职的日期只能选一个！"
                                    GoTo errProc
                                End If
                            End If

                            If strKQJL = "入职" Then
                                If intCount_RQ > 1 Then
                                    strErrMsg = "提示：入职的日期只能选一个！"
                                    GoTo errProc
                                End If
                            End If
                            For k = 0 To intCount_RQ - 1 Step 1

                            Next
                        End If
                    Next

                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdKQJLG.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL) = True Then
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdKQJLG.CurrentPageIndex, Me.grdKQJLG.PageSize)

                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdKQJLG, Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_VT_KAOQINJILU_RYDM)
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdKQJLG.Items(i), intIndex)

                            For k = 0 To intCount_RQ - 1 Step 1
                                If intSJLX = 3 Then
                                    For j = 1 To 2 Step 1
                                        objNewData.Clear()
                                        objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_SJLX, j.ToString)
                                        objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_JLDM, strJLDM)
                                        objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_KQJL, strKQJL)
                                        objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_ZZDM, strZZDM)
                                        objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RYDM, strRYDM)
                                        objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RQ, strKQRQ(k))

                                        '相应处理
                                        If objsystemKaoqinguanli.doAdd_Kaoqinjilu( _
                                            strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                                             objNewData) = False Then
                                            GoTo errProc
                                        End If

                                        '记录日志
                                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]对[" + strRYDM + "]更新了" + strKQRQ(k) + j.ToString + "[考勤记录]！")

                                    Next
                                Else
                                    objNewData.Clear()
                                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_SJLX, intSJLX.ToString)
                                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_JLDM, strJLDM)
                                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_KQJL, strKQJL)
                                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_ZZDM, strZZDM)
                                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RYDM, strRYDM)
                                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RQ, strKQRQ(k))

                                    '相应处理
                                    If objsystemKaoqinguanli.doAdd_Kaoqinjilu( _
                                        strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                                         objNewData) = False Then
                                        GoTo errProc
                                    End If

                                    '记录日志
                                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]对[" + strRYDM + "]更新了" + strKQRQ(k) + j.ToString + "[考勤记录]！")

                                End If
                            Next
                        End If
                    Next

                    If Me.doRefresh(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)
            doAdd = True
            Exit Function

errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)
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
        Private Function doDelete(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objsystemKaoqinguanli As New Josco.JSOA.BusinessFacade.systemKaoqinguanli
            Dim intStep As Integer

            Dim strCheck As String
            Dim intSW As Integer = 0
            Dim intXW As Integer = 0
            Dim rblLX As String
            Dim strWC As String
            Dim intSJLX As Integer


            doDelete = False

            Try
                Dim strRQ As String = ""
                Dim strKQRQ() As String
                Dim intCount_RQ As Integer

                If Me.chkSW.Checked = False And Me.chkXW.Checked = False Then
                    strErrMsg = "提示:您还没有选择任何一个考勤时段！请查证！"
                    GoTo errProc
                End If

                strRQ = Me.txtDay.Text.Trim
                strKQRQ = strRQ.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray())
                intCount_RQ = strKQRQ.Length

                If intCount_RQ < 1 Then
                    strErrMsg = "提示:您没有选择日期！请查证！"
                    GoTo errProc
                End If

                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdKQJLG.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdKQJLG.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要考勤的人员！"
                        GoTo errProc
                    End If
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备更新选定的[" + intSelect.ToString() + "]个人员的考勤吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim intPos As Integer
                    Dim intIndex As Integer
                    Dim strRYMC As String
                    Dim strJLDM As String = ""
                    Dim strKQJL As String = ""
                    Dim strZZDM As String = Me.htxtBM.Value
                    Dim strRYDM As String = ""

                    Dim j As Integer
                    Dim k As Integer


                    objNewData = New System.Collections.Specialized.NameValueCollection

                    '获取考勤时段，1-上午，2-下午
                    If Me.chkSW.Checked = True And Me.chkXW.Checked = True Then
                        intSJLX = 3
                    Else
                        If Me.chkSW.Checked = True Then
                            intSJLX = 1
                        Else
                            If Me.chkXW.Checked = True Then
                                intSJLX = 2
                            End If
                        End If
                    End If

                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdKQJLG.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL) = True Then
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdKQJLG.CurrentPageIndex, Me.grdKQJLG.PageSize)

                            intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdKQJLG, Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_VT_KAOQINJILU_RYDM)
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdKQJLG.Items(i), intIndex)

                            For k = 0 To intCount_RQ - 1 Step 1
                                If intSJLX = 3 Then
                                    For j = 1 To 2 Step 1
                                        objNewData.Clear()
                                        objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_SJLX, j.ToString)
                                        objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_ZZDM, strZZDM)
                                        objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RYDM, strRYDM)
                                        objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RQ, strKQRQ(k))

                                        '相应处理
                                        If objsystemKaoqinguanli.doDelete_Kaoqinjilu( _
                                            strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                                             objNewData) = False Then
                                            GoTo errProc
                                        End If

                                        '记录日志
                                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]对[" + strRYDM + "]删除了" + strKQRQ(k) + j.ToString + "[考勤记录]！")

                                    Next
                                Else
                                    objNewData.Clear()
                                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_SJLX, intSJLX.ToString)
                                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_ZZDM, strZZDM)
                                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RYDM, strRYDM)
                                    objNewData.Add(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RQ, strKQRQ(k))

                                    '相应处理
                                    If objsystemKaoqinguanli.doDelete_Kaoqinjilu( _
                                        strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                                         objNewData) = False Then
                                        GoTo errProc
                                    End If

                                    '记录日志
                                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]对[" + strRYDM + "]删除了" + strKQRQ(k) + j.ToString + "[考勤记录]！")

                                End If
                            Next
                        End If
                    Next

                    If Me.doRefresh(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)
            doDelete = True
            Exit Function

errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemKaoqinguanli.SafeRelease(objsystemKaoqinguanli)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 刷新数据
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doRefresh(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            doRefresh = False

            Try
                If Me.doRefresh(strErrMsg) = False Then
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

        Public Function spanRow(ByVal dg As System.Web.UI.WebControls.DataGrid, ByVal GroupColumn As Integer, ByVal compareColumn As Integer) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim intColIndex As Integer = -1
            Dim strWJBS As String = ""

            spanRow = False
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim rowspan As Integer
            Dim strTemp As String = ""
            For i = 0 To 1
                rowspan = 1
                strTemp = objDataGridProcess.getDataGridCellValue(Me.grdKQJLG.Items(GroupColumn), i)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdKQJLG.Items(compareColumn), i)
                If (String.Compare(strTemp, strWJBS) = 0) Then
                    rowspan = rowspan + 1
                    dg.Items(GroupColumn).Cells(i).RowSpan = rowspan
                    dg.Items(compareColumn).Cells(i).Visible = False
                End If
            Next

            For i = 34 To 36
                rowspan = 1
                strTemp = objDataGridProcess.getDataGridCellValue(Me.grdKQJLG.Items(GroupColumn), i)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdKQJLG.Items(compareColumn), i)
                If (String.Compare(strTemp, strWJBS) = 0) Then
                    rowspan = rowspan + 1
                    dg.Items(GroupColumn).Cells(i).RowSpan = rowspan
                    dg.Items(compareColumn).Cells(i).Visible = False
                End If
            Next

            spanRow = True

        End Function

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If doClose(strErrMsg, "btnClose") = False Then
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

        Private Sub btnADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnADD.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If doAdd(strErrMsg, "btnADD") = False Then
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

        Private Sub btnDELETE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDELETE.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If doDelete(strErrMsg, "btnDELETE") = False Then
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

        Private Sub ddlNF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNF.SelectedIndexChanged
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.searchModuleData_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub ddlYF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYF.SelectedIndexChanged
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.searchModuleData_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub btnFPBM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFPBM.Click
            Me.doSelect_ZZDM("btnFPBM")
        End Sub

        Private Sub btnSelect_DCDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_DCDW.Click
            Me.doSelect_ZZDM("btnSelect_DCDW")
        End Sub

        Private Sub btnSelect_DRDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_DRDW.Click
            Me.doSelect_ZZDM("btnSelect_DRDW")
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


        Protected Sub chkCD_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCD.CheckedChanged
            If Me.chkCD.Checked = True Then
                Me.chkDR.Checked = False
                Me.chkDC.Checked = False
                Me.chkWC.Checked = False
                Me.rblkqlx.SelectedValue = Nothing
            End If
        End Sub

        Protected Sub chkWC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkWC.CheckedChanged
            If Me.chkWC.Checked = True Then
                Me.chkDR.Checked = False
                Me.chkDC.Checked = False
                Me.chkCD.Checked = False
                Me.rblkqlx.SelectedValue = Nothing
            End If
        End Sub

        Protected Sub chkDR_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDR.CheckedChanged
            If Me.chkDR.Checked = True Then
                Me.chkWC.Checked = False
                Me.chkDC.Checked = False
                Me.chkCD.Checked = False
                Me.rblkqlx.SelectedValue = Nothing
            End If
        End Sub

        Protected Sub chkDC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDC.CheckedChanged
            If Me.chkDC.Checked = True Then
                Me.chkWC.Checked = False
                Me.chkDR.Checked = False
                Me.chkCD.Checked = False
                Me.rblkqlx.SelectedValue = Nothing
            End If
        End Sub

        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Me.doPrint("btnPrint")
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


        Private Sub btnPrintAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintAll.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Me.doPrint("btnPrintAll")
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

        Private Sub btnPrintWages_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintWages.Click
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Me.doPrintWages("btnPrintWages")
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

    End Class
End Namespace