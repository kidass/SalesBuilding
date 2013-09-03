Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_duban
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �����������ļ��Ķ�������
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowDuban����
    '----------------------------------------------------------------

    Public Class flow_duban
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblKDBXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdKDBXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblYDBXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdYDBXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnOK As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtKDBXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSessionIdKDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKDBXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKDBXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKDBXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKDBXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKDBXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYDBXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftKDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopKDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftYDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopYDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowDuban
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowDuban
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_KDBXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_KDBXX As String '��¼m_objDataSet_KDBXX������
        Private m_intRows_KDBXX As Integer '��¼m_objDataSet_KDBXX��DefaultView��¼��
        Private m_objDataSet_YDBXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_YDBXX As String '��¼m_objDataSet_YDBXX������
        Private m_intRows_YDBXX As Integer '��¼m_objDataSet_YDBXX��DefaultView��¼��

        '----------------------------------------------------------------
        '����������grdKDBXX��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrControlId_KDBXX_txtDBRQ As String = "txtDBRQ"
        Private Const m_cstrControlId_KDBXX_txtDBYQ As String = "txtDBYQ"
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_KDBXX As String = "chkKDBXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_KDBXX As String = "divKDBXX"
        '����Ҫ����������
        Private m_intFixedColumns_KDBXX As Integer

        '----------------------------------------------------------------
        '����������grdYDBXX��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_YDBXX As String = "chkYDBXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_YDBXX As String = "divYDBXX"
        '����Ҫ����������
        Private m_intFixedColumns_YDBXX As Integer

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
                    Me.htxtDivLeftKDBXX.Value = .htxtDivLeftKDBXX
                    Me.htxtDivTopKDBXX.Value = .htxtDivTopKDBXX
                    Me.htxtDivLeftYDBXX.Value = .htxtDivLeftYDBXX
                    Me.htxtDivTopYDBXX.Value = .htxtDivTopYDBXX

                    Me.htxtKDBXXQuery.Value = .htxtKDBXXQuery
                    Me.htxtKDBXXRows.Value = .htxtKDBXXRows
                    Me.htxtKDBXXSort.Value = .htxtKDBXXSort
                    Me.htxtKDBXXSortColumnIndex.Value = .htxtKDBXXSortColumnIndex
                    Me.htxtKDBXXSortType.Value = .htxtKDBXXSortType

                    Me.htxtYDBXXQuery.Value = .htxtYDBXXQuery
                    Me.htxtYDBXXRows.Value = .htxtYDBXXRows
                    Me.htxtYDBXXSort.Value = .htxtYDBXXSort
                    Me.htxtYDBXXSortColumnIndex.Value = .htxtYDBXXSortColumnIndex
                    Me.htxtYDBXXSortType.Value = .htxtYDBXXSortType

                    Me.htxtSessionIdKDBXX.Value = .htxtSessionIdKDBXX
                    Try
                        Me.grdKDBXX.PageSize = .grdKDBXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdKDBXX.CurrentPageIndex = .grdKDBXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdKDBXX.SelectedIndex = .grdKDBXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdYDBXX.PageSize = .grdYDBXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYDBXX.CurrentPageIndex = .grdYDBXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYDBXX.SelectedIndex = .grdYDBXX_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowDuban

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftKDBXX = Me.htxtDivLeftKDBXX.Value
                    .htxtDivTopKDBXX = Me.htxtDivTopKDBXX.Value
                    .htxtDivLeftYDBXX = Me.htxtDivLeftYDBXX.Value
                    .htxtDivTopYDBXX = Me.htxtDivTopYDBXX.Value

                    .htxtKDBXXQuery = Me.htxtKDBXXQuery.Value
                    .htxtKDBXXRows = Me.htxtKDBXXRows.Value
                    .htxtKDBXXSort = Me.htxtKDBXXSort.Value
                    .htxtKDBXXSortColumnIndex = Me.htxtKDBXXSortColumnIndex.Value
                    .htxtKDBXXSortType = Me.htxtKDBXXSortType.Value

                    .htxtYDBXXQuery = Me.htxtYDBXXQuery.Value
                    .htxtYDBXXRows = Me.htxtYDBXXRows.Value
                    .htxtYDBXXSort = Me.htxtYDBXXSort.Value
                    .htxtYDBXXSortColumnIndex = Me.htxtYDBXXSortColumnIndex.Value
                    .htxtYDBXXSortType = Me.htxtYDBXXSortType.Value

                    .htxtSessionIdKDBXX = Me.htxtSessionIdKDBXX.Value
                    .grdKDBXX_PageSize = Me.grdKDBXX.PageSize
                    .grdKDBXX_CurrentPageIndex = Me.grdKDBXX.CurrentPageIndex
                    .grdKDBXX_SelectedIndex = Me.grdKDBXX.SelectedIndex

                    .grdYDBXX_PageSize = Me.grdYDBXX.PageSize
                    .grdYDBXX_CurrentPageIndex = Me.grdYDBXX.CurrentPageIndex
                    .grdYDBXX_SelectedIndex = Me.grdYDBXX.SelectedIndex

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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowDuban)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowDuban)
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
                Me.m_intFixedColumns_KDBXX = objPulicParameters.getObjectValue(Me.htxtKDBXXFixed.Value, 0)
                Me.m_intRows_KDBXX = objPulicParameters.getObjectValue(Me.htxtKDBXXRows.Value, 0)
                Me.m_strQuery_KDBXX = Me.htxtKDBXXQuery.Value

                Me.m_intFixedColumns_YDBXX = objPulicParameters.getObjectValue(Me.htxtYDBXXFixed.Value, 0)
                Me.m_intRows_YDBXX = objPulicParameters.getObjectValue(Me.htxtYDBXXRows.Value, 0)
                Me.m_strQuery_YDBXX = Me.htxtYDBXXQuery.Value

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
                If Me.htxtSessionIdKDBXX.Value.Trim <> "" Then
                    Dim objFlowData As Josco.JSOA.Common.Data.FlowData
                    Try
                        objFlowData = CType(Session(Me.htxtSessionIdKDBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        objFlowData = Nothing
                    End Try
                    If Not (objFlowData Is Nothing) Then
                        objFlowData.Dispose()
                        objFlowData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdKDBXX.Value)
                    Me.htxtSessionIdKDBXX.Value = ""
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
        ' ��ȡ�ɶ�����Ϣ���ݼ�
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_KDBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_KDBXX = False

            Try
                '�ӻ����ȡ����
                If Me.htxtSessionIdKDBXX.Value.Trim <> "" Then
                    Try
                        Me.m_objDataSet_KDBXX = CType(Session(Me.htxtSessionIdKDBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        Me.m_objDataSet_KDBXX = Nothing
                    End Try
                End If

                '����ȱʡ����
                If Me.m_objDataSet_KDBXX Is Nothing Then
                    If Me.m_objsystemFlowObject.getKeDubanData(strErrMsg, Me.m_objInterface.iBLR, Me.m_objDataSet_KDBXX) = False Then
                        GoTo errProc
                    End If
                End If

                '�������ݼ�
                If Me.htxtSessionIdKDBXX.Value.Trim <> "" Then
                    Session.Remove(Me.htxtSessionIdKDBXX.Value)
                Else
                    Me.htxtSessionIdKDBXX.Value = objPulicParameters.getNewGuid()
                End If
                Session.Add(Me.htxtSessionIdKDBXX.Value, Me.m_objDataSet_KDBXX)

                '�������
                With Me.m_objDataSet_KDBXX.Tables(strTable)
                    Me.htxtKDBXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_KDBXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_KDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ�Ѷ�����Ϣ���ݼ�
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_YDBXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            getModuleData_YDBXX = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtYDBXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                If Not (Me.m_objDataSet_YDBXX Is Nothing) Then
                    Me.m_objDataSet_YDBXX.Dispose()
                    Me.m_objDataSet_YDBXX = Nothing
                End If

                '���¼�������
                If Me.m_objsystemFlowObject.getDubanData(strErrMsg, Me.m_objInterface.iBLR, Me.m_objDataSet_YDBXX) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_YDBXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_YDBXX.Tables(strTable)
                    Me.htxtYDBXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_YDBXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_YDBXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdKDBXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_KDBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            showDataGridInfo_KDBXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtKDBXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtKDBXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_KDBXX Is Nothing Then
                    Me.grdKDBXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_KDBXX.Tables(strTable)
                        Me.grdKDBXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_KDBXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdKDBXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdKDBXX)
                    With Me.grdKDBXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdKDBXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdKDBXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_KDBXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_KDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdYDBXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_YDBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            showDataGridInfo_YDBXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtYDBXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtYDBXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_YDBXX Is Nothing Then
                    Me.grdYDBXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YDBXX.Tables(strTable)
                        Me.grdYDBXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_YDBXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYDBXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdYDBXX)
                    With Me.grdYDBXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdYDBXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYDBXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_YDBXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_YDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdKDBXXδ�󶨵�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnVerify      ����ҪУ������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveModuleDataUnbound_KDBXX( _
            ByRef strErrMsg As String, _
            ByVal blnVerify As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveModuleDataUnbound_KDBXX = False
            strErrMsg = ""

            Try
                '����δ������
                Dim txtDBYQ As System.Web.UI.WebControls.TextBox
                Dim txtDBRQ As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdKDBXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKDBXX.CurrentPageIndex, Me.grdKDBXX.PageSize)
                    objDataRow = Me.m_objDataSet_KDBXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����[��������]txtDBRQ
                    txtDBRQ = CType(Me.grdKDBXX.Items(i).FindControl(Me.m_cstrControlId_KDBXX_txtDBRQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtDBRQ Is Nothing) Then
                        If txtDBRQ.Text.Trim <> "" Then
                            If objPulicParameters.isDatetimeString(txtDBRQ.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��������]����Ч���ڣ�"
                                    GoTo errProc
                                Else
                                    txtDBRQ.Text = ""
                                End If
                            End If
                        End If
                        If txtDBRQ.Text = "" Then
                            txtDBRQ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBRQ) = CType(txtDBRQ.Text, System.DateTime)
                    End If

                    '����[����Ҫ��]txtDBYQ
                    txtDBYQ = CType(Me.grdKDBXX.Items(i).FindControl(Me.m_cstrControlId_KDBXX_txtDBYQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtDBYQ Is Nothing) Then
                        If txtDBYQ.Text = "" Then
                            txtDBYQ.Text = "�뾡�����"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBYQ) = txtDBYQ.Text
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveModuleDataUnbound_KDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdKDBXXδ�󶨵�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleDataUnbound_KDBXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleDataUnbound_KDBXX = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim txtDBYQ As System.Web.UI.WebControls.TextBox
                Dim txtDBRQ As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdKDBXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKDBXX.CurrentPageIndex, Me.grdKDBXX.PageSize)
                    objDataRow = Me.m_objDataSet_KDBXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���[��������]txtDBRQ
                    txtDBRQ = CType(Me.grdKDBXX.Items(i).FindControl(Me.m_cstrControlId_KDBXX_txtDBRQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtDBRQ Is Nothing) Then
                        objControlProcess.doTranslateKey(txtDBRQ)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBRQ), "")
                        If strValue = "" Then
                            txtDBRQ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                        Else
                            txtDBRQ.Text = Format(CType(strValue, System.DateTime), "yyyy-MM-dd HH:mm:ss")
                        End If
                    End If

                    '���[����Ҫ��]txtDBYQ
                    txtDBYQ = CType(Me.grdKDBXX.Items(i).FindControl(Me.m_cstrControlId_KDBXX_txtDBYQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtDBYQ Is Nothing) Then
                        objControlProcess.doTranslateKey(txtDBYQ)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBYQ), "")
                        If strValue = "" Then
                            txtDBYQ.Text = "�뾡�����"
                        Else
                            txtDBYQ.Text = strValue
                        End If
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleDataUnbound_KDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdKDBXX���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_KDBXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_KDBXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_KDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾδ������
                If Me.showModuleDataUnbound_KDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                Me.lblKDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdKDBXX, Me.m_intRows_KDBXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_KDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdYDBXX���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_YDBXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_YDBXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_YDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                Me.lblYDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdYDBXX, Me.m_intRows_YDBXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_YDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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

                    '����ʾgrdKDBXX
                    If Me.showModuleData_KDBXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ȡ����
                    If Me.getModuleData_YDBXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_YDBXX(strErrMsg) = False Then
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
                If Me.getModuleData_KDBXX(strErrMsg) = False Then
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
        Sub grdKDBXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdKDBXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_KDBXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_KDBXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_KDBXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdKDBXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdKDBXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdKDBXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblKDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdKDBXX, Me.m_intRows_KDBXX) + ")"

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

        Private Sub grdKDBXX_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdKDBXX.PageIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '����δ������
                If Me.saveModuleDataUnbound_KDBXX(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                '�޸�����
                Me.grdKDBXX.CurrentPageIndex = e.NewPageIndex

                '������ʾ
                If Me.getModuleData_KDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_KDBXX(strErrMsg) = False Then
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

        Sub grdYDBXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYDBXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_YDBXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_YDBXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_YDBXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYDBXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdYDBXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdYDBXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblYDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdYDBXX, Me.m_intRows_YDBXX) + ")"
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objNewData As New System.Collections.Specialized.NameValueCollection
            Dim objDataRow As System.Data.DataRow
            Dim intStep As Integer

            Try
                'ѯ��
                Dim strUserList As String = ""
                Dim blnSelected As Boolean
                Dim intSelected As Integer
                Dim intRecPos As Integer
                Dim intCount As Integer
                Dim strValue As String
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '������������(У��)
                    If Me.saveModuleDataUnbound_KDBXX(strErrMsg, True) = False Then
                        GoTo errProc
                    End If

                    '���ѡ��
                    intCount = Me.grdKDBXX.Items.Count
                    intSelected = 0
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdKDBXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_KDBXX)
                        If blnSelected = True Then
                            '����
                            intSelected += 1
                            '��ȡ���ݼ�¼
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKDBXX.CurrentPageIndex, Me.grdKDBXX.PageSize)
                            With Me.m_objDataSet_KDBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With
                            '��ȡ��������
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_BDBR), "")
                            If strUserList = "" Then
                                strUserList = strValue
                            Else
                                strUserList = strUserList + objPulicParameters.CharSeparate + strValue
                            End If
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "����δѡ��Ҫ�������Ա��"
                        GoTo errProc
                    End If

                    'ѯ��
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ����[" + strUserList + "]��������֪ͨ����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                Dim strField As String
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '�������
                    intCount = Me.grdKDBXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdKDBXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_KDBXX)
                        If blnSelected = True Then
                            '��ȡ���ݼ�¼
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKDBXX.CurrentPageIndex, Me.grdKDBXX.PageSize)
                            With Me.m_objDataSet_KDBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With
                            '׼������
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_WJBS
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_JJXH
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), "0"))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBXH
                            objNewData.Add(strField, "") '�Զ�����
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBR
                            objNewData.Add(strField, Me.m_objInterface.iBLR)
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBRQ
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_BDBR
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBYQ
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBJG
                            objNewData.Add(strField, "") 'ȱʡ��
                            '����֪ͨ
                            If Me.m_objsystemFlowObject.doSaveDuban(strErrMsg, Nothing, objNewData) = False Then
                                GoTo errProc
                            End If
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
                    Response.Redirect(strUrl)

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

    End Class

End Namespace
