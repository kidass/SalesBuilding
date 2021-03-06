﻿Imports System.Web.Security

Namespace Josco.JSOA.web
    '----------------------------------------------------------------
    ' 命名空间：Josco.JsKernal.web
    ' 类名    ：ggdm_bmry
    ' 
    ' 调用性质：
    '     独立运行
    '
    ' 功能描述： 
    '   　“公共_B_人员”、“公共_B_组织机构”代码处理模块

    Partial Public Class staff_manager
        Inherits Josco.JsKernal.web.PageBase
        '----------------------------------------------------------------
        '模块私用参数
        '----------------------------------------------------------------
        '本模块相对image的相对路径
        Private m_cstrRelativePathToImage As String = "../../"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "ggdm_bmry_previlege_param"
        Private m_blnPrevilegeParams(11) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JsKernal.BusinessFacade.IMGgdmBmry
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JsKernal.BusinessFacade.IGgdmBmry
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdBMRY相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_BMRY As String = "chkBMRY"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_BMRY As String = "divBMRY"
        '网格要锁定的列数
        Private m_intFixedColumns_BMRY As Integer

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objDataSet_BMXX As Josco.JsKernal.Common.Data.CustomerData
        Private m_objDataSet_BMRY As Josco.JSOA.Common.Data.staffData
        Private m_strQuery_BMRY As String '记录m_objDataSet_BMRY搜索串
        Private m_intRows_BMRY As Integer '记录m_objDataSet_BMRY的DefaultView记录数







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
                    Me.htxtBMRYQuery.Value = .htxtBMRYQuery
                    Me.htxtBMRYRows.Value = .htxtBMRYRows
                    Me.htxtBMRYSort.Value = .htxtBMRYSort
                    Me.htxtBMRYSortColumnIndex.Value = .htxtBMRYSortColumnIndex
                    Me.htxtBMRYSortType.Value = .htxtBMRYSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftBMRY.Value = .htxtDivLeftBMRY
                    Me.htxtDivTopBMRY.Value = .htxtDivTopBMRY

                    Me.txtBMRYPageIndex.Text = .txtBMRYPageIndex
                    Me.txtBMRYPageSize.Text = .txtBMRYPageSize

                    Me.txtBMRYSearch_RYMC.Text = .txtBMRYSearch_RYMC
                    Me.txtBMRYSearch_RYXHMin.Text = .txtBMRYSearch_RYXHMin
                    Me.txtBMRYSearch_RYXHMax.Text = .txtBMRYSearch_RYXHMax
                    Me.txtBMRYSearch_RYJBMC.Text = .txtBMRYSearch_RYJBMC
                    Me.txtBMRYSearch_RYDRZW.Text = .txtBMRYSearch_RYDRZW

                    Try
                        Me.grdBMRY.PageSize = .grdBMRYPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBMRY.CurrentPageIndex = .grdBMRYCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    'Try
                    '    Me.grdBMRY.SelectedIndex = .grdBMRYSelectedIndex
                    'Catch ex As Exception
                    'End Try

                    Try
                        Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                        objTreeNode = Me.tvwBMLIST.GetNodeFromIndex(.tvwBMLISTSelectedNodeIndex)
                        If Not (objTreeNode Is Nothing) Then
                            Me.tvwBMLIST.SelectedNodeIndex = .tvwBMLISTSelectedNodeIndex
                        End If
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

            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '创建SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then Exit Try

                '创建对象
                Me.m_objSaveScence = New Josco.JsKernal.BusinessFacade.IMGgdmBmry

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtBMRYQuery = Me.htxtBMRYQuery.Value
                    .htxtBMRYRows = Me.htxtBMRYRows.Value
                    .htxtBMRYSort = Me.htxtBMRYSort.Value
                    .htxtBMRYSortColumnIndex = Me.htxtBMRYSortColumnIndex.Value
                    .htxtBMRYSortType = Me.htxtBMRYSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftBMRY = Me.htxtDivLeftBMRY.Value
                    .htxtDivTopBMRY = Me.htxtDivTopBMRY.Value

                    .txtBMRYPageIndex = Me.txtBMRYPageIndex.Text
                    .txtBMRYPageSize = Me.txtBMRYPageSize.Text

                    .txtBMRYSearch_RYMC = Me.txtBMRYSearch_RYMC.Text
                    .txtBMRYSearch_RYXHMin = Me.txtBMRYSearch_RYXHMin.Text
                    .txtBMRYSearch_RYXHMax = Me.txtBMRYSearch_RYXHMax.Text
                    .txtBMRYSearch_RYJBMC = Me.txtBMRYSearch_RYJBMC.Text
                    .txtBMRYSearch_RYDRZW = Me.txtBMRYSearch_RYDRZW.Text

                    .grdBMRYPageSize = Me.grdBMRY.PageSize
                    .grdBMRYCurrentPageIndex = Me.grdBMRY.CurrentPageIndex
                    .grdBMRYSelectedIndex = Me.grdBMRY.SelectedIndex

                    .tvwBMLISTSelectedNodeIndex = Me.tvwBMLIST.SelectedNodeIndex()
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule( _
            ByRef strErrMsg As String) As Boolean

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '=================================================================
                Dim objIGgdmBmryBmxx As Josco.JsKernal.BusinessFacade.IGgdmBmryBmxx
                Try
                    objIGgdmBmryBmxx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IGgdmBmryBmxx)
                Catch ex As Exception
                    objIGgdmBmryBmxx = Nothing
                End Try
                If Not (objIGgdmBmryBmxx Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIGgdmBmryBmxx.Dispose()
                    objIGgdmBmryBmxx = Nothing
                    Exit Try
                End If

                '=================================================================
                Dim objIGgdmBmryRyxx As Josco.JsKernal.BusinessFacade.IGgdmBmryRyxx
                Try
                    objIGgdmBmryRyxx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IGgdmBmryRyxx)
                Catch ex As Exception
                    objIGgdmBmryRyxx = Nothing
                End Try
                If Not (objIGgdmBmryRyxx Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIGgdmBmryRyxx.Dispose()
                    objIGgdmBmryRyxx = Nothing
                    Exit Try
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getDataFromCallModule = True
            Exit Function
errProc:
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
        ' 获取接口参数(没有接口参数则显示错误信息页面)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JsKernal.BusinessFacade.IGgdmBmry)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JsKernal.BusinessFacade.IMGgdmBmry)
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
                With objPulicParameters
                    '记录m_objDataSet_BMRY的DefaultView记录数
                    Me.m_intRows_BMRY = .getObjectValue(Me.htxtBMRYRows.Value, 0)
                    Me.m_strQuery_BMRY = Me.htxtBMRYQuery.Value

                    Me.m_intFixedColumns_BMRY = .getObjectValue(Me.htxtBMRYFixed.Value, 0)
                End With

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

            Catch ex As Exception

            End Try

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 获取grdBMRY的搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_BMRY( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_BMRY = False
            strQuery = ""

            Try
                '按人员名称搜索
                Dim strRYMC As String
                strRYMC = "a." + Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYMC
                If Me.txtBMRYSearch_RYMC.Text.Length > 0 Then Me.txtBMRYSearch_RYMC.Text = Me.txtBMRYSearch_RYMC.Text.Trim()
                If Me.txtBMRYSearch_RYMC.Text <> "" Then
                    Me.txtBMRYSearch_RYMC.Text = objPulicParameters.getNewSearchString(Me.txtBMRYSearch_RYMC.Text)
                    If strQuery = "" Then
                        strQuery = strRYMC + " like '" + Me.txtBMRYSearch_RYMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYMC + " like '" + Me.txtBMRYSearch_RYMC.Text + "%'"
                    End If
                End If

                '按人员序号搜索
                Dim strRYXH As String
                Dim intMin As Integer
                Dim intMax As Integer
                strRYXH = "a." + Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYXH
                If Me.txtBMRYSearch_RYXHMin.Text.Length > 0 Then Me.txtBMRYSearch_RYXHMin.Text = Me.txtBMRYSearch_RYXHMin.Text.Trim()
                If Me.txtBMRYSearch_RYXHMax.Text.Length > 0 Then Me.txtBMRYSearch_RYXHMax.Text = Me.txtBMRYSearch_RYXHMax.Text.Trim()
                If Me.txtBMRYSearch_RYXHMin.Text <> "" And Me.txtBMRYSearch_RYXHMax.Text <> "" Then
                    intMin = objPulicParameters.getObjectValue(Me.txtBMRYSearch_RYXHMin.Text, 1)
                    intMax = objPulicParameters.getObjectValue(Me.txtBMRYSearch_RYXHMax.Text, 1)
                    If intMin > intMax Then
                        Me.txtBMRYSearch_RYXHMin.Text = intMax.ToString()
                        Me.txtBMRYSearch_RYXHMax.Text = intMin.ToString()
                    Else
                        Me.txtBMRYSearch_RYXHMin.Text = intMin.ToString()
                        Me.txtBMRYSearch_RYXHMax.Text = intMax.ToString()
                    End If
                    If strQuery = "" Then
                        strQuery = strRYXH + " between " + Me.txtBMRYSearch_RYXHMin.Text + " and " + Me.txtBMRYSearch_RYXHMax.Text
                    Else
                        strQuery = strQuery + " and " + strRYXH + " between " + Me.txtBMRYSearch_RYXHMin.Text + " and " + Me.txtBMRYSearch_RYXHMax.Text
                    End If
                ElseIf Me.txtBMRYSearch_RYXHMin.Text <> "" Then
                    intMin = objPulicParameters.getObjectValue(Me.txtBMRYSearch_RYXHMin.Text, 1)
                    Me.txtBMRYSearch_RYXHMin.Text = intMin.ToString()
                    If strQuery = "" Then
                        strQuery = strRYXH + " >= " + Me.txtBMRYSearch_RYXHMin.Text
                    Else
                        strQuery = strQuery + " and " + strRYXH + " >= " + Me.txtBMRYSearch_RYXHMin.Text
                    End If
                ElseIf Me.txtBMRYSearch_RYXHMax.Text <> "" Then
                    intMax = objPulicParameters.getObjectValue(Me.txtBMRYSearch_RYXHMax.Text, 1)
                    Me.txtBMRYSearch_RYXHMax.Text = intMax.ToString()
                    If strQuery = "" Then
                        strQuery = strRYXH + " <= " + Me.txtBMRYSearch_RYXHMax.Text
                    Else
                        strQuery = strQuery + " and " + strRYXH + " <= " + Me.txtBMRYSearch_RYXHMax.Text
                    End If
                Else
                End If

                '按行政级别搜索
                Dim strJBMC As String
                strJBMC = "a." + Josco.JsKernal.Common.Data.XingzhengjibieData.FIELD_GG_B_XINGZHENGJIBIE_JBMC
                If Me.txtBMRYSearch_RYJBMC.Text.Length > 0 Then Me.txtBMRYSearch_RYJBMC.Text = Me.txtBMRYSearch_RYJBMC.Text.Trim()
                If Me.txtBMRYSearch_RYJBMC.Text <> "" Then
                    Me.txtBMRYSearch_RYJBMC.Text = objPulicParameters.getNewSearchString(Me.txtBMRYSearch_RYJBMC.Text)
                    If strQuery = "" Then
                        strQuery = strJBMC + " like '" + Me.txtBMRYSearch_RYJBMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJBMC + " like '" + Me.txtBMRYSearch_RYJBMC.Text + "%'"
                    End If
                End If

                '按担任职务搜索
                Dim strGWLB As String
                strGWLB = "a." + Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_FULLJOIN_GWLB
                If Me.txtBMRYSearch_RYDRZW.Text.Length > 0 Then Me.txtBMRYSearch_RYDRZW.Text = Me.txtBMRYSearch_RYDRZW.Text.Trim()
                If Me.txtBMRYSearch_RYDRZW.Text <> "" Then
                    Me.txtBMRYSearch_RYDRZW.Text = objPulicParameters.getNewSearchString(Me.txtBMRYSearch_RYDRZW.Text)
                    If strQuery = "" Then
                        strQuery = strGWLB + " like '" + Me.txtBMRYSearch_RYDRZW.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strGWLB + " like '" + Me.txtBMRYSearch_RYDRZW.Text + "%'"
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_BMRY = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取tvwBMLIST要显示的数据信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_BMXX( _
            ByRef strErrMsg As String) As Boolean

            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getModuleData_BMXX = False

            Try
                '释放资源
                If Not (Me.m_objDataSet_BMXX Is Nothing) Then
                    Me.m_objDataSet_BMXX.Dispose()
                    Me.m_objDataSet_BMXX = Nothing
                End If

                '重新检索数据
                If objsystemCustomer.getBumenData(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_BMXX) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getModuleData_BMXX = True
            Exit Function

errProc:
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdBMRY要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_BMRY( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.staffData.TABLE_GG_B_RENYUAN_FULLJOIN
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess

            getModuleData_BMRY = False

            Try
                '从TreeView中获取组织代码
                Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                Dim strZZDM As String
                If Me.tvwBMLIST.SelectedNodeIndex = "" Then
                    strErrMsg = "错误：没有选择单位！"
                    GoTo errProc
                End If
                objTreeNode = Me.tvwBMLIST.GetNodeFromIndex(Me.tvwBMLIST.SelectedNodeIndex)
                If objTreeNode Is Nothing Then
                    strErrMsg = "错误：没有选择单位！"
                    GoTo errProc
                End If
                strZZDM = objTreeviewProcess.getCodeValueFromNodeId(objTreeNode.ID)

                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtBMRYSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objDataSet_BMRY Is Nothing) Then
                    Me.m_objDataSet_BMRY.Dispose()
                    Me.m_objDataSet_BMRY = Nothing
                End If

                '重新检索数据

                With New Josco.JSOA.DataAccess.dacStaff
                    If .getRenyuanInBumenData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZDM, True, strWhere, Me.m_objDataSet_BMRY) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复Sort字符串
                With Me.m_objDataSet_BMRY.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_BMRY.Tables(strTable)
                    Me.htxtBMRYRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_BMRY = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)

            getModuleData_BMRY = True
            Exit Function

