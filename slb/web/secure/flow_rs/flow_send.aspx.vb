Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_send
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �����������ļ��ķ�������
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowSend����
    '----------------------------------------------------------------

    Public Class flow_send
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents grdJSRXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents grdWTXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents rblWTXX As System.Web.UI.WebControls.RadioButtonList
        Protected WithEvents cblFSXX As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents btnSelectRY As System.Web.UI.WebControls.Button
        Protected WithEvents btnDeleteRY As System.Web.UI.WebControls.Button
        Protected WithEvents btnAddFSR As System.Web.UI.WebControls.Button
        Protected WithEvents btnSend As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        'LJ 2008-07-25
        Protected WithEvents htxtXRMode As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtEditMode As System.Web.UI.HtmlControls.HtmlInputHidden
        'LJ 2008-07-25
        Protected WithEvents htxtJSRXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWTXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSessionIdJSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtJSRXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWTXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWTXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWTXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWTXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWTXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftJSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopJSRXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftWTXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopWTXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblJSRXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents lblWTXXGridLocInfo As System.Web.UI.WebControls.Label
        'Lj 2008-07-09
        Protected WithEvents ddlPLBLSY As System.Web.UI.WebControls.DropDownList
        Protected WithEvents btnPLTJSY As System.Web.UI.WebControls.Button
        Protected WithEvents lnkDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMoveNext As System.Web.UI.WebControls.LinkButton
        'Lj 2008-07-09

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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowSend
        Private m_blnSaveScence As Boolean



        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowSend
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_JSRXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_JSRXX As String '��¼m_objDataSet_JSRXX������
        Private m_intRows_JSRXX As Integer '��¼m_objDataSet_JSRXX��DefaultView��¼��
        Private m_objDataSet_WTXX As Josco.JsKernal.Common.Data.grswMyLiuyanData
        Private m_strQuery_WTXX As String '��¼m_objDataSet_WTXX������
        Private m_intRows_WTXX As Integer '��¼m_objDataSet_WTXX��DefaultView��¼��

        '----------------------------------------------------------------
        '����������grdJSRXX��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrControlId_JSRXX_ddlBLSY As String = "ddlBLSY"
        Private Const m_cstrControlId_JSRXX_txtBLQX As String = "txtBLQX"
        Private Const m_cstrControlId_JSRXX_ddlWJZT As String = "ddlWJZT"
        Private Const m_cstrControlId_JSRXX_txtWJZZFS As String = "txtWJZZFS"
        Private Const m_cstrControlId_JSRXX_txtWJDZFS As String = "txtWJDZFS"
        Private Const m_cstrControlId_JSRXX_ddlFJZT As String = "ddlFJZT"
        Private Const m_cstrControlId_JSRXX_txtFJZZFS As String = "txtFJZZFS"
        Private Const m_cstrControlId_JSRXX_txtFJDZFS As String = "txtFJDZFS"
        Private Const m_cstrControlId_JSRXX_ddlXBBZ As String = "ddlXBBZ"
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_JSRXX As String = "chkJSRXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_JSRXX As String = "divJSRXX"
        '����Ҫ����������
        Private m_intFixedColumns_JSRXX As Integer

        '----------------------------------------------------------------
        '����������grdWTXX��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_WTXX As String = "chkWTXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_WTXX As String = "divWTXX"
        '����Ҫ����������
        Private m_intFixedColumns_WTXX As Integer

        '----------------------------------------------------------------
        'ģ����������
        '----------------------------------------------------------------
        '��������������
        Private m_strFlowTypeName As String
        '�ļ���ʶ
        Private m_strWJBS As String
        '�״ν���
        Private m_blnEditMode As Boolean
        '�ӽ��淵�ص��ж�
        Private m_blnXR As Boolean
        Private m_strXR As String = ""










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
                    Me.htxtDivLeftWTXX.Value = .htxtDivLeftWTXX
                    Me.htxtDivTopWTXX.Value = .htxtDivTopWTXX

                    Me.htxtJSRXXQuery.Value = .htxtJSRXXQuery
                    Me.htxtJSRXXRows.Value = .htxtJSRXXRows
                    Me.htxtJSRXXSort.Value = .htxtJSRXXSort
                    Me.htxtJSRXXSortColumnIndex.Value = .htxtJSRXXSortColumnIndex
                    Me.htxtJSRXXSortType.Value = .htxtJSRXXSortType

                    Me.htxtWTXXQuery.Value = .htxtWTXXQuery
                    Me.htxtWTXXRows.Value = .htxtWTXXRows
                    Me.htxtWTXXSort.Value = .htxtWTXXSort
                    Me.htxtWTXXSortColumnIndex.Value = .htxtWTXXSortColumnIndex
                    Me.htxtWTXXSortType.Value = .htxtWTXXSortType

                    'LJ 2008-07-24
                    Me.htxtEditMode.Value = .htxtEditMode
                    Me.htxtXRMode.Value = .htxtXRMode
                    'LJ 2008-07-24

                    Me.htxtSessionIdJSRXX.Value = .htxtSessionIdJSRXX
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

                    Try
                        Me.grdWTXX.PageSize = .grdWTXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWTXX.CurrentPageIndex = .grdWTXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWTXX.SelectedIndex = .grdWTXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.rblWTXX.SelectedIndex = .rblWTXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Dim intCount As Integer
                        Dim i As Integer
                        intCount = Me.cblFSXX.Items.Count
                        For i = 0 To intCount - 1 Step 1
                            Me.cblFSXX.Items(i).Selected = .cblFSXX_SelectedItems(i)
                        Next
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowSend

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    'LJ 2008-07-24
                    .htxtEditMode = Me.htxtEditMode.Value
                    .htxtXRMode = Me.htxtXRMode.Value
                    'LJ 2008-07-24

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftJSRXX = Me.htxtDivLeftJSRXX.Value
                    .htxtDivTopJSRXX = Me.htxtDivTopJSRXX.Value
                    .htxtDivLeftWTXX = Me.htxtDivLeftWTXX.Value
                    .htxtDivTopWTXX = Me.htxtDivTopWTXX.Value

                    .htxtJSRXXQuery = Me.htxtJSRXXQuery.Value
                    .htxtJSRXXRows = Me.htxtJSRXXRows.Value
                    .htxtJSRXXSort = Me.htxtJSRXXSort.Value
                    .htxtJSRXXSortColumnIndex = Me.htxtJSRXXSortColumnIndex.Value
                    .htxtJSRXXSortType = Me.htxtJSRXXSortType.Value

                    .htxtWTXXQuery = Me.htxtWTXXQuery.Value
                    .htxtWTXXRows = Me.htxtWTXXRows.Value
                    .htxtWTXXSort = Me.htxtWTXXSort.Value
                    .htxtWTXXSortColumnIndex = Me.htxtWTXXSortColumnIndex.Value
                    .htxtWTXXSortType = Me.htxtWTXXSortType.Value

                    .htxtSessionIdJSRXX = Me.htxtSessionIdJSRXX.Value
                    .grdJSRXX_PageSize = Me.grdJSRXX.PageSize
                    .grdJSRXX_CurrentPageIndex = Me.grdJSRXX.CurrentPageIndex
                    .grdJSRXX_SelectedIndex = Me.grdJSRXX.SelectedIndex

                    .grdWTXX_PageSize = Me.grdWTXX.PageSize
                    .grdWTXX_CurrentPageIndex = Me.grdWTXX.CurrentPageIndex
                    .grdWTXX_SelectedIndex = Me.grdWTXX.SelectedIndex

                    .rblWTXX_SelectedIndex = Me.rblWTXX.SelectedIndex

                    Dim intCount As Integer
                    Dim i As Integer
                    intCount = Me.cblFSXX.Items.Count
                    Dim blnSelected(intCount) As Boolean
                    For i = 0 To intCount - 1 Step 1
                        blnSelected(i) = Me.cblFSXX.Items(i).Selected
                    Next
                    .cblFSXX_SelectedItems = blnSelected

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
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Try
                    objIDmxzZzry = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzry)
                Catch ex As Exception
                    objIDmxzZzry = Nothing
                End Try
                If Not (objIDmxzZzry Is Nothing) Then
                    If objIDmxzZzry.oExitMode = True Then
                        Select Case objIDmxzZzry.iSourceControlId.ToUpper
                            Case "btnSelectRY".ToUpper
                                If Me.htxtSessionIdJSRXX.Value.Trim <> "" Then
                                    Try
                                        Me.m_objDataSet_JSRXX = CType(Session(Me.htxtSessionIdJSRXX.Value), Josco.JSOA.Common.Data.FlowData)
                                    Catch ex As Exception
                                    End Try
                                End If
                                If Me.doAddData_JSRXX(strErrMsg, objIDmxzZzry.oRenyuanList) = False Then
                                    GoTo errProc
                                End If

                                'lj 2008-07-24
                                If Me.htxtXRMode.Value = "" Then
                                    m_strXR = "1"
                                Else
                                    m_strXR = Me.htxtXRMode.Value
                                End If
                            Case Else
                        End Select
                    Else
                        'lj 2008-07-24
                        If Me.htxtXRMode.Value.Trim = "" Then
                            m_strXR = "0"
                        Else
                            m_strXR = Me.htxtXRMode.Value.Trim
                        End If
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

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowSend)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowSend)
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

                Me.m_intFixedColumns_WTXX = objPulicParameters.getObjectValue(Me.htxtWTXXFixed.Value, 0)
                Me.m_intRows_WTXX = objPulicParameters.getObjectValue(Me.htxtWTXXRows.Value, 0)
                Me.m_strQuery_WTXX = Me.htxtWTXXQuery.Value

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
                If Me.htxtSessionIdJSRXX.Value.Trim <> "" Then
                    Dim objFSRDATA As Josco.JSOA.Common.Data.FlowData
                    Try
                        objFSRDATA = CType(Session(Me.htxtSessionIdJSRXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        objFSRDATA = Nothing
                    End Try
                    If Not (objFSRDATA Is Nothing) Then
                        objFSRDATA.Dispose()
                        objFSRDATA = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdJSRXX.Value)
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' �Զ�ɾ���������б���[������]+[��������]��ͬ����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doDeleteInvalidJSR(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doDeleteInvalidJSR = False
            strErrMsg = ""

            Try
                '���
                If Me.m_objDataSet_JSRXX Is Nothing Then
                    Exit Try
                End If
                If Me.m_objDataSet_JSRXX.Tables(strTable) Is Nothing Then
                    Exit Try
                End If

                'ɾ����Ч��
                Dim strValue1(2) As String
                Dim strValue2(2) As String
                Dim intCountA As Integer
                Dim intCount As Integer
                Dim blnFound As Boolean
                Dim i As Integer
                Dim j As Integer
                With Me.m_objDataSet_JSRXX.Tables(strTable)
                    intCount = .Rows.Count
                    For i = intCount - 1 To 0 Step -1
                        '��ȡ����
                        strValue1(0) = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR), "")
                        strValue1(1) = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY), "")
                        strValue1(0) = strValue1(0).ToUpper
                        strValue1(1) = strValue1(1).ToUpper

                        '����
                        blnFound = False
                        intCountA = .Rows.Count
                        For j = 0 To intCountA - 1 Step 1
                            If i <> j Then
                                strValue2(0) = objPulicParameters.getObjectValue(.Rows(j).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR), "")
                                strValue2(1) = objPulicParameters.getObjectValue(.Rows(j).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY), "")
                                strValue2(0) = strValue2(0).ToUpper
                                strValue2(1) = strValue2(1).ToUpper
                                If strValue1(0) = strValue2(0) And strValue1(1) = strValue2(1) Then
                                    blnFound = True
                                    Exit For
                                End If
                            End If
                        Next

                        'ɾ��
                        If blnFound = True Then
                            .Rows.RemoveAt(i)
                        End If
                    Next
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doDeleteInvalidJSR = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ӵ�ǰ����Ľ������б��л�ȡ����������(���ظ�)
        '     strErrMsg      �����ش�����Ϣ
        '     strJSRArray    �����ؽ���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getJSRArray( _
            ByRef strErrMsg As String, _
            ByRef strJSRArray As String()) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objJSR As New System.Collections.Specialized.NameValueCollection

            getJSRArray = False
            strJSRArray = Nothing
            strErrMsg = ""

            Try
                '���
                If Me.m_objDataSet_JSRXX Is Nothing Then
                    Exit Try
                End If
                If Me.m_objDataSet_JSRXX.Tables(strTable) Is Nothing Then
                    Exit Try
                End If

                '��ȡ����
                Dim intCountA As Integer
                Dim intCount As Integer
                Dim strJSR(2) As String
                Dim blnFound As Boolean
                Dim i As Integer
                Dim j As Integer
                With Me.m_objDataSet_JSRXX.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        '��ȡ����
                        strJSR(0) = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR), "")
                        strJSR(0) = strJSR(0).ToUpper

                        '����
                        blnFound = False
                        intCountA = objJSR.Count
                        For j = 0 To intCountA - 1 Step 1
                            strJSR(1) = objJSR(j)
                            strJSR(1) = strJSR(1).ToUpper
                            If strJSR(0) = strJSR(1) Then
                                blnFound = True
                                Exit For
                            End If
                        Next

                        '����
                        If blnFound = False Then
                            objJSR.Add(strJSR(0), strJSR(0))
                        End If
                    Next
                End With

                '��������
                If objJSR.Count > 0 Then
                    Dim strArray(objJSR.Count - 1) As String
                    intCount = objJSR.Count
                    For i = 0 To intCount - 1 Step 1
                        strArray(i) = objJSR(i)
                    Next
                    strJSRArray = strArray
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objJSR)

            getJSRArray = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objJSR)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����Ƿ��ܷ��͸�������
        '     strErrMsg      �����ش�����Ϣ
        '     blnCanSend     �������Ƿ��ܹ����͵�?
        '     strPrompt      ��������ʾ��Ϣ��������ܷ��ͣ�
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doCheckSendRestrict( _
            ByRef strErrMsg As String, _
            ByRef blnCanSend As Boolean, _
            ByRef strPrompt As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doCheckSendRestrict = False
            blnCanSend = False
            strPrompt = ""
            strErrMsg = ""

            Try
                '���
                If Me.m_objDataSet_JSRXX Is Nothing Then
                    Exit Try
                End If
                If Me.m_objDataSet_JSRXX.Tables(strTable) Is Nothing Then
                    Exit Try
                End If

                If Me.m_objsystemFlowObject.FlowData.FlowTypeName = Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWNAME Then

                End If

                '���ü�飡
                Select Case Me.m_objsystemFlowObject.FlowData.DDSZ
                    Case 1
                        '����Ҫ���
                        blnCanSend = True
                        Exit Try

                    Case Else
                        '��Ҫ���
                End Select

                '��ȡ����
                Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                Dim blnCanSendTo As Boolean
                Dim strNewWTR As String
                Dim intCount As Integer
                Dim strWTR As String
                Dim strJSR As String
                Dim strFSR As String
                Dim i As Integer
                With Me.m_objDataSet_JSRXX.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        '��ȡ�����ˡ������˵�ί���ˡ������˵�ί����
                        strJSR = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR), "")
                        strJSR = strJSR.ToUpper
                        strFSR = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FSR), "")
                        strFSR = strFSR.ToUpper

                        '�����˵�ί����
                        strWTR = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WTR), "")
                        strWTR = strWTR.ToUpper

                        '�����˵�ί����
                        If Me.m_objsystemFlowObject.getWeituoren(strErrMsg, Me.m_objInterface.iBLR, strNewWTR) = False Then
                            GoTo errProc
                        End If
                        If strNewWTR <> "" Then
                            If strWTR = "" Then
                                strWTR = strNewWTR
                            Else
                                strWTR = strWTR + strSep + strNewWTR
                            End If
                        End If

                        '���ܵķ������б�
                        If strWTR = "" Then
                            strWTR = strFSR
                        Else
                            strWTR = strWTR + strSep + strFSR
                        End If

                        '���
                        If Me.m_objsystemFlowObject.canSendTo(strErrMsg, strWTR, strJSR, blnCanSendTo, strNewWTR) = False Then
                            GoTo errProc
                        End If
                        If blnCanSendTo = False Then
                            strPrompt = "��ʾ�������ܷ��͸�[" + strJSR + "]��ֻ����[" + strNewWTR + "]ת�ͣ�"
                            Exit Try
                        End If
                    Next
                End With

                '�ܹ�����
                blnCanSend = True

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doCheckSendRestrict = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��������ļ���
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doComputeTaskLevel(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doComputeTaskLevel = False
            strErrMsg = ""

            Try
                '���
                If Me.m_objDataSet_JSRXX Is Nothing Then
                    Exit Try
                End If
                If Me.m_objDataSet_JSRXX.Tables(strTable) Is Nothing Then
                    Exit Try
                End If

                '��ȡ����
                Dim strTaskName As String
                Dim intLevel As Integer
                Dim intCount As Integer
                Dim i As Integer
                With Me.m_objDataSet_JSRXX.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        '��ȡ���������ˡ�
                        strTaskName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY), "")
                        strTaskName = strTaskName.ToUpper

                        '���㼶��
                        If Me.m_objsystemFlowObject.getTaskLevel(strErrMsg, strTaskName, intLevel) = False Then
                            GoTo errProc
                        End If

                        '������Ϣ
                        .Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_SYJB) = intLevel
                    Next
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doComputeTaskLevel = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

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
        ' ��������Ա���뵽��������Ϣ���ݼ�(�������ݼ��)
        '     strErrMsg      �����ش�����Ϣ
        '     strRyList      ����Ա��(�ָ����ָ�)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doAddData_JSRXX( _
            ByRef strErrMsg As String, _
            ByVal strRyList As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            doAddData_JSRXX = False
            strErrMsg = ""

            Try
                '���
                If strRyList Is Nothing Then
                    Exit Try
                End If
                If strRyList.Trim = "" Then
                    Exit Try
                End If
                If Me.m_objDataSet_JSRXX Is Nothing Then
                    Exit Try
                End If
                If Me.m_objDataSet_JSRXX.Tables(strTable) Is Nothing Then
                    Exit Try
                End If

                '����(������ظ�)
                Dim objDataRow As System.Data.DataRow
                Dim intCount As Integer
                Dim strJSR() As String
                Dim i As Integer
                strJSR = strRyList.Split(strSep.ToCharArray())
                intCount = strJSR.Length
                For i = 0 To intCount - 1 Step 1
                    With Me.m_objDataSet_JSRXX.Tables(strTable)
                        objDataRow = .NewRow()
                    End With

                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR) = strJSR(i)
                    'LJ 2008-06-25
                    'objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY) = Josco.JSOA.Common.Workflow.BaseFlowObject.TASK_XGCL
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY) = ""
                    'LJ 2008-06-25
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLQX) = Now.AddDays(3)
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FSR) = Me.m_objInterface.iBLR
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FSRQ) = Now
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJZT) = Josco.JSOA.Common.Workflow.BaseFlowObject.FILEZTLX_DZ
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJZZFS) = 0
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJDZFS) = 1
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJZT) = Josco.JSOA.Common.Workflow.BaseFlowObject.FILEZTLX_DZ
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJZZFS) = 0
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJDZFS) = 1
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_SYJB) = 0
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_XB) = Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse
                    If Me.m_objInterface.iWTFS = True Then
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WTR) = Me.m_objInterface.iBLR
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WTR) = ""
                    End If

                    With Me.m_objDataSet_JSRXX.Tables(strTable)
                        .Rows.Add(objDataRow)
                    End With
                Next


            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doAddData_JSRXX = True
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

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_JSRXX = False

            Try
                '�ӻ����ȡ����
                If Me.htxtSessionIdJSRXX.Value.Trim <> "" Then
                    Try
                        Me.m_objDataSet_JSRXX = CType(Session(Me.htxtSessionIdJSRXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        Me.m_objDataSet_JSRXX = Nothing
                    End Try
                End If

                '����ȱʡ����
                If Me.m_objDataSet_JSRXX Is Nothing Then
                    Me.m_objDataSet_JSRXX = New Josco.JSOA.Common.Data.FlowData(Josco.JSOA.Common.Data.FlowData.enumTableType.GW_B_VT_WENJIANFASONG)
                    If Me.m_objInterface.iJSR <> "" Then
                        If Me.doAddData_JSRXX(strErrMsg, Me.m_objInterface.iJSR) = False Then
                            GoTo errProc
                        End If
                    End If
                End If

                '�������ݼ�
                If Me.htxtSessionIdJSRXX.Value.Trim <> "" Then
                    Session.Remove(Me.htxtSessionIdJSRXX.Value)
                Else
                    Me.htxtSessionIdJSRXX.Value = objPulicParameters.getNewGuid()
                End If
                Session.Add(Me.htxtSessionIdJSRXX.Value, Me.m_objDataSet_JSRXX)

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
        ' ���ݽ�������Ϣ��ȡ�����˵�ί��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_WTXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.grswMyLiuyanData.TABLE_GR_B_LIKAILIUYAN
            Dim objsystemMyLiuyan As New Josco.JsKernal.BusinessFacade.systemMyLiuyan
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_WTXX = False

            Try
                '�ӵ�ǰ����Ľ������б��л�ȡ����������
                Dim strJSRArray As String()
                If Me.grdJSRXX.SelectedIndex < 0 Then
                    strJSRArray = Nothing
                Else
                    Dim intColIndex As Integer
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJSRXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR)
                    Dim strArray(0) As String
                    strArray(0) = objDataGridProcess.getDataGridCellValue(Me.grdJSRXX.Items(Me.grdJSRXX.SelectedIndex), intColIndex)
                    strJSRArray = strArray
                End If

                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtWTXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                If Not (Me.m_objDataSet_WTXX Is Nothing) Then
                    Me.m_objDataSet_WTXX.Dispose()
                    Me.m_objDataSet_WTXX = Nothing
                End If

                '���¼�������
                If objsystemMyLiuyan.getDataSet(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJSRArray, Me.m_objDataSet_WTXX) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_WTXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_WTXX.Tables(strTable)
                    Me.htxtWTXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_WTXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemMyLiuyan.SafeRelease(objsystemMyLiuyan)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_WTXX = True
            Exit Function

errProc:
            Josco.JsKernal.BusinessFacade.systemMyLiuyan.SafeRelease(objsystemMyLiuyan)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG

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
        ' ��ʾgrdWTXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_WTXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JsKernal.Common.Data.grswMyLiuyanData.TABLE_GR_B_LIKAILIUYAN

            showDataGridInfo_WTXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtWTXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtWTXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_WTXX Is Nothing Then
                    Me.grdWTXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_WTXX.Tables(strTable)
                        Me.grdWTXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_WTXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdWTXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdWTXX)
                    With Me.grdWTXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdWTXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdWTXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_WTXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_WTXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdJSRXXδ�󶨵�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnVerify      ����ҪУ������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveModuleDataUnbound_JSRXX( _
            ByRef strErrMsg As String, _
            ByVal blnVerify As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveModuleDataUnbound_JSRXX = False
            strErrMsg = ""

            Try
                '����δ������
                Dim ddlXBBZ As System.Web.UI.WebControls.DropDownList
                Dim ddlBLSY As System.Web.UI.WebControls.DropDownList
                Dim txtFJDZFS As System.Web.UI.WebControls.TextBox
                Dim txtFJZZFS As System.Web.UI.WebControls.TextBox
                Dim txtWJDZFS As System.Web.UI.WebControls.TextBox
                Dim txtWJZZFS As System.Web.UI.WebControls.TextBox
                Dim txtBLQX As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdJSRXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJSRXX.CurrentPageIndex, Me.grdJSRXX.PageSize)
                    objDataRow = Me.m_objDataSet_JSRXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����[��������]ddlBLSY
                    ddlBLSY = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_ddlBLSY), System.Web.UI.WebControls.DropDownList)
                    If Not (ddlBLSY Is Nothing) Then
                        'zengxianglin 2008-06-25
                        'If ddlBLSY.SelectedIndex < 0 Then
                        If ddlBLSY.SelectedIndex < 0 Then
                            'zengxianglin 2008-06-25
                            If blnVerify = True Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��������]û��ָ����"
                                GoTo errProc
                            Else
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY) = ""
                            End If
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY) = ddlBLSY.SelectedValue
                        End If
                    End If

                    '����[��������]txtBLQX
                    txtBLQX = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtBLQX), System.Web.UI.WebControls.TextBox)
                    If Not (txtBLQX Is Nothing) Then
                        If txtBLQX.Text.Trim <> "" Then
                            If objPulicParameters.isDatetimeString(txtBLQX.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��������]����Ч���ڣ�"
                                    GoTo errProc
                                Else
                                    txtBLQX.Text = ""
                                End If
                            Else
                                If CType(txtBLQX.Text, System.DateTime) < Now Then
                                    If blnVerify = True Then
                                        strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��������]�����ǽ����Ժ�"
                                        GoTo errProc
                                    Else
                                        txtBLQX.Text = ""
                                    End If
                                End If
                            End If
                        End If
                        If txtBLQX.Text = "" Then
                            txtBLQX.Text = Format(Now.AddDays(3), "yyyy-MM-dd HH:mm:ss")
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLQX) = CType(txtBLQX.Text, System.DateTime)
                    End If

                    '����[ֽ���ļ�����]txtWJZZFS
                    txtWJZZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtWJZZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtWJZZFS Is Nothing) Then
                        If txtWJZZFS.Text.Trim <> "" Then
                            If objPulicParameters.isIntegerString(txtWJZZFS.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[ֽ���ļ�����]����Ч������"
                                    GoTo errProc
                                Else
                                    txtWJZZFS.Text = ""
                                End If
                            Else
                                If CType(txtWJZZFS.Text, Integer) < 0 Then
                                    If blnVerify = True Then
                                        strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[ֽ���ļ�����]��������>=0��"
                                        GoTo errProc
                                    Else
                                        txtWJZZFS.Text = ""
                                    End If
                                End If
                            End If
                        End If
                        If txtWJZZFS.Text = "" Then
                            txtWJZZFS.Text = "0"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJZZFS) = CType(txtWJZZFS.Text, Integer)
                    End If

                    '����[�����ļ�����]txtWJDZFS
                    txtWJDZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtWJDZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtWJDZFS Is Nothing) Then
                        If txtWJDZFS.Text.Trim <> "" Then
                            If objPulicParameters.isIntegerString(txtWJDZFS.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�����ļ�����]����Ч������"
                                    GoTo errProc
                                Else
                                    txtWJDZFS.Text = ""
                                End If
                            Else
                                If CType(txtWJDZFS.Text, Integer) < 0 Then
                                    If blnVerify = True Then
                                        strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�����ļ�����]��������>=0��"
                                        GoTo errProc
                                    Else
                                        txtWJDZFS.Text = ""
                                    End If
                                End If
                            End If
                        End If
                        If txtWJDZFS.Text = "" Then
                            txtWJDZFS.Text = "1"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJDZFS) = CType(txtWJDZFS.Text, Integer)
                    End If

                    '����[ֽ�ʸ�������]txtFJZZFS
                    txtFJZZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtFJZZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtFJZZFS Is Nothing) Then
                        If txtFJZZFS.Text.Trim <> "" Then
                            If objPulicParameters.isIntegerString(txtFJZZFS.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[ֽ�ʸ�������]����Ч������"
                                    GoTo errProc
                                Else
                                    txtFJZZFS.Text = ""
                                End If
                            Else
                                If CType(txtFJZZFS.Text, Integer) < 0 Then
                                    If blnVerify = True Then
                                        strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[ֽ�ʸ�������]��������>=0��"
                                        GoTo errProc
                                    Else
                                        txtFJZZFS.Text = ""
                                    End If
                                End If
                            End If
                        End If
                        If txtFJZZFS.Text = "" Then
                            txtFJZZFS.Text = "0"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJZZFS) = CType(txtFJZZFS.Text, Integer)
                    End If

                    '����[���Ӹ�������]txtFJDZFS
                    txtFJDZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtFJDZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtFJDZFS Is Nothing) Then
                        If txtFJDZFS.Text.Trim <> "" Then
                            If objPulicParameters.isIntegerString(txtFJDZFS.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[���Ӹ�������]����Ч������"
                                    GoTo errProc
                                Else
                                    txtFJDZFS.Text = ""
                                End If
                            Else
                                If CType(txtFJDZFS.Text, Integer) < 0 Then
                                    If blnVerify = True Then
                                        strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[���Ӹ�������]��������>=0��"
                                        GoTo errProc
                                    Else
                                        txtFJDZFS.Text = ""
                                    End If
                                End If
                            End If
                        End If
                        If txtFJDZFS.Text = "" Then
                            txtFJDZFS.Text = "1"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJDZFS) = CType(txtFJDZFS.Text, Integer)
                    End If

                    '����[Э��]ddlXBBZ
                    ddlXBBZ = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_ddlXBBZ), System.Web.UI.WebControls.DropDownList)
                    If Not (ddlXBBZ Is Nothing) Then
                        If ddlXBBZ.SelectedIndex < 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_XB) = objPulicParameters.CharFalse
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_XB) = ddlXBBZ.SelectedValue
                        End If
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

            saveModuleDataUnbound_JSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdJSRXXδ�󶨵�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleDataUnbound_JSRXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG
            Dim objBLSY As System.Collections.Specialized.NameValueCollection

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleDataUnbound_JSRXX = False
            strErrMsg = ""

            Try
                '��ȡ�ɰ�����
                If Me.m_objsystemFlowObject.getCanDoTaskList(strErrMsg, objBLSY) = False Then
                    GoTo errProc
                End If

                '��ʾδ������
                Dim ddlXBBZ As System.Web.UI.WebControls.DropDownList
                Dim ddlBLSY As System.Web.UI.WebControls.DropDownList
                Dim txtFJDZFS As System.Web.UI.WebControls.TextBox
                Dim txtFJZZFS As System.Web.UI.WebControls.TextBox
                Dim txtWJDZFS As System.Web.UI.WebControls.TextBox
                Dim txtWJZZFS As System.Web.UI.WebControls.TextBox
                Dim txtBLQX As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdJSRXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJSRXX.CurrentPageIndex, Me.grdJSRXX.PageSize)
                    objDataRow = Me.m_objDataSet_JSRXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���[��������]ddlBLSY
                    ddlBLSY = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_ddlBLSY), System.Web.UI.WebControls.DropDownList)
                    If Not (ddlBLSY Is Nothing) Then
                        objControlProcess.doTranslateKey(ddlBLSY)
                        'zengxianglin 2008-06-25
                        'If objDropDownListProcess.doFillData(strErrMsg, ddlBLSY, objBLSY) = False Then
                        '    GoTo errProc
                        'End If
                        If objDropDownListProcess.doFillData(strErrMsg, ddlBLSY, objBLSY, True) = False Then
                            GoTo errProc
                        End If
                        'zengxianglin 2008-06-25

                        'LJ 2008-07-09
                        If objDropDownListProcess.doFillData(strErrMsg, Me.ddlPLBLSY, objBLSY, True) = False Then
                            GoTo errProc
                        End If
                        'LJ 2008-07-09
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY), "")
                        ddlBLSY.SelectedIndex = objDropDownListProcess.getSelectedItem(ddlBLSY, strValue)
                    End If

                    '���[��������]txtBLQX
                    txtBLQX = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtBLQX), System.Web.UI.WebControls.TextBox)
                    If Not (txtBLQX Is Nothing) Then
                        objControlProcess.doTranslateKey(txtBLQX)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLQX), "")
                        If strValue = "" Then
                            txtBLQX.Text = Format(Now.AddDays(3), "yyyy-MM-dd HH:mm:ss")
                        Else
                            txtBLQX.Text = Format(CType(strValue, System.DateTime), "yyyy-MM-dd HH:mm:ss")
                        End If
                    End If

                    '���[ֽ���ļ�����]txtWJZZFS
                    txtWJZZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtWJZZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtWJZZFS Is Nothing) Then
                        objControlProcess.doTranslateKey(txtWJZZFS)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJZZFS), "")
                        If strValue = "" Then
                            txtWJZZFS.Text = "0"
                        Else
                            txtWJZZFS.Text = strValue
                        End If
                    End If

                    '���[�����ļ�����]txtWJDZFS
                    txtWJDZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtWJDZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtWJDZFS Is Nothing) Then
                        objControlProcess.doTranslateKey(txtWJDZFS)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJDZFS), "")
                        If strValue = "" Then
                            txtWJDZFS.Text = "1"
                        Else
                            txtWJDZFS.Text = strValue
                        End If
                    End If

                    '���[ֽ�ʸ�������]txtFJZZFS
                    txtFJZZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtFJZZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtFJZZFS Is Nothing) Then
                        objControlProcess.doTranslateKey(txtFJZZFS)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJZZFS), "")
                        If strValue = "" Then
                            txtFJZZFS.Text = "0"
                        Else
                            txtFJZZFS.Text = strValue
                        End If
                    End If

                    '���[���Ӹ�������]txtFJDZFS
                    txtFJDZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtFJDZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtFJDZFS Is Nothing) Then
                        objControlProcess.doTranslateKey(txtFJDZFS)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJDZFS), "")
                        If strValue = "" Then
                            txtFJDZFS.Text = "1"
                        Else
                            txtFJDZFS.Text = strValue
                        End If
                    End If

                    '���[Э��]ddlXBBZ
                    ddlXBBZ = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_ddlXBBZ), System.Web.UI.WebControls.DropDownList)
                    If Not (ddlXBBZ Is Nothing) Then
                        objControlProcess.doTranslateKey(ddlXBBZ)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_XB), "")
                        If strValue = "" Then strValue = objPulicParameters.CharFalse
                        ddlXBBZ.SelectedIndex = objDropDownListProcess.getSelectedItem(ddlXBBZ, strValue)
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objBLSY)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleDataUnbound_JSRXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objBLSY)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
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

                '��ʾδ������
                If Me.showModuleDataUnbound_JSRXX(strErrMsg) = False Then
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
        ' ��ʾgrdWTXX���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_WTXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_WTXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_WTXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                Me.lblWTXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdWTXX, Me.m_intRows_WTXX) + ")"
                If Me.grdWTXX.Items.Count < 1 Then
                    Me.rblWTXX.Enabled = False
                Else
                    Me.rblWTXX.Enabled = True
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_WTXX = True
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
                    Me.m_blnEditMode = False
                    Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()

                    '��ʾMain
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '����ʾgrdJSRXX
                    If Me.showModuleData_JSRXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ȡ����
                    If Me.getModuleData_WTXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_WTXX(strErrMsg) = False Then
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

                'lj 2008-07-24
                '�Ƿ񵯳����ս���
                If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                    '�״ν���
                    If Me.m_blnEditMode = False Then
                        Me.doSelectRY("btnSelectRY")
                        Me.m_blnEditMode = True
                    End If
                Else
                    If Me.m_strXR = "0" Then
                        Me.doCancel("")
                    End If
                    Me.htxtXRMode.Value = "1"
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
                'If e.Item.ItemIndex < 0 Then
                '    '������,�����������һ������
                '    intCells = e.Item.Cells.Count
                '    For i = 0 To intCells - 1 Step 1
                '        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_JSRXX + ".scrollTop)")
                '    Next
                'End If
                'If Me.m_intFixedColumns_JSRXX > 0 Then
                '    '������
                '    For i = 0 To Me.m_intFixedColumns_JSRXX - 1 Step 1
                '        e.Item.Cells(i).CssClass = Me.grdJSRXX.ID + "Locked"
                '    Next
                'End If
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

                'ͬ����Ϣ
                If Me.getModuleData_WTXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_WTXX(strErrMsg) = False Then
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

        Private Sub grdJSRXX_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdJSRXX.PageIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '����δ������
                If Me.saveModuleDataUnbound_JSRXX(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                '�޸�����
                Me.grdJSRXX.CurrentPageIndex = e.NewPageIndex

                '������ʾ
                If Me.getModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_WTXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_WTXX(strErrMsg) = False Then
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

        Sub grdWTXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdWTXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_WTXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_WTXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_WTXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdWTXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdWTXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdWTXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblWTXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdWTXX, Me.m_intRows_WTXX) + ")"
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

        '----------------------------------------------------------------
        ' ����������ί���ˡ�
        '     strErrMsg      �����ش�����Ϣ
        '     strWTR         ��ί����
        '     strSTR         ��������
        '     blnRefresh     ���Ƿ�ˢ������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doNotSendWTR( _
            ByRef strErrMsg As String, _
            ByVal strWTR As String, _
            ByVal strSTR As String, _
            ByVal blnRefresh As Boolean) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            doNotSendWTR = False
            strErrMsg = ""

            Try
                '���
                If strWTR Is Nothing Then strWTR = ""
                strWTR = strWTR.Trim
                If strSTR Is Nothing Then strSTR = ""
                strSTR = strSTR.Trim

                '��λ
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                With Me.grdJSRXX
                    intRecPos = objDataGridProcess.getRecordPosition(.SelectedIndex, .CurrentPageIndex, .PageSize)
                End With
                With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG)
                    objDataRow = .DefaultView.Item(intRecPos).Row
                End With

                '�ӡ������ˡ��б�ɾ��
                With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG)
                    .Rows.Remove(objDataRow)
                End With

                '������ʾ
                If blnRefresh = True Then
                    If Me.showModuleData_JSRXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_WTXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_WTXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doNotSendWTR = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���strJSR�Ƿ�������б��У�
        '     strErrMsg      �����ش�����Ϣ
        '     strJSR         ��������
        '     blnExisted     �������Ƿ����
        '     intRow         �����أ���������򷵻��ҵ���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function IsJsrExisted( _
            ByRef strErrMsg As String, _
            ByVal strJSR As String, _
            ByRef blnExisted As Boolean, _
            ByRef intRow As Integer) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            IsJsrExisted = False
            strErrMsg = ""
            blnExisted = False
            intRow = -1

            Try
                '���
                If strJSR Is Nothing Then strJSR = ""
                strJSR = strJSR.Trim
                If strJSR = "" Then
                    Exit Try
                End If
                strJSR = strJSR.ToUpper

                '�ж�
                Dim strJSRValue As String
                Dim intCount As Integer
                Dim i As Integer
                With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strJSRValue = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR), "")
                        strJSRValue = strJSRValue.ToUpper
                        If strJSR = strJSRValue Then
                            '�Ѿ�����
                            blnExisted = True
                            intRow = i
                            Exit Try
                        End If
                    Next
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            IsJsrExisted = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��������������ͬʱ����ί���ˡ�
        '     strErrMsg      �����ش�����Ϣ
        '     strWTR         ��ί����
        '     strSTR         ��������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doSendSTR( _
            ByRef strErrMsg As String, _
            ByVal strWTR As String, _
            ByVal strSTR As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            doSendSTR = False
            strErrMsg = ""

            Try
                '���
                If strWTR Is Nothing Then strWTR = ""
                strWTR = strWTR.Trim
                If strSTR Is Nothing Then strSTR = ""
                strSTR = strSTR.Trim
                If strSTR = "" Then
                    Exit Try
                End If

                '��λ
                Dim objDataRow As System.Data.DataRow
                Dim blnExisted As Boolean
                Dim intRecPos As Integer
                If Me.IsJsrExisted(strErrMsg, strSTR, blnExisted, intRecPos) = False Then
                    GoTo errProc
                End If
                If blnExisted = True Then
                    With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG)
                        objDataRow = .Rows(intRecPos)
                    End With
                    '���á�ί���ˡ�
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WTR) = strWTR
                Else
                    '����strSTR���������ˡ��б�
                    With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG)
                        objDataRow = .NewRow()

                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR) = strSTR
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY) = Josco.JSOA.Common.Workflow.BaseFlowObject.TASK_XGCL
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLQX) = Now.AddDays(3)
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FSR) = Me.m_objInterface.iBLR
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FSRQ) = Now
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJZT) = Josco.JSOA.Common.Workflow.BaseFlowObject.FILEZTLX_DZ
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJZZFS) = 0
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJDZFS) = 1
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJZT) = Josco.JSOA.Common.Workflow.BaseFlowObject.FILEZTLX_DZ
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJZZFS) = 0
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJDZFS) = 1
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_SYJB) = 0
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_XB) = Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WTR) = strWTR

                        .Rows.Add(objDataRow)
                    End With
                End If

                '������ʾ
                If Me.showModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_WTXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_WTXX(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doSendSTR = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Sub rblWTXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblWTXX.SelectedIndexChanged

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʼ�����ݼ�
                If Me.getModuleData_WTXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '����������Ϣ
                If Me.saveModuleDataUnbound_JSRXX(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                '��ȡ��Ϣ
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strWTR As String
                Dim strSTR As String
                With Me.grdWTXX
                    intRecPos = objDataGridProcess.getRecordPosition(.SelectedIndex, .CurrentPageIndex, .PageSize)
                End With
                With Me.m_objDataSet_WTXX.Tables(Josco.JsKernal.Common.Data.grswMyLiuyanData.TABLE_GR_B_LIKAILIUYAN)
                    objDataRow = .DefaultView.Item(intRecPos).Row
                End With
                strWTR = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.grswMyLiuyanData.FIELD_GR_B_LIKAILIUYAN_LYR), "")
                strSTR = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.grswMyLiuyanData.FIELD_GR_B_LIKAILIUYAN_WTDLR), "")

                '�������ʹ���
                Select Case Me.rblWTXX.SelectedIndex
                    Case 0
                        '������ί����
                        If Me.doNotSendWTR(strErrMsg, strWTR, strSTR, True) = False Then
                            GoTo errProc
                        End If

                    Case 1
                        '����������ͬʱ����ί����
                        If Me.doSendSTR(strErrMsg, strWTR, strSTR) = False Then
                            GoTo errProc
                        End If

                    Case 2
                        '���������˵�������ί����
                        If Me.doNotSendWTR(strErrMsg, strWTR, strSTR, False) = False Then
                            GoTo errProc
                        End If
                        If Me.doSendSTR(strErrMsg, strWTR, strSTR) = False Then
                            GoTo errProc
                        End If

                    Case Else
                        Exit Try
                End Select

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

        Private Sub doSelectRY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String

            Try
                '������������(��У��)
                If Me.saveModuleDataUnbound_JSRXX(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                '��ȡ��ǰ�����˵�ί����
                Dim strWtrList As String = ""
                If Me.m_objsystemFlowObject.getWeituoren(strErrMsg, Me.m_objInterface.iBLR, strWtrList) = False Then
                    '���Բ��ɹ���
                    strWtrList = ""
                End If

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
                    Select Case Me.m_objsystemFlowObject.FlowData.DDSZ
                        Case 1
                            .iSendRestrict = False              '�رշ�������
                        Case Else
                            .iSendRestrict = True               '���÷�������
                    End Select
                    .iSelectMode = False
                    .iAllowInput = True
                    .iAllowNull = False
                    .iMultiSelect = True
                    .iSelectBMMC = False
                    .iSelectFFFW = False
                    .iRenyuanList = ""
                    .iCurrentBlrDlr = Me.m_objInterface.iDLR    '��ǰ�����˵Ĵ���
                    .iCurrentBlr = Me.m_objInterface.iBLR       '��ǰ������
                    .iWeiTuoRen = strWtrList                    '��strWtrListί�д���

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

        Private Sub doAddFSR(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '������������(��У��)
                If Me.saveModuleDataUnbound_JSRXX(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                '��ȡ���͸��ҡ������з�֪ͨ��Ľ�������
                Dim strSenders As String = ""
                If Me.m_objsystemFlowObject.getSenderList(strErrMsg, Me.m_objInterface.iBLR, strSenders) = False Then
                    GoTo errProc
                End If

                '���뵽�������б�
                If Me.doAddData_JSRXX(strErrMsg, strSenders) = False Then
                    GoTo errProc
                End If

                'ˢ����ʾ
                '��ʾMain
                If Me.showModuleData_Main(strErrMsg) = False Then
                    GoTo errProc
                End If
                '����ʾgrdJSRXX
                If Me.showModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                '��ȡ����
                If Me.getModuleData_WTXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_WTXX(strErrMsg) = False Then
                    GoTo errProc
                End If

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

        Private Sub doDeleteRY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objDataRow As System.Data.DataRow
            Dim intStep As Integer
            Dim intRow As Integer

            Try
                '������������(��У��)
                If Me.saveModuleDataUnbound_JSRXX(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                '���ѡ��
                Dim blnSelected As Boolean
                Dim intSelected As Integer
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdJSRXX.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdJSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX)
                    If blnSelected = True Then
                        intSelected += 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "����δѡ��Ҫɾ���Ľ����ˣ�"
                    GoTo errProc
                End If

                '����Ӻ���ǰɾ��
                intCount = Me.grdJSRXX.Items.Count
                For i = intCount - 1 To 0 Step -1
                    blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdJSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX)
                    If blnSelected = True Then
                        With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG)
                            intRow = objDataGridProcess.getRecordPosition(i, Me.grdJSRXX.CurrentPageIndex, Me.grdJSRXX.PageSize)
                            objDataRow = .DefaultView.Item(intRow).Row
                            .Rows.Remove(objDataRow)
                        End With
                    End If
                Next

                'ˢ����ʾ
                If Me.getModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_WTXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_WTXX(strErrMsg) = False Then
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

        '----------------------------------------------------------------
        ' ���SPR������
        '     strErrMsg      �����ش�����Ϣ
        '     blnVerify      ����ҪУ������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function checkSPR( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim blnVerify As Boolean = True

            checkSPR = False
            strErrMsg = ""

            Try
                '����δ������
                Dim ddlXBBZ As System.Web.UI.WebControls.DropDownList
                Dim ddlBLSY As System.Web.UI.WebControls.DropDownList
                Dim txtFJDZFS As System.Web.UI.WebControls.TextBox
                Dim txtFJZZFS As System.Web.UI.WebControls.TextBox
                Dim txtWJDZFS As System.Web.UI.WebControls.TextBox
                Dim txtWJZZFS As System.Web.UI.WebControls.TextBox
                Dim txtBLQX As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdJSRXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJSRXX.CurrentPageIndex, Me.grdJSRXX.PageSize)
                    objDataRow = Me.m_objDataSet_JSRXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����[��������]ddlBLSY
                    ddlBLSY = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_ddlBLSY), System.Web.UI.WebControls.DropDownList)
                    If Not (ddlBLSY Is Nothing) Then
                        'zengxianglin 2008-06-25
                        'If ddlBLSY.SelectedIndex < 0 Then
                        If ddlBLSY.SelectedIndex < 0 Then
                            'zengxianglin 2008-06-25
                            If blnVerify = True Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��������]û��ָ����"
                                GoTo errProc
                            Else
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY) = ""
                            End If
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY) = ddlBLSY.SelectedValue
                        End If
                    End If

                    '����[��������]txtBLQX
                    txtBLQX = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtBLQX), System.Web.UI.WebControls.TextBox)
                    If Not (txtBLQX Is Nothing) Then
                        If txtBLQX.Text.Trim <> "" Then
                            If objPulicParameters.isDatetimeString(txtBLQX.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��������]����Ч���ڣ�"
                                    GoTo errProc
                                Else
                                    txtBLQX.Text = ""
                                End If
                            Else
                                If CType(txtBLQX.Text, System.DateTime) < Now Then
                                    If blnVerify = True Then
                                        strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��������]�����ǽ����Ժ�"
                                        GoTo errProc
                                    Else
                                        txtBLQX.Text = ""
                                    End If
                                End If
                            End If
                        End If
                        If txtBLQX.Text = "" Then
                            txtBLQX.Text = Format(Now.AddDays(3), "yyyy-MM-dd HH:mm:ss")
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLQX) = CType(txtBLQX.Text, System.DateTime)
                    End If

                    '����[ֽ���ļ�����]txtWJZZFS
                    txtWJZZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtWJZZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtWJZZFS Is Nothing) Then
                        If txtWJZZFS.Text.Trim <> "" Then
                            If objPulicParameters.isIntegerString(txtWJZZFS.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[ֽ���ļ�����]����Ч������"
                                    GoTo errProc
                                Else
                                    txtWJZZFS.Text = ""
                                End If
                            Else
                                If CType(txtWJZZFS.Text, Integer) < 0 Then
                                    If blnVerify = True Then
                                        strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[ֽ���ļ�����]��������>=0��"
                                        GoTo errProc
                                    Else
                                        txtWJZZFS.Text = ""
                                    End If
                                End If
                            End If
                        End If
                        If txtWJZZFS.Text = "" Then
                            txtWJZZFS.Text = "0"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJZZFS) = CType(txtWJZZFS.Text, Integer)
                    End If

                    '����[�����ļ�����]txtWJDZFS
                    txtWJDZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtWJDZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtWJDZFS Is Nothing) Then
                        If txtWJDZFS.Text.Trim <> "" Then
                            If objPulicParameters.isIntegerString(txtWJDZFS.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�����ļ�����]����Ч������"
                                    GoTo errProc
                                Else
                                    txtWJDZFS.Text = ""
                                End If
                            Else
                                If CType(txtWJDZFS.Text, Integer) < 0 Then
                                    If blnVerify = True Then
                                        strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�����ļ�����]��������>=0��"
                                        GoTo errProc
                                    Else
                                        txtWJDZFS.Text = ""
                                    End If
                                End If
                            End If
                        End If
                        If txtWJDZFS.Text = "" Then
                            txtWJDZFS.Text = "1"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJDZFS) = CType(txtWJDZFS.Text, Integer)
                    End If

                    '����[ֽ�ʸ�������]txtFJZZFS
                    txtFJZZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtFJZZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtFJZZFS Is Nothing) Then
                        If txtFJZZFS.Text.Trim <> "" Then
                            If objPulicParameters.isIntegerString(txtFJZZFS.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[ֽ�ʸ�������]����Ч������"
                                    GoTo errProc
                                Else
                                    txtFJZZFS.Text = ""
                                End If
                            Else
                                If CType(txtFJZZFS.Text, Integer) < 0 Then
                                    If blnVerify = True Then
                                        strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[ֽ�ʸ�������]��������>=0��"
                                        GoTo errProc
                                    Else
                                        txtFJZZFS.Text = ""
                                    End If
                                End If
                            End If
                        End If
                        If txtFJZZFS.Text = "" Then
                            txtFJZZFS.Text = "0"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJZZFS) = CType(txtFJZZFS.Text, Integer)
                    End If

                    '����[���Ӹ�������]txtFJDZFS
                    txtFJDZFS = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_txtFJDZFS), System.Web.UI.WebControls.TextBox)
                    If Not (txtFJDZFS Is Nothing) Then
                        If txtFJDZFS.Text.Trim <> "" Then
                            If objPulicParameters.isIntegerString(txtFJDZFS.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[���Ӹ�������]����Ч������"
                                    GoTo errProc
                                Else
                                    txtFJDZFS.Text = ""
                                End If
                            Else
                                If CType(txtFJDZFS.Text, Integer) < 0 Then
                                    If blnVerify = True Then
                                        strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[���Ӹ�������]��������>=0��"
                                        GoTo errProc
                                    Else
                                        txtFJDZFS.Text = ""
                                    End If
                                End If
                            End If
                        End If
                        If txtFJDZFS.Text = "" Then
                            txtFJDZFS.Text = "1"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJDZFS) = CType(txtFJDZFS.Text, Integer)
                    End If

                    '����[Э��]ddlXBBZ
                    ddlXBBZ = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_ddlXBBZ), System.Web.UI.WebControls.DropDownList)
                    If Not (ddlXBBZ Is Nothing) Then
                        If ddlXBBZ.SelectedIndex < 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_XB) = objPulicParameters.CharFalse
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_XB) = ddlXBBZ.SelectedValue
                        End If
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

            checkSPR = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        Private Sub doSend(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objLastZJBJiaojieDataSet As Josco.JSOA.Common.Data.FlowData
            Dim strAddedJJXHList As String = ""
            Dim intStep As Integer

            Try
                '��ʼ����
                Dim blnCanSend As Boolean
                Dim strPrompt As String
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    ''���������
                    'If checkSPR(strErrMsg) = False Then
                    '    GoTo errProc
                    'End If

                    '������������(У��)
                    If Me.saveModuleDataUnbound_JSRXX(strErrMsg, True) = False Then
                        GoTo errProc
                    End If

                    '�������񼶱�
                    If Me.doComputeTaskLevel(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    'ɾ��������+����������ͬ�Ľ�����Ϣ
                    If Me.doDeleteInvalidJSR(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��鵱ǰ��Ա�Ƿ���Է��͸�ѡ��������
                    If Me.doCheckSendRestrict(strErrMsg, blnCanSend, strPrompt) = False Then
                        GoTo errProc
                    End If
                    If blnCanSend = False Then
                        strErrMsg = strPrompt
                        GoTo errProc
                    End If
                End If

                'ֽ���ļ�����
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.m_objsystemFlowObject.isAutoReceive(strErrMsg, Me.m_objInterface.iBLR, blnCanSend) = False Then
                        GoTo errProc
                    End If
                    If blnCanSend = True Then
                        '�Զ������ļ��������Ƿ��Ѿ��յ�ֽ���ļ�?
                        If Me.m_objsystemFlowObject.isReceiveZhizhi(strErrMsg, Me.m_objInterface.iBLR, blnCanSend) = False Then
                            GoTo errProc
                        End If
                        If blnCanSend = True Then
                            objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ֽ���ļ��͸����������û���յ�ֽ���ļ������ܷ��ͣ���ȷ���Ѿ��յ�ֽ���ļ�����/�񣩣�", strControlId, intStep)
                            Exit Try
                        End If
                    End If
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                'ѯ��
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ���������������󣬲������ð�����Ѱ���������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                Dim intDQSYJB As Integer = 0
                Dim intYJJH As Integer = 0
                Dim strBLSY As String = ""
                intStep = 4
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ��ǰ�����˵����δ��Ľ�������
                    Dim strBLR As String = Me.m_objInterface.iBLR
                    If Me.m_objsystemFlowObject.getLastZJBJiaojieData(strErrMsg, Me.m_objInterface.iBLR, objLastZJBJiaojieDataSet) = False Then
                        GoTo errProc
                    End If
                    With objLastZJBJiaojieDataSet.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                        If .Rows.Count > 0 Then
                            intYJJH = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJXH), 0)
                            strBLSY = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZL), "")
                        End If
                    End With
                    If Not (objLastZJBJiaojieDataSet Is Nothing) Then
                        objLastZJBJiaojieDataSet.Dispose()
                        objLastZJBJiaojieDataSet = Nothing
                    End If
                    If strBLSY <> "" Then
                        If Me.m_objsystemFlowObject.getTaskLevel(strErrMsg, strBLSY, intDQSYJB) = False Then
                            GoTo errProc
                        End If
                    End If

                    '��ȡ����ǰ���Ľ������
                    Dim intMaxJJXH As Integer = 0
                    If Me.m_objsystemFlowObject.getMaxJJXH(strErrMsg, intMaxJJXH) = False Then
                        GoTo errProc
                    End If

                    '���㷢����ţ������η��͵Ľ��ӵķ������һ�£�
                    Dim strFSXH As String = ""
                    If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                        GoTo errProc
                    End If

                    '���͡����ӵ���
                    If Me.m_objsystemFlowObject.doSend(strErrMsg, Me.m_objDataSet_JSRXX, strFSXH, intYJJH.ToString, intDQSYJB, strAddedJJXHList) = False Then
                        GoTo errRollData
                    End If

                    '֪ͨԭ������(�����ġ�֪ͨ)
                    If Me.cblFSXX.Items(0).Selected = True Then
                        If Me.m_objsystemFlowObject.doSendReply(strErrMsg, Me.m_objInterface.iBLR, intMaxJJXH, strFSXH, strAddedJJXHList) = False Then
                            GoTo errRollData
                        End If
                    End If

                    '���ߺ���Ҫ��������
                    If Me.cblFSXX.Items(1).Selected = True Then
                        If Me.m_objsystemFlowObject.doSetTaskBWTX(strErrMsg, Me.m_objInterface.iBLR, True) = False Then
                            GoTo errRollData
                        End If
                    End If

                    '�����Լ���δ�������Ѱ���
                    If Me.m_objsystemFlowObject.doSetTaskComplete(strErrMsg, Me.m_objInterface.iBLR, strAddedJJXHList) = False Then
                        GoTo errRollData
                    End If

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
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objLastZJBJiaojieDataSet)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errRollData:
            Dim strTempMsg As String = ""
            If Me.m_objsystemFlowObject.doDeleteJiaojie(strTempMsg, strAddedJJXHList) = False Then
                '�޷��ָ���
            End If
            GoTo errProc

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objLastZJBJiaojieDataSet)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doPLTJSY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objDataRow As System.Data.DataRow
            Dim ddlBLSY As System.Web.UI.WebControls.DropDownList
            Dim intStep As Integer
            Dim intRow As Integer
            Dim intPLSY As Integer

            Try

                '���ѡ��
                Dim blnSelected As Boolean
                Dim intSelected As Integer
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdJSRXX.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdJSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX)
                    If blnSelected = True Then
                        intSelected += 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "����δѡ��Ҫɾ���Ľ����ˣ�"
                    GoTo errProc
                End If


                Select Case Me.ddlPLBLSY.SelectedIndex
                    Case -1, 0
                        strErrMsg = "����δѡ��Ҫ������ӵ����ˣ�"
                        GoTo errProc
                    Case Else
                        intPLSY = Me.ddlPLBLSY.SelectedIndex
                End Select

                '����Ӻ���ǰ���
                intCount = Me.grdJSRXX.Items.Count
                For i = intCount - 1 To 0 Step -1
                    blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdJSRXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX)
                    If blnSelected = True Then
                        ddlBLSY = CType(Me.grdJSRXX.Items(i).FindControl(Me.m_cstrControlId_JSRXX_ddlBLSY), System.Web.UI.WebControls.DropDownList)
                        ddlBLSY.SelectedIndex = intPLSY
                    End If
                Next

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

        Private Sub doSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdJSRXX, 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX, True) = False Then
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

        Private Sub doDeSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdJSRXX, 0, Me.m_cstrCheckBoxIdInDataGrid_JSRXX, False) = False Then
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

        Private Sub doMoveNext(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJSRXX.CurrentPageIndex + 1, Me.grdJSRXX.PageCount)
                Me.grdJSRXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_JSRXX(strErrMsg) = False Then
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

        Private Sub doMovePrevious(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_JSRXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJSRXX.CurrentPageIndex - 1, Me.grdJSRXX.PageCount)
                Me.grdJSRXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_JSRXX(strErrMsg) = False Then
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

        Private Sub btnSelectRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectRY.Click
            Me.doSelectRY("btnSelectRY")
        End Sub

        Private Sub btnDeleteRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteRY.Click
            Me.doDeleteRY("btnDeleteRY")
        End Sub

        Private Sub btnAddFSR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddFSR.Click
            Me.doAddFSR("btnAddFSR")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
            Me.doSend("btnSend")
        End Sub

        Private Sub btnPLTJSY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPLTJSY.Click
            Me.doPLTJSY("btnPLTJSY")
        End Sub

        Private Sub lnkSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSelectAll.Click
            Me.doSelectAll("lnkSelectAll")
        End Sub

        Private Sub lnkDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDeSelectAll.Click
            Me.doDeSelectAll("lnkDeSelectAll")
        End Sub

        Private Sub lnkMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMoveNext.Click
            Me.doMoveNext("lnkMoveNext")
        End Sub

        Private Sub lnkMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMovePrev.Click
            Me.doMovePrevious("lnkMovePrev")
        End Sub


    End Class

End Namespace
