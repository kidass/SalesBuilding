Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_cuiban
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �����������ļ��Ĵ߰�����
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowCuiban����
    '----------------------------------------------------------------

    Public Class flow_cuiban
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblKCBXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdKCBXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblYCBXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdYCBXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnOK As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtKCBXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSessionIdKCBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKCBXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKCBXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKCBXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKCBXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtKCBXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtYCBXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftKCBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopKCBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftYCBXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopYCBXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowCuiban
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowCuiban
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_KCBXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_KCBXX As String '��¼m_objDataSet_KCBXX������
        Private m_intRows_KCBXX As Integer '��¼m_objDataSet_KCBXX��DefaultView��¼��
        Private m_objDataSet_YCBXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_YCBXX As String '��¼m_objDataSet_YCBXX������
        Private m_intRows_YCBXX As Integer '��¼m_objDataSet_YCBXX��DefaultView��¼��

        '----------------------------------------------------------------
        '����������grdKCBXX��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrControlId_KCBXX_txtCBRQ As String = "txtCBRQ"
        Private Const m_cstrControlId_KCBXX_txtCBSM As String = "txtCBSM"
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_KCBXX As String = "chkKCBXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_KCBXX As String = "divKCBXX"
        '����Ҫ����������
        Private m_intFixedColumns_KCBXX As Integer

        '----------------------------------------------------------------
        '����������grdYCBXX��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_YCBXX As String = "chkYCBXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_YCBXX As String = "divYCBXX"
        '����Ҫ����������
        Private m_intFixedColumns_YCBXX As Integer

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
                    Me.htxtDivLeftKCBXX.Value = .htxtDivLeftKCBXX
                    Me.htxtDivTopKCBXX.Value = .htxtDivTopKCBXX
                    Me.htxtDivLeftYCBXX.Value = .htxtDivLeftYCBXX
                    Me.htxtDivTopYCBXX.Value = .htxtDivTopYCBXX

                    Me.htxtKCBXXQuery.Value = .htxtKCBXXQuery
                    Me.htxtKCBXXRows.Value = .htxtKCBXXRows
                    Me.htxtKCBXXSort.Value = .htxtKCBXXSort
                    Me.htxtKCBXXSortColumnIndex.Value = .htxtKCBXXSortColumnIndex
                    Me.htxtKCBXXSortType.Value = .htxtKCBXXSortType

                    Me.htxtYCBXXQuery.Value = .htxtYCBXXQuery
                    Me.htxtYCBXXRows.Value = .htxtYCBXXRows
                    Me.htxtYCBXXSort.Value = .htxtYCBXXSort
                    Me.htxtYCBXXSortColumnIndex.Value = .htxtYCBXXSortColumnIndex
                    Me.htxtYCBXXSortType.Value = .htxtYCBXXSortType

                    Me.htxtSessionIdKCBXX.Value = .htxtSessionIdKCBXX
                    Try
                        Me.grdKCBXX.PageSize = .grdKCBXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdKCBXX.CurrentPageIndex = .grdKCBXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdKCBXX.SelectedIndex = .grdKCBXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdYCBXX.PageSize = .grdYCBXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYCBXX.CurrentPageIndex = .grdYCBXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYCBXX.SelectedIndex = .grdYCBXX_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowCuiban

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftKCBXX = Me.htxtDivLeftKCBXX.Value
                    .htxtDivTopKCBXX = Me.htxtDivTopKCBXX.Value
                    .htxtDivLeftYCBXX = Me.htxtDivLeftYCBXX.Value
                    .htxtDivTopYCBXX = Me.htxtDivTopYCBXX.Value

                    .htxtKCBXXQuery = Me.htxtKCBXXQuery.Value
                    .htxtKCBXXRows = Me.htxtKCBXXRows.Value
                    .htxtKCBXXSort = Me.htxtKCBXXSort.Value
                    .htxtKCBXXSortColumnIndex = Me.htxtKCBXXSortColumnIndex.Value
                    .htxtKCBXXSortType = Me.htxtKCBXXSortType.Value

                    .htxtYCBXXQuery = Me.htxtYCBXXQuery.Value
                    .htxtYCBXXRows = Me.htxtYCBXXRows.Value
                    .htxtYCBXXSort = Me.htxtYCBXXSort.Value
                    .htxtYCBXXSortColumnIndex = Me.htxtYCBXXSortColumnIndex.Value
                    .htxtYCBXXSortType = Me.htxtYCBXXSortType.Value

                    .htxtSessionIdKCBXX = Me.htxtSessionIdKCBXX.Value
                    .grdKCBXX_PageSize = Me.grdKCBXX.PageSize
                    .grdKCBXX_CurrentPageIndex = Me.grdKCBXX.CurrentPageIndex
                    .grdKCBXX_SelectedIndex = Me.grdKCBXX.SelectedIndex

                    .grdYCBXX_PageSize = Me.grdYCBXX.PageSize
                    .grdYCBXX_CurrentPageIndex = Me.grdYCBXX.CurrentPageIndex
                    .grdYCBXX_SelectedIndex = Me.grdYCBXX.SelectedIndex

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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowCuiban)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowCuiban)
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
                Me.m_intFixedColumns_KCBXX = objPulicParameters.getObjectValue(Me.htxtKCBXXFixed.Value, 0)
                Me.m_intRows_KCBXX = objPulicParameters.getObjectValue(Me.htxtKCBXXRows.Value, 0)
                Me.m_strQuery_KCBXX = Me.htxtKCBXXQuery.Value

                Me.m_intFixedColumns_YCBXX = objPulicParameters.getObjectValue(Me.htxtYCBXXFixed.Value, 0)
                Me.m_intRows_YCBXX = objPulicParameters.getObjectValue(Me.htxtYCBXXRows.Value, 0)
                Me.m_strQuery_YCBXX = Me.htxtYCBXXQuery.Value

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
                If Me.htxtSessionIdKCBXX.Value.Trim <> "" Then
                    Dim objFlowData As Josco.JSOA.Common.Data.FlowData
                    Try
                        objFlowData = CType(Session(Me.htxtSessionIdKCBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        objFlowData = Nothing
                    End Try
                    If Not (objFlowData Is Nothing) Then
                        objFlowData.Dispose()
                        objFlowData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdKCBXX.Value)
                    Me.htxtSessionIdKCBXX.Value = ""
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
        ' ��ȡ�ɴ߰���Ϣ���ݼ�
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_KCBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            getModuleData_KCBXX = False

            Try
                '�ӻ����ȡ����
                If Me.htxtSessionIdKCBXX.Value.Trim <> "" Then
                    Try
                        Me.m_objDataSet_KCBXX = CType(Session(Me.htxtSessionIdKCBXX.Value), Josco.JSOA.Common.Data.FlowData)
                    Catch ex As Exception
                        Me.m_objDataSet_KCBXX = Nothing
                    End Try
                End If

                '����ȱʡ����
                If Me.m_objDataSet_KCBXX Is Nothing Then
                    If Me.m_objsystemFlowObject.getKeCuibanData(strErrMsg, Me.m_objInterface.iBLR, Me.m_objDataSet_KCBXX) = False Then
                        GoTo errProc
                    End If
                End If

                '�������ݼ�
                If Me.htxtSessionIdKCBXX.Value.Trim <> "" Then
                    Session.Remove(Me.htxtSessionIdKCBXX.Value)
                Else
                    Me.htxtSessionIdKCBXX.Value = objPulicParameters.getNewGuid()
                End If
                Session.Add(Me.htxtSessionIdKCBXX.Value, Me.m_objDataSet_KCBXX)

                '�������
                With Me.m_objDataSet_KCBXX.Tables(strTable)
                    Me.htxtKCBXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_KCBXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_KCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ�Ѵ߰���Ϣ���ݼ�
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_YCBXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE

            getModuleData_YCBXX = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtYCBXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                If Not (Me.m_objDataSet_YCBXX Is Nothing) Then
                    Me.m_objDataSet_YCBXX.Dispose()
                    Me.m_objDataSet_YCBXX = Nothing
                End If

                '���¼�������
                If Me.m_objsystemFlowObject.getCuibanData(strErrMsg, Me.m_objInterface.iBLR, Me.m_objDataSet_YCBXX) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_YCBXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_YCBXX.Tables(strTable)
                    Me.htxtYCBXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_YCBXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_YCBXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdKCBXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_KCBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE

            showDataGridInfo_KCBXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtKCBXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtKCBXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_KCBXX Is Nothing Then
                    Me.grdKCBXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_KCBXX.Tables(strTable)
                        Me.grdKCBXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_KCBXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdKCBXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdKCBXX)
                    With Me.grdKCBXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdKCBXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdKCBXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_KCBXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_KCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdYCBXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_YCBXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE

            showDataGridInfo_YCBXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtYCBXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtYCBXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_YCBXX Is Nothing Then
                    Me.grdYCBXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YCBXX.Tables(strTable)
                        Me.grdYCBXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_YCBXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYCBXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdYCBXX)
                    With Me.grdYCBXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdYCBXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYCBXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_YCBXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_YCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdKCBXXδ�󶨵�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnVerify      ����ҪУ������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveModuleDataUnbound_KCBXX( _
            ByRef strErrMsg As String, _
            ByVal blnVerify As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveModuleDataUnbound_KCBXX = False
            strErrMsg = ""

            Try
                '����δ������
                Dim txtCBSM As System.Web.UI.WebControls.TextBox
                Dim txtCBRQ As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdKCBXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKCBXX.CurrentPageIndex, Me.grdKCBXX.PageSize)
                    objDataRow = Me.m_objDataSet_KCBXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����[�߰�����]txtCBRQ
                    txtCBRQ = CType(Me.grdKCBXX.Items(i).FindControl(Me.m_cstrControlId_KCBXX_txtCBRQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtCBRQ Is Nothing) Then
                        If txtCBRQ.Text.Trim <> "" Then
                            If objPulicParameters.isDatetimeString(txtCBRQ.Text) = False Then
                                If blnVerify = True Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�߰�����]����Ч���ڣ�"
                                    GoTo errProc
                                Else
                                    txtCBRQ.Text = ""
                                End If
                            End If
                        End If
                        If txtCBRQ.Text = "" Then
                            txtCBRQ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBRQ) = CType(txtCBRQ.Text, System.DateTime)
                    End If

                    '����[�߰�˵��]txtCBSM
                    txtCBSM = CType(Me.grdKCBXX.Items(i).FindControl(Me.m_cstrControlId_KCBXX_txtCBSM), System.Web.UI.WebControls.TextBox)
                    If Not (txtCBSM Is Nothing) Then
                        If txtCBSM.Text = "" Then
                            txtCBSM.Text = "�뾡�����"
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBSM) = txtCBSM.Text
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveModuleDataUnbound_KCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdKCBXXδ�󶨵�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleDataUnbound_KCBXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleDataUnbound_KCBXX = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim txtCBSM As System.Web.UI.WebControls.TextBox
                Dim txtCBRQ As System.Web.UI.WebControls.TextBox
                Dim objDataRow As System.Data.DataRow
                Dim intRecPos As Integer
                Dim strValue As String
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdKCBXX.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKCBXX.CurrentPageIndex, Me.grdKCBXX.PageSize)
                    objDataRow = Me.m_objDataSet_KCBXX.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���[�߰�����]txtCBRQ
                    txtCBRQ = CType(Me.grdKCBXX.Items(i).FindControl(Me.m_cstrControlId_KCBXX_txtCBRQ), System.Web.UI.WebControls.TextBox)
                    If Not (txtCBRQ Is Nothing) Then
                        objControlProcess.doTranslateKey(txtCBRQ)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBRQ), "")
                        If strValue = "" Then
                            txtCBRQ.Text = Format(Now, "yyyy-MM-dd HH:mm:ss")
                        Else
                            txtCBRQ.Text = Format(CType(strValue, System.DateTime), "yyyy-MM-dd HH:mm:ss")
                        End If
                    End If

                    '���[�߰�˵��]txtCBSM
                    txtCBSM = CType(Me.grdKCBXX.Items(i).FindControl(Me.m_cstrControlId_KCBXX_txtCBSM), System.Web.UI.WebControls.TextBox)
                    If Not (txtCBSM Is Nothing) Then
                        objControlProcess.doTranslateKey(txtCBSM)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBSM), "")
                        If strValue = "" Then
                            txtCBSM.Text = "�뾡�����"
                        Else
                            txtCBSM.Text = strValue
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

            showModuleDataUnbound_KCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdKCBXX���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_KCBXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_KCBXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_KCBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾδ������
                If Me.showModuleDataUnbound_KCBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                Me.lblKCBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdKCBXX, Me.m_intRows_KCBXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_KCBXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdYCBXX���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_YCBXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_YCBXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_YCBXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                Me.lblYCBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdYCBXX, Me.m_intRows_YCBXX) + ")"

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_YCBXX = True
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

                    '����ʾgrdKCBXX
                    If Me.showModuleData_KCBXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ȡ����
                    If Me.getModuleData_YCBXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_YCBXX(strErrMsg) = False Then
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
                If Me.getModuleData_KCBXX(strErrMsg) = False Then
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
        Sub grdKCBXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdKCBXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_KCBXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_KCBXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_KCBXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdKCBXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdKCBXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdKCBXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblKCBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdKCBXX, Me.m_intRows_KCBXX) + ")"

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

        Private Sub grdKCBXX_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdKCBXX.PageIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '����δ������
                If Me.saveModuleDataUnbound_KCBXX(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                '�޸�����
                Me.grdKCBXX.CurrentPageIndex = e.NewPageIndex

                '������ʾ
                If Me.getModuleData_KCBXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_KCBXX(strErrMsg) = False Then
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

        Sub grdYCBXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYCBXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_YCBXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_YCBXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_YCBXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYCBXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdYCBXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdYCBXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblYCBXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdYCBXX, Me.m_intRows_YCBXX) + ")"
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
                    If Me.saveModuleDataUnbound_KCBXX(strErrMsg, True) = False Then
                        GoTo errProc
                    End If

                    '���ѡ��
                    intCount = Me.grdKCBXX.Items.Count
                    intSelected = 0
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdKCBXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_KCBXX)
                        If blnSelected = True Then
                            '����
                            intSelected += 1
                            '��ȡ���ݼ�¼
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKCBXX.CurrentPageIndex, Me.grdKCBXX.PageSize)
                            With Me.m_objDataSet_KCBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With
                            '��ȡ���߰���
                            strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_BCBR), "")
                            If strUserList = "" Then
                                strUserList = strValue
                            Else
                                strUserList = strUserList + objPulicParameters.CharSeparate + strValue
                            End If
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "����δѡ��Ҫ�߰����Ա��"
                        GoTo errProc
                    End If

                    'ѯ��
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ����[" + strUserList + "]�����߰�֪ͨ����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                Dim strField As String
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����߰�
                    intCount = Me.grdKCBXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdKCBXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_KCBXX)
                        If blnSelected = True Then
                            '��ȡ���ݼ�¼
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdKCBXX.CurrentPageIndex, Me.grdKCBXX.PageSize)
                            With Me.m_objDataSet_KCBXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CUIBAN_JIAOJIE)
                                objDataRow = .DefaultView.Item(intRecPos).Row
                            End With
                            '׼������
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_WJBS
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_JJXH
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), "0"))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBXH
                            objNewData.Add(strField, "") '�Զ�����
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBR
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBRQ
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_BCBR
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            strField = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CUIBAN_CBSM
                            objNewData.Add(strField, objPulicParameters.getObjectValue(objDataRow.Item(strField), ""))
                            '����֪ͨ
                            If Me.m_objsystemFlowObject.doSaveCuiban(strErrMsg, Nothing, objNewData) = False Then
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
