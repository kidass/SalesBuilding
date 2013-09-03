Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_yongjinjitibiaozhun_x3
    ' 
    ' 调用性质：
    '     独立运行
    '
    ' 功能描述： 
    '   　“佣金计提标准X3”处理模块
    '----------------------------------------------------------------

    Partial Class estate_rs_yongjinjitibiaozhun_x3
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsYongjinJitiBiaozhun_X3
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsYongjinJitiBiaozhun_X3
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdSY相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdSY As String = "chkSY"
        Private Const m_cstrDataGridInDIV_grdSY As String = "divSY"
        Private m_intFixedColumns_grdSY As Integer
        Private Const m_cstrtxtQJZX_grdSY As String = "txtQJZX"
        Private Const m_cstrtxtQJZD_grdSY As String = "txtQJZD"
        Private Const m_cstrtxtEDZX_grdSY As String = "txtEDZX"
        Private Const m_cstrtxtEDZD_grdSY As String = "txtEDZD"
        Private Const m_cstrtxtJTBL_grdSY As String = "txtJTBL"

        '----------------------------------------------------------------
        '与数据网格grdGYZGZJ相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGYZGZJ As String = "chkGYZGZJ"
        Private Const m_cstrDataGridInDIV_grdGYZGZJ As String = "divGYZGZJ"
        Private m_intFixedColumns_grdGYZGZJ As Integer

        '----------------------------------------------------------------
        '与数据网格grdGYZG相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGYZG As String = "chkGYZG"
        Private Const m_cstrDataGridInDIV_grdGYZG As String = "divGYZG"
        Private m_intFixedColumns_grdGYZG As Integer
        Private Const m_cstrtxtZGQJZX_grdGYZG As String = "txtZGQJZX"
        Private Const m_cstrtxtZGQJZD_grdGYZG As String = "txtZGQJZD"
        Private Const m_cstrtxtZGZXED_grdGYZG As String = "txtZGZXED"
        Private Const m_cstrtxtZGZDED_grdGYZG As String = "txtZGZDED"
        Private Const m_cstrtxtZGJTBL_grdGYZG As String = "txtZGJTBL"

        '----------------------------------------------------------------
        '与数据网格grdGYXG相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGYXG As String = "chkGYXG"
        Private Const m_cstrDataGridInDIV_grdGYXG As String = "divGYXG"
        Private m_intFixedColumns_grdGYXG As Integer
        Private Const m_cstrtxtXGQJZX_grdGYXG As String = "txtXGQJZX"
        Private Const m_cstrtxtXGQJZD_grdGYXG As String = "txtXGQJZD"
        Private Const m_cstrtxtXGJTBL_grdGYXG As String = "txtXGJTBL"

        '----------------------------------------------------------------
        '与数据网格grdGYZTZJ相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGYZTZJ As String = "chkGYZTZJ"
        Private Const m_cstrDataGridInDIV_grdGYZTZJ As String = "divGYZTZJ"
        Private m_intFixedColumns_grdGYZTZJ As Integer

        '----------------------------------------------------------------
        '与数据网格grdGYZT相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGYZT As String = "chkGYZT"
        Private Const m_cstrDataGridInDIV_grdGYZT As String = "divGYZT"
        Private m_intFixedColumns_grdGYZT As Integer
        Private Const m_cstrtxtZTQJZX_grdGYZT As String = "txtZTQJZX"
        Private Const m_cstrtxtZTQJZD_grdGYZT As String = "txtZTQJZD"
        Private Const m_cstrtxtZTJTBL_grdGYZT As String = "txtZTJTBL"

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_SY As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_GYZGZJ As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_GYZG As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_GYXG As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_GYZTZJ As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_GYZT As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '模块其他参数
        '----------------------------------------------------------------
        Private m_blnReadOnly As Boolean

        'propFunctionId
        '=1  操作私佣标准
        '=2  操作直管公佣
        '=3  操作协管公佣
        '=4  操作直提公佣
        Public ReadOnly Property propFunctionId() As Integer
            Get
                Try
                    propFunctionId = CType(Me.htxtFunctionId.Value, Integer)
                Catch ex As Exception
                    propFunctionId = 1
                End Try
            End Get
        End Property








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
                    Me.htxtFunctionId.Value = .htxtFunctionId

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftSY.Value = .htxtDivLeftSY
                    Me.htxtDivTopSY.Value = .htxtDivTopSY
                    Me.htxtDivLeftGYZGZJ.Value = .htxtDivLeftGYZGZJ
                    Me.htxtDivTopGYZGZJ.Value = .htxtDivTopGYZGZJ
                    Me.htxtDivLeftGYZG.Value = .htxtDivLeftGYZG
                    Me.htxtDivTopGYZG.Value = .htxtDivTopGYZG
                    Me.htxtDivLeftGYXG.Value = .htxtDivLeftGYXG
                    Me.htxtDivTopGYXG.Value = .htxtDivTopGYXG
                    Me.htxtDivLeftGYZTZJ.Value = .htxtDivLeftGYZTZJ
                    Me.htxtDivTopGYZTZJ.Value = .htxtDivTopGYZTZJ
                    Me.htxtDivLeftGYZT.Value = .htxtDivLeftGYZT
                    Me.htxtDivTopGYZT.Value = .htxtDivTopGYZT

                    Me.htxtSessionId_SY.Value = .htxtSessionId_SY
                    Me.htxtSessionId_GYZGZJ.Value = .htxtSessionId_GYZGZJ
                    Me.htxtSessionId_GYZG.Value = .htxtSessionId_GYZG
                    Me.htxtSessionId_GYXG.Value = .htxtSessionId_GYXG
                    Me.htxtSessionId_GYZTZJ.Value = .htxtSessionId_GYZTZJ
                    Me.htxtSessionId_GYZT.Value = .htxtSessionId_GYZT

                    Try
                        Me.grdSY.PageSize = .grdSY_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSY.CurrentPageIndex = .grdSY_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSY.SelectedIndex = .grdSY_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdGYZGZJ.PageSize = .grdGYZGZJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZGZJ.CurrentPageIndex = .grdGYZGZJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZGZJ.SelectedIndex = .grdGYZGZJ_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdGYZG.PageSize = .grdGYZG_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZG.CurrentPageIndex = .grdGYZG_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZG.SelectedIndex = .grdGYZG_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdGYXG.PageSize = .grdGYXG_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYXG.CurrentPageIndex = .grdGYXG_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYXG.SelectedIndex = .grdGYXG_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdGYZTZJ.PageSize = .grdGYZTZJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZTZJ.CurrentPageIndex = .grdGYZTZJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZTZJ.SelectedIndex = .grdGYZTZJ_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdGYZT.PageSize = .grdGYZT_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZT.CurrentPageIndex = .grdGYZT_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZT.SelectedIndex = .grdGYZT_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsYongjinJitiBiaozhun_X3

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtFunctionId = Me.htxtFunctionId.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftSY = Me.htxtDivLeftSY.Value
                    .htxtDivTopSY = Me.htxtDivTopSY.Value
                    .htxtDivLeftGYZGZJ = Me.htxtDivLeftGYZGZJ.Value
                    .htxtDivTopGYZGZJ = Me.htxtDivTopGYZGZJ.Value
                    .htxtDivLeftGYZG = Me.htxtDivLeftGYZG.Value
                    .htxtDivTopGYZG = Me.htxtDivTopGYZG.Value
                    .htxtDivLeftGYXG = Me.htxtDivLeftGYXG.Value
                    .htxtDivTopGYXG = Me.htxtDivTopGYXG.Value
                    .htxtDivLeftGYZTZJ = Me.htxtDivLeftGYZTZJ.Value
                    .htxtDivTopGYZTZJ = Me.htxtDivTopGYZTZJ.Value
                    .htxtDivLeftGYZT = Me.htxtDivLeftGYZT.Value
                    .htxtDivTopGYZT = Me.htxtDivTopGYZT.Value

                    .htxtSessionId_SY = Me.htxtSessionId_SY.Value
                    .htxtSessionId_GYZGZJ = Me.htxtSessionId_GYZGZJ.Value
                    .htxtSessionId_GYZG = Me.htxtSessionId_GYZG.Value
                    .htxtSessionId_GYXG = Me.htxtSessionId_GYXG.Value
                    .htxtSessionId_GYZTZJ = Me.htxtSessionId_GYZTZJ.Value
                    .htxtSessionId_GYZT = Me.htxtSessionId_GYZT.Value

                    .grdSY_PageSize = Me.grdSY.PageSize
                    .grdSY_CurrentPageIndex = Me.grdSY.CurrentPageIndex
                    .grdSY_SelectedIndex = Me.grdSY.SelectedIndex

                    .grdGYZGZJ_PageSize = Me.grdGYZGZJ.PageSize
                    .grdGYZGZJ_CurrentPageIndex = Me.grdGYZGZJ.CurrentPageIndex
                    .grdGYZGZJ_SelectedIndex = Me.grdGYZGZJ.SelectedIndex

                    .grdGYZG_PageSize = Me.grdGYZG.PageSize
                    .grdGYZG_CurrentPageIndex = Me.grdGYZG.CurrentPageIndex
                    .grdGYZG_SelectedIndex = Me.grdGYZG.SelectedIndex

                    .grdGYXG_PageSize = Me.grdGYXG.PageSize
                    .grdGYXG_CurrentPageIndex = Me.grdGYXG.CurrentPageIndex
                    .grdGYXG_SelectedIndex = Me.grdGYXG.SelectedIndex

                    .grdGYZTZJ_PageSize = Me.grdGYZTZJ.PageSize
                    .grdGYZTZJ_CurrentPageIndex = Me.grdGYZTZJ.CurrentPageIndex
                    .grdGYZTZJ_SelectedIndex = Me.grdGYZTZJ.SelectedIndex

                    .grdGYZT_PageSize = Me.grdGYZT.PageSize
                    .grdGYZT_CurrentPageIndex = Me.grdGYZT.CurrentPageIndex
                    .grdGYZT_SelectedIndex = Me.grdGYZT.SelectedIndex
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
                            Case "btnAddNew_GYZGZJ".ToUpper()
                                If Me.getModuleData_GYZGZJ(strErrMsg) = True Then
                                    If Me.isExisted_GYZGZJ(strErrMsg, objIDmxzJbdm.oCodeValue, Me.m_objDataSet_GYZGZJ, blnExisted) = True Then
                                        If blnExisted = False Then
                                            strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG
                                            With Me.m_objDataSet_GYZGZJ.Tables(strTable)
                                                objDataRow = .NewRow()
                                            End With
                                            With objIDmxzJbdm
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJDM) = .oCodeValue
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJMC) = .oNameValue
                                            End With
                                            With Me.m_objDataSet_GYZGZJ.Tables(strTable)
                                                .Rows.Add(objDataRow)
                                            End With
                                        End If
                                    End If
                                End If

                            Case "btnAddNew_GYZTZJ".ToUpper()
                                If Me.getModuleData_GYZTZJ(strErrMsg) = True Then
                                    If Me.isExisted_GYZTZJ(strErrMsg, objIDmxzJbdm.oCodeValue, Me.m_objDataSet_GYZTZJ, blnExisted) = True Then
                                        If blnExisted = False Then
                                            strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT
                                            With Me.m_objDataSet_GYZTZJ.Tables(strTable)
                                                objDataRow = .NewRow()
                                            End With
                                            With objIDmxzJbdm
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJDM) = .oCodeValue
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJMC) = .oNameValue
                                            End With
                                            With Me.m_objDataSet_GYZTZJ.Tables(strTable)
                                                .Rows.Add(objDataRow)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsYongjinJitiBiaozhun_X3)
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
                    Dim strSessionId As String = ""
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsYongjinJitiBiaozhun_X3)
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

                Me.m_intFixedColumns_grdSY = objPulicParameters.getObjectValue(Me.htxtSYFixed.Value, 0)
                Me.m_intFixedColumns_grdGYZGZJ = objPulicParameters.getObjectValue(Me.htxtGYZGZJFixed.Value, 0)
                Me.m_intFixedColumns_grdGYZG = objPulicParameters.getObjectValue(Me.htxtGYZGFixed.Value, 0)
                Me.m_intFixedColumns_grdGYXG = objPulicParameters.getObjectValue(Me.htxtGYXGFixed.Value, 0)
                Me.m_intFixedColumns_grdGYZTZJ = objPulicParameters.getObjectValue(Me.htxtGYZTZJFixed.Value, 0)
                Me.m_intFixedColumns_grdGYZT = objPulicParameters.getObjectValue(Me.htxtGYZTFixed.Value, 0)
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

                If Me.htxtSessionId_SY.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_SY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_SY.Value)
                    Me.htxtSessionId_SY.Value = ""
                End If

                If Me.htxtSessionId_GYZGZJ.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GYZGZJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GYZGZJ.Value)
                    Me.htxtSessionId_GYZGZJ.Value = ""
                End If

                If Me.htxtSessionId_GYZG.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GYZG.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GYZG.Value)
                    Me.htxtSessionId_GYZG.Value = ""
                End If

                If Me.htxtSessionId_GYXG.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GYXG.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GYXG.Value)
                    Me.htxtSessionId_GYXG.Value = ""
                End If

                If Me.htxtSessionId_GYZTZJ.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GYZTZJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GYZTZJ.Value)
                    Me.htxtSessionId_GYZTZJ.Value = ""
                End If

                If Me.htxtSessionId_GYZT.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GYZT.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GYZT.Value)
                    Me.htxtSessionId_GYZT.Value = ""
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub









        Private Function isExisted_GYZGZJ( _
            ByRef strErrMsg As String, _
            ByVal strZJDM As String, _
            ByVal objDataSet_GYZGZJ As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef blnExisted As Boolean) As Boolean

            isExisted_GYZGZJ = False
            strErrMsg = ""
            blnExisted = True

            Try
                '检查
                If strZJDM Is Nothing Then strZJDM = ""
                strZJDM = strZJDM.Trim
                If objDataSet_GYZGZJ Is Nothing Then
                    Exit Try
                End If
                If strZJDM = "" Then
                    Exit Try
                End If

                '搜索
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With objDataSet_GYZGZJ.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG)
                    '备份
                    strOldFilter = .DefaultView.RowFilter

                    '新条件
                    strNewFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJDM + " = '" + strZJDM + "'"
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

            isExisted_GYZGZJ = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Function isExisted_GYZTZJ( _
            ByRef strErrMsg As String, _
            ByVal strZJDM As String, _
            ByVal objDataSet_GYZTZJ As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef blnExisted As Boolean) As Boolean

            isExisted_GYZTZJ = False
            strErrMsg = ""
            blnExisted = True

            Try
                '检查
                If strZJDM Is Nothing Then strZJDM = ""
                strZJDM = strZJDM.Trim
                If objDataSet_GYZTZJ Is Nothing Then
                    Exit Try
                End If
                If strZJDM = "" Then
                    Exit Try
                End If

                '搜索
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With objDataSet_GYZTZJ.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT)
                    '备份
                    strOldFilter = .DefaultView.RowFilter

                    '新条件
                    strNewFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJDM + " = '" + strZJDM + "'"
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

            isExisted_GYZTZJ = True
            Exit Function