errProc:
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdBMRY数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_BMRY(ByRef strErrMsg As String) As Boolean

            searchModuleData_BMRY = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_BMRY(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_BMRY(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_BMRY = strQuery
                Me.htxtBMRYQuery.Value = Me.m_strQuery_BMRY

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_BMRY = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示tvwBMLIST的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showTreeViewInfo_BMXX( _
            ByRef strErrMsg As String) As Boolean

            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess

            showTreeViewInfo_BMXX = False

            'TreeView显示处理
            Try
                '初始化tvwBMLIST
                If objTreeviewProcess.doDisplayTreeViewAll(strErrMsg, Me.tvwBMLIST, _
                    Me.m_objDataSet_BMXX.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU), _
                    Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZDM, _
                    Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZMC, _
                    True, True, Josco.JsKernal.Common.Data.CustomerData.intZZDM_FJCDSM) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)

            showTreeViewInfo_BMXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdBMRY的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_BMRY( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_RENYUAN_FULLJOIN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_BMRY = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtBMRYSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtBMRYSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_BMRY Is Nothing Then
                    Me.grdBMRY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_BMRY.Tables(strTable)
                        Me.grdBMRY.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_BMRY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdBMRY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdBMRY)
                    With Me.grdBMRY.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdBMRY.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdBMRY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_BMRY) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_BMRY = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdBMRY及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_BMRY( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.staffData.TABLE_GG_B_RENYUAN_FULLJOIN
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_BMRY = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_BMRY.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblBMRYGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdBMRY, .Count)
                    '显示页面浏览功能
                    Me.lnkCZBMRYMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdBMRY, .Count)
                    Me.lnkCZBMRYMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdBMRY, .Count)
                    Me.lnkCZBMRYMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdBMRY, .Count)
                    Me.lnkCZBMRYMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdBMRY, .Count)
                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZBMRYDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZBMRYSelectAll.Enabled = blnEnabled
                    Me.lnkCZBMRYGotoPage.Enabled = blnEnabled
                    Me.lnkCZBMRYSetPageSize.Enabled = blnEnabled
                End With

                '显示操作命令
                Me.lnkMLDWOpen.Enabled = Me.m_blnPrevilegeParams(1)
                Me.lnkMLDWAddNewTJ.Enabled = Me.m_blnPrevilegeParams(2)
                Me.lnkMLDWAddNewXJ.Enabled = Me.m_blnPrevilegeParams(3)
                Me.lnkMLDWUpdate.Enabled = Me.m_blnPrevilegeParams(4)
                Me.lnkMLDWDelete.Enabled = Me.m_blnPrevilegeParams(5)
                Me.lnkMLRYOpen.Enabled = Me.m_blnPrevilegeParams(6)
                Me.lnkMLRYAddNew.Enabled = Me.m_blnPrevilegeParams(7)
                Me.lnkMLRYUpdate.Enabled = Me.m_blnPrevilegeParams(8)
                Me.lnkMLRYDelete.Enabled = Me.m_blnPrevilegeParams(9)
                Me.lnkMLRYMoveUp.Enabled = Me.m_blnPrevilegeParams(10)
                Me.lnkMLRYMoveDn.Enabled = Me.m_blnPrevilegeParams(11)
                Me.lnkMLClose.Enabled = True

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_BMRY = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 初始化控件
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            initializeControls = False

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                Try
                    '根据接口参数设置
                Catch ex As Exception
                End Try

                '显示Pannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                '执行键转译(不论是否是“回发”)
                Try
                    With New Josco.JsKernal.web.ControlProcess
                        .doTranslateKey(Me.txtBMRYPageIndex)
                        .doTranslateKey(Me.txtBMRYPageSize)
                        .doTranslateKey(Me.txtBMRYSearch_RYMC)
                        .doTranslateKey(Me.txtBMRYSearch_RYXHMin)
                        .doTranslateKey(Me.txtBMRYSearch_RYXHMax)
                        .doTranslateKey(Me.txtBMRYSearch_RYJBMC)
                        .doTranslateKey(Me.txtBMRYSearch_RYDRZW)
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            End If

            If Me.IsPostBack = False Then
                '获取数据
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If
                '显示数据
                If Me.showModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If
            End If

            initializeControls = True
            Exit Function

