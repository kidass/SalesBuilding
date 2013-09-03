Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_hetong_jss_info
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“结算书查看与编辑”处理模块
    '
    ' 更改记录：
    '     zengxianglin 2009-12-26 更改
    '     zengxianglin 2010-01-06 更改
    '----------------------------------------------------------------

    Partial Class estate_es_hetong_jss_info
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        'zengxianglin 2009-12-26
        'zengxianglin 2009-12-26






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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsHetongJssInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdJSMX相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdJSMX As String = "chkJSMX"
        Private Const m_cstrDataGridInDIV_grdJSMX As String = "divJSMX"
        Private m_intFixedColumns_grdJSMX As Integer
        Private Const m_cstrControlIdInDataGrid_grdJSMX_ddlJSMX_SFDM As String = "ddlJSMX_SFDM"
        Private Const m_cstrControlIdInDataGrid_grdJSMX_txtJSMX_JSEJ As String = "txtJSMX_JSEJ"
        Private Const m_cstrControlIdInDataGrid_grdJSMX_txtJSMX_JSEY As String = "txtJSMX_JSEY"

        '----------------------------------------------------------------
        '与数据网格grdYEJI相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdYEJI As String = "chkYEJI"
        Private Const m_cstrDataGridInDIV_grdYEJI As String = "divYEJI"
        Private m_intFixedColumns_grdYEJI As Integer
        Private Const m_cstrControlIdInDataGrid_grdYEJI_txtYEJI_BCJT As String = "txtYEJI_BCJT"

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_MAIN As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_JSMX As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_YEJI As Josco.JSOA.Common.Data.estateErshouData

        '----------------------------------------------------------------
        '其他参数
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_blnEditMode As Boolean
        Private m_strQRSH As String
        Private m_strJSSH As String













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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo)
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
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftMain.Value = .htxtDivLeftMain
                    Me.htxtDivTopMain.Value = .htxtDivTopMain
                    Me.htxtDivLeftJSMX.Value = .htxtDivLeftJSMX
                    Me.htxtDivTopJSMX.Value = .htxtDivTopJSMX
                    Me.htxtDivLeftYEJI.Value = .htxtDivLeftYEJI
                    Me.htxtDivTopYEJI.Value = .htxtDivTopYEJI

                    Me.htxtSessionId_JSMX.Value = .htxtSessionId_JSMX
                    Try
                        Me.grdJSMX.PageSize = .grdJSMX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJSMX.CurrentPageIndex = .grdJSMX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJSMX.SelectedIndex = .grdJSMX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtSessionId_YEJI.Value = .htxtSessionId_YEJI
                    Try
                        Me.grdYEJI.PageSize = .grdYEJI_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYEJI.CurrentPageIndex = .grdYEJI_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYEJI.SelectedIndex = .grdYEJI_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.txtWYDZ.Text = .txtWYDZ
                    Me.txtJFMC.Text = .txtJFMC
                    Me.txtYFMC.Text = .txtYFMC
                    Me.txtHTZK.Text = .txtHTZK
                    Me.txtHTBH.Text = .txtHTBH
                    Me.rblHTLX.SelectedIndex = .rblHTLX_SelectedIndex

                    Me.htxtWYBS.Value = .htxtWYBS
                    Me.htxtQRSH.Value = .htxtQRSH
                    Me.htxtZTBZ.Value = .htxtZTBZ
                    Me.htxtJBRY.Value = .htxtJBRY
                    Me.htxtJSDW.Value = .htxtJSDW

                    Me.txtJSSH.Text = .txtJSSH
                    Me.txtJSRQ.Text = .txtJSRQ
                    'zengxianglin 2009-12-26
                    Me.txtJYRQ.Text = .txtJYRQ
                    'zengxianglin 2009-12-26
                    Me.txtJBRY.Text = .txtJBRY
                    Me.txtJSDW.Text = .txtJSDW
                    Me.txtZJFE.Text = .txtZJFE
                    Me.txtJSEJ.Text = .txtJSEJ
                    Me.txtJSEY.Text = .txtJSEY
                    Me.txtSSEJ.Text = .txtSSEJ
                    Me.txtSSEY.Text = .txtSSEY
                    Me.txtBZXX.Text = .txtBZXX
                    Me.rblJSLX.SelectedIndex = .rblJSLX_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsHetongJssInfo

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftJSMX = Me.htxtDivLeftJSMX.Value
                    .htxtDivTopJSMX = Me.htxtDivTopJSMX.Value
                    .htxtDivLeftYEJI = Me.htxtDivLeftYEJI.Value
                    .htxtDivTopYEJI = Me.htxtDivTopYEJI.Value

                    .htxtSessionId_JSMX = Me.htxtSessionId_JSMX.Value
                    .grdJSMX_PageSize = Me.grdJSMX.PageSize
                    .grdJSMX_CurrentPageIndex = Me.grdJSMX.CurrentPageIndex
                    .grdJSMX_SelectedIndex = Me.grdJSMX.SelectedIndex

                    .htxtSessionId_YEJI = Me.htxtSessionId_YEJI.Value
                    .grdYEJI_PageSize = Me.grdYEJI.PageSize
                    .grdYEJI_CurrentPageIndex = Me.grdYEJI.CurrentPageIndex
                    .grdYEJI_SelectedIndex = Me.grdYEJI.SelectedIndex

                    .txtWYDZ = Me.txtWYDZ.Text
                    .txtJFMC = Me.txtJFMC.Text
                    .txtYFMC = Me.txtYFMC.Text
                    .txtHTZK = Me.txtHTZK.Text
                    .txtHTBH = Me.txtHTBH.Text
                    .rblHTLX_SelectedIndex = Me.rblHTLX.SelectedIndex

                    .htxtWYBS = Me.htxtWYBS.Value
                    .htxtQRSH = Me.htxtQRSH.Value
                    .htxtZTBZ = Me.htxtZTBZ.Value
                    .htxtJBRY = Me.htxtJBRY.Value
                    .htxtJSDW = Me.htxtJSDW.Value

                    .txtJSSH = Me.txtJSSH.Text
                    .txtJSRQ = Me.txtJSRQ.Text
                    'zengxianglin 2009-12-26
                    .txtJYRQ = Me.txtJYRQ.Text
                    'zengxianglin 2009-12-26
                    .txtJBRY = Me.txtJBRY.Text
                    .txtJSDW = Me.txtJSDW.Text
                    .txtZJFE = Me.txtZJFE.Text
                    .txtJSEJ = Me.txtJSEJ.Text
                    .txtJSEY = Me.txtJSEY.Text
                    .txtSSEJ = Me.txtSSEJ.Text
                    .txtSSEY = Me.txtSSEY.Text
                    .txtBZXX = Me.txtBZXX.Text
                    .rblJSLX_SelectedIndex = Me.rblJSLX.SelectedIndex
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

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg = Nothing
                Try
                    objIDmxzZzjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzjg)
                Catch ex As Exception
                    objIDmxzZzjg = Nothing
                End Try
                If Not (objIDmxzZzjg Is Nothing) Then
                    If objIDmxzZzjg.oExitMode = True Then
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper()
                            Case "btnSelect_JSDW".ToUpper()
                                Me.txtJSDW.Text = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtJSDW.Text, Me.htxtJSDW.Value) = False Then
                                    Me.htxtJSDW.Value = ""
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIDmxzRyxx As Josco.JsKernal.BusinessFacade.IDmxzRyxx = Nothing
                Try
                    objIDmxzRyxx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzRyxx)
                Catch ex As Exception
                    objIDmxzRyxx = Nothing
                End Try
                If Not (objIDmxzRyxx Is Nothing) Then
                    If objIDmxzRyxx.oExitMode = True Then
                        Select Case objIDmxzRyxx.iSourceControlId.ToUpper()
                            Case "btnSelect_JBRY".ToUpper()
                                Me.htxtJBRY.Value = objIDmxzRyxx.oRYDM
                                Me.txtJBRY.Text = objIDmxzRyxx.oRYZM
                                Me.htxtJSDW.Value = objIDmxzRyxx.oZZDM
                                Me.txtJSDW.Text = objIDmxzRyxx.oZZMC
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzRyxx.SafeRelease(objIDmxzRyxx)
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    Me.m_strQRSH = ""
                    Me.m_strJSSH = ""
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_objenumEditType = Me.m_objInterface.iMode
                    Me.m_strQRSH = Me.m_objInterface.iQRSH
                    Me.m_strJSSH = Me.m_objInterface.iJSSH
                End If
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_blnEditMode = True
                    Case Else
                        Me.m_blnEditMode = False
                End Select

                '检查
                If Me.m_blnInterface = False Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "错误：没有提供本模块需要的接口！"
                    Exit Try
                End If

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsHetongJssInfo)
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
                Me.m_intFixedColumns_grdJSMX = objPulicParameters.getObjectValue(Me.htxtJSMXFixed.Value, 0)
                Me.m_intFixedColumns_grdYEJI = objPulicParameters.getObjectValue(Me.htxtYEJIFixed.Value, 0)
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

            Dim strErrMsg As String = ""

            Try
                Dim objDataSet As Josco.JSOA.Common.Data.estateErshouData = Nothing
                If Me.htxtSessionId_JSMX.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_JSMX.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_JSMX.Value)
                    Me.htxtSessionId_JSMX.Value = ""
                End If
                If Me.htxtSessionId_YEJI.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_YEJI.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_YEJI.Value)
                    Me.htxtSessionId_YEJI.Value = ""
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub













        '----------------------------------------------------------------
        ' 获取要显示的主数据信息
        '     strErrMsg      ：返回错误信息
        '     strJSSH        ：结算书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_MAIN( _
            ByRef strErrMsg As String, _
            ByVal strJSSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_MM
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_MAIN = False

            Try
                '检查
                If strJSSH Is Nothing Then strJSSH = ""
                strJSSH = strJSSH.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_MAIN)

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_HETONG_JSS(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJSSH, Me.m_objDataSet_MAIN) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdJSMX要显示的数据
        '     strErrMsg      ：返回错误信息
        '     strJSSH        ：结算书号
        '     blnEditMode    ：True-编辑 False-查看
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_JSMX( _
            ByRef strErrMsg As String, _
            ByVal strJSSH As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_JSMX = False

            Try
                '检查
                If strJSSH Is Nothing Then strJSSH = ""
                strJSSH = strJSSH.Trim

                '获取数据
                If blnEditMode = True Then
                    If Me.htxtSessionId_JSMX.Value.Trim <> "" Then
                        '从缓存中获取数据
                        Me.m_objDataSet_JSMX = CType(Session.Item(Me.htxtSessionId_JSMX.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Else
                        '释放资源
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_JSMX)
                        '重新检索数据
                        If objsystemEstateErshou.getDataSet_ES_HETONG_JSS_MX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJSSH, Me.m_objDataSet_JSMX) = False Then
                            GoTo errProc
                        End If
                        '缓存数据
                        Me.htxtSessionId_JSMX.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_JSMX.Value, Me.m_objDataSet_JSMX)
                    End If
                Else
                    '释放缓存数据
                    If Me.htxtSessionId_JSMX.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_JSMX = CType(Session.Item(Me.htxtSessionId_JSMX.Value), Josco.JSOA.Common.Data.estateErshouData)
                        Catch ex As Exception
                            Me.m_objDataSet_JSMX = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_JSMX)
                        Session.Remove(Me.htxtSessionId_JSMX.Value)
                        Me.htxtSessionId_JSMX.Value = ""
                    End If
                    '释放资源
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_JSMX)
                    '重新检索数据
                    If objsystemEstateErshou.getDataSet_ES_HETONG_JSS_MX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJSSH, Me.m_objDataSet_JSMX) = False Then
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

            getModuleData_JSMX = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdYEJI要显示的数据
        '     strErrMsg      ：返回错误信息
        '     strJSSH        ：结算书号
        '     blnEditMode    ：True-编辑 False-查看
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_YEJI( _
            ByRef strErrMsg As String, _
            ByVal strJSSH As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_YEJI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_YEJI = False

            Try
                '检查
                If strJSSH Is Nothing Then strJSSH = ""
                strJSSH = strJSSH.Trim

                '获取数据
                If blnEditMode = True Then
                    If Me.htxtSessionId_YEJI.Value.Trim <> "" Then
                        '从缓存中获取数据
                        Me.m_objDataSet_YEJI = CType(Session.Item(Me.htxtSessionId_YEJI.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Else
                        '释放资源
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YEJI)
                        '重新检索数据
                        If objsystemEstateErshou.getDataSet_ES_HETONG_JSS_YEJI(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJSSH, Me.m_objDataSet_YEJI) = False Then
                            GoTo errProc
                        End If
                        '缓存数据
                        Me.htxtSessionId_YEJI.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_YEJI.Value, Me.m_objDataSet_YEJI)
                    End If
                Else
                    '释放缓存数据
                    If Me.htxtSessionId_YEJI.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_YEJI = CType(Session.Item(Me.htxtSessionId_YEJI.Value), Josco.JSOA.Common.Data.estateErshouData)
                        Catch ex As Exception
                            Me.m_objDataSet_YEJI = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YEJI)
                        Session.Remove(Me.htxtSessionId_YEJI.Value)
                        Me.htxtSessionId_YEJI.Value = ""
                    End If
                    '释放资源
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YEJI)
                    '重新检索数据
                    If objsystemEstateErshou.getDataSet_ES_HETONG_JSS_YEJI(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJSSH, Me.m_objDataSet_YEJI) = False Then
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

            getModuleData_YEJI = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' 填充税费下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：添加空白条目
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillSfdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_SHUIFEIMULU
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillSfdmList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillSfdmList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemEstateCommon.getDataSet_ShuifeiMulu(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateCommonData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                If blnAddBlank = True Then
                    objDropDownList.Items.Add("")
                End If

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateCommonData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillSfdmList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdJSMX中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_JSMX( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_JSMX = False
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
                intCount = Me.grdJSMX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJSMX.CurrentPageIndex, Me.grdJSMX.PageSize)
                    objDataRow = Me.m_objDataSet_JSMX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充ddlJSMX_SFDM
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdJSMX.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJSMX_ddlJSMX_SFDM), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        '填充列表
                        If Me.doFillSfdmList(strErrMsg, objDropDownList, False) = False Then
                            GoTo errProc
                        End If
                        objControlProcess.doTranslateKey(objDropDownList)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_SFDM), "")
                        objDropDownList.SelectedIndex = objDropDownListProcess.getSelectedItem(objDropDownList, strValue)
                        objControlProcess.doEnabledControl(objDropDownList, blnEditMode)
                    End If

                    '填充txtJSMX_JSEJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJSMX.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJSMX_txtJSMX_JSEJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEJ), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '填充txtJSMX_JSEY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJSMX.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJSMX_txtJSMX_JSEY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEY), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
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

            showDataGridUnboundInfo_JSMX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdJSMX中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        '     blnCheck       ：检查输入信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_JSMX( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            Optional ByVal blnCheck As Boolean = False) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_JSMX = False
            strErrMsg = ""

            Try
                '非编辑模式
                If blnEditMode = False Then
                    Exit Try
                End If

                '显示未绑定数据
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdJSMX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJSMX.CurrentPageIndex, Me.grdJSMX.PageSize)
                    objDataRow = Me.m_objDataSet_JSMX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充ddlJSMX_SFDM
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdJSMX.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJSMX_ddlJSMX_SFDM), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        If objDropDownList.SelectedIndex >= 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_SFDM) = objDropDownList.SelectedValue
                        Else
                            If blnCheck = True Then
                                strErrMsg = "错误：未指定[费用]！"
                                GoTo errProc
                            End If
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_SFDM) = ""
                        End If
                    End If

                    '填充txtJSMX_JSEJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJSMX.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJSMX_txtJSMX_JSEJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then objTextBox.Text = "0"
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：[" + objTextBox.Text + "]是无效的数字！"
                                GoTo errProc
                            End If
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEJ) = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
                    End If

                    '填充txtJSMX_JSEY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJSMX.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJSMX_txtJSMX_JSEY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then objTextBox.Text = "0"
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：[" + objTextBox.Text + "]是无效的数字！"
                                GoTo errProc
                            End If
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEY) = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
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

            saveDataGridUnboundInfo_JSMX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYEJI中的非绑定数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_YEJI( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_YEJI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_YEJI = False
            strErrMsg = ""

            Try
                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdYEJI.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdYEJI.CurrentPageIndex, Me.grdYEJI.PageSize)
                    objDataRow = Me.m_objDataSet_YEJI.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充txtYEJI_BCJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYEJI.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdYEJI_txtYEJI_BCJT), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCJT), "", "##0.00", True)
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_YEJI = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存grdYEJI中的非绑定数据到数据集
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        '     blnCheck       ：检查
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_YEJI( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            Optional ByVal blnCheck As Boolean = False) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_YEJI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_YEJI = False
            strErrMsg = ""

            Try
                '非编辑模式
                If blnEditMode = False Then
                    Exit Try
                End If

                '显示未绑定数据
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdYEJI.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '获取对应数据行
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdYEJI.CurrentPageIndex, Me.grdYEJI.PageSize)
                    objDataRow = Me.m_objDataSet_YEJI.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '填充txtYEJI_BCJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdYEJI.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdYEJI_txtYEJI_BCJT), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then objTextBox.Text = "0"
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "错误：[" + objTextBox.Text + "]是无效的数值！"
                                GoTo errProc
                            End If
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCJT) = objPulicParameters.getObjectValue(objTextBox.Text, 0.0)
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_YEJI = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdJSMX的数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_JSMX( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_JSMX = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_JSMX Is Nothing Then
                    Me.grdJSMX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_JSMX.Tables(strTable)
                        Me.grdJSMX.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_JSMX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdJSMX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdJSMX.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdJSMX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdJSMX) = False Then
                    GoTo errProc
                End If

                '显示未绑定数据
                If Me.showDataGridUnboundInfo_JSMX(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_JSMX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdYEJI的数据
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_YEJI( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_YEJI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_YEJI = False

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_YEJI Is Nothing Then
                    Me.grdYEJI.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YEJI.Tables(strTable)
                        Me.grdYEJI.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_YEJI.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYEJI, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdYEJI.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYEJI, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdYEJI) = False Then
                    GoTo errProc
                End If

                '显示未绑定数据
                If Me.showDataGridUnboundInfo_YEJI(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_YEJI = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示模块主信息
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditPanel_MAIN( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objJYXX As Josco.JSOA.Common.Data.estateErshouData = Nothing
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanel_MAIN = False
            strErrMsg = ""

            Try
                '显示结算书信息
                Dim strValue As String = ""
                Dim intValue As Integer = 0
                If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                    With Me.m_objDataSet_MAIN.Tables(strTable)
                        If .Rows.Count < 1 Then
                            '设置空值
                            Me.htxtWYBS.Value = ""
                            Me.htxtQRSH.Value = ""
                            Me.htxtZTBZ.Value = ""
                            Me.htxtJBRY.Value = ""
                            Me.htxtJSDW.Value = ""

                            Me.txtJSSH.Text = ""
                            Me.txtJSRQ.Text = ""
                            'zengxianglin 2009-12-26
                            Me.txtJYRQ.Text = ""
                            'zengxianglin 2009-12-26
                            Me.txtJBRY.Text = ""
                            Me.txtJSDW.Text = ""
                            Me.txtZJFE.Text = ""
                            Me.txtJSEJ.Text = ""
                            Me.txtJSEY.Text = ""
                            Me.txtSSEJ.Text = ""
                            Me.txtSSEY.Text = ""
                            Me.txtBZXX.Text = ""

                            Me.rblJSLX.SelectedIndex = -1
                        Else
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSLX), "")
                            Me.rblJSLX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblJSLX, strValue)

                            Me.htxtWYBS.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_WYBS), "")
                            Me.htxtQRSH.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_QRSH), "")
                            Me.htxtZTBZ.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZ), "")
                            Me.htxtJBRY.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JBRY), "")
                            Me.htxtJSDW.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSDW), "")

                            Me.txtJSSH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH), "")
                            Me.txtBZXX.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_BZXX), "")
                            Me.txtJSRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSRQ), "", "yyyy-MM-dd")
                            'zengxianglin 2009-12-26
                            Me.txtJYRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JYRQ), "", "yyyy-MM-dd")
                            'zengxianglin 2009-12-26
                            Me.txtJBRY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JBRYMC), "")
                            Me.txtJSDW.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSDWMC), "")
                            Me.txtZJFE.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_ZJFE), 0.0).ToString("#,###.00")
                            Me.txtJSEJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSEJ), 0.0).ToString("#,###.00")
                            Me.txtJSEY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSEY), 0.0).ToString("#,###.00")
                            Me.txtSSEJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_SSEJ), 0.0).ToString("#,###.00")
                            Me.txtSSEY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_SSEY), 0.0).ToString("#,###.00")
                        End If
                    End With
                End If

                '显示合同信息
                Me.txtHTZK.Text = ""
                Me.txtWYDZ.Text = ""
                Me.txtJFMC.Text = ""
                Me.txtYFMC.Text = ""
                Me.txtHTBH.Text = ""
                Me.rblHTLX.SelectedIndex = -1
                If Me.m_strQRSH <> "" Then
                    If objsystemEstateErshou.getDataSet_ES_JYXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, "", objJYXX) = False Then
                        GoTo errProc
                    End If
                    If objJYXX.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI) Is Nothing Then
                        strErrMsg = "错误：无法获取[合同数据]！"
                        GoTo errProc
                    End If
                    With objJYXX.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI)
                        If .Rows.Count < 1 Then
                            strErrMsg = "错误：无法获取[合同数据]！"
                            GoTo errProc
                        End If
                        Me.txtHTZK.Text = (objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_DLFZK), 0.0) * 100).ToString("#.00")
                        Me.txtWYDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYDZ), "")
                        Me.txtJFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YZMC), "")
                        Me.txtYFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_KHMC), "")
                        Me.txtHTBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH), "")
                        strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYLX), "")
                        Me.rblHTLX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblHTLX, strValue)
                    End With
                End If

                '操作控制
                '****************************************************************
                objControlProcess.doEnabledControl(Me.rblJSLX, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJSRQ, blnEditMode)
                'zengxianglin 2009-12-26
                objControlProcess.doEnabledControl(Me.txtJYRQ, blnEditMode)
                'zengxianglin 2009-12-26
                objControlProcess.doEnabledControl(Me.txtJSSH, False)
                objControlProcess.doEnabledControl(Me.txtJBRY, False)
                objControlProcess.doEnabledControl(Me.txtJSDW, False)
                objControlProcess.doEnabledControl(Me.txtZJFE, False)
                objControlProcess.doEnabledControl(Me.txtJSEJ, False)
                objControlProcess.doEnabledControl(Me.txtJSEY, False)
                objControlProcess.doEnabledControl(Me.txtSSEJ, False)
                objControlProcess.doEnabledControl(Me.txtSSEY, False)
                objControlProcess.doEnabledControl(Me.txtBZXX, blnEditMode)
                '****************************************************************
                objControlProcess.doEnabledControl(Me.rblHTLX, False)
                objControlProcess.doEnabledControl(Me.txtWYDZ, False)
                objControlProcess.doEnabledControl(Me.txtJFMC, False)
                objControlProcess.doEnabledControl(Me.txtYFMC, False)
                objControlProcess.doEnabledControl(Me.txtHTZK, False)
                objControlProcess.doEnabledControl(Me.txtHTBH, False)
                '****************************************************************
                Me.btnSelect_JBRY.Visible = blnEditMode
                Me.btnSelect_JSDW.Visible = blnEditMode
                Me.btnAddNew_JSMX.Visible = blnEditMode
                Me.btnDelete_JSMX.Visible = blnEditMode
                Me.btnCompute_JSMX.Visible = blnEditMode
                Me.btnCompute_YEJI.Visible = blnEditMode
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objJYXX)

            showEditPanel_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objJYXX)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示模块其他信息
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            showModuleData_MAIN = False

            Try
                Me.btnOK.Visible = blnEditMode
                Me.btnCancel.Visible = blnEditMode
                Me.btnClose.Visible = Not blnEditMode
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

            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            Try
                '仅在第一次调用页面时执行
                If Me.IsPostBack = False Then
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    objControlProcess.doTranslateKey(Me.txtWYDZ)
                    objControlProcess.doTranslateKey(Me.txtJFMC)
                    objControlProcess.doTranslateKey(Me.txtYFMC)
                    objControlProcess.doTranslateKey(Me.txtHTZK)
                    objControlProcess.doTranslateKey(Me.txtHTBH)
                    '********************************************
                    objControlProcess.doTranslateKey(Me.txtJSSH)
                    objControlProcess.doTranslateKey(Me.txtJSRQ)
                    'zengxianglin 2009-12-26
                    objControlProcess.doTranslateKey(Me.txtJYRQ)
                    'zengxianglin 2009-12-26
                    objControlProcess.doTranslateKey(Me.txtJBRY)
                    objControlProcess.doTranslateKey(Me.txtJSDW)
                    objControlProcess.doTranslateKey(Me.txtZJFE)
                    objControlProcess.doTranslateKey(Me.txtJSEJ)
                    objControlProcess.doTranslateKey(Me.txtJSEY)
                    objControlProcess.doTranslateKey(Me.txtSSEJ)
                    objControlProcess.doTranslateKey(Me.txtSSEY)
                    objControlProcess.doTranslateKey(Me.txtBZXX)

                    '显示数据
                    If Me.getModuleData_MAIN(strErrMsg, Me.m_strJSSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_JSMX(strErrMsg, Me.m_strJSSH, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_JSMX(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_YEJI(strErrMsg, Me.m_strJSSH, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_YEJI(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    '设初始数据
                    If Me.m_blnSaveScence = False Then
                        Select Case Me.m_objenumEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                '结算日期
                                Me.txtJSRQ.Text = Now.ToString("yyyy-MM-dd")
                                'zengxianglin 2009-12-26
                                Me.txtJYRQ.Text = Now.ToString("yyyy-MM-dd")
                                'zengxianglin 2009-12-26
                                '计算备用金
                                Dim dblJF As Double = 0.0
                                Dim dblYF As Double = 0.0
                                If objsystemEstateCaiwu.getHetongBeiyongjin(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, dblJF, dblYF) = True Then
                                    Me.txtSSEJ.Text = dblJF.ToString("#,###.00")
                                    Me.txtSSEY.Text = dblYF.ToString("#,###.00")
                                End If
                            Case Else
                        End Select
                    End If
                Else
                    If Me.getModuleData_JSMX(strErrMsg, Me.m_strJSSH, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_YEJI(strErrMsg, Me.m_strJSSH, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    '自动保存信息
                    If Me.m_blnEditMode = True Then
                        If Me.saveDataGridUnboundInfo_JSMX(strErrMsg, Me.m_blnEditMode) = False Then
                            GoTo errProc
                        End If
                        If Me.saveDataGridUnboundInfo_YEJI(strErrMsg, Me.m_blnEditMode) = False Then
                            GoTo errProc
                        End If
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
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
        Sub grdJSMX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdJSMX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdJSMX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdJSMX > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdJSMX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdJSMX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdYEJI_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYEJI.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdYEJI + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdYEJI > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdYEJI - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYEJI.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub













        Private Sub doSelect_JBRY(ByVal strControlId As String)

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
                Dim objIDmxzRyxx As Josco.JsKernal.BusinessFacade.IDmxzRyxx = Nothing
                Dim strUrl As String = ""
                objIDmxzRyxx = New Josco.JsKernal.BusinessFacade.IDmxzRyxx
                With objIDmxzRyxx
                    .iAllowNull = False
                    .iMultiSelect = False
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
                Session.Add(strNewSessionId, objIDmxzRyxx)
                strUrl = ""
                strUrl += "../../dmxz/dmxz_ryxx.aspx"
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

        Private Sub doSelect_JSDW(ByVal strControlId As String)

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
                    .iAllowNull = False
                    .iMultiSelect = False
                    .iAllowInput = False
                    .iBumenList = ""
                    .iSelectFFFW = False
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
                strUrl += "../../dmxz/dmxz_zzjg.aspx"
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

        Private Sub btnSelect_JBRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JBRY.Click
            Me.doSelect_JBRY("btnSelect_JBRY")
        End Sub

        Private Sub btnSelect_JSDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JSDW.Click
            Me.doSelect_JSDW("btnSelect_JSDW")
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

        Private Sub doDelete_JSMX(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '删除选定行
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdJSMX.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdJSMX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdJSMX) = True Then
                        With Me.m_objDataSet_JSMX.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJSMX.CurrentPageIndex, Me.grdJSMX.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next

                '重新显示
                If Me.showDataGridInfo_JSMX(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doAddNew_JSMX(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '加入
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_JSMX.Tables(strTable)
                    objDataRow = .NewRow
                    .Rows.Add(objDataRow)
                End With

                '重新显示
                If Me.showDataGridInfo_JSMX(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Function doValidate_JSMX( _
            ByRef strErrMsg As String, _
            ByRef blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            doValidate_JSMX = False
            blnValid = False

            Try
                '检查
                If Me.saveDataGridUnboundInfo_JSMX(strErrMsg, Me.m_blnEditMode, True) = False Then
                    GoTo errProc
                End If

                '检查费用重复
                Dim strSFDM01 As String = ""
                Dim strSFDM02 As String = ""
                Dim intCountA As Integer = 0
                Dim intCountB As Integer = 0
                Dim i As Integer = 0
                Dim j As Integer = 0
                With Me.m_objDataSet_JSMX.Tables(strTable)
                    intCountA = .Rows.Count
                    For i = 0 To intCountA - 1 Step 1
                        strSFDM01 = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_SFDM), "")
                        With Me.m_objDataSet_JSMX.Tables(strTable)
                            intCountB = .Rows.Count
                            For j = i + 1 To intCountB - 1 Step 1
                                strSFDM02 = objPulicParameters.getObjectValue(.Rows(j).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_SFDM), "")
                                If strSFDM01 = strSFDM02 Then
                                    strErrMsg = "错误：费用重复！"
                                    GoTo errProc
                                End If
                            Next
                        End With
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doValidate_JSMX = True
            blnValid = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Function doValidate_YEJI( _
            ByRef strErrMsg As String, _
            ByRef blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_YEJI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            doValidate_YEJI = False
            blnValid = False

            Try
                '检查
                If Me.saveDataGridUnboundInfo_YEJI(strErrMsg, Me.m_blnEditMode, True) = False Then
                    GoTo errProc
                End If

                '检查输入的合理性
                Dim dblValue() As Double = {0.0, 0.0, 0.0}
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With Me.m_objDataSet_YEJI.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        'zengxianglin 2008-12-06
                        dblValue(0) = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCZE), 0.0)
                        .Rows(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCZE) = CType(dblValue(0).ToString("##0.00"), Double)
                        dblValue(0) = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCZE), 0.0)
                        dblValue(1) = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCJT), 0.0)
                        .Rows(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCJT) = CType(dblValue(1).ToString("##0.00"), Double)
                        dblValue(1) = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCJT), 0.0)
                        'zengxianglin 2008-12-06

                        dblValue(2) = dblValue(0) - dblValue(1)
                        If dblValue(2) < 0 Then
                            strErrMsg = "错误：[本次计提]超过[本次总额]！"
                            GoTo errProc
                        End If
                        .Rows(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCBL) = dblValue(2)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doValidate_YEJI = True
            blnValid = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Sub doCompute_JSMX(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                Dim blnValid As Boolean = False
                If Me.doValidate_JSMX(strErrMsg, blnValid) = False Then
                    GoTo errProc
                End If
                If blnValid = False Then
                    strErrMsg = "错误：费用录入有错误！"
                    GoTo errProc
                End If

                '计算：结算额甲、结算额乙
                Dim dblJSEJ As Double = 0.0
                Dim dblJSEY As Double = 0.0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With Me.m_objDataSet_JSMX.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        dblJSEJ += objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEJ), 0.0)
                        dblJSEY += objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEY), 0.0)
                    Next
                End With

                '计算中介费额
                Dim strField As String = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_SFDM
                Dim strZJFDM As String = Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_ZJF_TOP
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                Dim dblZJFE As Double = 0.0
                With Me.m_objDataSet_JSMX.Tables(strTable)
                    strOldFilter = .DefaultView.RowFilter

                    Try
                        strNewFilter = strField + " = '" + strZJFDM + "' or " + strField + " like '" + strZJFDM + ".%'"
                        .DefaultView.RowFilter = strNewFilter
                        With Me.m_objDataSet_JSMX.Tables(strTable).DefaultView
                            intCount = .Count
                            For i = 0 To intCount - 1 Step 1
                                dblZJFE += objPulicParameters.getObjectValue(.Item(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEJ), 0.0)
                                dblZJFE += objPulicParameters.getObjectValue(.Item(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEY), 0.0)
                            Next
                        End With
                    Catch ex As Exception
                        .DefaultView.RowFilter = strOldFilter
                        strErrMsg = ex.Message
                        GoTo errProc
                    End Try

                    .DefaultView.RowFilter = strOldFilter
                End With

                '设置相关值
                Me.txtJSEJ.Text = dblJSEJ.ToString("#,###.00")
                Me.txtJSEY.Text = dblJSEY.ToString("#,###.00")
                Me.txtZJFE.Text = dblZJFE.ToString("#,###.00")
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

        Private Sub doCompute_YEJI(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataSet As Josco.JSOA.Common.Data.estateErshouData = Nothing
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.rblJSLX.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定[结算类型]！"
                    GoTo errProc
                End If
                Dim intJSLX As Integer = objPulicParameters.getObjectValue(Me.rblJSLX.SelectedValue, 0)
                If Me.txtZJFE.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[中介费额]！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtZJFE.Text) = False Then
                    strErrMsg = "错误：无效的[中介费额]！"
                    GoTo errProc
                End If
                Dim dblZJFE As Double = objPulicParameters.getObjectValue(Me.txtZJFE.Text, 0.0)
                If Me.txtHTZK.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[合同折扣]！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtHTZK.Text) = False Then
                    strErrMsg = "错误：无效的[合同折扣]！"
                    GoTo errProc
                End If
                Dim dblHTZK As Double = objPulicParameters.getObjectValue(Me.txtHTZK.Text, 0.0) / 100.0
                If Me.m_strQRSH = "" Then
                    strErrMsg = "错误：没有指定[确认书号]！"
                    GoTo errProc
                End If
                If dblZJFE <= 0 Then
                    strErrMsg = "错误：没有[中介费额]！"
                    GoTo errProc
                End If

                '计算
                If objsystemEstateErshou.doComputeYeji(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, dblHTZK, dblZJFE, intJSLX, objDataSet) = False Then
                    GoTo errProc
                End If

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YEJI)
                Me.m_objDataSet_YEJI = objDataSet
                Session.Item(Me.htxtSessionId_YEJI.Value) = Me.m_objDataSet_YEJI

                '显示
                If Me.showDataGridInfo_YEJI(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objNewData As New System.Collections.Specialized.NameValueCollection
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strJSSH As String = ""

            Try
                '检查
                '**********************************************************
                If Me.grdJSMX.Items.Count < 1 Then
                    strErrMsg = "错误：必须至少指定一个费用！"
                    GoTo errProc
                End If
                '**********************************************************
                Dim blnValid As Boolean = False
                If Me.doValidate_JSMX(strErrMsg, blnValid) = False Then
                    GoTo errProc
                End If
                If blnValid = False Then
                    strErrMsg = "错误：费用输入存在错误！"
                    GoTo errProc
                End If
                If Me.doValidate_YEJI(strErrMsg, blnValid) = False Then
                    GoTo errProc
                End If
                If blnValid = False Then
                    strErrMsg = "错误：业绩拆分输入存在错误！"
                    GoTo errProc
                End If
                '**********************************************************
                If Me.rblJSLX.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定[结算类型]！"
                    GoTo errProc
                End If
                If Me.htxtJBRY.Value.Trim = "" Then
                    strErrMsg = "错误：没有指定[经办人员]！"
                    GoTo errProc
                End If
                If Me.htxtJSDW.Value.Trim = "" Then
                    strErrMsg = "错误：没有指定[结算单位]！"
                    GoTo errProc
                End If
                '**********************************************************
                If Me.txtZJFE.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[中介费额]！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtZJFE.Text) = False Then
                    strErrMsg = "错误：无效的[中介费额]！"
                    GoTo errProc
                End If
                Dim dblZJFE As Double = objPulicParameters.getObjectValue(Me.txtZJFE.Text, 0.0)
                If dblZJFE <= 0.0 Then
                    strErrMsg = "错误：无效的[中介费额]！"
                    GoTo errProc
                End If
                If Me.txtSSEJ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[甲方实收额]！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtSSEJ.Text) = False Then
                    strErrMsg = "错误：无效的[甲方实收额]！"
                    GoTo errProc
                End If
                If Me.txtSSEY.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[乙方实收额]！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtSSEY.Text) = False Then
                    strErrMsg = "错误：无效的[乙方实收额]！"
                    GoTo errProc
                End If
                If Me.txtJSEJ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[甲方结算额]！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtJSEJ.Text) = False Then
                    strErrMsg = "错误：无效的[甲方结算额]！"
                    GoTo errProc
                End If
                If Me.txtJSEY.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[乙方结算额]！"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtJSEY.Text) = False Then
                    strErrMsg = "错误：无效的[乙方结算额]！"
                    GoTo errProc
                End If
                '**********************************************************
                Dim dblJSE() As Double = {0.0, 0.0}
                Dim dblSSE() As Double = {0.0, 0.0}
                dblJSE(0) = objPulicParameters.getObjectValue(Me.txtJSEJ.Text, 0.0)
                dblJSE(1) = objPulicParameters.getObjectValue(Me.txtJSEY.Text, 0.0)
                dblSSE(0) = objPulicParameters.getObjectValue(Me.txtSSEJ.Text, 0.0)
                dblSSE(1) = objPulicParameters.getObjectValue(Me.txtSSEY.Text, 0.0)
                If dblSSE(0) < dblJSE(0) Then
                    strErrMsg = "错误：[甲方结算额]超过[甲方实收额]！"
                    GoTo errProc
                End If
                If dblSSE(1) < dblJSE(1) Then
                    strErrMsg = "错误：[乙方结算额]超过[乙方实收额]！"
                    GoTo errProc
                End If
                If Me.grdYEJI.Items.Count < 1 Then
                    strErrMsg = "错误：没有执行[根据业绩分配比例自动计算]！"
                    GoTo errProc
                End If

                '准备接口数据
                objNewData.Clear()
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_WYBS, Me.htxtWYBS.Value.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_QRSH, Me.htxtQRSH.Value.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZ, Me.htxtZTBZ.Value.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JBRY, Me.htxtJBRY.Value.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSDW, Me.htxtJSDW.Value.Trim)
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH, Me.txtJSSH.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSRQ, Me.txtJSRQ.Text.Trim)
                'zengxianglin 2009-12-26
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JYRQ, Me.txtJYRQ.Text.Trim)
                'zengxianglin 2009-12-26
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_ZJFE, Me.txtZJFE.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSEJ, Me.txtJSEJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSEY, Me.txtJSEY.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_SSEJ, Me.txtSSEJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_SSEY, Me.txtSSEY.Text.Trim)
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_BZXX, Me.txtBZXX.Text.Trim)
                '********************************************************************************************************************
                Dim intValue As Integer = 0
                If Me.rblJSLX.SelectedIndex > 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSLX, Me.rblJSLX.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSLX, "1")
                End If

                '保存数据
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZ) = CType(Josco.JSOA.Common.Data.estateErshouData.enumJiesuanshuStatus.Weishen, Integer).ToString
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_QRSH) = Me.m_strQRSH
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_WYBS) = ""
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH) = ""
                        If objsystemEstateErshou.doSaveData_ES_HETONG_JSS( _
                            strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                            objNewData, _
                            Nothing, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Me.m_objDataSet_JSMX, _
                            Me.m_objDataSet_YEJI) = False Then
                            GoTo errProc
                        End If
                        '记录审计日志
                        strJSSH = objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH)
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[二手_合同结算书]中增加了[" + strJSSH + "]！")
                    Case Else
                        '获取数据
                        If Me.getModuleData_MAIN(strErrMsg, Me.m_strJSSH) = False Then
                            GoTo errProc
                        End If
                        '保存数据
                        Dim objDataRow As System.Data.DataRow = Nothing
                        With Me.m_objDataSet_MAIN.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU)
                            If .Rows.Count < 1 Then
                                objDataRow = Nothing
                            Else
                                objDataRow = .Rows(0)
                            End If
                        End With
                        If objDataRow Is Nothing Then
                            objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZ) = CType(Josco.JSOA.Common.Data.estateErshouData.enumJiesuanshuStatus.Weishen, Integer).ToString
                            objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_QRSH) = Me.m_strQRSH
                            objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_WYBS) = ""
                            objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH) = ""
                            If objsystemEstateErshou.doSaveData_ES_HETONG_JSS( _
                                strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                                objNewData, _
                                Nothing, _
                                Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                Me.m_objDataSet_JSMX, _
                                Me.m_objDataSet_YEJI) = False Then
                                GoTo errProc
                            End If
                            '记录审计日志
                            strJSSH = objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH)
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[二手_合同结算书]中增加了[" + strJSSH + "]！")
                        Else
                            If objsystemEstateErshou.doSaveData_ES_HETONG_JSS( _
                                strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                                objNewData, _
                                objDataRow, _
                                Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, _
                                Me.m_objDataSet_JSMX, _
                                Me.m_objDataSet_YEJI) = False Then
                                GoTo errProc
                            End If
                            '记录审计日志
                            strJSSH = objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH)
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[二手_合同结算书]中[修改]了[" + strJSSH + "]！")
                        End If
                End Select

                '返回处理
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
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

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnAddNew_JSMX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_JSMX.Click
            Me.doAddNew_JSMX("btnAddNew_JSMX")
        End Sub

        Private Sub btnDelete_JSMX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_JSMX.Click
            Me.doDelete_JSMX("btnDelete_JSMX")
        End Sub

        Private Sub btnCompute_JSMX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompute_JSMX.Click
            Me.doCompute_JSMX("btnCompute_JSMX")
        End Sub

        Private Sub btnCompute_YEJI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompute_YEJI.Click
            Me.doCompute_YEJI("btnCompute_YEJI")
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
