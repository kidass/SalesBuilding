Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_tuihui
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �����������ļ����˻�����
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowTuihui����
    '----------------------------------------------------------------

    Public Class flow_tuihui
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblFSRXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents lblZZTS As System.Web.UI.WebControls.Label
        Protected WithEvents grdFSRXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnTuihui As System.Web.UI.WebControls.Button
        Protected WithEvents btnRefresh As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtFSRXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFSRXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFSRXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFSRXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFSRXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFSRXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftFSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopFSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowTuihui
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowTuihui
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_FSRXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_FSRXX As String '��¼m_objDataSet_FSRXX������
        Private m_intRows_FSRXX As Integer '��¼m_objDataSet_FSRXX��DefaultView��¼��

        '----------------------------------------------------------------
        '����������grdFSRXX��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_FSRXX As String = "chkFSRXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_FSRXX As String = "divFSRXX"
        '����Ҫ����������
        Private m_intFixedColumns_FSRXX As Integer

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
                    Me.htxtDivLeftFSRXX.Value = .htxtDivLeftFSRXX
                    Me.htxtDivTopFSRXX.Value = .htxtDivTopFSRXX

                    Me.htxtFSRXXQuery.Value = .htxtFSRXXQuery
                    Me.htxtFSRXXRows.Value = .htxtFSRXXRows
                    Me.htxtFSRXXSort.Value = .htxtFSRXXSort
                    Me.htxtFSRXXSortColumnIndex.Value = .htxtFSRXXSortColumnIndex
                    Me.htxtFSRXXSortType.Value = .htxtFSRXXSortType

                    Try
                        Me.grdFSRXX.PageSize = .grdFSRXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFSRXX.CurrentPageIndex = .grdFSRXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFSRXX.SelectedIndex = .grdFSRXX_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowTuihui

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftFSRXX = Me.htxtDivLeftFSRXX.Value
                    .htxtDivTopFSRXX = Me.htxtDivTopFSRXX.Value

                    .htxtFSRXXQuery = Me.htxtFSRXXQuery.Value
                    .htxtFSRXXRows = Me.htxtFSRXXRows.Value
                    .htxtFSRXXSort = Me.htxtFSRXXSort.Value
                    .htxtFSRXXSortColumnIndex = Me.htxtFSRXXSortColumnIndex.Value
                    .htxtFSRXXSortType = Me.htxtFSRXXSortType.Value

                    .grdFSRXX_PageSize = Me.grdFSRXX.PageSize
                    .grdFSRXX_CurrentPageIndex = Me.grdFSRXX.CurrentPageIndex
                    .grdFSRXX_SelectedIndex = Me.grdFSRXX.SelectedIndex

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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowTuihui)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowTuihui)
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
                Me.m_intFixedColumns_FSRXX = objPulicParameters.getObjectValue(Me.htxtFSRXXFixed.Value, 0)
                Me.m_intRows_FSRXX = objPulicParameters.getObjectValue(Me.htxtFSRXXRows.Value, 0)
                Me.m_strQuery_FSRXX = Me.htxtFSRXXQuery.Value

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
        Private Function getModuleData_FSRXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANTUIHUI
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_FSRXX = False

            Try
                '�ͷ���Դ
                If Not (Me.m_objDataSet_FSRXX Is Nothing) Then
                    Me.m_objDataSet_FSRXX.Dispose()
                    Me.m_objDataSet_FSRXX = Nothing
                End If

                '�����ݿ��ȡ����
                If Me.m_objsystemFlowObject.getTuihuiDataSet(strErrMsg, MyBase.UserXM, Me.m_strQuery_FSRXX, Me.m_objDataSet_FSRXX) = False Then
                    GoTo errProc
                End If

                '�������
                With Me.m_objDataSet_FSRXX.Tables(strTable)
                    Me.htxtFSRXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_FSRXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_FSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdFSRXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_FSRXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANTUIHUI

            showDataGridInfo_FSRXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtFSRXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtFSRXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_FSRXX Is Nothing Then
                    Me.grdFSRXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_FSRXX.Tables(strTable)
                        Me.grdFSRXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_FSRXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdFSRXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdFSRXX)
                    With Me.grdFSRXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdFSRXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdFSRXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_FSRXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_FSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdFSRXX���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_FSRXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_FSRXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_FSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                Me.lblFSRXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdFSRXX, Me.m_intRows_FSRXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_FSRXX = True
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
                If Me.m_objsystemFlowObject.isReceiveZhizhi(strErrMsg, MyBase.UserXM, blnHas) = False Then
                    GoTo errProc
                End If
                If blnHas = True Then
                    Me.lblZZTS.Text = "[��ʾ]�����ļ���ֽ���ļ���������ע���˻أ�"
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

                    '����ʾgrdFSRXX
                    If Me.showModuleData_FSRXX(strErrMsg) = False Then
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
                If Me.getModuleData_FSRXX(strErrMsg) = False Then
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
        Sub grdFSRXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdFSRXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_FSRXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_FSRXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_FSRXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdFSRXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdFSRXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFSRXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblFSRXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdFSRXX, Me.m_intRows_FSRXX) + ")"

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

        Private Sub grdFSRXX_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdFSRXX.PageIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '�޸�����
                Me.grdFSRXX.CurrentPageIndex = e.NewPageIndex

                '������ʾ
                If Me.getModuleData_FSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_FSRXX(strErrMsg) = False Then
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
                '��ʾ����
                If Me.showModuleData_Main(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_FSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_FSRXX(strErrMsg) = False Then
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

        Private Sub doTuihui(ByVal strControlId As String)

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
                    intCount = Me.grdFSRXX.Items.Count
                    intSelected = 0
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdFSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FSRXX)
                        If blnSelected = True Then
                            intSelected += 1

                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdFSRXX.CurrentPageIndex, Me.grdFSRXX.PageSize)
                            With Me.m_objDataSet_FSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANTUIHUI)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With

                            '��ȡ�����ӱ�ʶ��
                            'strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_JJBS), "")
                            'If Me.m_objsystemFlowObject.isTaskTuihui(strValue) = True Then
                            '    '�˻ص�
                            '    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]��Ϊ�˻��ļ�������ֱ���˻أ�"
                            '    GoTo errProc
                            'End If
                            'If Me.m_objsystemFlowObject.isTaskShouhui(strValue) = True Then
                            '    '�ջص�
                            '    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]��Ϊ�ջ��ļ�������ֱ���˻أ�"
                            '    GoTo errProc
                            'End If
                            'If Me.m_objsystemFlowObject.isTaskHuifu(strValue) = True Then
                            '    '�ظ�
                            '    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]��Ϊ�ظ�������ֱ���˻أ�"
                            '    GoTo errProc
                            'End If
                            If Me.m_objsystemFlowObject.isTaskTongzhi(strValue) = True Then
                                '֪ͨ
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]��Ϊ֪ͨ������ֱ���˻أ�"
                                GoTo errProc
                            End If
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "����δѡ��Ҫ�˻ص��ļ���"
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫ�˻�ѡ����[" + intSelected.ToString + "]���ļ�����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '�˻ش���
                Dim strYBLSY As String = ""
                Dim strFSXH As String = ""
                Dim strYXB As String = ""
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ�����εķ������
                    If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                        GoTo errProc
                    End If

                    '����˻��ļ�
                    intCount = Me.grdFSRXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdFSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FSRXX)
                        If blnSelected = True Then
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdFSRXX.CurrentPageIndex, Me.grdFSRXX.PageSize)
                            With Me.m_objDataSet_FSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANTUIHUI)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With

                            '׼����������(�˻���)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_WJBS, Me.m_objInterface.iWJBS)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJBS, "")            '�˻�ʱ�Զ���д
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT, "")            '�˻�ʱ�Զ���д
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSR, MyBase.UserXM)  '���˻ش�����
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSR), "")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSR, strValue)       '���˻ش�����
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_JJXH), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJXH, strValue)
                            '************************************************************************************************************************************************
                            strValue = Format(Now, "yyyy-MM-dd HH:mm:ss")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSRQ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_WCRQ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSWJZZFS), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSZZWJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSZZWJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSWJDZFS), "1")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSDZWJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSDZWJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSFJZZFS), "0")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSZZFJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSZZFJ, strValue)
                            '************************************************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSFJDZFS), "1")
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSDZFJ, strValue)
                            objValues.Add(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSDZFJ, strValue)
                            '************************************************************************************************************************************************

                            '��ȡ�������Լ��İ�������
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSRBLSY), "")
                            If Me.m_objsystemFlowObject.doTranslateTask(strErrMsg, strValue, strYBLSY) = False Then
                                GoTo errProc
                            End If
                            strYXB = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANTUIHUI_FSRXB), "")

                            '�˻ص�ǰ�ļ�
                            If Me.m_objsystemFlowObject.doTuihuiFile(strErrMsg, strYBLSY, strYXB, strFSXH, objValues, Me.m_objInterface.iCanReadFile, objHasSendNoticeRY) = False Then
                                GoTo errProc
                            End If

                            '���������
                            objValues.Clear()
                        End If
                    Next

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

        Private Sub btnTuihui_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTuihui.Click
            Me.doTuihui("btnTuihui")
        End Sub

    End Class

End Namespace
