Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_yongjinjitibiaozhun
    ' 
    ' 调用性质：
    '     独立运行
    '
    ' 功能描述： 
    '   　“佣金计提标准”处理模块
    '----------------------------------------------------------------

    Partial Class estate_rs_yongjinjitibiaozhun
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
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_yongjinjitibiaozhun_previlege_param"
        Private m_blnPrevilegeParams(2) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsYongjinJitiBiaozhun
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsYongjinJitiBiaozhun
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdGY相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGY As String = "chkGY"
        Private Const m_cstrDataGridInDIV_grdGY As String = "divGY"
        Private m_intFixedColumns_grdGY As Integer
        Private Const m_cstrtxtZGZJJTInDataGrid_grdGY As String = "txtZGZJJT"
        Private Const m_cstrtxtZGBLJTInDataGrid_grdGY As String = "txtZGBLJT"
        Private Const m_cstrtxtXGZJJTInDataGrid_grdGY As String = "txtXGZJJT"
        Private Const m_cstrtxtXGBLJTInDataGrid_grdGY As String = "txtXGBLJT"

        '----------------------------------------------------------------
        '与数据网格grdSYZJ相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdSYZJ As String = "chkSYZJ"
        Private Const m_cstrDataGridInDIV_grdSYZJ As String = "divSYZJ"
        Private m_intFixedColumns_grdSYZJ As Integer

        '----------------------------------------------------------------
        '与数据网格grdSYZB相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdSYZB As String = "chkSYZB"
        Private Const m_cstrDataGridInDIV_grdSYZB As String = "divSYZB"
        Private m_intFixedColumns_grdSYZB As Integer
        Private Const m_cstrtxtQJZXInDataGrid_grdSYZB As String = "txtQJZX"
        Private Const m_cstrtxtQJZDInDataGrid_grdSYZB As String = "txtQJZD"
        Private Const m_cstrtxtJTBLInDataGrid_grdSYZB As String = "txtJTBL"

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_GY As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_SYZJ As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_SYZB As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '其他参数
        '----------------------------------------------------------------
        Private m_blnReadOnly As Boolean











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsYongjinJitiBiaozhun)
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

                    Me.htxtSessionId_GY.Value = .htxtSessionId_GY
                    Me.htxtSessionId_SYZJ.Value = .htxtSessionId_SYZJ
                    Me.htxtSessionId_SYZB.Value = .htxtSessionId_SYZB

                    Try
                        Me.grdGY.PageSize = .grdGY_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGY.CurrentPageIndex = .grdGY_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGY.SelectedIndex = .grdGY_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdSYZJ.PageSize = .grdSYZJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSYZJ.CurrentPageIndex = .grdSYZJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSYZJ.SelectedIndex = .grdSYZJ_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdSYZB.PageSize = .grdSYZB_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSYZB.CurrentPageIndex = .grdSYZB_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSYZB.SelectedIndex = .grdSYZB_SelectedIndex
                    Catch ex As Exception
                    End Try
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

            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '创建SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then
                    Exit Try
                End If

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsYongjinJitiBiaozhun

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value

                    .htxtSessionId_GY = Me.htxtSessionId_GY.Value
                    .htxtSessionId_SYZJ = Me.htxtSessionId_SYZJ.Value
                    .htxtSessionId_SYZB = Me.htxtSessionId_SYZB.Value

                    .grdGY_PageSize = Me.grdGY.PageSize
                    .grdGY_CurrentPageIndex = Me.grdGY.CurrentPageIndex
                    .grdGY_SelectedIndex = Me.grdGY.SelectedIndex

                    .grdSYZJ_PageSize = Me.grdSYZJ.PageSize
                    .grdSYZJ_CurrentPageIndex = Me.grdSYZJ.CurrentPageIndex
                    .grdSYZJ_SelectedIndex = Me.grdSYZJ.SelectedIndex

                    .grdSYZB_PageSize = Me.grdSYZB.PageSize
                    .grdSYZB_CurrentPageIndex = Me.grdSYZB.CurrentPageIndex
                    .grdSYZB_SelectedIndex = Me.grdSYZB.SelectedIndex
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            saveModuleInformation = strSessionId
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim objDataRow As System.Data.DataRow = Nothing
            Dim blnExisted As Boolean = False
            Dim strTable As String = ""

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIDmxzJbdm As Josco.JsKernal.BusinessFacade.IDmxzJbdm = Nothing
                Try
                    objIDmxzJbdm = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzJbdm)
                Catch ex As Exception
                    objIDmxzJbdm = Nothing
                End Try
                If Not (objIDmxzJbdm Is Nothing) Then
                    If objIDmxzJbdm.oExitMode = True Then
                        Select Case objIDmxzJbdm.iSourceControlId.ToUpper()
                            Case "btnAddNew_GY".ToUpper()
                                If Me.getModuleData_GY(strErrMsg) = True Then
                                    If Me.isExisted_GY(strErrMsg, objIDmxzJbdm.oCodeValue, Me.m_objDataSet_GY, blnExisted) = True Then
                                        If blnExisted = False Then
                                            strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_GY
                                            With Me.m_objDataSet_GY.Tables(strTable)
                                                objDataRow = .NewRow()
                                            End With
                                            With objIDmxzJbdm
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZJDM) = .oCodeValue
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZJMC) = .oNameValue
                                            End With
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_SYFF) = Josco.JSOA.Common.Data.estateRenshiXingyeData.YJJT_SYFF_GY
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_YJBJ) = Josco.JSOA.Common.Data.estateRenshiXingyeData.YJJT_YJBJ_TD
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZGZJJT) = 0.0
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZGBLJT) = 0.0
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_XGZJJT) = 0.0
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_XGBLJT) = 0.0
                                            With Me.m_objDataSet_GY.Tables(strTable)
                                                .Rows.Add(objDataRow)
                                            End With
                                            '记录审计日志
                                            With objIDmxzJbdm
                                                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_佣金计提标准]字典[公佣计提标准]中增加了[" + .oNameValue + "]职级(暂没保存)！")
                                            End With
                                        End If
                                    End If
                                End If
                            Case "btnAddNew_SYZJ".ToUpper()
                                If Me.getModuleData_SYZJ(strErrMsg) = True Then
                                    If Me.isExisted_SYZJ(strErrMsg, objIDmxzJbdm.oCodeValue, Me.m_objDataSet_SYZJ, blnExisted) = True Then
                                        If blnExisted = False Then
                                            strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ
                                            With Me.m_objDataSet_SYZJ.Tables(strTable)
                                                objDataRow = .NewRow()
                                            End With
                                            With objIDmxzJbdm
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZJDM) = .oCodeValue
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZJMC) = .oNameValue
                                            End With
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_SYFF) = Josco.JSOA.Common.Data.estateRenshiXingyeData.YJJT_SYFF_SY
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_YJBJ) = Josco.JSOA.Common.Data.estateRenshiXingyeData.YJJT_YJBJ_GR
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZBBJ) = Josco.JSOA.Common.Data.estateRenshiXingyeData.YJJT_ZGBJ_WX
                                            With Me.m_objDataSet_SYZJ.Tables(strTable)
                                                .Rows.Add(objDataRow)
                                            End With
                                            '记录审计日志
                                            With objIDmxzJbdm
                                                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_佣金计提标准]字典[私佣计提标准]中增加了[" + .oNameValue + "]职级(暂没保存)！")
                                            End With
                                        End If
                                    End If
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzJbdm.SafeRelease(objIDmxzJbdm)
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
        ' 获取接口参数
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsYongjinJitiBiaozhun)
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
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsYongjinJitiBiaozhun)
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

                Me.m_intFixedColumns_grdGY = objPulicParameters.getObjectValue(Me.htxtGYFixed.Value, 0)
                Me.m_intFixedColumns_grdSYZJ = objPulicParameters.getObjectValue(Me.htxtSYZJFixed.Value, 0)
                Me.m_intFixedColumns_grdSYZB = objPulicParameters.getObjectValue(Me.htxtSYZBFixed.Value, 0)

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
                Dim objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                If Me.htxtSessionId_GY.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GY.Value)
                End If

                If Me.htxtSessionId_SYZJ.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_SYZJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_SYZJ.Value)
                End If

                If Me.htxtSessionId_SYZB.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_SYZB.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_SYZB.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub










        '----------------------------------------------------------------
        ' 获取grdGY要显示的数据 - 公佣计提数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_GY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_GY
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_GY = False

            Try
                If Me.htxtSessionId_GY.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_GY = CType(Session.Item(Me.htxtSessionId_GY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GY)

                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_Yjjtbz_GY(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GY) = False Then
                        GoTo errProc
                    End If

                    '缓存数据
                    Me.htxtSessionId_GY.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_GY.Value, Me.m_objDataSet_GY)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_GY = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdSYZJ要显示的数据 - 私佣计提数据的职级部分
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_SYZJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_SYZJ = False

            Try
                If Me.htxtSessionId_SYZJ.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_SYZJ = CType(Session.Item(Me.htxtSessionId_SYZJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_SYZJ)

                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_Yjjtbz_SYZJ(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_SYZJ) = False Then
                        GoTo errProc
                    End If

                    '缓存数据
                    Me.htxtSessionId_SYZJ.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_SYZJ.Value, Me.m_objDataSet_SYZJ)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_SYZJ = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdSYZB要显示的数据 - 私佣计提数据的职级部分
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_SYZB(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZB
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_SYZB = False

            Try
                If Me.htxtSessionId_SYZB.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_SYZB = CType(Session.Item(Me.htxtSessionId_SYZB.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_SYZB)

                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_Yjjtbz_SYZB(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_SYZB) = False Then
                        GoTo errProc
                    End If

                    '缓存数据
                    Me.htxtSessionId_SYZB.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_SYZB.Value, Me.m_objDataSet_SYZB)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_SYZB = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' 保存grdGY中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_GY(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_GY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_GY = False
            strErrMsg = ""

            Try
                '保存未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGY.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGY.CurrentPageIndex, Me.grdGY.PageSize)
                    objDataRow = Me.m_objDataSet_GY.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存ZGZJJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGY.Items(i).FindControl(Me.m_cstrtxtZGZJJTInDataGrid_grdGY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[直管直接计提]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[直管直接计提]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZGZJJT) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存ZGBLJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGY.Items(i).FindControl(Me.m_cstrtxtZGBLJTInDataGrid_grdGY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[直管保留计提]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[直管保留计提]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZGBLJT) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存XGZJJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGY.Items(i).FindControl(Me.m_cstrtxtXGZJJTInDataGrid_grdGY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[协管直接计提]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[协管直接计提]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_XGZJJT) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存XGBLJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGY.Items(i).FindControl(Me.m_cstrtxtXGBLJTInDataGrid_grdGY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[协管保留计提]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[协管保留计提]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_XGBLJT) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_GY = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdGY中的非绑定数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_GY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_GY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_GY = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGY.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGY.CurrentPageIndex, Me.grdGY.PageSize)
                    objDataRow = Me.m_objDataSet_GY.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充ZGZJJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGY.Items(i).FindControl(Me.m_cstrtxtZGZJJTInDataGrid_grdGY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZGZJJT), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充ZGBLJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGY.Items(i).FindControl(Me.m_cstrtxtZGBLJTInDataGrid_grdGY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZGBLJT), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充XGZJJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGY.Items(i).FindControl(Me.m_cstrtxtXGZJJTInDataGrid_grdGY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_XGZJJT), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充XGBLJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGY.Items(i).FindControl(Me.m_cstrtxtXGBLJTInDataGrid_grdGY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_XGBLJT), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_GY = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdGY的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_GY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GY = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_GY Is Nothing Then
                    Me.grdGY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GY.Tables(strTable)
                        Me.grdGY.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_GY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdGY.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGY) = False Then
                    GoTo errProc
                End If

                '显示其他未绑定数据
                If Me.showDataGridUnboundInfo_GY(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GY = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' 保存grdSYZJ中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_SYZJ(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            saveDataGridUnboundInfo_SYZJ = False
            strErrMsg = ""

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            saveDataGridUnboundInfo_SYZJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSYZJ中的非绑定数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_SYZJ(ByRef strErrMsg As String) As Boolean

            showDataGridUnboundInfo_SYZJ = False
            strErrMsg = ""

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showDataGridUnboundInfo_SYZJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSYZJ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SYZJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_SYZJ = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_SYZJ Is Nothing Then
                    Me.grdSYZJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SYZJ.Tables(strTable)
                        Me.grdSYZJ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_SYZJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSYZJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdSYZJ.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSYZJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdSYZJ) = False Then
                    GoTo errProc
                End If

                '显示其他未绑定数据
                If Me.showDataGridUnboundInfo_SYZJ(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SYZJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' 保存grdSYZB中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_SYZB(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZB
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_SYZB = False
            strErrMsg = ""

            Try
                '保存未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdSYZB.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdSYZB.CurrentPageIndex, Me.grdSYZB.PageSize)
                    objDataRow = Me.m_objDataSet_SYZB.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存QJZX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtQJZXInDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间小值]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间小值]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZX) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存QJZD
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtQJZDInDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间大值]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间大值]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZD) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存JTBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtJTBLInDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[计提比例]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[计提比例]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_JTBL) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_SYZB = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSYZB中的非绑定数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_SYZB(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZB
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_SYZB = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdSYZB.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdSYZB.CurrentPageIndex, Me.grdSYZB.PageSize)
                    objDataRow = Me.m_objDataSet_SYZB.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充QJZX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtQJZXInDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZX), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        If i = 0 Then
                            objControlProcess.doEnabledControl(objTextBox, False)
                        Else
                            objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                        End If
                    End If

                    '填充QJZD
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtQJZDInDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZD), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, False)
                    End If

                    '填充JTBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtJTBLInDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_JTBL), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_SYZB = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSYZB的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SYZB(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZB
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_SYZB = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_SYZB Is Nothing Then
                    Me.grdSYZB.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SYZB.Tables(strTable)
                        Me.grdSYZB.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_SYZB.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSYZB, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdSYZB.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSYZB, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdSYZB) = False Then
                    GoTo errProc
                End If

                '显示其他未绑定数据
                If Me.showDataGridUnboundInfo_SYZB(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SYZB = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function









        '----------------------------------------------------------------
        ' 显示整个模块信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_Main(ByRef strErrMsg As String) As Boolean

            showModuleData_Main = False

            Try
                Me.btnAddNew_GY.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_GY.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_GY.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_GY.Visible = Not Me.m_blnReadOnly

                Me.btnAddNew_SYZJ.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_SYZJ.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_SYZJ.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_SYZJ.Visible = Not Me.m_blnReadOnly

                Me.btnAddNew_SYZB.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_SYZB.Visible = Not Me.m_blnReadOnly

                Me.btnOK.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnCancel.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnClose.Visible = Not Me.btnOK.Visible

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

            Try
                '仅在第一次调用页面时执行
                If Me.IsPostBack = False Then
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '显示Main
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '显示grdGY
                    If Me.getModuleData_GY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_GY(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '显示grdSYZJ
                    If Me.getModuleData_SYZJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_SYZJ(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '显示grdSYZB
                    If Me.getModuleData_SYZB(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_SYZB(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    '获取缓存数据
                    If Me.getModuleData_GY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_SYZJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_SYZB(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    '保存正在编辑的信息
                    If Me.saveDataGridUnboundInfo_GY(strErrMsg, False) = False Then
                        GoTo errProc
                    End If
                    If Me.saveDataGridUnboundInfo_SYZB(strErrMsg, False) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

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

            Try
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
                Me.m_blnReadOnly = Not Me.m_blnPrevilegeParams(1)

                '获取接口参数
                If Me.getInterfaceParameters(strErrMsg) = False Then
                    GoTo errProc
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











        '---------------------------------------------------------------------------------------------------------------------------
        '网格事件处理器
        '---------------------------------------------------------------------------------------------------------------------------
        Sub grdGY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGY.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGY > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdGY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdSYZJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSYZJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdSYZJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdSYZJ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdSYZJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSYZJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdSYZB_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSYZB.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdSYZB + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdSYZB > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdSYZB - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSYZB.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub











        Private Sub doSelectAll_GY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdGY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGY, True) = False Then
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

        Private Sub doDeSelectAll_GY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdGY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGY, False) = False Then
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

        Private Sub doSelectAll_SYZJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdSYZJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdSYZJ, True) = False Then
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

        Private Sub doDeSelectAll_SYZJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdSYZJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdSYZJ, False) = False Then
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













        Private Sub doDelete_GY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_GY
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                intRows = Me.grdGY.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdGY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdGY) = True Then
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
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex As Integer = 0
                    Dim strName As String = ""
                    Dim intPos As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZJMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdGY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdGY) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdGY.Items(i), intColIndex)

                            '获取要删除的数据
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdGY.CurrentPageIndex, Me.grdGY.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_GY.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            '删除处理
                            With Me.m_objDataSet_GY.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_佣金计提标准]字典[公佣计提标准]中删除了[" + strName + "]职级(暂没保存)！")
                        End If
                    Next

                    '刷新网格显示
                    If Me.showDataGridInfo_GY(strErrMsg) = False Then
                        GoTo errProc
                    End If
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

        Private Sub doDelete_SYZJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                intRows = Me.grdSYZJ.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdSYZJ.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdSYZJ) = True Then
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
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex As Integer = 0
                    Dim strName As String = ""
                    Dim intPos As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSYZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZJMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdSYZJ.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdSYZJ) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdSYZJ.Items(i), intColIndex)

                            '获取要删除的数据
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdSYZJ.CurrentPageIndex, Me.grdSYZJ.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_SYZJ.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            '删除处理
                            With Me.m_objDataSet_SYZJ.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_佣金计提标准]字典[私佣计提标准]中删除了[" + strName + "]职级(暂没保存)！")
                        End If
                    Next

                    '刷新网格显示
                    If Me.showDataGridInfo_SYZJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
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

        Private Sub doDelete_SYZB(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZB
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                '检查
                Dim i As Integer = 0
                If Me.grdSYZB.Items.Count < 1 Then
                    strErrMsg = "错误：没有内容可删除！"
                    GoTo errProc
                End If

                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备删除最后一条内容吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '逐个删除
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex(2) As Integer
                    Dim strName(2) As String
                    Dim intPos As Integer = 0
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSYZB, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZX)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSYZB, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZD)
                    i = Me.grdSYZB.Items.Count - 1
                    strName(0) = objDataGridProcess.getDataGridCellValue(Me.grdSYZB.Items(i), intColIndex(0))
                    strName(1) = objDataGridProcess.getDataGridCellValue(Me.grdSYZB.Items(i), intColIndex(1))

                    '获取要删除的数据
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdSYZB.CurrentPageIndex, Me.grdSYZB.PageSize)
                    objOldData = Nothing
                    With Me.m_objDataSet_SYZB.Tables(strTable)
                        objOldData = .DefaultView.Item(intPos).Row
                    End With

                    '删除处理
                    With Me.m_objDataSet_SYZB.Tables(strTable)
                        .Rows.Remove(objOldData)
                    End With

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_佣金计提标准]字典[私佣计提标准]中删除了[" + strName(0) + "]-[" + strName(1) + "]区间(暂没保存)！")

                    '刷新网格显示
                    If Me.showDataGridInfo_SYZB(strErrMsg) = False Then
                        GoTo errProc
                    End If
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

        Private Sub doAddNew_GY(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
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
                Dim objIDmxzJbdm As Josco.JsKernal.BusinessFacade.IDmxzJbdm = Nothing
                Dim strUrl As String = ""
                objIDmxzJbdm = New Josco.JsKernal.BusinessFacade.IDmxzJbdm
                With objIDmxzJbdm
                    .iTitle = "选择职级"
                    .iAllowInput = False
                    .iMultiSelect = False
                    .iAllowNull = False
                    .iInitValue = ""
                    .iCodeField = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJDM
                    .iNameField = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJMC
                    .iRowSourceSQL = objsystemEstateRenshiXingye.getTableSQL_ZhijiDingyi()
                    Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                    .iColWidth = "30%" + strSep + "50%" + strSep + "20%"

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
                Session.Add(strNewSessionId, objIDmxzJbdm)

                strUrl = ""
                strUrl += "../../dmxz/dmxz_jbdm.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doAddNew_SYZJ(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
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
                Dim objIDmxzJbdm As Josco.JsKernal.BusinessFacade.IDmxzJbdm = Nothing
                Dim strUrl As String = ""
                objIDmxzJbdm = New Josco.JsKernal.BusinessFacade.IDmxzJbdm
                With objIDmxzJbdm
                    .iTitle = "选择职级"
                    .iAllowInput = False
                    .iMultiSelect = False
                    .iAllowNull = False
                    .iInitValue = ""
                    .iCodeField = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJDM
                    .iNameField = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJMC
                    .iRowSourceSQL = objsystemEstateRenshiXingye.getTableSQL_ZhijiDingyi()
                    Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                    .iColWidth = "30%" + strSep + "50%" + strSep + "20%"

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
                Session.Add(strNewSessionId, objIDmxzJbdm)

                strUrl = ""
                strUrl += "../../dmxz/dmxz_jbdm.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doAddNew_SYZB(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZB
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '增加新行
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_SYZB.Tables(strTable)
                    objDataRow = .NewRow()
                End With

                '赋初始值
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_JTBL) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZX) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZD) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_SYFF) = Josco.JSOA.Common.Data.estateRenshiXingyeData.YJJT_SYFF_SY
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_YJBJ) = Josco.JSOA.Common.Data.estateRenshiXingyeData.YJJT_YJBJ_GR
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_ZBBJ) = Josco.JSOA.Common.Data.estateRenshiXingyeData.YJJT_ZGBJ_WX

                '加入新行
                With Me.m_objDataSet_SYZB.Tables(strTable)
                    .Rows.Add(objDataRow)
                End With

                '重新显示
                If Me.showDataGridInfo_SYZB(strErrMsg) = False Then
                    GoTo errProc
                End If

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

        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 1

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
                    Dim strSessionId As String = ""
                    Dim strUrl As String = ""
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

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
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

        Private Function isExisted_GY( _
            ByRef strErrMsg As String, _
            ByVal strZJDM As String, _
            ByVal objDataSet_GY As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef blnExisted As Boolean) As Boolean

            isExisted_GY = False
            strErrMsg = ""
            blnExisted = True

            Try
                '检查
                If strZJDM Is Nothing Then strZJDM = ""
                strZJDM = strZJDM.Trim
                If objDataSet_GY Is Nothing Then
                    Exit Try
                End If
                If strZJDM = "" Then
                    Exit Try
                End If

                '搜索
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With objDataSet_GY.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_GY)
                    '备份
                    strOldFilter = .DefaultView.RowFilter

                    '新条件
                    strNewFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZJDM + " = '" + strZJDM + "'"
                    .DefaultView.RowFilter = strNewFilter

                    '判断
                    If .DefaultView.Count > 0 Then
                        blnExisted = True
                    Else
                        blnExisted = False
                    End If

                    '复原
                    .DefaultView.RowFilter = strOldFilter
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            isExisted_GY = True
            Exit Function

