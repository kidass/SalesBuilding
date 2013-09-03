Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：flow_spyjtx
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　处理工作流文件的签批意见或补登领导意见任务
    '
    ' 接口参数：
    '     参见接口类IFlowBycl描述
    '----------------------------------------------------------------

    Public Class flow_spyjtx
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlLDMC As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblPrompt As System.Web.UI.WebControls.Label
        Protected WithEvents rblYJLX As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents txtFSR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSPR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBDR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSCSPSJ As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBDSJ As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSCSPLX As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLDPSSJ As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnSelectXZRY As System.Web.UI.WebControls.Button
        Protected WithEvents btnOK As System.Web.UI.WebControls.Button
        Protected WithEvents btnZuofei As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents textareaZSYJ As System.Web.UI.HtmlControls.HtmlTextArea
        Protected WithEvents textareaBJYJ As System.Web.UI.HtmlControls.HtmlTextArea
        Protected WithEvents textareaXZCKRY As System.Web.UI.HtmlControls.HtmlTextArea
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSFPZ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtValueA As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtValueB As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtValueC As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJJXH As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYJLX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLastYJLX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents btnSelectZSYJ As System.Web.UI.WebControls.Button
        Protected WithEvents btnSelectBJYJ As System.Web.UI.WebControls.Button
        Protected WithEvents btnSelectZSRY As System.Web.UI.WebControls.Button
        Protected WithEvents btnSelectBJRY As System.Web.UI.WebControls.Button
        Protected WithEvents chkXBBZ As System.Web.UI.WebControls.CheckBox

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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowSpyjtx
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowSpyjtx
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块访问数据参数
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

        '----------------------------------------------------------------
        '模块其他参数
        '----------------------------------------------------------------
        '工作流类型名称
        Private m_strFlowTypeName As String
        '文件标识
        Private m_strWJBS As String








        '----------------------------------------------------------------
        ' 复原模块现场信息并释放相应的资源
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody

                    Me.htxtSFPZ.Value = .htxtSFPZ
                    Me.htxtJJXH.Value = .htxtJJXH
                    Me.htxtYJLX.Value = .htxtYJLX

                    Me.htxtValueA.Value = .htxtValueA
                    Me.htxtValueB.Value = .htxtValueB
                    Me.htxtValueC.Value = .htxtValueC
                    'LJ 2008-05-9
                    Me.htxtLastYJLX.Value = .htxtLastYJLX
                    'LJ 2008-05-9

                    Me.txtFSR.Text = .txtFSR
                    Me.txtSPR.Text = .txtSPR
                    Me.txtBDR.Text = .txtBDR
                    Me.txtSCSPSJ.Text = .txtSCSPSJ
                    Me.txtBDSJ.Text = .txtBDSJ
                    Me.txtSCSPLX.Text = .txtSCSPLX
                    Me.txtLDPSSJ.Text = .txtLDPSSJ

                    Me.chkXBBZ.Checked = .chkXBBZ

                    Try
                        Me.ddlLDMC.SelectedIndex = .ddlLDMC_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.ddlLDMC.Enabled = .ddlLDMC_Enabled

                    Try
                        Me.rblYJLX.SelectedIndex = .rblYJLX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.btnZuofei.Enabled = .btnZuofei_Enabled

                    Me.textareaZSYJ.InnerText = .textareaZSYJ
                    Me.textareaBJYJ.InnerText = .textareaBJYJ
                    Me.textareaXZCKRY.InnerText = .textareaXZCKRY

                End With

                '释放资源
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

        End Sub

        '----------------------------------------------------------------
        ' 保存模块现场信息并返回相应的SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strSessionId As String = ""
            Dim strErrMsg As String

            saveModuleInformation = ""

            Try
                '创建SessionId
                strSessionId = objPulicParameters.getNewGuid()
                If strSessionId = "" Then
                    Exit Try
                End If

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowSpyjtx

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value

                    .htxtSFPZ = Me.htxtSFPZ.Value
                    .htxtJJXH = Me.htxtJJXH.Value
                    .htxtYJLX = Me.htxtYJLX.Value

                    .htxtValueA = Me.htxtValueA.Value
                    .htxtValueB = Me.htxtValueB.Value
                    .htxtValueC = Me.htxtValueC.Value

                    'LJ 2008-05-9
                    .htxtLastYJLX = Me.htxtLastYJLX.Value
                    'LJ 2008-05-9

                    .txtFSR = Me.txtFSR.Text
                    .txtSPR = Me.txtSPR.Text
                    .txtBDR = Me.txtBDR.Text
                    .txtSCSPSJ = Me.txtSCSPSJ.Text
                    .txtBDSJ = Me.txtBDSJ.Text
                    .txtSCSPLX = Me.txtSCSPLX.Text
                    .txtLDPSSJ = Me.txtLDPSSJ.Text

                    .chkXBBZ = Me.chkXBBZ.Checked

                    .ddlLDMC_SelectedIndex = Me.ddlLDMC.SelectedIndex
                    .ddlLDMC_Enabled = Me.ddlLDMC.Enabled

                    .rblYJLX_SelectedIndex = Me.rblYJLX.SelectedIndex

                    .btnZuofei_Enabled = Me.btnZuofei.Enabled

                    .textareaBJYJ = Me.textareaBJYJ.InnerText
                    .textareaZSYJ = Me.textareaZSYJ.InnerText
                    .textareaXZCKRY = Me.textareaXZCKRY.InnerText
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
                If Me.IsPostBack = True Then Exit Try

                '==============================================================================================================================================================================
                Dim objIGrswCyyj As Josco.JsKernal.BusinessFacade.IGrswCyyj
                Try
                    objIGrswCyyj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IGrswCyyj)
                Catch ex As Exception
                    objIGrswCyyj = Nothing
                End Try
                If Not (objIGrswCyyj Is Nothing) Then
                    If objIGrswCyyj.oExitMode = True Then
                        Select Case objIGrswCyyj.iSourceControlId.ToUpper
                            Case "btnSelectZSYJ".ToUpper
                                Me.textareaZSYJ.InnerText += objIGrswCyyj.oOpinion
                            Case "btnSelectBJYJ".ToUpper
                                Me.textareaBJYJ.InnerText += objIGrswCyyj.oOpinion
                            Case Else
                        End Select
                    End If
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIGrswCyyj.Dispose()
                    objIGrswCyyj = Nothing
                    Exit Try
                End If

                '==============================================================================================================================================================================
                Dim objIFlowSend As Josco.JSOA.BusinessFacade.IFlowSend
                Try
                    objIFlowSend = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowSend)
                Catch ex As Exception
                    objIFlowSend = Nothing
                End Try
                If Not (objIFlowSend Is Nothing) Then
                    Dim blnReturn As Boolean = objIFlowSend.oExitMode
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowSend.Dispose()
                    objIFlowSend = Nothing
                    If blnReturn = True Then
                        '设置返回参数
                        Me.m_objInterface.oExitMode = True
                        '返回到调用模块，并附加返回参数
                        '要返回的SessionId
                        Dim strSessionId As String
                        strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        'SessionId附加到返回的Url
                        Dim strUrl As String
                        strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                        '释放模块资源
                        Me.releaseModuleParameters()
                        Me.releaseInterfaceParameters()
                        '返回
                        If strUrl <> "" Then
                            Response.Redirect(strUrl)
                        End If
                    End If
                    Exit Try
                End If

                '==============================================================================================================================================================================
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Try
                    objIDmxzZzry = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzry)
                Catch ex As Exception
                    objIDmxzZzry = Nothing
                End Try
                If Not (objIDmxzZzry Is Nothing) Then
                    If objIDmxzZzry.oExitMode = True Then
                        Select Case objIDmxzZzry.iSourceControlId.ToUpper
                            Case "btnSelectXZRY".ToUpper
                                Me.textareaXZCKRY.Value = objIDmxzZzry.oRenyuanList
                            Case "btnSelectZSRY".ToUpper
                                Me.textareaZSYJ.InnerText = Me.textareaZSYJ.InnerText + objIDmxzZzry.oRenyuanList
                            Case "btnSelectBJRY".ToUpper
                                Me.textareaBJYJ.InnerText = Me.textareaBJYJ.InnerText + objIDmxzZzry.oRenyuanList
                            Case Else
                        End Select
                    End If
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIDmxzZzry.Dispose()
                    objIDmxzZzry = Nothing
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
        ' 释放接口参数(模块无返回数据时用)
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
                If Not (Me.m_objInterface Is Nothing) Then
                    If Me.m_objInterface.iInterfaceType = Josco.JSOA.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                        '释放Session
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                        '释放对象
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
        Private Function getInterfaceParameters(ByRef strErrMsg As String, ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowSpyjtx)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try

                '必须有接口参数
                Me.m_blnInterface = False
                If m_objInterface Is Nothing Then
                    '显示错误信息
                    strErrMsg = "本模块必须提供输入接口参数！"
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = strErrMsg
                    blnContinue = False
                    Exit Try
                End If
                Me.m_blnInterface = True
                With Me.m_objInterface
                    Me.chkXBBZ.Visible = .iDisplayXBBZ
                    Me.chkXBBZ.Checked = .iXBBZ
                End With

                '初始化工作流
                If Me.doInitializeWorkflow(strErrMsg) = False Then
                    GoTo errProc
                End If

                '初始化“领导列表”
                If Me.m_objInterface.iDLR <> "" Then
                    '补登模式
                    If Me.IsPostBack = False Then
                        '首次进入
                        Dim strList As String
                        If Me.m_objsystemFlowObject.getKeBudengLingdao(strErrMsg, Me.m_objInterface.iDLR, strList) = False Then
                            '不能获取数据
                        Else
                            '填充列表
                            If objDropDownListProcess.doFillData(strErrMsg, Me.ddlLDMC, strList) = False Then
                                '填充错误
                            End If
                        End If
                    End If
                End If

                '初始化“审批事宜”
                If Me.IsPostBack = False Then
                    Dim objYjlx As System.Collections.Specialized.NameValueCollection
                    If Me.m_objsystemFlowObject.getAllYjlx(strErrMsg, objYjlx) = False Then
                        strErrMsg = "错误：无法获取审批类型！"
                        GoTo errProc
                    End If
                    If objRadioButtonListProcess.doFillData(strErrMsg, Me.rblYJLX, objYjlx) = False Then
                        strErrMsg = "错误：无法初始化审批类型！"
                        GoTo errProc
                    End If
                    Me.rblYJLX.RepeatColumns = Me.rblYJLX.Items.Count
                End If

                '获取恢复现场参数
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowSpyjtx)
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

                '设置模块其他参数
                Me.m_strFlowTypeName = Me.m_objInterface.iFlowTypeName
                Me.m_strWJBS = Me.m_objInterface.iWJBS

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            getInterfaceParameters = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数(模块返回时用)
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 初始化工作流对象
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doInitializeWorkflow(ByRef strErrMsg As String) As Boolean

            doInitializeWorkflow = False
            strErrMsg = ""

            Try
                '不用初始化
                If Not (Me.m_objsystemFlowObject Is Nothing) Then
                    Exit Try
                End If

                '创建工作流对象
                Dim strFlowTypeName As String = Me.m_objInterface.iFlowTypeName
                Dim strFlowType As String
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                Me.m_objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '初始化工作流并填充数据
                Dim strWJBS As String = Me.m_objInterface.iWJBS
                If Me.m_objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, True) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doInitializeWorkflow = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示给定领导的审批意见信息(自己签批的)
        '     strErrMsg      ：返回错误信息
        '     objJioajieData ：当前交接数据
        '     objBanliData   ：办理数据集
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_SPXX_Self( _
            ByRef strErrMsg As String, _
            ByVal objJioajieData As Josco.JSOA.Common.Data.FlowData, _
            ByVal objBanliData As Josco.JSOA.Common.Data.FlowData) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            showModuleData_SPXX_Self = False
            strErrMsg = ""

            Try
                If objJioajieData Is Nothing Then
                    Exit Try
                End If
                If objBanliData Is Nothing Then
                    Exit Try
                End If

                '初始化
                With objJioajieData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE).DefaultView
                    If .Count < 1 Then
                        '没有数据
                        strErrMsg = "错误：您没有未完成的审批事宜！"
                        GoTo errProc
                    End If
                    With .Item(0)
                        Me.txtFSR.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSR), "")
                        Me.txtSPR.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSR), "")
                    End With
                End With
                Me.txtSCSPSJ.Text = ""
                Me.txtSCSPLX.Text = ""
                Me.txtBDR.Text = ""
                Me.txtBDSJ.Text = ""
                Me.textareaZSYJ.Value = ""
                Me.textareaBJYJ.Value = ""
                Me.textareaXZCKRY.Value = ""
                Me.btnZuofei.Enabled = False
                Me.btnOK.Enabled = True

                '填写办理情况
                Dim strBLZL As String
                With objBanliData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_BANLI).DefaultView
                    If .Count < 1 Then
                        Exit Try
                    End If

                    Me.btnZuofei.Enabled = True

                    With .Item(0)
                        Me.htxtYJLX.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLZL), "")

                        Me.txtSCSPSJ.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLRQ), "")
                        Me.txtBDR.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_DLR), "")
                        Me.txtBDSJ.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_DLRQ), "")
                        Me.htxtSFPZ.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_SFPZ), "")
                        Me.txtSCSPLX.Text = Me.m_objsystemFlowObject.doTranslateSFPZ(Me.htxtSFPZ.Value)

                        Me.textareaZSYJ.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLYJ), "")
                        Me.textareaBJYJ.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BJNR), "")
                        Me.textareaXZCKRY.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_XZYDRY), "")

                        strBLZL = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLZL), "")
                    End With
                End With

                '显示意见类型
                Dim intIndex As Integer
                intIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYJLX, strBLZL)
                If intIndex < 0 Then
                Else
                    If Me.rblYJLX.SelectedIndex >= 0 Then
                        If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                            If intIndex <> Me.rblYJLX.SelectedIndex Then
                                Me.htxtLastYJLX.Value = Me.rblYJLX.Items(intIndex).Text
                                objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：[" + Me.txtSPR.Text + "]已经在[" + Me.rblYJLX.Items(intIndex).Text + "]栏签署过意见，系统自动转到[" + Me.rblYJLX.SelectedItem.Text + "]栏！")
                            End If
                        End If
                    Else
                        Me.rblYJLX.SelectedIndex = intIndex
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            showModuleData_SPXX_Self = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示给定领导的审批意见信息(补登的)
        '     strErrMsg      ：返回错误信息
        '     objJioajieData ：当前交接数据
        '     objBanliData   ：办理数据集
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_SPXX_Daili( _
            ByRef strErrMsg As String, _
            ByVal objJioajieData As Josco.JSOA.Common.Data.FlowData, _
            ByVal objBanliData As Josco.JSOA.Common.Data.FlowData) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            showModuleData_SPXX_Daili = False
            strErrMsg = ""

            Try
                If objJioajieData Is Nothing Then
                    Exit Try
                End If
                If objBanliData Is Nothing Then
                    Exit Try
                End If

                '初始化
                With objJioajieData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE).DefaultView
                    If .Count < 1 Then
                        '没有数据
                        strErrMsg = "错误：没有审批事宜！"
                        GoTo errProc
                    End If
                    With .Item(0)
                        Me.txtFSR.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSR), "")
                        Me.txtSPR.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSR), "")
                    End With
                End With
                Me.txtSCSPSJ.Text = ""
                Me.txtSCSPLX.Text = ""
                Me.textareaZSYJ.Value = ""
                Me.textareaBJYJ.Value = ""
                Me.textareaXZCKRY.Value = ""
                Me.btnZuofei.Enabled = False
                Me.btnOK.Enabled = False

                '填写办理情况
                Dim strBLZL As String = ""
                Dim strDLR As String = ""
                With objBanliData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_BANLI).DefaultView
                    If .Count < 1 Then
                        Me.btnOK.Enabled = True
                        Exit Try
                    End If

                    strDLR = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_DLR), "")
                    If strDLR = "" Then
                        strErrMsg = "错误：[" + Me.txtSPR.Text + "]已经自己签署意见，您不能补登！"
                        GoTo errProc
                    End If
                    If strDLR <> Me.m_objInterface.iDLR Then
                        strErrMsg = "错误：[" + Me.txtSPR.Text + "]签署的意见已经由[" + strDLR + "]补登，您不能再补登！"
                        GoTo errProc
                    End If
                    Me.btnZuofei.Enabled = True
                    Me.btnOK.Enabled = True

                    With .Item(0)
                        Me.htxtYJLX.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLZL), "")

                        Me.txtSCSPSJ.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLRQ), "")
                        Me.txtBDR.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_DLR), "")
                        Me.txtBDSJ.Text = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_DLRQ), "")
                        Me.htxtSFPZ.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_SFPZ), "")
                        Me.txtSCSPLX.Text = Me.m_objsystemFlowObject.doTranslateSFPZ(Me.htxtSFPZ.Value)

                        Me.textareaZSYJ.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLYJ), "")
                        Me.textareaBJYJ.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BJNR), "")
                        Me.textareaXZCKRY.Value = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_XZYDRY), "")

                        strBLZL = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLZL), "")
                    End With
                End With

                '显示意见类型
                Dim intIndex As Integer
                intIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYJLX, strBLZL)
                If intIndex < 0 Then
                Else
                    If Me.rblYJLX.SelectedIndex >= 0 Then
                        If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                            If intIndex <> Me.rblYJLX.SelectedIndex Then
                                Me.htxtLastYJLX.Value = Me.rblYJLX.Items(intIndex).Text
                                objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：[" + Me.txtSPR.Text + "]已经在[" + Me.rblYJLX.Items(intIndex).Text + "]栏签署过意见，系统自动转到[" + Me.rblYJLX.SelectedItem.Text + "]栏！")
                            End If
                        End If
                    Else
                        Me.rblYJLX.SelectedIndex = intIndex
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            showModuleData_SPXX_Daili = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示给定领导的审批意见信息
        '     strErrMsg      ：返回错误信息
        '     strSPR         ：指定审批人
        '     strYjlx        ：审批类型
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_SPXX( _
            ByRef strErrMsg As String, _
            ByVal strSPR As String, _
            ByVal strYjlx As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objJioajieData As Josco.JSOA.Common.Data.FlowData
            Dim objBanliData As Josco.JSOA.Common.Data.FlowData

            Dim intJJXH As Integer

            showModuleData_SPXX = False

            Try
                '初始交接序号
                Me.htxtJJXH.Value = ""
                Me.htxtYJLX.Value = ""

                '分类处理
                If Me.m_objInterface.iDLR <> "" Then
                    If strSPR Is Nothing Then strSPR = ""
                    strSPR = strSPR.Trim
                    If strYjlx Is Nothing Then strYjlx = ""
                    strYjlx = strYjlx.Trim

                    '补登情况
                    Me.ddlLDMC.Enabled = True    '能选领导
                    Me.txtLDPSSJ.Enabled = True  '能输入
                    Me.txtLDPSSJ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                    Me.txtBDR.Text = Me.m_objInterface.iDLR
                    Me.txtBDSJ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                    Me.txtFSR.Text = ""
                    Me.txtSPR.Text = ""
                    Me.txtSCSPLX.Text = ""
                    Me.txtSCSPSJ.Text = ""
                    Me.htxtSFPZ.Value = ""
                    Me.textareaBJYJ.Value = ""
                    Me.textareaZSYJ.Value = ""
                    Me.textareaXZCKRY.Value = ""
                    Me.btnOK.Enabled = False
                    Me.btnZuofei.Enabled = False
                    If strSPR = "" Then
                        Exit Try
                    End If
                    Me.txtSPR.Text = strSPR

                    '获取最近1次的审批事宜
                    If Me.m_objsystemFlowObject.getLastSpsyJiaojieData(strErrMsg, strSPR, False, objJioajieData) = False Then
                        GoTo errProc
                    End If
                    With objJioajieData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                        If .Rows.Count < 1 Then
                            '没有数据
                            strErrMsg = "错误：[" + strSPR + "]没有审批事宜！"
                            GoTo errProc
                        End If
                        With .Rows(0)
                            intJJXH = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJXH), 0)
                            Me.htxtJJXH.Value = intJJXH.ToString
                            If Me.m_objsystemFlowObject.getBanliData(strErrMsg, intJJXH, objBanliData) = False Then
                                GoTo errProc
                            End If
                        End With
                    End With

                    '显示信息
                    If Me.showModuleData_SPXX_Daili(strErrMsg, objJioajieData, objBanliData) = False Then
                        GoTo errProc
                    End If
                Else
                    '自己签署
                    Me.ddlLDMC.Enabled = False   '不能选领导
                    Me.txtLDPSSJ.Enabled = False '不能输入
                    Me.txtLDPSSJ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                    Me.txtBDR.Text = ""
                    Me.txtBDSJ.Text = ""
                    Me.txtFSR.Text = ""
                    Me.txtSPR.Text = ""
                    Me.txtSCSPLX.Text = ""
                    Me.txtSCSPSJ.Text = ""
                    Me.htxtSFPZ.Value = ""
                    Me.textareaBJYJ.Value = ""
                    Me.textareaZSYJ.Value = ""
                    Me.textareaXZCKRY.Value = ""
                    Me.btnOK.Enabled = False
                    Me.btnZuofei.Enabled = False

                    '获取最近1次的审批事宜
                    If Me.m_objsystemFlowObject.getLastSpsyJiaojieData(strErrMsg, Me.m_objInterface.iSPR, True, objJioajieData) = False Then
                        GoTo errProc
                    End If
                    With objJioajieData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                        If .Rows.Count < 1 Then
                            '没有数据
                            strErrMsg = "错误：您没有未完成的审批事宜！"
                            GoTo errProc
                        End If
                        With .Rows(0)
                            intJJXH = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJXH), 0)
                            Me.htxtJJXH.Value = intJJXH.ToString
                            If Me.m_objsystemFlowObject.getBanliData(strErrMsg, intJJXH, objBanliData) = False Then
                                GoTo errProc
                            End If
                        End With
                    End With

                    '显示信息
                    If Me.showModuleData_SPXX_Self(strErrMsg, objJioajieData, objBanliData) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objJioajieData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objBanliData)

            showModuleData_SPXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objJioajieData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objBanliData)
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

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim strYjlx As String
            Dim strSPR As String

            showModuleData_Main = False

            Try
                Me.lblPrompt.Text = Me.m_objInterface.iPromptInfo

                '根据输入参数获取信息
                If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                    '首次进入
                    If Me.m_objInterface.iDLR <> "" Then
                        '补登
                        If Me.ddlLDMC.Items.Count < 1 Then
                            strSPR = ""
                        Else
                            If Me.ddlLDMC.SelectedIndex < 0 Then
                                Me.ddlLDMC.SelectedIndex = 0
                            End If
                            strSPR = Me.ddlLDMC.Items(Me.ddlLDMC.SelectedIndex).Value
                        End If

                        If Me.rblYJLX.SelectedIndex < 0 Then
                            Me.rblYJLX.SelectedIndex = 0
                        End If
                        strYjlx = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Value
                    Else
                        '自签
                        strSPR = Me.m_objInterface.iSPR
                        strYjlx = Me.m_objInterface.iInitYjlx
                        If strYjlx = "" Then
                            If Me.rblYJLX.Items.Count > 0 Then
                                Me.rblYJLX.SelectedIndex = 0
                                strYjlx = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Value
                            End If
                        Else
                            Dim intIndex As Integer
                            intIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYJLX, strYjlx)
                            If intIndex >= 0 Then
                                Me.rblYJLX.SelectedIndex = intIndex
                            End If
                        End If
                    End If

                Else
                    '回发或调用返回
                    If Me.m_objInterface.iDLR <> "" Then
                        '补登
                        If Me.ddlLDMC.Items.Count < 1 Then
                            strSPR = ""
                        Else
                            If Me.ddlLDMC.SelectedIndex < 0 Then
                                Me.ddlLDMC.SelectedIndex = 0
                            End If
                            strSPR = Me.ddlLDMC.Items(Me.ddlLDMC.SelectedIndex).Value
                        End If
                    Else
                        '自签
                        strSPR = Me.m_objInterface.iSPR
                    End If

                    If Me.rblYJLX.SelectedIndex < 0 Then
                        Me.rblYJLX.SelectedIndex = 0
                    End If
                    strYjlx = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Value
                End If

                If Me.showModuleData_SPXX(strErrMsg, strSPR, strYjlx) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)

            showModuleData_Main = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
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

                    '显示提醒信息
                    Me.lblPrompt.Text = Me.m_objInterface.iPromptInfo

                    '显示Main
                    If Me.m_blnSaveScence = False Then
                        If Me.showModuleData_Main(strErrMsg) = False Then
                            GoTo errProc
                        End If
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

                '获取接口参数
                Dim blnContinue As Boolean
                If Me.getInterfaceParameters(strErrMsg, blnContinue) = False Then
                    GoTo errProc
                End If
                If blnContinue = False Then
                    Exit Try
                End If

                '控件初始化
                If Me.initializeControls(strErrMsg) = False Then
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

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(Me.m_objsystemFlowObject)

        End Sub




        Private Sub ddlLDMC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLDMC.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '重新显示
                If Me.showModuleData_Main(strErrMsg) = False Then
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

        Private Sub rblYJLX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblYJLX.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '不用检查
                If Me.rblYJLX.SelectedIndex < 0 Then
                    Exit Try
                End If

                '检查
                Dim strSelectedText As String = ""
                Dim intCount As Integer
                Dim i As Integer
                If Me.rblYJLX.SelectedIndex < Me.m_objInterface.iYjlxEnabled.Length Then
                    If Me.m_objInterface.iYjlxEnabled(Me.rblYJLX.SelectedIndex) = False Then
                        '备份选择
                        strSelectedText = Me.rblYJLX.SelectedItem.Text

                        '设置可能的缺省意见
                        intCount = Me.m_objInterface.iYjlxEnabled.Length
                        For i = intCount - 1 To 0 Step -1
                            If Me.m_objInterface.iYjlxEnabled(i) = True Then
                                Me.rblYJLX.SelectedIndex = i
                                Exit For
                            End If
                        Next

                        '提示错误
                        strErrMsg = "错误：您不能签署[" + strSelectedText + "]意见！"
                        GoTo errProc
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





        Private Sub doSelectXZRY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Dim strUrl As String
                objIDmxzZzry = New Josco.JsKernal.BusinessFacade.IDmxzZzry
                With objIDmxzZzry
                    .iSelectMode = False
                    .iAllowInput = False
                    .iAllowNull = False
                    .iMultiSelect = True
                    .iSelectBMMC = False
                    .iSelectFFFW = False
                    .iRenyuanList = ""

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIDmxzZzry)
                strUrl = ""
                strUrl += "../dmxz/dmxz_zzry.aspx"
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

        Private Sub doSelectZSRY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Dim strUrl As String
                objIDmxzZzry = New Josco.JsKernal.BusinessFacade.IDmxzZzry
                With objIDmxzZzry
                    .iSelectMode = True
                    .iAllowInput = False
                    .iAllowNull = False
                    .iMultiSelect = True
                    .iSelectBMMC = True
                    .iSelectFFFW = False
                    .iRenyuanList = ""

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIDmxzZzry)
                strUrl = ""
                strUrl += "../dmxz/dmxz_zzry.aspx"
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

        Private Sub doSelectBJRY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Dim strUrl As String
                objIDmxzZzry = New Josco.JsKernal.BusinessFacade.IDmxzZzry
                With objIDmxzZzry
                    .iSelectMode = True
                    .iAllowInput = False
                    .iAllowNull = False
                    .iMultiSelect = True
                    .iSelectBMMC = True
                    .iSelectFFFW = False
                    .iRenyuanList = ""

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIDmxzZzry)
                strUrl = ""
                strUrl += "../dmxz/dmxz_zzry.aspx"
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

        Private Sub doSelectZSYJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String

            Try
                If Me.m_objInterface.iDLR <> "" Then
                    If Me.ddlLDMC.SelectedIndex < 0 Then
                        strErrMsg = "错误：没有选择领导！"
                        GoTo errProc
                    End If
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIGrswCyyj As Josco.JsKernal.BusinessFacade.IGrswCyyj
                Dim strUrl As String
                objIGrswCyyj = New Josco.JsKernal.BusinessFacade.IGrswCyyj
                With objIGrswCyyj
                    If Me.m_objInterface.iDLR <> "" Then
                        .iBLR = Me.ddlLDMC.SelectedItem.Text
                    Else
                        .iBLR = Me.m_objInterface.iSPR
                    End If

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIGrswCyyj)
                strUrl = ""
                strUrl += "../grsw/grsw_cyyj.aspx"
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

        Private Sub doSelectBJYJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String

            Try
                If Me.m_objInterface.iDLR <> "" Then
                    If Me.ddlLDMC.SelectedIndex < 0 Then
                        strErrMsg = "错误：没有选择领导！"
                        GoTo errProc
                    End If
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIGrswCyyj As Josco.JsKernal.BusinessFacade.IGrswCyyj
                Dim strUrl As String
                objIGrswCyyj = New Josco.JsKernal.BusinessFacade.IGrswCyyj
                With objIGrswCyyj
                    If Me.m_objInterface.iDLR <> "" Then
                        .iBLR = Me.ddlLDMC.SelectedItem.Text
                    Else
                        .iBLR = Me.m_objInterface.iSPR
                    End If

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIGrswCyyj)
                strUrl = ""
                strUrl += "../grsw/grsw_cyyj.aspx"
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

        Private Sub btnSelectZSYJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZSYJ.Click
            Me.doSelectZSYJ("btnSelectZSYJ")
        End Sub

        Private Sub btnSelectBJYJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectBJYJ.Click
            Me.doSelectBJYJ("btnSelectBJYJ")
        End Sub

        Private Sub btnSelectXZRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectXZRY.Click
            Me.doSelectXZRY("btnSelectXZRY")
        End Sub

        Private Sub btnSelectZSRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZSRY.Click
            Me.doSelectZSRY("btnSelectZSRY")
        End Sub

        Private Sub btnSelectBJRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectBJRY.Click
            Me.doSelectBJRY("btnSelectBJRY")
        End Sub





        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '设置返回参数
                Me.m_objInterface.oExitMode = False

                '返回到调用模块，并附加返回参数
                '要返回的SessionId
                Dim strSessionId As String
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                'SessionId附加到返回的Url
                Dim strUrl As String
                strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)

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

        Private Function doSendFile( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strSPR As String, _
            ByVal strDLR As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doSendFile = False
            strErrMsg = ""

            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIFlowSend As Josco.JSOA.BusinessFacade.IFlowSend
                Dim strUrl As String
                objIFlowSend = New Josco.JSOA.BusinessFacade.IFlowSend
                With objIFlowSend
                    .iFlowTypeName = Me.m_objInterface.iFlowTypeName
                    .iWJBS = Me.m_objInterface.iWJBS
                    .iBLR = strSPR
                    .iWTFS = True
                    .iDLR = strDLR

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowSend)
                strUrl = ""
                strUrl += "flow_send.aspx"
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

            doSendFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Sub doOK(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Dim objNewData As New System.Collections.Specialized.NameValueCollection
            Dim objJiaojieData As Josco.JSOA.Common.Data.FlowData
            Dim strPrompt As String
            Dim strWhere As String = ""
            Dim strFileds As String = ""
            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

            Try
                '获取审批事宜
                Dim strXyrList As String
                Dim blnNeed As Boolean
                Dim blnYesNo As Boolean
                Dim strYjlxmc As String
                Dim strYjlx As String
                Dim strSPR As String
                If Me.rblYJLX.SelectedIndex < 0 Then
                    strErrMsg = "错误：未指定审批类型！"
                    GoTo errProc
                End If
                strYjlxmc = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Text
                strYjlx = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Value
                strSPR = Me.txtSPR.Text
                If Me.htxtJJXH.Value.Trim = "" Then
                    strErrMsg = "错误：没有审批事宜！"
                    GoTo errProc
                End If

                '能否签署本意见
                'If Me.rblYJLX.SelectedIndex < Me.m_objInterface.iYjlxEnabled.Length Then
                '    If Me.m_objInterface.iYjlxEnabled(Me.rblYJLX.SelectedIndex) = False Then
                '        strErrMsg = "错误：您不能签署[" + strYjlxmc + "]意见！"
                '        GoTo errProc
                '    End If
                'Else
                '    strErrMsg = "错误：传入的参数错误！"
                '    GoTo errProc
                'End If

                '检查意见内容
                If Me.textareaZSYJ.Value.Trim = "" Then
                    Me.textareaZSYJ.Value = Me.m_objsystemFlowObject.getDefaultYJNR(Me.rblYJLX.SelectedValue)
                End If
                If Me.textareaZSYJ.Value.Trim = "" Then
                    strErrMsg = "错误：没有输入任何意见！"
                    GoTo errProc
                End If

                '签名提示
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '需要签名询问?
                    If Me.m_objsystemFlowObject.isNeedQianminQuerenPrompt(strErrMsg, strYjlx, strSPR, blnNeed, strXyrList) = False Then
                        GoTo errProc
                    End If
                    Me.htxtValueB.Value = "0"
                    If blnNeed = True Then
                        If Me.m_objsystemFlowObject.isFileQianminTask(strYjlx, strPrompt) = True Then
                            '对整个文件负责的签名！
                            If strXyrList <> "" Then
                                strPrompt = "提示：" + strXyrList + "  已经签批。 您要继续签批吗？"
                            End If
                        Else
                            strPrompt = "提示：您确定文件[" + strYjlxmc + "]通过吗（确定/取消）？[通过]请按[确定]，否则请按[取消]！"
                            If strXyrList <> "" Then
                                strPrompt = "提示：[" + strXyrList + "]已经签批。 您要继续签批吗？ "
                            End If
                        End If
                        objMessageProcess.doConfirmMessage(Me.popMessageObject, strPrompt, strControlId, intStep, True)
                        Exit Try
                    Else
                        If Me.m_objsystemFlowObject.isQianminTask(strYjlx) = True Then
                            Me.htxtValueB.Value = "1"
                        End If
                    End If
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '接收审批签名类型
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    blnYesNo = objMessageProcess.getConfirmBoxValue(Request, Me.popMessageObject.UniqueID)
                    If blnYesNo = True Then
                        '签名意见
                        Me.htxtValueA.Value = "1"

                        '共同签名？单独签名？
                        If Me.m_objsystemFlowObject.isNeedQianminQuerenPrompt(strErrMsg, strYjlx, strSPR, blnNeed, strXyrList) = False Then
                            GoTo errProc
                        End If
                        If blnNeed = True Then
                            If strXyrList <> "" Then
                                Dim strTX As String = ""
                                objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：[" + strXyrList + "]已经签批        " + vbCr + vbCr + "您是要" + vbCr + vbCr + "[独立签批--------按确定]" + vbCr + vbCr + "[共同签批--------按取消]？", strControlId, intStep, True)
                                Exit Try
                            End If
                        End If
                    Else
                        If Me.htxtValueB.Value.Trim = "1" Then
                            '签名意见
                            Me.htxtValueA.Value = "1"
                        Else
                            '普通意见
                            Me.htxtValueA.Value = "0"
                        End If
                    End If
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '审批处理
                Dim intMode As Integer
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取审批模式
                    If Me.htxtValueA.Value = "0" Then
                        '普通
                        intMode = 2
                    Else
                        blnYesNo = objMessageProcess.getConfirmBoxValue(Request, Me.popMessageObject.UniqueID)
                        If blnYesNo = True Then
                            '单独
                            intMode = 0
                        Else
                            '共同
                            intMode = 1
                        End If
                    End If

                    '准备审批参数
                    objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BJNR, Me.textareaBJYJ.Value)
                    objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLJG, "")
                    objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLLX, Me.m_objsystemFlowObject.FlowData.FlowTypeBLLX)
                    objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLR, Me.txtSPR.Text)
                    If Me.txtLDPSSJ.Text.Trim <> "" Then
                        objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLRQ, Me.txtLDPSSJ.Text.Trim)
                    Else
                        objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLRQ, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                    End If
                    objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLYJ, Me.textareaZSYJ.Value)
                    objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_BLZL, strYjlx)
                    If Me.m_objInterface.iDLR <> "" Then
                        objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_DLR, Me.m_objInterface.iDLR)
                        objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_DLRQ, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                    Else
                        objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_DLR, "")
                        objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_DLRQ, "")
                    End If
                    objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_JJXH, Me.htxtJJXH.Value)
                    Select Case intMode
                        Case 0, 1
                            objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_SFPZ, Me.m_objsystemFlowObject.getPizhunBLBZ)
                        Case Else
                            objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_SFPZ, Me.m_objsystemFlowObject.getBaocunYijianBLBZ)
                    End Select
                    objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_TXRQ, "")
                    objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_WJBS, Me.m_objInterface.iWJBS)
                    objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_XZYDRY, Me.textareaXZCKRY.Value)

                    '取消签名(现有)
                    If Me.m_objsystemFlowObject.doQianminCancel(strErrMsg, Me.htxtYJLX.Value, Me.txtSPR.Text) = False Then
                        GoTo errProc
                    End If


                    '保存意见
                    Dim intJJXH As Integer = CType(Me.htxtJJXH.Value, Integer)
                    If Me.m_objsystemFlowObject.doSaveSpyj(strErrMsg, intJJXH, objNewData) = False Then
                        GoTo errProc
                    End If

                    '重新签名(新签名)
                    If Me.m_objsystemFlowObject.doQianminQueren(strErrMsg, strYjlx, Me.txtSPR.Text, intMode) = False Then
                        GoTo errProc
                    End If

                    '写协办标志
                    If Me.chkXBBZ.Visible = True Then
                        If Me.chkXBBZ.Checked = True Then
                            If Me.m_objsystemFlowObject.doSetJiaojieXBBZ(strErrMsg, Me.txtSPR.Text, Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue) = False Then
                                GoTo errProc
                            End If
                        Else
                            If Me.m_objsystemFlowObject.doSetJiaojieXBBZ(strErrMsg, Me.txtSPR.Text, Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse) = False Then
                                GoTo errProc
                            End If
                        End If
                    End If

                    '记录访问审计日志
                    If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "签署了文件[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]的[审批意见]！") = False Then
                        '忽略
                    End If

                    '如果是自己签名，则退出
                    If Me.m_objInterface.iDLR <> "" Then
                        '审批人的事宜是否办完？
                        If Me.m_objsystemFlowObject.isAllTaskComplete(strErrMsg, Me.txtSPR.Text, blnYesNo) = False Then
                            GoTo errProc
                        End If
                        If blnYesNo = False Then
                            '把审批人置成正在办理和填上日期，只有没有接收日期，或者没有接收
                            strWhere = "接收人='" + Me.txtSPR.Text.Trim + "' and 接收日期 is null"
                            If Me.m_objsystemFlowObject.getJiaojieData(strErrMsg, strWhere, False, objJiaojieData) = False Then
                                GoTo errProc
                            End If
                            Dim intCount As Integer
                            With objJiaojieData.Tables(strTable)
                                intCount = .DefaultView.Count
                                If intCount > 0 Then
                                    strWhere = ""
                                    strFileds = ""
                                    strWhere = "where 文件标识='" + Me.m_objInterface.iWJBS + "' and 接收人='" + Me.txtSPR.Text.Trim + "' and 接收日期 is null"
                                    strFileds = "set 办理状态='正在办理',接收日期=发送日期"
                                    If Me.m_objsystemFlowObject.doUpdateJiaojie(strErrMsg, strWhere, strFileds) = False Then
                                        GoTo errProc
                                    End If
                                End If
                            End With

                            '送出文件
                            If Me.doSendFile(strErrMsg, strControlId, Me.txtSPR.Text, Me.m_objInterface.iDLR) = False Then
                                GoTo errProc
                            End If
                        Else
                            '直接返回
                            If Me.showModuleData_Main(strErrMsg) = False Then
                                GoTo errProc
                            End If
                        End If
                    Else
                        '设置返回参数
                        Me.m_objInterface.oExitMode = True
                        '返回到调用模块，并附加返回参数
                        '要返回的SessionId
                        Dim strSessionId As String
                        strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        'SessionId附加到返回的Url
                        Dim strUrl As String
                        strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                        '释放模块资源
                        Me.releaseModuleParameters()
                        Me.releaseInterfaceParameters()
                        '返回
                        If strUrl <> "" Then
                            Response.Redirect(strUrl)
                        End If
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doZuofei(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                '获取审批事宜
                Dim strXyrList As String
                Dim blnNeed As Boolean
                Dim blnYesNo As Boolean
                Dim strYjlxmc As String
                Dim strYjlx As String
                Dim strSPR As String
                If Me.rblYJLX.SelectedIndex < 0 Then
                    strErrMsg = "错误：未指定审批类型！"
                    GoTo errProc
                End If
                strYjlxmc = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Text
                strYjlx = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Value
                strSPR = Me.txtSPR.Text
                If Me.htxtJJXH.Value.Trim = "" Then
                    strErrMsg = "错误：没有审批事宜！"
                    GoTo errProc
                End If

                '提示
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确定作废当前审批意见吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '作废
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '取消签名
                    If Me.m_objsystemFlowObject.doQianminCancel(strErrMsg, Me.htxtYJLX.Value, Me.txtSPR.Text) = False Then
                        GoTo errProc
                    End If

                    '取消审批记录
                    Dim intJJXH As Integer
                    intJJXH = CType(Me.htxtJJXH.Value, Integer)
                    If Me.m_objsystemFlowObject.doBanliCancel(strErrMsg, intJJXH) = False Then
                        GoTo errProc
                    End If

                    '设置返回参数
                    Me.m_objInterface.oExitMode = True
                    '返回到调用模块，并附加返回参数
                    '要返回的SessionId
                    Dim strSessionId As String
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    'SessionId附加到返回的Url
                    Dim strUrl As String
                    strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
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

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnZuofei_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnZuofei.Click
            Me.doZuofei("btnZuofei")
        End Sub

    End Class

End Namespace