errProc:
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

            '检查权限(不论是否回发！)
            Dim blnDo As Boolean
            If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then
                GoTo normExit
            End If

            '显示treeview
            If Me.IsPostBack = False Then
                '获取数据
                If Me.getModuleData_BMXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                '显示数据
                If Me.showTreeViewInfo_BMXX(strErrMsg) = False Then
                    GoTo errProc
                End If
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
        '实现对grdBMRY网格行、列的固定
        Sub grdBMRY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdBMRY.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_BMRY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_BMRY > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_BMRY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdBMRY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub tvwBMLIST_SelectedIndexChange(ByVal sender As Object, ByVal e As Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs) Handles tvwBMLIST.SelectedIndexChange

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '设置新索引
                Me.tvwBMLIST.SelectedNodeIndex = e.NewNode

                '获取数据
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If
                '显示数据
                If Me.showModuleData_BMRY(strErrMsg) = False Then
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

        Private Sub grdBMRY_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBMRY.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                With New Josco.JsKernal.web.DataGridProcess
                    Me.lblBMRYGridLocInfo.Text = .getDataGridLocation(Me.grdBMRY, Me.m_intRows_BMRY)
                End With
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

        Private Sub grdBMRY_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdBMRY.SortCommand

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_RENYUAN_FULLJOIN
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
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_BMRY.Tables(strTable).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_BMRY.Tables(strTable).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtBMRYSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtBMRYSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtBMRYSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMoveFirst_BMRY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdBMRY.PageCount)
                Me.grdBMRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMoveLast_BMRY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBMRY.PageCount - 1, Me.grdBMRY.PageCount)
                Me.grdBMRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMoveNext_BMRY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBMRY.CurrentPageIndex + 1, Me.grdBMRY.PageCount)
                Me.grdBMRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMovePrevious_BMRY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBMRY.CurrentPageIndex - 1, Me.grdBMRY.PageCount)
                Me.grdBMRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doGotoPage_BMRY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtBMRYPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdBMRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtBMRYPageIndex.Text = (Me.grdBMRY.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_BMRY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtBMRYPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdBMRY.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtBMRYPageSize.Text = (Me.grdBMRY.PageSize).ToString()

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

        Private Sub doSelectAll_BMRY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdBMRY, 0, Me.m_cstrCheckBoxIdInDataGrid_BMRY, True) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doDeSelectAll_BMRY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdBMRY, 0, Me.m_cstrCheckBoxIdInDataGrid_BMRY, False) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doSearch_BMRY(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_BMRY(strErrMsg) = False Then
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

        Private Sub lnkCZBMRYMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBMRYMoveFirst.Click
            Me.doMoveFirst_BMRY("lnkCZBMRYMoveFirst")
        End Sub

        Private Sub lnkCZBMRYMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBMRYMoveLast.Click
            Me.doMoveLast_BMRY("lnkCZBMRYMoveLast")
        End Sub

        Private Sub lnkCZBMRYMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBMRYMoveNext.Click
            Me.doMoveNext_BMRY("lnkCZBMRYMoveNext")
        End Sub

        Private Sub lnkCZBMRYMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBMRYMovePrev.Click
            Me.doMovePrevious_BMRY("lnkCZBMRYMovePrev")
        End Sub

        Private Sub lnkCZBMRYGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBMRYGotoPage.Click
            Me.doGotoPage_BMRY("lnkCZBMRYGotoPage")
        End Sub

        Private Sub lnkCZBMRYSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBMRYSetPageSize.Click
            Me.doSetPageSize_BMRY("lnkCZBMRYSetPageSize")
        End Sub

        Private Sub lnkCZBMRYSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBMRYSelectAll.Click
            Me.doSelectAll_BMRY("lnkCZBMRYSelectAll")
        End Sub

        Private Sub lnkCZBMRYDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBMRYDeSelectAll.Click
            Me.doDeSelectAll_BMRY("lnkCZBMRYDeSelectAll")
        End Sub

        Private Sub btnBMRYSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBMRYSearch.Click
            Me.doSearch_BMRY("btnBMRYSearch")
        End Sub










        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doOpenBumen(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                If Me.tvwBMLIST.SelectedNodeIndex = "" Then
                    strErrMsg = "错误：没有选定部门！"
                    GoTo errProc
                End If
                Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                objTreeNode = Me.tvwBMLIST.GetNodeFromIndex(Me.tvwBMLIST.SelectedNodeIndex)
                If objTreeNode Is Nothing Then
                    strErrMsg = "错误：没有选定部门！"
                    GoTo errProc
                End If
                Dim strZZDM As String
                With New Josco.JsKernal.web.TreeviewProcess
                    strZZDM = .getCodeValueFromNodeId(objTreeNode.ID)
                End With

                '备份现场参数
                Dim strSessionId As String
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIGgdmBmryBmxx As Josco.JsKernal.BusinessFacade.IGgdmBmryBmxx
                Dim strUrl As String
                objIGgdmBmryBmxx = New Josco.JsKernal.BusinessFacade.IGgdmBmryBmxx
                With objIGgdmBmryBmxx
                    .iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iZZDM = strZZDM

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
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
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strNewSessionId = .getNewGuid()
                End With
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIGgdmBmryBmxx)

                strUrl = ""
                strUrl += "../bmry/ggdm_bmry_bmxx.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

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

        Private Sub doAddNewBumenTJ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                Dim strPrevZZDM As String = ""
                Dim strZZDM As String = ""
                If Me.tvwBMLIST.SelectedNodeIndex = "" Then
                    strZZDM = ""
                    strPrevZZDM = ""
                Else
                    Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                    objTreeNode = Me.tvwBMLIST.GetNodeFromIndex(Me.tvwBMLIST.SelectedNodeIndex)
                    If objTreeNode Is Nothing Then
                        strErrMsg = "错误：没有选定部门！"
                        GoTo errProc
                    End If
                    With New Josco.JsKernal.web.TreeviewProcess
                        strZZDM = .getCodeValueFromNodeId(objTreeNode.ID)
                    End With
                    strZZDM = strZZDM.Trim()
                    With New Josco.JsKernal.Common.Utilities.PulicParameters
                        strPrevZZDM = .getPrevLevelCode(Josco.JsKernal.Common.Data.CustomerData.intZZDM_FJCDSM, strZZDM)
                    End With
                End If

                '备份现场参数
                Dim strSessionId As String
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIGgdmBmryBmxx As Josco.JsKernal.BusinessFacade.IGgdmBmryBmxx
                Dim strUrl As String
                objIGgdmBmryBmxx = New Josco.JsKernal.BusinessFacade.IGgdmBmryBmxx
                With objIGgdmBmryBmxx
                    .iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iZZDM = strZZDM
                    .iPrevZZDM = strPrevZZDM

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
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
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strNewSessionId = .getNewGuid()
                End With
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIGgdmBmryBmxx)

                strUrl = ""
                strUrl += "../bmry/ggdm_bmry_bmxx.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

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

        Private Sub doAddNewBumenXJ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                Dim strPrevZZDM As String = ""
                Dim strZZDM As String = ""
                If Me.tvwBMLIST.SelectedNodeIndex = "" Then
                    strZZDM = ""
                    strPrevZZDM = ""
                Else
                    Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                    objTreeNode = Me.tvwBMLIST.GetNodeFromIndex(Me.tvwBMLIST.SelectedNodeIndex)
                    If objTreeNode Is Nothing Then
                        strErrMsg = "错误：没有选定部门！"
                        GoTo errProc
                    End If
                    With New Josco.JsKernal.web.TreeviewProcess
                        strZZDM = .getCodeValueFromNodeId(objTreeNode.ID)
                    End With
                    strZZDM = strZZDM.Trim()
                    strPrevZZDM = strZZDM
                    '检查级别
                    With New Josco.JsKernal.Common.Utilities.PulicParameters
                        Dim intLevel As Integer
                        intLevel = .getCodeLevel(Josco.JsKernal.Common.Data.CustomerData.intZZDM_FJCDSM, strPrevZZDM.Length)
                        If intLevel >= Josco.JsKernal.Common.Data.CustomerData.intZZDM_FJCDSM.Length Then
                            strErrMsg = "错误：单位级别只允许[" + Josco.JsKernal.Common.Data.CustomerData.intZZDM_FJCDSM.Length.ToString() + "]级！"
                            GoTo errProc
                        End If
                    End With
                End If

                '备份现场参数
                Dim strSessionId As String
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIGgdmBmryBmxx As Josco.JsKernal.BusinessFacade.IGgdmBmryBmxx
                Dim strUrl As String
                objIGgdmBmryBmxx = New Josco.JsKernal.BusinessFacade.IGgdmBmryBmxx
                With objIGgdmBmryBmxx
                    .iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iZZDM = strZZDM
                    .iPrevZZDM = strPrevZZDM

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
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
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strNewSessionId = .getNewGuid()
                End With
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIGgdmBmryBmxx)

                strUrl = ""
                strUrl += "../bmry/ggdm_bmry_bmxx.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

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

        Private Sub doUpdateBumen(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                If Me.tvwBMLIST.SelectedNodeIndex = "" Then
                    strErrMsg = "错误：没有选定部门！"
                    GoTo errProc
                End If
                Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                objTreeNode = Me.tvwBMLIST.GetNodeFromIndex(Me.tvwBMLIST.SelectedNodeIndex)
                If objTreeNode Is Nothing Then
                    strErrMsg = "错误：没有选定部门！"
                    GoTo errProc
                End If
                Dim strZZDM As String
                With New Josco.JsKernal.web.TreeviewProcess
                    strZZDM = .getCodeValueFromNodeId(objTreeNode.ID)
                End With

                '备份现场参数
                Dim strSessionId As String
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIGgdmBmryBmxx As Josco.JsKernal.BusinessFacade.IGgdmBmryBmxx
                Dim strUrl As String
                objIGgdmBmryBmxx = New Josco.JsKernal.BusinessFacade.IGgdmBmryBmxx
                With objIGgdmBmryBmxx
                    .iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iZZDM = strZZDM

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
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
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strNewSessionId = .getNewGuid()
                End With
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIGgdmBmryBmxx)

                strUrl = ""
                strUrl += "../bmry/ggdm_bmry_bmxx.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

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

        Private Sub doDeleteBumen(ByVal strControlId As String)

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                Dim strZZDM As String

                '检查
                intStep = 1
                If Me.tvwBMLIST.SelectedNodeIndex = "" Then
                    strErrMsg = "错误：没有选定部门！"
                    GoTo errProc
                End If
                Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                objTreeNode = Me.tvwBMLIST.GetNodeFromIndex(Me.tvwBMLIST.SelectedNodeIndex)
                If objTreeNode Is Nothing Then
                    strErrMsg = "错误：没有选定部门！"
                    GoTo errProc
                End If
                Dim strZZMC As String
                With New Josco.JsKernal.web.TreeviewProcess
                    strZZDM = .getCodeValueFromNodeId(objTreeNode.ID)
                End With
                strZZMC = objTreeNode.Text

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：删除当前单位[" + objTreeNode.Text.Trim + "]将同时删除所有的下级单位以及单位下的人员信息，您确定要删除吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '删除处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取数据
                    If Me.getModuleData_BMXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '定位当前单位
                    Dim objOldData As System.Data.DataRow
                    With Me.m_objDataSet_BMXX.Tables(strTable)
                        .DefaultView.RowFilter = Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZDM + "=" + strZZDM
                        If .DefaultView.Count < 1 Then
                            strErrMsg = "错误：没有[" + strZZDM + "]单位的数据！"
                            GoTo errProc
                        End If
                        objOldData = .DefaultView.Item(0).Row
                    End With

                    '删除
                    With New Josco.JsKernal.BusinessFacade.systemCustomer
                        If .doDeleteZuzhijigouData(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData) = False Then
                            GoTo errProc
                        End If
                    End With

                    '刷新数据
                    If Me.getModuleData_BMXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showTreeViewInfo_BMXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_BMRY(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]删除了[" + strZZMC + "]单位！")
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

        Private Sub doOpenRenyuan(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                Dim strRYDM As String
                If Me.grdBMRY.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选定人员！"
                    GoTo errProc
                End If
                Dim intColIndex As Integer
                Dim intRow As Integer
                intRow = Me.grdBMRY.SelectedIndex
                With New Josco.JsKernal.web.DataGridProcess
                    intColIndex = .getDataGridColumnIndex(Me.grdBMRY, Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYDM)
                    strRYDM = .getDataGridCellValue(Me.grdBMRY.Items(intRow), intColIndex)
                End With

                '备份现场参数
                Dim strSessionId As String
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIGgdmBmryRyxx As Josco.JsKernal.BusinessFacade.IGgdmBmryRyxx
                Dim strUrl As String
                objIGgdmBmryRyxx = New Josco.JsKernal.BusinessFacade.IGgdmBmryRyxx
                With objIGgdmBmryRyxx
                    .iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iRYDM = strRYDM
                    .iZZDM = ""

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
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
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strNewSessionId = .getNewGuid()
                End With
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIGgdmBmryRyxx)

                strUrl = ""
                strUrl += "staff_information_role.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

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

        Private Sub doUpdateRenyuan(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                Dim strRYDM As String
                If Me.grdBMRY.SelectedIndex < 0 Then
                    strErrMsg = "错误：未选定人员！"
                    GoTo errProc
                End If

                Dim strZZDM As String
                Dim intColIndex(3) As Integer
                Dim intRow As Integer
                Dim strRYMC As String

                intRow = Me.grdBMRY.SelectedIndex
                With New Josco.JsKernal.web.DataGridProcess
                    'intColIndex = .getDataGridColumnIndex(Me.grdBMRY, Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYDM)
                    'strRYDM = .getDataGridCellValue(Me.grdBMRY.Items(intRow), intColIndex)
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdBMRY, Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYDM)
                    strRYDM = .getDataGridCellValue(Me.grdBMRY.Items(intRow), intColIndex(0))
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdBMRY, Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_ZZDM)
                    strZZDM = .getDataGridCellValue(Me.grdBMRY.Items(intRow), intColIndex(1))
                    intColIndex(2) = .getDataGridColumnIndex(Me.grdBMRY, Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYMC)
                    strRYMC = .getDataGridCellValue(Me.grdBMRY.Items(intRow), intColIndex(2))
                End With


                '备份现场参数
                Dim strSessionId As String
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIGgdmBmryRyxx As Josco.JsKernal.BusinessFacade.IGgdmBmryRyxx
                Dim strUrl As String
                objIGgdmBmryRyxx = New Josco.JsKernal.BusinessFacade.IGgdmBmryRyxx
                With objIGgdmBmryRyxx
                    .iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate



                    .iRYDM = strRYDM
                    .oRYMC = strRYMC


                    .iZZDM = strZZDM


                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
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
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strNewSessionId = .getNewGuid()
                End With
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIGgdmBmryRyxx)

                strUrl = ""

                strUrl += "staff_information_role.aspx"

                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

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

        Private Sub doAddNewRenyuan(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                Dim strZZDM As String
                If Me.tvwBMLIST.SelectedNodeIndex = "" Then
                    strZZDM = ""
                Else
                    objTreeNode = Me.tvwBMLIST.GetNodeFromIndex(Me.tvwBMLIST.SelectedNodeIndex)
                    If objTreeNode Is Nothing Then
                        strZZDM = ""
                    Else
                        With New Josco.JsKernal.web.TreeviewProcess
                            strZZDM = .getCodeValueFromNodeId(objTreeNode.ID)
                        End With
                    End If
                End If
                Dim strRYDM As String
                Dim intColIndex As Integer
                Dim intRow As Integer
                If Me.grdBMRY.SelectedIndex < 0 Then
                    strRYDM = ""
                Else
                    intRow = Me.grdBMRY.SelectedIndex
                    With New Josco.JsKernal.web.DataGridProcess
                        intColIndex = .getDataGridColumnIndex(Me.grdBMRY, Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYDM)
                        strRYDM = .getDataGridCellValue(Me.grdBMRY.Items(intRow), intColIndex)
                    End With
                End If

                '备份现场参数
                Dim strSessionId As String
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIGgdmBmryRyxx As Josco.JsKernal.BusinessFacade.IGgdmBmryRyxx
                Dim strUrl As String
                objIGgdmBmryRyxx = New Josco.JsKernal.BusinessFacade.IGgdmBmryRyxx
                With objIGgdmBmryRyxx
                    .iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iRYDM = strRYDM
                    .iZZDM = strZZDM

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
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
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strNewSessionId = .getNewGuid()
                End With
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIGgdmBmryRyxx)

                strUrl = ""
                strUrl += "../bmry/ggdm_bmry_ryxx.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

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

        Private Sub doDeleteRenyuan(ByVal strControlId As String)

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_RENYUAN_FULLJOIN
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                '检查
                Dim intSelected As Integer = 0
                Dim blnSelected As Boolean
                Dim intCount As Integer
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intCount = Me.grdBMRY.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdBMRY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_BMRY)
                        If blnSelected = True Then
                            intSelected += 1
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "错误：未选定要删除的人员！"
                        GoTo errProc
                    End If
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：删除选定人员将同时删除所有的人员担任职务信息，您确定要删除选定的[" + intSelected.ToString() + "]个人员吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '删除处理
                Dim objOldData As System.Data.DataRow
                Dim intColIndex As Integer
                Dim strRYDM As String
                Dim intRecPos As Integer
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取数据
                    If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                        GoTo errProc
                    End If

                    '逐个删除
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBMRY, Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYDM)
                    intCount = Me.grdBMRY.Items.Count
                    For i = intCount - 1 To 0 Step -1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdBMRY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_BMRY)
                        If blnSelected = True Then
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdBMRY.Items(i), intColIndex)

                            '定位当前单位
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdBMRY.CurrentPageIndex, Me.grdBMRY.PageSize)
                            With Me.m_objDataSet_BMRY.Tables(strTable)
                                objOldData = .DefaultView.Item(intRecPos).Row
                            End With

                            '删除
                            If objsystemCustomer.doDeleteRenyuanData(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData) = False Then
                                GoTo errProc
                            End If

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]删除了[" + strRYDM + "]账户！")
                        End If
                    Next

                    '刷新数据
                    If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_BMRY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Sub

        End Sub

        Private Sub doMoveDownRenyuan(ByVal strControlId As String)

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_RENYUAN_FULLJOIN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                If Me.grdBMRY.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定要移动的记录！"
                    GoTo errProc
                End If
                If Me.grdBMRY.SelectedIndex = Me.grdBMRY.Items.Count - 1 Then
                    strErrMsg = "错误：已经是最后！"
                    GoTo errProc
                End If

                '获取数据
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If

                '获取当前记录信息
                Dim objOldDataTo As System.Data.DataRow
                Dim objOldData As System.Data.DataRow
                Dim intRecPosTo As Integer
                Dim intRecPos As Integer
                Dim intColIndex As Integer
                Dim strRYDM As String
                With New Josco.JsKernal.web.DataGridProcess
                    intRecPos = .getRecordPosition(Me.grdBMRY.SelectedIndex, Me.grdBMRY.CurrentPageIndex, Me.grdBMRY.PageSize)
                    intRecPosTo = .getRecordPosition(Me.grdBMRY.SelectedIndex + 1, Me.grdBMRY.CurrentPageIndex, Me.grdBMRY.PageSize)

                    intColIndex = .getDataGridColumnIndex(Me.grdBMRY, Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYDM)
                    strRYDM = .getDataGridCellValue(Me.grdBMRY.Items(Me.grdBMRY.SelectedIndex), intColIndex)
                End With
                With Me.m_objDataSet_BMRY.Tables(strTable)
                    objOldData = .DefaultView.Item(intRecPos).Row
                    objOldDataTo = .DefaultView.Item(intRecPosTo).Row
                End With

                '移动
                If objsystemCustomer.doRenyuanMoveTo(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objOldDataTo) = False Then
                    GoTo errProc
                End If
                Me.grdBMRY.SelectedIndex += 1

                '刷新显示
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '记录审计日志
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]将[" + strRYDM + "]账户排序下移！")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

