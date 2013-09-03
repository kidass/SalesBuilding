Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_xgwjlj_add
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �������ļ����������ӡ��޸ġ�ɾ�����鿴�������Ȳ���
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowFujian����
    '----------------------------------------------------------------

    Public Class flow_xgwjlj_add
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILESelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFILEGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtFILEPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZFILESetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtFILEPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblFILEGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents txtFILESearch_NDMIN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFILESearch_NDMAX As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFILESearch_LSH As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFILESearch_WJBT As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFILESearch_WJZH As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFILESearch_ZBDW As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnFILEFullSearch As System.Web.UI.WebControls.Button
        Protected WithEvents btnFILESearch As System.Web.UI.WebControls.Button
        Protected WithEvents grdFILE As System.Web.UI.WebControls.DataGrid
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtFILEFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFILEQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFILERows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFILESort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFILESortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFILESortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftFILE As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopFILE As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents btnOK As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents btnOpenFile As System.Web.UI.WebControls.Button
        Protected WithEvents htxtSessionIdQuery As System.Web.UI.HtmlControls.HtmlInputHidden

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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowXgwjljAdd
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowXgwjljAdd
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_FILE As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_FILE As String '��¼m_objDataSet_FILE������
        Private m_intRows_FILE As Integer '��¼m_objDataSet_FILE��DefaultView��¼��

        '----------------------------------------------------------------
        '����������grdFILE��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_FILE As String = "chkFILE"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_FILE As String = "divFILE"
        '����Ҫ����������
        Private m_intFixedColumns_FILE As Integer

        '----------------------------------------------------------------
        'ģ����������
        '----------------------------------------------------------------









        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    '*********************************************************************
                    Me.txtFILEPageIndex.Text = .txtFILEPageIndex
                    Me.txtFILEPageSize.Text = .txtFILEPageSize
                    '*********************************************************************
                    Me.txtFILESearch_NDMIN.Text = .txtFILESearch_NDMIN
                    Me.txtFILESearch_NDMAX.Text = .txtFILESearch_NDMAX
                    Me.txtFILESearch_LSH.Text = .txtFILESearch_LSH
                    Me.txtFILESearch_WJBT.Text = .txtFILESearch_WJBT
                    Me.txtFILESearch_WJZH.Text = .txtFILESearch_WJZH
                    Me.txtFILESearch_ZBDW.Text = .txtFILESearch_ZBDW
                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery
                    '*********************************************************************
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftFILE.Value = .htxtDivLeftFILE
                    Me.htxtDivTopFILE.Value = .htxtDivTopFILE
                    '*********************************************************************
                    Me.htxtFILEQuery.Value = .htxtFILEQuery
                    Me.htxtFILERows.Value = .htxtFILERows
                    Me.htxtFILESort.Value = .htxtFILESort
                    Me.htxtFILESortColumnIndex.Value = .htxtFILESortColumnIndex
                    Me.htxtFILESortType.Value = .htxtFILESortType
                    '*********************************************************************
                    Try
                        Me.grdFILE.PageSize = .grdFILE_PageSize
                        Me.grdFILE.SelectedIndex = .grdFILE_SelectedIndex
                        Me.grdFILE.CurrentPageIndex = .grdFILE_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    '*********************************************************************
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowXgwjljAdd

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    '*********************************************************************
                    .txtFILEPageIndex = Me.txtFILEPageIndex.Text
                    .txtFILEPageSize = Me.txtFILEPageSize.Text
                    '*********************************************************************
                    .txtFILESearch_NDMIN = Me.txtFILESearch_NDMIN.Text
                    .txtFILESearch_NDMAX = Me.txtFILESearch_NDMAX.Text
                    .txtFILESearch_LSH = Me.txtFILESearch_LSH.Text
                    .txtFILESearch_WJBT = Me.txtFILESearch_WJBT.Text
                    .txtFILESearch_WJZH = Me.txtFILESearch_WJZH.Text
                    .txtFILESearch_ZBDW = Me.txtFILESearch_ZBDW.Text
                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value
                    '*********************************************************************
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftFILE = Me.htxtDivLeftFILE.Value
                    .htxtDivTopFILE = Me.htxtDivTopFILE.Value
                    '*********************************************************************
                    .htxtFILEQuery = Me.htxtFILEQuery.Value
                    .htxtFILERows = Me.htxtFILERows.Value
                    .htxtFILESort = Me.htxtFILESort.Value
                    .htxtFILESortColumnIndex = Me.htxtFILESortColumnIndex.Value
                    .htxtFILESortType = Me.htxtFILESortType.Value
                    '*********************************************************************
                    .grdFILE_PageSize = Me.grdFILE.PageSize
                    .grdFILE_SelectedIndex = Me.grdFILE.SelectedIndex
                    .grdFILE_CurrentPageIndex = Me.grdFILE.CurrentPageIndex
                    '*********************************************************************
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.IsPostBack = True Then Exit Try

                '=================================================================
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                        Me.htxtFILEQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQuery.Value.Trim = "" Then
                            Me.htxtSessionIdQuery.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            If Not (objQueryData Is Nothing) Then
                                objQueryData.Dispose()
                                objQueryData = Nothing
                            End If
                        End If
                        Session.Add(Me.htxtSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
                    End If
                    '�ͷ���Դ
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objISjcxCxtj.Dispose()
                    objISjcxCxtj = Nothing
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowXgwjljAdd)
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

                '��ʼ������������
                If Me.doInitializeWorkflow(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowXgwjljAdd)
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
                Me.m_intFixedColumns_FILE = objPulicParameters.getObjectValue(Me.htxtFILEFixed.Value, 0)
                Me.m_intRows_FILE = objPulicParameters.getObjectValue(Me.htxtFILERows.Value, 0)
                Me.m_strQuery_FILE = Me.htxtFILEQuery.Value

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
                If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    If Not (objQueryData Is Nothing) Then
                        objQueryData.Dispose()
                        objQueryData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdQuery.Value)
                    Me.htxtSessionIdQuery.Value = ""
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

                '��ʼ��������
                Dim strWJBS As String = Me.m_objInterface.iWJBS
                If Me.m_objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
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
        ' ��ȡ������Ϣ���ݼ�
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_FILE( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            getModuleData_FILE = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtFILESort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '��ȡ����
                If Not (Me.m_objDataSet_FILE Is Nothing) Then
                    Me.m_objDataSet_FILE.Dispose()
                    Me.m_objDataSet_FILE = Nothing
                End If
                If Me.m_objsystemFlowObject.getWorkflowFileData(strErrMsg, MyBase.UserXM, strWhere, Me.m_objDataSet_FILE) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_FILE.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_FILE.Tables(strTable)
                    Me.htxtFILERows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_FILE = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_FILE = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdFILE����������(RowFilter��ʽ)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_FILE( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_FILE = False
            strQuery = ""

            Try
                '���������
                Dim strFWJND As String
                Dim intMin As Integer
                Dim intMax As Integer
                strFWJND = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJND
                If Me.txtFILESearch_NDMIN.Text.Length > 0 Then Me.txtFILESearch_NDMIN.Text = Me.txtFILESearch_NDMIN.Text.Trim()
                If Me.txtFILESearch_NDMAX.Text.Length > 0 Then Me.txtFILESearch_NDMAX.Text = Me.txtFILESearch_NDMAX.Text.Trim()
                If Me.txtFILESearch_NDMIN.Text <> "" And Me.txtFILESearch_NDMAX.Text <> "" Then
                    Try
                        intMin = CType(Me.txtFILESearch_NDMIN.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "����[" + Me.txtFILESearch_NDMIN.Text + "]������Ч���֣�"
                        GoTo errProc
                    End Try
                    Try
                        intMax = CType(Me.txtFILESearch_NDMAX.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "����[" + Me.txtFILESearch_NDMAX.Text + "]������Ч���֣�"
                        GoTo errProc
                    End Try
                    If intMin > intMax Then
                        Me.txtFILESearch_NDMIN.Text = intMax.ToString
                        Me.txtFILESearch_NDMAX.Text = intMin.ToString
                    Else
                        Me.txtFILESearch_NDMIN.Text = intMin.ToString
                        Me.txtFILESearch_NDMAX.Text = intMax.ToString
                    End If
                    If strQuery = "" Then
                        strQuery = strFWJND + " between " + Me.txtFILESearch_NDMIN.Text + " and " + Me.txtFILESearch_NDMAX.Text
                    Else
                        strQuery = strQuery + " and " + strFWJND + " between " + Me.txtFILESearch_NDMIN.Text + " and " + Me.txtFILESearch_NDMAX.Text
                    End If
                ElseIf Me.txtFILESearch_NDMIN.Text <> "" Then
                    Try
                        intMin = CType(Me.txtFILESearch_NDMIN.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "����[" + Me.txtFILESearch_NDMIN.Text + "]������Ч���֣�"
                        GoTo errProc
                    End Try
                    Me.txtFILESearch_NDMIN.Text = intMin.ToString
                    If strQuery = "" Then
                        strQuery = strFWJND + " >= " + Me.txtFILESearch_NDMIN.Text
                    Else
                        strQuery = strQuery + " and " + strFWJND + " >= " + Me.txtFILESearch_NDMIN.Text
                    End If
                ElseIf Me.txtFILESearch_NDMAX.Text <> "" Then
                    Try
                        intMax = CType(Me.txtFILESearch_NDMAX.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "����[" + Me.txtFILESearch_NDMAX.Text + "]������Ч���֣�"
                        GoTo errProc
                    End Try
                    Me.txtFILESearch_NDMAX.Text = intMax.ToString
                    If strQuery = "" Then
                        strQuery = strFWJND + " <= " + Me.txtFILESearch_NDMAX.Text
                    Else
                        strQuery = strQuery + " and " + strFWJND + " <= " + Me.txtFILESearch_NDMAX.Text
                    End If
                Else
                End If

                '����ˮ������
                Dim strLSH As String
                strLSH = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_LSH
                If Me.txtFILESearch_LSH.Text.Length > 0 Then Me.txtFILESearch_LSH.Text = Me.txtFILESearch_LSH.Text.Trim()
                If Me.txtFILESearch_LSH.Text <> "" Then
                    'Me.txtFILESearch_LSH.Text = objPulicParameters.getNewSearchString(Me.txtFILESearch_LSH.Text)
                    If strQuery = "" Then
                        strQuery = strLSH + " like '" + Me.txtFILESearch_LSH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strLSH + " like '" + Me.txtFILESearch_LSH.Text + "%'"
                    End If
                End If

                '���ļ���������
                Dim strWJBT As String
                strWJBT = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBT
                If Me.txtFILESearch_WJBT.Text.Length > 0 Then Me.txtFILESearch_WJBT.Text = Me.txtFILESearch_WJBT.Text.Trim()
                If Me.txtFILESearch_WJBT.Text <> "" Then
                    Me.txtFILESearch_WJBT.Text = objPulicParameters.getNewSearchString(Me.txtFILESearch_WJBT.Text)
                    If strQuery = "" Then
                        strQuery = strWJBT + " like '" + Me.txtFILESearch_WJBT.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWJBT + " like '" + Me.txtFILESearch_WJBT.Text + "%'"
                    End If
                End If

                '���ļ��ֺ�����
                Dim strWJZH As String
                strWJZH = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJZH
                If Me.txtFILESearch_WJZH.Text.Length > 0 Then Me.txtFILESearch_WJZH.Text = Me.txtFILESearch_WJZH.Text.Trim()
                If Me.txtFILESearch_WJZH.Text <> "" Then
                    'Me.txtFILESearch_WJZH.Text = objPulicParameters.getNewSearchString(Me.txtFILESearch_WJZH.Text)
                    If strQuery = "" Then
                        strQuery = strWJZH + " like '" + Me.txtFILESearch_WJZH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWJZH + " like '" + Me.txtFILESearch_WJZH.Text + "%'"
                    End If
                End If

                '�����쵥λ����
                Dim strZBDW As String
                strZBDW = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_ZSDW
                If Me.txtFILESearch_ZBDW.Text.Length > 0 Then Me.txtFILESearch_ZBDW.Text = Me.txtFILESearch_ZBDW.Text.Trim()
                If Me.txtFILESearch_ZBDW.Text <> "" Then
                    'Me.txtFILESearch_ZBDW.Text = objPulicParameters.getNewSearchString(Me.txtFILESearch_ZBDW.Text)
                    If strQuery = "" Then
                        strQuery = strZBDW + " like '" + Me.txtFILESearch_ZBDW.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strZBDW + " like '" + Me.txtFILESearch_ZBDW.Text + "%'"
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_FILE = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdFILE����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_FILE(ByRef strErrMsg As String) As Boolean

            searchModuleData_FILE = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_FILE(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_FILE(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_FILE = strQuery
                Me.htxtFILEQuery.Value = Me.m_strQuery_FILE

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_FILE = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdFILE������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_FILE( _
            ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            showDataGridInfo_FILE = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtFILESortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtFILESortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_FILE Is Nothing Then
                    Me.grdFILE.DataSource = Nothing
                Else
                    With Me.m_objDataSet_FILE.Tables(strTable)
                        Me.grdFILE.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_FILE.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdFILE, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdFILE)
                    With Me.grdFILE.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdFILE.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdFILE, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_FILE) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_FILE = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdFILE���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_FILE(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            showModuleData_FILE = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_FILE.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblFILEGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdFILE, .Count)

                    '��ʾҳ���������
                    Me.lnkCZFILEMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdFILE, .Count)
                    Me.lnkCZFILEMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdFILE, .Count)
                    Me.lnkCZFILEMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdFILE, .Count)
                    Me.lnkCZFILEMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdFILE, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZFILEDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZFILESelectAll.Enabled = blnEnabled
                    Me.lnkCZFILEGotoPage.Enabled = blnEnabled
                    Me.lnkCZFILESetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_FILE = True
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
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String) As Boolean

            showModuleData_Main = False

            Try
                '��ʾ����
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ����

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

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    '****************************************************************
                    objControlProcess.doTranslateKey(Me.txtFILEPageIndex)
                    objControlProcess.doTranslateKey(Me.txtFILEPageSize)
                    '****************************************************************
                    objControlProcess.doTranslateKey(Me.txtFILESearch_NDMIN)
                    objControlProcess.doTranslateKey(Me.txtFILESearch_NDMAX)
                    objControlProcess.doTranslateKey(Me.txtFILESearch_LSH)
                    objControlProcess.doTranslateKey(Me.txtFILESearch_WJBT)
                    objControlProcess.doTranslateKey(Me.txtFILESearch_WJZH)
                    objControlProcess.doTranslateKey(Me.txtFILESearch_ZBDW)
                    '****************************************************************

                    '��ʾ����
                    If Me.m_blnSaveScence = False Then
                        'ȱʡ���2���ļ�
                        Me.txtFILESearch_NDMIN.Text = (Year(Now) - 1).ToString
                        Me.txtFILESearch_NDMAX.Text = Year(Now).ToString
                        If Me.searchModuleData_FILE(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                            GoTo errProc
                        End If
                    End If
                    If Me.showModuleData_Main(strErrMsg) = False Then
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
        '�����¼�������
        '----------------------------------------------------------------
        'ʵ�ֶ�grdFILE�����С��еĹ̶�
        Sub grdFILE_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdFILE.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_FILE + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_FILE > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_FILE - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdFILE.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ���ļ�
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�����ؼ�ID
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doOpenFile( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim strISessionId As String = ""
            Dim strMSessionId As String = ""
            Dim strUrl As String

            doOpenFile = False

            Try
                '��鵱ǰѡ��
                If Me.grdFILE.SelectedIndex < 0 Then
                    strErrMsg = "����û�е�ǰ�ļ���"
                    GoTo errProc
                End If

                '��ȡ�ļ���ʶ���ļ�����
                Dim strFlowTypeName As String
                Dim strWJBS As String
                Dim intColIndex(2) As Integer
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBS)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJLX)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(Me.grdFILE.SelectedIndex), intColIndex(0))
                strFlowTypeName = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(Me.grdFILE.SelectedIndex), intColIndex(1))
                If strWJBS = "" Then
                    strErrMsg = "����û�е�ǰ�ļ���"
                    GoTo errProc
                End If
                If strFlowTypeName = "" Then
                    strErrMsg = "���󣺵�ǰ�ļ����Ͳ���ȷ��"
                    GoTo errProc
                End If
                If strWJBS.ToUpper = Me.m_objInterface.iWJBS Then
                    strErrMsg = "���󣺲��ܴ��ļ�����"
                    GoTo errProc
                End If

                '����ָ������������
                Dim strType As String
                Dim strName As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If
                strISessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)

                '����Url
                If objsystemFlowObject.doFileOpen( _
                    strErrMsg, _
                    strControlId, _
                    strWJBS, _
                    strMSessionId, _
                    strISessionId, _
                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect, _
                    Request, Session, _
                    strUrl) = False Then
                    GoTo errProc
                End If
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doOpenFile = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Sub grdFILE_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFILE.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '��λ
                Me.grdFILE.SelectedIndex = e.Item.ItemIndex

                '����
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        If Me.doOpenFile(strErrMsg, strControlId) = False Then
                            GoTo errProc
                        End If
                    Case Else
                End Select

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

        Private Sub grdFILE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFILE.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                With New Josco.JsKernal.web.DataGridProcess
                    Me.lblFILEGridLocInfo.Text = .getDataGridLocation(Me.grdFILE, Me.m_intRows_FILE)
                End With
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

        Private Sub grdFILE_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdFILE.SortCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String
                Dim strOldCommand As String
                Dim strUniqueId As String
                Dim intColumnIndex As Integer

                '��ȡ����
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_FILE.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_FILE.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtFILESortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtFILESortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtFILESort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_FILE(strErrMsg) = False Then
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




        Private Sub doMoveFirst_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_FILE(strErrMsg) = False Then
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

        Private Sub doMoveLast_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFILE.PageCount - 1, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_FILE(strErrMsg) = False Then
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

        Private Sub doMoveNext_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFILE.CurrentPageIndex + 1, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_FILE(strErrMsg) = False Then
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

        Private Sub doMovePrevious_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFILE.CurrentPageIndex - 1, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_FILE(strErrMsg) = False Then
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

        Private Sub doGotoPage_FILE(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtFILEPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdFILE.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtFILEPageIndex.Text = (Me.grdFILE.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_FILE(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtFILEPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdFILE.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtFILEPageSize.Text = (Me.grdFILE.PageSize).ToString()

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

        Private Sub doSelectAll_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdFILE, 0, Me.m_cstrCheckBoxIdInDataGrid_FILE, True) = False Then
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

        Private Sub doDeSelectAll_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdFILE, 0, Me.m_cstrCheckBoxIdInDataGrid_FILE, False) = False Then
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

        Private Sub doSearch_FILE(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_FILE(strErrMsg) = False Then
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

        Private Sub doSearchFull_FILE(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW

            Try
                '��ȡ����
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_FILE.Tables(strTable)
                    .iFixQuery = ""

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

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objISjcxCxtj)
                strUrl = ""
                strUrl += "../sjcx/sjcx_cxtj.aspx"
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

        Private Sub lnkCZFILEMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMoveFirst.Click
            Me.doMoveFirst_FILE("lnkCZFILEMoveFirst")
        End Sub

        Private Sub lnkCZFILEMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMoveLast.Click
            Me.doMoveLast_FILE("lnkCZFILEMoveLast")
        End Sub

        Private Sub lnkCZFILEMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMovePrev.Click
            Me.doMovePrevious_FILE("lnkCZFILEMovePrev")
        End Sub

        Private Sub lnkCZFILEMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMoveNext.Click
            Me.doMoveNext_FILE("lnkCZFILEMoveNext")
        End Sub

        Private Sub lnkCZFILESetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILESetPageSize.Click
            Me.doSetPageSize_FILE("lnkCZFILESetPageSize")
        End Sub

        Private Sub lnkCZFILEGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEGotoPage.Click
            Me.doGotoPage_FILE("lnkCZFILEGotoPage")
        End Sub

        Private Sub lnkCZFILESelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILESelectAll.Click
            Me.doSelectAll_FILE("lnkCZFILESelectAll")
        End Sub

        Private Sub lnkCZFILEDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEDeSelectAll.Click
            Me.doDeSelectAll_FILE("lnkCZFILEDeSelectAll")
        End Sub

        Private Sub btnFILESearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFILESearch.Click
            Me.doSearch_FILE("btnFILESearch")
        End Sub

        Private Sub btnFILEFullSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFILEFullSearch.Click
            Me.doSearchFull_FILE("btnFILEFullSearch")
        End Sub




        Private Sub doOK(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Try
                '����Ƿ�ѡ���ˣ�
                Dim blnSelected As Boolean
                Dim intSelected As Integer
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdFILE.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE)
                    If blnSelected = True Then
                        intSelected += 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "����δѡ��Ҫ���뵽�����е��ļ���"
                    GoTo errProc
                End If

                '��ȡ����
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '���뵽������
                Dim intLJBS As Integer = Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FlowFile
                Dim objSrcDataRow As System.Data.DataRow
                Dim objDataRow As System.Data.DataRow
                Dim strNewFilter As String
                Dim strOldFilter As String
                Dim intMaxXSXH As Integer
                Dim strNewWJBS As String
                Dim strOldWJBS As String
                Dim intColIndex As Integer
                Dim intRecPos As Integer
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBS)
                intCount = Me.grdFILE.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE)
                    If blnSelected = True Then
                        '��ȡҪ������ļ���ʶ
                        strNewWJBS = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex)
                        If strNewWJBS.ToUpper <> Me.m_objInterface.iWJBS.ToUpper Then
                            '�ж��Ƿ����
                            With Me.m_objInterface.iDataSet_XGWJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN)
                                '����ԭ��������
                                strOldFilter = .DefaultView.RowFilter

                                '����
                                strNewFilter = ""
                                strNewFilter = strNewFilter + "     " + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBS + "='" + strNewWJBS + "'"
                                strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS + "= " + intLJBS.ToString
                                .DefaultView.RowFilter = strNewFilter
                                If .DefaultView.Count > 0 Then
                                    blnSelected = True
                                Else
                                    blnSelected = False
                                End If

                                '�ָ���������
                                .DefaultView.RowFilter = strOldFilter
                            End With
                        Else
                            blnSelected = True '�Լ����ܼ��룡
                        End If

                        '���뵽������
                        With Me.m_objInterface.iDataSet_XGWJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN)
                            If blnSelected = False Then
                                intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdFILE.CurrentPageIndex, Me.grdFILE.PageSize)
                                With Me.m_objDataSet_FILE.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_V_SHENPIWENJIAN_NEW).DefaultView
                                    objSrcDataRow = .Item(intRecPos).Row
                                End With

                                If .DefaultView.Count < 1 Then
                                    intMaxXSXH = 0
                                Else
                                    intMaxXSXH = objPulicParameters.getObjectValue(.DefaultView.Item(.DefaultView.Count - 1).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH), 0)
                                End If

                                objDataRow = .NewRow

                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS) = intLJBS
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH) = intMaxXSXH + 1
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJXH) = 0
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS) = 0
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ) = ""
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = ""
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XZBZ) = 0
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBS) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBS)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LSH) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_LSH)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJLX) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJLX)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BLLX) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_BLLX)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJZL) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJZL)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BLZT) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_BLZT)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJBT)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_ZSDW) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_ZSDW)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_JGDZ) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_JGDZ)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJNF) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJNF)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJXH) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJXH)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJND) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_WJND)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_ZBDW) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_ZBDW)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_ZTC) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_ZTC)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_NGR) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_NGR)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_NGRQ) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_NGRQ)
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_KSSW) = objSrcDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_V_SHENPIWENJIAN_NEW_KSSW)

                                .Rows.Add(objDataRow)
                            End If
                        End With
                    End If
                Next

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

        Private Sub doOpenFile(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doOpenFile(strErrMsg, strControlId) = False Then
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

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnOpenFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpenFile.Click
            Me.doOpenFile("btnOpenFile")
        End Sub

    End Class

End Namespace
