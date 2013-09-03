Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_byqk
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   ������鿴�����������
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowByqk����
    '----------------------------------------------------------------

    Public Class flow_byqk
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZBYQKGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtBYQKPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZBYQKSetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtBYQKPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblBYQKGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents txtBYQKSearch_FSR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBYQKSearch_JSR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBYQKSearch_BLSY As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBYQKSearch_WCRQMin As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBYQKSearch_WCRQMax As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnBYQKSearch As System.Web.UI.WebControls.Button
        Protected WithEvents grdBYQK As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtBYQKFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBYQKQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBYQKRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBYQKSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBYQKSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtBYQKSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBYQK As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBYQK As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowByqk
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowByqk
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdBYQK��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_BYQK As String = "chkBYQK"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_BYQK As String = "divBYQK"
        '����Ҫ����������
        Private m_intFixedColumns_BYQK As Integer

        '----------------------------------------------------------------
        'Ҫ���ʵ�����
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_BYQK As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_BYQK As String '��¼m_objDataSet_BYQK������
        Private m_intRows_BYQK As Integer '��¼m_objDataSet_BYQK��DefaultView��¼��









        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtBYQKQuery.Value = .htxtBYQKQuery
                    Me.htxtBYQKRows.Value = .htxtBYQKRows
                    Me.htxtBYQKSort.Value = .htxtBYQKSort
                    Me.htxtBYQKSortColumnIndex.Value = .htxtBYQKSortColumnIndex
                    Me.htxtBYQKSortType.Value = .htxtBYQKSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftBYQK.Value = .htxtDivLeftBYQK
                    Me.htxtDivTopBYQK.Value = .htxtDivTopBYQK

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtBYQKPageIndex.Text = .txtBYQKPageIndex
                    Me.txtBYQKPageSize.Text = .txtBYQKPageSize

                    Me.txtBYQKSearch_FSR.Text = .txtBYQKSearch_FSR
                    Me.txtBYQKSearch_JSR.Text = .txtBYQKSearch_JSR
                    Me.txtBYQKSearch_BLSY.Text = .txtBYQKSearch_BLSY
                    Me.txtBYQKSearch_WCRQMin.Text = .txtBYQKSearch_WCRQMin
                    Me.txtBYQKSearch_WCRQMax.Text = .txtBYQKSearch_WCRQMax

                    Try
                        Me.grdBYQK.PageSize = .grdBYQKPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBYQK.CurrentPageIndex = .grdBYQKCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBYQK.SelectedIndex = .grdBYQKSelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowByqk

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtBYQKQuery = Me.htxtBYQKQuery.Value
                    .htxtBYQKRows = Me.htxtBYQKRows.Value
                    .htxtBYQKSort = Me.htxtBYQKSort.Value
                    .htxtBYQKSortColumnIndex = Me.htxtBYQKSortColumnIndex.Value
                    .htxtBYQKSortType = Me.htxtBYQKSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftBYQK = Me.htxtDivLeftBYQK.Value
                    .htxtDivTopBYQK = Me.htxtDivTopBYQK.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtBYQKPageIndex = Me.txtBYQKPageIndex.Text
                    .txtBYQKPageSize = Me.txtBYQKPageSize.Text

                    .txtBYQKSearch_FSR = Me.txtBYQKSearch_FSR.Text
                    .txtBYQKSearch_JSR = Me.txtBYQKSearch_JSR.Text
                    .txtBYQKSearch_BLSY = Me.txtBYQKSearch_BLSY.Text
                    .txtBYQKSearch_WCRQMin = Me.txtBYQKSearch_WCRQMin.Text
                    .txtBYQKSearch_WCRQMax = Me.txtBYQKSearch_WCRQMax.Text

                    .grdBYQKPageSize = Me.grdBYQK.PageSize
                    .grdBYQKCurrentPageIndex = Me.grdBYQK.CurrentPageIndex
                    .grdBYQKSelectedIndex = Me.grdBYQK.SelectedIndex
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
                        Me.htxtBYQKQuery.Value = objISjcxCxtj.oQueryString
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowByqk)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowByqk)
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
                Me.m_intFixedColumns_BYQK = objPulicParameters.getObjectValue(Me.htxtBYQKFixed.Value, 0)
                Me.m_intRows_BYQK = objPulicParameters.getObjectValue(Me.htxtBYQKRows.Value, 0)
                Me.m_strQuery_BYQK = Me.htxtBYQKQuery.Value

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
        ' ��ȡgrdBYQK����������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_BYQK( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess

            getQueryString_BYQK = False
            strQuery = ""

            Try
                '���������ˡ�����
                Dim strFSR As String
                strFSR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_FSR
                If Me.txtBYQKSearch_FSR.Text.Length > 0 Then Me.txtBYQKSearch_FSR.Text = Me.txtBYQKSearch_FSR.Text.Trim()
                If Me.txtBYQKSearch_FSR.Text <> "" Then
                    Me.txtBYQKSearch_FSR.Text = objPulicParameters.getNewSearchString(Me.txtBYQKSearch_FSR.Text)
                    If strQuery = "" Then
                        strQuery = strFSR + " like '" + Me.txtBYQKSearch_FSR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strFSR + " like '" + Me.txtBYQKSearch_FSR.Text + "%'"
                    End If
                End If

                '���������ˡ�����
                Dim strJSR As String
                strJSR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JSR
                If Me.txtBYQKSearch_JSR.Text.Length > 0 Then Me.txtBYQKSearch_JSR.Text = Me.txtBYQKSearch_JSR.Text.Trim()
                If Me.txtBYQKSearch_JSR.Text <> "" Then
                    Me.txtBYQKSearch_JSR.Text = objPulicParameters.getNewSearchString(Me.txtBYQKSearch_JSR.Text)
                    If strQuery = "" Then
                        strQuery = strJSR + " like '" + Me.txtBYQKSearch_JSR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJSR + " like '" + Me.txtBYQKSearch_JSR.Text + "%'"
                    End If
                End If

                '�����������ˡ�����
                Dim strBLSY As String
                strBLSY = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZL
                If Me.txtBYQKSearch_BLSY.Text.Length > 0 Then Me.txtBYQKSearch_BLSY.Text = Me.txtBYQKSearch_BLSY.Text.Trim()
                If Me.txtBYQKSearch_BLSY.Text <> "" Then
                    Me.txtBYQKSearch_BLSY.Text = objPulicParameters.getNewSearchString(Me.txtBYQKSearch_BLSY.Text)
                    If strQuery = "" Then
                        strQuery = strBLSY + " like '" + Me.txtBYQKSearch_BLSY.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strBLSY + " like '" + Me.txtBYQKSearch_BLSY.Text + "%'"
                    End If
                End If

                '����������ڡ�����
                Dim strWCRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strWCRQ = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_WCRQ
                If Me.txtBYQKSearch_WCRQMin.Text.Length > 0 Then Me.txtBYQKSearch_WCRQMin.Text = Me.txtBYQKSearch_WCRQMin.Text.Trim()
                If Me.txtBYQKSearch_WCRQMax.Text.Length > 0 Then Me.txtBYQKSearch_WCRQMax.Text = Me.txtBYQKSearch_WCRQMax.Text.Trim()
                If Me.txtBYQKSearch_WCRQMin.Text <> "" And Me.txtBYQKSearch_WCRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtBYQKSearch_WCRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtBYQKSearch_WCRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtBYQKSearch_WCRQMin.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                        Me.txtBYQKSearch_WCRQMax.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    Else
                        Me.txtBYQKSearch_WCRQMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                        Me.txtBYQKSearch_WCRQMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    End If
                    If strQuery = "" Then
                        strQuery = strWCRQ + " between '" + Me.txtBYQKSearch_WCRQMin.Text + "' and '" + Me.txtBYQKSearch_WCRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " between '" + Me.txtBYQKSearch_WCRQMin.Text + "' and '" + Me.txtBYQKSearch_WCRQMax.Text + "'"
                    End If
                ElseIf Me.txtBYQKSearch_WCRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtBYQKSearch_WCRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtBYQKSearch_WCRQMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strWCRQ + " >= '" + Me.txtBYQKSearch_WCRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " >= '" + Me.txtBYQKSearch_WCRQMin.Text + "'"
                    End If
                ElseIf Me.txtBYQKSearch_WCRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtBYQKSearch_WCRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtBYQKSearch_WCRQMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strWCRQ + " <= '" + Me.txtBYQKSearch_WCRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " <= '" + Me.txtBYQKSearch_WCRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_BYQK = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdBYQKҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_BYQK( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            getModuleData_BYQK = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtBYQKSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                If Not (Me.m_objDataSet_BYQK Is Nothing) Then
                    Me.m_objDataSet_BYQK.Dispose()
                    Me.m_objDataSet_BYQK = Nothing
                End If

                '���¼�������
                If Me.m_objsystemFlowObject.getBuyueData(strErrMsg, Me.m_objInterface.iYjjhList, strWhere, Me.m_objDataSet_BYQK) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_BYQK.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_BYQK.Tables(strTable)
                    Me.htxtBYQKRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_BYQK = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_BYQK = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdBYQK����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_BYQK(ByRef strErrMsg As String) As Boolean

            searchModuleData_BYQK = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_BYQK(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_BYQK(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_BYQK = strQuery
                Me.htxtBYQKQuery.Value = Me.m_strQuery_BYQK

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_BYQK = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdBYQK������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_BYQK(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_BYQK = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtBYQKSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtBYQKSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_BYQK Is Nothing Then
                    Me.grdBYQK.DataSource = Nothing
                Else
                    With Me.m_objDataSet_BYQK.Tables(strTable)
                        Me.grdBYQK.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_BYQK.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdBYQK, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdBYQK)
                    With Me.grdBYQK.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdBYQK.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdBYQK, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_BYQK) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_BYQK = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdBYQK�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_BYQK(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_BYQK = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_BYQK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_BYQK.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblBYQKGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdBYQK, .Count)

                    '��ʾҳ���������
                    Me.lnkCZBYQKMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdBYQK, .Count)
                    Me.lnkCZBYQKMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdBYQK, .Count)
                    Me.lnkCZBYQKMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdBYQK, .Count)
                    Me.lnkCZBYQKMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdBYQK, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZBYQKDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZBYQKSelectAll.Enabled = blnEnabled
                    Me.lnkCZBYQKGotoPage.Enabled = blnEnabled
                    Me.lnkCZBYQKSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_BYQK = True
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
                    objControlProcess.doTranslateKey(Me.txtBYQKPageIndex)
                    objControlProcess.doTranslateKey(Me.txtBYQKPageSize)
                    objControlProcess.doTranslateKey(Me.txtBYQKSearch_FSR)
                    objControlProcess.doTranslateKey(Me.txtBYQKSearch_JSR)
                    objControlProcess.doTranslateKey(Me.txtBYQKSearch_BLSY)
                    objControlProcess.doTranslateKey(Me.txtBYQKSearch_WCRQMin)
                    objControlProcess.doTranslateKey(Me.txtBYQKSearch_WCRQMax)
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��ʾģ�鼶����
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ����
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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
                    If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]��[�ļ��������]��") = False Then
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
        'ʵ�ֶ�grdBYQK�����С��еĹ̶�
        Sub grdBYQK_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdBYQK.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_BYQK + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_BYQK > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_BYQK - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdBYQK.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdBYQK_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBYQK.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblBYQKGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdBYQK, Me.m_intRows_BYQK)
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

        Private Sub grdBYQK_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdBYQK.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

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
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_BYQK.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_BYQK.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtBYQKSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtBYQKSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtBYQKSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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




        Private Sub doMoveFirst_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdBYQK.PageCount)
                Me.grdBYQK.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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

        Private Sub doMoveLast_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBYQK.PageCount - 1, Me.grdBYQK.PageCount)
                Me.grdBYQK.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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

        Private Sub doMoveNext_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBYQK.CurrentPageIndex + 1, Me.grdBYQK.PageCount)
                Me.grdBYQK.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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

        Private Sub doMovePrevious_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBYQK.CurrentPageIndex - 1, Me.grdBYQK.PageCount)
                Me.grdBYQK.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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

        Private Sub doGotoPage_BYQK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtBYQKPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdBYQK.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_BYQK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtBYQKPageIndex.Text = (Me.grdBYQK.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_BYQK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtBYQKPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdBYQK.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_BYQK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtBYQKPageSize.Text = (Me.grdBYQK.PageSize).ToString()

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

        Private Sub doSelectAll_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdBYQK, 0, Me.m_cstrCheckBoxIdInDataGrid_BYQK, True) = False Then
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

        Private Sub doDeSelectAll_BYQK(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdBYQK, 0, Me.m_cstrCheckBoxIdInDataGrid_BYQK, False) = False Then
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

        Private Sub doSearch_BYQK(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_BYQK(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_BYQK(strErrMsg) = False Then
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

        Private Sub lnkCZBYQKMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKMoveFirst.Click
            Me.doMoveFirst_BYQK("lnkCZBYQKMoveFirst")
        End Sub

        Private Sub lnkCZBYQKMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKMoveLast.Click
            Me.doMoveLast_BYQK("lnkCZBYQKMoveLast")
        End Sub

        Private Sub lnkCZBYQKMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKMoveNext.Click
            Me.doMoveNext_BYQK("lnkCZBYQKMoveNext")
        End Sub

        Private Sub lnkCZBYQKMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKMovePrev.Click
            Me.doMovePrevious_BYQK("lnkCZBYQKMovePrev")
        End Sub

        Private Sub lnkCZBYQKGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKGotoPage.Click
            Me.doGotoPage_BYQK("lnkCZBYQKGotoPage")
        End Sub

        Private Sub lnkCZBYQKSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKSetPageSize.Click
            Me.doSetPageSize_BYQK("lnkCZBYQKSetPageSize")
        End Sub

        Private Sub lnkCZBYQKSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKSelectAll.Click
            Me.doSelectAll_BYQK("lnkCZBYQKSelectAll")
        End Sub

        Private Sub lnkCZBYQKDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBYQKDeSelectAll.Click
            Me.doDeSelectAll_BYQK("lnkCZBYQKDeSelectAll")
        End Sub

        Private Sub btnBYQKSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBYQKSearch.Click
            Me.doSearch_BYQK("btnBYQKSearch")
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

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            Try
                '��ȡ����
                If Me.getModuleData_BYQK(strErrMsg, Me.m_strQuery_BYQK) = False Then
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
                    .iQueryTable = Me.m_objDataSet_BYQK.Tables(strTable)
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
