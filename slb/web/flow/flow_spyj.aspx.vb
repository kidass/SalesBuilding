Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_spyj
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   ������鿴��ת�������
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowSpyj����
    '----------------------------------------------------------------

    Public Class flow_spyj
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZSPYJDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZSPYJSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZSPYJMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZSPYJMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZSPYJMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZSPYJMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZSPYJGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSPYJPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZSPYJSetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtSPYJPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblSPYJGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents txtSPYJSearch_JSR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSPYJSearch_DLR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSPYJSearch_BLSY As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSPYJSearch_QPRQMin As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSPYJSearch_QPRQMax As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnSPYJSearch As System.Web.UI.WebControls.Button
        Protected WithEvents grdSPYJ As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtSPYJFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSessionIdQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSPYJQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSPYJRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSPYJSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSPYJSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSPYJSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftSPYJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopSPYJ As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowSpyj
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowSpyj
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdSPYJ��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_SPYJ As String = "chkSPYJ"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_SPYJ As String = "divSPYJ"
        '����Ҫ����������
        Private m_intFixedColumns_SPYJ As Integer

        '----------------------------------------------------------------
        'Ҫ���ʵ�����
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_SPYJ As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_SPYJ As String '��¼m_objDataSet_SPYJ������
        Private m_intRows_SPYJ As Integer '��¼m_objDataSet_SPYJ��DefaultView��¼��












        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtSPYJQuery.Value = .htxtSPYJQuery
                    Me.htxtSPYJRows.Value = .htxtSPYJRows
                    Me.htxtSPYJSort.Value = .htxtSPYJSort
                    Me.htxtSPYJSortColumnIndex.Value = .htxtSPYJSortColumnIndex
                    Me.htxtSPYJSortType.Value = .htxtSPYJSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftSPYJ.Value = .htxtDivLeftSPYJ
                    Me.htxtDivTopSPYJ.Value = .htxtDivTopSPYJ

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtSPYJPageIndex.Text = .txtSPYJPageIndex
                    Me.txtSPYJPageSize.Text = .txtSPYJPageSize

                    Me.txtSPYJSearch_DLR.Text = .txtSPYJSearch_DLR
                    Me.txtSPYJSearch_JSR.Text = .txtSPYJSearch_JSR
                    Me.txtSPYJSearch_BLSY.Text = .txtSPYJSearch_BLSY
                    Me.txtSPYJSearch_QPRQMin.Text = .txtSPYJSearch_QPRQMin
                    Me.txtSPYJSearch_QPRQMax.Text = .txtSPYJSearch_QPRQMax

                    Try
                        Me.grdSPYJ.PageSize = .grdSPYJPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSPYJ.CurrentPageIndex = .grdSPYJCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSPYJ.SelectedIndex = .grdSPYJSelectedIndex
                    Catch ex As Exception
                    End Try
                End With

                '�ͷ���Դ
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ����ģ���ֳ���Ϣ��������Ӧ��SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess

            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '����SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then Exit Try

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowSpyj

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtSPYJQuery = Me.htxtSPYJQuery.Value
                    .htxtSPYJRows = Me.htxtSPYJRows.Value
                    .htxtSPYJSort = Me.htxtSPYJSort.Value
                    .htxtSPYJSortColumnIndex = Me.htxtSPYJSortColumnIndex.Value
                    .htxtSPYJSortType = Me.htxtSPYJSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftSPYJ = Me.htxtDivLeftSPYJ.Value
                    .htxtDivTopSPYJ = Me.htxtDivTopSPYJ.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtSPYJPageIndex = Me.txtSPYJPageIndex.Text
                    .txtSPYJPageSize = Me.txtSPYJPageSize.Text

                    .txtSPYJSearch_DLR = Me.txtSPYJSearch_DLR.Text
                    .txtSPYJSearch_JSR = Me.txtSPYJSearch_JSR.Text
                    .txtSPYJSearch_BLSY = Me.txtSPYJSearch_BLSY.Text
                    .txtSPYJSearch_QPRQMin = Me.txtSPYJSearch_QPRQMin.Text
                    .txtSPYJSearch_QPRQMax = Me.txtSPYJSearch_QPRQMax.Text

                    .grdSPYJPageSize = Me.grdSPYJ.PageSize
                    .grdSPYJCurrentPageIndex = Me.grdSPYJ.CurrentPageIndex
                    .grdSPYJSelectedIndex = Me.grdSPYJ.SelectedIndex
                End With

                '�������
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' �ӵ���ģ���л�ȡ����
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.IsPostBack = True Then Exit Try

                '==========================================================================================================================================================
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                        Me.htxtSPYJQuery.Value = objISjcxCxtj.oQueryString
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
        ' �ͷŽӿڲ���
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
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowSpyj)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowSpyj)
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

                '��ȡ�ֲ��ӿڲ���
                Me.m_intFixedColumns_SPYJ = objPulicParameters.getObjectValue(Me.htxtSPYJFixed.Value, 0)
                Me.m_intRows_SPYJ = objPulicParameters.getObjectValue(Me.htxtSPYJRows.Value, 0)
                Me.m_strQuery_SPYJ = Me.htxtSPYJQuery.Value

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
        ' �ͷű�ģ�黺��Ĳ���
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
        ' ��ȡgrdSPYJ����������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_SPYJ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess

            getQueryString_SPYJ = False
            strQuery = ""

            Try
                '���������ˡ�����
                Dim strDLR As String
                strDLR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIYIJIAN_DLR
                If Me.txtSPYJSearch_DLR.Text.Length > 0 Then Me.txtSPYJSearch_DLR.Text = Me.txtSPYJSearch_DLR.Text.Trim()
                If Me.txtSPYJSearch_DLR.Text <> "" Then
                    Me.txtSPYJSearch_DLR.Text = objPulicParameters.getNewSearchString(Me.txtSPYJSearch_DLR.Text)
                    If strQuery = "" Then
                        strQuery = strDLR + " like '" + Me.txtSPYJSearch_DLR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strDLR + " like '" + Me.txtSPYJSearch_DLR.Text + "%'"
                    End If
                End If

                '���������ˡ�����
                Dim strJSR As String
                strJSR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIYIJIAN_JSR
                If Me.txtSPYJSearch_JSR.Text.Length > 0 Then Me.txtSPYJSearch_JSR.Text = Me.txtSPYJSearch_JSR.Text.Trim()
                If Me.txtSPYJSearch_JSR.Text <> "" Then
                    Me.txtSPYJSearch_JSR.Text = objPulicParameters.getNewSearchString(Me.txtSPYJSearch_JSR.Text)
                    If strQuery = "" Then
                        strQuery = strJSR + " like '" + Me.txtSPYJSearch_JSR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJSR + " like '" + Me.txtSPYJSearch_JSR.Text + "%'"
                    End If
                End If

                '�����������ˡ�����
                Dim strBLSY As String
                strBLSY = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIYIJIAN_BLZL
                If Me.txtSPYJSearch_BLSY.Text.Length > 0 Then Me.txtSPYJSearch_BLSY.Text = Me.txtSPYJSearch_BLSY.Text.Trim()
                If Me.txtSPYJSearch_BLSY.Text <> "" Then
                    Me.txtSPYJSearch_BLSY.Text = objPulicParameters.getNewSearchString(Me.txtSPYJSearch_BLSY.Text)
                    If strQuery = "" Then
                        strQuery = strBLSY + " like '" + Me.txtSPYJSearch_BLSY.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strBLSY + " like '" + Me.txtSPYJSearch_BLSY.Text + "%'"
                    End If
                End If

                '�����������ڡ�����
                Dim strBLRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strBLRQ = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIYIJIAN_BLRQ
                If Me.txtSPYJSearch_QPRQMin.Text.Length > 0 Then Me.txtSPYJSearch_QPRQMin.Text = Me.txtSPYJSearch_QPRQMin.Text.Trim()
                If Me.txtSPYJSearch_QPRQMax.Text.Length > 0 Then Me.txtSPYJSearch_QPRQMax.Text = Me.txtSPYJSearch_QPRQMax.Text.Trim()
                If Me.txtSPYJSearch_QPRQMin.Text <> "" And Me.txtSPYJSearch_QPRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSPYJSearch_QPRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtSPYJSearch_QPRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtSPYJSearch_QPRQMin.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                        Me.txtSPYJSearch_QPRQMax.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    Else
                        Me.txtSPYJSearch_QPRQMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                        Me.txtSPYJSearch_QPRQMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    End If
                    If strQuery = "" Then
                        strQuery = strBLRQ + " between '" + Me.txtSPYJSearch_QPRQMin.Text + "' and '" + Me.txtSPYJSearch_QPRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strBLRQ + " between '" + Me.txtSPYJSearch_QPRQMin.Text + "' and '" + Me.txtSPYJSearch_QPRQMax.Text + "'"
                    End If
                ElseIf Me.txtSPYJSearch_QPRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSPYJSearch_QPRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtSPYJSearch_QPRQMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strBLRQ + " >= '" + Me.txtSPYJSearch_QPRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strBLRQ + " >= '" + Me.txtSPYJSearch_QPRQMin.Text + "'"
                    End If
                ElseIf Me.txtSPYJSearch_QPRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtSPYJSearch_QPRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtSPYJSearch_QPRQMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strBLRQ + " <= '" + Me.txtSPYJSearch_QPRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strBLRQ + " <= '" + Me.txtSPYJSearch_QPRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_SPYJ = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdSPYJҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_SPYJ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIYIJIAN

            getModuleData_SPYJ = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtSPYJSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                If Not (Me.m_objDataSet_SPYJ Is Nothing) Then
                    Me.m_objDataSet_SPYJ.Dispose()
                    Me.m_objDataSet_SPYJ = Nothing
                End If

                '���¼�������
                If Me.m_objsystemFlowObject.getOpinionData(strErrMsg, Me.m_objInterface.iBLR, strWhere, Me.m_objDataSet_SPYJ) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_SPYJ.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_SPYJ.Tables(strTable)
                    Me.htxtSPYJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_SPYJ = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_SPYJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdSPYJ����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_SPYJ(ByRef strErrMsg As String) As Boolean

            searchModuleData_SPYJ = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_SPYJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_SPYJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_SPYJ = strQuery
                Me.htxtSPYJQuery.Value = Me.m_strQuery_SPYJ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_SPYJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdSPYJ������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SPYJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIYIJIAN

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_SPYJ = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtSPYJSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtSPYJSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_SPYJ Is Nothing Then
                    Me.grdSPYJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SPYJ.Tables(strTable)
                        Me.grdSPYJ.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_SPYJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSPYJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdSPYJ)
                    With Me.grdSPYJ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdSPYJ.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSPYJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_SPYJ) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SPYJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdSPYJ�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_SPYJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIYIJIAN

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_SPYJ = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_SPYJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_SPYJ.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblSPYJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdSPYJ, .Count)

                    '��ʾҳ���������
                    Me.lnkCZSPYJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdSPYJ, .Count)
                    Me.lnkCZSPYJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdSPYJ, .Count)
                    Me.lnkCZSPYJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdSPYJ, .Count)
                    Me.lnkCZSPYJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdSPYJ, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZSPYJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZSPYJSelectAll.Enabled = blnEnabled
                    Me.lnkCZSPYJGotoPage.Enabled = blnEnabled
                    Me.lnkCZSPYJSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_SPYJ = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾģ�鼶�Ĳ���״̬
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN(ByRef strErrMsg As String) As Boolean

            showModuleData_MAIN = False

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_MAIN = True
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

            '���ڵ�һ�ε���ҳ��ʱִ��
            If Me.IsPostBack = False Then
                '��ʾPannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                Try
                    objControlProcess.doTranslateKey(Me.txtSPYJPageIndex)
                    objControlProcess.doTranslateKey(Me.txtSPYJPageSize)
                    objControlProcess.doTranslateKey(Me.txtSPYJSearch_JSR)
                    objControlProcess.doTranslateKey(Me.txtSPYJSearch_DLR)
                    objControlProcess.doTranslateKey(Me.txtSPYJSearch_BLSY)
                    objControlProcess.doTranslateKey(Me.txtSPYJSearch_QPRQMin)
                    objControlProcess.doTranslateKey(Me.txtSPYJSearch_QPRQMax)
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��ʾģ�鼶����
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ����
                If Me.m_blnSaveScence = False Then
                    Me.txtSPYJSearch_JSR.Text = Me.m_objInterface.iSPR
                    If Me.searchModuleData_SPYJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    If Me.getModuleData_SPYJ(strErrMsg, Me.m_strQuery_SPYJ) = False Then
                        GoTo errProc
                    End If
                End If
                If Me.showModuleData_SPYJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            End If

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

            'Ԥ����
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '��ȡ�ӿڲ���
            Dim blnDo As Boolean
            If Me.getInterfaceParameters(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then GoTo normExit

            '�ؼ���ʼ��
            If Me.initializeControls(strErrMsg) = False Then
                GoTo errProc
            End If

            '��¼���������־
            If Me.IsPostBack = False Then
                If Me.m_blnSaveScence = False Then
                    If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]��[����������]��") = False Then
                        '����
                    End If
                End If
            End If