errProc:
            Exit Function

        End Function









        '----------------------------------------------------------------
        ' 获取grdSY要显示的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_SY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_SY
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_SY = False

            Try
                If Me.htxtSessionId_SY.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_SY = CType(Session.Item(Me.htxtSessionId_SY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_SY)

                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_YJBZ_X3_SY(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", Me.m_objDataSet_SY) = False Then
                        GoTo errProc
                    End If

                    '缓存数据
                    Me.htxtSessionId_SY.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_SY.Value, Me.m_objDataSet_SY)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_SY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdGYZGZJ要显示的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_GYZGZJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_GYZGZJ = False

            Try
                If Me.htxtSessionId_GYZGZJ.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_GYZGZJ = CType(Session.Item(Me.htxtSessionId_GYZGZJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GYZGZJ)

                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_YJBZ_X3_GY_ZG_ZJ(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", Me.m_objDataSet_GYZGZJ) = False Then
                        GoTo errProc
                    End If

                    '缓存数据
                    Me.htxtSessionId_GYZGZJ.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_GYZGZJ.Value, Me.m_objDataSet_GYZGZJ)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_GYZGZJ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdGYZG要显示的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_GYZG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intColIndex As Integer
            Dim strWhere As String = ""
            Dim strZJDM As String = ""

            getModuleData_GYZG = False

            Try
                If Me.htxtSessionId_GYZG.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_GYZG = CType(Session.Item(Me.htxtSessionId_GYZG.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GYZG)

                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_YJBZ_X3_GY_ZG_ZB(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", Me.m_objDataSet_GYZG) = False Then
                        GoTo errProc
                    End If

                    '缓存数据
                    Me.htxtSessionId_GYZG.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_GYZG.Value, Me.m_objDataSet_GYZG)
                End If

                '数据同步
                If Me.grdGYZGZJ.SelectedIndex >= 0 Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZGZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJDM)
                    strZJDM = objDataGridProcess.getDataGridCellValue(Me.grdGYZGZJ.Items(Me.grdGYZGZJ.SelectedIndex), intColIndex)
                Else
                    strZJDM = ""
                End If
                strWhere = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJDM + " = '" + strZJDM + "'"
                With Me.m_objDataSet_GYZG.Tables(strTable)
                    .DefaultView.RowFilter = strWhere
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_GYZG = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdGYXG要显示的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_GYXG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_XG
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_GYXG = False

            Try
                If Me.htxtSessionId_GYXG.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_GYXG = CType(Session.Item(Me.htxtSessionId_GYXG.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GYXG)

                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_YJBZ_X3_GY_XG(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", Me.m_objDataSet_GYXG) = False Then
                        GoTo errProc
                    End If

                    '缓存数据
                    Me.htxtSessionId_GYXG.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_GYXG.Value, Me.m_objDataSet_GYXG)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_GYXG = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdGYZTZJ要显示的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_GYZTZJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_GYZTZJ = False

            Try
                If Me.htxtSessionId_GYZTZJ.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_GYZTZJ = CType(Session.Item(Me.htxtSessionId_GYZTZJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GYZTZJ)

                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_YJBZ_X3_GY_ZT_ZJ(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", Me.m_objDataSet_GYZTZJ) = False Then
                        GoTo errProc
                    End If

                    '缓存数据
                    Me.htxtSessionId_GYZTZJ.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_GYZTZJ.Value, Me.m_objDataSet_GYZTZJ)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_GYZTZJ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdGYZT要显示的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_GYZT(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intColIndex As Integer
            Dim strWhere As String = ""
            Dim strZJDM As String = ""

            getModuleData_GYZT = False

            Try
                If Me.htxtSessionId_GYZT.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_GYZT = CType(Session.Item(Me.htxtSessionId_GYZT.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GYZT)

                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_YJBZ_X3_GY_ZT_ZB(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", Me.m_objDataSet_GYZT) = False Then
                        GoTo errProc
                    End If

                    '缓存数据
                    Me.htxtSessionId_GYZT.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_GYZT.Value, Me.m_objDataSet_GYZT)
                End If

                '数据同步
                If Me.grdGYZTZJ.SelectedIndex >= 0 Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZTZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJDM)
                    strZJDM = objDataGridProcess.getDataGridCellValue(Me.grdGYZTZJ.Items(Me.grdGYZTZJ.SelectedIndex), intColIndex)
                Else
                    strZJDM = ""
                End If
                strWhere = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJDM + " = '" + strZJDM + "'"
                With Me.m_objDataSet_GYZT.Tables(strTable)
                    .DefaultView.RowFilter = strWhere
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_GYZT = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' 保存grdSY中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_SY(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_SY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_SY = False
            strErrMsg = ""

            Try
                '保存未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdSY.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdSY.CurrentPageIndex, Me.grdSY.PageSize)
                    objDataRow = Me.m_objDataSet_SY.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存[txtJTBL]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSY.Items(i).FindControl(Me.m_cstrtxtJTBL_grdSY), System.Web.UI.WebControls.TextBox)
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
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_JTBL) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtQJZX]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSY.Items(i).FindControl(Me.m_cstrtxtQJZX_grdSY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间最小]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间最小]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_QJZX) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtQJZD]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSY.Items(i).FindControl(Me.m_cstrtxtQJZD_grdSY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间最大]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间最大]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_QJZD) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtEDZX]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSY.Items(i).FindControl(Me.m_cstrtxtEDZX_grdSY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[最小额度]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[最小额度]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_ZXED) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtEDZD]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSY.Items(i).FindControl(Me.m_cstrtxtEDZD_grdSY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[最大额度]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[最大额度]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_ZDED) = CType(objTextBox.Text, Double)
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

            saveDataGridUnboundInfo_SY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSY中的非绑定数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_SY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_SY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_SY = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdSY.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdSY.CurrentPageIndex, Me.grdSY.PageSize)
                    objDataRow = Me.m_objDataSet_SY.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充[txtJTBL]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSY.Items(i).FindControl(Me.m_cstrtxtJTBL_grdSY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_JTBL), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充[txtQJZX]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSY.Items(i).FindControl(Me.m_cstrtxtQJZX_grdSY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_QJZX), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充[txtQJZD]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSY.Items(i).FindControl(Me.m_cstrtxtQJZD_grdSY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_QJZD), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充[txtEDZX]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSY.Items(i).FindControl(Me.m_cstrtxtEDZX_grdSY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_ZXED), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充[txtEDZD]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSY.Items(i).FindControl(Me.m_cstrtxtEDZD_grdSY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_ZDED), "")
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

            showDataGridUnboundInfo_SY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSY的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_SY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_SY = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_SY Is Nothing Then
                    Me.grdSY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SY.Tables(strTable)
                        Me.grdSY.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_SY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdSY.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdSY) = False Then
                    GoTo errProc
                End If
                '显示其他未绑定数据
                If Me.showDataGridUnboundInfo_SY(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function













        '----------------------------------------------------------------
        ' 显示grdGYZGZJ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GYZGZJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GYZGZJ = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_GYZGZJ Is Nothing Then
                    Me.grdGYZGZJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GYZGZJ.Tables(strTable)
                        Me.grdGYZGZJ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_GYZGZJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGYZGZJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdGYZGZJ.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGYZGZJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZGZJ) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GYZGZJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存grdGYZG中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_GYZG(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_GYZG = False
            strErrMsg = ""

            Try
                '保存未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYZG.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZG.CurrentPageIndex, Me.grdGYZG.PageSize)
                    objDataRow = Me.m_objDataSet_GYZG.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存[txtZGQJZX]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZG.Items(i).FindControl(Me.m_cstrtxtZGQJZX_grdGYZG), System.Web.UI.WebControls.TextBox)
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
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZX) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtZGQJZD]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZG.Items(i).FindControl(Me.m_cstrtxtZGQJZD_grdGYZG), System.Web.UI.WebControls.TextBox)
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
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZD) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtZGZXED]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZG.Items(i).FindControl(Me.m_cstrtxtZGZXED_grdGYZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[最小额度]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[最小额度]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZXED) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtZGZDED]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZG.Items(i).FindControl(Me.m_cstrtxtZGZDED_grdGYZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[最大额度]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[最大额度]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZDED) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtZGJTBL]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZG.Items(i).FindControl(Me.m_cstrtxtZGJTBL_grdGYZG), System.Web.UI.WebControls.TextBox)
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
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_JTBL) = CType(objTextBox.Text, Double)
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

            saveDataGridUnboundInfo_GYZG = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdGYZG中的非绑定数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_GYZG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_GYZG = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYZG.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZG.CurrentPageIndex, Me.grdGYZG.PageSize)
                    objDataRow = Me.m_objDataSet_GYZG.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充[txtZGQJZX]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZG.Items(i).FindControl(Me.m_cstrtxtZGQJZX_grdGYZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZX), "")
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

                    '填充[txtZGQJZD]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZG.Items(i).FindControl(Me.m_cstrtxtZGQJZD_grdGYZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZD), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充[txtZGZXED]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZG.Items(i).FindControl(Me.m_cstrtxtZGZXED_grdGYZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZXED), "")
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

                    '填充[txtZGZDED]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZG.Items(i).FindControl(Me.m_cstrtxtZGZDED_grdGYZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZDED), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充[txtZGJTBL]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZG.Items(i).FindControl(Me.m_cstrtxtZGJTBL_grdGYZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_JTBL), "")
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

            showDataGridUnboundInfo_GYZG = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdGYZG的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GYZG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GYZG = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_GYZG Is Nothing Then
                    Me.grdGYZG.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GYZG.Tables(strTable)
                        Me.grdGYZG.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_GYZG.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGYZG, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdGYZG.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGYZG, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZG) = False Then
                    GoTo errProc
                End If
                '显示其他未绑定数据
                If Me.showDataGridUnboundInfo_GYZG(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GYZG = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function














        '----------------------------------------------------------------
        ' 保存grdGYXG中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_GYXG(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_XG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_GYXG = False
            strErrMsg = ""

            Try
                '保存未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYXG.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYXG.CurrentPageIndex, Me.grdGYXG.PageSize)
                    objDataRow = Me.m_objDataSet_GYXG.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存[txtXGJTBL]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXG.Items(i).FindControl(Me.m_cstrtxtXGJTBL_grdGYXG), System.Web.UI.WebControls.TextBox)
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
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_JTBL) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtXGQJZX]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXG.Items(i).FindControl(Me.m_cstrtxtXGQJZX_grdGYXG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间最小]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间最小]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZX) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtXGQJZD]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXG.Items(i).FindControl(Me.m_cstrtxtXGQJZD_grdGYXG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间最大]是无效数值！"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "错误：第[" + (i + 1).ToString + "]行的[区间最大]必须>=0！"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZD) = CType(objTextBox.Text, Double)
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

            saveDataGridUnboundInfo_GYXG = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdGYXG中的非绑定数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_GYXG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_XG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_GYXG = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYXG.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYXG.CurrentPageIndex, Me.grdGYXG.PageSize)
                    objDataRow = Me.m_objDataSet_GYXG.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充[txtXGJTBL]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXG.Items(i).FindControl(Me.m_cstrtxtXGJTBL_grdGYXG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_JTBL), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充[txtXGQJZX]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXG.Items(i).FindControl(Me.m_cstrtxtXGQJZX_grdGYXG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZX), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充[txtXGQJZD]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXG.Items(i).FindControl(Me.m_cstrtxtXGQJZD_grdGYXG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZD), "")
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

            showDataGridUnboundInfo_GYXG = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdGYXG的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GYXG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_XG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GYXG = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_GYXG Is Nothing Then
                    Me.grdGYXG.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GYXG.Tables(strTable)
                        Me.grdGYXG.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_GYXG.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGYXG, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdGYXG.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGYXG, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYXG) = False Then
                    GoTo errProc
                End If
                '显示其他未绑定数据
                If Me.showDataGridUnboundInfo_GYXG(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GYXG = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' 显示grdGYZTZJ的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GYZTZJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GYZTZJ = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_GYZTZJ Is Nothing Then
                    Me.grdGYZTZJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GYZTZJ.Tables(strTable)
                        Me.grdGYZTZJ.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_GYZTZJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGYZTZJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdGYZTZJ.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGYZTZJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZTZJ) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GYZTZJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存grdGYZT中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_GYZT(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_GYZT = False
            strErrMsg = ""

            Try
                '保存未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYZT.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZT.CurrentPageIndex, Me.grdGYZT.PageSize)
                    objDataRow = Me.m_objDataSet_GYZT.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存[txtZTQJZX]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZT.Items(i).FindControl(Me.m_cstrtxtZTQJZX_grdGYZT), System.Web.UI.WebControls.TextBox)
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
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZX) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtZTQJZD]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZT.Items(i).FindControl(Me.m_cstrtxtZTQJZD_grdGYZT), System.Web.UI.WebControls.TextBox)
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
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZD) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '保存[txtZTJTBL]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZT.Items(i).FindControl(Me.m_cstrtxtZTJTBL_grdGYZT), System.Web.UI.WebControls.TextBox)
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
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_JTBL) = CType(objTextBox.Text, Double)
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

            saveDataGridUnboundInfo_GYZT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdGYZT中的非绑定数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_GYZT(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_GYZT = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYZT.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZT.CurrentPageIndex, Me.grdGYZT.PageSize)
                    objDataRow = Me.m_objDataSet_GYZT.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充[txtZTQJZX]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZT.Items(i).FindControl(Me.m_cstrtxtZTQJZX_grdGYZT), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZX), "")
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

                    '填充[txtZTQJZD]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZT.Items(i).FindControl(Me.m_cstrtxtZTQJZD_grdGYZT), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZD), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充[txtZTJTBL]
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZT.Items(i).FindControl(Me.m_cstrtxtZTJTBL_grdGYZT), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_JTBL), "")
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

            showDataGridUnboundInfo_GYZT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdGYZT的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GYZT(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GYZT = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_GYZT Is Nothing Then
                    Me.grdGYZT.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GYZT.Tables(strTable)
                        Me.grdGYZT.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_GYZT.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGYZT, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdGYZT.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGYZT, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZT) = False Then
                    GoTo errProc
                End If
                '显示其他未绑定数据
                If Me.showDataGridUnboundInfo_GYZT(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GYZT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function












        Private Function showFunctionData(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            showFunctionData = False
            strErrMsg = ""

            Try
                Select Case Me.propFunctionId
                    Case 1 '"lnkSYBZ"
                        '显示grdSY
                        If Me.getModuleData_SY(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_SY(strErrMsg) = False Then
                            GoTo errProc
                        End If

                    Case 2 '"lnkZGGY"
                        '显示grdGYZGZJ
                        If Me.getModuleData_GYZGZJ(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_GYZGZJ(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        '显示grdGYZG
                        If Me.getModuleData_GYZG(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_GYZG(strErrMsg) = False Then
                            GoTo errProc
                        End If

                    Case 3 '"lnkXGGY"
                        '显示grdGYXG
                        If Me.getModuleData_GYXG(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_GYXG(strErrMsg) = False Then
                            GoTo errProc
                        End If

                    Case 4 '"lnkZTGY"
                        '显示grdGYZTZJ
                        If Me.getModuleData_GYZTZJ(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_GYZTZJ(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        '显示grdGYZT
                        If Me.getModuleData_GYZT(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_GYZT(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    Case Else
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            showFunctionData = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doSaveFunctionData(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            doSaveFunctionData = False
            strErrMsg = ""

            Try
                Select Case Me.propFunctionId
                    Case 1 '"lnkSYBZ"
                        If Me.getModuleData_SY(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.saveDataGridUnboundInfo_SY(strErrMsg, False) = False Then
                            GoTo errProc
                        End If

                    Case 2 '"lnkZGGY"
                        If Me.getModuleData_GYZGZJ(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.getModuleData_GYZG(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.saveDataGridUnboundInfo_GYZG(strErrMsg, False) = False Then
                            GoTo errProc
                        End If

                    Case 3 '"lnkXGGY"
                        If Me.getModuleData_GYXG(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.saveDataGridUnboundInfo_GYXG(strErrMsg, False) = False Then
                            GoTo errProc
                        End If

                    Case 4 '"lnkZTGY"
                        If Me.getModuleData_GYZTZJ(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.getModuleData_GYZT(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.saveDataGridUnboundInfo_GYZT(strErrMsg, False) = False Then
                            GoTo errProc
                        End If
                    Case Else
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            doSaveFunctionData = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
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
                Me.btnAddNew_SY.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_SY.Visible = Not Me.m_blnReadOnly
                Me.btnSave_SY.Visible = Me.m_blnPrevilegeParams(1)

                Me.btnAddNew_GYZGZJ.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_GYZGZJ.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_GYZGZJ.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_GYZGZJ.Visible = Not Me.m_blnReadOnly
                Me.btnAddNew_GYZG.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_GYZG.Visible = Not Me.m_blnReadOnly
                Me.btnSave_GYZG.Visible = Me.m_blnPrevilegeParams(1)

                Me.btnAddNew_GYXG.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_GYXG.Visible = Not Me.m_blnReadOnly
                Me.btnSave_GYXG.Visible = Me.m_blnPrevilegeParams(1)

                Me.btnAddNew_GYZTZJ.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_GYZTZJ.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_GYZTZJ.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_GYZTZJ.Visible = Not Me.m_blnReadOnly
                Me.btnAddNew_GYZT.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_GYZT.Visible = Not Me.m_blnReadOnly
                Me.btnSave_GYZT.Visible = Me.m_blnPrevilegeParams(1)
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

                    '显示数据
                    If Me.showFunctionData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    '保存当前缓存数据
                    If Me.doSaveFunctionData(strErrMsg) = False Then
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
            Dim strErrMsg As String = ""
            Dim strUrl As String = ""

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
        Sub grdSY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSY.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdSY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdSY > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdSY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGYZGZJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGYZGZJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGYZGZJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGYZGZJ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdGYZGZJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGYZGZJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGYZG_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGYZG.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGYZG + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGYZG > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdGYZG - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGYZG.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGYXG_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGYXG.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGYXG + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGYXG > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdGYXG - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGYXG.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGYZTZJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGYZTZJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGYZTZJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGYZTZJ > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdGYZTZJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGYZTZJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGYZT_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGYZT.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGYZT + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGYZT > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdGYZT - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGYZT.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub












        Private Sub grdGYZGZJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGYZGZJ.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '显示数据
                If Me.getModuleData_GYZG(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_GYZG(strErrMsg) = False Then
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

        Private Sub grdGYZTZJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGYZTZJ.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '显示数据
                If Me.getModuleData_GYZT(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_GYZT(strErrMsg) = False Then
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











        Private Sub doSelectAll_GYZGZJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdGYZGZJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZGZJ, True) = False Then
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

        Private Sub doDeSelectAll_GYZGZJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdGYZGZJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZGZJ, False) = False Then
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

        Private Sub doSelectAll_GYZTZJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdGYZTZJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZTZJ, True) = False Then
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

        Private Sub doDeSelectAll_GYZTZJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdGYZTZJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZTZJ, False) = False Then
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

        Private Sub btnSelAll_GYZGZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_GYZGZJ.Click
            Me.doSelectAll_GYZGZJ("btnSelAll_GYZGZJ")
        End Sub
        Private Sub btnDeSelAll_GYZGZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_GYZGZJ.Click
            Me.doDeSelectAll_GYZGZJ("btnDeSelAll_GYZGZJ")
        End Sub
        Private Sub btnSelAll_GYZTZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_GYZTZJ.Click
            Me.doSelectAll_GYZTZJ("btnSelAll_GYZTZJ")
        End Sub
        Private Sub btnDeSelAll_GYZTZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_GYZTZJ.Click
            Me.doDeSelectAll_GYZTZJ("btnDeSelAll_GYZTZJ")
        End Sub










        Private Sub doDelete_SY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_SY
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '检查
                Dim i As Integer = 0
                If Me.grdSY.Items.Count < 1 Then
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
                    If Me.getModuleData_SY(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '逐个删除
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex(2) As Integer
                    Dim strName(2) As String
                    Dim intPos As Integer = 0
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_QJZX)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_QJZD)
                    i = Me.grdSY.Items.Count - 1
                    strName(0) = objDataGridProcess.getDataGridCellValue(Me.grdSY.Items(i), intColIndex(0))
                    strName(1) = objDataGridProcess.getDataGridCellValue(Me.grdSY.Items(i), intColIndex(1))

                    '获取要删除的数据
                    i = Me.grdSY.Items.Count - 1
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdSY.CurrentPageIndex, Me.grdSY.PageSize)
                    With Me.m_objDataSet_SY.Tables(strTable)
                        objOldData = Nothing
                        objOldData = .DefaultView.Item(intPos).Row
                        .Rows.Remove(objOldData)
                    End With

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[地产_B_人事_佣金标准_X3_私佣]中删除了[" + strName(0) + "]-[" + strName(1) + "]区间(暂没保存)！")

                    '刷新网格显示
                    If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doDelete_GYZGZJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                If Me.grdGYZGZJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有职级可删除！"
                    GoTo errProc
                End If
                Dim intColIndex As Integer = 0
                Dim strZJDM As String = ""
                Dim strZJMC As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZGZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJDM)
                strZJDM = objDataGridProcess.getDataGridCellValue(Me.grdGYZGZJ.Items(Me.grdGYZGZJ.SelectedIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZGZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJMC)
                strZJMC = objDataGridProcess.getDataGridCellValue(Me.grdGYZGZJ.Items(Me.grdGYZGZJ.SelectedIndex), intColIndex)

                intStep = 2
                '询问
                Dim objOldData As System.Data.DataRow = Nothing
                Dim intPos As Integer = 0
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备删除[" + strZJMC + "]的所有内容吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '提示后回答“是”接着处理
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.getModuleData_GYZGZJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_GYZG(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '删除职级对应的指标
                    With Me.m_objDataSet_GYZG.Tables(strTable)
                        intRows = .DefaultView.Count
                        For i = intRows - 1 To 0 Step -1
                            objOldData = Nothing
                            objOldData = .DefaultView.Item(i).Row
                            .Rows.Remove(objOldData)
                        Next
                    End With

                    '删除职级数据
                    i = Me.grdGYZGZJ.SelectedIndex
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZGZJ.CurrentPageIndex, Me.grdGYZGZJ.PageSize)
                    With Me.m_objDataSet_GYZGZJ.Tables(strTable)
                        objOldData = Nothing
                        objOldData = .DefaultView.Item(intPos).Row
                        .Rows.Remove(objOldData)
                    End With

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[地产_B_人事_佣金标准_X3_公佣_直管]中删除了[" + strZJMC + "]职级(暂没保存)！")

                    '刷新网格显示
                    If Me.showFunctionData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDelete_GYZG(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '检查
                Dim i As Integer = 0
                If Me.grdGYZG.Items.Count < 1 Then
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
                    If Me.getModuleData_GYZG(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '逐个删除
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex(2) As Integer
                    Dim strName(2) As String
                    Dim intPos As Integer = 0
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZG, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZX)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZG, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZD)
                    i = Me.grdGYZG.Items.Count - 1
                    strName(0) = objDataGridProcess.getDataGridCellValue(Me.grdGYZG.Items(i), intColIndex(0))
                    strName(1) = objDataGridProcess.getDataGridCellValue(Me.grdGYZG.Items(i), intColIndex(1))

                    '获取要删除的数据
                    i = Me.grdGYZG.Items.Count - 1
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZG.CurrentPageIndex, Me.grdGYZG.PageSize)
                    With Me.m_objDataSet_GYZG.Tables(strTable)
                        objOldData = Nothing
                        objOldData = .DefaultView.Item(intPos).Row
                        .Rows.Remove(objOldData)
                    End With

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[地产_B_人事_佣金标准_X3_公佣_直管]中删除了[" + strName(0) + "]-[" + strName(1) + "]区间(暂没保存)！")

                    '刷新网格显示
                    If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doDelete_GYXG(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_XG
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '检查
                Dim i As Integer = 0
                If Me.grdGYXG.Items.Count < 1 Then
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
                    If Me.getModuleData_GYXG(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '逐个删除
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex(2) As Integer
                    Dim strName(2) As String
                    Dim intPos As Integer = 0
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdGYXG, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZX)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdGYXG, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZD)
                    i = Me.grdGYXG.Items.Count - 1
                    strName(0) = objDataGridProcess.getDataGridCellValue(Me.grdGYXG.Items(i), intColIndex(0))
                    strName(1) = objDataGridProcess.getDataGridCellValue(Me.grdGYXG.Items(i), intColIndex(1))

                    '获取要删除的数据
                    i = Me.grdGYXG.Items.Count - 1
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdGYXG.CurrentPageIndex, Me.grdGYXG.PageSize)
                    With Me.m_objDataSet_GYXG.Tables(strTable)
                        objOldData = Nothing
                        objOldData = .DefaultView.Item(intPos).Row
                        .Rows.Remove(objOldData)
                    End With

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[地产_B_人事_佣金标准_X3_公佣_协管]中删除了[" + strName(0) + "]-[" + strName(1) + "]区间(暂没保存)！")

                    '刷新网格显示
                    If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doDelete_GYZTZJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                intStep = 1
                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                If Me.grdGYZTZJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有职级可删除！"
                    GoTo errProc
                End If
                Dim intColIndex As Integer = 0
                Dim strZJDM As String = ""
                Dim strZJMC As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZTZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJDM)
                strZJDM = objDataGridProcess.getDataGridCellValue(Me.grdGYZTZJ.Items(Me.grdGYZTZJ.SelectedIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZTZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJMC)
                strZJMC = objDataGridProcess.getDataGridCellValue(Me.grdGYZTZJ.Items(Me.grdGYZTZJ.SelectedIndex), intColIndex)

                intStep = 2
                '询问
                Dim objOldData As System.Data.DataRow = Nothing
                Dim intPos As Integer = 0
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备删除[" + strZJMC + "]的所有内容吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '提示后回答“是”接着处理
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.getModuleData_GYZTZJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_GYZT(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '删除职级对应的指标
                    With Me.m_objDataSet_GYZT.Tables(strTable)
                        intRows = .DefaultView.Count
                        For i = intRows - 1 To 0 Step -1
                            objOldData = Nothing
                            objOldData = .DefaultView.Item(i).Row
                            .Rows.Remove(objOldData)
                        Next
                    End With

                    '删除职级数据
                    i = Me.grdGYZTZJ.SelectedIndex
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZTZJ.CurrentPageIndex, Me.grdGYZTZJ.PageSize)
                    With Me.m_objDataSet_GYZTZJ.Tables(strTable)
                        objOldData = Nothing
                        objOldData = .DefaultView.Item(intPos).Row
                        .Rows.Remove(objOldData)
                    End With

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[地产_B_人事_佣金标准_X3_公佣_直管]中删除了[" + strZJMC + "]职级(暂没保存)！")

                    '刷新网格显示
                    If Me.showFunctionData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDelete_GYZT(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '检查
                Dim i As Integer = 0
                If Me.grdGYZT.Items.Count < 1 Then
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
                    If Me.getModuleData_GYZT(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '逐个删除
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex(2) As Integer
                    Dim strName(2) As String
                    Dim intPos As Integer = 0
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZT, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZX)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZT, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZD)
                    i = Me.grdGYZT.Items.Count - 1
                    strName(0) = objDataGridProcess.getDataGridCellValue(Me.grdGYZT.Items(i), intColIndex(0))
                    strName(1) = objDataGridProcess.getDataGridCellValue(Me.grdGYZT.Items(i), intColIndex(1))

                    '获取要删除的数据
                    i = Me.grdGYZT.Items.Count - 1
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZT.CurrentPageIndex, Me.grdGYZT.PageSize)
                    With Me.m_objDataSet_GYZT.Tables(strTable)
                        objOldData = Nothing
                        objOldData = .DefaultView.Item(intPos).Row
                        .Rows.Remove(objOldData)
                    End With

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[地产_B_人事_佣金标准_X3_公佣_直管]中删除了[" + strName(0) + "]-[" + strName(1) + "]区间(暂没保存)！")

                    '刷新网格显示
                    If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doAddNew_SY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_SY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.getModuleData_SY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '增加新行
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_SY.Tables(strTable)
                    objDataRow = .NewRow()
                End With

                '赋初始值
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_JTBL) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_QJZX) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_QJZD) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_ZXED) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_SY_ZDED) = 0.0

                '加入新行
                With Me.m_objDataSet_SY.Tables(strTable)
                    .Rows.Add(objDataRow)
                End With

                '刷新网格显示
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doAddNew_GYZGZJ(ByVal strControlId As String)

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

        Private Sub doAddNew_GYZG(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.grdGYZGZJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有职级数据！"
                    GoTo errProc
                End If
                Dim intColIndex As Integer
                Dim strZJDM As String = ""
                Dim strZJMC As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZGZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJDM)
                strZJDM = objDataGridProcess.getDataGridCellValue(Me.grdGYZGZJ.Items(Me.grdGYZGZJ.SelectedIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZGZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJMC)
                strZJMC = objDataGridProcess.getDataGridCellValue(Me.grdGYZGZJ.Items(Me.grdGYZGZJ.SelectedIndex), intColIndex)
                If Me.getModuleData_GYZG(strErrMsg) = False Then
                    GoTo errProc
                End If

                '增加新行
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_GYZG.Tables(strTable)
                    objDataRow = .NewRow()
                End With

                '赋初始值
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJDM) = strZJDM
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJMC) = strZJMC
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_JTBL) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZX) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZD) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZXED) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZDED) = 0.0

                '加入新行
                With Me.m_objDataSet_GYZG.Tables(strTable)
                    .Rows.Add(objDataRow)
                End With

                '刷新网格显示
                If Me.showFunctionData(strErrMsg) = False Then
                    GoTo errProc
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

        Private Sub doAddNew_GYXG(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_XG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.getModuleData_GYXG(strErrMsg) = False Then
                    GoTo errProc
                End If

                '增加新行
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_GYXG.Tables(strTable)
                    objDataRow = .NewRow()
                End With

                '赋初始值
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_JTBL) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZX) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZD) = 0.0

                '加入新行
                With Me.m_objDataSet_GYXG.Tables(strTable)
                    .Rows.Add(objDataRow)
                End With

                '刷新网格显示
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doAddNew_GYZTZJ(ByVal strControlId As String)

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

        Private Sub doAddNew_GYZT(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YJBZ_X3_GY_ZT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.grdGYZTZJ.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有职级数据！"
                    GoTo errProc
                End If
                Dim intColIndex As Integer
                Dim strZJDM As String = ""
                Dim strZJMC As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZTZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJDM)
                strZJDM = objDataGridProcess.getDataGridCellValue(Me.grdGYZTZJ.Items(Me.grdGYZTZJ.SelectedIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZTZJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJMC)
                strZJMC = objDataGridProcess.getDataGridCellValue(Me.grdGYZTZJ.Items(Me.grdGYZTZJ.SelectedIndex), intColIndex)
                If Me.getModuleData_GYZT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '增加新行
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_GYZT.Tables(strTable)
                    objDataRow = .NewRow()
                End With

                '赋初始值
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJDM) = strZJDM
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJMC) = strZJMC
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_JTBL) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZX) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZD) = 0.0

                '加入新行
                With Me.m_objDataSet_GYZT.Tables(strTable)
                    .Rows.Add(objDataRow)
                End With

                '刷新网格显示
                If Me.showFunctionData(strErrMsg) = False Then
                    GoTo errProc
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

        Private Sub doSave_SY(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.getModuleData_SY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '检查区间：值有效？
                If Me.saveDataGridUnboundInfo_SY(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                '保存数据
                If objsystemEstateRenshiXingye.doSaveData_YJBZ_X3_SY(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_SY) = False Then
                    GoTo errProc
                End If

                '记录审计日志
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]提交了上述对[地产_B_人事_佣金标准_X3_私佣]的改动！")
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

        Private Sub doSave_GYZT(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.getModuleData_GYZT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '检查区间：值有效？
                If Me.saveDataGridUnboundInfo_GYZT(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                '保存数据
                If objsystemEstateRenshiXingye.doSaveData_YJBZ_X3_GY_ZT(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GYZT) = False Then
                    GoTo errProc
                End If

                '记录审计日志
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]提交了上述对[地产_B_人事_佣金标准_X3_公佣_直提]的改动！")
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

        Private Sub doSave_GYXG(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.getModuleData_GYXG(strErrMsg) = False Then
                    GoTo errProc
                End If

                '检查区间：值有效？
                If Me.saveDataGridUnboundInfo_GYXG(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                '保存数据
                If objsystemEstateRenshiXingye.doSaveData_YJBZ_X3_GY_XG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GYXG) = False Then
                    GoTo errProc
                End If

                '记录审计日志
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]提交了上述对[地产_B_人事_佣金标准_X3_公佣_协管]的改动！")
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

        Private Sub doSave_GYZG(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intColIndex As Integer
            Dim strJJDM As String

            Try
                If Me.getModuleData_GYZG(strErrMsg) = False Then
                    GoTo errProc
                End If

                '检查区间：值有效？
                If Me.saveDataGridUnboundInfo_GYZG(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                '保存数据
                If objsystemEstateRenshiXingye.doSaveData_YJBZ_X3_GY_ZG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GYZG) = False Then
                    GoTo errProc
                End If

                '记录审计日志
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]提交了上述对[地产_B_人事_佣金标准_X3_公佣_直管]的改动！")
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

        Private Sub btnAddNew_SY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_SY.Click
            Me.doAddNew_SY("btnAddNew_SY")
        End Sub
        Private Sub btnDelete_SY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_SY.Click
            Me.doDelete_SY("btnDelete_SY")
        End Sub
        Private Sub btnSave_SY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave_SY.Click
            Me.doSave_SY("btnSave_SYZ")
        End Sub

        Private Sub btnAddNew_GYZGZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GYZGZJ.Click
            Me.doAddNew_GYZGZJ("btnAddNew_GYZGZJ")
        End Sub
        Private Sub btnDelete_GYZGZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GYZGZJ.Click
            Me.doDelete_GYZGZJ("btnDelete_GYZGZJ")
        End Sub
        Private Sub btnAddNew_GYZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GYZG.Click
            Me.doAddNew_GYZG("btnAddNew_GYZG")
        End Sub
        Private Sub btnDelete_GYZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GYZG.Click
            Me.doDelete_GYZG("btnDelete_GYZG")
        End Sub
        Private Sub btnSave_GYZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave_GYZG.Click
            Me.doSave_GYZG("btnSave_GYZG")
        End Sub

        Private Sub btnAddNew_GYXG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GYXG.Click
            Me.doAddNew_GYXG("btnAddNew_GYXG")
        End Sub
        Private Sub btnDelete_GYXG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GYXG.Click
            Me.doDelete_GYXG("btnDelete_GYXG")
        End Sub
        Private Sub btnSave_GYXG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave_GYXG.Click
            Me.doSave_GYXG("btnSave_GYZGXG")
        End Sub

        Private Sub btnAddNew_GYZTZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GYZTZJ.Click
            Me.doAddNew_GYZTZJ("btnAddNew_GYZTZJ")
        End Sub
        Private Sub btnDelete_GYZTZJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GYZTZJ.Click
            Me.doDelete_GYZTZJ("btnDelete_GYZTZJ")
        End Sub
        Private Sub btnAddNew_GYZT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GYZT.Click
            Me.doAddNew_GYZT("btnAddNew_GYZT")
        End Sub
        Private Sub btnDelete_GYZT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GYZT.Click
            Me.doDelete_GYZT("btnDelete_GYZT")
        End Sub
        Private Sub btnSave_GYZT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave_GYZT.Click
            Me.doSave_GYZT("btnSave_GYZT")
        End Sub









        Private Sub doSYBZ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '记录当前操作类型
                Me.htxtFunctionId.Value = "1"

                '释放缓存数据
                Me.releaseModuleParameters()

                '显示数据
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doZGGY(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '记录当前操作类型
                Me.htxtFunctionId.Value = "2"

                '释放缓存数据
                Me.releaseModuleParameters()

                '显示数据
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doXGGY(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '记录当前操作类型
                Me.htxtFunctionId.Value = "3"

                '释放缓存数据
                Me.releaseModuleParameters()

                '显示数据
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doZTGY(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '记录当前操作类型
                Me.htxtFunctionId.Value = "4"

                '释放缓存数据
                Me.releaseModuleParameters()

                '显示数据
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 1

            Try
                '提示信息
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备返回吗（是/否）？", strControlId, intStep)
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

        Private Sub lnkSYBZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSYBZ.Click
            Me.doSYBZ("lnkSYBZ")
        End Sub
        Private Sub lnkZGGY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkZGGY.Click
            Me.doZGGY("lnkZGGY")
        End Sub
        Private Sub lnkXGGY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkXGGY.Click
            Me.doXGGY("lnkXGGY")
        End Sub
        Private Sub lnkZTGY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkZTGY.Click
            Me.doZTGY("lnkZTGY")
        End Sub
        Private Sub lnkFHSJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFHSJ.Click
            Me.doCancel("lnkFHSJ")
        End Sub

    End Class

End Namespace
