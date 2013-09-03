Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_editword
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   ��������Ϣ����
    '     �½�ʱ��������ɺ��Զ���������ӿڵ�iWJBS��iEditMode���ȴ��û���������
    '         ���ȡ������ֱ�ӷ����ϼ���
    '     �༭ʱ�����۱����ȡ�����ȴ��û���������
    ' �ӿڲ�����
    '     �μ��ӿ���IMFlowEditWord����
    '----------------------------------------------------------------

    Public Class flow_editword
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
		Protected WithEvents popMessageObject As Josco.Web.PopMessage

        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
		Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden

        Protected WithEvents htxtWatchInterval As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWatchSwitch As System.Web.UI.HtmlControls.HtmlInputHidden

        Protected WithEvents htxtUserName As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtProtectPassword As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtEditMode As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFileSpec As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtAutoSave As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCanQSYJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCanImportFile As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCanExportFile As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCanSelectTGWJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtTrackRevisions As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWJBS As System.Web.UI.HtmlControls.HtmlInputHidden
		Protected WithEvents htxtFlowTypeName As System.Web.UI.HtmlControls.HtmlInputHidden
		Protected WithEvents htxtCursorPos As System.Web.UI.HtmlControls.HtmlInputHidden
		Protected WithEvents htxtISession As System.Web.UI.HtmlControls.HtmlInputHidden

		Protected WithEvents lnkMLSaveAndClose As System.Web.UI.WebControls.LinkButton
		Protected WithEvents lnkMLClose As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLSave As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLXgfj As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLXgwj As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLXzgj As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLDrwj As System.Web.UI.WebControls.LinkButton

        '2009-02-20
        Protected WithEvents htxtLocked As System.Web.UI.HtmlControls.HtmlInputHidden
        '2009-02-20

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
        Private m_cstrRelativePathToImage As String = "../../"            '��ģ�����image�����·��
        Private m_cstrUrlBaseToFileCache As String = "/temp/filecache/"   '��ģ���Ӧ�ļ�������·��

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowEditWord
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowEditWord
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ�����ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

        '----------------------------------------------------------------
        'ģ����������
        '----------------------------------------------------------------
        Private m_strGJFileName As String      '�ļ����ƣ�ȫUrl��ַ
        Private m_blnEditMode As Boolean       '�༭ģʽ










        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtEditMode.Value = .htxtEditMode
                    '2009-02-20
                    Me.htxtLocked.Value = .htxtLocked
                    '2009-02-20
                    Me.htxtFileSpec.Value = .htxtFileSpec
                    Me.htxtAutoSave.Value = .htxtAutoSave
                    Me.htxtCanQSYJ.Value = .htxtCanQSYJ
                    Me.htxtCanImportFile.Value = .htxtCanImportFile
                    Me.htxtCanExportFile.Value = .htxtCanExportFile
                    Me.htxtCanSelectTGWJ.Value = .htxtCanSelectTGWJ
                    Me.htxtCursorPos.Value = .htxtCursorPos
                    Me.htxtProtectPassword.Value = .htxtProtectPassword
                    Me.htxtUserName.Value = .htxtUserName
                    Me.htxtTrackRevisions.Value = .htxtTrackRevisions
                End With

                '�ͷ���Դ
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Sub

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
                If strSessionId = "" Then Exit Try

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowEditWord

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtEditMode = Me.htxtEditMode.Value
                    '2009-02-20
                    .htxtLocked = Me.htxtLocked.Value
                    '2009-02-20
                    .htxtFileSpec = Me.htxtFileSpec.Value
                    .htxtAutoSave = Me.htxtAutoSave.Value
                    .htxtCanQSYJ = Me.htxtCanQSYJ.Value
                    .htxtCanImportFile = Me.htxtCanImportFile.Value
                    .htxtCanExportFile = Me.htxtCanExportFile.Value
                    .htxtCanSelectTGWJ = Me.htxtCanSelectTGWJ.Value
                    .htxtCursorPos = Me.htxtCursorPos.Value
                    .htxtProtectPassword = Me.htxtProtectPassword.Value
                    .htxtUserName = Me.htxtUserName.Value
                    .htxtTrackRevisions = Me.htxtTrackRevisions.Value
                End With

                '�������
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            saveModuleInformation = strSessionId
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ӵ���ģ���л�ȡ����
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Try
                If Me.IsPostBack = True Then Exit Try

                '=================================================================
                Dim objIFlowXgwj As Josco.JSOA.BusinessFacade.IFlowXgwj
                Try
                    objIFlowXgwj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowXgwj)
                Catch ex As Exception
                    objIFlowXgwj = Nothing
                End Try
                If Not (objIFlowXgwj Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowXgwj.Dispose()
                    objIFlowXgwj = Nothing
                    Exit Try
                End If

                '=================================================================
                Dim objIFlowFujian As Josco.JSOA.BusinessFacade.IFlowFujian
                Try
                    objIFlowFujian = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowFujian)
                Catch ex As Exception
                    objIFlowFujian = Nothing
                End Try
                If Not (objIFlowFujian Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowFujian.Dispose()
                    objIFlowFujian = Nothing
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
        ' �ͷŽӿڲ���(ģ���޷�������ʱ��)
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
                If Not (Me.m_objInterface Is Nothing) Then
                    If Me.m_objInterface.iInterfaceType = Josco.JSOA.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
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
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowEditWord)
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
                Me.htxtISession.Value = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)

                '��ʼ��������
                If Me.doInitializeWorkflowData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowEditWord)
                    Catch ex As Exception
                        Me.m_objSaveScence = Nothing
                    End Try
                    If Me.m_objSaveScence Is Nothing Then
                        Me.m_blnSaveScence = False
                    Else
                        Me.m_blnSaveScence = True
                    End If

                    If Me.m_blnSaveScence = False Then
                        '�ӽӿڻ�ȡ����
                        Me.htxtFileSpec.Value = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + Me.m_objInterface.iGJFileSpec
                        Me.htxtProtectPassword.Value = Josco.JsKernal.Common.Utilities.PulicParameters.FileProtectPassword
                        Me.htxtUserName.Value = MyBase.UserXM

                        If Me.m_objInterface.iEditMode = True Then
                            Me.htxtEditMode.Value = "1"
                        Else
                            Me.htxtEditMode.Value = "0"
                        End If

                        '�ۼ�����
                        If Me.m_objInterface.iTrackRevisions = True And Me.m_objInterface.iHasSendOnce = True Then
                            Me.htxtTrackRevisions.Value = "1"
                        Else
                            Me.htxtTrackRevisions.Value = "0"
                        End If

                        '�Զ����棿
                        If Me.m_objInterface.iAutoSave = True Then
                            Me.htxtAutoSave.Value = "1"
                        Else
                            Me.htxtAutoSave.Value = "0"
                        End If

                        '��ʾ�����
                        If Me.m_objInterface.iCanQSYJ = True Then
                            Me.htxtCanQSYJ.Value = "1"
                        Else
                            Me.htxtCanQSYJ.Value = "0"
                        End If

                        '�����ļ���
                        If Me.m_objInterface.iCanImportGJ = True Then
                            Me.htxtCanImportFile.Value = "1"
                        Else
                            Me.htxtCanImportFile.Value = "0"
                        End If

                        '�����ļ���
                        If Me.m_objInterface.iCanExportGJ = True Then
                            Me.htxtCanExportFile.Value = "1"
                        Else
                            Me.htxtCanExportFile.Value = "0"
                        End If

                        'ѡ��Ͷ���ļ���
                        If Me.m_objInterface.iCanSelectTGWJ = True Then
                            Me.htxtCanSelectTGWJ.Value = "1"
                        Else
                            Me.htxtCanSelectTGWJ.Value = "0"
                        End If
                    Else
                        '�ָ��ֳ��������ͷŸ���Դ
                        Me.restoreModuleInformation(strSessionId)
                    End If

                    '�������ģ�鷵�غ����Ϣ��ͬʱ�ͷ���Ӧ��Դ
                    If Me.getDataFromCallModule(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

                '����ģ����������
                If Me.htxtEditMode.Value = "1" Then
                    Me.m_blnEditMode = True
                Else
                    Me.m_blnEditMode = False
                End If
                Me.m_strGJFileName = objPulicParameters.getObjectValue(Me.htxtFileSpec.Value, "")
                Me.htxtFlowTypeName.Value = Me.m_objInterface.iFlowTypeName
                Me.htxtWJBS.Value = Me.m_objInterface.iWJBS
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
        ' �ͷű�ģ�黺��Ĳ���(ģ�鷵��ʱ��)
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ��������ʼ������������
        '----------------------------------------------------------------
        Private Function doInitializeWorkflowData(ByRef strErrMsg As String) As Boolean

            doInitializeWorkflowData = False
            Dim blnlocked As Boolean = False

            Try
                '��������������
                Dim strFlowTypeName As String = Me.m_objInterface.iFlowTypeName
                Dim strFlowType As String
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                Me.m_objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '��ʼ�����������󲢻�ȡ����������
                If Me.m_objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, True) = False Then
                    GoTo errProc
                End If

                '2009-02-20
                Dim strBMMC As String = ""
                Dim strRYMC As String = ""
                If Me.m_objsystemFlowObject.getFileLocked(strErrMsg, blnlocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If

                '�Ƿ������ڱ༭��
                If blnlocked = True Then
                    Me.htxtLocked.Value = "[" + strBMMC + "]��λ��[" + strRYMC + "]��Ա���ڱ༭���ļ���"
                Else
                    Me.htxtLocked.Value = ""
                End If
                '2009-02-20
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doInitializeWorkflowData = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʼ���ؼ�
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            initializeControls = False

            Try
              

                '���ڵ�һ�ε���ҳ��ʱִ��
                If Me.IsPostBack = False Then
                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '�����ļ��Ѿ��Ķ�
                    If Me.m_blnSaveScence = False Then
                        If Me.m_objsystemFlowObject.doSetHasReadFile(strErrMsg, MyBase.UserXM) = False Then
                            GoTo errProc
                        End If
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            initializeControls = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strUrl As String

            Try
                'Ԥ����
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                '��ȡ�ӿڲ���
                Dim blnDo As Boolean
                If Me.getInterfaceParameters(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = False Then
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
                            If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]��[���ļ�]��") = False Then
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

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(Me.m_objsystemFlowObject)
        End Sub








        '----------------------------------------------------------------
        ' ɾ�������ļ�
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doDeleteCacheFile(ByRef strErrMsg As String) As Boolean

            doDeleteCacheFile = False

            Try
                'ɾ�������ļ�
                If Me.doDeleteCacheFile_GJ(strErrMsg) = False Then
                    '���Բ��ɹ������������ļ�
                End If
                If Me.m_objsystemFlowObject.doDeleteCacheFile_FJ(strErrMsg, Me.m_objInterface.iobjDataSet_FJ) = False Then
                    '���Բ��ɹ������������ļ�
                End If
                If Me.m_objsystemFlowObject.doDeleteCacheFile_XGWJ(strErrMsg, Me.m_objInterface.iobjDataSet_XGWJ) = False Then
                    '���Բ��ɹ������������ļ�
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doDeleteCacheFile = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ɾ���������ļ�
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doDeleteCacheFile_GJ(ByRef strErrMsg As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doDeleteCacheFile_GJ = False

            Try
                If Me.m_strGJFileName <> "" Then
                    'ɾ����ʱ�����ļ�
                    Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                    Dim strGJFileSpec As String = ""
                    strGJFileSpec = objBaseLocalFile.getFileName(Me.m_strGJFileName)
                    strGJFileSpec = objBaseLocalFile.doMakePath(strGJPath, strGJFileSpec)
                    If objBaseLocalFile.doDeleteFile(strErrMsg, strGJFileSpec) = False Then
                        '���Բ��ɹ���������������
                    End If
                End If

                'ǿ�����»�ȡ�ļ���
                Me.htxtFileSpec.Value = ""
                Me.m_strGJFileName = ""

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doDeleteCacheFile_GJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '�Զ�����ģʽ������ļ�����
                If Me.m_objInterface.iEditMode = True Then
                    If Me.m_objInterface.iAutoSave = True Then
                        '����Լ��ı༭����
                        If Me.m_objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                            GoTo errProc
                        End If
                        '�����ʱ�ļ�
                        If Me.doDeleteCacheFile(strErrMsg) = False Then
                            '����ɾ�����ɹ����γ������ļ���
                        End If
                    End If
                End If

                '���÷��ز���
                Me.m_objInterface.oExitMode = False
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

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        '=================================================================================
        '���ļ�¼
        'zengxianglin 2008-07-04 �Զ�����ʱ�����ļ������˳��ļ��༭
        '=================================================================================
        Private Sub doSave(ByVal strControlId As String)

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '�Ƿ��Զ�����?
                If Me.m_objInterface.iEditMode = True Then      '�༭ģʽ
                    If Me.m_objInterface.iAutoSave = True Then     '�Զ�����
                        'ת��Url��Web����·����
                        Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                        Dim strGJFileSpec As String = ""
                        strGJFileSpec = objBaseLocalFile.getFileName(Me.m_strGJFileName)
                        strGJFileSpec = objBaseLocalFile.doMakePath(strGJPath, strGJFileSpec)

                        '��Ҫ�Զ�����
                        'ͬʱ������������������ļ���ǩ�����������
                        If Me.m_objsystemFlowObject.doSaveFileZDBCVariantParam(strErrMsg, _
                            MyBase.UserId, MyBase.UserPassword, _
                            strGJFileSpec, _
                            Me.m_objInterface.iobjDataSet_FJ, _
                            Me.m_objInterface.iobjDataSet_XGWJ, _
                            MyBase.UserXM, _
                            Me.m_objInterface.iEnforeEdit, _
                            Nothing) = False Then
                            GoTo errProc
                        End If

                        '2009-03-18 zengxianglin
                        '���������༭
                        If Me.m_objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, True) = False Then
                            GoTo errProc
                        End If
                        '2009-03-18 zengxianglin
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpenFJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objIFlowFujian As Josco.JSOA.BusinessFacade.IFlowFujian = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim blnHasSendOnce As Boolean = False
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '�ļ����͹���
                blnHasSendOnce = Me.m_objInterface.iHasSendOnce

                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String = ""
                objIFlowFujian = New Josco.JSOA.BusinessFacade.IFlowFujian
                With objIFlowFujian
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iFlowTypeName = Me.m_objInterface.iFlowTypeName
                    .iDataSet_FJ = Me.m_objInterface.iobjDataSet_FJ
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iEditMode = Me.m_objInterface.iEditMode
                    .iWJBS = Me.m_objInterface.iWJBS
                    .iAutoSave = False

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
                    strUrl += strSessionId
                    .iReturnUrl = strUrl
                End With
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowFujian)

                strUrl = ""
                strUrl += "flow_fujian.aspx"
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

        Private Sub doOpenXGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objIFlowXgwj As Josco.JSOA.BusinessFacade.IFlowXgwj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim blnHasSendOnce As Boolean = False
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '�ļ����͹���
                blnHasSendOnce = Me.m_objInterface.iHasSendOnce

                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String = ""
                objIFlowXgwj = New Josco.JSOA.BusinessFacade.IFlowXgwj
                With objIFlowXgwj
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iDataSet_XGWJ = Me.m_objInterface.iobjDataSet_XGWJ
                    .iFlowTypeName = Me.m_objInterface.iFlowTypeName
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iEditMode = Me.m_objInterface.iEditMode
                    .iWJBS = Me.m_objInterface.iWJBS
                    .iAutoSave = False

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
                    strUrl += strSessionId
                    .iReturnUrl = strUrl
                End With
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowXgwj)

                strUrl = ""
                strUrl += "flow_xgwj.aspx"
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

        '=================================================================================
        '���ļ�¼
        'zengxianglin 2008-07-04 ���ӱ�����
        '=================================================================================
        Private Sub doSaveAndClose(ByVal strControlId As String)

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim blnExitMode As Boolean = True
            Dim strErrMsg As String = ""

            Try
                '�Ƿ��Զ�����?
                If Me.m_objInterface.iEditMode = True Then      '�༭ģʽ
                    If Me.m_objInterface.iAutoSave = True Then     '�Զ�����
                        'ת��Url��Web����·����
                        Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                        Dim strGJFileSpec As String = ""
                        strGJFileSpec = objBaseLocalFile.getFileName(Me.m_strGJFileName)
                        strGJFileSpec = objBaseLocalFile.doMakePath(strGJPath, strGJFileSpec)

                        '��Ҫ�Զ�����
                        'ͬʱ������������������ļ���ǩ�����������
                        If Me.m_objsystemFlowObject.doSaveFileZDBCVariantParam(strErrMsg, _
                         MyBase.UserId, MyBase.UserPassword, _
                         strGJFileSpec, _
                         Me.m_objInterface.iobjDataSet_FJ, _
                         Me.m_objInterface.iobjDataSet_XGWJ, _
                         MyBase.UserXM, _
                         Me.m_objInterface.iEnforeEdit, _
                         Nothing) = False Then
                            GoTo errProc
                        End If

                        '�����ʱ�ļ�
                        If Me.doDeleteCacheFile(strErrMsg) = False Then
                            '����ɾ�����ɹ����γ������ļ���
                        End If

                        '��ֹ��������
                        blnExitMode = False
                    End If
                End If

                '���÷��ز���
                Me.m_objInterface.oExitMode = blnExitMode
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

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub lnkMLClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub

        Private Sub lnkMLSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSave.Click
            Me.doSave("lnkMLSave")
        End Sub

        Private Sub lnkMLSaveAndClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSaveAndClose.Click
            Me.doSaveAndClose("lnkMLSaveAndClose")
        End Sub

        Private Sub lnkMLXgfj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLXgfj.Click
            Me.doOpenFJ("lnkMLXgfj")
        End Sub

        Private Sub lnkMLXgwj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLXgwj.Click
            Me.doOpenXGWJ("lnkMLXgwj")
        End Sub

    End Class

End Namespace