errProc:
            Exit Function

        End Function

        Private Function isExisted_SYZJ( _
            ByRef strErrMsg As String, _
            ByVal strZJDM As String, _
            ByVal objDataSet_SYZJ As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef blnExisted As Boolean) As Boolean

            isExisted_SYZJ = False
            strErrMsg = ""
            blnExisted = True

            Try
                '检查
                If strZJDM Is Nothing Then strZJDM = ""
                strZJDM = strZJDM.Trim
                If objDataSet_SYZJ Is Nothing Then
                    Exit Try
                End If
                If strZJDM = "" Then
                    Exit Try
                End If

                '搜索
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With objDataSet_SYZJ.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ)
                    '备份
                    strOldFilter = .DefaultView.RowFilter

                    '新条件
                    strNewFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZJDM + " = '" + strZJDM + "'"
                    .DefaultView.RowFilter = strNewFilter

                    '判断
                    If .DefaultView.Count > 0 Then
                        blnExisted = True
                    Else
                        blnExisted = False
                    End If

                    '复原
                    .DefaultView.RowFilter = strOldFilter
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            isExisted_SYZJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        Private Function isQujianValid(ByRef strErrMsg As String) As Boolean

            Dim strFieldZX As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZX
            Dim strFieldZD As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZD
            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZB
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            isQujianValid = False
            strErrMsg = ""

            Try
                Dim dblValue(2) As Double
                Dim intCount As Integer = 0
                Dim i As Integer = 0

                '检查最小值是否满足要求?
                dblValue(1) = 0
                With Me.m_objDataSet_SYZB.Tables(strTable).DefaultView
                    intCount = .Count
                    For i = 0 To intCount - 1 Step 1
                        '本行最小
                        dblValue(0) = objPulicParameters.getObjectValue(.Item(i).Item(strFieldZX), 0.0)
                        If i > 0 Then
                            If dblValue(0) <= dblValue(1) + 1 Then
                                strErrMsg = "错误：区间不是按照由小到大顺序输入！"
                                GoTo errProc
                            End If
                        End If
                        '继续
                        dblValue(1) = dblValue(0)
                    Next
                End With

                '自动设置最大值 = 下一行的最小值 - 1
                With Me.m_objDataSet_SYZB.Tables(strTable).DefaultView
                    intCount = .Count
                    For i = intCount - 1 To 0 Step -1
                        '本行最小
                        dblValue(0) = objPulicParameters.getObjectValue(.Item(i).Item(strFieldZX), 0.0)
                        '上行最大 = 本行最小 - 1
                        If i - 1 >= 0 Then
                            .Item(i - 1).Item(strFieldZD) = dblValue(0) - 1
                        End If
                    Next
                End With

                '最后一行的最大值=0
                With Me.m_objDataSet_SYZB.Tables(strTable).DefaultView
                    intCount = .Count
                    If intCount > 0 Then
                        .Item(intCount - 1).Item(strFieldZD) = 0.0
                    End If
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            isQujianValid = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查区间：值有效？
                If Me.saveDataGridUnboundInfo_SYZB(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                '检查区间：区间有效？
                If Me.isQujianValid(strErrMsg) = False Then
                    GoTo errProc
                End If

                '保存数据
                If objsystemEstateRenshiXingye.doSaveData_YongjinJitiBiaozhun(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GY, Me.m_objDataSet_SYZJ, Me.m_objDataSet_SYZB) = False Then
                    GoTo errProc
                End If

                '记录审计日志
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]提交了上述对[人事_佣金计提标准]的改动！")

                '返回处理
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnSelAll_GY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_GY.Click
            Me.doSelectAll_GY("btnSelAll_GY")
        End Sub

        Private Sub btnDeSelAll_GY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_GY.Click
            Me.doDeSelectAll_GY("btnDeSelAll_GY")
        End Sub

        Private Sub btnSelAll_SYZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_SYZJ.Click
            Me.doSelectAll_SYZJ("btnSelAll_SYZJ")
        End Sub

        Private Sub btnDeSelAll_SYZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_SYZJ.Click
            Me.doDeSelectAll_SYZJ("btnDeSelAll_SYZJ")
        End Sub

        Private Sub btnDelete_GY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GY.Click
            Me.doDelete_GY("btnDelete_GY")
        End Sub

        Private Sub btnDelete_SYZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_SYZJ.Click
            Me.doDelete_SYZJ("btnDelete_SYZJ")
        End Sub

        Private Sub btnDelete_SYZB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_SYZB.Click
            Me.doDelete_SYZB("btnDelete_SYZB")
        End Sub

        Private Sub btnAddNew_GY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GY.Click
            Me.doAddNew_GY("btnAddNew_GY")
        End Sub

        Private Sub btnAddNew_SYZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_SYZJ.Click
            Me.doAddNew_SYZJ("btnAddNew_SYZJ")
        End Sub

        Private Sub btnAddNew_SYZB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_SYZB.Click
            Me.doAddNew_SYZB("btnAddNew_SYZB")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

    End Class

End Namespace
