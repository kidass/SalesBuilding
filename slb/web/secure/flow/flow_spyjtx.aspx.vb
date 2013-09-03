Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_spyjtx
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �����������ļ���ǩ������򲹵��쵼�������
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowBycl����
    '----------------------------------------------------------------

    Public Class flow_spyjtx
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
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

        'ע��: ����ռλ�������� Web ���������������ġ�
        '��Ҫɾ�����ƶ�����
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: �˷��������� Web ����������������
            '��Ҫʹ�ô���༭���޸�����
            InitializeComponent()
        End Sub

#End Region

        '----------------------------------------------------------------
        'ģ��˽�ò���
        '----------------------------------------------------------------
        '��ģ�����image�����·��
        Private m_cstrRelativePathToImage As String = "../../"

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowSpyjtx
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowSpyjtx
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

        '----------------------------------------------------------------
        'ģ����������
        '----------------------------------------------------------------
        '��������������
        Private m_strFlowTypeName As String
        '�ļ���ʶ
        Private m_strWJBS As String








        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
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

                '�ͷ���Դ
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

        End Sub

        '----------------------------------------------------------------
        ' ����ģ���ֳ���Ϣ��������Ӧ��SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strSessionId As String = ""
            Dim strErrMsg As String

            saveModuleInformation = ""

            Try
                '����SessionId
                strSessionId = objPulicParameters.getNewGuid()
                If strSessionId = "" Then
                    Exit Try
                End If

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowSpyjtx

                '�����ֳ���Ϣ
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

                '�������
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' �ӵ���ģ���л�ȡ����
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
                    '�ͷ���Դ
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
                    '�ͷ���Դ
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowSend.Dispose()
                    objIFlowSend = Nothing
                    If blnReturn = True Then
                        '���÷��ز���
                        Me.m_objInterface.oExitMode = True
                        '���ص�����ģ�飬�����ӷ��ز���
                        'Ҫ���ص�SessionId
                        Dim strSessionId As String
                        strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        'SessionId���ӵ����ص�Url
                        Dim strUrl As String
                        strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                        '�ͷ�ģ����Դ
                        Me.releaseModuleParameters()
                        Me.releaseInterfaceParameters()
                        '����
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
                    '�ͷ���Դ
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
        ' �ͷŽӿڲ���(ģ���޷�������ʱ��)
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
                If Not (Me.m_objInterface Is Nothing) Then
                    If Me.m_objInterface.iInterfaceType = Josco.JSOA.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                        '�ͷ�Session
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                        '�ͷŶ���
                        Me.m_objInterface.Dispose()
                        Me.m_objInterface = Nothing
                    End If
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ��ȡ�ӿڲ���(û�нӿڲ�������ʾ������Ϣҳ��)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String, ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowSpyjtx)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try

                '�����нӿڲ���
                Me.m_blnInterface = False
                If m_objInterface Is Nothing Then
                    '��ʾ������Ϣ
                    strErrMsg = "��ģ������ṩ����ӿڲ�����"
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

                '��ʼ��������
                If Me.doInitializeWorkflow(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʼ�����쵼�б�
                If Me.m_objInterface.iDLR <> "" Then
                    '����ģʽ
                    If Me.IsPostBack = False Then
                        '�״ν���
                        Dim strList As String
                        If Me.m_objsystemFlowObject.getKeBudengLingdao(strErrMsg, Me.m_objInterface.iDLR, strList) = False Then
                            '���ܻ�ȡ����
                        Else
                            '����б�
                            If objDropDownListProcess.doFillData(strErrMsg, Me.ddlLDMC, strList) = False Then
                                '������
                            End If
                        End If
                    End If
                End If

                '��ʼ�����������ˡ�
                If Me.IsPostBack = False Then
                    Dim objYjlx As System.Collections.Specialized.NameValueCollection
                    If Me.m_objsystemFlowObject.getAllYjlx(strErrMsg, objYjlx) = False Then
                        strErrMsg = "�����޷���ȡ�������ͣ�"
                        GoTo errProc
                    End If
                    If objRadioButtonListProcess.doFillData(strErrMsg, Me.rblYJLX, objYjlx) = False Then
                        strErrMsg = "�����޷���ʼ���������ͣ�"
                        GoTo errProc
                    End If
                    Me.rblYJLX.RepeatColumns = Me.rblYJLX.Items.Count
                End If

                '��ȡ�ָ��ֳ�����
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

                    '�ָ��ֳ��������ͷŸ���Դ
                    Me.restoreModuleInformation(strSessionId)

                    '�������ģ�鷵�غ����Ϣ��ͬʱ�ͷ���Ӧ��Դ
                    If Me.getDataFromCallModule(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

                '����ģ����������
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
        ' �ͷű�ģ�黺��Ĳ���(ģ�鷵��ʱ��)
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ��ʼ������������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doInitializeWorkflow(ByRef strErrMsg As String) As Boolean

            doInitializeWorkflow = False
            strErrMsg = ""

            Try
                '���ó�ʼ��
                If Not (Me.m_objsystemFlowObject Is Nothing) Then
                    Exit Try
                End If

                '��������������
                Dim strFlowTypeName As String = Me.m_objInterface.iFlowTypeName
                Dim strFlowType As String
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                Me.m_objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '��ʼ�����������������
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
        ' ��ʾ�����쵼�����������Ϣ(�Լ�ǩ����)
        '     strErrMsg      �����ش�����Ϣ
        '     objJioajieData ����ǰ��������
        '     objBanliData   ���������ݼ�
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
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

                '��ʼ��
                With objJioajieData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE).DefaultView
                    If .Count < 1 Then
                        'û������
                        strErrMsg = "������û��δ��ɵ��������ˣ�"
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

                '��д�������
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

                '��ʾ�������
                Dim intIndex As Integer
                intIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYJLX, strBLZL)
                If intIndex < 0 Then
                Else
                    If Me.rblYJLX.SelectedIndex >= 0 Then
                        If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                            If intIndex <> Me.rblYJLX.SelectedIndex Then
                                Me.htxtLastYJLX.Value = Me.rblYJLX.Items(intIndex).Text
                                objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ��[" + Me.txtSPR.Text + "]�Ѿ���[" + Me.rblYJLX.Items(intIndex).Text + "]��ǩ��������ϵͳ�Զ�ת��[" + Me.rblYJLX.SelectedItem.Text + "]����")
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
        ' ��ʾ�����쵼�����������Ϣ(���ǵ�)
        '     strErrMsg      �����ش�����Ϣ
        '     objJioajieData ����ǰ��������
        '     objBanliData   ���������ݼ�
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
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

                '��ʼ��
                With objJioajieData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE).DefaultView
                    If .Count < 1 Then
                        'û������
                        strErrMsg = "����û���������ˣ�"
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

                '��д�������
                Dim strBLZL As String = ""
                Dim strDLR As String = ""
                With objBanliData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_BANLI).DefaultView
                    If .Count < 1 Then
                        Me.btnOK.Enabled = True
                        Exit Try
                    End If

                    strDLR = objPulicParameters.getObjectValue(.Item(0).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_BANLI_DLR), "")
                    If strDLR = "" Then
                        strErrMsg = "����[" + Me.txtSPR.Text + "]�Ѿ��Լ�ǩ������������ܲ��ǣ�"
                        GoTo errProc
                    End If
                    If strDLR <> Me.m_objInterface.iDLR Then
                        strErrMsg = "����[" + Me.txtSPR.Text + "]ǩ�������Ѿ���[" + strDLR + "]���ǣ��������ٲ��ǣ�"
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

                '��ʾ�������
                Dim intIndex As Integer
                intIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYJLX, strBLZL)
                If intIndex < 0 Then
                Else
                    If Me.rblYJLX.SelectedIndex >= 0 Then
                        If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                            If intIndex <> Me.rblYJLX.SelectedIndex Then
                                Me.htxtLastYJLX.Value = Me.rblYJLX.Items(intIndex).Text
                                objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ��[" + Me.txtSPR.Text + "]�Ѿ���[" + Me.rblYJLX.Items(intIndex).Text + "]��ǩ��������ϵͳ�Զ�ת��[" + Me.rblYJLX.SelectedItem.Text + "]����")
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
        ' ��ʾ�����쵼�����������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strSPR         ��ָ��������
        '     strYjlx        ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
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
                '��ʼ�������
                Me.htxtJJXH.Value = ""
                Me.htxtYJLX.Value = ""

                '���ദ��
                If Me.m_objInterface.iDLR <> "" Then
                    If strSPR Is Nothing Then strSPR = ""
                    strSPR = strSPR.Trim
                    If strYjlx Is Nothing Then strYjlx = ""
                    strYjlx = strYjlx.Trim

                    '�������
                    Me.ddlLDMC.Enabled = True    '��ѡ�쵼
                    Me.txtLDPSSJ.Enabled = True  '������
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

                    '��ȡ���1�ε���������
                    If Me.m_objsystemFlowObject.getLastSpsyJiaojieData(strErrMsg, strSPR, False, objJioajieData) = False Then
                        GoTo errProc
                    End If
                    With objJioajieData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                        If .Rows.Count < 1 Then
                            'û������
                            strErrMsg = "����[" + strSPR + "]û���������ˣ�"
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

                    '��ʾ��Ϣ
                    If Me.showModuleData_SPXX_Daili(strErrMsg, objJioajieData, objBanliData) = False Then
                        GoTo errProc
                    End If
                Else
                    '�Լ�ǩ��
                    Me.ddlLDMC.Enabled = False   '����ѡ�쵼
                    Me.txtLDPSSJ.Enabled = False '��������
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

                    '��ȡ���1�ε���������
                    If Me.m_objsystemFlowObject.getLastSpsyJiaojieData(strErrMsg, Me.m_objInterface.iSPR, True, objJioajieData) = False Then
                        GoTo errProc
                    End If
                    With objJioajieData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                        If .Rows.Count < 1 Then
                            'û������
                            strErrMsg = "������û��δ��ɵ��������ˣ�"
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

                    '��ʾ��Ϣ
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
        ' ��ʾ����ģ����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_Main(ByRef strErrMsg As String) As Boolean

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim strYjlx As String
            Dim strSPR As String

            showModuleData_Main = False

            Try
                Me.lblPrompt.Text = Me.m_objInterface.iPromptInfo

                '�������������ȡ��Ϣ
                If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                    '�״ν���
                    If Me.m_objInterface.iDLR <> "" Then
                        '����
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
                        '��ǩ
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
                    '�ط�����÷���
                    If Me.m_objInterface.iDLR <> "" Then
                        '����
                        If Me.ddlLDMC.Items.Count < 1 Then
                            strSPR = ""
                        Else
                            If Me.ddlLDMC.SelectedIndex < 0 Then
                                Me.ddlLDMC.SelectedIndex = 0
                            End If
                            strSPR = Me.ddlLDMC.Items(Me.ddlLDMC.SelectedIndex).Value
                        End If
                    Else
                        '��ǩ
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
        ' ��ʼ���ؼ�
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            Try
                '���ڵ�һ�ε���ҳ��ʱִ��
                If Me.IsPostBack = False Then
                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '��ʾ������Ϣ
                    Me.lblPrompt.Text = Me.m_objInterface.iPromptInfo

                    '��ʾMain
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
                'Ԥ����
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                '��ȡ�ӿڲ���
                Dim blnContinue As Boolean
                If Me.getInterfaceParameters(strErrMsg, blnContinue) = False Then
                    GoTo errProc
                End If
                If blnContinue = False Then
                    Exit Try
                End If

                '�ؼ���ʼ��
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
                '������ʾ
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
                '���ü��
                If Me.rblYJLX.SelectedIndex < 0 Then
                    Exit Try
                End If

                '���
                Dim strSelectedText As String = ""
                Dim intCount As Integer
                Dim i As Integer
                If Me.rblYJLX.SelectedIndex < Me.m_objInterface.iYjlxEnabled.Length Then
                    If Me.m_objInterface.iYjlxEnabled(Me.rblYJLX.SelectedIndex) = False Then
                        '����ѡ��
                        strSelectedText = Me.rblYJLX.SelectedItem.Text

                        '���ÿ��ܵ�ȱʡ���
                        intCount = Me.m_objInterface.iYjlxEnabled.Length
                        For i = intCount - 1 To 0 Step -1
                            If Me.m_objInterface.iYjlxEnabled(i) = True Then
                                Me.rblYJLX.SelectedIndex = i
                                Exit For
                            End If
                        Next

                        '��ʾ����
                        strErrMsg = "����������ǩ��[" + strSelectedText + "]�����"
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
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
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

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
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
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
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

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
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
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
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

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
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
                        strErrMsg = "����û��ѡ���쵼��"
                        GoTo errProc
                    End If
                End If

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
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

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
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
                        strErrMsg = "����û��ѡ���쵼��"
                        GoTo errProc
                    End If
                End If

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
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

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
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
                '���÷��ز���
                Me.m_objInterface.oExitMode = False

                '���ص�����ģ�飬�����ӷ��ز���
                'Ҫ���ص�SessionId
                Dim strSessionId As String
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                'SessionId���ӵ����ص�Url
                Dim strUrl As String
                strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)

                '�ͷ�ģ����Դ
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()

                '����
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
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
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

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
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
                '��ȡ��������
                Dim strXyrList As String
                Dim blnNeed As Boolean
                Dim blnYesNo As Boolean
                Dim strYjlxmc As String
                Dim strYjlx As String
                Dim strSPR As String
                If Me.rblYJLX.SelectedIndex < 0 Then
                    strErrMsg = "����δָ���������ͣ�"
                    GoTo errProc
                End If
                strYjlxmc = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Text
                strYjlx = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Value
                strSPR = Me.txtSPR.Text
                If Me.htxtJJXH.Value.Trim = "" Then
                    strErrMsg = "����û���������ˣ�"
                    GoTo errProc
                End If

                '�ܷ�ǩ�����
                'If Me.rblYJLX.SelectedIndex < Me.m_objInterface.iYjlxEnabled.Length Then
                '    If Me.m_objInterface.iYjlxEnabled(Me.rblYJLX.SelectedIndex) = False Then
                '        strErrMsg = "����������ǩ��[" + strYjlxmc + "]�����"
                '        GoTo errProc
                '    End If
                'Else
                '    strErrMsg = "���󣺴���Ĳ�������"
                '    GoTo errProc
                'End If

                '����������
                If Me.textareaZSYJ.Value.Trim = "" Then
                    Me.textareaZSYJ.Value = Me.m_objsystemFlowObject.getDefaultYJNR(Me.rblYJLX.SelectedValue)
                End If
                If Me.textareaZSYJ.Value.Trim = "" Then
                    strErrMsg = "����û�������κ������"
                    GoTo errProc
                End If

                'ǩ����ʾ
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��Ҫǩ��ѯ��?
                    If Me.m_objsystemFlowObject.isNeedQianminQuerenPrompt(strErrMsg, strYjlx, strSPR, blnNeed, strXyrList) = False Then
                        GoTo errProc
                    End If
                    Me.htxtValueB.Value = "0"
                    If blnNeed = True Then
                        If Me.m_objsystemFlowObject.isFileQianminTask(strYjlx, strPrompt) = True Then
                            '�������ļ������ǩ����
                            If strXyrList <> "" Then
                                strPrompt = "��ʾ��" + strXyrList + "  �Ѿ�ǩ���� ��Ҫ����ǩ����"
                            End If
                        Else
                            strPrompt = "��ʾ����ȷ���ļ�[" + strYjlxmc + "]ͨ����ȷ��/ȡ������[ͨ��]�밴[ȷ��]�������밴[ȡ��]��"
                            If strXyrList <> "" Then
                                strPrompt = "��ʾ��[" + strXyrList + "]�Ѿ�ǩ���� ��Ҫ����ǩ���� "
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

                '��������ǩ������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    blnYesNo = objMessageProcess.getConfirmBoxValue(Request, Me.popMessageObject.UniqueID)
                    If blnYesNo = True Then
                        'ǩ�����
                        Me.htxtValueA.Value = "1"

                        '��ͬǩ��������ǩ����
                        If Me.m_objsystemFlowObject.isNeedQianminQuerenPrompt(strErrMsg, strYjlx, strSPR, blnNeed, strXyrList) = False Then
                            GoTo errProc
                        End If
                        If blnNeed = True Then
                            If strXyrList <> "" Then
                                Dim strTX As String = ""
                                objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ��[" + strXyrList + "]�Ѿ�ǩ��        " + vbCr + vbCr + "����Ҫ" + vbCr + vbCr + "[����ǩ��--------��ȷ��]" + vbCr + vbCr + "[��ͬǩ��--------��ȡ��]��", strControlId, intStep, True)
                                Exit Try
                            End If
                        End If
                    Else
                        If Me.htxtValueB.Value.Trim = "1" Then
                            'ǩ�����
                            Me.htxtValueA.Value = "1"
                        Else
                            '��ͨ���
                            Me.htxtValueA.Value = "0"
                        End If
                    End If
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                Dim intMode As Integer
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ����ģʽ
                    If Me.htxtValueA.Value = "0" Then
                        '��ͨ
                        intMode = 2
                    Else
                        blnYesNo = objMessageProcess.getConfirmBoxValue(Request, Me.popMessageObject.UniqueID)
                        If blnYesNo = True Then
                            '����
                            intMode = 0
                        Else
                            '��ͬ
                            intMode = 1
                        End If
                    End If

                    '׼����������
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

                    'ȡ��ǩ��(����)
                    If Me.m_objsystemFlowObject.doQianminCancel(strErrMsg, Me.htxtYJLX.Value, Me.txtSPR.Text) = False Then
                        GoTo errProc
                    End If


                    '�������
                    Dim intJJXH As Integer = CType(Me.htxtJJXH.Value, Integer)
                    If Me.m_objsystemFlowObject.doSaveSpyj(strErrMsg, intJJXH, objNewData) = False Then
                        GoTo errProc
                    End If

                    '����ǩ��(��ǩ��)
                    If Me.m_objsystemFlowObject.doQianminQueren(strErrMsg, strYjlx, Me.txtSPR.Text, intMode) = False Then
                        GoTo errProc
                    End If

                    'дЭ���־
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

                    '��¼���������־
                    If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "ǩ�����ļ�[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]��[�������]��") = False Then
                        '����
                    End If

                    '������Լ�ǩ�������˳�
                    If Me.m_objInterface.iDLR <> "" Then
                        '�����˵������Ƿ���ꣿ
                        If Me.m_objsystemFlowObject.isAllTaskComplete(strErrMsg, Me.txtSPR.Text, blnYesNo) = False Then
                            GoTo errProc
                        End If
                        If blnYesNo = False Then
                            '���������ó����ڰ�����������ڣ�ֻ��û�н������ڣ�����û�н���
                            strWhere = "������='" + Me.txtSPR.Text.Trim + "' and �������� is null"
                            If Me.m_objsystemFlowObject.getJiaojieData(strErrMsg, strWhere, False, objJiaojieData) = False Then
                                GoTo errProc
                            End If
                            Dim intCount As Integer
                            With objJiaojieData.Tables(strTable)
                                intCount = .DefaultView.Count
                                If intCount > 0 Then
                                    strWhere = ""
                                    strFileds = ""
                                    strWhere = "where �ļ���ʶ='" + Me.m_objInterface.iWJBS + "' and ������='" + Me.txtSPR.Text.Trim + "' and �������� is null"
                                    strFileds = "set ����״̬='���ڰ���',��������=��������"
                                    If Me.m_objsystemFlowObject.doUpdateJiaojie(strErrMsg, strWhere, strFileds) = False Then
                                        GoTo errProc
                                    End If
                                End If
                            End With

                            '�ͳ��ļ�
                            If Me.doSendFile(strErrMsg, strControlId, Me.txtSPR.Text, Me.m_objInterface.iDLR) = False Then
                                GoTo errProc
                            End If
                        Else
                            'ֱ�ӷ���
                            If Me.showModuleData_Main(strErrMsg) = False Then
                                GoTo errProc
                            End If
                        End If
                    Else
                        '���÷��ز���
                        Me.m_objInterface.oExitMode = True
                        '���ص�����ģ�飬�����ӷ��ز���
                        'Ҫ���ص�SessionId
                        Dim strSessionId As String
                        strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        'SessionId���ӵ����ص�Url
                        Dim strUrl As String
                        strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                        '�ͷ�ģ����Դ
                        Me.releaseModuleParameters()
                        Me.releaseInterfaceParameters()
                        '����
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
                '��ȡ��������
                Dim strXyrList As String
                Dim blnNeed As Boolean
                Dim blnYesNo As Boolean
                Dim strYjlxmc As String
                Dim strYjlx As String
                Dim strSPR As String
                If Me.rblYJLX.SelectedIndex < 0 Then
                    strErrMsg = "����δָ���������ͣ�"
                    GoTo errProc
                End If
                strYjlxmc = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Text
                strYjlx = Me.rblYJLX.Items(Me.rblYJLX.SelectedIndex).Value
                strSPR = Me.txtSPR.Text
                If Me.htxtJJXH.Value.Trim = "" Then
                    strErrMsg = "����û���������ˣ�"
                    GoTo errProc
                End If

                '��ʾ
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ�����ϵ�ǰ�����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '����
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    'ȡ��ǩ��
                    If Me.m_objsystemFlowObject.doQianminCancel(strErrMsg, Me.htxtYJLX.Value, Me.txtSPR.Text) = False Then
                        GoTo errProc
                    End If

                    'ȡ��������¼
                    Dim intJJXH As Integer
                    intJJXH = CType(Me.htxtJJXH.Value, Integer)
                    If Me.m_objsystemFlowObject.doBanliCancel(strErrMsg, intJJXH) = False Then
                        GoTo errProc
                    End If

                    '���÷��ز���
                    Me.m_objInterface.oExitMode = True
                    '���ص�����ģ�飬�����ӷ��ز���
                    'Ҫ���ص�SessionId
                    Dim strSessionId As String
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    'SessionId���ӵ����ص�Url
                    Dim strUrl As String
                    strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                    '�ͷ�ģ����Դ
                    Me.releaseModuleParameters()
                    Me.releaseInterfaceParameters()
                    '����
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