normExit:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Sub

        End Sub

        Private Sub doMoveUpRenyuan(ByVal strControlId As String)

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_RENYUAN_FULLJOIN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '检查
                If Me.grdBMRY.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定要移动的记录！"
                    GoTo errProc
                End If
                If Me.grdBMRY.SelectedIndex <= 0 Then
                    strErrMsg = "错误：已经是最前！"
                    GoTo errProc
                End If

                '获取数据
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If

                '获取当前记录信息
                Dim objOldDataTo As System.Data.DataRow
                Dim objOldData As System.Data.DataRow
                Dim intRecPosTo As Integer
                Dim intRecPos As Integer
                Dim intColIndex As Integer
                Dim strRYDM As String
                With New Josco.JsKernal.web.DataGridProcess
                    intRecPos = .getRecordPosition(Me.grdBMRY.SelectedIndex, Me.grdBMRY.CurrentPageIndex, Me.grdBMRY.PageSize)
                    intRecPosTo = .getRecordPosition(Me.grdBMRY.SelectedIndex - 1, Me.grdBMRY.CurrentPageIndex, Me.grdBMRY.PageSize)

                    intColIndex = .getDataGridColumnIndex(Me.grdBMRY, Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_RYDM)
                    strRYDM = .getDataGridCellValue(Me.grdBMRY.Items(Me.grdBMRY.SelectedIndex), intColIndex)
                End With
                With Me.m_objDataSet_BMRY.Tables(strTable)
                    objOldData = .DefaultView.Item(intRecPos).Row
                    objOldDataTo = .DefaultView.Item(intRecPosTo).Row
                End With

                '移动
                If objsystemCustomer.doRenyuanMoveTo(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objOldDataTo) = False Then
                    GoTo errProc
                End If
                Me.grdBMRY.SelectedIndex -= 1

                '刷新显示
                If Me.getModuleData_BMRY(strErrMsg, Me.m_strQuery_BMRY) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_BMRY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '记录审计日志
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]将[" + strRYDM + "]账户排序上移！")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

