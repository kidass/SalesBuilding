Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_shouhui
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �����������ļ���ǿ���ջ�����
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowShouhui����
    '----------------------------------------------------------------

    Public Class flow_shouhui
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblJSRXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents lblZZTS As System.Web.UI.WebControls.Label
        Protected WithEvents grdJSRXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents chkSHTZ As System.Web.UI.WebControls.CheckBox
        Protected WithEvents btnShouhui As System.Web.UI.WebControls.Button
        Protected WithEvents btnRefresh As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtJSRXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftJSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopJSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden

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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowShouhui
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowShouhui
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_JSRXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_JSRXX As String '��¼m_objDataSet_JSRXX������
        Private m_intRows_JSRXX As Integer '��¼m_objDataSet_JSRXX��DefaultView��¼��

        '----------------------------------------------------------------
        '����������grdJSRXX��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_JSRXX As String = "chkJSRXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_JSRXX As String = "divJSRXX"
        '����Ҫ����������
        Private m_intFixedColumns_JSRXX As Integer

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
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftJSRXX.Value = .htxtDivLeftJSRXX
                    Me.htxtDivTopJSRXX.Value = .htxtDivTopJSRXX

                    Me.htxtJSRXXQuery.Value = .htxtJSRXXQuery
                    Me.htxtJSRXXRows.Value = .htxtJSRXXRows
                    Me.htxtJSRXXSort.Value = .htxtJSRXXSort
                    Me.htxtJSRXXSortColumnIndex.Value = .htxtJSRXXSortColumnIndex
                    Me.htxtJSRXXSortType.Value = .htxtJSRXXSortType

                    Me.chkSHTZ.Checked = .chkSHTZ_Selected

                    Try
                        Me.grdJSRXX.PageSize = .grdJSRXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJSRXX.CurrentPageIndex = .grdJSRXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJSRXX.SelectedIndex = .grdJSRXX_SelectedIndex
                    Catch ex As Exception
                    End Try

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
                If strSessionId = "" Then Exit Try

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowShouhui

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftJSRXX = Me.htxtDivLeftJSRXX.Value
                    .htxtDivTopJSRXX = Me.htxtDivTopJSRXX.Value

                    .htxtJSRXXQuery = Me.htxtJSRXXQuery.Value
                    .htxtJSRXXRows = Me.htxtJSRXXRows.Value
                    .htxtJSRXXSort = Me.htxtJSRXXSort.Value
                    .htxtJSRXXSortColumnIndex = Me.htxtJSRXXSortColumnIndex.Value
                    .htxtJSRXXSortType = Me.htxtJSRXXSortType.Value

                    .chkSHTZ_Selected = Me.chkSHTZ.Checked

                    .grdJSRXX_PageSize = Me.grdJSRXX.PageSize
                    .grdJSRXX_CurrentPageIndex = Me.grdJSRXX.CurrentPageIndex
                    .grdJSRXX_SelectedIndex = Me.grdJSRXX.SelectedIndex

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

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowShouhui)
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

                '��ʼ��������
                If Me.doInitializeWorkflow(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowShouhui)
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
                Me.m_intFixedColumns_JSRXX = objPulicParameters.getObjectValue(Me.htxtJSRXXFixed.Value, 0)
                Me.m_intRows_JSRXX = objPulicParameters.getObjectValue(Me.htxtJSRXXRows.Value, 0)
                Me.m_strQuery_JSRXX = Me.htxtJSRXXQuery.Value

                Me.m_strFlowTypeName = Me.m_objInterface.iFlowTypeName
                Me.m_strWJBS = Me.m_objInterface.iWJBS

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
        ' ��ȡ��������Ϣ���ݼ�
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_JSRXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANSHOUHUI
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_JSRXX = False

            Try
                '�ͷ���Դ
                If Not (Me.m_objDataSet_JSRXX Is Nothing) Then
                    Me.m_objDataSet_JSRXX.Dispose()
                    Me.m_objDataSet_JSRXX = Nothing
                End If

                If m_strQuery_JSRXX = "" Then
                    m_strQuery_JSRXX = ""

                End If

                '�����ݿ��ȡ����
                If Me.m_objsystemFlowObject.getShouhuiDataSet(strErrMsg, MyBase.UserXM, Me.m_strQuery_JSRXX, Me.m_objDataSet_JSRXX) = False Then
                    GoTo errProc
                End If

                '�������
                With Me.m_objDataSet_JSRXX.Tables(strTable)
                    Me.htxtJSRXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_JSRXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_JSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdJSRXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_JSRXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANSHOUHUI

            showDataGridInfo_JSRXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtJSRXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtJSRXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_JSRXX Is Nothing Then
                    Me.grdJSRXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_JSRXX.Tables(strTable)
                        Me.grdJSRXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_JSRXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdJSRXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdJSRXX)
                    With Me.grdJSRXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdJSRXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdJSRXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_JSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdJSRXX���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_JSRXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_JSRXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                Me.lblJSRXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdJSRXX, Me.m_intRows_JSRXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_JSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
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

            showModuleData_Main = False

            Try
                'ֽ���ļ���ת����
                Dim blnHas As Boolean
                If Me.m_objsystemFlowObject.isSendZhizhi(strErrMsg, MyBase.UserXM, blnHas) = False Then
                    GoTo errProc
                End If
                If blnHas = True Then
                    Me.lblZZTS.Text = "[��ʾ]�����ļ������ͳ�ֽ���ļ�����ע���ջأ�"
                End If

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

                    '��ʾMain
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '����ʾgrdJSRXX
                    If Me.showModuleData_JSRXX(strErrMsg) = False Then
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

                '��ȡ��������
                If Me.getModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
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




        '---------------------------------------------------------------------------------------------------------------------------
        '�����¼�������
        '---------------------------------------------------------------------------------------------------------------------------
        Sub grdJSRXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdJSRXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_JSRXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_JSRXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_JSRXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdJSRXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdJSRXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdJSRXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblJSRXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdJSRXX, Me.m_intRows_JSRXX) + ")"

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

        Private Sub grdJSRXX_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdJSRXX.PageIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '�޸�����
                Me.grdJSRXX.CurrentPageIndex = e.NewPageIndex

                '������ʾ
                If Me.getModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_JSRXX(strErrMsg) = False Then
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

        Private Function doRefreshData(ByRef strErrMsg As String) As Boolean

            doRefreshData = False
            strErrMsg = ""

            Try
                If Me.showModuleData_Main(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doRefreshData = True
            Exit Function

errProc:
            Exit Function

        End Function

        Private Sub doRefresh(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doRefreshData(strErrMsg) = False Then
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

        Private Sub doShouhui(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim objHasSendNoticeRY As System.Collections.Specialized.NameValueCollection
            Dim objValues As New System.Collections.Specialized.NameValueCollection
            Dim objDataRow As System.Data.DataRow

            Try
                Dim blnSelected As Boolean
                Dim intSelected As Integer
                Dim intRecPos As Integer
                Dim intCount As Integer
                Dim strValue As String
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '���ѡ��
                    intCount = Me.grdJSRXX.Items.Count
                    intSelected = 0
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdJSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX)
                        If blnSelected = True Then
                            intSelected += 1

                            '************************************************************************************************************************************************
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJSRXX.CurrentPageIndex, Me.grdJSRXX.PageSize)
                            With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANSHOUHUI)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_JSR), "")
                            If Me.m_objsystemFlowObject.isEditFile(strErrMsg, strValue, blnSelected) = False Then
                                GoTo errProc
                            End If
                            If blnSelected = True Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е��ļ�[" + strValue + "]���ڱ༭�ļ��������ջأ�"
                                GoTo errProc
                            End If
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "����δѡ��Ҫ�ջص��ļ���"
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫ�ջ�ѡ����[" + intSelected.ToString + "]���ļ�����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '�ջش���
                Dim strFSXH As String = ""
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ�����εķ������
                    If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                        GoTo errProc
                    End If

                    '����ջ��ļ�
                    intCount = Me.grdJSRXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdJSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX)
                        If blnSelected = True Then
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJSRXX.CurrentPageIndex, Me.grdJSRXX.PageSize)
                            With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANSHOUHUI)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With

                            '׼����������(�˻���)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_WJBS, Me.m_objInterface.iWJBS)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJBS, "")            '�ջ�ʱ�Զ���д
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT, "")            '�ջ�ʱ�Զ���д
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_JSR), "")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSR, strValue)       '���ջ�֪ͨ��
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_FSR), "")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSR, strValue)       '���ջ�֪ͨ��
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_JJXH), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJXH, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_YJJH), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_YJJH, strValue)
                            '************************************************************************************************************************************************
                            strValue = Format(Now, "yyyy-MM-dd HH:mm:ss")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSRQ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_WCRQ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_FSWJZZFS), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSZZWJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSZZWJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_FSWJDZFS), "1")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSDZWJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSDZWJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_FSFJZZFS), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSZZFJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSZZFJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANSHOUHUI_FSFJDZFS), "1")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSDZFJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSDZFJ, strValue)
                            '************************************************************************************************************************************************

                            '�ջص�ǰ�ļ�
                            If Me.m_objsystemFlowObject.doShouhuiFile(strErrMsg, strFSXH, objValues, Me.chkSHTZ.Checked, objHasSendNoticeRY) = False Then
                                GoTo errProc
                            End If

                            '���������
                            objValues.Clear()
                        End If
                    Next

                    'ˢ������
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '�Ƿ�ȫ���˻أ�
                    With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANSHOUHUI)
                        If .Rows.Count < 1 Then
                            '�����ϼ�
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
                        Else
                            '��������
                        End If
                    End With
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objHasSendNoticeRY)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objValues)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objHasSendNoticeRY)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objValues)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Me.doRefresh("btnRefresh")
        End Sub

        Private Sub btnShouhui_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShouhui.Click
            Me.doShouhui("btnShouhui")
        End Sub

    End Class

End Namespace
