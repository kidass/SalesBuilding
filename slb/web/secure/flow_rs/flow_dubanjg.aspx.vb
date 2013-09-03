Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_dubanjg
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �����������ļ��ĵǼǶ���������
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowDubanjg����
    '----------------------------------------------------------------

    Public Class flow_dubanjg
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblBDBXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdBDBXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnOK As System.Web.UI.WebControls.Button
        Protected WithEvents btnSave As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtBDBXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents textareaQBJG As System.Web.UI.HtmlControls.HtmlTextArea
        Protected WithEvents textareaBCJG As System.Web.UI.HtmlControls.HtmlTextArea
        Protected WithEvents htxtSessionIdBDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBDBXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBDBXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBDBXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBDBXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBDBXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBDBXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowDubanjg
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowDubanjg
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_BDBXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_BDBXX As String '��¼m_objDataSet_BDBXX������
        Private m_intRows_BDBXX As Integer '��¼m_objDataSet_BDBXX��DefaultView��¼��

        '----------------------------------------------------------------
        '����������grdBDBXX��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_BDBXX As String = "chkBDBXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_BDBXX As String = "divBDBXX"
        '����Ҫ����������
        Private m_intFixedColumns_BDBXX As Integer

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
                    Me.htxtDivLeftBDBXX.Value = .htxtDivLeftBDBXX
                    Me.htxtDivTopBDBXX.Value = .htxtDivTopBDBXX

                    Me.htxtBDBXXQuery.Value = .htxtBDBXXQuery
                    Me.htxtBDBXXRows.Value = .htxtBDBXXRows
                    Me.htxtBDBXXSort.Value = .htxtBDBXXSort
                    Me.htxtBDBXXSortColumnIndex.Value = .htxtBDBXXSortColumnIndex
                    Me.htxtBDBXXSortType.Value = .htxtBDBXXSortType

                    Me.htxtSessionIdBDBXX.Value = .htxtSessionIdBDBXX
                    Try
                        Me.grdBDBXX.PageSize = .grdBDBXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBDBXX.CurrentPageIndex = .grdBDBXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBDBXX.SelectedIndex = .grdBDBXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.textareaQBJG.InnerText = .textareaQBJG
                    Me.textareaBCJG.InnerText = .textareaBCJG

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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowDubanjg

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftBDBXX = Me.htxtDivLeftBDBXX.Value
                    .htxtDivTopBDBXX = Me.htxtDivTopBDBXX.Value

                    .htxtBDBXXQuery = Me.htxtBDBXXQuery.Value
                    .htxtBDBXXRows = Me.htxtBDBXXRows.Value
                    .htxtBDBXXSort = Me.htxtBDBXXSort.Value
                    .htxtBDBXXSortColumnIndex = Me.htxtBDBXXSortColumnIndex.Value
                    .htxtBDBXXSortType = Me.htxtBDBXXSortType.Value

                    .htxtSessionIdBDBXX = Me.htxtSessionIdBDBXX.Value
                    .grdBDBXX_PageSize = Me.grdBDBXX.PageSize
                    .grdBDBXX_CurrentPageIndex = Me.grdBDBXX.CurrentPageIndex
                    .grdBDBXX_SelectedIndex = Me.grdBDBXX.SelectedIndex

                    .textareaBCJG = Me.textareaBCJG.InnerText
                    .textareaQBJG = Me.textareaQBJG.InnerText

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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowDubanjg)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowDubanjg)
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
                Me.m_intFixedColumns_BDBXX = objPulicParameters.getObjectValue(Me.htxtBDBXXFixed.Value, 0)
                Me.m_intRows_BDBXX = objPulicParameters.getObjectValue(Me.htxtBDBXXRows.Value, 0)
                Me.m_strQuery_BDBXX = Me.htxtBDBXXQuery.Value

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
                If Me.htxtSessionIdBDBXX.Value.Trim <> "" Then
                    Dim objFlowData As Josco.JSOA.Common.Data.FlowData
                    Try
                        objFlowData = CType(Session(Me.htxtSessionIdBDBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        objFlowData = Nothing
                    End Try
                    If Not (objFlowData Is Nothing) Then
                        objFlowData.Dispose()
                        objFlowData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdBDBXX.Value)
                    Me.htxtSessionIdBDBXX.Value = ""
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
        Private Function getModuleData_BDBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_BDBXX = False

            Try
                '�ӻ����ȡ����
                If Me.htxtSessionIdBDBXX.Value.Trim <> "" Then
                    Try
                        Me.m_objDataSet_BDBXX = CType(Session(Me.htxtSessionIdBDBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        Me.m_objDataSet_BDBXX = Nothing
                    End Try
                End If

                '����ȱʡ����
                If Me.m_objDataSet_BDBXX Is Nothing Then
                    If Me.m_objsystemFlowObject.getBeidubanData(strErrMsg, Me.m_objInterface.iBLR, Me.m_objDataSet_BDBXX) = False Then
                        GoTo errProc
                    End If
                End If

                '�������ݼ�
                If Me.htxtSessionIdBDBXX.Value.Trim <> "" Then
                    Session.Remove(Me.htxtSessionIdBDBXX.Value)
                Else
                    Me.htxtSessionIdBDBXX.Value = objPulicParameters.getNewGuid()
                End If
                Session.Add(Me.htxtSessionIdBDBXX.Value, Me.m_objDataSet_BDBXX)

                '�������
                With Me.m_objDataSet_BDBXX.Tables(strTable)
                    Me.htxtBDBXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_BDBXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_BDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdBDBXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_BDBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE

            showDataGridInfo_BDBXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtBDBXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtBDBXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_BDBXX Is Nothing Then
                    Me.grdBDBXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_BDBXX.Tables(strTable)
                        Me.grdBDBXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_BDBXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdBDBXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdBDBXX)
                    With Me.grdBDBXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdBDBXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdBDBXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_BDBXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_BDBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Function showModuleData_Edit(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_Edit = False
            strErrMsg = ""

            Try
                '��ʼ��
                Me.textareaQBJG.InnerText = ""

                '���
                If Me.grdBDBXX.Items.Count < 1 Then
                    Exit Try
                End If
                If Me.grdBDBXX.SelectedIndex < 0 Then
                    Exit Try
                End If

                '��ʾ
                Dim strQBJG As String = ""
                Dim strBCJG As String = ""
                Dim strYYJG As String = ""
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                With Me.m_objDataSet_BDBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE)
                    intRecPos = objDataGridProcess.getRecordPosition(Me.grdBDBXX.SelectedIndex, Me.grdBDBXX.CurrentPageIndex, Me.grdBDBXX.PageSize)
                    objDataRow = .DefaultView.Item(intRecPos).Row
                End With
                strYYJG = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBJG), "")
                strBCJG = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_JIAOJIE_BCJG), "")
                If strYYJG <> "" Then
                    strQBJG = strYYJG
                End If
                If strBCJG <> "" Then
                    If strQBJG <> "" Then
                        strQBJG = strQBJG + vbCr + strBCJG
                    Else
                        strQBJG = strBCJG
                    End If
                End If
                Me.textareaQBJG.InnerText = strQBJG
                Me.textareaBCJG.InnerText = strBCJG

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_Edit = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdBDBXX���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_BDBXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_BDBXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_BDBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ����������
                If Me.showModuleData_Edit(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                Me.lblBDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdBDBXX, Me.m_intRows_BDBXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_BDBXX = True
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

                    '����ʾgrdBDBXX
                    If Me.showModuleData_BDBXX(strErrMsg) = False Then
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
                If Me.getModuleData_BDBXX(strErrMsg) = False Then
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
        Sub grdBDBXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdBDBXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_BDBXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_BDBXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_BDBXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdBDBXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdBDBXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBDBXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblBDBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdBDBXX, Me.m_intRows_BDBXX) + ")"

                'ͬ��
                If Me.showModuleData_BDBXX(strErrMsg) = False Then
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

        Private Sub doSave(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���
                If Me.textareaBCJG.InnerText.Trim = "" Then
                    strErrMsg = "����û���������ݣ�"
                    GoTo errProc
                End If
                If Me.grdBDBXX.Items.Count < 1 Then
                    strErrMsg = "������û�б����죬�����������"
                    GoTo errProc
                End If
                If Me.grdBDBXX.SelectedIndex < 0 Then
                    strErrMsg = "����δѡ�����屻�������Ŀ��"
                    GoTo errProc
                End If

                '�ݴ�
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                With Me.m_objDataSet_BDBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE)
                    intRecPos = objDataGridProcess.getRecordPosition(Me.grdBDBXX.SelectedIndex, Me.grdBDBXX.CurrentPageIndex, Me.grdBDBXX.PageSize)
                    objDataRow = .DefaultView.Item(intRecPos).Row
                End With
                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_JIAOJIE_BCJG) = Me.textareaBCJG.InnerText.Trim + vbCr + "    " + Me.m_objInterface.iBLR + "    " + Format(Now, "yyyy-MM-dd HH:mm:ss")

                '��ʾ
                If Me.showModuleData_BDBXX(strErrMsg) = False Then
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objDataRow As System.Data.DataRow
            Dim intStep As Integer

            Try
                'ѯ��
                Dim strUserList As String = ""
                Dim intRecPos As Integer
                Dim intCount As Integer
                Dim strValue As String
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    'ѯ��
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ����д�İ��������ȷ����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                Dim strField As String
                Dim intJJXH As Integer
                Dim intDBXH As Integer
                Dim strQBJG As String = ""
                Dim strBCJG As String = ""
                Dim strYYJG As String = ""
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '�������
                    intCount = Me.grdBDBXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        '��ȡ���ݼ�¼
                        intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdBDBXX.CurrentPageIndex, Me.grdBDBXX.PageSize)
                        With Me.m_objDataSet_BDBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_DUBAN_JIAOJIE)
                            objDataRow = .DefaultView.Item(intRecPos).Row
                        End With

                        '׼������
                        strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_JJXH
                        intJJXH = objPulicParameters.getObjectValue(objDataRow.Item(strField), 0)
                        strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBXH
                        intDBXH = objPulicParameters.getObjectValue(objDataRow.Item(strField), 0)
                        strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_DBJG
                        strYYJG = objPulicParameters.getObjectValue(objDataRow.Item(strField), "")
                        strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_DUBAN_JIAOJIE_BCJG
                        strBCJG = objPulicParameters.getObjectValue(objDataRow.Item(strField), "")
                        If strYYJG <> "" Then
                            strQBJG = strYYJG
                        End If
                        If strBCJG <> "" Then
                            If strQBJG <> "" Then
                                strQBJG = strQBJG + vbCr + strBCJG
                            Else
                                strQBJG = strBCJG
                            End If
                        End If

                        '����
                        If Me.m_objsystemFlowObject.doSaveDuban(strErrMsg, intJJXH, intDBXH, strQBJG) = False Then
                            GoTo errProc
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

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Me.doSave("btnSave")
        End Sub

    End Class

End Namespace