normExit:
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
        'ʵ�ֶ�grdSPYJ�����С��еĹ̶�
        Sub grdSPYJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSPYJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_SPYJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_SPYJ > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_SPYJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSPYJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdSPYJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSPYJ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblSPYJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdSPYJ, Me.m_intRows_SPYJ)
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

        Private Sub grdSPYJ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdSPYJ.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIYIJIAN

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String
                Dim strOldCommand As String
                Dim strUniqueId As String
                Dim intColumnIndex As Integer

                '��ȡ����
                If Me.getModuleData_SPYJ(strErrMsg, Me.m_strQuery_SPYJ) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_SPYJ.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_SPYJ.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtSPYJSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtSPYJSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtSPYJSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_SPYJ(strErrMsg) = False Then
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




        Private Sub doMoveFirst_SPYJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_SPYJ(strErrMsg, Me.m_strQuery_SPYJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdSPYJ.PageCount)
                Me.grdSPYJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_SPYJ(strErrMsg) = False Then
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

        Private Sub doMoveLast_SPYJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_SPYJ(strErrMsg, Me.m_strQuery_SPYJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSPYJ.PageCount - 1, Me.grdSPYJ.PageCount)
                Me.grdSPYJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_SPYJ(strErrMsg) = False Then
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

        Private Sub doMoveNext_SPYJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_SPYJ(strErrMsg, Me.m_strQuery_SPYJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSPYJ.CurrentPageIndex + 1, Me.grdSPYJ.PageCount)
                Me.grdSPYJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_SPYJ(strErrMsg) = False Then
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

        Private Sub doMovePrevious_SPYJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_SPYJ(strErrMsg, Me.m_strQuery_SPYJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSPYJ.CurrentPageIndex - 1, Me.grdSPYJ.PageCount)
                Me.grdSPYJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_SPYJ(strErrMsg) = False Then
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

        Private Sub doGotoPage_SPYJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtSPYJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_SPYJ(strErrMsg, Me.m_strQuery_SPYJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdSPYJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_SPYJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtSPYJPageIndex.Text = (Me.grdSPYJ.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_SPYJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtSPYJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_SPYJ(strErrMsg, Me.m_strQuery_SPYJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdSPYJ.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_SPYJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtSPYJPageSize.Text = (Me.grdSPYJ.PageSize).ToString()

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

        Private Sub doSelectAll_SPYJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdSPYJ, 0, Me.m_cstrCheckBoxIdInDataGrid_SPYJ, True) = False Then
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

        Private Sub doDeSelectAll_SPYJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdSPYJ, 0, Me.m_cstrCheckBoxIdInDataGrid_SPYJ, False) = False Then
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

        Private Sub doSearch_SPYJ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_SPYJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_SPYJ(strErrMsg) = False Then
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

        Private Sub lnkCZSPYJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSPYJMoveFirst.Click
            Me.doMoveFirst_SPYJ("lnkCZSPYJMoveFirst")
        End Sub

        Private Sub lnkCZSPYJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSPYJMoveLast.Click
            Me.doMoveLast_SPYJ("lnkCZSPYJMoveLast")
        End Sub

        Private Sub lnkCZSPYJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSPYJMoveNext.Click
            Me.doMoveNext_SPYJ("lnkCZSPYJMoveNext")
        End Sub

        Private Sub lnkCZSPYJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSPYJMovePrev.Click
            Me.doMovePrevious_SPYJ("lnkCZSPYJMovePrev")
        End Sub

        Private Sub lnkCZSPYJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSPYJGotoPage.Click
            Me.doGotoPage_SPYJ("lnkCZSPYJGotoPage")
        End Sub

        Private Sub lnkCZSPYJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSPYJSetPageSize.Click
            Me.doSetPageSize_SPYJ("lnkCZSPYJSetPageSize")
        End Sub

        Private Sub lnkCZSPYJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSPYJSelectAll.Click
            Me.doSelectAll_SPYJ("lnkCZSPYJSelectAll")
        End Sub

        Private Sub lnkCZSPYJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSPYJDeSelectAll.Click
            Me.doDeSelectAll_SPYJ("lnkCZSPYJDeSelectAll")
        End Sub

        Private Sub btnSPYJSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSPYJSearch.Click
            Me.doSearch_SPYJ("btnSPYJSearch")
        End Sub



        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
        Private Sub doClose(ByVal strControlId As String)

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

        Private Sub doSearchFull(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIYIJIAN

            Try
                '��ȡ����
                If Me.getModuleData_SPYJ(strErrMsg, Me.m_strQuery_SPYJ) = False Then
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
                    .iQueryTable = Me.m_objDataSet_SPYJ.Tables(strTable)
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

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.doSearchFull("btnSearch")
        End Sub

    End Class

End Namespace
