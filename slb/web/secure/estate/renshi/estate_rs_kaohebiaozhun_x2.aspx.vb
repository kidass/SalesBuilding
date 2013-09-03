Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_kaohebiaozhun_x2
    ' 
    ' 调用性质：
    '     独立运行
    '
    ' 功能描述： 
    '   　人事考核标准(二)
    '----------------------------------------------------------------

    Partial Class estate_rs_kaohebiaozhun_x2
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
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_kaohebiaozhun_previlege_param"
        Private m_blnPrevilegeParams(2) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsKaoheBiaozhun_X2
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsKaoheBiaozhun_X2
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdYWJY相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdYWJY As String = "chkYWJY"
        Private Const m_cstrDataGridInDIV_grdYWJY As String = "divYWJY"
        Private m_intFixedColumns_grdYWJY As Integer
        Private Const m_cstrtxtZSBZInDataGrid_grdYWJY As String = "txtYWJY_ZSBZ"
        Private Const m_cstrtxtSYBZInDataGrid_grdYWJY As String = "txtYWJY_SYBZ"
        Private Const m_cstrddlZJDMInDataGrid_grdYWJY As String = "ddlYWJY_ZJDM"

        '----------------------------------------------------------------
        '与数据网格grdYWZG相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdYWZG As String = "chkYWZG"
        Private Const m_cstrDataGridInDIV_grdYWZG As String = "divYWZG"
        Private m_intFixedColumns_grdYWZG As Integer
        Private Const m_cstrtxtJZZBInDataGrid_grdYWZG As String = "txtYWZG_JZZB"
        Private Const m_cstrtxtJZRSInDataGrid_grdYWZG As String = "txtYWZG_JZRS"
        Private Const m_cstrtxtTZZBInDataGrid_grdYWZG As String = "txtYWZG_TZZB"
        Private Const m_cstrddlTDSXInDataGrid_grdYWZG As String = "ddlYWZG_TDSX"

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_YWJY As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_YWZG As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '其他参数
        '----------------------------------------------------------------
        Private m_blnReadOnly As Boolean










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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsKaoheBiaozhun_X2)
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
                    Me.htxtDivLeftYWJY.Value = .htxtDivLeftYWJY
                    Me.htxtDivTopYWJY.Value = .htxtDivTopYWJY
                    Me.htxtDivLeftYWZG.Value = .htxtDivLeftYWZG
                    Me.htxtDivTopYWZG.Value = .htxtDivTopYWZG

                    Me.htxtSessionIdYWJY.Value = .htxtSessionIdYWJY
                    Me.htxtSessionIdYWZG.Value = .htxtSessionIdYWZG

                    Try
                        Me.grdYWJY.PageSize = .grdYWJY_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYWJY.CurrentPageIndex = .grdYWJY_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYWJY.SelectedIndex = .grdYWJY_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdYWZG.PageSize = .grdYWZG_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYWZG.CurrentPageIndex = .grdYWZG_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYWZG.SelectedIndex = .grdYWZG_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsKaoheBiaozhun_X2

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftYWJY = Me.htxtDivLeftYWJY.Value
                    .htxtDivTopYWJY = Me.htxtDivTopYWJY.Value
                    .htxtDivLeftYWZG = Me.htxtDivLeftYWZG.Value
                    .htxtDivTopYWZG = Me.htxtDivTopYWZG.Value

                    .htxtSessionIdYWJY = Me.htxtSessionIdYWJY.Value
                    .htxtSessionIdYWZG = Me.htxtSessionIdYWZG.Value

                    .grdYWJY_PageSize = Me.grdYWJY.PageSize
                    .grdYWJY_CurrentPageIndex = Me.grdYWJY.CurrentPageIndex
                    .grdYWJY_SelectedIndex = Me.grdYWJY.SelectedIndex

                    .grdYWZG_PageSize = Me.grdYWZG.PageSize
                    .grdYWZG_CurrentPageIndex = Me.grdYWZG.CurrentPageIndex
                    .grdYWZG_SelectedIndex = Me.grdYWZG.SelectedIndex
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

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsKaoheBiaozhun_X2)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsKaoheBiaozhun_X2)
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

                Me.m_intFixedColumns_grdYWJY = objPulicParameters.getObjectValue(Me.htxtYWJYFixed.Value, 0)
                Me.m_intFixedColumns_grdYWZG = objPulicParameters.getObjectValue(Me.htxtYWZGFixed.Value, 0)
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

                If Me.htxtSessionIdYWJY.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionIdYWJY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionIdYWJY.Value)
                End If

                If Me.htxtSessionIdYWZG.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionIdYWZG.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionIdYWZG.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub










        '----------------------------------------------------------------
        ' 获取grdYWJY要显示的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_YWJY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_JY
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_YWJY = False

            Try
                If Me.htxtSessionIdYWJY.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_YWJY = CType(Session.Item(Me.htxtSessionIdYWJY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_YWJY)
                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_X2_KHBZ_JY(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", Me.m_objDataSet_YWJY) = False Then
                        GoTo errProc
                    End If
                    '缓存数据
                    Me.htxtSessionIdYWJY.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionIdYWJY.Value, Me.m_objDataSet_YWJY)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_YWJY = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdYWZG要显示的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_YWZG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_GL
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_YWZG = False

            Try
                If Me.htxtSessionIdYWZG.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_YWZG = CType(Session.Item(Me.htxtSessionIdYWZG.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_YWZG)
                    '重新检索数据
                    If objsystemEstateRenshiXingye.getDataSet_X2_KHBZ_GL(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", Me.m_objDataSet_YWZG) = False Then
                        GoTo errProc
                    End If
                    '缓存数据
                    Me.htxtSessionIdYWZG.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionIdYWZG.Value, Me.m_objDataSet_YWZG)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_YWZG = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' 保存grdYWJY中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_YWJY(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_JY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_YWJY = False
            strErrMsg = ""

            Try
                '保存未绑定数据
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim dblValue As Double = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdYWJY.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdYWJY.CurrentPageIndex, Me.grdYWJY.PageSize)
                    objDataRow = Me.m_objDataSet_YWJY.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存ddlYWJY_ZJDM
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdYWJY.Items(i).FindControl(Me.m_cstrddlZJDMInDataGrid_grdYWJY), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        strValue = ""
                        If blnValid = True Then
                            If objDropDownList.SelectedIndex < 0 Then
                                strErrMsg = "错误：没有选定[职级]！"
                                GoTo errProc
                            End If
                        End If
                        If objDropDownList.SelectedIndex >= 0 Then
                            strValue = objDropDownList.SelectedItem.Value
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_JY_ZJDM) = strValue
                    End If

                    '保存txtYWJY_ZSBZ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYWJY.Items(i).FindControl(Me.m_cstrtxtZSBZInDataGrid_grdYWJY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        dblValue = 0
                        If blnValid = True Then
                            If objTextBox.Text.Trim <> "" Then
                                If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                    strErrMsg = "错误：输入的[" + objTextBox.Text + "]不是有效数值！"
                                    GoTo errProc
                                End If
                                dblValue = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
                            End If
                        Else
                            dblValue = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_JY_ZSBZ) = dblValue.ToString("##0.00")
                    End If

                    '保存txtYWJY_SYBZ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYWJY.Items(i).FindControl(Me.m_cstrtxtSYBZInDataGrid_grdYWJY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        dblValue = 0
                        If blnValid = True Then
                            If objTextBox.Text.Trim <> "" Then
                                If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                    strErrMsg = "错误：输入的[" + objTextBox.Text + "]不是有效数值！"
                                    GoTo errProc
                                End If
                                dblValue = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
                            End If
                        Else
                            dblValue = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_JY_SYBZ) = dblValue.ToString("##0.00")
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_YWJY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存grdYWZG中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnValid       ：true-执行有效性检查,false-不执行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_YWZG(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_GL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_YWZG = False
            strErrMsg = ""

            Try
                '保存未绑定数据
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim dblValue As Double = 0
                Dim intValue As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdYWZG.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdYWZG.CurrentPageIndex, Me.grdYWZG.PageSize)
                    objDataRow = Me.m_objDataSet_YWZG.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '保存ddlYWZG_TDSX
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdYWZG.Items(i).FindControl(Me.m_cstrddlTDSXInDataGrid_grdYWZG), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        intValue = 0
                        If blnValid = True Then
                            If objDropDownList.SelectedIndex < 0 Then
                                strErrMsg = "错误：没有选定[团队类型]！"
                                GoTo errProc
                            End If
                        End If
                        If objDropDownList.SelectedIndex >= 0 Then
                            intValue = objPulicParameters.getObjectValue(objDropDownList.SelectedItem.Value, 0)
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_GL_TDSX) = intValue
                    End If

                    '保存txtYWZG_JZRS
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYWZG.Items(i).FindControl(Me.m_cstrtxtJZRSInDataGrid_grdYWZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        intValue = 0
                        If blnValid = True Then
                            If objTextBox.Text.Trim <> "" Then
                                If objPulicParameters.isIntegerString(objTextBox.Text) = False Then
                                    strErrMsg = "错误：输入的[" + objTextBox.Text + "]不是有效数值！"
                                    GoTo errProc
                                End If
                                intValue = objPulicParameters.getObjectValue(objTextBox.Text, 0)
                            End If
                        Else
                            intValue = objPulicParameters.getObjectValue(objTextBox.Text, 0)
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_GL_JZRS) = intValue
                    End If

                    '保存txtYWZG_JZZB
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYWZG.Items(i).FindControl(Me.m_cstrtxtJZZBInDataGrid_grdYWZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        dblValue = 0
                        If blnValid = True Then
                            If objTextBox.Text.Trim <> "" Then
                                If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                    strErrMsg = "错误：输入的[" + objTextBox.Text + "]不是有效数值！"
                                    GoTo errProc
                                End If
                                dblValue = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
                            End If
                        Else
                            dblValue = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_GL_JZZB) = dblValue.ToString("##0.00")
                    End If

                    '保存txtYWZG_TZZB
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYWZG.Items(i).FindControl(Me.m_cstrtxtTZZBInDataGrid_grdYWZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        dblValue = 0
                        If blnValid = True Then
                            If objTextBox.Text.Trim <> "" Then
                                If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                    strErrMsg = "错误：输入的[" + objTextBox.Text + "]不是有效数值！"
                                    GoTo errProc
                                End If
                                dblValue = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
                            End If
                        Else
                            dblValue = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_GL_TZZB) = dblValue.ToString("##0.00")
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_YWZG = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充职级下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：加空行
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillZjdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_ZHIJIDINGYI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZjdmList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillZjdmList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                Dim strWhere As String = ""
                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJDM + " like '020.010.%'"
                If objsystemEstateRenshiXingye.getDataSet_ZhijiDingyi(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiXingyeData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()

                '加空行
                If blnAddBlank = True Then
                    objDropDownList.Items.Add("")
                End If

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiXingyeData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)

            doFillZjdmList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYWJY中的非绑定数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_YWJY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_JY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_YWJY = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdYWJY.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdYWJY.CurrentPageIndex, Me.grdYWJY.PageSize)
                    objDataRow = Me.m_objDataSet_YWJY.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充ddlYWJY_ZJDM
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdYWJY.Items(i).FindControl(Me.m_cstrddlZJDMInDataGrid_grdYWJY), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        objControlProcess.doTranslateKey(objDropDownList)
                        Me.doFillZjdmList(strErrMsg, objDropDownList, False)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_JY_ZJDM), "")
                        Try
                            objDropDownList.SelectedIndex = objDropDownListProcess.getSelectedItem(objDropDownList, strValue)
                        Catch ex As Exception
                        End Try
                        objControlProcess.doEnabledControl(objDropDownList, Not Me.m_blnReadOnly)
                    End If

                    '填充txtYWJY_ZSBZ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYWJY.Items(i).FindControl(Me.m_cstrtxtZSBZInDataGrid_grdYWJY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_JY_ZSBZ), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充txtYWJY_SYBZ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYWJY.Items(i).FindControl(Me.m_cstrtxtSYBZInDataGrid_grdYWJY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_JY_SYBZ), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_YWJY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYWZG中的非绑定数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_YWZG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_GL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_YWZG = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdYWZG.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdYWZG.CurrentPageIndex, Me.grdYWZG.PageSize)
                    objDataRow = Me.m_objDataSet_YWZG.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充ddlYWZG_TDSX
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdYWZG.Items(i).FindControl(Me.m_cstrddlTDSXInDataGrid_grdYWZG), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        objControlProcess.doTranslateKey(objDropDownList)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_GL_TDSX), "")
                        Try
                            objDropDownList.SelectedIndex = objDropDownListProcess.getSelectedItem(objDropDownList, strValue)
                        Catch ex As Exception
                        End Try
                        objControlProcess.doEnabledControl(objDropDownList, Not Me.m_blnReadOnly)
                    End If

                    '填充txtYWZG_JZZB
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYWZG.Items(i).FindControl(Me.m_cstrtxtJZZBInDataGrid_grdYWZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_GL_JZZB), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充txtYWZG_TZZB
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYWZG.Items(i).FindControl(Me.m_cstrtxtTZZBInDataGrid_grdYWZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_GL_TZZB), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '填充txtYWZG_JZRS
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYWZG.Items(i).FindControl(Me.m_cstrtxtJZRSInDataGrid_grdYWZG), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_GL_JZRS), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_YWZG = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYWJY的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_YWJY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_JY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_YWJY = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_YWJY Is Nothing Then
                    Me.grdYWJY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YWJY.Tables(strTable)
                        Me.grdYWJY.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_YWJY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYWJY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdYWJY.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYWJY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWJY) = False Then
                    GoTo errProc
                End If

                '显示其他未绑定数据
                If Me.showDataGridUnboundInfo_YWJY(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_YWJY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYWZG的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_YWZG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_GL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_YWZG = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_YWZG Is Nothing Then
                    Me.grdYWZG.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YWZG.Tables(strTable)
                        Me.grdYWZG.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_YWZG.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYWZG, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdYWZG.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYWZG, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWZG) = False Then
                    GoTo errProc
                End If

                '显示其他未绑定数据
                If Me.showDataGridUnboundInfo_YWZG(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_YWZG = True
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
                Me.btnAddNew_YWJY.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_YWJY.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_YWJY.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_YWJY.Visible = Not Me.m_blnReadOnly

                Me.btnAddNew_YWZG.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_YWZG.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_YWZG.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_YWZG.Visible = Not Me.m_blnReadOnly

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

                    '显示grdYWJY
                    If Me.getModuleData_YWJY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_YWJY(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '显示grdYWZG
                    If Me.getModuleData_YWZG(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_YWZG(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    '获取缓存数据
                    If Me.getModuleData_YWJY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    '保存正在编辑的信息
                    If Me.saveDataGridUnboundInfo_YWJY(strErrMsg, False) = False Then
                        GoTo errProc
                    End If

                    '获取缓存数据
                    If Me.getModuleData_YWZG(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    '保存正在编辑的信息
                    If Me.saveDataGridUnboundInfo_YWZG(strErrMsg, False) = False Then
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
            Dim blnDo As Boolean

            Try
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
        Sub grdYWJY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYWJY.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdYWJY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdYWJY > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdYWJY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYWJY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdYWZG_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYWZG.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdYWZG + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdYWZG > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdYWZG - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYWZG.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub











        Private Sub doSelectAll_YWJY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdYWJY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWJY, True) = False Then
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

        Private Sub doDeSelectAll_YWJY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdYWJY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWJY, False) = False Then
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

        Private Sub doSelectAll_YWZG(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdYWZG, 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWZG, True) = False Then
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

        Private Sub doDeSelectAll_YWZG(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdYWZG, 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWZG, False) = False Then
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













        Private Sub doDelete_YWJY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_JY
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
                intRows = Me.grdYWJY.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdYWJY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWJY) = True Then
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
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYWJY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_JY_ZJMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdYWJY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWJY) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdYWJY.Items(i), intColIndex)
                            '获取要删除的数据
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdYWJY.CurrentPageIndex, Me.grdYWJY.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_YWJY.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            '删除处理
                            With Me.m_objDataSet_YWJY.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_考核标准]字典中删除了[" + strName + "]职级(暂没保存)！")
                        End If
                    Next

                    '刷新网格显示
                    If Me.showDataGridInfo_YWJY(strErrMsg) = False Then
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

        Private Sub doDelete_YWZG(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_GL
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
                intRows = Me.grdYWZG.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdYWZG.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWZG) = True Then
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
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYWZG, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_X2_KHBZ_GL_TDSXMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdYWZG.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWZG) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdYWZG.Items(i), intColIndex)
                            '获取要删除的数据
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdYWZG.CurrentPageIndex, Me.grdYWZG.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_YWZG.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            '删除处理
                            With Me.m_objDataSet_YWZG.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[人事_考核标准]字典中删除了[" + strName + "]团队指标(暂没保存)！")
                        End If
                    Next

                    '刷新网格显示
                    If Me.showDataGridInfo_YWZG(strErrMsg) = False Then
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














        Private Sub doAddNew_YWJY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_JY
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '加空行
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_YWJY.Tables(strTable)
                    objDataRow = .NewRow
                    .Rows.Add(objDataRow)
                End With

                '重新显示
                If Me.showDataGridInfo_YWJY(strErrMsg) = False Then
                    GoTo errProc
                End If
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

        Private Sub doAddNew_YWZG(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_X2_KHBZ_GL
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '加空行
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_YWZG.Tables(strTable)
                    objDataRow = .NewRow
                    .Rows.Add(objDataRow)
                End With

                '重新显示
                If Me.showDataGridInfo_YWZG(strErrMsg) = False Then
                    GoTo errProc
                End If
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.saveDataGridUnboundInfo_YWJY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                If Me.saveDataGridUnboundInfo_YWZG(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                '保存数据
                If objsystemEstateRenshiXingye.doSave_X2_KHBZ( _
                    strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                    Me.m_objDataSet_YWJY, _
                    Me.m_objDataSet_YWZG) = False Then
                    GoTo errProc
                End If

                '记录审计日志
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]提交了上述对[人事_考核标准]的改动！")

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

        Private Sub btnSelAll_YWJY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_YWJY.Click
            Me.doSelectAll_YWJY("btnSelAll_YWJY")
        End Sub

        Private Sub btnDeSelAll_YWJY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_YWJY.Click
            Me.doDeSelectAll_YWJY("btnDeSelAll_YWJY")
        End Sub

        Private Sub btnDelete_YWJY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_YWJY.Click
            Me.doDelete_YWJY("btnDelete_YWJY")
        End Sub

        Private Sub btnAddNew_YWJY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_YWJY.Click
            Me.doAddNew_YWJY("btnAddNew_YWJY")
        End Sub

        Private Sub btnSelAll_YWZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_YWZG.Click
            Me.doSelectAll_YWZG("btnSelAll_YWZG")
        End Sub

        Private Sub btnDeSelAll_YWZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_YWZG.Click
            Me.doDeSelectAll_YWZG("btnDeSelAll_YWZG")
        End Sub

        Private Sub btnDelete_YWZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_YWZG.Click
            Me.doDelete_YWZG("btnDelete_YWZG")
        End Sub

        Private Sub btnAddNew_YWZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_YWZG.Click
            Me.doAddNew_YWZG("btnAddNew_YWZG")
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
