Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_editword_save
    ' 
    ' �������ʣ�
    '     ����querystring��������
    '         SessionId
    '         FileName
    ' ���������� 
    '     ��ǿ�Ʊ༭�ļ�ʱ����̨�����ļ������ݵ�������
    ' �ӿڲ�����
    '----------------------------------------------------------------

    Public Class flow_editword_save
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        End Sub

        Protected WithEvents htxtPostFlag As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lnkMLSave As System.Web.UI.WebControls.LinkButton

        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage

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

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowEditWord
        Private m_blnInterface As Boolean

        Private QUERYSTRING_SESSIONID As String = "SessionId"
        Private QUERYSTRING_FILENAME As String = "FileName"

        '----------------------------------------------------------------
        'ģ�����ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

        '----------------------------------------------------------------
        'ģ����������
        '----------------------------------------------------------------
        Private m_strGJFileName As String
        Private m_blnEditMode As Boolean










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
                    objTemp = Session.Item(Request.QueryString(Me.QUERYSTRING_SESSIONID))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowEditWord)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                Me.m_strGJFileName = Request.QueryString(Me.QUERYSTRING_FILENAME)
                If Me.m_strGJFileName Is Nothing Then Me.m_strGJFileName = ""
                Me.m_strGJFileName = Me.m_strGJFileName.Trim

                '�����нӿڲ���
                Me.m_blnInterface = False
                If (m_objInterface Is Nothing) Or (Me.m_strGJFileName = "") Then
                    strErrMsg = "��ģ������ṩ����ӿڲ�����"
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = strErrMsg
                    blnContinue = False
                    Exit Try
                End If
                Me.m_blnInterface = True
                Me.m_blnEditMode = Me.m_objInterface.iEditMode

                '��ʼ��������
                If Me.doInitializeWorkflowData(strErrMsg) = False Then
                    GoTo errProc
                End If
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
        ' ��������ʼ������������
        '----------------------------------------------------------------
        Private Function doInitializeWorkflowData(ByRef strErrMsg As String) As Boolean

            doInitializeWorkflowData = False

            Try
                '��������������
                Dim strFlowTypeName As String = Me.m_objInterface.iFlowTypeName
                Dim strFlowType As String = ""
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                Me.m_objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '��ʼ�����������󲢻�ȡ����������
                If Me.m_objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, True) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doInitializeWorkflowData = True
            Exit Function
errProc:
            Exit Function

        End Function

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
            Dim strUrl As String = ""

            Try
                'Ԥ����
                If MyBase.doPagePreprocess(True, Not Me.IsPostBack) = True Then
                    Exit Sub
                End If

                '��ȡ�ӿڲ���
                Dim blnDo As Boolean = False
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

        Private Sub lnkMLSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSave.Click
            Me.doSave("lnkMLSave")
        End Sub

    End Class

End Namespace