normExit:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
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

        Private Sub lnkMLDWOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDWOpen.Click
            Me.doOpenBumen("lnkMLDWOpen")
        End Sub

        Private Sub lnkMLDWAddNewTJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDWAddNewTJ.Click
            Me.doAddNewBumenTJ("lnkMLDWAddNewTJ")
        End Sub

        Private Sub lnkMLDWAddNewXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDWAddNewXJ.Click
            Me.doAddNewBumenXJ("lnkMLDWAddNewXJ")
        End Sub

        Private Sub lnkMLDWUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDWUpdate.Click
            Me.doUpdateBumen("lnkMLDWUpdate")
        End Sub

        Private Sub lnkMLDWDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDWDelete.Click
            Me.doDeleteBumen("lnkMLDWDelete")
        End Sub

        Private Sub lnkMLRYOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLRYOpen.Click
            Me.doOpenRenyuan("lnkMLRYOpen")
        End Sub

        Private Sub lnkMLRYUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLRYUpdate.Click
            Me.doUpdateRenyuan("lnkMLRYUpdate")
        End Sub

        Private Sub lnkMLRYAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLRYAddNew.Click
            Me.doAddNewRenyuan("lnkMLRYAddNew")
        End Sub

        Private Sub lnkMLRYDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLRYDelete.Click
            Me.doDeleteRenyuan("lnkMLRYDelete")
        End Sub

        Private Sub lnkMLRYMoveDn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLRYMoveDn.Click
            Me.doMoveDownRenyuan("lnkMLRYMoveDn")
        End Sub

        Private Sub lnkMLRYMoveUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLRYMoveUp.Click
            Me.doMoveUpRenyuan("lnkMLRYMoveUp")
        End Sub

        Private Sub lnkMLClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub



    End Class
End Namespace
