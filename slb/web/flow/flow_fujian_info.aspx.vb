Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_fujian_info
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ����������ģ��
    '
    ' ���������� 
    '   �������ļ�������Ϣ�Ĳ鿴��༭����
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowFujianInfo����
    '----------------------------------------------------------------

    Public Class flow_fujian_info
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtWJXH As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWJWZ As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWJSM As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWJYS As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWEBURL As System.Web.UI.WebControls.TextBox
        Protected WithEvents hifKHDWJ As System.Web.UI.HtmlControls.HtmlInputFile
        Protected WithEvents htxtWEBLOC As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWJBS As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWJXH As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFlowTypeName As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden

        Protected WithEvents htxtProtectPassword As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtTrackRevisions As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCanExportFile As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtUserName As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtEditMode As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtEditType As System.Web.UI.HtmlControls.HtmlInputHidden

        Protected WithEvents htxtFileSpec As System.Web.UI.HtmlControls.HtmlInputHidden

        Protected WithEvents lnkMLClose As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLSave As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLXzwj As System.Web.UI.WebControls.LinkButton

        Protected WithEvents htxtWatchInterval As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWatchSwitch As System.Web.UI.HtmlControls.HtmlInputHidden

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
        '�ļ����غ�Ļ���·��
        Private m_cstrUrlBaseToFileCache As String = "/temp/filecache/"

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowFujianInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowFujianInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

        '----------------------------------------------------------------
        'ģ����������
        '----------------------------------------------------------------
        Private m_objEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType   '�༭����
        Private m_strFlowTypeName As String                                                 '��������������
        Private m_blnEditMode As Boolean                                                    '�༭ģʽ
        Private m_strWJBS As String                                                         '�ļ���ʶ









        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.txtWJXH.Text = .txtWJXH
                    Me.txtWJSM.Text = .txtWJSM
                    Me.txtWJYS.Text = .txtWJYS
                    Me.txtWJWZ.Text = .txtWJWZ
                    Me.txtWEBURL.Text = .txtWEBURL

                    Me.htxtWEBLOC.Value = .htxtWEBLOC

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
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

            Dim strSessionId As String = ""
            Dim strErrMsg As String

            saveModuleInformation = ""

            Try
                '����SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then Exit Try

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowFujianInfo

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .txtWJXH = Me.txtWJXH.Text
                    .txtWJSM = Me.txtWJSM.Text
                    .txtWJYS = Me.txtWJYS.Text
                    .txtWJWZ = Me.txtWJWZ.Text
                    .txtWEBURL = Me.txtWEBURL.Text

                    .htxtWEBLOC = Me.htxtWEBLOC.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                End With

                '�������
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' �ӵ���ģ���л�ȡ����
        '----------------------------------------------------------------
        Private Function getDataFromCallModule( _
            ByRef strErrMsg As String) As Boolean

            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            Try
                If Me.IsPostBack = True Then Exit Try

                '=================================================================

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
        ' ��ȡ�ӿڲ���(û�нӿڲ�������ʾ������Ϣҳ��)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String, ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowFujianInfo)
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

                '��������ʼ��
                If Me.doInitializeWorkflow(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    '��ȡ�ֳ��ָ�����
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowFujianInfo)
                    Catch ex As Exception
                        Me.m_objSaveScence = Nothing
                    End Try
                    '����Ƿ���ֳ��ָ�����
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
                Me.m_objEditType = Me.m_objInterface.iEditType
                Select Case Me.m_objEditType
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Me.m_blnEditMode = True
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        Me.m_blnEditMode = True
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_blnEditMode = True
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eDelete
                        Me.m_blnEditMode = False
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                        Me.m_blnEditMode = False
                End Select
                Me.m_strFlowTypeName = Me.m_objInterface.iFlowTypeName
                Me.m_strWJBS = Me.m_objInterface.iWJBS
                Me.htxtFlowTypeName.Value = Me.m_objInterface.iFlowTypeName
                Me.htxtWJBS.Value = Me.m_objInterface.iWJBS
                Me.htxtWJXH.Value = Me.m_objInterface.iWJXH

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
        ' ��������ļ�
        '----------------------------------------------------------------
        Private Sub doDeleteTempFiles()

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim strErrMsg As String

            Try
                '���β����γɵĻ����ļ�
                Dim strOldFile As String = Me.m_objInterface.iBDWJ.Trim.ToUpper
                Dim strNewFile As String = Me.htxtWEBLOC.Value.Trim.ToUpper
                If strNewFile <> "" Then
                    If strNewFile <> strOldFile Then
                        If objBaseLocalFile.doDeleteFile(strErrMsg, Me.htxtWEBLOC.Value) = False Then
                            '�γ������ļ�
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

        End Sub

        '----------------------------------------------------------------
        ' �ͷű�ģ�黺��Ĳ���(ģ�鷵��ʱ��)
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ��ȡ��ǰ��ʾ�ļ�����չ��
        '----------------------------------------------------------------
        Private Function getDisplayFileExtension() As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            getDisplayFileExtension = ""

            Try
                '�����ļ�������ʾOffice�ؼ�
                Dim strFile As String = ""
                If Me.htxtWEBLOC.Value.Trim <> "" Then
                    strFile = Me.htxtWEBLOC.Value.Trim
                End If
                If strFile = "" Then
                    If Me.txtWJWZ.Text.Trim <> "" Then
                        strFile = Me.txtWJWZ.Text.Trim
                    End If
                End If

                '��ȡ�ļ�����
                Dim strFileExt As String = ""
                If strFile <> "" Then
                    strFileExt = objBaseLocalFile.getExtension(strFile)
                    strFileExt = strFileExt.ToUpper
                End If

                getDisplayFileExtension = strFileExt

            Catch ex As Exception
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ����ģ����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_Main = False

            Try
                '��ʾ����
                Me.txtWJXH.Text = Me.m_objInterface.iWJXH
                Me.txtWJSM.Text = Me.m_objInterface.iWJSM
                Me.txtWJYS.Text = Me.m_objInterface.iWJYS
                Me.txtWJWZ.Text = Me.m_objInterface.iWJWZ

                '��ȡ��ʱ�ļ���WEB����·��
                Me.htxtWEBLOC.Value = Me.m_objInterface.iBDWJ

                '��ȡ��ʱ�ļ���WEB����·��
                Dim strFile As String = ""
                If Me.m_objInterface.iBDWJ <> "" Then
                    strFile = Me.m_objInterface.iBDWJ
                    strFile = objBaseLocalFile.getFileName(strFile)
                    strFile = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strFile
                End If
                Me.txtWEBURL.Text = strFile

                Select Case Me.m_objInterface.iEditType
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                         JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        objControlProcess.doEnabledControl(Me.txtWJXH, False)
                        objControlProcess.doEnabledControl(Me.txtWJWZ, False)
                        objControlProcess.doEnabledControl(Me.txtWJSM, True)
                        objControlProcess.doEnabledControl(Me.txtWJYS, True)
                        objControlProcess.doEnabledControl(Me.hifKHDWJ, True)
                        objControlProcess.doEnabledControl(Me.txtWEBURL, False)
                    Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        objControlProcess.doEnabledControl(Me.txtWJXH, False)
                        objControlProcess.doEnabledControl(Me.txtWJWZ, False)
                        objControlProcess.doEnabledControl(Me.txtWJSM, True)
                        objControlProcess.doEnabledControl(Me.txtWJYS, True)
                        objControlProcess.doEnabledControl(Me.hifKHDWJ, True)
                        objControlProcess.doEnabledControl(Me.txtWEBURL, False)
                    Case Else
                        objControlProcess.doEnabledControl(Me.txtWJXH, False)
                        objControlProcess.doEnabledControl(Me.txtWJWZ, False)
                        objControlProcess.doEnabledControl(Me.txtWJSM, False)
                        objControlProcess.doEnabledControl(Me.txtWJYS, False)
                        objControlProcess.doEnabledControl(Me.hifKHDWJ, False)
                        objControlProcess.doEnabledControl(Me.txtWEBURL, False)
                End Select

                '��ȡҪ��ʾ�ļ�
                Dim strFileExt As String = Me.getDisplayFileExtension()
                Select Case strFileExt.ToUpper
                    Case ".DOC", ".XLS"
                        If Me.getDisplayFile(strErrMsg, True, strFile) = False Then
                            GoTo errProc
                        End If
                    Case Else
                        If Me.getDisplayFile(strErrMsg, False, strFile) = False Then
                            GoTo errProc
                        End If
                End Select
                If Me.doSetOfficeParameters(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_Main = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
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

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    With objControlProcess
                        .doTranslateKey(Me.txtWJXH)
                        .doTranslateKey(Me.txtWJWZ)
                        .doTranslateKey(Me.txtWEBURL)
                        .doTranslateKey(Me.txtWJSM)
                        .doTranslateKey(Me.txtWJYS)
                        .doTranslateKey(Me.hifKHDWJ)
                    End With

                    If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
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

                '��¼���������־
                If Me.IsPostBack = False Then
                    If Me.m_blnSaveScence = False Then
                        If Me.m_objsystemFlowObject.FlowData.WJBS <> "" Then
                            If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]�ĵ�[" + Me.m_objInterface.iWJXH + "]���������ݣ�") = False Then
                                '����
                            End If
                        End If
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

        Private Sub Page_Unload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(Me.m_objsystemFlowObject)

        End Sub



        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '����Լ��ı༭����
                Select Case Me.m_objInterface.iEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        If Me.m_objInterface.iAutoSave = True Then
                            If Me.m_objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                                GoTo errProc
                            End If
                        End If
                End Select

                '�����ʱ�ļ�
                doDeleteTempFiles()

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

        '----------------------------------------------------------------
        ' �ӿؼ��л�ȡ��ǰ������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     objNewData     �����������ݵ��ַ�������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getNewData( _
            ByRef strErrMsg As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            getNewData = False
            objNewData = Nothing
            strErrMsg = ""

            Try
                '��������
                objNewData = New System.Collections.Specialized.NameValueCollection

                '��ȡ����
                objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJXH, Me.txtWJXH.Text)
                objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM, Me.txtWJSM.Text)
                objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS, Me.txtWJYS.Text)
                objNewData.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ, Me.htxtWEBLOC.Value)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getNewData = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Exit Function
        End Function

        '----------------------------------------------------------------
        ' ��������ֵ���õ��ؼ�
        '     strErrMsg      �����ش�����Ϣ
        '     objNewData     �������ݵ��ַ�������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function setNewData( _
            ByRef strErrMsg As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            setNewData = False
            strErrMsg = ""

            Try
                '���
                If objNewData Is Nothing Then
                    Exit Try
                End If

                '��������
                With objPulicParameters
                    Me.txtWJXH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJXH), "")
                    Me.txtWJSM.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM), "")
                    Me.txtWJYS.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            setNewData = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function
        End Function

        '----------------------------------------------------------------
        ' ������ļ��ϴ����򻺴���WEB���������ص��ļ�����Ŀ¼��
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doUploadFile(ByRef strErrMsg As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doUploadFile = False

            Try
                '������ļ��ϴ����򻺴���WEB���������ص��ļ�����Ŀ¼��
                Dim strFilePath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                Dim strFileSpec As String = ""
                Dim strFileName As String = ""
                Dim strOldFile As String = ""
                If Not (Me.hifKHDWJ.PostedFile Is Nothing) Then
                    If Me.hifKHDWJ.PostedFile.FileName <> "" Then
                        '��ȡ���ļ�·��
                        If objBaseLocalFile.doCreateTempFile(strErrMsg, Me.hifKHDWJ.PostedFile.FileName, True, strFileName) = False Then
                            GoTo errProc
                        End If
                        If strFileName = "" Then
                            strErrMsg = "�����޷���ȡ��ʱ�ļ���"
                            GoTo errProc
                        End If
                        strFileSpec = objBaseLocalFile.doMakePath(strFilePath, strFileName)
                        'ɾ������Ļ�����γɵ���ʱ�ļ�
                        Me.doDeleteTempFiles()
                        '���������ļ�
                        Me.hifKHDWJ.PostedFile.SaveAs(strFileSpec)
                        '����WEB�����ļ�·��
                        Me.htxtWEBLOC.Value = strFileSpec
                        '����WEB�����ļ�·��
                        Me.txtWEBURL.Text = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strFileName
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doUploadFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        Private Sub doSave(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objNewData As System.Collections.Specialized.NameValueCollection

            Try
                '׼��У�������
                If Me.getNewData(strErrMsg, objNewData) = False Then
                    GoTo errProc
                End If
                'У��Ҫ���������
                If Me.m_objsystemFlowObject.doVerifyFujian(strErrMsg, objNewData) = False Then
                    GoTo errProc
                End If
                'У����������������
                If Me.setNewData(strErrMsg, objNewData) = False Then
                    GoTo errProc
                End If

                '������ļ��ϴ����򻺴���WEB���������ص��ļ�����Ŀ¼��
                If Me.doUploadFile(strErrMsg) = False Then
                    GoTo errProc
                End If

                '�Ƿ���Ҫ�Զ����棿
                '�Զ�����ֻ�ᷢ����Updateģʽ��
                Dim blnReturnSet As Boolean = True
                Select Case Me.m_objInterface.iEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        If Me.m_objInterface.iAutoSave = True Then
                            '��Ҫ���浱ǰ���������ݿ�
                            If Me.m_objsystemFlowObject.doSaveFujian(strErrMsg, Me.m_objInterface.iEnforeEdit, MyBase.UserXM, objNewData) = False Then
                                GoTo errProc
                            End If
                            '��¼���������־
                            If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]�ĵ�[" + Me.txtWJXH.Text + "]��������") = False Then
                                '����
                            End If
                            'ɾ�������ļ�
                            If Me.htxtWEBLOC.Value.Trim <> "" Then
                                If objBaseLocalFile.doDeleteFile(strErrMsg, Me.htxtWEBLOC.Value) = False Then
                                    '�γ������ļ�
                                End If
                                Me.htxtWEBLOC.Value = ""
                            End If
                            '���÷��ز���
                            blnReturnSet = False
                            Me.m_objInterface.oExitMode = False
                        End If
                    Case Else
                End Select
                If blnReturnSet = True Then
                    '���÷��ز���
                    Me.m_objInterface.oExitMode = True
                    Me.m_objInterface.oWJXH = Me.txtWJXH.Text.Trim
                    Me.m_objInterface.oWJSM = Me.txtWJSM.Text.Trim
                    Me.m_objInterface.oWJYS = Me.txtWJYS.Text.Trim
                    Me.m_objInterface.oBDWJ = Me.htxtWEBLOC.Value.Trim
                    Me.m_objInterface.oWJWZ = Me.m_objInterface.iWJWZ
                End If

                '���ص�����ģ�飬�����ӷ��ز���
                'Ҫ���ص�SessionId
                Dim strSessionId As String = ""
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                'SessionId���ӵ����ص�Url
                Dim strUrl As String = ""
                strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                '�ͷ�ģ����Դ
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()
                '����
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' ��ȡ��ǰҪ��ʾ���ļ���
        '     strErrMsg      �����ش�����Ϣ
        '     blnDownload    ��=trueû�л����ļ�������
        '     strFileName    ������Ҫ��ʾ���ļ���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getDisplayFile( _
            ByRef strErrMsg As String, _
            ByVal blnDownload As Boolean, _
            ByRef strFileName As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon

            getDisplayFile = False
            strFileName = ""

            Try
                '��ȡ��Ϣ
                Dim strFTPPath As String
                Dim strDesSpec As String
                Dim strDesPath As String
                Dim strDesFile As String
                Dim strUrl As String
                strFTPPath = Me.txtWJWZ.Text.Trim
                strDesSpec = Me.htxtWEBLOC.Value.Trim

                '�����ļ�
                If strDesSpec <> "" Then
                    '���ֱ���б����ļ�����ֱ�ӽ�WEB�����ļ����ص��ͻ���
                    strDesFile = objBaseLocalFile.getFileName(strDesSpec)
                Else
                    '��FTP����������
                    If blnDownload = True Then
                        strDesPath = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache
                        strDesPath = Server.MapPath(strDesPath)
                        If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, strFTPPath, strDesSpec, strDesPath, strDesFile) = False Then
                            GoTo errProc
                        End If
                        strDesSpec = objBaseLocalFile.doMakePath(strDesPath, strDesFile)
                    Else
                        'LJ 2008-07-24
                        If strFTPPath <> "" Then
                            strDesPath = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache
                            strDesPath = Server.MapPath(strDesPath)
                            If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, strFTPPath, strDesSpec, strDesPath, strDesFile) = False Then
                                GoTo errProc
                            End If
                            strDesSpec = objBaseLocalFile.doMakePath(strDesPath, strDesFile)
                        Else
                            strDesFile = ""
                            strDesSpec = ""
                        End If
                    End If
                End If

                '��¼�����ļ�
                If strDesFile <> "" Then
                    strUrl = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strDesFile
                    Me.htxtWEBLOC.Value = strDesSpec
                    Me.txtWEBURL.Text = strUrl
                End If

                '����
                strFileName = strDesFile

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)

            getDisplayFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������ʾ�ļ�����Office�ؼ��Ĳ���
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doSetOfficeParameters(ByRef strErrMsg As String) As Boolean

            doSetOfficeParameters = False
            strErrMsg = ""

            Try
                '��ȡ��ʱ�ļ�����
                Dim strFileExt As String = Me.getDisplayFileExtension()
                Dim strDesFile As String = ""

                '�����������ò���
                Select Case strFileExt
                    Case ".DOC", ".XLS"
                        '��ȡҪ��ʾ���ļ�
                        If Me.getDisplayFile(strErrMsg, False, strDesFile) = False Then
                            GoTo errProc
                        End If
                        If strDesFile <> "" Then
                            Me.htxtProtectPassword.Value = Josco.JsKernal.Common.Utilities.PulicParameters.FileProtectPassword
                            Me.htxtFileSpec.Value = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + strDesFile
                            Me.htxtUserName.Value = MyBase.UserXM
                            If Me.m_objInterface.iTrackRevisions = True Then
                                Me.htxtTrackRevisions.Value = "1"
                            Else
                                Me.htxtTrackRevisions.Value = "0"
                            End If
                            Me.htxtCanExportFile.Value = "1"
                            If Me.m_blnEditMode = True Then
                                Me.htxtEditMode.Value = "1"
                            Else
                                Me.htxtEditMode.Value = "0"
                            End If
                            Select Case Me.m_objEditType
                                Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                    Me.htxtEditType.Value = "1"
                                Case Else
                                    Me.htxtEditType.Value = "0"
                            End Select
                        Else
                            Me.htxtProtectPassword.Value = ""
                            Me.htxtFileSpec.Value = ""
                            Me.htxtUserName.Value = ""
                            Me.htxtTrackRevisions.Value = "0"
                            Me.htxtCanExportFile.Value = "0"
                            If Me.m_blnEditMode = True Then
                                Me.htxtEditMode.Value = "1"
                            Else
                                Me.htxtEditMode.Value = "0"
                            End If
                            Select Case Me.m_objEditType
                                Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                    Me.htxtEditType.Value = "1"
                                Case Else
                                    Me.htxtEditType.Value = "0"
                            End Select
                        End If

                    Case Else
                        Me.htxtProtectPassword.Value = ""
                        Me.htxtFileSpec.Value = ""
                        Me.htxtUserName.Value = ""
                        Me.htxtTrackRevisions.Value = "0"
                        Me.htxtCanExportFile.Value = "0"
                        If Me.m_blnEditMode = True Then
                            Me.htxtEditMode.Value = "1"
                        Else
                            Me.htxtEditMode.Value = "0"
                        End If
                        Select Case Me.m_objEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                   Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                                   Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                Me.htxtEditType.Value = "1"
                            Case Else
                                Me.htxtEditType.Value = "0"
                        End Select
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doSetOfficeParameters = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Sub doDownloadFile(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon

            Try
                '��ʼ��������
                Dim strName As String = Me.m_objInterface.iFlowTypeName
                Dim strType As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strName)
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, False) = False Then
                    GoTo errProc
                End If

                '������ļ����أ�
                If Me.doUploadFile(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ȡ��ʾ�ļ�
                Dim strDesFile As String = ""
                If Me.getDisplayFile(strErrMsg, True, strDesFile) = False Then
                    GoTo errProc
                End If

                '�����ļ�������ʾ
                If Me.doSetOfficeParameters(strErrMsg) = False Then
                    GoTo errProc
                End If
                Dim strFileExt As String = Me.getDisplayFileExtension()
                Dim strUrl As String = ""
                Select Case strFileExt
                    Case ".DOC", ".XLS"
                    Case Else
                        '��¼���������־
                        If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + objsystemFlowObject.FlowData.WJBS + "]�ĵ�[" + Me.txtWJXH.Text + "]��������") = False Then
                            '����
                        End If

                        strUrl = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strDesFile
                        objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub lnkMLXzwj_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLXzwj.Click
            Me.doDownloadFile("lnkMLXzwj")
        End Sub

        Private Sub lnkMLClose_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub

        Private Sub lnkMLSave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSave.Click
            Me.doSave("lnkMLSave")
        End Sub

    End Class

End Namespace
